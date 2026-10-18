using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Seeming (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Seeming2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "seeming");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "seeming", "en"),
					Language = LanguageCode.En,
					Name = "Seeming",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "8 hours",
					MaterialComponent = null,
					Description = "You give an illusory appearance to each creature of your choice that you can see within range. An unwilling target can make a Charisma saving throw, and if it succeeds, it is unaffected by this spell.\n\nYou can give the same appearance or different ones to the targets. The spell can change the appearance of the targets' bodies and equipment. You can make each creature seem 1 foot shorter or taller and appear heavier or lighter. A target's new appearance must have the same basic arrangement of limbs as the target, but the extent of the illusion is otherwise up to you. The spell lasts for the duration.\n\nThe changes wrought by this spell fail to hold up to physical inspection. For example, if you use this spell to add a hat to a creature's outfit, objects pass through the hat.\n\nA creature that takes the Study action to examine a target can make an Intelligence (Investigation) check against your spell save DC. If it succeeds, it becomes aware that the target is disguised.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "seeming", "it"),
					Language = LanguageCode.It,
					Name = "Sembrare",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "8 ore",
					MaterialComponent = null,
					Description = "L'incantatore conferisce un aspetto illusorio a ogni creatura a sua scelta entro gittata che è in grado di vedere. Un bersaglio non consenziente può effettuare un tiro salvezza su Carisma e, se lo supera, non è influenzato da questo incantesimo.\n\nL'incantatore può conferire ai bersagli lo stesso aspetto o aspetti diversi. L'incantesimo può cambiare l'aspetto del corpo e dell'equipaggiamento dei bersagli. L'incantatore può far sembrare ogni creatura più bassa o più alta di 30 centimetri e farla apparire più pesante o più leggera. Il nuovo aspetto di un bersaglio deve avere la stessa disposizione di base degli arti del bersaglio, ma per il resto l'entità dell'illusione è a discrezione dell'incantatore. L'incantesimo permane per la durata.\n\nLe modifiche prodotte da questo incantesimo non reggono a un'ispezione fisica. Per esempio, se l'incantatore usa questo incantesimo per aggiungere un cappello all'abbigliamento di una creatura, gli oggetti passano attraverso il cappello.\n\nUna creatura che effettua l'azione di Studio per esaminare un bersaglio può compiere una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se la supera, si accorge che il bersaglio è camuffato.",
					HigherLevels = null
				}
			}
		};
	}
}
