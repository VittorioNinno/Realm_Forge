using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Gentle Repose (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GentleRepose2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gentle-repose");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gentle-repose", "en"),
					Language = LanguageCode.En,
					Name = "Gentle Repose",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "10 days",
					MaterialComponent = "2 Copper Pieces, which the spell consumes",
					Description = "You touch a corpse or other remains. For the duration, the target is protected from decay and can't become Undead.\n\nThe spell also effectively extends the time limit on raising the target from the dead, since days spent under the influence of this spell don't count against the time limit of spells such as *Raise Dead*.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gentle-repose", "it"),
					Language = LanguageCode.It,
					Name = "Riposo Inviolato",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "10 giorni",
					MaterialComponent = "2 monete di rame, che l'incantesimo consuma",
					Description = "L'incantatore tocca un cadavere o altri resti. Per la durata, il bersaglio è protetto dalla decomposizione e non può diventare un non morto.\n\nL'incantesimo estende inoltre, di fatto, il limite di tempo entro cui il bersaglio può essere riportato in vita, poiché i giorni trascorsi sotto l'influenza di questo incantesimo non vengono conteggiati nel limite di tempo di incantesimi come *rianimare morti*.",
					HigherLevels = null
				}
			}
		};
	}
}
