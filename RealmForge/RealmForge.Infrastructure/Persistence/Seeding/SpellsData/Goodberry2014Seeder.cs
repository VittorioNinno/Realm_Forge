using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Goodberry (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Goodberry2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "goodberry");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "goodberry", "en"),
					Language = LanguageCode.En,
					Name = "Goodberry",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a sprig of mistletoe",
					Description = "Up to ten berries appear in your hand and are infused with magic for the duration. A creature can use its action to eat one berry. Eating a berry restores 1 hit point, and the berry provides enough nourishment to sustain a creature for a day.\n\nThe berries lose their potency if they have not been consumed within 24 hours of the casting of this spell.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "goodberry", "it"),
					Language = LanguageCode.It,
					Name = "Bacche Benefiche",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "un rametto di vischio",
					Description = "Nella mano dell'incantatore compaiono fino a dieci bacche, infuse di magia per la durata. Una creatura può usare la sua azione per mangiare una bacca. Mangiare una bacca fa recuperare 1 punto ferita, e ogni bacca fornisce nutrimento sufficiente a sostentare una creatura per un giorno.\n\nLe bacche perdono il loro potere se non vengono consumate entro 24 ore dal lancio di questo incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
