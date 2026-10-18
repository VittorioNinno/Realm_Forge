using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Witch Bolt (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class WitchBolt2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "witch-bolt");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "witch-bolt", "en"),
					Language = LanguageCode.En,
					Name = "Witch Bolt",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a twig from a tree that has been struck by lightning",
					Description = "A beam of crackling blue energy leaps toward a creature within range and forms a lasting arc of lightning between you and it. Make a ranged spell attack against the creature. On a hit, it takes 1d12 lightning damage, and on each of your turns for the duration, you can use your action to deal 1d12 lightning damage to it automatically. The spell ends if you use your action for anything else, if the target is ever outside the spell's range, or if it has total cover from you.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the initial damage increases by 1d12 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "witch-bolt", "it"),
					Language = LanguageCode.It,
					Name = "Dardo Stregato",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un ramoscello di un albero colpito da un fulmine",
					Description = "Un raggio di energia azzurra e crepitante balza verso una creatura entro gittata e forma un arco elettrico persistente tra l'incantatore e la creatura. L'incantatore effettua un attacco con incantesimo a distanza contro la creatura. Se colpisce, la creatura subisce 1d12 danni da fulmine e, in ognuno dei turni dell'incantatore per la durata, l'incantatore può usare la sua azione per infliggerle automaticamente 1d12 danni da fulmine. L'incantesimo termina se l'incantatore usa la sua azione per fare qualsiasi altra cosa, se in qualsiasi momento il bersaglio si trova fuori dalla gittata dell'incantesimo o se dispone di copertura totale nei confronti dell'incantatore.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni iniziali aumentano di 1d12 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
