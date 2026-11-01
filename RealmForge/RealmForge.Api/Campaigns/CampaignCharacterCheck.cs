using Microsoft.EntityFrameworkCore;
using RealmForge.Api.Controllers;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Campaigns
{
	///	<summary>
	///	Whether a character can sit at a campaign's table: the edition of the campaign, and every Homebrew piece it uses
	///	(species, subspecies, background, classes, subclasses, feats, spells, items) must be available to the table:
	///	public, or shared with the campaign and approved (a subclass or lineage also through its shared class or species).
	///	</summary>
	public class CampaignCharacterCheck
	{
		private readonly RealmForgeDbContext _context;
		private readonly HomebrewLookup _homebrew;

		public CampaignCharacterCheck(RealmForgeDbContext context, HomebrewLookup homebrew)
		{
			_context = context;
			_homebrew = homebrew;
		}

		public async Task<CampaignCharacterCheckDto> CheckAsync(Campaign campaign, Character character, LanguageCode lang)
		{
			var issues = new List<CampaignCheckIssueDto>();
			if (campaign.Ruleset is { } ruleset && character.Ruleset != ruleset)
			{
				issues.Add(new CampaignCheckIssueDto(CampaignCheckIssue.Edition, null, null, character.Ruleset));
			}

			var used = ContentOf(character);
			var entries = await _homebrew.FindAsync(used, lang);
			var approved = (await _context.CampaignContents.AsNoTracking()
				.Where(c => c.CampaignId == campaign.Id && c.Status == CampaignContentStatus.Approved)
				.Select(c => c.EntityId)
				.ToListAsync()).ToHashSet();

			bool Available(HomebrewEntry entry) =>
				entry.IsBase
				|| entry.Visibility == ContentVisibility.Public
				|| approved.Contains(entry.Id)
				|| (entry.ParentId is { } parent && approved.Contains(parent) && entries.TryGetValue(parent, out var p) && p.AuthorId == entry.AuthorId);

			foreach (var entry in entries.Values.Where(e => !Available(e)).OrderBy(e => e.Kind).ThenBy(e => e.Name))
			{
				var mine = entry.AuthorId == character.OwnerId;
				issues.Add(new CampaignCheckIssueDto(mine ? CampaignCheckIssue.HomebrewNotShared : CampaignCheckIssue.HomebrewUnavailable,
					entry.Kind, entry.Name, null, entry.Id));
			}

			//	Homebrew from another edition (it would not work with the campaign's rules; rule modules hold for both)
			if (campaign.Ruleset is { } edition)
			{
				foreach (var entry in entries.Values.Where(e => !e.IsBase && e.Kind != "module" && e.Ruleset != edition && Available(e)))
				{
					issues.Add(new CampaignCheckIssueDto(CampaignCheckIssue.HomebrewEdition, entry.Kind, entry.Name, entry.Ruleset, entry.Id));
				}
			}

			return new CampaignCharacterCheckDto(issues.Count == 0, issues);
		}

		///	<summary>
		///	Every compendium entry the character uses.
		///	</summary>
		public static HashSet<Guid> ContentOf(Character character)
		{
			var build = CharactersController.ReadBuild(character.Build);
			var sheet = CharactersController.ReadSheet(character.Sheet);
			var ids = new HashSet<Guid> { character.SpeciesId, character.BackgroundId, character.ClassId };
			if (character.SubspeciesId is { } sub)
			{
				ids.Add(sub);
			}

			void Add(Guid? id)
			{
				if (id is { } value && value != Guid.Empty)
				{
					ids.Add(value);
				}
			}
			void AddAll(IEnumerable<Guid> list)
			{
				foreach (var id in list)
				{
					Add(id);
				}
			}
			void AddChoice(FeatChoice? choice)
			{
				if (choice is not null)
				{
					AddAll(choice.Cantrips);
					AddAll(choice.Spells);
				}
			}

			Add(build.SpeciesFeatId);
			AddChoice(build.SpeciesFeat);
			AddChoice(build.OriginFeat);
			AddAll(build.SpeciesCantrips);
			AddAll(build.ModuleIds);
			foreach (var entry in build.Classes)
			{
				Add(entry.ClassId);
				Add(entry.SubclassId);
				Add(entry.FightingStyleFeatId);
				AddAll(entry.Cantrips);
				AddAll(entry.Spells);
				AddAll(entry.Spellbook);
				AddAll(entry.StyleCantrips);
				AddAll(entry.SubclassCantrips);
				AddAll(entry.WeaponMasteries);
			}
			foreach (var level in build.Levels)
			{
				Add(level.ClassId);
				Add(level.FeatId);
				AddChoice(level.Feat);
			}
			foreach (var item in sheet.Inventory)
			{
				Add(item.EquipmentId);
			}
			return ids;
		}
	}
}
