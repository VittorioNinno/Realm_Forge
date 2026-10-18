using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Project Image (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ProjectImage2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "project-image");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "project-image", "en"),
					Language = LanguageCode.En,
					Name = "Project Image",
					CastingTime = "1 action",
					Range = "500 miles",
					Duration = "Concentration, up to 1 day",
					MaterialComponent = "a small replica of you made from materials worth at least 5 gp",
					Description = "You create an illusory copy of yourself that lasts for the duration. The copy can appear at any location within range that you have seen before, regardless of intervening obstacles. The illusion looks and sounds like you but is intangible. If the illusion takes any damage, it disappears, and the spell ends.\n\nYou can use your action to move this illusion up to twice your speed, and make it gesture, speak, and behave in whatever way you choose. It mimics your mannerisms perfectly.\n\nYou can see through its eyes and hear through its ears as if you were in its space. On your turn as a bonus action, you can switch from using its senses to using your own, or back again. While you are using its senses, you are blinded and deafened in regard to your own surroundings.\n\nPhysical interaction with the image reveals it to be an illusion, because things can pass through it. A creature that uses its action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the creature can see through the image, and any noise it makes sounds hollow to the creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "project-image", "it"),
					Language = LanguageCode.It,
					Name = "Immagine Proiettata",
					CastingTime = "1 azione",
					Range = "750 km",
					Duration = "Concentrazione, fino a 1 giorno",
					MaterialComponent = "una piccola riproduzione dell'incantatore, realizzata con materiali del valore di almeno 5 mo",
					Description = "L'incantatore crea una copia illusoria di sé stesso che dura per la durata. La copia può comparire in qualsiasi luogo entro gittata che l'incantatore abbia già visto, indipendentemente dagli ostacoli frapposti. L'illusione ha l'aspetto e la voce dell'incantatore, ma è intangibile. Se l'illusione subisce danni, scompare e l'incantesimo termina.\n\nL'incantatore può usare la sua azione per spostare l'illusione fino al doppio della propria velocità e farle fare gesti, parlare e comportarsi nel modo che preferisce. L'illusione imita alla perfezione i suoi modi di fare.\n\nL'incantatore può vedere attraverso gli occhi dell'illusione e sentire attraverso le sue orecchie come se si trovasse nel suo spazio. Nel suo turno, come azione bonus, può passare dall'uso dei sensi dell'illusione all'uso dei propri, o viceversa. Mentre usa i sensi dell'illusione, l'incantatore è accecato e assordato per quanto riguarda ciò che lo circonda.\n\nL'interazione fisica con l'immagine rivela che si tratta di un'illusione, perché le cose possono attraversarla. Una creatura che usa la sua azione per esaminare l'immagine può capire che si tratta di un'illusione superando una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se una creatura riconosce l'illusione per ciò che è, può vedere attraverso l'immagine, e qualsiasi rumore prodotto dall'immagine le suona vuoto.",
					HigherLevels = null
				}
			}
		};
	}
}
