using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Produce Flame (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ProduceFlame2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "produce-flame");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "produce-flame", "en"),
					Language = LanguageCode.En,
					Name = "Produce Flame",
					CastingTime = "Bonus Action",
					Range = "Self",
					Duration = "10 minutes",
					MaterialComponent = null,
					Description = "A flickering flame appears in your hand and remains there for the duration. While there, the flame emits no heat and ignites nothing, and it sheds Bright Light in a 20-foot radius and Dim Light for an additional 20 feet. The spell ends if you cast it again.\n\nUntil the spell ends, you can take a Magic action to hurl fire at a creature or an object within 60 feet of you. Make a ranged spell attack. On a hit, the target takes 1d8 Fire damage.",
					HigherLevels = "The damage increases by 1d8 when you reach levels 5 (2d8), 11 (3d8), and 17 (4d8)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "produce-flame", "it"),
					Language = LanguageCode.It,
					Name = "Produrre Fiamma",
					CastingTime = "Azione bonus",
					Range = "Incantatore",
					Duration = "10 minuti",
					MaterialComponent = null,
					Description = "Una fiamma tremolante compare nella mano dell'incantatore e vi rimane per la durata. Finché è lì, la fiamma non emette calore e non incendia nulla, e proietta luce intensa in un raggio di 6 metri e luce fioca per altri 6 metri. L'incantesimo termina se l'incantatore lo lancia di nuovo.\n\nFinché l'incantesimo non termina, l'incantatore può effettuare un'azione di Magia per scagliare il fuoco contro una creatura o un oggetto entro 18 metri da sé, effettuando un attacco con incantesimo a distanza. Se colpisce, il bersaglio subisce 1d8 danni da fuoco.",
					HigherLevels = "I danni aumentano di 1d8 quando l'incantatore raggiunge il 5° livello (2d8), l'11° livello (3d8) e il 17° livello (4d8)."
				}
			}
		};
	}
}
