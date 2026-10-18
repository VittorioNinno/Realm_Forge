using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Contagion (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Contagion2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "contagion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "contagion", "en"),
					Language = LanguageCode.En,
					Name = "Contagion",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "7 days",
					MaterialComponent = null,
					Description = "Your touch inflicts a magical contagion. The target must succeed on a Constitution saving throw or take 11d8 Necrotic damage and have the Poisoned condition. Also, choose one ability when you cast the spell. While Poisoned, the target has Disadvantage on saving throws made with the chosen ability.\n\nThe target must repeat the saving throw at the end of each of its turns until it gets three successes or failures. If the target succeeds on three of these saves, the spell ends on the target. If the target fails three of the saves, the spell lasts for 7 days on it.\n\nWhenever the Poisoned target receives an effect that would end the Poisoned condition, the target must succeed on a Constitution saving throw, or the Poisoned condition doesn't end on it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "contagion", "it"),
					Language = LanguageCode.It,
					Name = "Contagio",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "7 giorni",
					MaterialComponent = null,
					Description = "Il tocco dell'incantatore trasmette un contagio magico. Il bersaglio deve superare un tiro salvezza su Costituzione, altrimenti subisce 11d8 danni necrotici ed è avvelenato. Inoltre, quando lancia l'incantesimo, l'incantatore sceglie una caratteristica. Finché è avvelenato, il bersaglio subisce svantaggio ai tiri salvezza effettuati con la caratteristica scelta.\n\nIl bersaglio deve ripetere il tiro salvezza alla fine di ogni suo turno, finché non ottiene tre successi o tre fallimenti. Se il bersaglio supera tre di questi tiri salvezza, l'incantesimo termina su di lui. Se ne fallisce tre, l'incantesimo dura 7 giorni su di lui.\n\nOgni volta che il bersaglio avvelenato riceve un effetto che porrebbe fine alla condizione avvelenato, deve superare un tiro salvezza su Costituzione, altrimenti la condizione avvelenato non termina.",
					HigherLevels = null
				}
			}
		};
	}
}
