using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Earthquake (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Earthquake2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "earthquake");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Transmutation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "earthquake", "en"),
					Language = LanguageCode.En,
					Name = "Earthquake",
					CastingTime = "Action",
					Range = "500 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a fractured rock",
					Description = "Choose a point on the ground that you can see within range. For the duration, an intense tremor rips through the ground in a 100-foot-radius circle centered on that point. The ground there is Difficult Terrain.\n\nWhen you cast this spell and at the end of each of your turns for the duration, each creature on the ground in the area makes a Dexterity saving throw. On a failed save, a creature has the Prone condition, and its Concentration is broken.\n\nYou can also cause the effects below.\n\n***Fissures.*** A total of 1d6 fissures open in the spell's area at the end of the turn you cast it. You choose the fissures' locations, which can't be under structures. Each fissure is 1d10 × 10 feet deep and 10 feet wide, and it extends from one edge of the spell's area to another edge. A creature in the same space as a fissure must succeed on a Dexterity saving throw or fall in. A creature that successfully saves moves with the fissure's edge as it opens.\n\n***Structures.*** The tremor deals 50 Bludgeoning damage to any structure in contact with the ground in the area when you cast the spell and at the end of each of your turns until the spell ends. If a structure drops to 0 Hit Points, it collapses.\n\nA creature within a distance from a collapsing structure equal to half the structure's height makes a Dexterity saving throw. On a failed save, the creature takes 12d6 Bludgeoning damage, has the Prone condition, and is buried in the rubble, requiring a DC 20 Strength (Athletics) check as an action to escape. On a successful save, the creature takes half as much damage only.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "earthquake", "it"),
					Language = LanguageCode.It,
					Name = "Terremoto",
					CastingTime = "Azione",
					Range = "150 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una roccia spaccata",
					Description = "L'incantatore sceglie un punto sul terreno entro gittata che è in grado di vedere. Per la durata, un intenso tremore squarcia il terreno in un cerchio del raggio di 30 metri centrato su quel punto. Il terreno in quell'area è terreno difficile.\n\nQuando l'incantatore lancia questo incantesimo e alla fine di ogni suo turno per la durata, ogni creatura sul terreno nell'area effettua un tiro salvezza su Destrezza. Se lo fallisce, una creatura cade prona e la sua concentrazione si interrompe.\n\nL'incantatore può anche provocare gli effetti seguenti.\n\n***Fenditure.*** Alla fine del turno in cui l'incantesimo viene lanciato, nell'area dell'incantesimo si aprono in totale 1d6 fenditure. L'incantatore sceglie la posizione delle fenditure, che non possono trovarsi sotto delle strutture. Ogni fenditura è profonda 1d10 × 3 metri e larga 3 metri, e si estende da un bordo all'altro dell'area dell'incantesimo. Una creatura che si trova nello stesso spazio di una fenditura deve superare un tiro salvezza su Destrezza, altrimenti vi cade dentro. Una creatura che supera il tiro salvezza si sposta insieme al bordo della fenditura mentre questa si apre.\n\n***Strutture.*** Il tremore infligge 50 danni contundenti a qualsiasi struttura a contatto con il terreno nell'area quando l'incantatore lancia l'incantesimo e alla fine di ogni suo turno, finché l'incantesimo non termina. Se una struttura scende a 0 punti ferita, crolla.\n\nUna creatura che si trova a una distanza da una struttura che crolla pari alla metà dell'altezza della struttura effettua un tiro salvezza su Destrezza. Se lo fallisce, la creatura subisce 12d6 danni contundenti, cade prona e rimane sepolta tra le macerie; per liberarsi deve superare una prova di Forza (Atletica) con CD 20 effettuata come azione. Se lo supera, la creatura subisce soltanto la metà dei danni.",
					HigherLevels = null
				}
			}
		};
	}
}
