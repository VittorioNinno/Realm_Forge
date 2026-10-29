using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Ultroloth (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Ultroloth2014Seeder
{
	public static Monster Build() => Create("ultroloth", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Fiend,
		19, 153, "18d8 + 72", 30, new[] { 16, 16, 18, 18, 15, 19 }, 13m, 10000, 5, 17,
		new Text(
			"Ultroloth",
			null,
			"Immondo Medio (yugoloth), neutrale malvagio",
			"19 (armatura naturale)",
			"9 m, volare 18 m",
			"",
			"Furtività +8, Intimidire +9, Percezione +7",
			"",
			"freddo, fuoco, fulmine; contundenti, perforanti e taglienti da armi non magiche",
			"acido, veleno",
			"affascinato, avvelenato, spaventato",
			"Percezione passiva 17, vista pura 36 m",
			"Abissale, Infernale, telepatia 36 m",
			"***Incantesimi innati.*** L'ultroloth lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 17), senza bisogno di componenti materiali:\n\n- A volontà: *alterare se stesso*, *chiaroveggenza*, *oscurità*, *individuazione del magico*, *individuazione dei pensieri*, *dissolvi magie*, *invisibilità* (solo su se stesso), *suggestione*\n- 3/giorno ciascuno: *porta dimensionale*, *paura*, *muro di fuoco*\n- 1/giorno ciascuno: *tempesta di fuoco*, *suggestione di massa*\n\n***Resistenza alla magia.*** L'ultroloth dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Armi magiche.*** Gli attacchi con arma dell'ultroloth sono considerati magici.",
			"***Multiattacco.*** L'ultroloth può usare il suo Sguardo ipnotico ed effettua tre attacchi in mischia.\n\n***Spada lunga.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d8 + 3) danni taglienti, o 8 (1d10 + 3) danni taglienti se impugnata a due mani.\n\n***Sguardo ipnotico.*** Gli occhi dell'ultroloth lampeggiano di luce opalescente verso una creatura che è in grado di vedere entro 9 metri da lui. Se il bersaglio è in grado di vedere l'ultroloth, effettua un tiro salvezza su Saggezza con CD 17 contro questa magia, altrimenti è affascinato, e stordito finché è affascinato in questo modo, fino alla fine del turno successivo dell'ultroloth. Un bersaglio che lo supera è immune allo sguardo dell'ultroloth per 24 ore.\n\n***Teletrasporto.*** L'ultroloth si teletrasporta magicamente fino a 18 metri in uno spazio libero che è in grado di vedere, insieme a ciò che indossa o trasporta.",
			"",
			"",
			"",
			"Gli ultroloth sono i generali senza volto degli yugoloth, al comando delle schiere mercenarie per conto di chi paga meglio."),
		new Text(
			"Ultroloth",
			null,
			"Medium fiend (yugoloth), neutral evil",
			"19 (natural armor)",
			"30 ft., fly 60 ft.",
			"",
			"Intimidation +9, Perception +7, Stealth +8",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"acid, poison",
			"charmed, frightened, poisoned",
			"truesight 120 ft., passive Perception 17",
			"Abyssal, Infernal, telepathy 120 ft.",
			"***Innate Spellcasting.*** The ultroloth casts the following spells innately, using Charisma (spell save DC 17) and needing no material components:\n\n- At will: *alter self*, *clairvoyance*, *darkness*, *detect magic*, *detect thoughts*, *dispel magic*, *invisibility* (self only), *suggestion*\n- 3/day each: *dimension door*, *fear*, *wall of fire*\n- 1/day each: *fire storm*, *mass suggestion*\n\n***Magic Resistance.*** The ultroloth has advantage on saving throws against spells and other magical effects.\n\n***Magic Weapons.*** The ultroloth's weapon attacks count as magical.",
			"***Multiattack.*** The ultroloth can use its Hypnotic Gaze, and it makes three melee attacks.\n\n***Longsword.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 7 (1d8 + 3) slashing damage, or 8 (1d10 + 3) slashing damage if used with two hands.\n\n***Hypnotic Gaze.*** The ultroloth's eyes flash with opalescent light at a creature it can see within 30 feet of it. If the target can see the ultroloth, it makes a DC 17 Wisdom saving throw against this magic or is charmed, and stunned while charmed this way, until the end of the ultroloth's next turn. A target that succeeds is immune to the ultroloth's gaze for 24 hours.\n\n***Teleport.*** The ultroloth magically teleports up to 60 feet to an unoccupied space it can see, together with whatever it is wearing or carrying.",
			"",
			"",
			"",
			"Ultroloths are the faceless generals of the yugoloths, commanding the mercenary hosts on behalf of whoever pays best."));
}
