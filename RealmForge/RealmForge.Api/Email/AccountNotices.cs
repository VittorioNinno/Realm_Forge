namespace RealmForge.Api.Email
{
	///	<summary>
	///	E-mails that tell the person what happened to the account: suspended by an administrator (until when),
	///	reactivated, deleted (by an administrator or by the person). In Italian and English like the other e-mails; a
	///	failure to send never stops the action (the sender logs it).
	///	</summary>
	public class AccountNotices
	{
		private static readonly string[] MonthsIt = ["gennaio", "febbraio", "marzo", "aprile", "maggio", "giugno", "luglio", "agosto", "settembre", "ottobre", "novembre", "dicembre"];
		private static readonly string[] MonthsEn = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

		private readonly IdentityEmailSender _sender;

		public AccountNotices(IdentityEmailSender sender)
		{
			_sender = sender;
		}

		//	A suspension longer than five years reads as "until reactivated"
		public Task SuspendedAsync(string email, DateTimeOffset until)
		{
			var forever = until > DateTimeOffset.UtcNow.AddYears(5);
			var it = new EmailTemplate.Section("Account sospeso",
				forever
					? "Un amministratore ha sospeso il tuo account RealmForge fino a nuova riattivazione. Nel frattempo non puoi accedere; i tuoi personaggi, le campagne e i contenuti restano come sono."
					: $"Un amministratore ha sospeso il tuo account RealmForge fino al {DateIt(until)}. Fino ad allora non puoi accedere; i tuoi personaggi, le campagne e i contenuti restano come sono.",
				string.Empty);
			var en = new EmailTemplate.Section("Account suspended",
				forever
					? "An administrator suspended your RealmForge account until it is reactivated. Meanwhile you cannot sign in; your characters, campaigns and content stay as they are."
					: $"An administrator suspended your RealmForge account until {DateEn(until)}. Until then you cannot sign in; your characters, campaigns and content stay as they are.",
				string.Empty);
			return SendAsync(email, "Account sospeso · Account suspended", "notice:suspended", it, en, null);
		}

		public Task ReactivatedAsync(string email)
		{
			var it = new EmailTemplate.Section("Account riattivato",
				"Un amministratore ha riattivato il tuo account RealmForge: puoi accedere di nuovo.", "Accedi");
			var en = new EmailTemplate.Section("Account reactivated",
				"An administrator reactivated your RealmForge account: you can sign in again.", "Sign in");
			return SendAsync(email, "Account riattivato · Account reactivated", "notice:reactivated", it, en, _sender.ClientPage("account"));
		}

		public Task DeletedAsync(string email, bool byAdministrator)
		{
			var it = new EmailTemplate.Section("Account eliminato",
				byAdministrator
					? "Un amministratore ha eliminato il tuo account RealmForge con i tuoi personaggi e i dati personali. I contenuti Homebrew usati da altri restano senza autore."
					: "Il tuo account RealmForge è stato eliminato come hai chiesto, con i tuoi personaggi e i dati personali. I contenuti Homebrew usati da altri restano senza autore.",
				string.Empty);
			var en = new EmailTemplate.Section("Account deleted",
				byAdministrator
					? "An administrator deleted your RealmForge account with your characters and personal data. Homebrew content used by others stays without an author."
					: "Your RealmForge account was deleted as you asked, with your characters and personal data. Homebrew content used by others stays without an author.",
				string.Empty);
			return SendAsync(email, "Account eliminato · Account deleted", byAdministrator ? "notice:deleted-by-admin" : "notice:deleted", it, en, null);
		}

		private Task SendAsync(string email, string subject, string tag, EmailTemplate.Section it, EmailTemplate.Section en, string? link) =>
			_sender.SendNoticeAsync(email, $"RealmForge · {subject}", tag,
				EmailTemplate.NoticeEmail(it.Title, it, en, link),
				EmailTemplate.NoticeText(it, en, link));

		private static string DateIt(DateTimeOffset at) => $"{at.UtcDateTime.Day} {MonthsIt[at.UtcDateTime.Month - 1]} {at.UtcDateTime.Year}";

		private static string DateEn(DateTimeOffset at) => $"{MonthsEn[at.UtcDateTime.Month - 1]} {at.UtcDateTime.Day}, {at.UtcDateTime.Year}";
	}
}
