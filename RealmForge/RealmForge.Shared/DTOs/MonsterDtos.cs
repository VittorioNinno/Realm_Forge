using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Texts of a statblock in one language. The lines (armor class, speed, saving throws, senses…) are text because
	///	each language writes them its own way (metres or feet, "armatura naturale"); traits, actions, bonus actions,
	///	reactions and legendary actions are Markdown (one paragraph per entry, "***Name.*** text").
	///	</summary>
	public class MonsterTextDto
	{
		public LanguageCode Language { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Alias { get; set; }

		//	"Drago Enorme, caotico malvagio"
		public string Subtitle { get; set; } = string.Empty;
		public string ArmorClass { get; set; } = string.Empty;
		public string Speed { get; set; } = string.Empty;
		public string SavingThrows { get; set; } = string.Empty;
		public string Skills { get; set; } = string.Empty;
		public string DamageVulnerabilities { get; set; } = string.Empty;
		public string DamageResistances { get; set; } = string.Empty;
		public string DamageImmunities { get; set; } = string.Empty;
		public string ConditionImmunities { get; set; } = string.Empty;
		public string Senses { get; set; } = string.Empty;
		public string Languages { get; set; } = string.Empty;
		public string Traits { get; set; } = string.Empty;
		public string Actions { get; set; } = string.Empty;
		public string BonusActions { get; set; } = string.Empty;
		public string Reactions { get; set; } = string.Empty;
		public string LegendaryActions { get; set; } = string.Empty;

		//	Description and lore (Markdown), shown under the statblock
		public string Description { get; set; } = string.Empty;

		//	NPC sheet: role ("Locandiere"), ancestry ("Nano delle colline"), personality (Markdown) and secrets (Markdown,
		//	empty for who cannot edit the character)
		public string Role { get; set; } = string.Empty;
		public string Ancestry { get; set; } = string.Empty;
		public string Personality { get; set; } = string.Empty;
		public string Secrets { get; set; } = string.Empty;
	}

	///	<summary>
	///	Monster in the localized list.
	///	</summary>
	public record MonsterResponseDto(
		Guid Id,
		string Name,
		string? Alias,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		CreatureSize Size,
		CreatureType Type,
		string Subtitle,
		int ArmorClass,
		int HitPoints,
		string HitDice,
		decimal ChallengeRating,
		int Xp,
		int Dexterity,
		Guid? VariantOfId,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public,
		bool IsNpc = false,

		//	NPC card: archetype, portrait (data URL), role, ancestry, the start of the personality, whether the account
		//	wrote it, and the first campaign of the account it is shared with
		NpcArchetype? Archetype = null,
		string? Portrait = null,
		string Role = "",
		string Ancestry = "",
		string Personality = "",
		bool IsMine = false,
		Guid? CampaignId = null,
		string? CampaignName = null
	);

	///	<summary>
	///	Statblock in one language. Abilities: Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma.
	///	VariantOfId is the monster this one was made from ("Crea variante").
	///	</summary>
	public record MonsterDetailDto(
		Guid Id,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		CreatureSize Size,
		CreatureType Type,
		int ArmorClass,
		int HitPoints,
		string HitDice,
		int Speed,
		List<int> Abilities,
		decimal ChallengeRating,
		int Xp,
		int ProficiencyBonus,
		int PassivePerception,
		Guid? VariantOfId,
		string? VariantOfName,
		MonsterTextDto Text,
		bool CanEdit = false,
		ContentSource? Source = null,
		ContentVisibility Visibility = ContentVisibility.Public,
		string? AuthorName = null,

		//	A nonplayer character (the NPC page), with its archetype and portrait
		bool IsNpc = false,
		NpcArchetype? Archetype = null,
		string? Portrait = null,
		bool IsMine = false,

		//	The campaigns of the account the character is shared with
		List<NpcCampaignDto>? Campaigns = null
	);

	///	<summary>
	///	A campaign an NPC is shared with (the link on its sheet).
	///	</summary>
	public record NpcCampaignDto(Guid Id, string Name);

	///	<summary>
	///	Homebrew monster on create and update (a variant of another monster carries its id in VariantOfId).
	///	</summary>
	public class SaveMonsterDto
	{
		public RulesetVersion Ruleset { get; set; } = RulesetVersion.Dnd5e_2014;
		public ContentVisibility Visibility { get; set; } = ContentVisibility.Private;
		public CreatureSize Size { get; set; } = CreatureSize.Medium;
		public CreatureType Type { get; set; } = CreatureType.Humanoid;
		public int ArmorClass { get; set; } = 10;
		public int HitPoints { get; set; } = 1;
		public string HitDice { get; set; } = string.Empty;

		//	Walking speed in feet (the text line says it in each language)
		public int Speed { get; set; } = 30;
		public List<int> Abilities { get; set; } = new() { 10, 10, 10, 10, 10, 10 };
		public decimal ChallengeRating { get; set; }
		public int Xp { get; set; }
		public int ProficiencyBonus { get; set; } = 2;
		public int PassivePerception { get; set; } = 10;
		public Guid? VariantOfId { get; set; }

		//	A nonplayer character: listed on the NPC page
		public bool IsNpc { get; set; }
		public NpcArchetype? Archetype { get; set; }

		//	Square JPEG as a data URL ("data:image/jpeg;base64,…"), null for none
		public string? Portrait { get; set; }
		public List<MonsterTextDto> Translations { get; set; } = new();
	}
}
