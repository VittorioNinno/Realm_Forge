using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sequester (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Sequester2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sequester");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sequester", "en"),
					Language = LanguageCode.En,
					Name = "Sequester",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "a powder composed of diamond, emerald, ruby, and sapphire dust worth at least 5,000 gp, which the spell consumes",
					Description = "By means of this spell, a willing creature or an object can be hidden away, safe from detection for the duration. When you cast the spell and touch the target, it becomes invisible and can't be targeted by divination spells or perceived through scrying sensors created by divination spells.\n\nIf the target is a creature, it falls into a state of suspended animation. Time ceases to flow for it, and it doesn't grow older.\n\nYou can set a condition for the spell to end early. The condition can be anything you choose, but it must occur or be visible within 1 mile of the target. Examples include \"after 1,000 years\" or \"when the tarrasque awakens.\" This spell also ends if the target takes any damage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sequester", "it"),
					Language = LanguageCode.It,
					Name = "Celare",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "una polvere composta da polvere di diamante, smeraldo, rubino e zaffiro del valore di almeno 5.000 mo, che l'incantesimo consuma",
					Description = "Grazie a questo incantesimo, una creatura consenziente o un oggetto può essere nascosto al sicuro da ogni tentativo di individuazione per la durata. Quando l'incantatore lancia l'incantesimo e tocca il bersaglio, quest'ultimo diventa invisibile e non può essere bersagliato dagli incantesimi di divinazione né percepito tramite i sensori di scrutamento creati dagli incantesimi di divinazione.\n\nSe il bersaglio è una creatura, cade in uno stato di animazione sospesa. Per lei il tempo smette di scorrere e non invecchia.\n\nL'incantatore può stabilire una condizione che faccia terminare prematuramente l'incantesimo. La condizione può essere qualsiasi cosa a sua scelta, ma deve verificarsi o essere visibile entro 1,5 km dal bersaglio. Alcuni esempi sono \"dopo 1.000 anni\" o \"quando la tarrasque si risveglierà\". Questo incantesimo termina anche se il bersaglio subisce danni.",
					HigherLevels = null
				}
			}
		};
	}
}
