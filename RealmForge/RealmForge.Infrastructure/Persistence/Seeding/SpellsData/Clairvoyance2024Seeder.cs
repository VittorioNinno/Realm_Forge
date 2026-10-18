using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Clairvoyance (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Clairvoyance2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "clairvoyance");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "clairvoyance", "en"),
					Language = LanguageCode.En,
					Name = "Clairvoyance",
					CastingTime = "10 minutes",
					Range = "1 mile",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a focus worth 100+ GP, either a jeweled horn for hearing or a glass eye for seeing",
					Description = "You create an Invisible sensor within range in a location familiar to you (a place you have visited or seen before) or in an obvious location that is unfamiliar to you (such as behind a door, around a corner, or in a grove of trees). The intangible, invulnerable sensor remains in place for the duration.\n\nWhen you cast the spell, choose seeing or hearing. You can use the chosen sense through the sensor as if you were in its space. As a Bonus Action, you can switch between seeing and hearing.\n\nA creature that sees the sensor (such as a creature benefiting from *See Invisibility* or Truesight) sees a luminous orb about the size of your fist.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "clairvoyance", "it"),
					Language = LanguageCode.It,
					Name = "Chiaroveggenza",
					CastingTime = "10 minuti",
					Range = "1,5 km",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un focus del valore di almeno 100 mo: un corno ingioiellato per l'udito o un occhio di vetro per la vista",
					Description = "L'incantatore crea entro gittata un sensore invisibile in un luogo a lui familiare (un luogo che ha già visitato o visto) o in un luogo evidente che non gli è familiare (come dietro una porta, dietro un angolo o in un boschetto). Il sensore, intangibile e invulnerabile, resta in posizione per la durata.\n\nQuando lancia l'incantesimo, l'incantatore sceglie la vista o l'udito. Può usare il senso scelto attraverso il sensore come se si trovasse nel suo spazio. Come azione bonus, può passare dalla vista all'udito e viceversa.\n\nUna creatura che vede il sensore (come una creatura che beneficia di *vedere invisibilità* o della vista pura) vede un globo luminoso grande all'incirca quanto il pugno dell'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
