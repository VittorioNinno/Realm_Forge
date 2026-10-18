using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Black Tentacles (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class BlackTentacles2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "black-tentacles");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "black-tentacles", "en"),
					Language = LanguageCode.En,
					Name = "Black Tentacles",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a tentacle",
					Description = "Squirming, ebony tentacles fill a 20-foot square on ground that you can see within range. For the duration, these tentacles turn the ground in that area into Difficult Terrain.\n\nEach creature in that area makes a Strength saving throw. On a failed save, it takes 3d6 Bludgeoning damage, and it has the Restrained condition until the spell ends. A creature also makes that save if it enters the area or ends it turn there. A creature makes that save only once per turn.\n\nA Restrained creature can take an action to make a Strength (Athletics) check against your spell save DC, ending the condition on itself on a success.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "black-tentacles", "it"),
					Language = LanguageCode.It,
					Name = "Tentacoli Neri",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un tentacolo",
					Description = "Tentacoli d'ebano che si contorcono riempiono un quadrato di 6 metri di lato sul terreno entro gittata che l'incantatore è in grado di vedere. Per la durata, questi tentacoli trasformano il terreno in quell'area in terreno difficile.\n\nOgni creatura in quell'area effettua un tiro salvezza su Forza. Se lo fallisce, subisce 3d6 danni contundenti ed è trattenuta finché l'incantesimo non termina. Una creatura effettua questo tiro salvezza anche se entra nell'area o vi termina il proprio turno. Una creatura effettua questo tiro salvezza soltanto una volta per turno.\n\nUna creatura trattenuta può effettuare un'azione per compiere una prova di Forza (Atletica) contro la CD del tiro salvezza degli incantesimi dell'incantatore e, se la supera, pone fine alla condizione su di sé.",
					HigherLevels = null
				}
			}
		};
	}
}
