using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

public enum ResourceReset
{
	//	All uses come back at the end of a long rest
	LongRest = 1,

	//	All uses come back at the end of a short or long rest
	ShortRest = 2,

	//	2024: one use comes back with a short rest, all with a long rest
	OneOnShortRest = 3
}

///	<summary>
///	A limited-use class feature with the uses it has at the current level (Rage, Channel Divinity, Focus Points…).
///	Pool: a large number of points spent a few at a time (Lay on Hands, Ki, Sorcery Points) rather than single uses.
///	</summary>
public sealed record ClassResource(string Key, string Name, int Maximum, ResourceReset Reset, bool Pool);

///	<summary>
///	The limited-use features of the Base classes, from the class tables of both editions: the sheet tracks them on its
///	own, the player only marks what is spent.
///	</summary>
public static class CharacterResources
{
	public static List<ClassResource> For(ComputedCharacter c, LanguageCode lang)
	{
		var list = new List<ClassResource>();
		var is2024 = c.Ruleset == RulesetVersion.Dnd5e_2024;
		var it = lang == LanguageCode.It;
		string T(string itName, string enName) => it ? itName : enName;
		void Add(string key, string name, int max, ResourceReset reset, bool pool = false)
		{
			if (max > 0)
			{
				list.Add(new ClassResource(key, name, max, reset, pool));
			}
		}
		static int Step(int level, params (int From, int Value)[] table) =>
			table.Where(t => level >= t.From).Select(t => t.Value).DefaultIfEmpty(0).Last();

		var charisma = Math.Max(1, c.Modifier(AbilityScore.Charisma));

		var barbarian = c.ClassLevel("barbarian");
		if (barbarian > 0 && (is2024 || barbarian < 20))
		{
			Add("barbarian-rage", T("Ira", "Rage"), Step(barbarian, (1, 2), (3, 3), (6, 4), (12, 5), (17, 6)),
				is2024 ? ResourceReset.OneOnShortRest : ResourceReset.LongRest);
		}

		var bard = c.ClassLevel("bard");
		if (bard > 0)
		{
			Add("bard-inspiration", T("Ispirazione Bardica", "Bardic Inspiration"), charisma,
				bard >= 5 ? ResourceReset.ShortRest : ResourceReset.LongRest);
		}

		var cleric = c.ClassLevel("cleric");
		if (cleric >= 2)
		{
			Add("cleric-channel", T("Incanalare Divinità", "Channel Divinity"),
				is2024 ? Step(cleric, (2, 2), (6, 3), (18, 4)) : Step(cleric, (2, 1), (6, 2), (18, 3)),
				is2024 ? ResourceReset.OneOnShortRest : ResourceReset.ShortRest);
		}
		if (is2024 && cleric >= 10)
		{
			Add("cleric-intervention", T("Intervento Divino", "Divine Intervention"), 1, ResourceReset.LongRest);
		}

		var druid = c.ClassLevel("druid");
		if (druid >= 2 && (is2024 || druid < 20))
		{
			Add("druid-wild-shape", T("Forma Selvatica", "Wild Shape"),
				is2024 ? Step(druid, (2, 2), (6, 3), (17, 4)) : 2,
				is2024 ? ResourceReset.OneOnShortRest : ResourceReset.ShortRest);
		}

		var fighter = c.ClassLevel("fighter");
		if (fighter > 0)
		{
			Add("fighter-second-wind", T("Recuperare Energie", "Second Wind"),
				is2024 ? Step(fighter, (1, 2), (4, 3), (10, 4)) : 1,
				is2024 ? ResourceReset.OneOnShortRest : ResourceReset.ShortRest);
			Add("fighter-action-surge", T("Azione Impetuosa", "Action Surge"), Step(fighter, (2, 1), (17, 2)), ResourceReset.ShortRest);
			Add("fighter-indomitable", is2024 ? T("Indomabile", "Indomitable") : T("Indomito", "Indomitable"),
				Step(fighter, (9, 1), (13, 2), (17, 3)), ResourceReset.LongRest);
		}

		var monk = c.ClassLevel("monk");
		if (monk >= 2)
		{
			Add("monk-points", is2024 ? T("Punti concentrazione", "Focus Points") : T("Punti ki", "Ki Points"), monk, ResourceReset.ShortRest, pool: true);
			if (is2024)
			{
				Add("monk-metabolism", T("Metabolismo Straordinario", "Uncanny Metabolism"), 1, ResourceReset.LongRest);
			}
		}

		var paladin = c.ClassLevel("paladin");
		if (paladin > 0)
		{
			Add("paladin-lay-on-hands", T("Imposizione delle Mani", "Lay on Hands"), paladin * 5, ResourceReset.LongRest, pool: true);
			if (!is2024)
			{
				Add("paladin-divine-sense", T("Percezione del Divino", "Divine Sense"), 1 + c.Modifier(AbilityScore.Charisma), ResourceReset.LongRest);
			}
			if (paladin >= 3)
			{
				Add("paladin-channel", T("Incanalare Divinità", "Channel Divinity"),
					is2024 ? Step(paladin, (3, 2), (11, 3)) : 1,
					is2024 ? ResourceReset.OneOnShortRest : ResourceReset.ShortRest);
			}
		}

		var ranger = c.ClassLevel("ranger");
		if (is2024 && ranger > 0)
		{
			//	Free castings of Hunter's Mark
			Add("ranger-favored-enemy", T("Nemico Prescelto", "Favored Enemy"), Step(ranger, (1, 2), (5, 3), (9, 4), (13, 5), (17, 6)), ResourceReset.LongRest);
		}

		var rogue = c.ClassLevel("rogue");
		if (rogue >= 20)
		{
			Add("rogue-stroke-of-luck", T("Colpo di Fortuna", "Stroke of Luck"), 1, ResourceReset.ShortRest);
		}

		var sorcerer = c.ClassLevel("sorcerer");
		if (sorcerer > 0)
		{
			if (is2024)
			{
				Add("sorcerer-innate", T("Stregoneria Innata", "Innate Sorcery"), 2, ResourceReset.LongRest);
			}
			if (sorcerer >= 2)
			{
				Add("sorcerer-points", T("Punti stregoneria", "Sorcery Points"), sorcerer, ResourceReset.LongRest, pool: true);
			}
		}

		if (is2024 && c.ClassLevel("warlock") >= 2)
		{
			Add("warlock-cunning", T("Scaltrezza Magica", "Magical Cunning"), 1, ResourceReset.LongRest);
		}

		if (c.ClassLevel("wizard") > 0)
		{
			Add("wizard-arcane-recovery", T("Recupero Arcano", "Arcane Recovery"), 1, ResourceReset.LongRest);
		}

		return list;
	}

	///	<summary>
	///	Uses left after a rest, from the uses spent before it.
	///	</summary>
	public static int SpentAfterRest(ClassResource resource, int spent, bool longRest) => longRest
		? 0
		: resource.Reset switch
		{
			ResourceReset.ShortRest => 0,
			ResourceReset.OneOnShortRest => Math.Max(0, spent - 1),
			_ => spent
		};
}
