using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Armor of Agathys (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ArmorOfAgathys2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "armor-of-agathys");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "armor-of-agathys", "en"),
					Language = LanguageCode.En,
					Name = "Armor of Agathys",
					CastingTime = "Bonus Action",
					Range = "Self",
					Duration = "1 hour",
					MaterialComponent = "a shard of blue glass",
					Description = "A coat of magical frost settles over you. You gain 5 Temporary Hit Points. Until the spell ends, any creature that hits you with a melee attack roll takes 5 Cold damage. The spell ends early once you have no Temporary Hit Points left.",
					HigherLevels = "Both the Temporary Hit Points and the Cold damage increase by 5 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "armor-of-agathys", "it"),
					Language = LanguageCode.It,
					Name = "Armatura di Agathys",
					CastingTime = "Azione bonus",
					Range = "Incantatore",
					Duration = "1 ora",
					MaterialComponent = "una scheggia di vetro azzurro",
					Description = "Uno strato di brina magica si deposita sull'incantatore, che ottiene 5 punti ferita temporanei. Finché l'incantesimo non termina, qualsiasi creatura che colpisce l'incantatore con un tiro per colpire in mischia subisce 5 danni da freddo. L'incantesimo termina prima del tempo quando all'incantatore non resta più alcun punto ferita temporaneo.",
					HigherLevels = "Sia i punti ferita temporanei sia i danni da freddo aumentano di 5 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
