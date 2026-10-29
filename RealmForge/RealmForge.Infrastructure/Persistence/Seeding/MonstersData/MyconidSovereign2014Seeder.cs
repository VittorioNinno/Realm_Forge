using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Myconid Sovereign (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class MyconidSovereign2014Seeder
{
	public static Monster Build() => Create("myconid-sovereign", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Plant,
		13, 60, "8d10 + 16", 30, new[] { 12, 10, 14, 13, 15, 10 }, 2m, 450, 2, 12,
		new Text(
			"Miconide sovrano",
			null,
			"Vegetale Grande, legale neutrale",
			"13 (armatura naturale)",
			"9 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, scurovisione 36 m",
			"—",
			"***Spore di allarme.*** Quando il miconide subisce danni, ogni altro miconide entro 72 metri da lui ne avverte il dolore.\n\n***Malattia del sole.*** Alla luce del sole, il miconide subisce svantaggio alle prove di caratteristica, ai tiri per colpire e ai tiri salvezza; muore se trascorre più di 1 ora alla luce diretta del sole.",
			"***Multiattacco.*** Il miconide usa Spore allucinogene o Spore pacificanti, poi effettua un attacco con il pugno.\n\n***Pugno.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 8 (3d4 + 1) danni contundenti più 7 (3d4) danni da veleno.\n\n***Spore animatrici (3/giorno).*** Il miconide spruzza spore sul cadavere di un umanoide, o di una bestia di taglia Grande o inferiore, entro 1,5 metri da lui. Dopo 24 ore il cadavere si rialza come servitore delle spore, che resta animato per 1d4 + 1 settimane o finché non viene distrutto; non può essere animato di nuovo in questo modo.\n\n***Spore allucinogene.*** Il miconide spruzza spore contro una creatura che è in grado di vedere entro 1,5 metri da lui, che effettua un tiro salvezza su Costituzione con CD 12, altrimenti è avvelenata per 1 minuto e, finché è avvelenata, incapacitata dalle visioni. Ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.\n\n***Spore pacificanti.*** Il miconide spruzza spore contro una creatura che è in grado di vedere entro 1,5 metri da lui, che effettua un tiro salvezza su Costituzione con CD 12, altrimenti è stordita per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e l'effetto termina con un successo.\n\n***Spore di intesa.*** Il miconide rilascia spore in un raggio di 9 metri attorno a sé; le spore si propagano oltre gli angoli e agiscono solo sulle creature con Intelligenza 2 o superiore che non siano non morti, costrutti o elementali. Per 1 ora, quelle creature possono comunicare telepaticamente tra loro finché si trovano entro 9 metri l'una dall'altra.",
			"",
			"",
			"",
			""),
		new Text(
			"Myconid Sovereign",
			null,
			"Large plant, lawful neutral",
			"13 (natural armor)",
			"30 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 12",
			"—",
			"***Distress Spores.*** When the myconid takes damage, every other myconid within 240 feet of it feels its pain.\n\n***Sun Sickness.*** In sunlight, the myconid has disadvantage on ability checks, attack rolls and saving throws; it dies after spending more than 1 hour in direct sunlight.",
			"***Multiattack.*** The myconid uses Hallucination Spores or Pacifying Spores, then makes a fist attack.\n\n***Fist.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 8 (3d4 + 1) bludgeoning damage plus 7 (3d4) poison damage.\n\n***Animating Spores (3/Day).*** The myconid sprays spores on the corpse of a humanoid, or of a Large or smaller beast, within 5 feet of it. After 24 hours the corpse rises as a spore servant, which stays animated for 1d4 + 1 weeks or until destroyed; it can't be animated this way again.\n\n***Hallucination Spores.*** The myconid sprays spores at a creature it can see within 5 feet of it, which makes a DC 12 Constitution saving throw or is poisoned for 1 minute, and incapacitated by visions for as long as it is poisoned. It repeats the save at the end of each of its turns, ending the effect on a success.\n\n***Pacifying Spores.*** The myconid sprays spores at a creature it can see within 5 feet of it, which makes a DC 12 Constitution saving throw or is stunned for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success.\n\n***Rapport Spores.*** The myconid releases spores in a 30-foot radius around it; they spread around corners and affect only creatures with Intelligence 2 or higher that aren't undead, constructs or elementals. For 1 hour, those creatures can talk telepathically with each other while within 30 feet of one another.",
			"",
			"",
			"",
			""));
}
