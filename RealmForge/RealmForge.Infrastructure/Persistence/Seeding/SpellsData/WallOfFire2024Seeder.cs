using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wall of Fire (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WallOfFire2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-fire");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-fire", "en"),
					Language = LanguageCode.En,
					Name = "Wall of Fire",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a piece of charcoal",
					Description = "You create a wall of fire on a solid surface within range. You can make the wall up to 60 feet long, 20 feet high, and 1 foot thick, or a ringed wall up to 20 feet in diameter, 20 feet high, and 1 foot thick. The wall is opaque and lasts for the duration.\n\nWhen the wall appears, each creature in its area makes a Dexterity saving throw, taking 5d8 Fire damage on a failed save or half as much damage on a successful one.\n\nOne side of the wall, selected by you when you cast this spell, deals 5d8 Fire damage to each creature that ends its turn within 10 feet of that side or inside the wall. A creature takes the same damage when it enters the wall for the first time on a turn or ends its turn there. The other side of the wall deals no damage.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-fire", "it"),
					Language = LanguageCode.It,
					Name = "Muro di Fuoco",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pezzo di carbone",
					Description = "L'incantatore crea un muro di fuoco su una superficie solida entro gittata. Può creare un muro lungo fino a 18 metri, alto fino a 6 metri e spesso 30 centimetri, oppure un muro circolare con un diametro fino a 6 metri, alto fino a 6 metri e spesso 30 centimetri. Il muro è opaco e permane per la durata.\n\nQuando il muro compare, ogni creatura nella sua area effettua un tiro salvezza su Destrezza, subendo 5d8 danni da fuoco se lo fallisce, o la metà di quei danni se lo supera.\n\nUn lato del muro, scelto dall'incantatore quando lancia l'incantesimo, infligge 5d8 danni da fuoco a ogni creatura che termina il proprio turno entro 3 metri da quel lato o all'interno del muro. Una creatura subisce gli stessi danni quando entra nel muro per la prima volta in un turno o vi termina il proprio turno. L'altro lato del muro non infligge danni.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 4°."
				}
			}
		};
	}
}
