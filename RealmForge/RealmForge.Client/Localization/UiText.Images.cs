using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	public static partial class UiText
	{
		public static string ImagesTitle(LanguageCode lang) => T(lang, "Immagini", "Images");
		public static string ImagesSubtitle(LanguageCode lang) => T(lang, "Ritratti per segnalini, mostri e PNG", "Portraits for tokens, monsters and NPCs");
		public static string ImagesSignIn(LanguageCode lang) => T(lang, "Accedi per caricare le tue immagini.", "Sign in to upload your images.");
		public static string ImagesEmpty(LanguageCode lang) => T(lang,
			"Nessuna immagine. Caricane una: la puoi usare per i segnalini del tavolo virtuale e come ritratto di un mostro o di un PNG.",
			"No images. Upload one: use it for the tokens of the virtual tabletop and as the portrait of a monster or an NPC.");
		public static string ImageUpload(LanguageCode lang) => T(lang, "Carica immagini", "Upload images");
		public static string ImageName(LanguageCode lang) => T(lang, "Nome", "Name");
		public static string ImageNone(LanguageCode lang) => T(lang, "Nessuna", "None");
		public static string ImageTooLarge(LanguageCode lang) => T(lang, "Immagine non caricata: usa un JPEG, PNG o WebP.", "Image not uploaded: use a JPEG, PNG or WebP.");
		public static string ImageAssign(LanguageCode lang) => T(lang, "Usala per un mostro o un PNG…", "Use it for a monster or an NPC…");
		public static string ImagePick(LanguageCode lang) => T(lang, "Immagine", "Image");
		public static string ToolArt(LanguageCode lang) => T(lang, "Immagine", "Art");
	}
}
