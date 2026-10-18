using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Disintegrate (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Disintegrate2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "disintegrate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "disintegrate", "en"),
					Language = LanguageCode.En,
					Name = "Disintegrate",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a lodestone and a pinch of dust",
					Description = "A thin green ray springs from your pointing finger to a target that you can see within range. The target can be a creature, an object, or a creation of magical force, such as the wall created by wall of force.\n\nA creature targeted by this spell must make a Dexterity saving throw. On a failed save, the target takes 10d6 + 40 force damage. If this damage reduces the target to 0 hit points, it is disintegrated.\n\nA disintegrated creature and everything it is wearing and carrying, except magic items, are reduced to a pile of fine gray dust. The creature can be restored to life only by means of a true resurrection or a wish spell.\n\nThis spell automatically disintegrates a Large or smaller nonmagical object or a creation of magical force. If the target is a Huge or larger object or creation of force, this spell disintegrates a 10-foot-cube portion of it. A magic item is unaffected by this spell.",
					HigherLevels = "When you cast this spell using a spell slot of 7th level or higher, the damage increases by 3d6 for each slot level above 6th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "disintegrate", "it"),
					Language = LanguageCode.It,
					Name = "Disintegrazione",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = "una calamita e un pizzico di polvere",
					Description = "Un sottile raggio verde scaturisce dal dito puntato dell'incantatore verso un bersaglio entro gittata che sia in grado di vedere. Il bersaglio può essere una creatura, un oggetto o una creazione di forza magica, come il muro creato da muro di forza.\n\nUna creatura bersagliata da questo incantesimo deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, subisce 10d6 + 40 danni da forza. Se questi danni riducono il bersaglio a 0 punti ferita, il bersaglio è disintegrato.\n\nUna creatura disintegrata e tutto ciò che indossa e trasporta, a eccezione degli oggetti magici, si riducono a un mucchietto di sottile polvere grigia. La creatura può essere riportata in vita soltanto tramite un incantesimo resurrezione pura o desiderio.\n\nQuesto incantesimo disintegra automaticamente un oggetto non magico di taglia Grande o inferiore, oppure una creazione di forza magica. Se il bersaglio è un oggetto o una creazione di forza di taglia Enorme o superiore, l'incantesimo ne disintegra una porzione pari a un cubo con spigolo di 3 metri. Un oggetto magico non è influenzato da questo incantesimo.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 7° livello o superiore, i danni aumentano di 3d6 per ogni livello dello slot superiore al 6°."
				}
			}
		};
	}
}
