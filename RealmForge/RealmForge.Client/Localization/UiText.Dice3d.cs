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
		public static string Dice3dMaterial(LanguageCode lang) => T(lang, "Materiale", "Material");
		public static string Dice3dSound(LanguageCode lang) => T(lang, "Suono dei dadi", "Dice sound");
		public static string Dice3dOthers(LanguageCode lang) => T(lang, "Mostra anche i lanci degli altri al tavolo (nel loro colore)", "Show the rolls of the others at the table too (in their colour)");
		public static string Dice3dTest(LanguageCode lang) => T(lang, "Prova un lancio", "Try a throw");

		public static string Dice3dColorName(string color, LanguageCode lang) => color switch
		{
			"ivory" => T(lang, "Avorio", "Ivory"),
			"obsidian" => T(lang, "Ossidiana", "Obsidian"),
			"ruby" => T(lang, "Rubino", "Ruby"),
			"emerald" => T(lang, "Smeraldo", "Emerald"),
			"sapphire" => T(lang, "Zaffiro", "Sapphire"),
			"amethyst" => T(lang, "Ametista", "Amethyst"),
			_ => T(lang, "Forgia (arancio)", "Forge (orange)")
		};

		public static string Dice3dMaterialName(string material, LanguageCode lang) => material switch
		{
			"metal" => T(lang, "Metallo", "Metal"),
			"wood" => T(lang, "Legno", "Wood"),
			"glass" => T(lang, "Vetro", "Glass"),
			_ => T(lang, "Resina", "Resin")
		};
	}
}
