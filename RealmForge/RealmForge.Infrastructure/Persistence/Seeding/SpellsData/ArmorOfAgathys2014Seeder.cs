using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Armor of Agathys (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ArmorOfAgathys2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "armor-of-agathys");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "armor-of-agathys", "en"),
					Language = LanguageCode.En,
					Name = "Armor of Agathys",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "1 hour",
					MaterialComponent = "a cup of water",
					Description = "A layer of spectral frost settles over you and your gear, shielding you with protective magic. You gain 5 temporary hit points for the duration. While you still have any of these temporary hit points, a creature that hits you with a melee attack takes 5 cold damage.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the temporary hit points and the cold damage both increase by 5 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "armor-of-agathys", "it"),
					Language = LanguageCode.It,
					Name = "Armatura di Agathys",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "1 ora",
					MaterialComponent = "una coppa d'acqua",
					Description = "Uno strato di brina spettrale si deposita sull'incantatore e sul suo equipaggiamento, proteggendolo con una magia difensiva. L'incantatore ottiene 5 punti ferita temporanei per la durata. Finché gli resta almeno uno di questi punti ferita temporanei, una creatura che lo colpisce con un attacco in mischia subisce 5 danni da freddo.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, sia i punti ferita temporanei sia i danni da freddo aumentano di 5 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
