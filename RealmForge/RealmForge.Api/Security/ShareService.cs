using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Api.Security
{
	///	<summary>
	///	Homebrew entries shared with the current user, loaded once per request.
	///	</summary>
	public class ShareService
	{
		private static readonly IReadOnlySet<Guid> None = new HashSet<Guid>();
		private readonly RealmForgeDbContext _context;
		private readonly Dictionary<string, IReadOnlySet<Guid>> _byUser = new();

		public ShareService(RealmForgeDbContext context)
		{
			_context = context;
		}

		public async Task<IReadOnlySet<Guid>> SharedWithAsync(ClaimsPrincipal user)
		{
			var userId = user.Identity?.IsAuthenticated == true ? ContentAccess.GetUserId(user) : null;
			if (userId is null)
			{
				return None;
			}
			if (!_byUser.TryGetValue(userId, out var shared))
			{
				shared = (await _context.ContentShares.AsNoTracking().Where(s => s.UserId == userId).Select(s => s.EntityId).ToListAsync()).ToHashSet();
				_byUser[userId] = shared;
			}
			return shared;
		}
	}
}
