using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Befuddlement (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Befuddlement2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "befuddlement");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "befuddlement", "en"),
					Language = LanguageCode.En,
					Name = "Befuddlement",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a key ring with no keys",
					Description = "You blast the mind of a creature that you can see within range. The target makes an Intelligence saving throw.\n\nOn a failed save, the target takes 10d12 Psychic damage and can't cast spells or take the Magic action. At the end of every 30 days, the target repeats the save, ending the effect on a success. The effect can also be ended by the *Greater Restoration*, *Heal*, or *Wish* spell.\n\nOn a successful save, the target takes half as much damage only.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "befuddlement", "it"),
					Language = LanguageCode.It,
					Name = "Disorientare",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "un portachiavi senza chiavi",
					Description = "L'incantatore investe con un'esplosione la mente di una creatura entro gittata che è in grado di vedere. Il bersaglio effettua un tiro salvezza su Intelligenza.\n\nSe lo fallisce, il bersaglio subisce 10d12 danni psichici e non può lanciare incantesimi né effettuare l'azione di Magia. Alla fine di ogni periodo di 30 giorni, il bersaglio ripete il tiro salvezza e, se lo supera, l'effetto termina. L'effetto può essere terminato anche dagli incantesimi *ristorare superiore*, *guarigione* o *desiderio*.\n\nSe lo supera, il bersaglio subisce soltanto la metà dei danni.",
					HigherLevels = null
				}
			}
		};
	}
}
