using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Lich (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Lich2014Seeder
{
	public static Monster Build() => Create("lich", null, CreatureSize.Medium, CreatureType.Undead,
		17, 135, "18d8 + 54", 30, new[] { 11, 16, 16, 20, 14, 16 }, 21m, 33000, 7, 19,
		new Text(
			"Lich",
			null,
			"Non morto Medio, qualsiasi allineamento malvagio",
			"17 (armatura naturale)",
			"9 m",
			"Cos +10, Int +12, Sag +9",
			"Arcano +18, Intuizione +9, Percezione +9, Storia +12",
			"",
			"freddo, fulmine, necrotici",
			"veleno; contundenti, perforanti e taglienti da attacchi non magici",
			"affascinato, avvelenato, indebolimento, paralizzato, spaventato",
			"Percezione passiva 19, vista pura 36 m",
			"Comune, più al massimo altri cinque linguaggi",
			"***Incantesimi.*** Il lich è un incantatore di 18° livello. La sua caratteristica da incantatore è l'Intelligenza (CD del tiro salvezza sull'incantesimo 20, +12 al tiro per colpire con attacco con incantesimo). Ha a disposizione i seguenti incantesimi da mago:\n\n- Trucchetti (a volontà): *mano magica, prestidigitazione, raggio di gelo*\n- 1° livello (4 slot): *dardo incantato, individuazione del magico, onda tonante, scudo*\n- 2° livello (3 slot): *freccia acida, immagine speculare, individuazione dei pensieri, invisibilità*\n- 3° livello (3 slot): *animare morti, controincantesimo, dissolvi magie, palla di fuoco*\n- 4° livello (3 slot): *inaridire, porta dimensionale*\n- 5° livello (3 slot): *nube mortale, scrutare*\n- 6° livello (1 slot): *disintegrazione, globo di invulnerabilità*\n- 7° livello (1 slot): *dito della morte, spostamento planare*\n- 8° livello (1 slot): *dominare mostri, parola del potere stordire*\n- 9° livello (1 slot): *parola del potere uccidere*\n\n***Resistenza allo scacciare.*** Il lich dispone di vantaggio ai tiri salvezza contro qualsiasi effetto che scacci i non morti.\n\n***Resistenza leggendaria (3/giorno).*** Se il lich fallisce un tiro salvezza, può scegliere di superarlo comunque.\n\n***Rigenerazione.*** Se possiede un filatterio, quando il lich è distrutto ottiene un nuovo corpo nel giro di 1d10 giorni, recuperando tutti i suoi punti ferita e tornando a essere attivo. Il nuovo corpo compare entro 1,5 metri dal filatterio.",
			"***Tocco paralizzante.*** *Attacco in mischia con incantesimo:* +12 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 10 (3d6) danni da freddo. Il bersaglio deve superare un tiro salvezza su Costituzione con CD 18, altrimenti rimane paralizzato per 1 minuto. Il bersaglio può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			"Il lich può eseguire 3 azioni leggendarie a scelta tra le opzioni seguenti. È possibile utilizzare solo un'opzione di azione leggendaria alla volta e soltanto alla fine del turno di un'altra creatura. All'inizio del proprio turno, il lich recupera le azioni leggendarie effettuate.\n\n***Trucchetto.*** Il lich lancia un trucchetto.\n\n***Sguardo terrificante (costa 2 azioni).*** Il lich fissa lo sguardo su una creatura nel suo campo visivo entro un raggio di 3 metri. Il bersaglio deve superare un tiro salvezza su Saggezza con CD 18 contro questa magia, altrimenti rimane spaventato per 1 minuto. Il bersaglio spaventato può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce. Se il bersaglio supera il tiro salvezza o se l'effetto termina, è immune allo sguardo del lich per le 24 ore successive.\n\n***Tocco paralizzante (costa 2 azioni).*** Il lich usa il tocco paralizzante.\n\n***Distruggere vita (costa 3 azioni).*** Ogni creatura che non sia un non morto e situata entro 6 metri dal lich deve effettuare un tiro salvezza su Costituzione con CD 18 contro questa magia, subendo 21 (6d6) danni necrotici in caso di fallimento, o la metà in caso di successo."),
		new Text(
			"Lich",
			null,
			"Medium undead, any evil alignment",
			"17 (natural armor)",
			"30 ft.",
			"Con +10, Int +12, Wis +9",
			"Arcana +18, History +12, Insight +9, Perception +9",
			"",
			"cold, lightning, necrotic",
			"poison; bludgeoning, piercing, and slashing from nonmagical weapons",
			"charmed, exhaustion, frightened, paralyzed, poisoned",
			"truesight 120 ft., passive Perception 19",
			"Common plus up to five other languages",
			"***Legendary Resistance (3/Day).*** If the lich fails a saving throw, it can choose to succeed instead.\n\n***Rejuvenation.*** If it has a phylactery, a destroyed lich gains a new body in 1d10 days, regaining all its hit points and becoming active again. The new body appears within 5 feet of the phylactery.\n\n***Spellcasting.*** The lich is an 18th-level spellcaster. Its spellcasting ability is Intelligence (spell save DC 20, +12 to hit with spell attacks). The lich has the following wizard spells prepared:\n\n- Cantrips (at will): *mage hand, prestidigitation, ray of frost*\n- 1st level (4 slots): *detect magic, magic missile, shield, thunderwave*\n- 2nd level (3 slots): *acid arrow, detect thoughts, invisibility, mirror image*\n- 3rd level (3 slots): *animate dead, counterspell, dispel magic, fireball*\n- 4th level (3 slots): *blight, dimension door*\n- 5th level (3 slots): *cloudkill, scrying*\n- 6th level (1 slot): *disintegrate, globe of invulnerability*\n- 7th level (1 slot): *finger of death, plane shift*\n- 8th level (1 slot): *dominate monster, power word stun*\n- 9th level (1 slot): *power word kill*\n\n***Turn Resistance.*** The lich has advantage on saving throws against any effect that turns undead.",
			"***Paralyzing Touch.*** *Melee Spell Attack:* +12 to hit, reach 5 ft., one creature. *Hit:* 10 (3d6) cold damage. The target must succeed on a DC 18 Constitution saving throw or be paralyzed for 1 minute. The target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			"The lich can take 3 legendary actions, choosing from the options below. Only one legendary action option can be used at a time and only at the end of another creature's turn. The lich regains spent legendary actions at the start of its turn.\n\n***Cantrip.*** The lich casts a cantrip.\n\n***Paralyzing Touch (Costs 2 Actions).*** The lich uses its Paralyzing Touch.\n\n***Frightening Gaze (Costs 2 Actions).*** The lich fixes its gaze on one creature it can see within 10 feet of it. The target must succeed on a DC 18 Wisdom saving throw against this magic or become frightened for 1 minute. The frightened target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success. If a target's saving throw is successful or the effect ends for it, the target is immune to the lich's gaze for the next 24 hours.\n\n***Disrupt Life (Costs 3 Actions).*** Each living creature within 20 feet of the lich must make a DC 18 Constitution saving throw against this magic, taking 21 (6d6) necrotic damage on a failed save, or half as much damage on a successful one."));
}
