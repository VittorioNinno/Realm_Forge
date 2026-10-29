using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Flameskull (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Flameskull2014Seeder
{
	public static Monster Build() => Create("flameskull", null, ContentSource.RealmForge, CreatureSize.Tiny, CreatureType.Undead,
		13, 40, "9d4 + 18", 0, new[] { 1, 17, 14, 16, 10, 11 }, 4m, 1100, 2, 12,
		new Text(
			"Teschio infuocato",
			null,
			"Non morto Minuscolo, neutrale malvagio",
			"13",
			"0 m, volare 12 m",
			"",
			"Arcano +5, Percezione +2",
			"",
			"fulmine, necrotici, perforanti",
			"freddo, fuoco, veleno",
			"affascinato, avvelenato, paralizzato, spaventato",
			"Percezione passiva 12, scurovisione 18 m",
			"Comune",
			"***Luminosità.*** Il teschio infuocato emana luce fioca in un raggio di 4,5 metri, oppure luce intensa in un raggio di 4,5 metri e luce fioca per altri 4,5 metri. Passare da un'opzione all'altra richiede un'azione.\n\n***Resistenza alla magia.*** Il teschio infuocato dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Ringiovanimento.*** Quando viene distrutto, il teschio infuocato recupera tutti i suoi punti ferita dopo 1 ora, a meno che i suoi resti non vengano cosparsi d'acqua santa o bersagliati da un incantesimo *dissolvi magie* o *rimuovi maledizione*.\n\n***Incantesimi.*** Il teschio infuocato lancia incantesimi come un incantatore di 5° livello, usando l'Intelligenza (CD del tiro salvezza sull'incantesimo 13, +5 al tiro per colpire con attacco con incantesimo), senza componenti somatiche o materiali. Ha preparati i seguenti incantesimi da mago:\n\n- Trucchetto (a volontà): *mano magica*\n- 1° livello (3 slot): *dardo incantato*, *scudo*\n- 2° livello (2 slot): *sfocatura*, *sfera infuocata*\n- 3° livello (1 slot): *palla di fuoco*",
			"***Multiattacco.*** Il teschio infuocato usa due volte Raggio di fuoco.\n\n***Raggio di fuoco.*** *Attacco con incantesimo a distanza:* +5 al tiro per colpire, gittata 9 m, un bersaglio. *Colpito:* 10 (3d6) danni da fuoco.",
			"",
			"",
			"",
			""),
		new Text(
			"Flameskull",
			null,
			"Tiny undead, neutral evil",
			"13",
			"0 ft., fly 40 ft.",
			"",
			"Arcana +5, Perception +2",
			"",
			"lightning, necrotic, piercing",
			"cold, fire, poison",
			"charmed, frightened, paralyzed, poisoned",
			"darkvision 60 ft., passive Perception 12",
			"Common",
			"***Illumination.*** The flameskull gives off either dim light in a 15-foot radius, or bright light in a 15-foot radius plus dim light for another 15 feet. Switching between the two takes an action.\n\n***Magic Resistance.*** The flameskull has advantage on saving throws against spells and other magical effects.\n\n***Rejuvenation.*** When destroyed, the flameskull gets back all its hit points after 1 hour, unless its remains are sprinkled with holy water or targeted by a dispel magic or remove curse spell.\n\n***Spellcasting.*** The flameskull casts spells as a 5th-level spellcaster, using Intelligence (spell save DC 13, +5 to hit with spell attacks), without somatic or material components. It has these wizard spells prepared:\n\n- Cantrip (at will): *mage hand*\n- 1st level (3 slots): *magic missile*, *shield*\n- 2nd level (2 slots): *blur*, *flaming sphere*\n- 3rd level (1 slot): *fireball*",
			"***Multiattack.*** The flameskull uses Fire Ray twice.\n\n***Fire Ray.*** *Ranged Spell Attack:* +5 to hit, range 30 ft., one target. *Hit:* 10 (3d6) fire damage.",
			"",
			"",
			"",
			""));
}
