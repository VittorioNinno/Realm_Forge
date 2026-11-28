using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Security;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;

namespace RealmForge.Api.Campaigns
{
	///	<summary>
	///	The table screen: a second window of a master's virtual tabletop, on a monitor (or a touch screen) the players sit
	///	round. It sees the table as the players do (X-Rf-Screen: table): nothing hidden, the party's characters as its own.
	///	When a player acts on it (X-Rf-Act-As: their id) the request is theirs: their rights and limits (their turn, their
	///	moves), their name on the rolls, their achievements. Only a master or co-master of the campaign may ask for it, only
	///	for a player of that campaign, and only on the table (maps, rolls, encounters, treasure).
	///	</summary>
	public static partial class TableScreen
	{
		public const string ScreenHeader = "X-Rf-Screen";
		public const string ActAsHeader = "X-Rf-Act-As";

		private static readonly AsyncLocal<HashSet<string>?> party = new();
		private static readonly HashSet<string> Acting = ["maps", "rolls", "encounters", "treasure"];

		[GeneratedRegex(@"^/api/campaigns/(?<id>[0-9a-fA-F-]{36})(?:/(?<part>[a-z-]+))?", RegexOptions.IgnoreCase)]
		private static partial Regex CampaignRoute();

		///	<summary>The players of the campaign, when the request is the table screen looking at the table (null otherwise).</summary>
		public static HashSet<string>? Party => party.Value;

		public static async Task Middleware(HttpContext http, Func<Task> next)
		{
			if (http.Request.Headers[ScreenHeader].ToString() != "table" || http.User.Identity?.IsAuthenticated != true
				|| CampaignRoute().Match(http.Request.Path.Value ?? string.Empty) is not { Success: true } route
				|| !Guid.TryParse(route.Groups["id"].Value, out var campaignId))
			{
				await next();
				return;
			}
			var context = http.RequestServices.GetRequiredService<RealmForgeDbContext>();
			var me = ContentAccess.GetUserId(http.User);
			var members = await context.CampaignMembers.AsNoTracking().Where(m => m.CampaignId == campaignId)
				.Select(m => new { m.UserId, m.Role }).ToListAsync(http.RequestAborted);
			if (members.FirstOrDefault(m => m.UserId == me) is not { } mine || !CampaignRules.RunsTheTable(mine.Role))
			{
				http.Response.StatusCode = StatusCodes.Status403Forbidden;
				return;
			}
			var players = members.Where(m => m.Role == CampaignRole.Player).Select(m => m.UserId).ToHashSet();
			var actAs = http.Request.Headers[ActAsHeader].ToString();
			if (actAs.Length > 0)
			{
				if (!players.Contains(actAs) || !Acting.Contains(route.Groups["part"].Value.ToLowerInvariant()))
				{
					http.Response.StatusCode = StatusCodes.Status403Forbidden;
					return;
				}
				//	From here on the request is the player's
				var identity = new ClaimsIdentity(
					http.User.Claims.Where(c => c.Type is not (ClaimTypes.NameIdentifier or "sub")).Append(new Claim(ClaimTypes.NameIdentifier, actAs)),
					http.User.Identity.AuthenticationType ?? "TableScreen");
				http.User = new ClaimsPrincipal(identity);
				await next();
				return;
			}
			party.Value = players;
			try
			{
				await next();
			}
			finally
			{
				party.Value = null;
			}
		}
	}
}
