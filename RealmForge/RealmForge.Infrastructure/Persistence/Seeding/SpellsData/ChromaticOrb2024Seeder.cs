using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Chromatic Orb (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ChromaticOrb2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "chromatic-orb");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Evocation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "chromatic-orb", "en"),
					Language = LanguageCode.En,
					Name = "Chromatic Orb",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a diamond worth 50+ GP",
					Description = "You hurl an orb of energy at a target within range. Choose Acid, Cold, Fire, Lightning, Poison, or Thunder for the type of orb you create, and then make a ranged spell attack against the target. On a hit, the target takes 3d8 damage of the chosen type.\n\nIf you roll the same number on two or more of the d8s, the orb leaps to a different target of your choice within 30 feet of the target. Make an attack roll against the new target, and make a new damage roll. The orb can't leap again unless you cast the spell with a level 2+ spell slot.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 1. The orb can leap a maximum number of times equal to the level of the slot expended, and a creature can be targeted only once by each casting of this spell."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "chromatic-orb", "it"),
					Language = LanguageCode.It,
					Name = "Globo Cromatico",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Istantanea",
					MaterialComponent = "un diamante del valore di almeno 50 mo",
					Description = "L'incantatore scaglia un globo di energia contro un bersaglio entro gittata. Sceglie acido, freddo, fuoco, fulmine, tuono o veleno come tipo del globo creato, poi effettua un attacco con incantesimo a distanza contro il bersaglio. Se colpisce, il bersaglio subisce 3d8 danni del tipo scelto.\n\nSe l'incantatore ottiene lo stesso numero su due o più d8, il globo balza verso un bersaglio diverso a sua scelta entro 9 metri dal bersaglio. L'incantatore effettua un tiro per colpire contro il nuovo bersaglio ed effettua un nuovo tiro per i danni. Il globo non può balzare di nuovo, a meno che l'incantatore non lanci l'incantesimo usando uno slot incantesimo di 2° livello o superiore.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 1°. Il globo può balzare un numero massimo di volte pari al livello dello slot speso, e una creatura può essere presa come bersaglio una sola volta per ogni lancio di questo incantesimo."
				}
			}
		};
	}
}
