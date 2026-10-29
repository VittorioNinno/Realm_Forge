using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Gray Slaad (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GraySlaad2014Seeder
{
	public static Monster Build() => Create("gray-slaad", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Aberration,
		18, 127, "17d8 + 51", 30, new[] { 17, 17, 16, 13, 8, 14 }, 9m, 5000, 4, 16,
		new Text(
			"Slaad grigio",
			null,
			"Aberrazione Media (mutaforma), caotico neutrale",
			"18 (armatura naturale)",
			"9 m",
			"",
			"Arcano +5, Percezione +6",
			"",
			"acido, freddo, fuoco, fulmine, tuono",
			"",
			"",
			"Percezione passiva 16, scurovisione 18 m, vista cieca 18 m",
			"Slaad, telepatia 18 m",
			"***Mutaforma.*** Con un'azione, lo slaad può assumere l'aspetto di un umanoide di taglia Piccola o Media, o tornare alla sua vera forma. A parte la taglia le sue statistiche non cambiano, e ciò che indossa o trasporta non si trasforma. Quando muore torna alla sua vera forma.\n\n***Incantesimi innati.*** Lo slaad lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 14), senza bisogno di componenti materiali:\n\n- A volontà: *individuazione del magico*, *individuazione dei pensieri*, *invisibilità* (solo su se stesso), *mano magica*, *immagine maggiore*\n- 2/giorno ciascuno: *paura*, *palla di fuoco*, *volare*, *linguaggi*\n- 1/giorno: *spostamento planare* (solo su se stesso)\n\n***Resistenza alla magia.*** Lo slaad dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Armi magiche.*** Gli attacchi con arma dello slaad sono considerati magici.\n\n***Rigenerazione.*** All'inizio del suo turno lo slaad recupera 10 punti ferita, purché abbia almeno 1 punto ferita.",
			"***Multiattacco.*** Lo slaad effettua tre attacchi: uno con il morso e due con gli artigli o con lo spadone.\n\n***Morso (solo in forma di slaad).*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni perforanti.\n\n***Artigli (solo in forma di slaad).*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (1d10 + 3) danni taglienti.\n\n***Spadone.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni taglienti.",
			"",
			"",
			"",
			""),
		new Text(
			"Gray Slaad",
			null,
			"Medium aberration (shapechanger), chaotic neutral",
			"18 (natural armor)",
			"30 ft.",
			"",
			"Arcana +5, Perception +6",
			"",
			"acid, cold, fire, lightning, thunder",
			"",
			"",
			"blindsight 60 ft., darkvision 60 ft., passive Perception 16",
			"Slaad, telepathy 60 ft.",
			"***Shapechanger.*** As an action, the slaad can take the shape of a Small or Medium humanoid, or return to its true form. Apart from its size its statistics don't change, and what it wears or carries isn't transformed. It returns to its true form when it dies.\n\n***Innate Spellcasting.*** The slaad casts the following spells innately, using Charisma (spell save DC 14) and needing no material components:\n\n- At will: *detect magic*, *detect thoughts*, *invisibility* (self only), *mage hand*, *major image*\n- 2/day each: *fear*, *fireball*, *fly*, *tongues*\n- 1/day: *plane shift* (self only)\n\n***Magic Resistance.*** The slaad has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The slaad's weapon attacks count as magical.\n\n***Regeneration.*** At the start of its turn, the slaad regains 10 hit points, provided it has at least 1 hit point.",
			"***Multiattack.*** The slaad makes three attacks: one bite and two attacks with its claws or greatsword.\n\n***Bite (Slaad Form Only).*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) piercing damage.\n\n***Claws (Slaad Form Only).*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 8 (1d10 + 3) slashing damage.\n\n***Greatsword.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) slashing damage.",
			"",
			"",
			"",
			""));
}
