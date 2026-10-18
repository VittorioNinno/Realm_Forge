using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Astral Projection (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AstralProjection2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "astral-projection");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "astral-projection", "en"),
					Language = LanguageCode.En,
					Name = "Astral Projection",
					CastingTime = "1 hour",
					Range = "10 feet",
					Duration = "Until dispelled",
					MaterialComponent = "for each of the spell's targets, one jacinth worth 1,000+ GP and one silver bar worth 100+ GP, all of which the spell consumes",
					Description = "You and up to eight willing creatures within range project your astral bodies into the Astral Plane (the spell ends instantly if you are already on that plane). Each target's body is left behind in a state of suspended animation; it has the Unconscious condition, doesn't need food or air, and doesn't age.\n\nA target's astral form resembles its body in almost every way, replicating its game statistics and possessions. The principal difference is the addition of a silvery cord that trails from between the shoulder blades of the astral form. The cord fades from view after 1 foot. If the cord is cut—which happens only when an effect states that it does so—the target's body and astral form both die.\n\nA target's astral form can travel through the Astral Plane. The moment an astral form leaves that plane, the target's body and possessions travel along the silver cord, causing the target to re-enter its body on the new plane.\n\nAny damage or other effects that apply to an astral form have no effect on the target's body and vice versa. If a target's body or astral form drops to 0 Hit Points, the spell ends for that target. The spell ends for all the targets if you take a Magic action to dismiss it.\n\nWhen the spell ends for a target who isn't dead, the target reappears in its body and exits the state of suspended animation.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "astral-projection", "it"),
					Language = LanguageCode.It,
					Name = "Proiezione Astrale",
					CastingTime = "1 ora",
					Range = "3 metri",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "per ciascun bersaglio dell'incantesimo, un giacinto del valore di almeno 1.000 mo e una barra d'argento del valore di almeno 100 mo, che l'incantesimo consuma",
					Description = "L'incantatore e fino a otto creature consenzienti entro gittata proiettano i propri corpi astrali nel Piano Astrale (l'incantesimo termina immediatamente se l'incantatore si trova già su quel piano). Il corpo di ogni bersaglio resta indietro in uno stato di animazione sospesa: è privo di sensi, non ha bisogno di cibo né di aria e non invecchia.\n\nLa forma astrale di un bersaglio somiglia al suo corpo in quasi tutto, replicandone le statistiche di gioco e i possedimenti. La differenza principale è un cordone argenteo che si diparte da in mezzo alle scapole della forma astrale. Il cordone svanisce alla vista dopo 30 centimetri. Se il cordone viene reciso (cosa che accade solo quando un effetto lo specifica), sia il corpo sia la forma astrale del bersaglio muoiono.\n\nLa forma astrale di un bersaglio può viaggiare attraverso il Piano Astrale. Nel momento in cui una forma astrale lascia quel piano, il corpo e i possedimenti del bersaglio viaggiano lungo il cordone argenteo, facendo sì che il bersaglio rientri nel proprio corpo sul nuovo piano.\n\nI danni o gli altri effetti che si applicano a una forma astrale non hanno alcun effetto sul corpo del bersaglio, e viceversa. Se il corpo o la forma astrale di un bersaglio scende a 0 punti ferita, l'incantesimo termina per quel bersaglio. L'incantesimo termina per tutti i bersagli se l'incantatore effettua un'azione di Magia per congedarlo.\n\nQuando l'incantesimo termina per un bersaglio che non è morto, il bersaglio ricompare nel proprio corpo ed esce dallo stato di animazione sospesa.",
					HigherLevels = null
				}
			}
		};
	}
}
