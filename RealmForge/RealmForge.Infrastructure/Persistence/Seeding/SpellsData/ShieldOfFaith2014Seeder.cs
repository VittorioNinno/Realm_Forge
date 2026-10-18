using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Shield of Faith (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ShieldOfFaith2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shield-of-faith");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shield-of-faith", "en"),
					Language = LanguageCode.En,
					Name = "Shield of Faith",
					CastingTime = "1 bonus action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a small parchment with a bit of holy text written on it",
					Description = "A shimmering field appears and surrounds a creature of your choice within range, granting it a +2 bonus to AC for the duration.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "shield-of-faith", "it"),
					Language = LanguageCode.It,
					Name = "Scudo della Fede",
					CastingTime = "1 azione bonus",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una piccola pergamena su cui è scritto un passo di un testo sacro",
					Description = "Un campo scintillante compare e circonda una creatura entro gittata a scelta dell'incantatore, conferendole un bonus di +2 alla CA per la durata.",
					HigherLevels = null
				}
			}
		};
	}
}
