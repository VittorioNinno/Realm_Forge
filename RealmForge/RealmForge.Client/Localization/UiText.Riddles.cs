using RealmForge.Shared.Enums;
using RealmForge.Shared.Puzzles;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the riddles lab and of the riddles in the handouts.</summary>
	public static partial class UiText
	{
		public static string RiddleLab(LanguageCode lang) => T(lang, "Enigma e cifrari", "Riddle and ciphers");
		public static string RiddleAnswer(LanguageCode lang) => T(lang, "Soluzione", "Answer");
		public static string RiddleAnswerHint(LanguageCode lang) => T(lang, "Le risposte accettate, separate da | (vuoto: nessun enigma)", "The accepted answers, split by | (empty: no riddle)");
		public static string RiddleDoor(LanguageCode lang) => T(lang, "Apre la porta", "Opens the door");
		public static string RiddleNoDoor(LanguageCode lang) => T(lang, "Nessuna", "None");
		public static string RiddleCipher(LanguageCode lang) => T(lang, "Cifrario", "Cipher");
		public static string RiddleShift(LanguageCode lang) => T(lang, "Spostamento (es. 3)", "Shift (e.g. 3)");
		public static string RiddleKeyword(LanguageCode lang) => T(lang, "Parola chiave", "Keyword");
		public static string RiddlePlain(LanguageCode lang) => T(lang, "Il messaggio in chiaro", "The plain message");
		public static string RiddleInsert(LanguageCode lang) => T(lang, "Inserisci nel testo", "Add to the text");
		public static string RiddleUseAnswer(LanguageCode lang) => T(lang, "Usa il messaggio come soluzione", "Use the message as the answer");
		public static string RiddleCatalog(LanguageCode lang) => T(lang, "Catalogo di enigmi ambientali", "Catalogue of environmental riddles");
		public static string RiddleHintsFor(LanguageCode lang) => T(lang, "Indizi per chi supera la prova (solo per te):", "Hints for whoever passes the check (for you only):");
		public static string RiddleUse(LanguageCode lang) => T(lang, "Usa questo enigma", "Use this riddle");
		public static string RiddleYourAnswer(LanguageCode lang) => T(lang, "La vostra risposta…", "Your answer…");
		public static string RiddleTry(LanguageCode lang) => T(lang, "Prova", "Try");
		public static string RiddleWrong(LanguageCode lang) => T(lang, "Non succede nulla. Non è la risposta giusta.", "Nothing happens. That is not the answer.");
		public static string RiddleSolved(string? by, LanguageCode lang) => by is { Length: > 0 }
			? T(lang, $"Enigma risolto da {by}.", $"Riddle solved by {by}.")
			: T(lang, "Enigma risolto.", "Riddle solved.");
		public static string RiddleDoorOpened(LanguageCode lang) => T(lang, "Una porta si apre sulla mappa.", "A door opens on the map.");
		public static string CipherName(CipherKind kind, LanguageCode lang) => kind switch
		{
			CipherKind.Caesar => T(lang, "Cesare (spostamento)", "Caesar (shift)"),
			CipherKind.Vigenere => T(lang, "Vigenère (parola chiave)", "Vigenère (keyword)"),
			CipherKind.Atbash => T(lang, "Atbash (alfabeto rovesciato)", "Atbash (reversed alphabet)"),
			CipherKind.Runes => T(lang, "Rune", "Runes"),
			CipherKind.Draconic => T(lang, "Draconico", "Draconic"),
			_ => T(lang, "Numeri (A=1 … Z=26)", "Numbers (A=1 … Z=26)")
		};
	}
}
