using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Summon Beast (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SummonBeast2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-beast");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 2,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-beast", "en"),
					Language = LanguageCode.En,
					Name = "Summon Beast",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a feather, a bit of fur, and a fish's tail sealed inside a gold-leafed acorn worth 200+ GP",
					Description = "A spirit of untamed nature answers your call and forms in an unoccupied space you can see within range. Its statistics are given in the **Bestial Spirit** block below. Pick its habitat when you cast the spell (Air, Land, or Water); the spirit takes the shape of an animal of your choice from that habitat, and the habitat decides which of the habitat-specific entries apply. The spirit is gone as soon as its Hit Points reach 0 or the spell ends.\n\nThe spirit fights on your side and is friendly to your companions. It doesn't roll its own Initiative: it acts immediately after you, on your turn. You can direct it with spoken orders at no cost in actions; left without orders, it takes the Dodge action and moves only to avoid harm.\n\n#### Bestial Spirit\n\n*Small Beast, Neutral*\n\n**AC** 11 + spell level · **HP** 20 (Air) or 30 (Land, Water), plus 5 per spell level above 2 · **Speed** 30 ft.; Climb 30 ft. (Land only); Fly 60 ft. (Air only); Swim 30 ft. (Water only)\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 18 | +4 | +4 |\n| DEX | 11 | +0 | +0 |\n| CON | 16 | +3 | +3 |\n| INT | 4 | −3 | −3 |\n| WIS | 14 | +2 | +2 |\n| CHA | 5 | −3 | −3 |\n\n**Senses** Darkvision 60 ft., Passive Perception 12 · **Languages** understands every language you know · **Challenge** none (XP 0); uses your Proficiency Bonus\n\n**Features**\n\n- **Hit and Away (Air).** Flying out of an enemy's reach never provokes an Opportunity Attack against the spirit.\n- **Hunting Partner (Land, Water).** The spirit's attack roll against a creature has Advantage when at least one of the spirit's allies is within 5 feet of that creature and isn't Incapacitated.\n- **Water Breather (Water).** The spirit can breathe underwater, and only there.\n\n**Actions**\n\n- **Multiattack.** The spirit makes Savage Bite attacks equal in number to half the spell level, rounded down.\n- **Savage Bite.** Melee attack using your spell attack modifier, reach 5 ft. On a hit: Piercing damage equal to 1d8 + 4 + spell level.",
					HigherLevels = "Wherever the stat block refers to the spell level, use the level of the slot you spent."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-beast", "it"),
					Language = LanguageCode.It,
					Name = "Richiama Bestia",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "una piuma, un po' di pelo e una coda di pesce sigillati dentro una ghianda rivestita di foglia d'oro, del valore di almeno 200 mo",
					Description = "Uno spirito della natura indomita risponde al richiamo dell'incantatore e si forma in uno spazio libero entro gittata che questi è in grado di vedere. Le sue statistiche sono riportate nella scheda dello **Spirito Bestiale** qui sotto. Al momento del lancio l'incantatore sceglie il suo habitat (Aria, Terra o Acqua); lo spirito assume la forma di un animale di quell'habitat a scelta dell'incantatore, e l'habitat decide quali voci specifiche si applicano. Lo spirito scompare non appena i suoi punti ferita scendono a 0 o l'incantesimo termina.\n\nLo spirito combatte dalla parte dell'incantatore ed è amichevole verso i suoi compagni. Non tira la propria Iniziativa: agisce subito dopo l'incantatore, nel turno di quest'ultimo. L'incantatore può guidarlo con ordini verbali senza spendere azioni; se non riceve ordini, lo spirito effettua l'azione di Schivata e si muove soltanto per evitare danni.\n\n#### Spirito Bestiale\n\n*Bestia Piccola, neutrale*\n\n**CA** 11 + livello dell'incantesimo · **PF** 20 (Aria) o 30 (Terra, Acqua), più 5 per ogni livello dell'incantesimo oltre il 2° · **Velocità** 9 m; scalare 9 m (solo Terra); volare 18 m (solo Aria); nuotare 9 m (solo Acqua)\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 18 | +4 | +4 |\n| DES | 11 | +0 | +0 |\n| COS | 16 | +3 | +3 |\n| INT | 4 | −3 | −3 |\n| SAG | 14 | +2 | +2 |\n| CAR | 5 | −3 | −3 |\n\n**Sensi** scurovisione 18 m, Percezione passiva 12 · **Linguaggi** comprende tutti i linguaggi conosciuti dall'incantatore · **Grado di sfida** nessuno (PE 0); usa il bonus di competenza dell'incantatore\n\n**Capacità**\n\n- **Colpisci e Fuggi (Aria).** Uscire in volo dalla portata di un nemico non provoca mai un attacco di opportunità contro lo spirito.\n- **Compagno di Caccia (Terra, Acqua).** Il tiro per colpire dello spirito contro una creatura ha vantaggio quando almeno uno degli alleati dello spirito si trova entro 1,5 metri da quella creatura e non è incapacitato.\n- **Respirazione Acquatica (Acqua).** Lo spirito può respirare sott'acqua, e soltanto lì.\n\n**Azioni**\n\n- **Multiattacco.** Lo spirito effettua un numero di attacchi di Morso Selvaggio pari alla metà del livello dell'incantesimo, arrotondata per difetto.\n- **Morso Selvaggio.** Attacco in mischia con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. Se colpisce: danni perforanti pari a 1d8 + 4 + livello dell'incantesimo.",
					HigherLevels = "Ovunque la scheda faccia riferimento al livello dell'incantesimo, si usa il livello dello slot speso."
				}
			}
		};
	}
}
