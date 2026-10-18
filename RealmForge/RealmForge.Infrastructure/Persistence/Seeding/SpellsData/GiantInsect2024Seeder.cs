using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Giant Insect (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GiantInsect2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "giant-insect");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "giant-insect", "en"),
					Language = LanguageCode.En,
					Name = "Giant Insect",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You summon a giant centipede, spider, or wasp (chosen when you cast the spell). It manifests in an unoccupied space you can see within range and uses the Giant Insect stat block. The form you choose determines certain details in its stat block. The creature disappears when it drops to 0 Hit Points or when the spell ends.\n\nThe creature is an ally to you and your allies. In combat, the creature shares your Initiative count, but it takes its turn immediately after yours. It obeys your verbal commands (no action required by you). If you don't issue any, it takes the Dodge action and uses its movement to avoid danger.\n\n#### Giant Insect\n\n*Large Beast, Unaligned*\n\n**AC** 11 + the spell's level\n\n**HP** 30 + 10 for each spell level above 4\n\n**Speed** 40 ft., Climb 40 ft., Fly 40 ft. (Wasp only)\n\n| Ability | Score | Mod | Save |\n|---|---|---|---|\n| STR | 17 | +3 | +3 |\n| DEX | 13 | +1 | +1 |\n| CON | 15 | +2 | +2 |\n| INT | 4 | −3 | −3 |\n| WIS | 14 | +2 | +2 |\n| CHA | 3 | −4 | −4 |\n\n**Senses** Darkvision 60 ft.; Passive Perception 12\n\n**Languages** Understands the languages you know\n\n**CR** None (XP 0; PB equals your Proficiency Bonus)\n\n***Traits***\n\n***Spider Climb.*** The insect can climb difficult surfaces, including along ceilings, without needing to make an ability check.\n\n***Actions***\n\n***Multiattack.*** The insect makes a number of attacks equal to half this spell's level (round down).\n\n***Poison Jab.*** *Melee Attack Roll:* Bonus equals your spell attack modifier, reach 10 ft. *Hit:* 1d6 + 3 plus the spell's level Piercing damage plus 1d4 Poison damage.\n\n***Web Bolt (Spider Only).*** *Ranged Attack Roll:* Bonus equals your spell attack modifier, range 60 ft. *Hit:* 1d10 + 3 plus the spell's level Bludgeoning damage, and the target's Speed is reduced to 0 until the start of the insect's next turn.\n\n***Bonus Actions***\n\n***Venomous Spew (Centipede Only).*** *Constitution Saving Throw:* Your spell save DC, one creature the insect can see within 10 feet. *Failure:* The target has the Poisoned condition until the start of the insect's next turn.",
					HigherLevels = "Use the spell slot's level for the spell's level in the stat block."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "giant-insect", "it"),
					Language = LanguageCode.It,
					Name = "Insetto Gigante",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore evoca un centopiedi, un ragno o una vespa giganti (a scelta al momento del lancio). La creatura si manifesta in uno spazio libero entro gittata che l'incantatore è in grado di vedere e usa la scheda delle statistiche dell'insetto gigante. La forma scelta determina alcuni dettagli della sua scheda delle statistiche. La creatura scompare quando scende a 0 punti ferita o quando l'incantesimo termina.\n\nLa creatura è un'alleata dell'incantatore e dei suoi alleati. In combattimento condivide il conteggio di Iniziativa dell'incantatore, ma svolge il proprio turno subito dopo il suo. Obbedisce ai suoi comandi verbali (non è richiesta alcuna azione da parte dell'incantatore). Se l'incantatore non impartisce alcun comando, la creatura effettua l'azione di Schivata e usa il proprio movimento per evitare pericoli.\n\n#### Insetto Gigante\n\n*Bestia Grande, senza allineamento*\n\n**CA** 11 + il livello dell'incantesimo\n\n**PF** 30 + 10 per ogni livello dell'incantesimo superiore al 4°\n\n**Velocità** 12 m, scalare 12 m, volare 12 m (solo vespa)\n\n| Caratteristica | Punteggio | Mod | TS |\n|---|---|---|---|\n| FOR | 17 | +3 | +3 |\n| DES | 13 | +1 | +1 |\n| COS | 15 | +2 | +2 |\n| INT | 4 | −3 | −3 |\n| SAG | 14 | +2 | +2 |\n| CAR | 3 | −4 | −4 |\n\n**Sensi** scurovisione 18 m; Percezione passiva 12\n\n**Linguaggi** comprende i linguaggi conosciuti dall'incantatore\n\n**GS** nessuno (PE 0; BC pari al bonus di competenza dell'incantatore)\n\n***Tratti***\n\n***Movimenti del Ragno.*** L'insetto può arrampicarsi su superfici difficili, anche a testa in giù sui soffitti, senza dover effettuare alcuna prova di caratteristica.\n\n***Azioni***\n\n***Multiattacco.*** L'insetto effettua un numero di attacchi pari alla metà del livello di questo incantesimo (arrotondato per difetto).\n\n***Aculeo Velenoso.*** *Tiro per colpire in mischia:* bonus pari al modificatore di attacco con incantesimo dell'incantatore, portata 3 m. *Colpito:* 1d6 + 3 più il livello dell'incantesimo danni perforanti più 1d4 danni da veleno.\n\n***Getto di Ragnatela (solo ragno).*** *Tiro per colpire a distanza:* bonus pari al modificatore di attacco con incantesimo dell'incantatore, gittata 18 m. *Colpito:* 1d10 + 3 più il livello dell'incantesimo danni contundenti, e la velocità del bersaglio si riduce a 0 fino all'inizio del turno successivo dell'insetto.\n\n***Azioni Bonus***\n\n***Sputo Velenoso (solo centopiedi).*** *Tiro salvezza su Costituzione:* CD pari alla CD del tiro salvezza degli incantesimi dell'incantatore, una creatura entro 3 metri che l'insetto è in grado di vedere. *Fallimento:* il bersaglio è avvelenato fino all'inizio del turno successivo dell'insetto.",
					HigherLevels = "Si usa il livello dello slot incantesimo come livello dell'incantesimo nella scheda delle statistiche."
				}
			}
		};
	}
}
