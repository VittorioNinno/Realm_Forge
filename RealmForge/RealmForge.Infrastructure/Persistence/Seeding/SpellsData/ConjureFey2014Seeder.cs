using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Fey (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConjureFey2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-fey");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-fey", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Fey",
					CastingTime = "1 minute",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You summon a fey creature of challenge rating 6 or lower, or a fey spirit that takes the form of a beast of challenge rating 6 or lower. It appears in an unoccupied space that you can see within range. The fey creature disappears when it drops to 0 hit points or when the spell ends.\n\nThe fey creature is friendly to you and your companions for the duration. Roll initiative for the creature, which has its own turns. It obeys any verbal commands that you issue to it (no action required by you), as long as they don't violate its alignment. If you don't issue any commands to the fey creature, it defends itself from hostile creatures but otherwise takes no actions.\n\nIf your concentration is broken, the fey creature doesn't disappear. Instead, you lose control of the fey creature, it becomes hostile toward you and your companions, and it might attack. An uncontrolled fey creature can't be dismissed by you, and it disappears 1 hour after you summoned it.\n\nThe GM has the fey creature's statistics.",
					HigherLevels = "When you cast this spell using a spell slot of 7th level or higher, the challenge rating increases by 1 for each slot level above 6th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-fey", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Folletto",
					CastingTime = "1 minuto",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore evoca una creatura folletto con grado di sfida pari o inferiore a 6, oppure uno spirito folletto che assume la forma di una bestia con grado di sfida pari o inferiore a 6. La creatura compare in uno spazio libero entro gittata che l'incantatore sia in grado di vedere, e scompare quando scende a 0 punti ferita o quando l'incantesimo termina.\n\nIl folletto è amichevole nei confronti dell'incantatore e dei suoi compagni per la durata. Si tira l'iniziativa per la creatura, che agisce nei propri turni. Obbedisce a qualsiasi comando verbale impartito dall'incantatore (non è richiesta alcuna azione da parte sua), purché non vada contro il suo allineamento. Se l'incantatore non gli impartisce alcun comando, il folletto si difende dalle creature ostili, ma per il resto non compie alcuna azione.\n\nSe la concentrazione dell'incantatore si interrompe, il folletto non scompare. L'incantatore perde invece il controllo del folletto, che diventa ostile nei confronti suoi e dei suoi compagni e potrebbe attaccarli. Un folletto fuori controllo non può essere congedato dall'incantatore e scompare 1 ora dopo essere stato evocato.\n\nIl DM possiede le statistiche del folletto.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 7° livello o superiore, il grado di sfida aumenta di 1 per ogni livello dello slot superiore al 6°."
				}
			}
		};
	}
}
