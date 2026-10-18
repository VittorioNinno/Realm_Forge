using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	True Polymorph (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TruePolymorph2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-polymorph");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 9,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-polymorph", "en"),
					Language = LanguageCode.En,
					Name = "True Polymorph",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a drop of mercury, a dollop of gum arabic, and a wisp of smoke",
					Description = "Choose one creature or nonmagical object that you can see within range. You transform the creature into a different creature, the creature into an object, or the object into a creature (the object must be neither worn nor carried by another creature). The transformation lasts for the duration, or until the target drops to 0 hit points or dies. If you concentrate on this spell for the full duration, the transformation becomes permanent.\n\nShapechangers aren't affected by this spell. An unwilling creature can make a Wisdom saving throw, and if it succeeds, it isn't affected by this spell.\n\n***Creature into Creature.*** If you turn a creature into another kind of creature, the new form can be any kind you choose whose challenge rating is equal to or less than the target's (or its level, if the target doesn't have a challenge rating). The target's game statistics, including mental ability scores, are replaced by the statistics of the new form. It retains its alignment and personality.\n\nThe target assumes the hit points of its new form, and when it reverts to its normal form, the creature returns to the number of hit points it had before it transformed. If it reverts as a result of dropping to 0 hit points, any excess damage carries over to its normal form. As long as the excess damage doesn't reduce the creature's normal form to 0 hit points, it isn't knocked unconscious.\n\nThe creature is limited in the actions it can perform by the nature of its new form, and it can't speak, cast spells, or take any other action that requires hands or speech unless its new form is capable of such actions.\n\nThe target's gear melds into the new form. The creature can't activate, use, wield, or otherwise benefit from any of its equipment.\n\n***Object into Creature.*** You can turn an object into any kind of creature, as long as the creature's size is no larger than the object's size and the creature's challenge rating is 9 or lower. The creature is friendly to you and your companions. It acts on each of your turns. You decide what action it takes and how it moves. The GM has the creature's statistics and resolves all of its actions and movement.\n\nIf the spell becomes permanent, you no longer control the creature. It might remain friendly to you, depending on how you have treated it.\n\n***Creature into Object.*** If you turn a creature into an object, it transforms along with whatever it is wearing and carrying into that form. The creature's statistics become those of the object, and the creature has no memory of time spent in this form, after the spell ends and it returns to its normal form.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "true-polymorph", "it"),
					Language = LanguageCode.It,
					Name = "Metamorfosi Pura",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "una goccia di mercurio, un grumo di gomma arabica e un filo di fumo",
					Description = "L'incantatore sceglie una creatura o un oggetto non magico entro gittata che sia in grado di vedere. Trasforma la creatura in una creatura diversa, la creatura in un oggetto oppure l'oggetto in una creatura (l'oggetto non deve essere né indossato né trasportato da un'altra creatura). La trasformazione dura per la durata, o finché il bersaglio non scende a 0 punti ferita o muore. Se l'incantatore mantiene la concentrazione su questo incantesimo per l'intera durata, la trasformazione diventa permanente.\n\nI mutaforma non sono influenzati da questo incantesimo. Una creatura non consenziente può effettuare un tiro salvezza su Saggezza e, se lo supera, non è influenzata da questo incantesimo.\n\n***Da Creatura a Creatura.*** Se l'incantatore trasforma una creatura in un altro tipo di creatura, la nuova forma può essere di qualsiasi tipo a sua scelta, purché con grado di sfida pari o inferiore a quello del bersaglio (o al suo livello, se il bersaglio non ha un grado di sfida). Le statistiche di gioco del bersaglio, compresi i punteggi delle caratteristiche mentali, vengono sostituite da quelle della nuova forma. Il bersaglio conserva il proprio allineamento e la propria personalità.\n\nIl bersaglio assume i punti ferita della nuova forma e, quando torna alla sua forma normale, recupera i punti ferita che aveva prima della trasformazione. Se torna alla forma normale perché è sceso a 0 punti ferita, gli eventuali danni in eccesso si trasferiscono alla forma normale. Finché i danni in eccesso non riducono la forma normale della creatura a 0 punti ferita, la creatura non cade priva di sensi.\n\nLe azioni che la creatura può compiere sono limitate dalla natura della sua nuova forma, e la creatura non può parlare, lanciare incantesimi o compiere qualsiasi altra azione che richieda l'uso delle mani o della parola, a meno che la nuova forma non sia in grado di compiere tali azioni.\n\nL'equipaggiamento del bersaglio si fonde nella nuova forma. La creatura non può attivare, usare, impugnare o trarre in altro modo beneficio da alcun oggetto del proprio equipaggiamento.\n\n***Da Oggetto a Creatura.*** L'incantatore può trasformare un oggetto in qualsiasi tipo di creatura, purché la taglia della creatura non sia superiore alle dimensioni dell'oggetto e il suo grado di sfida sia pari o inferiore a 9. La creatura è amichevole nei confronti dell'incantatore e dei suoi compagni. Agisce in ogni turno dell'incantatore, che decide quale azione compie e come si muove. Il DM possiede le statistiche della creatura e ne risolve tutte le azioni e i movimenti.\n\nSe l'incantesimo diventa permanente, l'incantatore non controlla più la creatura, che potrebbe restare amichevole nei suoi confronti, a seconda di come l'ha trattata.\n\n***Da Creatura a Oggetto.*** Se l'incantatore trasforma una creatura in un oggetto, la creatura si trasforma in quella forma insieme a tutto ciò che indossa e trasporta. Le statistiche della creatura diventano quelle dell'oggetto e, dopo che l'incantesimo termina e torna alla sua forma normale, la creatura non ricorda nulla del tempo trascorso in quella forma.",
					HigherLevels = null
				}
			}
		};
	}
}
