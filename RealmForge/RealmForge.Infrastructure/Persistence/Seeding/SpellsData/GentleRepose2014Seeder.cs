using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Gentle Repose (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GentleRepose2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gentle-repose");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gentle-repose", "en"),
					Language = LanguageCode.En,
					Name = "Gentle Repose",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "10 days",
					MaterialComponent = "a pinch of salt and one copper piece placed on each of the corpse's eyes, which must remain there for the duration",
					Description = "You touch a corpse or other remains. For the duration, the target is protected from decay and can't become undead.\n\nThe spell also effectively extends the time limit on raising the target from the dead, since days spent under the influence of this spell don't count against the time limit of spells such as raise dead.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gentle-repose", "it"),
					Language = LanguageCode.It,
					Name = "Riposo Inviolato",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "10 giorni",
					MaterialComponent = "un pizzico di sale e una moneta di rame posata su ciascun occhio del cadavere, che deve restarvi per la durata",
					Description = "L'incantatore tocca un cadavere o altri resti. Per la durata, il bersaglio è protetto dalla decomposizione e non può diventare un non morto.\n\nL'incantesimo estende di fatto anche il limite di tempo entro cui è possibile riportare in vita il bersaglio, dato che i giorni trascorsi sotto l'effetto di questo incantesimo non vengono conteggiati ai fini del limite di tempo di incantesimi come rianimare morti.",
					HigherLevels = null
				}
			}
		};
	}
}
