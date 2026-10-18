using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Celestial (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConjureCelestial2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-celestial");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-celestial", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Celestial",
					CastingTime = "1 minute",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You summon a celestial of challenge rating 4 or lower, which appears in an unoccupied space that you can see within range. The celestial disappears when it drops to 0 hit points or when the spell ends.\n\nThe celestial is friendly to you and your companions for the duration. Roll initiative for the celestial, which has its own turns. It obeys any verbal commands that you issue to it (no action required by you), as long as they don't violate its alignment. If you don't issue any commands to the celestial, it defends itself from hostile creatures but otherwise takes no actions.\n\nThe GM has the celestial's statistics.",
					HigherLevels = "When you cast this spell using a 9th-level spell slot, you summon a celestial of challenge rating 5 or lower."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-celestial", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Celestiale",
					CastingTime = "1 minuto",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore evoca un celestiale con grado di sfida pari o inferiore a 4, che compare in uno spazio libero entro gittata che egli sia in grado di vedere. Il celestiale scompare quando scende a 0 punti ferita o quando l'incantesimo termina.\n\nIl celestiale è amichevole nei confronti dell'incantatore e dei suoi compagni per la durata. Si tira l'iniziativa per il celestiale, che agisce nei propri turni. Obbedisce a qualsiasi comando verbale impartito dall'incantatore (non è richiesta alcuna azione da parte sua), purché non vada contro il suo allineamento. Se l'incantatore non gli impartisce alcun comando, il celestiale si difende dalle creature ostili, ma per il resto non compie alcuna azione.\n\nIl DM possiede le statistiche del celestiale.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 9° livello, evoca un celestiale con grado di sfida pari o inferiore a 5."
				}
			}
		};
	}
}
