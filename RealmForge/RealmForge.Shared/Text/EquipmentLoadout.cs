using System.Text.RegularExpressions;

namespace RealmForge.Shared.Text
{
	///	<summary>
	///	One item of a starting equipment: its name, the quantity in front of it ("20 frecce" → 20, "frecce")
	///	and the coins it contains ("Una borsa con 15 mo" → "Una borsa con", "15 mo"; "8 GP" → "", "8 GP").
	///	</summary>
	public sealed record LoadoutItem(string Text, int? Quantity, string? Coins);

	///	<summary>
	///	One alternative: a lettered kit of the 2024 rules ("(A) Greataxe, 4 Handaxes…") or one of the choices of a line
	///	of the 2014 rules ("(a) a greataxe" or "(b) any martial melee weapon").
	///	</summary>
	public sealed record LoadoutOption(string? Letter, IReadOnlyList<LoadoutItem> Items);

	///	<summary>
	///	A line of equipment: a single entry or a choice between options.
	///	</summary>
	public sealed record LoadoutRow(IReadOnlyList<LoadoutOption> Options);

	///	<summary>
	///	Starting equipment of a class or a background in a common shape: either a choice between whole kits (A/B/C)
	///	or a list of lines, each one fixed or with a choice. Built from the stored texts, so nothing changes in the data.
	///	</summary>
	public sealed partial class EquipmentLoadout
	{
		public IReadOnlyList<LoadoutOption> Kits { get; }
		public IReadOnlyList<LoadoutRow> Rows { get; }

		public bool IsEmpty => Kits.Count == 0 && Rows.Count == 0;

		private EquipmentLoadout(IReadOnlyList<LoadoutOption> kits, IReadOnlyList<LoadoutRow> rows)
		{
			Kits = kits;
			Rows = rows;
		}

		///	<summary>
		///	Class texts: "Choose A or B:\n- (A) …\n- (B) 75 GP" (2024) or "- (a) … or (b) …\n- An explorer's pack…" (2014).
		///	Free Homebrew text becomes one line per row.
		///	</summary>
		public static EquipmentLoadout FromClassText(string? text)
		{
			var lines = (text ?? string.Empty).Replace("\r", string.Empty).Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
				.Select(l => ListMarker().Replace(l, string.Empty).Trim())
				.Where(l => l.Length > 0)
				.ToList();

			//	Whole kits: every line starts with "(A)", "(B)"…; the "Choose A or B:" line is replaced by the layout itself
			var kitLines = lines.Where(l => KitLetter().IsMatch(l)).ToList();
			if (kitLines.Count >= 2 && lines.All(l => KitLetter().IsMatch(l) || l.EndsWith(':')))
			{
				return new EquipmentLoadout(
					kitLines.Select(l =>
					{
						var m = KitLetter().Match(l);
						return new LoadoutOption(m.Groups[1].Value, SplitItems(l[m.Length..]).Select(ToLedgerItem).ToList());
					}).ToList(),
					Array.Empty<LoadoutRow>());
			}

			var rows = lines.Where(l => !l.EndsWith(':')).Select(l =>
			{
				var parts = ChoiceLetter().Split(l);
				//	Split keeps the letters: ["", "a", "a greataxe or ", "b", "any martial melee weapon"]
				if (parts.Length >= 5)
				{
					var options = new List<LoadoutOption>();
					for (var i = 1; i + 1 < parts.Length; i += 2)
					{
						var option = TrailingOr().Replace(parts[i + 1], string.Empty).Trim();
						options.Add(new LoadoutOption(parts[i], SplitItems(option).Select(t => new LoadoutItem(t, null, null)).ToList()));
					}

					return new LoadoutRow(options);
				}

				return new LoadoutRow(new[] { new LoadoutOption(null, SplitItems(l).Select(t => new LoadoutItem(t, null, null)).ToList()) });
			}).ToList();

			return new EquipmentLoadout(Array.Empty<LoadoutOption>(), rows);
		}

		///	<summary>
		///	Background texts: one item per line, plus the gold of option B in the 2024 rules.
		///	</summary>
		public static EquipmentLoadout FromBackground(string? equipment, string? goldAlternative)
		{
			var items = (equipment ?? string.Empty).Replace("\r", string.Empty).Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
				.Select(l => ListMarker().Replace(l, string.Empty).Trim())
				.Where(l => l.Length > 0)
				.Select(ToLedgerItem)
				.ToList();

			if (goldAlternative is not null)
			{
				return new EquipmentLoadout(
					new[] { new LoadoutOption("A", items), new LoadoutOption("B", new[] { ToLedgerItem(goldAlternative) }) },
					Array.Empty<LoadoutRow>());
			}

			return new EquipmentLoadout(Array.Empty<LoadoutOption>(), items.Select(i => new LoadoutRow(new[] { new LoadoutOption(null, new[] { i }) })).ToList());
		}

		///	<summary>
		///	"Greataxe, 4 Handaxes, Explorer's Pack and 15 GP" → the four items ("e"/"and" before the last one, also after a comma).
		///	Commas inside parentheses ("Focus (sprig, mistletoe)") do not split.
		///	</summary>
		public static IReadOnlyList<string> SplitItems(string text)
		{
			var parts = new List<string>();
			var depth = 0;
			var start = 0;
			for (var i = 0; i < text.Length; i++)
			{
				depth += text[i] == '(' ? 1 : text[i] == ')' ? -1 : 0;
				if (text[i] == ',' && depth == 0)
				{
					parts.Add(text[start..i]);
					start = i + 1;
				}
			}
			parts.Add(text[start..]);

			var items = parts.Select(p => LeadingAnd().Replace(p.Trim(), string.Empty)).Where(p => p.Length > 0).ToList();
			if (items.Count > 0)
			{
				//	The last item may still hold "X and Y" / "X e Y"
				var last = items[^1];
				var m = LastAnd().Match(last);
				if (m.Success && !InsideParentheses(last, m.Index))
				{
					items[^1] = last[..m.Index].Trim();
					items.Add(last[(m.Index + m.Length)..].Trim());
				}
			}

			return items.Where(i => i.Length > 0).ToList();
		}

		//	A line of a list becomes an entry with its quantity and its coins
		private static LoadoutItem ToLedgerItem(string text)
		{
			var coins = Coins().Match(text);
			if (coins.Success)
			{
				return new LoadoutItem(Capitalize(text[..coins.Index].Trim() + " " + text[(coins.Index + coins.Length)..].Trim()).Trim(), null, coins.Value.Trim());
			}

			var quantity = Quantity().Match(text);
			if (quantity.Success && int.TryParse(quantity.Groups[1].Value, out var n) && n > 1)
			{
				return new LoadoutItem(Capitalize(text[quantity.Length..].Trim()), n, null);
			}

			return new LoadoutItem(Capitalize(text.Trim()), null, null);
		}

		private static string Capitalize(string text) =>
			text.Length == 0 ? text : char.ToUpperInvariant(text[0]) + text[1..];

		private static bool InsideParentheses(string text, int index) =>
			text[..index].Count(c => c == '(') > text[..index].Count(c => c == ')');

		[GeneratedRegex(@"^[-*•]\s+")]
		private static partial Regex ListMarker();

		[GeneratedRegex(@"^\(([A-Z])\)\s*")]
		private static partial Regex KitLetter();

		[GeneratedRegex(@"\(([a-z])\)\s*")]
		private static partial Regex ChoiceLetter();

		//	"… or " / "… o " / "…, " left before the next letter
		[GeneratedRegex(@"(?:,?\s+(?:or|o|oppure))?\s*,?\s*$")]
		private static partial Regex TrailingOr();

		[GeneratedRegex(@"^(?:and|e)\s+", RegexOptions.IgnoreCase)]
		private static partial Regex LeadingAnd();

		[GeneratedRegex(@"\s+(?:and|e)\s+(?!.*\s(?:and|e)\s)")]
		private static partial Regex LastAnd();

		[GeneratedRegex(@"\b\d+\s*(?:mo|ma|mr|me|mp|gp|sp|cp|ep|pp)\b\.?", RegexOptions.IgnoreCase)]
		private static partial Regex Coins();

		[GeneratedRegex(@"^(\d+)\s+")]
		private static partial Regex Quantity();
	}
}
