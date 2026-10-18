using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Summon Fey (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SummonFey2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-fey");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-fey", "en"),
					Language = LanguageCode.En,
					Name = "Summon Fey",
					CastingTime = "Action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a flower dipped in gold, worth 300+ GP",
					Description = "A spirit from the Feywild steps through to you and forms in an unoccupied space you can see within range, shaped like a Fey creature of your choosing. Its statistics are given in the **Fey Spirit** block below. Pick its temper when you cast the spell (Furious, Merry, or Sly); the temper colors its manner and decides how its Fey Step resolves. The spirit is gone as soon as its Hit Points reach 0 or the spell ends.\n\nThe spirit fights on your side and is friendly to your companions. It doesn't roll its own Initiative: it acts immediately after you, on your turn. You can direct it with spoken orders at no cost in actions; left without orders, it takes the Dodge action and moves only to avoid harm.\n\n#### Fey Spirit\n\n*Small Fey, Neutral*\n\n**AC** 12 + spell level · **HP** 30, plus 10 per spell level above 3 · **Speed** 30 ft.; Fly 30 ft.\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 13 | +1 | +1 |\n| DEX | 16 | +3 | +3 |\n| CON | 14 | +2 | +2 |\n| INT | 14 | +2 | +2 |\n| WIS | 11 | +0 | +0 |\n| CHA | 16 | +3 | +3 |\n\n**Immune** to the Charmed condition · **Senses** Darkvision 60 ft., Passive Perception 10 · **Languages** Sylvan; understands every language you know · **Challenge** none (XP 0); uses your Proficiency Bonus\n\n**Actions**\n\n- **Multiattack.** The spirit makes Glamour Blade attacks equal in number to half the spell level, rounded down.\n- **Glamour Blade.** Melee attack using your spell attack modifier, reach 5 ft. On a hit: Force damage equal to 2d6 + 3 + spell level.\n\n**Bonus Actions**\n\n- **Fey Step.** The spirit teleports to an unoccupied space it can see up to 30 feet away, and then its temper takes over:\n  - *Furious:* its next attack roll before the end of this turn has Advantage.\n  - *Merry:* one creature the spirit can see within 10 feet of it makes a Wisdom saving throw against your spell save DC. On a failure, it is Charmed by both you and the spirit for 1 minute, or until it takes damage.\n  - *Sly:* magical Darkness fills a 10-foot Cube within 5 feet of the spirit and lasts until the end of the spirit's next turn.",
					HigherLevels = "Wherever the stat block refers to the spell level, use the level of the slot you spent."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "summon-fey", "it"),
					Language = LanguageCode.It,
					Name = "Richiama Folletto",
					CastingTime = "Azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un fiore immerso nell'oro, del valore di almeno 300 mo",
					Description = "Uno spirito della Selva Fatata giunge dall'incantatore e si forma in uno spazio libero entro gittata che questi è in grado di vedere, con l'aspetto di una creatura folletto a sua scelta. Le sue statistiche sono riportate nella scheda dello **Spirito Fatato** qui sotto. Al momento del lancio l'incantatore sceglie il suo temperamento (Furioso, Allegro o Scaltro); il temperamento ne colora i modi e decide come si risolve il suo Passo Fatato. Lo spirito scompare non appena i suoi punti ferita scendono a 0 o l'incantesimo termina.\n\nLo spirito combatte dalla parte dell'incantatore ed è amichevole verso i suoi compagni. Non tira la propria Iniziativa: agisce subito dopo l'incantatore, nel turno di quest'ultimo. L'incantatore può guidarlo con ordini verbali senza spendere azioni; se non riceve ordini, lo spirito effettua l'azione di Schivata e si muove soltanto per evitare danni.\n\n#### Spirito Fatato\n\n*Folletto Piccolo, neutrale*\n\n**CA** 12 + livello dell'incantesimo · **PF** 30, più 10 per ogni livello dell'incantesimo oltre il 3° · **Velocità** 9 m; volare 9 m\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 13 | +1 | +1 |\n| DES | 16 | +3 | +3 |\n| COS | 14 | +2 | +2 |\n| INT | 14 | +2 | +2 |\n| SAG | 11 | +0 | +0 |\n| CAR | 16 | +3 | +3 |\n\n**Immune** alla condizione affascinato · **Sensi** scurovisione 18 m, Percezione passiva 10 · **Linguaggi** Silvano; comprende tutti i linguaggi conosciuti dall'incantatore · **Grado di sfida** nessuno (PE 0); usa il bonus di competenza dell'incantatore\n\n**Azioni**\n\n- **Multiattacco.** Lo spirito effettua un numero di attacchi di Lama d'Incanto pari alla metà del livello dell'incantesimo, arrotondata per difetto.\n- **Lama d'Incanto.** Attacco in mischia con il modificatore di attacco con incantesimo dell'incantatore, portata 1,5 m. Se colpisce: danni da forza pari a 2d6 + 3 + livello dell'incantesimo.\n\n**Azioni bonus**\n\n- **Passo Fatato.** Lo spirito si teletrasporta in uno spazio libero che è in grado di vedere entro 9 metri, poi prende il sopravvento il suo temperamento:\n  - *Furioso:* il suo prossimo tiro per colpire prima della fine di questo turno ha vantaggio.\n  - *Allegro:* una creatura che lo spirito è in grado di vedere entro 3 metri da lui effettua un tiro salvezza su Saggezza contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se fallisce, è affascinata sia dall'incantatore sia dallo spirito per 1 minuto, o finché non subisce danni.\n  - *Scaltro:* un'oscurità magica riempie un cubo di 3 metri di spigolo entro 1,5 metri dallo spirito e dura fino alla fine del turno successivo dello spirito.",
					HigherLevels = "Ovunque la scheda faccia riferimento al livello dell'incantesimo, si usa il livello dello slot speso."
				}
			}
		};
	}
}
