using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Call Lightning (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CallLightning2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "call-lightning");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "call-lightning", "en"),
					Language = LanguageCode.En,
					Name = "Call Lightning",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "A storm cloud appears in the shape of a cylinder that is 10 feet tall with a 60-foot radius, centered on a point you can see 100 feet directly above you. The spell fails if you can't see a point in the air where the storm cloud could appear (for example, if you are in a room that can't accommodate the cloud).\n\nWhen you cast the spell, choose a point you can see within range. A bolt of lightning flashes down from the cloud to that point. Each creature within 5 feet of that point must make a Dexterity saving throw. A creature takes 3d10 lightning damage on a failed save, or half as much damage on a successful one. On each of your turns until the spell ends, you can use your action to call down lightning in this way again, targeting the same point or a different one.\n\nIf you are outdoors in stormy conditions when you cast this spell, the spell gives you control over the existing storm instead of creating a new one. Under such conditions, the spell's damage increases by 1d10.",
					HigherLevels = "When you cast this spell using a spell slot of 4th or higher level, the damage increases by 1d10 for each slot level above 3rd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "call-lightning", "it"),
					Language = LanguageCode.It,
					Name = "Invocare il Fulmine",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "Compare una nube temporalesca a forma di cilindro alto 3 metri e con un raggio di 18 metri, centrata su un punto visibile all'incantatore situato 30 metri direttamente sopra di lui. L'incantesimo fallisce se l'incantatore non è in grado di vedere un punto in aria in cui la nube possa comparire (per esempio, se si trova in una stanza che non può contenerla).\n\nQuando lancia l'incantesimo, l'incantatore sceglie un punto entro gittata che sia in grado di vedere. Un fulmine si abbatte dalla nube su quel punto. Ogni creatura entro 1,5 metri da quel punto deve effettuare un tiro salvezza su Destrezza. Una creatura subisce 3d10 danni da fulmine se fallisce il tiro salvezza, o la metà di quei danni se lo supera. In ognuno dei suoi turni, finché l'incantesimo non termina, l'incantatore può usare la sua azione per richiamare di nuovo un fulmine in questo modo, bersagliando lo stesso punto o un punto diverso.\n\nSe l'incantatore si trova all'aperto durante una tempesta quando lancia questo incantesimo, l'incantesimo gli conferisce il controllo della tempesta esistente invece di crearne una nuova. In queste condizioni, i danni dell'incantesimo aumentano di 1d10.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, i danni aumentano di 1d10 per ogni livello dello slot superiore al 3°."
				}
			}
		};
	}
}
