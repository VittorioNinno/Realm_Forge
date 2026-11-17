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
		List<Guid>? Campaigns = null,

		//	Rule modules the campaigns of the character make active for it (shared with the table and approved)
		List<Guid>? CampaignModuleIds = null);

	public record CharacterSavedDto(Guid Id, int MaxHitPoints, int ArmorClass, DateTimeOffset UpdatedAt, SheetVitalsDto? Vitals = null);

	///	<summary>
	///	What an encounter shares with the sheet: hit points, temporary hit points, conditions, exhaustion, concentration
	///	and death saves, with the stamp of the last change made from an encounter.
	///	</summary>
	public record SheetVitalsDto(int VitalsStamp, int? CurrentHitPoints, int TemporaryHitPoints, List<string> Conditions, int Exhaustion,
		Guid? Concentration, int DeathSaveSuccesses, int DeathSaveFailures, int MaxHitPoints, DateTimeOffset UpdatedAt, string? UpdatedBy = null)
	{
		public static SheetVitalsDto From(CharacterSheetState s, int maxHitPoints, DateTimeOffset updatedAt, string? updatedBy = null) =>
			new(s.VitalsStamp, s.CurrentHitPoints, s.TemporaryHitPoints, s.Conditions.ToList(), s.Exhaustion, s.Concentration,
				s.DeathSaveSuccesses, s.DeathSaveFailures, maxHitPoints, updatedAt, updatedBy);

		public void ApplyTo(CharacterSheetState s)
		{
			s.VitalsStamp = VitalsStamp;
			s.CurrentHitPoints = CurrentHitPoints;
			s.TemporaryHitPoints = TemporaryHitPoints;
			s.Conditions = Conditions.ToList();
			s.Exhaustion = Exhaustion;
			s.Concentration = Concentration;
			s.DeathSaveSuccesses = DeathSaveSuccesses;
			s.DeathSaveFailures = DeathSaveFailures;
		}
	}
}

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	A character as a file to keep or to move to another RealmForge: its choices (the build) and its play state (the
	///	sheet), with the format and the version of the file. The species, background, classes and the rest are named by
	///	their ids: Base content has the same ids on every RealmForge, Homebrew must be there too (exported with it).
	///	</summary>
	public class CharacterExportDto
	{
		public const string FormatName = "realmforge.character";
		public const int CurrentVersion = 1;

		public string Format { get; set; } = FormatName;
		public int Version { get; set; } = CurrentVersion;
		public DateTimeOffset ExportedAt { get; set; } = DateTimeOffset.UtcNow;
		public string Name { get; set; } = string.Empty;
		public RulesetVersion Ruleset { get; set; }
		public Guid SpeciesId { get; set; }
		public Guid? SubspeciesId { get; set; }
		public Guid BackgroundId { get; set; }
		public CharacterBuild Build { get; set; } = new();
		public CharacterSheetState Sheet { get; set; } = new();
	}
}

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Homebrew as a file to keep or to move to another RealmForge: entries (a spell, a class with its features and
	///	subclasses, a monster…), each as the rows of its tables. Imported, each becomes a new private entry of the account.
	///	</summary>
	public class HomebrewExportDto
	{
		public const string FormatName = "realmforge.homebrew";
		public const int CurrentVersion = 1;

		public string Format { get; set; } = FormatName;
		public int Version { get; set; } = CurrentVersion;
		public DateTimeOffset ExportedAt { get; set; } = DateTimeOffset.UtcNow;
		public List<HomebrewExportItemDto> Items { get; set; } = new();
	}

	public class HomebrewExportItemDto
	{
		public string Kind { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public List<System.Text.Json.JsonElement> Rows { get; set; } = new();
	}

	//	What to put in a file: entries by kind and id
	public class HomebrewExportRequestDto
	{
		public List<HomebrewRefDto> Entries { get; set; } = new();
	}

	public record HomebrewRefDto(string Kind, Guid Id);

	//	An entry of the account's Homebrew: where it opens, its edition and visibility, the languages it is written in
	public record MyHomebrewDto(string Kind, Guid Id, string Name, string Link, RulesetVersion Ruleset, ContentVisibility Visibility, List<LanguageCode> Languages);

	//	An entry imported (its link to open it), or one that could not be (what it needs and is missing here)
	public record HomebrewImportedDto(string Kind, string Name, Guid? Id, string? Link, string? Missing);
}
