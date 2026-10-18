using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Crusader's Mantle (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CrusadersMantle2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "crusaders-mantle");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
			School = SpellSchool.Evocation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "crusaders-mantle", "en"),
					Language = LanguageCode.En,
					Name = "Crusader's Mantle",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "A holy aura spreads from you in a 30-foot radius, filling your allies with courage. Until the spell ends, the aura moves with you, centered on you. While inside it, every nonhostile creature, you included, deals an extra 1d4 radiant damage when it hits with a weapon attack.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "crusaders-mantle", "it"),
					Language = LanguageCode.It,
					Name = "Manto del Crociato",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Un'aura sacra si irradia dall'incantatore in un raggio di 9 metri, infondendo coraggio nei suoi alleati. Finché l'incantesimo non termina, l'aura si sposta con l'incantatore, rimanendo centrata su di lui. Finché si trova al suo interno, ogni creatura non ostile, incluso l'incantatore, infligge 1d4 danni radiosi extra quando colpisce con un attacco con un'arma.",
					HigherLevels = null
				}
			}
		};
	}
}
