using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

public enum GrantedSpellKind
{
	//	Always prepared from the class level of the row, not counted among the spells to prepare
	Prepared = 1,

	//	2014 warlock patrons: spells added to the class list (the row is the spell level)
	Expanded = 2
}

public sealed record SubclassSpellRow(int Level, IReadOnlyList<string> Spells);

///	<summary>
///	A spell table of a subclass; Option is the land of the Circle of the Land (null for the others).
///	</summary>
public sealed record SubclassSpellTable(RulesetVersion Ruleset, string Subclass, string? Option, GrantedSpellKind Kind, IReadOnlyList<SubclassSpellRow> Rows);

///	<summary>
///	Spells a subclass gives on its own: the tables of its features (generated, <see cref="Tables"/>) and the single
///	spells named in a feature text ("<i>Counterspell</i> and <i>Dispel Magic</i> are always prepared for you").
///	Keys are the spell keys of the Base content ("cure-wounds").
///	</summary>
public static partial class SubclassSpells
{
	//	Spells named in a feature, from the class level of the feature
	private static readonly SubclassSpellTable[] Singles =
	{
		new(RulesetVersion.Dnd5e_2014, "light-domain", null, GrantedSpellKind.Prepared, new SubclassSpellRow[] { new(1, new[] { "light" }) }),
		new(RulesetVersion.Dnd5e_2024, "abjurer", null, GrantedSpellKind.Prepared, new SubclassSpellRow[] { new(10, new[] { "counterspell", "dispel-magic" }) }),
		new(RulesetVersion.Dnd5e_2024, "circle-of-the-stars", null, GrantedSpellKind.Prepared, new SubclassSpellRow[] { new(3, new[] { "guidance", "guiding-bolt" }) }),
		new(RulesetVersion.Dnd5e_2024, "college-of-glamour", null, GrantedSpellKind.Prepared, new SubclassSpellRow[] { new(3, new[] { "charm-person", "mirror-image" }), new(6, new[] { "command" }) }),
		new(RulesetVersion.Dnd5e_2024, "illusionist", null, GrantedSpellKind.Prepared, new SubclassSpellRow[] { new(3, new[] { "minor-illusion" }), new(6, new[] { "summon-beast", "summon-fey" }) }),
		new(RulesetVersion.Dnd5e_2024, "path-of-the-wild-heart", null, GrantedSpellKind.Prepared, new SubclassSpellRow[] { new(3, new[] { "beast-sense", "speak-with-animals" }) })
	};

	private static IEnumerable<SubclassSpellTable> All => Tables.Concat(Singles);

	//	Lands of the Circle of the Land
	public static IReadOnlyList<string> Options(RulesetVersion ruleset, string? subclass) =>
		subclass is null ? Array.Empty<string>() : Tables.Where(t => t.Ruleset == ruleset && t.Subclass == subclass && t.Option is not null).Select(t => t.Option!).ToList();

	///	<summary>
	///	Spells always prepared at this class level (a subclass with lands needs the land chosen).
	///	</summary>
	public static IReadOnlyList<string> Prepared(RulesetVersion ruleset, string? subclass, string? option, int classLevel) =>
		subclass is null
			? Array.Empty<string>()
			: All.Where(t => t.Ruleset == ruleset && t.Subclass == subclass && t.Kind == GrantedSpellKind.Prepared && (t.Option is null || t.Option == option))
				.SelectMany(t => t.Rows.Where(r => r.Level <= classLevel).SelectMany(r => r.Spells))
				.Distinct()
				.ToList();

	///	<summary>
	///	Spells the subclass adds to the class list (2014 patrons' Expanded Spell List).
	///	</summary>
	public static IReadOnlyList<string> Expanded(RulesetVersion ruleset, string? subclass) =>
		subclass is null
			? Array.Empty<string>()
			: All.Where(t => t.Ruleset == ruleset && t.Subclass == subclass && t.Kind == GrantedSpellKind.Expanded)
				.SelectMany(t => t.Rows.SelectMany(r => r.Spells))
				.Distinct()
				.ToList();
}
