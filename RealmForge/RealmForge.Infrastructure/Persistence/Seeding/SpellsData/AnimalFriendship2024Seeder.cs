using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Animal Friendship (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AnimalFriendship2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animal-friendship");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animal-friendship", "en"),
					Language = LanguageCode.En,
					Name = "Animal Friendship",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "24 hours",
					MaterialComponent = "a morsel of food",
					Description = "Target a Beast that you can see within range. The target must succeed on a Wisdom saving throw or have the Charmed condition for the duration. If you or one of your allies deals damage to the target, the spells ends.",
					HigherLevels = "You can target one additional Beast for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animal-friendship", "it"),
					Language = LanguageCode.It,
					Name = "Amicizia con gli Animali",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "24 ore",
					MaterialComponent = "un boccone di cibo",
					Description = "L'incantatore sceglie come bersaglio una bestia entro gittata che è in grado di vedere. Il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è affascinato per la durata. Se l'incantatore o uno dei suoi alleati infligge danni al bersaglio, l'incantesimo termina.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una bestia aggiuntiva per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
