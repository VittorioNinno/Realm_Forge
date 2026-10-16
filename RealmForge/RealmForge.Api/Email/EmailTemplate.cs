using System.Net;
using System.Text;

namespace RealmForge.Api.Email
{
	///	<summary>
	///	RealmForge e-mail layout: same palette and fonts as the client (dark surfaces, forge orange, Cinzel titles),
	///	headed by the RealmForge wordmark. Built with tables and inline styles because mail clients ignore most modern CSS.
	///	</summary>
	public static class EmailTemplate
	{
		//	Palette of RealmForge.Client/wwwroot/css/app.css
		private const string BgMain = "#0d0d0d";
		private const string BgCard = "#161616";
		private const string BorderLight = "#333333";
		private const string Orange = "#ff8c00";
		private const string TextPrimary = "#ffffff";
		private const string TextSecondary = "#b0b0b0";
		private const string TextMuted = "#777777";
		private const string FontDisplay = "'Cinzel', Georgia, 'Times New Roman', serif";
		private const string FontBody = "'Inter', 'Segoe UI', Roboto, Helvetica, Arial, sans-serif";

		///	<summary>
		///	One section per language (Italian first), each with a title, a text and a call-to-action button.
		///	</summary>
		public record Section(string Title, string Text, string ButtonLabel);

		public static string ActionEmail(string preheader, Section italian, Section english, string link)
		{
			var href = WebUtility.HtmlEncode(link);

			var content = new StringBuilder()
				.Append(SectionHtml(italian, href))
				.Append(Divider())
				.Append(SectionHtml(english, href))
				.Append($"""
					<p style="margin:28px 0 6px;font-family:{FontBody};font-size:12px;line-height:18px;color:{TextMuted};">
					  Se il pulsante non funziona, copia questo indirizzo nel browser · If the button does not work, paste this address into your browser:
					</p>
					<p style="margin:0;font-family:{FontBody};font-size:12px;line-height:18px;word-break:break-all;">
					  <a href="{href}" style="color:{Orange};text-decoration:underline;">{href}</a>
					</p>
					""");

			return Layout(preheader, content.ToString());
		}

		public static string CodeEmail(string preheader, Section italian, Section english, string code)
		{
			var encoded = WebUtility.HtmlEncode(code);
			string CodeBox() => $"""
				<table role="presentation" cellspacing="0" cellpadding="0" border="0" style="margin:18px 0 4px;">
				  <tr><td style="background:{BgMain};border:1px solid {BorderLight};border-left:3px solid {Orange};border-radius:4px;padding:12px 18px;font-family:Consolas,'Courier New',monospace;font-size:18px;letter-spacing:2px;color:{TextPrimary};">{encoded}</td></tr>
				</table>
				""";

			var content = new StringBuilder()
				.Append(Title(italian.Title)).Append(Paragraph(italian.Text)).Append(CodeBox())
				.Append(Divider())
				.Append(Title(english.Title)).Append(Paragraph(english.Text)).Append(CodeBox());

			return Layout(preheader, content.ToString());
		}

		///	<summary>
		///	Plain-text alternative (shown by clients that do not render HTML; it also helps with spam filters).
		///	</summary>
		public static string PlainText(Section italian, Section english, string linkOrCode) =>
			$"""
			{italian.Title}
			{italian.Text}
			{linkOrCode}

			{english.Title}
			{english.Text}
			{linkOrCode}

			Se non hai fatto tu questa richiesta, ignora questa email. · If you did not ask for this, ignore this e-mail.
			RealmForge
			""";

		private static string SectionHtml(Section section, string href) =>
			Title(section.Title) + Paragraph(section.Text) + Button(section.ButtonLabel, href);

		private static string Title(string text) => $"""
			<h1 style="margin:0 0 14px;font-family:{FontDisplay};font-size:22px;line-height:30px;font-weight:700;letter-spacing:1.5px;text-transform:uppercase;color:{Orange};">{WebUtility.HtmlEncode(text)}</h1>
			""";

		private static string Paragraph(string text) => $"""
			<p style="margin:0;font-family:{FontBody};font-size:15px;line-height:23px;color:{TextSecondary};">{WebUtility.HtmlEncode(text)}</p>
			""";

		//	"Bulletproof" button: a table cell with a background colour works in every client, Outlook included
		private static string Button(string label, string href) => $"""
			<table role="presentation" cellspacing="0" cellpadding="0" border="0" style="margin:22px 0 0;">
			  <tr>
			    <td bgcolor="{Orange}" style="border-radius:6px;background:{Orange};">
			      <a href="{href}" style="display:inline-block;padding:13px 26px;font-family:{FontBody};font-size:13px;font-weight:800;letter-spacing:1.5px;text-transform:uppercase;color:#000000;text-decoration:none;border-radius:6px;">{WebUtility.HtmlEncode(label)}</a>
			    </td>
			  </tr>
			</table>
			""";

		private static string Divider() => $"""
			<table role="presentation" width="100%" cellspacing="0" cellpadding="0" border="0" style="margin:30px 0;">
			  <tr><td style="border-top:1px solid {BorderLight};font-size:0;line-height:0;">&nbsp;</td></tr>
			</table>
			""";

		private static string Layout(string preheader, string content) => $"""
			<!DOCTYPE html>
			<html lang="it">
			<head>
			  <meta charset="utf-8">
			  <meta name="viewport" content="width=device-width, initial-scale=1">
			  <meta name="color-scheme" content="dark">
			  <meta name="supported-color-schemes" content="dark">
			  <title>RealmForge</title>
			  <link href="https://fonts.googleapis.com/css2?family=Cinzel:wght@700&family=Inter:wght@400;800&display=swap" rel="stylesheet">
			</head>
			<body style="margin:0;padding:0;background:{BgMain};">
			  <!-- Preview text shown by the inbox next to the subject -->
			  <div style="display:none;max-height:0;overflow:hidden;opacity:0;color:{BgMain};">{WebUtility.HtmlEncode(preheader)}</div>
			  <table role="presentation" width="100%" cellspacing="0" cellpadding="0" border="0" bgcolor="{BgMain}" style="background:{BgMain};">
			    <tr>
			      <td align="center" style="padding:32px 16px;">
			        <table role="presentation" width="100%" cellspacing="0" cellpadding="0" border="0" style="max-width:560px;">
			          <tr>
			            <td align="center" style="padding:0 0 22px;">
			              <span style="font-family:{FontDisplay};font-size:26px;line-height:32px;font-weight:700;letter-spacing:5px;color:{Orange};">REALMFORGE</span>
			            </td>
			          </tr>
			          <tr>
			            <td bgcolor="{BgCard}" style="background:{BgCard};border:1px solid {BorderLight};border-top:3px solid {Orange};border-radius:8px;padding:32px 30px;">
			              {content}
			            </td>
			          </tr>
			          <tr>
			            <td align="center" style="padding:22px 10px 0;font-family:{FontBody};font-size:12px;line-height:18px;color:{TextMuted};">
			              Se non hai fatto tu questa richiesta, ignora questa email.<br>
			              If you did not ask for this, ignore this e-mail.<br><br>
			              <span style="font-family:{FontDisplay};letter-spacing:2px;color:{TextSecondary};">REALMFORGE</span> · TTRPG Suite
			            </td>
			          </tr>
			        </table>
			      </td>
			    </tr>
			  </table>
			</body>
			</html>
			""";
	}
}
