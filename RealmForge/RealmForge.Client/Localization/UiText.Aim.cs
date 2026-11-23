using RealmForge.Shared.Enums;

namespace RealmForge.Client.Localization
{
	///	<summary>Texts of the aiming on the table: distance, range, cover, and a second spell with concentration.</summary>
	public static partial class UiText
	{
		public static string VttAimDistance(string distance, LanguageCode lang) => T(lang, $"Distanza {distance}", $"Distance {distance}");
		public static string VttAimOut(LanguageCode lang) => T(lang, "fuori portata", "out of reach");
		public static string VttAimOutHint(LanguageCode lang) => T(lang, "troppo lontano per questo attacco", "too far for this attack");
		public static string VttAimLong(LanguageCode lang) => T(lang, "gittata lunga", "long range");
		public static string VttAimLongHint(LanguageCode lang) => T(lang, "gittata lunga: tiro con svantaggio", "long range: the roll has disadvantage");
		public static string VttAimCover(int cover, LanguageCode lang) => cover >= 5 ? T(lang, "copertura ¾", "¾ cover") : T(lang, "copertura ½", "½ cover");
		public static string VttAimCoverHint(int cover, LanguageCode lang) => cover >= 5
			? T(lang, "copertura tre quarti: +5 alla CA e ai TS di Destrezza", "three-quarters cover: +5 to AC and Dexterity saves")
			: T(lang, "mezza copertura: +2 alla CA e ai TS di Destrezza", "half cover: +2 to AC and Dexterity saves");
		public static string VttAimCoverTotal(LanguageCode lang) => T(lang, "copertura totale", "total cover");
		public static string VttAimCoverTotalHint(LanguageCode lang) => T(lang, "dietro un muro o una porta chiusa: non può essere bersagliato", "behind a wall or a closed door: it cannot be targeted");

		public static string VttConcentrationAsk(string caster, string? previous, LanguageCode lang) => previous is { Length: > 0 }
			? T(lang, $"{caster} mantiene già «{previous}»: lanciando questo incantesimo la concentrazione su quello termina (e con essa la sua aura).",
				$"{caster} already holds “{previous}”: casting this spell ends the concentration on it (and its aura).")
			: T(lang, $"{caster} sta già mantenendo la concentrazione su un incantesimo: lanciando questo, il precedente termina.",
				$"{caster} is already concentrating on a spell: casting this one ends the previous one.");
		public static string VttConcentrationYes(LanguageCode lang) => T(lang, "Lancia comunque", "Cast anyway");
	}
}
