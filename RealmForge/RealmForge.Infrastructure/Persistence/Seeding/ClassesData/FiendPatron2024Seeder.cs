using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Fiend Patron (warlock, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FiendPatron2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "fiend-patron");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Warlock2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "fiend-patron", "en"), Language = LanguageCode.En, Name = "Fiend Patron", Description = "Your pact draws on the Lower Planes, the realms of perdition. You might forge a bargain with a demon lord such as Demogorgon or Orcus; an archdevil such as Asmodeus; or a pit fiend, balor, yugoloth, or night hag that is especially mighty. That patron’s aims are evil—the corruption or destruction of all things, ultimately including you—and your path is defined by the extent to which you strive against those aims." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "fiend-patron", "it"), Language = LanguageCode.It, Name = "Patrono Immondo", Description = "Il patto del warlock attinge ai Piani Inferiori, i reami della perdizione. Potrebbe aver stretto un accordo con un signore dei demoni come Demogorgone od Orcus, con un arcidiavolo come Asmodeus, oppure con un diavolo della fossa, un balor, uno yugoloth o una megera notturna particolarmente potenti. Gli scopi di quel patrono sono malvagi, la corruzione o la distruzione di ogni cosa, compreso alla fine lo stesso warlock, e il suo cammino è definito da quanto si sforza di opporsi a quegli scopi." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/dark-ones-blessing"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/dark-ones-blessing", "en"), Language = LanguageCode.En, Name = "Dark One's Blessing", Description = "When you reduce an enemy to 0 Hit Points, you gain Temporary Hit Points equal to your Charisma modifier plus your Warlock level (minimum of 1 Temporary Hit Point). You also gain this benefit if someone else reduces an enemy within 10 feet of you to 0 Hit Points." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/dark-ones-blessing", "it"), Language = LanguageCode.It, Name = "Benedizione dell'Oscuro", Description = "Quando riduce un nemico a 0 punti ferita, il warlock ottiene punti ferita temporanei pari al suo modificatore di Carisma + il suo livello da warlock (minimo 1 punto ferita temporaneo). Ottiene questo beneficio anche se è qualcun altro a ridurre a 0 punti ferita un nemico entro 3 metri da lui." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/fiend-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/fiend-spells", "en"), Language = LanguageCode.En, Name = "Fiend Spells", Description = "The magic of your patron ensures you always have certain spells ready; when you reach a Warlock level specified in the table below, you thereafter always have the listed spells prepared.\n\n| Warlock Level | Spells |\n|---|---|\n| 3 | *Burning Hands*, *Command*, *Scorching Ray*, *Suggestion* |\n| 5 | *Fireball*, *Stinking Cloud* |\n| 7 | *Fire Shield*, *Wall of Fire* |\n| 9 | *Geas*, *Insect Plague* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/fiend-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi Immondi", Description = "La magia del patrono garantisce al warlock di avere sempre pronti determinati incantesimi: quando raggiunge un livello da warlock indicato nella tabella seguente, da quel momento ha sempre preparati gli incantesimi elencati.\n\n| Livello da warlock | Incantesimi |\n|---|---|\n| 3 | *comando*, *mani brucianti*, *raggio rovente*, *suggestione* |\n| 5 | *nube maleodorante*, *palla di fuoco* |\n| 7 | *muro di fuoco*, *scudo di fuoco* |\n| 9 | *costrizione*, *piaga degli insetti* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/dark-ones-own-luck"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/dark-ones-own-luck", "en"), Language = LanguageCode.En, Name = "Dark One's Own Luck", Description = "You can call on your fiendish patron to alter fate in your favor. When you make an ability check or a saving throw, you can use this feature to add 1d10 to your roll. You can do so after seeing the roll but before any of the roll’s effects occur.\n\nYou can use this feature a number of times equal to your Charisma modifier (minimum of once), but you can use it no more than once per roll. You regain all expended uses when you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/dark-ones-own-luck", "it"), Language = LanguageCode.It, Name = "Fortuna dell'Oscuro", Description = "Il warlock può invocare il suo patrono immondo affinché alteri il destino a suo favore. Quando effettua una prova di caratteristica o un tiro salvezza, può usare questo privilegio per sommare 1d10 al tiro, anche dopo averne visto il risultato ma prima che se ne verifichino gli effetti.\n\nPuò usare questo privilegio un numero di volte pari al suo modificatore di Carisma (minimo una volta), ma non più di una volta per tiro, e recupera tutti gli utilizzi spesi quando completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/fiendish-resilience"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/fiendish-resilience", "en"), Language = LanguageCode.En, Name = "Fiendish Resilience", Description = "Choose one damage type, other than Force, whenever you finish a Short or Long Rest. You have Resistance to that damage type until you choose a different one with this feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/fiendish-resilience", "it"), Language = LanguageCode.It, Name = "Resilienza Immonda", Description = "Ogni volta che completa un riposo breve o lungo, il warlock sceglie un tipo di danni diverso da forza: ha resistenza a quel tipo di danni finché non ne sceglie un altro con questo privilegio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/hurl-through-hell"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/hurl-through-hell", "en"), Language = LanguageCode.En, Name = "Hurl Through Hell", Description = "Once per turn when you hit a creature with an attack roll, you can try to instantly transport the target through the Lower Planes. The target must succeed on a Charisma saving throw against your spell save DC, or the target disappears and hurtles through a nightmare landscape. The target takes 8d10 Psychic damage if it isn’t a Fiend, and it has the Incapacitated condition until the end of your next turn, when it returns to the space it previously occupied or the nearest unoccupied space.\n\nOnce you use this feature, you can’t use it again until you finish a Long Rest unless you expend a Pact Magic spell slot (no action required) to restore your use of it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "fiend-patron/hurl-through-hell", "it"), Language = LanguageCode.It, Name = "Scagliare all'Inferno", Description = "Una volta per turno, quando colpisce una creatura con un tiro per colpire, il warlock può tentare di trasportare all'istante il bersaglio attraverso i Piani Inferiori. Il bersaglio deve superare un tiro salvezza su Carisma contro la CD del tiro salvezza dei suoi incantesimi, altrimenti scompare e precipita attraverso un paesaggio da incubo. Se non è un immondo, subisce 8d10 danni psichici; resta incapacitato fino alla fine del turno successivo del warlock, quando torna nello spazio che occupava o nello spazio libero più vicino.\n\nDopo aver usato questo privilegio, il warlock non può farlo di nuovo finché non completa un riposo lungo, a meno che non spenda uno slot incantesimo della Magia del patto (nessuna azione richiesta) per ripristinarlo." }
					}
				}
			}
		};
	}
}
