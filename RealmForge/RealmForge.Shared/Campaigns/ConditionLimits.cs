namespace RealmForge.Shared.Campaigns;

///	<summary>
///	What a condition stops a creature from doing, in a few words: the same lines on the table, on the sheet and in the
///	refusals of the server, so a player knows at once why an action is out of reach and which condition is the cause.
///	</summary>
public static class ConditionLimits
{
	//	No actions and no reactions
	public static readonly IReadOnlyList<string> NoActions = new[] { "unconscious", "paralyzed", "petrified", "stunned", "incapacitated" };

	//	Speed 0: the creature does not move by itself (a master moves it anyway)
	public static readonly IReadOnlyList<string> NoMove = new[] { "unconscious", "paralyzed", "petrified", "restrained", "grappled" };

	//	The order the limits are listed in: the heaviest first
	private static readonly IReadOnlyList<string> Order = new[]
	{
		"unconscious", "paralyzed", "petrified", "stunned", "incapacitated", "restrained", "grappled", "frightened", "charmed",
		"blinded", "poisoned", "prone", "deafened"
	};

	///	<summary>The condition that stops any action, if one does</summary>
	public static string? ActionBlocker(IEnumerable<string>? conditions) => First(conditions, NoActions);

	///	<summary>The condition that holds the creature in place, if one does</summary>
	public static string? MoveBlocker(IEnumerable<string>? conditions) => First(conditions, NoMove);

	///	<summary>The conditions with a limit worth telling, the heaviest first</summary>
	public static IReadOnlyList<string> Limiting(IEnumerable<string>? conditions)
	{
		var set = conditions?.ToHashSet() ?? new HashSet<string>();
		return Order.Where(set.Contains).ToList();
	}

	///	<summary>The name of a condition</summary>
	public static string Name(string key, bool italian) => key switch
	{
		"blinded" => T(italian, "Accecato", "Blinded"),
		"charmed" => T(italian, "Affascinato", "Charmed"),
		"deafened" => T(italian, "Assordato", "Deafened"),
		"frightened" => T(italian, "Spaventato", "Frightened"),
		"grappled" => T(italian, "Afferrato", "Grappled"),
		"incapacitated" => T(italian, "Incapacitato", "Incapacitated"),
		"invisible" => T(italian, "Invisibile", "Invisible"),
		"paralyzed" => T(italian, "Paralizzato", "Paralyzed"),
		"petrified" => T(italian, "Pietrificato", "Petrified"),
		"poisoned" => T(italian, "Avvelenato", "Poisoned"),
		"prone" => T(italian, "Prono", "Prone"),
		"restrained" => T(italian, "Trattenuto", "Restrained"),
		"stunned" => T(italian, "Stordito", "Stunned"),
		"unconscious" => T(italian, "Privo di sensi", "Unconscious"),
		"exhaustion" => T(italian, "Indebolimento", "Exhaustion"),
		"concentrating" => T(italian, "Concentrazione", "Concentrating"),
		_ => key
	};

	///	<summary>What the condition stops or makes harder, in a few words (null: nothing worth a warning)</summary>
	public static string? Limit(string key, bool italian) => key switch
	{
		"unconscious" => T(italian, "non agisce, non reagisce e non si muove", "no actions, no reactions, no movement"),
		"paralyzed" => T(italian, "non agisce, non reagisce e non si muove", "no actions, no reactions, no movement"),
		"petrified" => T(italian, "non agisce, non reagisce e non si muove", "no actions, no reactions, no movement"),
		"stunned" => T(italian, "non agisce e non reagisce", "no actions and no reactions"),
		"incapacitated" => T(italian, "non agisce e non reagisce", "no actions and no reactions"),
		"restrained" => T(italian, "velocità 0, attacca con svantaggio", "speed 0, attacks with disadvantage"),
		"grappled" => T(italian, "velocità 0 finché non si libera", "speed 0 until it escapes"),
		"frightened" => T(italian, "svantaggio a prove e attacchi mentre vede la fonte, non può avvicinarsi a essa", "disadvantage on checks and attacks while it sees the source, cannot move closer to it"),
		"charmed" => T(italian, "non può attaccare chi l'ha affascinato", "cannot attack the charmer"),
		"blinded" => T(italian, "attacca con svantaggio, fallisce le prove basate sulla vista", "attacks with disadvantage, fails checks that need sight"),
		"poisoned" => T(italian, "svantaggio a prove e attacchi", "disadvantage on checks and attacks"),
		"prone" => T(italian, "attacca con svantaggio, rialzarsi costa metà movimento", "attacks with disadvantage, standing up costs half the movement"),
		"deafened" => T(italian, "fallisce le prove basate sull'udito", "fails checks that need hearing"),
		_ => null
	};

	///	<summary>"Frightened: …" — the name and the limit together</summary>
	public static string Line(string key, bool italian) => Limit(key, italian) is { } limit ? $"{Name(key, italian)}: {limit}" : Name(key, italian);

	///	<summary>The refusal of an action for a creature that cannot act</summary>
	public static string NoActionText(string key, bool italian) =>
		T(italian, $"{Name(key, true)}: non può compiere azioni né reazioni.", $"{Name(key, false)}: it cannot take actions or reactions.");

	///	<summary>The refusal of a move for a creature that cannot move</summary>
	public static string NoMoveText(string key, bool italian) => key == "grappled"
		? T(italian, "Afferrato: velocità 0, non si muove finché non si libera.", "Grappled: speed 0, it cannot move until it escapes.")
		: T(italian, $"{Name(key, true)}: velocità 0, non può muoversi.", $"{Name(key, false)}: speed 0, it cannot move.");

	private static string? First(IEnumerable<string>? conditions, IReadOnlyList<string> keys)
	{
		var set = conditions?.ToHashSet() ?? new HashSet<string>();
		return keys.FirstOrDefault(set.Contains);
	}

	private static string T(bool italian, string it, string en) => italian ? it : en;
}
