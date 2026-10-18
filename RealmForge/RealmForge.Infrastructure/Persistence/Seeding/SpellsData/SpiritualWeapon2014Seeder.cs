using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Spiritual Weapon (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SpiritualWeapon2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spiritual-weapon");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spiritual-weapon", "en"),
					Language = LanguageCode.En,
					Name = "Spiritual Weapon",
					CastingTime = "1 bonus action",
					Range = "60 feet",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "You create a floating, spectral weapon within range that lasts for the duration or until you cast this spell again. When you cast the spell, you can make a melee spell attack against a creature within 5 feet of the weapon. On a hit, the target takes force damage equal to 1d8 + your spellcasting ability modifier.\n\nAs a bonus action on your turn, you can move the weapon up to 20 feet and repeat the attack against a creature within 5 feet of it.\n\nThe weapon can take whatever form you choose. Clerics of deities who are associated with a particular weapon (as St. Cuthbert is known for his mace and Thor for his hammer) make this spell's effect resemble that weapon.",
					HigherLevels = "When you cast this spell using a spell slot of 3rd level or higher, the damage increases by 1d8 for every two slot levels above the 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "spiritual-weapon", "it"),
					Language = LanguageCode.It,
					Name = "Arma Spirituale",
					CastingTime = "1 azione bonus",
					Range = "18 metri",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore crea entro gittata un'arma spettrale fluttuante che dura per la durata o finché l'incantatore non lancia di nuovo questo incantesimo. Quando lancia l'incantesimo, l'incantatore può effettuare un attacco con incantesimo in mischia contro una creatura entro 1,5 metri dall'arma. Se colpisce, il bersaglio subisce danni da forza pari a 1d8 + il modificatore di caratteristica da incantatore dell'incantatore.\n\nCome azione bonus nel suo turno, l'incantatore può spostare l'arma di un massimo di 6 metri e ripetere l'attacco contro una creatura entro 1,5 metri da essa.\n\nL'arma può assumere la forma che l'incantatore preferisce. I chierici delle divinità associate a una particolare arma (come San Cuthbert, noto per la sua mazza, e Thor, per il suo martello) fanno sì che l'effetto di questo incantesimo assomigli a quell'arma.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, i danni aumentano di 1d8 ogni due livelli dello slot superiori al 2°."
				}
			}
		};
	}
}
