using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Glabrezu (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Glabrezu2014Seeder
{
	public static Monster Build() => Create("glabrezu", null, CreatureSize.Large, CreatureType.Fiend,
		17, 157, "15d10 + 75", 40, new[] { 20, 15, 21, 19, 17, 16 }, 9m, 5000, 4, 13,
		new Text(
			"Glabrezu",
			null,
			"Immondo Grande (demone), caotico malvagio",
			"17 (armatura naturale)",
			"12 m",
			"Car +7, Cos +9, For +9, Sag +7",
			"",
			"",
			"freddo, fulmine, fuoco; contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"avvelenato",
			"Percezione passiva 13, vista pura 36 m",
			"Abissale, telepatia 36 m",
			"***Incantesimi innati.*** La caratteristica da incantatore del glabrezu è Intelligenza (CD del tiro salvezza sull'incantesimo 16). Per sua natura, il glabrezu è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *dissolvi magie, individuazione del magico, oscurità*\n- 1/giorno ciascuno: *confusione, parola del potere stordire, volare*\n\n***Resistenza alla magia.*** Il glabrezu dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Multiattacco.*** Il glabrezu effettua quattro attacchi: due con le tenaglie e due con i pugni. In alternativa, effettua due attacchi con le tenaglie e lancia un incantesimo.\n\n***Pugno.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (2d4 + 2) danni contundenti.\n\n***Tenaglia.*** *Attacco con arma da mischia:* +9 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 16 (2d10 + 5) danni contundenti. Se il bersaglio è una creatura di taglia Media o inferiore, viene afferrato (CD 15 per sfuggire). Il glabrezu ha due tenaglie, ognuna delle quali può afferrare solo un bersaglio.",
			"",
			""),
		new Text(
			"Glabrezu",
			null,
			"Large fiend (demon), chaotic evil",
			"17 (natural armor)",
			"40 ft.",
			"Str +9, Con +9, Wis +7, Cha +7",
			"",
			"",
			"cold, fire, lightning; bludgeoning, piercing, and slashing from nonmagical weapons",
			"poison",
			"poisoned",
			"truesight 120 ft., passive Perception 13",
			"Abyssal, telepathy 120 ft.",
			"***Innate Spellcasting.*** The glabrezu's spellcasting ability is Intelligence (spell save DC 16). The glabrezu can innately cast the following spells, requiring no material components:\n\n- At will: *darkness, detect magic, dispel magic*\n- 1/day each: *confusion, fly, power word stun*\n\n***Magic Resistance.*** The glabrezu has advantage on saving throws against spells and other magical effects.",
			"***Multiattack.*** The glabrezu makes four attacks: two with its pincers and two with its fists. Alternatively, it makes two attacks with its pincers and casts one spell.\n\n***Pincer.*** *Melee Weapon Attack:* +9 to hit, reach 10 ft., one target. *Hit:* 16 (2d10 + 5) bludgeoning damage. If the target is a Medium or smaller creature, it is grappled (escape DC 15). The glabrezu has two pincers, each of which can grapple only one target.\n\n***Fist.*** *Melee Weapon Attack:* +9 to hit, reach 5 ft., one target. *Hit:* 7 (2d4 + 2) bludgeoning damage.",
			"",
			""));
}
