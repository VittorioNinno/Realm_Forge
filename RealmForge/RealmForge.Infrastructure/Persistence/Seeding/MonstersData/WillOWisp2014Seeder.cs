using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Will-o'-Wisp (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class WillOWisp2014Seeder
{
	public static Monster Build() => Create("will-o-wisp", null, CreatureSize.Tiny, CreatureType.Undead,
		19, 22, "9d4", 0, new[] { 1, 28, 10, 13, 14, 11 }, 2m, 450, 2, 12,
		new Text(
			"Fuoco fatuo",
			null,
			"Non morto Minuscolo, caotico malvagio",
			"19",
			"0 m, volare 15 m (fluttuare)",
			"",
			"",
			"",
			"acido, freddo, fuoco, necrotici, tuono; contundenti, perforanti e taglienti da attacchi non magici",
			"fulmine, veleno",
			"afferrato, avvelenato, indebolimento, paralizzato, privo di sensi, prono, trattenuto",
			"Percezione passiva 12, scurovisione 36 m",
			"quelli conosciuti in vita",
			"***Assorbire vita.*** Con un'azione bonus, il fuoco fatuo può prendere di mira una creatura nel suo campo visivo in un raggio di 1,5 metri che abbia 0 punti ferita e sia ancora viva. Il bersaglio deve superare un tiro salvezza su Costituzione con CD 10 contro questa magia, altrimenti muore. Se il bersaglio muore, il fuoco fatuo recupera 10 (3d6) punti ferita.\n\n***Effimero.*** Il fuoco fatuo non può indossare o trasportare niente.\n\n***Illuminazione variabile.*** Il fuoco fatuo proietta luce intensa in un raggio da 1,5 a 6 metri e luce fioca per un numero aggiuntivo di metri pari al raggio scelto. Il fuoco fatuo può alterare il raggio con un'azione bonus.\n\n***Movimento incorporeo.*** Il fuoco fatuo è in grado di attraversare oggetti e creature come se si trattasse di terreno difficile. Subisce 5 (1d10) danni da forza se termina il proprio turno all'interno di un oggetto.",
			"***Folgore.*** *Attacco in mischia con incantesimo:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 9 (2d8) danni da fulmine.\n\n***Invisibilità.*** Il fuoco fatuo e la sua luce diventano magicamente invisibili finché esso non attacca, non usa Assorbire vita o non perde la concentrazione (come se si concentrasse su un incantesimo).",
			"",
			""),
		new Text(
			"Will-o'-Wisp",
			null,
			"Tiny undead, chaotic evil",
			"19",
			"0 ft., fly 50 ft. (hover)",
			"",
			"",
			"",
			"acid, cold, fire, necrotic, thunder; bludgeoning, piercing, and slashing from nonmagical weapons",
			"lightning, poison",
			"exhaustion, grappled, paralyzed, poisoned, prone, restrained, unconscious",
			"darkvision 120 ft., passive Perception 12",
			"the languages it knew in life",
			"***Consume Life.*** As a bonus action, the will-o'-wisp can target one creature it can see within 5 ft. of it that has 0 hit points and is still alive. The target must succeed on a DC 10 Constitution saving throw against this magic or die. If the target dies, the will-o'-wisp regains 10 (3d6) hit points.\n\n***Ephemeral.*** The will-o'-wisp can't wear or carry anything.\n\n***Incorporeal Movement.*** The will-o'-wisp can move through other creatures and objects as if they were difficult terrain. It takes 5 (1d10) force damage if it ends its turn inside an object.\n\n***Variable Illumination.*** The will-o'-wisp sheds bright light in a 5- to 20-foot radius and dim light for an additional number of ft. equal to the chosen radius. The will-o'-wisp can alter the radius as a bonus action.",
			"***Shock.*** *Melee Spell Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 9 (2d8) lightning damage.\n\n***Invisibility.*** The will-o'-wisp and its light magically become invisible until it attacks or uses its Consume Life, or until its concentration ends (as if concentrating on a spell).",
			"",
			""));
}
