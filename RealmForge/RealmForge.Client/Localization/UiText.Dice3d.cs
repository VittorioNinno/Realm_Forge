using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the 3D dice.</summary>
	public static partial class UiText
	{
		public static string Dice3dTitle(LanguageCode lang) => T(lang, "Dadi 3D", "3D dice");
		public static string Dice3dHint(LanguageCode lang) => T(lang,
			"Dadi veri che rotolano sullo schermo e si fermano sul risultato del tiro. Le impostazioni valgono per questo dispositivo.",
			"Real dice tumbling across the screen and landing on the result of the roll. The settings apply to this device.");
		public static string Dice3dUnavailable(LanguageCode lang) => T(lang,
			"Questo browser non può mostrarli (WebGL assente o movimento ridotto attivo): restano i dadi animati del vassoio.",
			"This browser cannot show them (no WebGL, or reduced motion is on): the animated dice of the tray stay.");
		public static string Dice3dEnabled(LanguageCode lang) => T(lang, "Lancia i dadi in 3D", "Throw the dice in 3D");
		public static string Dice3dColor(LanguageCode lang) => T(lang, "Colore", "Colour");
		public static string Dice3dSound(LanguageCode lang) => T(lang, "Suono dei dadi", "Dice sound");
		public static string Dice3dOthers(LanguageCode lang) => T(lang, "Mostra anche i lanci degli altri al tavolo (nel loro colore)", "Show the rolls of the others at the table too (in their colour)");
		public static string Dice3dTest(LanguageCode lang) => T(lang, "Prova un lancio", "Try a throw");

		public static string Dice3dColorName(string color, LanguageCode lang) => color switch
		{
			"ivory" => T(lang, "Avorio", "Ivory"),
			"graphite" => T(lang, "Grafite", "Graphite"),
			"teal" => T(lang, "Ottanio", "Teal"),
			"ruby" => T(lang, "Rubino", "Ruby"),
			"emerald" => T(lang, "Smeraldo", "Emerald"),
			"sapphire" => T(lang, "Zaffiro", "Sapphire"),
			"amethyst" => T(lang, "Ametista", "Amethyst"),
			_ => T(lang, "Forgia (arancio)", "Forge (orange)")
		};

		public static string Dice3dSkin(LanguageCode lang) => T(lang, "Dadi", "Dice");
		public static string Dice3dSkinName(string skin, LanguageCode lang) => skin switch
		{
			"ember" => T(lang, "Brace del drago", "Dragon ember"),
			"stardust" => T(lang, "Polvere di stelle", "Stardust"),
			_ => T(lang, "Resina", "Resin")
		};
		public static string Dice3dSkinHint(string skin, LanguageCode lang) => skin switch
		{
			"ember" => T(lang, "Pietra lavica che arde: lasciano una scia di braci e atterrano in una fiammata", "Burning lava stone: a trail of embers, and a burst of flame where they land"),
			"stardust" => T(lang, "Vetro notturno pieno di stelle: una scia di scintille e un lampo di luce stellare all'arrivo", "Night glass full of stars: a trail of sparkles and a flash of starlight where they land"),
			_ => T(lang, "Resina classica, nel colore che preferisci", "Classic resin, in the colour you like")
		};
		public static string Dice3dSkinLocked(LanguageCode lang) => T(lang, "Dadi segreti: si sbloccano con un codice", "Secret dice: a code unlocks them");
		public static string Dice3dCustom(LanguageCode lang) => T(lang, "Colore personalizzato", "Custom colour");
		public static string Dice3dCustomHex(LanguageCode lang) => T(lang, "Colore personalizzato in esadecimale", "Custom colour in hex");
		public static string Dice3dCode(LanguageCode lang) => T(lang, "Codice di sblocco", "Unlock code");
		public static string Dice3dCodePlaceholder(LanguageCode lang) => T(lang, "Hai un codice segreto?", "Got a secret code?");
		public static string Dice3dUnlock(LanguageCode lang) => T(lang, "Sblocca", "Unlock");
		public static string Dice3dUnlocked(string name, LanguageCode lang) => T(lang, $"Sbloccati: {name}! Sono già selezionati.", $"Unlocked: {name}! They are already selected.");
		public static string Dice3dAlready(string name, LanguageCode lang) => T(lang, $"Hai già sbloccato {name}.", $"You already unlocked {name}.");
		public static string Dice3dWrongCode(LanguageCode lang) => T(lang, "Il codice non apre nulla.", "That code opens nothing.");
		public static string Dice3dTooMany(LanguageCode lang) => T(lang, "Troppi tentativi: riprova tra un minuto.", "Too many tries: try again in a minute.");
	}
}
