using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Orc Eye of Gruumsh (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class OrcEyeOfGruumsh2014Seeder
{
	public static Monster Build() => Create("orc-eye-of-gruumsh", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		16, 45, "6d8 + 18", 30, new[] { 16, 12, 16, 9, 13, 12 }, 2m, 450, 2, 11,
		new Text(
			"Orco occhio di Gruumsh",
			null,
			"Umanoide Medio (orco), caotico malvagio",
			"16 (armatura ad anelli, scudo)",
			"9 m",
			"",
			"Intimidire +3, Religione +1",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 18 m",
			"Comune, Orchesco",
			"***Aggressivo.*** Come azione bonus, l'orco può muoversi fino alla sua velocità verso una creatura ostile che è in grado di vedere.\n\n***Furia di Gruumsh.*** Ogni volta che l'orco colpisce con un attacco con arma, infligge 4 (1d8) danni extra (già inclusi nei suoi attacchi).\n\n***Incantesimi.*** L'orco lancia incantesimi come un incantatore di 3° livello, usando la Saggezza (CD del tiro salvezza sull'incantesimo 11, +3 al tiro per colpire con attacco con incantesimo). Ha preparati i seguenti incantesimi da chierico:\n\n- Trucchetti (a volontà): *guida*, *resistenza*, *taumaturgia*\n- 1° livello (4 slot): *benedizione*, *comando*\n- 2° livello (2 slot): *presagio*, *arma spirituale* (lancia)",
			"***Lancia.*** *Attacco con arma da mischia o a distanza:* +5 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 11 (1d6 + 3 più 1d8) danni perforanti, o 12 (2d8 + 3) danni perforanti se impugnata a due mani in mischia.",
			"",
			"",
			"",
			""),
		new Text(
			"Orc Eye of Gruumsh",
			null,
			"Medium humanoid (orc), chaotic evil",
			"16 (ring mail, shield)",
			"30 ft.",
			"",
			"Intimidation +3, Religion +1",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 11",
			"Common, Orc",
			"***Aggressive.*** As a bonus action, the orc can move up to its speed toward a hostile creature it can see.\n\n***Gruumsh's Fury.*** Whenever the orc hits with a weapon attack, it deals an extra 4 (1d8) damage (already counted in its attacks).\n\n***Spellcasting.*** The orc casts spells as a 3rd-level spellcaster, using Wisdom (spell save DC 11, +3 to hit with spell attacks). It has these cleric spells prepared:\n\n- Cantrips (at will): *guidance*, *resistance*, *thaumaturgy*\n- 1st level (4 slots): *bless*, *command*\n- 2nd level (2 slots): *augury*, *spiritual weapon* (spear)",
			"***Spear.*** *Melee or Ranged Weapon Attack:* +5 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 11 (1d6 + 3 plus 1d8) piercing damage, or 12 (2d8 + 3) piercing damage if used with two hands in melee.",
			"",
			"",
			"",
			""));
}
