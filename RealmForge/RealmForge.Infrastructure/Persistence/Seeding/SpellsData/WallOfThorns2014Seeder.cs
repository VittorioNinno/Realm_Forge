using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wall of Thorns (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WallOfThorns2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-thorns");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-thorns", "en"),
					Language = LanguageCode.En,
					Name = "Wall of Thorns",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a handful of thorns",
					Description = "You create a wall of tough, pliable, tangled brush bristling with needle-sharp thorns. The wall appears within range on a solid surface and lasts for the duration. You choose to make the wall up to 60 feet long, 10 feet high, and 5 feet thick or a circle that has a 20-foot diameter and is up to 20 feet high and 5 feet thick. The wall blocks line of sight.\n\nWhen the wall appears, each creature within its area must make a Dexterity saving throw. On a failed save, a creature takes 7d8 piercing damage, or half as much damage on a successful save.\n\nA creature can move through the wall, albeit slowly and painfully. For every 1 foot a creature moves through the wall, it must spend 4 feet of movement. Furthermore, the first time a creature enters the wall on a turn or ends its turn there, the creature must make a Dexterity saving throw. It takes 7d8 slashing damage on a failed save, or half as much damage on a successful one.",
					HigherLevels = "When you cast this spell using a spell slot of 7th level or higher, both types of damage increase by 1d8 for each slot level above 6th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-thorns", "it"),
					Language = LanguageCode.It,
					Name = "Muro di Spine",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una manciata di spine",
					Description = "L'incantatore crea un muro di sterpaglia resistente, flessibile e intricata, irta di spine aguzze come aghi. Il muro compare entro gittata su una superficie solida e dura per la durata. L'incantatore può creare un muro lungo fino a 18 metri, alto 3 metri e spesso 1,5 metri, oppure un cerchio del diametro di 6 metri, alto fino a 6 metri e spesso 1,5 metri. Il muro blocca la linea di vista.\n\nQuando il muro compare, ogni creatura nella sua area deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, la creatura subisce 7d8 danni perforanti; se lo supera, subisce la metà di quei danni.\n\nUna creatura può attraversare il muro, anche se lentamente e dolorosamente. Per ogni metro percorso attraverso il muro, la creatura deve spendere 4 metri di movimento. Inoltre, la prima volta che una creatura entra nel muro in un turno o vi termina il proprio turno, deve effettuare un tiro salvezza su Destrezza. Subisce 7d8 danni taglienti se fallisce il tiro salvezza, o la metà di quei danni se lo supera.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 7° livello o superiore, entrambi i tipi di danni aumentano di 1d8 per ogni livello dello slot superiore al 6°."
				}
			}
		};
	}
}
