using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcane Sword (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ArcaneSword2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-sword");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-sword", "en"),
					Language = LanguageCode.En,
					Name = "Arcane Sword",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a miniature sword worth 250+ GP",
					Description = "You create a spectral sword that hovers within range. It lasts for the duration.\n\nWhen the sword appears, you make a melee spell attack against a target within 5 feet of the sword. On a hit, the target takes Force damage equal to 4d12 plus your spellcasting ability modifier.\n\nOn your later turns, you can take a Bonus Action to move the sword up to 30 feet to a spot you can see and repeat the attack against the same target or a different one.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-sword", "it"),
					Language = LanguageCode.It,
					Name = "Spada Arcana",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una spada in miniatura del valore di almeno 250 mo",
					Description = "L'incantatore crea una spada spettrale che fluttua entro gittata. La spada permane per la durata.\n\nQuando la spada compare, l'incantatore effettua un attacco con incantesimo in mischia contro un bersaglio entro 1,5 metri dalla spada. Se colpisce, il bersaglio subisce danni da forza pari a 4d12 più il modificatore di caratteristica da incantatore dell'incantatore.\n\nNei turni successivi, l'incantatore può effettuare un'azione bonus per spostare la spada fino a 9 metri in un punto che è in grado di vedere e ripetere l'attacco contro lo stesso bersaglio o contro un bersaglio diverso.",
					HigherLevels = null
				}
			}
		};
	}
}
