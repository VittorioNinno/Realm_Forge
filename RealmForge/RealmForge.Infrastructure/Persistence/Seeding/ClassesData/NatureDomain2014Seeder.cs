using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Nature Domain (cleric, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class NatureDomain2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "nature-domain");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "nature-domain", "en"), Language = LanguageCode.En, Name = "Nature Domain", Description = "Nature gods are as varied as the wild itself, from the unknowable powers of deep forests to gentle spirits of a single spring or grove. Druids often revere nature as a whole, but many of these deities also have clerics who take a more active role: hunting the monsters that blight the woodlands, blessing the harvest of the faithful, or withering the crops of those who anger their god." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "nature-domain", "it"), Language = LanguageCode.It, Name = "Dominio della Natura", Description = "Gli dèi della natura sono vari quanto il mondo selvaggio, dalle potenze imperscrutabili delle foreste profonde ai benevoli spiriti di una singola sorgente o di un boschetto. I druidi venerano spesso la natura nel suo insieme, ma molte di queste divinità hanno anche chierici che assumono un ruolo più attivo: danno la caccia ai mostri che devastano i boschi, benedicono il raccolto dei fedeli o fanno avvizzire le messi di chi suscita l'ira del loro dio." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/nature-domain-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/nature-domain-spells", "en"), Language = LanguageCode.En, Name = "Nature Domain Spells", Description = "You gain these domain spells at the cleric levels shown. See the Divine Domain class feature for how domain spells work.\n\n| Cleric Level | Spells |\n|---|---|\n| 1st | animal friendship, speak with animals |\n| 3rd | barkskin, spike growth |\n| 5th | plant growth, wind wall |\n| 7th | dominate beast, grasping vine |\n| 9th | insect plague, tree stride |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/nature-domain-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Dominio della Natura", Description = "Il chierico ottiene questi incantesimi di dominio ai livelli da chierico indicati. Il funzionamento degli incantesimi di dominio è descritto nel privilegio di classe Dominio Divino.\n\n| Livello da chierico | Incantesimi |\n|---|---|\n| 1° | amicizia con gli animali, parlare con gli animali |\n| 3° | crescita di spine, pelle coriacea |\n| 5° | crescita vegetale, muro di vento |\n| 7° | dominare bestie, rampicante afferrante |\n| 9° | piaga degli insetti, traslazione arborea |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/acolyte-of-nature"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/acolyte-of-nature", "en"), Language = LanguageCode.En, Name = "Acolyte of Nature", Description = "At 1st level, you learn one druid cantrip of your choice, and you gain proficiency in one of these skills of your choice: Animal Handling, Nature, or Survival." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/acolyte-of-nature", "it"), Language = LanguageCode.It, Name = "Accolito della Natura", Description = "Al 1° livello il chierico apprende un trucchetto da druido a sua scelta e ottiene competenza in una tra queste abilità a sua scelta: Addestrare Animali, Natura o Sopravvivenza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/bonus-proficiency"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/bonus-proficiency", "en"), Language = LanguageCode.En, Name = "Bonus Proficiency", Description = "Also at 1st level, you become proficient with heavy armor." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/bonus-proficiency", "it"), Language = LanguageCode.It, Name = "Competenza Bonus", Description = "Sempre al 1° livello, il chierico ottiene competenza nelle armature pesanti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/channel-divinity-charm-animals-and-plants"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/channel-divinity-charm-animals-and-plants", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Charm Animals and Plants", Description = "From 2nd level, you can sway the creatures of the wild. As an action, you present your holy symbol, call out your deity's name and use your Channel Divinity. Every beast or plant creature within 30 feet of you that can see you makes a Wisdom saving throw. On a failure, it is charmed by you for 1 minute or until it takes damage, and while charmed it is friendly to you and to the creatures you designate." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/channel-divinity-charm-animals-and-plants", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Charme su Animali e Vegetali", Description = "Dal 2° livello il chierico può ammansire le creature selvagge. Come azione, presenta il suo simbolo sacro, pronuncia il nome della sua divinità e usa Incanalare Divinità. Ogni bestia o creatura vegetale entro 9 metri da lui che è in grado di vederlo effettua un tiro salvezza su Saggezza. Se lo fallisce, è affascinata dal chierico per 1 minuto o finché non subisce danni, e finché è affascinata è amichevole verso di lui e verso le creature che lui designa." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/dampen-elements"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/dampen-elements", "en"), Language = LanguageCode.En, Name = "Dampen Elements", Description = "From 6th level, when you or a creature within 30 feet of you takes acid, cold, fire, lightning, or thunder damage, you can use your reaction to give that creature resistance against that instance of damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/dampen-elements", "it"), Language = LanguageCode.It, Name = "Mitigare Elementi", Description = "Dal 6° livello il chierico può attenuare la furia degli elementi. Se lui stesso o una creatura situata a non più di 9 metri subisce danni da acido, freddo, fulmine, fuoco o tuono, il chierico può reagire (usando la sua reazione) e rendere quella creatura resistente a quei danni specifici." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/divine-strike"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 8,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/divine-strike", "en"), Language = LanguageCode.En, Name = "Divine Strike", Description = "At 8th level, divine power flows into your weapon. Once on each of your turns when you hit a creature with a weapon attack, you can deal an extra 1d8 cold, fire, or lightning damage (your choice) to it. The extra damage becomes 2d8 at 14th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/divine-strike", "it"), Language = LanguageCode.It, Name = "Colpo Divino", Description = "All'8° livello il potere divino fluisce nell'arma del chierico. Una volta in ognuno dei suoi turni, quando colpisce una creatura con un attacco con un'arma, può infliggerle 1d8 danni extra da freddo, da fuoco o da fulmine (a sua scelta). I danni extra diventano 2d8 al 14° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/master-of-nature"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/master-of-nature", "en"), Language = LanguageCode.En, Name = "Master of Nature", Description = "At 17th level, you can direct the creatures you have charmed with Charm Animals and Plants. As a bonus action on your turn, you can tell each of them, aloud, what it will do on its next turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "nature-domain/master-of-nature", "it"), Language = LanguageCode.It, Name = "Maestro della Natura", Description = "Al 17° livello il chierico può impartire ordini alle creature che ha affascinato con Charme su Animali e Vegetali. Come azione bonus nel suo turno, può dire a voce a ciascuna di esse che cosa farà nel suo turno successivo." }
					}
				}
			}
		};
	}
}
