using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RealmForge.Client.Localization;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	Play helpers of the sheet: experience and level, slots used one at a time, conditions with the ones they
	///	imply, coins, the inventory split between worn and carried items, portrait and personal details.
	///	</summary>
	public partial class CharacterSheet
	{
		//	Experience needed for each level (same in both editions)
		private static readonly int[] ExperienceTable =
		{
			0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 195000, 225000, 265000, 305000, 355000
		};

		//	Conditions that bring others with them (2014 and 2024 rules glossaries)
		private static readonly Dictionary<string, string[]> ImpliedConditions = new()
		{
			["paralyzed"] = new[] { "incapacitated" },
			["petrified"] = new[] { "incapacitated" },
			["stunned"] = new[] { "incapacitated" },
			["unconscious"] = new[] { "incapacitated", "prone" }
		};

		private Guid? spellDetailId;
		private string? openTrait;
		private int xpAmount;
		private string? portraitError;

		// ===== Experience =====

		private int Level => computed?.Level ?? 1;

		private int NextLevelExperience => Level >= 20 ? ExperienceTable[19] : ExperienceTable[Level];

		private int ExperiencePercent
		{
			get
			{
				if (Level >= 20)
				{
					return 100;
				}
				var start = ExperienceTable[Level - 1];
				var span = Math.Max(1, NextLevelExperience - start);
				return Math.Clamp((Sheet.Experience - start) * 100 / span, 0, 100);
			}
		}

		private bool ReadyToLevelUp => Sheet.Advancement == AdvancementType.Experience && Level < 20 && Sheet.Experience >= NextLevelExperience;

		private void SetAdvancement(AdvancementType type)
		{
			Sheet.Advancement = type;
			Changed();
		}

		private void AddExperience()
		{
			Sheet.Experience = Math.Clamp(Sheet.Experience + xpAmount, 0, 10_000_000);
			xpAmount = 0;
			Changed();
		}

		// ===== Spell slots: "use" spends one, a dot gives it back =====

		private void UseSlot(int level, int total)
		{
			if (SpentSlots(level) < total)
			{
				ToggleSlot(level, SpentSlots(level));
			}
		}

		private void UsePactSlot(int total)
		{
			if (Sheet.SpentPactSlots < total)
			{
				Sheet.SpentPactSlots++;
				Changed();
			}
		}

		// ===== Conditions =====

		private IEnumerable<string> ImpliedBy(string key) =>
			Sheet.Conditions.Where(c => ImpliedConditions.TryGetValue(c, out var implied) && implied.Contains(key));

		private bool IsImplied(string key) => !Sheet.Conditions.Contains(key) && ImpliedBy(key).Any();

		private void ClickCondition(string key)
		{
			if (IsImplied(key))
			{
				return;
			}
			ToggleCondition(key);
		}

		private void ChangeExhaustion(int delta)
		{
			Sheet.Exhaustion = Math.Clamp(Sheet.Exhaustion + delta, 0, ExhaustionMax);
			Changed();
		}

		// ===== Coins =====

		private void AddCoin(CoinType type, int delta) => SetCoin(type, Math.Max(0, Coin(type) + delta).ToString());

		// ===== Inventory =====

		private bool IsWearable(InventoryItem item) => ItemOf(item) is { } info && (info.ArmorCategory is not null || info.Category == EquipmentCategory.Weapon);

		//	Worn: one body armor, one shield; a two-handed weapon and a shield do not go together
		private void Equip(InventoryItem item)
		{
			var info = ItemOf(item);
			if (!item.Equipped && info is not null)
			{
				var twoHanded = info.WeaponProperties.Contains(WeaponProperty.TwoHanded);
				var shield = info.ArmorCategory == ArmorCategory.Shield;
				foreach (var other in Sheet.Inventory.Where(i => i != item && i.Equipped))
				{
					var o = ItemOf(other);
					if (o is null)
					{
						continue;
					}
					if ((twoHanded && o.ArmorCategory == ArmorCategory.Shield) || (shield && o.WeaponProperties.Contains(WeaponProperty.TwoHanded)))
					{
						other.Equipped = false;
					}
				}
			}
			ToggleEquipped(item);
		}

		private void ChangeQuantity(InventoryItem item, int delta)
		{
			item.Quantity = Math.Clamp(item.Quantity + delta, 0, 99999);
			Changed();
		}

		// ===== Portrait and personal details =====

		private async Task UploadPortraitAsync(InputFileChangeEventArgs e)
		{
			portraitError = null;
			try
			{
				//	Resized in the browser to a small square-ish JPEG before it is read
				var image = await e.File.RequestImageFileAsync("image/jpeg", 320, 320);
				await using var stream = image.OpenReadStream(maxAllowedSize: 1_000_000);
				using var memory = new MemoryStream();
				await stream.CopyToAsync(memory);
				var url = $"data:image/jpeg;base64,{Convert.ToBase64String(memory.ToArray())}";
				if (url.Length > 400_000)
				{
					portraitError = UiText.PortraitTooLarge(Lang);
					return;
				}
				Sheet.Portrait = url;
				Changed();
			}
			catch (Exception)
			{
				portraitError = UiText.PortraitTooLarge(Lang);
			}
		}

		private void RemovePortrait()
		{
			Sheet.Portrait = null;
			Changed();
		}

		private void SetBio(Action<string?> set, ChangeEventArgs e) => SetText(set, e);

		// ===== Species traits and senses =====

		private IEnumerable<TraitResponseDto> SpeciesTraits => speciesDetail is null
			? Enumerable.Empty<TraitResponseDto>()
			: speciesDetail.BaseTraits
				.Concat(speciesDetail.Subspecies.FirstOrDefault(s => s.Id == character!.SubspeciesId)?.Traits ?? new List<TraitResponseDto>())
				.Where(t => t.RequiredLevel <= Level);

		private void ToggleTrait(string name) => openTrait = openTrait == name ? null : name;

		//	Passive scores of the three senses-related skills
		private int Passive(Skill skill) => 10 + (computed?.SkillBonus(skill) ?? 0);
	}
}
