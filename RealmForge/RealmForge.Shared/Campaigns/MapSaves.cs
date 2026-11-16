namespace RealmForge.Shared.Campaigns;

///	<summary>
///	A spell that asks for saving throws: who cast it, the save (ability and DC), the damage rolled once for every
///	target, whether a success halves it, and the targets with their outcome. Kept on the map until every target has
///	rolled (or a master dismisses it): the masters see it at once and roll for their creatures, each player for the
///	own characters.
///	</summary>
public sealed class MapSaveCall
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public Guid CasterTokenId { get; set; }
	public string Caster { get; set; } = string.Empty;
	public string Spell { get; set; } = string.Empty;

	//	The ability of the save (AbilityScore: 1 Strength ... 6 Charisma)
	public int Ability { get; set; }
	public int Dc { get; set; }
	public int? Damage { get; set; }
	public string? DamageType { get; set; }
	public bool Half { get; set; }
	public bool CasterHidden { get; set; }
	public DateTimeOffset At { get; set; } = DateTimeOffset.UtcNow;
	public List<MapSaveTarget> Targets { get; set; } = new();
}

public sealed class MapSaveTarget
{
	public Guid TokenId { get; set; }
	public string Label { get; set; } = string.Empty;

	//	Careful Spell, Sculpt Spells: it succeeds by itself (no damage where a success halves it)
	public bool Careful { get; set; }

	//	Heightened Spell: disadvantage on the save
	public bool Disadvantage { get; set; }
	public int? Roll { get; set; }
	public bool? Saved { get; set; }
	public int? Dealt { get; set; }
}

public static class MapSaveRules
{
	public const int MaxCalls = 12;
	public const int MaxTargets = 40;

	///	<summary>The damage a target takes: all of it on a failure, half (rounded down) or nothing on a success.</summary>
	public static int? Dealt(int? damage, bool saved, bool half, bool careful) =>
		damage is not { } d ? null : !saved ? d : half && !careful ? d / 2 : 0;

	///	<summary>
	///	The ability named by a text ("Destrezza", "Dexterity", "DES", "dex"), or 0. The first three letters of the
	///	Italian and English names are enough.
	///	</summary>
	public static int AbilityOf(string? name)
	{
		var key = (name ?? string.Empty).Trim().ToLowerInvariant();
		if (key.Length < 3)
		{
			return 0;
		}
		return key[..3] switch
		{
			"for" or "str" => 1,
			"des" or "dex" => 2,
			"cos" or "con" => 3,
			"int" => 4,
			"sag" or "wis" => 5,
			"car" or "cha" => 6,
			_ => 0
		};
	}
}
