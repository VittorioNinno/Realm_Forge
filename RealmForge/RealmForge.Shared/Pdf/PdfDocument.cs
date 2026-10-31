using System.Globalization;
using System.Text;

namespace RealmForge.Shared.Pdf;

public enum PdfFont
{
	Regular = 1,
	Bold = 2
}

public readonly record struct PdfColor(double R, double G, double B)
{
	public static readonly PdfColor Black = new(0.1, 0.1, 0.1);
	public static readonly PdfColor Grey = new(0.42, 0.42, 0.42);
	public static readonly PdfColor Light = new(0.85, 0.85, 0.85);
	public static readonly PdfColor Paper = new(0.97, 0.96, 0.94);
	public static readonly PdfColor Orange = new(0.86, 0.45, 0.0);
	public static readonly PdfColor White = new(1, 1, 1);
}

///	<summary>
///	A minimal PDF 1.4 writer: A4 pages with text in the standard Helvetica fonts (WinAnsi, so Italian accents work
///	without embedding fonts), lines and rectangles. Coordinates are in points from the top-left corner. No
///	dependencies, so it runs in the browser (Blazor WebAssembly) as well as on the server.
///	</summary>
public sealed class PdfDocument
{
	public const double Width = 595.28;
	public const double Height = 841.89;

	private readonly List<StringBuilder> _pages = new();
	private StringBuilder _page = new();

	public PdfDocument()
	{
		AddPage();
	}

	public int PageCount => _pages.Count;

	///	<summary>
	///	Draws on an existing page (0-based), e.g. the footers once the page count is known.
	///	</summary>
	public void UsePage(int index) => _page = _pages[index];

	public void AddPage()
	{
		_page = new StringBuilder();
		_pages.Add(_page);
	}

	public void Text(double x, double y, string text, PdfFont font = PdfFont.Regular, double size = 10, PdfColor? color = null)
	{
		if (string.IsNullOrEmpty(text))
		{
			return;
		}

		var c = color ?? PdfColor.Black;
		_page.Append(CultureInfo.InvariantCulture, $"BT {Rgb(c)} rg /F{(int)font} {N(size)} Tf {N(x)} {N(Height - y - size)} Td (");
		_page.Append(Escape(text));
		_page.Append(") Tj ET\n");
	}

	public void TextRight(double right, double y, string text, PdfFont font = PdfFont.Regular, double size = 10, PdfColor? color = null) =>
		Text(right - Measure(text, font, size), y, text, font, size, color);

	public void TextCenter(double center, double y, string text, PdfFont font = PdfFont.Regular, double size = 10, PdfColor? color = null) =>
		Text(center - Measure(text, font, size) / 2, y, text, font, size, color);

	public void Line(double x1, double y1, double x2, double y2, PdfColor color, double width = 0.6) =>
		_page.Append(CultureInfo.InvariantCulture, $"{Rgb(color)} RG {N(width)} w {N(x1)} {N(Height - y1)} m {N(x2)} {N(Height - y2)} l S\n");

	public void Rect(double x, double y, double w, double h, PdfColor? fill, PdfColor? stroke, double width = 0.6)
	{
		var op = (fill, stroke) switch
		{
			(not null, not null) => "B",
			(not null, null) => "f",
			_ => "S"
		};
		if (fill is { } f)
		{
			_page.Append(CultureInfo.InvariantCulture, $"{Rgb(f)} rg ");
		}
		if (stroke is { } s)
		{
			_page.Append(CultureInfo.InvariantCulture, $"{Rgb(s)} RG {N(width)} w ");
		}
		_page.Append(CultureInfo.InvariantCulture, $"{N(x)} {N(Height - y - h)} {N(w)} {N(h)} re {op}\n");
	}

	///	<summary>
	///	A rectangle with rounded corners (radius r), filled and/or stroked.
	///	</summary>
	public void RoundRect(double x, double y, double w, double h, double r, PdfColor? fill, PdfColor? stroke, double width = 0.6)
	{
		r = Math.Max(0, Math.Min(r, Math.Min(w, h) / 2));
		var k = r * Kappa;
		var b = Height - y - h;
		var t = Height - y;
		Paint(fill, stroke, width);
		_page.Append(CultureInfo.InvariantCulture,
			$"{N(x + r)} {N(b)} m {N(x + w - r)} {N(b)} l {N(x + w - r + k)} {N(b)} {N(x + w)} {N(b + r - k)} {N(x + w)} {N(b + r)} c ");
		_page.Append(CultureInfo.InvariantCulture,
			$"{N(x + w)} {N(t - r)} l {N(x + w)} {N(t - r + k)} {N(x + w - r + k)} {N(t)} {N(x + w - r)} {N(t)} c ");
		_page.Append(CultureInfo.InvariantCulture,
			$"{N(x + r)} {N(t)} l {N(x + r - k)} {N(t)} {N(x)} {N(t - r + k)} {N(x)} {N(t - r)} c ");
		_page.Append(CultureInfo.InvariantCulture,
			$"{N(x)} {N(b + r)} l {N(x)} {N(b + r - k)} {N(x + r - k)} {N(b)} {N(x + r)} {N(b)} c h {Op(fill, stroke)}\n");
	}

	///	<summary>
	///	A circle centered on (cx, cy), filled and/or stroked.
	///	</summary>
	public void Circle(double cx, double cy, double r, PdfColor? fill, PdfColor? stroke, double width = 0.6)
	{
		var k = r * Kappa;
		var y = Height - cy;
		Paint(fill, stroke, width);
		_page.Append(CultureInfo.InvariantCulture,
			$"{N(cx + r)} {N(y)} m {N(cx + r)} {N(y + k)} {N(cx + k)} {N(y + r)} {N(cx)} {N(y + r)} c {N(cx - k)} {N(y + r)} {N(cx - r)} {N(y + k)} {N(cx - r)} {N(y)} c ");
		_page.Append(CultureInfo.InvariantCulture,
			$"{N(cx - r)} {N(y - k)} {N(cx - k)} {N(y - r)} {N(cx)} {N(y - r)} c {N(cx + k)} {N(y - r)} {N(cx + r)} {N(y - k)} {N(cx + r)} {N(y)} c h {Op(fill, stroke)}\n");
	}

	///	<summary>
	///	A dashed line (dash and gap in points).
	///	</summary>
	public void DashedLine(double x1, double y1, double x2, double y2, PdfColor color, double width = 0.6, double dash = 2, double gap = 2) =>
		_page.Append(CultureInfo.InvariantCulture,
			$"[{N(dash)} {N(gap)}] 0 d {Rgb(color)} RG {N(width)} w {N(x1)} {N(Height - y1)} m {N(x2)} {N(Height - y2)} l S [] 0 d\n");

	//	Bezier handle of a quarter circle
	private const double Kappa = 0.5523;

	private void Paint(PdfColor? fill, PdfColor? stroke, double width)
	{
		if (fill is { } f)
		{
			_page.Append(CultureInfo.InvariantCulture, $"{Rgb(f)} rg ");
		}
		if (stroke is { } s)
		{
			_page.Append(CultureInfo.InvariantCulture, $"{Rgb(s)} RG {N(width)} w ");
		}
	}

	private static string Op(PdfColor? fill, PdfColor? stroke) => (fill, stroke) switch
	{
		(not null, not null) => "B",
		(not null, null) => "f",
		_ => "S"
	};

	///	<summary>
	///	Width of a text in points.
	///	</summary>
	public static double Measure(string text, PdfFont font, double size)
	{
		var widths = font == PdfFont.Bold ? HelveticaBold : Helvetica;
		var total = 0;
		foreach (var b in Encode(text))
		{
			total += b >= 32 ? widths[b - 32] : 0;
		}

		return total * size / 1000.0;
	}

	///	<summary>
	///	Splits a text into lines that fit the width (words longer than the width are cut).
	///	</summary>
	public static List<string> Wrap(string text, PdfFont font, double size, double width)
	{
		var lines = new List<string>();
		foreach (var paragraph in (text ?? string.Empty).Replace("\r", string.Empty).Split('\n'))
		{
			var line = new StringBuilder();
			foreach (var word in paragraph.Split(' ', StringSplitOptions.RemoveEmptyEntries))
			{
				var candidate = line.Length == 0 ? word : $"{line} {word}";
				if (Measure(candidate, font, size) <= width)
				{
					line.Clear().Append(candidate);
					continue;
				}

				if (line.Length > 0)
				{
					lines.Add(line.ToString());
					line.Clear();
				}

				var rest = word;
				while (Measure(rest, font, size) > width && rest.Length > 1)
				{
					var cut = rest.Length - 1;
					while (cut > 1 && Measure(rest[..cut], font, size) > width)
					{
						cut--;
					}
					lines.Add(rest[..cut]);
					rest = rest[cut..];
				}
				line.Append(rest);
			}

			lines.Add(line.ToString());
		}

		return lines;
	}

	public byte[] ToBytes()
	{
		var output = new MemoryStream();
		var offsets = new List<long>();

		void Write(string s)
		{
			var bytes = Encoding.ASCII.GetBytes(s);
			output.Write(bytes, 0, bytes.Length);
		}

		void Object(int number, Action body)
		{
			while (offsets.Count < number)
			{
				offsets.Add(0);
			}
			offsets[number - 1] = output.Position;
			Write($"{number} 0 obj\n");
			body();
			Write("\nendobj\n");
		}

		Write("%PDF-1.4\n");
		output.Write(new byte[] { (byte)'%', 0xE2, 0xE3, 0xCF, 0xD3, (byte)'\n' });

		var pageCount = _pages.Count;
		var kids = string.Join(" ", Enumerable.Range(0, pageCount).Select(i => $"{5 + i * 2} 0 R"));

		Object(1, () => Write("<< /Type /Catalog /Pages 2 0 R >>"));
		Object(2, () => Write($"<< /Type /Pages /Kids [{kids}] /Count {pageCount} >>"));
		Object(3, () => Write("<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica /Encoding /WinAnsiEncoding >>"));
		Object(4, () => Write("<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold /Encoding /WinAnsiEncoding >>"));

		for (var i = 0; i < pageCount; i++)
		{
			var pageNumber = 5 + i * 2;
			var content = Encode(_pages[i].ToString());
			Object(pageNumber, () => Write(string.Create(CultureInfo.InvariantCulture,
				$"<< /Type /Page /Parent 2 0 R /MediaBox [0 0 {N(Width)} {N(Height)}] /Resources << /Font << /F1 3 0 R /F2 4 0 R >> >> /Contents {pageNumber + 1} 0 R >>")));
			Object(pageNumber + 1, () =>
			{
				Write($"<< /Length {content.Length} >>\nstream\n");
				output.Write(content, 0, content.Length);
				Write("\nendstream");
			});
		}

		var xref = output.Position;
		Write($"xref\n0 {offsets.Count + 1}\n0000000000 65535 f \n");
		foreach (var offset in offsets)
		{
			Write($"{offset:D10} 00000 n \n");
		}
		Write($"trailer\n<< /Size {offsets.Count + 1} /Root 1 0 R >>\nstartxref\n{xref}\n%%EOF\n");

		return output.ToArray();
	}

	private static string N(double value) => value.ToString("0.##", CultureInfo.InvariantCulture);

	private static string Rgb(PdfColor c) => $"{N(c.R)} {N(c.G)} {N(c.B)}";

	private static string Escape(string text)
	{
		var sb = new StringBuilder(text.Length + 8);
		foreach (var ch in text)
		{
			switch (ch)
			{
				case '\\': sb.Append("\\\\"); break;
				case '(': sb.Append("\\("); break;
				case ')': sb.Append("\\)"); break;
				case '\n':
				case '\r':
				case '\t': sb.Append(' '); break;
				default: sb.Append(ch); break;
			}
		}

		return sb.ToString();
	}

	///	<summary>
	///	Windows-1252 bytes of a text (characters outside it become a close ASCII form or "?").
	///	</summary>
	public static byte[] Encode(string text)
	{
		var bytes = new byte[text.Length];
		for (var i = 0; i < text.Length; i++)
		{
			bytes[i] = ToWinAnsi(text[i]);
		}

		return bytes;
	}

	private static byte ToWinAnsi(char ch)
	{
		if (ch < 128 || (ch >= 0xA0 && ch <= 0xFF))
		{
			return (byte)ch;
		}

		return ch switch
		{
			'€' => 0x80,
			'‚' => 0x82,
			'„' => 0x84,
			'…' => 0x85,
			'†' => 0x86,
			'‰' => 0x89,
			'Š' => 0x8A,
			'‹' => 0x8B,
			'Œ' => 0x8C,
			'Ž' => 0x8E,
			'‘' => 0x91,
			'’' => 0x92,
			'“' => 0x93,
			'”' => 0x94,
			'•' => 0x95,
			'–' => 0x96,
			'—' => 0x97,
			'™' => 0x99,
			'š' => 0x9A,
			'›' => 0x9B,
			'œ' => 0x9C,
			'ž' => 0x9E,
			'Ÿ' => 0x9F,
			'−' => (byte)'-',
			'‐' or '‑' => (byte)'-',
			'✓' or '✔' => (byte)'x',
			'○' or '◯' => (byte)'o',
			'●' => 0x95,
			_ => (byte)'?'
		};
	}

	//	Advance widths (1/1000 em) of Helvetica and Helvetica-Bold for WinAnsi codes 32–255
	private static readonly int[] Helvetica =
	{
		278,278,355,556,556,889,667,191,333,333,389,584,278,333,278,278,556,556,556,556,556,556,556,556,556,556,278,278,584,584,584,556,
		1015,667,667,722,722,667,611,778,722,278,500,667,556,833,722,778,667,778,722,667,611,722,667,944,667,667,611,278,278,278,469,556,
		333,556,556,500,556,556,278,556,556,222,222,500,222,833,556,556,556,556,333,500,278,556,500,722,500,500,500,334,260,334,584,761,
		556,0,222,556,333,1000,556,556,333,1000,667,333,1000,0,611,0,0,222,222,333,333,350,556,1000,333,1000,500,333,944,0,500,667,
		278,333,556,556,556,556,260,556,333,737,370,556,584,333,737,333,400,584,333,333,333,556,537,278,333,333,365,556,834,834,834,611,
		667,667,667,667,667,667,1000,722,667,667,667,667,278,278,278,278,722,722,778,778,778,778,778,584,778,722,722,722,722,667,667,611,
		556,556,556,556,556,556,889,500,556,556,556,556,278,278,278,278,556,556,556,556,556,556,556,584,611,556,556,556,556,500,556,500
	};

	private static readonly int[] HelveticaBold =
	{
		278,333,474,556,556,889,722,238,333,333,389,584,278,333,278,278,556,556,556,556,556,556,556,556,556,556,333,333,584,584,584,611,
		975,722,722,722,722,667,611,778,722,278,556,722,611,833,722,778,667,778,722,667,611,722,667,944,667,667,611,333,278,333,584,556,
		333,556,611,556,611,556,333,611,611,278,278,556,278,889,611,611,611,611,389,556,333,611,556,778,556,556,500,389,280,389,584,761,
		556,0,278,556,500,1000,556,556,333,1000,667,333,1000,0,611,0,0,278,278,500,500,350,556,1000,333,1000,556,333,944,0,500,667,
		278,333,556,556,556,556,280,556,333,737,370,556,584,333,737,333,400,584,333,333,333,611,556,278,333,333,365,556,834,834,834,611,
		722,722,722,722,722,722,1000,722,667,667,667,667,278,278,278,278,722,722,778,778,778,778,778,584,778,722,722,722,722,667,667,611,
		556,556,556,556,556,556,889,556,556,556,556,556,278,278,278,278,611,611,611,611,611,611,611,584,611,611,611,611,611,556,611,556
	};
}
