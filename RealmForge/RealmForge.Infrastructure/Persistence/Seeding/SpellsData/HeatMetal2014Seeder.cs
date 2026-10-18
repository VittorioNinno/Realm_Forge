using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Heat Metal (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HeatMetal2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "heat-metal");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "heat-metal", "en"),
					Language = LanguageCode.En,
					Name = "Heat Metal",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a piece of iron and a flame",
					Description = "Choose a manufactured metal object, such as a metal weapon or a suit of heavy or medium metal armor, that you can see within range. You cause the object to glow red-hot. Any creature in physical contact with the object takes 2d8 fire damage when you cast the spell. Until the spell ends, you can use a bonus action on each of your subsequent turns to cause this damage again.\n\nIf a creature is holding or wearing the object and takes the damage from it, the creature must succeed on a Constitution saving throw or drop the object if it can. If it doesn't drop the object, it has disadvantage on attack rolls and ability checks until the start of your next turn.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, the damage increases by 1d8 for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "heat-metal", "it"),
					Language = LanguageCode.It,
					Name = "Riscaldare il Metallo",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pezzo di ferro e una fiamma",
					Description = "L'incantatore sceglie un oggetto di metallo lavorato entro gittata che sia in grado di vedere, come un'arma di metallo o un'armatura pesante o media di metallo, e lo rende rovente. Qualsiasi creatura a contatto fisico con l'oggetto subisce 2d8 danni da fuoco quando l'incantatore lancia l'incantesimo. Finché l'incantesimo non termina, in ognuno dei suoi turni successivi l'incantatore può usare un'azione bonus per infliggere di nuovo questi danni.\n\nSe una creatura impugna o indossa l'oggetto e ne subisce i danni, deve superare un tiro salvezza su Costituzione, altrimenti lascia cadere l'oggetto, se può farlo. Se non lascia cadere l'oggetto, subisce svantaggio ai tiri per colpire e alle prove di caratteristica fino all'inizio del turno successivo dell'incantatore.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, i danni aumentano di 1d8 per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
