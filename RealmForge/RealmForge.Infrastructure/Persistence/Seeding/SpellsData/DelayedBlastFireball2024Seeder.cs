using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Delayed Blast Fireball (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DelayedBlastFireball2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "delayed-blast-fireball");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "delayed-blast-fireball", "en"),
					Language = LanguageCode.En,
					Name = "Delayed Blast Fireball",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a ball of bat guano and sulfur",
					Description = "A beam of yellow light flashes from you, then condenses at a chosen point within range as a glowing bead for the duration. When the spell ends, the bead explodes, and each creature in a 20-foot-radius Sphere centered on that point makes a Dexterity saving throw. A creature takes Fire damage equal to the total accumulated damage on a failed save or half as much damage on a successful one.\n\nThe spell's base damage is 12d6, and the damage increases by 1d6 whenever your turn ends and the spell hasn't ended.\n\nIf a creature touches the glowing bead before the spell ends, that creature makes a Dexterity saving throw. On a failed save, the spell ends, causing the bead to explode. On a successful save, the creature can throw the bead up to 40 feet. If the thrown bead enters a creature's space or collides with a solid object, the spell ends, and the bead explodes.\n\nWhen the bead explodes, flammable objects in the explosion that aren't being worn or carried start burning.",
					HigherLevels = "The base damage increases by 1d6 for each spell slot level above 7."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "delayed-blast-fireball", "it"),
					Language = LanguageCode.It,
					Name = "Palla di Fuoco Ritardata",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una pallina di guano di pipistrello e zolfo",
					Description = "Un raggio di luce gialla scaturisce dall'incantatore, poi si condensa in un punto scelto entro gittata sotto forma di una perla luminosa che permane per la durata. Quando l'incantesimo termina, la perla esplode e ogni creatura in una sfera del raggio di 6 metri centrata su quel punto effettua un tiro salvezza su Destrezza. Una creatura subisce danni da fuoco pari al totale dei danni accumulati se lo fallisce, o la metà di quei danni se lo supera.\n\nI danni base dell'incantesimo sono 12d6 e aumentano di 1d6 ogni volta che il turno dell'incantatore termina senza che l'incantesimo sia terminato.\n\nSe una creatura tocca la perla luminosa prima che l'incantesimo termini, quella creatura effettua un tiro salvezza su Destrezza. Se lo fallisce, l'incantesimo termina e la perla esplode. Se lo supera, la creatura può lanciare la perla fino a 12 metri di distanza. Se la perla lanciata entra nello spazio di una creatura o urta un oggetto solido, l'incantesimo termina e la perla esplode.\n\nQuando la perla esplode, gli oggetti infiammabili nell'esplosione che non sono indossati o trasportati prendono fuoco.",
					HigherLevels = "I danni base aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 7°."
				}
			}
		};
	}
}
