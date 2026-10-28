using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A player character. The columns hold what lists and links need (owner, name, edition, level, origin, starting
	///	class and the derived values shown in the list); every rules choice is in <see cref="Build"/> and the play state
	///	(hit points, resources, inventory, notes) in <see cref="Sheet"/>, both JSON documents
	///	(RealmForge.Shared.Characters). Private to its owner, readable by the accounts it is shared with, and editable
	///	by the masters and co-masters of the campaigns it takes part in.
	///	</summary>
	public class Character
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		//	Identity user id of the owner
		public string OwnerId { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;
		public RulesetVersion Ruleset { get; set; } = RulesetVersion.Dnd5e_2024;
		public int Level { get; set; } = 1;

		public Guid SpeciesId { get; set; }
		public Species Species { get; set; } = null!;
		public Guid? SubspeciesId { get; set; }
		public Subspecies? Subspecies { get; set; }
		public Guid BackgroundId { get; set; }
		public Background Background { get; set; } = null!;

		//	Starting class (level 1)
		public Guid ClassId { get; set; }
		public CharacterClass Class { get; set; } = null!;

		//	CharacterBuild and CharacterSheetState as JSON (jsonb)
		public string Build { get; set; } = "{}";
		public string Sheet { get; set; } = "{}";

		//	Derived values, computed by the API when the character is saved
		public int MaxHitPoints { get; set; }
		public int ArmorClass { get; set; }

		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

		//	Who saved it last: the owner, or a master of one of its campaigns (shown on the sheet); null before campaigns
		public string? UpdatedById { get; set; }
	}
}
