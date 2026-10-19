using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Synchronizes the base equipment with the database (same rules as SpellSeeder): missing items are inserted,
///	existing base items are updated to match their definition, Homebrew is never touched.
///	One file per section and edition in the EquipmentData folder, exposing <c>public static IEnumerable&lt;Equipment&gt; Build()</c>,
///	with ids from DeterministicGuid (e.g. ForSrd(Dnd5e_2024, "equipment", "longsword", "it")).
///	</summary>
public static class EquipmentSeeder
{
	public const string DataNamespace = "RealmForge.Infrastructure.Persistence.Seeding.EquipmentData";

	public static IReadOnlyList<Equipment> GetDefinitions()
	{
		var definitions = typeof(EquipmentSeeder).Assembly.GetTypes()
			.Where(t => t.Namespace == DataNamespace && t.IsAbstract && t.IsSealed)
			.OrderBy(t => t.Name, StringComparer.Ordinal)
			.Select(t => t.GetMethod("Build", BindingFlags.Public | BindingFlags.Static, Type.EmptyTypes))
			.Where(m => m is not null && typeof(IEnumerable<Equipment>).IsAssignableFrom(m.ReturnType))
			.SelectMany(m => (IEnumerable<Equipment>)m!.Invoke(null, null)!)
			.ToList();

		foreach (var definition in definitions)
		{
			definition.IsOfficialSRD = true;
			definition.Source ??= ContentSource.RealmForge;
		}

		EnsureUniqueIds(definitions);
		return definitions;
	}

	public static void EnsureUniqueIds(IEnumerable<Equipment> definitions)
	{
		var ids = definitions.SelectMany(e => e.Translations.Select(t => t.Id).Prepend(e.Id)).ToList();
		var duplicates = ids.GroupBy(id => id).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

		if (duplicates.Count > 0)
		{
			throw new InvalidOperationException($"Duplicate ids in equipment seed data: [{string.Join(", ", duplicates)}]");
		}
	}

	public static async Task SeedAsync(RealmForgeDbContext context, CancellationToken cancellationToken = default)
	{
		var definitions = GetDefinitions();
		if (definitions.Count == 0)
		{
			return;
		}

		var ids = definitions.Select(d => d.Id).ToList();
		var existing = await context.Equipment
			.Include(e => e.Translations)
			.Where(e => ids.Contains(e.Id))
			.AsSplitQuery()
			.ToDictionaryAsync(e => e.Id, cancellationToken);

		foreach (var definition in definitions)
		{
			if (!existing.TryGetValue(definition.Id, out var item))
			{
				context.Equipment.Add(definition);
				continue;
			}

			//	Never overwrite user content, even in the unlikely case of an id clash
			if (!item.IsOfficialSRD)
			{
				continue;
			}

			CopyMechanics(definition, item);

			foreach (var source in definition.Translations)
			{
				var target = item.Translations.FirstOrDefault(t => t.Language == source.Language);

				if (target is null)
				{
					//	New rows with preset Guid keys are added through the context (see FeatSeeder)
					context.EquipmentTranslations.Add(new EquipmentTranslation
					{
						Id = source.Id,
						EquipmentId = item.Id,
						Language = source.Language
					});
					target = context.EquipmentTranslations.Local.First(t => t.Id == source.Id);
				}

				target.Name = source.Name;
				target.Description = source.Description;
			}
		}

		await context.SaveChangesAsync(cancellationToken);
	}

	///	<summary>
	///	Copies every structured field (not the translations) from one item to another.
	///	</summary>
	public static void CopyMechanics(Equipment from, Equipment to)
	{
		to.Ruleset = from.Ruleset;
		to.Source = from.Source;
		to.Category = from.Category;
		to.CostInCopper = from.CostInCopper;
		to.WeightInPounds = from.WeightInPounds;
		to.Quantity = from.Quantity;
		to.WeaponCategory = from.WeaponCategory;
		to.WeaponRange = from.WeaponRange;
		to.DamageDice = from.DamageDice;
		to.DamageType = from.DamageType;
		to.VersatileDamageDice = from.VersatileDamageDice;
		to.WeaponProperties = from.WeaponProperties.ToList();
		to.NormalRange = from.NormalRange;
		to.LongRange = from.LongRange;
		to.Mastery = from.Mastery;
		to.ArmorCategory = from.ArmorCategory;
		to.ArmorClass = from.ArmorClass;
		to.ArmorAddsDexterity = from.ArmorAddsDexterity;
		to.ArmorMaxDexterityBonus = from.ArmorMaxDexterityBonus;
		to.StrengthRequirement = from.StrengthRequirement;
		to.StealthDisadvantage = from.StealthDisadvantage;
		to.ToolCategory = from.ToolCategory;
		to.ToolAbility = from.ToolAbility;
		to.FocusType = from.FocusType;
		to.SpeedInFeet = from.SpeedInFeet;
		to.SpeedInMilesPerHour = from.SpeedInMilesPerHour;
		to.CarryingCapacityInPounds = from.CarryingCapacityInPounds;
	}
}
