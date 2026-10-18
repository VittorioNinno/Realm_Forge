using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Banishment (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Banishment2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "banishment");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "banishment", "en"),
					Language = LanguageCode.En,
					Name = "Banishment",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "an item distasteful to the target",
					Description = "You attempt to send one creature that you can see within range to another plane of existence. The target must succeed on a Charisma saving throw or be banished.\n\nIf the target is native to the plane of existence you're on, you banish the target to a harmless demiplane. While there, the target is incapacitated. The target remains there until the spell ends, at which point the target reappears in the space it left or in the nearest unoccupied space if that space is occupied.\n\nIf the target is native to a different plane of existence than the one you're on, the target is banished with a faint popping noise, returning to its home plane. If the spell ends before 1 minute has passed, the target reappears in the space it left or in the nearest unoccupied space if that space is occupied. Otherwise, the target doesn't return.",
					HigherLevels = "When you cast this spell using a spell slot of 5th level or higher, you can target one additional creature for each slot level above 4th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "banishment", "it"),
					Language = LanguageCode.It,
					Name = "Esilio",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un oggetto sgradito al bersaglio",
					Description = "L'incantatore tenta di inviare in un altro piano di esistenza una creatura entro gittata che sia in grado di vedere. Il bersaglio deve superare un tiro salvezza su Carisma, altrimenti viene esiliato.\n\nSe il bersaglio è originario del piano di esistenza in cui si trova l'incantatore, viene esiliato in un semipiano innocuo. Finché si trova lì, il bersaglio è incapacitato. Il bersaglio vi rimane finché l'incantesimo non termina; a quel punto ricompare nello spazio che aveva lasciato o, se quello spazio è occupato, nello spazio libero più vicino.\n\nSe il bersaglio è originario di un piano di esistenza diverso da quello in cui si trova l'incantatore, viene esiliato con un lieve schiocco e fa ritorno al suo piano d'origine. Se l'incantesimo termina prima che sia trascorso 1 minuto, il bersaglio ricompare nello spazio che aveva lasciato o, se quello spazio è occupato, nello spazio libero più vicino. Altrimenti, il bersaglio non fa ritorno.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 5° livello o superiore, può bersagliare una creatura aggiuntiva per ogni livello dello slot superiore al 4°."
				}
			}
		};
	}
}
