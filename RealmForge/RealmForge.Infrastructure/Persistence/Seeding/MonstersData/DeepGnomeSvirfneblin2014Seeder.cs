using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Deep Gnome (Svirfneblin) (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class DeepGnomeSvirfneblin2014Seeder
{
	public static Monster Build() => Create("deep-gnome-svirfneblin", null, ContentSource.Srd51, CreatureSize.Small, CreatureType.Humanoid,
		15, 16, "3d6 + 6", 20, new[] { 15, 14, 14, 12, 10, 9 }, 0.5m, 100, 2, 12,
		new Text(
			"Gnomo delle profondità (svirfneblin)",
			null,
			"Umanoide Piccolo (gnomo), neutrale buono",
			"15 (giaco di maglia)",
			"6 m",
			"",
			"Furtività +4, Indagare +3, Percezione +2",
			"",
			"",
			"",
			"",
			"Percezione passiva 12, scurovisione 36 m",
			"Gnomesco, Sottocomune, Terran",
			"***Astuzia gnomesca.*** Lo gnomo dispone di vantaggio ai tiri salvezza su Intelligenza, Saggezza e Carisma contro la magia.\n\n***Incantesimi innati.*** La caratteristica innata da incantatore dello gnomo è Intelligenza (CD del tiro salvezza sull'incantesimo 11). Per sua natura, è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *anti-individuazione* (solo se stesso)\n- 1/giorno ciascuno: *camuffare se stesso, cecità/sordità, sfocatura*\n\n***Mimetizzazione rocciosa.*** Lo gnomo dispone di vantaggio alle prove di Destrezza (Furtività) effettuate per nascondersi nei terreni rocciosi.",
			"***Piccone da guerra.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d8 + 2) danni perforanti.\n\n***Dardo avvelenato.*** *Attacco con arma a distanza:* +4 al tiro per colpire, gittata 9/36 m, una creatura. *Colpito:* 4 (1d4 + 2) danni perforanti e il bersaglio deve superare un tiro salvezza su Costituzione con CD 12, altrimenti è avvelenato per 1 minuto. Il bersaglio può ripetere il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto svanisce.",
			"",
			"",
			"",
			""),
		new Text(
			"Deep Gnome (Svirfneblin)",
			null,
			"Small humanoid (gnome), neutral good",
			"15 (chain shirt)",
			"20 ft.",
			"",
			"Investigation +3, Perception +2, Stealth +4",
			"",
			"",
			"",
			"",
			"darkvision 120 ft., passive Perception 12",
			"Gnomish, Terran, Undercommon",
			"***Stone Camouflage.*** The gnome has advantage on Dexterity (Stealth) checks made to hide in rocky terrain.\n\n***Gnome Cunning.*** The gnome has advantage on Intelligence, Wisdom, and Charisma saving throws against magic.\n\n***Innate Spellcasting.*** The gnome's innate spellcasting ability is Intelligence (spell save DC 11). It can innately cast the following spells, requiring no material components:\n\n- At will: *nondetection (self only)*\n- 1/day each: *blindness/deafness, blur, disguise self*",
			"***War Pick.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 6 (1d8 + 2) piercing damage.\n\n***Poisoned Dart.*** *Ranged Weapon Attack:* +4 to hit, range 30/120 ft., one creature. *Hit:* 4 (1d4 + 2) piercing damage, and the target must succeed on a DC 12 Constitution saving throw or be poisoned for 1 minute. The target can repeat the saving throw at the end of each of its turns, ending the effect on itself on a success",
			"",
			"",
			"",
			""));
}
