using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arms of Hadar (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ArmsOfHadar2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arms-of-hadar");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arms-of-hadar", "en"),
					Language = LanguageCode.En,
					Name = "Arms of Hadar",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Calling on the dark power of Hadar, you make shadowy tendrils whip outward from your body. They reach every creature in a 10-foot Emanation centered on you, and each of those creatures attempts a Strength saving throw.\n\n- **Failure:** 2d6 Necrotic damage, and the creature loses the use of its Reaction until its next turn begins.\n- **Success:** half the damage and no other effect.",
					HigherLevels = "Add 1d6 to the damage for each slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arms-of-hadar", "it"),
					Language = LanguageCode.It,
					Name = "Braccia di Hadar",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Attingendo all'oscuro potere di Hadar, l'incantatore fa saettare dal proprio corpo dei viticci d'ombra. Raggiungono tutte le creature in un'emanazione di 3 metri centrata su di lui, e ognuna di esse tenta un tiro salvezza su Forza.\n\n- **Fallimento:** 2d6 danni necrotici, e la creatura perde l'uso della propria reazione finché non inizia il suo turno successivo.\n- **Successo:** metà dei danni e nessun altro effetto.",
					HigherLevels = "Aggiungere 1d6 ai danni per ogni livello dello slot oltre il 1°."
				}
			}
		};
	}
}
