namespace RealmForge.Shared.DTOs
{
	///	<summary>The special dice a user has unlocked (resin is always there).</summary>
	public record DiceSkinsDto(List<string> Unlocked);

	public class DiceUnlockDto
	{
		public string Code { get; set; } = string.Empty;
	}

	///	<summary>Skin: what the code unlocked (null: no such code); New: unlocked now, not before.</summary>
	public record DiceUnlockResultDto(string? Skin, bool New, List<string> Unlocked);
}
