using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Call Lightning (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CallLightning2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "call-lightning");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "call-lightning", "en"),
					Language = LanguageCode.En,
					Name = "Call Lightning",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "A storm cloud appears at a point within range that you can see above yourself. It takes the shape of a Cylinder that is 10 feet tall with a 60-foot radius.\n\nWhen you cast the spell, choose a point you can see under the cloud. A lightning bolt shoots from the cloud to that point. Each creature within 5 feet of that point makes a Dexterity saving throw, taking 3d10 Lightning damage on a failed save or half as much damage on a successful one.\n\nUntil the spell ends, you can take a Magic action to call down lightning in that way again, targeting the same point or a different one.\n\nIf you're outdoors in a storm when you cast this spell, the spell gives you control over that storm instead of creating a new one. Under such conditions, the spell's damage increases by 1d10.",
					HigherLevels = "The damage increases by 1d10 for each spell slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "call-lightning", "it"),
					Language = LanguageCode.It,
					Name = "Invocare il Fulmine",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "Una nube temporalesca compare in un punto entro gittata sopra l'incantatore, che è in grado di vedere. La nube assume la forma di un cilindro alto 3 metri con un raggio di 18 metri.\n\nQuando lancia l'incantesimo, l'incantatore sceglie un punto sotto la nube che è in grado di vedere. Un fulmine scaturisce dalla nube e colpisce quel punto. Ogni creatura entro 1,5 metri da quel punto effettua un tiro salvezza su Destrezza, subendo 3d10 danni da fulmine se lo fallisce, o la metà di quei danni se lo supera.\n\nFinché l'incantesimo non termina, l'incantatore può effettuare un'azione di Magia per richiamare di nuovo un fulmine in quel modo, scegliendo come bersaglio lo stesso punto o un punto diverso.\n\nSe l'incantatore si trova all'aperto durante una tempesta quando lancia questo incantesimo, l'incantesimo gli conferisce il controllo di quella tempesta invece di crearne una nuova. In tali condizioni, i danni dell'incantesimo aumentano di 1d10.",
					HigherLevels = "I danni aumentano di 1d10 per ogni livello dello slot incantesimo superiore al 3°."
				}
			}
		};
	}
}
