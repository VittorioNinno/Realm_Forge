using System.Globalization;
using System.Text;
using RealmForge.Client.Localization;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	The log of a session to keep: a Markdown file with the session (plan, recap, the masters' notes for the masters)
	///	and the rolls made at the table, oldest first; or the rolls alone as CSV for a spreadsheet. Times are local.
	///	</summary>
	public static class SessionLogExport
	{
		///	<summary>The window of a session's rolls: its day, from midnight to the morning after (sessions that end late).</summary>
		public static (DateTimeOffset From, DateTimeOffset To)? WindowOf(CampaignSessionDto session)
		{
			if (session.ScheduledAt is not { } when)
			{
				return null;
			}
			var day = when.ToLocalTime().Date;
			var from = new DateTimeOffset(day, TimeZoneInfo.Local.GetUtcOffset(day));
			return (from, from.AddHours(30));
		}

		public static string Markdown(string campaign, CampaignSessionDto? session, IReadOnlyList<CampaignRollDto> rolls, LanguageCode lang)
		{
			var culture = CultureInfo.GetCultureInfo(lang == LanguageCode.It ? "it-IT" : "en-GB");
			var md = new StringBuilder();
			if (session is not null)
			{
				md.AppendLine($"# {campaign} · {UiText.ExportSession(session.Number, lang)}{(session.Title.Length > 0 ? $": {session.Title}" : null)}");
				md.AppendLine();
				if (session.ScheduledAt is { } when)
				{
					md.AppendLine($"*{when.ToLocalTime().ToString("dddd d MMMM yyyy, HH:mm", culture)}*");
					md.AppendLine();
				}
				Section(md, UiText.SessionPlan(lang), session.Plan);
				Section(md, UiText.SessionRecap(lang), session.Recap);
				Section(md, UiText.SessionMasterNotes(lang), session.MasterNotes);
			}
			else
			{
				md.AppendLine($"# {campaign} · {UiText.ExportRollsTitle(lang)}");
				md.AppendLine();
			}
			md.AppendLine($"## {UiText.ExportRolls(rolls.Count, lang)}");
			md.AppendLine();
			if (rolls.Count == 0)
			{
				md.AppendLine(session?.ScheduledAt is null && session is not null ? UiText.ExportNoDate(lang) : UiText.RollsEmpty(lang));
			}
			DateTime? day = null;
			foreach (var roll in rolls.OrderBy(r => r.CreatedAt))
			{
				var at = roll.CreatedAt.ToLocalTime();
				if (day != at.Date)
				{
					day = at.Date;
					md.AppendLine();
					md.AppendLine($"### {at.ToString("dddd d MMMM yyyy", culture)}");
					md.AppendLine();
				}
				var dice = roll.Dice.Count == 0 ? string.Empty
					: $" [{string.Join(", ", roll.Dice.Select(d => d.Dropped ? $"~~{d.Value}~~" : d.Value.ToString(CultureInfo.InvariantCulture)))}]";
				var modifier = roll.Modifier == 0 ? string.Empty : roll.Modifier > 0 ? $" + {roll.Modifier}" : $" − {-roll.Modifier}";
				var label = roll.Label.Length > 0 && roll.Label != roll.Expression ? $"{Escape(roll.Label)}: " : string.Empty;
				md.Append($"- {at:HH:mm} · **{Escape(roll.Roller)}** — {label}`{roll.Expression}`{dice}{modifier} = **{roll.Total}**");
				if (!string.IsNullOrWhiteSpace(roll.Note))
				{
					md.Append($" — *{Escape(roll.Note)}*");
				}
				if (roll.Hidden)
				{
					md.Append($" ({UiText.ExportHidden(lang)})");
				}
				md.AppendLine();
			}
			return md.ToString();
		}

		public static string Csv(IReadOnlyList<CampaignRollDto> rolls, LanguageCode lang)
		{
			var csv = new StringBuilder();
			csv.AppendLine(string.Join(";", UiText.ExportCsvHeader(lang).Select(Cell)));
			foreach (var roll in rolls.OrderBy(r => r.CreatedAt))
			{
				var at = roll.CreatedAt.ToLocalTime();
				csv.AppendLine(string.Join(";", new[]
				{
					at.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
					at.ToString("HH:mm:ss", CultureInfo.InvariantCulture),
					roll.Roller,
					roll.Label,
					roll.Expression,
					string.Join(" ", roll.Dice.Select(d => d.Dropped ? $"({d.Value})" : d.Value.ToString(CultureInfo.InvariantCulture))),
					roll.Modifier.ToString(CultureInfo.InvariantCulture),
					roll.Total.ToString(CultureInfo.InvariantCulture),
					roll.Note ?? string.Empty,
					roll.Hidden ? "1" : "0"
				}.Select(Cell)));
			}
			return csv.ToString();
		}

		///	<summary>A name for the file: the campaign and what is in it, without the characters files cannot have.</summary>
		public static string FileName(string campaign, string what, string extension)
		{
			var name = string.Concat($"{campaign} {what}".Select(c => char.IsLetterOrDigit(c) ? c : c is ' ' or '-' or '_' ? '-' : '\0').Where(c => c != '\0'));
			while (name.Contains("--", StringComparison.Ordinal))
			{
				name = name.Replace("--", "-", StringComparison.Ordinal);
			}
			name = name.Trim('-');
			return $"{(name.Length == 0 ? "realmforge" : name)}.{extension}";
		}

		private static void Section(StringBuilder md, string title, string? text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			md.AppendLine($"## {title}");
			md.AppendLine();
			md.AppendLine(text.Trim());
			md.AppendLine();
		}

		//	Characters Markdown would read as formatting
		private static string Escape(string text) => text.Replace("*", "\\*", StringComparison.Ordinal).Replace("_", "\\_", StringComparison.Ordinal).Replace("`", "'", StringComparison.Ordinal);

		//	A CSV cell: in quotes, quotes doubled; a leading = + - @ made harmless for spreadsheets
		private static string Cell(string value)
		{
			var text = value.Length > 0 && "=+-@".Contains(value[0]) && !int.TryParse(value, out _) ? "'" + value : value;
			return $"\"{text.Replace("\"", "\"\"", StringComparison.Ordinal)}\"";
		}
	}
}
