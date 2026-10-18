using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Create or Destroy Water (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CreateOrDestroyWater2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "create-or-destroy-water");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "create-or-destroy-water", "en"),
					Language = LanguageCode.En,
					Name = "Create or Destroy Water",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a drop of water if creating water, or a few grains of sand if destroying it",
					Description = "You either create or destroy water.\n\n***Create Water.*** You create up to 10 gallons of clean water within range in an open container. Alternatively, the water falls as rain in a 30-foot cube within range.\n\n***Destroy Water.*** You destroy up to 10 gallons of water in an open container within range. Alternatively, you destroy fog in a 30-foot cube within range.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, you create or destroy 10 additional gallons of water, or the size of the cube increases by 5 feet, for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "create-or-destroy-water", "it"),
					Language = LanguageCode.It,
					Name = "Creare o Distruggere Acqua",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = "una goccia d'acqua per creare l'acqua, oppure qualche granello di sabbia per distruggerla",
					Description = "L'incantatore crea o distrugge dell'acqua.\n\n***Creare Acqua.*** L'incantatore crea fino a 40 litri d'acqua pulita entro gittata, all'interno di un contenitore aperto. In alternativa, l'acqua cade come pioggia in un cubo con spigolo di 9 metri entro gittata.\n\n***Distruggere Acqua.*** L'incantatore distrugge fino a 40 litri d'acqua contenuti in un contenitore aperto entro gittata. In alternativa, dissolve la nebbia in un cubo con spigolo di 9 metri entro gittata.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, crea o distrugge 40 litri d'acqua aggiuntivi, oppure lo spigolo del cubo aumenta di 1,5 metri, per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
