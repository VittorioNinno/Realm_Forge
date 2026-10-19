using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Synchronizes the Base classes and subclasses (with their features) with the database, like the other seeders:
///	missing rows are inserted, existing Base rows are updated to match the seed, Base features and subclasses no longer in
///	the seed are removed. Homebrew is never touched, including Homebrew subclasses of Base classes.
///	One file per class (<c>public static CharacterClass Build()</c>) and one per subclass (<c>public static Subclass Build()</c>)
///	in the ClassesData folder, with ids from DeterministicGuid (e.g. ForSrd(Dnd5e_2014, "class", "wizard")).
///	</summary>
public static class ClassSeeder
{
	public const string DataNamespace = "RealmForge.Infrastructure.Persistence.Seeding.ClassesData";

	public static IReadOnlyList<CharacterClass> GetClassDefinitions() => Discover<CharacterClass>();

	public static IReadOnlyList<Subclass> GetSubclassDefinitions() => Discover<Subclass>();

	private static List<T> Discover<T>() =>
		typeof(ClassSeeder).Assembly.GetTypes()
			.Where(t => t.Namespace == DataNamespace && t.IsAbstract && t.IsSealed)
			.Select(t => t.GetMethod("Build", BindingFlags.Public | BindingFlags.Static, Type.EmptyTypes))
			.Where(m => m is not null && m.ReturnType == typeof(T))
			.OrderBy(m => m!.DeclaringType!.Name)
			.Select(m => (T)m!.Invoke(null, null)!)
			.ToList();

	public static void EnsureUniqueIds(IEnumerable<CharacterClass> classes, IEnumerable<Subclass> subclasses)
	{
		var ids = new List<Guid>();

		foreach (var c in classes)
		{
			ids.Add(c.Id);
			ids.AddRange(c.Translations.Select(t => t.Id));
			AddFeatureIds(ids, c.Features);
		}

		foreach (var s in subclasses)
		{
			ids.Add(s.Id);
			ids.AddRange(s.Translations.Select(t => t.Id));
			AddFeatureIds(ids, s.Features);
		}

		var duplicates = ids.GroupBy(id => id).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
		if (duplicates.Count > 0)
		{
			throw new InvalidOperationException($"Duplicate ids in class seed data: [{string.Join(", ", duplicates)}]");
		}
	}

	private static void AddFeatureIds(List<Guid> ids, IEnumerable<ClassFeature> features)
	{
		foreach (var f in features)
		{
			ids.Add(f.Id);
			ids.AddRange(f.Translations.Select(t => t.Id));
		}
	}

	public static async Task SeedAsync(RealmForgeDbContext context, CancellationToken cancellationToken = default)
	{
		var classes = GetClassDefinitions().ToList();
		var subclasses = GetSubclassDefinitions().ToList();
		if (classes.Count == 0)
		{
			return;
		}

		EnsureUniqueIds(classes, subclasses);
		AssignInheritedData(classes, subclasses);

		var classIds = classes.Select(c => c.Id).ToList();
		var existingClasses = await context.Classes
			.Include(c => c.Translations)
			.Include(c => c.Features).ThenInclude(f => f.Translations)
			.Include(c => c.Subclasses).ThenInclude(s => s.Translations)
			.Include(c => c.Subclasses).ThenInclude(s => s.Features).ThenInclude(f => f.Translations)
			.AsSplitQuery()
			.Where(c => classIds.Contains(c.Id))
			.ToDictionaryAsync(c => c.Id, cancellationToken);

		foreach (var definition in classes)
		{
			var classSubclasses = subclasses.Where(s => s.CharacterClassId == definition.Id).ToList();

			if (!existingClasses.TryGetValue(definition.Id, out var current))
			{
				foreach (var sub in classSubclasses)
				{
					definition.Subclasses.Add(sub);
				}

				context.Classes.Add(definition);
				continue;
			}

			//	Never overwrite user content, even in the unlikely case of an id clash
			if (!current.IsOfficialSRD)
			{
				continue;
			}

			current.Ruleset = definition.Ruleset;
			current.Source = definition.Source;
			current.HitDie = definition.HitDie;
			current.PrimaryAbilities = definition.PrimaryAbilities;
			current.SavingThrows = definition.SavingThrows;
			current.SkillChoiceCount = definition.SkillChoiceCount;
			current.SkillOptions = definition.SkillOptions;
			current.CasterProgression = definition.CasterProgression;
			current.SpellcastingAbility = definition.SpellcastingAbility;
			current.SubclassLevel = definition.SubclassLevel;

			foreach (var tr in definition.Translations)
			{
				var currentTr = current.Translations.FirstOrDefault(t => t.Language == tr.Language);
				if (currentTr is null)
				{
					tr.CharacterClassId = current.Id;
					context.ClassTranslations.Add(tr);
					continue;
				}

				currentTr.Name = tr.Name;
				currentTr.Description = tr.Description;
				currentTr.SubclassTitle = tr.SubclassTitle;
				currentTr.ArmorProficiencies = tr.ArmorProficiencies;
				currentTr.WeaponProficiencies = tr.WeaponProficiencies;
				currentTr.ToolProficiencies = tr.ToolProficiencies;
				currentTr.StartingEquipment = tr.StartingEquipment;
				currentTr.ProgressionTable = tr.ProgressionTable;
			}

			SyncFeatures(context, current.Features, definition.Features, f => f.CharacterClassId = current.Id);
			SyncSubclasses(context, current, classSubclasses);
		}

		//	Single transaction: either the whole Base set is synchronized or nothing changes
		await context.SaveChangesAsync(cancellationToken);
	}

	//	Features and subclasses inherit ruleset and source from their owner when the seed leaves them unset
	private static void AssignInheritedData(List<CharacterClass> classes, List<Subclass> subclasses)
	{
		foreach (var c in classes)
		{
			c.Source ??= ContentSource.RealmForge;
			c.IsOfficialSRD = true;

			foreach (var f in c.Features)
			{
				f.Ruleset = c.Ruleset;
				f.Source ??= c.Source;
				f.IsOfficialSRD = true;
			}
		}

		foreach (var s in subclasses)
		{
			s.Source ??= ContentSource.RealmForge;
			s.IsOfficialSRD = true;

			foreach (var f in s.Features)
			{
				f.Ruleset = s.Ruleset;
				f.Source ??= s.Source;
				f.IsOfficialSRD = true;
			}
		}
	}

	private static void SyncSubclasses(RealmForgeDbContext context, CharacterClass target, List<Subclass> source)
	{
		var sourceIds = source.Select(s => s.Id).ToHashSet();

		//	Base subclasses removed from the seed are deleted with their features; Homebrew subclasses stay
		foreach (var stale in target.Subclasses.Where(s => s.IsOfficialSRD && !sourceIds.Contains(s.Id)).ToList())
		{
			context.ClassFeatures.RemoveRange(stale.Features);
			context.Subclasses.Remove(stale);
		}

		foreach (var sub in source)
		{
			var current = target.Subclasses.FirstOrDefault(s => s.Id == sub.Id);
			if (current is null)
			{
				//	New rows with preset Guid keys must be added through the context, otherwise EF treats them as existing
				sub.CharacterClassId = target.Id;
				context.Subclasses.Add(sub);
				continue;
			}

			current.Ruleset = sub.Ruleset;
			current.Source = sub.Source;
			current.CasterProgression = sub.CasterProgression;
			current.SpellcastingAbility = sub.SpellcastingAbility;

			foreach (var tr in sub.Translations)
			{
				var currentTr = current.Translations.FirstOrDefault(t => t.Language == tr.Language);
				if (currentTr is null)
				{
					tr.SubclassId = current.Id;
					context.SubclassTranslations.Add(tr);
				}
				else
				{
					currentTr.Name = tr.Name;
					currentTr.Description = tr.Description;
				}
			}

			SyncFeatures(context, current.Features, sub.Features, f => f.SubclassId = current.Id);
		}
	}

	private static void SyncFeatures(RealmForgeDbContext context, ICollection<ClassFeature> target, ICollection<ClassFeature> source, Action<ClassFeature> attach)
	{
		var sourceIds = source.Select(f => f.Id).ToHashSet();

		//	Explicit delete: features have nullable owner keys, so removing them from the collection alone would orphan them
		foreach (var stale in target.Where(f => f.IsOfficialSRD && !sourceIds.Contains(f.Id)).ToList())
		{
			context.ClassFeatures.Remove(stale);
		}

		foreach (var feature in source)
		{
			var current = target.FirstOrDefault(f => f.Id == feature.Id);
			if (current is null)
			{
				attach(feature);
				context.ClassFeatures.Add(feature);
				continue;
			}

			current.Ruleset = feature.Ruleset;
			current.Source = feature.Source;
			current.Level = feature.Level;
			current.SortOrder = feature.SortOrder;

			foreach (var tr in feature.Translations)
			{
				var currentTr = current.Translations.FirstOrDefault(t => t.Language == tr.Language);
				if (currentTr is null)
				{
					tr.ClassFeatureId = current.Id;
					context.ClassFeatureTranslations.Add(tr);
				}
				else
				{
					currentTr.Name = tr.Name;
					currentTr.Description = tr.Description;
				}
			}
		}
	}
}
