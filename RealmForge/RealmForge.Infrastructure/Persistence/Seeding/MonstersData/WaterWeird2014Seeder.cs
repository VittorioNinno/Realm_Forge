using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Water Weird (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class WaterWeird2014Seeder
{
	public static Monster Build() => Create("water-weird", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Elemental,
		13, 58, "9d10 + 9", 0, new[] { 17, 16, 13, 11, 10, 10 }, 3m, 700, 2, 10,
		new Text(
			"Fatale dell'acqua",
			null,
			"Elementale Grande, neutrale",
			"13",
			"0 m, nuotare 18 m",
			"",
			"",
			"",
			"fuoco; contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"afferrato, avvelenato, indebolimento, paralizzato, privo di sensi, prono, trattenuto",
			"Percezione passiva 10, vista cieca 9 m",
			"capisce l'Acquan ma non lo parla",
			"***Invisibile nell'acqua.*** Il fatale dell'acqua è invisibile finché è completamente immerso.\n\n***Legato all'acqua.*** Il fatale dell'acqua muore se abbandona l'acqua a cui è legato, o se quell'acqua viene distrutta.",
			"***Stritolare.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 3 m, una creatura. *Colpito:* 13 (3d6 + 3) danni contundenti. Un bersaglio di taglia Media o inferiore è afferrato (CD 13 per sfuggire) e trascinato di 1,5 metri verso il fatale dell'acqua. Finché dura la presa, il bersaglio è trattenuto, il fatale cerca di annegarlo e non può stritolare nessun altro.",
			"",
			"",
			"",
			"Un fatale dell'acqua legato a una fonte sacra o profanata ne assume la natura e diventa neutrale buono o neutrale malvagio; purificarne l'acqua con *purificare cibo e bevande* gli toglie l'allineamento malvagio."),
		new Text(
			"Water Weird",
			null,
			"Large elemental, neutral",
			"13",
			"0 ft., swim 60 ft.",
			"",
			"",
			"",
			"fire; bludgeoning, piercing, and slashing from nonmagical attacks",
			"poison",
			"exhaustion, grappled, paralyzed, poisoned, prone, restrained, unconscious",
			"blindsight 30 ft., passive Perception 10",
			"understands Aquan but doesn't speak",
			"***Invisible in Water.*** The water weird is invisible while it is completely underwater.\n\n***Water Bound.*** The water weird dies if it leaves the water it is bound to, or if that water is destroyed.",
			"***Constrict.*** *Melee Weapon Attack:* +5 to hit, reach 10 ft., one creature. *Hit:* 13 (3d6 + 3) bludgeoning damage. A Medium or smaller target is grappled (escape DC 13) and pulled 5 feet toward the water weird. While the grapple lasts, the target is restrained, the water weird tries to drown it, and it can't constrict anyone else.",
			"",
			"",
			"",
			"A water weird bound to a sacred or a defiled spring takes on its nature and becomes neutral good or neutral evil; purifying its water with purify food and drink removes an evil alignment."));
}
