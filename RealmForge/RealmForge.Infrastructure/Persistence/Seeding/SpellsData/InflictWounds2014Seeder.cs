using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Inflict Wounds (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class InflictWounds2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "inflict-wounds");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "inflict-wounds", "en"),
					Language = LanguageCode.En,
					Name = "Inflict Wounds",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Make a melee spell attack against a creature you can reach. On a hit, the target takes 3d10 necrotic damage.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d10 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "inflict-wounds", "it"),
					Language = LanguageCode.It,
					Name = "Infliggi Ferite",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore effettua un attacco con incantesimo in mischia contro una creatura a portata. Se colpisce, il bersaglio subisce 3d10 danni necrotici.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni aumentano di 1d10 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
