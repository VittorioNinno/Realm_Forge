using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Simulacrum (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Simulacrum2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "simulacrum");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "simulacrum", "en"),
					Language = LanguageCode.En,
					Name = "Simulacrum",
					CastingTime = "12 hours",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "powdered ruby worth 1,500+ GP, which the spell consumes",
					Description = "You create a simulacrum of one Beast or Humanoid that is within 10 feet of you for the entire casting of the spell. You finish the casting by touching both the creature and a pile of ice or snow that is the same size as that creature, and the pile turns into the simulacrum, which is a creature. It uses the game statistics of the original creature at the time of casting, except it is a Construct, its Hit Point maximum is half as much, and it can't cast this spell.\n\nThe simulacrum is Friendly to you and creatures you designate. It obeys your commands and acts on your turn in combat. The simulacrum can't gain levels, and it can't take Short or Long Rests.\n\nIf the simulacrum takes damage, the only way to restore its Hit Points is to repair it as you take a Long Rest, during which you expend components worth 100 GP per Hit Point restored. The simulacrum must stay within 5 feet of you for the repair.\n\nThe simulacrum lasts until it drops to 0 Hit Points, at which point it reverts to snow and melts away. If you cast this spell again, any simulacrum you created with this spell is instantly destroyed.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "simulacrum", "it"),
					Language = LanguageCode.It,
					Name = "Simulacro",
					CastingTime = "12 ore",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "polvere di rubino del valore di almeno 1.500 mo, che l'incantesimo consuma",
					Description = "L'incantatore crea un simulacro di una bestia o di un umanoide che si trova entro 3 metri da lui per l'intera durata del lancio dell'incantesimo. Completa il lancio toccando sia la creatura sia un mucchio di ghiaccio o neve delle stesse dimensioni della creatura, e il mucchio si trasforma nel simulacro, che è una creatura. Il simulacro usa le statistiche di gioco della creatura originale al momento del lancio, tranne per il fatto che è un costrutto, il suo massimo dei punti ferita è dimezzato e non può lanciare questo incantesimo.\n\nIl simulacro è amichevole nei confronti dell'incantatore e delle creature da lui designate. Obbedisce ai suoi comandi e agisce nel suo turno durante il combattimento. Il simulacro non può salire di livello e non può effettuare riposi brevi o lunghi.\n\nSe il simulacro subisce danni, l'unico modo per ripristinarne i punti ferita è ripararlo mentre l'incantatore effettua un riposo lungo, durante il quale spende componenti del valore di 100 mo per ogni punto ferita ripristinato. Per la riparazione, il simulacro deve restare entro 1,5 metri dall'incantatore.\n\nIl simulacro permane finché non scende a 0 punti ferita; a quel punto torna a essere neve e si scioglie. Se l'incantatore lancia di nuovo questo incantesimo, qualsiasi simulacro creato con questo incantesimo viene distrutto all'istante.",
					HigherLevels = null
				}
			}
		};
	}
}
