using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mirage Arcane (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MirageArcane2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mirage-arcane");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mirage-arcane", "en"),
					Language = LanguageCode.En,
					Name = "Mirage Arcane",
					CastingTime = "10 minutes",
					Range = "Sight",
					Duration = "10 days",
					MaterialComponent = null,
					Description = "You make terrain in an area up to 1 mile square look, sound, smell, and even feel like some other sort of terrain. Open fields or a road could be made to resemble a swamp, hill, crevasse, or some other rough or impassable terrain. A pond can be made to seem like a grassy meadow, a precipice like a gentle slope, or a rock-strewn gully like a wide and smooth road.\n\nSimilarly, you can alter the appearance of structures or add them where none are present. The spell doesn't disguise, conceal, or add creatures.\n\nThe illusion includes audible, visual, tactile, and olfactory elements, so it can turn clear ground into Difficult Terrain (or vice versa) or otherwise impede movement through the area. Any piece of the illusory terrain (such as a rock or stick) that is removed from the spell's area disappears immediately.\n\nCreatures with Truesight can see through the illusion to the terrain's true form; however, all other elements of the illusion remain, so while the creature is aware of the illusion's presence, the creature can still physically interact with the illusion.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "mirage-arcane", "it"),
					Language = LanguageCode.It,
					Name = "Miraggio Arcano",
					CastingTime = "10 minuti",
					Range = "Vista",
					Duration = "10 giorni",
					MaterialComponent = null,
					Description = "L'incantatore fa sì che il terreno in un'area quadrata con lato fino a 1,5 km abbia l'aspetto, i suoni, l'odore e persino la consistenza di un altro tipo di terreno. Campi aperti o una strada potrebbero essere fatti somigliare a una palude, una collina, un crepaccio o qualche altro terreno accidentato o impraticabile. Uno stagno può sembrare un prato erboso, un precipizio un dolce pendio, o un canalone disseminato di rocce una strada ampia e liscia.\n\nAllo stesso modo, l'incantatore può alterare l'aspetto delle strutture o aggiungerne dove non ce ne sono. L'incantesimo non camuffa, non nasconde e non aggiunge creature.\n\nL'illusione include elementi uditivi, visivi, tattili e olfattivi, quindi può trasformare un terreno sgombro in terreno difficile (o viceversa) od ostacolare in altro modo il movimento attraverso l'area. Qualsiasi frammento del terreno illusorio (come una roccia o un bastone) che viene rimosso dall'area dell'incantesimo scompare immediatamente.\n\nLe creature dotate di vista pura possono vedere attraverso l'illusione la vera forma del terreno; tuttavia, tutti gli altri elementi dell'illusione rimangono, quindi, pur essendo consapevole della presenza dell'illusione, la creatura può comunque interagire fisicamente con essa.",
					HigherLevels = null
				}
			}
		};
	}
}
