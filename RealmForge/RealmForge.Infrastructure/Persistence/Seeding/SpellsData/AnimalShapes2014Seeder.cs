using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Animal Shapes (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AnimalShapes2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animal-shapes");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animal-shapes", "en"),
					Language = LanguageCode.En,
					Name = "Animal Shapes",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 24 hours",
					MaterialComponent = null,
					Description = "Your magic turns others into beasts. Choose any number of willing creatures that you can see within range. You transform each target into the form of a Large or smaller beast with a challenge rating of 4 or lower. On subsequent turns, you can use your action to transform affected creatures into new forms.\n\nThe transformation lasts for the duration for each target, or until the target drops to 0 hit points or dies. You can choose a different form for each target. A target's game statistics are replaced by the statistics of the chosen beast, though the target retains its alignment and Intelligence, Wisdom, and Charisma scores. The target assumes the hit points of its new form, and when it reverts to its normal form, it returns to the number of hit points it had before it transformed. If it reverts as a result of dropping to 0 hit points, any excess damage carries over to its normal form. As long as the excess damage doesn't reduce the creature's normal form to 0 hit points, it isn't knocked unconscious. The creature is limited in the actions it can perform by the nature of its new form, and it can't speak or cast spells.\n\nThe target's gear melds into the new form. The target can't activate, wield, or otherwise benefit from any of its equipment.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animal-shapes", "it"),
					Language = LanguageCode.It,
					Name = "Forme Animali",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 24 ore",
					MaterialComponent = null,
					Description = "La magia dell'incantatore trasforma altre creature in bestie. L'incantatore sceglie un qualsiasi numero di creature consenzienti entro gittata che sia in grado di vedere. Trasforma ogni bersaglio in una bestia di taglia Grande o inferiore con grado di sfida pari o inferiore a 4. Nei turni successivi, può usare la sua azione per trasformare le creature influenzate in nuove forme.\n\nLa trasformazione dura per tutta la durata dell'incantesimo per ciascun bersaglio, oppure finché il bersaglio non scende a 0 punti ferita o muore. L'incantatore può scegliere una forma diversa per ogni bersaglio. Le statistiche di gioco del bersaglio sono sostituite da quelle della bestia scelta, ma il bersaglio conserva il proprio allineamento e i propri punteggi di Intelligenza, Saggezza e Carisma. Il bersaglio assume i punti ferita della nuova forma e, quando torna alla sua forma normale, recupera i punti ferita che aveva prima della trasformazione. Se torna alla forma normale perché è sceso a 0 punti ferita, gli eventuali danni in eccesso si trasferiscono alla forma normale. Finché i danni in eccesso non riducono la forma normale della creatura a 0 punti ferita, la creatura non cade priva di sensi. Le azioni che la creatura può compiere sono limitate dalla natura della sua nuova forma, e la creatura non può parlare né lanciare incantesimi.\n\nL'equipaggiamento del bersaglio si fonde nella nuova forma. Il bersaglio non può attivare, impugnare o trarre in altro modo beneficio da alcun oggetto del proprio equipaggiamento.",
					HigherLevels = null
				}
			}
		};
	}
}
