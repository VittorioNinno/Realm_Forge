using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Haste (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Haste2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "haste");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "haste", "en"),
					Language = LanguageCode.En,
					Name = "Haste",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a shaving of licorice root",
					Description = "Choose a willing creature that you can see within range. Until the spell ends, the target's speed is doubled, it gains a +2 bonus to AC, it has advantage on Dexterity saving throws, and it gains an additional action on each of its turns. That action can be used only to take the Attack (one weapon attack only), Dash, Disengage, Hide, or Use an Object action.\n\nWhen the spell ends, the target can't move or take actions until after its next turn, as a wave of lethargy sweeps over it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "haste", "it"),
					Language = LanguageCode.It,
					Name = "Velocità",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un ricciolo di radice di liquirizia",
					Description = "L'incantatore sceglie una creatura consenziente entro gittata che sia in grado di vedere. Finché l'incantesimo non termina, la velocità del bersaglio raddoppia, il bersaglio ottiene un bonus di +2 alla CA, dispone di vantaggio ai tiri salvezza su Destrezza e ottiene un'azione aggiuntiva in ognuno dei suoi turni. Quell'azione può essere usata soltanto per effettuare l'azione di Attacco (un solo attacco con un'arma), Disimpegno, Nascondersi, Scatto o Usare un Oggetto.\n\nQuando l'incantesimo termina, il bersaglio non può muoversi né compiere azioni fino al termine del suo turno successivo, poiché viene sopraffatto da un'ondata di letargia.",
					HigherLevels = null
				}
			}
		};
	}
}
