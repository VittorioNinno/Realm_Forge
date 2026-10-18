using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Celestial (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConjureCelestial2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-celestial");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-celestial", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Celestial",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You conjure a spirit from the Upper Planes, which manifests as a pillar of light in a 10-foot-radius, 40-foot-high Cylinder centered on a point within range. For each creature you can see in the Cylinder, choose which of these lights shines on it:\n\n**Healing Light.** The target regains Hit Points equal to 4d12 plus your spellcasting ability modifier.\n\n**Searing Light.** The target makes a Dexterity saving throw, taking 6d12 Radiant damage on a failed save or half as much damage on a successful one.\n\nUntil the spell ends, Bright Light fills the Cylinder, and when you move on your turn, you can also move the Cylinder up to 30 feet.\n\nWhenever the Cylinder moves into the space of a creature you can see and whenever a creature you can see enters the Cylinder or ends its turn there, you can bathe it in one of the lights. A creature can be affected by this spell only once per turn.",
					HigherLevels = "The healing and damage increase by 1d12 for each spell slot level above 7."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-celestial", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Celestiale",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore evoca uno spirito dai Piani Superiori, che si manifesta come una colonna di luce in un cilindro del raggio di 3 metri e alto 12 metri, centrato su un punto entro gittata. Per ogni creatura nel cilindro che è in grado di vedere, l'incantatore sceglie quale di queste luci la illumina:\n\n**Luce Curativa.** Il bersaglio recupera punti ferita pari a 4d12 più il modificatore di caratteristica da incantatore dell'incantatore.\n\n**Luce Bruciante.** Il bersaglio effettua un tiro salvezza su Destrezza, subendo 6d12 danni radiosi se lo fallisce, o la metà di quei danni se lo supera.\n\nFinché l'incantesimo non termina, il cilindro è pervaso di luce intensa e, quando l'incantatore si muove nel proprio turno, può anche spostare il cilindro fino a 9 metri.\n\nOgni volta che il cilindro si sposta nello spazio di una creatura che l'incantatore è in grado di vedere, e ogni volta che una creatura che è in grado di vedere entra nel cilindro o vi termina il proprio turno, l'incantatore può bagnarla con una delle luci. Una creatura può essere influenzata da questo incantesimo soltanto una volta per turno.",
					HigherLevels = "La guarigione e i danni aumentano di 1d12 per ogni livello dello slot incantesimo superiore al 7°."
				}
			}
		};
	}
}
