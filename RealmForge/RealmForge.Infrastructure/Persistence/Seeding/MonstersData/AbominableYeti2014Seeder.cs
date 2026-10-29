using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Abominable Yeti (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class AbominableYeti2014Seeder
{
	public static Monster Build() => Create("abominable-yeti", null, ContentSource.RealmForge, CreatureSize.Huge, CreatureType.Monstrosity,
		15, 137, "11d12 + 66", 40, new[] { 24, 10, 22, 9, 13, 9 }, 9m, 5000, 4, 15,
		new Text(
			"Yeti abominevole",
			null,
			"Mostruosità Enorme, caotico malvagio",
			"15 (armatura naturale)",
			"12 m, scalare 12 m",
			"",
			"Furtività +4, Percezione +5",
			"",
			"",
			"freddo",
			"",
			"Percezione passiva 15, scurovisione 18 m",
			"Yeti",
			"***Paura del fuoco.*** Ogni volta che subisce danni da fuoco, lo yeti subisce svantaggio ai tiri per colpire e alle prove di caratteristica fino alla fine del suo turno successivo.\n\n***Olfatto acuto.*** Lo yeti dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'olfatto.\n\n***Mimetismo nella neve.*** Lo yeti dispone di vantaggio alle prove di Destrezza (Furtività) per nascondersi su un terreno innevato.",
			"***Multiattacco.*** Lo yeti può usare il suo Sguardo agghiacciante ed effettua due attacchi con gli artigli.\n\n***Artiglio.*** *Attacco con arma da mischia:* +11 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 14 (2d6 + 7) danni taglienti più 7 (2d6) danni da freddo.\n\n***Sguardo agghiacciante.*** Lo yeti bersaglia una creatura che è in grado di vedere entro 9 metri da lui. Se il bersaglio è in grado di vedere lo yeti, effettua un tiro salvezza su Costituzione con CD 18 contro questa magia; se lo fallisce subisce 21 (6d6) danni da freddo e, a meno che non sia immune ai danni da freddo, è paralizzato per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo. Un bersaglio che lo supera, o la cui paralisi termina, è immune allo sguardo di questo yeti per 1 ora.\n\n***Soffio gelido (ricarica 6).*** Lo yeti soffia aria gelida in un cono di 9 metri. Ogni creatura nel cono effettua un tiro salvezza su Costituzione con CD 18 e subisce 45 (10d8) danni da freddo se lo fallisce, o la metà di quei danni se lo supera.",
			"",
			"",
			"",
			"Alto tre volte un umano, lo yeti abominevole di solito vive e caccia da solo, divorando qualsiasi creatura a sangue caldo incontri."),
		new Text(
			"Abominable Yeti",
			null,
			"Huge monstrosity, chaotic evil",
			"15 (natural armor)",
			"40 ft., climb 40 ft.",
			"",
			"Perception +5, Stealth +4",
			"",
			"",
			"cold",
			"",
			"darkvision 60 ft., passive Perception 15",
			"Yeti",
			"***Fear of Fire.*** Whenever the yeti takes fire damage, it has disadvantage on attack rolls and ability checks until the end of its next turn.\n\n***Keen Smell.*** The yeti has advantage on Wisdom (Perception) checks that rely on smell.\n\n***Snow Camouflage.*** The yeti has advantage on Dexterity (Stealth) checks to hide in snowy terrain.",
			"***Multiattack.*** The yeti can use its Chilling Gaze, and it makes two claw attacks.\n\n***Claw.*** *Melee Weapon Attack:* +11 to hit, reach 5 ft., one target. *Hit:* 14 (2d6 + 7) slashing damage plus 7 (2d6) cold damage.\n\n***Chilling Gaze.*** The yeti targets a creature it can see within 30 feet of it. If the target can see the yeti, it makes a DC 18 Constitution saving throw against this magic; on a failure it takes 21 (6d6) cold damage and, unless it is immune to cold damage, is paralyzed for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success. A target that succeeds, or whose paralysis ends, is immune to this yeti's gaze for 1 hour.\n\n***Cold Breath (Recharge 6).*** The yeti breathes freezing air in a 30-foot cone. Each creature in the cone makes a DC 18 Constitution saving throw, taking 45 (10d8) cold damage on a failure or half as much on a success.",
			"",
			"",
			"",
			"Three times the height of a human, the abominable yeti usually lives and hunts alone, devouring any warm-blooded creature it meets."));
}
