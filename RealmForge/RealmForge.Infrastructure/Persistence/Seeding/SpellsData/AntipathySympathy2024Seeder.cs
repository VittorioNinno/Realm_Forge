using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Antipathy/Sympathy (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AntipathySympathy2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "antipathy-sympathy");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "antipathy-sympathy", "en"),
					Language = LanguageCode.En,
					Name = "Antipathy/Sympathy",
					CastingTime = "1 hour",
					Range = "60 feet",
					Duration = "10 days",
					MaterialComponent = "a mix of vinegar and honey",
					Description = "As you cast the spell, choose whether it creates antipathy or sympathy, and target one creature or object that is Huge or smaller. Then specify a kind of creature, such as red dragons, goblins, or vampires. A creature of the chosen kind makes a Wisdom saving throw when it comes within 120 feet of the target. Your choice of antipathy or sympathy determines what happens to a creature when it fails that save:\n\n**Antipathy.** The creature has the Frightened condition. The Frightened creature must use its movement on its turns to get as far away as possible from the target, moving by the safest route.\n\n**Sympathy.** The creature has the Charmed condition. The Charmed creature must use its movement on its turns to get as close as possible to the target, moving by the safest route. If the creature is within 5 feet of the target, the creature can't willingly move away. If the target damages the Charmed creature, that creature can make a Wisdom saving throw to end the effect, as described below.\n\n***Ending the Effect.*** If the Frightened or Charmed creature ends its turn more than 120 feet away from the target, the creature makes a Wisdom saving throw. On a successful save, the creature is no longer affected by the target. A creature that successfully saves against this effect is immune to it for 1 minute, after which it can be affected again.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "antipathy-sympathy", "it"),
					Language = LanguageCode.It,
					Name = "Antipatia/Simpatia",
					CastingTime = "1 ora",
					Range = "18 metri",
					Duration = "10 giorni",
					MaterialComponent = "un miscuglio di aceto e miele",
					Description = "Quando lancia l'incantesimo, l'incantatore sceglie se crea antipatia o simpatia e prende come bersaglio una creatura o un oggetto di taglia Enorme o inferiore. Poi specifica un tipo di creatura, come draghi rossi, goblin o vampiri. Una creatura del tipo scelto effettua un tiro salvezza su Saggezza quando arriva entro 36 metri dal bersaglio. La scelta tra antipatia e simpatia determina cosa succede a una creatura che fallisce il tiro salvezza:\n\n**Antipatia.** La creatura è spaventata. La creatura spaventata deve usare il proprio movimento nei suoi turni per allontanarsi il più possibile dal bersaglio, seguendo il percorso più sicuro.\n\n**Simpatia.** La creatura è affascinata. La creatura affascinata deve usare il proprio movimento nei suoi turni per avvicinarsi il più possibile al bersaglio, seguendo il percorso più sicuro. Se la creatura si trova entro 1,5 metri dal bersaglio, non può allontanarsene volontariamente. Se il bersaglio infligge danni alla creatura affascinata, quella creatura può effettuare un tiro salvezza su Saggezza per porre fine all'effetto, come descritto sotto.\n\n***Fine dell'Effetto.*** Se la creatura spaventata o affascinata termina il proprio turno a più di 36 metri dal bersaglio, effettua un tiro salvezza su Saggezza. Se lo supera, la creatura non è più influenzata dal bersaglio. Una creatura che supera il tiro salvezza contro questo effetto ne è immune per 1 minuto, dopodiché può esserne influenzata di nuovo.",
					HigherLevels = null
				}
			}
		};
	}
}
