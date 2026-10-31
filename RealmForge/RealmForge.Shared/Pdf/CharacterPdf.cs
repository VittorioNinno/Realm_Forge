namespace RealmForge.Shared.Pdf;

///	<summary>
///	Everything printed on the character PDF, already in the reader's language.
///	</summary>
public sealed class CharacterPdfData
{
	// Header
	public string Name { get; set; } = string.Empty;
	public string LevelBadge { get; set; } = string.Empty;
	public string Origin { get; set; } = string.Empty;
	public string Classes { get; set; } = string.Empty;
	public List<PdfField> Meta { get; set; } = new();

	public List<PdfField> Vitals { get; set; } = new();
	public List<PdfAbility> Abilities { get; set; } = new();

	//	Conditions, exhaustion, inspiration: one line under the abilities, when there is something
	public string? Status { get; set; }

	public string SkillsTitle { get; set; } = string.Empty;
	public List<PdfSkill> Skills { get; set; } = new();

	public string AttacksTitle { get; set; } = string.Empty;
	public List<string> AttackHeaders { get; set; } = new();
	public List<PdfAttack> Attacks { get; set; } = new();
	public string NoAttacks { get; set; } = string.Empty;

	public string SpellsTitle { get; set; } = string.Empty;
	public string? SlotsPill { get; set; }
	public List<PdfCaster> Casters { get; set; } = new();

	public PdfInfoBox Proficiencies { get; set; } = new(string.Empty, new());
	public PdfInfoBox Features { get; set; } = new(string.Empty, new());

	public string InventoryTitle { get; set; } = string.Empty;
	public string? CoinsPill { get; set; }
	public List<PdfItem> Items { get; set; } = new();

	// Page of the notes
	public string NotesSubtitle { get; set; } = string.Empty;
	public List<PdfField> NotesMeta { get; set; } = new();
	public List<PdfNote> Personality { get; set; } = new();
	public List<PdfNote> Notes { get; set; } = new();

	public string Footer { get; set; } = string.Empty;

	//	"Pagina {0} / {1}"
	public string PageFormat { get; set; } = "{0} / {1}";
}

public sealed record PdfField(string Label, string Value);

public sealed record PdfAbility(string Label, int Score, string Modifier, string Save, bool SaveProficient);

public sealed record PdfSkill(string Name, string Ability, string Bonus, bool Proficient, bool Expertise = false);

public sealed record PdfAttack(string Name, string Hit, string Damage);

///	<summary>
///	A spellcasting source: its name, the line of its numbers and the spells by level ("Trucchetti: …").
///	</summary>
public sealed record PdfCaster(string Name, string Stats, List<PdfLine> Lines);

public sealed record PdfLine(string Label, string Text);

public sealed record PdfInfoBox(string Title, List<PdfLine> Lines);

public sealed record PdfItem(string Name, string? Tag = null);

public sealed record PdfNote(string Title, string Text);

///	<summary>
///	Lays out the character sheet on white A4 pages with orange accents: the header (name, level, origin and classes,
///	background, alignment and size), seven vitals, the six abilities with their saves, then the skills on the left
///	and attacks, spells, proficiencies, features and inventory on the right; a page for personality and notes. Boxes
///	that do not fit continue on the next page.
///	</summary>
public static class CharacterPdf
{
	private const double Margin = 40;
	private const double ContentWidth = PdfDocument.Width - 2 * Margin;
	private const double Bottom = PdfDocument.Height - 52;

	//	Palette of the sheet
	private static readonly PdfColor Accent = new(0.918, 0.345, 0.047);
	private static readonly PdfColor AccentBright = new(1, 0.478, 0);
	private static readonly PdfColor AccentBorder = new(0.992, 0.729, 0.455);
	private static readonly PdfColor Subtle = new(1, 0.969, 0.929);
	private static readonly PdfColor Neutral = new(0.973, 0.98, 0.988);
	private static readonly PdfColor BorderSoft = new(0.886, 0.91, 0.941);
	private static readonly PdfColor BorderStrong = new(0.796, 0.835, 0.882);
	private static readonly PdfColor Main = new(0.094, 0.094, 0.106);
	private static readonly PdfColor Muted = new(0.322, 0.322, 0.357);
	private static readonly PdfColor Dim = new(0.443, 0.443, 0.478);
	private static readonly PdfColor White = PdfColor.White;

	private const double Pad = 10;
	private const double TitleHeight = 20;

	public static byte[] Create(CharacterPdfData data)
	{
		var pdf = new PdfDocument();
		var y = Header(pdf, data.Name, data.LevelBadge, data.Origin, data.Classes, data.Meta);
		y = Vitals(pdf, data.Vitals, y);
		y = Abilities(pdf, data.Abilities, y);
		if (!string.IsNullOrWhiteSpace(data.Status))
		{
			var lines = PdfDocument.Wrap(data.Status, PdfFont.Bold, 8, ContentWidth - 16);
			var h = lines.Count * 11 + 8;
			pdf.RoundRect(Margin, y, ContentWidth, h, 5, Subtle, AccentBorder);
			for (var i = 0; i < lines.Count; i++)
			{
				pdf.Text(Margin + 8, y + 5 + i * 11, lines[i], PdfFont.Bold, 8, Accent);
			}
			y += h + 8;
		}

		// Skills on the left, the rest on the right (and on the full width once it goes to a new page)
		const double leftWidth = 180;
		const double gap = 10;
		Skills(pdf, data, Margin, y, leftWidth);
		var flow = new Flow(pdf, Margin + leftWidth + gap, ContentWidth - leftWidth - gap, y);

		Attacks(flow, data);
		Spells(flow, data);
		InfoPair(flow, data.Proficiencies, data.Features);
		Inventory(flow, data);

		// Personality and notes on a page of their own
		if (data.Personality.Count > 0 || data.Notes.Count > 0)
		{
			pdf.AddPage();
			var ny = Header(pdf, data.Name, data.LevelBadge, null, data.NotesSubtitle, data.NotesMeta);
			var notes = new Flow(pdf, Margin, ContentWidth, ny);
			for (var i = 0; i < data.Personality.Count; i += 2)
			{
				NotePair(notes, data.Personality[i], i + 1 < data.Personality.Count ? data.Personality[i + 1] : null);
			}
			foreach (var note in data.Notes)
			{
				Note(notes, note);
			}
		}

		Footers(pdf, data);
		return pdf.ToBytes();
	}

	// ===== Header, vitals, abilities =====

	private static double Header(PdfDocument pdf, string name, string badge, string? origin, string line, List<PdfField> meta)
	{
		var y = Margin;

		// Meta cards on the right, on one line
		var cards = meta.Select(m =>
		{
			var w = Math.Max(PdfDocument.Measure(m.Label.ToUpperInvariant(), PdfFont.Bold, 6.5), PdfDocument.Measure(m.Value, PdfFont.Bold, 9.5)) + 18;
			return (m, w);
		}).ToList();
		var cardsWidth = cards.Sum(c => c.w) + Math.Max(0, cards.Count - 1) * 6;
		var cx = Margin + ContentWidth - cardsWidth;
		foreach (var (m, w) in cards)
		{
			pdf.RoundRect(cx, y + 2, w, 32, 5, Subtle, AccentBorder);
			pdf.Text(cx + 9, y + 8, m.Label.ToUpperInvariant(), PdfFont.Bold, 6.5, Accent);
			pdf.Text(cx + 9, y + 18, m.Value, PdfFont.Bold, 9.5, Main);
			cx += w + 6;
		}

		// Name and level badge, origin and classes
		var left = ContentWidth - cardsWidth - 16;
		var badgeWidth = string.IsNullOrEmpty(badge) ? 0 : PdfDocument.Measure(badge.ToUpperInvariant(), PdfFont.Bold, 7.5) + 14;
		var title = Fit(name.ToUpperInvariant(), PdfFont.Bold, 21, left - badgeWidth - 8);
		pdf.Text(Margin, y, title, PdfFont.Bold, 21, Accent);
		if (badgeWidth > 0)
		{
			var bx = Margin + PdfDocument.Measure(title, PdfFont.Bold, 21) + 8;
			pdf.RoundRect(bx, y + 4, badgeWidth, 15, 4, Accent, null);
			pdf.Text(bx + 7, y + 8, badge.ToUpperInvariant(), PdfFont.Bold, 7.5, White);
		}

		var ly = y + 27;
		var x = Margin;
		if (!string.IsNullOrWhiteSpace(origin))
		{
			pdf.Text(x, ly, origin, PdfFont.Bold, 10.5, Main);
			x += PdfDocument.Measure(origin, PdfFont.Bold, 10.5) + 5;
			pdf.Text(x, ly, "•", PdfFont.Bold, 10.5, AccentBright);
			x += PdfDocument.Measure("•", PdfFont.Bold, 10.5) + 5;
		}
		pdf.Text(x, ly, Fit(line, PdfFont.Bold, 10.5, Margin + left - x), PdfFont.Bold, 10.5, Main);

		y += 46;
		pdf.Line(Margin, y, Margin + ContentWidth, y, AccentBright, 2);
		return y + 10;
	}

	private static double Vitals(PdfDocument pdf, List<PdfField> vitals, double y)
	{
		if (vitals.Count == 0)
		{
			return y;
		}
		const double gap = 6;
		const double h = 40;
		var w = (ContentWidth - gap * (vitals.Count - 1)) / vitals.Count;
		for (var i = 0; i < vitals.Count; i++)
		{
			var x = Margin + i * (w + gap);
			pdf.RoundRect(x, y, w, h, 6, AccentBright, null);
			pdf.RoundRect(x, y + 2.5, w, h - 2.5, 6, White, BorderStrong);
			pdf.TextCenter(x + w / 2, y + 10, Fit(vitals[i].Value, PdfFont.Bold, 12.5, w - 6), PdfFont.Bold, 12.5, Main);
			pdf.TextCenter(x + w / 2, y + 27, Fit(vitals[i].Label.ToUpperInvariant(), PdfFont.Bold, 6, w - 4), PdfFont.Bold, 6, Accent);
		}
		return y + h + 8;
	}

	private static double Abilities(PdfDocument pdf, List<PdfAbility> abilities, double y)
	{
		if (abilities.Count == 0)
		{
			return y;
		}
		const double gap = 8;
		const double h = 66;
		var w = (ContentWidth - gap * (abilities.Count - 1)) / abilities.Count;
		for (var i = 0; i < abilities.Count; i++)
		{
			var a = abilities[i];
			var x = Margin + i * (w + gap);
			var center = x + w / 2;
			pdf.RoundRect(x, y, w, h, 6, Neutral, BorderStrong);
			pdf.TextCenter(center, y + 7, Fit(a.Label.ToUpperInvariant(), PdfFont.Bold, 7.5, w - 6), PdfFont.Bold, 7.5, Accent);
			pdf.TextCenter(center, y + 17, a.Modifier, PdfFont.Bold, 15, Main);
			var score = a.Score.ToString();
			var sw = PdfDocument.Measure(score, PdfFont.Bold, 8) + 14;
			pdf.RoundRect(center - sw / 2, y + 35, sw, 12, 6, White, BorderStrong);
			pdf.TextCenter(center, y + 37, score, PdfFont.Bold, 8, Muted);
			pdf.DashedLine(x + 6, y + 51, x + w - 6, y + 51, BorderStrong, 0.6);
			var font = a.SaveProficient ? PdfFont.Bold : PdfFont.Regular;
			var save = Fit(a.Save, font, 8, w - 18);
			var tw = PdfDocument.Measure(save, font, 8) + 9;
			var sx = center - tw / 2;
			Dot(pdf, sx + 2.6, y + 58, a.SaveProficient);
			pdf.Text(sx + 9, y + 54, save, font, 8, a.SaveProficient ? Accent : Muted);
		}
		return y + h + 10;
	}

	private static void Dot(PdfDocument pdf, double cx, double cy, bool filled)
	{
		if (filled)
		{
			pdf.Circle(cx, cy, 2.6, AccentBright, Accent, 0.9);
		}
		else
		{
			pdf.Circle(cx, cy, 2.6, null, Dim, 0.9);
		}
	}

	// ===== Skills =====

	private static void Skills(PdfDocument pdf, CharacterPdfData data, double x, double y, double w)
	{
		const double row = 13.5;
		var h = Pad + TitleHeight + data.Skills.Count * row + Pad - 2;
		pdf.RoundRect(x, y, w, h, 7, White, BorderStrong);
		BoxTitle(pdf, x, y, w, data.SkillsTitle, null);
		var ry = y + Pad + TitleHeight;
		foreach (var s in data.Skills)
		{
			if (s.Proficient)
			{
				pdf.RoundRect(x + 6, ry - 2, w - 12, row - 1, 3.5, Subtle, AccentBorder);
			}
			Dot(pdf, x + 13, ry + 4.8, s.Proficient);
			if (s.Expertise)
			{
				pdf.Circle(x + 13, ry + 4.8, 4.2, null, Accent, 0.7);
			}
			var font = s.Proficient ? PdfFont.Bold : PdfFont.Regular;
			var bonusWidth = PdfDocument.Measure(s.Bonus, PdfFont.Bold, 8.5);
			var name = Fit(s.Name, font, 8.5, w - 52 - bonusWidth);
			pdf.Text(x + 21, ry + 1, name, font, 8.5, s.Proficient ? Main : Muted);
			pdf.Text(x + 21 + PdfDocument.Measure(name, font, 8.5) + 4, ry + 2, $"({s.Ability})", PdfFont.Regular, 7, Dim);
			pdf.TextRight(x + w - 11, ry + 1, s.Bonus, PdfFont.Bold, 8.5, s.Proficient ? Accent : Main);
			ry += row;
		}
	}

	// ===== Right column boxes =====

	private static void Attacks(Flow flow, CharacterPdfData data)
	{
		var items = new List<Func<double, Part>>();
		if (data.Attacks.Count == 0)
		{
			items.Add(w => Paragraph(data.NoAttacks, PdfFont.Regular, 8.5, Muted, w));
		}
		else
		{
			items.Add(w => new Part(14, (pdf, x, y) =>
			{
				var cols = AttackColumns(w);
				for (var i = 0; i < Math.Min(3, data.AttackHeaders.Count); i++)
				{
					pdf.Text(x + cols[i], y, Fit(data.AttackHeaders[i].ToUpperInvariant(), PdfFont.Bold, 6.5, (i < 2 ? cols[i + 1] - cols[i] : w - cols[i]) - 4), PdfFont.Bold, 6.5, Dim);
				}
				pdf.Line(x, y + 11, x + w, y + 11, BorderSoft, 0.6);
			}));
			for (var i = 0; i < data.Attacks.Count; i++)
			{
				var attack = data.Attacks[i];
				var last = i == data.Attacks.Count - 1;
				items.Add(w =>
				{
					var cols = AttackColumns(w);
					var nameLines = PdfDocument.Wrap(attack.Name, PdfFont.Bold, 8.5, cols[1] - 6);
					var damageLines = PdfDocument.Wrap(attack.Damage, PdfFont.Regular, 8.5, w - cols[2]);
					var h = Math.Max(nameLines.Count, damageLines.Count) * 11 + 8;
					return new Part(h, (pdf, x, y) =>
					{
						for (var l = 0; l < nameLines.Count; l++)
						{
							pdf.Text(x + cols[0], y + 3 + l * 11, nameLines[l], PdfFont.Bold, 8.5, Main);
						}
						var hw = PdfDocument.Measure(attack.Hit, PdfFont.Bold, 8.5) + 12;
						pdf.RoundRect(x + cols[1], y + 1, hw, 13, 4, Subtle, AccentBorder);
						pdf.Text(x + cols[1] + 6, y + 3, attack.Hit, PdfFont.Bold, 8.5, Accent);
						for (var l = 0; l < damageLines.Count; l++)
						{
							pdf.Text(x + cols[2], y + 3 + l * 11, damageLines[l], PdfFont.Regular, 8.5, Main);
						}
						if (!last)
						{
							pdf.Line(x, y + h - 2, x + w, y + h - 2, BorderSoft, 0.6);
						}
					});
				});
			}
		}
		flow.Box(data.AttacksTitle, null, items);
	}

	private static double[] AttackColumns(double w) => new[] { 0, w * 0.38, w * 0.58 };

	private static void Spells(Flow flow, CharacterPdfData data)
	{
		if (data.Casters.Count == 0 && data.SlotsPill is null)
		{
			return;
		}
		var items = new List<Func<double, Part>>();
		var single = data.Casters.Count == 1;
		for (var i = 0; i < data.Casters.Count; i += 2)
		{
			var first = data.Casters[i];
			var second = !single && i + 1 < data.Casters.Count ? data.Casters[i + 1] : null;
			items.Add(w =>
			{
				var cw = single ? w : (w - 8) / 2;
				var a = CasterCard(first, cw);
				var b = second is null ? null : CasterCard(second, cw);
				var h = Math.Max(a.Height, b?.Height ?? 0);
				return new Part(h + 8, (pdf, x, y) =>
				{
					a.Draw(pdf, x, y, cw, h);
					b?.Draw(pdf, x + cw + 8, y, cw, h);
				});
			});
		}
		flow.Box(data.SpellsTitle, data.SlotsPill, items);
	}

	private sealed record Card(double Height, Action<PdfDocument, double, double, double, double> Draw);

	private static Card CasterCard(PdfCaster caster, double w)
	{
		var inner = w - 18;
		var statsWidth = PdfDocument.Measure(caster.Stats, PdfFont.Bold, 7.5);
		var stacked = PdfDocument.Measure(caster.Name, PdfFont.Bold, 9) + statsWidth + 12 > inner;
		var headHeight = stacked ? 26 : 16;
		var blocks = caster.Lines.Select(l => LabelledLines(l, 8, inner)).ToList();
		var h = 8 + headHeight + 4 + blocks.Sum(b => b.Count * 10.5 + 3) + 5;
		return new Card(h, (pdf, x, y, cw, ch) =>
		{
			pdf.RoundRect(x, y, cw, ch, 5, Neutral, BorderSoft);
			pdf.RoundRect(x, y, 3, ch, 1.5, AccentBright, null);
			pdf.Text(x + 10, y + 8, Fit(caster.Name, PdfFont.Bold, 9, inner), PdfFont.Bold, 9, Main);
			if (stacked)
			{
				pdf.Text(x + 10, y + 20, Fit(caster.Stats, PdfFont.Bold, 7.5, inner), PdfFont.Bold, 7.5, Accent);
			}
			else
			{
				pdf.TextRight(x + cw - 9, y + 9, caster.Stats, PdfFont.Bold, 7.5, Accent);
			}
			var ly = y + 8 + headHeight;
			pdf.Line(x + 10, ly - 3, x + cw - 9, ly - 3, BorderSoft, 0.6);
			ly += 2;
			foreach (var block in blocks)
			{
				DrawLabelled(pdf, x + 10, ly, block, 8, 10.5);
				ly += block.Count * 10.5 + 3;
			}
		});
	}

	private static void InfoPair(Flow flow, PdfInfoBox left, PdfInfoBox right)
	{
		var boxes = new[] { left, right }.Where(b => b.Lines.Count > 0).ToList();
		if (boxes.Count == 0)
		{
			return;
		}
		flow.Row(w =>
		{
			var bw = boxes.Count == 1 ? w : (w - 10) / 2;
			var contents = boxes.Select(b => b.Lines.Select(l => LabelledLines(l, 8, bw - 2 * Pad)).ToList()).ToList();
			var heights = contents.Select(c => Pad + TitleHeight + c.Sum(b => b.Count * 11 + 3) + Pad - 4).ToList();
			var h = heights.Max();
			return new Part(h, (pdf, x, y) =>
			{
				for (var i = 0; i < boxes.Count; i++)
				{
					var bx = x + i * (bw + 10);
					pdf.RoundRect(bx, y, bw, h, 7, White, BorderStrong);
					BoxTitle(pdf, bx, y, bw, boxes[i].Title, null);
					var ly = y + Pad + TitleHeight;
					foreach (var block in contents[i])
					{
						DrawLabelled(pdf, bx + Pad, ly, block, 8, 11);
						ly += block.Count * 11 + 3;
					}
				}
			});
		});
	}

	private static void Inventory(Flow flow, CharacterPdfData data)
	{
		if (data.Items.Count == 0 && data.CoinsPill is null)
		{
			return;
		}
		var items = new List<Func<double, Part>>();
		for (var i = 0; i < data.Items.Count; i += 2)
		{
			var first = data.Items[i];
			var second = i + 1 < data.Items.Count ? data.Items[i + 1] : null;
			items.Add(w =>
			{
				var cw = (w - 14) / 2;
				var a = ItemLines(first, cw);
				var b = second is null ? null : ItemLines(second, cw);
				var h = Math.Max(a.Count, b?.Count ?? 0) * 10.5 + 5;
				return new Part(h, (pdf, x, y) =>
				{
					DrawItem(pdf, x, y, cw, h, first, a);
					if (second is not null && b is not null)
					{
						DrawItem(pdf, x + cw + 14, y, cw, h, second, b);
					}
				});
			});
		}
		flow.Box(data.InventoryTitle, data.CoinsPill, items);
	}

	private static List<string> ItemLines(PdfItem item, double w)
	{
		var tag = item.Tag is null ? 0 : PdfDocument.Measure(item.Tag, PdfFont.Bold, 7) + 14;
		return PdfDocument.Wrap(item.Name, PdfFont.Regular, 8.5, w - tag);
	}

	private static void DrawItem(PdfDocument pdf, double x, double y, double w, double h, PdfItem item, List<string> lines)
	{
		for (var l = 0; l < lines.Count; l++)
		{
			pdf.Text(x, y + 1 + l * 10.5, lines[l], PdfFont.Regular, 8.5, Main);
		}
		if (item.Tag is { } tag)
		{
			var tw = PdfDocument.Measure(tag, PdfFont.Bold, 7) + 8;
			pdf.RoundRect(x + w - tw, y, tw, 11, 3, Subtle, AccentBorder);
			pdf.Text(x + w - tw + 4, y + 2, tag, PdfFont.Bold, 7, Accent);
		}
		pdf.DashedLine(x, y + h - 2, x + w, y + h - 2, BorderStrong, 0.5);
	}

	// ===== Notes =====

	private static void NotePair(Flow flow, PdfNote first, PdfNote? second)
	{
		flow.Row(w =>
		{
			var nw = second is null ? w : (w - 10) / 2;
			var a = PdfDocument.Wrap(first.Text, PdfFont.Regular, 9, nw - 26);
			var b = second is null ? null : PdfDocument.Wrap(second.Text, PdfFont.Regular, 9, nw - 26);
			var h = Math.Max(a.Count, b?.Count ?? 0) * 13 + 38;
			if (h > Bottom - Margin - 60)
			{
				//	Too long to stay side by side: one under the other, each one free to continue on the next page
				return null;
			}
			return new Part(h, (pdf, x, y) =>
			{
				NoteFrame(pdf, x, y, nw, h, first.Title, a);
				if (second is not null && b is not null)
				{
					NoteFrame(pdf, x + nw + 10, y, nw, h, second.Title, b);
				}
			});
		}, () =>
		{
			Note(flow, first);
			if (second is not null)
			{
				Note(flow, second);
			}
		});
	}

	private static void NoteFrame(PdfDocument pdf, double x, double y, double w, double h, string title, List<string> lines)
	{
		pdf.RoundRect(x, y, w, h, 6, White, BorderStrong);
		pdf.RoundRect(x, y, 3.5, h, 1.75, AccentBright, null);
		pdf.Text(x + 14, y + 11, title.ToUpperInvariant(), PdfFont.Bold, 8.5, Accent);
		pdf.Line(x + 14, y + 24, x + w - 12, y + 24, BorderSoft, 0.6);
		for (var l = 0; l < lines.Count; l++)
		{
			pdf.Text(x + 14, y + 30 + l * 13, lines[l], PdfFont.Regular, 9, Main);
		}
	}

	//	A full-width note: its lines continue on the next page when needed
	private static void Note(Flow flow, PdfNote note)
	{
		var items = new List<Func<double, Part>>();
		foreach (var paragraph in note.Text.Replace("\r", string.Empty).Split('\n'))
		{
			var text = paragraph;
			items.Add(w =>
			{
				var lines = PdfDocument.Wrap(text.Length == 0 ? " " : text, PdfFont.Regular, 9, w);
				return new Part(lines.Count * 13, (pdf, x, y) =>
				{
					for (var l = 0; l < lines.Count; l++)
					{
						pdf.Text(x, y + l * 13, lines[l], PdfFont.Regular, 9, Main);
					}
				}, lines.Count > 1 ? lines : null);
			});
		}
		flow.Box(note.Title, null, items, note: true);
	}

	// ===== Shared pieces =====

	private static void BoxTitle(PdfDocument pdf, double x, double y, double w, string title, string? pill)
	{
		pdf.Text(x + Pad, y + Pad, title.ToUpperInvariant(), PdfFont.Bold, 8.5, Accent);
		if (pill is not null)
		{
			var text = Fit(pill, PdfFont.Bold, 7.5, w - 2 * Pad - PdfDocument.Measure(title.ToUpperInvariant(), PdfFont.Bold, 8.5) - 16);
			var pw = PdfDocument.Measure(text, PdfFont.Bold, 7.5) + 14;
			pdf.RoundRect(x + w - Pad - pw, y + Pad - 3, pw, 13, 6.5, Subtle, AccentBorder);
			pdf.Text(x + w - Pad - pw + 7, y + Pad - 0.5, text, PdfFont.Bold, 7.5, Accent);
		}
		pdf.Line(x + Pad, y + Pad + 13, x + w - Pad, y + Pad + 13, AccentBright, 1.1);
	}

	//	A label in bold at the start of the first line, the text after it and on the next lines
	private sealed record Labelled(string Label, List<string> Lines)
	{
		public int Count => Lines.Count;
	}

	private static Labelled LabelledLines(PdfLine line, double size, double width)
	{
		var label = string.IsNullOrEmpty(line.Label) ? string.Empty : line.Label + ": ";
		var available = width - PdfDocument.Measure(label, PdfFont.Bold, size);
		var lines = new List<string>();
		var current = string.Empty;
		foreach (var word in line.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
		{
			var candidate = current.Length == 0 ? word : current + " " + word;
			if (PdfDocument.Measure(candidate, PdfFont.Regular, size) > available && current.Length > 0)
			{
				lines.Add(current);
				current = word;
				available = width;
			}
			else
			{
				current = candidate;
			}
		}
		lines.Add(current);
		return new Labelled(label, lines);
	}

	private static void DrawLabelled(PdfDocument pdf, double x, double y, Labelled block, double size, double leading)
	{
		for (var i = 0; i < block.Lines.Count; i++)
		{
			var lx = x;
			if (i == 0 && block.Label.Length > 0)
			{
				pdf.Text(x, y, block.Label, PdfFont.Bold, size, Main);
				lx += PdfDocument.Measure(block.Label, PdfFont.Bold, size);
			}
			pdf.Text(lx, y + i * leading, block.Lines[i], PdfFont.Regular, size, Muted);
		}
	}

	private static Part Paragraph(string text, PdfFont font, double size, PdfColor color, double w)
	{
		var lines = PdfDocument.Wrap(text, font, size, w);
		return new Part(lines.Count * 11 + 2, (pdf, x, y) =>
		{
			for (var l = 0; l < lines.Count; l++)
			{
				pdf.Text(x, y + l * 11, lines[l], font, size, color);
			}
		});
	}

	private static void Footers(PdfDocument pdf, CharacterPdfData data)
	{
		for (var i = 0; i < pdf.PageCount; i++)
		{
			pdf.UsePage(i);
			var y = PdfDocument.Height - 40;
			pdf.Line(Margin, y, PdfDocument.Width - Margin, y, BorderSoft, 0.6);
			pdf.Text(Margin, y + 6, data.Footer, PdfFont.Regular, 7.5, Dim);
			pdf.TextRight(PdfDocument.Width - Margin, y + 6, string.Format(data.PageFormat, i + 1, pdf.PageCount), PdfFont.Regular, 7.5, Dim);
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

	// ===== Flow of boxes =====

	///	<summary>
	///	A piece of a box: its height and how to draw it at (x, y). Lines, when given, let a long paragraph split
	///	across pages.
	///	</summary>
	private sealed record Part(double Height, Action<PdfDocument, double, double> Draw, List<string>? Lines = null);

	///	<summary>
	///	Boxes one under the other in a column; when the page ends they continue on a new page, on the full width.
	///	</summary>
	private sealed class Flow
	{
		private readonly PdfDocument _pdf;
		private double _x;
		private double _w;
		private double _y;

		public Flow(PdfDocument pdf, double x, double w, double y)
		{
			_pdf = pdf;
			_x = x;
			_w = w;
			_y = y;
		}

		private void NewPage()
		{
			_pdf.AddPage();
			_x = Margin;
			_w = ContentWidth;
			_y = Margin;
		}

		///	<summary>
		///	A row drawn whole (side-by-side boxes); a null part means it does not fit any page, and the fallback
		///	draws it another way.
		///	</summary>
		public void Row(Func<double, Part?> make, Action? fallback = null)
		{
			var part = make(_w);
			if (part is null)
			{
				fallback?.Invoke();
				return;
			}
			if (_y + part.Height > Bottom)
			{
				NewPage();
				part = make(_w);
				if (part is null)
				{
					fallback?.Invoke();
					return;
				}
			}
			part.Draw(_pdf, _x, _y);
			_y += part.Height + 10;
		}

		///	<summary>
		///	A titled box with its parts; the parts that do not fit go to the next page in a box with the same title.
		///	</summary>
		public void Box(string title, string? pill, List<Func<double, Part>> items, bool note = false)
		{
			if (items.Count == 0)
			{
				return;
			}
			var head = note ? 30 : Pad + TitleHeight;
			double Inner() => _w - 2 * Pad - (note ? 4 : 0);

			//	Parts measured for the current width; a paragraph cut by a page keeps its remaining lines
			var parts = items.Select(i => i(Inner())).ToList();
			var index = 0;
			Part? carried = null;
			while (index < parts.Count)
			{
				var first = carried ?? parts[index];
				if (_y + head + Math.Min(first.Height, 40) + Pad > Bottom)
				{
					NewPage();
					parts = items.Select(i => i(Inner())).ToList();
				}

				var top = _y;
				var y = top + head;
				var drawn = new List<(Part Part, double Y)>();
				while (index < parts.Count)
				{
					var part = carried ?? parts[index];
					if (y + part.Height + Pad - 4 <= Bottom)
					{
						drawn.Add((part, y));
						y += part.Height;
						index++;
						carried = null;
						continue;
					}

					//	A long paragraph: as many lines as fit here, the rest on the next page
					if (part.Lines is { Count: > 1 } lines)
					{
						var room = (int)Math.Floor((Bottom - Pad - y) / 13);
						if (room > 0 && room < lines.Count)
						{
							var here = lines.Take(room).ToList();
							drawn.Add((LinesPart(here), y));
							y += here.Count * 13;
							carried = LinesPart(lines.Skip(room).ToList());
						}
					}
					break;
				}

				//	Nothing fits even on an empty page: draw the part anyway rather than loop
				if (drawn.Count == 0 && _y <= Margin + 1)
				{
					var part = carried ?? parts[index];
					drawn.Add((part, y));
					y += part.Height;
					index++;
					carried = null;
				}

				if (drawn.Count > 0)
				{
					var bottom = y + Pad - 4;
					if (note)
					{
						_pdf.RoundRect(_x, top, _w, bottom - top, 6, White, BorderStrong);
						_pdf.RoundRect(_x, top, 3.5, bottom - top, 1.75, AccentBright, null);
						_pdf.Text(_x + 14, top + 11, title.ToUpperInvariant(), PdfFont.Bold, 8.5, Accent);
						_pdf.Line(_x + 14, top + 24, _x + _w - 12, top + 24, BorderSoft, 0.6);
					}
					else
					{
						_pdf.RoundRect(_x, top, _w, bottom - top, 7, White, BorderStrong);
						BoxTitle(_pdf, _x, top, _w, title, pill);
					}
					foreach (var (part, py) in drawn)
					{
						part.Draw(_pdf, _x + Pad + (note ? 4 : 0), py);
					}
					_y = bottom + 10;
				}

				if (index < parts.Count)
				{
					//	The rest on a new page, measured again for its width (the cut paragraph keeps its lines)
					NewPage();
					var fresh = items.Select(i => i(Inner())).ToList();
					for (var i = index; i < parts.Count; i++)
					{
						parts[i] = fresh[i];
					}
				}
			}
		}

		private static Part LinesPart(List<string> lines) => new(lines.Count * 13, (pdf, x, y) =>
		{
			for (var l = 0; l < lines.Count; l++)
			{
				pdf.Text(x, y + l * 13, lines[l], PdfFont.Regular, 9, Main);
			}
		}, lines);
	}
}
