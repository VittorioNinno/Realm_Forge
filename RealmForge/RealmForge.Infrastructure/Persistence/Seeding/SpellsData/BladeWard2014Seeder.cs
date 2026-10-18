using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blade Ward (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class BladeWard2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blade-ward");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 0,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blade-ward", "en"),
					Language = LanguageCode.En,
					Name = "Blade Ward",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "You sketch a protective sigil in the air with your hand. Until the end of your next turn, you have resistance to bludgeoning, piercing, and slashing damage from weapon attacks.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blade-ward", "it"),
					Language = LanguageCode.It,
					Name = "Interdizione alle Lame",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "1 round",
					MaterialComponent = null,
					Description = "L'incantatore traccia con la mano un sigillo protettivo nell'aria. Fino alla fine del suo turno successivo, ha resistenza ai danni contundenti, perforanti e taglienti inflitti dagli attacchi con un'arma.",
					HigherLevels = null
				}
			}
		};
	}
}
