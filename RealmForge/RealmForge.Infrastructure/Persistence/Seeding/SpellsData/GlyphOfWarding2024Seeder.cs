using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Glyph of Warding (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GlyphOfWarding2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "glyph-of-warding");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "glyph-of-warding", "en"),
					Language = LanguageCode.En,
					Name = "Glyph of Warding",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Until dispelled or triggered",
					MaterialComponent = "powdered diamond worth 200+ GP, which the spell consumes",
					Description = "You inscribe a glyph that later unleashes a magical effect. You inscribe it either on a surface (such as a table or a section of floor) or within an object that can be closed (such as a book or chest) to conceal the glyph. The glyph can cover an area no larger than 10 feet in diameter. If the surface or object is moved more than 10 feet from where you cast this spell, the glyph is broken, and the spell ends without being triggered.\n\nThe glyph is nearly imperceptible and requires a successful Wisdom (Perception) check against your spell save DC to notice.\n\nWhen you inscribe the glyph, you set its trigger and choose whether it's an explosive rune or a spell glyph, as explained below.\n\n***Set the Trigger.*** You decide what triggers the glyph when you cast the spell. For glyphs inscribed on a surface, common triggers include touching or stepping on the glyph, removing another object covering it, or approaching within a certain distance of it. For glyphs inscribed within an object, common triggers include opening that object or seeing the glyph. Once a glyph is triggered, this spell ends.\n\nYou can refine the trigger so that only creatures of certain types activate it (for example, the glyph could be set to affect Aberrations). You can also set conditions for creatures that don't trigger the glyph, such as those who say a certain password.\n\n***Explosive Rune.*** When triggered, the glyph erupts with magical energy in a 20-foot-radius Sphere centered on the glyph. Each creature in the area makes a Dexterity saving throw. A creature takes 5d8 Acid, Cold, Fire, Lightning, or Thunder damage (your choice when you create the glyph) on a failed save or half as much damage on a successful one.\n\n***Spell Glyph.*** You can store a prepared spell of level 3 or lower in the glyph by casting it as part of creating the glyph. The spell must target a single creature or an area. The spell being stored has no immediate effect when cast in this way.\n\nWhen the glyph is triggered, the stored spell takes effect. If the spell has a target, it targets the creature that triggered the glyph. If the spell affects an area, the area is centered on that creature. If the spell summons Hostile creatures or creates harmful objects or traps, they appear as close as possible to the intruder and attack it. If the spell requires Concentration, it lasts until the end of its full duration.",
					HigherLevels = "The damage of an explosive rune increases by 1d8 for each spell slot level above 3. If you create a spell glyph, you can store any spell of up to the same level as the spell slot you use for the *Glyph of Warding*."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "glyph-of-warding", "it"),
					Language = LanguageCode.It,
					Name = "Glifo di Interdizione",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Finché non viene dissolto o innescato",
					MaterialComponent = "polvere di diamante del valore di almeno 200 mo, che l'incantesimo consuma",
					Description = "L'incantatore incide un glifo che in seguito scatenerà un effetto magico. Lo incide su una superficie (come un tavolo o una sezione di pavimento) oppure all'interno di un oggetto che può essere chiuso (come un libro o uno scrigno), in modo da nascondere il glifo. Il glifo può coprire un'area con un diametro non superiore a 3 metri. Se la superficie o l'oggetto vengono spostati di più di 3 metri dal punto in cui l'incantatore ha lanciato questo incantesimo, il glifo si spezza e l'incantesimo termina senza essere stato innescato.\n\nIl glifo è quasi impercettibile e, per notarlo, occorre superare una prova di Saggezza (Percezione) contro la CD del tiro salvezza degli incantesimi dell'incantatore.\n\nQuando incide il glifo, l'incantatore ne stabilisce l'innesco e sceglie se si tratta di una runa esplosiva o di un glifo incantato, come spiegato sotto.\n\n***Stabilire l'Innesco.*** Quando lancia l'incantesimo, l'incantatore decide cosa innesca il glifo. Per i glifi incisi su una superficie, gli inneschi più comuni includono il toccare o calpestare il glifo, rimuovere un altro oggetto che lo copre o avvicinarsi entro una certa distanza da esso. Per i glifi incisi all'interno di un oggetto, gli inneschi più comuni includono l'apertura di quell'oggetto o la vista del glifo. Una volta che un glifo è stato innescato, questo incantesimo termina.\n\nL'incantatore può affinare l'innesco in modo che soltanto le creature di determinati tipi lo attivino (per esempio, il glifo potrebbe essere impostato per influenzare le aberrazioni). Può anche stabilire delle condizioni per le creature che non innescano il glifo, come quelle che pronunciano una certa parola d'ordine.\n\n***Runa Esplosiva.*** Quando viene innescato, il glifo erompe in un'esplosione di energia magica in una sfera del raggio di 6 metri centrata sul glifo. Ogni creatura nell'area effettua un tiro salvezza su Destrezza. Una creatura subisce 5d8 danni da acido, freddo, fuoco, fulmine o tuono (a scelta dell'incantatore quando crea il glifo) se lo fallisce, o la metà di quei danni se lo supera.\n\n***Glifo Incantato.*** L'incantatore può immagazzinare nel glifo un incantesimo preparato di 3° livello o inferiore, lanciandolo come parte della creazione del glifo. L'incantesimo deve prendere come bersaglio una singola creatura o un'area. L'incantesimo immagazzinato non ha alcun effetto immediato quando viene lanciato in questo modo.\n\nQuando il glifo viene innescato, l'incantesimo immagazzinato ha effetto. Se l'incantesimo ha un bersaglio, prende come bersaglio la creatura che ha innescato il glifo. Se l'incantesimo influenza un'area, l'area è centrata su quella creatura. Se l'incantesimo evoca creature ostili o crea oggetti o trappole dannosi, questi compaiono il più vicino possibile all'intruso e lo attaccano. Se l'incantesimo richiede concentrazione, dura fino al termine della sua durata completa.",
					HigherLevels = "I danni di una runa esplosiva aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 3°. Se l'incantatore crea un glifo incantato, può immagazzinare qualsiasi incantesimo di livello pari o inferiore a quello dello slot incantesimo usato per *glifo di interdizione*."
				}
			}
		};
	}
}
