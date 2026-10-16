namespace RealmForge.Shared.Enums;

///	<summary>
///	Where the text of a base (platform) content entry comes from. Homebrew has no source.
///	</summary>
public enum ContentSource
{
	//	Text written for RealmForge
	RealmForge = 1,

	//	Text from the System Reference Document 5.1 (CC BY 4.0)
	Srd51 = 2,

	//	Text from the System Reference Document 5.2 (CC BY 4.0)
	Srd52 = 3
}
