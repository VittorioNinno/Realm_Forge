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
		public static string Dice3dOthers(LanguageCode lang) => T(lang, "I dadi degli altri giocatori al tavolo, nel loro colore", "The dice of the other players at the table, in their colour");
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
			"frost" => T(lang, "Brina eterna", "Everfrost"),
			"storm" => T(lang, "Cuore di tempesta", "Stormheart"),
			"bone" => T(lang, "Ossa del negromante", "Necromancer's bones"),
			"hoard" => T(lang, "Tesoro del drago", "Dragon's hoard"),
			"abyss" => T(lang, "Occhio dell'abisso", "Eye of the abyss"),
			"fey" => T(lang, "Bosco fatato", "Feywood"),
			"acid" => T(lang, "Ampolla d'acido", "Acid flask"),
			"arcane" => T(lang, "Runa arcana", "Arcane rune"),
			"dawn" => T(lang, "Raggio d'alba", "Dawnbeam"),
			"tide" => T(lang, "Marea profonda", "Deep tide"),
			_ => T(lang, "Resina", "Resin")
		};
		public static string Dice3dSkinHint(string skin, LanguageCode lang) => skin switch
		{
			"ember" => T(lang, "Pietra lavica che pulsa: con un 20 naturale un anello di fiamme e una pioggia di braci", "Pulsing lava stone: on a natural 20, a ring of flames and a shower of embers"),
			"stardust" => T(lang, "Vetro notturno che scintilla: con un 20 naturale si accende il Grande Carro tra luci che scoppiettano e una stella cadente colpisce il dado", "Twinkling night glass: on a natural 20 the Plough lights up among crackling lights and a falling star strikes the die"),
			"frost" => T(lang, "Ghiaccio con brina che luccica: con un 20 naturale un fiocco di neve si allarga sul tavolo", "Shimmering rime ice: on a natural 20 a snowflake spreads over the table"),
			"storm" => T(lang, "Ardesia percorsa da lampi: con un 20 naturale una scarica di fulmini", "Slate run through with lightning: on a natural 20, a storm of bolts"),
			"bone" => T(lang, "Avorio crepato con rune verdi che respirano: con un 20 naturale spiriti verdi", "Cracked ivory with breathing green runes: on a natural 20, green wisps"),
			"hoard" => T(lang, "Oro martellato a scaglie che brilla: con un 20 naturale una pioggia di monete", "Scaled hammered gold that glints: on a natural 20, a rain of coins"),
			"abyss" => T(lang, "Nero con un vortice viola: con un 20 naturale tutto viene risucchiato e scagliato via", "Black with a violet whirl: on a natural 20 everything is drawn in and hurled out"),
			"fey" => T(lang, "Legno vivo con muschio e piccole luci: con un 20 naturale rampicanti in fiore e lucciole", "Living wood with moss and tiny lights: on a natural 20, flowering vines and fireflies"),
			"acid" => T(lang, "Vetro verde pieno di bolle: con un 20 naturale schizzi d'acido", "Green glass full of bubbles: on a natural 20, splashes of acid"),
			"arcane" => T(lang, "Cristallo indaco con cerchi di rune d'oro: con un 20 naturale un cerchio magico", "Indigo crystal with circles of golden runes: on a natural 20, a magic circle"),
			"dawn" => T(lang, "Perla e oro con venature di luce: con un 20 naturale raggi d'alba e anelli di luce", "Pearl and gold veined with light: on a natural 20, rays of dawn and rings of light"),
			"tide" => T(lang, "Acqua profonda con riflessi di superficie: con un 20 naturale onde e una corona di gocce", "Deep water with the light of the surface on it: on a natural 20, waves and a crown of drops"),
			_ => T(lang, "Resina classica, nel colore che preferisci", "Classic resin, in the colour you like")
		};
		public static string Dice3dSkinLocked(LanguageCode lang) => T(lang, "Dadi segreti: si sbloccano con un codice", "Secret dice: a code unlocks them");
		public static string Dice3dOn(LanguageCode lang) => T(lang, "Attivi", "On");
		public static string Dice3dOff(LanguageCode lang) => T(lang, "Spenti", "Off");
		public static string Dice3dSelected(LanguageCode lang) => T(lang, "Set selezionato", "Selected set");
		public static string Dice3dCritTest(LanguageCode lang) => T(lang, "Prova un critico", "Try a critical");
		public static string Dice3dCritHint(LanguageCode lang) => T(lang, "Un d20 che cade sul 20: l'effetto del dado con un 20 naturale (con un 1 naturale la luce si spegne)", "A d20 landing on 20: the die's effect on a natural 20 (on a natural 1 the light dies)");
		public static string Dice3dPreparing(LanguageCode lang) => T(lang, "Preparazione…", "Preparing…");
		public static string Dice3dPreparingHint(LanguageCode lang) => T(lang, "Preparo i nuovi dadi: i lanci partono appena sono pronti.", "Preparing the new dice: the throws start as soon as they are ready.");
		public static string Dice3dSearch(LanguageCode lang) => T(lang, "Cerca un set…", "Search a set…");
		public static string Dice3dSecretCode(LanguageCode lang) => T(lang, "Codice segreto", "Secret code");
		public static string Dice3dCustomShort(LanguageCode lang) => T(lang, "Personalizzato", "Custom");
		public static string Dice3dCustomPick(LanguageCode lang) => T(lang, "Scegli un colore", "Pick a colour");
		public static string Dice3dNone(LanguageCode lang) => T(lang, "Nessun set con questo nome.", "No set by that name.");
		public static string Dice3dSoundHint(LanguageCode lang) => T(lang, "Rotolamenti e rimbalzi sul tavolo", "Rolling and bouncing on the table");
		public static string Dice3dOthersShort(LanguageCode lang) => T(lang, "Lanci degli altri", "The others' rolls");
		public static string Dice3dCategoryResin(LanguageCode lang) => T(lang, "Resina", "Resin");
		public static string Dice3dCategorySpecial(LanguageCode lang) => T(lang, "Speciale", "Special");
		public static string Dice3dCategorySecret(LanguageCode lang) => T(lang, "Segreto", "Secret");
		public static string Dice3dFilterAll(LanguageCode lang) => T(lang, "Tutti", "All");
		public static string Dice3dFilterResin(LanguageCode lang) => T(lang, "Resina", "Resin");
		public static string Dice3dFilterSpecial(LanguageCode lang) => T(lang, "Speciali", "Special");
		public static string Dice3dFilterSecret(LanguageCode lang) => T(lang, "Segreti", "Secret");
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
