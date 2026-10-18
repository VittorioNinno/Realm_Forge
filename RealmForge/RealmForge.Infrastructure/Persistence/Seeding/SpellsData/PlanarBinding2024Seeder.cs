using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Planar Binding (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PlanarBinding2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "planar-binding");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "planar-binding", "en"),
					Language = LanguageCode.En,
					Name = "Planar Binding",
					CastingTime = "1 hour",
					Range = "60 feet",
					Duration = "24 hours",
					MaterialComponent = "a jewel worth 1,000+ GP, which the spell consumes",
					Description = "You attempt to bind a Celestial, an Elemental, a Fey, or a Fiend to your service. The creature must be within range for the entire casting of the spell. (Typically, the creature is first summoned into the center of the inverted version of the *Magic Circle* spell to trap it while this spell is cast.) At the completion of the casting, the target must succeed on a Charisma saving throw or be bound to serve you for the duration. If the creature was summoned or created by another spell, that spell's duration is extended to match the duration of this spell.\n\nA bound creature must follow your commands to the best of its ability. You might command the creature to accompany you on an adventure, to guard a location, or to deliver a message. If the creature is Hostile, it strives to twist your commands to achieve its own objectives. If the creature carries out your commands completely before the spell ends, it travels to you to report this fact if you are on the same plane of existence. If you are on a different plane, it returns to the place where you bound it and remains there until the spell ends.",
					HigherLevels = "The duration increases with a spell slot of level 6 (10 days), 7 (30 days), 8 (180 days), and 9 (366 days)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "planar-binding", "it"),
					Language = LanguageCode.It,
					Name = "Legame Planare",
					CastingTime = "1 ora",
					Range = "18 metri",
					Duration = "24 ore",
					MaterialComponent = "un gioiello del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore tenta di vincolare al proprio servizio un celestiale, un elementale, un folletto o un immondo. La creatura deve trovarsi entro gittata per l'intera durata del lancio dell'incantesimo. (Di solito, la creatura viene prima evocata al centro della versione invertita dell'incantesimo *cerchio magico*, per intrappolarla mentre questo incantesimo viene lanciato.) Al termine del lancio, il bersaglio deve superare un tiro salvezza su Carisma, altrimenti è vincolato a servire l'incantatore per la durata. Se la creatura è stata evocata o creata da un altro incantesimo, la durata di quell'incantesimo viene estesa fino a corrispondere alla durata di questo incantesimo.\n\nUna creatura vincolata deve seguire i comandi dell'incantatore al meglio delle proprie capacità. L'incantatore potrebbe ordinarle di accompagnarlo in un'avventura, di sorvegliare un luogo o di consegnare un messaggio. Se la creatura è ostile, si sforza di distorcere i comandi per raggiungere i propri obiettivi. Se la creatura esegue completamente i comandi prima che l'incantesimo termini, si reca dall'incantatore per riferirlo, se si trovano sullo stesso piano di esistenza. Se l'incantatore si trova su un piano diverso, la creatura ritorna nel luogo in cui è stata vincolata e vi rimane finché l'incantesimo non termina.",
					HigherLevels = "La durata aumenta con uno slot incantesimo di 6° livello (10 giorni), di 7° livello (30 giorni), di 8° livello (180 giorni) e di 9° livello (366 giorni)."
				}
			}
		};
	}
}
