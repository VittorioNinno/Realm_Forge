using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Common;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Security
{
	///	<summary>
	///	What deleting an account does to the data of that person: their characters, bin, shares and private notes are
	///	deleted; their Homebrew is deleted when nobody else can use it (private, not shared with people or campaigns),
	///	otherwise it stays without an author so the characters of the others keep working; in the campaigns they
	///	leave, the role of master passes to the member who has been there longest (co-masters first), and a campaign
	///	left empty is deleted. The account itself is deleted afterwards by the caller (Identity).
	///	</summary>
	public class AccountDeletion
	{
		private readonly RealmForgeDbContext _context;

		public AccountDeletion(RealmForgeDbContext context)
		{
			_context = context;
		}

		public sealed record Outcome(int Characters, int HomebrewDeleted, int HomebrewKept, int CampaignsDeleted, int CampaignsHandedOver);

		public async Task<Outcome> RemoveDataAsync(string userId)
		{
			// ----- Characters (their campaign seats and shares go with them) -----
			var characters = await _context.Characters.Where(c => c.OwnerId == userId).ToListAsync();
			_context.Characters.RemoveRange(characters);
			_context.CharacterShares.RemoveRange(await _context.CharacterShares.Where(s => s.UserId == userId).ToListAsync());

			// ----- Homebrew -----
			var shared = (await _context.ContentShares.Where(s => s.UserId != userId).Select(s => s.EntityId).ToListAsync()).ToHashSet();
			var inCampaigns = (await _context.CampaignContents.Select(c => c.EntityId).ToListAsync()).ToHashSet();
			var deleted = new HashSet<Guid>();
			var kept = 0;
			async Task Handle<T>(DbSet<T> set) where T : GameEntity
			{
				foreach (var entry in await set.Where(e => e.AuthorId == userId && !e.IsOfficialSRD).ToListAsync())
				{
					if (entry.Visibility == ContentVisibility.Private && !shared.Contains(entry.Id) && !inCampaigns.Contains(entry.Id))
					{
						set.Remove(entry);
						deleted.Add(entry.Id);
					}
					else
					{
						//	Someone else may use it: it stays, without an author (only an administrator manages it)
						entry.AuthorId = null;
						kept++;
					}
				}
			}
			await Handle(_context.Subspecies);
			await Handle(_context.Subclasses);
			await Handle(_context.Species);
			await Handle(_context.Classes);
			await Handle(_context.Backgrounds);
			await Handle(_context.Feats);
			await Handle(_context.Spells);
			await Handle(_context.Equipment);
			await Handle(_context.Monsters);
			await Handle(_context.MagicItems);

			_context.ContentShares.RemoveRange(await _context.ContentShares.Where(s => s.UserId == userId || deleted.Contains(s.EntityId)).ToListAsync());
			_context.CampaignContents.RemoveRange(await _context.CampaignContents.Where(c => deleted.Contains(c.EntityId)).ToListAsync());

			// ----- Campaigns -----
			var campaignsDeleted = 0;
			var handedOver = 0;
			var memberships = await _context.CampaignMembers.Where(m => m.UserId == userId).ToListAsync();
			foreach (var membership in memberships)
			{
				var others = await _context.CampaignMembers.Where(m => m.CampaignId == membership.CampaignId && m.UserId != userId).ToListAsync();
				if (others.Count == 0)
				{
					var campaign = await _context.Campaigns.FindAsync(membership.CampaignId);
					if (campaign is not null)
					{
						_context.Campaigns.Remove(campaign);
						campaignsDeleted++;
					}
					continue;
				}
				if (membership.Role == CampaignRole.Master && others.All(m => m.Role != CampaignRole.Master))
				{
					var heir = others.OrderBy(m => m.Role == CampaignRole.CoMaster ? 0 : 1).ThenBy(m => m.JoinedAt).First();
					heir.Role = CampaignRole.Master;
					handedOver++;
				}
				_context.CampaignMembers.Remove(membership);
			}
			_context.CampaignInvites.RemoveRange(await _context.CampaignInvites.Where(i => i.UserId == userId).ToListAsync());
			_context.CampaignNotes.RemoveRange(await _context.CampaignNotes.Where(n => n.AuthorId == userId && n.Kind == CampaignNoteKind.Private).ToListAsync());
			_context.CampaignContents.RemoveRange(await _context.CampaignContents
				.Where(c => c.SharedById == userId && c.Status == CampaignContentStatus.Pending).ToListAsync());

			// ----- Dice logs -----
			//	The hidden rolls (seen only by the masters and the person) go; the others stay in the history of the table,
			//	grey, with the character's name, or "deleted account" instead of the nickname
			_context.CampaignRolls.RemoveRange(await _context.CampaignRolls.Where(r => r.UserId == userId && r.Hidden).ToListAsync());
			foreach (var roll in await _context.CampaignRolls.Where(r => r.UserId == userId).ToListAsync())
			{
				roll.UserId = string.Empty;
				roll.Color = PlayerColors.Removed;
				if (roll.CharacterId is null)
				{
					roll.Roller = string.Empty;
				}
			}
			foreach (var session in await _context.CampaignSessions.Where(s => s.UpdatedById == userId).ToListAsync())
			{
				session.UpdatedById = string.Empty;
			}

			// ----- Bin -----
			_context.TrashEntries.RemoveRange(await _context.TrashEntries.Where(t => t.UserId == userId).ToListAsync());

			await _context.SaveChangesAsync();
			return new Outcome(characters.Count, deleted.Count, kept, campaignsDeleted, handedOver);
		}
	}
}
