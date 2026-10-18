using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wall of Ice (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WallOfIce2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-ice");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-ice", "en"),
					Language = LanguageCode.En,
					Name = "Wall of Ice",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a piece of quartz",
					Description = "You create a wall of ice on a solid surface within range. You can form it into a hemispherical dome or a globe with a radius of up to 10 feet, or you can shape a flat surface made up of ten 10-foot-square panels. Each panel must be contiguous with another panel. In any form, the wall is 1 foot thick and lasts for the duration.\n\nIf the wall cuts through a creature's space when it appears, the creature is pushed to one side of the wall (you choose which side) and makes a Dexterity saving throw, taking 10d6 Cold damage on a failed save or half as much damage on a successful one.\n\nThe wall is an object that can be damaged and thus breached. It has AC 12 and 30 Hit Points per 10-foot section, and it has Immunity to Cold, Poison, and Psychic damage and Vulnerability to Fire damage. Reducing a 10-foot section of wall to 0 Hit Points destroys it and leaves behind a sheet of frigid air in the space the wall occupied.\n\nA creature moving through the sheet of frigid air for the first time on a turn makes a Constitution saving throw, taking 5d6 Cold damage on a failed save or half as much damage on a successful one.",
					HigherLevels = "The damage the wall deals when it appears increases by 2d6 and the damage from passing through the sheet of frigid air increases by 1d6 for each spell slot level above 6."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-ice", "it"),
					Language = LanguageCode.It,
					Name = "Muro di Ghiaccio",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un pezzo di quarzo",
					Description = "L'incantatore crea un muro di ghiaccio su una superficie solida entro gittata. Può dargli la forma di una cupola emisferica o di un globo con un raggio fino a 3 metri, oppure di una superficie piatta composta da dieci pannelli quadrati di 3 metri di lato. Ogni pannello deve essere adiacente a un altro pannello. In qualsiasi forma, il muro è spesso 30 centimetri e permane per la durata.\n\nSe il muro attraversa lo spazio di una creatura quando compare, la creatura viene spinta su un lato del muro (a scelta dell'incantatore) ed effettua un tiro salvezza su Destrezza, subendo 10d6 danni da freddo se lo fallisce, o la metà di quei danni se lo supera.\n\nIl muro è un oggetto che può essere danneggiato e quindi sfondato. Ha CA 12 e 30 punti ferita per ogni sezione di 3 metri, è immune ai danni da freddo, psichici e da veleno ed è vulnerabile ai danni da fuoco. Ridurre a 0 punti ferita una sezione di muro di 3 metri la distrugge e lascia al suo posto una cortina di aria gelida nello spazio occupato dal muro.\n\nUna creatura che si muove attraverso la cortina di aria gelida per la prima volta in un turno effettua un tiro salvezza su Costituzione, subendo 5d6 danni da freddo se lo fallisce, o la metà di quei danni se lo supera.",
					HigherLevels = "I danni inflitti dal muro quando compare aumentano di 2d6 e i danni inflitti dall'attraversamento della cortina di aria gelida aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 6°."
				}
			}
		};
	}
}
