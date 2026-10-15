using System.Security.Claims;
using RealmForge.Domain.Common;

namespace RealmForge.Api.Security
{
	///	<summary>
	///	Single place that decides who may change a piece of game content:
	///	- official SRD content: nobody (it comes from the seeders);
	///	- Homebrew: its author, or an administrator listed in "Auth:AdminEmails".
	///	Legacy Homebrew created before authentication (AuthorId = null) is editable by administrators only.
	///	</summary>
	public class ContentAccess
	{
		private readonly HashSet<string> _adminEmails;

		public ContentAccess(IConfiguration configuration)
		{
			var emails = configuration.GetSection("Auth:AdminEmails").Get<string[]>() ?? Array.Empty<string>();
			_adminEmails = new HashSet<string>(emails, StringComparer.OrdinalIgnoreCase);
		}

		public static string? GetUserId(ClaimsPrincipal user) =>
			user.FindFirstValue(ClaimTypes.NameIdentifier);

		public bool IsAdmin(ClaimsPrincipal user)
		{
			var email = user.FindFirstValue(ClaimTypes.Email) ?? user.Identity?.Name;
			return email is not null && _adminEmails.Contains(email);
		}

		public bool CanModify(GameEntity entity, ClaimsPrincipal user)
		{
			if (entity.IsOfficialSRD || user.Identity?.IsAuthenticated != true)
			{
				return false;
			}

			if (IsAdmin(user))
			{
				return true;
			}

			var userId = GetUserId(user);
			return userId is not null && entity.AuthorId == userId;
		}
	}
}
