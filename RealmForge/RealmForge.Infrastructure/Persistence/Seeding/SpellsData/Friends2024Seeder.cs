using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Friends (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class Friends2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "friends");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 0,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = false,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "friends", "en"),
					Language = LanguageCode.En,
					Name = "Friends",
					CastingTime = "Action",
					Range = "10 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a dab of cosmetics",
					Description = "You nudge the feelings of a creature you can see within range so that it warms to you. Unless it passes a Wisdom saving throw, it is Charmed for the duration. The save is an automatic success if the creature isn't a Humanoid, if the two of you are in a fight, or if it has already been targeted by this spell of yours within the past 24 hours.\n\nThe charm breaks early if the creature is damaged, or if you deal damage, make an attack roll, or force anyone to make a saving throw. Once the spell ends, the creature realizes that you charmed it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "friends", "it"),
					Language = LanguageCode.It,
					Name = "Amicizia",
					CastingTime = "Azione",
					Range = "3 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un tocco di cosmetici",
					Description = "L'incantatore influenza i sentimenti di una creatura entro gittata che è in grado di vedere, rendendola ben disposta nei suoi confronti. A meno che non superi un tiro salvezza su Saggezza, la creatura è affascinata per la durata. Il tiro salvezza riesce automaticamente se la creatura non è un umanoide, se lei e l'incantatore stanno combattendo o se nelle ultime 24 ore l'incantatore l'ha già presa di mira con questo incantesimo.\n\nL'affascinamento si spezza prima del tempo se la creatura subisce danni, oppure se l'incantatore infligge danni, effettua un tiro per colpire o costringe qualcuno a un tiro salvezza. Una volta terminato l'incantesimo, la creatura si rende conto di essere stata affascinata dall'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
