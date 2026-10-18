using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Charm Monster (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CharmMonster2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "charm-monster");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "charm-monster", "en"),
					Language = LanguageCode.En,
					Name = "Charm Monster",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "One creature you can see within range makes a Wisdom saving throw. It does so with Advantage if you or your allies are fighting it. On a failed save, the target has the Charmed condition until the spell ends or until you or your allies damage it. The Charmed creature is Friendly to you. When the spell ends, the target knows it was Charmed by you.",
					HigherLevels = "You can target one additional creature for each spell slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "charm-monster", "it"),
					Language = LanguageCode.It,
					Name = "Charme sui Mostri",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "Una creatura entro gittata che l'incantatore è in grado di vedere effettua un tiro salvezza su Saggezza, con vantaggio se l'incantatore o i suoi alleati stanno combattendo contro di essa. Se lo fallisce, il bersaglio è affascinato finché l'incantesimo non termina o finché l'incantatore o i suoi alleati non gli infliggono danni. La creatura affascinata è amichevole nei confronti dell'incantatore. Quando l'incantesimo termina, il bersaglio sa di essere stato affascinato dall'incantatore.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 4°."
				}
			}
		};
	}
}
