using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Campaigns;
using RealmForge.Api.Controllers;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Dice;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using AchievementRules = RealmForge.Shared.Dice.Achievements;

namespace RealmForge.Api.Achievements
{
	///	<summary>
	///	The achievements of a person: how far each one has come, the ones reached now (earned on their own, which unlocks
	///	their die), and the ones an administrator gives or takes back. A revoked achievement is not earned again on its own.
	///	</summary>
	public sealed class AchievementService
	{
		//	The measures that need many queries are looked at again at most this often for a person (the quick checks of the
		//	notices); the profile and the administrators always look at everything
		private static readonly TimeSpan SlowEvery = TimeSpan.FromMinutes(5);
		private static readonly ConcurrentDictionary<string, DateTimeOffset> LastSlow = new();

		private static readonly HashSet<AchievementMeasure> FromDice =
		[
			AchievementMeasure.Rolls, AchievementMeasure.NaturalTwenties, AchievementMeasure.NaturalOnes,
			AchievementMeasure.OneThenTwenty, AchievementMeasure.TwoTwentiesInASitting, AchievementMeasure.TwentyAfterMidnight
		];

		private readonly RealmForgeDbContext _context;
		private readonly HomebrewLookup _homebrew;

		public AchievementService(RealmForgeDbContext context, HomebrewLookup homebrew)
		{
			_context = context;
			_homebrew = homebrew;
		}

		///	<summary>How far a person has come on the measures asked for.</summary>
		public async Task<Dictionary<AchievementMeasure, int>> MeasureAsync(string userId, IReadOnlyCollection<AchievementMeasure> wanted)
		{
			var values = new Dictionary<AchievementMeasure, int>();
			if (wanted.Count == 0)
			{
				return values;
			}
			if (wanted.Any(FromDice.Contains))
			{
				var stats = await DiceStatsRules.OfAsync(_context, userId);
				if (_context.Entry(stats).State == EntityState.Added)
				{
					await _context.SaveChangesAsync();
				}
				values[AchievementMeasure.Rolls] = stats.Rolls;
				values[AchievementMeasure.NaturalTwenties] = stats.NaturalTwenties;
				values[AchievementMeasure.NaturalOnes] = stats.NaturalOnes;
				values[AchievementMeasure.OneThenTwenty] = stats.OneThenTwenty ? 1 : 0;
				values[AchievementMeasure.TwoTwentiesInASitting] = stats.TwoTwentiesInASitting ? 1 : 0;
				values[AchievementMeasure.TwentyAfterMidnight] = stats.TwentyAfterMidnight ? 1 : 0;
			}
			if (wanted.Any(m => m is AchievementMeasure.SessionsPlayed or AchievementMeasure.SessionsMastered or AchievementMeasure.PlayedMonths))
			{
				//	The sessions played in a campaign the person was in by then (a day of grace for those who joined on the day)
				var memberships = await _context.CampaignMembers.AsNoTracking().Where(m => m.UserId == userId)
					.Select(m => new { m.CampaignId, m.Role, m.JoinedAt }).ToListAsync();
				var ids = memberships.Select(m => m.CampaignId).ToList();
				var sessions = await _context.CampaignSessions.AsNoTracking()
					.Where(s => ids.Contains(s.CampaignId) && s.Status == CampaignSessionStatus.Played)
					.Select(s => new { s.CampaignId, When = s.ScheduledAt ?? s.UpdatedAt }).ToListAsync();
				var played = sessions
					.Select(s => (Session: s, Member: memberships.First(m => m.CampaignId == s.CampaignId)))
					.Where(p => p.Session.When >= p.Member.JoinedAt.AddDays(-1))
					.ToList();
				var zone = DiceStatsRules.Zone(await _context.UserDiceStats.AsNoTracking().Where(s => s.UserId == userId).Select(s => s.TimeZone).FirstOrDefaultAsync());
				values[AchievementMeasure.SessionsPlayed] = played.Count;
				values[AchievementMeasure.SessionsMastered] = played.Count(p => p.Member.Role is CampaignRole.Master or CampaignRole.CoMaster);
				values[AchievementMeasure.PlayedMonths] = played
					.Select(p => TimeZoneInfo.ConvertTime(p.Session.When, zone))
					.Select(d => d.Year * 12 + d.Month).Distinct().Count();
			}
			if (wanted.Contains(AchievementMeasure.Homebrew))
			{
				values[AchievementMeasure.Homebrew] = (await _homebrew.ByAuthorAsync(userId, LanguageCode.En)).Count;
			}
			if (wanted.Contains(AchievementMeasure.Maps))
			{
				values[AchievementMeasure.Maps] = await _context.CampaignMaps.CountAsync(m => m.CreatedById == userId);
			}
			if (wanted.Contains(AchievementMeasure.CharacterLevel))
			{
				values[AchievementMeasure.CharacterLevel] = await _context.Characters.Where(c => c.OwnerId == userId)
					.Select(c => (int?)c.Level).MaxAsync() ?? 0;
			}
			if (wanted.Contains(AchievementMeasure.CharacterGold))
			{
				//	The worth of each purse in gold pieces (platinum 10, electrum 1/2, silver 1/10, copper 1/100)
				var sheets = await _context.Characters.AsNoTracking().Where(c => c.OwnerId == userId).Select(c => c.Sheet).ToListAsync();
				values[AchievementMeasure.CharacterGold] = sheets.Count == 0 ? 0 : sheets
					.Select(s => CharactersController.ReadSheet(s).Coins)
					.Max(c => (int)Math.Min(int.MaxValue, c.Pp * 10L + c.Gp + c.Ep / 2L + c.Sp / 10L + c.Cp / 100L));
			}
			return values;
		}

		///	<summary>
		///	Earns what the person has reached (and records as achievements the dice they already had, from the codes of
		///	before). <paramref name="full"/> false looks again at the slow measures only every few minutes.
		///	</summary>
		public async Task<List<UserAchievement>> EvaluateAsync(string userId, bool full = true)
		{
			var rows = await _context.UserAchievements.Where(a => a.UserId == userId).ToListAsync();
			var skins = await _context.UserDiceSkins.Where(s => s.UserId == userId).ToListAsync();
			var now = DateTimeOffset.UtcNow;

			foreach (var skin in skins)
			{
				if (AchievementRules.OfSkin(skin.Skin) is { } had && rows.All(r => r.Key != had.Key))
				{
					var row = new UserAchievement { UserId = userId, Key = had.Key, EarnedAt = skin.UnlockedAt, Seen = true };
					_context.UserAchievements.Add(row);
					rows.Add(row);
				}
			}

			var slow = full || !LastSlow.TryGetValue(userId, out var last) || now - last >= SlowEvery;
			if (slow)
			{
				LastSlow[userId] = now;
			}
			var open = AchievementRules.All.Where(a => rows.All(r => r.Key != a.Key) && (slow || FromDice.Contains(a.Measure))).ToList();
			var values = await MeasureAsync(userId, open.Select(a => a.Measure).Distinct().ToList());
			foreach (var achievement in open)
			{
				if (values.GetValueOrDefault(achievement.Measure) >= achievement.Target)
				{
					var row = new UserAchievement { UserId = userId, Key = achievement.Key, EarnedAt = now };
					_context.UserAchievements.Add(row);
					rows.Add(row);
					if (skins.All(s => s.Skin != achievement.Skin))
					{
						_context.UserDiceSkins.Add(new UserDiceSkin { UserId = userId, Skin = achievement.Skin, UnlockedAt = now });
					}
				}
			}
			if (_context.ChangeTracker.HasChanges())
			{
				try
				{
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateException)
				{
					//	Another request of the same person got there first (two tabs): what it saved is what counts
					_context.ChangeTracker.Clear();
					return await _context.UserAchievements.Where(a => a.UserId == userId).ToListAsync();
				}
			}
			return rows;
		}

		///	<summary>The achievements as the person (or an administrator, <paramref name="all"/>) sees them.</summary>
		public async Task<List<AchievementDto>> ListAsync(string userId, bool all)
		{
			var rows = await EvaluateAsync(userId);
			var visible = AchievementRules.All.Where(a => all || !a.Hidden || rows.Any(r => r.Key == a.Key && r.RevokedAt is null)).ToList();
			var open = visible.Where(a => rows.All(r => r.Key != a.Key || r.RevokedAt is not null)).Select(a => a.Measure).Distinct().ToList();
			var values = await MeasureAsync(userId, open);
			return visible.Select(a =>
			{
				var row = rows.FirstOrDefault(r => r.Key == a.Key);
				var earned = row is { RevokedAt: null };
				return new AchievementDto(a.Key, a.Skin, a.Hidden, earned, earned ? row!.EarnedAt : null, earned && row!.GrantedById is not null,
					row?.RevokedAt is not null, earned ? a.Target : Math.Min(a.Target, values.GetValueOrDefault(a.Measure)), a.Target);
			}).ToList();
		}

		///	<summary>The achievements earned and not told yet.</summary>
		public async Task<List<AchievementDto>> NewsAsync(string userId)
		{
			var rows = await EvaluateAsync(userId, full: false);
			return rows.Where(r => r.RevokedAt is null && !r.Seen)
				.Select(r => AchievementRules.Find(r.Key)).OfType<Achievement>()
				.Select(a => new AchievementDto(a.Key, a.Skin, a.Hidden, true, rows.First(r => r.Key == a.Key).EarnedAt, false, false, a.Target, a.Target))
				.ToList();
		}

		public async Task SeenAsync(string userId, IReadOnlyCollection<string> keys)
		{
			foreach (var row in await _context.UserAchievements.Where(a => a.UserId == userId && keys.Contains(a.Key) && !a.Seen).ToListAsync())
			{
				row.Seen = true;
			}
			await _context.SaveChangesAsync();
		}

		///	<summary>An administrator gives an achievement (and its die); given back if it had been revoked.</summary>
		public async Task GrantAsync(string userId, Achievement achievement, string byId)
		{
			var now = DateTimeOffset.UtcNow;
			var row = await _context.UserAchievements.FirstOrDefaultAsync(a => a.UserId == userId && a.Key == achievement.Key);
			if (row is null)
			{
				_context.UserAchievements.Add(new UserAchievement { UserId = userId, Key = achievement.Key, EarnedAt = now, GrantedById = byId });
			}
			else if (row.RevokedAt is not null)
			{
				row.RevokedAt = null;
				row.RevokedById = null;
				row.GrantedById = byId;
				row.EarnedAt = now;
				row.Seen = false;
			}
			if (!await _context.UserDiceSkins.AnyAsync(s => s.UserId == userId && s.Skin == achievement.Skin))
			{
				_context.UserDiceSkins.Add(new UserDiceSkin { UserId = userId, Skin = achievement.Skin, UnlockedAt = now });
			}
			await _context.SaveChangesAsync();
		}

		///	<summary>An administrator takes an achievement (and its die) back; it is not earned again on its own.</summary>
		public async Task RevokeAsync(string userId, Achievement achievement, string byId)
		{
			var now = DateTimeOffset.UtcNow;
			var row = await _context.UserAchievements.FirstOrDefaultAsync(a => a.UserId == userId && a.Key == achievement.Key);
			if (row is null)
			{
				_context.UserAchievements.Add(new UserAchievement { UserId = userId, Key = achievement.Key, EarnedAt = now, RevokedAt = now, RevokedById = byId, Seen = true });
			}
			else
			{
				row.RevokedAt = now;
				row.RevokedById = byId;
				row.Seen = true;
			}
			_context.UserDiceSkins.RemoveRange(await _context.UserDiceSkins.Where(s => s.UserId == userId && s.Skin == achievement.Skin).ToListAsync());
			await _context.SaveChangesAsync();
		}

		///	<summary>The person's own clock, for "after midnight" (an IANA name such as Europe/Rome).</summary>
		public async Task<bool> SetTimeZoneAsync(string userId, string? timeZone)
		{
			if (timeZone is not { Length: > 0 and <= 64 } || !TimeZoneInfo.TryFindSystemTimeZoneById(timeZone, out _))
			{
				return false;
			}
			var stats = await DiceStatsRules.OfAsync(_context, userId);
			if (stats.TimeZone != timeZone)
			{
				stats.TimeZone = timeZone;
				await _context.SaveChangesAsync();
			}
			else if (_context.Entry(stats).State == EntityState.Added)
			{
				await _context.SaveChangesAsync();
			}
			return true;
		}
	}
}
