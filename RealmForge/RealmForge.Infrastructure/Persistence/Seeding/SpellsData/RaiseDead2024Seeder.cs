using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Raise Dead (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class RaiseDead2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "raise-dead");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "raise-dead", "en"),
					Language = LanguageCode.En,
					Name = "Raise Dead",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a diamond worth 500+ GP, which the spell consumes",
					Description = "With a touch, you revive a dead creature if it has been dead no longer than 10 days and it wasn't Undead when it died.\n\nThe creature returns to life with 1 Hit Point. This spell also neutralizes any poisons that affected the creature at the time of death.\n\nThis spell closes all mortal wounds, but it doesn't restore missing body parts. If the creature is lacking body parts or organs integral for its survival—its head, for instance—the spell automatically fails.\n\nComing back from the dead is an ordeal. The target takes a −4 penalty to D20 Tests. Every time the target finishes a Long Rest, the penalty is reduced by 1 until it becomes 0.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "raise-dead", "it"),
					Language = LanguageCode.It,
					Name = "Rianimare Morti",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "un diamante del valore di almeno 500 mo, che l'incantesimo consuma",
					Description = "Con un tocco, l'incantatore riporta in vita una creatura morta, purché sia morta da non più di 10 giorni e non fosse un non morto al momento della morte.\n\nLa creatura ritorna in vita con 1 punto ferita. Questo incantesimo neutralizza inoltre qualsiasi veleno che affliggeva la creatura al momento della morte.\n\nQuesto incantesimo chiude tutte le ferite mortali, ma non ripristina le parti del corpo mancanti. Se alla creatura mancano parti del corpo o organi indispensabili per la sopravvivenza (la testa, per esempio), l'incantesimo fallisce automaticamente.\n\nTornare dal mondo dei morti è una dura prova. Il bersaglio subisce una penalità di −4 alle prove con d20. Ogni volta che il bersaglio termina un riposo lungo, la penalità si riduce di 1, finché non arriva a 0.",
					HigherLevels = null
				}
			}
		};
	}
}
