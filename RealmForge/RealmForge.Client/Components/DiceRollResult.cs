using RealmForge.Shared.Rules;

namespace RealmForge.Client.Components
{
	public sealed record DieFace(int Sides, int Value, bool Dropped = false);

	///	<summary>
	///	A finished roll: the dice with their faces (a dropped die for advantage and disadvantage), the modifier and
	///	the total; the note says what it means (critical, success…).
	///	</summary>
	public sealed record DiceRollResult(string Label, List<DieFace> Dice, int Modifier, int Total, string? Note = null)
	{
		public string Text => $"{Label}: {string.Join(" + ", Dice.Where(d => !d.Dropped).Select(d => d.Value))}"
			+ (Modifier == 0 ? string.Empty : $" {CharacterMath.FormatModifier(Modifier)}") + $" = {Total}" + (Note is null ? string.Empty : $" · {Note}");
	}
}
