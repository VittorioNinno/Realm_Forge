using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

///	<summary>
///	What changes a character's spells at the table: the sorcerer's Metamagic (paid with Sorcery Points), the
///	Evocation wizard's Sculpt Spells, Potent Cantrip and Empowered Evocation, the warlock's Agonizing Blast.
///	</summary>
public sealed record CastingOptions(
	string? PointsKey,
	IReadOnlyList<string> Metamagic,
	int Charisma,
	bool SculptSpells,
	int SculptCount,
	bool PotentCantrip,
	int EmpoweredEvocation,
	int AgonizingBlast)
{
	public static readonly CastingOptions None = new(null, Array.Empty<string>(), 0, false, 0, false, 0, 0);

	public bool Has(string option) => Metamagic.Contains(option);

	//	The Metamagic options, by key, with their cost in Sorcery Points
	public static readonly IReadOnlyList<(string Key, int Cost)> All = new[]
	{
		("careful", 1), ("distant", 1), ("empowered", 1), ("extended", 1), ("heightened", 2),
		("quickened", 2), ("seeking", 1), ("subtle", 1), ("transmuted", 1), ("twinned", 1)
	};

	public static int CostOf(string option) => All.FirstOrDefault(o => o.Key == option).Cost;

	//	The names an option goes by in the options written on the sheet (Italian and English, both editions)
	private static readonly Dictionary<string, string[]> Names = new()
	{
		["careful"] = new[] { "careful", "preciso", "accurato", "attento" },
		["distant"] = new[] { "distant", "distante" },
		["empowered"] = new[] { "empowered", "potenziato" },
		["extended"] = new[] { "extended", "esteso" },
		["heightened"] = new[] { "heightened", "intensificato", "amplificato" },
		["quickened"] = new[] { "quickened", "rapido", "accelerato" },
		["seeking"] = new[] { "seeking", "mirato", "ricercato" },
		["subtle"] = new[] { "subtle", "celato", "sottile" },
		["transmuted"] = new[] { "transmuted", "trasmutato" },
		["twinned"] = new[] { "twinned", "raddoppiato", "gemello" }
	};

	///	<summary>
	///	The options of a character: the Metamagic it wrote among its feature options (all of them when it wrote none),
	///	the features of its subclass and its invocations.
	///	</summary>
	public static CastingOptions For(ComputedCharacter c, string? featureNotes)
	{
		var notes = (featureNotes ?? string.Empty).ToLowerInvariant();
		var is2014 = c.Ruleset == RulesetVersion.Dnd5e_2014;
		var sorcerer = c.ClassLevel("sorcerer");
		var metamagic = new List<string>();
		if (sorcerer >= (is2014 ? 3 : 2))
		{
			metamagic.AddRange(Names.Where(n => n.Value.Any(notes.Contains)).Select(n => n.Key));
			if (metamagic.Count == 0)
			{
				metamagic.AddRange(All.Select(o => o.Key).Where(k => !is2014 || k is not ("seeking" or "transmuted")));
			}
		}
		var wizard = c.Classes.FirstOrDefault(x => x.Class.Key == "wizard");
		var evoker = wizard?.Subclass?.Key is "school-of-evocation" or "evoker" ? wizard.Level : 0;
		var intelligence = Math.Max(0, c.Modifier(AbilityScore.Intelligence));
		var charisma = c.Modifier(AbilityScore.Charisma);
		var agonizing = c.ClassLevel("warlock") > 0 && (notes.Contains("agonizing") || notes.Contains("agonizzante")) ? Math.Max(0, charisma) : 0;
		return new CastingOptions(
			metamagic.Count > 0 ? "sorcerer-points" : null,
			metamagic,
			charisma,
			evoker >= (is2014 ? 2 : 6),
			evoker > 0 ? 1 : 0,
			evoker >= (is2014 ? 6 : 3),
			evoker >= 10 ? intelligence : 0,
			agonizing);
	}
}
