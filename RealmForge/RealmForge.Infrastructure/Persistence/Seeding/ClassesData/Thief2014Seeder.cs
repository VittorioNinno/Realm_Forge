using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Thief (rogue, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Thief2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "thief");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Rogue2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "thief", "en"), Language = LanguageCode.En, Name = "Thief", Description = "You hone your skills in the larcenous arts. Burglars, bandits, cutpurses, and other criminals typically follow this archetype, but so do rogues who prefer to think of themselves as professional treasure seekers, explorers, delvers, and investigators. In addition to improving your agility and stealth, you learn skills useful for delving into ancient ruins, reading unfamiliar languages, and using magic items you normally couldn't employ." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "thief", "it"), Language = LanguageCode.It, Name = "Furfante", Description = "Il ladro affina le proprie capacità nelle arti del furto. Scassinatori, banditi, borseggiatori e altri criminali seguono di solito questo archetipo, ma lo fanno anche i ladri che preferiscono considerarsi cercatori di tesori professionisti, esploratori, speleologi e investigatori. Oltre a migliorare la propria agilità e la propria furtività, il ladro apprende capacità utili per esplorare rovine antiche, leggere lingue sconosciute e usare oggetti magici che normalmente non potrebbe impiegare." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/fast-hands"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/fast-hands", "en"), Language = LanguageCode.En, Name = "Fast Hands", Description = "Starting at 3rd level, you can use the bonus action granted by your Cunning Action to make a Dexterity (Sleight of Hand) check, use your thieves' tools to disarm a trap or open a lock, or take the Use an Object action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/fast-hands", "it"), Language = LanguageCode.It, Name = "Mani Veloci", Description = "A partire dal 3° livello, il ladro può usare l'azione bonus concessa da Azione Scaltra per effettuare una prova di Destrezza (Rapidità di Mano), usare i suoi arnesi da scasso per disattivare una trappola o aprire una serratura, oppure effettuare l'azione di Usare un Oggetto." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/second-story-work"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/second-story-work", "en"), Language = LanguageCode.En, Name = "Second-Story Work", Description = "When you choose this archetype at 3rd level, you gain the ability to climb faster than normal; climbing no longer costs you extra movement.\n\nIn addition, when you make a running jump, the distance you cover increases by a number of feet equal to your Dexterity modifier." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/second-story-work", "it"), Language = LanguageCode.It, Name = "Lavoro al Secondo Piano", Description = "Quando sceglie questo archetipo al 3° livello, il ladro ottiene la capacità di arrampicarsi più velocemente del normale: arrampicarsi non gli costa più movimento extra.\n\nInoltre, quando effettua un salto con rincorsa, la distanza che copre aumenta di un numero di metri pari a 0,3 × il suo modificatore di Destrezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/supreme-sneak"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 9,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/supreme-sneak", "en"), Language = LanguageCode.En, Name = "Supreme Sneak", Description = "Starting at 9th level, you have advantage on a Dexterity (Stealth) check if you move no more than half your speed on the same turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/supreme-sneak", "it"), Language = LanguageCode.It, Name = "Furtività Suprema", Description = "A partire dal 9° livello, il ladro dispone di vantaggio a una prova di Destrezza (Furtività) se nello stesso turno non si muove di più della metà della sua velocità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/use-magic-device"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 13,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/use-magic-device", "en"), Language = LanguageCode.En, Name = "Use Magic Device", Description = "By 13th level, you have learned enough about the workings of magic that you can improvise the use of items even when they are not intended for you. You ignore all class, race, and level requirements on the use of magic items." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/use-magic-device", "it"), Language = LanguageCode.It, Name = "Usare Oggetto Magico", Description = "Al 13° livello il ladro ha imparato abbastanza sul funzionamento della magia da riuscire a improvvisare l'uso di oggetti anche quando non sono destinati a lui. Ignora tutti i requisiti di classe, razza e livello per l'uso degli oggetti magici." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/thief-s-reflexes"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/thief-s-reflexes", "en"), Language = LanguageCode.En, Name = "Thief's Reflexes", Description = "When you reach 17th level, you have become adept at laying ambushes and quickly escaping danger. You can take two turns during the first round of any combat. You take your first turn at your normal initiative and your second turn at your initiative minus 10. You can't use this feature when you are surprised." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "thief/thief-s-reflexes", "it"), Language = LanguageCode.It, Name = "Riflessi da Furfante", Description = "Quando arriva al 17° livello, il ladro è diventato esperto nel tendere imboscate e nel sottrarsi rapidamente al pericolo. Può effettuare due turni durante il primo round di qualsiasi combattimento. Effettua il primo turno con la sua iniziativa normale e il secondo con la sua iniziativa meno 10. Non può usare questo privilegio quando è sorpreso." }
					}
				}
			}
		};
	}
}
