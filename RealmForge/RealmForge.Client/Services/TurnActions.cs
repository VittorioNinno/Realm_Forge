using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	public enum TurnSlot
	{
		Action = 1,
		BonusAction = 2,
		Reaction = 3
	}

	///	<summary>
	///	What the character can do in a turn besides the standard actions: features of its classes that use an action,
	///	a bonus action or a reaction (names as in the Italian and English rules).
	///	</summary>
	//	ResourceKey: the class resource it spends (CharacterResources), so the summary shows the uses left
	public sealed record TurnFeature(TurnSlot Slot, string Name, string? Note = null, string? ResourceKey = null);

	public static class TurnActions
	{
		//	Glossary keys of the standard actions of each edition
		public static IReadOnlyList<string> StandardActionKeys(RulesetVersion ruleset) => ruleset == RulesetVersion.Dnd5e_2024
			? new[] { "attack", "dash", "disengage", "dodge", "help", "hide", "influence", "magic", "ready", "search", "study", "utilize" }
			: new[] { "attack", "cast-a-spell", "dash", "disengage", "dodge", "help", "hide", "ready", "search", "use-an-object" };

		//	Extra Attack does not stack between classes: the best one counts
		public static int AttacksPerAction(ComputedCharacter c)
		{
			var fighter = c.ClassLevel("fighter");
			var attacks = fighter >= 20 ? 4 : fighter >= 11 ? 3 : fighter >= 5 ? 2 : 1;
			if (new[] { "barbarian", "monk", "paladin", "ranger" }.Any(k => c.ClassLevel(k) >= 5))
			{
				attacks = Math.Max(attacks, 2);
			}
			return attacks;
		}

		public static List<TurnFeature> Features(ComputedCharacter c, LanguageCode lang)
		{
			var it = lang == LanguageCode.It;
			string T(string itName, string enName) => it ? itName : enName;
			var is2024 = c.Ruleset == RulesetVersion.Dnd5e_2024;
			var list = new List<TurnFeature>();
			void Add(TurnSlot slot, string name, string? note = null, string? key = null) => list.Add(new TurnFeature(slot, name, note, key));

			int Level(string key) => c.ClassLevel(key);

			//	Actions
			if (Level("cleric") >= 2 || Level("paladin") >= 3)
			{
				Add(TurnSlot.Action, T("Incanalare Divinità", "Channel Divinity"), null, Level("cleric") >= 2 ? "cleric-channel" : "paladin-channel");
			}
			if (!is2024 && Level("druid") >= 2)
			{
				Add(TurnSlot.Action, T("Forma Selvatica", "Wild Shape"), null, "druid-wild-shape");
			}
			if (!is2024 && Level("paladin") >= 1)
			{
				Add(TurnSlot.Action, T("Imposizione delle Mani", "Lay on Hands"), null, "paladin-lay-on-hands");
				Add(TurnSlot.Action, T("Percezione del Divino", "Divine Sense"), null, "paladin-divine-sense");
			}
			if (Level("fighter") >= 2)
			{
				Add(TurnSlot.Action, T("Azione Impetuosa", "Action Surge"), T("un'azione in più", "one more action"), "fighter-action-surge");
			}

			//	Bonus actions
			if (Level("barbarian") >= 1)
			{
				Add(TurnSlot.BonusAction, T("Ira", "Rage"), null, "barbarian-rage");
			}
			if (Level("bard") >= 1)
			{
				Add(TurnSlot.BonusAction, T("Ispirazione Bardica", "Bardic Inspiration"), null, "bard-inspiration");
			}
			if (Level("fighter") >= 1)
			{
				Add(TurnSlot.BonusAction, T("Recuperare Energie", "Second Wind"), null, "fighter-second-wind");
			}
			if (Level("monk") >= 1)
			{
				Add(TurnSlot.BonusAction, T("Arti Marziali", "Martial Arts"), T("colpo senz'armi", "Unarmed Strike"));
			}
			if (Level("monk") >= 2)
			{
				Add(TurnSlot.BonusAction, T("Raffica di Colpi", "Flurry of Blows"), null, "monk-points");
				Add(TurnSlot.BonusAction, T("Difesa Paziente", "Patient Defense"));
				Add(TurnSlot.BonusAction, T("Passo del Vento", "Step of the Wind"));
			}
			if (Level("rogue") >= 2)
			{
				Add(TurnSlot.BonusAction, T("Azione Scaltra", "Cunning Action"), T("Scatto, Disimpegno, Nascondersi", "Dash, Disengage, Hide"));
			}
			if (is2024 && Level("druid") >= 2)
			{
				Add(TurnSlot.BonusAction, T("Forma Selvatica", "Wild Shape"), null, "druid-wild-shape");
			}
			if (is2024 && Level("paladin") >= 1)
			{
				Add(TurnSlot.BonusAction, T("Imposizione delle Mani", "Lay on Hands"), null, "paladin-lay-on-hands");
			}
			if (is2024 && Level("sorcerer") >= 1)
			{
				Add(TurnSlot.BonusAction, T("Stregoneria Innata", "Innate Sorcery"), null, "sorcerer-innate");
			}

			//	Reactions
			Add(TurnSlot.Reaction, T("Attacco di opportunità", "Opportunity Attack"));
			if (Level("monk") >= 3)
			{
				Add(TurnSlot.Reaction, is2024 ? T("Deviare Attacchi", "Deflect Attacks") : T("Deviare Proiettili", "Deflect Missiles"));
			}
			if (Level("rogue") >= 5)
			{
				Add(TurnSlot.Reaction, T("Schivata Prodigiosa", "Uncanny Dodge"));
			}
			return list;
		}

		///	<summary>
		///	Which part of the turn a casting time uses ("1 azione bonus", "Bonus Action", "1 reazione…").
		///	</summary>
		public static TurnSlot? SlotOfCastingTime(string? castingTime)
		{
			var text = castingTime?.ToLowerInvariant() ?? string.Empty;
			if (text.Contains("bonus"))
			{
				return TurnSlot.BonusAction;
			}
			if (text.Contains("reazion") || text.Contains("reaction"))
			{
				return TurnSlot.Reaction;
			}
			if (text.Contains("azion") || text.Contains("action"))
			{
				return TurnSlot.Action;
			}
			return null;
		}
	}
}
