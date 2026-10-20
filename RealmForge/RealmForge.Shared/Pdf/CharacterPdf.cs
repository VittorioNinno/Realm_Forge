namespace RealmForge.Shared.Pdf;

///	<summary>
///	Everything printed on the character PDF, already in the reader's language.
///	</summary>
public sealed class CharacterPdfData
{
	public string Name { get; set; } = string.Empty;
	public List<string> Subtitle { get; set; } = new();
	public List<(string Label, string Value)> Vitals { get; set; } = new();
	public List<PdfAbility> Abilities { get; set; } = new();
	public List<PdfSection> Columns { get; set; } = new();
	public List<PdfSection> Sections { get; set; } = new();
	public string Footer { get; set; } = string.Empty;
}

public sealed record PdfAbility(string Label, int Score, string Modifier, string Save, bool SaveProficient);

///	<summary>
///	A titled block: rows with an optional value on the right (marked rows get a dot, e.g. proficient skills), or
///	paragraphs of text.
///	</summary>
public sealed record PdfSection(string Title, List<PdfRow> Rows);

public sealed record PdfRow(string Text, string? Value = null, bool Marked = false, bool Bold = false, bool Paragraph = false);

///	<summary>
///	Lays out the character sheet on A4 pages: header, vitals, the six abilities, two narrow columns (saves and
///	skills) and the full-width sections, breaking pages as needed.
///	</summary>
public static class CharacterPdf
{
	private const double Margin = 40;
	private const double ContentWidth = PdfDocument.Width - 2 * Margin;
	private const double Bottom = PdfDocument.Height - 50;

	public static byte[] Create(CharacterPdfData data)
	{
		var pdf = new PdfDocument();
		var y = Margin;

		// Header
		pdf.Text(Margin, y, data.Name, PdfFont.Bold, 22, PdfColor.Black);
		y += 28;
		pdf.Line(Margin, y, Margin + ContentWidth, y, PdfColor.Orange, 1.5);
		y += 6;
		foreach (var line in data.Subtitle)
		{
			foreach (var wrapped in PdfDocument.Wrap(line, PdfFont.Regular, 10, ContentWidth))
			{
				pdf.Text(Margin, y, wrapped, PdfFont.Regular, 10, PdfColor.Grey);
				y += 13;
			}
		}
		y += 8;

		// Vitals
		if (data.Vitals.Count > 0)
		{
			var gap = 6.0;
			var w = (ContentWidth - gap * (data.Vitals.Count - 1)) / data.Vitals.Count;
			for (var i = 0; i < data.Vitals.Count; i++)
			{
				var x = Margin + i * (w + gap);
				pdf.Rect(x, y, w, 42, PdfColor.Paper, PdfColor.Light);
				pdf.TextCenter(x + w / 2, y + 7, Fit(data.Vitals[i].Value, PdfFont.Bold, 15, w - 6), PdfFont.Bold, 15, PdfColor.Black);
				pdf.TextCenter(x + w / 2, y + 28, Fit(data.Vitals[i].Label.ToUpperInvariant(), PdfFont.Bold, 6.5, w - 4), PdfFont.Bold, 6.5, PdfColor.Orange);
			}
			y += 52;
		}

		// Abilities
		if (data.Abilities.Count > 0)
		{
			var gap = 6.0;
			var w = (ContentWidth - gap * (data.Abilities.Count - 1)) / data.Abilities.Count;
			for (var i = 0; i < data.Abilities.Count; i++)
			{
				var a = data.Abilities[i];
				var x = Margin + i * (w + gap);
				pdf.Rect(x, y, w, 66, null, PdfColor.Orange, 0.8);
				pdf.TextCenter(x + w / 2, y + 6, Fit(a.Label.ToUpperInvariant(), PdfFont.Bold, 7, w - 4), PdfFont.Bold, 7, PdfColor.Orange);
				pdf.TextCenter(x + w / 2, y + 17, a.Modifier, PdfFont.Bold, 17, PdfColor.Black);
				pdf.TextCenter(x + w / 2, y + 39, a.Score.ToString(), PdfFont.Regular, 10, PdfColor.Grey);
				pdf.TextCenter(x + w / 2, y + 53, Fit((a.SaveProficient ? "• " : string.Empty) + a.Save, PdfFont.Regular, 7.5, w - 4), PdfFont.Regular, 7.5, PdfColor.Black);
			}
			y += 76;
		}

		// Two columns (saves, skills…)
		if (data.Columns.Count > 0)
		{
			var gap = 18.0;
			var w = (ContentWidth - gap * (data.Columns.Count - 1)) / data.Columns.Count;
			var columnBottom = y;
			for (var i = 0; i < data.Columns.Count; i++)
			{
				var cy = y;
				Section(pdf, data.Columns[i], Margin + i * (w + gap), w, ref cy, data.Footer, allowBreak: false);
				columnBottom = Math.Max(columnBottom, cy);
			}
			y = columnBottom + 4;
		}

		foreach (var section in data.Sections.Where(s => s.Rows.Count > 0))
		{
			Section(pdf, section, Margin, ContentWidth, ref y, data.Footer, allowBreak: true);
			y += 4;
		}

		Footers(pdf, data.Footer);
		return pdf.ToBytes();
	}

	private static void Section(PdfDocument pdf, PdfSection section, double x, double width, ref double y, string footer, bool allowBreak)
	{
		void EnsureRoom(double needed, ref double yy)
		{
			if (allowBreak && yy + needed > Bottom)
			{
				pdf.AddPage();
				yy = Margin;
			}
		}

		EnsureRoom(40, ref y);
		pdf.Text(x, y, section.Title.ToUpperInvariant(), PdfFont.Bold, 9, PdfColor.Orange);
		y += 12;
		pdf.Line(x, y, x + width, y, PdfColor.Light, 0.6);
		y += 5;

		foreach (var row in section.Rows)
		{
			var font = row.Bold ? PdfFont.Bold : PdfFont.Regular;
			const double size = 9;
			var indent = row.Marked || !row.Paragraph ? 9 : 0;
			var valueWidth = row.Value is null ? 0 : PdfDocument.Measure(row.Value, PdfFont.Bold, size) + 8;
			var lines = PdfDocument.Wrap(row.Text, font, size, width - indent - valueWidth);
			foreach (var (line, index) in lines.Select((l, i) => (l, i)))
			{
				EnsureRoom(12, ref y);
				if (index == 0 && row.Marked)
				{
					pdf.Rect(x + 1, y + 2.5, 4, 4, PdfColor.Orange, null);
				}
				else if (index == 0 && !row.Paragraph)
				{
					pdf.Rect(x + 1, y + 2.5, 4, 4, null, PdfColor.Light, 0.6);
				}
				pdf.Text(x + indent, y, line, font, size, PdfColor.Black);
				if (index == 0 && row.Value is not null)
				{
					pdf.TextRight(x + width, y, row.Value, PdfFont.Bold, size, PdfColor.Black);
				}
				y += 11.5;
			}
		}
	}

	private static void Footers(PdfDocument pdf, string footer)
	{
		for (var i = 0; i < pdf.PageCount; i++)
		{
			pdf.UsePage(i);
			pdf.Line(Margin, PdfDocument.Height - 38, PdfDocument.Width - Margin, PdfDocument.Height - 38, PdfColor.Light, 0.5);
			pdf.Text(Margin, PdfDocument.Height - 34, footer, PdfFont.Regular, 7, PdfColor.Grey);
			pdf.TextRight(PdfDocument.Width - Margin, PdfDocument.Height - 34, $"{i + 1} / {pdf.PageCount}", PdfFont.Regular, 7, PdfColor.Grey);
		}
	}

	private static string Fit(string text, PdfFont font, double size, double width)
	{
		if (PdfDocument.Measure(text, font, size) <= width)
		{
			return text;
		}

		var cut = text;
		while (cut.Length > 1 && PdfDocument.Measure(cut + "…", font, size) > width)
		{
			cut = cut[..^1];
		}

		return cut + "…";
	}
}
