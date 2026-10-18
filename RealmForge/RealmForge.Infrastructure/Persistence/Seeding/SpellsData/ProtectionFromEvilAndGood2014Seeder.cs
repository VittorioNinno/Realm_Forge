using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Protection from Evil and Good (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ProtectionFromEvilAndGood2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "protection-from-evil-and-good");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "protection-from-evil-and-good", "en"),
					Language = LanguageCode.En,
					Name = "Protection from Evil and Good",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "holy water or powdered silver and iron, which the spell consumes",
					Description = "Until the spell ends, one willing creature you touch is protected against certain types of creatures: aberrations, celestials, elementals, fey, fiends, and undead.\n\nThe protection grants several benefits. Creatures of those types have disadvantage on attack rolls against the target. The target also can't be charmed, frightened, or possessed by them. If the target is already charmed, frightened, or possessed by such a creature, the target has advantage on any new saving throw against the relevant effect.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "protection-from-evil-and-good", "it"),
					Language = LanguageCode.It,
					Name = "Protezione dal Bene e dal Male",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "acqua santa oppure polvere d'argento e di ferro, che l'incantesimo consuma",
					Description = "Finché l'incantesimo non termina, una creatura consenziente toccata dall'incantatore è protetta da determinati tipi di creature: aberrazioni, celestiali, elementali, folletti, immondi e non morti.\n\nLa protezione conferisce diversi benefici. Le creature di quei tipi subiscono svantaggio ai tiri per colpire contro il bersaglio. Inoltre, il bersaglio non può essere affascinato, spaventato o posseduto da esse. Se il bersaglio è già affascinato, spaventato o posseduto da una di queste creature, dispone di vantaggio a qualsiasi nuovo tiro salvezza contro l'effetto in questione.",
					HigherLevels = null
				}
			}
		};
	}
}
