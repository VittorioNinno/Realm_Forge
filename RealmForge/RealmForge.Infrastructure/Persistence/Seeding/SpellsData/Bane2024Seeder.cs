using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Bane (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Bane2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "bane");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "bane", "en"),
					Language = LanguageCode.En,
					Name = "Bane",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a drop of blood",
					Description = "Up to three creatures of your choice that you can see within range must each make a Charisma saving throw. Whenever a target that fails this save makes an attack roll or a saving throw before the spell ends, the target must subtract 1d4 from the attack roll or save.",
					HigherLevels = "You can target one additional creature for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "bane", "it"),
					Language = LanguageCode.It,
					Name = "Anatema",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una goccia di sangue",
					Description = "Fino a tre creature a scelta dell'incantatore, che è in grado di vedere entro gittata, devono effettuare ciascuna un tiro salvezza su Carisma. Ogni volta che un bersaglio che ha fallito questo tiro salvezza effettua un tiro per colpire o un tiro salvezza prima che l'incantesimo termini, deve sottrarre 1d4 al tiro per colpire o al tiro salvezza.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
