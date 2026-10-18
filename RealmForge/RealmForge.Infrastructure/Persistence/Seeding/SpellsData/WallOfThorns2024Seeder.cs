using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wall of Thorns (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WallOfThorns2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-thorns");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-thorns", "en"),
					Language = LanguageCode.En,
					Name = "Wall of Thorns",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a handful of thorns",
					Description = "You create a wall of tangled brush bristling with needle-sharp thorns. The wall appears within range on a solid surface and lasts for the duration. You choose to make the wall up to 60 feet long, 10 feet high, and 5 feet thick or a circle that has a 20-foot diameter and is up to 20 feet high and 5 feet thick. The wall blocks line of sight.\n\nWhen the wall appears, each creature in its area makes a Dexterity saving throw, taking 7d8 Piercing damage on a failed save or half as much damage on a successful one.\n\nA creature can move through the wall, albeit slowly and painfully. For every 1 foot a creature moves through the wall, it must spend 4 feet of movement. Furthermore, the first time a creature enters a space in the wall on a turn or ends its turn there, the creature makes a Dexterity saving throw, taking 7d8 Slashing damage on a failed save or half as much damage on a successful one. A creature makes this save only once per turn.",
					HigherLevels = "Both types of damage increase by 1d8 for each spell slot level above 6."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-thorns", "it"),
					Language = LanguageCode.It,
					Name = "Muro di Spine",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una manciata di spine",
					Description = "L'incantatore crea un muro di sterpaglia aggrovigliata irta di spine aguzze come aghi. Il muro compare entro gittata su una superficie solida e permane per la durata. L'incantatore può creare un muro lungo fino a 18 metri, alto fino a 3 metri e spesso 1,5 metri, oppure un cerchio con un diametro di 6 metri, alto fino a 6 metri e spesso 1,5 metri. Il muro blocca la linea di vista.\n\nQuando il muro compare, ogni creatura nella sua area effettua un tiro salvezza su Destrezza, subendo 7d8 danni perforanti se lo fallisce, o la metà di quei danni se lo supera.\n\nUna creatura può attraversare il muro, anche se lentamente e dolorosamente. Per ogni metro percorso attraverso il muro, una creatura deve spendere 4 metri di movimento. Inoltre, la prima volta in un turno in cui una creatura entra in uno spazio del muro o vi termina il proprio turno, la creatura effettua un tiro salvezza su Destrezza, subendo 7d8 danni taglienti se lo fallisce, o la metà di quei danni se lo supera. Una creatura effettua questo tiro salvezza soltanto una volta per turno.",
					HigherLevels = "Entrambi i tipi di danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 6°."
				}
			}
		};
	}
}
