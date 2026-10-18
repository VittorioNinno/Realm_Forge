using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Tsunami (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Tsunami2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tsunami");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tsunami", "en"),
					Language = LanguageCode.En,
					Name = "Tsunami",
					CastingTime = "1 minute",
					Range = "1 mile",
					Duration = "Concentration, up to 6 rounds",
					MaterialComponent = null,
					Description = "A wall of water springs into existence at a point you choose within range. You can make the wall up to 300 feet long, 300 feet high, and 50 feet thick. The wall lasts for the duration.\n\nWhen the wall appears, each creature in its area makes a Strength saving throw, taking 6d10 Bludgeoning damage on a failed save or half as much damage on a successful one.\n\nAt the start of each of your turns after the wall appears, the wall, along with any creatures in it, moves 50 feet away from you. Any Huge or smaller creature inside the wall or whose space the wall enters when it moves must succeed on a Strength saving throw or take 5d10 Bludgeoning damage. A creature can take this damage only once per round. At the end of the turn, the wall's height is reduced by 50 feet, and the damage the wall deals on later rounds is reduced by 1d10. When the wall reaches 0 feet in height, the spell ends.\n\nA creature caught in the wall can move by swimming. Because of the wave's force, though, the creature must succeed on a Strength (Athletics) check against your spell save DC to move at all. If it fails the check, it can't move. A creature that moves out of the wall falls to the ground.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tsunami", "it"),
					Language = LanguageCode.It,
					Name = "Tsunami",
					CastingTime = "1 minuto",
					Range = "1,5 km",
					Duration = "Concentrazione, fino a 6 round",
					MaterialComponent = null,
					Description = "Un muro d'acqua prende forma in un punto entro gittata a scelta dell'incantatore. L'incantatore può creare un muro lungo fino a 90 metri, alto fino a 90 metri e spesso fino a 15 metri. Il muro permane per la durata.\n\nQuando il muro compare, ogni creatura nella sua area effettua un tiro salvezza su Forza, subendo 6d10 danni contundenti se lo fallisce, o la metà di quei danni se lo supera.\n\nAll'inizio di ogni turno dell'incantatore successivo alla comparsa del muro, il muro, insieme a tutte le creature al suo interno, si allontana di 15 metri dall'incantatore. Qualsiasi creatura di taglia Enorme o inferiore che si trova all'interno del muro o nel cui spazio il muro entra mentre si sposta deve superare un tiro salvezza su Forza, altrimenti subisce 5d10 danni contundenti. Una creatura può subire questi danni soltanto una volta per round. Alla fine del turno, l'altezza del muro si riduce di 15 metri e i danni che il muro infligge nei round successivi si riducono di 1d10. Quando l'altezza del muro scende a 0 metri, l'incantesimo termina.\n\nUna creatura intrappolata nel muro può muoversi nuotando. A causa della forza dell'onda, tuttavia, la creatura deve superare una prova di Forza (Atletica) contro la CD del tiro salvezza degli incantesimi dell'incantatore per potersi muovere. Se fallisce la prova, non può muoversi. Una creatura che esce dal muro cade a terra.",
					HigherLevels = null
				}
			}
		};
	}
}
