using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hallucinatory Terrain (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HallucinatoryTerrain2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hallucinatory-terrain");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hallucinatory-terrain", "en"),
					Language = LanguageCode.En,
					Name = "Hallucinatory Terrain",
					CastingTime = "10 minutes",
					Range = "300 feet",
					Duration = "24 hours",
					MaterialComponent = "a mushroom",
					Description = "You make natural terrain in a 150-foot Cube in range look, sound, and smell like another sort of natural terrain. Thus, open fields or a road can be made to resemble a swamp, hill, crevasse, or some other difficult or impassable terrain. A pond can be made to seem like a grassy meadow, a precipice like a gentle slope, or a rock-strewn gully like a wide and smooth road. Manufactured structures, equipment, and creatures within the area aren't changed.\n\nThe tactile characteristics of the terrain are unchanged, so creatures entering the area are likely to notice the illusion. If the difference isn't obvious by touch, a creature examining the illusion can take the Study action to make an Intelligence (Investigation) check against your spell save DC to disbelieve it. If a creature discerns that the terrain is illusory, the creature sees a vague image superimposed on the real terrain.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hallucinatory-terrain", "it"),
					Language = LanguageCode.It,
					Name = "Terreno Illusorio",
					CastingTime = "10 minuti",
					Range = "90 metri",
					Duration = "24 ore",
					MaterialComponent = "un fungo",
					Description = "L'incantatore fa sì che il terreno naturale in un cubo con spigolo di 45 metri entro gittata abbia l'aspetto, i suoni e l'odore di un altro tipo di terreno naturale. Così, campi aperti o una strada possono essere fatti somigliare a una palude, una collina, un crepaccio o qualche altro terreno difficile o impraticabile. Uno stagno può sembrare un prato erboso, un precipizio un dolce pendio, o un canalone disseminato di rocce una strada ampia e liscia. Le strutture costruite, l'equipaggiamento e le creature all'interno dell'area non cambiano.\n\nLe caratteristiche tattili del terreno restano invariate, quindi è probabile che le creature che entrano nell'area notino l'illusione. Se la differenza non è evidente al tatto, una creatura che esamina l'illusione può effettuare l'azione di Studio per compiere una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore per non crederci. Se una creatura si accorge che il terreno è illusorio, vede un'immagine vaga sovrapposta al terreno reale.",
					HigherLevels = null
				}
			}
		};
	}
}
