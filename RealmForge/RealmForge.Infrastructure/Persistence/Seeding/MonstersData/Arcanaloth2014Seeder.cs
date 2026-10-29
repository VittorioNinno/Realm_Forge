using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Arcanaloth (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Arcanaloth2014Seeder
{
	public static Monster Build() => Create("arcanaloth", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Fiend,
		17, 104, "16d8 + 32", 30, new[] { 17, 12, 14, 20, 16, 17 }, 12m, 8400, 4, 17,
		new Text(
			"Arcanaloth",
			null,
			"Immondo Medio (yugoloth), neutrale malvagio",
			"17 (armatura naturale)",
			"9 m, volare 9 m",
			"Car +7, Des +5, Int +9, Sag +7",
			"Arcano +13, Inganno +9, Intuizione +9, Percezione +7",
			"",
			"freddo, fuoco, fulmine; contundenti, perforanti e taglienti da armi non magiche",
			"acido, veleno",
			"affascinato, avvelenato",
			"Percezione passiva 17, vista pura 36 m",
			"tutti, telepatia 36 m",
			"***Incantesimi innati.*** L'arcanaloth lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 15), senza bisogno di componenti materiali:\n\n- A volontà: *alterare se stesso*, *oscurità*, *riscaldare il metallo*, *invisibilità* (solo su se stesso), *dardo incantato*\n\n***Resistenza alla magia.*** L'arcanaloth dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Armi magiche.*** Gli attacchi con arma dell'arcanaloth sono considerati magici.\n\n***Incantesimi.*** L'arcanaloth lancia incantesimi come un incantatore di 16° livello, usando l'Intelligenza (CD del tiro salvezza sull'incantesimo 17, +9 al tiro per colpire con attacco con incantesimo). Ha preparati i seguenti incantesimi da mago:\n\n- Trucchetti (a volontà): *dardo di fuoco*, *mano magica*, *illusione minore*, *prestidigitazione*\n- 1° livello (4 slot): *individuazione del magico*, *identificare*, *scudo*, *disco fluttuante di Tenser*\n- 2° livello (3 slot): *individuazione dei pensieri*, *immagine speculare*, *allucinazione di forza*, *suggestione*\n- 3° livello (3 slot): *controincantesimo*, *paura*, *palla di fuoco*\n- 4° livello (3 slot): *esilio*, *porta dimensionale*\n- 5° livello (2 slot): *contattare altri piani*, *blocca mostri*\n- 6° livello (1 slot): *catena di fulmini*\n- 7° livello (1 slot): *dito della morte*\n- 8° livello (1 slot): *vuoto mentale*",
			"***Artigli.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (2d4 + 3) danni taglienti. Il bersaglio effettua un tiro salvezza su Costituzione con CD 14 e subisce 10 (3d6) danni da veleno se lo fallisce, o la metà di quei danni se lo supera.\n\n***Teletrasporto.*** L'arcanaloth si teletrasporta magicamente fino a 18 metri in uno spazio libero che è in grado di vedere, insieme a ciò che indossa o trasporta.",
			"",
			"",
			"",
			"Gli arcanaloth sono gli studiosi e gli scribi degli yugoloth: immondi dalla testa di sciacallo che redigono contratti e custodiscono archivi, di solito sotto un ingannevole aspetto umano."),
		new Text(
			"Arcanaloth",
			null,
			"Medium fiend (yugoloth), neutral evil",
			"17 (natural armor)",
			"30 ft., fly 30 ft.",
			"Dex +5, Int +9, Wis +7, Cha +7",
			"Arcana +13, Deception +9, Insight +9, Perception +7",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"acid, poison",
			"charmed, poisoned",
			"truesight 120 ft., passive Perception 17",
			"all, telepathy 120 ft.",
			"***Innate Spellcasting.*** The arcanaloth casts the following spells innately, using Charisma (spell save DC 15) and needing no material components:\n\n- At will: *alter self*, *darkness*, *heat metal*, *invisibility* (self only), *magic missile*\n\n***Magic Resistance.*** The arcanaloth has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The arcanaloth's weapon attacks count as magical.\n\n***Spellcasting.*** The arcanaloth casts spells as a 16th-level spellcaster, using Intelligence (spell save DC 17, +9 to hit with spell attacks). It has these wizard spells prepared:\n\n- Cantrips (at will): *fire bolt*, *mage hand*, *minor illusion*, *prestidigitation*\n- 1st level (4 slots): *detect magic*, *identify*, *shield*, *Tenser's floating disk*\n- 2nd level (3 slots): *detect thoughts*, *mirror image*, *phantasmal force*, *suggestion*\n- 3rd level (3 slots): *counterspell*, *fear*, *fireball*\n- 4th level (3 slots): *banishment*, *dimension door*\n- 5th level (2 slots): *contact other plane*, *hold monster*\n- 6th level (1 slot): *chain lightning*\n- 7th level (1 slot): *finger of death*\n- 8th level (1 slot): *mind blank*",
			"***Claws.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 8 (2d4 + 3) slashing damage. The target makes a DC 14 Constitution saving throw, taking 10 (3d6) poison damage on a failure or half as much on a success.\n\n***Teleport.*** The arcanaloth magically teleports up to 60 feet to an unoccupied space it can see, together with whatever it is wearing or carrying.",
			"",
			"",
			"",
			"Arcanaloths are the scholars and scribes of the yugoloths: jackal-headed fiends who draw up contracts and keep records, usually in a deceptively human guise."));
}
