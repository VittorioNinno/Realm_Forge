using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fire Shield (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FireShield2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fire-shield");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fire-shield", "en"),
					Language = LanguageCode.En,
					Name = "Fire Shield",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "10 minutes",
					MaterialComponent = "a little phosphorus or a firefly",
					Description = "Thin and wispy flames wreathe your body for the duration, shedding bright light in a 10-foot radius and dim light for an additional 10 feet. You can end the spell early by using an action to dismiss it.\n\nThe flames provide you with a warm shield or a chill shield, as you choose. The warm shield grants you resistance to cold damage, and the chill shield grants you resistance to fire damage.\n\nIn addition, whenever a creature within 5 feet of you hits you with a melee attack, the shield erupts with flame. The attacker takes 2d8 fire damage from a warm shield, or 2d8 cold damage from a chill shield.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "fire-shield", "it"),
					Language = LanguageCode.It,
					Name = "Scudo di Fuoco",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "10 minuti",
					MaterialComponent = "un po' di fosforo o una lucciola",
					Description = "Per la durata, sottili fiamme evanescenti avvolgono il corpo dell'incantatore, emettendo luce intensa in un raggio di 3 metri e luce fioca per ulteriori 3 metri. L'incantatore può porre fine prematuramente all'incantesimo usando un'azione per congedarlo.\n\nLe fiamme forniscono all'incantatore uno scudo caldo o uno scudo gelido, a sua scelta. Lo scudo caldo gli conferisce resistenza ai danni da freddo, mentre lo scudo gelido gli conferisce resistenza ai danni da fuoco.\n\nInoltre, ogni volta che una creatura entro 1,5 metri dall'incantatore lo colpisce con un attacco in mischia, lo scudo erompe in fiamme. L'attaccante subisce 2d8 danni da fuoco se lo scudo è caldo, o 2d8 danni da freddo se lo scudo è gelido.",
					HigherLevels = null
				}
			}
		};
	}
}
