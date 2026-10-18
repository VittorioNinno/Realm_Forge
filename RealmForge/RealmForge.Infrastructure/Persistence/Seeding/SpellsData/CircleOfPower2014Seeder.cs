using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Circle of Power (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CircleOfPower2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "circle-of-power");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 5,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "circle-of-power", "en"),
					Language = LanguageCode.En,
					Name = "Circle of Power",
					CastingTime = "1 action",
					Range = "Self (30-foot radius)",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "Divine energy pours out of you and unravels hostile magic within 30 feet of you. Until the spell ends, this area moves with you, centered on you. For the duration, each friendly creature in the area, you included, has advantage on saving throws against spells and other magical effects. Also, when such a creature succeeds on a saving throw against a spell or magical effect that deals half damage on a successful save, it takes no damage instead.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "circle-of-power", "it"),
					Language = LanguageCode.It,
					Name = "Cerchio di Potere",
					CastingTime = "1 azione",
					Range = "Incantatore (raggio di 9 metri)",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "Un'energia divina si riversa dall'incantatore e sfalda la magia ostile entro 9 metri da lui. Finché l'incantesimo non termina, quest'area si sposta con l'incantatore, rimanendo centrata su di lui. Per la durata, ogni creatura amichevole nell'area, incluso l'incantatore, dispone di vantaggio ai tiri salvezza contro gli incantesimi e gli altri effetti magici. Inoltre, quando una di queste creature supera un tiro salvezza contro un incantesimo o un effetto magico che infligge la metà dei danni in caso di successo, non subisce invece alcun danno.",
					HigherLevels = null
				}
			}
		};
	}
}
