using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Light Domain (cleric, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class LightDomain2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "light-domain");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Cleric2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "light-domain", "en"), Language = LanguageCode.En, Name = "Light Domain", Description = "Clerics of the Light Domain carry the divine power of flame and revelation. Filled with radiance and with the clear sight of their gods, they are sent to drive out falsehood and burn the shadows away. Their patrons are deities of truth, vigilance, beauty, insight and renewal: some steer the sun across the sky, others are watchful sentinels who see through every deception." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "light-domain", "it"), Language = LanguageCode.It, Name = "Dominio della Luce", Description = "I chierici del Dominio della Luce portano con sé il potere divino della fiamma e della rivelazione. Colmi di radiosità e della vista limpida dei loro dei, hanno il compito di scacciare la menzogna e di bruciare le ombre. I loro patroni sono divinità della verità, della vigilanza, della bellezza, della perspicacia e del rinnovamento: alcune guidano il sole attraverso il cielo, altre sono sentinelle attente che smascherano ogni inganno." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/light-domain-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/light-domain-spells", "en"), Language = LanguageCode.En, Name = "Light Domain Spells", Description = "Your bond with this domain keeps certain spells always at hand: from the Cleric level shown in the table below onward, the listed spells are always prepared for you.\n\n| Cleric Level | Prepared Spells |\n|---|---|\n| 3 | *Burning Hands*, *Faerie Fire*, *Scorching Ray*, *See Invisibility* |\n| 5 | *Daylight*, *Fireball* |\n| 7 | *Arcane Eye*, *Wall of Fire* |\n| 9 | *Flame Strike*, *Scrying* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/light-domain-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Dominio della Luce", Description = "Grazie al legame con il suo dominio, il chierico ha sempre a disposizione alcuni incantesimi: dal livello da chierico indicato nella tabella seguente, gli incantesimi elencati sono sempre preparati per lui.\n\n| Livello da chierico | Incantesimi preparati |\n|---|---|\n| 3 | *luminescenza*, *mani brucianti*, *raggio rovente*, *vedere invisibilità* |\n| 5 | *luce diurna*, *palla di fuoco* |\n| 7 | *muro di fuoco*, *occhio arcano* |\n| 9 | *colpo infuocato*, *scrutare* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/radiance-of-the-dawn"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/radiance-of-the-dawn", "en"), Language = LanguageCode.En, Name = "Radiance of the Dawn", Description = "As a Magic action, you raise your Holy Symbol and spend a use of Channel Divinity to release a burst of light in a 30-foot Emanation centered on you. Any magical Darkness in the area, such as that of the *Darkness* spell, is dispelled. Each creature of your choice in the area makes a Constitution saving throw, taking Radiant damage equal to 2d10 plus your Cleric level on a failure, or half that on a success." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/radiance-of-the-dawn", "it"), Language = LanguageCode.It, Name = "Fulgore dell'Alba", Description = "Con un'azione di Magia, il chierico solleva il suo simbolo sacro e spende un utilizzo di Incanalare Divinità per sprigionare un lampo di luce in un'emanazione di 9 metri centrata su di sé. Ogni oscurità magica presente nell'area, come quella creata dall'incantesimo *oscurità*, viene dissolta. Inoltre, ogni creatura a sua scelta nell'area effettua un tiro salvezza su Costituzione: se lo fallisce subisce danni radiosi pari a 2d10 + il livello da chierico, se lo supera ne subisce la metà." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/warding-flare"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/warding-flare", "en"), Language = LanguageCode.En, Name = "Warding Flare", Description = "When a creature you can see within 30 feet of you makes an attack roll, you can use your Reaction to make light blaze up before the attack lands or misses, giving that roll Disadvantage.\n\nYou can use this feature a number of times equal to your Wisdom modifier (at least once), and you regain every expended use after a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/warding-flare", "it"), Language = LanguageCode.It, Name = "Bagliore di Interdizione", Description = "Quando una creatura che il chierico è in grado di vedere entro 9 metri da lui effettua un tiro per colpire, il chierico può usare una reazione per far divampare un lampo di luce prima che l'attacco vada a segno o fallisca, imponendo svantaggio a quel tiro.\n\nIl chierico può usare questo privilegio un numero di volte pari al suo modificatore di Saggezza (minimo una volta) e recupera tutti gli utilizzi spesi quando completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/improved-warding-flare"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/improved-warding-flare", "en"), Language = LanguageCode.En, Name = "Improved Warding Flare", Description = "Your expended uses of Warding Flare now return after either a Short or a Long Rest.\n\nAlso, each time you use Warding Flare, the creature targeted by the attack can gain Temporary Hit Points equal to 2d6 plus your Wisdom modifier." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/improved-warding-flare", "it"), Language = LanguageCode.It, Name = "Bagliore di Interdizione Migliorato", Description = "Da questo livello gli utilizzi di Bagliore di interdizione tornano disponibili dopo qualsiasi riposo, breve o lungo.\n\nIn più, a ogni Bagliore di interdizione la creatura presa di mira dall'attacco può ricevere 2d6 + il modificatore di Saggezza del chierico in punti ferita temporanei." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/corona-of-light"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/corona-of-light", "en"), Language = LanguageCode.En, Name = "Corona of Light", Description = "As a Magic action, you wrap yourself in an aura of sunlight for 1 minute or until you end it (no action required). The aura casts Bright Light out to 60 feet and Dim Light a further 30 feet. Any enemy inside the Bright Light rolls with Disadvantage when saving against your Radiance of the Dawn or against spells that deal Fire or Radiant damage.\n\nYou can use this feature a number of times equal to your Wisdom modifier (at least once), and you regain every expended use after a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "light-domain/corona-of-light", "it"), Language = LanguageCode.It, Name = "Corona di Luce", Description = "Con un'azione di Magia, il chierico si avvolge in un alone di luce del sole per 1 minuto, oppure finché non decide di spegnerlo (senza bisogno di azioni). L'alone emana luce intensa fino a 18 metri e luce fioca per ulteriori 9 metri. Ogni nemico immerso nella luce intensa tira con svantaggio i tiri salvezza contro il Fulgore dell'alba del chierico e contro gli incantesimi che infliggono danni da fuoco o radiosi.\n\nGli utilizzi di questo privilegio sono pari al modificatore di Saggezza del chierico (almeno uno) e tornano tutti disponibili dopo un riposo lungo." }
					}
				}
			}
		};
	}
}
