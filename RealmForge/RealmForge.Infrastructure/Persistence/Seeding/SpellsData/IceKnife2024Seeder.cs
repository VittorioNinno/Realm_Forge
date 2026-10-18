using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Ice Knife (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class IceKnife2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ice-knife");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = false,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ice-knife", "en"),
					Language = LanguageCode.En,
					Name = "Ice Knife",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a drop of water or a piece of ice",
					Description = "You create a shard of ice and fling it at one creature within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 Piercing damage. Hit or miss, the shard then explodes. The target and each creature within 5 feet of it must succeed on a Dexterity saving throw or take 2d6 Cold damage.",
					HigherLevels = "The Cold damage increases by 1d6 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "ice-knife", "it"),
					Language = LanguageCode.It,
					Name = "Coltello di Ghiaccio",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = "una goccia d'acqua o un pezzetto di ghiaccio",
					Description = "L'incantatore crea una scheggia di ghiaccio e la scaglia contro una creatura entro gittata, effettuando un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 1d10 danni perforanti. Che colpisca o manchi, la scheggia poi esplode. Il bersaglio e ogni creatura entro 1,5 metri da esso devono superare un tiro salvezza su Destrezza, altrimenti subiscono 2d6 danni da freddo.",
					HigherLevels = "I danni da freddo aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
