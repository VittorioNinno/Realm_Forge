using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Sahuagin Baron (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class SahuaginBaron2014Seeder
{
	public static Monster Build() => Create("sahuagin-baron", null, ContentSource.RealmForge, CreatureSize.Large, CreatureType.Humanoid,
		16, 76, "9d10 + 27", 30, new[] { 19, 15, 16, 14, 13, 17 }, 5m, 1800, 3, 17,
		new Text(
			"Sahuagin barone",
			null,
			"Umanoide Grande (sahuagin), legale malvagio",
			"16 (corazza di piastre)",
			"9 m, nuotare 15 m",
			"Cos +6, Des +5, Int +5, Sag +4",
			"Percezione +7",
			"",
			"",
			"",
			"",
			"Percezione passiva 17, scurovisione 36 m",
			"Sahuagin",
			"***Frenesia sanguinaria.*** Il sahuagin dispone di vantaggio ai tiri per colpire in mischia contro qualsiasi creatura che non abbia tutti i suoi punti ferita.\n\n***Anfibio limitato.*** Il sahuagin respira sia in aria che in acqua, ma deve immergersi completamente almeno una volta ogni 4 ore, altrimenti comincia a soffocare.\n\n***Telepatia con gli squali.*** Tramite una telepatia limitata, il sahuagin può comandare magicamente qualsiasi squalo entro 36 metri da lui.",
			"***Multiattacco.*** Il sahuagin effettua tre attacchi: uno con il morso e due con gli artigli o con il tridente.\n\n***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 9 (2d4 + 4) danni perforanti.\n\n***Artigli.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni taglienti.\n\n***Tridente.*** *Attacco con arma da mischia o a distanza:* +7 al tiro per colpire, portata 1,5 m o gittata 6/18 m, un bersaglio. *Colpito:* 11 (2d6 + 4) danni perforanti, o 13 (2d8 + 4) danni perforanti se impugnata a due mani.",
			"",
			"",
			"",
			""),
		new Text(
			"Sahuagin Baron",
			null,
			"Large humanoid (sahuagin), lawful evil",
			"16 (breastplate)",
			"30 ft., swim 50 ft.",
			"Dex +5, Con +6, Int +5, Wis +4",
			"Perception +7",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 17",
			"Sahuagin",
			"***Blood Frenzy.*** The sahuagin has advantage on melee attack rolls against any creature that is missing some of its hit points.\n\n***Limited Amphibiousness.*** The sahuagin breathes both air and water, but must be fully underwater at least once every 4 hours or he starts to suffocate.\n\n***Shark Telepathy.*** Through a limited telepathy, the sahuagin can magically command any shark within 120 feet of him.",
			"***Multiattack.*** The sahuagin makes three attacks: a bite and two attacks with its claws or trident.\n\n***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 9 (2d4 + 4) piercing damage.\n\n***Claws.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 11 (2d6 + 4) slashing damage.\n\n***Trident.*** *Melee or Ranged Weapon Attack:* +7 to hit, reach 5 ft. or range 20/60 ft., one target. *Hit:* 11 (2d6 + 4) piercing damage, or 13 (2d8 + 4) piercing damage if used with two hands.",
			"",
			"",
			"",
			""));
}
