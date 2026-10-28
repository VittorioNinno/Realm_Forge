using System.Text.Json;
using RealmForge.Client.Localization;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	Spells changed from the sheet, as the rules allow: the long rest and the level up open the changes of each class
	///	(SpellChangeRules), the wizard writes spells in the spellbook (free ones of its levels, copied ones for gold), and
	///	"free correction" skips the limits when the game master agrees. Saving goes through the normal character update.
	///	</summary>
	public partial class CharacterSheet
	{
		private SpellcastingInfo? bookSource;
		private List<Guid> draftCantrips = new();
		private List<Guid> draftSpells = new();
		private List<Guid> draftBook = new();
		private List<Guid> draftCopied = new();
		private List<Guid> originalCantrips = new();
		private List<Guid> originalSpells = new();
		private List<Guid> originalBook = new();
		private bool bookFree;
		private bool bookSaving;
		private bool bookOnSpellbook;
		private string bookSearch = string.Empty;
		private string? bookError;

		// ===== Changes the rules open =====

		private IEnumerable<SpellChangeGrant> GrantsOf(Guid classId) => Sheet.SpellChanges.Where(g => g.ClassId == classId && g.Remaining > 0);

		//	After a long rest: the changes of each class replace the ones of the previous rest
		private void GrantLongRestChanges()
		{
			if (computed is null)
			{
				return;
			}
			Sheet.SpellChanges.RemoveAll(g => g.FromLongRest);
			foreach (var source in computed.Spellcasting.Where(s => s.Class is not null))
			{
				var rule = SpellChangeRules.For(Ruleset, source.Class!);
				if (rule.LongRest is { } kind)
				{
					Sheet.SpellChanges.Add(new SpellChangeGrant { ClassId = source.Class!.Class.Id, Kind = kind, Remaining = 1, FromLongRest = true });
				}
				if (rule.LongRestCantrip)
				{
					Sheet.SpellChanges.Add(new SpellChangeGrant { ClassId = source.Class!.Class.Id, Kind = SpellChangeKind.Cantrip, Remaining = 1, FromLongRest = true });
				}
			}
		}

		//	A class level the sheet has not seen yet: the replacements of that level (one spell, one cantrip)
		private void TrackLevelUps()
		{
			if (computed is null || character is null || ReadOnly)
			{
				return;
			}
			var first = Sheet.ClassLevelsSeen.Count == 0;
			var changed = false;
			foreach (var info in computed.Classes)
			{
				var key = info.Class.Id.ToString("N");
				var seen = Sheet.ClassLevelsSeen.TryGetValue(key, out var value) ? value : (int?)null;
				if (seen == info.Level)
				{
					continue;
				}
				changed = true;
				Sheet.ClassLevelsSeen[key] = info.Level;
				if (first || seen is null || info.Level <= seen)
				{
					continue;
				}
				var gained = info.Level - seen.Value;
				var rule = SpellChangeRules.For(Ruleset, info);
				if (rule.LevelUpSpell)
				{
					AddGrant(info.Class.Id, SpellChangeKind.Spell, gained);
				}
				if (rule.LevelUpCantrip)
				{
					AddGrant(info.Class.Id, SpellChangeKind.Cantrip, gained);
				}
			}
			if (changed)
			{
				Changed();
			}
		}

		private void AddGrant(Guid classId, SpellChangeKind kind, int count)
		{
			if (Sheet.SpellChanges.FirstOrDefault(g => g.ClassId == classId && g.Kind == kind && !g.FromLongRest) is { } grant)
			{
				grant.Remaining += count;
			}
			else
			{
				Sheet.SpellChanges.Add(new SpellChangeGrant { ClassId = classId, Kind = kind, Remaining = count });
			}
		}

		// ===== The editor =====

		private bool IsWizardBook(SpellcastingInfo source) => source.Class is { } info && SpellChangeRules.For(Ruleset, info).Spellbook;

		private CharacterClassBuild? BuildOf(SpellcastingInfo source) =>
			source.Class is { } info ? character?.Build.Classes.FirstOrDefault(e => e.ClassId == info.Class.Id) : null;

		private void OpenBook(SpellcastingInfo source)
		{
			if (BuildOf(source) is not { } entry)
			{
				return;
			}
			bookSource = source;
			originalCantrips = entry.Cantrips.ToList();
			originalSpells = entry.Spells.ToList();
			draftCantrips = entry.Cantrips.ToList();
			draftSpells = entry.Spells.ToList();

			//	A wizard without a book yet (created before it existed): the book starts with the prepared spells
			originalBook = entry.Spellbook.Count > 0 ? entry.Spellbook.ToList() : entry.Spells.ToList();
			draftBook = originalBook.ToList();
			draftCopied = entry.SpellbookCopied.ToList();
			bookFree = false;
			bookOnSpellbook = IsWizardBook(source) && LearnedLeft > 0;
			bookSearch = string.Empty;
			bookError = null;
		}

		private void CloseBook() => bookSource = null;

		private int CantripSwapsLeft => bookSource?.Class is { } info ? GrantsOf(info.Class.Id).Where(g => g.Kind == SpellChangeKind.Cantrip).Sum(g => g.Remaining) : 0;

		private int SpellSwapsLeft => bookSource?.Class is { } info ? GrantsOf(info.Class.Id).Where(g => g.Kind == SpellChangeKind.Spell).Sum(g => g.Remaining) : 0;

		private bool AllChangesOpen => bookFree || (bookSource?.Class is { } info && GrantsOf(info.Class.Id).Any(g => g.Kind == SpellChangeKind.All));

		private int RemovedCantrips => originalCantrips.Count(id => !draftCantrips.Contains(id));

		private int RemovedSpells => originalSpells.Count(id => !draftSpells.Contains(id));

		private int LearnedLeft => bookSource?.Class is { } info
			? SpellChangeRules.FreeSpellbookSpells(info.Level) - draftBook.Count(id => !draftCopied.Contains(id))
			: 0;

		private int CopyCost => draftBook.Where(id => draftCopied.Contains(id) && !originalBook.Contains(id))
			.Sum(id => SpellChangeRules.CopyCostGold(context?.Spells.FirstOrDefault(s => s.Id == id)?.Level ?? 1));

		private bool CanRemoveCantrip(Guid id) => !originalCantrips.Contains(id) || bookFree || RemovedCantrips < CantripSwapsLeft;

		private bool CanRemoveSpell(Guid id) => !originalSpells.Contains(id) || AllChangesOpen || RemovedSpells < SpellSwapsLeft;

		private void ToggleDraftCantrip(Guid id)
		{
			if (draftCantrips.Contains(id))
			{
				if (CanRemoveCantrip(id))
				{
					draftCantrips.Remove(id);
				}
			}
			else if (draftCantrips.Count < (bookSource?.Cantrips ?? 0))
			{
				draftCantrips.Add(id);
			}
		}

		private void ToggleDraftSpell(Guid id)
		{
			if (draftSpells.Contains(id))
			{
				if (CanRemoveSpell(id))
				{
					draftSpells.Remove(id);
				}
			}
			else if (draftSpells.Count < (bookSource?.Spells ?? 0))
			{
				draftSpells.Add(id);
			}
		}

		//	A spell written in the book: free while the levels allow it, copied (gold) after that
		private void AddToBook(Guid id)
		{
			if (draftBook.Contains(id))
			{
				return;
			}
			draftBook.Add(id);
			if (LearnedLeft < 0)
			{
				draftCopied.Add(id);
			}
		}

		private void RemoveFromBook(Guid id)
		{
			if (!originalBook.Contains(id) || bookFree)
			{
				draftBook.Remove(id);
				draftCopied.Remove(id);
				draftSpells.Remove(id);
			}
		}

		private IEnumerable<ContextSpell> BookOptions(int minLevel, int maxLevel)
		{
			if (bookSource is null || context is null)
			{
				return Enumerable.Empty<ContextSpell>();
			}
			var list = bookSource.SpellList;
			return context.Spells
				.Where(s => s.Level >= minLevel && s.Level <= maxLevel && (list is null || s.Classes.Contains(list.Value)))
				.Where(s => string.IsNullOrWhiteSpace(bookSearch) || s.Name.Contains(bookSearch.Trim(), StringComparison.OrdinalIgnoreCase))
				.OrderBy(s => s.Level)
				.ThenBy(s => s.Name);
		}

		private ContextSpell? SpellById(Guid id) => context?.Spells.FirstOrDefault(s => s.Id == id);

		private async Task SaveBookAsync()
		{
			if (bookSource?.Class is not { } info || character is null || ReadOnly || BuildOf(bookSource) is null)
			{
				return;
			}
			var wizard = IsWizardBook(bookSource);
			var cost = wizard ? CopyCost : 0;
			if (cost > 0 && !bookFree && Sheet.Coins.Gp < cost)
			{
				bookError = UiText.CopyNotEnoughGold(cost, Lang);
				return;
			}

			bookSaving = true;
			bookError = null;
			var build = JsonSerializer.Deserialize<CharacterBuild>(JsonSerializer.Serialize(character.Build))!;
			var entry = build.Classes.First(e => e.ClassId == info.Class.Id);
			entry.Cantrips = draftCantrips.ToList();
			entry.Spells = draftSpells.ToList();
			if (wizard)
			{
				entry.Spellbook = draftBook.ToList();
				entry.SpellbookCopied = draftCopied.Where(draftBook.Contains).ToList();
			}

			var dto = new SaveCharacterDto
			{
				Name = character.Name,
				Ruleset = character.Ruleset,
				SpeciesId = character.SpeciesId,
				SubspeciesId = character.SubspeciesId,
				BackgroundId = character.BackgroundId,
				Language = Lang,
				Build = build,
				Advancement = Sheet.Advancement
			};
			var (saved, error) = await Characters.SaveCharacterAsync(character.Id, dto);
			bookSaving = false;
			if (saved is null)
			{
				bookError = error ?? UiText.ErrSave(Lang);
				return;
			}

			//	The play state stays the local one (it may have changes still being saved)
			var removedCantrips = RemovedCantrips;
			var removedSpells = RemovedSpells;
			character = saved with { Sheet = character.Sheet };
			if (!bookFree)
			{
				Consume(info.Class.Id, SpellChangeKind.Cantrip, removedCantrips);
				if (removedSpells > 0)
				{
					Sheet.SpellChanges.RemoveAll(g => g.ClassId == info.Class.Id && g.Kind == SpellChangeKind.All);
					Consume(info.Class.Id, SpellChangeKind.Spell, removedSpells);
				}
				Sheet.Coins.Gp -= cost;
			}
			if (Sheet.Concentration is { } focus && !draftCantrips.Contains(focus) && !draftSpells.Contains(focus)
				&& originalSpells.Concat(originalCantrips).Contains(focus))
			{
				Sheet.Concentration = null;
			}
			bookSource = null;
			Changed();
		}

		private void Consume(Guid classId, SpellChangeKind kind, int count)
		{
			foreach (var grant in Sheet.SpellChanges.Where(g => g.ClassId == classId && g.Kind == kind && g.Remaining > 0))
			{
				var used = Math.Min(count, grant.Remaining);
				grant.Remaining -= used;
				count -= used;
			}
			Sheet.SpellChanges.RemoveAll(g => g.Remaining <= 0);
		}

		private string ChangesText(SpellcastingInfo source)
		{
			if (source.Class is not { } info)
			{
				return string.Empty;
			}
			var grants = GrantsOf(info.Class.Id).ToList();
			var parts = new List<string>();
			if (grants.Any(g => g.Kind == SpellChangeKind.All))
			{
				parts.Add(UiText.ChangesAll(Lang));
			}
			if (grants.Where(g => g.Kind == SpellChangeKind.Spell).Sum(g => g.Remaining) is > 0 and var spells)
			{
				parts.Add(UiText.ChangesSpells(spells, Lang));
			}
			if (grants.Where(g => g.Kind == SpellChangeKind.Cantrip).Sum(g => g.Remaining) is > 0 and var cantrips)
			{
				parts.Add(UiText.ChangesCantrips(cantrips, Lang));
			}
			return parts.Count == 0 ? UiText.ChangesNone(Lang) : string.Join(" · ", parts);
		}
	}
}
