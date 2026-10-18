using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Stinking Cloud (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class StinkingCloud2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "stinking-cloud");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "stinking-cloud", "en"),
					Language = LanguageCode.En,
					Name = "Stinking Cloud",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a rotten egg",
					Description = "You create a 20-foot-radius Sphere of yellow, nauseating gas centered on a point within range. The cloud is Heavily Obscured. The cloud lingers in the air for the duration or until a strong wind (such as the one created by *Gust of Wind*) disperses it.\n\nEach creature that starts its turn in the Sphere must succeed on a Constitution saving throw or have the Poisoned condition until the end of the current turn. While Poisoned in this way, the creature can't take an action or a Bonus Action.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "stinking-cloud", "it"),
					Language = LanguageCode.It,
					Name = "Nube Maleodorante",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un uovo marcio",
					Description = "L'incantatore crea una sfera di gas giallo e nauseabondo del raggio di 6 metri, centrata su un punto entro gittata. La nube è pesantemente oscurata. La nube persiste nell'aria per la durata o finché un vento forte (come quello creato da *folata di vento*) non la disperde.\n\nOgni creatura che inizia il proprio turno nella sfera deve superare un tiro salvezza su Costituzione, altrimenti è avvelenata fino alla fine del turno in corso. Finché è avvelenata in questo modo, la creatura non può effettuare un'azione né un'azione bonus.",
					HigherLevels = null
				}
			}
		};
	}
}
