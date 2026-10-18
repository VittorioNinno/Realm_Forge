using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Ensnaring Strike (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class EnsnaringStrike2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "ensnaring-strike");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "ensnaring-strike", "en"),
					Language = LanguageCode.En,
					Name = "Ensnaring Strike",
					CastingTime = "1 bonus action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "The next time you hit a creature with a weapon attack before this spell ends, a tangle of thorny vines bursts from the point of impact. The target must succeed on a Strength saving throw or be restrained by the vines until the spell ends; a Large or larger creature makes this save with advantage. If the target succeeds, the vines wither away.\n\nWhile restrained this way, the target takes 1d6 piercing damage at the start of each of its turns. The restrained creature, or another creature that can touch it, can use its action to make a Strength check against your spell save DC, freeing the target on a success.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d6 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "ensnaring-strike", "it"),
					Language = LanguageCode.It,
					Name = "Colpo Intrappolante",
					CastingTime = "1 azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "La prossima volta che l'incantatore colpisce una creatura con un attacco con un'arma prima che questo incantesimo termini, un groviglio di rampicanti spinosi erompe dal punto d'impatto. Il bersaglio deve superare un tiro salvezza su Forza, altrimenti è trattenuto dai rampicanti finché l'incantesimo non termina; una creatura di taglia Grande o superiore effettua questo tiro salvezza con vantaggio. Se il bersaglio supera il tiro salvezza, i rampicanti avvizziscono.\n\nFinché è trattenuto in questo modo, il bersaglio subisce 1d6 danni perforanti all'inizio di ogni suo turno. La creatura trattenuta, o un'altra creatura in grado di toccarla, può usare la propria azione per effettuare una prova di Forza contro la CD del tiro salvezza degli incantesimi dell'incantatore; se la supera, il bersaglio si libera.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni aumentano di 1d6 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
