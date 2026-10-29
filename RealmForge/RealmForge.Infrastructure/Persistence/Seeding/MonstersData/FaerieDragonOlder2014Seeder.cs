using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Faerie Dragon (Green to Violet) (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class FaerieDragonOlder2014Seeder
{
	public static Monster Build() => Create("faerie-dragon-older", "faerie-dragon", ContentSource.RealmForge, CreatureSize.Tiny, CreatureType.Dragon,
		15, 14, "4d4 + 4", 10, new[] { 3, 20, 13, 14, 12, 16 }, 2m, 450, 2, 13,
		new Text(
			"Drago fatato (dal verde al viola)",
			null,
			"Drago Minuscolo, caotico buono",
			"15",
			"3 m, volare 18 m",
			"",
			"Arcano +4, Furtività +7, Percezione +3",
			"",
			"",
			"",
			"",
			"Percezione passiva 13, scurovisione 18 m",
			"Draconico, Silvano",
			"***Invisibilità superiore.*** Come azione bonus, il drago diventa magicamente invisibile, insieme a ciò che indossa o trasporta, finché la sua concentrazione non termina (come se si concentrasse su un incantesimo).\n\n***Telepatia limitata.*** Il drago può comunicare telepaticamente con qualsiasi altro drago fatato entro 18 metri da lui.\n\n***Resistenza alla magia.*** Il drago dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Incantesimi innati.*** Il drago lancia incantesimi per natura usando il Carisma (CD del tiro salvezza sull'incantesimo 13), senza bisogno di componenti materiali. Impara nuovi incantesimi man mano che invecchia e le sue scaglie cambiano colore; conosce tutti gli incantesimi del suo colore e di quelli più giovani:\n\n- Rosso, 1/giorno ciascuno: *luci danzanti*, *mano magica*, *illusione minore*\n- Arancione, 1/giorno: *spruzzo colorato*\n- Giallo, 1/giorno: *immagine speculare*\n- Verde, 1/giorno: *suggestione*\n- Blu, 1/giorno: *immagine maggiore*\n- Indaco, 1/giorno: *terreno illusorio*\n- Viola, 1/giorno: *metamorfosi*",
			"***Morso.*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 1 danno perforante.\n\n***Soffio euforico (ricarica 5–6).*** Il drago soffia un gas euforico contro una creatura entro 1,5 metri da lui, che effettua un tiro salvezza su Saggezza con CD 11. Se lo fallisce, per 1 minuto il bersaglio non può effettuare reazioni e all'inizio di ogni suo turno tira un d6: con 1–4 non effettua azioni né azioni bonus e usa tutto il suo movimento per vagare in una direzione casuale; con 5–6 resta fermo e può solo ripetere il tiro salvezza, e l'effetto termina con un successo.",
			"",
			"",
			"",
			"I draghi fatati verdi hanno da 21 a 30 anni, i blu da 31 a 40, gli indaco da 41 a 50, i viola 51 o più."),
		new Text(
			"Faerie Dragon (Green to Violet)",
			null,
			"Tiny dragon, chaotic good",
			"15",
			"10 ft., fly 60 ft.",
			"",
			"Arcana +4, Perception +3, Stealth +7",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 13",
			"Draconic, Sylvan",
			"***Superior Invisibility.*** As a bonus action, the dragon magically becomes invisible, together with what it wears or carries, until its concentration ends (as if it were concentrating on a spell).\n\n***Limited Telepathy.*** The dragon can speak telepathically with any other faerie dragon within 60 feet of it.\n\n***Magic Resistance.*** The dragon has advantage on saving throws against spells and other magical effects.\n\n***Innate Spellcasting.*** The dragon casts spells innately, using Charisma (spell save DC 13) and needing no material components. It learns new spells as it grows older and its scales change color; it knows every spell of its color and of the younger ones:\n\n- Red, 1/day each: *dancing lights*, *mage hand*, *minor illusion*\n- Orange, 1/day: *color spray*\n- Yellow, 1/day: *mirror image*\n- Green, 1/day: *suggestion*\n- Blue, 1/day: *major image*\n- Indigo, 1/day: *hallucinatory terrain*\n- Violet, 1/day: *polymorph*",
			"***Bite.*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one creature. *Hit:* 1 piercing damage.\n\n***Euphoria Breath (Recharge 5–6).*** The dragon puffs euphoric gas at a creature within 5 feet of it, which makes a DC 11 Wisdom saving throw. On a failure, for 1 minute the target can't take reactions and rolls a d6 at the start of each of its turns: on 1–4 it takes no action or bonus action and spends all its movement wandering in a random direction; on 5–6 it stays where it is and can only repeat the saving throw, ending the effect on a success.",
			"",
			"",
			"",
			"Green faerie dragons are 21 to 30 years old, blue 31 to 40, indigo 41 to 50, violet 51 or more."));
}
