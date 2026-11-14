using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Characters;

public enum FeatureSlot
{
	Free = 0,
	Action = 1,
	Bonus = 2,
	Reaction = 3
}

///	<summary>
///	A feature used at the table: the part of the turn it takes, the class resource it spends (one use, or points of a
///	pool), the dice it rolls and what the roll does (heal: hit points back; temp: temporary hit points; surge: one more
///	action; none: the roll is told), a note.
///	</summary>
public sealed record FeatureUse(string Key, string Name, FeatureSlot Slot, string? ResourceKey, string? Roll, string Effect, string? Note = null, bool OncePerTurn = false);

///	<summary>
///	The features of a character that can be used from the table: those with a class resource (Second Wind, Action
///	Surge, Rage, Bardic Inspiration, Channel Divinity, Lay on Hands, Ki/Focus, the species' ones…) and the dice added to
///	an attack (Sneak Attack, the Martial Arts die, Divine Smite in 2014).
///	</summary>
public static class FeatureUses
{
	public static List<FeatureUse> For(ComputedCharacter c, LanguageCode lang)
	{
		var it = lang == LanguageCode.It;
		string T(string itText, string enText) => it ? itText : enText;
		var is2024 = c.Ruleset == RulesetVersion.Dnd5e_2024;
		var resources = CharacterResources.For(c, lang);
		var list = new List<FeatureUse>();
		var known = new HashSet<string>();
		void Use(string resource, FeatureSlot slot, string? roll, string effect, string? note = null, string? name = null)
		{
			if (resources.FirstOrDefault(r => r.Key == resource) is { } r)
			{
				list.Add(new FeatureUse(resource, name ?? r.Name, slot, resource, roll, effect, note));
				known.Add(resource);
			}
		}
		int Level(string key) => c.ClassLevel(key);
		var proficiency = c.ProficiencyBonus;

		Use("fighter-second-wind", FeatureSlot.Bonus, $"1d10+{Level("fighter")}", "heal");
		Use("fighter-action-surge", FeatureSlot.Free, null, "surge", T("Un'azione in più in questo turno", "One more action this turn"));
		Use("fighter-indomitable", FeatureSlot.Free, null, "none", T("Ripeti un tiro salvezza fallito", "Reroll a failed saving throw"));
		Use("barbarian-rage", FeatureSlot.Bonus, null, "none",
			T($"Danni +{(Level("barbarian") >= 16 ? 4 : Level("barbarian") >= 9 ? 3 : 2)} in mischia con la Forza, resistenza a contundenti, perforanti e taglienti",
				$"+{(Level("barbarian") >= 16 ? 4 : Level("barbarian") >= 9 ? 3 : 2)} melee Strength damage, resistance to bludgeoning, piercing and slashing"));
		var inspiration = $"1d{(Level("bard") >= 15 ? 12 : Level("bard") >= 10 ? 10 : Level("bard") >= 5 ? 8 : 6)}";
		Use("bard-inspiration", FeatureSlot.Bonus, inspiration, "none", T($"Un alleato aggiunge {inspiration} a un tiro", $"An ally adds {inspiration} to a roll"));
		Use("cleric-channel", FeatureSlot.Action, null, "none");
		Use("paladin-channel", FeatureSlot.Action, null, "none");
		Use("cleric-intervention", FeatureSlot.Action, null, "none");
		Use("druid-wild-shape", is2024 ? FeatureSlot.Bonus : FeatureSlot.Action, null, "none");
		Use("paladin-lay-on-hands", is2024 ? FeatureSlot.Bonus : FeatureSlot.Action, null, "pool-heal", T("Punti ferita dalla riserva", "Hit points from the pool"));
		Use("paladin-divine-sense", FeatureSlot.Action, null, "none");
		Use("monk-points", FeatureSlot.Bonus, null, "none", T("Raffica di colpi, Difesa paziente o Passo del vento", "Flurry of Blows, Patient Defense or Step of the Wind"));
		Use("monk-metabolism", FeatureSlot.Free, $"1d{MartialArts(Level("monk"), is2024)}+{Level("monk")}", "heal");
		Use("sorcerer-points", FeatureSlot.Free, null, "none", T("Metamagia o slot incantesimo", "Metamagic or spell slots"));
		Use("sorcerer-innate", FeatureSlot.Bonus, null, "none");
		Use("ranger-favored-enemy", FeatureSlot.Free, null, "none", T("Marchio del cacciatore senza slot", "Hunter's Mark without a slot"));
		Use("rogue-stroke-of-luck", FeatureSlot.Free, null, "none");
		Use("battle-master-dice", FeatureSlot.Free, $"1d{(c.ClassLevel("fighter") >= 18 ? 12 : c.ClassLevel("fighter") >= 10 ? 10 : 8)}", "none", T("Manovra", "Maneuver"));
		Use("species-healing-hands", FeatureSlot.Action, is2024 ? $"{proficiency}d4" : null, is2024 ? "heal" : "pool-level",
			is2024 ? null : T("Punti ferita pari al livello", "Hit points equal to the level"));
		Use("species-adrenaline", FeatureSlot.Bonus, null, "temp", T($"Scatto e {proficiency} punti ferita temporanei", $"Dash and {proficiency} temporary hit points"));
		Use("species-endurance", FeatureSlot.Free, null, "none", T("A 0 punti ferita resti a 1", "At 0 hit points you stay at 1"));
		Use("species-breath", FeatureSlot.Action, Breath(c, is2024), "none");
		Use("feat-lucky", FeatureSlot.Free, null, "none", T("Tira un d20 in più", "Roll one more d20"));

		//	Every other resource is spent the same way, without dice
		foreach (var r in resources.Where(r => !known.Contains(r.Key)))
		{
			list.Add(new FeatureUse(r.Key, r.Name, FeatureSlot.Free, r.Key, null, "none"));
		}

		//	Dice added to an attack, without a resource
		if (Level("rogue") > 0)
		{
			list.Add(new FeatureUse("rogue-sneak-attack", T("Attacco Furtivo", "Sneak Attack"), FeatureSlot.Free, null, $"{(Level("rogue") + 1) / 2}d6", "none",
				T("Una volta per turno, con vantaggio o un alleato vicino", "Once per turn, with advantage or an ally nearby"), true));
		}
		if (Level("monk") > 0)
		{
			list.Add(new FeatureUse("monk-martial-arts", T("Arti Marziali", "Martial Arts"), FeatureSlot.Free, null, $"1d{MartialArts(Level("monk"), is2024)}", "none",
				T("Il dado dei colpi senz'armi e delle armi da monaco", "The die of unarmed strikes and monk weapons")));
		}
		if (!is2024 && Level("paladin") >= 2)
		{
			list.Add(new FeatureUse("paladin-smite", T("Punizione Divina", "Divine Smite"), FeatureSlot.Free, null, "2d8", "none",
				T("Con uno slot di 1° livello: +1d8 per ogni livello in più, +1d8 contro non morti e immondi", "With a 1st-level slot: +1d8 per higher level, +1d8 against undead and fiends")));
		}
		if (Level("ranger") > 0 && !is2024)
		{
			list.Add(new FeatureUse("ranger-hunters-mark", T("Marchio del Cacciatore", "Hunter's Mark"), FeatureSlot.Free, null, "1d6", "none",
				T("Danni in più contro il bersaglio marchiato", "Extra damage against the marked target")));
		}
		return list;
	}

	private static int MartialArts(int monk, bool is2024) => is2024
		? monk >= 17 ? 12 : monk >= 11 ? 10 : monk >= 5 ? 8 : 6
		: monk >= 17 ? 10 : monk >= 11 ? 8 : monk >= 5 ? 6 : 4;

	private static string Breath(ComputedCharacter c, bool is2024)
	{
		var level = c.Level;
		return is2024
			? $"{(level >= 17 ? 4 : level >= 11 ? 3 : level >= 5 ? 2 : 1)}d10"
			: $"{(level >= 16 ? 5 : level >= 11 ? 4 : level >= 6 ? 3 : 2)}d6";
	}
}
