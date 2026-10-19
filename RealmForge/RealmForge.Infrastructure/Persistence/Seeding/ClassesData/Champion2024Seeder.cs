using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Champion (fighter, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Champion2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "champion");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Fighter2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "champion", "en"), Language = LanguageCode.En, Name = "Champion", Description = "A Champion focuses on the development of martial prowess in a relentless pursuit of victory. Champions combine rigorous training with physical excellence to deal devastating blows, withstand peril, and garner glory. Whether in athletic contests or bloody battle, Champions strive for the crown of the victor." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "champion", "it"), Language = LanguageCode.It, Name = "Campione", Description = "Il campione si dedica allo sviluppo dell'abilità marziale nell'inseguimento incessante della vittoria. Unisce un addestramento rigoroso all'eccellenza fisica per sferrare colpi devastanti, resistere al pericolo e conquistare la gloria. Che si tratti di gare atletiche o di battaglie sanguinose, il campione aspira alla corona del vincitore." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/improved-critical"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/improved-critical", "en"), Language = LanguageCode.En, Name = "Improved Critical", Description = "Your attack rolls with weapons and Unarmed Strikes can score a Critical Hit on a roll of 19 or 20 on the d20." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/improved-critical", "it"), Language = LanguageCode.It, Name = "Critico Migliorato", Description = "I tiri per colpire del guerriero con le armi e con i colpi senz'armi infliggono un colpo critico con un risultato di 19 o 20 sul d20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/remarkable-athlete"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/remarkable-athlete", "en"), Language = LanguageCode.En, Name = "Remarkable Athlete", Description = "Thanks to your athleticism, you have Advantage on Initiative rolls and Strength (Athletics) checks.\n\nIn addition, immediately after you score a Critical Hit, you can move up to half your Speed without provoking Opportunity Attacks." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/remarkable-athlete", "it"), Language = LanguageCode.It, Name = "Atleta Straordinario", Description = "La prestanza fisica del guerriero gli conferisce vantaggio sia ai tiri per l'iniziativa sia alle prove di Forza (Atletica).\n\nIn più, appena mette a segno un colpo critico, può spostarsi di un massimo pari a metà della propria velocità senza che questo movimento provochi attacchi di opportunità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/additional-fighting-style"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/additional-fighting-style", "en"), Language = LanguageCode.En, Name = "Additional Fighting Style", Description = "You gain another Fighting Style feat of your choice." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/additional-fighting-style", "it"), Language = LanguageCode.It, Name = "Stile di Combattimento Aggiuntivo", Description = "Il guerriero ottiene un altro talento Stile di combattimento a sua scelta." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/heroic-warrior"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/heroic-warrior", "en"), Language = LanguageCode.En, Name = "Heroic Warrior", Description = "The thrill of battle drives you toward victory. During combat, you can give yourself Heroic Inspiration whenever you start your turn without it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/heroic-warrior", "it"), Language = LanguageCode.It, Name = "Guerriero Eroico", Description = "L'ebbrezza della battaglia spinge il guerriero verso la vittoria. Durante un combattimento, ogni volta che inizia il suo turno senza Ispirazione eroica, può conferirsela." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/superior-critical"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/superior-critical", "en"), Language = LanguageCode.En, Name = "Superior Critical", Description = "Your attack rolls with weapons and Unarmed Strikes can now score a Critical Hit on a roll of 18–20 on the d20." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/superior-critical", "it"), Language = LanguageCode.It, Name = "Critico Superiore", Description = "I tiri per colpire del guerriero con le armi e con i colpi senz'armi ora infliggono un colpo critico con un risultato da 18 a 20 sul d20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/survivor"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/survivor", "en"), Language = LanguageCode.En, Name = "Survivor", Description = "You attain the pinnacle of resilience in battle, giving you these benefits.\n\n**Defy Death.** You have Advantage on Death Saving Throws. Moreover, when you roll 18–20 on a Death Saving Throw, you gain the benefit of rolling a 20 on it.\n\n**Heroic Rally.** At the start of each of your turns, you regain Hit Points equal to 5 plus your Constitution modifier if you are Bloodied and have at least 1 Hit Point." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "champion/survivor", "it"), Language = LanguageCode.It, Name = "Sopravvissuto", Description = "Il guerriero raggiunge l'apice della resistenza in battaglia e ottiene i benefici seguenti.\n\n**Sfuggire alla morte.** Il guerriero dispone di vantaggio ai tiri salvezza contro la morte. Inoltre, quando ottiene un risultato da 18 a 20 in un tiro salvezza contro la morte, beneficia degli effetti di un 20.\n\n**Incoraggiamento eroico.** All'inizio di ognuno dei suoi turni, se è sanguinante e ha almeno 1 punto ferita, il guerriero recupera un numero di punti ferita pari a 5 + il suo modificatore di Costituzione." }
					}
				}
			}
		};
	}
}
