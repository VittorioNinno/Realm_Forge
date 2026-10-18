using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Flame Blade (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FlameBlade2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flame-blade");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flame-blade", "en"),
					Language = LanguageCode.En,
					Name = "Flame Blade",
					CastingTime = "1 bonus action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "leaf of sumac",
					Description = "You evoke a fiery blade in your free hand. The blade is similar in size and shape to a scimitar, and it lasts for the duration. If you let go of the blade, it disappears, but you can evoke the blade again as a bonus action.\n\nYou can use your action to make a melee spell attack with the fiery blade. On a hit, the target takes 3d6 fire damage.\n\nThe flaming blade sheds bright light in a 10-foot radius and dim light for an additional 10 feet.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for every two slot levels above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flame-blade", "it"),
					Language = LanguageCode.It,
					Name = "Lama Infuocata",
					CastingTime = "1 azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una foglia di sommacco",
					Description = "L'incantatore evoca una lama infuocata nella sua mano libera. La lama ha dimensioni e forma simili a quelle di una scimitarra e dura per la durata. Se l'incantatore lascia andare la lama, questa scompare, ma l'incantatore può evocarla di nuovo come azione bonus.\n\nL'incantatore può usare la sua azione per effettuare un attacco con incantesimo in mischia con la lama infuocata. Se colpisce, il bersaglio subisce 3d6 danni da fuoco.\n\nLa lama infuocata emette luce intensa in un raggio di 3 metri e luce fioca per ulteriori 3 metri.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, i danni aumentano di 1d6 ogni due livelli dello slot superiori al 2°."
				}
			}
		};
	}
}
