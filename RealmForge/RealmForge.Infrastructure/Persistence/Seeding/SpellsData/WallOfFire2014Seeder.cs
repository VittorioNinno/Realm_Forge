using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wall of Fire (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WallOfFire2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-fire");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-fire", "en"),
					Language = LanguageCode.En,
					Name = "Wall of Fire",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a small piece of phosphorus",
					Description = "You create a wall of fire on a solid surface within range. You can make the wall up to 60 feet long, 20 feet high, and 1 foot thick, or a ringed wall up to 20 feet in diameter, 20 feet high, and 1 foot thick. The wall is opaque and lasts for the duration.\n\nWhen the wall appears, each creature within its area must make a Dexterity saving throw. On a failed save, a creature takes 5d8 fire damage, or half as much damage on a successful save.\n\nOne side of the wall, selected by you when you cast this spell, deals 5d8 fire damage to each creature that ends its turn within 10 feet of that side or inside the wall. A creature takes the same damage when it enters the wall for the first time on a turn or ends its turn there. The other side of the wall deals no damage.",
					HigherLevels = "When you cast this spell using a spell slot of 5th level or higher, the damage increases by 1d8 for each slot level above 4th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-fire", "it"),
					Language = LanguageCode.It,
					Name = "Muro di Fuoco",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un piccolo pezzo di fosforo",
					Description = "L'incantatore crea un muro di fuoco su una superficie solida entro gittata. Può creare un muro lungo fino a 18 metri, alto 6 metri e spesso 30 cm, oppure un muro circolare del diametro massimo di 6 metri, alto 6 metri e spesso 30 cm. Il muro è opaco e dura per la durata.\n\nQuando il muro compare, ogni creatura nella sua area deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, la creatura subisce 5d8 danni da fuoco; se lo supera, subisce la metà di quei danni.\n\nUn lato del muro, scelto dall'incantatore al momento del lancio, infligge 5d8 danni da fuoco a ogni creatura che termina il proprio turno entro 3 metri da quel lato o all'interno del muro. Una creatura subisce gli stessi danni quando entra nel muro per la prima volta in un turno o vi termina il proprio turno. L'altro lato del muro non infligge danni.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 5° livello o superiore, i danni aumentano di 1d8 per ogni livello dello slot superiore al 4°."
				}
			}
		};
	}
}
