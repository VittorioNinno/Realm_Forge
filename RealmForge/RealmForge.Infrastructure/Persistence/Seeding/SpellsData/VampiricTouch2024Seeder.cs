using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Vampiric Touch (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class VampiricTouch2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "vampiric-touch");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "vampiric-touch", "en"),
					Language = LanguageCode.En,
					Name = "Vampiric Touch",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "The touch of your shadow-wreathed hand can siphon life force from others to heal your wounds. Make a melee spell attack against one creature within reach. On a hit, the target takes 3d6 Necrotic damage, and you regain Hit Points equal to half the amount of Necrotic damage dealt.\n\nUntil the spell ends, you can make the attack again on each of your turns as a Magic action, targeting the same creature or a different one.",
					HigherLevels = "The damage increases by 1d6 for each spell slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "vampiric-touch", "it"),
					Language = LanguageCode.It,
					Name = "Tocco del Vampiro",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Il tocco della mano dell'incantatore, avvolta dalle ombre, può prosciugare la forza vitale altrui per curare le sue ferite. L'incantatore effettua un attacco con incantesimo in mischia contro una creatura entro portata. Se colpisce, il bersaglio subisce 3d6 danni necrotici e l'incantatore recupera punti ferita pari alla metà dei danni necrotici inflitti.\n\nFinché l'incantesimo non termina, l'incantatore può effettuare di nuovo l'attacco in ognuno dei suoi turni come azione di Magia, prendendo come bersaglio la stessa creatura o una creatura diversa.",
					HigherLevels = "I danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 3°."
				}
			}
		};
	}
}
