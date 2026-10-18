using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Charm Person (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CharmPerson2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "charm-person");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "charm-person", "en"),
					Language = LanguageCode.En,
					Name = "Charm Person",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "You attempt to charm a humanoid you can see within range. It must make a Wisdom saving throw, and does so with advantage if you or your companions are fighting it. If it fails the saving throw, it is charmed by you until the spell ends or until you or your companions do anything harmful to it. The charmed creature regards you as a friendly acquaintance. When the spell ends, the creature knows it was charmed by you.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st. The creatures must be within 30 feet of each other when you target them."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "charm-person", "it"),
					Language = LanguageCode.It,
					Name = "Charme su Persone",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "L'incantatore tenta di affascinare un umanoide entro gittata che sia in grado di vedere. Il bersaglio deve effettuare un tiro salvezza su Saggezza, con vantaggio se l'incantatore o i suoi compagni lo stanno combattendo. Se fallisce il tiro salvezza, è affascinato dall'incantatore finché l'incantesimo non termina o finché l'incantatore o i suoi compagni non compiono qualcosa di dannoso nei suoi confronti. La creatura affascinata considera l'incantatore un conoscente amichevole. Quando l'incantesimo termina, la creatura sa di essere stata affascinata dall'incantatore.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, può bersagliare una creatura aggiuntiva per ogni livello dello slot superiore al 1°. Quando l'incantatore le bersaglia, le creature devono trovarsi entro 9 metri l'una dall'altra."
				}
			}
		};
	}
}
