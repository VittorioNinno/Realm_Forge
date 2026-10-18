using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dispel Magic (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DispelMagic2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dispel-magic");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Ranger, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dispel-magic", "en"),
					Language = LanguageCode.En,
					Name = "Dispel Magic",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Choose one creature, object, or magical effect within range. Any ongoing spell of level 3 or lower on the target ends. For each ongoing spell of level 4 or higher on the target, make an ability check using your spellcasting ability (DC 10 plus that spell's level). On a successful check, the spell ends.",
					HigherLevels = "You automatically end a spell on the target if the spell's level is equal to or less than the level of the spell slot you use."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dispel-magic", "it"),
					Language = LanguageCode.It,
					Name = "Dissolvi Magie",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore sceglie una creatura, un oggetto o un effetto magico entro gittata. Qualsiasi incantesimo in corso di 3° livello o inferiore sul bersaglio termina. Per ogni incantesimo in corso di 4° livello o superiore sul bersaglio, l'incantatore effettua una prova di caratteristica usando la propria caratteristica da incantatore (CD 10 più il livello di quell'incantesimo). Se la supera, l'incantesimo termina.",
					HigherLevels = "L'incantatore pone fine automaticamente a un incantesimo sul bersaglio se il livello dell'incantesimo è pari o inferiore al livello dello slot incantesimo usato."
				}
			}
		};
	}
}
