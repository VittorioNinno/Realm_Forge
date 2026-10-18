using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Teleportation Circle (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TeleportationCircle2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "teleportation-circle");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "teleportation-circle", "en"),
					Language = LanguageCode.En,
					Name = "Teleportation Circle",
					CastingTime = "1 minute",
					Range = "10 feet",
					Duration = "1 round",
					MaterialComponent = "rare inks worth 50+ GP, which the spell consumes",
					Description = "As you cast the spell, you draw a 5-foot-radius circle on the ground inscribed with sigils that link your location to a permanent teleportation circle of your choice whose sigil sequence you know and that is on the same plane of existence as you. A shimmering portal opens within the circle you drew and remains open until the end of your next turn. Any creature that enters the portal instantly appears within 5 feet of the destination circle or in the nearest unoccupied space if that space is occupied.\n\nMany major temples, guildhalls, and other important places have permanent teleportation circles. Each circle includes a unique sigil sequence—a string of runes arranged in a particular pattern.\n\nWhen you first gain the ability to cast this spell, you learn the sigil sequences for two destinations on the Material Plane, determined by the GM. You might learn additional sigil sequences during your adventures. You can commit a new sigil sequence to memory after studying it for 1 minute.\n\nYou can create a permanent teleportation circle by casting this spell in the same location every day for 365 days.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "teleportation-circle", "it"),
					Language = LanguageCode.It,
					Name = "Cerchio di Teletrasporto",
					CastingTime = "1 minuto",
					Range = "3 metri",
					Duration = "1 round",
					MaterialComponent = "inchiostri rari del valore di almeno 50 mo, che l'incantesimo consuma",
					Description = "Mentre lancia l'incantesimo, l'incantatore traccia sul terreno un cerchio del raggio di 1,5 metri inciso con sigilli che collegano il luogo in cui si trova a un cerchio di teletrasporto permanente a sua scelta, di cui conosce la sequenza di sigilli e che si trova sul suo stesso piano di esistenza. Un portale scintillante si apre all'interno del cerchio tracciato e rimane aperto fino alla fine del turno successivo dell'incantatore. Qualsiasi creatura che entra nel portale compare istantaneamente entro 1,5 metri dal cerchio di destinazione o, se quello spazio è occupato, nello spazio libero più vicino.\n\nMolti templi importanti, sedi di gilde e altri luoghi di rilievo hanno cerchi di teletrasporto permanenti. Ogni cerchio include una sequenza di sigilli unica: una serie di rune disposte secondo uno schema particolare.\n\nQuando ottiene per la prima volta la capacità di lanciare questo incantesimo, l'incantatore apprende le sequenze di sigilli di due destinazioni sul Piano Materiale, stabilite dal DM. Potrebbe apprendere altre sequenze di sigilli durante le sue avventure. Può memorizzare una nuova sequenza di sigilli dopo averla studiata per 1 minuto.\n\nL'incantatore può creare un cerchio di teletrasporto permanente lanciando questo incantesimo nello stesso luogo ogni giorno per 365 giorni.",
					HigherLevels = null
				}
			}
		};
	}
}
