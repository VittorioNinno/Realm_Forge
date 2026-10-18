using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Project Image (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ProjectImage2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "project-image");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "project-image", "en"),
					Language = LanguageCode.En,
					Name = "Project Image",
					CastingTime = "Action",
					Range = "500 miles",
					Duration = "Concentration, up to 1 day",
					MaterialComponent = "a statuette of yourself worth 5+ GP",
					Description = "You create an illusory copy of yourself that lasts for the duration. The copy can appear at any location within range that you have seen before, regardless of intervening obstacles. The illusion looks and sounds like you, but it is intangible. If the illusion takes any damage, it disappears, and the spell ends.\n\nYou can see through the illusion's eyes and hear through its ears as if you were in its space. As a Magic action, you can move it up to 60 feet and make it gesture, speak, and behave in whatever way you choose. It mimics your mannerisms perfectly.\n\nPhysical interaction with the image reveals it to be illusory, since things can pass through it. A creature that takes the Study action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. If a creature discerns the illusion for what it is, the creature can see through the image, and any noise it makes sounds hollow to the creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "project-image", "it"),
					Language = LanguageCode.It,
					Name = "Immagine Proiettata",
					CastingTime = "Azione",
					Range = "750 km",
					Duration = "Concentrazione, fino a 1 giorno",
					MaterialComponent = "una statuetta raffigurante l'incantatore del valore di almeno 5 mo",
					Description = "L'incantatore crea una copia illusoria di sé stesso che permane per la durata. La copia può comparire in qualsiasi luogo entro gittata che l'incantatore ha già visto, indipendentemente dagli ostacoli frapposti. L'illusione ha l'aspetto e la voce dell'incantatore, ma è intangibile. Se l'illusione subisce danni, scompare e l'incantesimo termina.\n\nL'incantatore può vedere attraverso gli occhi dell'illusione e sentire attraverso le sue orecchie come se si trovasse nel suo spazio. Come azione di Magia, può spostarla fino a 18 metri e farle compiere gesti, parlare e comportarsi in qualsiasi modo desideri. L'illusione imita perfettamente i suoi modi di fare.\n\nL'interazione fisica con l'immagine rivela che si tratta di un'illusione, perché le cose possono attraversarla. Una creatura che effettua l'azione di Studio per esaminare l'immagine può capire che si tratta di un'illusione superando una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se una creatura riconosce l'illusione per ciò che è, può vedere attraverso l'immagine e qualsiasi rumore emesso dall'illusione le suona vuoto.",
					HigherLevels = null
				}
			}
		};
	}
}
