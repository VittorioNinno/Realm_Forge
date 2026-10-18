using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Resurrection (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Resurrection2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "resurrection");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "resurrection", "en"),
					Language = LanguageCode.En,
					Name = "Resurrection",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a diamond worth 1,000+ GP, which the spell consumes",
					Description = "With a touch, you revive a dead creature that has been dead for no more than a century, didn't die of old age, and wasn't Undead when it died.\n\nThe creature returns to life with all its Hit Points. This spell also neutralizes any poisons that affected the creature at the time of death. This spell closes all mortal wounds and restores any missing body parts.\n\nComing back from the dead is an ordeal. The target takes a −4 penalty to D20 Tests. Every time the target finishes a Long Rest, the penalty is reduced by 1 until it becomes 0.\n\nCasting this spell to revive a creature that has been dead for 365 days or longer taxes you. Until you finish a Long Rest, you can't cast spells again, and you have Disadvantage on D20 Tests.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "resurrection", "it"),
					Language = LanguageCode.It,
					Name = "Resurrezione",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "un diamante del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "Con un tocco, l'incantatore riporta in vita una creatura morta da non più di un secolo, che non sia morta di vecchiaia e che non fosse un non morto al momento della morte.\n\nLa creatura ritorna in vita con tutti i suoi punti ferita. Questo incantesimo neutralizza inoltre qualsiasi veleno che affliggeva la creatura al momento della morte. Questo incantesimo chiude tutte le ferite mortali e ripristina le eventuali parti del corpo mancanti.\n\nTornare dal mondo dei morti è una dura prova. Il bersaglio subisce una penalità di −4 alle prove con d20. Ogni volta che il bersaglio termina un riposo lungo, la penalità si riduce di 1, finché non arriva a 0.\n\nLanciare questo incantesimo per riportare in vita una creatura morta da 365 giorni o più mette a dura prova l'incantatore. Finché non termina un riposo lungo, l'incantatore non può lanciare di nuovo incantesimi e subisce svantaggio alle prove con d20.",
					HigherLevels = null
				}
			}
		};
	}
}
