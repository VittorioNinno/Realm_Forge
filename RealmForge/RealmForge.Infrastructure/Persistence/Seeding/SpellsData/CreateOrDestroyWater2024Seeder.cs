using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Create or Destroy Water (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CreateOrDestroyWater2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "create-or-destroy-water");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "create-or-destroy-water", "en"),
					Language = LanguageCode.En,
					Name = "Create or Destroy Water",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a mix of water and sand",
					Description = "You do one of the following:\n\n**Create Water.** You create up to 10 gallons of clean water within range in an open container. Alternatively, the water falls as rain in a 30-foot Cube within range, extinguishing exposed flames there.\n\n**Destroy Water.** You destroy up to 10 gallons of water in an open container within range. Alternatively, you destroy fog in a 30-foot Cube within range.",
					HigherLevels = "You create or destroy 10 additional gallons of water, or the size of the Cube increases by 5 feet, for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "create-or-destroy-water", "it"),
					Language = LanguageCode.It,
					Name = "Creare o Distruggere Acqua",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = "un miscuglio di acqua e sabbia",
					Description = "L'incantatore produce uno degli effetti seguenti:\n\n**Creare Acqua.** L'incantatore crea fino a 40 litri di acqua pulita entro gittata in un contenitore aperto. In alternativa, l'acqua cade come pioggia in un cubo con spigolo di 9 metri entro gittata, spegnendo le fiamme esposte al suo interno.\n\n**Distruggere Acqua.** L'incantatore distrugge fino a 40 litri di acqua in un contenitore aperto entro gittata. In alternativa, distrugge la nebbia in un cubo con spigolo di 9 metri entro gittata.",
					HigherLevels = "L'incantatore crea o distrugge altri 40 litri di acqua, oppure lo spigolo del cubo aumenta di 1,5 metri, per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
