using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Shadow (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Shadow2014Seeder
{
	public static Monster Build() => Create("shadow", null, CreatureSize.Medium, CreatureType.Undead,
		12, 16, "3d8 + 3", 40, new[] { 6, 14, 13, 6, 10, 8 }, 0.5m, 100, 2, 10,
		new Text(
			"Ombra",
			null,
			"Non morto Medio, caotica malvagia",
			"12",
			"12 m",
			"",
			"Furtività +4 (+6 in condizioni di luce fioca o oscurità)",
			"radiosi",
			"acido, freddo, fuoco, fulmine, tuono; contundenti, perforanti e taglienti da attacchi non magici",
			"necrotici, veleno",
			"afferrato, avvelenato, indebolimento, paralizzato, pietrificato, prono, spaventato, trattenuto",
			"Percezione passiva 10, scurovisione 18 m",
			"—",
			"***Amorfo.*** L'ombra può muoversi attraverso uno spazio stretto fino a 2,5 centimetri senza doversi stringere.\n\n***Debolezza al sole.*** Quando è esposta alla luce del sole, l'ombra subisce svantaggio ai tiri per colpire, alle prove di caratteristica e ai tiri salvezza.\n\n***Furtività d'ombra.*** Quando si trova in condizioni di luce fioca o oscurità, l'ombra può nascondersi come azione bonus.",
			"***Risucchio di forza.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 9 (2d6 + 2) danni necrotici e il punteggio di Forza del bersaglio è ridotto di 1d4. Se questo porta la sua Forza a 0, il bersaglio muore. Altrimenti, questa riduzione dura finché il bersaglio non termina un riposo breve o lungo. Se a causa di questo attacco muore un umanoide non malvagio, una nuova ombra emerge dal cadavere 1d4 ore dopo.",
			"",
			""),
		new Text(
			"Shadow",
			null,
			"Medium undead, chaotic evil",
			"12",
			"40 ft.",
			"",
			"Stealth +4",
			"radiant",
			"acid, cold, fire, lightning, thunder; bludgeoning, piercing, and slashing from nonmagical weapons",
			"necrotic, poison",
			"exhaustion, frightened, grappled, paralyzed, petrified, poisoned, prone, restrained",
			"darkvision 60 ft., passive Perception 10",
			"—",
			"***Amorphous.*** The shadow can move through a space as narrow as 1 inch wide without squeezing.\n\n***Shadow Stealth.*** While in dim light or darkness, the shadow can take the Hide action as a bonus action. Its stealth bonus is also improved to +6.\n\n***Sunlight Weakness.*** While in sunlight, the shadow has disadvantage on attack rolls, ability checks, and saving throws.",
			"***Strength Drain.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 9 (2d6 + 2) necrotic damage, and the target's Strength score is reduced by 1d4. The target dies if this reduces its Strength to 0. Otherwise, the reduction lasts until the target finishes a short or long rest.\n\nIf a non-evil humanoid dies from this attack, a new shadow rises from the corpse 1d4 hours later.",
			"",
			""));
}
