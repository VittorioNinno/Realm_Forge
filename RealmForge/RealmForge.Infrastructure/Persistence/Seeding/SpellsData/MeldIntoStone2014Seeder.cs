using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Meld Into Stone (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MeldIntoStone2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "meld-into-stone");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "meld-into-stone", "en"),
					Language = LanguageCode.En,
					Name = "Meld Into Stone",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "8 hours",
					MaterialComponent = null,
					Description = "You step into a stone object or surface large enough to fully contain your body, melding yourself and all the equipment you carry with the stone for the duration. Using your movement, you step into the stone at a point you can touch. Nothing of your presence remains visible or otherwise detectable by nonmagical senses.\n\nWhile merged with the stone, you can't see what occurs outside it, and any Wisdom (Perception) checks you make to hear sounds outside it are made with disadvantage. You remain aware of the passage of time and can cast spells on yourself while merged in the stone. You can use your movement to leave the stone where you entered it, which ends the spell. You otherwise can't move.\n\nMinor physical damage to the stone doesn't harm you, but its partial destruction or a change in its shape (to the extent that you no longer fit within it) expels you and deals 6d6 bludgeoning damage to you. The stone's complete destruction (or transmutation into a different substance) expels you and deals 50 bludgeoning damage to you. If expelled, you fall prone in an unoccupied space closest to where you first entered.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "meld-into-stone", "it"),
					Language = LanguageCode.It,
					Name = "Fondersi nella Pietra",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "8 ore",
					MaterialComponent = null,
					Description = "L'incantatore entra in un oggetto o in una superficie di pietra abbastanza grande da contenere completamente il suo corpo, fondendo sé stesso e tutto l'equipaggiamento che trasporta con la pietra per la durata. Usando il proprio movimento, entra nella pietra in un punto che è in grado di toccare. Nulla della sua presenza rimane visibile o individuabile in altro modo con sensi non magici.\n\nFinché è fuso con la pietra, l'incantatore non può vedere ciò che accade all'esterno, e qualsiasi prova di Saggezza (Percezione) effettuata per sentire i suoni all'esterno subisce svantaggio. Rimane consapevole del trascorrere del tempo e può lanciare incantesimi su di sé mentre è fuso con la pietra. Può usare il proprio movimento per uscire dalla pietra nel punto in cui vi è entrato, ponendo fine all'incantesimo. Altrimenti, non può muoversi.\n\nLievi danni fisici alla pietra non feriscono l'incantatore, ma la sua distruzione parziale o un cambiamento della sua forma (tale che l'incantatore non vi sia più contenuto) lo espelle e gli infligge 6d6 danni contundenti. La distruzione completa della pietra (o la sua trasmutazione in una sostanza diversa) lo espelle e gli infligge 50 danni contundenti. Se viene espulso, l'incantatore cade prono in uno spazio libero il più vicino possibile al punto in cui era entrato.",
					HigherLevels = null
				}
			}
		};
	}
}
