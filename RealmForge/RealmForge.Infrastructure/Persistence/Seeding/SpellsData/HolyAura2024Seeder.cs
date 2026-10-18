using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Holy Aura (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HolyAura2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "holy-aura");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "holy-aura", "en"),
					Language = LanguageCode.En,
					Name = "Holy Aura",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a reliquary worth 1,000+ GP",
					Description = "For the duration, you emit an aura in a 30-foot Emanation. While in the aura, creatures of your choice have Advantage on all saving throws, and other creatures have Disadvantage on attack rolls against them. In addition, when a Fiend or an Undead hits an affected creature with a melee attack roll, the attacker must succeed on a Constitution saving throw or have the Blinded condition until the end of its next turn.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "holy-aura", "it"),
					Language = LanguageCode.It,
					Name = "Aura Sacra",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un reliquiario del valore di almeno 1.000 mo",
					Description = "Per la durata, l'incantatore emana un'aura in un'emanazione di 9 metri. Finché si trovano nell'aura, le creature a sua scelta dispongono di vantaggio a tutti i tiri salvezza, e le altre creature subiscono svantaggio ai tiri per colpire contro di esse. Inoltre, quando un immondo o un non morto colpisce una creatura influenzata con un tiro per colpire in mischia, l'attaccante deve superare un tiro salvezza su Costituzione, altrimenti è accecato fino alla fine del suo turno successivo.",
					HigherLevels = null
				}
			}
		};
	}
}
