using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Rules;

///	<summary>
///	The damage types a creature resists (half), is immune to (none) or is vulnerable to (double), as the server applies
///	them to the damage of a hit or a failed save before the hit points (and before the DC of concentration): read from a
///	statblock ("bludgeoning, piercing, and slashing from nonmagical attacks", "contundenti, perforanti e taglienti da
///	attacchi non magici") or from a character's sheet.
///	</summary>
public sealed record DamageDefenses(
	IReadOnlyCollection<DamageType> Resist,
	IReadOnlyCollection<DamageType> Immune,
	IReadOnlyCollection<DamageType> Vulnerable,
	IReadOnlyCollection<DamageType> ResistMundane,
	IReadOnlyCollection<DamageType> ImmuneMundane)
{
	public static readonly DamageDefenses None = new(Array.Empty<DamageType>(), Array.Empty<DamageType>(), Array.Empty<DamageType>(), Array.Empty<DamageType>(), Array.Empty<DamageType>());

	public bool IsEmpty => Resist.Count + Immune.Count + Vulnerable.Count + ResistMundane.Count + ImmuneMundane.Count == 0;

	//	The stems of the names of each type, Italian and English
	private static readonly (DamageType Type, string[] Stems)[] Names =
	{
		(DamageType.Acid, new[] { "acid" }),
		(DamageType.Bludgeoning, new[] { "bludgeon", "contundent" }),
		(DamageType.Cold, new[] { "cold", "freddo" }),
		(DamageType.Fire, new[] { "fire", "fuoco" }),
		(DamageType.Force, new[] { "force", "forza" }),
		(DamageType.Lightning, new[] { "lightning", "fulmin" }),
		(DamageType.Necrotic, new[] { "necrotic" }),
		(DamageType.Piercing, new[] { "piercing", "perforant" }),
		(DamageType.Poison, new[] { "poison", "veleno" }),
		(DamageType.Psychic, new[] { "psychic", "psichic" }),
		(DamageType.Radiant, new[] { "radiant", "radios" }),
		(DamageType.Slashing, new[] { "slashing", "taglient" }),
		(DamageType.Thunder, new[] { "thunder", "tuono" })
	};

	///	<summary>The damage type a text names ("taglienti", "fire", "da fuoco"), or null.</summary>
	public static DamageType? TypeOf(string? text)
	{
		var lower = (text ?? string.Empty).ToLowerInvariant();
		foreach (var (type, stems) in Names)
		{
			if (stems.Any(lower.Contains))
			{
				return type;
			}
		}
		return null;
	}

	private static List<DamageType> TypesIn(string text)
	{
		var lower = text.ToLowerInvariant();
		return Names.Where(n => n.Stems.Any(lower.Contains)).Select(n => n.Type).ToList();
	}

	//	"from nonmagical attacks", "that aren't silvered", "non magici", "non argentate"
	private static bool Mundane(string segment)
	{
		var lower = segment.ToLowerInvariant();
		return lower.Contains("nonmagical") || lower.Contains("non-magical") || lower.Contains("non magic") || lower.Contains("silvered")
			|| lower.Contains("adamantine") || lower.Contains("argentat") || lower.Contains("adamantio");
	}

	///	<summary>The defenses of a statblock: its lines of vulnerabilities, resistances and immunities.</summary>
	public static DamageDefenses FromStatblock(string? vulnerabilities, string? resistances, string? immunities)
	{
		(List<DamageType> Always, List<DamageType> Mundane) Split(string? line)
		{
			var always = new List<DamageType>();
			var mundane = new List<DamageType>();
			foreach (var segment in (line ?? string.Empty).Split(';'))
			{
				(Mundane(segment) ? mundane : always).AddRange(TypesIn(segment));
			}
			return (always, mundane);
		}
		var resist = Split(resistances);
		var immune = Split(immunities);
		return new DamageDefenses(resist.Always, immune.Always, TypesIn(vulnerabilities ?? string.Empty), resist.Mundane, immune.Mundane);
	}

	///	<summary>A character's defenses kept with it: "r:4,12|i:9|v:" (the numbers of the damage types).</summary>
	public static string Write(IEnumerable<DamageType> resist, IEnumerable<DamageType> immune) =>
		$"r:{string.Join(",", resist.Distinct().Select(t => (int)t))}|i:{string.Join(",", immune.Distinct().Select(t => (int)t))}|v:";

	public static DamageDefenses Read(string? text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return None;
		}
		List<DamageType> Part(string key) => text.Split('|')
			.Where(p => p.StartsWith(key + ":", StringComparison.Ordinal))
			.SelectMany(p => p[(key.Length + 1)..].Split(',', StringSplitOptions.RemoveEmptyEntries))
			.Select(v => int.TryParse(v, out var n) && Enum.IsDefined((DamageType)n) ? (DamageType?)n : null)
			.OfType<DamageType>().ToList();
		return new DamageDefenses(Part("r"), Part("i"), Part("v"), Array.Empty<DamageType>(), Array.Empty<DamageType>());
	}

	///	<summary>
	///	The damage after the defenses: none when immune, half (rounded down) when resistant, double when vulnerable
	///	(resistance and vulnerability together cancel out). Magical damage (a spell) passes the defenses against
	///	nonmagical attacks. The key of what changed it, or null: "immune", "resist", "vulnerable".
	///	</summary>
	public (int Damage, string? Why) Apply(int damage, DamageType? type, bool magical)
	{
		if (type is not { } t || damage <= 0)
		{
			return (damage, null);
		}
		if (Immune.Contains(t) || (!magical && ImmuneMundane.Contains(t)))
		{
			return (0, "immune");
		}
		var resists = Resist.Contains(t) || (!magical && ResistMundane.Contains(t));
		var vulnerable = Vulnerable.Contains(t);
		return (resists, vulnerable) switch
		{
			(true, false) => (damage / 2, "resist"),
			(false, true) => (damage * 2, "vulnerable"),
			_ => (damage, null)
		};
	}
}
