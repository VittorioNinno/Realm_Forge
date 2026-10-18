using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Detect Thoughts (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DetectThoughts2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "detect-thoughts");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "detect-thoughts", "en"),
					Language = LanguageCode.En,
					Name = "Detect Thoughts",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "1 Copper Piece",
					Description = "You activate one of the effects below. Until the spell ends, you can activate either effect as a Magic action on your later turns.\n\n***Sense Thoughts.*** You sense the presence of thoughts within 30 feet of yourself that belong to creatures that know languages or are telepathic. You don't read the thoughts, but you know that a thinking creature is present.\n\nThe spell is blocked by 1 foot of stone, dirt, or wood; 1 inch of metal; or a thin sheet of lead.\n\n***Read Thoughts.*** Target one creature you can see within 30 feet of yourself or one creature within 30 feet of yourself that you detected with the Sense Thoughts option. You learn what is most on the target's mind right now. If the target doesn't know any languages and isn't telepathic, you learn nothing.\n\nAs a Magic action on your next turn, you can try to probe deeper into the target's mind. If you probe deeper, the target makes a Wisdom saving throw. On a failed save, you discern the target's reasoning, emotions, and something that looms large in its mind (such as a worry, love, or hate). On a successful save, the spell ends. Either way, the target knows that you are probing into its mind, and until you shift your attention away from the target's mind, the target can take an action on its turn to make an Intelligence (Arcana) check against your spell save DC, ending the spell on a success.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "detect-thoughts", "it"),
					Language = LanguageCode.It,
					Name = "Individuazione dei Pensieri",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "1 moneta di rame",
					Description = "L'incantatore attiva uno degli effetti seguenti. Finché l'incantesimo non termina, può attivare l'uno o l'altro effetto come azione di Magia nei turni successivi.\n\n***Percepire i Pensieri.*** L'incantatore percepisce la presenza di pensieri entro 9 metri da sé che appartengono a creature che conoscono dei linguaggi o che sono telepatiche. Non legge i pensieri, ma sa che è presente una creatura pensante.\n\nL'incantesimo è bloccato da 30 centimetri di pietra, terra o legno, da 2,5 centimetri di metallo o da una sottile lamina di piombo.\n\n***Leggere i Pensieri.*** L'incantatore sceglie come bersaglio una creatura che è in grado di vedere entro 9 metri da sé, oppure una creatura entro 9 metri da sé che ha individuato con l'opzione Percepire i Pensieri. Scopre ciò che occupa maggiormente la mente del bersaglio in quel momento. Se il bersaglio non conosce alcun linguaggio e non è telepatico, l'incantatore non scopre nulla.\n\nCome azione di Magia nel suo turno successivo, l'incantatore può tentare di sondare più a fondo la mente del bersaglio. Se lo fa, il bersaglio effettua un tiro salvezza su Saggezza. Se lo fallisce, l'incantatore comprende i ragionamenti del bersaglio, le sue emozioni e qualcosa che occupa un posto importante nella sua mente (come una preoccupazione, un amore o un odio). Se lo supera, l'incantesimo termina. In entrambi i casi, il bersaglio sa che l'incantatore sta sondando la sua mente e, finché l'incantatore non distoglie l'attenzione dalla sua mente, può effettuare un'azione nel proprio turno per compiere una prova di Intelligenza (Arcano) contro la CD del tiro salvezza degli incantesimi dell'incantatore; se la supera, l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
