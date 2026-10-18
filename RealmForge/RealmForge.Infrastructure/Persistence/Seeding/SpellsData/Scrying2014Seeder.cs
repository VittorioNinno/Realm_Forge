using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Scrying (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Scrying2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "scrying");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "scrying", "en"),
					Language = LanguageCode.En,
					Name = "Scrying",
					CastingTime = "10 minutes",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a focus worth at least 1,000 gp, such as a crystal ball, a silver mirror, or a font filled with holy water",
					Description = "You can see and hear a particular creature you choose that is on the same plane of existence as you. The target must make a Wisdom saving throw, which is modified by how well you know the target and the sort of physical connection you have to it. If a target knows you're casting this spell, it can fail the saving throw voluntarily if it wants to be observed.\n\n| Knowledge | Save Modifier |\n|---|---|\n| Secondhand (you have heard of the target) | +5 |\n| Firsthand (you have met the target) | +0 |\n| Familiar (you know the target well) | -5 |\n\n| Connection | Save Modifier |\n|---|---|\n| Likeness or picture | -2 |\n| Possession or garment | -4 |\n| Body part, lock of hair, bit of nail, or the like | -10 |\n\nOn a successful save, the target isn't affected, and you can't use this spell against it again for 24 hours.\n\nOn a failed save, the spell creates an invisible sensor within 10 feet of the target. You can see and hear through the sensor as if you were there. The sensor moves with the target, remaining within 10 feet of it for the duration. A creature that can see invisible objects sees the sensor as a luminous orb about the size of your fist.\n\nInstead of targeting a creature, you can choose a location you have seen before as the target of this spell. When you do, the sensor appears at that location and doesn't move.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "scrying", "it"),
					Language = LanguageCode.It,
					Name = "Scrutare",
					CastingTime = "10 minuti",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un focus del valore di almeno 1.000 mo, come una sfera di cristallo, uno specchio d'argento o una fonte piena di acqua santa",
					Description = "L'incantatore può vedere e sentire una particolare creatura da lui scelta che si trova sul suo stesso piano di esistenza. Il bersaglio deve effettuare un tiro salvezza su Saggezza, modificato in base a quanto bene l'incantatore conosce il bersaglio e al tipo di legame fisico che ha con esso. Se un bersaglio sa che l'incantatore sta lanciando questo incantesimo, può fallire volontariamente il tiro salvezza, se desidera essere osservato.\n\n| Conoscenza | Modificatore al tiro salvezza |\n|---|---|\n| Indiretta (l'incantatore ha sentito parlare del bersaglio) | +5 |\n| Diretta (l'incantatore ha incontrato il bersaglio) | +0 |\n| Familiare (l'incantatore conosce bene il bersaglio) | -5 |\n\n| Legame | Modificatore al tiro salvezza |\n|---|---|\n| Ritratto o immagine | -2 |\n| Oggetto posseduto o indumento | -4 |\n| Parte del corpo, ciocca di capelli, frammento di unghia o simili | -10 |\n\nSe supera il tiro salvezza, il bersaglio non è influenzato e l'incantatore non può usare di nuovo questo incantesimo contro di esso per 24 ore.\n\nSe lo fallisce, l'incantesimo crea un sensore invisibile entro 3 metri dal bersaglio. L'incantatore può vedere e sentire attraverso il sensore come se si trovasse lì. Il sensore si sposta insieme al bersaglio, rimanendo entro 3 metri da esso per la durata. Una creatura in grado di vedere gli oggetti invisibili vede il sensore come un globo luminoso grande all'incirca quanto il pugno dell'incantatore.\n\nInvece di bersagliare una creatura, l'incantatore può scegliere come bersaglio di questo incantesimo un luogo che ha già visto. In tal caso, il sensore compare in quel luogo e non si sposta.",
					HigherLevels = null
				}
			}
		};
	}
}
