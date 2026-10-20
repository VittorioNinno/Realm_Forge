using Microsoft.AspNetCore.Components;
using RealmForge.Client.Pages;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Components.Wizard
{
	///	<summary>
	///	A step of the character wizard: it reads and changes the character through the wizard, which recomputes it.
	///	</summary>
	public abstract class WizardStepBase : ComponentBase
	{
		[Parameter, EditorRequired] public CharacterWizard W { get; set; } = default!;

		protected LanguageCode Lang => W.Lang;
		protected RulesetVersion Ruleset => W.Ruleset;
		protected bool Is2024 => W.Is2024;
		protected CharacterBuild Build => W.Build;
		protected ComputedCharacter Computed => W.Computed;
		protected CharacterContextDto Context => W.Context!;
	}
}
