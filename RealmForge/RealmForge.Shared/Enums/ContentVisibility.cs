namespace RealmForge.Shared.Enums;

///	<summary>
///	Who can see a Homebrew entry. Public is 0 so rows created before this setting existed stay visible.
///	Base content is always public.
///	</summary>
public enum ContentVisibility
{
	Public = 0,		//	listed for everyone
	Link = 1,		//	readable by anyone with the link, not listed
	Private = 2		//	only the author (and administrators)
}
