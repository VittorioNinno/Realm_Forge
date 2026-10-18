using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Greater Restoration (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GreaterRestoration2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "greater-restoration");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "greater-restoration", "en"),
					Language = LanguageCode.En,
					Name = "Greater Restoration",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "diamond dust worth 100+ GP, which the spell consumes",
					Description = "You touch a creature and magically remove one of the following effects from it:\n\n- 1 Exhaustion level\n\n- The Charmed or Petrified condition\n\n- A curse, including the target's Attunement to a cursed magic item\n\n- Any reduction to one of the target's ability scores\n\n- Any reduction to the target's Hit Point maximum",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "greater-restoration", "it"),
					Language = LanguageCode.It,
					Name = "Ristorare Superiore",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "polvere di diamante del valore di almeno 100 mo, che l'incantesimo consuma",
					Description = "L'incantatore tocca una creatura e rimuove magicamente da essa uno degli effetti seguenti:\n\n- 1 livello di indebolimento\n\n- La condizione affascinato o pietrificato\n\n- Una maledizione, inclusa la sintonia del bersaglio con un oggetto magico maledetto\n\n- Qualsiasi riduzione di uno dei punteggi di caratteristica del bersaglio\n\n- Qualsiasi riduzione del massimo dei punti ferita del bersaglio",
					HigherLevels = null
				}
			}
		};
	}
}
