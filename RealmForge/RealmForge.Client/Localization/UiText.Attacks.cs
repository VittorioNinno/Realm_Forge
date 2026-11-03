using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>
	///	Texts of the attack options: the features that can join an attack and when they apply.
	///	</summary>
	public static partial class UiText
	{
		public static string AttackOptionsHint(LanguageCode lang) => T(lang,
			"Prima di tirare, scegli cosa si aggiunge a questo attacco: le opzioni dipendono da come stai combattendo.",
			"Before rolling, choose what joins this attack: the options depend on how you are fighting.");
		public static string AttackRollDamage(LanguageCode lang) => T(lang, "Tira i danni", "Roll damage");

		public static string RiderName(string key, LanguageCode lang) => key switch
		{
			"sneak-attack" => T(lang, "Attacco furtivo", "Sneak Attack"),
			"rage" => T(lang, "Ira", "Rage"),
			"divine-smite" => T(lang, "Punizione divina", "Divine Smite"),
			"improved-smite" => T(lang, "Punizione divina migliorata", "Improved Divine Smite"),
			"colossus-slayer" => T(lang, "Uccisore di colossi", "Colossus Slayer"),
			"hunters-mark" => T(lang, "Marchio del cacciatore", "Hunter's Mark"),
			"hex" => T(lang, "Anatema", "Hex"),
			"great-weapon-master" => T(lang, "Maestro delle armi possenti", "Great Weapon Master"),
			"sharpshooter" => T(lang, "Tiratore scelto", "Sharpshooter"),
			_ => key
		};

		public static string RiderValue(AttackRiders.Rider rider, LanguageCode lang) => rider.Kind switch
		{
			AttackRiders.Kind.Dice => T(lang, $"+{rider.Dice} danni", $"+{rider.Dice} damage"),
			AttackRiders.Kind.Flat => T(lang, $"+{rider.Flat} danni", $"+{rider.Flat} damage"),
			AttackRiders.Kind.SlotDice => T(lang, "uno slot incantesimo: da 2d8 radiosi", "a spell slot: from 2d8 radiant"),
			AttackRiders.Kind.PowerAttack => T(lang, $"−5 al tiro per colpire, +{rider.Flat} danni", $"−5 to hit, +{rider.Flat} damage"),
			_ => string.Empty
		};

		public static string RiderCondition(string key, LanguageCode lang) => key switch
		{
			"sneak-attack" => T(lang,
				"Se hai vantaggio al tiro per colpire, oppure un tuo alleato non incapacitato è entro 1,5 m dal bersaglio e tu non hai svantaggio.",
				"If you have advantage on the attack roll, or an ally who is not incapacitated is within 5 feet of the target and you do not have disadvantage."),
			"rage" => T(lang, "Se sei in ira e l'attacco usa la Forza.", "If you are raging and the attack uses Strength."),
			"divine-smite" => T(lang,
				"Quando colpisci con un'arma da mischia: spendi uno slot, 1d8 in più per ogni livello oltre il 1° (massimo 5d8) e 1d8 in più contro non morti e immondi.",
				"When you hit with a melee weapon: spend a slot, 1d8 more per level above the 1st (at most 5d8) and 1d8 more against undead and fiends."),
			"colossus-slayer" => T(lang, "Se il bersaglio è sotto il suo massimo dei punti ferita.", "If the target is below its hit point maximum."),
			"hunters-mark" => T(lang, "Contro la creatura che hai marchiato (stai mantenendo la concentrazione).", "Against the creature you marked (you are concentrating on it)."),
			"hex" => T(lang, "Contro la creatura maledetta (stai mantenendo la concentrazione), danni necrotici.", "Against the cursed creature (you are concentrating on it), necrotic damage."),
			"great-weapon-master" => T(lang, "Con un'arma pesante da mischia, prima di tirare.", "With a heavy melee weapon, before rolling."),
			"sharpshooter" => T(lang, "Con un'arma a distanza, prima di tirare.", "With a ranged weapon, before rolling."),
			_ => string.Empty
		};

		public static string RiderAutomatic(LanguageCode lang) => T(lang, "Si aggiunge sempre quando colpisci.", "Always added when you hit.");
		public static string RiderOncePerTurn(LanguageCode lang) => T(lang, "Una volta per turno.", "Once per turn.");
		public static string RiderSlot(LanguageCode lang) => T(lang, "Slot:", "Slot:");
		public static string RiderUndead(LanguageCode lang) => T(lang, "Non morto o immondo (+1d8)", "Undead or fiend (+1d8)");
		public static string RiderCritical(LanguageCode lang) => T(lang, "Colpo critico (raddoppia i dadi dei danni)", "Critical hit (double the damage dice)");
	}
}
