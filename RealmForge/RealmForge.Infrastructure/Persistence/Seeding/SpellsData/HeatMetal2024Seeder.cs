using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Heat Metal (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HeatMetal2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "heat-metal");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "heat-metal", "en"),
					Language = LanguageCode.En,
					Name = "Heat Metal",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a piece of iron and a flame",
					Description = "Choose a manufactured metal object, such as a metal weapon or a suit of Heavy or Medium metal armor, that you can see within range. You cause the object to glow red-hot. Any creature in physical contact with the object takes 2d8 Fire damage when you cast the spell. Until the spell ends, you can take a Bonus Action on each of your later turns to deal this damage again if the object is within range.\n\nIf a creature is holding or wearing the object and takes the damage from it, the creature must succeed on a Constitution saving throw or drop the object if it can. If it doesn't drop the object, it has Disadvantage on attack rolls and ability checks until the start of your next turn.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "heat-metal", "it"),
					Language = LanguageCode.It,
					Name = "Riscaldare il Metallo",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pezzo di ferro e una fiamma",
					Description = "L'incantatore sceglie un oggetto di metallo lavorato entro gittata che è in grado di vedere, come un'arma di metallo o un'armatura di metallo pesante o media. L'incantatore rende l'oggetto incandescente. Qualsiasi creatura a contatto fisico con l'oggetto subisce 2d8 danni da fuoco quando l'incantatore lancia l'incantesimo. Finché l'incantesimo non termina, l'incantatore può effettuare un'azione bonus in ognuno dei suoi turni successivi per infliggere di nuovo questi danni, se l'oggetto si trova entro gittata.\n\nSe una creatura impugna o indossa l'oggetto e subisce i danni da esso, deve superare un tiro salvezza su Costituzione, altrimenti lascia cadere l'oggetto, se può farlo. Se non lascia cadere l'oggetto, subisce svantaggio ai tiri per colpire e alle prove di caratteristica fino all'inizio del turno successivo dell'incantatore.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
