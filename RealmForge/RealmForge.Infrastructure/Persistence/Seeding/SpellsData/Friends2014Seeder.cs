using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Friends (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class Friends2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "friends");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 0,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = false,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "friends", "en"),
					Language = LanguageCode.En,
					Name = "Friends",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a little makeup applied to the face while casting",
					Description = "For the duration, you have advantage on all Charisma checks directed at one creature of your choice that isn't hostile toward you. When the spell ends, the creature realizes that magic was used to sway its mood and becomes hostile toward you. A violent creature might attack you, while another might look for some other way to get even (at the GM's discretion), depending on how you dealt with it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "friends", "it"),
					Language = LanguageCode.It,
					Name = "Amicizia",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un po' di trucco applicato sul viso durante il lancio",
					Description = "Per la durata, l'incantatore dispone di vantaggio a tutte le prove di Carisma rivolte a una creatura a sua scelta che non gli è ostile. Quando l'incantesimo termina, la creatura si rende conto che la magia è stata usata per influenzare il suo umore e diventa ostile nei confronti dell'incantatore. Una creatura violenta potrebbe attaccarlo, mentre un'altra potrebbe cercare un modo diverso per vendicarsi (a discrezione del DM), a seconda di come l'incantatore l'ha trattata.",
					HigherLevels = null
				}
			}
		};
	}
}
