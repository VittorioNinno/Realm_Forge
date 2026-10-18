using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wall of Ice (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WallOfIce2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-ice");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-ice", "en"),
					Language = LanguageCode.En,
					Name = "Wall of Ice",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a small piece of quartz",
					Description = "You create a wall of ice on a solid surface within range. You can form it into a hemispherical dome or a sphere with a radius of up to 10 feet, or you can shape a flat surface made up of ten 10-foot-square panels. Each panel must be contiguous with another panel. In any form, the wall is 1 foot thick and lasts for the duration.\n\nIf the wall cuts through a creature's space when it appears, the creature within its area is pushed to one side of the wall and must make a Dexterity saving throw. On a failed save, the creature takes 10d6 cold damage, or half as much damage on a successful save.\n\nThe wall is an object that can be damaged and thus breached. It has AC 12 and 30 hit points per 10-foot section, and it is vulnerable to fire damage. Reducing a 10-foot section of wall to 0 hit points destroys it and leaves behind a sheet of frigid air in the space the wall occupied. A creature moving through the sheet of frigid air for the first time on a turn must make a Constitution saving throw. That creature takes 5d6 cold damage on a failed save, or half as much damage on a successful one.",
					HigherLevels = "When you cast this spell using a spell slot of 7th level or higher, the damage the wall deals when it appears increases by 2d6, and the damage from passing through the sheet of frigid air increases by 1d6, for each slot level above 6th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-ice", "it"),
					Language = LanguageCode.It,
					Name = "Muro di Ghiaccio",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un piccolo pezzo di quarzo",
					Description = "L'incantatore crea un muro di ghiaccio su una superficie solida entro gittata. Può dargli la forma di una cupola semisferica o di una sfera con un raggio massimo di 3 metri, oppure modellare una superficie piana composta da dieci pannelli di 3 metri di lato. Ogni pannello deve essere adiacente a un altro pannello. In qualsiasi forma, il muro è spesso 30 cm e dura per la durata.\n\nSe, quando compare, il muro attraversa lo spazio di una creatura, la creatura nella sua area viene spinta su uno dei lati del muro e deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, la creatura subisce 10d6 danni da freddo; se lo supera, subisce la metà di quei danni.\n\nIl muro è un oggetto che può essere danneggiato e quindi aperto. Ha CA 12 e 30 punti ferita per ogni sezione di 3 metri, ed è vulnerabile ai danni da fuoco. Ridurre una sezione di muro di 3 metri a 0 punti ferita la distrugge e lascia una cortina di aria gelida nello spazio occupato dal muro. Una creatura che attraversa la cortina di aria gelida per la prima volta in un turno deve effettuare un tiro salvezza su Costituzione. Quella creatura subisce 5d6 danni da freddo se fallisce il tiro salvezza, o la metà di quei danni se lo supera.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 7° livello o superiore, i danni inflitti dal muro quando compare aumentano di 2d6 e i danni inflitti dall'attraversamento della cortina di aria gelida aumentano di 1d6, per ogni livello dello slot superiore al 6°."
				}
			}
		};
	}
}
