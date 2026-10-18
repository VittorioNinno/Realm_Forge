using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dominate Beast (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DominateBeast2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dominate-beast");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dominate-beast", "en"),
					Language = LanguageCode.En,
					Name = "Dominate Beast",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You attempt to beguile a creature that you can see within range. It must succeed on a Wisdom saving throw or be charmed by you for the duration. If you or creatures that are friendly to you are fighting it, it has advantage on the saving throw.\n\nWhile the creature is charmed, you have a telepathic link with it as long as the two of you are on the same plane of existence. You can use this telepathic link to issue commands to the creature while you are conscious (no action required), which it does its best to obey. You can specify a simple and general course of action, such as \"Attack that creature,\" \"Run over there,\" or \"Fetch that object.\" If the creature completes the order and doesn't receive further direction from you, it defends and preserves itself to the best of its ability.\n\nYou can use your action to take total and precise control of the target. Until the end of your next turn, the creature takes only the actions you choose, and doesn't do anything that you don't allow it to do. During this time, you can also cause the creature to use a reaction, but this requires you to use your own reaction as well. Each time the target takes damage, it makes a new Wisdom saving throw against the spell. If the saving throw succeeds, the spell ends.",
					HigherLevels = "When you cast this spell with a 9th level spell slot, the duration is concentration, up to 8 hours."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dominate-beast", "it"),
					Language = LanguageCode.It,
					Name = "Dominare Bestie",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore tenta di soggiogare una bestia entro gittata che sia in grado di vedere. La bestia deve superare un tiro salvezza su Saggezza, altrimenti è affascinata dall'incantatore per la durata. Se l'incantatore o creature a lui amichevoli la stanno combattendo, la bestia dispone di vantaggio al tiro salvezza.\n\nFinché la creatura è affascinata, l'incantatore ha un legame telepatico con essa, purché entrambi si trovino sullo stesso piano di esistenza. Finché è cosciente, l'incantatore può usare questo legame telepatico per impartire comandi alla creatura (non è richiesta alcuna azione), che fa del suo meglio per obbedire. Può specificare una linea d'azione semplice e generica, come \"Attacca quella creatura\", \"Corri laggiù\" o \"Prendi quell'oggetto\". Se la creatura porta a termine l'ordine e non riceve ulteriori istruzioni dall'incantatore, si difende e si preserva al meglio delle sue capacità.\n\nL'incantatore può usare la sua azione per assumere il controllo totale e preciso del bersaglio. Fino alla fine del turno successivo dell'incantatore, la creatura compie soltanto le azioni da lui scelte e non fa nulla che l'incantatore non le permetta di fare. Durante questo periodo, l'incantatore può anche far usare una reazione alla creatura, ma per farlo deve usare anche la propria reazione. Ogni volta che il bersaglio subisce danni, effettua un nuovo tiro salvezza su Saggezza contro l'incantesimo. Se lo supera, l'incantesimo termina.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 9° livello, la durata diventa concentrazione, fino a 8 ore."
				}
			}
		};
	}
}
