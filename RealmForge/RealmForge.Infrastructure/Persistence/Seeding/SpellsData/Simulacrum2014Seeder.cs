using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Simulacrum (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Simulacrum2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "simulacrum");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "simulacrum", "en"),
					Language = LanguageCode.En,
					Name = "Simulacrum",
					CastingTime = "12 hours",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "snow or ice in quantities sufficient to make a life-size copy of the duplicated creature; some hair, fingernail clippings, or other piece of that creature's body placed inside the snow or ice; and powdered ruby worth 1,500 gp, sprinkled over the duplicate and consumed by the spell",
					Description = "You shape an illusory duplicate of one beast or humanoid that is within range for the entire casting time of the spell. The duplicate is a creature, partially real and formed from ice or snow, and it can take actions and otherwise be affected as a normal creature. It appears to be the same as the original, but it has half the creature's hit point maximum and is formed without any equipment. Otherwise, the illusion uses all the statistics of the creature it duplicates.\n\nThe simulacrum is friendly to you and creatures you designate. It obeys your spoken commands, moving and acting in accordance with your wishes and acting on your turn in combat. The simulacrum lacks the ability to learn or become more powerful, so it never increases its level or other abilities, nor can it regain expended spell slots.\n\nIf the simulacrum is damaged, you can repair it in an alchemical laboratory, using rare herbs and minerals worth 100 gp per hit point it regains. The simulacrum lasts until it drops to 0 hit points, at which point it reverts to snow and melts instantly.\n\nIf you cast this spell again, any currently active duplicates you created with this spell are instantly destroyed.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "simulacrum", "it"),
					Language = LanguageCode.It,
					Name = "Simulacro",
					CastingTime = "12 ore",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "neve o ghiaccio in quantità sufficiente a realizzare una copia a grandezza naturale della creatura duplicata; alcuni capelli, frammenti di unghie o un'altra parte del corpo di quella creatura posti all'interno della neve o del ghiaccio; e polvere di rubino del valore di 1.500 mo, cosparsa sul duplicato e consumata dall'incantesimo",
					Description = "L'incantatore plasma un duplicato illusorio di una bestia o di un umanoide che resta entro gittata per l'intero tempo di lancio dell'incantesimo. Il duplicato è una creatura, in parte reale e formata di ghiaccio o di neve, che può compiere azioni ed essere influenzata come una normale creatura. Sembra identico all'originale, ma ha la metà del massimo dei punti ferita della creatura e si forma privo di equipaggiamento. Per il resto, l'illusione usa tutte le statistiche della creatura che duplica.\n\nIl simulacro è amichevole nei confronti dell'incantatore e delle creature da lui designate. Obbedisce ai suoi comandi verbali, muovendosi e agendo secondo i suoi desideri e agendo nel turno dell'incantatore durante il combattimento. Il simulacro non ha la capacità di imparare o di diventare più potente, quindi non aumenta mai il proprio livello o le altre capacità, né può recuperare gli slot incantesimo spesi.\n\nSe il simulacro viene danneggiato, l'incantatore può ripararlo in un laboratorio alchemico, usando erbe e minerali rari del valore di 100 mo per ogni punto ferita recuperato. Il simulacro dura finché non scende a 0 punti ferita; a quel punto torna a essere neve e si scioglie istantaneamente.\n\nSe l'incantatore lancia di nuovo questo incantesimo, tutti i duplicati attivi creati con questo incantesimo vengono istantaneamente distrutti.",
					HigherLevels = null
				}
			}
		};
	}
}
