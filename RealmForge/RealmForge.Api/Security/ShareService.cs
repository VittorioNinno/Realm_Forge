using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;

namespace RealmForge.Api.Security
{
	///	<summary>
	///	Homebrew entries shared with the current user, loaded once per request: shared with them by the author, added to
	///	their collection, or shared with a campaign they play (approved; pending too for its masters and co-masters).
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
				var direct = await _context.ContentShares.AsNoTracking().Where(s => s.UserId == userId).Select(s => s.EntityId).ToListAsync();

				//	Campaigns: approved entries for every member; the pending ones also for those who review them
				var campaigns = await _context.CampaignContents.AsNoTracking()
					.Where(c => _context.CampaignMembers.Any(m => m.CampaignId == c.CampaignId && m.UserId == userId
						&& (c.Status == CampaignContentStatus.Approved || m.Role == CampaignRole.Master || m.Role == CampaignRole.CoMaster)))
					.Select(c => c.EntityId)
					.ToListAsync();
				shared = direct.Concat(campaigns).ToHashSet();
				_byUser[userId] = shared;
			}
			return shared;
		}
	}
}
