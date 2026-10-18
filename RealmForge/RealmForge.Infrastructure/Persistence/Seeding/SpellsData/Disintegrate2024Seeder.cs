using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Disintegrate (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Disintegrate2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "disintegrate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "disintegrate", "en"),
					Language = LanguageCode.En,
					Name = "Disintegrate",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a lodestone and dust",
					Description = "You launch a green ray at a target you can see within range. The target can be a creature, a nonmagical object, or a creation of magical force, such as the wall created by *Wall of Force*.\n\nA creature targeted by this spell makes a Dexterity saving throw. On a failed save, the target takes 10d6 + 40 Force damage. If this damage reduces it to 0 Hit Points, it and everything nonmagical it is wearing and carrying are disintegrated into gray dust. The target can be revived only by a *True Resurrection* or a *Wish* spell.\n\nThis spell automatically disintegrates a Large or smaller nonmagical object or a creation of magical force. If such a target is Huge or larger, this spell disintegrates a 10-foot-Cube portion of it.",
					HigherLevels = "The damage increases by 3d6 for each spell slot level above 6."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "disintegrate", "it"),
					Language = LanguageCode.It,
					Name = "Disintegrazione",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = "una calamita e un po' di polvere",
					Description = "L'incantatore scaglia un raggio verde contro un bersaglio entro gittata che è in grado di vedere. Il bersaglio può essere una creatura, un oggetto non magico o una creazione di forza magica, come il muro creato da *muro di forza*.\n\nUna creatura presa come bersaglio da questo incantesimo effettua un tiro salvezza su Destrezza. Se lo fallisce, il bersaglio subisce 10d6 + 40 danni da forza. Se questi danni lo riducono a 0 punti ferita, il bersaglio e tutti gli oggetti non magici che indossa e trasporta vengono disintegrati in polvere grigia. Il bersaglio può essere riportato in vita soltanto da un incantesimo *resurrezione pura* o *desiderio*.\n\nQuesto incantesimo disintegra automaticamente un oggetto non magico di taglia Grande o inferiore, o una creazione di forza magica. Se un tale bersaglio è di taglia Enorme o superiore, l'incantesimo ne disintegra una porzione pari a un cubo con spigolo di 3 metri.",
					HigherLevels = "I danni aumentano di 3d6 per ogni livello dello slot incantesimo superiore al 6°."
				}
			}
		};
	}
}
