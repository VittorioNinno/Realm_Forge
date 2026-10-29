using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Galeb Duhr (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class GalebDuhr2014Seeder
{
	public static Monster Build() => Create("galeb-duhr", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Elemental,
		16, 85, "9d8 + 45", 15, new[] { 20, 14, 20, 11, 12, 11 }, 6m, 2300, 3, 11,
		new Text(
			"Galeb duhr",
			null,
			"Elementale Medio, neutrale",
			"16 (armatura naturale)",
			"4,5 m (9 m quando rotola, 18 m quando rotola in discesa)",
			"",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici",
			"veleno",
			"avvelenato, indebolimento, paralizzato, pietrificato",
			"Percezione passiva 11, percezione tellurica 18 m, scurovisione 18 m",
			"Terran",
			"***Falso aspetto.*** Finché resta immobile, il galeb duhr ha esattamente l'aspetto di un normale macigno.\n\n***Carica rotolante.*** Se il galeb duhr rotola per almeno 6 metri in linea retta verso un bersaglio e poi lo colpisce con un attacco di schianto nello stesso turno, il bersaglio subisce 7 (2d6) danni contundenti extra, e una creatura deve superare un tiro salvezza su Forza con CD 16, altrimenti cade prona.",
			"***Schianto.*** *Attacco con arma da mischia:* +8 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 12 (2d6 + 5) danni contundenti.\n\n***Animare macigni (1/giorno).*** Il galeb duhr anima magicamente fino a due macigni che è in grado di vedere entro 18 metri da lui. I macigni usano le statistiche del galeb duhr, ma hanno Intelligenza 1 e Carisma 1, non possono essere affascinati o spaventati e non possono usare questa azione. Restano animati finché il galeb duhr mantiene la concentrazione, fino a 1 minuto (come se si concentrasse su un incantesimo).",
			"",
			"",
			"",
			""),
		new Text(
			"Galeb Duhr",
			null,
			"Medium elemental, neutral",
			"16 (natural armor)",
			"15 ft. (30 ft. when rolling, 60 ft. rolling downhill)",
			"",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical attacks",
			"poison",
			"exhaustion, paralyzed, petrified, poisoned",
			"darkvision 60 ft., tremorsense 60 ft., passive Perception 11",
			"Terran",
			"***False Appearance.*** As long as it stays still, the galeb duhr looks exactly like an ordinary boulder.\n\n***Rolling Charge.*** If the galeb duhr rolls at least 20 feet straight toward a target and then hits it with a slam attack on the same turn, the target takes an extra 7 (2d6) bludgeoning damage, and a creature must succeed on a DC 16 Strength saving throw or be knocked prone.",
			"***Slam.*** *Melee Weapon Attack:* +8 to hit, reach 5 ft., one target. *Hit:* 12 (2d6 + 5) bludgeoning damage.\n\n***Animate Boulders (1/Day).*** The galeb duhr magically brings to life up to two boulders it can see within 60 feet of it. They use the galeb duhr's statistics, but have Intelligence 1 and Charisma 1, can't be charmed or frightened, and can't use this action. They stay animated for as long as the galeb duhr concentrates, up to 1 minute (as if it were concentrating on a spell).",
			"",
			"",
			"",
			""));
}
