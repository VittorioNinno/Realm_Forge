using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Aura of Purity (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class AuraOfPurity2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aura-of-purity");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 4,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aura-of-purity", "en"),
					Language = LanguageCode.En,
					Name = "Aura of Purity",
					CastingTime = "1 action",
					Range = "Self (30-foot radius)",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "A cleansing aura spreads from you in a 30-foot radius and moves with you, centered on you, until the spell ends. Every nonhostile creature inside the aura, you included, can't become diseased, has resistance to poison damage, and has advantage on saving throws against effects that would leave it blinded, charmed, deafened, frightened, paralyzed, poisoned, or stunned.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "aura-of-purity", "it"),
					Language = LanguageCode.It,
					Name = "Aura di Purezza",
					CastingTime = "1 azione",
					Range = "Incantatore (raggio di 9 metri)",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "Un'aura purificatrice si irradia dall'incantatore in un raggio di 9 metri e si sposta con lui, rimanendo centrata su di lui, finché l'incantesimo non termina. Ogni creatura non ostile all'interno dell'aura, incluso l'incantatore, non può contrarre malattie, ha resistenza ai danni da veleno e dispone di vantaggio ai tiri salvezza contro gli effetti che la renderebbero accecata, affascinata, assordata, avvelenata, paralizzata, spaventata o stordita.",
					HigherLevels = null
				}
			}
		};
	}
}
