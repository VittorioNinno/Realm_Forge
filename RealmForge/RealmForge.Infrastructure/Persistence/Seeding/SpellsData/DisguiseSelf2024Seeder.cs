using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Disguise Self (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DisguiseSelf2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "disguise-self");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "disguise-self", "en"),
					Language = LanguageCode.En,
					Name = "Disguise Self",
					CastingTime = "Action",
					Range = "Self",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "You make yourself—including your clothing, armor, weapons, and other belongings on your person—look different until the spell ends. You can seem 1 foot shorter or taller and can appear heavier or lighter. You must adopt a form that has the same basic arrangement of limbs as you have. Otherwise, the extent of the illusion is up to you.\n\nThe changes wrought by this spell fail to hold up to physical inspection. For example, if you use this spell to add a hat to your outfit, objects pass through the hat, and anyone who touches it would feel nothing.\n\nTo discern that you are disguised, a creature must take the Study action to inspect your appearance and succeed on an Intelligence (Investigation) check against your spell save DC.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "disguise-self", "it"),
					Language = LanguageCode.It,
					Name = "Camuffare Se Stesso",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "L'incantatore modifica il proprio aspetto (inclusi abiti, armatura, armi e altri oggetti che ha addosso) finché l'incantesimo non termina. Può sembrare più basso o più alto di 30 centimetri e può apparire più pesante o più leggero. Deve assumere una forma che abbia la stessa disposizione di base degli arti della sua. Per il resto, l'entità dell'illusione è a sua discrezione.\n\nLe modifiche prodotte da questo incantesimo non reggono a un'ispezione fisica. Per esempio, se l'incantatore usa questo incantesimo per aggiungere un cappello al proprio abbigliamento, gli oggetti passano attraverso il cappello e chiunque lo tocchi non sente nulla.\n\nPer accorgersi che l'incantatore è camuffato, una creatura deve effettuare l'azione di Studio per esaminare il suo aspetto e superare una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
