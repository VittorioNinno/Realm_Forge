using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Knock (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Knock2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "knock");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "knock", "en"),
					Language = LanguageCode.En,
					Name = "Knock",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Choose an object that you can see within range. The object can be a door, a box, a chest, a set of manacles, a padlock, or another object that contains a mundane or magical means that prevents access.\n\nA target that is held shut by a mundane lock or that is stuck or barred becomes unlocked, unstuck, or unbarred. If the object has multiple locks, only one of them is unlocked.\n\nIf you choose a target that is held shut with arcane lock, that spell is suppressed for 10 minutes, during which time the target can be opened and shut normally.\n\nWhen you cast the spell, a loud knock, audible from as far away as 300 feet, emanates from the target object.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "knock", "it"),
					Language = LanguageCode.It,
					Name = "Scassinare",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore sceglie un oggetto entro gittata che sia in grado di vedere. L'oggetto può essere una porta, una scatola, uno scrigno, un paio di manette, un lucchetto o un altro oggetto dotato di un mezzo comune o magico che ne impedisce l'accesso.\n\nUn bersaglio tenuto chiuso da una serratura comune, oppure incastrato o sbarrato, viene aperto, sbloccato o liberato dalla sbarra. Se l'oggetto ha più serrature, solo una di esse viene aperta.\n\nSe l'incantatore sceglie un bersaglio tenuto chiuso da serratura arcana, quell'incantesimo viene soppresso per 10 minuti, durante i quali il bersaglio può essere aperto e chiuso normalmente.\n\nQuando l'incantatore lancia l'incantesimo, dall'oggetto bersaglio proviene un colpo sonoro, udibile fino a 90 metri di distanza.",
					HigherLevels = null
				}
			}
		};
	}
}
