using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hold Monster (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HoldMonster2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hold-monster");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hold-monster", "en"),
					Language = LanguageCode.En,
					Name = "Hold Monster",
					CastingTime = "1 action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a small piece of iron",
					Description = "Choose a creature that you can see within range. The target must succeed on a Wisdom saving throw or be paralyzed for the duration. This spell has no effect on undead. At the end of each of its turns, the target can make another Wisdom saving throw. On a success, the spell ends on the target.",
					HigherLevels = "When you cast this spell using a spell slot of 6th level or higher, you can target one additional creature for each slot level above 5th. The creatures must be within 30 feet of each other when you target them."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hold-monster", "it"),
					Language = LanguageCode.It,
					Name = "Blocca Mostri",
					CastingTime = "1 azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un piccolo pezzo di ferro",
					Description = "L'incantatore sceglie una creatura entro gittata che sia in grado di vedere. Il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è paralizzato per la durata. Questo incantesimo non ha alcun effetto sui non morti. Alla fine di ogni suo turno, il bersaglio può effettuare un altro tiro salvezza su Saggezza. Se lo supera, l'incantesimo termina per quel bersaglio.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 6° livello o superiore, può bersagliare una creatura aggiuntiva per ogni livello dello slot superiore al 5°. Quando l'incantatore le bersaglia, le creature devono trovarsi entro 9 metri l'una dall'altra."
				}
			}
		};
	}
}
