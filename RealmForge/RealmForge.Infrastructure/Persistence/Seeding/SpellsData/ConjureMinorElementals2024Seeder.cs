using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Minor Elementals (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConjureMinorElementals2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-minor-elementals");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-minor-elementals", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Minor Elementals",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You conjure spirits from the Elemental Planes that flit around you in a 15-foot Emanation for the duration. Until the spell ends, any attack you make deals an extra 2d8 damage when you hit a creature in the Emanation. This damage is Acid, Cold, Fire, or Lightning (your choice when you make the attack).\n\nIn addition, the ground in the Emanation is Difficult Terrain for your enemies.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-minor-elementals", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Elementali Minori",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore evoca spiriti dai Piani Elementali che gli svolazzano intorno in un'emanazione di 4,5 metri per la durata. Finché l'incantesimo non termina, qualsiasi attacco effettuato dall'incantatore infligge 2d8 danni extra quando colpisce una creatura nell'emanazione. Questi danni sono da acido, da freddo, da fuoco o da fulmine (a scelta dell'incantatore quando effettua l'attacco).\n\nInoltre, il terreno nell'emanazione è terreno difficile per i nemici dell'incantatore.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 4°."
				}
			}
		};
	}
}
