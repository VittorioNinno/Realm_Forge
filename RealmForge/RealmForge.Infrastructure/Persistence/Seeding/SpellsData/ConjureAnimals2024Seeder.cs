using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Animals (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConjureAnimals2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-animals");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-animals", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Animals",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You conjure nature spirits that appear as a Large pack of spectral, intangible animals in an unoccupied space you can see within range. The pack lasts for the duration, and you choose the spirits' animal form, such as wolves, serpents, or birds.\n\nYou have Advantage on Strength saving throws while you're within 5 feet of the pack, and when you move on your turn, you can also move the pack up to 30 feet to an unoccupied space you can see.\n\nWhenever the pack moves within 10 feet of a creature you can see and whenever a creature you can see enters a space within 10 feet of the pack or ends its turn there, you can force that creature to make a Dexterity saving throw. On a failed save, the creature takes 3d10 Slashing damage. A creature makes this save only once per turn.",
					HigherLevels = "The damage increases by 1d10 for each spell slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-animals", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Animali",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore evoca spiriti della natura che appaiono come un branco Grande di animali spettrali e intangibili in uno spazio libero entro gittata che è in grado di vedere. Il branco permane per la durata e l'incantatore sceglie la forma animale degli spiriti, per esempio lupi, serpenti o uccelli.\n\nL'incantatore dispone di vantaggio ai tiri salvezza su Forza finché si trova entro 1,5 metri dal branco e, quando si muove nel proprio turno, può anche spostare il branco fino a 9 metri in uno spazio libero che è in grado di vedere.\n\nOgni volta che il branco si muove entro 3 metri da una creatura che l'incantatore è in grado di vedere, e ogni volta che una creatura che l'incantatore è in grado di vedere entra in uno spazio entro 3 metri dal branco o vi termina il proprio turno, l'incantatore può costringere quella creatura a effettuare un tiro salvezza su Destrezza. Se lo fallisce, la creatura subisce 3d10 danni taglienti. Una creatura effettua questo tiro salvezza soltanto una volta per turno.",
					HigherLevels = "I danni aumentano di 1d10 per ogni livello dello slot incantesimo superiore al 3°."
				}
			}
		};
	}
}
