using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sorcerous Burst (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SorcerousBurst2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sorcerous-burst");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sorcerous-burst", "en"),
					Language = LanguageCode.En,
					Name = "Sorcerous Burst",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You cast sorcerous energy at one creature or object within range. Make a ranged spell attack against the target. On a hit, the target takes 1d8 damage of a type you choose: Acid, Cold, Fire, Lightning, Poison, Psychic, or Thunder.\n\nIf you roll an 8 on a d8 for this spell, you can roll another d8, and add it to the damage. When you cast this spell, the maximum number of these d8s you can add to the spell's damage equals your spellcasting ability modifier.",
					HigherLevels = "The damage increases by 1d8 when you reach levels 5 (2d8), 11 (3d8), and 17 (4d8)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sorcerous-burst", "it"),
					Language = LanguageCode.It,
					Name = "Stregoneria Esplosiva",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore scaglia energia stregonesca contro una creatura o un oggetto entro gittata ed effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 1d8 danni di un tipo a scelta dell'incantatore: acido, freddo, fuoco, fulmine, psichici, tuono o veleno.\n\nSe l'incantatore ottiene un 8 su un d8 di questo incantesimo, può tirare un altro d8 e aggiungerlo ai danni. Quando lancia questo incantesimo, il numero massimo di questi d8 che può aggiungere ai danni dell'incantesimo è pari al suo modificatore di caratteristica da incantatore.",
					HigherLevels = "I danni aumentano di 1d8 quando l'incantatore raggiunge il 5° livello (2d8), l'11° livello (3d8) e il 17° livello (4d8)."
				}
			}
		};
	}
}
