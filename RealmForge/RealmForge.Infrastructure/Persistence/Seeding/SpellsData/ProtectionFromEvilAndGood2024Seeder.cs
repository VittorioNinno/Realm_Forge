using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Protection from Evil and Good (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ProtectionFromEvilAndGood2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "protection-from-evil-and-good");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Paladin, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "protection-from-evil-and-good", "en"),
					Language = LanguageCode.En,
					Name = "Protection from Evil and Good",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a flask of Holy Water worth 25+ GP, which the spell consumes",
					Description = "Until the spell ends, one willing creature you touch is protected against creatures that are Aberrations, Celestials, Elementals, Fey, Fiends, or Undead.\n\nThe protection grants several benefits. Creatures of those types have Disadvantage on attack rolls against the target. The target also can't be possessed by or gain the Charmed or Frightened conditions from them. If the target is already possessed, Charmed, or Frightened by such a creature, the target has Advantage on any new saving throw against the relevant effect.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "protection-from-evil-and-good", "it"),
					Language = LanguageCode.It,
					Name = "Protezione dal Bene e dal Male",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una fiala di acqua santa del valore di almeno 25 mo, che l'incantesimo consuma",
					Description = "Finché l'incantesimo non termina, una creatura consenziente toccata dall'incantatore è protetta contro le creature che sono aberrazioni, celestiali, elementali, folletti, immondi o non morti.\n\nLa protezione conferisce diversi benefici. Le creature di quei tipi subiscono svantaggio ai tiri per colpire contro il bersaglio. Inoltre, il bersaglio non può essere posseduto, affascinato o spaventato da esse. Se il bersaglio è già posseduto, affascinato o spaventato da una tale creatura, dispone di vantaggio a qualsiasi nuovo tiro salvezza contro l'effetto in questione.",
					HigherLevels = null
				}
			}
		};
	}
}
