using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Scrying (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Scrying2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "scrying");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "scrying", "en"),
					Language = LanguageCode.En,
					Name = "Scrying",
					CastingTime = "10 minutes",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a focus worth 1,000+ GP, such as a crystal ball, mirror, or water-filled font",
					Description = "You can see and hear a creature you choose that is on the same plane of existence as you. The target makes a Wisdom saving throw, which is modified (see the tables below) by how well you know the target and the sort of physical connection you have to it. The target doesn't know what it is making the save against, only that it feels uneasy.\n\n| Your Knowledge of the Target Is … | Save Modifier |\n|---|---|\n| Secondhand (heard of the target) | +5 |\n| Firsthand (met the target) | +0 |\n| Extensive (know the target well) | −5 |\n\n| You Have the Target's … | Save Modifier |\n|---|---|\n| Picture or other likeness | −2 |\n| Garment or other possession | −4 |\n| Body part, lock of hair, or bit of nail | −10 |\n\nOn a successful save, the target isn't affected, and you can't use this spell on it again for 24 hours.\n\nOn a failed save, the spell creates an Invisible, intangible sensor within 10 feet of the target. You can see and hear through the sensor as if you were there. The sensor moves with the target, remaining within 10 feet of it for the duration. If something can see the sensor, it appears as a luminous orb about the size of your fist.\n\nInstead of targeting a creature, you can target a location you have seen. When you do so, the sensor appears at that location and doesn't move.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "scrying", "it"),
					Language = LanguageCode.It,
					Name = "Scrutare",
					CastingTime = "10 minuti",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un focus del valore di almeno 1.000 mo, come una sfera di cristallo, uno specchio o una fonte piena d'acqua",
					Description = "L'incantatore può vedere e sentire una creatura a sua scelta che si trova sul suo stesso piano di esistenza. Il bersaglio effettua un tiro salvezza su Saggezza, modificato (vedi le tabelle seguenti) da quanto bene l'incantatore conosce il bersaglio e dal tipo di legame fisico che ha con esso. Il bersaglio non sa contro cosa sta effettuando il tiro salvezza, sente soltanto un senso di disagio.\n\n| La conoscenza del bersaglio da parte dell'incantatore è… | Modificatore al tiro salvezza |\n|---|---|\n| Indiretta (ha sentito parlare del bersaglio) | +5 |\n| Diretta (ha incontrato il bersaglio) | +0 |\n| Approfondita (conosce bene il bersaglio) | −5 |\n\n| L'incantatore possiede del bersaglio… | Modificatore al tiro salvezza |\n|---|---|\n| Un ritratto o un'altra raffigurazione | −2 |\n| Un indumento o un altro possedimento | −4 |\n| Una parte del corpo, una ciocca di capelli o un frammento di unghia | −10 |\n\nSe lo supera, il bersaglio non viene influenzato e l'incantatore non può usare di nuovo questo incantesimo su di esso per 24 ore.\n\nSe lo fallisce, l'incantesimo crea un sensore invisibile e intangibile entro 3 metri dal bersaglio. L'incantatore può vedere e sentire attraverso il sensore come se si trovasse lì. Il sensore si muove con il bersaglio, rimanendo entro 3 metri da esso per la durata. Se qualcosa è in grado di vedere il sensore, questo appare come un globo luminoso grande all'incirca quanto il pugno dell'incantatore.\n\nInvece di prendere come bersaglio una creatura, l'incantatore può prendere come bersaglio un luogo che ha già visto. In tal caso, il sensore compare in quel luogo e non si muove.",
					HigherLevels = null
				}
			}
		};
	}
}
