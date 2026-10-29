using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Vine Blight (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class VineBlight2014Seeder
{
	public static Monster Build() => Create("vine-blight", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Plant,
		12, 26, "4d8 + 8", 10, new[] { 15, 8, 14, 5, 10, 3 }, 0.5m, 100, 2, 10,
		new Text(
			"Rampicante maligno",
			null,
			"Vegetale Medio, neutrale malvagio",
			"12 (armatura naturale)",
			"3 m",
			"",
			"Furtività +1",
			"",
			"",
			"",
			"accecato, assordato",
			"Percezione passiva 10, vista cieca 18 m (cieco oltre questo raggio)",
			"Comune",
			"***Falso aspetto.*** Finché resta immobile, il maligno ha esattamente l'aspetto di un groviglio di viticci.",
			"***Stritolare.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 9 (2d6 + 2) danni contundenti. Un bersaglio di taglia Grande o inferiore è anche afferrato (CD 12 per sfuggire); finché è afferrato è trattenuto, e il maligno non può stritolare nessun altro.\n\n***Piante avviluppanti (ricarica 5–6).*** Radici e viticci spuntano dal terreno in un raggio di 4,5 metri attorno al maligno e avvizziscono dopo 1 minuto. Nel frattempo l'area è terreno difficile per le creature che non siano vegetali, e ogni creatura a scelta del maligno che vi si trova quando le piante compaiono effettua un tiro salvezza su Forza con CD 12, altrimenti è trattenuta. Con un'azione, una creatura può effettuare una prova di Forza con CD 12 per liberare se stessa o un'altra creatura trattenuta entro la sua portata.",
			"",
			"",
			"",
			""),
		new Text(
			"Vine Blight",
			null,
			"Medium plant, neutral evil",
			"12 (natural armor)",
			"10 ft.",
			"",
			"Stealth +1",
			"",
			"",
			"",
			"blinded, deafened",
			"blindsight 60 ft. (blind beyond this radius), passive Perception 10",
			"Common",
			"***False Appearance.*** As long as it stays still, the blight looks exactly like a knot of vines.",
			"***Constrict.*** *Melee Weapon Attack:* +4 to hit, reach 10 ft., one target. *Hit:* 9 (2d6 + 2) bludgeoning damage. A Large or smaller target is also grappled (escape DC 12); while grappled it is restrained, and the blight can't constrict anyone else.\n\n***Entangling Plants (Recharge 5–6).*** Roots and creepers burst from the ground in a 15-foot radius around the blight and wither after 1 minute. Meanwhile, the area is difficult terrain for creatures that aren't plants, and each creature of the blight's choice standing there when the plants appear makes a DC 12 Strength saving throw or is restrained. As an action, a creature can make a DC 12 Strength check to free itself or another restrained creature within its reach.",
			"",
			"",
			"",
			""));
}
