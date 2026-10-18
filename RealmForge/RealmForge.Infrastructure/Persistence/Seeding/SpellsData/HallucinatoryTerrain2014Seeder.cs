using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hallucinatory Terrain (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HallucinatoryTerrain2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hallucinatory-terrain");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hallucinatory-terrain", "en"),
					Language = LanguageCode.En,
					Name = "Hallucinatory Terrain",
					CastingTime = "10 minutes",
					Range = "300 feet",
					Duration = "24 hours",
					MaterialComponent = "a stone, a twig, and a bit of green plant",
					Description = "You make natural terrain in a 150-foot cube in range look, sound, and smell like some other sort of natural terrain. Thus, open fields or a road can be made to resemble a swamp, hill, crevasse, or some other difficult or impassable terrain. A pond can be made to seem like a grassy meadow, a precipice like a gentle slope, or a rock-strewn gully like a wide and smooth road. Manufactured structures, equipment, and creatures within the area aren't changed in appearance.\n\nThe tactile characteristics of the terrain are unchanged, so creatures entering the area are likely to see through the illusion. If the difference isn't obvious by touch, a creature carefully examining the illusion can attempt an Intelligence (Investigation) check against your spell save DC to disbelieve it. A creature who discerns the illusion for what it is, sees it as a vague image superimposed on the terrain.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hallucinatory-terrain", "it"),
					Language = LanguageCode.It,
					Name = "Terreno Illusorio",
					CastingTime = "10 minuti",
					Range = "90 metri",
					Duration = "24 ore",
					MaterialComponent = "una pietra, un ramoscello e un pezzetto di pianta verde",
					Description = "L'incantatore fa sì che il terreno naturale in un cubo con spigolo di 45 metri entro gittata appaia, suoni e abbia l'odore di un altro tipo di terreno naturale. In questo modo, dei campi aperti o una strada possono essere fatti sembrare una palude, una collina, un crepaccio o un altro terreno difficile o invalicabile. Uno stagno può sembrare un prato erboso, un precipizio un dolce pendio e un canalone disseminato di rocce una strada ampia e liscia. Le strutture costruite, l'equipaggiamento e le creature nell'area non cambiano aspetto.\n\nLe caratteristiche tattili del terreno restano invariate, quindi le creature che entrano nell'area probabilmente si accorgono dell'illusione. Se la differenza non è evidente al tatto, una creatura che esamina attentamente l'illusione può effettuare una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore per smascherarla. Una creatura che riconosce l'illusione per ciò che è la vede come un'immagine indistinta sovrapposta al terreno.",
					HigherLevels = null
				}
			}
		};
	}
}
