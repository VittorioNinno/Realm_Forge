using RealmForge.Shared.Enums;

namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	Glossary entry in the list: also everything the client needs to link the term in other descriptions
	///	(the forms of the term in the requested language and a plain-text summary for the tooltip).
	///	</summary>
	public record RuleEntryResponseDto(
		Guid Id,
		string Key,
		string Name,
		RulesetVersion Ruleset,
		RuleCategory Category,
		string Summary,
		List<string> Aliases,
		ContentSource? Source);

	///	<summary>
	///	Link to another glossary entry ("See also").
	///	</summary>
	public record RuleEntryLinkDto(Guid Id, string Key, string Name, RuleCategory Category);

	///	<summary>
	///	Glossary entry with its full Markdown text and the related entries of the same edition.
	///	</summary>
	public record RuleEntryDetailResponseDto(
		Guid Id,
		string Key,
		string Name,
		RulesetVersion Ruleset,
		RuleCategory Category,
		string Description,
		List<RuleEntryLinkDto> Related,
		ContentSource? Source);
}
