using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Spiritual Weapon (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpiritualWeapon2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spiritual-weapon");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spiritual-weapon", "en"),
					Language = LanguageCode.En,
					Name = "Spiritual Weapon",
					CastingTime = "Bonus Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You create a floating, spectral force that resembles a weapon of your choice and lasts for the duration. The force appears within range in a space of your choice, and you can immediately make one melee spell attack against one creature within 5 feet of the force. On a hit, the target takes Force damage equal to 1d8 plus your spellcasting ability modifier.\n\nAs a Bonus Action on your later turns, you can move the force up to 20 feet and repeat the attack against a creature within 5 feet of it.",
					HigherLevels = "The damage increases by 1d8 for every slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "spiritual-weapon", "it"),
					Language = LanguageCode.It,
					Name = "Arma Spirituale",
					CastingTime = "Azione bonus",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore crea una forza spettrale e fluttuante che ha la forma di un'arma a sua scelta e permane per la durata. La forza compare entro gittata in uno spazio a scelta dell'incantatore, il quale può effettuare immediatamente un attacco con incantesimo in mischia contro una creatura entro 1,5 metri dalla forza. Se colpisce, il bersaglio subisce danni da forza pari a 1d8 più il modificatore di caratteristica da incantatore dell'incantatore.\n\nCome azione bonus nei turni successivi, l'incantatore può spostare la forza fino a 6 metri e ripetere l'attacco contro una creatura entro 1,5 metri da essa.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
