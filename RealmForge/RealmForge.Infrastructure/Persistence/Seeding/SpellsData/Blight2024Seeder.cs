using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Blight (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Blight2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blight");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blight", "en"),
					Language = LanguageCode.En,
					Name = "Blight",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "A creature that you can see within range makes a Constitution saving throw, taking 8d8 Necrotic damage on a failed save or half as much damage on a successful one. A Plant creature automatically fails the save.\n\nAlternatively, target a nonmagical plant that isn't a creature, such as a tree or shrub. It doesn't make a save; it simply withers and dies.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "blight", "it"),
					Language = LanguageCode.It,
					Name = "Inaridire",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Una creatura entro gittata che l'incantatore è in grado di vedere effettua un tiro salvezza su Costituzione, subendo 8d8 danni necrotici se lo fallisce, o la metà di quei danni se lo supera. Una creatura vegetale fallisce automaticamente il tiro salvezza.\n\nIn alternativa, l'incantatore sceglie come bersaglio una pianta non magica che non sia una creatura, come un albero o un arbusto. Il bersaglio non effettua alcun tiro salvezza: semplicemente avvizzisce e muore.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 4°."
				}
			}
		};
	}
}
