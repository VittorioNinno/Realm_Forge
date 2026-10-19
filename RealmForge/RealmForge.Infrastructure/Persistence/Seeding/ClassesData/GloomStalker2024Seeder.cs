using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Gloom Stalker (ranger, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class GloomStalker2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "gloom-stalker");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Ranger2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "gloom-stalker", "en"), Language = LanguageCode.En, Name = "Gloom Stalker", Description = "Gloom Stalkers feel at home in the deepest dark. They wield magic drawn from the Shadowfell to hunt down the enemies that hide in the shadows." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "gloom-stalker", "it"), Language = LanguageCode.It, Name = "Cacciatore delle Tenebre", Description = "I cacciatori delle tenebre si sentono a casa nell'oscurità più profonda. Impugnano una magia attinta dalla Coltre Oscura per dare la caccia ai nemici che si celano nelle ombre." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/dread-ambusher"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/dread-ambusher", "en"), Language = LanguageCode.En, Name = "Dread Ambusher", Description = "You have mastered the craft of frightening ambushes and gain these benefits.\n\n**Ambusher's Leap.** At the start of your first turn in each combat, your Speed rises by 10 feet until that turn ends.\n\n**Dreadful Strike.** When you attack a creature and hit it with a weapon, you can add 2d6 Psychic damage. You can do so only once per turn, a number of times equal to your Wisdom modifier (at least once), regaining every use after a Long Rest.\n\n**Initiative Bonus.** When you roll Initiative, you can add your Wisdom modifier to the roll." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/dread-ambusher", "it"), Language = LanguageCode.It, Name = "Imboscata Terrificante", Description = "Il ranger padroneggia l'arte delle imboscate più temibili e ottiene i benefici seguenti.\n\n**Balzo silente.** All'inizio del suo primo turno di ogni combattimento, la velocità del ranger aumenta di 3 metri fino alla fine di quel turno.\n\n**Colpo terribile.** Quando attacca una creatura e la colpisce con un'arma, il ranger può infliggerle 2d6 danni psichici extra. Può usare questo beneficio una sola volta per turno, un numero di volte pari al suo modificatore di Saggezza (almeno una), e recupera tutti gli utilizzi dopo un riposo lungo.\n\n**Bonus di iniziativa.** Quando tira per l'iniziativa, il ranger può sommare al tiro il suo modificatore di Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/gloom-stalker-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/gloom-stalker-spells", "en"), Language = LanguageCode.En, Name = "Gloom Stalker Spells", Description = "From the Ranger level shown in the table below onward, the listed spells are always prepared for you.\n\n| Ranger Level | Spells |\n|---|---|\n| 3 | *Disguise Self* |\n| 5 | *Rope Trick* |\n| 9 | *Fear* |\n| 13 | *Greater Invisibility* |\n| 17 | *Seeming* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/gloom-stalker-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Cacciatore delle Tenebre", Description = "Dal livello da ranger indicato nella tabella seguente, il ranger ha sempre preparati gli incantesimi elencati.\n\n| Livello da ranger | Incantesimi |\n|---|---|\n| 3 | *camuffare se stesso* |\n| 5 | *trucco della corda* |\n| 9 | *paura* |\n| 13 | *invisibilità superiore* |\n| 17 | *sembrare* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/umbral-sight"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/umbral-sight", "en"), Language = LanguageCode.En, Name = "Umbral Sight", Description = "You gain Darkvision out to 60 feet; if you already have it when you gain this feature, its range grows by 60 feet.\n\nYou also know how to slip past creatures that depend on Darkvision: while wholly in Darkness, you have the Invisible condition to any creature relying on Darkvision to see you there." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/umbral-sight", "it"), Language = LanguageCode.It, Name = "Vista dell'Ombra", Description = "Il ranger ottiene scurovisione con un raggio di 18 metri; se ne possiede già quando ottiene questo privilegio, il raggio aumenta di 18 metri.\n\nIl ranger sa anche sfuggire alle creature che si affidano alla scurovisione: finché si trova interamente nell'oscurità, è invisibile per qualsiasi creatura che dipende dalla scurovisione per vederlo in quell'oscurità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/iron-mind"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/iron-mind", "en"), Language = LanguageCode.En, Name = "Iron Mind", Description = "Your mind has been tempered against anything that would twist it. You become proficient in Wisdom saving throws or, if you already were, in your choice of Intelligence or Charisma saving throws." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/iron-mind", "it"), Language = LanguageCode.It, Name = "Mente di Ferro", Description = "Il ranger ha affinato la sua capacità di resistere ai poteri che alterano la mente: ottiene competenza nei tiri salvezza su Saggezza. Se ce l'ha già, ottiene invece competenza nei tiri salvezza su Intelligenza o su Carisma (a sua scelta)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/stalkers-flurry"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/stalkers-flurry", "en"), Language = LanguageCode.En, Name = "Stalker's Flurry", Description = "Your Dreadful Strike's Psychic damage becomes 2d8. Also, when you use the Dreadful Strike benefit of Dread Ambusher, you can add one of these effects.\n\n**Sudden Strike.** You can make another attack with the same weapon against a different creature within 5 feet of the original target and within the weapon's range.\n\n**Mass Fear.** The target and every creature within 10 feet of it make a Wisdom saving throw against your spell save DC; each one that fails is Frightened until the start of your next turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/stalkers-flurry", "it"), Language = LanguageCode.It, Name = "Raffica del Cacciatore", Description = "I danni psichici di Colpo terribile diventano 2d8. Inoltre, quando usa l'effetto Colpo terribile di Imboscata terrificante, il ranger può causare uno degli effetti aggiuntivi seguenti.\n\n**Colpo improvviso.** Il ranger può effettuare un altro attacco con la stessa arma contro una creatura diversa, che si trovi entro 1,5 metri dal bersaglio originale e nella gittata o portata dell'arma.\n\n**Paura di massa.** Il bersaglio e ogni creatura entro 3 metri da esso devono effettuare un tiro salvezza su Saggezza contro la CD del tiro salvezza degli incantesimi del ranger; chi lo fallisce subisce la condizione di spaventato fino all'inizio del turno successivo del ranger." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/shadowy-dodge"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/shadowy-dodge", "en"), Language = LanguageCode.En, Name = "Shadowy Dodge", Description = "As a foe swings at you, the shadows answer: when a creature rolls to attack you, your Reaction can hinder that roll with Disadvantage, and whatever the outcome you may then vanish and reappear in an unoccupied space you can see up to 30 feet away." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "gloom-stalker/shadowy-dodge", "it"), Language = LanguageCode.It, Name = "Schivata dell'Ombra", Description = "Quando una creatura effettua un tiro per colpire contro di lui, il ranger può usare una reazione per imporre svantaggio a quel tiro. Che l'attacco vada a segno o meno, può poi teletrasportarsi fino a 9 metri in uno spazio libero che è in grado di vedere." }
					}
				}
			}
		};
	}
}
