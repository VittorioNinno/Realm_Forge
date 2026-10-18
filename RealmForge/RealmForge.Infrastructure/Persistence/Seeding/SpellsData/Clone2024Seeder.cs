using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Clone (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Clone2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "clone");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "clone", "en"),
					Language = LanguageCode.En,
					Name = "Clone",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a diamond worth 1,000+ GP, which the spell consumes, and a sealable vessel worth 2,000+ GP that is large enough to hold the creature being cloned",
					Description = "You touch a creature or at least 1 cubic inch of its flesh. An inert duplicate of that creature forms inside the vessel used in the spell's casting and finishes growing after 120 days; you choose whether the finished clone is the same age as the creature or younger. The clone remains inert and endures indefinitely while its vessel remains undisturbed.\n\nIf the original creature dies after the clone finishes forming, the creature's soul transfers to the clone if the soul is free and willing to return. The clone is physically identical to the original and has the same personality, memories, and abilities, but none of the original's equipment. The creature's original remains, if any, become inert and can't be revived, since the creature's soul is elsewhere.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "clone", "it"),
					Language = LanguageCode.It,
					Name = "Clone",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "un diamante del valore di almeno 1.000 mo, che l'incantesimo consuma, e un recipiente sigillabile del valore di almeno 2.000 mo, abbastanza grande da contenere la creatura da clonare",
					Description = "L'incantatore tocca una creatura o almeno 16 centimetri cubi della sua carne. Un duplicato inerte di quella creatura si forma all'interno del recipiente usato per lanciare l'incantesimo e termina di crescere dopo 120 giorni; l'incantatore sceglie se il clone completo ha la stessa età della creatura o è più giovane. Il clone rimane inerte e si conserva indefinitamente finché il suo recipiente non viene disturbato.\n\nSe la creatura originale muore dopo che il clone ha terminato di formarsi, la sua anima si trasferisce nel clone, purché sia libera e desiderosa di tornare. Il clone è fisicamente identico all'originale e ha la stessa personalità, gli stessi ricordi e le stesse capacità, ma nessun oggetto dell'equipaggiamento dell'originale. Gli eventuali resti originali della creatura diventano inerti e non possono essere riportati in vita, poiché l'anima della creatura si trova altrove.",
					HigherLevels = null
				}
			}
		};
	}
}
