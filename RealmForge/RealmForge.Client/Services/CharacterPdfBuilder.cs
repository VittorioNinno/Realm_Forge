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
	///	The content of the character PDF in the reader's language: header (level, origin and classes, background,
	///	alignment, size), vitals, abilities and saves, skills, attacks, spells by source, proficiencies, features,
	///	inventory, and a page for personality and notes.
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
				LevelBadge = UiText.CharacterLevel(c.Level, lang),
				Origin = c.Subspecies?.Name ?? c.Species?.Name ?? string.Empty,
				Classes = string.Join(" / ", c.Classes.Select(i => i.Subclass is null ? $"{i.Class.Name} {i.Level}" : $"{i.Class.Name} {i.Level} ({i.Subclass.Name})")),
				Footer = $"{UiText.PdfFooter(lang)} · {UiText.FormatRuleset(ruleset, lang)} · {DateTime.Now:yyyy-MM-dd}",
				PageFormat = UiText.PdfPage(lang)
			};
			data.Meta.Add(new PdfField(UiText.LabelBackground(lang), c.Background?.Name ?? "—"));
			data.Meta.Add(new PdfField(UiText.LabelAlignment(lang), UiText.AlignmentName(character.Build.Alignment, lang)));
			data.Meta.Add(new PdfField(UiText.LabelSize(lang), UiText.FormatSizeSingle(character.Build.Size, lang)));

			data.Vitals.Add(new PdfField(UiText.SheetArmorClassLong(lang), $"{c.ArmorClass}"));
			data.Vitals.Add(new PdfField(UiText.SheetHitPoints(lang), sheet.TemporaryHitPoints > 0 ? $"{current} / {maxHp} +{sheet.TemporaryHitPoints}" : $"{current} / {maxHp}"));
			data.Vitals.Add(new PdfField(UiText.SheetInitiative(lang), Mod(c.Initiative)));
			data.Vitals.Add(new PdfField(UiText.SheetSpeed(lang), UiText.FormatSpeed(c.Speed, lang)));
			data.Vitals.Add(new PdfField(UiText.SheetProficiency(lang), Mod(c.ProficiencyBonus)));
			data.Vitals.Add(new PdfField(UiText.PdfPassivePerception(lang), $"{c.PassivePerception}"));
			data.Vitals.Add(new PdfField(UiText.SheetHitDice(lang), string.Join(" ", c.HitDice.Select(h => $"{h.Count - sheet.HitDiceSpent.GetValueOrDefault(h.Die)}d{h.Die}"))));

			foreach (var ability in CharacterMath.Abilities)
			{
				data.Abilities.Add(new PdfAbility(FeatPrerequisiteFormatter.AbilityName(ability, lang), c.Score(ability), Mod(c.Modifier(ability)),
					$"{UiText.SheetSaveShort(lang)} {Mod(c.SaveBonus(ability))}", c.SaveProficiencies.Contains(ability)));
			}

			//	Abilities added by rule modules (Fortuna), next to the six
			foreach (var extra in c.ExtraAbilities)
			{
				data.Abilities.Add(new PdfAbility(extra.Definition.Name(lang), extra.Score, Mod(extra.Modifier),
					extra.HasSave ? $"{UiText.SheetSaveShort(lang)} {Mod(extra.SaveBonus)}" : "—", extra.SaveProficient));
			}

			// Conditions and inspiration, under the abilities
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
				data.Status = $"{UiText.SheetConditions(lang)}: {string.Join(" · ", states)}";
			}

			// Skills
			data.SkillsTitle = UiText.SheetSkills(lang);
			data.Skills = Enum.GetValues<Skill>().OrderBy(s => GameTerms.SkillName(s, lang))
				.Select(s => new PdfSkill(GameTerms.SkillName(s, lang), UiText.AbilityShort(GameTerms.SkillAbility(s), lang), Mod(c.SkillBonus(s)),
					c.SkillProficiencies.Contains(s), c.Expertise.Contains(s)))
				.ToList();

			data.PassivesTitle = UiText.PdfPassives(lang);
			data.Passives.Add(new PdfField(GameTerms.SkillName(Skill.Perception, lang), $"{c.PassivePerception}"));
			data.Passives.Add(new PdfField(GameTerms.SkillName(Skill.Insight, lang), $"{10 + c.SkillBonus(Skill.Insight)}"));
			data.Passives.Add(new PdfField(GameTerms.SkillName(Skill.Investigation, lang), $"{10 + c.SkillBonus(Skill.Investigation)}"));

			// Attacks
			data.AttacksTitle = UiText.SheetAttacks(lang);
			data.AttackHeaders = new List<string> { UiText.PdfWeapon(lang), UiText.PdfAttackBonus(lang), UiText.PdfDamage(lang) };
			data.NoAttacks = UiText.NoAttacks(lang);
			foreach (var attack in c.Attacks)
			{
				var damage = attack.DamageType is { } type ? $"{attack.Damage} {EquipmentTerms.DamageTypeName(type, lang)}" : attack.Damage;
				if (attack.VersatileDamage is { } versatile)
				{
					damage += $" ({versatile})";
				}
				data.Attacks.Add(new PdfAttack(attack.Item.Name, Mod(attack.AttackBonus), damage));
			}

			// Spells: the slots in the title, one card per source
			data.SpellsTitle = UiText.SheetSpells(lang);
			var slots = Enumerable.Range(1, 9).Where(l => c.SpellSlots[l - 1] > 0)
				.Select(l => $"{l}°: {c.SpellSlots[l - 1] - (l - 1 < sheet.SpentSlots.Count ? sheet.SpentSlots[l - 1] : 0)} / {c.SpellSlots[l - 1]}")
				.ToList();
			if (c.PactSlots > 0)
			{
				slots.Add($"{UiText.SheetPactSlots(c.PactSlotLevel, lang)}: {c.PactSlots - sheet.SpentPactSlots} / {c.PactSlots}");
			}
			if (slots.Count > 0)
			{
				data.SlotsPill = $"{UiText.PdfSlots(lang)} {string.Join(" · ", slots)}";
			}
			foreach (var source in c.AllSpellSources())
			{
				var name = source.Class is { } owner && source.Source == "subclass" ? $"{owner.Class.Name} · {owner.Subclass?.Name}"
					: source.Class?.Class.Name ?? (source.Source == "species" ? UiText.SpellSourceSpecies(ruleset, lang) : source.Source == "subclass" ? UiText.SpellSourceSubclass(lang) : source.Source);
				var stats = $"{UiText.AbilityShort(source.Ability, lang)} • {UiText.PdfDc(lang)} {source.SaveDc} • {UiText.SheetAttackShort(lang)} {Mod(source.AttackBonus)}";
				var lines = source.Known
					.Select(id => context.Spells.FirstOrDefault(s => s.Id == id))
					.Where(s => s is not null)
					.Select(s => s!)
					.GroupBy(s => s.Level)
					.OrderBy(g => g.Key)
					.Select(g => new PdfLine(g.Key == 0 ? UiText.LabelCantrips(lang) : GameTerms.SpellLevel(g.Key, lang), string.Join(", ", g.Select(s => s.Name).OrderBy(n => n))))
					.ToList();
				data.Casters.Add(new PdfCaster(name, stats, lines));
			}

			// Proficiencies and languages
			var proficiencies = new List<PdfLine>
			{
				new(UiText.SheetArmorTraining(lang), UiText.ArmorTrainingText(c.ArmorTraining, lang))
			};
			foreach (var info in c.Classes.Where(i => i.Starting))
			{
				if (classDetails.GetValueOrDefault(info.Class.Id) is { } detail && !string.IsNullOrWhiteSpace(detail.WeaponProficiencies))
				{
					proficiencies.Add(new PdfLine(UiText.LabelWeapons(lang), detail.WeaponProficiencies));
				}
			}
			if (!string.IsNullOrWhiteSpace(sheet.OtherProficiencies))
			{
				proficiencies.Add(new PdfLine(UiText.PdfOtherProficiencies(lang), sheet.OtherProficiencies.Replace('\n', ' ')));
			}
			proficiencies.Add(new PdfLine(UiText.LabelLanguages(ruleset, lang), string.Join(", ", c.Languages.Select(l => CharacterLanguages.Name(ruleset, l, lang)))));
			if (c.ExtraWeapons.Count > 0)
			{
				proficiencies.Add(new PdfLine(UiText.SheetWeaponTraining(lang), string.Join(", ", c.ExtraWeapons.Select(w => context.Items.FirstOrDefault(i => string.Equals(i.EnglishName, w, StringComparison.OrdinalIgnoreCase))?.Name ?? w))));
			}
			if (UiText.SensesText(c, lang) is { Length: > 0 } senses)
			{
				proficiencies.Add(new PdfLine(UiText.SheetSenses(lang), senses));
			}
			if (UiText.DefensesText(c, lang) is { Length: > 0 } defenses)
			{
				proficiencies.Add(new PdfLine(UiText.SheetDefenses(lang), defenses));
			}
			data.Proficiencies = new PdfInfoBox(UiText.PdfProficienciesTitle(lang), proficiencies);

			// Features and feats, with the resources left
			var features = new List<PdfLine>();
			if (c.Feats.Count > 0)
			{
				features.Add(new PdfLine(UiText.SheetFeats(lang), string.Join(", ", c.Feats.Select(f => f.Feat.Name))));
			}
			foreach (var info in c.Classes)
			{
				if (classDetails.GetValueOrDefault(info.Class.Id) is not { } detail)
				{
					continue;
				}
				var names = detail.Features.Where(f => f.Level <= info.Level).OrderBy(f => f.Level).ThenBy(f => f.SortOrder).Select(f => f.Name).Distinct();
				features.Add(new PdfLine($"{info.Class.Name} {info.Level}", string.Join(", ", names)));
				if (detail.Subclasses.FirstOrDefault(s => s.Id == info.Subclass?.Id) is { } subclass)
				{
					var subNames = subclass.Features.Where(f => f.Level <= info.Level).OrderBy(f => f.Level).Select(f => f.Name).Distinct();
					features.Add(new PdfLine(subclass.Name, string.Join(", ", subNames)));
				}
			}
			var resources = CharacterResources.For(c, lang)
				.Select(r => $"{r.Name} {r.Maximum - Math.Clamp(sheet.ResourceUses.GetValueOrDefault(r.Key), 0, r.Maximum)}/{r.Maximum}")
				.Concat(sheet.Resources.Select(r => $"{r.Name} {r.Maximum - r.Used}/{r.Maximum}"))
				.ToList();
			if (resources.Count > 0)
			{
				features.Add(new PdfLine(UiText.PdfResources(lang), string.Join(", ", resources)));
			}
			if (c.Breath is { } breath)
			{
				features.Add(new PdfLine(UiText.SheetBreath(lang), UiText.BreathText(breath, lang)));
			}
			data.Features = new PdfInfoBox(UiText.PdfFeaturesTitle(lang), features);

			// Inventory, two columns, with the coins in the title
			data.InventoryTitle = UiText.TabInventory(lang);
			var items = context.Items.ToDictionary(i => i.Id);
			foreach (var i in sheet.Inventory)
			{
				var name = i.EquipmentId is { } id && items.TryGetValue(id, out var item) ? item.Name : i.Name ?? string.Empty;
				var marks = new[]
				{
					i.Magic is { } magic ? UiText.MagicSummary(magic, lang) : null,
					i.Attuned ? UiText.SheetAttuned(lang) : null,
					i.Magic is { Charges: > 0 } charged ? UiText.ChargesLeft(charged.Charges - charged.ChargesUsed, charged.Charges, lang) : null
				}.Where(m => m is not null).ToList();
				var text = marks.Count > 0 ? $"{name} ({string.Join(", ", marks)})" : name;
				if (i.Quantity > 1)
				{
					text += $" ×{i.Quantity}";
				}
				data.Items.Add(new PdfItem(text, i.Equipped ? UiText.SheetEquipped(lang) : null));
			}
			var coins = string.Join("  ", new[] { (sheet.Coins.Pp, CoinType.Pp), (sheet.Coins.Gp, CoinType.Gp), (sheet.Coins.Ep, CoinType.Ep), (sheet.Coins.Sp, CoinType.Sp), (sheet.Coins.Cp, CoinType.Cp) }
				.Where(x => x.Item1 > 0).Select(x => $"{x.Item1} {UiText.CoinName(x.Item2, lang)}"));
			if (coins.Length > 0)
			{
				data.CoinsPill = $"{UiText.LabelCoins(lang)}: {coins}";
			}

			// Page of the notes: personality in a grid, then the longer texts
			data.NotesSubtitle = UiText.PdfNotesSubtitle(lang);
			data.HandNotesTitle = UiText.PdfHandNotes(lang);
			data.NotesMeta.Add(new PdfField(UiText.LabelAdvancement(lang), UiText.AdvancementName(sheet.Advancement, lang)));
			if (sheet.Advancement == AdvancementType.Experience)
			{
				data.NotesMeta.Add(new PdfField(UiText.SheetExperience(lang), $"{sheet.Experience}"));
			}
			void Add(List<PdfNote> list, string title, string? text)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.Add(new PdfNote(title, text.Trim()));
				}
			}
			Add(data.Personality, UiText.LabelPersonalityTraits(lang), sheet.Traits);
			Add(data.Personality, UiText.LabelIdeals(lang), sheet.Ideals);
			Add(data.Personality, UiText.LabelBonds(lang), sheet.Bonds);
			Add(data.Personality, UiText.LabelFlaws(lang), sheet.Flaws);
			Add(data.Notes, UiText.LabelAppearance(lang), sheet.Appearance);
			Add(data.Notes, UiText.LabelBackstory(lang), sheet.Backstory);
			Add(data.Notes, UiText.LabelAllies(lang), sheet.Allies);
			Add(data.Notes, UiText.TabFeatures(lang), sheet.FeatureNotes);
			Add(data.Notes, UiText.LabelNotes(lang), sheet.Notes);

			return data;
		}
	}
}
