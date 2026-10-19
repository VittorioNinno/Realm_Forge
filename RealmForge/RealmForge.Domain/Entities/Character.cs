using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A player character: the choices made in the creation wizard (references to the compendium, scores, equipment
	///	and spells) plus the derived values computed when it is saved. Always private to its owner.
	///	</summary>
	public class Character
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		//	Identity user id of the owner
		public string OwnerId { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;
		public RulesetVersion Ruleset { get; set; } = RulesetVersion.Dnd5e_2024;
		public int Level { get; set; } = 1;
		public Alignment Alignment { get; set; } = Alignment.Neutral;

		//	Origin
		public Guid SpeciesId { get; set; }
		public Species Species { get; set; } = null!;
		public Guid? SubspeciesId { get; set; }
		public Subspecies? Subspecies { get; set; }
		public CreatureSize Size { get; set; } = CreatureSize.Medium;
		public Guid BackgroundId { get; set; }
		public Background Background { get; set; } = null!;
		public List<string> Languages { get; set; } = new();

		//	Class
		public Guid ClassId { get; set; }
		public CharacterClass Class { get; set; } = null!;
		public Guid? SubclassId { get; set; }
		public Subclass? Subclass { get; set; }
		public List<Skill> ClassSkills { get; set; } = new();

		//	Ability scores (Str, Dex, Con, Int, Wis, Cha)
		public AbilityMethod AbilityMethod { get; set; } = AbilityMethod.StandardArray;
		public List<int> BaseScores { get; set; } = new();
		public AbilityBonusMode BonusMode { get; set; } = AbilityBonusMode.TwoAndOne;
		public List<int> AbilityBonuses { get; set; } = new();

		//	Equipment choices (see SaveCharacterDto) and spells
		public string? BackgroundEquipment { get; set; }
		public List<string> ClassEquipment { get; set; } = new();
		public List<Guid> SpellIds { get; set; } = new();

		//	Derived values, computed by the API when the character is saved
		public int MaxHitPoints { get; set; }
		public int ArmorClass { get; set; }

		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	}
}
