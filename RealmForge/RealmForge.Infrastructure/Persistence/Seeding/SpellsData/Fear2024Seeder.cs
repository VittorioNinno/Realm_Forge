using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fear (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Fear2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fear");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fear", "en"),
					Language = LanguageCode.En,
					Name = "Fear",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a white feather",
					Description = "Each creature in a 30-foot Cone must succeed on a Wisdom saving throw or drop whatever it is holding and have the Frightened condition for the duration.\n\nA Frightened creature takes the Dash action and moves away from you by the safest route on each of its turns unless there is nowhere to move. If the creature ends its turn in a space where it doesn't have line of sight to you, the creature makes a Wisdom saving throw. On a successful save, the spell ends on that creature.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fear", "it"),
					Language = LanguageCode.It,
					Name = "Paura",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una piuma bianca",
					Description = "Ogni creatura in un cono di 9 metri deve superare un tiro salvezza su Saggezza, altrimenti lascia cadere qualsiasi cosa stia impugnando ed è spaventata per la durata.\n\nIn ognuno dei suoi turni, una creatura spaventata effettua l'azione di Scatto e si allontana dall'incantatore seguendo il percorso più sicuro, a meno che non abbia alcun luogo in cui muoversi. Se la creatura termina il proprio turno in uno spazio da cui non ha linea di vista verso l'incantatore, effettua un tiro salvezza su Saggezza. Se lo supera, l'incantesimo termina su quella creatura.",
					HigherLevels = null
				}
			}
		};
	}
}
