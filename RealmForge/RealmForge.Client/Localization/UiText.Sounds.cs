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
		public static string SoundScenes(LanguageCode lang) => T(lang, "Scene sonore", "Sound scenes");
		public static string SoundScenesHint(LanguageCode lang) => T(lang,
			"Una scena avvia insieme una traccia, fino a quattro loop d'ambiente (pioggia, folla, fuoco) e un effetto iniziale; collegata a una mappa, parte quando la mostri ai giocatori.",
			"A scene starts a track, up to four ambience loops (rain, crowd, fire) and an opening effect together; tied to a map, it starts when you show that map to the players.");
		public static string SoundSceneNew(LanguageCode lang) => T(lang, "Nuova scena", "New scene");
		public static string SoundSceneName(LanguageCode lang) => T(lang, "Nome della scena (es. Taverna sotto la pioggia)", "Scene name (e.g. Tavern in the rain)");
		public static string SoundSceneNone(LanguageCode lang) => T(lang, "Nessuna", "None");
		public static string SoundSceneLayers(int max, LanguageCode lang) => T(lang, $"Loop d'ambiente (fino a {max})", $"Ambience loops (up to {max})");
		public static string SoundSceneCue(LanguageCode lang) => T(lang, "Effetto all'avvio", "Effect at the start");
		public static string SoundSceneOnMap(LanguageCode lang) => T(lang, "Avvia quando mostro questa mappa", "Start when I show this map");
		public static string SoundSceneMapLinked(LanguageCode lang) => T(lang, "Parte con la sua mappa", "Starts with its map");
		public static string SoundScenePlay(LanguageCode lang) => T(lang, "Avvia la scena per tutti", "Start the scene for everyone");
		public static string SoundSceneInvalid(LanguageCode lang) => T(lang, "Dai un nome alla scena e scegli almeno un suono.", "Name the scene and pick at least one sound.");
		public static string SoundSceneSummary(bool track, int loops, bool cue, LanguageCode lang)
		{
			var parts = new List<string>();
			if (track)
			{
				parts.Add(T(lang, "traccia", "track"));
			}
			if (loops > 0)
			{
				parts.Add(T(lang, $"{loops} loop", loops == 1 ? "1 loop" : $"{loops} loops"));
			}
			if (cue)
			{
				parts.Add(T(lang, "effetto", "effect"));
			}
			return string.Join(" + ", parts);
		}
		public static string SoundPlay(LanguageCode lang) => T(lang, "Riproduci al tavolo", "Play at the table");
		public static string SoundStop(LanguageCode lang) => T(lang, "Silenzio", "Silence");
		public static string SoundsEmpty(LanguageCode lang) => T(lang, "Nessun suono ancora.", "No sounds yet.");
		public static string SoundInvalid(LanguageCode lang) => T(lang, "Servono un nome e un link https.", "A name and an https link are needed.");
		public static string SoundUnlock(LanguageCode lang) => T(lang, "Attiva l'audio del tavolo", "Turn the table's sound on");
		public static string SoundMute(LanguageCode lang) => T(lang, "Silenzia (solo per te)", "Mute (only for you)");
		public static string SoundUnmute(LanguageCode lang) => T(lang, "Riattiva l'audio", "Sound on");
	}
}
