using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Glyph of Warding (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GlyphOfWarding2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "glyph-of-warding");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "glyph-of-warding", "en"),
					Language = LanguageCode.En,
					Name = "Glyph of Warding",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Until dispelled or triggered",
					MaterialComponent = "incense and powdered diamond worth at least 200 gp, which the spell consumes",
					Description = "When you cast this spell, you inscribe a glyph that harms other creatures, either upon a surface (such as a table or a section of floor or wall) or within an object that can be closed (such as a book, a scroll, or a treasure chest) to conceal the glyph. If you choose a surface, the glyph can cover an area of the surface no larger than 10 feet in diameter. If you choose an object, that object must remain in its place; if the object is moved more than 10 feet from where you cast this spell, the glyph is broken, and the spell ends without being triggered.\n\nThe glyph is nearly invisible and requires a successful Intelligence (Investigation) check against your spell save DC to be found.\n\nYou decide what triggers the glyph when you cast the spell. For glyphs inscribed on a surface, the most typical triggers include touching or standing on the glyph, removing another object covering the glyph, approaching within a certain distance of the glyph, or manipulating the object on which the glyph is inscribed. For glyphs inscribed within an object, the most common triggers include opening that object, approaching within a certain distance of the object, or seeing or reading the glyph. Once a glyph is triggered, this spell ends.\n\nYou can further refine the trigger so the spell activates only under certain circumstances or according to physical characteristics (such as height or weight), creature kind (for example, the ward could be set to affect aberrations or drow), or alignment. You can also set conditions for creatures that don't trigger the glyph, such as those who say a certain password.\n\nWhen you inscribe the glyph, choose *explosive runes* or a *spell glyph*.\n\n***Explosive Runes.*** When triggered, the glyph erupts with magical energy in a 20-foot-radius sphere centered on the glyph. The sphere spreads around corners. Each creature in the area must make a Dexterity saving throw. A creature takes 5d8 acid, cold, fire, lightning, or thunder damage on a failed saving throw (your choice when you create the glyph), or half as much damage on a successful one.\n\n***Spell Glyph.*** You can store a prepared spell of 3rd level or lower in the glyph by casting it as part of creating the glyph. The spell must target a single creature or an area. The spell being stored has no immediate effect when cast in this way. When the glyph is triggered, the stored spell is cast. If the spell has a target, it targets the creature that triggered the glyph. If the spell affects an area, the area is centered on that creature. If the spell summons hostile creatures or creates harmful objects or traps, they appear as close as possible to the intruder and attack it. If the spell requires concentration, it lasts until the end of its full duration.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, the damage of an explosive runes glyph increases by 1d8 for each slot level above 3rd. If you create a spell glyph, you can store any spell of up to the same level as the slot you use for the glyph of warding."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "glyph-of-warding", "it"),
					Language = LanguageCode.It,
					Name = "Glifo di Interdizione",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Finché non viene dissolto o innescato",
					MaterialComponent = "incenso e polvere di diamante del valore di almeno 200 mo, che l'incantesimo consuma",
					Description = "Quando lancia questo incantesimo, l'incantatore iscrive un glifo che nuoce alle altre creature, su una superficie (come un tavolo o una sezione di pavimento o di muro) oppure all'interno di un oggetto che può essere chiuso (come un libro, una pergamena o uno scrigno del tesoro), così da nascondere il glifo. Se sceglie una superficie, il glifo può coprire un'area della superficie del diametro massimo di 3 metri. Se sceglie un oggetto, quell'oggetto deve restare al suo posto: se viene spostato di più di 3 metri dal punto in cui l'incantatore ha lanciato l'incantesimo, il glifo si spezza e l'incantesimo termina senza essere stato innescato.\n\nIl glifo è quasi invisibile e per trovarlo è necessario superare una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore.\n\nQuando lancia l'incantesimo, l'incantatore decide cosa innesca il glifo. Per i glifi iscritti su una superficie, gli inneschi più tipici sono toccare il glifo o calpestarlo, rimuovere un altro oggetto che lo copre, avvicinarsi al glifo entro una certa distanza o manipolare l'oggetto su cui è iscritto. Per i glifi iscritti all'interno di un oggetto, gli inneschi più comuni sono aprire l'oggetto, avvicinarsi all'oggetto entro una certa distanza o vedere o leggere il glifo. Una volta innescato il glifo, l'incantesimo termina.\n\nL'incantatore può affinare ulteriormente l'innesco in modo che l'incantesimo si attivi soltanto in determinate circostanze o in base a caratteristiche fisiche (come l'altezza o il peso), al tipo di creatura (per esempio, la protezione potrebbe essere impostata per influenzare le aberrazioni o i drow) o all'allineamento. Può anche stabilire le condizioni per le creature che non innescano il glifo, come quelle che pronunciano una determinata parola d'ordine.\n\nQuando iscrive il glifo, l'incantatore sceglie tra *rune esplosive* e *glifo incantato*.\n\n***Rune Esplosive.*** Quando viene innescato, il glifo erompe in un'esplosione di energia magica in una sfera del raggio di 6 metri centrata sul glifo. La sfera si propaga dietro gli angoli. Ogni creatura nell'area deve effettuare un tiro salvezza su Destrezza. Una creatura subisce 5d8 danni da acido, freddo, fuoco, fulmine o tuono (a scelta dell'incantatore al momento della creazione del glifo) se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\n***Glifo Incantato.*** L'incantatore può immagazzinare nel glifo un incantesimo preparato di 3° livello o inferiore, lanciandolo come parte della creazione del glifo. L'incantesimo deve bersagliare una singola creatura o un'area. L'incantesimo immagazzinato non ha alcun effetto immediato quando viene lanciato in questo modo. Quando il glifo viene innescato, l'incantesimo immagazzinato viene lanciato. Se l'incantesimo ha un bersaglio, bersaglia la creatura che ha innescato il glifo. Se l'incantesimo influenza un'area, l'area è centrata su quella creatura. Se l'incantesimo evoca creature ostili o crea oggetti o trappole dannosi, questi compaiono il più vicino possibile all'intruso e lo attaccano. Se l'incantesimo richiede concentrazione, dura fino al termine della sua intera durata.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, i danni di un glifo di rune esplosive aumentano di 1d8 per ogni livello dello slot superiore al 3°. Se crea un glifo incantato, può immagazzinarvi qualsiasi incantesimo di livello pari o inferiore a quello dello slot usato per glifo di interdizione."
				}
			}
		};
	}
}
