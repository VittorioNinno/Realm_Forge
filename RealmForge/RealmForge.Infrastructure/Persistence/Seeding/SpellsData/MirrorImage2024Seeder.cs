using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mirror Image (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MirrorImage2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mirror-image");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mirror-image", "en"),
					Language = LanguageCode.En,
					Name = "Mirror Image",
					CastingTime = "Action",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "Three illusory duplicates of yourself appear in your space. Until the spell ends, the duplicates move with you and mimic your actions, shifting position so it's impossible to track which image is real.\n\nEach time a creature hits you with an attack roll during the spell's duration, roll a d6 for each of your remaining duplicates. If any of the d6s rolls a 3 or higher, one of the duplicates is hit instead of you, and the duplicate is destroyed. The duplicates otherwise ignore all other damage and effects. The spell ends when all three duplicates are destroyed.\n\nA creature is unaffected by this spell if it has the Blinded condition, Blindsight, or Truesight.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mirror-image", "it"),
					Language = LanguageCode.It,
					Name = "Immagine Speculare",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Tre duplicati illusori dell'incantatore compaiono nel suo spazio. Finché l'incantesimo non termina, i duplicati si muovono con lui e ne imitano le azioni, cambiando posizione in modo che sia impossibile capire quale immagine sia reale.\n\nOgni volta che una creatura colpisce l'incantatore con un tiro per colpire durante la durata dell'incantesimo, l'incantatore tira un d6 per ciascuno dei duplicati rimasti. Se uno qualsiasi dei d6 ottiene 3 o più, uno dei duplicati viene colpito al posto dell'incantatore e il duplicato viene distrutto. Per il resto, i duplicati ignorano tutti gli altri danni ed effetti. L'incantesimo termina quando tutti e tre i duplicati sono stati distrutti.\n\nUna creatura non è influenzata da questo incantesimo se è accecata o se dispone di vista cieca o di vista pura.",
					HigherLevels = null
				}
			}
		};
	}
}
