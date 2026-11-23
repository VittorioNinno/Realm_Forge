using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the visual effects.</summary>
	public static partial class UiText
	{
		public static string FxTitle(LanguageCode lang) => T(lang, "Effetti visivi", "Visual effects");
		public static string FxHint(LanguageCode lang) => T(lang,
			"Particelle sui colpi nel colore del tipo di danno, aree degli incantesimi che si accendono, critici dorati, coriandoli a ogni livello. Valgono per questo dispositivo.",
			"Particles on hits in the colour of their damage type, spell areas lighting up, golden criticals, confetti at every level. They apply to this device.");
		public static string FxLevel(string level, LanguageCode lang) => level switch
		{
			"reduced" => T(lang, "Ridotti", "Reduced"),
			"off" => T(lang, "Spenti", "Off"),
			_ => T(lang, "Completi", "Full")
		};
		public static string FxPreviewName(string kind, LanguageCode lang) => kind switch
		{
			"fire" => T(lang, "Fuoco", "Fire"),
			"cold" => T(lang, "Freddo", "Cold"),
			"lightning" => T(lang, "Fulmine", "Lightning"),
			"necrotic" => T(lang, "Necrotico", "Necrotic"),
			"radiant" => T(lang, "Radioso", "Radiant"),
			"heal" => T(lang, "Cura", "Healing"),
			_ => T(lang, "Critico", "Critical")
		};
	}
}
