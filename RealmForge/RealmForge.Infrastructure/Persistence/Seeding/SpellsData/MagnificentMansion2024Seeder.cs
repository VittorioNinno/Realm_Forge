using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Magnificent Mansion (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MagnificentMansion2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magnificent-mansion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magnificent-mansion", "en"),
					Language = LanguageCode.En,
					Name = "Magnificent Mansion",
					CastingTime = "1 minute",
					Range = "300 feet",
					Duration = "24 hours",
					MaterialComponent = "a miniature door worth 15+ GP",
					Description = "You conjure a shimmering door in range that lasts for the duration. The door leads to an extradimensional dwelling and is 5 feet wide and 10 feet tall. You and any creature you designate when you cast the spell can enter the extradimensional dwelling as long as the door remains open. You can open or close it (no action required) if you are within 30 feet of it. While closed, the door is imperceptible.\n\nBeyond the door is a magnificent foyer with numerous chambers beyond. The dwelling's atmosphere is clean, fresh, and warm.\n\nYou can create any floor plan you like for the dwelling, but it can't exceed 50 contiguous 10-foot Cubes. The place is furnished and decorated as you choose. It contains sufficient food to serve a nine-course banquet for up to 100 people. Furnishings and other objects created by this spell dissipate into smoke if removed from it.\n\nA staff of 100 near-transparent servants attends all who enter. You determine the appearance of these servants and their attire. They are invulnerable and obey your commands. Each servant can perform tasks that a human could perform, but they can't attack or take any action that would directly harm another creature. Thus the servants can fetch things, clean, mend, fold clothes, light fires, serve food, pour wine, and so on. The servants can't leave the dwelling.\n\nWhen the spell ends, any creatures or objects left inside the extradimensional space are expelled into the unoccupied spaces nearest to the entrance.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "magnificent-mansion", "it"),
					Language = LanguageCode.It,
					Name = "Reggia Meravigliosa",
					CastingTime = "1 minuto",
					Range = "90 metri",
					Duration = "24 ore",
					MaterialComponent = "una porta in miniatura del valore di almeno 15 mo",
					Description = "L'incantatore evoca entro gittata una porta scintillante che permane per la durata. La porta conduce a una dimora extradimensionale ed è larga 1,5 metri e alta 3 metri. L'incantatore e le eventuali creature da lui designate al momento del lancio possono entrare nella dimora extradimensionale finché la porta rimane aperta. L'incantatore può aprirla o chiuderla (non è richiesta alcuna azione) se si trova entro 9 metri da essa. Quando è chiusa, la porta è impercettibile.\n\nOltre la porta si trova un magnifico atrio da cui si accede a numerose stanze. L'aria della dimora è pulita, fresca e tiepida.\n\nL'incantatore può creare la pianta che preferisce per la dimora, ma non può superare 50 cubi contigui con spigolo di 3 metri. Il luogo è arredato e decorato secondo le preferenze dell'incantatore. Contiene cibo sufficiente a servire un banchetto di nove portate per un massimo di 100 persone. Gli arredi e gli altri oggetti creati da questo incantesimo si dissolvono in fumo se vengono portati fuori da esso.\n\nUno staff di 100 servitori quasi trasparenti assiste tutti coloro che entrano. L'incantatore stabilisce l'aspetto di questi servitori e il loro abbigliamento. I servitori sono invulnerabili e obbediscono ai suoi comandi. Ogni servitore può svolgere i compiti che potrebbe svolgere un umano, ma non può attaccare né effettuare alcuna azione che danneggerebbe direttamente un'altra creatura. I servitori possono quindi andare a prendere oggetti, pulire, rammendare, piegare abiti, accendere fuochi, servire il cibo, versare il vino e così via. I servitori non possono lasciare la dimora.\n\nQuando l'incantesimo termina, tutte le creature o gli oggetti rimasti all'interno dello spazio extradimensionale vengono espulsi negli spazi liberi più vicini all'ingresso.",
					HigherLevels = null
				}
			}
		};
	}
}
