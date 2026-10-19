using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Fey Wanderer (ranger, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class FeyWanderer2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "fey-wanderer");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "fey-wanderer", "en"), Language = LanguageCode.En, Name = "Fey Wanderer", Description = "An aura of fey mystery clings to you, a gift from an archfey or from a place in the Feywild that changed you forever. However the magic found you, you are now a Fey Wanderer: your bright laughter lifts the spirits of the weary, while your prowess in battle fills your enemies with dread, for the joy of the fey is boundless and their wrath is terrible." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "fey-wanderer", "it"), Language = LanguageCode.It, Name = "Viandante Fatato", Description = "Un'aura di mistero fatato avvolge il ranger, dono di un arcifolletto o di un luogo della Selva Fatata che lo ha cambiato per sempre. Comunque la magia lo abbia trovato, ora è un viandante fatato: la sua risata luminosa solleva lo spirito degli sfiniti, mentre la sua abilità in battaglia riempie i nemici di terrore, perché la gioia dei folletti è sconfinata e la loro ira è terribile." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/dreadful-strikes"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/dreadful-strikes", "en"), Language = LanguageCode.En, Name = "Dreadful Strikes", Description = "Your blows carry a sliver of the Feywild's darkest dreams. A weapon hit can inflict an extra 1d4 Psychic damage on the creature struck, though no creature suffers this extra damage more than once in a turn; the die grows to 1d6 once you reach Ranger level 11." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/dreadful-strikes", "it"), Language = LanguageCode.It, Name = "Colpi Terribili", Description = "Il ranger può potenziare i suoi colpi con una magia che ferisce la mente, attinta dai recessi più torbidi della Selva Fatata. Quando colpisce una creatura con un'arma, può infliggerle 1d4 danni psichici extra; una creatura può subire questi danni extra una sola volta per turno. I danni extra diventano 1d6 all'11° livello da ranger." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/fey-wanderer-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/fey-wanderer-spells", "en"), Language = LanguageCode.En, Name = "Fey Wanderer Spells", Description = "From the Ranger level shown in the table below onward, the listed spells are always prepared for you.\n\n| Ranger Level | Spell |\n|---|---|\n| 3 | *Charm Person* |\n| 5 | *Misty Step* |\n| 9 | *Summon Fey* |\n| 13 | *Dimension Door* |\n| 17 | *Mislead* |\n\nYou also carry a fey blessing; pick it from the table below or roll for it.\n\n| 1d6 | Feywild Gift |\n|---|---|\n| 1 | Illusory butterflies drift around you while you take a Short or Long Rest. |\n| 2 | Each dawn, flowers blossom in your hair. |\n| 3 | You carry a faint scent of cinnamon, lavender, nutmeg, or some other soothing herb or spice. |\n| 4 | Your shadow dances whenever no one looks straight at it. |\n| 5 | Horns or antlers grow from your head. |\n| 6 | Your skin and hair shift color every dawn. |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/fey-wanderer-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Viandante Fatato", Description = "Dal livello da ranger indicato nella tabella seguente, il ranger ha sempre preparati gli incantesimi elencati.\n\n| Livello da ranger | Incantesimo |\n|---|---|\n| 3 | *charme su persone* |\n| 5 | *passo velato* |\n| 9 | *richiama folletto* |\n| 13 | *porta dimensionale* |\n| 17 | *fuorviare* |\n\nIl ranger possiede inoltre una benedizione fatata, che sceglie dalla tabella seguente o determina casualmente.\n\n| 1d6 | Dono della Selva Fatata |\n|---|---|\n| 1 | Farfalle illusorie svolazzano attorno al ranger mentre effettua un riposo breve o lungo. |\n| 2 | Ogni alba, tra i suoi capelli sbocciano fiori. |\n| 3 | Emana un lieve profumo di cannella, lavanda, noce moscata o un'altra erba o spezia rassicurante. |\n| 4 | La sua ombra danza quando nessuno la guarda direttamente. |\n| 5 | Sulla sua testa spuntano corna o palchi. |\n| 6 | Il colore della sua pelle e dei suoi capelli cambia a ogni alba. |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/otherworldly-glamour"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/otherworldly-glamour", "en"), Language = LanguageCode.En, Name = "Otherworldly Glamour", Description = "Whenever you make a Charisma check, you add a bonus equal to your Wisdom modifier (at least +1). You also gain proficiency in your choice of Deception, Performance, or Persuasion." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/otherworldly-glamour", "it"), Language = LanguageCode.It, Name = "Fascino Ultraterreno", Description = "Ogni volta che effettua una prova di Carisma, il ranger ottiene un bonus pari al suo modificatore di Saggezza (minimo +1). Ottiene inoltre competenza in un'abilità a sua scelta tra Inganno, Intrattenere e Persuasione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/beguiling-twist"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/beguiling-twist", "en"), Language = LanguageCode.En, Name = "Beguiling Twist", Description = "Feywild magic shields your mind: you have Advantage on saving throws to avoid or end the Charmed or Frightened condition. Also, whenever you or a creature you can see within 120 feet of you succeeds on a save to avoid or end either condition, you can use your Reaction to force another creature you can see within 120 feet to make a Wisdom saving throw against your spell save DC. On a failure, the target is Charmed or Frightened (your choice) for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/beguiling-twist", "it"), Language = LanguageCode.It, Name = "Scambio Seducente", Description = "La magia della Selva Fatata protegge la mente del ranger, che dispone di vantaggio ai tiri salvezza per evitare o porre fine alle condizioni di affascinato o spaventato. Inoltre, ogni volta che lui o una creatura che è in grado di vedere entro 36 metri da lui supera un tiro salvezza per evitare o porre fine a una di quelle condizioni, il ranger può usare una reazione per costringere un'altra creatura che è in grado di vedere entro 36 metri a effettuare un tiro salvezza su Saggezza contro la CD del tiro salvezza dei suoi incantesimi. Se lo fallisce, il bersaglio è affascinato o spaventato (a scelta del ranger) per 1 minuto; ripete il tiro salvezza alla fine di ognuno dei suoi turni e, se lo supera, l'effetto su di lui termina." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/fey-reinforcements"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/fey-reinforcements", "en"), Language = LanguageCode.En, Name = "Fey Reinforcements", Description = "You can cast *Summon Fey* without a Material component. You can also cast it once without a spell slot, regaining that option after a Long Rest.\n\nEach time you begin casting the spell, you can alter it so it doesn't need Concentration; that casting then lasts 1 minute." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/fey-reinforcements", "it"), Language = LanguageCode.It, Name = "Rinforzi Fatati", Description = "Il ranger può lanciare *richiama folletto* senza componenti materiali. Può inoltre lanciarlo una volta senza slot incantesimo, e riacquista questa possibilità quando completa un riposo lungo.\n\nOgni volta che inizia a lanciare l'incantesimo, può modificarlo in modo che non richieda concentrazione; in tal caso, per quel lancio la durata diventa di 1 minuto." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/misty-wanderer"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/misty-wanderer", "en"), Language = LanguageCode.En, Name = "Misty Wanderer", Description = "You can cast *Misty Step* without a spell slot a number of times equal to your Wisdom modifier (at least once), regaining every use after a Long Rest.\n\nAlso, each time you cast *Misty Step*, you can take along one willing creature you can see within 5 feet of you; it teleports to an unoccupied space of your choice within 5 feet of where you arrive." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fey-wanderer/misty-wanderer", "it"), Language = LanguageCode.It, Name = "Viandante Velato", Description = "Il ranger può lanciare *passo velato* senza spendere uno slot incantesimo, un numero di volte pari al suo modificatore di Saggezza (almeno una), e recupera tutti gli utilizzi dopo un riposo lungo.\n\nInoltre, ogni volta che lancia *passo velato*, può portare con sé una creatura consenziente che è in grado di vedere entro 1,5 metri da lui, che si teletrasporta in uno spazio libero a scelta del ranger entro 1,5 metri dal punto di arrivo." }
					}
				}
			}
		};
	}
}
