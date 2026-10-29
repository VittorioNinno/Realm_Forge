using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Archmage (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Archmage2014Seeder
{
	public static Monster Build() => Create("archmage", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Humanoid,
		12, 99, "18d8 + 18", 30, new[] { 10, 14, 12, 20, 15, 16 }, 12m, 8400, 4, 12,
		new Text(
			"Arcimago",
			null,
			"Umanoide Medio (qualsiasi razza), qualsiasi allineamento",
			"12 (15 con armatura magica)",
			"9 m",
			"Int +9, Sag +6",
			"Arcano +13, Storia +13",
			"",
			"danni degli incantesimi; contundenti, perforanti e taglienti non magici (da pelle di pietra)",
			"",
			"",
			"Percezione passiva 12",
			"sei qualsiasi",
			"***Resistenza alla magia.*** L'arcimago dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Incantesimi.*** L'arcimago è un incantatore di 18° livello: la sua caratteristica da incantatore è Intelligenza (CD del tiro salvezza sull'incantesimo 17, +9 al tiro per colpire con attacco con incantesimo). L'arcimago può lanciare *camuffare se stesso* e *invisibilità* a volontà e ha a disposizione i seguenti incantesimi da mago:\n\n- Trucchetti (a volontà): *dardo di fuoco, luce, mano magica, prestidigitazione, stretta folgorante*\n- 1° livello (4 slot): *armatura magica*, dardo incantato, identificare, individuazione del magico*\n- 2° livello (3 slot): *immagine speculare, individuazione dei pensieri, passo velato*\n- 3° livello (3 slot): *controincantesimo, fulmine, volare*\n- 4° livello (3 slot): *esilio, pelle di pietra*, scudo di fuoco*\n- 5° livello (3 slot): *cono di freddo, muro di forza, scrutare*\n- 6° livello (1 slot): *globo di invulnerabilità*\n- 7° livello (1 slot): *teletrasporto*\n- 8° livello (1 slot): *vuoto mentale**\n- 9° livello (1 slot): *fermare il tempo* ** L'arcimago lancia questi incantesimi su se stesso prima del combattimento.*",
			"***Pugnale.*** *Attacco con arma da mischia o con arma a distanza:* +6 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Archmage",
			null,
			"Medium humanoid (any race), any alignment",
			"12 (15 with mage armor)",
			"30 ft.",
			"Int +9, Wis +6",
			"Arcana +13, History +13",
			"",
			"damage from spells; bludgeoning, piercing, and slashing from nonmagical attacks (from stoneskin)",
			"",
			"",
			"passive Perception 12",
			"any six languages",
			"***Magic Resistance.*** The archmage has advantage on saving throws against spells and other magical effects.\n\n***Spellcasting.*** The archmage is an 18th-level spellcaster. Its spellcasting ability is Intelligence (spell save DC 17, +9 to hit with spell attacks). The archmage can cast disguise self and invisibility at will and has the following wizard spells prepared:\n\n- Cantrips (at will): *fire bolt, light, mage hand, prestidigitation, shocking grasp*\n- 1st level (4 slots): *detect magic, identify, mage armor*, magic missile*\n- 2nd level (3 slots): *detect thoughts, mirror image, misty step*\n- 3rd level (3 slots): *counterspell, fly, lightning bolt*\n- 4th level (3 slots): *banishment, fire shield, stoneskin**\n- 5th level (3 slots): *cone of cold, scrying, wall of force*\n- 6th level (1 slot): *globe of invulnerability*\n- 7th level (1 slot): *teleport*\n- 8th level (1 slot): *mind blank**\n- 9th level (1 slot): *time stop*\n* The archmage casts these spells on itself before combat.",
			"***Dagger.*** *Melee or Ranged Weapon Attack:* +6 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage.",
			"",
			"",
			"",
			""));
}
