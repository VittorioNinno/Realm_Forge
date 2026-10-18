using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Bestow Curse (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class BestowCurse2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "bestow-curse");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "bestow-curse", "en"),
					Language = LanguageCode.En,
					Name = "Bestow Curse",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You touch a creature, which must succeed on a Wisdom saving throw or become cursed for the duration. Until the curse ends, the target suffers one of the following effects of your choice:\n\n- Choose one ability. The target has Disadvantage on ability checks and saving throws made with that ability.\n\n- The target has Disadvantage on attack rolls against you.\n\n- In combat, the target must succeed on a Wisdom saving throw at the start of each of its turns or be forced to take the Dodge action on that turn.\n\n- If you deal damage to the target with an attack roll or a spell, the target takes an extra 1d8 Necrotic damage.",
					HigherLevels = "If you cast this spell using a level 4 spell slot, you can maintain Concentration on it for up to 10 minutes. If you use a level 5+ spell slot, the spell doesn't require Concentration, and the duration becomes 8 hours (level 5–6 slot) or 24 hours (level 7–8 slot). If you use a level 9 spell slot, the spell lasts until dispelled."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "bestow-curse", "it"),
					Language = LanguageCode.It,
					Name = "Scagliare Maledizione",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore tocca una creatura, che deve superare un tiro salvezza su Saggezza, altrimenti è maledetta per la durata. Finché la maledizione non termina, il bersaglio subisce uno degli effetti seguenti, a scelta dell'incantatore:\n\n- L'incantatore sceglie una caratteristica. Il bersaglio subisce svantaggio alle prove di caratteristica e ai tiri salvezza effettuati con quella caratteristica.\n\n- Il bersaglio subisce svantaggio ai tiri per colpire contro l'incantatore.\n\n- In combattimento, il bersaglio deve superare un tiro salvezza su Saggezza all'inizio di ogni suo turno, altrimenti è costretto a effettuare l'azione di Schivata in quel turno.\n\n- Se l'incantatore infligge danni al bersaglio con un tiro per colpire o con un incantesimo, il bersaglio subisce 1d8 danni necrotici extra.",
					HigherLevels = "Se l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello, può mantenere la concentrazione su di esso fino a 10 minuti. Se usa uno slot di 5° livello o superiore, l'incantesimo non richiede concentrazione e la durata diventa di 8 ore (slot di 5°-6° livello) o di 24 ore (slot di 7°-8° livello). Se usa uno slot incantesimo di 9° livello, l'incantesimo dura finché non viene dissolto."
				}
			}
		};
	}
}
