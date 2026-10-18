using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Elementalism (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Elementalism2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "elementalism");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "elementalism", "en"),
					Language = LanguageCode.En,
					Name = "Elementalism",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You exert control over the elements, creating one of the following effects within range.\n\n***Beckon Air.*** You create a breeze strong enough to ripple cloth, stir dust, rustle leaves, and close open doors and shutters, all in a 5-foot Cube. Doors and shutters being held open by someone or something aren't affected.\n\n***Beckon Earth.*** You create a thin shroud of dust or sand that covers surfaces in a 5-foot-square area, or you cause a single word to appear in your handwriting in a patch of dirt or sand.\n\n***Beckon Fire.*** You create a thin cloud of harmless embers and colored, scented smoke in a 5-foot Cube. You choose the color and scent, and the embers can light candles, torches, or lamps in that area. The smoke's scent lingers for 1 minute.\n\n***Beckon Water.*** You create a spray of cool mist that lightly dampens creatures and objects in a 5-foot Cube. Alternatively, you create 1 cup of clean water either in an open container or on a surface, and the water evaporates in 1 minute.\n\n***Sculpt Element.*** You cause dirt, sand, fire, smoke, mist, or water that can fit in a 1-foot Cube to assume a crude shape (such as that of a creature) for 1 hour.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "elementalism", "it"),
					Language = LanguageCode.It,
					Name = "Elementalismo",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore esercita il proprio controllo sugli elementi, creando uno degli effetti seguenti entro gittata.\n\n***Richiamare l'Aria.*** L'incantatore crea una brezza abbastanza forte da increspare i tessuti, sollevare la polvere, far frusciare le foglie e chiudere porte e imposte aperte, il tutto in un cubo con spigolo di 1,5 metri. Le porte e le imposte tenute aperte da qualcuno o da qualcosa non sono influenzate.\n\n***Richiamare la Terra.*** L'incantatore crea un sottile velo di polvere o sabbia che ricopre le superfici in un'area quadrata di 1,5 metri di lato, oppure fa comparire una singola parola, con la propria calligrafia, in un tratto di terra o di sabbia.\n\n***Richiamare il Fuoco.*** L'incantatore crea una sottile nube di braci innocue e di fumo colorato e profumato in un cubo con spigolo di 1,5 metri. Sceglie il colore e il profumo, e le braci possono accendere candele, torce o lampade in quell'area. Il profumo del fumo permane per 1 minuto.\n\n***Richiamare l'Acqua.*** L'incantatore crea uno spruzzo di nebbiolina fresca che inumidisce leggermente le creature e gli oggetti in un cubo con spigolo di 1,5 metri. In alternativa, crea una tazza di acqua pulita in un contenitore aperto o su una superficie; l'acqua evapora dopo 1 minuto.\n\n***Plasmare l'Elemento.*** L'incantatore fa sì che terra, sabbia, fuoco, fumo, nebbia o acqua che possano rientrare in un cubo con spigolo di 30 centimetri assumano una forma rozza (come quella di una creatura) per 1 ora.",
					HigherLevels = null
				}
			}
		};
	}
}
