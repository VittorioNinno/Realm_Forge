using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Green Slaad (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GreenSlaad2014Seeder
{
	public static Monster Build() => Create("green-slaad", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Aberration,
		16, 127, "15d10 + 45", 30, new[] { 18, 15, 16, 11, 8, 12 }, 8m, 3900, 3, 12,
		new Text(
			"Slaad verde",
			null,
			"Aberrazione Grande (mutaforma), caotico neutrale",
			"16 (armatura naturale)",
			"9 m",
			"",
			"Arcano +3, Percezione +2",
			"",
			"acido, freddo, fuoco, fulmine, tuono",
			"",
			"",
			"Percezione passiva 12, scurovisione 18 m, vista cieca 9 m",
			"Slaad, telepatia 18 m",
			"***Mutaforma.*** Con un'azione, lo slaad può assumere l'aspetto di un umanoide di taglia Piccola o Media, o tornare alla sua vera forma. A parte la taglia le sue statistiche non cambiano, e ciò che indossa o trasporta non si trasforma. Quando muore torna alla sua vera forma.\n\n***Incantesimi innati.*** Lo slaad lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 12), senza bisogno di componenti materiali:\n\n- A volontà: *individuazione del magico*, *individuazione dei pensieri*, *mano magica*\n- 2/giorno ciascuno: *paura*, *invisibilità* (solo su se stesso)\n- 1/giorno: *palla di fuoco*\n\n***Resistenza alla magia.*** Lo slaad dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Rigenerazione.*** All'inizio del suo turno lo slaad recupera 10 punti ferita, purché abbia almeno 1 punto ferita.",
			"***Multiattacco.*** Lo slaad effettua tre attacchi: uno con il morso e due con gli artigli o con il bastone. In alternativa, usa due volte Scagliare fiamme.\n\n***Morso (solo in forma di slaad).*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni perforanti.\n\n***Artiglio (solo in forma di slaad).*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d6 + 4) danni taglienti.\n\n***Bastone.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti.\n\n***Scagliare fiamme.*** *Attacco con incantesimo a distanza:* +4 al tiro per colpire, gittata 18 m, un bersaglio. *Colpito:* 10 (3d6) danni da fuoco. Il fuoco incendia gli oggetti infiammabili che nessuno indossa o trasporta.",
			"",
			"",
			"",
			""),
		new Text(
			"Green Slaad",
			null,
			"Large aberration (shapechanger), chaotic neutral",
			"16 (natural armor)",
			"30 ft.",
			"",
			"Arcana +3, Perception +2",
			"",
			"acid, cold, fire, lightning, thunder",
			"",
			"",
			"blindsight 30 ft., darkvision 60 ft., passive Perception 12",
			"Slaad, telepathy 60 ft.",
			"***Shapechanger.*** As an action, the slaad can take the shape of a Small or Medium humanoid, or return to its true form. Apart from its size its statistics don't change, and what it wears or carries isn't transformed. It returns to its true form when it dies.\n\n***Innate Spellcasting.*** The slaad casts the following spells innately, using Charisma (spell save DC 12) and needing no material components:\n\n- At will: *detect magic*, *detect thoughts*, *mage hand*\n- 2/day each: *fear*, *invisibility* (self only)\n- 1/day: *fireball*\n\n***Magic Resistance.*** The slaad has advantage on saving throws against spells and other magical effects.\n\n***Regeneration.*** At the start of its turn, the slaad regains 10 hit points, provided it has at least 1 hit point.",
			"***Multiattack.*** The slaad makes three attacks: one bite and two attacks with its claws or staff. Alternatively, it uses Hurl Flame twice.\n\n***Bite (Slaad Form Only).*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) piercing damage.\n\n***Claw (Slaad Form Only).*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 7 (1d6 + 4) slashing damage.\n\n***Staff.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage.\n\n***Hurl Flame.*** *Ranged Spell Attack:* +4 to hit, range 60 ft., one target. *Hit:* 10 (3d6) fire damage. The fire sets alight flammable objects nobody is wearing or carrying.",
			"",
			"",
			"",
			""));
}
