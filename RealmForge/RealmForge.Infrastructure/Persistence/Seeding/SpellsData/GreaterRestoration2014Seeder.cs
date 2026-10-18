using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Greater Restoration (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GreaterRestoration2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "greater-restoration");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "greater-restoration", "en"),
					Language = LanguageCode.En,
					Name = "Greater Restoration",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "diamond dust worth at least 100 gp, which the spell consumes",
					Description = "You imbue a creature you touch with positive energy to undo a debilitating effect. You can reduce the target's exhaustion level by one, or end one of the following effects on the target:\n\n- One effect that charmed or petrified the target\n\n- One curse, including the target's attunement to a cursed magic item\n\n- Any reduction to one of the target's ability scores\n\n- One effect reducing the target's hit point maximum",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "greater-restoration", "it"),
					Language = LanguageCode.It,
					Name = "Ristorare Superiore",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "polvere di diamante del valore di almeno 100 mo, che l'incantesimo consuma",
					Description = "L'incantatore infonde energia positiva in una creatura che tocca per annullare un effetto debilitante. Può ridurre di uno il livello di indebolimento del bersaglio, oppure porre fine a uno degli effetti seguenti sul bersaglio:\n\n- Un effetto che ha reso il bersaglio affascinato o pietrificato\n\n- Una maledizione, inclusa la sintonia del bersaglio con un oggetto magico maledetto\n\n- Qualsiasi riduzione di uno dei punteggi di caratteristica del bersaglio\n\n- Un effetto che riduce il massimo dei punti ferita del bersaglio",
					HigherLevels = null
				}
			}
		};
	}
}
