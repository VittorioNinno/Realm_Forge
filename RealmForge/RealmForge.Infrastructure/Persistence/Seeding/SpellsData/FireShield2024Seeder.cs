using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fire Shield (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FireShield2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fire-shield");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fire-shield", "en"),
					Language = LanguageCode.En,
					Name = "Fire Shield",
					CastingTime = "Action",
					Range = "Self",
					Duration = "10 minutes",
					MaterialComponent = "a bit of phosphorus or a firefly",
					Description = "Wispy flames wreathe your body for the duration, shedding Bright Light in a 10-foot radius and Dim Light for an additional 10 feet.\n\nThe flames provide you with a warm shield or a chill shield, as you choose. The warm shield grants you Resistance to Cold damage, and the chill shield grants you Resistance to Fire damage.\n\nIn addition, whenever a creature within 5 feet of you hits you with a melee attack roll, the shield erupts with flame. The attacker takes 2d8 Fire damage from a warm shield or 2d8 Cold damage from a chill shield.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fire-shield", "it"),
					Language = LanguageCode.It,
					Name = "Scudo di Fuoco",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "10 minuti",
					MaterialComponent = "un pezzetto di fosforo o una lucciola",
					Description = "Per la durata, sottili fiamme avvolgono il corpo dell'incantatore, proiettando luce intensa in un raggio di 3 metri e luce fioca per altri 3 metri.\n\nLe fiamme forniscono all'incantatore uno scudo caldo o uno scudo gelido, a sua scelta. Lo scudo caldo gli conferisce resistenza ai danni da freddo e lo scudo gelido gli conferisce resistenza ai danni da fuoco.\n\nInoltre, ogni volta che una creatura entro 1,5 metri dall'incantatore lo colpisce con un tiro per colpire in mischia, lo scudo erompe in fiamme. L'attaccante subisce 2d8 danni da fuoco da uno scudo caldo o 2d8 danni da freddo da uno scudo gelido.",
					HigherLevels = null
				}
			}
		};
	}
}
