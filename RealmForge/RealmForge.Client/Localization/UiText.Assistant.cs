using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the background assistant of the wizard.</summary>
	public static partial class UiText
	{
		public static string BgAssistant(LanguageCode lang) => T(lang, "Assistente del passato", "Backstory assistant");
		public static string BgAssistantHint(LanguageCode lang) => T(lang,
			"Tre idee per il passato del personaggio, pensate per la sua classe, il suo allineamento e il suo background: scegline una e modificala nei Dettagli.",
			"Three ideas for the character's past, shaped by class, alignment and background: pick one and edit it in Details.");
		public static string BgAssistantPropose(LanguageCode lang) => T(lang, "Proponi 3 idee", "Suggest 3 ideas");
		public static string BgAssistantAgain(LanguageCode lang) => T(lang, "Altre 3 idee", "3 more ideas");
		public static string BgAssistantUse(LanguageCode lang) => T(lang, "Usa questa", "Use this one");
		public static string BgAssistantUsed(LanguageCode lang) => T(lang, "Scelta", "Chosen");

		//	The conversation
		public static string BgChatHint(LanguageCode lang) => T(lang,
			"Scrivi i tuoi spunti (un luogo, una persona, un torto subito…): l'assistente li arricchisce e ti fa una domanda, e si va avanti così. Ogni risposta può finire nella storia del personaggio.",
			"Write your ideas (a place, a person, a wrong suffered…): the assistant enriches them and asks you a question, and so on. Any answer can go into the character's story.");
		public static string BgEngineRules(LanguageCode lang) => T(lang, "Assistente semplice", "Simple assistant");
		public static string BgEngineRulesHint(LanguageCode lang) => T(lang,
			"Questo dispositivo non supporta l'assistente avanzato (serve WebGPU): risponde la versione a tabelle, sempre disponibile.",
			"This device does not support the advanced assistant (WebGPU is needed): the table-based version answers, always available.");
		public static string BgEngineDownload(int sizeMb, LanguageCode lang) => T(lang,
			$"Scarica l'assistente avanzato (~{sizeMb / 1000.0:0.#} GB)", $"Download the advanced assistant (~{sizeMb / 1000.0:0.#} GB)");
		public static string BgEngineDownloadHint(LanguageCode lang) => T(lang,
			"Un modello linguistico che gira nel tuo browser: si scarica una volta sola, poi funziona senza limiti, senza costi e senza inviare nulla a nessuno.",
			"A language model that runs in your browser: downloaded only once, then it works without limits, without costs and without sending anything anywhere.");
		public static string BgEngineLoading(int percent, LanguageCode lang) => T(lang, $"Preparo l'assistente avanzato… {percent}%", $"Preparing the advanced assistant… {percent}%");
		public static string BgEngineReady(LanguageCode lang) => T(lang, "Assistente avanzato pronto (nel tuo browser)", "Advanced assistant ready (in your browser)");
		public static string BgEngineRemove(LanguageCode lang) => T(lang, "Libera spazio", "Free up space");
		public static string BgEngineFailed(LanguageCode lang) => T(lang, "L'assistente avanzato non è partito: risponde quello semplice.", "The advanced assistant did not start: the simple one answers.");
		public static string BgChatEmpty(LanguageCode lang) => T(lang,
			"Per cominciare: da dove viene il personaggio? Chi ha lasciato indietro? Cosa non si è mai perdonato?",
			"To start: where does the character come from? Who did they leave behind? What have they never forgiven themselves for?");
		public static string BgChatPlaceholder(LanguageCode lang) => T(lang, "Il tuo spunto… (es. mio fratello Aldric è sparito nella foresta di Morvenna)", "Your idea… (e.g. my brother Aldric vanished in the Morvenna woods)");
		public static string BgChatInspire(LanguageCode lang) => T(lang, "Ispirami", "Inspire me");
		public static string BgChatInspireHint(LanguageCode lang) => T(lang, "Uno spunto casuale da modificare prima di inviarlo", "A random idea to edit before sending it");
		public static string BgChatSend(LanguageCode lang) => T(lang, "Invia", "Send");
		public static string BgChatStop(LanguageCode lang) => T(lang, "Ferma", "Stop");
		public static string BgChatAddToStory(LanguageCode lang) => T(lang, "Aggiungi alla storia", "Add to the story");
		public static string BgChatAdded(LanguageCode lang) => T(lang, "Aggiunto alla storia: lo trovi nel passo Dettagli.", "Added to the story: you will find it in the Details step.");
		public static string BgChatFill(LanguageCode lang) => T(lang, "Compila tratti, ideali, legami e difetti", "Fill traits, ideals, bonds and flaws");
		public static string BgChatFilled(LanguageCode lang) => T(lang, "Personalità compilata: puoi modificarla nel passo Dettagli.", "Personality filled: you can edit it in the Details step.");
		public static string BgChatRestart(LanguageCode lang) => T(lang, "Ricomincia la conversazione", "Start the conversation over");
	}
}
