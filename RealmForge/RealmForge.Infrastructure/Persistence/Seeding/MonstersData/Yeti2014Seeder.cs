using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Yeti (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Yeti2014Seeder
{
	public static Monster Build() => Create("yeti", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Monstrosity,
		12, 51, "6d10 + 18", 40, new[] { 18, 13, 16, 8, 12, 7 }, 3m, 700, 2, 13,
		new Text(
			"Yeti",
			null,
			"Mostruosità Grande, caotico malvagio",
			"12 (armatura naturale)",
			"12 m, scalare 12 m",
			"",
			"Furtività +3, Percezione +3",
			"",
			"",
			"freddo",
			"",
			"Percezione passiva 13, scurovisione 18 m",
			"Yeti",
			"***Paura del fuoco.*** Ogni volta che subisce danni da fuoco, lo yeti subisce svantaggio ai tiri per colpire e alle prove di caratteristica fino alla fine del suo turno successivo.\n\n***Olfatto acuto.*** Lo yeti dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.\n\n***Mimetismo nella neve.*** Lo yeti dispone di vantaggio alle prove di Destrezza (Furtività) per nascondersi su un terreno innevato.",
			"***Multiattacco.*** Lo yeti può usare il suo Sguardo agghiacciante ed effettua due attacchi con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d6 + 4) danni taglienti più 3 (1d6) danni da freddo.\n\n***Sguardo agghiacciante.*** Lo yeti bersaglia una creatura che è in grado di vedere entro 9 metri da lui. Se il bersaglio è in grado di vedere lo yeti, effettua un tiro salvezza su Costituzione con CD 13 contro questa magia; se lo fallisce subisce 10 (3d6) danni da freddo e, a meno che non sia immune ai danni da freddo, è paralizzato per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo. Un bersaglio che lo supera, o la cui paralisi termina, è immune allo Sguardo agghiacciante di tutti gli yeti (esclusi gli yeti abominevoli) per 1 ora.",
			"",
			"",
			"",
			"Gli yeti vagano sulle vette più remote, quasi invisibili contro la neve, e fiutano la carne viva a chilometri di distanza; la fame può spingerli ad assaltare gli insediamenti."),
		new Text(
			"Yeti",
			null,
			"Large monstrosity, chaotic evil",
			"12 (natural armor)",
			"40 ft., climb 40 ft.",
			"",
			"Perception +3, Stealth +3",
			"",
			"",
			"cold",
			"",
			"darkvision 60 ft., passive Perception 13",
			"Yeti",
			"***Fear of Fire.*** Whenever the yeti takes fire damage, it has disadvantage on attack rolls and ability checks until the end of its next turn.\n\n***Keen Smell.*** The yeti has advantage on Wisdom (Perception) checks that rely on smell.\n\n***Snow Camouflage.*** The yeti has advantage on Dexterity (Stealth) checks to hide in snowy terrain.",
			"***Multiattack.*** The yeti can use its Chilling Gaze, and it makes two claw attacks.\n\n***Claw.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 7 (1d6 + 4) slashing damage plus 3 (1d6) cold damage.\n\n***Chilling Gaze.*** The yeti targets a creature it can see within 30 feet of it. If the target can see the yeti, it makes a DC 13 Constitution saving throw against this magic; on a failure it takes 10 (3d6) cold damage and, unless it is immune to cold damage, is paralyzed for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success. A target that succeeds, or whose paralysis ends, is immune to the Chilling Gaze of every yeti (abominable yetis excluded) for 1 hour.",
			"",
			"",
			"",
			"Yetis roam remote mountain peaks, nearly invisible against the snow, and can scent living flesh from miles away; hunger can drive them to raid settlements."));
}
