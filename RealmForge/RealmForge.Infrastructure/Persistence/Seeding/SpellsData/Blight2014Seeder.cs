using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blight (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Blight2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blight");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blight", "en"),
					Language = LanguageCode.En,
					Name = "Blight",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Necromantic energy washes over a creature of your choice that you can see within range, draining moisture and vitality from it. The target must make a Constitution saving throw. The target takes 8d8 necrotic damage on a failed save, or half as much damage on a successful one. The spell has no effect on undead or constructs.\n\nIf you target a plant creature or a magical plant, it makes the saving throw with disadvantage, and the spell deals maximum damage to it.\n\nIf you target a nonmagical plant that isn't a creature, such as a tree or shrub, it doesn't make a saving throw; it simply withers and dies.",
					HigherLevels = "When you cast this spell using a spell slot of 5th level of higher, the damage increases by 1d8 for each slot level above 4th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "blight", "it"),
					Language = LanguageCode.It,
					Name = "Inaridire",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Un'ondata di energia necromantica investe una creatura a scelta dell'incantatore entro gittata, che egli sia in grado di vedere, prosciugandone l'umidità e la vitalità. Il bersaglio deve effettuare un tiro salvezza su Costituzione. Se lo fallisce, subisce 8d8 danni necrotici; se lo supera, subisce la metà di quei danni. L'incantesimo non ha alcun effetto sui non morti e sui costrutti.\n\nSe il bersaglio è una creatura vegetale o un vegetale magico, effettua il tiro salvezza con svantaggio e l'incantesimo gli infligge il massimo dei danni.\n\nSe il bersaglio è un vegetale non magico che non è una creatura, come un albero o un arbusto, non effettua alcun tiro salvezza: semplicemente avvizzisce e muore.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 5° livello o superiore, i danni aumentano di 1d8 per ogni livello dello slot superiore al 4°."
				}
			}
		};
	}
}
