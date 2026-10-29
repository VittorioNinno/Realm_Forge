using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Chasme (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Chasme2014Seeder
{
	public static Monster Build() => Create("chasme", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Fiend,
		15, 84, "13d10 + 13", 20, new[] { 15, 15, 12, 11, 14, 10 }, 6m, 2300, 3, 15,
		new Text(
			"Chasme",
			null,
			"Immondo Grande (demone), caotico malvagio",
			"15 (armatura naturale)",
			"6 m, volare 18 m",
			"Des +5, Sag +5",
			"Percezione +5",
			"",
			"freddo, fuoco, fulmine",
			"veleno",
			"avvelenato",
			"Percezione passiva 15, scurovisione 36 m, vista cieca 3 m",
			"Abissale, telepatia 36 m",
			"***Ronzio.*** Il chasme emette un ronzio nauseante che non ha effetto sui demoni. Ogni altra creatura che inizia il suo turno entro 9 metri dal chasme e lo sente effettua un tiro salvezza su Costituzione con CD 12, altrimenti cade priva di sensi per 10 minuti; si risveglia se subisce danni o se un'altra creatura usa un'azione per spruzzarle addosso acqua santa. Una creatura che supera il tiro salvezza, o che si risveglia, è immune al ronzio per 24 ore.\n\n***Resistenza alla magia.*** Il chasme dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Movimenti del ragno.*** Il chasme può scalare superfici difficili, soffitti compresi (a testa in giù), senza effettuare prove di caratteristica.",
			"***Proboscide.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 16 (4d6 + 2) danni perforanti più 24 (7d6) danni necrotici. I punti ferita massimi del bersaglio si riducono di un ammontare pari ai danni necrotici subiti, finché non completa un riposo lungo o un incantesimo come *ristorare superiore* non li ripristina; una creatura i cui punti ferita massimi scendono a 0 muore.",
			"",
			"",
			"",
			""),
		new Text(
			"Chasme",
			null,
			"Large fiend (demon), chaotic evil",
			"15 (natural armor)",
			"20 ft., fly 60 ft.",
			"Dex +5, Wis +5",
			"Perception +5",
			"",
			"cold, fire, lightning",
			"poison",
			"poisoned",
			"blindsight 10 ft., darkvision 120 ft., passive Perception 15",
			"Abyssal, telepathy 120 ft.",
			"***Drone.*** The chasme gives off a sickening drone that doesn't affect demons. Any other creature that starts its turn within 30 feet of the chasme and can hear it makes a DC 12 Constitution saving throw or falls unconscious for 10 minutes; it wakes up if it takes damage or another creature uses an action to splash it with holy water. A creature that succeeds, or that wakes up, is immune to the drone for 24 hours.\n\n***Magic Resistance.*** The chasme has advantage on saving throws against spells and other magical effects.\n\n***Spider Climb.*** The chasme can climb difficult surfaces, ceilings included (upside down), without making an ability check.",
			"***Proboscis.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one creature. *Hit:* 16 (4d6 + 2) piercing damage plus 24 (7d6) necrotic damage. The target's hit point maximum drops by the necrotic damage it took, until it finishes a long rest or a spell such as greater restoration restores it; a creature whose maximum drops to 0 dies.",
			"",
			"",
			"",
			""));
}
