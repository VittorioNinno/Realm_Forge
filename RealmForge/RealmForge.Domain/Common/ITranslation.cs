using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Common
{
	///	<summary>
	///	Common contract for every localized text row (species, subspecies, traits, feats).
	///	</summary>
	public interface ITranslation
	{
		LanguageCode Language { get; }
		string Name { get; }
		string Description { get; }
	}
}
