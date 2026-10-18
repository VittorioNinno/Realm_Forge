using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Teleportation Circle (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TeleportationCircle2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "teleportation-circle");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "teleportation-circle", "en"),
					Language = LanguageCode.En,
					Name = "Teleportation Circle",
					CastingTime = "1 minute",
					Range = "10 feet",
					Duration = "1 round",
					MaterialComponent = "rare chalks and inks infused with precious gems worth 50 gp, which the spell consumes",
					Description = "As you cast the spell, you draw a 10-foot-diameter circle on the ground inscribed with sigils that link your location to a permanent teleportation circle of your choice whose sigil sequence you know and that is on the same plane of existence as you. A shimmering portal opens within the circle you drew and remains open until the end of your next turn. Any creature that enters the portal instantly appears within 5 feet of the destination circle or in the nearest unoccupied space if that space is occupied.\n\nMany major temples, guilds, and other important places have permanent teleportation circles inscribed somewhere within their confines. Each such circle includes a unique sigil sequence—a string of magical runes arranged in a particular pattern. When you first gain the ability to cast this spell, you learn the sigil sequences for two destinations on the Material Plane, determined by the GM. You can learn additional sigil sequences during your adventures. You can commit a new sigil sequence to memory after studying it for 1 minute.\n\nYou can create a permanent teleportation circle by casting this spell in the same location every day for one year. You need not use the circle to teleport when you cast the spell in this way.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "teleportation-circle", "it"),
					Language = LanguageCode.It,
					Name = "Cerchio di Teletrasporto",
					CastingTime = "1 minuto",
					Range = "3 metri",
					Duration = "1 round",
					MaterialComponent = "gessi e inchiostri rari infusi di gemme preziose del valore di 50 mo, che l'incantesimo consuma",
					Description = "Mentre lancia l'incantesimo, l'incantatore traccia sul terreno un cerchio del diametro di 3 metri, iscritto con sigilli che collegano la sua posizione a un cerchio di teletrasporto permanente a sua scelta, di cui conosce la sequenza di sigilli e che si trova sul suo stesso piano di esistenza. All'interno del cerchio tracciato si apre un portale scintillante, che rimane aperto fino alla fine del turno successivo dell'incantatore. Qualsiasi creatura che entra nel portale compare istantaneamente entro 1,5 metri dal cerchio di destinazione o, se quello spazio è occupato, nello spazio libero più vicino.\n\nMolti grandi templi, gilde e altri luoghi importanti hanno cerchi di teletrasporto permanenti iscritti da qualche parte all'interno dei loro confini. Ognuno di questi cerchi include una sequenza di sigilli unica: una serie di rune magiche disposte secondo uno schema particolare. Quando ottiene per la prima volta la capacità di lanciare questo incantesimo, l'incantatore apprende le sequenze di sigilli di due destinazioni nel Piano Materiale, stabilite dal DM. Può apprendere altre sequenze di sigilli nel corso delle sue avventure. Può memorizzare una nuova sequenza di sigilli dopo averla studiata per 1 minuto.\n\nL'incantatore può creare un cerchio di teletrasporto permanente lanciando questo incantesimo nello stesso luogo ogni giorno per un anno. Quando lancia l'incantesimo in questo modo, non è obbligato a usare il cerchio per teletrasportarsi.",
					HigherLevels = null
				}
			}
		};
	}
}
