using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Vampiric Touch (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class VampiricTouch2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "vampiric-touch");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "vampiric-touch", "en"),
					Language = LanguageCode.En,
					Name = "Vampiric Touch",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "The touch of your shadow-wreathed hand can siphon life force from others to heal your wounds. Make a melee spell attack against a creature within your reach. On a hit, the target takes 3d6 necrotic damage, and you regain hit points equal to half the amount of necrotic damage dealt. Until the spell ends, you can make the attack again on each of your turns as an action.",
					HigherLevels = "When you cast this spell using a spell slot of 4th level or higher, the damage increases by 1d6 for each slot level above 3rd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "vampiric-touch", "it"),
					Language = LanguageCode.It,
					Name = "Tocco del Vampiro",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Il tocco della mano dell'incantatore, avvolta dalle ombre, può prosciugare la forza vitale altrui per guarire le sue ferite. L'incantatore effettua un attacco con incantesimo in mischia contro una creatura a portata. Se colpisce, il bersaglio subisce 3d6 danni necrotici e l'incantatore recupera un numero di punti ferita pari alla metà dei danni necrotici inflitti. Finché l'incantesimo non termina, l'incantatore può effettuare di nuovo l'attacco in ognuno dei suoi turni, come azione.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 4° livello o superiore, i danni aumentano di 1d6 per ogni livello dello slot superiore al 3°."
				}
			}
		};
	}
}
