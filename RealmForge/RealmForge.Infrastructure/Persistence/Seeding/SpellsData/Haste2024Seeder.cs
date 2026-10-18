using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Haste (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Haste2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "haste");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "haste", "en"),
					Language = LanguageCode.En,
					Name = "Haste",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a shaving of licorice root",
					Description = "Choose a willing creature that you can see within range. Until the spell ends, the target's Speed is doubled, it gains a +2 bonus to Armor Class, it has Advantage on Dexterity saving throws, and it gains an additional action on each of its turns. That action can be used to take only the Attack (one attack only), Dash, Disengage, Hide, or Utilize action.\n\nWhen the spell ends, the target is Incapacitated and has a Speed of 0 until the end of its next turn, as a wave of lethargy washes over it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "haste", "it"),
					Language = LanguageCode.It,
					Name = "Velocità",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un frammento di radice di liquirizia",
					Description = "L'incantatore sceglie una creatura consenziente entro gittata che è in grado di vedere. Finché l'incantesimo non termina, la velocità del bersaglio raddoppia, il bersaglio ottiene un bonus di +2 alla Classe Armatura, dispone di vantaggio ai tiri salvezza su Destrezza e ottiene un'azione aggiuntiva in ognuno dei suoi turni. Quell'azione può essere usata soltanto per effettuare l'azione di Attacco (un solo attacco), Disimpegno, Nascondersi, Scatto o Utilizzo.\n\nQuando l'incantesimo termina, il bersaglio è incapacitato e ha velocità 0 fino alla fine del suo turno successivo, mentre un'ondata di letargia lo travolge.",
					HigherLevels = null
				}
			}
		};
	}
}
