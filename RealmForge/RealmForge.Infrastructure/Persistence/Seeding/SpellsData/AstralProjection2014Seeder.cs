using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Astral Projection (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AstralProjection2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "astral-projection");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 9,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "astral-projection", "en"),
					Language = LanguageCode.En,
					Name = "Astral Projection",
					CastingTime = "1 hour",
					Range = "10 feet",
					Duration = "Special",
					MaterialComponent = "for each creature you affect with this spell, you must provide one jacinth worth at least 1,000 gp and one ornately carved bar of silver worth at least 100 gp, all of which the spell consumes",
					Description = "You and up to eight willing creatures within range project your astral bodies into the Astral Plane (the spell fails and the casting is wasted if you are already on that plane). The material body you leave behind is unconscious and in a state of suspended animation; it doesn't need food or air and doesn't age.\n\nYour astral body resembles your mortal form in almost every way, replicating your game statistics and possessions. The principal difference is the addition of a silvery cord that extends from between your shoulder blades and trails behind you, fading to invisibility after 1 foot. This cord is your tether to your material body. As long as the tether remains intact, you can find your way home. If the cord is cut—something that can happen only when an effect specifically states that it does—your soul and body are separated, killing you instantly.\n\nYour astral form can freely travel through the Astral Plane and can pass through portals there leading to any other plane. If you enter a new plane or return to the plane you were on when casting this spell, your body and possessions are transported along the silver cord, allowing you to re-enter your body as you enter the new plane. Your astral form is a separate incarnation. Any damage or other effects that apply to it have no effect on your physical body, nor do they persist when you return to it.\n\nThe spell ends for you and your companions when you use your action to dismiss it. When the spell ends, the affected creature returns to its physical body, and it awakens.\n\nThe spell might also end early for you or one of your companions. A successful dispel magic spell used against an astral or physical body ends the spell for that creature. If a creature's original body or its astral form drops to 0 hit points, the spell ends for that creature. If the spell ends and the silver cord is intact, the cord pulls the creature's astral form back to its body, ending its state of suspended animation.\n\nIf you are returned to your body prematurely, your companions remain in their astral forms and must find their own way back to their bodies, usually by dropping to 0 hit points.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "astral-projection", "it"),
					Language = LanguageCode.It,
					Name = "Proiezione Astrale",
					CastingTime = "1 ora",
					Range = "3 metri",
					Duration = "Speciale",
					MaterialComponent = "per ogni creatura influenzata dall'incantesimo, l'incantatore deve fornire un giacinto del valore di almeno 1.000 mo e una barra d'argento finemente decorata del valore di almeno 100 mo, che l'incantesimo consuma",
					Description = "L'incantatore e fino a otto creature consenzienti entro gittata proiettano i propri corpi astrali nel Piano Astrale (l'incantesimo fallisce e il lancio va sprecato se l'incantatore si trova già su quel piano). Il corpo materiale lasciato indietro è privo di sensi e in uno stato di animazione sospesa: non ha bisogno di cibo né di aria e non invecchia.\n\nIl corpo astrale dell'incantatore somiglia sotto quasi ogni aspetto alla sua forma mortale, riproducendone le statistiche di gioco e i possedimenti. La differenza principale è la presenza di un cordone argenteo che si diparte da un punto tra le scapole e si trascina alle sue spalle, diventando invisibile dopo 30 cm. Questo cordone è il legame con il corpo materiale. Finché il legame resta intatto, l'incantatore può trovare la strada di casa. Se il cordone viene reciso (cosa che può accadere solo quando un effetto lo specifica espressamente), l'anima e il corpo si separano, uccidendo l'incantatore all'istante.\n\nLa forma astrale dell'incantatore può viaggiare liberamente attraverso il Piano Astrale e attraversare i portali che vi si trovano, verso qualsiasi altro piano. Se l'incantatore entra in un nuovo piano o fa ritorno al piano in cui si trovava quando ha lanciato l'incantesimo, il suo corpo e i suoi possedimenti vengono trasportati lungo il cordone argenteo, permettendogli di rientrare nel proprio corpo quando entra nel nuovo piano. La forma astrale è un'incarnazione separata. Qualsiasi danno o altro effetto che si applica a essa non ha alcun effetto sul corpo fisico, né persiste quando l'incantatore vi fa ritorno.\n\nL'incantesimo termina per l'incantatore e per i suoi compagni quando l'incantatore usa la sua azione per congedarlo. Quando l'incantesimo termina, la creatura influenzata torna nel proprio corpo fisico e si risveglia.\n\nL'incantesimo può anche terminare prima per l'incantatore o per uno dei suoi compagni. Un incantesimo dissolvi magie riuscito usato contro un corpo astrale o fisico pone fine all'incantesimo per quella creatura. Se il corpo originale di una creatura o la sua forma astrale scende a 0 punti ferita, l'incantesimo termina per quella creatura. Se l'incantesimo termina e il cordone argenteo è intatto, il cordone riporta la forma astrale della creatura nel suo corpo, ponendo fine allo stato di animazione sospesa.\n\nSe l'incantatore viene riportato nel proprio corpo prima del tempo, i suoi compagni restano nelle loro forme astrali e devono trovare da soli la strada per tornare nei rispettivi corpi, di solito scendendo a 0 punti ferita.",
					HigherLevels = null
				}
			}
		};
	}
}
