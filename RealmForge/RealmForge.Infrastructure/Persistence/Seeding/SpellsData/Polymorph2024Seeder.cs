using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Polymorph (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Polymorph2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "polymorph");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "polymorph", "en"),
					Language = LanguageCode.En,
					Name = "Polymorph",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a caterpillar cocoon",
					Description = "You attempt to transform a creature that you can see within range into a Beast. The target must succeed on a Wisdom saving throw or shape-shift into a Beast form for the duration. That form can be any Beast you choose that has a Challenge Rating equal to or less than the target's (or the target's level if it doesn't have a Challenge Rating). The target's game statistics are replaced by the stat block of the chosen Beast, but the target retains its alignment, personality, creature type, Hit Points, and Hit Point Dice. See the \"Animals\" section of \"Monsters\" for a sample of Beast stat blocks.\n\nThe target gains a number of Temporary Hit Points equal to the Hit Points of the Beast form. These Temporary Hit Points vanish if any remain when the spell ends. The spell ends early on the target if it has no Temporary Hit Points left.\n\nThe target is limited in the actions it can perform by the anatomy of its new form, and it can't speak or cast spells. The target's gear melds into the new form. The creature can't use or otherwise benefit from any of that equipment.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "polymorph", "it"),
					Language = LanguageCode.It,
					Name = "Metamorfosi",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un bozzolo di bruco",
					Description = "L'incantatore tenta di trasformare in una bestia una creatura entro gittata che è in grado di vedere. Il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti assume la forma di una bestia per la durata. Quella forma può essere qualsiasi bestia a scelta dell'incantatore con un Grado di Sfida pari o inferiore a quello del bersaglio (o al livello del bersaglio, se non ha un Grado di Sfida). Le statistiche di gioco del bersaglio sono sostituite dalla scheda delle statistiche della bestia scelta, ma il bersaglio mantiene il proprio allineamento, la personalità, il tipo di creatura, i punti ferita e i Dadi Vita. Alcuni esempi di schede delle statistiche delle bestie si trovano nella sezione \"Animali\" del capitolo \"Mostri\" dell'SRD.\n\nIl bersaglio ottiene un numero di punti ferita temporanei pari ai punti ferita della forma bestiale. Gli eventuali punti ferita temporanei rimasti svaniscono quando l'incantesimo termina. L'incantesimo termina prima del tempo sul bersaglio se non gli restano più punti ferita temporanei.\n\nLe azioni che il bersaglio può effettuare sono limitate dall'anatomia della sua nuova forma, e il bersaglio non può parlare né lanciare incantesimi. L'equipaggiamento del bersaglio si fonde con la nuova forma. La creatura non può usare nessun oggetto di quell'equipaggiamento né trarne beneficio in altro modo.",
					HigherLevels = null
				}
			}
		};
	}
}
