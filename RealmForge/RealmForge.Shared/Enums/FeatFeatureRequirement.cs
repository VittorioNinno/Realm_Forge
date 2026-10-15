namespace RealmForge.Shared.Enums;

///	<summary>
///	Class feature or training a character must have to take a feat.
///	The displayed wording depends on the ruleset (e.g. 2014 "Proficiency with light armor" vs 2024 "Light Armor Training").
///	</summary>
public enum FeatFeatureRequirement
{
	FightingStyle = 1,
	Spellcasting = 2,
	SpellcastingOrPactMagic = 3,
	LightArmor = 4,
	MediumArmor = 5,
	HeavyArmor = 6,
	Shield = 7
}
