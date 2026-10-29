using Microsoft.EntityFrameworkCore;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Text;

namespace RealmForge.Api.Security
{
	///	<summary>
	///	Names of accounts as other players see them: the nickname, never the e-mail address (see <see cref="Nicknames"/>).
	///	</summary>
	public static class PublicNames
	{
		public static async Task<Dictionary<string, string>> LoadAsync(RealmForgeDbContext context, IEnumerable<string?> ids)
		{
			var list = ids.OfType<string>().Distinct().ToList();
			if (list.Count == 0)
			{
				return new Dictionary<string, string>();
			}
			var users = await context.Users.AsNoTracking()
				.Where(u => list.Contains(u.Id))
				.Select(u => new { u.Id, u.Nickname, u.Email })
				.ToListAsync();
			return users.ToDictionary(u => u.Id, u => Nicknames.Display(u.Nickname, u.Email));
		}
	}
}
