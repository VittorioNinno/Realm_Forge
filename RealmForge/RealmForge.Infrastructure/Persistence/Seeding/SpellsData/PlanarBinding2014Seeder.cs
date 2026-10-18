using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Planar Binding (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PlanarBinding2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "planar-binding");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "planar-binding", "en"),
					Language = LanguageCode.En,
					Name = "Planar Binding",
					CastingTime = "1 hour",
					Range = "60 feet",
					Duration = "24 hours",
					MaterialComponent = "a jewel worth at least 1,000 gp, which the spell consumes",
					Description = "With this spell, you attempt to bind a celestial, an elemental, a fey, or a fiend to your service. The creature must be within range for the entire casting of the spell. (Typically, the creature is first summoned into the center of an inverted magic circle in order to keep it trapped while this spell is cast.) At the completion of the casting, the target must make a Charisma saving throw. On a failed save, it is bound to serve you for the duration. If the creature was summoned or created by another spell, that spell's duration is extended to match the duration of this spell.\n\nA bound creature must follow your instructions to the best of its ability. You might command the creature to accompany you on an adventure, to guard a location, or to deliver a message. The creature obeys the letter of your instructions, but if the creature is hostile to you, it strives to twist your words to achieve its own objectives. If the creature carries out your instructions completely before the spell ends, it travels to you to report this fact if you are on the same plane of existence. If you are on a different plane of existence, it returns to the place where you bound it and remains there until the spell ends.",
					HigherLevels = "When you cast this spell using a spell slot of a higher level, the duration increases to 10 days with a 6th-level slot, to 30 days with a 7th-level slot, to 180 days with an 8th-level slot, and to a year and a day with a 9th-level spell slot."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "planar-binding", "it"),
					Language = LanguageCode.It,
					Name = "Legame Planare",
					CastingTime = "1 ora",
					Range = "18 metri",
					Duration = "24 ore",
					MaterialComponent = "un gioiello del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "Con questo incantesimo, l'incantatore tenta di vincolare al proprio servizio un celestiale, un elementale, un folletto o un immondo. La creatura deve trovarsi entro gittata per tutto il lancio dell'incantesimo. (Di solito, la creatura viene prima evocata al centro di un cerchio magico invertito, così da tenerla intrappolata mentre viene lanciato questo incantesimo.) Al termine del lancio, il bersaglio deve effettuare un tiro salvezza su Carisma. Se lo fallisce, è vincolato a servire l'incantatore per la durata. Se la creatura è stata evocata o creata da un altro incantesimo, la durata di quell'incantesimo viene estesa fino a coincidere con quella di questo incantesimo.\n\nUna creatura vincolata deve seguire le istruzioni dell'incantatore al meglio delle sue capacità. L'incantatore potrebbe ordinarle di accompagnarlo in un'avventura, di sorvegliare un luogo o di recapitare un messaggio. La creatura obbedisce alla lettera alle istruzioni, ma se è ostile all'incantatore si sforza di distorcerne le parole per perseguire i propri obiettivi. Se la creatura porta a termine completamente le istruzioni prima che l'incantesimo termini, raggiunge l'incantatore per riferirglielo, se si trovano sullo stesso piano di esistenza. Se l'incantatore si trova su un piano di esistenza diverso, la creatura torna nel luogo in cui è stata vincolata e vi rimane finché l'incantesimo non termina.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di livello superiore, la durata aumenta a 10 giorni con uno slot di 6° livello, a 30 giorni con uno slot di 7° livello, a 180 giorni con uno slot di 8° livello e a un anno e un giorno con uno slot incantesimo di 9° livello."
				}
			}
		};
	}
}
