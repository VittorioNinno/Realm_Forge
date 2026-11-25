using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	A campaign: the people playing it (with their role), the characters taking part, the Homebrew shared with the table
	///	and the pending invitations. Ruleset, when set, is the edition of its characters.
	///	</summary>
	public class Campaign
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; } = string.Empty;

		//	Markdown: the premise, the house rules, the next session…
		public string Description { get; set; } = string.Empty;

		public RulesetVersion? Ruleset { get; set; }

		//	Code of the invite link (anyone with the link joins as a player); null when the link is disabled
		public string? InviteCode { get; set; }

		public string CreatedById { get; set; } = string.Empty;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

		//	The virtual tabletop opened by a master or co-master for a session: the players are told and the campaign page
		//	shows the way in. Closed by hand, or on its own after CampaignRules.TableIdleHours
		//	with nothing happening at the table
		public DateTimeOffset? TableOpenedAt { get; set; }
		public string? TableOpenedById { get; set; }

		//	Theater of the mind: the handout shown to the whole table in place of the map (null: the map)
		public Guid? SceneHandoutId { get; set; }

		//	The time inside the game, in minutes from the start of day 1 (GameClock): the masters move it on
		public long GameMinutes { get; set; } = 8 * 60;

		//	The soundboard: the track the table plays (from when) and the last effect played (when)
		public Guid? SoundTrackId { get; set; }
		public DateTimeOffset? SoundTrackAt { get; set; }
		public Guid? SoundCueId { get; set; }

		//	The party's chest: the coins not shared out yet (JSON of a CoinPurse)
		public string? TreasureCoins { get; set; }
		public DateTimeOffset? SoundCueAt { get; set; }
		//	The ambience loops of the sound scene playing (ids of CampaignSound, comma separated) and the scene itself;
		//	they start with the track (SoundTrackAt)
		public string? SoundLayers { get; set; }
		public Guid? SoundSceneId { get; set; }

		public ICollection<CampaignMember> Members { get; set; } = new List<CampaignMember>();
		public ICollection<CampaignInvite> Invites { get; set; } = new List<CampaignInvite>();
		public ICollection<CampaignCharacter> Characters { get; set; } = new List<CampaignCharacter>();
		public ICollection<CampaignContent> Contents { get; set; } = new List<CampaignContent>();
		public ICollection<CampaignNote> Notes { get; set; } = new List<CampaignNote>();
		public ICollection<CampaignEncounter> Encounters { get; set; } = new List<CampaignEncounter>();
		public ICollection<CampaignSession> Sessions { get; set; } = new List<CampaignSession>();
		public ICollection<CampaignRoll> Rolls { get; set; } = new List<CampaignRoll>();
		public ICollection<CampaignMap> Maps { get; set; } = new List<CampaignMap>();
	}

	///	<summary>
	///	A map of the virtual tabletop: the picture (a JPEG as a data URL, its size in pixels) with a square grid (cell size
	///	and offset in pixels of the picture), and the tokens on it. Shown makes it visible to the players.
	///	</summary>
	public class CampaignMap
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public string Name { get; set; } = string.Empty;
		public string Image { get; set; } = string.Empty;
		public int Width { get; set; }
		public int Height { get; set; }
		public GridType GridType { get; set; } = GridType.Square;
		public int GridSize { get; set; } = 70;
		public int GridOffsetX { get; set; }
		public int GridOffsetY { get; set; }
		public bool Shown { get; set; }

		//	Fog of war: what the players do not see yet. Fog: groups of 5 numbers (MapFog), applied in order on a map all
		//	covered
		public bool FogEnabled { get; set; }

		//	The light where nobody carries one, and whether each player sees only what their creatures see (the lights,
		//	the darkvision, the walls in the way; see MapVision)
		public MapLighting Lighting { get; set; }
		public bool DynamicVision { get; set; }

		//	The masters stopped the players' areas and pings (the drawings each one keeps for themselves stay)
		public bool PlayersLocked { get; set; }

		//	The encounter being fought on this map: its initiative order runs over the tokens
		public Guid? EncounterId { get; set; }
		public List<double> Fog { get; set; } = new();

		//	The terrain (MapTerrain): groups of column, row and kind for the cells that are not plain floor; whether the
		//	players' tokens go around walls and closed doors
		public List<int> Terrain { get; set; } = new();
		public bool TerrainBlocks { get; set; } = true;

		//	The last ping (a point the table should look at) and the last view the masters brought everyone to
		public double? PingX { get; set; }
		public double? PingY { get; set; }
		public string? PingColor { get; set; }
		public DateTimeOffset? PingAt { get; set; }

		//	The last attack, for its effect on every screen: the target, missed / hit / critical (0, 1, 2), the damage
		public Guid? StrikeTokenId { get; set; }
		public int StrikeKind { get; set; }
		public int? StrikeDamage { get; set; }

		//	Its damage type in English ("fire"), for the colour of the effect
		public string? StrikeType { get; set; }

		//	The saving throws a spell asks for, waiting for their rolls (JSON of MapSaveCall)
		public string? SaveCalls { get; set; }
		public DateTimeOffset? StrikeAt { get; set; }
		public double? FocusX { get; set; }
		public double? FocusY { get; set; }
		public double? FocusZoom { get; set; }
		public DateTimeOffset? FocusAt { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

		//	Changes with the map and with every token, so that the tables refresh what moved
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
		public ICollection<CampaignToken> Tokens { get; set; } = new List<CampaignToken>();
		public ICollection<CampaignMapShape> Shapes { get; set; } = new List<CampaignMapShape>();
	}

	///	<summary>
	///	Something drawn on a map: a stroke, a text, the area of a spell. Points in pixels of the picture; Size is the length
	///	of an area in cells. MasterOnly marks what only its author sees (see MapRules.Sees): every stroke, the players'
	///	texts and the masters' texts not shared with the table.
	///	</summary>
	public class CampaignMapShape
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid MapId { get; set; }
		public CampaignMap Map { get; set; } = null!;
		public string OwnerId { get; set; } = string.Empty;
		public ShapeKind Kind { get; set; } = ShapeKind.Freehand;
		public List<double> Points { get; set; } = new();
		public string Color { get; set; } = PlayerColors.Master;
		public string? Text { get; set; }
		public int Size { get; set; }
		public bool MasterOnly { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A handout of a campaign: a letter, a clue, a picture or a map that is not tactical, prepared by the masters and
	///	revealed to the players during a session (a pop-up at the table). Written in Italian and English: each player
	///	reads it in their language (the other one when it has only that).
	///	</summary>
	public class CampaignHandout
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public string AuthorId { get; set; } = string.Empty;
		public string TitleIt { get; set; } = string.Empty;
		public string TitleEn { get; set; } = string.Empty;
		public string BodyIt { get; set; } = string.Empty;
		public string BodyEn { get; set; } = string.Empty;
		public Guid? ImageId { get; set; }

		//	When it was shown to the players (null: still hidden)
		public DateTimeOffset? RevealedAt { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A progress clock (4, 6, 8 or 12 segments): a threat or a goal that fills by hand or every few hours of game time
	///	(TickHours); the players see it when Shown.
	///	</summary>
	public class CampaignProgressClock
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public string Name { get; set; } = string.Empty;
		public int Segments { get; set; } = 6;
		public int Filled { get; set; }
		public bool Shown { get; set; }
		public string Color { get; set; } = "#ff8c00";
		public int? TickHours { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A faction or a city of the campaign and the party's standing with it, from hostile (-3) to allied (+3).
	///	</summary>
	public class CampaignFaction
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int Standing { get; set; }
		public bool Shown { get; set; } = true;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	An item in the party's chest: from the compendium (equipment, a magic item) or free. Until it is identified the
	///	players see only its Appearance (and the name the masters gave it); it goes to a character's inventory when given.
	///	</summary>
	public class CampaignLoot
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Guid? EquipmentId { get; set; }
		public Guid? MagicItemId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Appearance { get; set; } = string.Empty;
		public bool Identified { get; set; } = true;
		public int Quantity { get; set; } = 1;
		public int? ValueInCopper { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A sound of the soundboard: a link to an audio file or stream hosted elsewhere, a track that loops (music,
	///	ambience) or a one-shot effect, with its volume.
	///	</summary>
	///	<summary>
	///	A sound scene: a track, up to four ambience loops played over it and an effect at the start, all with one click;
	///	tied to a map, it starts when the master shows that map to the players.
	///	</summary>
	public class CampaignSoundScene
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public string Name { get; set; } = string.Empty;
		public Guid? TrackId { get; set; }
		//	Ids of CampaignSound, comma separated
		public string Layers { get; set; } = string.Empty;
		public Guid? CueId { get; set; }
		public Guid? MapId { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	public class CampaignSound
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Url { get; set; } = string.Empty;
		public bool Effect { get; set; }
		public int Volume { get; set; } = 80;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A shop of a campaign (a merchant, a blacksmith, a temple): the masters stock it with items of the compendium or
	///	their own and a price multiplier (PricePercent: 100 = list price); the players buy while it is open, the coins
	///	come off their character's purse and the item goes to their inventory.
	///	</summary>
	public class CampaignShop
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public string AuthorId { get; set; } = string.Empty;
		public string NameIt { get; set; } = string.Empty;
		public string NameEn { get; set; } = string.Empty;
		public string DescriptionIt { get; set; } = string.Empty;
		public string DescriptionEn { get; set; } = string.Empty;
		public int PricePercent { get; set; } = 100;

		//	The faction it belongs to: its standing with the party moves the prices
		public Guid? FactionId { get; set; }

		//	Open: the players see it and buy (closed: behind the screen)
		public bool Open { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
		public ICollection<CampaignShopItem> Items { get; set; } = new List<CampaignShopItem>();
	}

	///	<summary>
	///	An item on sale: equipment or a magic item of the compendium (its name follows the reader's language), or a free
	///	entry with its own Name. PriceInCopper is the list price of one piece (before the shop's multiplier); Stock null:
	///	as many as wanted.
	///	</summary>
	public class CampaignShopItem
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid ShopId { get; set; }
		public CampaignShop Shop { get; set; } = null!;
		public Guid? EquipmentId { get; set; }
		public Guid? MagicItemId { get; set; }
		public string Name { get; set; } = string.Empty;
		public int PriceInCopper { get; set; }
		public int? Stock { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A group of monsters the masters keep ready for the table (a goblin patrol: four goblins and their boss): placed on a
	///	map in one go. Entries: JSON of MonsterGroupEntry (the monster and how many).
	///	</summary>
	public class CampaignMonsterGroup
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Entries { get; set; } = "[]";
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	One step a master can take back on a map (MapUndo): what the tokens, the drawings, the terrain or the fog were
	///	before an edit of theirs, as JSON; the last ones of each master on each map are kept.
	///	</summary>
	public class CampaignMapEdit
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid MapId { get; set; }
		public string UserId { get; set; } = string.Empty;
		public string Kind { get; set; } = string.Empty;
		public string Payload { get; set; } = "{}";
		public DateTimeOffset At { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A token on a map, on a cell of the grid (X, Y from the top left), Size cells wide: a character of the table (its
	///	owner can move it), a monster, an NPC or a marker. Hidden tokens are seen by the masters only.
	///	</summary>
	public class CampaignToken
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid MapId { get; set; }
		public CampaignMap Map { get; set; } = null!;
		public string Label { get; set; } = string.Empty;
		public string Color { get; set; } = PlayerColors.Master;
		public TokenKind Kind { get; set; } = TokenKind.Marker;
		public Guid? CharacterId { get; set; }
		public Guid? MonsterId { get; set; }

		//	A copy of a character's token: a nonplayer character of its own (hit points, conditions) that uses the
		//	numbers of that character's sheet
		public Guid? SheetCharacterId { get; set; }

		//	The masters let the players see its hit points; the armour class a master set at the table (over the statblock)
		public bool ShowHp { get; set; }
		public int? ArmorClass { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int Size { get; set; } = 1;
		public bool Hidden { get; set; }

		//	Props under the other tokens (a chest, a cart)
		public TokenLayer Layer { get; set; } = TokenLayer.Tokens;

		//	The combatant of the map's encounter this token is; the conditions of a token outside any fight
		public Guid? CombatantId { get; set; }
		public List<string> Conditions { get; set; } = new();

		//	The players (user ids) a master lets move this token, besides the owner of its character
		public List<string> ControlledBy { get; set; } = new();

		//	Hit points of a token outside a fight (a monster placed by hand); in a fight its combatant's count
		public int? Hp { get; set; }
		public int? MaxHp { get; set; }

		//	Temporary hit points of a token (outside a fight, or of a monster in it: its combatant keeps them too)
		public int? TempHp { get; set; }

		//	An object (Kind Prop): what it is, how it is, whether the players open and close it themselves
		public PropType? PropType { get; set; }

		//	The picture of the token, from an account's images (UserImage); a character shows its portrait
		public Guid? ImageId { get; set; }
		public PropState PropState { get; set; } = PropState.Closed;
		public bool PlayersInteract { get; set; }

		//	What it carries (JSON of TokenGear): a creature's loot, the item lying on a dropped-item token, the statblock
		//	attacks it lost with its weapon
		public string Gear { get; set; } = "{}";
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A session of the campaign, numbered in order: its date, status, the plan the players read beforehand, the recap
	///	afterwards and the notes of the masters (never sent to the players).
	///	</summary>
	public class CampaignSession
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public int Number { get; set; }
		public string Title { get; set; } = string.Empty;
		public DateTimeOffset? ScheduledAt { get; set; }
		public CampaignSessionStatus Status { get; set; } = CampaignSessionStatus.Planned;

		//	Markdown
		public string Plan { get; set; } = string.Empty;
		public string Recap { get; set; } = string.Empty;
		public string MasterNotes { get; set; } = string.Empty;

		public string UpdatedById { get; set; } = string.Empty;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A roll of the shared dice log: made on the campaign page (rolled by the server) or on a character sheet. Dice is
	///	the JSON of the dice (sides, value, dropped). Only the last SessionRules.MaxRolls of a campaign are kept.
	///	</summary>
	public class CampaignRoll
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public string UserId { get; set; } = string.Empty;
		public Guid? CharacterId { get; set; }
		public string? CharacterName { get; set; }

		//	Name and colour shown for the roll, kept as they were when it was made (they survive the account)
		public string Roller { get; set; } = string.Empty;
		public string Color { get; set; } = PlayerColors.Master;
		public string Label { get; set; } = string.Empty;
		public string Expression { get; set; } = string.Empty;
		public string Dice { get; set; } = "[]";
		public int Modifier { get; set; }
		public int Total { get; set; }
		public string? Note { get; set; }
		public bool Hidden { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	An encounter prepared (and then run) by the masters and co-masters: the combatants with initiative, hit points and
	///	conditions (JSON of EncounterCombatant), the characters it is balanced for, round and turn. Shown makes an
	///	encounter under way visible to the players.
	///	</summary>
	public class CampaignEncounter
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public string Name { get; set; } = string.Empty;
		public string Notes { get; set; } = string.Empty;
		public EncounterStatus Status { get; set; } = EncounterStatus.Planned;
		public int Round { get; set; }
		//	The combatant whose turn it is
		public Guid? CurrentId { get; set; }
		public bool Shown { get; set; }

		//	The players see how hurt the enemies are in the initiative bar of the table (a master's choice; off at first)
		public bool ShowHealth { get; set; }

		//	JSON array of EncounterCombatant
		public string Combatants { get; set; } = "[]";

		//	The map it is fought on: the combatants' starting cells are on it
		public Guid? MapId { get; set; }
		public List<Guid> PartyIds { get; set; } = new();

		public int Version { get; set; } = 1;
		public string CreatedById { get; set; } = string.Empty;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	An account playing the campaign, with its role (unique per campaign and account).
	///	</summary>
	public class CampaignMember
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public string UserId { get; set; } = string.Empty;
		public CampaignRole Role { get; set; } = CampaignRole.Player;
		public DateTimeOffset JoinedAt { get; set; } = DateTimeOffset.UtcNow;

		//	Colour of the person's rolls (PlayerColors.Palette); a master is shown in orange whatever this says
		public string? Color { get; set; }
	}

	///	<summary>
	///	An invitation to an account, with the role it will have; it becomes a member when the person accepts.
	///	</summary>
	public class CampaignInvite
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public string UserId { get; set; } = string.Empty;
		public CampaignRole Role { get; set; } = CampaignRole.Player;
		public string InvitedById { get; set; } = string.Empty;
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A character taking part in the campaign: its masters and co-masters can open and change it.
	///	</summary>
	public class CampaignCharacter
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public Guid CharacterId { get; set; }
		public Character Character { get; set; } = null!;
		public string AddedById { get; set; } = string.Empty;
		public DateTimeOffset AddedAt { get; set; } = DateTimeOffset.UtcNow;

		//	An inactive character stays at the table but sits out: it is not counted in the party of new encounters
		public bool Inactive { get; set; }
	}

	///	<summary>
	///	A note of the campaign: private (its author only), for the masters, or a page of the shared journal.
	///	</summary>
	public class CampaignNote
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public CampaignNoteKind Kind { get; set; } = CampaignNoteKind.Journal;
		public string AuthorId { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;

		//	Markdown
		public string Body { get; set; } = string.Empty;

		//	The masters' secrets of a journal page (Markdown): only who runs the table reads and writes them
		public string? Secret { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	A Homebrew entry shared with the campaign (any kind: species, class, feat, spell…). Once approved, every member
	///	sees it in the compendium and in character creation, as if it were shared with them.
	///	</summary>
	public class CampaignContent
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CampaignId { get; set; }
		public Campaign Campaign { get; set; } = null!;
		public Guid EntityId { get; set; }
		public string SharedById { get; set; } = string.Empty;
		public CampaignContentStatus Status { get; set; } = CampaignContentStatus.Pending;
		public string? ReviewedById { get; set; }

		//	Switched on with a collection of Homebrew (switched off with it as a block)
		public Guid? CollectionId { get; set; }
		public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
	}
}
