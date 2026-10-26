using RealmForge.Shared.Enums;
using RealmForge.Shared.Localization;
using RealmForge.Shared.Rules;

namespace RealmForge.Shared.Characters;

///	<summary>
///	Issue codes of <see cref="CharacterCalculator"/> (the client shows them in the reader's language).
///	</summary>
public static class IssueCodes
{
	public const string Name = "name";
	public const string Level = "level";
	public const string Species = "species";
	public const string Subspecies = "subspecies";
	public const string SubspeciesMissing = "subspecies-missing";
	public const string Size = "size";
	public const string Background = "background";
	public const string Class = "class";
	public const string Multiclass = "multiclass";
	public const string Subclass = "subclass";
	public const string SubclassMissing = "subclass-missing";
	public const string BaseScores = "base-scores";
	public const string Bonuses = "bonuses";
	public const string BonusesMissing = "bonuses-missing";
	public const string Improvement = "improvement";
	public const string ImprovementMissing = "improvement-missing";
	public const string Feat = "feat";
	public const string FeatPrerequisite = "feat-prerequisite";
	public const string FeatDuplicate = "feat-duplicate";
	public const string FeatChoice = "feat-choice";
	public const string FeatChoiceMissing = "feat-choice-missing";
	public const string SpeciesFeatMissing = "species-feat-missing";
	public const string ScoreCap = "score-cap";
	public const string Skills = "skills";
	public const string SkillsMissing = "skills-missing";
	public const string Expertise = "expertise";
	public const string ExpertiseMissing = "expertise-missing";
	public const string Languages = "languages";
	public const string LanguagesMissing = "languages-missing";
	public const string Spells = "spells";
	public const string CantripsMissing = "cantrips-missing";
	public const string SpellsMissing = "spells-missing";
	public const string HitPointRoll = "hit-point-roll";
	public const string FightingStyle = "fighting-style";
	public const string FightingStyleMissing = "fighting-style-missing";
	public const string Order = "order";
	public const string OrderMissing = "order-missing";
	public const string WeaponMastery = "weapon-mastery";
	public const string WeaponMasteryMissing = "weapon-mastery-missing";
	public const string Equipment = "equipment";
}

///	<summary>
///	Computes a character from its choices and the compendium of its edition, and checks every choice against the
///	rules of that edition: the same code runs in the wizard, on the sheet and in the API before saving.
///	</summary>
public static class CharacterCalculator
{
	public static ComputedCharacter Compute(CharacterInput input, CharacterContextDto context, bool checkEquipment = false)
	{
		var ruleset = input.Ruleset;
		var is2024 = ruleset == RulesetVersion.Dnd5e_2024;
		var build = input.Build;

		var species = context.Species.FirstOrDefault(s => s.Id == input.SpeciesId);
		var subspecies = species?.Subspecies.FirstOrDefault(s => s.Id == input.SubspeciesId);
		var background = context.Backgrounds.FirstOrDefault(b => b.Id == input.BackgroundId);
		var result = new ComputedCharacter { Ruleset = ruleset, Species = species, Subspecies = subspecies, Background = background };

		if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Trim().Length > 100)
		{
			result.Error(IssueCodes.Name);
		}

		CheckOrigin(input, result, species, subspecies, background);

		// ----- Classes and levels -----
		var levels = build.Levels;
		result.Level = Math.Clamp(levels.Count, 1, 20);
		if (levels.Count is < 1 or > 20)
		{
			result.Error(IssueCodes.Level);
		}
		result.ProficiencyBonus = CharacterMath.ProficiencyBonus(result.Level);

		var classes = new List<(ContextClass Class, CharacterClassBuild Build)>();
		foreach (var entry in build.Classes)
		{
			var cls = context.Classes.FirstOrDefault(c => c.Id == entry.ClassId);
			if (cls is null || classes.Any(c => c.Class.Id == cls.Id))
			{
				result.Error(IssueCodes.Class);
				continue;
			}
			classes.Add((cls, entry));
		}

		if (classes.Count == 0 || levels.Count == 0 || levels[0].ClassId != classes[0].Class.Id || levels.Any(l => classes.All(c => c.Class.Id != l.ClassId)))
		{
			result.Error(IssueCodes.Class);
		}

		// ----- Ability scores -----
		var baseScores = build.BaseScores.Count == 6 ? build.BaseScores.ToArray() : new[] { 10, 10, 10, 10, 10, 10 };
		if (!CharacterMath.AreValidBaseScores(build.AbilityMethod, build.BaseScores))
		{
			result.Error(IssueCodes.BaseScores);
		}
		result.BaseScores = baseScores;
		result.OriginBonuses = OriginBonuses(input, result, species, subspecies, background);

		var running = baseScores.Select((s, i) => s + result.OriginBonuses[i]).ToArray();
		var levelBonuses = new int[6];

		//	Feats outside the levels: background origin feat (2024), species feat
		var takenFeats = new List<TakenFeat>();
		if (is2024 && background?.OriginFeatId is { } originFeatId && context.Feats.FirstOrDefault(f => f.Id == originFeatId) is { } originFeat)
		{
			takenFeats.Add(new TakenFeat(originFeat, "origin", build.OriginFeat));
		}
		if (CharacterRules.SpeciesGrantsFeat(ruleset, species, subspecies))
		{
			var speciesFeat = build.SpeciesFeatId is { } sfId ? context.Feats.FirstOrDefault(f => f.Id == sfId) : null;
			if (build.SpeciesFeatId is not null && speciesFeat is null)
			{
				result.ErrorIn(IssueAreas.Species, IssueCodes.Feat, "species");
			}
			else if (speciesFeat is null)
			{
				result.Todo(IssueCodes.SpeciesFeatMissing);
			}
			else if (is2024 && speciesFeat.Category != FeatCategory.Origin)
			{
				result.ErrorIn(IssueAreas.Species, IssueCodes.FeatPrerequisite, speciesFeat.Name);
			}
			else
			{
				takenFeats.Add(new TakenFeat(speciesFeat, "species", build.SpeciesFeat));
			}
		}
		else if (build.SpeciesFeatId is not null)
		{
			result.ErrorIn(IssueAreas.Species, IssueCodes.Feat, "species");
		}

		foreach (var feat in takenFeats)
		{
			ApplyFeatIncreases(feat, running, levelBonuses, result, ruleset);
		}

		//	Level by level: class level, multiclassing, improvements
		var classLevels = classes.ToDictionary(c => c.Class.Id, _ => 0);
		for (var i = 0; i < levels.Count && i < 20; i++)
		{
			var entry = levels[i];
			var pair = classes.FirstOrDefault(c => c.Class.Id == entry.ClassId);
			if (pair.Class is null)
			{
				continue;
			}

			var cls = pair.Class;
			var newClass = classLevels[cls.Id] == 0;
			classLevels[cls.Id]++;
			var classLevel = classLevels[cls.Id];

			if (newClass && i > 0)
			{
				//	Multiclassing: 13 in the primary abilities of the new class and of the classes already taken
				foreach (var taken in classes.Where(c => classLevels[c.Class.Id] > 0))
				{
					if (!CharacterRules.MeetsMulticlassPrerequisite(taken.Class, running))
					{
						result.Error(IssueCodes.Multiclass, taken.Class.Name);
					}
				}
			}

			var improvement = CharacterRules.ImprovementLevels(cls, ruleset).Contains(classLevel);
			var epicBoon = CharacterRules.EpicBoonLevel(ruleset) == classLevel;
			result.Plan.Add(new LevelPlanEntry(i + 1, cls, classLevel, newClass, improvement, epicBoon,
				cls.Subclasses.Count > 0 && classLevel == cls.SubclassLevel, cls.HitDie));

			if (i == 0 && entry.HitPointRoll is not null)
			{
				result.Error(IssueCodes.HitPointRoll, 1);
			}
			if (entry.HitPointRoll is { } roll && (roll < 1 || roll > cls.HitDie))
			{
				result.Error(IssueCodes.HitPointRoll, i + 1);
			}

			if (improvement || epicBoon)
			{
				ApplyLevelImprovement(entry, i + 1, cls, epicBoon, result, context, takenFeats, running, levelBonuses, classes);
			}
			else if (entry.FeatId is not null || entry.Increases.Count > 0)
			{
				result.Error(IssueCodes.Improvement, i + 1);
			}
		}

		result.LevelBonuses = levelBonuses;
		MagicItemRules.ApplyToScores(input.Sheet, running);
		result.FinalScores = running;
		result.Feats.AddRange(takenFeats);

		foreach (var (cls, classBuild) in classes)
		{
			var level = classLevels[cls.Id];
			if (level == 0)
			{
				continue;
			}

			ContextSubclass? subclass = null;
			if (classBuild.SubclassId is { } subId)
			{
				subclass = cls.Subclasses.FirstOrDefault(s => s.Id == subId);
				if (subclass is null || level < cls.SubclassLevel)
				{
					result.Error(IssueCodes.Subclass, cls.Name);
					subclass = null;
				}
			}
			else if (cls.Subclasses.Count > 0 && level >= cls.SubclassLevel)
			{
				result.Todo(IssueCodes.SubclassMissing, cls.Name);
			}

			result.Classes.Add(new ClassLevelInfo(cls, subclass, level, classBuild, result.Classes.Count == 0));
		}

		ComputeProficiencies(input, result, context, species, subspecies, background);
		ComputeHitPoints(input, result, species, subspecies);
		ComputeLanguages(input, result, species, subspecies, background);
		ComputeSpells(input, result, context, subspecies);
		ComputeClassOptions(input, result, context);
		ComputeDefenses(input, result, context, species);

		if (checkEquipment)
		{
			CheckEquipment(build, result, context, background, classes.Count > 0 ? classes[0].Class : null);
		}

		return result;
	}

	// ===== Origin =====

	private static void CheckOrigin(CharacterInput input, ComputedCharacter result, ContextSpecies? species, ContextSubspecies? subspecies, ContextBackground? background)
	{
		if (species is null)
		{
			result.Error(IssueCodes.Species);
		}
		else
		{
			if (input.SubspeciesId is not null && subspecies is null)
			{
				result.Error(IssueCodes.Subspecies);
			}
			else if (subspecies is null && species.Subspecies.Count > 0 && species.Key is not null)
			{
				result.Todo(IssueCodes.SubspeciesMissing);
			}
			if (!species.Sizes.Contains(input.Build.Size))
			{
				result.Error(IssueCodes.Size);
			}
		}

		if (background is null)
		{
			result.Error(IssueCodes.Background);
		}
	}

	///	<summary>
	///	2024: the increases of the background (+2/+1 or +1/+1/+1 on its three abilities). 2014: the racial
	///	increases, with the free +1 of the half-elf and the variant human; Homebrew races choose freely.
	///	</summary>
	private static int[] OriginBonuses(CharacterInput input, ComputedCharacter result, ContextSpecies? species, ContextSubspecies? subspecies, ContextBackground? background)
	{
		var build = input.Build;
		var bonuses = new int[6];
		var choices = build.BonusChoices;
		var area = input.Ruleset == RulesetVersion.Dnd5e_2024 ? IssueAreas.Background : IssueAreas.Species;

		if (choices.Any(c => !Enum.IsDefined(c)))
		{
			result.ErrorIn(area, IssueCodes.Bonuses);
			return bonuses;
		}

		if (input.Ruleset == RulesetVersion.Dnd5e_2014 && CharacterRules.IsBaseRace2014(species))
		{
			var (fixedBonus, count) = CharacterRules.RacialIncreases2014(species, subspecies);
			Array.Copy(fixedBonus, bonuses, 6);
			var excluded = species?.Key == "half-elf" ? new[] { AbilityScore.Charisma } : Array.Empty<AbilityScore>();
			if (choices.Count > count || choices.Distinct().Count() != choices.Count || choices.Any(excluded.Contains))
			{
				result.ErrorIn(area, IssueCodes.Bonuses);
				return bonuses;
			}
			if (choices.Count < count)
			{
				result.TodoIn(area, IssueCodes.BonusesMissing);
			}
			foreach (var c in choices)
			{
				bonuses[(int)c - 1] += 1;
			}

			return bonuses;
		}

		var allowed = input.Ruleset == RulesetVersion.Dnd5e_2024 && background is { AbilityOptions.Count: > 0 }
			? background.AbilityOptions
			: CharacterMath.Abilities.ToList();

		var expected = build.BonusMode switch
		{
			AbilityBonusMode.TwoAndOne => 2,
			AbilityBonusMode.ThreeOnes => 3,
			AbilityBonusMode.AllOnes when input.Ruleset == RulesetVersion.Dnd5e_2014 => 0,
			_ => -1
		};
		if (expected < 0 || choices.Count > expected || choices.Distinct().Count() != choices.Count || choices.Any(c => !allowed.Contains(c)))
		{
			result.ErrorIn(area, IssueCodes.Bonuses);
			return bonuses;
		}
		if (choices.Count < expected)
		{
			result.TodoIn(area, IssueCodes.BonusesMissing);
		}

		switch (build.BonusMode)
		{
			case AbilityBonusMode.TwoAndOne:
				for (var i = 0; i < choices.Count; i++)
				{
					bonuses[(int)choices[i] - 1] += i == 0 ? 2 : 1;
				}
				break;
			case AbilityBonusMode.ThreeOnes:
				foreach (var c in choices)
				{
					bonuses[(int)c - 1] += 1;
				}
				break;
			default:
				Array.Fill(bonuses, 1);
				break;
		}

		return bonuses;
	}

	// ===== Improvements and feats =====

	private static void ApplyLevelImprovement(CharacterLevelBuild entry, int level, ContextClass cls, bool epicBoon, ComputedCharacter result,
		CharacterContextDto context, List<TakenFeat> takenFeats, int[] running, int[] levelBonuses, List<(ContextClass Class, CharacterClassBuild Build)> classes)
	{
		var ruleset = result.Ruleset;

		if (entry.FeatId is null)
		{
			//	2014: the plain improvement, +2 to one score or +1 to two; 2024 always takes a feat
			if (ruleset == RulesetVersion.Dnd5e_2024 || entry.Increases.Count == 0)
			{
				result.Todo(IssueCodes.ImprovementMissing, level);
				return;
			}
			if (entry.Increases.Count != 2 || entry.Increases.Any(a => !Enum.IsDefined(a)))
			{
				result.Error(IssueCodes.Improvement, level);
				return;
			}

			foreach (var ability in entry.Increases)
			{
				Raise(ability, 20, running, levelBonuses, result);
			}
			return;
		}

		if (entry.Increases.Count > 0)
		{
			result.Error(IssueCodes.Improvement, level);
			return;
		}

		var feat = context.Feats.FirstOrDefault(f => f.Id == entry.FeatId);
		if (feat is null)
		{
			result.Error(IssueCodes.Feat, level);
			return;
		}

		if (!MeetsFeatPrerequisites(feat, level, running, result, classes, takenFeats))
		{
			result.Error(IssueCodes.FeatPrerequisite, feat.Name);
		}
		if (epicBoon && ruleset == RulesetVersion.Dnd5e_2024 && feat.Category == FeatCategory.Origin)
		{
			result.Error(IssueCodes.FeatPrerequisite, feat.Name);
		}

		var taken = new TakenFeat(feat, $"level:{level}", entry.Feat);
		ApplyFeatIncreases(taken, running, levelBonuses, result, ruleset);
		takenFeats.Add(taken);
	}

	private static bool MeetsFeatPrerequisites(ContextFeat feat, int level, int[] scores, ComputedCharacter result,
		List<(ContextClass Class, CharacterClassBuild Build)> classes, List<TakenFeat> taken)
	{
		if (feat.MinimumLevel is { } minimum && level < minimum)
		{
			return false;
		}
		if (feat.PrerequisiteAbilities.Count > 0 && feat.MinimumScore is { } minScore
			&& feat.PrerequisiteAbilities.All(a => scores[(int)a - 1] < minScore))
		{
			return false;
		}
		if (!CharacterRules.IsRepeatable(feat) && taken.Any(t => t.Feat.Id == feat.Id))
		{
			result.Error(IssueCodes.FeatDuplicate, feat.Name);
		}

		var levels = result.Plan;
		bool HasClassAtLevel(Func<ContextClass, int, bool> test) =>
			classes.Any(c => test(c.Class, levels.Where(p => p.Class.Id == c.Class.Id).Select(p => p.ClassLevel).DefaultIfEmpty(0).Max()));

		return feat.PrerequisiteFeature switch
		{
			FeatFeatureRequirement.FightingStyle => HasClassAtLevel((c, l) => CharacterRules.FightingStyleLevel(c) is { } fs && l >= fs),
			FeatFeatureRequirement.Spellcasting => HasClassAtLevel((c, l) => c.CasterProgression is CasterProgression.Full or CasterProgression.Half && CharacterRules.SingleClassCasterLevel(c.CasterProgression, l, result.Ruleset) > 0)
				|| classes.Any(c => c.Build.SubclassId is not null && c.Class.Subclasses.Any(s => s.Id == c.Build.SubclassId && s.CasterProgression == CasterProgression.Third)),
			FeatFeatureRequirement.SpellcastingOrPactMagic => HasClassAtLevel((c, l) => c.CasterProgression != CasterProgression.None)
				|| classes.Any(c => c.Build.SubclassId is not null && c.Class.Subclasses.Any(s => s.Id == c.Build.SubclassId && s.CasterProgression == CasterProgression.Third)),
			FeatFeatureRequirement.LightArmor => HasTraining(ArmorTraining.Light),
			FeatFeatureRequirement.MediumArmor => HasTraining(ArmorTraining.Medium),
			FeatFeatureRequirement.HeavyArmor => HasTraining(ArmorTraining.Heavy),
			FeatFeatureRequirement.Shield => HasTraining(ArmorTraining.Shield),
			_ => true
		};

		bool HasTraining(ArmorTraining needed)
		{
			var training = ArmorTraining.None;
			for (var i = 0; i < classes.Count; i++)
			{
				training |= CharacterRules.Armor(classes[i].Class, result.Ruleset, i == 0);
				training |= OrderArmor(classes[i].Build.Order);
			}
			foreach (var t in taken)
			{
				training |= CharacterRules.FeatArmor(t.Feat);
			}

			return training.HasFlag(needed);
		}
	}

	private static ArmorTraining OrderArmor(string? order) => order switch
	{
		"protector" => ArmorTraining.Heavy,
		"warden" => ArmorTraining.Medium,
		_ => ArmorTraining.None
	};

	private static void ApplyFeatIncreases(TakenFeat taken, int[] running, int[] levelBonuses, ComputedCharacter result, RulesetVersion ruleset)
	{
		var feat = taken.Feat;
		var area = IssueAreas.OfSource(taken.Source);
		var increases = taken.Choice.Increases;
		var asi = feat.Key == "ability-score-improvement";
		var expected = asi ? 2 : feat.Increases.Count > 0 ? 1 : 0;

		if (increases.Count > expected || increases.Any(a => !Enum.IsDefined(a)) || (!asi && increases.Any(a => !feat.Increases.Contains(a))))
		{
			result.ErrorIn(area, IssueCodes.FeatChoice, feat.Name);
			return;
		}
		if (increases.Count < expected)
		{
			result.TodoIn(area, IssueCodes.FeatChoiceMissing, feat.Name);
		}

		foreach (var ability in increases)
		{
			Raise(ability, asi ? 20 : feat.IncreaseMaximum, running, levelBonuses, result);
		}

		//	Skills of Skilled, Skill Expert, Keen Mind and Observant (2024)
		var skillCount = CharacterRules.FeatSkillChoices(feat, ruleset);
		var options = CharacterRules.FeatSkillOptions(feat, ruleset);
		var skills = taken.Choice.Skills;
		if (skills.Count > skillCount || skills.Distinct().Count() != skills.Count || (options is not null && skills.Any(s => !options.Contains(s))))
		{
			result.ErrorIn(area, IssueCodes.FeatChoice, feat.Name);
		}
		else if (skills.Count < skillCount)
		{
			result.TodoIn(area, IssueCodes.FeatChoiceMissing, feat.Name);
		}
	}

	private static void Raise(AbilityScore ability, int maximum, int[] running, int[] levelBonuses, ComputedCharacter result)
	{
		var index = (int)ability - 1;
		if (running[index] + 1 > maximum)
		{
			result.Error(IssueCodes.ScoreCap, ability);
			return;
		}

		running[index]++;
		levelBonuses[index]++;
	}

	// ===== Proficiencies =====

	private static void ComputeProficiencies(CharacterInput input, ComputedCharacter result, CharacterContextDto context,
		ContextSpecies? species, ContextSubspecies? subspecies, ContextBackground? background)
	{
		var ruleset = input.Ruleset;
		var skills = result.SkillProficiencies;

		foreach (var s in background?.Skills ?? new List<Skill>())
		{
			skills.Add(s);
		}

		//	Species skills
		var (fixedSkills, speciesCount, speciesOptions) = CharacterRules.SpeciesSkills(ruleset, species, subspecies);
		foreach (var s in fixedSkills)
		{
			skills.Add(s);
		}
		var chosenSpecies = input.Build.SpeciesSkills;
		if (chosenSpecies.Count > speciesCount || chosenSpecies.Distinct().Count() != chosenSpecies.Count
			|| (speciesOptions is not null && chosenSpecies.Any(s => !speciesOptions.Contains(s))) || chosenSpecies.Any(skills.Contains))
		{
			result.ErrorIn(IssueAreas.Species, IssueCodes.Skills, "species");
		}
		else if (chosenSpecies.Count < speciesCount)
		{
			result.TodoIn(IssueAreas.Species, IssueCodes.SkillsMissing, "species", speciesCount - chosenSpecies.Count);
		}
		foreach (var s in chosenSpecies)
		{
			skills.Add(s);
		}

		//	Class skills: all the starting class choices, one skill for bard / ranger / rogue taken later
		foreach (var info in result.Classes)
		{
			var chosen = info.Build.Skills;
			var (count, any) = info.Starting
				? (info.Class.SkillChoiceCount, false)
				: CharacterRules.MulticlassSkills(info.Class);
			var options = any ? Enum.GetValues<Skill>().ToList() : info.Class.SkillOptions;
			var skillArea = info.Starting ? IssueAreas.Class : IssueAreas.Progression;
			if (chosen.Count > count || chosen.Distinct().Count() != chosen.Count || chosen.Any(s => !options.Contains(s)) || chosen.Any(skills.Contains))
			{
				result.ErrorIn(skillArea, IssueCodes.Skills, info.Class.Name);
			}
			else
			{
				var target = Math.Min(count, options.Count(s => !skills.Contains(s)));
				if (chosen.Count < target)
				{
					result.TodoIn(skillArea, IssueCodes.SkillsMissing, info.Class.Name, target - chosen.Count);
				}
			}
			foreach (var s in chosen)
			{
				skills.Add(s);
			}
		}

		//	Feat skills: proficiency, or Expertise when already proficient (2024 Keen Mind, Observant)
		foreach (var feat in result.Feats)
		{
			foreach (var s in feat.Choice.Skills)
			{
				if (!skills.Add(s) && feat.Feat.Key is "keen-mind" or "observant")
				{
					result.Expertise.Add(s);
				}
			}
		}

		foreach (var s in input.Sheet.ExtraSkills)
		{
			skills.Add(s);
		}

		//	Expertise of the classes and of Skill Expert, only on proficient skills
		foreach (var info in result.Classes)
		{
			var grants = CharacterRules.Expertise(info.Class, ruleset).Where(g => g.Level <= info.Level).ToList();
			var allowedCount = grants.Sum(g => g.Count);
			var restricted = grants.Count > 0 && grants.All(g => g.Allowed is not null) ? grants.SelectMany(g => g.Allowed!).ToList() : null;
			var chosen = info.Build.Expertise;
			if (chosen.Count > allowedCount || chosen.Distinct().Count() != chosen.Count || chosen.Any(s => !skills.Contains(s))
				|| (restricted is not null && chosen.Any(s => !restricted.Contains(s))) || chosen.Any(result.Expertise.Contains))
			{
				result.Error(IssueCodes.Expertise, info.Class.Name);
			}
			else if (chosen.Count < allowedCount)
			{
				result.Todo(IssueCodes.ExpertiseMissing, info.Class.Name, allowedCount - chosen.Count);
			}
			foreach (var s in chosen)
			{
				result.Expertise.Add(s);
			}
		}
		foreach (var feat in result.Feats)
		{
			var allowed = CharacterRules.FeatExpertise(feat.Feat);
			var chosen = feat.Choice.Expertise;
			if (chosen.Count > allowed || chosen.Any(s => !skills.Contains(s) || result.Expertise.Contains(s)))
			{
				result.ErrorIn(IssueAreas.OfSource(feat.Source), IssueCodes.FeatChoice, feat.Feat.Name);
			}
			else if (chosen.Count < allowed)
			{
				result.TodoIn(IssueAreas.OfSource(feat.Source), IssueCodes.FeatChoiceMissing, feat.Feat.Name);
			}
			foreach (var s in chosen)
			{
				result.Expertise.Add(s);
			}
		}
		foreach (var s in input.Sheet.ExtraExpertise.Where(skills.Contains))
		{
			result.Expertise.Add(s);
		}

		//	Saving throws: the starting class, Resilient, the monk at 14 (all), the rogue at 15
		if (result.Classes.FirstOrDefault() is { } first)
		{
			foreach (var a in first.Class.SavingThrows)
			{
				result.SaveProficiencies.Add(a);
			}
		}
		foreach (var feat in result.Feats.Where(f => f.Feat.Key == "resilient"))
		{
			foreach (var a in feat.Choice.Increases)
			{
				result.SaveProficiencies.Add(a);
			}
		}
		if (result.ClassLevel("monk") >= 14)
		{
			foreach (var a in CharacterMath.Abilities)
			{
				result.SaveProficiencies.Add(a);
			}
		}
		if (result.ClassLevel("rogue") >= 15)
		{
			result.SaveProficiencies.Add(AbilityScore.Wisdom);
			if (ruleset == RulesetVersion.Dnd5e_2024)
			{
				result.SaveProficiencies.Add(AbilityScore.Charisma);
			}
		}
		foreach (var a in input.Sheet.ExtraSaves)
		{
			result.SaveProficiencies.Add(a);
		}

		//	Paladin Aura of Protection: Charisma modifier (at least +1) to every save
		if (result.ClassLevel("paladin") >= 6)
		{
			result.SaveBonusAll = Math.Max(1, result.Modifier(AbilityScore.Charisma));
		}

		result.JackOfAllTrades = result.ClassLevel("bard") >= 2;

		//	Magic items: bonuses to every save and every ability check (Ring of Protection, Stone of Good Luck)
		result.SaveBonusAll += MagicItemRules.Sum(input.Sheet, MagicEffectKind.SavingThrows);
		result.CheckBonusAll = MagicItemRules.Sum(input.Sheet, MagicEffectKind.AbilityChecks);
		result.Resistances.AddRange(MagicItemRules.ActiveEffects(input.Sheet)
			.Where(e => e.Kind == MagicEffectKind.Resistance && e.DamageType is not null)
			.Select(e => e.DamageType!.Value)
			.Distinct());

		//	Armor and weapon training
		var training = ArmorTraining.None;
		foreach (var info in result.Classes)
		{
			training |= CharacterRules.Armor(info.Class, ruleset, info.Starting);
			training |= OrderArmor(info.Build.Order);
		}
		foreach (var feat in result.Feats)
		{
			training |= CharacterRules.FeatArmor(feat.Feat);
		}
		result.ArmorTraining = training;
		result.MartialWeapons = result.Classes.Any(c => CharacterRules.MartialWeapons(c.Class))
			|| result.Classes.Any(c => c.Build.Order is "protector" or "warden")
			|| result.Feats.Any(f => CharacterRules.FeatMartialWeapons(f.Feat));
	}

	// ===== Hit points =====

	private static void ComputeHitPoints(CharacterInput input, ComputedCharacter result, ContextSpecies? species, ContextSubspecies? subspecies)
	{
		var con = result.Modifier(AbilityScore.Constitution);
		var total = 0;
		for (var i = 0; i < result.Plan.Count; i++)
		{
			var plan = result.Plan[i];
			var roll = i == 0 ? plan.HitDie : input.Build.Levels[i].HitPointRoll ?? plan.HitDie / 2 + 1;
			total += Math.Max(1, roll + con);
		}

		total += result.Level * CharacterRules.SpeciesHitPointsPerLevel(input.Ruleset, species, subspecies);
		total += 2 * result.Level * result.Feats.Count(f => f.Feat.Key == "tough");

		foreach (var info in result.Classes)
		{
			if (info.Subclass?.Key == "draconic-bloodline" || (info.Subclass?.Key == "draconic-sorcery" && info.Level >= 3))
			{
				total += info.Level;
			}
		}

		result.MaxHitPoints = Math.Max(1, total + MagicItemRules.Sum(input.Sheet, MagicEffectKind.MaxHitPoints) + input.Sheet.MaxHitPointsAdjustment);

		foreach (var group in result.Plan.GroupBy(p => p.HitDie).OrderByDescending(g => g.Key))
		{
			result.HitDice.Add((group.Key, group.Count()));
		}
	}

	// ===== Languages =====

	private static void ComputeLanguages(CharacterInput input, ComputedCharacter result, ContextSpecies? species, ContextSubspecies? subspecies, ContextBackground? background)
	{
		var ruleset = input.Ruleset;
		var (fixedLanguages, speciesChoices) = CharacterRules.SpeciesLanguages(ruleset, species, subspecies);
		result.FixedLanguages.AddRange(fixedLanguages);
		foreach (var info in result.Classes)
		{
			foreach (var key in CharacterRules.ClassLanguages(info.Class).Where(k => !result.FixedLanguages.Contains(k)))
			{
				result.FixedLanguages.Add(key);
			}
		}

		var choices = speciesChoices
			+ (ruleset == RulesetVersion.Dnd5e_2014 ? background?.LanguageChoices ?? 0 : 0)
			+ result.Classes.Sum(c => CharacterRules.ClassLanguageChoices(c.Class, ruleset, c.Level))
			+ result.Feats.Sum(f => CharacterRules.FeatLanguages(f.Feat));
		result.LanguageChoices = choices;

		var chosen = input.Build.Languages.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
		var extras = chosen.Where(l => !result.FixedLanguages.Contains(l)).ToList();
		if (chosen.Distinct().Count() != chosen.Count || extras.Count > choices
			|| extras.Any(l => !CharacterLanguages.IsKnown(ruleset, l) || CharacterLanguages.Find(ruleset, l)!.Group == LanguageGroup.Secret))
		{
			result.Error(IssueCodes.Languages);
		}
		else if (extras.Count < choices)
		{
			result.Todo(IssueCodes.LanguagesMissing, choices - extras.Count);
		}

		result.Languages.AddRange(result.FixedLanguages);
		result.Languages.AddRange(extras.Where(CharacterLanguagesIsKnown(ruleset)));
	}

	private static Func<string, bool> CharacterLanguagesIsKnown(RulesetVersion ruleset) => key => CharacterLanguages.IsKnown(ruleset, key);

	// ===== Spells =====

	private static void ComputeSpells(CharacterInput input, ComputedCharacter result, CharacterContextDto context, ContextSubspecies? subspecies)
	{
		//	Magic items: Wand of the War Mage, Rod of the Pact Keeper…
		var spellAttack = MagicItemRules.Sum(input.Sheet, MagicEffectKind.SpellAttack);
		var spellDc = MagicItemRules.Sum(input.Sheet, MagicEffectKind.SpellSaveDc);

		var ruleset = input.Ruleset;
		var spells = context.Spells.ToDictionary(s => s.Id);

		var multiclassLevel = 0;
		var casterClasses = 0;
		var singleLevel = 0;

		foreach (var info in result.Classes)
		{
			var cls = info.Class;
			var progression = cls.CasterProgression;
			var list = cls.SpellList;
			var ability = info.Subclass?.SpellcastingAbility ?? cls.SpellcastingAbility;
			if (progression == CasterProgression.None && info.Subclass?.CasterProgression == CasterProgression.Third)
			{
				progression = CasterProgression.Third;
				list = SpellcastingClass.Wizard;
				ability = info.Subclass.SpellcastingAbility ?? AbilityScore.Intelligence;
			}

			var build = info.Build;
			if (progression == CasterProgression.None || ability is null)
			{
				if (build.Cantrips.Count > 0 || build.Spells.Count > 0)
				{
					result.Error(IssueCodes.Spells, cls.Name);
				}
				CheckStyleCantrips(info, result, spells);
				continue;
			}

			var mod = result.Modifier(ability.Value);
			int cantrips, prepared, maxLevel;
			if (progression == CasterProgression.Pact)
			{
				var allowance = CharacterMath.Spells(cls.ProgressionTable, info.Level, mod, false);
				(cantrips, prepared) = (allowance.Cantrips, allowance.Spells);
				maxLevel = CharacterRules.PactSlots(info.Level).Level;
				var (pactSlots, pactLevel) = CharacterRules.PactSlots(info.Level);
				result.PactSlots = pactSlots;
				result.PactSlotLevel = pactLevel;
			}
			else if (progression == CasterProgression.Third)
			{
				(cantrips, prepared) = CharacterRules.ThirdCaster(info.Subclass!, info.Level);
				maxLevel = CharacterRules.HighestSlot(CharacterRules.SlotsForCasterLevel(CharacterRules.SingleClassCasterLevel(progression, info.Level, ruleset)));
			}
			else
			{
				var allowance = CharacterMath.Spells(cls.ProgressionTable, info.Level, mod, progression == CasterProgression.Half && ruleset == RulesetVersion.Dnd5e_2014);
				(cantrips, prepared) = (allowance.Cantrips, allowance.Spells);
				maxLevel = CharacterRules.HighestSlot(CharacterRules.SlotsForCasterLevel(CharacterRules.SingleClassCasterLevel(progression, info.Level, ruleset)));
				if (allowance.IsNone && maxLevel > 0)
				{
					//	Homebrew table without spell columns: the 2014 formula
					prepared = Math.Max(1, mod + (progression == CasterProgression.Half ? info.Level / 2 : info.Level));
				}
			}

			//	2024 Thaumaturge / Magician: one extra cantrip
			if (build.Order is "thaumaturge" or "magician")
			{
				cantrips++;
			}

			if (progression != CasterProgression.Pact)
			{
				casterClasses++;
				singleLevel = CharacterRules.SingleClassCasterLevel(progression, info.Level, ruleset);
				multiclassLevel += CharacterRules.MulticlassCasterLevel(progression, info.Level, ruleset);
			}

			CheckSpellList(cls.Name, build.Cantrips, build.Spells, cantrips, prepared, maxLevel, list, result, spells);
			CheckStyleCantrips(info, result, spells);
			CheckSpellbook(info, list, maxLevel, result, spells);

			result.Spellcasting.Add(new SpellcastingInfo("class", info, ability.Value, 8 + result.ProficiencyBonus + mod + spellDc, result.ProficiencyBonus + mod + spellAttack,
				list, cantrips, prepared, maxLevel, build.Cantrips, build.Spells));
		}

		var casterLevel = casterClasses == 1 ? singleLevel : multiclassLevel;
		result.SpellSlots = CharacterRules.SlotsForCasterLevel(casterLevel);

		//	Magic Initiate: two cantrips and a level 1 spell of the chosen list
		foreach (var feat in result.Feats.Where(f => CharacterRules.IsMagicInitiate(f.Feat)))
		{
			var choice = feat.Choice;
			var featArea = IssueAreas.OfSource(feat.Source);
			var lists = CharacterRules.MagicInitiateLists(ruleset);
			if (choice.SpellList is not { } list || !lists.Contains(list))
			{
				if (choice.SpellList is not null)
				{
					result.ErrorIn(featArea, IssueCodes.FeatChoice, feat.Feat.Name);
				}
				else
				{
					result.TodoIn(featArea, IssueCodes.FeatChoiceMissing, feat.Feat.Name);
				}
				continue;
			}

			var ability = ruleset == RulesetVersion.Dnd5e_2024
				? choice.SpellcastingAbility ?? AbilityScore.Intelligence
				: CharacterRules.MagicInitiateAbility2014(list);
			if (ruleset == RulesetVersion.Dnd5e_2024 && choice.SpellcastingAbility is not (AbilityScore.Intelligence or AbilityScore.Wisdom or AbilityScore.Charisma))
			{
				result.TodoIn(featArea, IssueCodes.FeatChoiceMissing, feat.Feat.Name);
			}

			CheckSpellList(feat.Feat.Name, choice.Cantrips, choice.Spells, 2, 1, 1, list, result, spells);
			var mod = result.Modifier(ability);
			result.Spellcasting.Add(new SpellcastingInfo(feat.Feat.Name, null, ability, 8 + result.ProficiencyBonus + mod + spellDc, result.ProficiencyBonus + mod + spellAttack,
				list, 2, 1, 1, choice.Cantrips, choice.Spells));
		}

		//	2014 high elf: one wizard cantrip (Intelligence)
		var speciesCantrips = CharacterRules.SpeciesCantrips(ruleset, subspecies);
		var chosenSpecies = input.Build.SpeciesCantrips;
		if (speciesCantrips > 0 || chosenSpecies.Count > 0)
		{
			CheckSpellList("species", chosenSpecies, new List<Guid>(), speciesCantrips, 0, 0, SpellcastingClass.Wizard, result, spells);
			if (speciesCantrips > 0)
			{
				var mod = result.Modifier(AbilityScore.Intelligence);
				result.Spellcasting.Add(new SpellcastingInfo("species", null, AbilityScore.Intelligence, 8 + result.ProficiencyBonus + mod + spellDc,
					result.ProficiencyBonus + mod + spellAttack, SpellcastingClass.Wizard, speciesCantrips, 0, 0, chosenSpecies, new List<Guid>()));
			}
		}
	}

	///	<summary>
	///	Wizard spellbook (when the character has one): spells of the class list of a level it can cast, at most the
	///	free ones of its levels plus the copied ones, and the prepared spells come from it.
	///	</summary>
	private static void CheckSpellbook(ClassLevelInfo info, SpellcastingClass? list, int maxLevel, ComputedCharacter result, Dictionary<Guid, ContextSpell> spells)
	{
		var build = info.Build;
		if (build.Spellbook.Count == 0)
		{
			return;
		}
		var valid = build.Spellbook.Distinct().Count() == build.Spellbook.Count
			&& build.Spellbook.All(id => spells.TryGetValue(id, out var spell) && spell.Level >= 1 && spell.Level <= maxLevel
				&& (list is null || spell.Classes.Contains(list.Value)))
			&& build.SpellbookCopied.All(build.Spellbook.Contains)
			&& build.Spellbook.Count(id => !build.SpellbookCopied.Contains(id)) <= SpellChangeRules.FreeSpellbookSpells(info.Level)
			&& build.Spells.All(build.Spellbook.Contains);
		if (!valid)
		{
			result.Error(IssueCodes.Spells, info.Class.Name);
		}
	}

	private static void CheckStyleCantrips(ClassLevelInfo info, ComputedCharacter result, Dictionary<Guid, ContextSpell> spells)
	{
		var list = result.Ruleset == RulesetVersion.Dnd5e_2024 ? CharacterRules.StyleAlternativeList(info.Build.FightingStyle) : null;
		var chosen = info.Build.StyleCantrips;
		if (list is null)
		{
			if (chosen.Count > 0)
			{
				result.Error(IssueCodes.FightingStyle, info.Class.Name);
			}
			return;
		}

		CheckSpellList(info.Class.Name, chosen, new List<Guid>(), 2, 0, 0, list, result, spells);
	}

	private static void CheckSpellList(string source, List<Guid> cantrips, List<Guid> leveled, int maxCantrips, int maxSpells, int maxLevel,
		SpellcastingClass? list, ComputedCharacter result, Dictionary<Guid, ContextSpell> spells)
	{
		var valid = cantrips.Distinct().Count() == cantrips.Count && leveled.Distinct().Count() == leveled.Count
			&& cantrips.Count <= maxCantrips && leveled.Count <= maxSpells
			&& cantrips.All(id => spells.TryGetValue(id, out var s) && s.Level == 0 && (list is null || s.Classes.Contains(list.Value)))
			&& leveled.All(id => spells.TryGetValue(id, out var s) && s.Level >= 1 && s.Level <= maxLevel && (list is null || s.Classes.Contains(list.Value)));
		if (!valid)
		{
			result.Error(IssueCodes.Spells, source);
			return;
		}

		var available = spells.Values.Where(s => list is null || s.Classes.Contains(list.Value)).ToList();
		var cantripTarget = Math.Min(maxCantrips, available.Count(s => s.Level == 0));
		var spellTarget = Math.Min(maxSpells, available.Count(s => s.Level >= 1 && s.Level <= maxLevel));
		if (cantrips.Count < cantripTarget)
		{
			result.Todo(IssueCodes.CantripsMissing, source, cantripTarget - cantrips.Count);
		}
		if (leveled.Count < spellTarget)
		{
			result.Todo(IssueCodes.SpellsMissing, source, spellTarget - leveled.Count);
		}
	}

	// ===== Class options: Fighting Style, Divine / Primal Order, Weapon Mastery =====

	private static void ComputeClassOptions(CharacterInput input, ComputedCharacter result, CharacterContextDto context)
	{
		var ruleset = input.Ruleset;
		var items = context.Items.ToDictionary(i => i.Id);

		foreach (var info in result.Classes)
		{
			var build = info.Build;
			var cls = info.Class;

			//	Fighting Style
			var styleLevel = CharacterRules.FightingStyleLevel(cls);
			var hasStyle = styleLevel is { } sl && info.Level >= sl;
			if (!hasStyle)
			{
				if (build.FightingStyle is not null || build.FightingStyleFeatId is not null)
				{
					result.Error(IssueCodes.FightingStyle, cls.Name);
				}
			}
			else if (ruleset == RulesetVersion.Dnd5e_2014)
			{
				if (build.FightingStyleFeatId is not null || (build.FightingStyle is { } key && CharacterRules.FightingStyles2014(cls).All(o => o.Key != key)))
				{
					result.Error(IssueCodes.FightingStyle, cls.Name);
				}
				else if (build.FightingStyle is null)
				{
					result.Todo(IssueCodes.FightingStyleMissing, cls.Name);
				}
			}
			else
			{
				var alternative = CharacterRules.StyleAlternative2024(cls);
				if (build.FightingStyleFeatId is { } styleFeatId)
				{
					var feat = context.Feats.FirstOrDefault(f => f.Id == styleFeatId);
					if (feat is null || feat.Category != FeatCategory.FightingStyle || build.FightingStyle is not null)
					{
						result.Error(IssueCodes.FightingStyle, cls.Name);
					}
					else if (result.Feats.Any(f => f.Feat.Id == feat.Id))
					{
						result.Error(IssueCodes.FeatDuplicate, feat.Name);
					}
					else
					{
						result.Feats.Add(new TakenFeat(feat, $"style:{cls.Id}", new FeatChoice()));
					}
				}
				else if (build.FightingStyle is { } key)
				{
					if (alternative?.Key != key)
					{
						result.Error(IssueCodes.FightingStyle, cls.Name);
					}
				}
				else
				{
					result.Todo(IssueCodes.FightingStyleMissing, cls.Name);
				}
			}

			//	Divine Order / Primal Order (2024, class level 1)
			var orders = ruleset == RulesetVersion.Dnd5e_2024 ? CharacterRules.Orders2024(cls) : Array.Empty<RuleOption>();
			if (build.Order is { } order && orders.All(o => o.Key != order))
			{
				result.Error(IssueCodes.Order, cls.Name);
			}
			else if (orders.Count > 0 && build.Order is null)
			{
				result.Todo(IssueCodes.OrderMissing, cls.Name);
			}

			//	Weapon Mastery (2024)
			var masteries = CharacterRules.WeaponMasteries(cls, ruleset, info.Level);
			var chosen = build.WeaponMasteries;
			var meleeOnly = CharacterRules.MasteryMeleeOnly(cls);
			if (chosen.Count > masteries || chosen.Distinct().Count() != chosen.Count
				|| chosen.Any(id => !items.TryGetValue(id, out var item) || item.Mastery is null || (meleeOnly && item.WeaponRange != WeaponRange.Melee)))
			{
				result.Error(IssueCodes.WeaponMastery, cls.Name);
			}
			else if (chosen.Count < masteries)
			{
				result.Todo(IssueCodes.WeaponMasteryMissing, cls.Name, masteries - chosen.Count);
			}
		}
	}

	// ===== Armor Class, speed, initiative, attacks =====

	private static void ComputeDefenses(CharacterInput input, ComputedCharacter result, CharacterContextDto context, ContextSpecies? species)
	{
		var ruleset = input.Ruleset;
		var items = context.Items.ToDictionary(i => i.Id);
		var equipped = input.Sheet.Inventory
			.Where(i => i.Equipped && i.EquipmentId is not null && items.ContainsKey(i.EquipmentId.Value))
			.Select(i => (Entry: i, Item: items[i.EquipmentId!.Value]))
			.ToList();

		var dex = result.Modifier(AbilityScore.Dexterity);
		var body = equipped.Where(e => e.Item.ArmorCategory is ArmorCategory.Light or ArmorCategory.Medium or ArmorCategory.Heavy && e.Item.ArmorClass is not null)
			.Select(e => e.Item)
			.OrderByDescending(a => a.ArmorClass!.Value + (a.ArmorAddsDexterity ? Math.Min(dex, a.ArmorMaxDexterityBonus ?? dex) : 0))
			.FirstOrDefault();
		var shield = equipped.Select(e => e.Item).Where(i => i.ArmorCategory == ArmorCategory.Shield).OrderByDescending(i => i.ArmorClass ?? 0).FirstOrDefault();
		result.WornArmor = body;
		result.Shield = shield;

		int ac;
		if (body is not null)
		{
			ac = body.ArmorClass!.Value + (body.ArmorAddsDexterity ? Math.Min(dex, body.ArmorMaxDexterityBonus ?? dex) : 0);
		}
		else
		{
			ac = 10 + dex;
			foreach (var info in result.Classes)
			{
				var kind = CharacterRules.UnarmoredDefenseOf(info.Class, info.Subclass, info.Level);
				var value = kind switch
				{
					UnarmoredDefense.Barbarian => 10 + dex + result.Modifier(AbilityScore.Constitution),
					UnarmoredDefense.Monk when shield is null => 10 + dex + result.Modifier(AbilityScore.Wisdom),
					UnarmoredDefense.DraconicBloodline => 13 + dex,
					UnarmoredDefense.DraconicSorcery => 10 + dex + result.Modifier(AbilityScore.Charisma),
					_ => 0
				};
				if (value > ac)
				{
					ac = value;
					result.UnarmoredDefense = kind;
				}
			}
		}

		ac += shield?.ArmorClass ?? 0;

		//	Magic items: +N armor and shields, rings and cloaks; Bracers of Defense only without armor and shield
		ac += MagicItemRules.Sum(input.Sheet, MagicEffectKind.ArmorClass);
		if (body is null && shield is null)
		{
			ac += MagicItemRules.Sum(input.Sheet, MagicEffectKind.UnarmoredArmorClass);
		}

		//	Defense: +1 while wearing armor (2014 Fighting Style or 2024 feat)
		var defense = result.Classes.Any(c => c.Build.FightingStyle == "defense") || result.Feats.Any(f => f.Feat.Key == "defense");
		if (defense && body is not null)
		{
			ac += 1;
		}
		result.ArmorClass = ac + input.Sheet.ArmorClassAdjustment;

		//	Speed: species, Unarmored Movement, Fast Movement, Mobile / Speedy, heavy armor without the Strength
		var speed = result.Subspecies?.Speed ?? species?.Speed ?? 30;
		if (body is null && shield is null)
		{
			speed += CharacterRules.MonkSpeedBonus(result.ClassLevel("monk"));
		}
		if (result.ClassLevel("barbarian") >= 5 && body?.ArmorCategory != ArmorCategory.Heavy)
		{
			speed += 10;
		}
		if (result.Feats.Any(f => f.Feat.Key is "mobile" or "speedy"))
		{
			speed += 10;
		}
		if (body?.StrengthRequirement is { } strength && result.Score(AbilityScore.Strength) < strength && !CharacterRules.IgnoresHeavyArmorSpeed(ruleset, species))
		{
			speed -= 10;
		}
		result.Speed = speed + MagicItemRules.Sum(input.Sheet, MagicEffectKind.Speed) + input.Sheet.SpeedAdjustment;

		//	Initiative: Dexterity, Alert (2014 +5, 2024 Proficiency Bonus), Jack of All Trades
		var initiative = dex + (result.JackOfAllTrades ? result.ProficiencyBonus / 2 : 0);
		if (result.Feats.Any(f => f.Feat.Key == "alert"))
		{
			initiative += ruleset == RulesetVersion.Dnd5e_2024 ? result.ProficiencyBonus : 5;
		}
		result.Initiative = initiative + result.CheckBonusAll + MagicItemRules.Sum(input.Sheet, MagicEffectKind.Initiative) + input.Sheet.InitiativeAdjustment;

		var observant = ruleset == RulesetVersion.Dnd5e_2014 && result.Feats.Any(f => f.Feat.Key == "observant") ? 5 : 0;
		result.PassivePerception = 10 + result.SkillBonus(Skill.Perception) + observant;

		//	Attacks with the equipped weapons
		var archery = result.Classes.Any(c => c.Build.FightingStyle == "archery") || result.Feats.Any(f => f.Feat.Key == "archery");
		foreach (var (entry, item) in equipped.Where(e => e.Item.Category == EquipmentCategory.Weapon && e.Item.DamageDice is not null))
		{
			var str = result.Modifier(AbilityScore.Strength);
			var ranged = item.WeaponRange == WeaponRange.Ranged;
			var mod = item.WeaponProperties.Contains(WeaponProperty.Finesse) ? Math.Max(str, dex) : ranged ? dex : str;
			var proficient = IsProficient(item, result);
			var magic = MagicItemRules.WeaponBonus(entry);
			var bonus = mod + magic + (proficient ? result.ProficiencyBonus : 0) + (archery && ranged ? 2 : 0);
			var damage = $"{item.DamageDice}{FormatBonus(mod + magic)}";
			var versatile = item.VersatileDamageDice is { } v ? $"{v}{FormatBonus(mod + magic)}" : null;
			result.Attacks.Add(new AttackInfo(entry.Id, item, bonus, damage, item.DamageType, proficient, versatile));
		}
	}

	private static string FormatBonus(int mod) => mod == 0 ? string.Empty : mod > 0 ? $"+{mod}" : $"−{-mod}";

	public static bool IsProficient(ContextItem weapon, ComputedCharacter result)
	{
		var name = weapon.EnglishName.Trim().ToLowerInvariant();
		if (result.MartialWeapons)
		{
			return true;
		}

		foreach (var info in result.Classes)
		{
			if (!info.Starting)
			{
				continue;
			}

			var list = CharacterRules.WeaponList(info.Class, result.Ruleset);
			if (weapon.WeaponCategory == WeaponCategory.Simple && (list is null || list.Contains(name)))
			{
				return true;
			}
			if (CharacterRules.ExtraWeapons(info.Class, result.Ruleset).Contains(name))
			{
				return true;
			}
			var properties = CharacterRules.MartialWithProperties(info.Class, result.Ruleset);
			if (weapon.WeaponCategory == WeaponCategory.Martial && properties.Any(weapon.WeaponProperties.Contains))
			{
				return true;
			}
		}

		return false;
	}

	// ===== Starting equipment =====

	private static void CheckEquipment(CharacterBuild build, ComputedCharacter result, CharacterContextDto context, ContextBackground? background, ContextClass? cls)
	{
		var items = context.Items.ToDictionary(i => i.Id);
		var picks = build.EquipmentPicks.ToDictionary(p => p.Slot, p => p.Items);
		var used = new HashSet<string>();

		//	Background: option A/B when there is a gold alternative, nothing to choose otherwise
		var bg = background?.Equipment ?? ContextLoadout.Empty;
		if (bg.Kits.Count > 0 ? bg.Kits.All(k => k.Letter != build.BackgroundEquipment) : build.BackgroundEquipment is not null)
		{
			result.Error(IssueCodes.Equipment, "background");
		}
		else
		{
			foreach (var (slot, item) in ChosenOptions("background", bg, build.BackgroundEquipment is null ? new List<string>() : new List<string> { build.BackgroundEquipment }))
			{
				CheckPick(slot, item, picks, used, items, result);
			}
		}

		var loadout = cls?.Equipment ?? ContextLoadout.Empty;
		var choice = build.ClassEquipment;
		var valid = loadout.IsEmpty
			? choice.Count == 0
			: loadout.Kits.Count > 0
				? choice.Count == 1 && loadout.Kits.Any(k => k.Letter == choice[0])
				: choice.Count == loadout.Rows.Count && loadout.Rows.Select((row, i) =>
					row.Options.Count == 1 ? choice[i] == string.Empty : row.Options.Any(o => o.Letter == choice[i])).All(ok => ok);
		if (!valid)
		{
			result.Error(IssueCodes.Equipment, "class");
		}
		else
		{
			foreach (var (slot, item) in ChosenOptions("class", loadout, choice))
			{
				CheckPick(slot, item, picks, used, items, result);
			}
		}

		if (picks.Keys.Any(k => !used.Contains(k)))
		{
			result.Error(IssueCodes.Equipment, "picks");
		}
	}

	private static void CheckPick(string slot, ContextLoadoutItem item, Dictionary<string, List<Guid>> picks, HashSet<string> used,
		Dictionary<Guid, ContextItem> items, ComputedCharacter result)
	{
		if (item.Pick is not { } pick)
		{
			return;
		}

		if (!picks.TryGetValue(slot, out var chosen))
		{
			result.Todo(IssueCodes.Equipment, slot);
			return;
		}

		used.Add(slot);

		//	Guid.Empty keeps the place of an item not picked yet
		var picked = chosen.Where(id => id != Guid.Empty).ToList();
		if (chosen.Count > pick.Count || !picked.All(id => items.TryGetValue(id, out var it) && Matches(pick, it)))
		{
			result.Error(IssueCodes.Equipment, slot);
		}
		else if (picked.Count < pick.Count)
		{
			result.Todo(IssueCodes.Equipment, slot);
		}
	}

	public static bool Matches(LoadoutPick pick, ContextItem item) => pick.Kind switch
	{
		LoadoutPickKind.SimpleWeapon => item.Category == EquipmentCategory.Weapon && item.WeaponCategory == WeaponCategory.Simple && (!pick.MeleeOnly || item.WeaponRange == WeaponRange.Melee),
		LoadoutPickKind.MartialWeapon => item.Category == EquipmentCategory.Weapon && item.WeaponCategory == WeaponCategory.Martial && (!pick.MeleeOnly || item.WeaponRange == WeaponRange.Melee),
		LoadoutPickKind.MusicalInstrument => item.Category == EquipmentCategory.Tool && item.ToolCategory == ToolCategory.MusicalInstrument,
		_ => false
	};

	///	<summary>
	///	The items of the chosen options, with their slot ("class/row/option/item").
	///	</summary>
	public static IEnumerable<(string Slot, ContextLoadoutItem Item)> ChosenOptions(string prefix, ContextLoadout loadout, IReadOnlyList<string> choice)
	{
		if (loadout.Kits.Count > 0)
		{
			var index = choice.Count > 0 ? loadout.Kits.FindIndex(k => k.Letter == choice[0]) : -1;
			if (index < 0)
			{
				yield break;
			}
			for (var i = 0; i < loadout.Kits[index].Items.Count; i++)
			{
				yield return ($"{prefix}/0/{index}/{i}", loadout.Kits[index].Items[i]);
			}
			yield break;
		}

		for (var r = 0; r < loadout.Rows.Count; r++)
		{
			var row = loadout.Rows[r];
			var o = row.Options.Count == 1 ? 0 : (r < choice.Count ? row.Options.FindIndex(x => x.Letter == choice[r]) : -1);
			if (o < 0)
			{
				continue;
			}
			for (var i = 0; i < row.Options[o].Items.Count; i++)
			{
				yield return ($"{prefix}/{r}/{o}/{i}", row.Options[o].Items[i]);
			}
		}
	}
}
