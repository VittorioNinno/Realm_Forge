using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hold Monster (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HoldMonster2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hold-monster");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hold-monster", "en"),
					Language = LanguageCode.En,
					Name = "Hold Monster",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a straight piece of iron",
					Description = "Choose a creature that you can see within range. The target must succeed on a Wisdom saving throw or have the Paralyzed condition for the duration. At the end of each of its turns, the target repeats the save, ending the spell on itself on a success.",
					HigherLevels = "You can target one additional creature for each spell slot level above 5."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hold-monster", "it"),
					Language = LanguageCode.It,
					Name = "Blocca Mostri",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pezzo di ferro dritto",
					Description = "L'incantatore sceglie una creatura entro gittata che è in grado di vedere. Il bersaglio deve superare un tiro salvezza su Saggezza, altrimenti è paralizzato per la durata. Alla fine di ogni suo turno, il bersaglio ripete il tiro salvezza e, se lo supera, l'incantesimo termina su di lui.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 5°."
				}
			}
		};
	}
}
