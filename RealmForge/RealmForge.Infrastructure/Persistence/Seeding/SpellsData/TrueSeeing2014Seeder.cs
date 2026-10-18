using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	True Seeing (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TrueSeeing2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-seeing");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-seeing", "en"),
					Language = LanguageCode.En,
					Name = "True Seeing",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "an ointment for the eyes that costs 25 gp; is made from mushroom powder, saffron, and fat; and is consumed by the spell",
					Description = "This spell gives the willing creature you touch the ability to see things as they actually are. For the duration, the creature has truesight, notices secret doors hidden by magic, and can see into the Ethereal Plane, all out to a range of 120 feet.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-seeing", "it"),
					Language = LanguageCode.It,
					Name = "Visione del Vero",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "un unguento per gli occhi del costo di 25 mo, ricavato da polvere di funghi, zafferano e grasso, che l'incantesimo consuma",
					Description = "Questo incantesimo conferisce alla creatura consenziente toccata dall'incantatore la capacità di vedere le cose come sono realmente. Per la durata, la creatura possiede vista pura, nota le porte segrete nascoste dalla magia e può vedere nel Piano Etereo, il tutto entro una distanza di 36 metri.",
					HigherLevels = null
				}
			}
		};
	}
}
