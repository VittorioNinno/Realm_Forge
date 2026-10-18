using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Magnificent Mansion (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MagnificentMansion2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magnificent-mansion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magnificent-mansion", "en"),
					Language = LanguageCode.En,
					Name = "Magnificent Mansion",
					CastingTime = "1 minute",
					Range = "300 feet",
					Duration = "24 hours",
					MaterialComponent = "a miniature portal carved from ivory, a small piece of polished marble, and a tiny silver spoon, each item worth at least 5 gp",
					Description = "You conjure an extradimensional dwelling in range that lasts for the duration. You choose where its one entrance is located. The entrance shimmers faintly and is 5 feet wide and 10 feet tall. You and any creature you designate when you cast the spell can enter the extradimensional dwelling as long as the portal remains open. You can open or close the portal if you are within 30 feet of it. While closed, the portal is invisible.\n\nBeyond the portal is a magnificent foyer with numerous chambers beyond. The atmosphere is clean, fresh, and warm.\n\nYou can create any floor plan you like, but the space can't exceed 50 cubes, each cube being 10 feet on each side. The place is furnished and decorated as you choose. It contains sufficient food to serve a nine course banquet for up to 100 people. A staff of 100 near-transparent servants attends all who enter. You decide the visual appearance of these servants and their attire. They are completely obedient to your orders. Each servant can perform any task a normal human servant could perform, but they can't attack or take any action that would directly harm another creature. Thus the servants can fetch things, clean, mend, fold clothes, light fires, serve food, pour wine, and so on. The servants can go anywhere in the mansion but can't leave it. Furnishings and other objects created by this spell dissipate into smoke if removed from the mansion. When the spell ends, any creatures inside the extradimensional space are expelled into the open spaces nearest to the entrance.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magnificent-mansion", "it"),
					Language = LanguageCode.It,
					Name = "Reggia Meravigliosa",
					CastingTime = "1 minuto",
					Range = "90 metri",
					Duration = "24 ore",
					MaterialComponent = "un portale in miniatura scolpito nell'avorio, un piccolo pezzo di marmo levigato e un minuscolo cucchiaio d'argento, ognuno del valore di almeno 5 mo",
					Description = "L'incantatore evoca entro gittata una dimora extradimensionale che dura per la durata. Sceglie dove si trova la sua unica entrata. L'entrata scintilla debolmente ed è larga 1,5 metri e alta 3 metri. L'incantatore e qualsiasi creatura da lui designata al momento del lancio possono entrare nella dimora extradimensionale finché il portale rimane aperto. L'incantatore può aprire o chiudere il portale se si trova entro 9 metri da esso. Quando è chiuso, il portale è invisibile.\n\nOltre il portale si trova un magnifico atrio, da cui si accede a numerose stanze. L'atmosfera è pulita, fresca e calda.\n\nL'incantatore può creare la pianta che preferisce, ma lo spazio non può superare 50 cubi, ognuno con uno spigolo di 3 metri. Il luogo è arredato e decorato come l'incantatore desidera. Contiene cibo sufficiente a servire un banchetto di nove portate a un massimo di 100 persone. Uno staff di 100 servitori quasi trasparenti si prende cura di chiunque entri. L'incantatore decide l'aspetto di questi servitori e i loro abiti. I servitori obbediscono completamente ai suoi ordini. Ogni servitore può svolgere qualsiasi compito che potrebbe svolgere un normale servitore umano, ma non può attaccare né compiere alcuna azione che nuocerebbe direttamente a un'altra creatura. I servitori possono quindi prendere oggetti, pulire, rammendare, piegare abiti, accendere fuochi, servire cibo, versare vino e così via. I servitori possono andare ovunque nella dimora, ma non possono uscirne. Gli arredi e gli altri oggetti creati da questo incantesimo si dissolvono in fumo se vengono portati fuori dalla dimora. Quando l'incantesimo termina, tutte le creature che si trovano all'interno dello spazio extradimensionale vengono espulse negli spazi liberi più vicini all'entrata.",
					HigherLevels = null
				}
			}
		};
	}
}
