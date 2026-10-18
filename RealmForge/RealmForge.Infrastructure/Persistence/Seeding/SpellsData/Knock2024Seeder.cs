using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Knock (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Knock2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "knock");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "knock", "en"),
					Language = LanguageCode.En,
					Name = "Knock",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Choose an object that you can see within range. The object can be a door, a box, a chest, a set of manacles, a padlock, or another object that contains a mundane or magical means that prevents access.\n\nA target that is held shut by a mundane lock or that is stuck or barred becomes unlocked, unstuck, or unbarred. If the object has multiple locks, only one of them is unlocked.\n\nIf the target is held shut by *Arcane Lock*, that spell is suppressed for 10 minutes, during which time the target can be opened and closed.\n\nWhen you cast the spell, a loud knock, audible up to 300 feet away, emanates from the target.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "knock", "it"),
					Language = LanguageCode.It,
					Name = "Scassinare",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore sceglie un oggetto entro gittata che è in grado di vedere. L'oggetto può essere una porta, una scatola, uno scrigno, un paio di manette, un lucchetto o un altro oggetto dotato di un mezzo comune o magico che ne impedisce l'accesso.\n\nUn bersaglio tenuto chiuso da una serratura comune, oppure incastrato o sbarrato, viene aperto, sbloccato o liberato dalla sbarra. Se l'oggetto ha più serrature, soltanto una di esse viene aperta.\n\nSe il bersaglio è tenuto chiuso da *serratura arcana*, quell'incantesimo viene soppresso per 10 minuti, durante i quali il bersaglio può essere aperto e chiuso.\n\nQuando l'incantatore lancia l'incantesimo, dal bersaglio proviene un colpo forte, udibile fino a 90 metri di distanza.",
					HigherLevels = null
				}
			}
		};
	}
}
