using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Levitate (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Levitate2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "levitate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "levitate", "en"),
					Language = LanguageCode.En,
					Name = "Levitate",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "either a small leather loop or a piece of golden wire bent into a cup shape with a long shank on one end",
					Description = "One creature or object of your choice that you can see within range rises vertically, up to 20 feet, and remains suspended there for the duration. The spell can levitate a target that weighs up to 500 pounds. An unwilling creature that succeeds on a Constitution saving throw is unaffected.\n\nThe target can move only by pushing or pulling against a fixed object or surface within reach (such as a wall or a ceiling), which allows it to move as if it were climbing. You can change the target's altitude by up to 20 feet in either direction on your turn. If you are the target, you can move up or down as part of your move. Otherwise, you can use your action to move the target, which must remain within the spell's range.\n\nWhen the spell ends, the target floats gently to the ground if it is still aloft.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "levitate", "it"),
					Language = LanguageCode.It,
					Name = "Levitazione",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un piccolo cappio di cuoio o un pezzo di filo d'oro piegato a forma di coppa con un lungo gambo a un'estremità",
					Description = "Una creatura o un oggetto a scelta dell'incantatore entro gittata, che egli sia in grado di vedere, si solleva verticalmente fino a un massimo di 6 metri e rimane sospeso a mezz'aria per la durata. L'incantesimo può far levitare un bersaglio che pesa fino a 250 kg. Una creatura non consenziente che supera un tiro salvezza su Costituzione non è influenzata.\n\nIl bersaglio può muoversi soltanto spingendo o tirando contro un oggetto fisso o una superficie a portata (come un muro o un soffitto), il che gli permette di muoversi come se stesse scalando. Nel suo turno, l'incantatore può modificare l'altitudine del bersaglio di un massimo di 6 metri in entrambe le direzioni. Se il bersaglio è l'incantatore stesso, può salire o scendere come parte del suo movimento. Altrimenti, può usare la sua azione per spostare il bersaglio, che deve restare entro la gittata dell'incantesimo.\n\nQuando l'incantesimo termina, se il bersaglio si trova ancora sospeso in aria, scende dolcemente fino al terreno.",
					HigherLevels = null
				}
			}
		};
	}
}
