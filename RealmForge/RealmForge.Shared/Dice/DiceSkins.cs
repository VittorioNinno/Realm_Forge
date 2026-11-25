using System.Security.Cryptography;
using System.Text;

namespace RealmForge.Shared.Dice;

///	<summary>
///	The looks of the 3D dice. Resin (in any colour) is everyone's; the special dice are unlocked with a code, an easter
///	egg: the codes live in a table, as hashes, never in the code.
///	</summary>
public static class DiceSkins
{
	public const string Resin = "resin";
	public const string Ember = "ember";
	public const string Stardust = "stardust";

	///	<summary>The special dice, in the order they are shown.</summary>
	public static readonly IReadOnlyList<string> Special = [Ember, Stardust];

	public static bool IsKnown(string? skin) => skin == Resin || Special.Contains(skin);

	///	<summary>A code as it is compared: capitals and digits only ("fiato di drago" = "FIATO-DI-DRAGO").</summary>
	public static string Normalize(string? code) =>
		new((code ?? string.Empty).ToUpperInvariant().Where(c => c is >= 'A' and <= 'Z' or >= '0' and <= '9').ToArray());

	///	<summary>The hash a code is stored as (SHA-256 of the normalized code, lowercase hex).</summary>
	public static string Hash(string? code) =>
		Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(Normalize(code)))).ToLowerInvariant();
}
