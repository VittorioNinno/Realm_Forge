using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Name and id of a Base entry, used to link it from the texts of the other modules.
	///	</summary>
	public record CompendiumIndexEntryDto(Guid Id, string Name, RulesetVersion Ruleset);

	///	<summary>
	///	A Base class with the spell list it uses (null for classes without spells) and its key ("barbarian", "wizard"…).
	///	</summary>
	public record CompendiumClassDto(Guid Id, string Name, RulesetVersion Ruleset, SpellcastingClass? SpellList, string? Key = null);

	///	<summary>
	///	Names of the Base spells, equipment and classes of both editions in one language.
	///	</summary>
	public record CompendiumIndexDto(
		List<CompendiumIndexEntryDto> Spells,
		List<CompendiumIndexEntryDto> Equipment,
		List<CompendiumClassDto> Classes);
}
