using RealmForge.Client.Localization;
using RealmForge.Shared.Characters;
using RealmForge.Shared.DTOs;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Localization;
using RealmForge.Shared.Pdf;
using RealmForge.Shared.Rules;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	The content of the character PDF in the reader's language: header, vitals, abilities, saves and skills, then
	///	attacks, spells, inventory, features, proficiencies and notes.
	///	</summary>
	public static class CharacterPdfBuilder
	{
		public static CharacterPdfData Build(CharacterDto character, ComputedCharacter c, CharacterContextDto context,
			IReadOnlyList<RuleEntryResponseDto> conditions, IReadOnlyDictionary<Guid, ClassDetailResponseDto> classDetails, LanguageCode lang)
		{
			var ruleset = character.Ruleset;
			var sheet = character.Sheet;
			var maxHp = c.MaxHitPoints;
			var current = Math.Clamp(sheet.CurrentHitPoints ?? maxHp, 0, maxHp);
			string Mod(int value) => CharacterMath.FormatModifier(value);

			var data = new CharacterPdfData
			{
				Name = character.Name,
				Footer = $"{UiText.PdfFooter(lang)} · {UiText.FormatRuleset(ruleset, lang)} · {DateTime.Now:yyyy-MM-dd}"
			};

			data.Subtitle.Add($"{c.Subspecies?.Name ?? c.Species?.Name} · {string.Join(" / ", c.Classes.Select(i => i.Subclass is null ? $"{i.Class.Name} {i.Level}" : $"{i.Class.Name} {i.Level} ({i.Subclass.Name})"))}");
			data.Subtitle.Add($"{c.Background?.Name} · {UiText.AlignmentName(character.Build.Alignment, lang)} · {UiText.FormatSizeSingle(character.Build.Size, lang)} · {UiText.CharacterLevel(c.Level, lang)}");

			data.Vitals.Add((UiText.SheetArmorClassLong(lang), $"{c.ArmorClass}"));
			data.Vitals.Add((UiText.SheetHitPoints(lang), sheet.TemporaryHitPoints > 0 ? $"{current}/{maxHp} +{sheet.TemporaryHitPoints}" : $"{current}/{maxHp}"));
			data.Vitals.Add((UiText.SheetInitiative(lang), Mod(c.Initiative)));
			data.Vitals.Add((UiText.SheetSpeed(lang), UiText.FormatSpeed(c.Speed, lang)));
			data.Vitals.Add((UiText.SheetProficiency(lang), Mod(c.ProficiencyBonus)));
			data.Vitals.Add((UiText.SheetPassivePerception(lang), $"{c.PassivePerception}"));
			data.Vitals.Add((UiText.SheetHitDice(lang), string.Join(" ", c.HitDice.Select(h => $"{h.Count - sheet.HitDiceSpent.GetValueOrDefault(h.Die)}d{h.Die}"))));

			foreach (var ability in CharacterMath.Abilities)
			{
				data.Abilities.Add(new PdfAbility(FeatPrerequisiteFormatter.AbilityName(ability, lang), c.Score(ability), Mod(c.Modifier(ability)),
					$"{UiText.SheetSaveShort(lang)} {Mod(c.SaveBonus(ability))}", c.SaveProficiencies.Contains(ability)));
			}

			// Columns: skills, and the combat summary
			var skills = Enum.GetValues<Skill>().OrderBy(s => GameTerms.SkillName(s, lang))
				.Select(s => new PdfRow(
					$"{GameTerms.SkillName(s, lang)} ({UiText.AbilityShort(GameTerms.SkillAbility(s), lang)}){(c.Expertise.Contains(s) ? " · " + UiText.SheetExpertiseMark(lang) : null)}",
					Mod(c.SkillBonus(s)), c.SkillProficiencies.Contains(s)))
				.ToList();
			data.Columns.Add(new PdfSection(UiText.SheetSkills(lang), skills));

			var status = new List<PdfRow>();
			foreach (var attack in c.Attacks)
			{
				var damage = attack.DamageType is { } type ? $"{attack.Damage} {EquipmentTerms.DamageTypeName(type, lang)}" : attack.Damage;
				status.Add(new PdfRow($"{attack.Item.Name} · {damage}{(attack.VersatileDamage is { } v ? $" ({v})" : null)}", Mod(attack.AttackBonus), attack.Proficient));
			}
			if (status.Count == 0)
			{
				status.Add(new PdfRow(UiText.NoAttacks(lang), Paragraph: true));
			}
			var states = new List<string>();
			states.AddRange(sheet.Conditions.Select(k => conditions.FirstOrDefault(x => x.Key == k)?.Name ?? k));
			if (sheet.Exhaustion > 0)
			{
				states.Add($"{UiText.SheetExhaustion(lang)} {sheet.Exhaustion}");
			}
			if (sheet.Inspiration)
			{
				states.Add(UiText.SheetInspiration(ruleset, lang));
			}
			if (states.Count > 0)
			{
				status.Add(new PdfRow($"{UiText.SheetConditions(lang)}: {string.Join(", ", states)}", Bold: true, Paragraph: true));
			}
			status.Add(new PdfRow($"{UiText.SheetArmorTraining(lang)}: {UiText.ArmorTrainingText(c.ArmorTraining, lang)}", Paragraph: true));
			status.Add(new PdfRow($"{UiText.LabelLanguages(ruleset, lang)}: {string.Join(", ", c.Languages.Select(l => CharacterLanguages.Name(ruleset, l, lang)))}", Paragraph: true));
			foreach (var info in c.Classes.Where(i => i.Starting))
			{
				if (classDetails.GetValueOrDefault(info.Class.Id) is { } detail && !string.IsNullOrWhiteSpace(detail.WeaponProficiencies))
				{
					status.Add(new PdfRow($"{UiText.LabelWeapons(lang)}: {detail.WeaponProficiencies}", Paragraph: true));
				}
			}
			if (!string.IsNullOrWhiteSpace(sheet.OtherProficiencies))
			{
				status.Add(new PdfRow(sheet.OtherProficiencies, Paragraph: true));
			}
			data.Columns.Add(new PdfSection(UiText.SheetAttacks(lang), status));

			// Spells
			var spellRows = new List<PdfRow>();
			var slots = Enumerable.Range(1, 9).Where(l => c.SpellSlots[l - 1] > 0)
				.Select(l => $"{UiText.SlotLevel(l, lang)}: {c.SpellSlots[l - 1] - (l - 1 < sheet.SpentSlots.Count ? sheet.SpentSlots[l - 1] : 0)}/{c.SpellSlots[l - 1]}")
				.ToList();
			if (c.PactSlots > 0)
			{
				slots.Add($"{UiText.SheetPactSlots(c.PactSlotLevel, lang)}: {c.PactSlots - sheet.SpentPactSlots}/{c.PactSlots}");
			}
			if (slots.Count > 0)
			{
				spellRows.Add(new PdfRow($"{UiText.SheetSpellSlots(lang)}: {string.Join(" · ", slots)}", Bold: true, Paragraph: true));
			}
			foreach (var source in c.Spellcasting)
			{
				var name = source.Class?.Class.Name ?? (source.Source == "species" ? UiText.SpellSourceSpecies(ruleset, lang) : source.Source);
				spellRows.Add(new PdfRow($"{name} · {UiText.SheetSpellcasting(source.Ability, source.SaveDc, source.AttackBonus, lang)}", Bold: true, Paragraph: true));
				var spells = source.ChosenCantrips.Concat(source.ChosenSpells)
					.Select(id => context.Spells.FirstOrDefault(s => s.Id == id))
					.Where(s => s is not null)
					.Select(s => s!)
					.GroupBy(s => s.Level)
					.OrderBy(g => g.Key);
				foreach (var group in spells)
				{
					var label = group.Key == 0 ? UiText.LabelCantrips(lang) : GameTerms.SpellLevel(group.Key, lang);
					spellRows.Add(new PdfRow($"{label}: {string.Join(", ", group.Select(s => s.Name).OrderBy(n => n))}", Paragraph: true));
				}
			}
			data.Sections.Add(new PdfSection(UiText.SheetSpells(lang), spellRows));

			// Inventory
			var items = context.Items.ToDictionary(i => i.Id);
			var inventory = sheet.Inventory.Select(i =>
			{
				var name = i.EquipmentId is { } id && items.TryGetValue(id, out var item) ? item.Name : i.Name ?? string.Empty;
				var marks = new[] { i.Equipped ? UiText.SheetEquipped(lang) : null, i.Attuned ? UiText.SheetAttuned(lang) : null }.Where(m => m is not null);
				return new PdfRow(marks.Any() ? $"{name} ({string.Join(", ", marks)})" : name, i.Quantity > 1 ? $"×{i.Quantity}" : null, i.Equipped);
			}).ToList();
			var coins = string.Join("  ", new[] { (sheet.Coins.Pp, CoinType.Pp), (sheet.Coins.Gp, CoinType.Gp), (sheet.Coins.Ep, CoinType.Ep), (sheet.Coins.Sp, CoinType.Sp), (sheet.Coins.Cp, CoinType.Cp) }
				.Where(x => x.Item1 > 0).Select(x => $"{x.Item1} {UiText.CoinName(x.Item2, lang)}"));
			if (coins.Length > 0)
			{
				inventory.Add(new PdfRow($"{UiText.LabelCoins(lang)}: {coins}", Bold: true, Paragraph: true));
			}
			data.Sections.Add(new PdfSection(UiText.TabInventory(lang), inventory));

			// Features: feats, class and subclass features by name, resources
			var features = new List<PdfRow>();
			if (c.Feats.Count > 0)
			{
				features.Add(new PdfRow($"{UiText.SheetFeats(lang)}: {string.Join(", ", c.Feats.Select(f => f.Feat.Name))}", Paragraph: true));
			}
			foreach (var info in c.Classes)
			{
				if (classDetails.GetValueOrDefault(info.Class.Id) is not { } detail)
				{
					continue;
				}
				var names = detail.Features.Where(f => f.Level <= info.Level).OrderBy(f => f.Level).ThenBy(f => f.SortOrder).Select(f => f.Name).Distinct();
				features.Add(new PdfRow($"{info.Class.Name} {info.Level}: {string.Join(", ", names)}", Paragraph: true));
				if (detail.Subclasses.FirstOrDefault(s => s.Id == info.Subclass?.Id) is { } subclass)
				{
					var subNames = subclass.Features.Where(f => f.Level <= info.Level).OrderBy(f => f.Level).Select(f => f.Name).Distinct();
					features.Add(new PdfRow($"{subclass.Name}: {string.Join(", ", subNames)}", Paragraph: true));
				}
			}
			foreach (var resource in sheet.Resources)
			{
				features.Add(new PdfRow(resource.Name, $"{resource.Maximum - resource.Used}/{resource.Maximum}"));
			}
			if (!string.IsNullOrWhiteSpace(sheet.FeatureNotes))
			{
				features.Add(new PdfRow(sheet.FeatureNotes, Paragraph: true));
			}
			data.Sections.Add(new PdfSection(UiText.TabFeatures(lang), features));

			// Personality and notes
			var notes = new List<PdfRow>();
			void Note(string label, string? text)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					notes.Add(new PdfRow(label, Bold: true, Paragraph: true));
					notes.Add(new PdfRow(text, Paragraph: true));
				}
			}
			Note(UiText.LabelPersonalityTraits(lang), sheet.Traits);
			Note(UiText.LabelIdeals(lang), sheet.Ideals);
			Note(UiText.LabelBonds(lang), sheet.Bonds);
			Note(UiText.LabelFlaws(lang), sheet.Flaws);
			Note(UiText.LabelAppearance(lang), sheet.Appearance);
			Note(UiText.LabelBackstory(lang), sheet.Backstory);
			Note(UiText.LabelAllies(lang), sheet.Allies);
			Note(UiText.LabelNotes(lang), sheet.Notes);
			notes.Add(new PdfRow(UiText.LabelAdvancement(lang), UiText.AdvancementName(sheet.Advancement, lang)));
			if (sheet.Advancement == AdvancementType.Experience && sheet.Experience > 0)
			{
				notes.Add(new PdfRow(UiText.SheetExperience(lang), $"{sheet.Experience}"));
			}
			data.Sections.Add(new PdfSection(UiText.TabNotes(lang), notes));

			return data;
		}
	}
}
