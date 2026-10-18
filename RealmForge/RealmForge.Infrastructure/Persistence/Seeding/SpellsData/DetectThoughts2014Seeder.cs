using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Detect Thoughts (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DetectThoughts2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "detect-thoughts");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "detect-thoughts", "en"),
					Language = LanguageCode.En,
					Name = "Detect Thoughts",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a copper coin",
					Description = "For the duration, you can read the thoughts of certain creatures. When you cast the spell and as your action on each turn until the spell ends, you can focus your mind on any one creature that you can see within 30 feet of you. If the creature you choose has an Intelligence of 3 or lower or doesn't speak any language, the creature is unaffected.\n\nYou initially learn the surface thoughts of the creature - what is most on its mind in that moment. As an action, you can either shift your attention to another creature's thoughts or attempt to probe deeper into the same creature's mind. If you probe deeper, the target must make a Wisdom saving throw. If it fails, you gain insight into its reasoning (if any), its emotional state, and something that looms large in its mind (such as something it worries over, loves, or hates). If it succeeds, the spell ends. Either way, the target knows that you are probing into its mind, and unless you shift your attention to another creature's thoughts, the creature can use its action on its turn to make an Intelligence check contested by your Intelligence check; if it succeeds, the spell ends.\n\nQuestions verbally directed at the target creature naturally shape the course of its thoughts, so this spell is particularly effective as part of an interrogation.\n\nYou can also use this spell to detect the presence of thinking creatures you can't see. When you cast the spell or as your action during the duration, you can search for thoughts within 30 feet of you. The spell can penetrate barriers, but 2 feet of rock, 2 inches of any metal other than lead, or a thin sheet of lead blocks you. You can't detect a creature with an Intelligence of 3 or lower or one that doesn't speak any language.\n\nOnce you detect the presence of a creature in this way, you can read its thoughts for the rest of the duration as described above, even if you can't see it, but it must still be within range.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "detect-thoughts", "it"),
					Language = LanguageCode.It,
					Name = "Individuazione dei Pensieri",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una moneta di rame",
					Description = "Per la durata, l'incantatore può leggere i pensieri di determinate creature. Quando lancia l'incantesimo, e come azione in ogni turno finché l'incantesimo non termina, può concentrare la mente su una qualsiasi creatura entro 9 metri da lui che sia in grado di vedere. Se la creatura scelta ha Intelligenza pari o inferiore a 3 o non parla alcun linguaggio, non è influenzata.\n\nAll'inizio l'incantatore apprende i pensieri superficiali della creatura, ovvero ciò che occupa maggiormente la sua mente in quel momento. Come azione, può spostare la sua attenzione sui pensieri di un'altra creatura oppure tentare di sondare più a fondo la mente della stessa creatura. Se sonda più a fondo, il bersaglio deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, l'incantatore ottiene un'intuizione sul ragionamento del bersaglio (se ne ha uno), sul suo stato emotivo e su qualcosa che occupa un posto importante nella sua mente (come qualcosa che lo preoccupa, che ama o che odia). Se lo supera, l'incantesimo termina. In entrambi i casi, il bersaglio sa che l'incantatore sta sondando la sua mente e, a meno che l'incantatore non sposti la sua attenzione sui pensieri di un'altra creatura, la creatura può usare la sua azione nel proprio turno per effettuare una prova di Intelligenza contrapposta a una prova di Intelligenza dell'incantatore; se la vince, l'incantesimo termina.\n\nLe domande rivolte verbalmente alla creatura bersaglio orientano naturalmente il corso dei suoi pensieri, quindi questo incantesimo è particolarmente efficace durante un interrogatorio.\n\nL'incantatore può usare questo incantesimo anche per individuare la presenza di creature pensanti che non è in grado di vedere. Quando lancia l'incantesimo, o come azione per la durata, può cercare pensieri entro 9 metri da sé. L'incantesimo può penetrare le barriere, ma 60 cm di roccia, 5 cm di qualsiasi metallo diverso dal piombo o una sottile lamina di piombo lo bloccano. Non può individuare una creatura con Intelligenza pari o inferiore a 3 o che non parla alcun linguaggio.\n\nUna volta individuata la presenza di una creatura in questo modo, l'incantatore può leggerne i pensieri per il resto della durata come descritto sopra, anche se non è in grado di vederla, ma la creatura deve comunque trovarsi entro gittata.",
					HigherLevels = null
				}
			}
		};
	}
}
