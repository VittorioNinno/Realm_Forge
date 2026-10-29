using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Campaigns;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Monsters;

namespace RealmForge.Tests;

public class MonsterTests
{
	private static readonly IReadOnlyList<Monster> Monsters = MonsterSeeder.GetDefinitions();

	private static MonsterTranslation Tr(Monster m, LanguageCode lang) => m.Translations.Single(t => t.Language == lang);

	private static Monster ByEnglishName(string name) => Monsters.Single(m => Tr(m, LanguageCode.En).Name == name);

	[Fact]
	public void The_2014_monsters_are_the_Monster_Manual_statblocks()
	{
		//	SRD 5.1: 317 statblocks (lycanthropes and the vampire as one statblock each, like the book) plus the variants
		//	of the swarm of insects (beetles, centipedes, spiders, wasps) and the diseased giant rat
		Assert.Equal(441, Monsters.Count);
		Assert.Equal(322, Monsters.Count(m => m.Source == ContentSource.Srd51));

		//	The Monster Manual outside the SRD, texts written for RealmForge: 117 statblocks plus the cave bear and the
		//	psychic gray ooze, variants of SRD statblocks
		Assert.Equal(119, Monsters.Count(m => m.Source == ContentSource.RealmForge));
		Assert.Equal(13, Monsters.Count(m => m.VariantOfId is not null));
		Assert.All(Monsters, m => Assert.True(m.IsOfficialSRD));
		Assert.All(Monsters, m => Assert.Contains(m.Source, new[] { ContentSource.Srd51, ContentSource.RealmForge }));
		Assert.All(Monsters, m => Assert.Equal(RulesetVersion.Dnd5e_2014, m.Ruleset));
	}

	[Fact]
	public void Every_statblock_is_complete_in_both_languages()
	{
		var ids = Monsters.Select(m => m.Id).ToHashSet();
		foreach (var m in Monsters)
		{
			Assert.Equal(new[] { LanguageCode.En, LanguageCode.It }, m.Translations.Select(t => t.Language).OrderBy(l => l));
			Assert.True(MonsterMath.IsChallenge(m.ChallengeRating), m.Id.ToString());
			//	Challenge 0 without attacks is worth 0 XP (frog, sea horse)
			Assert.True(m.Xp == MonsterMath.XpFor(m.ChallengeRating) || (m.ChallengeRating == 0 && m.Xp == 0), m.Id.ToString());
			Assert.Equal(MonsterMath.ProficiencyFor(m.ChallengeRating), m.ProficiencyBonus);
			Assert.InRange(m.ArmorClass, 5, 25);
			Assert.InRange(m.HitPoints, 1, 676);
			Assert.All(new[] { m.Strength, m.Dexterity, m.Constitution, m.Intelligence, m.Wisdom, m.Charisma }, a => Assert.InRange(a, 1, 30));

			//	The hit points are the average of their dice, except the demilich (and Acererak), which always has the maximum
			if (Tr(m, LanguageCode.En).Name is "Demilich" or "Acererak")
			{
				Assert.Equal(80, m.HitPoints);
			}
			else
			{
				Assert.Equal(m.HitPoints, MonsterMath.Average(m.HitDice));
			}

			foreach (var tr in m.Translations)
			{
				var label = $"{tr.Name} ({tr.Language})";
				Assert.False(string.IsNullOrWhiteSpace(tr.Name), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.Subtitle), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.ArmorClass), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.Speed), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.Senses), label);
				Assert.False(string.IsNullOrWhiteSpace(tr.Actions + tr.Traits), label);
				Assert.StartsWith(m.ArmorClass.ToString(), tr.ArmorClass);
				Assert.DoesNotContain("Rivendita", tr.Traits + tr.Actions);
			}
			if (m.VariantOfId is { } original)
			{
				Assert.Contains(original, ids);
			}
		}

		//	Names are unique within a language
		foreach (var lang in new[] { LanguageCode.It, LanguageCode.En })
		{
			var names = Monsters.Select(m => Tr(m, lang).Name).ToList();
			Assert.Equal(names.Count, names.Distinct(StringComparer.OrdinalIgnoreCase).Count());
		}
	}

	[Fact]
	public void Statblocks_keep_the_official_names_and_numbers()
	{
		var dragon = ByEnglishName("Adult Red Dragon");
		Assert.Equal("Drago rosso adulto", Tr(dragon, LanguageCode.It).Name);
		Assert.Equal(19, dragon.ArmorClass);
		Assert.Equal(256, dragon.HitPoints);
		Assert.Equal(17m, dragon.ChallengeRating);
		Assert.Equal(18000, dragon.Xp);
		Assert.Contains("***Soffio di fuoco (ricarica 5–6).***", Tr(dragon, LanguageCode.It).Actions);
		Assert.StartsWith("Il drago può eseguire 3 azioni leggendarie", Tr(dragon, LanguageCode.It).LegendaryActions);
		Assert.StartsWith("The dragon can take 3 legendary actions", Tr(dragon, LanguageCode.En).LegendaryActions);

		//	Manuale dei Mostri names kept as alias when the Italian SRD names differ
		Assert.Equal("Drow", Tr(ByEnglishName("Drow"), LanguageCode.It).Alias);

		//	One statblock for every form of a lycanthrope, with the form of each action
		var werewolf = ByEnglishName("Werewolf");
		Assert.Contains("***Bite (Wolf or Hybrid Form Only).***", Tr(werewolf, LanguageCode.En).Actions);
		Assert.Equal("Perception +4, Stealth +3", Tr(werewolf, LanguageCode.En).Skills);

		//	The Manuale dei Mostri names equal the SRD ones for the skeletons, so no alias
		Assert.Null(Tr(ByEnglishName("Warhorse Skeleton"), LanguageCode.It).Alias);
		Assert.Null(Tr(ByEnglishName("Minotaur Skeleton"), LanguageCode.It).Alias);

		var rat = ByEnglishName("Giant Rat (Diseased)");
		Assert.Equal(ByEnglishName("Giant Rat").Id, rat.VariantOfId);
		Assert.Equal("Topo gigante contagioso", Tr(rat, LanguageCode.It).Name);
	}

	[Fact]
	public void Monster_Manual_statblocks_outside_the_SRD()
	{
		var beholder = ByEnglishName("Beholder");
		Assert.Equal(ContentSource.RealmForge, beholder.Source);
		Assert.Equal("Beholder", Tr(beholder, LanguageCode.It).Name);
		Assert.Equal(18, beholder.ArmorClass);
		Assert.Equal(180, beholder.HitPoints);
		Assert.Equal(13m, beholder.ChallengeRating);
		Assert.Equal(10000, beholder.Xp);
		Assert.False(string.IsNullOrWhiteSpace(Tr(beholder, LanguageCode.It).LegendaryActions));

		//	Official Italian names from the Manuale dei Mostri
		Assert.Equal("Vermeiena", Tr(ByEnglishName("Carrion Crawler"), LanguageCode.It).Name);
		Assert.Equal("Cuspide letale", Tr(ByEnglishName("Piercer"), LanguageCode.It).Name);
		Assert.Equal("Yuan-ti sanguepuro", Tr(ByEnglishName("Yuan-ti Pureblood"), LanguageCode.It).Name);
		Assert.Equal("Mostruosità Media (mutaforma, yuan-ti), neutrale malvagio", Tr(ByEnglishName("Yuan-ti Malison"), LanguageCode.It).Subtitle);

		//	Variants of other statblocks, SRD ones included
		Assert.Equal(ByEnglishName("Specter").Id, ByEnglishName("Poltergeist").VariantOfId);
		Assert.Equal(ByEnglishName("Mind Flayer").Id, ByEnglishName("Mind Flayer Arcanist").VariantOfId);
		var cave = ByEnglishName("Cave Bear");
		Assert.Equal(ByEnglishName("Polar Bear").Id, cave.VariantOfId);
		Assert.StartsWith("darkvision 60 ft.", Tr(cave, LanguageCode.En).Senses);
		Assert.Equal(6, ByEnglishName("Psychic Gray Ooze").Intelligence);

		//	Spells with their Italian names, proper names capitalized
		Assert.Contains("*disco fluttuante di Tenser*", Tr(ByEnglishName("Arcanaloth"), LanguageCode.It).Traits);
		Assert.Contains("*tentacoli neri di Evard*", Tr(ByEnglishName("Drow Mage"), LanguageCode.It).Traits);

		//	Notes on the variants written in the description
		Assert.Contains("gythka", Tr(ByEnglishName("Thri-kreen"), LanguageCode.En).Description);
	}

	[Fact]
	public void Challenge_numbers()
	{
		Assert.Equal("1/8", MonsterMath.FormatChallenge(0.125m));
		Assert.Equal("1/2", MonsterMath.FormatChallenge(0.5m));
		Assert.Equal("12", MonsterMath.FormatChallenge(12m));
		Assert.Equal(1800, MonsterMath.XpFor(5m));
		Assert.Equal(0, MonsterMath.XpFor(0.3m));
		Assert.Equal("17 (18.000 PE)", MonsterMath.ChallengeLine(17m, 18000, LanguageCode.It));
		Assert.Equal("1/4 (50 XP)", MonsterMath.ChallengeLine(0.25m, 50, LanguageCode.En));
		Assert.Equal(-1, MonsterMath.Modifier(8));
		Assert.Equal(-1, MonsterMath.Modifier(9));
		Assert.Equal(3, MonsterMath.Modifier(17));
		Assert.Equal(22, MonsterMath.Average("5d8"));
		Assert.Equal(256, MonsterMath.Average("19d12 + 133"));
		Assert.Equal(5, MonsterMath.Average("2d6 - 2"));
		Assert.Null(MonsterMath.Average("lots"));
	}

	[Fact]
	public void Encounter_difficulty_2014_uses_the_multiplier()
	{
		//	Four level-3 characters: 300 / 600 / 900 / 1600
		var party = new[] { 3, 3, 3, 3 };
		Assert.Equal(new[] { 300, 600, 900, 1600 }, EncounterMath.Thresholds(RulesetVersion.Dnd5e_2014, party));

		//	Four goblins (50 XP each): 200 × 2 = 400, easy
		var goblins = EncounterMath.Evaluate(RulesetVersion.Dnd5e_2014, party, new[] { 50, 50, 50, 50 });
		Assert.Equal(200, goblins.TotalXp);
		Assert.Equal(2, goblins.Multiplier);
		Assert.Equal(400, goblins.AdjustedXp);
		Assert.Equal(1, goblins.Rating);
		Assert.Equal(50, goblins.XpPerCharacter(4));

		//	A small party counts one step more, a big one one step less
		Assert.Equal(1.5, EncounterMath.Multiplier(1, 2));
		Assert.Equal(0.5, EncounterMath.Multiplier(1, 6));
		Assert.Equal(4, EncounterMath.Multiplier(15, 4));
		Assert.Equal(5, EncounterMath.Multiplier(15, 1));

		//	An ogre (450) for one level-1 character: deadly
		Assert.Equal(4, EncounterMath.Evaluate(RulesetVersion.Dnd5e_2014, new[] { 1 }, new[] { 450 }).Rating);
	}

	[Fact]
	public void Encounter_difficulty_2024_uses_the_plain_total()
	{
		var party = new[] { 5, 5, 5, 5 };
		Assert.Equal(new[] { 2000, 3000, 4400 }, EncounterMath.Thresholds(RulesetVersion.Dnd5e_2024, party));
		var result = EncounterMath.Evaluate(RulesetVersion.Dnd5e_2024, party, new[] { 1100, 1100, 1100 });
		Assert.Equal(1, result.Multiplier);
		Assert.Equal(3300, result.AdjustedXp);
		Assert.Equal(2, result.Rating);
	}

	[Fact]
	public void Encounters_follow_the_roles()
	{
		Assert.True(EncounterRules.CanManage(CampaignRole.CoMaster));
		Assert.False(EncounterRules.CanManage(CampaignRole.Player));
		Assert.False(EncounterRules.CanSee(CampaignRole.Player, EncounterStatus.Planned, shown: true));
		Assert.False(EncounterRules.CanSee(CampaignRole.Player, EncounterStatus.Running, shown: false));
		Assert.True(EncounterRules.CanSee(CampaignRole.Player, EncounterStatus.Running, shown: true));
		Assert.True(EncounterRules.CanSee(CampaignRole.Master, EncounterStatus.Planned, shown: false));

		Assert.Equal(CombatantHealth.Unharmed, EncounterRules.HealthOf(20, 20));
		Assert.Equal(CombatantHealth.Wounded, EncounterRules.HealthOf(11, 20));
		Assert.Equal(CombatantHealth.Bloodied, EncounterRules.HealthOf(10, 20));
		Assert.Equal(CombatantHealth.Down, EncounterRules.HealthOf(0, 20));

		var order = EncounterRules.Order(new[]
		{
			new EncounterCombatant { Name = "B", Initiative = 12, InitiativeBonus = 1 },
			new EncounterCombatant { Name = "A", Initiative = null },
			new EncounterCombatant { Name = "C", Initiative = 12, InitiativeBonus = 3 },
			new EncounterCombatant { Name = "D", Initiative = 18 }
		});
		Assert.Equal(new[] { "D", "C", "B", "A" }, order.Select(c => c.Name));
	}
}
