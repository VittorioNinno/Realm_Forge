using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	The editor model of an NPC: read from its sheet in both languages (to edit it), copied into a private NPC of the
	///	account ("Clona nei miei PNG"), or filled at random from a base NPC ("Genera casuale").
	///	</summary>
	public static class NpcModels
	{
		public static async Task<SaveMonsterDto?> LoadAsync(MonsterDataService monsters, Guid id)
		{
			var it = monsters.GetMonsterAsync(id, LanguageCode.It);
			var en = monsters.GetMonsterAsync(id, LanguageCode.En);
			await Task.WhenAll(it, en);
			var source = (await it) ?? (await en);
			if (source is null)
			{
				return null;
			}

			//	A translation that is missing stays empty (not filled with the other language)
			var texts = new[] { await it, await en }
				.Where(d => d is not null && d.Text.Language is LanguageCode.It or LanguageCode.En)
				.Select(d => d!.Text)
				.GroupBy(t => t.Language)
				.Select(g => g.First())
				.ToList();
			return new SaveMonsterDto
			{
				Ruleset = source.Ruleset,
				Visibility = source.Visibility,
				Size = source.Size,
				Type = source.Type,
				ArmorClass = source.ArmorClass,
				HitPoints = source.HitPoints,
				HitDice = source.HitDice,
				Speed = source.Speed,
				Abilities = source.Abilities.ToList(),
				ChallengeRating = source.ChallengeRating,
				Xp = source.Xp,
				ProficiencyBonus = source.ProficiencyBonus,
				PassivePerception = source.PassivePerception,
				VariantOfId = source.VariantOfId,
				IsNpc = true,
				Archetype = source.Archetype,
				Attitude = source.Attitude,
				Portrait = source.Portrait,
				Translations = texts
			};
		}

		//	A private copy linked to the original; the secrets of someone else are never copied (the API does not send them)
		public static async Task<SaveMonsterDto?> CloneAsync(MonsterDataService monsters, Guid id)
		{
			var model = await LoadAsync(monsters, id);
			if (model is null)
			{
				return null;
			}
			//	Built on the same statblock: a community NPC copied keeps the monster it was made from
			model.VariantOfId = model.VariantOfId is { } statblock && await IsHomebrewNpcAsync(monsters, id) ? statblock : id;
			model.Visibility = ContentVisibility.Private;
			foreach (var text in model.Translations)
			{
				text.Alias = null;
			}
			return model;
		}

		private static async Task<bool> IsHomebrewNpcAsync(MonsterDataService monsters, Guid id)
		{
			var detail = await monsters.GetMonsterAsync(id, LanguageCode.It);
			return detail is { IsNpc: true, IsOfficialSRD: false };
		}

		//	A base NPC of the archetype with a random name, ancestry, role and hook
		public static async Task<SaveMonsterDto?> RandomAsync(MonsterDataService monsters, IReadOnlyList<MonsterResponseDto> bases, NpcArchetype? archetype)
		{
			var pool = bases.Where(m => m.IsNpc && m.IsOfficialSRD && (archetype is null || m.Archetype == archetype)).ToList();
			if (pool.Count == 0)
			{
				pool = bases.Where(m => m.IsNpc && m.IsOfficialSRD).ToList();
			}
			if (pool.Count == 0)
			{
				return null;
			}
			var basis = pool[Random.Shared.Next(pool.Count)];
			var model = await CloneAsync(monsters, basis.Id);
			if (model is null)
			{
				return null;
			}
			var idea = NpcGenerator.For(archetype ?? basis.Archetype ?? NpcArchetype.Merchant);
			model.Archetype = archetype ?? basis.Archetype;
			model.Attitude = NpcGenerator.Attitude();
			foreach (var language in new[] { LanguageCode.It, LanguageCode.En })
			{
				var text = model.Translations.FirstOrDefault(t => t.Language == language);
				if (text is null)
				{
					text = new MonsterTextDto { Language = language };
					model.Translations.Add(text);
				}
				var it = language == LanguageCode.It;
				text.Name = idea.Name;
				text.Ancestry = it ? idea.AncestryIt : idea.AncestryEn;
				text.Role = it ? idea.RoleIt : idea.RoleEn;
				text.Personality = it ? idea.HookIt : idea.HookEn;
			}
			return model;
		}
	}
}
