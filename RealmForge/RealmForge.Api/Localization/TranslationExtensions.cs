using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

namespace RealmForge.Api.Localization
{
	public static class TranslationExtensions
	{
		///	<summary>
		///	Single fallback policy for every localized entity:
		///	requested language → English → any available translation.
		///	</summary>
		public static T? Localize<T>(this IEnumerable<T> translations, LanguageCode language)
			where T : class, ITranslation
		{
			var list = translations as IReadOnlyCollection<T> ?? translations.ToList();

			return list.FirstOrDefault(t => t.Language == language)
				?? list.FirstOrDefault(t => t.Language == LanguageCode.En)
				?? list.FirstOrDefault();
		}
	}
}
