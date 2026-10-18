using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Resurrection (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Resurrection2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "resurrection");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "resurrection", "en"),
					Language = LanguageCode.En,
					Name = "Resurrection",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a diamond worth at least 1,000 gp, which the spell consumes",
					Description = "You touch a dead creature that has been dead for no more than a century, that didn't die of old age, and that isn't undead. If its soul is free and willing, the target returns to life with all its hit points.\n\nThis spell neutralizes any poisons and cures normal diseases afflicting the creature when it died. It doesn't, however, remove magical diseases, curses, and the like; if such effects aren't removed prior to casting the spell, they afflict the target on its return to life.\n\nThis spell closes all mortal wounds and restores any missing body parts.\n\nComing back from the dead is an ordeal. The target takes a -4 penalty to all attack rolls, saving throws, and ability checks. Every time the target finishes a long rest, the penalty is reduced by 1 until it disappears.\n\nCasting this spell to restore life to a creature that has been dead for one year or longer taxes you greatly. Until you finish a long rest, you can't cast spells again, and you have disadvantage on all attack rolls, ability checks, and saving throws.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "resurrection", "it"),
					Language = LanguageCode.It,
					Name = "Resurrezione",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "un diamante del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore tocca una creatura morta da non più di un secolo, che non sia morta di vecchiaia e che non sia un non morto. Se la sua anima è libera e disposta a tornare, il bersaglio torna in vita con tutti i suoi punti ferita.\n\nQuesto incantesimo neutralizza tutti i veleni e cura le malattie normali che affliggevano la creatura al momento della morte. Tuttavia, non rimuove le malattie magiche, le maledizioni e simili; se questi effetti non vengono rimossi prima del lancio dell'incantesimo, affliggono il bersaglio al suo ritorno in vita.\n\nQuesto incantesimo chiude tutte le ferite mortali e ripristina tutte le parti del corpo mancanti.\n\nTornare dal regno dei morti è un'esperienza estenuante. Il bersaglio subisce una penalità di -4 a tutti i tiri per colpire, ai tiri salvezza e alle prove di caratteristica. Ogni volta che il bersaglio termina un riposo lungo, la penalità si riduce di 1, finché non scompare.\n\nLanciare questo incantesimo per riportare in vita una creatura morta da un anno o più mette a dura prova l'incantatore. Finché non termina un riposo lungo, non può lanciare altri incantesimi e subisce svantaggio a tutti i tiri per colpire, alle prove di caratteristica e ai tiri salvezza.",
					HigherLevels = null
				}
			}
		};
	}
}
