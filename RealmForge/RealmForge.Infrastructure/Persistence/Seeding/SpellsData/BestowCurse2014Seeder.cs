using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Bestow Curse (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class BestowCurse2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "bestow-curse");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "bestow-curse", "en"),
					Language = LanguageCode.En,
					Name = "Bestow Curse",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You touch a creature, and that creature must succeed on a Wisdom saving throw or become cursed for the duration of the spell. When you cast this spell, choose the nature of the curse from the following options:\n\n- Choose one ability score. While cursed, the target has disadvantage on ability checks and saving throws made with that ability score.\n\n- While cursed, the target has disadvantage on attack rolls against you.\n\n- While cursed, the target must make a Wisdom saving throw at the start of each of its turns. If it fails, it wastes its action that turn doing nothing.\n\n- While the target is cursed, your attacks and spells deal an extra 1d8 necrotic damage to the target.\n\nA remove curse spell ends this effect. At the GM's option, you may choose an alternative curse effect, but it should be no more powerful than those described above. The GM has final say on such a curse's effect.",
					HigherLevels = "If you cast this spell using a spell slot of 4th level or higher, the duration is concentration, up to 10 minutes. If you use a spell slot of 5th level or higher, the duration is 8 hours. If you use a spell slot of 7th level or higher, the duration is 24 hours. If you use a 9th level spell slot, the spell lasts until it is dispelled. Using a spell slot of 5th level or higher grants a duration that doesn't require concentration."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "bestow-curse", "it"),
					Language = LanguageCode.It,
					Name = "Scagliare Maledizione",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore tocca una creatura, che deve superare un tiro salvezza su Saggezza, altrimenti diventa maledetta per la durata dell'incantesimo. Quando lancia questo incantesimo, l'incantatore sceglie la natura della maledizione tra le opzioni seguenti:\n\n- Sceglie un punteggio di caratteristica. Finché è maledetto, il bersaglio subisce svantaggio alle prove di caratteristica e ai tiri salvezza effettuati con quel punteggio di caratteristica.\n\n- Finché è maledetto, il bersaglio subisce svantaggio ai tiri per colpire contro l'incantatore.\n\n- Finché è maledetto, il bersaglio deve effettuare un tiro salvezza su Saggezza all'inizio di ogni suo turno. Se lo fallisce, spreca la sua azione di quel turno senza fare nulla.\n\n- Finché il bersaglio è maledetto, gli attacchi e gli incantesimi dell'incantatore gli infliggono 1d8 danni necrotici extra.\n\nUn incantesimo rimuovi maledizione pone fine a questo effetto. A discrezione del DM, l'incantatore può scegliere un effetto di maledizione alternativo, che non dovrebbe però essere più potente di quelli descritti sopra. Il DM ha l'ultima parola sull'effetto di una tale maledizione.",
					HigherLevels = "Se l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, la durata diventa concentrazione, fino a 10 minuti. Se usa uno slot incantesimo di 5° livello o superiore, la durata è di 8 ore. Se usa uno slot incantesimo di 7° livello o superiore, la durata è di 24 ore. Se usa uno slot incantesimo di 9° livello, l'incantesimo dura finché non viene dissolto. Usando uno slot incantesimo di 5° livello o superiore, la durata non richiede concentrazione."
				}
			}
		};
	}
}
