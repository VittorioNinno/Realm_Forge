using System.Net;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using RealmForge.Infrastructure.Identity;

namespace RealmForge.Api.Email
{
	///	<summary>
	///	E-mails sent by the Identity endpoints (/api/auth): account confirmation and password reset.
	///	Links point to the Blazor client (e.g. /confirm-email), which then calls the API.
	///	Texts are bilingual because the user's language is not known when the account is created.
	///	</summary>
	public class IdentityEmailSender : IEmailSender<ApplicationUser>
	{
		private readonly EmailOptions _options;
		private readonly IHttpContextAccessor _http;
		private readonly string[] _allowedOrigins;
		private readonly ILogger<IdentityEmailSender> _logger;

		public IdentityEmailSender(IOptions<EmailOptions> options, IHttpContextAccessor http, IConfiguration configuration, ILogger<IdentityEmailSender> logger)
		{
			_options = options.Value;
			_http = http;
			_allowedOrigins = (configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>())
				.Where(o => !string.IsNullOrWhiteSpace(o))
				.Select(o => o.Trim().TrimEnd('/'))
				.ToArray();
			_logger = logger;
		}

		public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
		{
			var link = ToClientLink("confirm-email", confirmationLink);
			var it = new EmailTemplate.Section("Conferma il tuo indirizzo email",
				"Benvenuto nella Forgia! Per creare e condividere contenuti Homebrew su RealmForge conferma il tuo indirizzo email.", "Conferma email");
			var en = new EmailTemplate.Section("Confirm your e-mail address",
				"Welcome to the Forge! To create and share Homebrew content on RealmForge, please confirm your e-mail address.", "Confirm e-mail");

			return SendAsync(email, "Conferma il tuo account RealmForge · Confirm your RealmForge account", link,
				EmailTemplate.ActionEmail("Conferma il tuo indirizzo email per iniziare a forgiare.", it, en, link),
				EmailTemplate.PlainText(it, en, link));
		}

		//	Not called by the Identity API endpoints (they send a code, see SendPasswordResetCodeAsync); kept for the interface
		public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
		{
			var link = ToClientLink("reset-password", resetLink);
			var it = new EmailTemplate.Section("Reimposta la password",
				"Hai chiesto di reimpostare la password del tuo account RealmForge.", "Reimposta password");
			var en = new EmailTemplate.Section("Reset your password",
				"You asked to reset the password of your RealmForge account.", "Reset password");

			return SendAsync(email, "Reimposta la password · Reset your password", link,
				EmailTemplate.ActionEmail("Reimposta la password del tuo account RealmForge.", it, en, link),
				EmailTemplate.PlainText(it, en, link));
		}

		//	The Identity endpoint /api/auth/forgotPassword sends a reset code (only to confirmed addresses).
		//	The e-mail links to the client page /reset-password with the address and the code already filled in
		public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
		{
			var link = QueryHelpers.AddQueryString($"{ClientBaseUrl().TrimEnd('/')}/reset-password",
				new Dictionary<string, string?> { ["email"] = email, ["code"] = resetCode });
			var it = new EmailTemplate.Section("Reimposta la password",
				"Hai chiesto di reimpostare la password del tuo account RealmForge. Il link vale per un tempo limitato.", "Reimposta password");
			var en = new EmailTemplate.Section("Reset your password",
				"You asked to reset the password of your RealmForge account. The link is valid for a limited time.", "Reset password");

			return SendAsync(email, "Reimposta la password · Reset your password", link,
				EmailTemplate.ActionEmail("Reimposta la password del tuo account RealmForge.", it, en, link),
				EmailTemplate.PlainText(it, en, link));
		}

		//	Identity builds links to its own API endpoint; the same query (userId, code, ...) is sent to the client page instead.
		//	Identity hands the link over HTML-encoded ("&amp;code="), so it is decoded before reading the query
		private string ToClientLink(string clientPage, string identityLink)
		{
			var query = QueryHelpers.ParseQuery(new Uri(WebUtility.HtmlDecode(identityLink)).Query)
				.ToDictionary(kv => kv.Key, kv => (string?)kv.Value.ToString());

			return QueryHelpers.AddQueryString($"{ClientBaseUrl().TrimEnd('/')}/{clientPage}", query);
		}

		//	The client that sent the request (registration or "resend" button) when it is an allowed origin, otherwise the configured one
		private string ClientBaseUrl()
		{
			var origin = _http.HttpContext?.Request.Headers.Origin.ToString();

			if (!string.IsNullOrWhiteSpace(origin) && _allowedOrigins.Contains(origin, StringComparer.OrdinalIgnoreCase))
			{
				return origin;
			}

			return _options.ClientBaseUrl ?? _allowedOrigins.FirstOrDefault() ?? "http://localhost:5227";
		}

		private async Task SendAsync(string to, string subject, string logValue, string html, string text)
		{
			if (!_options.IsConfigured)
			{
				//	Development / CI: no SMTP server, the link is written to the log so the flow can still be completed
				_logger.LogWarning("E-mail not sent (SMTP not configured). {Subject} for {Email}: {Link}", subject, to, logValue);
				return;
			}

			//	IsConfigured guarantees host and username
			var host = _options.Host!;
			var username = _options.Username!;

			var message = new MimeMessage();
			message.From.Add(new MailboxAddress(_options.FromName, _options.FromAddress ?? username));
			message.To.Add(MailboxAddress.Parse(to));
			message.Subject = subject;
			message.Body = new BodyBuilder { HtmlBody = html, TextBody = text }.ToMessageBody();

			//	Port 465 uses TLS from the first byte; 587 (and 25) start in clear text and switch with STARTTLS
			var security = _options.Port == 465 ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls;

			try
			{
				using var client = new SmtpClient();
				client.Timeout = 30000;

				await client.ConnectAsync(host, _options.Port, security);

				//	App passwords are shown by Google in groups of four characters: the spaces are not part of the password
				await client.AuthenticateAsync(username, (_options.Password ?? string.Empty).Replace(" ", string.Empty));
				await client.SendAsync(message);
				await client.DisconnectAsync(true);

				_logger.LogInformation("E-mail sent to {Email}: {Subject}", to, subject);
			}
			//	Gmail answers wrong credentials with "5.7.8" and closes the connection instead of a plain authentication error
			catch (Exception ex) when (ex is AuthenticationException || (ex is SmtpProtocolException or SmtpCommandException && ex.Message.Contains("5.7.8")))
			{
				_logger.LogError(ex, "SMTP login refused for {Username} on {Host}:{Port}. With Gmail, Email:Password must be an app password generated in that same account (2-Step Verification on), not the normal password.",
					_options.Username, _options.Host, _options.Port);
			}
			catch (Exception ex) when (ex is SmtpCommandException or SmtpProtocolException or SslHandshakeException or System.Net.Sockets.SocketException or IOException or TimeoutException)
			{
				//	Registration must not fail because of the mail server: the user can ask for a new e-mail from the account page
				_logger.LogError(ex, "Could not send e-mail to {Email} through {Host}:{Port} ({Security}). Check host and port (Gmail: smtp.gmail.com, 587) and that no antivirus mail shield intercepts the connection.",
					to, _options.Host, _options.Port, security);
			}
		}
	}
}
