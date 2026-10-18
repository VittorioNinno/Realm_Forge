using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Symbol (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Symbol2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "symbol");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "symbol", "en"),
					Language = LanguageCode.En,
					Name = "Symbol",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "Until dispelled or triggered",
					MaterialComponent = "powdered diamond worth 1,000+ GP, which the spell consumes",
					Description = "You inscribe a harmful glyph either on a surface (such as a section of floor or wall) or within an object that can be closed (such as a book or chest). The glyph can cover an area no larger than 10 feet in diameter. If you choose an object, it must remain in place; if it is moved more than 10 feet from where you cast this spell, the glyph is broken, and the spell ends without being triggered.\n\nThe glyph is nearly imperceptible and requires a successful Wisdom (Perception) check against your spell save DC to notice.\n\nWhen you inscribe the glyph, you set its trigger and choose which effect the symbol bears: Death, Discord, Fear, Pain, Sleep, or Stunning. Each one is explained below.\n\n***Set the Trigger.*** You decide what triggers the glyph when you cast the spell. For glyphs inscribed on a surface, common triggers include touching or stepping on the glyph, removing another object covering it, or approaching within a certain distance of it. For glyphs inscribed within an object, common triggers include opening that object or seeing the glyph.\n\nYou can refine the trigger so that only creatures of certain types activate it (for example, the glyph could be set to affect Aberrations). You can also set conditions for creatures that don't trigger the glyph, such as those who say a certain password.\n\nOnce triggered, the glyph glows, filling a 60-foot-radius Sphere with Dim Light for 10 minutes, after which time the spell ends. Each creature in the Sphere when the glyph activates is targeted by its effect, as is a creature that enters the Sphere for the first time on a turn or ends its turn there. A creature is targeted only once per turn.\n\n***Death.*** Each target makes a Constitution saving throw, taking 10d10 Necrotic damage on a failed save or half as much damage on a successful save.\n\n***Discord.*** Each target makes a Wisdom saving throw. On a failed save, a target argues with other creatures for 1 minute. During this time, it is incapable of meaningful communication and has Disadvantage on attack rolls and ability checks.\n\n***Fear.*** Each target must succeed on a Wisdom saving throw or have the Frightened condition for 1 minute. While Frightened, the target must move at least 30 feet away from the glyph on each of its turns, if able.\n\n***Pain.*** Each target must succeed on a Constitution saving throw or have the Incapacitated condition for 1 minute.\n\n***Sleep.*** Each target must succeed on a Wisdom saving throw or have the Unconscious condition for 10 minutes. A creature awakens if it takes damage or if someone takes an action to shake it awake.\n\n***Stunning.*** Each target must succeed on a Wisdom saving throw or have the Stunned condition for 1 minute.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "symbol", "it"),
					Language = LanguageCode.It,
					Name = "Simbolo",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "Finché non viene dissolto o innescato",
					MaterialComponent = "polvere di diamante del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore incide un glifo dannoso su una superficie (come una sezione di pavimento o di muro) oppure all'interno di un oggetto che può essere chiuso (come un libro o uno scrigno). Il glifo può coprire un'area con un diametro non superiore a 3 metri. Se l'incantatore sceglie un oggetto, questo deve rimanere al suo posto; se viene spostato di più di 3 metri dal punto in cui l'incantatore ha lanciato questo incantesimo, il glifo si spezza e l'incantesimo termina senza essere stato innescato.\n\nIl glifo è quasi impercettibile e, per notarlo, occorre superare una prova di Saggezza (Percezione) contro la CD del tiro salvezza degli incantesimi dell'incantatore.\n\nQuando incide il glifo, l'incantatore ne stabilisce l'innesco e sceglie quale effetto porta il simbolo: Morte, Discordia, Paura, Dolore, Sonno o Stordimento. Ciascuno è spiegato sotto.\n\n***Stabilire l'Innesco.*** Quando lancia l'incantesimo, l'incantatore decide cosa innesca il glifo. Per i glifi incisi su una superficie, gli inneschi più comuni includono il toccare o calpestare il glifo, rimuovere un altro oggetto che lo copre o avvicinarsi entro una certa distanza da esso. Per i glifi incisi all'interno di un oggetto, gli inneschi più comuni includono l'apertura di quell'oggetto o la vista del glifo.\n\nL'incantatore può affinare l'innesco in modo che soltanto le creature di determinati tipi lo attivino (per esempio, il glifo potrebbe essere impostato per influenzare le aberrazioni). Può anche stabilire delle condizioni per le creature che non innescano il glifo, come quelle che pronunciano una certa parola d'ordine.\n\nUna volta innescato, il glifo si illumina, riempiendo una sfera del raggio di 18 metri di luce fioca per 10 minuti, dopodiché l'incantesimo termina. Ogni creatura nella sfera quando il glifo si attiva viene presa come bersaglio dal suo effetto, così come una creatura che entra nella sfera per la prima volta in un turno o vi termina il proprio turno. Una creatura viene presa come bersaglio soltanto una volta per turno.\n\n***Morte.*** Ogni bersaglio effettua un tiro salvezza su Costituzione, subendo 10d10 danni necrotici se lo fallisce, o la metà di quei danni se lo supera.\n\n***Discordia.*** Ogni bersaglio effettua un tiro salvezza su Saggezza. Se lo fallisce, un bersaglio litiga con le altre creature per 1 minuto. Durante questo periodo, è incapace di comunicare in modo significativo e subisce svantaggio ai tiri per colpire e alle prove di caratteristica.\n\n***Paura.*** Ogni bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è spaventato per 1 minuto. Finché è spaventato, il bersaglio deve allontanarsi di almeno 9 metri dal glifo in ognuno dei suoi turni, se può farlo.\n\n***Dolore.*** Ogni bersaglio deve superare un tiro salvezza su Costituzione, altrimenti è incapacitato per 1 minuto.\n\n***Sonno.*** Ogni bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è privo di sensi per 10 minuti. Una creatura si sveglia se subisce danni o se qualcuno effettua un'azione per scuoterla e svegliarla.\n\n***Stordimento.*** Ogni bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è stordito per 1 minuto.",
					HigherLevels = null
				}
			}
		};
	}
}
