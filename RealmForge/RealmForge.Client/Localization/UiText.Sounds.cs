using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the soundboard of the table.</summary>
	public static partial class UiText
	{
		public static string VttToolSounds(LanguageCode lang) => T(lang, "Soundboard", "Soundboard");
		public static string SoundsHint(LanguageCode lang) => T(lang,
			"Le tracce vanno in loop e restano sincronizzate per tutto il tavolo; gli effetti suonano una volta.",
			"Tracks loop and stay in time for the whole table; effects play once.");
		public static string SoundName(LanguageCode lang) => T(lang, "Nome (es. Pioggia in taverna)", "Name (e.g. Rain in the tavern)");
		public static string CampaignTabAudio(LanguageCode lang) => T(lang, "Audio", "Audio");
		public static string SoundsKicker(LanguageCode lang) => T(lang, "Audio e suoni", "Audio and sounds");
		public static string SoundsPageHint(LanguageCode lang) => T(lang,
			"Prepara qui tracce, effetti e scene sonore: al tavolo li trovi pronti nella soundboard. L'ascolto da questa pagina resta sul tuo dispositivo.",
			"Prepare tracks, effects and sound scenes here: at the table you find them ready in the soundboard. Listening from this page stays on your device.");
		public static string SoundSourceLink(LanguageCode lang) => T(lang, "Link (https)", "Link (https)");
		public static string SoundSourceFile(LanguageCode lang) => T(lang, "File locale", "Local file");
		public static string SoundFilePick(LanguageCode lang) => T(lang, "Scegli un file audio (.mp3, .ogg, .m4a, .wav)", "Choose an audio file (.mp3, .ogg, .m4a, .wav)");
		public static string SoundFileLimits(string used, string max, LanguageCode lang) => T(lang, $"Fino a 4 MB per file · usati {used} di {max} MB", $"Up to 4 MB a file · {used} of {max} MB used");
		public static string SoundFileTooBig(LanguageCode lang) => T(lang, "Il file supera i 4 MB.", "The file is over 4 MB.");
		public static string SoundFileNoRoom(LanguageCode lang) => T(lang, "I file audio della campagna supererebbero i 30 MB: rimuovine qualcuno.", "The audio files of the campaign would pass 30 MB: remove some first.");
		public static string SoundFileInvalid(LanguageCode lang) => T(lang, "Scegli un file mp3, ogg, m4a o wav e dagli un nome.", "Choose an mp3, ogg, m4a or wav file and give it a name.");
		public static string SoundUploading(LanguageCode lang) => T(lang, "Caricamento…", "Uploading…");
		public static string SoundMode(LanguageCode lang) => T(lang, "Modalità di riproduzione", "Playback mode");
		public static string SoundModeLoop(LanguageCode lang) => T(lang, "Traccia (loop)", "Track (loop)");
		public static string SoundModeOnce(LanguageCode lang) => T(lang, "Effetto (1×)", "Effect (1×)");
		public static string SoundBadgeLoop(LanguageCode lang) => T(lang, "Loop", "Loop");
		public static string SoundBadgeOnce(LanguageCode lang) => T(lang, "Effetto 1×", "Effect 1×");
		public static string SoundFromLink(LanguageCode lang) => T(lang, "Link", "Link");
		public static string SoundFromFile(LanguageCode lang) => T(lang, "File", "File");
		public static string SoundsEmptyTitle(LanguageCode lang) => T(lang, "Nessun suono ancora.", "No sounds yet.");
		public static string SoundTracksCount(int n, LanguageCode lang) => T(lang, n == 1 ? "1 traccia (loop)" : $"{n} tracce (loop)", n == 1 ? "1 track (loop)" : $"{n} tracks (loop)");
		public static string SoundEffectsCount(int n, LanguageCode lang) => T(lang, n == 1 ? "1 effetto (1×)" : $"{n} effetti (1×)", n == 1 ? "1 effect (1×)" : $"{n} effects (1×)");
		public static string SoundAddTitle(LanguageCode lang) => T(lang, "Aggiungi alla soundboard", "Add to the soundboard");
		public static string SoundFilter(string filter, LanguageCode lang) => filter switch
		{
			"loop" => T(lang, "Tracce (loop)", "Tracks (loop)"),
			"once" => T(lang, "Effetti (1×)", "Effects (1×)"),
			_ => T(lang, "Tutti", "All")
		};
		public static string SoundSearch(LanguageCode lang) => T(lang, "Cerca suono…", "Search a sound…");
		public static string SoundStopAll(LanguageCode lang) => T(lang, "Ferma tutto", "Stop all");
		public static string SoundsNoneHere(LanguageCode lang) => T(lang, "Nessun suono con questo filtro.", "No sound with this filter.");
		public static string SoundPreview(LanguageCode lang) => T(lang, "Ascolta qui", "Listen here");
		public static string SoundPreviewStop(LanguageCode lang) => T(lang, "Ferma l'ascolto", "Stop listening");
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
		public static string SoundsEmpty(LanguageCode lang) => T(lang, "Aggiungi un link o carica un file audio per creare la soundboard.", "Add a link or upload an audio file to build the soundboard.");
		public static string SoundInvalid(LanguageCode lang) => T(lang, "Servono un nome e un link https.", "A name and an https link are needed.");
		public static string SoundUnlock(LanguageCode lang) => T(lang, "Attiva l'audio del tavolo", "Turn the table's sound on");
		public static string SoundMute(LanguageCode lang) => T(lang, "Silenzia (solo per te)", "Mute (only for you)");
		public static string SoundUnmute(LanguageCode lang) => T(lang, "Riattiva l'audio", "Sound on");
	}
}
