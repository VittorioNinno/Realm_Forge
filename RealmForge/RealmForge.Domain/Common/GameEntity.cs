using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Common
{
	///	<summary>
	///	Base class of every game content entity (species, subspecies, traits, feats, backgrounds):
	///	ruleset, Base or Homebrew, author, text source and visibility. Localized texts live in a …Translation table.
	///	</summary>
	public abstract class GameEntity
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		//	Applicable ruleset version (defaulting to the modern 2024 revision)
		public RulesetVersion Ruleset { get; set; } = RulesetVersion.Dnd5e_2024;

		//	True for Base content (created by the seeders, read-only, text origin in Source), false for Homebrew.
		//	The name predates the RealmForge texts: Base content is not always SRD text
		public bool IsOfficialSRD { get; set; } = false;

		//	Identity user id of the Homebrew author; null for Base content and for Homebrew created before accounts existed
		public string? AuthorId { get; set; }

		//	Origin of the text for base content (null for Homebrew)
		public ContentSource? Source { get; set; }

		//	Homebrew sharing: public (listed), link (readable with the link) or private (author only)
		public ContentVisibility Visibility { get; set; } = ContentVisibility.Public;
	}
}