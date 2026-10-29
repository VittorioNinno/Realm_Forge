using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Vampire Spawn (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class VampireSpawn2014Seeder
{
	public static Monster Build() => Create("vampire-spawn", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Undead,
		15, 82, "11d8 + 33", 30, new[] { 16, 16, 16, 11, 10, 12 }, 5m, 1800, 3, 13,
		new Text(
			"Progenie vampirica",
			null,
			"Non morto Medio, neutrale malvagia",
			"15 (armatura naturale)",
			"9 m",
			"Des +6, Sag +3",
			"Furtività +6, Percezione +3",
			"",
			"necrotici; contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"",
			"Percezione passiva 13, scurovisione 18 m",
			"quelli conosciuti in vita",
			"***Debolezze dei vampiri.*** Il vampiro ha i seguenti difetti: *Danneggiato dall'acqua corrente.* La progenie subisce 20 danni da acido se termina il suo turno nell'acqua corrente. *Ipersensibilità al sole.* Il vampiro subisce 20 danni radiosi quando inizia il suo turno alla luce del sole. Mentre è esposto a tale luce, subisce svantaggio a tiri per colpire e prove di caratteristica. *Paletto nel cuore.* Se un'arma perforante fatta di legno viene piantata nel cuore della progenie mentre è incapacitata nel suo luogo di riposo, la progenie viene distrutta. *Proibizione.* Il vampiro non può entrare in casa di qualcuno se non viene invitato da chi vi risiede.\n\n***Movimenti del ragno.*** Il vampiro può arrampicarsi su superfici difficili, compresi i soffitti (lungo i quali si muove a testa in giù), senza effettuare una prova di caratteristica.\n\n***Rigenerazione.*** Il vampiro recupera 10 punti ferita all'inizio del suo turno se possiede almeno 1 punto ferita e non è esposto alla luce del sole o all'acqua corrente. Se subisce danni radiosi o danni dall'acqua santa, questo tratto non funziona all'inizio del suo turno successivo.",
			"***Multiattacco.*** Il vampiro effettua due attacchi, di cui solo uno può essere un morso.\n\n***Artigli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, una creatura. *Colpito:* 8 (2d4 + 3) danni taglienti. Invece di infliggere danni, il vampiro può afferrare il bersaglio (CD 13 per sfuggire).\n\n***Morso.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, una creatura consenziente o una che sia incapacitata, afferrata o trattenuta dal vampiro. *Colpito:* 6 (1d6 + 3) danni perforanti più 7 (2d6) danni necrotici. I punti ferita massimi del bersaglio sono ridotti di un importo pari ai danni necrotici subiti e il vampiro recupera un numero di punti ferita pari a quell'importo. La riduzione dura finché il bersaglio non termina un riposo lungo. Il bersaglio muore se questo effetto riduce a 0 i suoi punti ferita massimi.",
			"",
			"",
			"",
			""),
		new Text(
			"Vampire Spawn",
			null,
			"Medium undead, neutral evil",
			"15 (natural armor)",
			"30 ft.",
			"Dex +6, Wis +3",
			"Perception +3, Stealth +6",
			"",
			"necrotic; bludgeoning, piercing, and slashing from nonmagical weapons",
			"",
			"",
			"darkvision 60 ft., passive Perception 13",
			"the languages it knew in life",
			"***Regeneration.*** The vampire regains 10 hit points at the start of its turn if it has at least 1 hit point and isn't in sunlight or running water. If the vampire takes radiant damage or damage from holy water, this trait doesn't function at the start of the vampire's next turn.\n\n***Spider Climb.*** The vampire can climb difficult surfaces, including upside down on ceilings, without needing to make an ability check.\n\n***Vampire Weaknesses.*** The vampire has the following flaws:\n\nForbiddance. The vampire can't enter a residence without an invitation from one of the occupants.\nHarmed by Running Water. The vampire takes 20 acid damage when it ends its turn in running water.\nStake to the Heart. The vampire is destroyed if a piercing weapon made of wood is driven into its heart while it is incapacitated in its resting place.\nSunlight Hypersensitivity. The vampire takes 20 radiant damage when it starts its turn in sunlight. While in sunlight, it has disadvantage on attack rolls and ability checks.",
			"***Multiattack.*** The vampire makes two attacks, only one of which can be a bite attack.\n\n***Bite.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one willing creature, or a creature that is grappled by the vampire, incapacitated, or restrained. *Hit:* 6 (1d6 + 3) piercing damage plus 7 (2d6) necrotic damage. The target's hit point maximum is reduced by an amount equal to the necrotic damage taken, and the vampire regains hit points equal to that amount. The reduction lasts until the target finishes a long rest. The target dies if this effect reduces its hit point maximum to 0.\n\n***Claws.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one creature. *Hit:* 8 (2d4 + 3) slashing damage. Instead of dealing damage, the vampire can grapple the target (escape DC 13).",
			"",
			"",
			"",
			""));
}
