using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mislead (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Mislead2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mislead");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = false,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mislead", "en"),
					Language = LanguageCode.En,
					Name = "Mislead",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You gain the Invisible condition at the same time that an illusory double of you appears where you are standing. The double lasts for the duration, but the invisibility ends immediately after you make an attack roll, deal damage, or cast a spell.\n\nAs a Magic action, you can move the illusory double up to twice your Speed and make it gesture, speak, and behave in whatever way you choose. It is intangible and invulnerable.\n\nYou can see through its eyes and hear through its ears as if you were located where it is.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mislead", "it"),
					Language = LanguageCode.It,
					Name = "Fuorviare",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore diventa invisibile e, nello stesso momento, un suo doppio illusorio compare nel punto in cui si trova. Il doppio permane per la durata, ma l'invisibilità termina subito dopo che l'incantatore effettua un tiro per colpire, infligge danni o lancia un incantesimo.\n\nCome azione di Magia, l'incantatore può spostare il doppio illusorio fino al doppio della propria velocità e fargli compiere gesti, parlare e comportarsi in qualsiasi modo desideri. Il doppio è intangibile e invulnerabile.\n\nL'incantatore può vedere attraverso i suoi occhi e sentire attraverso le sue orecchie come se si trovasse nella sua posizione.",
					HigherLevels = null
				}
			}
		};
	}
}
