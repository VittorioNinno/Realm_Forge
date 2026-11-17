using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the soundboard of the table.</summary>
	public static partial class UiText
	{
		public static string VttToolSounds(LanguageCode lang) => T(lang, "Soundboard", "Soundboard");
		public static string SoundsHint(LanguageCode lang) => T(lang,
			"Link a file audio o stream (https) ospitati altrove: le tracce vanno in loop e restano sincronizzate per tutto il tavolo, gli effetti suonano una volta.",
			"Links to audio files or streams (https) hosted elsewhere: tracks loop and stay in time for the whole table, effects play once.");
		public static string SoundName(LanguageCode lang) => T(lang, "Nome", "Name");
		public static string SoundUrl(LanguageCode lang) => T(lang, "Link audio (https)", "Audio link (https)");
		public static string SoundEffect(LanguageCode lang) => T(lang, "Effetto (una volta)", "Effect (once)");
		public static string SoundVolume(LanguageCode lang) => T(lang, "Volume", "Volume");
		public static string SoundAdd(LanguageCode lang) => T(lang, "Aggiungi suono", "Add sound");
		public static string SoundTracks(LanguageCode lang) => T(lang, "Tracce", "Tracks");
		public static string SoundEffects(LanguageCode lang) => T(lang, "Effetti", "Effects");
		public static string SoundPlay(LanguageCode lang) => T(lang, "Riproduci al tavolo", "Play at the table");
		public static string SoundStop(LanguageCode lang) => T(lang, "Silenzio", "Silence");
		public static string SoundsEmpty(LanguageCode lang) => T(lang, "Nessun suono ancora.", "No sounds yet.");
		public static string SoundInvalid(LanguageCode lang) => T(lang, "Servono un nome e un link https.", "A name and an https link are needed.");
		public static string SoundUnlock(LanguageCode lang) => T(lang, "Attiva l'audio del tavolo", "Turn the table's sound on");
		public static string SoundMute(LanguageCode lang) => T(lang, "Silenzia (solo per te)", "Mute (only for you)");
		public static string SoundUnmute(LanguageCode lang) => T(lang, "Riattiva l'audio", "Sound on");
	}
}
