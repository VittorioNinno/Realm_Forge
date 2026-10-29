using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Cloaker (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Cloaker2014Seeder
{
	public static Monster Build() => Create("cloaker", null, CreatureSize.Large, CreatureType.Aberration,
		14, 78, "12d10 + 12", 10, new[] { 17, 15, 12, 13, 12, 14 }, 8m, 3900, 3, 11,
		new Text(
			"Manto assassino",
			null,
			"Aberrazione Grande, caotico neutrale",
			"14 (armatura naturale)",
			"3 m, volare 12 m",
			"",
			"Furtività +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 18 m",
			"Gergo delle profondità, Sottocomune",
			"***Falso aspetto.*** Finché il manto assassino rimane immobile e non rende visibile il suo lato inferiore, non è possibile distinguerlo da un mantello di cuoio scuro.\n\n***Sensibilità alla luce.*** Finché è esposto alla luce intensa, il manto assassino subisce svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista.\n\n***Trasferire danni.*** Finché è avvinghiato a una creatura, il manto assassino subisce solo metà dei danni che gli vengono inflitti (arrotondati per difetto) e quella creatura subisce l'altra metà.",
			"***Multiattacco.*** Il manto assassino effettua due attacchi: uno con il morso e uno con la coda.\n\n***Coda.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 7 (1d8 + 3) danni taglienti.\n\n***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 10 (2d6 + 3) danni perforanti e, se il bersaglio è di taglia Grande o inferiore, il manto assassino si avvinghia a esso. Se il manto assassino dispone di vantaggio contro il bersaglio, si avvinghia alla testa del bersaglio, che è accecato e impossibilitato a respirare finché il manto assassino resta attaccato. Mentre è avvinghiato, il manto assassino può effettuare questo attacco solo contro il bersaglio e dispone di vantaggio al tiro per colpire. Il manto assassino può staccarsi da solo spendendo 1,5 metri del suo movimento. Una creatura, incluso il bersaglio, può usare la sua azione per staccare il manto assassino, se effettua con successo una prova di Forza con CD 16.\n\n***Allucinazioni (ricarica dopo un riposo breve o lungo).*** Il manto assassino crea magicamente tre duplicati illusori di se stesso se non è esposto alla luce intensa. I duplicati si muovono insieme a lui e imitano le sue azioni, scambiandosi di posizione in modo che sia impossibile capire quale manto assassino sia quello vero. Se il manto assassino si trova in un'area di luce intensa, i duplicati scompaiono. Ogni volta che una creatura bersaglia il manto assassino con un attacco o un incantesimo dannoso finché permane un duplicato, quella creatura effettua un tiro casuale per determinare se bersaglia il manto assassino o uno dei suoi duplicati. Una creatura non è influenzata da questo effetto magico se non può vedere o se si affida a sensi diversi dalla vista. Un duplicato possiede la CA del manto assassino e usa i suoi tiri salvezza. Se un attacco colpisce un duplicato o se un duplicato fallisce un tiro salvezza contro un effetto che infligge danni, quel duplicato scompare.\n\n***Gemito.*** Ogni creatura entro 18 metri dal manto assassino che possa sentire il suo gemito e che non sia un'aberrazione deve superare un tiro salvezza su Saggezza con CD 13, altrimenti è spaventata fino alla fine del turno successivo del manto assassino. Se la creatura supera il tiro salvezza, è immune al gemito del manto assassino per le 24 ore successive.",
			"",
			""),
		new Text(
			"Cloaker",
			null,
			"Large aberration, chaotic neutral",
			"14 (natural armor)",
			"10 ft., fly 40 ft.",
			"",
			"Stealth +5",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 11",
			"Deep Speech, Undercommon",
			"***Damage Transfer.*** While attached to a creature, the cloaker takes only half the damage dealt to it (rounded down). and that creature takes the other half.\n\n***False Appearance.*** While the cloaker remains motionless without its underside exposed, it is indistinguishable from a dark leather cloak.\n\n***Light Sensitivity.*** While in bright light, the cloaker has disadvantage on attack rolls and Wisdom (Perception) checks that rely on sight.",
			"***Multiattack.*** The cloaker makes two attacks: one with its bite and one with its tail.\n\n***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one creature. *Hit:* 10 (2d6 + 3) piercing damage, and if the target is Large or smaller, the cloaker attaches to it. If the cloaker has advantage against the target, the cloaker attaches to the target's head, and the target is blinded and unable to breathe while the cloaker is attached. While attached, the cloaker can make this attack only against the target and has advantage on the attack roll. The cloaker can detach itself by spending 5 feet of its movement. A creature, including the target, can take its action to detach the cloaker by succeeding on a DC 16 Strength check.\n\n***Tail.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one creature. *Hit:* 7 (1d8 + 3) slashing damage.\n\n***Moan.*** Each creature within 60 feet of the cloaker that can hear its moan and that isn't an aberration must succeed on a DC 13 Wisdom saving throw or become frightened until the end of the cloaker's next turn. If a creature's saving throw is successful, the creature is immune to the cloaker's moan for the next 24 hours.\n\n***Phantasms (Recharges after a Short or Long Rest).*** The cloaker magically creates three illusory duplicates of itself if it isn't in bright light. The duplicates move with it and mimic its actions, shifting position so as to make it impossible to track which cloaker is the real one. If the cloaker is ever in an area of bright light, the duplicates disappear.\n\nWhenever any creature targets the cloaker with an attack or a harmful spell while a duplicate remains, that creature rolls randomly to determine whether it targets the cloaker or one of the duplicates. A creature is unaffected by this magical effect if it can't see or if it relies on senses other than sight.\nA duplicate has the cloaker's AC and uses its saving throws. If an attack hits a duplicate, or if a duplicate fails a saving throw against an effect that deals damage, the duplicate disappears.",
			"",
			""));
}
