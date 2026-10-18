using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Animals (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConjureAnimals2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-animals");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-animals", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Animals",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You summon fey spirits that take the form of beasts and appear in unoccupied spaces that you can see within range. Choose one of the following options for what appears:\n\n- One beast of challenge rating 2 or lower\n\n- Two beasts of challenge rating 1 or lower\n\n- Four beasts of challenge rating 1/2 or lower\n\n- Eight beasts of challenge rating 1/4 or lower\n\nEach beast is also considered fey, and it disappears when it drops to 0 hit points or when the spell ends.\n\nThe summoned creatures are friendly to you and your companions. Roll initiative for the summoned creatures as a group, which has its own turns. They obey any verbal commands that you issue to them (no action required by you). If you don't issue any commands to them, they defend themselves from hostile creatures, but otherwise take no actions.\n\nThe GM has the creatures' statistics.",
					HigherLevels = "When you cast this spell using certain higher-level spell slots, you choose one of the summoning options above, and more creatures appear: twice as many with a 5th-level slot, three times as many with a 7th-level."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-animals", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Animali",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore evoca degli spiriti folletti che assumono la forma di bestie e compaiono in spazi liberi entro gittata che egli sia in grado di vedere. Sceglie una delle opzioni seguenti per determinare cosa compare:\n\n- Una bestia con grado di sfida pari o inferiore a 2\n\n- Due bestie con grado di sfida pari o inferiore a 1\n\n- Quattro bestie con grado di sfida pari o inferiore a 1/2\n\n- Otto bestie con grado di sfida pari o inferiore a 1/4\n\nOgni bestia è considerata anche un folletto e scompare quando scende a 0 punti ferita o quando l'incantesimo termina.\n\nLe creature evocate sono amichevoli nei confronti dell'incantatore e dei suoi compagni. Si tira l'iniziativa per le creature evocate come gruppo, che agisce nei propri turni. Le creature obbediscono a qualsiasi comando verbale impartito dall'incantatore (non è richiesta alcuna azione da parte sua). Se l'incantatore non impartisce loro alcun comando, si difendono dalle creature ostili, ma per il resto non compiono alcuna azione.\n\nIl DM possiede le statistiche delle creature.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando slot incantesimo di determinati livelli superiori, sceglie una delle opzioni di evocazione sopra indicate e compaiono più creature: il doppio con uno slot di 5° livello, il triplo con uno slot di 7° livello."
				}
			}
		};
	}
}
