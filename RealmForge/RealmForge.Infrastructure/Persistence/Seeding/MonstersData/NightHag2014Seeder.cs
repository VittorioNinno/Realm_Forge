using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Night Hag (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class NightHag2014Seeder
{
	public static Monster Build() => Create("night-hag", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Fiend,
		17, 112, "15d8 + 45", 30, new[] { 18, 15, 16, 16, 14, 16 }, 5m, 1800, 3, 16,
		new Text(
			"Megera notturna",
			null,
			"Immondo Medio, neutrale malvagia",
			"17 (armatura naturale)",
			"9 m",
			"",
			"Furtività +6, Inganno +7, Intuizione +6, Percezione +6",
			"",
			"freddo, fuoco; contundenti, perforanti e taglienti da attacchi non magici con armi non argentate",
			"",
			"affascinato",
			"Percezione passiva 16, scurovisione 36 m",
			"Abissale, Comune, Infernale, Primordiale",
			"***Incantesimi innati.*** La caratteristica innata da incantatore della megera è Carisma (CD del tiro salvezza sull'incantesimo 14, +6 al tiro per colpire con attacco con incantesimo). Per sua natura, è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *dardo incantato, individuazione del magico*\n- 2/giorno ciascuno: *raggio di affaticamento, sonno, spostamento planare (solo se stessa)*\n\n***Resistenza alla magia.*** La megera dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Artigli (solo forma di megera).*** *Attacco con arma da mischia:* +7 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni taglienti.\n\n***Cambiare forma.*** La megera si trasforma magicamente in un'umanoide femminile di taglia Media o Piccola, o ritorna alla sua vera forma. Le sue statistiche rimangono le stesse in ogni forma. Ogni oggetto che indossa o trasporta non viene trasformato. Se muore, ritorna alla sua vera forma.\n\n***Forma eterea.*** La megera entra magicamente nel Piano Etereo dal Piano Materiale o viceversa. Per farlo dev'essere in possesso di una *pietra del cuore.*\n\n***Infestare incubi (1/giorno).*** Finché si trova sul Piano Etereo, la megera tocca magicamente un umanoide addormentato sul Piano Materiale. Un incantesimo *protezione dal bene e dal male* lanciato sul bersaglio impedisce questo contatto, come anche un *cerchio magico.* Finché il contatto persiste, il bersaglio è tormentato da orrende visioni. Se queste visioni durano almeno 1 ora, il bersaglio non ottiene alcun beneficio dal suo riposo e i suoi punti ferita massimi vengono ridotti di 5 (1d10). Se questo effetto riduce i punti ferita massimi del bersaglio a 0, questi muore e, se era malvagio, la sua anima resta intrappolata nella *borsa dell'anima* della megera. La riduzione dei punti ferita massimi del bersaglio dura finché non viene rimossa da un incantesimo *ristorare superiore* o da una magia analoga.",
			"",
			"",
			"",
			""),
		new Text(
			"Night Hag",
			null,
			"Medium fiend, neutral evil",
			"17 (natural armor)",
			"30 ft.",
			"",
			"Deception +7, Insight +6, Perception +6, Stealth +6",
			"",
			"cold, fire; bludgeoning, piercing, and slashing from nonmagical weapons that aren't silvered",
			"",
			"charmed",
			"darkvision 120 ft., passive Perception 16",
			"Abyssal, Common, Infernal, Primordial",
			"***Innate Spellcasting.*** The hag's innate spellcasting ability is Charisma (spell save DC 14, +6 to hit with spell attacks). She can innately cast the following spells, requiring no material components:\n\n\n- At will: *detect magic, magic missile*\n- 2/day each: *plane shift (self only), ray of enfeeblement, sleep*\n\n***Magic Resistance.*** The hag has advantage on saving throws against spells and other magical effects.\n\n***Night Hag Items.*** A night hag carries two very rare magic items that she must craft for herself If either object is lost, the night hag will go to great lengths to retrieve it, as creating a new tool takes time and effort.\n\nHeartstone: This lustrous black gem allows a night hag to become ethereal while it is in her possession. The touch of a heartstone also cures any disease. Crafting a heartstone takes 30 days.\nSoul Bag: When an evil humanoid dies as a result of a night hag's Nightmare Haunting, the hag catches the soul in this black sack made of stitched flesh. A soul bag can hold only one evil soul at a time, and only the night hag who crafted the bag can catch a soul with it. Crafting a soul bag takes 7 days and a humanoid sacrifice (whose flesh is used to make the bag).",
			"***Claws (Hag Form Only).*** *Melee Weapon Attack:* +7 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) slashing damage.\n\n***Change Shape.*** The hag magically polymorphs into a Small or Medium female humanoid, or back into her true form. Her statistics are the same in each form. Any equipment she is wearing or carrying isn't transformed. She reverts to her true form if she dies.\n\n***Etherealness.*** The hag magically enters the Ethereal Plane from the Material Plane, or vice versa. To do so, the hag must have a heartstone in her possession.\n\n***Nightmare Haunting (1/Day).*** While on the Ethereal Plane, the hag magically touches a sleeping humanoid on the Material Plane. A protection from evil and good spell cast on the target prevents this contact, as does a magic circle. As long as the contact persists, the target has dreadful visions. If these visions last for at least 1 hour, the target gains no benefit from its rest, and its hit point maximum is reduced by 5 (1d10). If this effect reduces the target's hit point maximum to 0, the target dies, and if the target was evil, its soul is trapped in the hag's soul bag. The reduction to the target's hit point maximum lasts until removed by the greater restoration spell or similar magic.",
			"",
			"",
			"",
			""));
}
