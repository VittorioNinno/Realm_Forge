using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Piercer (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Piercer2014Seeder
{
	public static Monster Build() => Create("piercer", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Monstrosity,
		15, 22, "3d8 + 9", 5, new[] { 10, 13, 16, 1, 7, 3 }, 0.5m, 100, 2, 8,
		new Text(
			"Cuspide letale",
			null,
			"Mostruosità Media, senza allineamento",
			"15 (armatura naturale)",
			"1,5 m, scalare 1,5 m",
			"",
			"Furtività +5",
			"",
			"",
			"",
			"",
			"Percezione passiva 8, scurovisione 18 m, vista cieca 9 m",
			"—",
			"***Falso aspetto.*** Finché resta immobile sul soffitto, la cuspide letale ha esattamente l'aspetto di una normale stalattite.\n\n***Movimenti del ragno.*** La cuspide letale può scalare superfici difficili, anche a testa in giù sui soffitti, senza dover effettuare prove di caratteristica.",
			"***Caduta.*** *Attacco con arma da mischia:* +3 al tiro per colpire, una creatura direttamente sotto la cuspide letale. *Colpito:* 3 (1d6) danni perforanti per ogni 3 metri di caduta, fino a un massimo di 21 (6d6). *Mancato:* La cuspide letale subisce la metà dei normali danni da caduta per la distanza percorsa.",
			"",
			"",
			"",
			"La cuspide letale è la forma larvale di un roper: si aggrappa ai soffitti delle caverne camuffata da stalattite, spesso in colonie, e si lascia cadere sulle creature che passano sotto."),
		new Text(
			"Piercer",
			null,
			"Medium monstrosity, unaligned",
			"15 (natural armor)",
			"5 ft., climb 5 ft.",
			"",
			"Stealth +5",
			"",
			"",
			"",
			"",
			"blindsight 30 ft., darkvision 60 ft., passive Perception 8",
			"—",
			"***False Appearance.*** As long as it stays still on the ceiling, the piercer looks exactly like an ordinary stalactite.\n\n***Spider Climb.*** The piercer can climb difficult surfaces, ceilings included (upside down), without making an ability check.",
			"***Drop.*** *Melee Weapon Attack:* +3 to hit, one creature directly below the piercer. *Hit:* 3 (1d6) piercing damage for every 10 feet fallen, up to a maximum of 21 (6d6). *Miss:* The piercer takes half the normal falling damage for the distance it fell.",
			"",
			"",
			"",
			"A piercer is the larval form of a roper: it clings to cavern ceilings disguised as a stalactite, often in colonies, and drops onto creatures passing below."));
}
