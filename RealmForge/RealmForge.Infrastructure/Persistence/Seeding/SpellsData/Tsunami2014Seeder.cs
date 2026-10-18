using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Tsunami (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class Tsunami2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "tsunami");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "tsunami", "en"),
					Language = LanguageCode.En,
					Name = "Tsunami",
					CastingTime = "1 minute",
					Range = "Sight",
					Duration = "Concentration, up to 6 rounds",
					MaterialComponent = null,
					Description = "A towering wall of water rises at a point you choose within range. The wall can be up to 300 feet long, 300 feet high, and 50 feet thick, and it lasts for the duration.\n\nWhen the wall appears, each creature in its area makes a Strength saving throw, taking 6d10 bludgeoning damage on a failure or half as much on a success.\n\nAt the start of each of your turns after the wall appears, the wall moves 50 feet away from you, carrying along any creatures inside it. Any Huge or smaller creature inside the wall, or whose space the wall enters as it moves, must succeed on a Strength saving throw or take 5d10 bludgeoning damage; a creature can take this damage only once per round. At the end of each of your turns, the wall loses 50 feet of height, and the damage it deals in later rounds drops by 1d10. The spell ends when the wall's height reaches 0.\n\nA creature caught in the wall can move by swimming, but the force of the wave means it must first succeed on a Strength (Athletics) check against your spell save DC to move at all; on a failure, it can't move that turn. A creature that leaves the wall's area falls to the ground.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "tsunami", "it"),
					Language = LanguageCode.It,
					Name = "Tsunami",
					CastingTime = "1 minuto",
					Range = "Vista",
					Duration = "Concentrazione, fino a 6 round",
					MaterialComponent = null,
					Description = "Un'immensa muraglia d'acqua si innalza in un punto entro gittata scelto dall'incantatore. Il muro può essere lungo fino a 90 metri, alto fino a 90 metri e spesso fino a 15 metri, e dura per la durata.\n\nQuando il muro compare, ogni creatura nella sua area effettua un tiro salvezza su Forza; subisce 6d10 danni contundenti se lo fallisce, o la metà di quei danni se lo supera.\n\nAll'inizio di ogni turno dell'incantatore dopo la comparsa del muro, il muro si allontana da lui di 15 metri, trascinando con sé le creature che si trovano al suo interno. Qualsiasi creatura di taglia Enorme o inferiore che si trova all'interno del muro, o nel cui spazio il muro entra mentre si muove, deve superare un tiro salvezza su Forza, altrimenti subisce 5d10 danni contundenti; una creatura può subire questi danni solo una volta per round. Alla fine di ogni turno dell'incantatore, l'altezza del muro si riduce di 15 metri e i danni che infligge nei round successivi diminuiscono di 1d10. L'incantesimo termina quando l'altezza del muro arriva a 0.\n\nUna creatura intrappolata nel muro può muoversi nuotando, ma a causa della forza dell'onda deve prima superare una prova di Forza (Atletica) contro la CD del tiro salvezza degli incantesimi dell'incantatore per potersi muovere; se la fallisce, non può muoversi in quel turno. Una creatura che esce dall'area del muro cade a terra.",
					HigherLevels = null
				}
			}
		};
	}
}
