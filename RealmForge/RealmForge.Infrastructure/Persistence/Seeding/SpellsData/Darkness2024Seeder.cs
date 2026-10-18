using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Darkness (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Darkness2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "darkness");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "darkness", "en"),
					Language = LanguageCode.En,
					Name = "Darkness",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "bat fur and a piece of coal",
					Description = "For the duration, magical Darkness spreads from a point within range and fills a 15-foot-radius Sphere. Darkvision can't see through it, and nonmagical light can't illuminate it.\n\nAlternatively, you cast the spell on an object that isn't being worn or carried, causing the Darkness to fill a 15-foot Emanation originating from that object. Covering that object with something opaque, such as a bowl or helm, blocks the Darkness.\n\nIf any of this spell's area overlaps with an area of Bright Light or Dim Light created by a spell of level 2 or lower, that other spell is dispelled.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "darkness", "it"),
					Language = LanguageCode.It,
					Name = "Oscurità",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "pelo di pipistrello e un pezzo di carbone",
					Description = "Per la durata, un'oscurità magica si espande da un punto entro gittata e riempie una sfera del raggio di 4,5 metri. La scurovisione non permette di vedere attraverso di essa e la luce non magica non può illuminarla.\n\nIn alternativa, l'incantatore lancia l'incantesimo su un oggetto che non sia indossato o trasportato, facendo sì che l'oscurità riempia un'emanazione di 4,5 metri che ha origine da quell'oggetto. Coprire l'oggetto con qualcosa di opaco, come una ciotola o un elmo, blocca l'oscurità.\n\nSe una qualsiasi parte dell'area di questo incantesimo si sovrappone a un'area di luce intensa o di luce fioca creata da un incantesimo di 2° livello o inferiore, quell'altro incantesimo viene dissolto.",
					HigherLevels = null
				}
			}
		};
	}
}
