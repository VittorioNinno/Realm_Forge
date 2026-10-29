using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Displacer Beast (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class DisplacerBeast2014Seeder
{
	public static Monster Build() => Create("displacer-beast", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Monstrosity,
		13, 85, "10d10 + 30", 40, new[] { 18, 15, 16, 6, 12, 8 }, 3m, 700, 2, 11,
		new Text(
			"Belva distorcente",
			null,
			"Mostruosità Grande, legale malvagio",
			"13 (armatura naturale)",
			"12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 18 m",
			"—",
			"***Elusione.*** Quando un effetto consente alla belva distorcente di effettuare un tiro salvezza per subire solo la metà dei danni, non subisce alcun danno se lo supera e solo la metà se lo fallisce.\n\n***Distorsione.*** Un'illusione magica fa sembrare la belva distorcente poco distante dal punto in cui si trova davvero, perciò i tiri per colpire contro di lei subiscono svantaggio. Se viene colpita da un attacco, l'illusione si interrompe fino alla fine del suo turno successivo, e non funziona mentre la belva è incapacitata o ha velocità 0.",
			"***Multiattacco.*** La belva distorcente effettua due attacchi con i tentacoli.\n\n***Tentacolo.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 7 (1d6 + 4) danni contundenti più 3 (1d6) danni perforanti.",
			"",
			"",
			"",
			""),
		new Text(
			"Displacer Beast",
			null,
			"Large monstrosity, lawful evil",
			"13 (natural armor)",
			"40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 11",
			"—",
			"***Avoidance.*** When an effect lets the displacer beast make a saving throw to take only half damage, it takes no damage on a success and only half damage on a failure.\n\n***Displacement.*** A magical illusion makes the displacer beast seem to stand a little way from where it really is, so attack rolls against it have disadvantage. Being hit by an attack breaks the illusion until the end of the beast's next turn, and it doesn't work while the beast is incapacitated or has a speed of 0.",
			"***Multiattack.*** The displacer beast makes two tentacle attacks.\n\n***Tentacle.*** *Melee Weapon Attack:* +6 to hit, reach 10 ft., one target. *Hit:* 7 (1d6 + 4) bludgeoning damage plus 3 (1d6) piercing damage.",
			"",
			"",
			"",
			""));
}
