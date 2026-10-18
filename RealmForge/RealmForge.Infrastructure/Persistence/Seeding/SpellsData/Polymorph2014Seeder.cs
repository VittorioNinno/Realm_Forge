using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Polymorph (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Polymorph2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "polymorph");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "polymorph", "en"),
					Language = LanguageCode.En,
					Name = "Polymorph",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a caterpillar cocoon",
					Description = "This spell transforms a creature that you can see within range into a new form. An unwilling creature must make a Wisdom saving throw to avoid the effect. A shapechanger automatically succeeds on this saving throw.\n\nThe transformation lasts for the duration, or until the target drops to 0 hit points or dies. The new form can be any beast whose challenge rating is equal to or less than the target's (or the target's level, if it doesn't have a challenge rating). The target's game statistics, including mental ability scores, are replaced by the statistics of the chosen beast. It retains its alignment and personality.\n\nThe target assumes the hit points of its new form. When it reverts to its normal form, the creature returns to the number of hit points it had before it transformed. If it reverts as a result of dropping to 0 hit points, any excess damage carries over to its normal form. As long as the excess damage doesn't reduce the creature's normal form to 0 hit points, it isn't knocked unconscious.\n\nThe creature is limited in the actions it can perform by the nature of its new form, and it can't speak, cast spells, or take any other action that requires hands or speech.\n\nThe target's gear melds into the new form. The creature can't activate, use, wield, or otherwise benefit from any of its equipment.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "polymorph", "it"),
					Language = LanguageCode.It,
					Name = "Metamorfosi",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "il bozzolo di un bruco",
					Description = "Questo incantesimo trasforma in una nuova forma una creatura entro gittata che l'incantatore sia in grado di vedere. Una creatura non consenziente deve effettuare un tiro salvezza su Saggezza per evitare l'effetto. Un mutaforma supera automaticamente questo tiro salvezza.\n\nLa trasformazione dura per la durata, o finché il bersaglio non scende a 0 punti ferita o muore. La nuova forma può essere quella di qualsiasi bestia con grado di sfida pari o inferiore a quello del bersaglio (o al livello del bersaglio, se non ha un grado di sfida). Le statistiche di gioco del bersaglio, compresi i punteggi delle caratteristiche mentali, vengono sostituite da quelle della bestia scelta. Il bersaglio conserva il proprio allineamento e la propria personalità.\n\nIl bersaglio assume i punti ferita della sua nuova forma. Quando torna alla sua forma normale, la creatura recupera i punti ferita che aveva prima della trasformazione. Se torna alla forma normale perché è scesa a 0 punti ferita, gli eventuali danni in eccesso si trasferiscono alla forma normale. Finché i danni in eccesso non riducono la forma normale della creatura a 0 punti ferita, la creatura non cade priva di sensi.\n\nLe azioni che la creatura può compiere sono limitate dalla natura della sua nuova forma, e la creatura non può parlare, lanciare incantesimi o compiere qualsiasi altra azione che richieda l'uso delle mani o della parola.\n\nL'equipaggiamento del bersaglio si fonde nella nuova forma. La creatura non può attivare, usare, impugnare o trarre in altro modo beneficio da alcun oggetto del proprio equipaggiamento.",
					HigherLevels = null
				}
			}
		};
	}
}
