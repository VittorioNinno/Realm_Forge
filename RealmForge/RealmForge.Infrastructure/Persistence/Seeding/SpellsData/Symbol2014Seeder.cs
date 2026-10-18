using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Symbol (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Symbol2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "symbol");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "symbol", "en"),
					Language = LanguageCode.En,
					Name = "Symbol",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "Until dispelled or triggered",
					MaterialComponent = "mercury, phosphorus, and powdered diamond and opal with a total value of at least 1,000 gp, which the spell consumes",
					Description = "When you cast this spell, you inscribe a harmful glyph either on a surface (such as a section of floor, a wall, or a table) or within an object that can be closed to conceal the glyph (such as a book, a scroll, or a treasure chest). If you choose a surface, the glyph can cover an area of the surface no larger than 10 feet in diameter. If you choose an object, that object must remain in its place; if the object is moved more than 10 feet from where you cast this spell, the glyph is broken, and the spell ends without being triggered.\n\nThe glyph is nearly invisible, requiring an Intelligence (Investigation) check against your spell save DC to find it.\n\nYou decide what triggers the glyph when you cast the spell. For glyphs inscribed on a surface, the most typical triggers include touching or stepping on the glyph, removing another object covering it, approaching within a certain distance of it, or manipulating the object that holds it. For glyphs inscribed within an object, the most common triggers are opening the object, approaching within a certain distance of it, or seeing or reading the glyph.\n\nYou can further refine the trigger so the spell is activated only under certain circumstances or according to a creature's physical characteristics (such as height or weight), or physical kind (for example, the ward could be set to affect hags or shapechangers). You can also specify creatures that don't trigger the glyph, such as those who say a certain password.\n\nWhen you inscribe the glyph, choose one of the options below for its effect. Once triggered, the glyph glows, filling a 60-foot-radius sphere with dim light for 10 minutes, after which time the spell ends. Each creature in the sphere when the glyph activates is targeted by its effect, as is a creature that enters the sphere for the first time on a turn or ends its turn there.\n\n***Death.*** Each target must make a Constitution saving throw, taking 10d10 necrotic damage on a failed save, or half as much damage on a successful save.\n\n***Discord.*** Each target must make a Constitution saving throw. On a failed save, a target bickers and argues with other creatures for 1 minute. During this time, it is incapable of meaningful communication and has disadvantage on attack rolls and ability checks.\n\n***Fear.*** Each target must make a Wisdom saving throw and becomes frightened for 1 minute on a failed save. While frightened, the target drops whatever it is holding and must move at least 30 feet away from the glyph on each of its turns, if able.\n\n***Hopelessness.*** Each target must make a Charisma saving throw. On a failed save, the target is overwhelmed with despair for 1 minute. During this time, it can't attack or target any creature with harmful abilities, spells, or other magical effects.\n\n***Insanity.*** Each target must make an Intelligence saving throw. On a failed save, the target is driven insane for 1 minute. An insane creature can't take actions, can't understand what other creatures say, can't read, and speaks only in gibberish. The GM controls its movement, which is erratic.\n\n***Pain.*** Each target must make a Constitution saving throw and becomes incapacitated with excruciating pain for 1 minute on a failed save.\n\n***Sleep.*** Each target must make a Wisdom saving throw and falls unconscious for 10 minutes on a failed save. A creature awakens if it takes damage or if someone uses an action to shake or slap it awake.\n\n***Stunning.*** Each target must make a Wisdom saving throw and becomes stunned for 1 minute on a failed save.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "symbol", "it"),
					Language = LanguageCode.It,
					Name = "Simbolo",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "Finché non viene dissolto o innescato",
					MaterialComponent = "mercurio, fosforo e polvere di diamante e di opale per un valore complessivo di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "Quando lancia questo incantesimo, l'incantatore iscrive un glifo dannoso su una superficie (come una sezione di pavimento, un muro o un tavolo) oppure all'interno di un oggetto che può essere chiuso per nascondere il glifo (come un libro, una pergamena o uno scrigno del tesoro). Se sceglie una superficie, il glifo può coprire un'area della superficie del diametro massimo di 3 metri. Se sceglie un oggetto, quell'oggetto deve restare al suo posto: se viene spostato di più di 3 metri dal punto in cui l'incantatore ha lanciato l'incantesimo, il glifo si spezza e l'incantesimo termina senza essere stato innescato.\n\nIl glifo è quasi invisibile: per trovarlo è necessaria una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore.\n\nQuando lancia l'incantesimo, l'incantatore decide cosa innesca il glifo. Per i glifi iscritti su una superficie, gli inneschi più tipici sono toccare il glifo o calpestarlo, rimuovere un altro oggetto che lo copre, avvicinarsi al glifo entro una certa distanza o manipolare l'oggetto su cui si trova. Per i glifi iscritti all'interno di un oggetto, gli inneschi più comuni sono aprire l'oggetto, avvicinarsi all'oggetto entro una certa distanza o vedere o leggere il glifo.\n\nL'incantatore può affinare ulteriormente l'innesco in modo che l'incantesimo si attivi soltanto in determinate circostanze o in base alle caratteristiche fisiche di una creatura (come l'altezza o il peso) o alla sua natura fisica (per esempio, la protezione potrebbe essere impostata per influenzare le megere o i mutaforma). Può anche specificare le creature che non innescano il glifo, come quelle che pronunciano una determinata parola d'ordine.\n\nQuando iscrive il glifo, l'incantatore sceglie per il suo effetto una delle opzioni seguenti. Una volta innescato, il glifo si illumina e riempie una sfera del raggio di 18 metri di luce fioca per 10 minuti, dopodiché l'incantesimo termina. Ogni creatura che si trova nella sfera quando il glifo si attiva è bersagliata dal suo effetto, così come una creatura che entra nella sfera per la prima volta in un turno o vi termina il proprio turno.\n\n***Morte.*** Ogni bersaglio deve effettuare un tiro salvezza su Costituzione; subisce 10d10 danni necrotici se lo fallisce, o la metà di quei danni se lo supera.\n\n***Discordia.*** Ogni bersaglio deve effettuare un tiro salvezza su Costituzione. Se lo fallisce, il bersaglio litiga e discute con le altre creature per 1 minuto. Durante questo periodo, non è in grado di comunicare in modo significativo e subisce svantaggio ai tiri per colpire e alle prove di caratteristica.\n\n***Paura.*** Ogni bersaglio deve effettuare un tiro salvezza su Saggezza e, se lo fallisce, è spaventato per 1 minuto. Finché è spaventato, il bersaglio lascia cadere qualsiasi cosa stia impugnando e, in ognuno dei suoi turni, deve allontanarsi di almeno 9 metri dal glifo, se può.\n\n***Disperazione.*** Ogni bersaglio deve effettuare un tiro salvezza su Carisma. Se lo fallisce, il bersaglio viene sopraffatto dalla disperazione per 1 minuto. Durante questo periodo, non può attaccare né bersagliare alcuna creatura con capacità, incantesimi o altri effetti magici dannosi.\n\n***Follia.*** Ogni bersaglio deve effettuare un tiro salvezza su Intelligenza. Se lo fallisce, il bersaglio impazzisce per 1 minuto. Una creatura folle non può compiere azioni, non comprende ciò che dicono le altre creature, non sa leggere e pronuncia soltanto parole senza senso. Il DM controlla il suo movimento, che è erratico.\n\n***Dolore.*** Ogni bersaglio deve effettuare un tiro salvezza su Costituzione e, se lo fallisce, è incapacitato da un dolore lancinante per 1 minuto.\n\n***Sonno.*** Ogni bersaglio deve effettuare un tiro salvezza su Saggezza e, se lo fallisce, cade privo di sensi per 10 minuti. Una creatura si sveglia se subisce danni o se qualcuno usa un'azione per scuoterla o schiaffeggiarla e svegliarla.\n\n***Stordimento.*** Ogni bersaglio deve effettuare un tiro salvezza su Saggezza e, se lo fallisce, è stordito per 1 minuto.",
					HigherLevels = null
				}
			}
		};
	}
}
