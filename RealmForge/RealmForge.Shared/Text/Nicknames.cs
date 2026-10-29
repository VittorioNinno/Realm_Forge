using System.Text.RegularExpressions;

namespace RealmForge.Shared.Text;

///	<summary>
///	Public names of the accounts: what the other players see instead of the e-mail address.
///	</summary>
public static partial class Nicknames
{
	public const int MinLength = 3;
	public const int MaxLength = 24;

	//	Letters (accented too), digits, spaces, dots, dashes and underscores; starts with a letter or a digit
	[GeneratedRegex(@"^[\p{L}\p{N}][\p{L}\p{N} ._\-]*$")]
	private static partial Regex Allowed();

	///	<summary>
	///	The nickname as stored: trimmed, inner spaces collapsed; null when empty.
	///	</summary>
	public static string? Clean(string? value)
	{
		var text = Regex.Replace(value?.Trim() ?? string.Empty, @"\s+", " ");
		return text.Length == 0 ? null : text;
	}

	public static bool IsValid(string? nickname) =>
		nickname is not null && nickname.Length is >= MinLength and <= MaxLength && Allowed().IsMatch(nickname);

	//	The form the uniqueness is checked on ("Sylas" and "SYLAS" are the same name)
	public static string Normalize(string nickname) => nickname.ToUpperInvariant();

	///	<summary>
	///	What other players see: the nickname, or the first letters of the e-mail when there is none (never the address).
	///	</summary>
	public static string Display(string? nickname, string? email)
	{
		if (!string.IsNullOrWhiteSpace(nickname))
		{
			return nickname;
		}
		var local = email?.Split('@')[0] ?? string.Empty;
		return local.Length == 0 ? "•••" : local[..Math.Min(2, local.Length)] + "•••";
	}
}
