using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dominate Person (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DominatePerson2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dominate-person");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dominate-person", "en"),
					Language = LanguageCode.En,
					Name = "Dominate Person",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "One Humanoid you can see within range must succeed on a Wisdom saving throw or have the Charmed condition for the duration. The target has Advantage on the save if you or your allies are fighting it. Whenever the target takes damage, it repeats the save, ending the spell on itself on a success.\n\nYou have a telepathic link with the Charmed target while the two of you are on the same plane of existence. On your turn, you can use this link to issue commands to the target (no action required), such as \"Attack that creature,\" \"Move over there,\" or \"Fetch that object.\" The target does its best to obey on its turn. If it completes an order and doesn't receive further direction from you, it acts and moves as it likes, focusing on protecting itself.\n\nYou can command the target to take a Reaction but must take your own Reaction to do so.",
					HigherLevels = "Your Concentration can last longer with a spell slot of level 6 (up to 10 minutes), 7 (up to 1 hour), or 8+ (up to 8 hours)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dominate-person", "it"),
					Language = LanguageCode.It,
					Name = "Dominare Persone",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Un umanoide entro gittata che l'incantatore è in grado di vedere deve superare un tiro salvezza su Saggezza, altrimenti è affascinato per la durata. Il bersaglio dispone di vantaggio al tiro salvezza se l'incantatore o i suoi alleati stanno combattendo contro di esso. Ogni volta che il bersaglio subisce danni, ripete il tiro salvezza e, se lo supera, l'incantesimo termina su di lui.\n\nL'incantatore ha un legame telepatico con il bersaglio affascinato finché entrambi si trovano sullo stesso piano di esistenza. Nel proprio turno, può usare questo legame per impartire comandi al bersaglio (non è richiesta alcuna azione), come \"Attacca quella creatura\", \"Spostati laggiù\" o \"Porta qui quell'oggetto\". Il bersaglio fa del suo meglio per obbedire nel proprio turno. Se porta a termine un ordine e non riceve ulteriori istruzioni dall'incantatore, agisce e si muove come preferisce, concentrandosi sulla propria protezione.\n\nL'incantatore può ordinare al bersaglio di effettuare una reazione, ma per farlo deve spendere la propria reazione.",
					HigherLevels = "La concentrazione dell'incantatore può durare più a lungo con uno slot incantesimo di 6° livello (fino a 10 minuti), di 7° livello (fino a 1 ora) o di 8° livello o superiore (fino a 8 ore)."
				}
			}
		};
	}
}
