using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Moonbeam (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Moonbeam2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "moonbeam");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "moonbeam", "en"),
					Language = LanguageCode.En,
					Name = "Moonbeam",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "several seeds of any moonseed plant and a piece of opalescent feldspar",
					Description = "A silvery beam of pale light shines down in a 5-foot radius, 40-foot-high cylinder centered on a point within range. Until the spell ends, dim light fills the cylinder.\n\nWhen a creature enters the spell's area for the first time on a turn or starts its turn there, it is engulfed in ghostly flames that cause searing pain, and it must make a Constitution saving throw. It takes 2d10 radiant damage on a failed save, or half as much damage on a successful one.\n\nA shapechanger makes its saving throw with disadvantage. If it fails, it also instantly reverts to its original form and can't assume a different form until it leaves the spell's light.\n\nOn each of your turns after you cast this spell, you can use an action to move the beam 60 feet in any direction.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, the damage increases by 1d10 for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "moonbeam", "it"),
					Language = LanguageCode.It,
					Name = "Bagliore Lunare",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "alcuni semi di una qualsiasi pianta di menisperma e un frammento di feldspato opalescente",
					Description = "Un raggio argenteo di luce pallida risplende verso il basso in un cilindro del raggio di 1,5 metri e alto 12 metri, centrato su un punto entro gittata. Finché l'incantesimo non termina, una luce fioca riempie il cilindro.\n\nQuando una creatura entra nell'area dell'incantesimo per la prima volta in un turno o vi inizia il proprio turno, viene avvolta da fiamme spettrali che provocano un dolore lancinante e deve effettuare un tiro salvezza su Costituzione. Subisce 2d10 danni radiosi se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\nUn mutaforma effettua il tiro salvezza con svantaggio. Se lo fallisce, inoltre, riprende istantaneamente la sua forma originale e non può assumere una forma diversa finché non esce dalla luce dell'incantesimo.\n\nIn ognuno dei suoi turni dopo aver lanciato questo incantesimo, l'incantatore può usare un'azione per spostare il raggio di 18 metri in qualsiasi direzione.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, i danni aumentano di 1d10 per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
