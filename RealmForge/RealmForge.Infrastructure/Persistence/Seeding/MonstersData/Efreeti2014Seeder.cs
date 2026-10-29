using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Efreeti (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Efreeti2014Seeder
{
	public static Monster Build() => Create("efreeti", null, CreatureSize.Large, CreatureType.Elemental,
		17, 200, "16d10 + 112", 40, new[] { 22, 12, 24, 16, 15, 16 }, 11m, 7200, 4, 12,
		new Text(
			"Efreeti",
			null,
			"Elementale Grande, legale malvagio",
			"17 (armatura naturale)",
			"12 m, volare 18 m",
			"Car +7, Int +7, Sag +6",
			"",
			"",
			"",
			"fuoco",
			"",
			"Percezione passiva 12, scurovisione 36 m",
			"Ignan",
			"***Dipartita elementale.*** Se l'efreeti muore, il suo corpo si disintegra in una fiammata e in uno sbuffo di fumo, lasciando dietro di sé solo gli oggetti che l'efreeti indossava o trasportava.\n\n***Incantesimi innati.*** La caratteristica innata da incantatore dell'efreeti è Carisma (CD del tiro salvezza sull'incantesimo 15, +7 al tiro per colpire con attacco con incantesimo). Per sua natura, è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *individuazione del magico*\n- 3/giorno ciascuno: *ingrandire/ridurre, linguaggi*\n- 1/giorno ciascuno: *evoca elementale* (solo elementale del fuoco), *forma gassosa, immagine maggiore, invisibilità, muro di fuoco, spostamento planare*",
			"***Multiattacco.*** L'efreeti effettua due attacchi con la scimitarra o usa Scagliare fiamma due volte.\n\n***Scimitarra.*** *Attacco con arma da mischia:* +10 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d6 + 6) danni taglienti più 7 (2d6) danni da fuoco.\n\n***Scagliare fiamma.*** *Attacco a distanza con incantesimo:* +7 al tiro per colpire, gittata 36 m, un bersaglio. *Colpito:* 17 (5d6) danni da fuoco.",
			"",
			""),
		new Text(
			"Efreeti",
			null,
			"Large elemental, lawful evil",
			"17 (natural armor)",
			"40 ft., fly 60 ft.",
			"Int +7, Wis +6, Cha +7",
			"",
			"",
			"",
			"fire",
			"",
			"darkvision 120 ft., passive Perception 12",
			"Ignan",
			"***Elemental Demise.*** If the efreeti dies, its body disintegrates in a flash of fire and puff of smoke, leaving behind only equipment the djinni was wearing or carrying.\n\n***Innate Spellcasting.*** The efreeti's innate spell casting ability is Charisma (spell save DC 15, +7 to hit with spell attacks). It can innately cast the following spells, requiring no material components:\n\n\n- At will: *detect magic*\n- 3/day: *enlarge/reduce, tongues*\n- 1/day each: *conjure elemental (fire elemental only), gaseous form, invisibility, major image, plane shift, wall of fire*",
			"***Multiattack.*** The efreeti makes two scimitar attacks or uses its Hurl Flame twice.\n\n***Scimitar.*** *Melee Weapon Attack:* +10 to hit, reach 5 ft., one target. *Hit:* 13 (2d6 + 6) slashing damage plus 7 (2d6) fire damage.\n\n***Hurl Flame.*** *Ranged Spell Attack:* +7 to hit, range 120 ft., one target. *Hit:* 17 (5d6) fire damage.",
			"",
			""));
}
