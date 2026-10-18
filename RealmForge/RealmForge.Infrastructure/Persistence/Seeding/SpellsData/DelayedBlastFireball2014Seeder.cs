using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Delayed Blast Fireball (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DelayedBlastFireball2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "delayed-blast-fireball");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "delayed-blast-fireball", "en"),
					Language = LanguageCode.En,
					Name = "Delayed Blast Fireball",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a tiny ball of bat guano and sulfur",
					Description = "A beam of yellow light flashes from your pointing finger, then condenses to linger at a chosen point within range as a glowing bead for the duration. When the spell ends, either because your concentration is broken or because you decide to end it, the bead blossoms with a low roar into an explosion of flame that spreads around corners. Each creature in a 20-foot-radius sphere centered on that point must make a Dexterity saving throw. A creature takes fire damage equal to the total accumulated damage on a failed save, or half as much damage on a successful one.\n\nThe spell's base damage is 12d6. If at the end of your turn the bead has not yet detonated, the damage increases by 1d6.\n\nIf the glowing bead is touched before the interval has expired, the creature touching it must make a Dexterity saving throw. On a failed save, the spell ends immediately, causing the bead to erupt in flame. On a successful save, the creature can throw the bead up to 40 feet. When it strikes a creature or a solid object, the spell ends, and the bead explodes.\n\nThe fire damages objects in the area and ignites flammable objects that aren't being worn or carried.",
					HigherLevels = "When you cast this spell using a spell slot of 8th level or higher, the base damage increases by 1d6 for each slot level above 7th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "delayed-blast-fireball", "it"),
					Language = LanguageCode.It,
					Name = "Palla di Fuoco Ritardata",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una minuscola pallina di guano di pipistrello e zolfo",
					Description = "Un raggio di luce gialla scaturisce dal dito puntato dell'incantatore, poi si condensa e resta sospeso in un punto entro gittata da lui scelto, sotto forma di perla luminosa, per la durata. Quando l'incantesimo termina, perché la concentrazione dell'incantatore si interrompe o perché lui decide di porvi fine, la perla sboccia con un rombo sordo in un'esplosione di fiamme che si propaga dietro gli angoli. Ogni creatura in una sfera del raggio di 6 metri centrata su quel punto deve effettuare un tiro salvezza su Destrezza. Una creatura subisce danni da fuoco pari al totale dei danni accumulati se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\nI danni base dell'incantesimo sono 12d6. Se alla fine del turno dell'incantatore la perla non è ancora esplosa, i danni aumentano di 1d6.\n\nSe la perla luminosa viene toccata prima che l'intervallo sia trascorso, la creatura che la tocca deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, l'incantesimo termina immediatamente e la perla erompe in fiamme. Se lo supera, la creatura può lanciare la perla fino a 12 metri di distanza. Quando la perla colpisce una creatura o un oggetto solido, l'incantesimo termina e la perla esplode.\n\nIl fuoco danneggia gli oggetti nell'area e incendia gli oggetti infiammabili che non sono indossati o trasportati.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 8° livello o superiore, i danni base aumentano di 1d6 per ogni livello dello slot superiore al 7°."
				}
			}
		};
	}
}
