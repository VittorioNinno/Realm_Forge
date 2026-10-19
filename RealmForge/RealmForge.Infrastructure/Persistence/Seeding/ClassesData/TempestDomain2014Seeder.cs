using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Tempest Domain (cleric, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class TempestDomain2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "tempest-domain");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Cleric2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "tempest-domain", "en"), Language = LanguageCode.En, Name = "Tempest Domain", Description = "Gods of the tempest rule over storms, the sea and the sky: lords of thunder and lightning, of earthquakes and some fires, and gods of strength, violence and courage. In some pantheons the tempest god reigns over the other deities and delivers swift justice with thunderbolts; among seafaring peoples, these gods guard the oceans and the sailors who cross them. Their clerics often stir up fear in common folk, to keep them on a righteous path or to urge offerings that will turn divine anger aside." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "tempest-domain", "it"), Language = LanguageCode.It, Name = "Dominio della Tempesta", Description = "Gli dèi della tempesta regnano su burrasche, mare e cielo: signori del tuono e del fulmine, dei terremoti e di alcuni fuochi, e dèi della forza, della violenza e del coraggio. In alcuni pantheon il dio della tempesta domina sulle altre divinità e amministra una giustizia rapida a colpi di folgore; presso i popoli di navigatori, questi dèi proteggono gli oceani e i marinai che li attraversano. I loro chierici spesso incutono timore nella gente comune, per mantenerla sulla retta via o per spingerla a offerte che allontanino l'ira divina." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/tempest-domain-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/tempest-domain-spells", "en"), Language = LanguageCode.En, Name = "Tempest Domain Spells", Description = "You gain these domain spells at the cleric levels shown. See the Divine Domain class feature for how domain spells work.\n\n| Cleric Level | Spells |\n|---|---|\n| 1st | fog cloud, thunderwave |\n| 3rd | gust of wind, shatter |\n| 5th | call lightning, sleet storm |\n| 7th | control water, ice storm |\n| 9th | destructive wave, insect plague |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/tempest-domain-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Dominio della Tempesta", Description = "Il chierico ottiene questi incantesimi di dominio ai livelli da chierico indicati. Il funzionamento degli incantesimi di dominio è descritto nel privilegio di classe Dominio Divino.\n\n| Livello da chierico | Incantesimi |\n|---|---|\n| 1° | nube di nebbia, onda tonante |\n| 3° | folata di vento, frantumare |\n| 5° | invocare il fulmine, tempesta di nevischio |\n| 7° | controllare acqua, tempesta di ghiaccio |\n| 9° | onda distruttiva, piaga degli insetti |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/bonus-proficiencies"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/bonus-proficiencies", "en"), Language = LanguageCode.En, Name = "Bonus Proficiencies", Description = "At 1st level, you become proficient with martial weapons and heavy armor." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/bonus-proficiencies", "it"), Language = LanguageCode.It, Name = "Competenze Bonus", Description = "Al 1° livello il chierico ottiene competenza nelle armi da guerra e nelle armature pesanti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/wrath-of-the-storm"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/wrath-of-the-storm", "en"), Language = LanguageCode.En, Name = "Wrath of the Storm", Description = "Also at 1st level, you can answer blows with thunder. When a creature you can see within 5 feet of you hits you with an attack, you can use your reaction to force it to make a Dexterity saving throw. It takes 2d8 lightning or thunder damage (your choice) on a failure, or half as much on a success.\n\nYou can use this feature a number of times equal to your Wisdom modifier (at least once), and you regain all uses when you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/wrath-of-the-storm", "it"), Language = LanguageCode.It, Name = "Collera della Tempesta", Description = "Sempre al 1° livello, il chierico può rispondere ai colpi con il tuono. Quando una creatura entro 1,5 metri che il chierico è in grado di vedere lo colpisce con un attacco, il chierico può usare la sua reazione per costringerla a effettuare un tiro salvezza su Destrezza. Se lo fallisce subisce 2d8 danni da fulmine o da tuono (a scelta del chierico), se lo supera la metà.\n\nIl chierico può usare questo privilegio un numero di volte pari al suo modificatore di Saggezza (almeno una volta) e recupera tutti gli utilizzi quando completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/channel-divinity-destructive-wrath"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/channel-divinity-destructive-wrath", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Destructive Wrath", Description = "From 2nd level, you can unleash the full fury of the storm. When you roll lightning or thunder damage, you can use your Channel Divinity to deal the maximum damage instead of rolling." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/channel-divinity-destructive-wrath", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Collera Distruttiva", Description = "Dal 2° livello il chierico può scatenare tutta la furia della tempesta. Quando tira danni da fulmine o da tuono, può usare Incanalare Divinità per infliggere il massimo dei danni invece di tirarli." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/thunderbolt-strike"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/thunderbolt-strike", "en"), Language = LanguageCode.En, Name = "Thunderbolt Strike", Description = "From 6th level, when you deal lightning damage to a Large or smaller creature, you can also push it up to 10 feet away from you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/thunderbolt-strike", "it"), Language = LanguageCode.It, Name = "Colpo del Tuono e del Fulmine", Description = "Dal 6° livello, quando infligge danni da fulmine a una creatura di taglia Grande o inferiore, il chierico può anche spingerla fino a 3 metri lontano da sé." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/divine-strike"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 8,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/divine-strike", "en"), Language = LanguageCode.En, Name = "Divine Strike", Description = "At 8th level, divine power flows into your weapon. Once on each of your turns when you hit a creature with a weapon attack, you can deal an extra 1d8 thunder damage to it. The extra damage becomes 2d8 at 14th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/divine-strike", "it"), Language = LanguageCode.It, Name = "Colpo Divino", Description = "All'8° livello il potere divino fluisce nell'arma del chierico. Una volta in ognuno dei suoi turni, quando colpisce una creatura con un attacco con un'arma, può infliggerle 1d8 danni da tuono extra. I danni extra diventano 2d8 al 14° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/stormborn"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/stormborn", "en"), Language = LanguageCode.En, Name = "Stormborn", Description = "At 17th level, whenever you are neither underground nor indoors, you have a flying speed equal to your current walking speed." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "tempest-domain/stormborn", "it"), Language = LanguageCode.It, Name = "Nato dalla Tempesta", Description = "Al 17° livello, ogni volta che non si trova sottoterra o al chiuso, il chierico ha una velocità di volare pari alla sua velocità sul terreno attuale." }
					}
				}
			}
		};
	}
}
