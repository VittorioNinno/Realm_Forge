using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A Homebrew rule module: house rules written as data (an extra ability like Fortuna, a resource, bonuses,
	///	training, defences), applied to the characters that choose it and to the characters of the campaigns that
	///	share it. Effects is the JSON of the RuleEffect list (RealmForge.Shared.Characters). Modules hold for both
	///	editions; Ruleset is the one it was written for.
	///	</summary>
	public class RuleModule : GameEntity
	{
		public string Effects { get; set; } = "[]";
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

		public ICollection<RuleModuleTranslation> Translations { get; set; } = new List<RuleModuleTranslation>();
	}

	public class RuleModuleTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid RuleModuleId { get; set; }
		public RuleModule RuleModule { get; set; } = null!;

		public LanguageCode Language { get; set; }

		public string Name { get; set; } = string.Empty;

		//	Markdown: what the module is for and how the table uses it
		public string Description { get; set; } = string.Empty;
	}
}
