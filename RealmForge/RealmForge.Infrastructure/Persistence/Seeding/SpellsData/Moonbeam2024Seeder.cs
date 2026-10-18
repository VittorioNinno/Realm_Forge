using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Moonbeam (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Moonbeam2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "moonbeam");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "moonbeam", "en"),
					Language = LanguageCode.En,
					Name = "Moonbeam",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a moonseed leaf",
					Description = "A silvery beam of pale light shines down in a 5-foot-radius, 40-foot-high Cylinder centered on a point within range. Until the spell ends, Dim Light fills the Cylinder, and you can take a Magic action on later turns to move the Cylinder up to 60 feet.\n\nWhen the Cylinder appears, each creature in it makes a Constitution saving throw. On a failed save, a creature takes 2d10 Radiant damage, and if the creature is shape-shifted (as a result of the *Polymorph* spell, for example), it reverts to its true form and can't shape-shift until it leaves the Cylinder. On a successful save, a creature takes half as much damage only. A creature also makes this save when the spell's area moves into its space and when it enters the spell's area or ends its turn there. A creature makes this save only once per turn.",
					HigherLevels = "The damage increases by 1d10 for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "moonbeam", "it"),
					Language = LanguageCode.It,
					Name = "Bagliore Lunare",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una foglia di menisperma",
					Description = "Un raggio argenteo di luce pallida risplende in un cilindro del raggio di 1,5 metri e alto 12 metri, centrato su un punto entro gittata. Finché l'incantesimo non termina, il cilindro è pervaso di luce fioca e, nei turni successivi, l'incantatore può effettuare un'azione di Magia per spostare il cilindro fino a 18 metri.\n\nQuando il cilindro compare, ogni creatura al suo interno effettua un tiro salvezza su Costituzione. Se lo fallisce, una creatura subisce 2d10 danni radiosi e, se ha cambiato forma (per esempio a causa dell'incantesimo *metamorfosi*), torna alla sua vera forma e non può cambiare forma finché non esce dal cilindro. Se lo supera, una creatura subisce soltanto la metà dei danni. Una creatura effettua questo tiro salvezza anche quando l'area dell'incantesimo si sposta nel suo spazio e quando entra nell'area dell'incantesimo o vi termina il proprio turno. Una creatura effettua questo tiro salvezza soltanto una volta per turno.",
					HigherLevels = "I danni aumentano di 1d10 per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
