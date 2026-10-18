using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hallow (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Hallow2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hallow");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Evocation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hallow", "en"),
					Language = LanguageCode.En,
					Name = "Hallow",
					CastingTime = "24 hours",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "herbs, oils, and incense worth at least 1,000 gp, which the spell consumes",
					Description = "You touch a point and infuse an area around it with holy (or unholy) power. The area can have a radius up to 60 feet, and the spell fails if the radius includes an area already under the effect of a hallow spell. The affected area is subject to the following effects.\n\nFirst, celestials, elementals, fey, fiends, and undead can't enter the area, nor can such creatures charm, frighten, or possess creatures within it. Any creature charmed, frightened, or possessed by such a creature is no longer charmed, frightened, or possessed upon entering the area. You can exclude one or more of those types of creatures from this effect.\n\nSecond, you can bind an extra effect to the area. Choose the effect from the following list, or choose an effect offered by the GM. Some of these effects apply to creatures in the area; you can designate whether the effect applies to all creatures, creatures that follow a specific deity or leader, or creatures of a specific sort, such as orcs or trolls. When a creature that would be affected enters the spell's area for the first time on a turn or starts its turn there, it can make a Charisma saving throw. On a success, the creature ignores the extra effect until it leaves the area.\n\n***Courage.*** Affected creatures can't be frightened while in the area.\n\n***Darkness.*** Darkness fills the area. Normal light, as well as magical light created by spells of a lower level than the slot you used to cast this spell, can't illuminate the area.\n\n***Daylight.*** Bright light fills the area. Magical darkness created by spells of a lower level than the slot you used to cast this spell can't extinguish the light.\n\n***Energy Protection.*** Affected creatures in the area have resistance to one damage type of your choice, except for bludgeoning, piercing, or slashing.\n\n***Energy Vulnerability.*** Affected creatures in the area have vulnerability to one damage type of your choice, except for bludgeoning, piercing, or slashing.\n\n***Everlasting Rest.*** Dead bodies interred in the area can't be turned into undead.\n\n***Extradimensional Interference.*** Affected creatures can't move or travel using teleportation or by extradimensional or interplanar means.\n\n***Fear.*** Affected creatures are frightened while in the area.\n\n***Silence.*** No sound can emanate from within the area, and no sound can reach into it.\n\n***Tongues.*** Affected creatures can communicate with any other creature in the area, even if they don't share a common language.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "hallow", "it"),
					Language = LanguageCode.It,
					Name = "Santificare",
					CastingTime = "24 ore",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "erbe, oli e incenso del valore di almeno 1.000 mo, che l'incantesimo consuma",
					Description = "L'incantatore tocca un punto e infonde nell'area circostante un potere sacro (o sacrilego). L'area può avere un raggio massimo di 18 metri, e l'incantesimo fallisce se il raggio comprende un'area già sotto l'effetto di un incantesimo santificare. L'area influenzata è soggetta agli effetti seguenti.\n\nInnanzitutto, i celestiali, gli elementali, i folletti, gli immondi e i non morti non possono entrare nell'area, né possono affascinare, spaventare o possedere le creature che si trovano al suo interno. Qualsiasi creatura affascinata, spaventata o posseduta da una di queste creature non è più affascinata, spaventata o posseduta quando entra nell'area. L'incantatore può escludere da questo effetto uno o più di questi tipi di creature.\n\nIn secondo luogo, l'incantatore può vincolare all'area un effetto aggiuntivo, scelto dall'elenco seguente o tra quelli proposti dal DM. Alcuni di questi effetti si applicano alle creature nell'area; l'incantatore può stabilire se l'effetto si applica a tutte le creature, alle creature che seguono una specifica divinità o un capo, oppure alle creature di un tipo specifico, come gli orchi o i troll. Quando una creatura che sarebbe influenzata entra nell'area dell'incantesimo per la prima volta in un turno o vi inizia il proprio turno, può effettuare un tiro salvezza su Carisma. Se lo supera, la creatura ignora l'effetto aggiuntivo finché non esce dall'area.\n\n***Coraggio.*** Le creature influenzate non possono essere spaventate finché si trovano nell'area.\n\n***Oscurità.*** L'oscurità riempie l'area. La luce normale, così come la luce magica creata da incantesimi di livello inferiore a quello dello slot usato per lanciare questo incantesimo, non può illuminare l'area.\n\n***Luce del Giorno.*** Una luce intensa riempie l'area. L'oscurità magica creata da incantesimi di livello inferiore a quello dello slot usato per lanciare questo incantesimo non può spegnere la luce.\n\n***Protezione dall'Energia.*** Le creature influenzate nell'area hanno resistenza a un tipo di danno a scelta dell'incantatore, tranne contundente, perforante o tagliente.\n\n***Vulnerabilità all'Energia.*** Le creature influenzate nell'area sono vulnerabili a un tipo di danno a scelta dell'incantatore, tranne contundente, perforante o tagliente.\n\n***Riposo Eterno.*** I cadaveri sepolti nell'area non possono essere trasformati in non morti.\n\n***Interferenza Extradimensionale.*** Le creature influenzate non possono muoversi o viaggiare tramite il teletrasporto o con mezzi extradimensionali o interplanari.\n\n***Paura.*** Le creature influenzate sono spaventate finché si trovano nell'area.\n\n***Silenzio.*** Nessun suono può provenire dall'interno dell'area e nessun suono può raggiungerla.\n\n***Linguaggi.*** Le creature influenzate possono comunicare con qualsiasi altra creatura nell'area, anche se non hanno un linguaggio in comune.",
					HigherLevels = null
				}
			}
		};
	}
}
