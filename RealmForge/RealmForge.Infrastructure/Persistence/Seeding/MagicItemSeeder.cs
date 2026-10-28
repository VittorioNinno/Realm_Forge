using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Synchronizes the base magic items with the database (same rules as SpellSeeder): missing items are inserted,
///	existing base items are updated to match their definition, Homebrew is never touched. One file per item in the
///	MagicItemsData folder, exposing <c>public static IEnumerable&lt;MagicItem&gt; Build()</c> (the item, then its
///	variants), with ids from DeterministicGuid (ForSrd(Dnd5e_2014, "magic-item", "bag-of-holding", "it")).
///	</summary>
public static class MagicItemSeeder
{
	public const string DataNamespace = "RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData";

	//	Same JSON shape the API reads back (MagicItemProperties)
	public static readonly JsonSerializerOptions MechanicsJson = new(JsonSerializerDefaults.Web);

	public static IReadOnlyList<MagicItem> GetDefinitions()
	{
		var definitions = typeof(MagicItemSeeder).Assembly.GetTypes()
			.Where(t => t.Namespace == DataNamespace && t.IsAbstract && t.IsSealed)
			.Select(t => t.GetMethod("Build", BindingFlags.Public | BindingFlags.Static, Type.EmptyTypes))
			.Where(m => m is not null && m.ReturnType == typeof(IEnumerable<MagicItem>))
			.SelectMany(m => (IEnumerable<MagicItem>)m!.Invoke(null, null)!)
			.ToList();

		var ids = definitions.SelectMany(s => s.Translations.Select(t => t.Id).Prepend(s.Id)).ToList();
		var duplicates = ids.GroupBy(id => id).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
		if (duplicates.Count > 0)
		{
			throw new InvalidOperationException($"Duplicate ids in magic item seed data: [{string.Join(", ", duplicates)}]");
		}
		return definitions;
	}

	///	<summary>
	///	A base item (parent null) or a variant of the 2014 rules, with its Italian and English texts.
	///	</summary>
	public static MagicItem Item(
		string key, string? parentKey, int order, MagicItemType type, ItemRarity? rarity, bool attunement, ContentSource source,
		MagicItemProperties? mechanics,
		(string Name, string Subtitle, string Description) it,
		(string Name, string Subtitle, string Description, string? Alias) en)
	{
		var ruleset = RulesetVersion.Dnd5e_2014;
		var id = DeterministicGuid.ForSrd(ruleset, "magic-item", key);
		return new MagicItem
		{
			Id = id,
			Ruleset = ruleset,
			IsOfficialSRD = true,
			Source = source,
			Type = type,
			Rarity = rarity,
			RequiresAttunement = attunement,
			Mechanics = mechanics is null ? null : JsonSerializer.Serialize(mechanics, MechanicsJson),
			ParentId = parentKey is null ? null : DeterministicGuid.ForSrd(ruleset, "magic-item", parentKey),
			SortOrder = order,
			Translations = new List<MagicItemTranslation>
			{
				new()
				{
					Id = DeterministicGuid.ForSrd(ruleset, "magic-item", key, "it"),
					Language = LanguageCode.It,
					Name = it.Name,
					Subtitle = it.Subtitle,
					Description = it.Description
				},
				new()
				{
					Id = DeterministicGuid.ForSrd(ruleset, "magic-item", key, "en"),
					Language = LanguageCode.En,
					Name = en.Name,
					Subtitle = en.Subtitle,
					Description = en.Description,
					Alias = en.Alias
				}
			}
		};
	}

	//	Short builders for the data files
	public static MagicItemProperties Magic(params MagicEffect[] effects) => new() { Effects = effects.ToList() };

	public static MagicItemProperties Charges(int charges, ItemRecharge recharge, string? dice, params MagicEffect[] effects) => new()
	{
		Charges = charges,
		Recharge = recharge,
		RechargeDice = dice,
		Effects = effects.ToList()
	};

	public static MagicItemProperties Heal(string dice) => new() { HealDice = dice };

	public static MagicEffect Effect(MagicEffectKind kind, int value) => new() { Kind = kind, Value = value };

	public static MagicEffect Ability(MagicEffectKind kind, int value, AbilityScore ability) => new() { Kind = kind, Value = value, Ability = ability };

	public static MagicEffect Resist(DamageType type) => new() { Kind = MagicEffectKind.Resistance, DamageType = type };

	public static async Task SeedAsync(RealmForgeDbContext context, CancellationToken cancellationToken = default)
	{
		var definitions = GetDefinitions();
		if (definitions.Count == 0)
		{
			return;
		}

		var ids = definitions.Select(d => d.Id).ToList();
		var existing = await context.MagicItems
			.Include(s => s.Translations)
			.Where(s => ids.Contains(s.Id))
			.AsSplitQuery()
			.ToDictionaryAsync(s => s.Id, cancellationToken);

		//	Parents first, so that the variants find them
		foreach (var definition in definitions.OrderBy(d => d.ParentId is null ? 0 : 1))
		{
			if (!existing.TryGetValue(definition.Id, out var item))
			{
				context.MagicItems.Add(definition);
				continue;
			}

			//	Never overwrite user content, even in the unlikely case of an id clash
			if (!item.IsOfficialSRD)
			{
				continue;
			}

			item.Ruleset = definition.Ruleset;
			item.Source = definition.Source;
			item.Type = definition.Type;
			item.Rarity = definition.Rarity;
			item.RequiresAttunement = definition.RequiresAttunement;
			item.Mechanics = definition.Mechanics;
			item.ParentId = definition.ParentId;
			item.SortOrder = definition.SortOrder;

			foreach (var source in definition.Translations)
			{
				var target = item.Translations.FirstOrDefault(t => t.Language == source.Language);

				if (target is null)
				{
					//	New rows with preset Guid keys are added through the context (see FeatSeeder)
					context.MagicItemTranslations.Add(new MagicItemTranslation
					{
						Id = source.Id,
						MagicItemId = item.Id,
						Language = source.Language
					});
					target = context.MagicItemTranslations.Local.First(t => t.Id == source.Id);
				}

				target.Name = source.Name;
				target.Subtitle = source.Subtitle;
				target.Description = source.Description;
				target.Alias = source.Alias;
			}
		}

		await context.SaveChangesAsync(cancellationToken);
	}
}
