using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Earthquake (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Earthquake2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "earthquake");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Sorcerer },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "earthquake", "en"),
					Language = LanguageCode.En,
					Name = "Earthquake",
					CastingTime = "1 action",
					Range = "500 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a pinch of dirt, a piece of rock, and a lump of clay",
					Description = "You create a seismic disturbance at a point on the ground that you can see within range. For the duration, an intense tremor rips through the ground in a 100-foot-radius circle centered on that point and shakes creatures and structures in contact with the ground in that area.\n\nThe ground in the area becomes difficult terrain. Each creature on the ground that is concentrating must make a Constitution saving throw. On a failed save, the creature's concentration is broken.\n\nWhen you cast this spell and at the end of each turn you spend concentrating on it, each creature on the ground in the area must make a Dexterity saving throw. On a failed save, the creature is knocked prone.\n\nThis spell can have additional effects depending on the terrain in the area, as determined by the GM.\n\n***Fissures.*** Fissures open throughout the spell's area at the start of your next turn after you cast the spell. A total of 1d6 such fissures open in locations chosen by the GM. Each is 1d10 x 10 feet deep, 10 feet wide, and extends from one edge of the spell's area to the opposite side. A creature standing on a spot where a fissure opens must succeed on a Dexterity saving throw or fall in. A creature that successfully saves moves with the fissure's edge as it opens.\n\nA fissure that opens beneath a structure causes it to automatically collapse (see below).\n\n***Structures.*** The tremor deals 50 bludgeoning damage to any structure in contact with the ground in the area when you cast the spell and at the start of each of your turns until the spell ends. If a structure drops to 0 hit points, it collapses and potentially damages nearby creatures. A creature within half the distance of a structure's height must make a Dexterity saving throw. On a failed save, the creature takes 5d6 bludgeoning damage, is knocked prone, and is buried in the rubble, requiring a DC 20 Strength (Athletics) check as an action to escape. The GM can adjust the DC higher or lower, depending on the nature of the rubble. On a successful save, the creature takes half as much damage and doesn't fall prone or become buried.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "earthquake", "it"),
					Language = LanguageCode.It,
					Name = "Terremoto",
					CastingTime = "1 azione",
					Range = "150 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pizzico di terra, un frammento di roccia e un grumo d'argilla",
					Description = "L'incantatore crea una scossa sismica in un punto del terreno entro gittata che sia in grado di vedere. Per la durata, un intenso tremore squarcia il terreno in un cerchio del raggio di 30 metri centrato su quel punto e scuote le creature e le strutture che si trovano a contatto con il terreno nell'area.\n\nIl terreno nell'area diventa terreno difficile. Ogni creatura sul terreno che sta mantenendo la concentrazione deve effettuare un tiro salvezza su Costituzione. Se lo fallisce, la sua concentrazione si interrompe.\n\nQuando l'incantatore lancia questo incantesimo e alla fine di ogni turno trascorso a mantenere la concentrazione su di esso, ogni creatura sul terreno nell'area deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, la creatura cade prona.\n\nQuesto incantesimo può avere effetti aggiuntivi a seconda del terreno nell'area, come stabilito dal DM.\n\n***Fenditure.*** All'inizio del turno dell'incantatore successivo al lancio dell'incantesimo, si aprono delle fenditure in tutta l'area dell'incantesimo. In totale si aprono 1d6 fenditure, nei punti scelti dal DM. Ognuna è profonda 1d10 × 3 metri, larga 3 metri e si estende da un bordo all'altro dell'area dell'incantesimo. Una creatura che si trova in un punto in cui si apre una fenditura deve superare un tiro salvezza su Destrezza, altrimenti vi cade dentro. Una creatura che supera il tiro salvezza si sposta con il bordo della fenditura mentre questa si apre.\n\nUna fenditura che si apre sotto una struttura la fa crollare automaticamente (vedi sotto).\n\n***Strutture.*** Il tremore infligge 50 danni contundenti a ogni struttura a contatto con il terreno nell'area quando l'incantatore lancia l'incantesimo e all'inizio di ogni suo turno, finché l'incantesimo non termina. Se una struttura scende a 0 punti ferita, crolla e può danneggiare le creature vicine. Una creatura che si trova entro una distanza pari alla metà dell'altezza della struttura deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, subisce 5d6 danni contundenti, cade prona e resta sepolta sotto le macerie; per liberarsi deve superare una prova di Forza (Atletica) con CD 20, usando un'azione. Il DM può alzare o abbassare la CD a seconda della natura delle macerie. Se supera il tiro salvezza, la creatura subisce la metà di quei danni, non cade prona e non resta sepolta.",
					HigherLevels = null
				}
			}
		};
	}
}
