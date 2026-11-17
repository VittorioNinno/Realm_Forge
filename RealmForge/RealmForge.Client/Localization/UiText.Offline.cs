using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the app installed and used offline.</summary>
	public static partial class UiText
	{
		public static string SheetSavedOffline(LanguageCode lang) => T(lang, "Offline: salvato sul dispositivo, verrà inviato appena torni online", "Offline: saved on the device, sent as soon as you are back online");
	}
}
