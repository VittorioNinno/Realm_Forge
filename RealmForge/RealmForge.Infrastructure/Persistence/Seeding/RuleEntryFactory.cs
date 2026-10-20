using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Builds a base glossary entry with its English and Italian texts, so the data files stay compact.
///	Ids: ForSrd(ruleset, "rule", key) and ForSrd(ruleset, "rule", key, "en"/"it").
///	</summary>
public static class RuleEntryFactory
{
	public const string Kind = "rule";

	public static RuleEntry Create(
		RulesetVersion ruleset,
		ContentSource source,
		string key,
		RuleCategory category,
		string[] related,
		(string Name, string Description, string[] Aliases) en,
		(string Name, string Description, string[] Aliases) it)
	{
		return new RuleEntry
		{
			Id = DeterministicGuid.ForSrd(ruleset, Kind, key),
			Ruleset = ruleset,
			IsOfficialSRD = true,
			Source = source,
			Key = key,
			Category = category,
			RelatedKeys = related.ToList(),
			Translations = new List<RuleEntryTranslation>
			{
				Translation(ruleset, key, LanguageCode.En, en),
				Translation(ruleset, key, LanguageCode.It, it)
			}
		};
	}

	private static RuleEntryTranslation Translation(RulesetVersion ruleset, string key, LanguageCode language, (string Name, string Description, string[] Aliases) text) => new()
	{
		Id = DeterministicGuid.ForSrd(ruleset, Kind, key, language == LanguageCode.En ? "en" : "it"),
		Language = language,
		Name = text.Name,
		Description = text.Description,
		Aliases = text.Aliases.ToList()
	};
}
