using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Raise Dead (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class RaiseDead2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "raise-dead");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "raise-dead", "en"),
					Language = LanguageCode.En,
					Name = "Raise Dead",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a diamond worth at least 500 gp, which the spell consumes",
					Description = "You return a dead creature you touch to life, provided that it has been dead no longer than 10 days. If the creature's soul is both willing and at liberty to rejoin the body, the creature returns to life with 1 hit point.\n\nThis spell also neutralizes any poisons and cures nonmagical diseases that affected the creature at the time it died. This spell doesn't, however, remove magical diseases, curses, or similar effects; if these aren't first removed prior to casting the spell, they take effect when the creature returns to life. The spell can't return an undead creature to life.\n\nThis spell closes all mortal wounds, but it doesn't restore missing body parts. If the creature is lacking body parts or organs integral for its survival—its head, for instance—the spell automatically fails.\n\nComing back from the dead is an ordeal. The target takes a -4 penalty to all attack rolls, saving throws, and ability checks. Every time the target finishes a long rest, the penalty is reduced by 1 until it disappears.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "raise-dead", "it"),
					Language = LanguageCode.It,
					Name = "Rianimare Morti",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "un diamante del valore di almeno 500 mo, che l'incantesimo consuma",
					Description = "L'incantatore riporta in vita una creatura morta che tocca, purché non sia morta da più di 10 giorni. Se l'anima della creatura è disposta e libera di ricongiungersi al corpo, la creatura torna in vita con 1 punto ferita.\n\nQuesto incantesimo neutralizza inoltre tutti i veleni e cura le malattie non magiche che affliggevano la creatura al momento della morte. Tuttavia, non rimuove le malattie magiche, le maledizioni o effetti simili; se questi non vengono rimossi prima del lancio dell'incantesimo, hanno effetto quando la creatura torna in vita. L'incantesimo non può riportare in vita una creatura non morta.\n\nQuesto incantesimo chiude tutte le ferite mortali, ma non ripristina le parti del corpo mancanti. Se alla creatura mancano parti del corpo o organi indispensabili alla sua sopravvivenza, come la testa, l'incantesimo fallisce automaticamente.\n\nTornare dal regno dei morti è un'esperienza estenuante. Il bersaglio subisce una penalità di -4 a tutti i tiri per colpire, ai tiri salvezza e alle prove di caratteristica. Ogni volta che il bersaglio termina un riposo lungo, la penalità si riduce di 1, finché non scompare.",
					HigherLevels = null
				}
			}
		};
	}
}
