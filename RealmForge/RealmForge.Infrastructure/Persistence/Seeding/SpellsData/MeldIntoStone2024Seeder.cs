using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Meld into Stone (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MeldIntoStone2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "meld-into-stone");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "meld-into-stone", "en"),
					Language = LanguageCode.En,
					Name = "Meld into Stone",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = null,
					Description = "You step into a stone object or surface large enough to fully contain your body, merging yourself and your equipment with the stone for the duration. You must touch the stone to do so. Nothing of your presence remains visible or otherwise detectable by nonmagical senses.\n\nWhile merged with the stone, you can't see what occurs outside it, and any Wisdom (Perception) checks you make to hear sounds outside it are made with Disadvantage. You remain aware of the passage of time and can cast spells on yourself while merged in the stone. You can use 5 feet of movement to leave the stone where you entered it, which ends the spell. You otherwise can't move.\n\nMinor physical damage to the stone doesn't harm you, but its partial destruction or a change in its shape (to the extent that you no longer fit within it) expels you and deals 6d6 Force damage to you. The stone's complete destruction (or transmutation into a different substance) expels you and deals 50 Force damage to you. If expelled, you move into an unoccupied space closest to where you first entered and have the Prone condition.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "meld-into-stone", "it"),
					Language = LanguageCode.It,
					Name = "Fondersi nella Pietra",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = null,
					Description = "L'incantatore entra in un oggetto o in una superficie di pietra abbastanza grande da contenere completamente il suo corpo, fondendo sé stesso e il proprio equipaggiamento con la pietra per la durata. Per farlo, deve toccare la pietra. Nulla della sua presenza resta visibile o rilevabile in altro modo con i sensi non magici.\n\nFinché è fuso con la pietra, l'incantatore non può vedere ciò che accade all'esterno e qualsiasi prova di Saggezza (Percezione) che effettua per sentire i suoni all'esterno subisce svantaggio. Resta consapevole del trascorrere del tempo e può lanciare incantesimi su di sé mentre è fuso nella pietra. Può usare 1,5 metri di movimento per uscire dalla pietra dal punto in cui è entrato, ponendo fine all'incantesimo. Altrimenti, non può muoversi.\n\nDanni fisici di lieve entità alla pietra non lo danneggiano, ma la sua distruzione parziale o un cambiamento della sua forma (al punto che l'incantatore non vi entra più) lo espellono e gli infliggono 6d6 danni da forza. La distruzione completa della pietra (o la sua trasmutazione in una sostanza diversa) lo espelle e gli infligge 50 danni da forza. Se viene espulso, l'incantatore si sposta nello spazio libero più vicino al punto in cui era entrato e cade prono.",
					HigherLevels = null
				}
			}
		};
	}
}
