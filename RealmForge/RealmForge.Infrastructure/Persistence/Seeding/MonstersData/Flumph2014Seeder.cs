using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Flumph (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Flumph2014Seeder
{
	public static Monster Build() => Create("flumph", null, ContentSource.RealmForge, CreatureSize.Small, CreatureType.Aberration,
		12, 7, "2d6", 5, new[] { 6, 15, 10, 14, 14, 11 }, 0.125m, 25, 2, 12,
		new Text(
			"Flumph",
			null,
			"Aberrazione Piccola, legale buono",
			"12",
			"1,5 m, volare 9 m",
			"",
			"Arcano +4, Religione +4, Storia +4",
			"psichici",
			"",
			"",
			"",
			"Percezione passiva 12, scurovisione 18 m",
			"capisce il Sottocomune ma non lo parla, telepatia 18 m",
			"***Telepatia avanzata.*** Il flumph percepisce il contenuto di qualsiasi comunicazione telepatica entro 18 metri da lui, e le creature dotate di qualsiasi forma di telepatia non possono sorprenderlo.\n\n***Goffaggine da prono.*** Quando il flumph cade prono, si tira un dado: con un risultato dispari si ritrova a testa in giù ed è incapacitato. Alla fine di ogni suo turno può effettuare un tiro salvezza su Destrezza con CD 10 per raddrizzarsi, e con un successo non è più incapacitato.\n\n***Velo telepatico.*** Nessun effetto può percepire le emozioni o leggere i pensieri del flumph, e gli incantesimi di divinazione non hanno effetto su di lui.",
			"***Viticci.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 4 (1d4 + 2) danni perforanti più 2 (1d4) danni da acido. Alla fine di ogni suo turno il bersaglio effettua un tiro salvezza su Costituzione con CD 10: se lo fallisce subisce 2 (1d4) danni da acido, se lo supera l'acido smette di agire. Anche l'incantesimo *ristorare inferiore* lo ferma.\n\n***Spruzzo fetido (1/giorno).*** Ogni creatura in un cono di 4,5 metri a partire dal flumph effettua un tiro salvezza su Destrezza con CD 10, altrimenti viene ricoperta da un liquido nauseabondo che puzza per 1d4 ore. Finché dura il fetore, la creatura è avvelenata, e lo è anche ogni altra creatura finché si trova entro 1,5 metri da lei. Una creatura può lavare via l'odore trascorrendo un riposo breve a bagnarsi in acqua, alcol o aceto.",
			"",
			"",
			"",
			""),
		new Text(
			"Flumph",
			null,
			"Small aberration, lawful good",
			"12",
			"5 ft., fly 30 ft.",
			"",
			"Arcana +4, History +4, Religion +4",
			"psychic",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 12",
			"understands Undercommon but can't speak, telepathy 60 ft.",
			"***Advanced Telepathy.*** The flumph perceives the content of any telepathic exchange within 60 feet of it, and creatures that have any kind of telepathy can't surprise it.\n\n***Prone Deficiency.*** When the flumph is knocked prone, roll a die: on an odd number it ends up upside down and incapacitated. At the end of each of its turns it can make a DC 10 Dexterity saving throw to right itself, ending the incapacitation on a success.\n\n***Telepathic Shroud.*** No effect can sense the emotions or read the thoughts of the flumph, and divination spells have no effect on it.",
			"***Tendrils.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one creature. *Hit:* 4 (1d4 + 2) piercing damage plus 2 (1d4) acid damage. At the end of each of its turns, the target makes a DC 10 Constitution saving throw: on a failure it takes 2 (1d4) acid damage, on a success the acid stops. A lesser restoration spell also stops it.\n\n***Stench Spray (1/Day).*** Each creature in a 15-foot cone from the flumph makes a DC 10 Dexterity saving throw or is covered in a reeking liquid that stinks for 1d4 hours. For as long as the stench lasts, the creature is poisoned, and so is any other creature while within 5 feet of it. A creature can wash the smell away by spending a short rest bathing in water, alcohol or vinegar.",
			"",
			"",
			"",
			""));
}
