using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Antimagic Field (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AntimagicField2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "antimagic-field");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "antimagic-field", "en"),
					Language = LanguageCode.En,
					Name = "Antimagic Field",
					CastingTime = "1 action",
					Range = "Self (10-foot-radius sphere)",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a pinch of powdered iron or iron filings",
					Description = "A 10-foot-radius invisible sphere of antimagic surrounds you. This area is divorced from the magical energy that suffuses the multiverse. Within the sphere, spells can't be cast, summoned creatures disappear, and even magic items become mundane. Until the spell ends, the sphere moves with you, centered on you.\n\nSpells and other magical effects, except those created by an artifact or a deity, are suppressed in the sphere and can't protrude into it. A slot expended to cast a suppressed spell is consumed. While an effect is suppressed, it doesn't function, but the time it spends suppressed counts against its duration.\n\n***Targeted Effects.*** Spells and other magical effects, such as magic missile and charm person, that target a creature or an object in the sphere have no effect on that target.\n\n***Areas of Magic.*** The area of another spell or magical effect, such as fireball, can't extend into the sphere. If the sphere overlaps an area of magic, the part of the area that is covered by the sphere is suppressed. For example, the flames created by a wall of fire are suppressed within the sphere, creating a gap in the wall if the overlap is large enough.\n\n***Spells.*** Any active spell or other magical effect on a creature or an object in the sphere is suppressed while the creature or object is in it.\n\n***Magic Items.*** The properties and powers of magic items are suppressed in the sphere. For example, a +1 longsword in the sphere functions as a nonmagical longsword.\n\nA magic weapon's properties and powers are suppressed if it is used against a target in the sphere or wielded by an attacker in the sphere. If a magic weapon or a piece of magic ammunition fully leaves the sphere (for example, if you fire a magic arrow or throw a magic spear at a target outside the sphere), the magic of the item ceases to be suppressed as soon as it exits.\n\n***Magical Travel.*** Teleportation and planar travel fail to work in the sphere, whether the sphere is the destination or the departure point for such magical travel. A portal to another location, world, or plane of existence, as well as an opening to an extradimensional space such as that created by the rope trick spell, temporarily closes while in the sphere.\n\n***Creatures and Objects.*** A creature or object summoned or created by magic temporarily winks out of existence in the sphere. Such a creature instantly reappears once the space the creature occupied is no longer within the sphere.\n\n***Dispel Magic.*** Spells and magical effects such as dispel magic have no effect on the sphere. Likewise, the spheres created by different antimagic field spells don't nullify each other.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "antimagic-field", "it"),
					Language = LanguageCode.It,
					Name = "Campo Anti-magia",
					CastingTime = "1 azione",
					Range = "Incantatore (sfera del raggio di 3 metri)",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un pizzico di ferro in polvere o di limatura di ferro",
					Description = "Una sfera invisibile di antimagia del raggio di 3 metri circonda l'incantatore. Quest'area è isolata dall'energia magica che permea il multiverso. All'interno della sfera non è possibile lanciare incantesimi, le creature evocate scompaiono e perfino gli oggetti magici diventano comuni. Finché l'incantesimo non termina, la sfera si sposta con l'incantatore, rimanendo centrata su di lui.\n\nGli incantesimi e gli altri effetti magici, a eccezione di quelli creati da un artefatto o da una divinità, sono soppressi nella sfera e non possono estendersi al suo interno. Uno slot speso per lanciare un incantesimo soppresso viene comunque consumato. Finché un effetto è soppresso non funziona, ma il tempo trascorso in questo stato viene sottratto dalla sua durata.\n\n***Effetti con Bersaglio.*** Gli incantesimi e gli altri effetti magici, come dardo incantato e charme su persone, che bersagliano una creatura o un oggetto situato nella sfera non hanno alcun effetto su quel bersaglio.\n\n***Aree di Magia.*** L'area di un altro incantesimo o effetto magico, come palla di fuoco, non può estendersi all'interno della sfera. Se la sfera si sovrappone a un'area di magia, la parte dell'area coperta dalla sfera è soppressa. Per esempio, le fiamme create da un muro di fuoco sono soppresse all'interno della sfera, creando un varco nel muro se la sovrapposizione è abbastanza ampia.\n\n***Incantesimi.*** Qualsiasi incantesimo attivo o altro effetto magico su una creatura o un oggetto situato nella sfera è soppresso finché la creatura o l'oggetto si trova al suo interno.\n\n***Oggetti Magici.*** Le proprietà e i poteri degli oggetti magici sono soppressi nella sfera. Per esempio, una spada lunga +1 nella sfera funziona come una spada lunga non magica.\n\nLe proprietà e i poteri di un'arma magica sono soppressi se l'arma viene usata contro un bersaglio situato nella sfera o se è impugnata da un attaccante situato nella sfera. Se un'arma magica o una munizione magica esce completamente dalla sfera (per esempio, se l'incantatore scocca una freccia magica o scaglia una lancia magica contro un bersaglio fuori dalla sfera), la magia dell'oggetto cessa di essere soppressa non appena ne esce.\n\n***Viaggi Magici.*** Il teletrasporto e i viaggi planari non funzionano nella sfera, che la sfera sia la destinazione o il punto di partenza di tale viaggio magico. Un portale verso un altro luogo, mondo o piano di esistenza, così come un'apertura verso uno spazio extradimensionale come quello creato dall'incantesimo trucco della corda, si chiude temporaneamente finché si trova nella sfera.\n\n***Creature e Oggetti.*** Una creatura o un oggetto evocato o creato con la magia cessa temporaneamente di esistere nella sfera. Una creatura di questo tipo ricompare all'istante non appena lo spazio che occupava non si trova più all'interno della sfera.\n\n***Dissolvi Magie.*** Gli incantesimi e gli effetti magici come dissolvi magie non hanno alcun effetto sulla sfera. Allo stesso modo, le sfere create da diversi incantesimi campo anti-magia non si annullano a vicenda.",
					HigherLevels = null
				}
			}
		};
	}
}
