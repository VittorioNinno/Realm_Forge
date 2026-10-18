using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Antimagic Field (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AntimagicField2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "antimagic-field");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "antimagic-field", "en"),
					Language = LanguageCode.En,
					Name = "Antimagic Field",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "iron filings",
					Description = "An aura of antimagic surrounds you in 10-foot Emanation. No one can cast spells, take Magic actions, or create other magical effects inside the aura, and those things can't target or otherwise affect anything inside it. Magical properties of magic items don't work inside the aura or on anything inside it.\n\nAreas of effect created by spells or other magic can't extend into the aura, and no one can teleport into or out of it or use planar travel there. Portals close temporarily while in the aura.\n\nOngoing spells, except those cast by an Artifact or a deity, are suppressed in the area. While an effect is suppressed, it doesn't function, but the time it spends suppressed counts against its duration.\n\n*Dispel Magic* has no effect on the aura, and the auras created by different *Antimagic Field* spells don't nullify each other.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "antimagic-field", "it"),
					Language = LanguageCode.It,
					Name = "Campo Anti-magia",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "limatura di ferro",
					Description = "Un'aura di antimagia circonda l'incantatore in un'emanazione di 3 metri. Nessuno può lanciare incantesimi, effettuare azioni di Magia o creare altri effetti magici all'interno dell'aura, e queste cose non possono prendere come bersaglio né influenzare in altro modo nulla al suo interno. Le proprietà magiche degli oggetti magici non funzionano all'interno dell'aura né su qualsiasi cosa al suo interno.\n\nLe aree d'effetto create da incantesimi o da altre magie non possono estendersi all'interno dell'aura, e nessuno può teletrasportarsi dentro o fuori di essa né usarvi viaggi planari. I portali si chiudono temporaneamente mentre si trovano nell'aura.\n\nGli incantesimi in corso, tranne quelli lanciati da un artefatto o da una divinità, sono soppressi nell'area. Finché un effetto è soppresso, non funziona, ma il tempo trascorso in soppressione viene conteggiato nella sua durata.\n\n*Dissolvi magie* non ha alcun effetto sull'aura, e le aure create da diversi incantesimi *campo anti-magia* non si annullano a vicenda.",
					HigherLevels = null
				}
			}
		};
	}
}
