using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Bullywug (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Bullywug2014Seeder
{
	public static Monster Build() => Create("bullywug", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		15, 11, "2d8 + 2", 20, new[] { 12, 12, 13, 7, 10, 7 }, 0.25m, 50, 2, 10,
		new Text(
			"Bullywug",
			null,
			"Umanoide Medio (bullywug), neutrale malvagio",
			"15 (armatura di pelle, scudo)",
			"6 m, nuotare 12 m",
			"",
			"Furtività +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 10",
			"Bullywug",
			"***Anfibio.*** Il bullywug può respirare in aria e in acqua.\n\n***Parlare con rane e rospi.*** Parlando in Bullywug, il bullywug può trasmettere idee semplici a rane e rospi.\n\n***Mimetismo palustre.*** Il bullywug dispone di vantaggio alle prove di Destrezza (Furtività) per nascondersi in un terreno paludoso.\n\n***Salto da fermo.*** Con o senza rincorsa, il bullywug può saltare fino a 6 metri in lungo e fino a 3 metri in alto.",
			"***Multiattacco.*** Il bullywug effettua due attacchi in mischia: uno con il morso e uno con la lancia.\n\n***Morso.*** *Attacco con arma da mischia:* +3 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 3 (1d4 + 1) danni contundenti.\n\n***Lancia.*** *Attacco con arma da mischia o a distanza:* +3 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 4 (1d6 + 1) danni perforanti, o 5 (1d8 + 1) danni perforanti se impugnata a due mani.",
			"",
			"",
			"",
			""),
		new Text(
			"Bullywug",
			null,
			"Medium humanoid (bullywug), neutral evil",
			"15 (hide armor, shield)",
			"20 ft., swim 40 ft.",
			"",
			"Stealth +3",
			"",
			"",
			"",
			"",
			"passive Perception 10",
			"Bullywug",
			"***Amphibious.*** The bullywug can breathe air and water.\n\n***Speak with Frogs and Toads.*** Speaking Bullywug, the bullywug can get simple ideas across to frogs and toads.\n\n***Swamp Camouflage.*** The bullywug has advantage on Dexterity (Stealth) checks to hide in swampy terrain.\n\n***Standing Leap.*** With or without a run-up, the bullywug can long jump up to 20 feet and high jump up to 10 feet.",
			"***Multiattack.*** The bullywug makes two melee attacks: a bite and a spear attack.\n\n***Bite.*** *Melee Weapon Attack:* +3 to hit, reach 5 ft., one target. *Hit:* 3 (1d4 + 1) bludgeoning damage.\n\n***Spear.*** *Melee or Ranged Weapon Attack:* +3 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 4 (1d6 + 1) piercing damage, or 5 (1d8 + 1) piercing damage if used with two hands.",
			"",
			"",
			"",
			""));
}
