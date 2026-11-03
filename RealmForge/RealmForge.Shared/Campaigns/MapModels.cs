namespace RealmForge.Shared.Campaigns;

///	<summary>
///	What a token on the virtual tabletop stands for.
///	</summary>
public enum TokenKind
{
	Character = 1,
	Npc = 2,
	Monster = 3,
	Marker = 4
}

///	<summary>
///	Limits of the virtual tabletop: maps per campaign, tokens per map, the picture (a JPEG data URL), the grid.
///	</summary>
public static class MapRules
{
	public const int MaxMaps = 20;
	public const int MaxTokens = 200;
	public const int MaxImageLength = 4_000_000;
	public const int MaxImageSide = 4096;
	public const int MinGrid = 16;
	public const int MaxGrid = 300;
	public const int MaxTokenSize = 6;

	//	Cells across a map: the picture over the grid, at least one
	public static int Columns(int width, int grid, int offset) => Math.Max(1, (width - offset + grid - 1) / grid);

	public static int Rows(int height, int grid, int offset) => Math.Max(1, (height - offset + grid - 1) / grid);

	///	<summary>
	///	Who moves a token: the masters any token; a player only the token of a character they own, on a map shown to the
	///	table, when the token is not hidden.
	///	</summary>
	public static bool CanMove(CampaignRole role, bool ownsCharacter, bool mapShown, bool hidden) =>
		CampaignRules.RunsTheTable(role) || (ownsCharacter && mapShown && !hidden);
}
