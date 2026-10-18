using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Animal Friendship (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AnimalFriendship2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animal-friendship");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animal-friendship", "en"),
					Language = LanguageCode.En,
					Name = "Animal Friendship",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "24 hours",
					MaterialComponent = "a morsel of food",
					Description = "This spell lets you convince a beast that you mean it no harm. Choose a beast that you can see within range. It must see and hear you. If the beast's Intelligence is 4 or higher, the spell fails. Otherwise, the beast must succeed on a Wisdom saving throw or be charmed by you for the spell's duration. If you or one of your companions harms the target, the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animal-friendship", "it"),
					Language = LanguageCode.It,
					Name = "Amicizia con gli Animali",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "24 ore",
					MaterialComponent = "un boccone di cibo",
					Description = "Questo incantesimo permette all'incantatore di convincere una bestia che non ha intenzioni ostili nei suoi confronti. L'incantatore sceglie una bestia entro gittata che sia in grado di vedere. La bestia deve poterlo vedere e sentire. Se la bestia ha Intelligenza pari o superiore a 4, l'incantesimo fallisce. Altrimenti, la bestia deve superare un tiro salvezza su Saggezza, altrimenti è affascinata dall'incantatore per la durata dell'incantesimo. Se l'incantatore o uno dei suoi compagni ferisce il bersaglio, l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
