using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Thri-kreen (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class ThriKreen2014Seeder
{
	public static Monster Build() => Create("thri-kreen", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		15, 33, "6d8 + 6", 40, new[] { 12, 15, 13, 8, 12, 7 }, 1m, 200, 2, 13,
		new Text(
			"Thri-kreen",
			null,
			"Umanoide Medio (thri-kreen), caotico neutrale",
			"15 (armatura naturale)",
			"12 m",
			"",
			"Furtività +4, Percezione +3, Sopravvivenza +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, scurovisione 18 m",
			"Thri-kreen",
			"***Carapace mimetico.*** Il thri-kreen può cambiare il colore e la trama del suo carapace per confondersi con l'ambiente, perciò dispone di vantaggio alle prove di Destrezza (Furtività) per nascondersi.\n\n***Salto da fermo.*** Con o senza rincorsa, il thri-kreen può saltare fino a 9 metri in lungo e fino a 4,5 metri in alto.",
			"***Multiattacco.*** Il thri-kreen effettua due attacchi: uno con il morso e uno con gli artigli.\n\n***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 4 (1d6 + 1) danni perforanti. Il bersaglio effettua un tiro salvezza su Costituzione con CD 11, altrimenti è avvelenato per 1 minuto; se lo fallisce di 5 o più, resta anche paralizzato finché è avvelenato in questo modo. Ripete il tiro salvezza in ogni suo turno e l'effetto termina con un successo.\n\n***Artigli.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (2d4 + 1) danni taglienti.",
			"",
			"",
			"",
			"Variante con armi: un thri-kreen con una gythka (un'arma ad asta a due mani con una lama a ciascuna estremità) e dei chatkcha (cunei da lancio leggeri con tre lame seghettate) può effettuare come Multiattacco due attacchi con la gythka (+3 al tiro per colpire, portata 1,5 m, 5 (1d8 + 1) danni taglienti) o due con i chatkcha (+4 al tiro per colpire, gittata 9/36 m, 5 (1d6 + 2) danni taglienti).\n\nVariante psionica: un thri-kreen psionico ha telepatia 18 m e lancia per natura, usando la Saggezza e senza bisogno di componenti, *mano magica* (la mano è invisibile) a volontà, *sfocatura* e *arma magica* 2/giorno ciascuno, e *invisibilità* (solo su se stesso) 1/giorno."),
		new Text(
			"Thri-kreen",
			null,
			"Medium humanoid (thri-kreen), chaotic neutral",
			"15 (natural armor)",
			"40 ft.",
			"",
			"Perception +3, Stealth +4, Survival +3",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 13",
			"Thri-kreen",
			"***Chameleon Carapace.*** The thri-kreen can change the color and pattern of its carapace to match its surroundings, so it has advantage on Dexterity (Stealth) checks to hide.\n\n***Standing Leap.*** With or without a run-up, the thri-kreen can long jump up to 30 feet and high jump up to 15 feet.",
			"***Multiattack.*** The thri-kreen makes two attacks: one with its bite and one with its claws.\n\n***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one creature. *Hit:* 4 (1d6 + 1) piercing damage. The target makes a DC 11 Constitution saving throw or is poisoned for 1 minute; if it fails by 5 or more, it is also paralyzed for as long as it is poisoned this way. It repeats the save on each of its turns, ending the effect on a success.\n\n***Claws.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 6 (2d4 + 1) slashing damage.",
			"",
			"",
			"",
			"Variant weapons: a thri-kreen with a gythka (a two-handed polearm with a blade at each end) and chatkchas (light thrown wedges with three serrated blades) can make two gythka attacks (+3 to hit, reach 5 ft., 5 (1d8 + 1) slashing damage) or two chatkcha attacks (+4 to hit, range 30/120 ft., 5 (1d6 + 2) slashing damage) as its Multiattack.\n\nVariant psionics: a psionic thri-kreen has telepathy 60 ft. and casts innately, using Wisdom and needing no components, mage hand (the hand is invisible) at will, blur and magic weapon 2/day each, and invisibility (self only) 1/day."));
}
