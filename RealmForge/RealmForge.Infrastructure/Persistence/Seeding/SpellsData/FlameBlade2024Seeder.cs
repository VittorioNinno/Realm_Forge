using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Flame Blade (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FlameBlade2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flame-blade");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flame-blade", "en"),
					Language = LanguageCode.En,
					Name = "Flame Blade",
					CastingTime = "Bonus Action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a sumac leaf",
					Description = "You evoke a fiery blade in your free hand. The blade is similar in size and shape to a scimitar, and it lasts for the duration. If you let go of the blade, it disappears, but you can evoke it again as a Bonus Action.\n\nAs a Magic action, you can make a melee spell attack with the fiery blade. On a hit, the target takes Fire damage equal to 3d6 plus your spellcasting ability modifier.\n\nThe flaming blade sheds Bright Light in a 10-foot radius and Dim Light for an additional 10 feet.",
					HigherLevels = "The damage increases by 1d6 for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flame-blade", "it"),
					Language = LanguageCode.It,
					Name = "Lama Infuocata",
					CastingTime = "Azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una foglia di sommacco",
					Description = "L'incantatore evoca una lama fiammeggiante nella propria mano libera. La lama ha forma e dimensioni simili a quelle di una scimitarra e permane per la durata. Se l'incantatore lascia la lama, questa scompare, ma può evocarla di nuovo come azione bonus.\n\nCome azione di Magia, l'incantatore può effettuare un attacco con incantesimo in mischia con la lama fiammeggiante. Se colpisce, il bersaglio subisce danni da fuoco pari a 3d6 più il modificatore di caratteristica da incantatore dell'incantatore.\n\nLa lama fiammeggiante proietta luce intensa in un raggio di 3 metri e luce fioca per altri 3 metri.",
					HigherLevels = "I danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
