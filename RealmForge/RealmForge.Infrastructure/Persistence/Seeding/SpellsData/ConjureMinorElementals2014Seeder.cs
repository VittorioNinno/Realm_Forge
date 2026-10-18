using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Minor Elementals (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConjureMinorElementals2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-minor-elementals");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-minor-elementals", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Minor Elementals",
					CastingTime = "1 minute",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You summon elementals that appear in unoccupied spaces that you can see within range. You choose one the following options for what appears:\n\n- One elemental of challenge rating 2 or lower\n\n- Two elementals of challenge rating 1 or lower\n\n- Four elementals of challenge rating 1/2 or lower\n\n- Eight elementals of challenge rating 1/4 or lower.\n\nAn elemental summoned by this spell disappears when it drops to 0 hit points or when the spell ends.\n\nThe summoned creatures are friendly to you and your companions. Roll initiative for the summoned creatures as a group, which has its own turns. They obey any verbal commands that you issue to them (no action required by you). If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.\n\nThe GM has the creatures' statistics.",
					HigherLevels = "When you cast this spell using certain higher-level spell slots, you choose one of the summoning options above, and more creatures appear: twice as many with a 6th-level slot and three times as many with an 8th-level slot."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-minor-elementals", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Elementali Minori",
					CastingTime = "1 minuto",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore evoca degli elementali che compaiono in spazi liberi entro gittata che egli sia in grado di vedere. Sceglie una delle opzioni seguenti per determinare cosa compare:\n\n- Un elementale con grado di sfida pari o inferiore a 2\n\n- Due elementali con grado di sfida pari o inferiore a 1\n\n- Quattro elementali con grado di sfida pari o inferiore a 1/2\n\n- Otto elementali con grado di sfida pari o inferiore a 1/4\n\nUn elementale evocato con questo incantesimo scompare quando scende a 0 punti ferita o quando l'incantesimo termina.\n\nLe creature evocate sono amichevoli nei confronti dell'incantatore e dei suoi compagni. Si tira l'iniziativa per le creature evocate come gruppo, che agisce nei propri turni. Le creature obbediscono a qualsiasi comando verbale impartito dall'incantatore (non è richiesta alcuna azione da parte sua). Se l'incantatore non impartisce loro alcun comando, si difendono dalle creature ostili, ma per il resto non compiono alcuna azione.\n\nIl DM possiede le statistiche delle creature.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando slot incantesimo di determinati livelli superiori, sceglie una delle opzioni di evocazione sopra indicate e compaiono più creature: il doppio con uno slot di 6° livello e il triplo con uno slot di 8° livello."
				}
			}
		};
	}
}
