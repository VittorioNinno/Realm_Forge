using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Toll the Dead (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class TollTheDead2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "toll-the-dead");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 0,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "toll-the-dead", "en"),
					Language = LanguageCode.En,
					Name = "Toll the Dead",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You point toward a creature you can see within range, and a funeral bell sounds once, close beside it. The creature attempts a Wisdom saving throw. If it fails, it suffers Necrotic damage: 1d8 if it has all its Hit Points, or 1d12 if it is already wounded.",
					HigherLevels = "The damage grows by one die at level 5 (2d8 or 2d12), level 11 (3d8 or 3d12), and level 17 (4d8 or 4d12)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "toll-the-dead", "it"),
					Language = LanguageCode.It,
					Name = "Rintocco dei Morti",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore indica una creatura entro gittata che è in grado di vedere, e una campana funebre suona una sola volta, proprio accanto a lei. La creatura tenta un tiro salvezza su Saggezza. Se fallisce, subisce danni necrotici: 1d8 se ha tutti i suoi punti ferita, oppure 1d12 se è già ferita.",
					HigherLevels = "I danni crescono di un dado al 5° livello (2d8 o 2d12), all'11° livello (3d8 o 3d12) e al 17° livello (4d8 o 4d12)."
				}
			}
		};
	}
}
