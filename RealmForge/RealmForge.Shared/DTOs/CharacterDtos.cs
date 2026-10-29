using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	A character as the wizard sends it: header (name, edition, origin) and every rules choice. The sheet state is
	///	only read on creation (personality and details written in the wizard); afterwards it has its own endpoint.
	///	</summary>
	public class SaveCharacterDto
	{
		public string Name { get; set; } = string.Empty;
		public RulesetVersion Ruleset { get; set; } = RulesetVersion.Dnd5e_2024;
		public Guid SpeciesId { get; set; }
		public Guid? SubspeciesId { get; set; }
		public Guid BackgroundId { get; set; }

		//	Language of the names of the free starting items (the rules never depend on it)
		public LanguageCode Language { get; set; } = LanguageCode.It;
		public CharacterBuild Build { get; set; } = new();
		public CharacterSheetState? Sheet { get; set; }

		//	Advancement type chosen in the wizard: applied to the sheet when creating and when editing
		public AdvancementType? Advancement { get; set; }
	}

	///	<summary>
	///	A character in the list of the owner ("Mago 3 / Guerriero 2").
	///	</summary>
	public record CharacterSummaryDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		int Level,
		string SpeciesName,
		string ClassLine,
		string BackgroundName,
		int MaxHitPoints,
		int CurrentHitPoints,
		int ArmorClass,
		DateTimeOffset UpdatedAt)
	{
		//	The portrait (a small square JPEG) and its framing, for the cards of the lists
		public string? Portrait { get; init; }
		public int? PortraitX { get; init; }
		public int? PortraitY { get; init; }

		//	The background, linked from the card
		public Guid BackgroundId { get; init; }

		//	The campaigns the character sits in (filled in the owner's list)
		public List<CharacterCampaignRefDto> Campaigns { get; init; } = new();
	}

	public record CharacterCampaignRefDto(Guid Id, string Name);

	///	<summary>
	///	A whole character: the client computes the sheet with <see cref="CharacterCalculator"/> and the context of
	///	its edition, in the reader's language.
	///	</summary>
	public record CharacterDto(
		Guid Id,
		string Name,
		RulesetVersion Ruleset,
		Guid SpeciesId,
		Guid? SubspeciesId,
		Guid BackgroundId,
		CharacterBuild Build,
		CharacterSheetState Sheet,
		int MaxHitPoints,
		int ArmorClass,
		DateTimeOffset CreatedAt,
		DateTimeOffset UpdatedAt,

		//	Opened by someone the owner shared it with: the sheet is shown but nothing is saved
		bool ReadOnly = false,

		//	Opened by a master or co-master of one of its campaigns: the sheet saves, OwnerName says whose it is
		bool IsOwner = true,
		string? OwnerName = null,

		//	Nickname of whoever saved it last, when it is someone else than the reader
		string? LastEditedBy = null,

		//	Campaigns the character takes part in (for its owner and the masters who opened it)
		List<Guid>? Campaigns = null);

	public record CharacterSavedDto(Guid Id, int MaxHitPoints, int ArmorClass, DateTimeOffset UpdatedAt);
}
