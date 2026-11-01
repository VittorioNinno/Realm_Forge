using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.WebUtilities;
using RealmForge.Infrastructure.Identity;
using RealmForge.Shared.DTOs;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	Passkeys (WebAuthn) with the bearer tokens of the API: a signed-in person adds, renames and removes passkeys;
	///	anyone signs in with one. The state between the options and the browser's answer travels with the client,
	///	protected and valid for 10 minutes, so no cookie is needed across the client's and the API's domains. The
	///	checks (challenge, origin, relying party, signature, counter) are those of ASP.NET Core Identity.
	///	</summary>
	[ApiController]
	[Route("api/passkeys")]
	public class PasskeysController : ControllerBase
	{
		private const int MaxPasskeys = 10;
		private static readonly TimeSpan StateLifetime = TimeSpan.FromMinutes(10);

		private readonly UserManager<ApplicationUser> _users;
		private readonly SignInManager<ApplicationUser> _signIn;
		private readonly IPasskeyHandler<ApplicationUser> _passkeys;
		private readonly ITimeLimitedDataProtector _protector;
		private readonly ILogger<PasskeysController> _logger;

		public PasskeysController(UserManager<ApplicationUser> users, SignInManager<ApplicationUser> signIn, IPasskeyHandler<ApplicationUser> passkeys,
			IDataProtectionProvider protection, ILogger<PasskeysController> logger)
		{
			_users = users;
			_signIn = signIn;
			_passkeys = passkeys;
			_protector = protection.CreateProtector("RealmForge.Passkeys.v1").ToTimeLimitedDataProtector();
			_logger = logger;
		}

		//	GET: api/passkeys — the passkeys of my account
		[HttpGet]
		[Authorize]
		public async Task<ActionResult<List<PasskeyDto>>> GetPasskeys()
		{
			var user = await _users.GetUserAsync(User);
			if (user is null)
			{
				return Unauthorized();
			}
			var passkeys = await _users.GetPasskeysAsync(user);
			return Ok(passkeys.OrderBy(p => p.CreatedAt).Select(ToDto).ToList());
		}

		//	POST: api/passkeys/creation-options — options to create a passkey for my account
		[HttpPost("creation-options")]
		[Authorize]
		[EnableRateLimiting(Program.AuthRateLimit)]
		public async Task<ActionResult<PasskeyOptionsDto>> CreationOptions()
		{
			var user = await _users.GetUserAsync(User);
			if (user is null)
			{
				return Unauthorized();
			}
			if ((await _users.GetPasskeysAsync(user)).Count >= MaxPasskeys)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: $"At most {MaxPasskeys} passkeys per account.");
			}
			var email = user.Email ?? user.UserName ?? user.Id;
			var options = await _passkeys.MakeCreationOptionsAsync(new PasskeyUserEntity
			{
				Id = user.Id,
				Name = email,
				DisplayName = string.IsNullOrWhiteSpace(user.Nickname) ? email : user.Nickname
			}, HttpContext);
			return Ok(new PasskeyOptionsDto(options.CreationOptionsJson, Protect("create", options.AttestationState)));
		}

		//	POST: api/passkeys — the browser's answer: the new passkey is saved on my account
		[HttpPost]
		[Authorize]
		[EnableRateLimiting(Program.AuthRateLimit)]
		public async Task<ActionResult<PasskeyDto>> AddPasskey([FromBody] PasskeyCredentialDto dto)
		{
			var user = await _users.GetUserAsync(User);
			if (user is null)
			{
				return Unauthorized();
			}
			if (!TryUnprotect("create", dto.State, out var state) || string.IsNullOrWhiteSpace(dto.Credential))
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The passkey request expired: try again.", detail: "PasskeyExpired");
			}
			var result = await _passkeys.PerformAttestationAsync(new PasskeyAttestationContext
			{
				HttpContext = HttpContext,
				CredentialJson = dto.Credential,
				AttestationState = state
			});
			if (!result.Succeeded || result.UserEntity.Id != user.Id)
			{
				_logger.LogInformation("Passkey not added for {UserId}: {Reason}", user.Id, result.Failure?.Message ?? "another account");
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The passkey could not be verified.", detail: "PasskeyFailed");
			}
			result.Passkey.Name = CleanName(dto.Name) ?? "Passkey";
			var saved = await _users.AddOrUpdatePasskeyAsync(user, result.Passkey);
			if (!saved.Succeeded)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "The passkey could not be saved.", detail: "PasskeyFailed");
			}
			return Ok(ToDto(result.Passkey));
		}

		//	PUT: api/passkeys/{id} — a new name
		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> RenamePasskey(string id, [FromBody] RenamePasskeyDto dto)
		{
			var user = await _users.GetUserAsync(User);
			if (user is null)
			{
				return Unauthorized();
			}
			if (FromId(id) is not { } credentialId || await _users.GetPasskeyAsync(user, credentialId) is not { } passkey)
			{
				return NotFound();
			}
			if (CleanName(dto.Name) is not { } name)
			{
				return Problem(statusCode: StatusCodes.Status400BadRequest, title: "A passkey needs a name (at most 60 characters).");
			}
			passkey.Name = name;
			await _users.AddOrUpdatePasskeyAsync(user, passkey);
			return NoContent();
		}

		//	DELETE: api/passkeys/{id}
		[HttpDelete("{id}")]
		[Authorize]
		public async Task<IActionResult> RemovePasskey(string id)
		{
			var user = await _users.GetUserAsync(User);
			if (user is null)
			{
				return Unauthorized();
			}
			if (FromId(id) is not { } credentialId || await _users.GetPasskeyAsync(user, credentialId) is null)
			{
				return NotFound();
			}
			await _users.RemovePasskeyAsync(user, credentialId);
			return NoContent();
		}

		//	POST: api/passkeys/request-options — options to sign in with a passkey (any account: the browser lists the ones it has)
		[HttpPost("request-options")]
		[AllowAnonymous]
		[EnableRateLimiting(Program.AuthRateLimit)]
		public async Task<ActionResult<PasskeyOptionsDto>> RequestOptions()
		{
			var options = await _passkeys.MakeRequestOptionsAsync(null, HttpContext);
			return Ok(new PasskeyOptionsDto(options.RequestOptionsJson, Protect("sign-in", options.AssertionState)));
		}

		//	POST: api/passkeys/sign-in — the browser's answer: the same tokens as /api/auth/login
		[HttpPost("sign-in")]
		[AllowAnonymous]
		[EnableRateLimiting(Program.AuthRateLimit)]
		public async Task<IActionResult> SignIn([FromBody] PasskeyCredentialDto dto)
		{
			if (!TryUnprotect("sign-in", dto.State, out var state) || string.IsNullOrWhiteSpace(dto.Credential))
			{
				return Problem(statusCode: StatusCodes.Status401Unauthorized, title: "The passkey request expired: try again.", detail: "PasskeyExpired");
			}
			var result = await _passkeys.PerformAssertionAsync(new PasskeyAssertionContext
			{
				HttpContext = HttpContext,
				CredentialJson = dto.Credential,
				AssertionState = state
			});
			if (!result.Succeeded)
			{
				_logger.LogInformation("Passkey sign-in refused: {Reason}", result.Failure.Message);
				return Problem(statusCode: StatusCodes.Status401Unauthorized, title: "Passkey not recognised.", detail: "PasskeyFailed");
			}
			var user = result.User;

			//	The same checks as the password sign-in: a suspended or locked account stays out
			if (await _users.IsLockedOutAsync(user))
			{
				return Problem(statusCode: StatusCodes.Status401Unauthorized, title: "Account locked.", detail: "LockedOut");
			}
			if (!await _signIn.CanSignInAsync(user))
			{
				return Problem(statusCode: StatusCodes.Status401Unauthorized, title: "Sign-in not allowed.", detail: "NotAllowed");
			}

			//	The latest counter and authenticator data are kept, as Identity does after a passkey sign-in
			await _users.AddOrUpdatePasskeyAsync(user, result.Passkey);

			//	The bearer handler writes the token response itself, like the password sign-in of /api/auth/login
			_signIn.AuthenticationScheme = IdentityConstants.BearerScheme;
			await _signIn.SignInAsync(user, isPersistent: false);
			return new EmptyResult();
		}

		private static PasskeyDto ToDto(UserPasskeyInfo p) => new(WebEncoders.Base64UrlEncode(p.CredentialId), p.Name ?? "Passkey", p.CreatedAt);

		private static byte[]? FromId(string id)
		{
			try
			{
				return WebEncoders.Base64UrlDecode(id);
			}
			catch (FormatException)
			{
				return null;
			}
		}

		private static string? CleanName(string? name)
		{
			var value = name?.Trim();
			return string.IsNullOrEmpty(value) ? null : value.Length > 60 ? value[..60] : value;
		}

		//	The purpose is part of the protected text: a state for adding a passkey cannot be used to sign in
		private string Protect(string purpose, string? state) => _protector.Protect($"{purpose}\n{state}", StateLifetime);

		private bool TryUnprotect(string purpose, string? protectedState, out string? state)
		{
			state = null;
			if (string.IsNullOrEmpty(protectedState))
			{
				return false;
			}
			try
			{
				var text = _protector.Unprotect(protectedState);
				var newline = text.IndexOf('\n');
				if (newline < 0 || text[..newline] != purpose)
				{
					return false;
				}
				state = text[(newline + 1)..];
				return true;
			}
			catch (System.Security.Cryptography.CryptographicException)
			{
				return false;
			}
		}
	}
}
