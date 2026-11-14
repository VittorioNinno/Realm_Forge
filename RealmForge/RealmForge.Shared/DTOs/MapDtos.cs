using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	A map in the list of the campaign (without its picture).
	///	</summary>
	public record CampaignMapSummaryDto(Guid Id, string Name, bool Shown, int Width, int Height, DateTimeOffset UpdatedAt);

	///	<summary>
	///	A token as the table sees it: CanMove when the account can drag it; Portrait for a character with one.
	///	</summary>
	public record MapTokenDto(
		Guid Id,
		string Label,
		string Color,
		TokenKind Kind,
		Guid? CharacterId,
		Guid? MonsterId,
		int X,
		int Y,
		int Size,
		bool Hidden,
		bool CanMove,
		string? Portrait = null,
		TokenLayer Layer = TokenLayer.Tokens,
		Guid? CombatantId = null,
		List<string>? Conditions = null,

		//	Hit points of a monster in the fight, for the masters; its health, for the players
		int? Hp = null,
		int? MaxHp = null,
		CombatantHealth? Health = null,

		//	The players a master lets move it (sent to the masters only)
		List<string>? ControlledBy = null,
		PropType? PropType = null,
		PropState PropState = PropState.Closed,
		bool PlayersInteract = false,
		Guid? ImageId = null,

		//	Temporary hit points (to the masters and to whoever controls the token)
		int? TempHp = null,

		//	The account controls it (its character, or given by a master): hit points, ring and sheet are theirs too
		bool Controlled = false,

		//	A copy of a character (an NPC using its sheet); hit points the players may see; the armour class set at the
		//	table; what kind of creature a monster is (for the players' pop-up)
		Guid? SheetCharacterId = null,
		bool ShowHp = false,
		int? ArmorClass = null,
		CreatureSize? CreatureSize = null,
		CreatureType? CreatureType = null,

		//	What it carries (see TokenGearDto), and what was spent of its turn in the fight (attack, other, reaction)
		TokenGearDto? Gear = null,
		string? ActionSpent = null,
		bool ReactionUsed = false,

		//	A character's hit points from its sheet now (everyone at the table sees them), so a hit shows on every screen
		int? SheetHp = null,
		int? SheetMaxHp = null,
		int? SheetTempHp = null,
		TokenTurnDto? Turn = null);

	///	<summary>
	///	The fight on a map: the encounter, the round, whose turn it is and the initiative order (what the players see of it).
	///	</summary>
	public record MapCombatDto(Guid EncounterId, string Name, int Round, Guid? CurrentId, List<MapCombatantDto> Order, bool ShowHealth = false);

	public record MapCombatantDto(Guid Id, string Name, CombatantKind Kind, int? Initiative, Guid? TokenId, bool Hidden, int InitiativeBonus = 0);

	public class CombatHealthDto
	{
		public bool Show { get; set; }
	}

	//	A box of the map (pixels of the picture): what is erased in it
	public class EraseAreaDto
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }
	}

	public class StartCombatDto
	{
		public Guid EncounterId { get; set; }
	}

	public class QuickCombatDto
	{
		public List<Guid> TokenIds { get; set; } = new();
	}

	public class SetInitiativeDto
	{
		public Guid CombatantId { get; set; }
		public int Initiative { get; set; }
	}

	public class TokenStateDto
	{
		public List<string> Conditions { get; set; } = new();
		public int? Hp { get; set; }
		public int? TempHp { get; set; }

		//	A new maximum (a token outside a fight)
		public int? MaxHp { get; set; }

		//	Masters only: the hit points shown to the players; the armour class (0 or less: the statblock's again)
		public bool? ShowHp { get; set; }
		public int? ArmorClass { get; set; }
	}

	///	<summary>
	///	An attack from a token at another token: the attack as the attacker's sheet or statblock has it (bonus, damage,
	///	how far it reaches in cells), the advantage or disadvantage chosen by hand, a condition the hit imposes. The
	///	server rolls it against the target's armour class (which the players do not see) and applies the damage.
	///	</summary>
	public class MapAttackDto
	{
		public Guid AttackerId { get; set; }
		public Guid TargetId { get; set; }
		public string Name { get; set; } = string.Empty;
		public int Bonus { get; set; }
		public string? Damage { get; set; }
		public string? DamageType { get; set; }
		public int Reach { get; set; } = 1;
		public int Range { get; set; }
		public int LongRange { get; set; }
		public int Mode { get; set; }
		public string? Condition { get; set; }

		//	A character's attacks with one Attack action (Extra Attack); null: not counted
		public int? ActionAttacks { get; set; }
	}

	///	<summary>
	///	What a token did with its turn: an action (dash, disengage, dodge, help, hide, ready, search, other), a bonus action
	///	(bonus), the weapon taken in hand (wield: melee or ranged), an attack of opportunity let go (pass).
	///	</summary>
	public class TurnActionDto
	{
		public string Kind { get; set; } = string.Empty;
		public string? Wield { get; set; }
	}

	///	<summary>The turn of a token in a fight, as the table shows it.</summary>
	public record TokenTurnDto(bool BonusUsed, int AttacksMade, bool Dashed, bool Disengaged, bool Dodging, bool Interacted, string? Wield, Guid? OpportunityOn);

	///	<summary>
	///	How an attack went: the d20 (and the one left out), the total, hit or miss, critical, the damage dealt and what
	///	the roll log shows of it. ArmorClass only for the masters.
	///	</summary>
	public record MapAttackResultDto(bool Hit, bool Critical, List<RollDieDto> Dice, int Bonus, int Total, int? Damage, List<RollDieDto> DamageDice,
		string Text, int? ArmorClass = null);

	///	<summary>
	///	What a token carries, as the table sees it: the loot of a creature (to the masters; to everyone once it is
	///	down), the item lying on a dropped-item token, the statblock attacks it lost.
	///	</summary>
	public record TokenItemDto(int Index, string Name, int Quantity, Guid? EquipmentId = null);

	public record TokenGearDto(List<TokenItemDto> Items, int Coins, List<string> Disarmed);

	//	A weapon dropped by a token: the inventory entry of a character, or the attack of a statblock
	public class DropItemDto
	{
		public Guid? InventoryId { get; set; }
		public string? Attack { get; set; }

		//	The name the token on the ground shows (the item in the language of who dropped it)
		public string? Name { get; set; }
	}

	//	An item taken by a token (an item on the ground, a beaten creature's loot): the index of the item, or -1 for the coins
	public class TakeItemDto
	{
		public Guid ByTokenId { get; set; }
		public int Index { get; set; }

		//	Taken in hand (equipped; a creature's own weapon gives its attack back), else into the pack
		public bool Equip { get; set; }
	}

	//	The masters fill a creature's loot
	public class SaveLootDto
	{
		public List<LootEntryDto> Items { get; set; } = new();
		public int Coins { get; set; }
	}

	public class LootEntryDto
	{
		public string Name { get; set; } = string.Empty;
		public int Quantity { get; set; } = 1;
		public Guid? EquipmentId { get; set; }
	}

	public class PlayersLockDto
	{
		public bool Locked { get; set; }
	}

	///	<summary>
	///	Something drawn on a map (see CampaignMapShape). Private: only its author sees it; CanDelete: the author, or a master
	///	for what the whole table sees; CanMove: a text its author (or a master, when shared) drags somewhere else.
	///	</summary>
	public record MapShapeDto(Guid Id, ShapeKind Kind, List<double> Points, string Color, string? Text, int Size, bool Private, bool CanDelete,
		bool CanMove = false);

	public class SaveShapeDto
	{
		public ShapeKind Kind { get; set; } = ShapeKind.Freehand;
		public List<double> Points { get; set; } = new();
		public string? Color { get; set; }
		public string? Text { get; set; }
		public int Size { get; set; }

		//	A master's text for the whole table (the players' texts and every stroke stay with their author)
		public bool Shared { get; set; }
	}

	public class MoveShapeDto
	{
		public List<double> Points { get; set; } = new();
	}

	///	<summary>
	///	A map with its picture, its grid and its tokens (the hidden ones only for the masters).
	///	</summary>
	public record CampaignMapDto(
		Guid Id,
		string Name,
		string Image,
		int Width,
		int Height,
		int GridSize,
		int GridOffsetX,
		int GridOffsetY,
		bool Shown,
		bool CanEdit,
		DateTimeOffset UpdatedAt,
		List<MapTokenDto> Tokens,
		GridType GridType = GridType.Square,
		List<MapShapeDto>? Shapes = null,
		MapTableDto? Table = null,
		MapCombatDto? Combat = null,
		MapTerrainDto? Terrain = null);

	///	<summary>
	///	What the table polls every few seconds: the grid and the tokens, without the picture.
	///	</summary>
	public record MapStateDto(Guid Id, string Name, int GridSize, int GridOffsetX, int GridOffsetY, bool Shown, DateTimeOffset UpdatedAt, List<MapTokenDto> Tokens,
		GridType GridType = GridType.Square, List<MapShapeDto>? Shapes = null, MapTableDto? Table = null,
		MapCombatDto? Combat = null, MapTerrainDto? Terrain = null);

	///	<summary>
	///	The terrain of a map (see MapTerrain): the cells that are not plain floor (column, row, kind) and whether the players'
	///	tokens go around the walls and the closed doors.
	///	</summary>
	public record MapTerrainDto(List<int> Cells, bool BlockPlayers);

	///	<summary>
	///	Cells painted with a kind of terrain (pairs of column and row; Walkable clears them), or the whole terrain replaced
	///	(Replace: Cells as groups of three), and the rule for the players.
	///	</summary>
	public class SaveTerrainDto
	{
		public List<int> Cells { get; set; } = new();
		public TerrainKind Kind { get; set; }
		public bool Replace { get; set; }
		public bool BlockPlayers { get; set; } = true;
	}

	///	<summary>
	///	The fog of war (see MapFog), the last ping and the last view the masters brought the table to.
	///	</summary>
	public record MapTableDto(bool FogEnabled, List<double> Fog, MapPingDto? Ping, MapFocusDto? Focus, bool PlayersLocked = false);

	public record MapPingDto(double X, double Y, string Color, DateTimeOffset At);

	public record MapFocusDto(double X, double Y, double Zoom, DateTimeOffset At);

	public class SaveFogDto
	{
		public bool Enabled { get; set; }
		public List<double> Fog { get; set; } = new();
	}

	public class MapPointDto
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Zoom { get; set; } = 1;
	}

	///	<summary>
	///	A new map, or its changes (Image null keeps the picture).
	///	</summary>
	public class SaveMapDto
	{
		public string Name { get; set; } = string.Empty;
		public string? Image { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public GridType GridType { get; set; } = GridType.Square;
		public int GridSize { get; set; } = 70;
		public int GridOffsetX { get; set; }
		public int GridOffsetY { get; set; }
		public bool Shown { get; set; }
	}

	///	<summary>
	///	A new token, or its changes.
	///	</summary>
	public class SaveTokenDto
	{
		public string Label { get; set; } = string.Empty;
		public string? Color { get; set; }
		public TokenKind Kind { get; set; } = TokenKind.Marker;
		public Guid? CharacterId { get; set; }
		public Guid? MonsterId { get; set; }
		public Guid? SheetCharacterId { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Size { get; set; } = 1;
		public bool Hidden { get; set; }
		public TokenLayer Layer { get; set; } = TokenLayer.Tokens;
		public List<string> ControlledBy { get; set; } = new();
		public int? Hp { get; set; }
		public int? MaxHp { get; set; }
		public PropType? PropType { get; set; }
		public PropState PropState { get; set; } = PropState.Closed;
		public bool PlayersInteract { get; set; }
		public Guid? ImageId { get; set; }
	}

	public class MoveTokenDto
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}
