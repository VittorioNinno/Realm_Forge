using System.Text.RegularExpressions;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Rules;
using RealmForge.Shared.Text;

namespace RealmForge.Shared.Characters;

///	<summary>
///	Rules read from the English texts of the compendium: starting equipment as language-safe choices, the ability
///	increases of the feats and the free languages of the 2014 backgrounds.
///	</summary>
public static partial class CharacterTextRules
{
	///	<summary>
	///	Starting equipment of a class or background: the structure (kits, rows, options, items, quantities, coins,
	///	generic picks, compendium ids) always comes from the English text; the labels come from the localized text
	///	when it has the same structure, otherwise from the English one.
	///	</summary>
	public static ContextLoadout Loadout(string? englishText, string? localizedText, bool background, int? goldAlternative,
		LanguageCode lang, Func<string, Guid?> findItem)
	{
		var english = Parse(englishText, background, goldAlternative, LanguageCode.En);
		if (english.IsEmpty)
		{
			return ContextLoadout.Empty;
		}

		var localized = lang == LanguageCode.En || string.IsNullOrWhiteSpace(localizedText)
			? english
			: Parse(localizedText, background, goldAlternative, lang);
		if (!SameShape(english, localized))
		{
			localized = english;
		}

		ContextLoadoutOption Option(LoadoutOption en, LoadoutOption loc) => new(
			en.Letter ?? string.Empty,
			en.Items.Select((item, i) => Item(item, loc.Items[i], findItem)).ToList());

		return new ContextLoadout(
			english.Kits.Select((kit, k) => Option(kit, localized.Kits[k])).ToList(),
			english.Rows.Select((row, r) => new ContextLoadoutRow(row.Options.Select((o, i) => Option(o, localized.Rows[r].Options[i])).ToList())).ToList());
	}

	private static EquipmentLoadout Parse(string? text, bool background, int? gold, LanguageCode lang) => background
		? EquipmentLoadout.FromBackground(text, gold is null ? null : lang == LanguageCode.It ? $"{gold} mo" : $"{gold} GP")
		: EquipmentLoadout.FromClassText(text);

	public static bool SameShape(EquipmentLoadout a, EquipmentLoadout b) =>
		a.Kits.Count == b.Kits.Count && a.Rows.Count == b.Rows.Count
		&& a.Kits.Zip(b.Kits).All(p => p.First.Letter == p.Second.Letter && p.First.Items.Count == p.Second.Items.Count)
		&& a.Rows.Zip(b.Rows).All(p => p.First.Options.Count == p.Second.Options.Count
			&& p.First.Options.Zip(p.Second.Options).All(o => o.First.Letter == o.Second.Letter && o.First.Items.Count == o.Second.Items.Count));

	private static ContextLoadoutItem Item(LoadoutItem english, LoadoutItem localized, Func<string, Guid?> findItem)
	{
		var label = string.Join(" ", new[] { localized.Text, localized.Coins }.Where(p => !string.IsNullOrWhiteSpace(p))).Trim();
		var text = english.Text.Trim();

		//	Coins: "15 GP", "a pouch containing 10 gp" (the pouch and the coins)
		int? amount = null;
		CoinType? type = null;
		var coins = Coins().Match(english.Coins ?? text);
		if (coins.Success)
		{
			amount = int.Parse(coins.Groups[1].Value);
			type = coins.Groups[2].Value.ToLowerInvariant() switch
			{
				"cp" => CoinType.Cp,
				"sp" => CoinType.Sp,
				"ep" => CoinType.Ep,
				"pp" => CoinType.Pp,
				_ => CoinType.Gp
			};
			text = Coins().Replace(text, string.Empty).Trim();
			if (text.Length == 0)
			{
				return new ContextLoadoutItem(label, 1, null, amount, type, null);
			}
		}

		//	"any martial melee weapon", "two simple melee weapons", "any other musical instrument"
		var pick = Pick().Match(text);
		if (pick.Success && amount is null)
		{
			var count = Number(pick.Groups["count"].Value) ?? 1;
			var kind = pick.Groups["instrument"].Success
				? LoadoutPickKind.MusicalInstrument
				: pick.Groups["category"].Value.Equals("martial", StringComparison.OrdinalIgnoreCase) ? LoadoutPickKind.MartialWeapon : LoadoutPickKind.SimpleWeapon;
			return new ContextLoadoutItem(label, count, null, null, null, new LoadoutPick(kind, pick.Groups["melee"].Success, count));
		}

		var quantity = english.Quantity ?? LeadingQuantity(text);
		return new ContextLoadoutItem(label, Math.Max(1, quantity ?? 1), findItem(text), amount, type, null);
	}

	private static int? LeadingQuantity(string text)
	{
		var m = LeadingNumber().Match(text);
		return m.Success ? Number(m.Groups[1].Value) : null;
	}

	private static int? Number(string word) => word.Trim().ToLowerInvariant() switch
	{
		"" => null,
		"a" or "an" or "one" or "any" => 1,
		"two" => 2,
		"three" => 3,
		"four" => 4,
		"five" => 5,
		"six" => 6,
		"eight" => 8,
		"ten" => 10,
		var n when int.TryParse(n, out var v) => v,
		_ => null
	};

	///	<summary>
	///	Abilities raised by a feat's "Ability Score Increase" (all six for "of your choice"), with the maximum; none
	///	when the feat raises no ability.
	///	</summary>
	public static (List<AbilityScore> Abilities, int Maximum) FeatIncreases(string? englishDescription)
	{
		foreach (var sentence in (englishDescription ?? string.Empty).Replace("\r", string.Empty).Split('\n'))
		{
			if (!sentence.Contains("by 1", StringComparison.Ordinal) || !sentence.Contains("ncrease", StringComparison.Ordinal))
			{
				continue;
			}

			var maximum = Maximum().Match(sentence) is { Success: true } m ? int.Parse(m.Groups[1].Value) : 20;
			if (AnyAbility().IsMatch(sentence))
			{
				return (CharacterMath.Abilities.ToList(), maximum);
			}

			var abilities = CharacterMath.Abilities
				.Where(a => sentence.Contains(a.ToString(), StringComparison.Ordinal))
				.ToList();
			if (abilities.Count > 0)
			{
				return (abilities, maximum);
			}
		}

		return (new List<AbilityScore>(), 20);
	}

	///	<summary>
	///	"Two of your choice" → 2 (2014 backgrounds).
	///	</summary>
	public static int LanguageChoices(string? englishLanguages)
	{
		var m = LanguageCount().Match(englishLanguages ?? string.Empty);
		return m.Success ? Number(m.Groups[1].Value) ?? 0 : 0;
	}

	[GeneratedRegex(@"(?:^|\b)(\d+)\s*(gp|sp|cp|ep|pp)\b", RegexOptions.IgnoreCase)]
	private static partial Regex Coins();

	[GeneratedRegex(@"\b(?:(?<count>any|two|three|a|an)\s+)?(?:other\s+)?(?:(?<category>simple|martial)(?<melee>\s+melee)?\s+weapons?|(?<instrument>musical\s+instrument))\b", RegexOptions.IgnoreCase)]
	private static partial Regex Pick();

	[GeneratedRegex(@"^(\d+|two|three|four|five|six|eight|ten)\s+", RegexOptions.IgnoreCase)]
	private static partial Regex LeadingNumber();

	[GeneratedRegex(@"maximum of (\d+)")]
	private static partial Regex Maximum();

	[GeneratedRegex(@"of your choice|Choose one ability|Choose an ability", RegexOptions.IgnoreCase)]
	private static partial Regex AnyAbility();

	[GeneratedRegex(@"^\s*(one|two|three|\d+)\s+of your choice", RegexOptions.IgnoreCase)]
	private static partial Regex LanguageCount();
}
