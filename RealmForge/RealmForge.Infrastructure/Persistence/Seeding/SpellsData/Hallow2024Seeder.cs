using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hallow (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Hallow2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hallow");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hallow", "en"),
					Language = LanguageCode.En,
					Name = "Hallow",
					CastingTime = "24 hours",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "incense worth 1,000+ GP, which the spell consumes",
					Description = "You touch a point and infuse an area around it with holy or unholy power. The area can have a radius up to 60 feet, and the spell fails if the radius includes an area already under the effect of *Hallow*. The affected area has the following effects.\n\n**Hallowed Ward.** Choose any of these creature types: Aberration, Celestial, Elemental, Fey, Fiend, or Undead. Creatures of the chosen types can't willingly enter the area, and any creature that is possessed by or that has the Charmed or Frightened condition from such creatures isn't possessed, Charmed, or Frightened by them while in the area.\n\n**Extra Effect.** You bind an extra effect to the area from the list below:\n\n**Courage.** Creatures of any types you choose can't gain the Frightened condition while in the area.\n\n**Darkness.** Darkness fills the area. Normal light, as well as magical light created by spells of a level lower than this spell, can't illuminate the area.\n\n**Daylight.** Bright light fills the area. Magical Darkness created by spells of a level lower than this spell can't extinguish the light.\n\n**Peaceful Rest.** Dead bodies interred in the area can't be turned into Undead.\n\n**Extradimensional Interference.** Creatures of any types you choose can't enter or exit the area using teleportation or interplanar travel.\n\n**Fear.** Creatures of any types you choose have the Frightened condition while in the area.\n\n**Resistance.** Creatures of any types you choose have Resistance to one damage type of your choice while in the area.\n\n**Silence.** No sound can emanate from within the area, and no sound can reach into it.\n\n**Tongues.** Creatures of any types you choose can communicate with any other creature in the area even if they don't share a common language.\n\n**Vulnerability.** Creatures of any types you choose have Vulnerability to one damage type of your choice while in the area.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hallow", "it"),
					Language = LanguageCode.It,
					Name = "Santificare",
					CastingTime = "24 ore",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "incenso del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore tocca un punto e infonde un'area attorno a esso di potere sacro o empio. L'area può avere un raggio fino a 18 metri, e l'incantesimo fallisce se il raggio include un'area già sotto l'effetto di *santificare*. L'area influenzata è soggetta agli effetti seguenti.\n\n**Protezione Santificata.** L'incantatore sceglie uno qualsiasi di questi tipi di creatura: aberrazione, celestiale, elementale, folletto, immondo o non morto. Le creature dei tipi scelti non possono entrare volontariamente nell'area, e qualsiasi creatura che è posseduta, affascinata o spaventata da tali creature non è posseduta, affascinata o spaventata da esse finché si trova nell'area.\n\n**Effetto Extra.** L'incantatore vincola all'area un effetto extra scelto dall'elenco seguente:\n\n**Coraggio.** Le creature dei tipi scelti dall'incantatore non possono diventare spaventate finché si trovano nell'area.\n\n**Oscurità.** L'oscurità riempie l'area. La luce normale, così come la luce magica creata da incantesimi di livello inferiore a questo incantesimo, non può illuminare l'area.\n\n**Luce Diurna.** Una luce intensa riempie l'area. L'oscurità magica creata da incantesimi di livello inferiore a questo incantesimo non può spegnere la luce.\n\n**Riposo Eterno.** I cadaveri sepolti nell'area non possono essere trasformati in non morti.\n\n**Interferenza Extradimensionale.** Le creature dei tipi scelti dall'incantatore non possono entrare nell'area o uscirne tramite il teletrasporto o un viaggio interplanare.\n\n**Paura.** Le creature dei tipi scelti dall'incantatore sono spaventate finché si trovano nell'area.\n\n**Resistenza.** Le creature dei tipi scelti dall'incantatore hanno resistenza a un tipo di danni a scelta dell'incantatore finché si trovano nell'area.\n\n**Silenzio.** Nessun suono può provenire dall'interno dell'area e nessun suono può raggiungerla.\n\n**Linguaggi.** Le creature dei tipi scelti dall'incantatore possono comunicare con qualsiasi altra creatura nell'area, anche se non hanno un linguaggio in comune.\n\n**Vulnerabilità.** Le creature dei tipi scelti dall'incantatore hanno vulnerabilità a un tipo di danni a scelta dell'incantatore finché si trovano nell'area.",
					HigherLevels = null
				}
			}
		};
	}
}
