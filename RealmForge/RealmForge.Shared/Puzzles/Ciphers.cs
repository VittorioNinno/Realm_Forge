using System.Globalization;
using System.Text;

namespace RealmForge.Shared.Puzzles;

public enum CipherKind
{
	Caesar = 1,
	Vigenere = 2,
	Atbash = 3,
	Runes = 4,
	Draconic = 5,
	Numbers = 6
}

///	<summary>
///	The ciphers of the riddles lab: Caesar (a shift), Vigenère (a keyword), Atbash (the alphabet backwards), runes and
///	draconic glyphs (one symbol per letter) and numbers (A=1 … Z=26). Letters lose their accents first; what is not a
///	letter stays as it is (numbers: words split by " / ").
///	</summary>
public static class Ciphers
{
	//	The draconic script of RealmForge: invented, one glyph per letter
	private static readonly string[] DraconicGlyphs =
	[
		"⟁", "⟒", "⟟", "⏃", "⎍", "⟓", "⊑", "⏁", "⟊", "⌇", "⋔", "⌰", "⍜", "⋏", "⊬", "⏚", "⍀", "☌", "⏄", "⟐", "⍙", "⌿", "⍾", "⎎", "⊛", "⋉"
	];

	//	Elder Futhark, one rune per Latin letter (the missing ones borrowed from the nearest sound)
	private static readonly string[] Runes = ["ᚨ", "ᛒ", "ᚲ", "ᛞ", "ᛖ", "ᚠ", "ᚷ", "ᚺ", "ᛁ", "ᛃ", "ᚴ", "ᛚ", "ᛗ", "ᚾ", "ᛟ", "ᛈ", "ᛩ", "ᚱ", "ᛋ", "ᛏ", "ᚢ", "ᚡ", "ᚹ", "ᛪ", "ᛇ", "ᛉ"];

	public static bool NeedsKey(CipherKind kind) => kind is CipherKind.Caesar or CipherKind.Vigenere;

	//	The text without accents, in capitals
	public static string Plain(string? text)
	{
		var decomposed = (text ?? string.Empty).Normalize(NormalizationForm.FormD);
		var sb = new StringBuilder(decomposed.Length);
		foreach (var c in decomposed)
		{
			if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
			{
				sb.Append(char.ToUpperInvariant(c));
			}
		}
		return sb.ToString().Normalize(NormalizationForm.FormC);
	}

	//	An answer as it is compared: letters and digits only, no accents, in capitals
	public static string Normalize(string? answer) => new(Plain(answer).Where(char.IsLetterOrDigit).ToArray());

	//	A solution among those written by the master ("|" separates the accepted ones)
	public static bool Matches(string? answer, string? accepted)
	{
		var given = Normalize(answer);
		return given.Length > 0 && (accepted ?? string.Empty).Split('|').Any(a => Normalize(a) == given);
	}

	public static int Shift(string? key) => int.TryParse(key?.Trim(), out var n) ? ((n % 26) + 26) % 26 : 3;

	public static string Encode(CipherKind kind, string? text, string? key = null) => kind switch
	{
		CipherKind.Caesar => Rotate(text, i => Shift(key)),
		CipherKind.Vigenere => Vigenere(text, key, +1),
		CipherKind.Atbash => Map(text, i => ((char)('Z' - i)).ToString()),
		CipherKind.Runes => Map(text, i => Runes[i]),
		CipherKind.Draconic => Map(text, i => DraconicGlyphs[i]),
		CipherKind.Numbers => Numbers(text),
		_ => text ?? string.Empty
	};

	public static string Decode(CipherKind kind, string? text, string? key = null) => kind switch
	{
		CipherKind.Caesar => Rotate(text, i => 26 - Shift(key)),
		CipherKind.Vigenere => Vigenere(text, key, -1),
		CipherKind.Atbash => Encode(CipherKind.Atbash, text),
		CipherKind.Runes => Unmap(text, Runes),
		CipherKind.Draconic => Unmap(text, DraconicGlyphs),
		CipherKind.Numbers => FromNumbers(text),
		_ => text ?? string.Empty
	};

	private static string Rotate(string? text, Func<int, int> shift)
	{
		var sb = new StringBuilder();
		var n = 0;
		foreach (var c in Plain(text))
		{
			sb.Append(c is >= 'A' and <= 'Z' ? (char)('A' + (c - 'A' + shift(n++)) % 26) : c);
		}
		return sb.ToString();
	}

	private static string Vigenere(string? text, string? key, int sign)
	{
		var shifts = Plain(key).Where(c => c is >= 'A' and <= 'Z').Select(c => c - 'A').ToArray();
		if (shifts.Length == 0)
		{
			return Plain(text);
		}
		return Rotate(text, i => (26 + sign * shifts[i % shifts.Length]) % 26);
	}

	private static string Map(string? text, Func<int, string> glyph)
	{
		var sb = new StringBuilder();
		foreach (var c in Plain(text))
		{
			sb.Append(c is >= 'A' and <= 'Z' ? glyph(c - 'A') : c.ToString());
		}
		return sb.ToString();
	}

	private static string Unmap(string? text, string[] glyphs)
	{
		var sb = new StringBuilder();
		var source = text ?? string.Empty;
		for (var i = 0; i < source.Length;)
		{
			var hit = -1;
			for (var g = 0; g < glyphs.Length && hit < 0; g++)
			{
				if (string.CompareOrdinal(source, i, glyphs[g], 0, glyphs[g].Length) == 0)
				{
					hit = g;
				}
			}
			if (hit >= 0)
			{
				sb.Append((char)('A' + hit));
				i += glyphs[hit].Length;
			}
			else
			{
				sb.Append(source[i]);
				i++;
			}
		}
		return sb.ToString();
	}

	//	"ciao mondo" → "3-9-1-15 / 13-15-14-4-15"
	private static string Numbers(string? text) => string.Join(" / ", Plain(text)
		.Split(' ', StringSplitOptions.RemoveEmptyEntries)
		.Select(word => string.Join("-", word.Select(c => c is >= 'A' and <= 'Z' ? (c - 'A' + 1).ToString(CultureInfo.InvariantCulture) : c.ToString()))));

	private static string FromNumbers(string? text) => string.Join(" ", (text ?? string.Empty)
		.Split('/', StringSplitOptions.RemoveEmptyEntries)
		.Select(word => new string(word.Split('-', StringSplitOptions.RemoveEmptyEntries)
			.Select(n => int.TryParse(n.Trim(), out var v) && v is >= 1 and <= 26 ? (char)('A' + v - 1) : '?').ToArray())));
}
