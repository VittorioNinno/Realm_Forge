using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	Entry of the rules glossary (conditions, actions, areas of effect and the other rules terms of an edition).
	///	Its terms are linked, with a tooltip, in the descriptions of the other modules.
	///	</summary>
	public class RuleEntry : GameEntity
	{
		//	Stable slug within the edition (e.g. "prone", "opportunity-attacks")
		public string Key { get; set; } = string.Empty;

		public RuleCategory Category { get; set; } = RuleCategory.Rule;

		//	Keys of the entries of the same edition listed under "See also"
		public List<string> RelatedKeys { get; set; } = new();

		//	Collection of localized texts for this entry
		public ICollection<RuleEntryTranslation> Translations { get; set; } = new List<RuleEntryTranslation>();
	}

	///	<summary>
	///	Texts of a glossary entry in one language (unique per entry and language).
	///	</summary>
	public class RuleEntryTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid RuleEntryId { get; set; }
		public RuleEntry RuleEntry { get; set; } = null!;

		public LanguageCode Language { get; set; }

		//	Localized fields
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		//	Forms of the term recognised in the descriptions of the other modules (e.g. "prono", "prona", "proni", "prone").
		//	Case-insensitive; "=Term" matches only with that exact case, "~regex" is a regular expression. Empty: never linked
		public List<string> Aliases { get; set; } = new();
	}
}
