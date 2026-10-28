using System.Security.Claims;
using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

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

		///	<summary>
		///	Detail pages and share links: base content, public and link entries, plus the user's own (or any, for admins).
		///	</summary>
		public bool CanView(GameEntity entity, ClaimsPrincipal user, IReadOnlySet<Guid> shared) =>
			entity.IsOfficialSRD || entity.Visibility != ContentVisibility.Private || shared.Contains(entity.Id) || IsAuthorOrAdmin(entity, user);

		///	<summary>
		///	Lists show base content, public entries, the user's own and the ones shared with the user (chosen by the author,
		///	or link-only entries the user added to the collection); other link-only entries are reachable through their link.
		///	</summary>
		public bool IsListed(GameEntity entity, ClaimsPrincipal user, IReadOnlySet<Guid> shared) =>
			entity.IsOfficialSRD || entity.Visibility == ContentVisibility.Public || shared.Contains(entity.Id) || IsAuthor(entity, user);

		///	<summary>
		///	A subclass or lineage is also listed when its class or species was shared with the user by the same author.
		///	</summary>
		public bool IsListed(GameEntity child, ClaimsPrincipal user, IReadOnlySet<Guid> shared, GameEntity parent) =>
			IsListed(child, user, shared) || (shared.Contains(parent.Id) && child.AuthorId is not null && child.AuthorId == parent.AuthorId);

		///	<summary>
		///	Same rule as <see cref="IsListed"/>, translated to SQL.
		///	</summary>
		public static IQueryable<T> ListedFor<T>(IQueryable<T> query, ClaimsPrincipal user, IReadOnlySet<Guid> shared) where T : GameEntity
		{
			var userId = user.Identity?.IsAuthenticated == true ? GetUserId(user) : null;
			var sharedIds = shared.ToList();
			return query.Where(e => e.IsOfficialSRD || e.Visibility == ContentVisibility.Public || (userId != null && e.AuthorId == userId) || sharedIds.Contains(e.Id));
		}

		private static bool IsAuthor(GameEntity entity, ClaimsPrincipal user)
		{
			var userId = user.Identity?.IsAuthenticated == true ? GetUserId(user) : null;
			return userId is not null && entity.AuthorId == userId;
		}

		private bool IsAuthorOrAdmin(GameEntity entity, ClaimsPrincipal user) =>
			user.Identity?.IsAuthenticated == true && (IsAdmin(user) || IsAuthor(entity, user));

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
