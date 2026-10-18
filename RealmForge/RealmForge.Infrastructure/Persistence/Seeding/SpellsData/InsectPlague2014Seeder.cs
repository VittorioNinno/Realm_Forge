using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Insect Plague (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class InsectPlague2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "insect-plague");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Conjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "insect-plague", "en"),
					Language = LanguageCode.En,
					Name = "Insect Plague",
					CastingTime = "1 action",
					Range = "300 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a few grains of sugar, some kernels of grain, and a smear of fat",
					Description = "Swarming, biting locusts fill a 20-foot-radius sphere centered on a point you choose within range. The sphere spreads around corners. The sphere remains for the duration, and its area is lightly obscured. The sphere's area is difficult terrain.\n\nWhen the area appears, each creature in it must make a Constitution saving throw. A creature takes 4d10 piercing damage on a failed save, or half as much damage on a successful one. A creature must also make this saving throw when it enters the spell's area for the first time on a turn or ends its turn there.",
					HigherLevels = "When you cast this spell using a spell slot of 6th level or higher, the damage increases by 1d10 for each slot level above 5th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "insect-plague", "it"),
					Language = LanguageCode.It,
					Name = "Piaga degli Insetti",
					CastingTime = "1 azione",
					Range = "90 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "qualche granello di zucchero, alcuni chicchi di cereale e una spalmata di grasso",
					Description = "Uno sciame di locuste fameliche riempie una sfera del raggio di 6 metri centrata su un punto entro gittata scelto dall'incantatore. La sfera si propaga dietro gli angoli. La sfera rimane per la durata e la sua area è leggermente oscurata. L'area della sfera è terreno difficile.\n\nQuando l'area compare, ogni creatura al suo interno deve effettuare un tiro salvezza su Costituzione. Una creatura subisce 4d10 danni perforanti se fallisce il tiro salvezza, o la metà di quei danni se lo supera. Una creatura deve effettuare questo tiro salvezza anche quando entra nell'area dell'incantesimo per la prima volta in un turno o vi termina il proprio turno.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 6° livello o superiore, i danni aumentano di 1d10 per ogni livello dello slot superiore al 5°."
				}
			}
		};
	}
}
