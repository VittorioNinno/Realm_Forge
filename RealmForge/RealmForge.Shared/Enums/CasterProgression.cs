namespace RealmForge.Shared.Enums;

///	<summary>
///	How a class (or a subclass that grants spellcasting) gains spell slots: full casters (wizard), half casters
///	(paladin), third casters (eldritch knight) or the warlock's Pact Magic.
///	</summary>
public enum CasterProgression
{
	None = 0,
	Full = 1,
	Half = 2,
	Third = 3,
	Pact = 4
}
