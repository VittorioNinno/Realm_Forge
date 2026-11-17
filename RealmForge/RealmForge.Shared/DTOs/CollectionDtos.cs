using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	A collection of the author's Homebrew: its link code and the entries in it.
	///	</summary>
	public record ContentCollectionSummaryDto(Guid Id, string Name, string Description, string Code, List<Guid> EntityIds, DateTimeOffset UpdatedAt);

	public class SaveContentCollectionDto
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public List<Guid> EntityIds { get; set; } = new();
	}

	//	A collection as its link shows it, with the entries the reader can open
	public record ContentCollectionDto(Guid Id, string Name, string Description, string Code, string Author, bool IsMine, List<ContentCollectionEntryDto> Entries);

	public record ContentCollectionEntryDto(Guid Id, string Kind, string Name, string Link, RulesetVersion Ruleset);

	//	A collection switched on in a campaign: how many entries, who did it, whether the reader can switch it off
	public record CampaignCollectionDto(Guid Id, string Name, int Count, string EnabledBy, bool CanRemove);

	public class EnableCollectionDto
	{
		public string Code { get; set; } = string.Empty;
	}

	//	Switched on: the entries added, those left out (another edition, already there by another way do not count), and their status
	public record CampaignCollectionAddedDto(Guid Id, string Name, int Added, int Skipped, CampaignContentStatus Status);
}

namespace RealmForge.Shared.DTOs
{
	//	The entry of the other edition that corresponds to one (2014 ↔ 2024)
	public record ContentEquivalentDto(string Kind, Guid Id, string Name, string Link, RulesetVersion Ruleset);
}
