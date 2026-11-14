using System.Globalization;
using System.Text.RegularExpressions;

namespace RealmForge.Shared.Campaigns;

///	<summary>
///	How far an attack reaches, in cells: Reach in melee (0 when it cannot strike in melee), Range and LongRange at a
///	distance (0 when it cannot shoot). Beyond Range up to LongRange the attack has disadvantage.
///	</summary>
public sealed record AttackReach(int Reach, int Range, int LongRange)
{
	public static readonly AttackReach Melee = new(1, 0, 0);

	public int Max => Math.Max(Reach, LongRange);

	//	Whether a target that far can be attacked, and with disadvantage (only past the normal range)
	public (bool Can, bool Disadvantage) At(int gap) =>
		gap <= Reach ? (true, false)
		: Range > 0 && gap <= Range ? (true, false)
		: LongRange > 0 && gap <= LongRange ? (true, true)
		: (false, false);
}

///	<summary>
///	An area of a spell: its shape, its size in cells (the radius of a sphere, the side of a cube, the length of a cone
///	or a line), how far from the caster it can be placed (in cells; 0 for the caster's own cell) and whether it starts
///	from the caster (cones, lines, auras).
///	</summary>
public sealed record SpellArea(ShapeKind Kind, int Size, int Range, bool FromCaster);

///	<summary>
///	The rules of fighting on the map: the distance between two tokens, how far an attack reaches, the area of a spell
///	read from its texts.
///	</summary>
public static partial class TableCombat
{
	//	The keys of what a combatant spent of its turn
	public const string SpentAttack = "attack";
	public const string SpentOther = "other";

	//	A range the map cannot measure (sight, miles): anywhere on it
	public const int Unlimited = 999;

	///	<summary>
	///	Cells between two tokens: between the nearest cells they cover (adjacent tokens are 1 apart). Bigger tokens
	///	cover size × size squares; on hexagons a token is its own cell.
	///	</summary>
	public static int Gap(GridType type, int x1, int y1, int size1, int x2, int y2, int size2)
	{
		if (type != GridType.Square)
		{
			return MapGeometry.Distance(type, x1, y1, x2, y2);
		}
		var dx = Math.Max(0, Math.Max(x2 - (x1 + size1 - 1), x1 - (x2 + size2 - 1)));
		var dy = Math.Max(0, Math.Max(y2 - (y1 + size1 - 1), y1 - (y2 + size2 - 1)));
		return Math.Max(dx, dy);
	}

	//	Feet in cells (5 feet each), rounding down; at least one cell for a distance that is not zero
	public static int FeetToCells(int feet) => feet <= 0 ? 0 : Math.Max(1, feet / 5);

	//	Metres in cells (1,5 m each)
	public static int MetresToCells(double metres) => metres <= 0 ? 0 : Math.Max(1, (int)Math.Floor(metres / 1.5 + 0.001));

	///	<summary>
	///	The reach of a weapon of a sheet: 5 feet in melee (10 with Reach), the normal and long range of a ranged or
	///	thrown weapon.
	///	</summary>
	public static AttackReach OfWeapon(bool ranged, bool reachProperty, bool thrown, int? normalRange, int? longRange)
	{
		var reach = ranged ? 0 : reachProperty ? 2 : 1;
		var shoots = ranged || thrown;
		var normal = shoots ? FeetToCells(normalRange ?? (ranged ? 80 : 20)) : 0;
		var far = shoots ? Math.Max(normal, FeetToCells(longRange ?? normalRange ?? 0)) : 0;
		return new AttackReach(reach, normal, far);
	}

	///	<summary>
	///	The reach of a statblock attack: "portata 3 m", "reach 10 ft.", "gittata 24/96 m", "range 80/320 ft." (a
	///	thrown weapon has both). Without any, a melee attack of 5 feet.
	///	</summary>
	public static AttackReach OfStatblock(string? text)
	{
		var body = text ?? string.Empty;
		var reach = 0;
		var (range, far) = (0, 0);
		if (ReachText().Match(body) is { Success: true } r)
		{
			reach = Cells(r.Groups["n"].Value, r.Groups["unit"].Value);
			reach = Math.Max(reach, 1);
		}
		if (RangeText().Match(body) is { Success: true } g)
		{
			range = Cells(g.Groups["n"].Value, g.Groups["unit"].Value);
			far = g.Groups["far"].Success ? Cells(g.Groups["far"].Value, g.Groups["unit"].Value) : range;
		}
		return reach == 0 && range == 0 ? AttackReach.Melee : new AttackReach(reach, range, Math.Max(range, far));
	}

	private static int Cells(string number, string unit)
	{
		var value = double.Parse(number.Replace(',', '.'), CultureInfo.InvariantCulture);
		return unit.StartsWith('m') ? MetresToCells(value) : FeetToCells((int)value);
	}

	///	<summary>
	///	The area of a spell from its range ("Incantatore (cono di 18 metri)", "Self (60-foot cone)", "45 metri", "150
	///	feet") and, for an area placed at a point, its description ("una sfera del raggio di 6 metri", "a
	///	20-foot-radius sphere"). Null when it has none.
	///	</summary>
	public static SpellArea? AreaOf(string? range, string? description)
	{
		var rangeText = (range ?? string.Empty).Trim();
		var self = SelfText().IsMatch(rangeText);
		if (self && Shape(rangeText) is { } aura)
		{
			return aura with { Range = 0, FromCaster = true };
		}
		if (Shape(description ?? string.Empty) is not { } area)
		{
			return null;
		}
		var reach = self ? 0 : TouchText().IsMatch(rangeText) ? 1 : DistanceText().Match(rangeText) is { Success: true } d ? Cells(d.Groups["n"].Value, d.Groups["unit"].Value) : Unlimited;
		//	A cone or a line always starts from the caster, whatever the range says
		return area with { Range = reach, FromCaster = self || area.Kind is ShapeKind.Cone or ShapeKind.Line };
	}

	//	The first shape a text names, with its size
	private static SpellArea? Shape(string text)
	{
		var best = (Index: int.MaxValue, Area: (SpellArea?)null);
		void Try(Regex regex, ShapeKind kind)
		{
			if (regex.Match(text) is { Success: true } m && m.Index < best.Index)
			{
				var size = Cells(m.Groups["n"].Value, m.Groups["unit"].Success && m.Groups["unit"].Value.Length > 0 ? m.Groups["unit"].Value : "m");
				best = (m.Index, new SpellArea(kind, Math.Clamp(size, 1, 40), 0, false));
			}
		}
		Try(SphereIt(), ShapeKind.Sphere);
		Try(CubeIt(), ShapeKind.Cube);
		Try(ConeIt(), ShapeKind.Cone);
		Try(LineIt(), ShapeKind.Line);
		Try(SphereEn(), ShapeKind.Sphere);
		Try(CubeEn(), ShapeKind.Cube);
		Try(ConeEn(), ShapeKind.Cone);
		Try(LineEn(), ShapeKind.Line);
		return best.Area;
	}

	public sealed record AttackEffect(bool Advantage, bool Disadvantage, bool AutoCritical, IReadOnlyList<string> Causes)
	{
		public int Mode => Advantage == Disadvantage ? 0 : Advantage ? 1 : -1;
	}

	///	<summary>
	///	What the conditions of the attacker and of the target do to an attack roll: the attacker blinded, frightened,
	///	poisoned, prone or restrained has disadvantage, invisible advantage; a target blinded, paralyzed, petrified,
	///	restrained, stunned or unconscious is easier to hit, an invisible one harder, a prone one easier up close and
	///	harder from afar; a hit within 5 feet on a paralyzed or unconscious target is a critical hit; past the normal
	///	range the attack has disadvantage. Mode is the advantage (1) or disadvantage (-1) chosen by hand.
	///	</summary>
	public static AttackEffect Effect(IReadOnlyCollection<string> attacker, IReadOnlyCollection<string> target, int gap, bool longRange, int mode = 0)
	{
		var advantage = mode > 0;
		var disadvantage = mode < 0 || longRange;
		var causes = new List<string>();
		foreach (var key in new[] { "blinded", "frightened", "poisoned", "prone", "restrained" }.Where(attacker.Contains))
		{
			disadvantage = true;
			causes.Add(key);
		}
		if (attacker.Contains("invisible"))
		{
			advantage = true;
			causes.Add("invisible");
		}
		foreach (var key in new[] { "blinded", "paralyzed", "petrified", "restrained", "stunned", "unconscious" }.Where(target.Contains))
		{
			advantage = true;
			causes.Add(key);
		}
		if (target.Contains("invisible"))
		{
			disadvantage = true;
			causes.Add("invisible");
		}
		if (target.Contains("prone"))
		{
			if (gap <= 1)
			{
				advantage = true;
			}
			else
			{
				disadvantage = true;
			}
			causes.Add("prone");
		}
		var critical = gap <= 1 && (target.Contains("paralyzed") || target.Contains("unconscious"));
		return new AttackEffect(advantage, disadvantage, critical, causes.Distinct().ToList());
	}

	///	<summary>
	///	The damage of a critical hit: every die of the expression rolled twice ("1d8+3" → "2d8+3").
	///	</summary>
	public static string Critical(string expression) => CriticalDice().Replace(expression, m =>
		$"{(m.Groups["n"].Value.Length == 0 ? 1 : int.Parse(m.Groups["n"].Value, CultureInfo.InvariantCulture)) * 2}d{m.Groups["s"].Value}");

	[GeneratedRegex(@"(?<n>\d*)d(?<s>\d+)")]
	private static partial Regex CriticalDice();

	[GeneratedRegex(@"\b(?:portata|reach)\s+(?<n>\d+(?:[.,]\d+)?)\s*(?<unit>m|ft|feet)\b", RegexOptions.IgnoreCase)]
	private static partial Regex ReachText();

	[GeneratedRegex(@"\b(?:gittata|range)\s+(?<n>\d+(?:[.,]\d+)?)(?:\s*/\s*(?<far>\d+(?:[.,]\d+)?))?\s*(?<unit>m|ft|feet)\b", RegexOptions.IgnoreCase)]
	private static partial Regex RangeText();

	[GeneratedRegex(@"^(?:self|incantatore|s[ée] stess[oa])\b", RegexOptions.IgnoreCase)]
	private static partial Regex SelfText();

	[GeneratedRegex(@"^(?:touch|contatto)\b", RegexOptions.IgnoreCase)]
	private static partial Regex TouchText();

	[GeneratedRegex(@"^(?<n>\d+(?:[.,]\d+)?)\s*(?<unit>metri|metro|m|feet|foot|ft)\b", RegexOptions.IgnoreCase)]
	private static partial Regex DistanceText();

	//	"sfera del raggio di 6 metri", "cilindro del raggio di 3 metri", "raggio di 9 metri", "sfera con un raggio massimo di 3 metri"
	[GeneratedRegex(@"(?:(?:sfera|semisfera|emisfera|cilindro)[^.,;]{0,25}?\s)?raggio\s+(?:massimo\s+)?di\s+(?<n>\d+(?:,\d+)?)\s*(?<unit>m)etri", RegexOptions.IgnoreCase)]
	private static partial Regex SphereIt();

	//	"cubo con spigolo di 6 metri", "cubo di 4,5 metri", "quadrato di 6 metri", "quadrato fino a 6 metri"
	[GeneratedRegex(@"(?:cubo|quadrato)\s+(?:con\s+(?:uno\s+)?spigolo\s+di|con\s+lato\s+di|di\s+lato|fino\s+a|di)\s+(?<n>\d+(?:,\d+)?)\s*(?<unit>m)etri", RegexOptions.IgnoreCase)]
	private static partial Regex CubeIt();

	[GeneratedRegex(@"cono\s+(?:lungo\s+)?di\s+(?<n>\d+(?:,\d+)?)\s*(?<unit>m)etri", RegexOptions.IgnoreCase)]
	private static partial Regex ConeIt();

	[GeneratedRegex(@"linea\s+(?:lunga\s+)?(?:di\s+)?(?<n>\d+(?:,\d+)?)\s*(?<unit>m)etri", RegexOptions.IgnoreCase)]
	private static partial Regex LineIt();

	//	"20-foot-radius sphere", "10-foot radius", "30-foot-radius, 40-foot-high cylinder"
	[GeneratedRegex(@"(?<n>\d+)-(?<unit>f)oot[- ]radius", RegexOptions.IgnoreCase)]
	private static partial Regex SphereEn();

	[GeneratedRegex(@"(?<n>\d+)-(?<unit>f)oot[- ](?:cube|square)", RegexOptions.IgnoreCase)]
	private static partial Regex CubeEn();

	[GeneratedRegex(@"(?<n>\d+)-(?<unit>f)oot[- ]cone", RegexOptions.IgnoreCase)]
	private static partial Regex ConeEn();

	[GeneratedRegex(@"(?<n>\d+)-(?<unit>f)oot[- ](?:long\s+)?line", RegexOptions.IgnoreCase)]
	private static partial Regex LineEn();

	// ===== The damage and the effect of a statblock attack =====

	///	<summary>
	///	Every damage of an attack's text joined into one expression: "7 (1d8 + 3) slashing damage plus 3 (1d6) fire
	///	damage" → "1d8+3+1d6"; a flat damage ("1 piercing damage") when it has no dice; null without damage.
	///	</summary>
	public static string? DamageOf(string? text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		var groups = DamageDice().Matches(text).Select(m => m.Groups[1].Value.Replace("−", "-").Replace(" ", string.Empty)).ToList();
		if (groups.Count > 0)
		{
			return string.Join("+", groups).Replace("+-", "-");
		}
		var flat = FlatDamage().Match(text);
		return flat.Success ? flat.Groups["n"].Value : null;
	}

	//	The words of a condition in both languages (masculine and feminine, singular and plural in Italian)
	private static readonly (string Key, Regex Words)[] ConditionWords =
	{
		("prone", new Regex(@"\bprone\b|\bpron[oaie]\b", RegexOptions.IgnoreCase)),
		("grappled", new Regex(@"\bgrappled\b|\bafferrat[oaie]\b", RegexOptions.IgnoreCase)),
		("restrained", new Regex(@"\brestrained\b|\btrattenut[oaie]\b", RegexOptions.IgnoreCase)),
		("poisoned", new Regex(@"\bpoisoned\b|\bavvelenat[oaie]\b", RegexOptions.IgnoreCase)),
		("frightened", new Regex(@"\bfrightened\b|\bspaventat[oaie]\b", RegexOptions.IgnoreCase)),
		("paralyzed", new Regex(@"\bparalyzed\b|\bparalizzat[oaie]\b", RegexOptions.IgnoreCase)),
		("stunned", new Regex(@"\bstunned\b|\bstordit[oaie]\b", RegexOptions.IgnoreCase)),
		("blinded", new Regex(@"\bblinded\b|\baccecat[oaie]\b", RegexOptions.IgnoreCase)),
		("charmed", new Regex(@"\bcharmed\b|\baffascinat[oaie]\b", RegexOptions.IgnoreCase)),
		("deafened", new Regex(@"\bdeafened\b|\bassordat[oaie]\b", RegexOptions.IgnoreCase)),
		("petrified", new Regex(@"\bpetrified\b|\bpietrificat[oaie]\b", RegexOptions.IgnoreCase)),
		("incapacitated", new Regex(@"\bincapacitated\b|\bincapacitat[oaie]\b", RegexOptions.IgnoreCase)),
		("unconscious", new Regex(@"\bunconscious\b|\bprivo di sensi\b|\bpriva di sensi\b", RegexOptions.IgnoreCase))
	};

	///	<summary>
	///	The condition an attack's text gives on a hit (the first one named: "the target is grappled (escape DC 13)",
	///	"il bersaglio è afferrato"); null when it names none.
	///	</summary>
	public static string? ConditionOf(string? text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		return ConditionWords
			.Select(c => (c.Key, Match: c.Words.Match(text)))
			.Where(c => c.Match.Success)
			.OrderBy(c => c.Match.Index)
			.Select(c => c.Key)
			.FirstOrDefault();
	}

	///	<summary>The name of a condition for the log of the table.</summary>
	public static string ConditionName(string key, bool italian) => (key, italian) switch
	{
		("blinded", true) => "accecato", ("charmed", true) => "affascinato", ("deafened", true) => "assordato",
		("frightened", true) => "spaventato", ("grappled", true) => "afferrato", ("incapacitated", true) => "incapacitato",
		("invisible", true) => "invisibile", ("paralyzed", true) => "paralizzato", ("petrified", true) => "pietrificato",
		("poisoned", true) => "avvelenato", ("prone", true) => "prono", ("restrained", true) => "trattenuto",
		("stunned", true) => "stordito", ("unconscious", true) => "privo di sensi", ("exhaustion", true) => "indebolimento",
		("concentrating", true) => "concentrazione",
		_ => key
	};

	[GeneratedRegex(@"\((\d+d\d+(?:\s*[+\-−]\s*\d+)?)\)")]
	private static partial Regex DamageDice();

	[GeneratedRegex(@"(?:Hit|Colpito)\s*:\s*(?<n>\d+)\s+(?:danni|\p{L}+\s+damage)", RegexOptions.IgnoreCase)]
	private static partial Regex FlatDamage();
}

///	<summary>
///	What a token carries besides its sheet: the loot of a monster or an NPC (taken when it is beaten), the item lying
///	on the ground of a dropped-item token, the attacks of a statblock it can no longer make (its weapon was dropped).
///	</summary>
public sealed class TokenGear
{
	public List<TokenItem> Items { get; set; } = new();
	public List<string> Disarmed { get; set; } = new();
	public int Coins { get; set; }

	public bool IsEmpty => Items.Count == 0 && Disarmed.Count == 0 && Coins == 0;

	public const int MaxItems = 40;
}

///	<summary>
///	An item a token carries: its name, how many, the compendium item it is (if any) and, for one dropped from a
///	character, the inventory entry as it was (magic, charges) to give it back as it was.
///	</summary>
public sealed class TokenItem
{
	public string Name { get; set; } = string.Empty;
	public int Quantity { get; set; } = 1;
	public Guid? EquipmentId { get; set; }
	public string? Entry { get; set; }

	//	The statblock attack it is the weapon of (a monster's dropped weapon), to give the attack back
	public string? Attack { get; set; }
}
