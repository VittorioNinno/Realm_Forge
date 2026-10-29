using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Chuul (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Chuul2014Seeder
{
	public static Monster Build() => Create("chuul", null, CreatureSize.Large, CreatureType.Aberration,
		16, 93, "11d10 + 33", 30, new[] { 19, 10, 16, 5, 11, 5 }, 4m, 1100, 2, 14,
		new Text(
			"Chuul",
			null,
			"Aberrazione Grande, caotico malvagio",
			"16 (armatura naturale)",
			"9 m, nuotare 9 m",
			"",
			"Percezione +4",
			"",
			"",
			"veleno",
			"avvelenato",
			"Percezione passiva 14, scurovisione 18 m",
			"capisce il Gergo delle profondità ma non lo parla",
			"***Anfibio.*** Il chuul può respirare in aria e in acqua.\n\n***Percezione della magia.*** Il chuul percepisce la magia entro 36 metri da sé a volontà. Sotto ogni altro aspetto questo tratto funziona come l'incantesimo *individuazione del magico,* ma di per sé non è magico.",
			"***Multiattacco.*** Il chuul effettua due attacchi con le tenaglie. Se il chuul afferra una creatura, può usare anche i tentacoli una volta.\n\n***Tenaglia.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni contundenti. Il bersaglio è afferrato (CD 14 per sfuggire) se si tratta di una creatura di taglia Grande o inferiore e il chuul non è in lotta con altre due creature.\n\n***Tentacoli.*** Una creatura afferrata dal chuul deve superare un tiro salvezza su Costituzione con CD 13, altrimenti è avvelenata per 1 minuto. Finché l'avvelenamento non termina, il bersaglio è paralizzato. Il bersaglio può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			""),
		new Text(
			"Chuul",
			null,
			"Large aberration, chaotic evil",
			"16 (natural armor)",
			"30 ft., swim 30 ft.",
			"",
			"Perception +4",
			"",
			"",
			"poison",
			"poisoned",
			"darkvision 60 ft., passive Perception 14",
			"understands Deep Speech but can't speak",
			"***Amphibious.*** The chuul can breathe air and water.\n\n***Sense Magic.*** The chuul senses magic within 120 feet of it at will. This trait otherwise works like the detect magic spell but isn't itself magical.",
			"***Multiattack.*** The chuul makes two pincer attacks. If the chuul is grappling a creature, the chuul can also use its tentacles once.\n\n***Pincer.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one target. *Hit:* 11 (2d6 + 4) bludgeoning damage. The target is grappled (escape DC 14) if it is a Large or smaller creature and the chuul doesn't have two other creatures grappled.\n\n***Tentacles.*** One creature grappled by the chuul must succeed on a DC 13 Constitution saving throw or be poisoned for 1 minute. Until this poison ends, the target is paralyzed. The target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success.",
			"",
			""));
}
