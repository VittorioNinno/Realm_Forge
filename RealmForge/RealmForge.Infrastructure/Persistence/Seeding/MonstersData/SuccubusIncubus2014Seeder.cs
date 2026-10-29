using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Succubus/Incubus (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SuccubusIncubus2014Seeder
{
	public static Monster Build() => Create("succubus-incubus", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Fiend,
		15, 66, "12d8 + 12", 30, new[] { 8, 17, 13, 15, 12, 20 }, 4m, 1100, 2, 15,
		new Text(
			"Succube/Incubo",
			null,
			"Immondo Medio (mutaforma), neutrale malvagio",
			"15 (armatura naturale)",
			"9 m, volare 18 m",
			"",
			"Furtività +7, Inganno +9, Intuizione +5, Percezione +5, Persuasione +9",
			"",
			"freddo, fulmine, fuoco, veleno; contundenti, perforanti e taglienti da attacchi non magici",
			"",
			"",
			"Percezione passiva 15, scurovisione 18 m",
			"Abissale, Comune, Infernale, telepatia 18 m",
			"***Mutaforma.*** L'immondo può usare la sua azione per trasformarsi in un umanoide Piccolo o Medio oppure per tornare alla sua forma naturale. Senza ali, l'immondo perde la sua velocità di volare. Le sue statistiche, a eccezione di taglia e velocità, restano le stesse in ogni forma. Ogni oggetto che indossa o trasporta non viene trasformato. Se muore, torna alla sua forma naturale.\n\n***Legame telepatico.*** L'immondo ignora la restrizione di gittata della sua telepatia quando comunica con una creatura da lui affascinata. Non è nemmeno necessario che i due si trovino sullo stesso piano di esistenza.",
			"***Artiglio (solo forma di immondo).*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 6 (1d6 + 3) danni taglienti.\n\n***Bacio prosciugante.*** L'immondo bacia una creatura da lui affascinata o una creatura consenziente. Il bersaglio deve effettuare un tiro salvezza su Costituzione con CD 15 contro questa magia; subendo 32 (5d10 + 5) danni psichici in caso di fallimento, o la metà in caso di successo. I punti ferita massimi del bersaglio vengono ridotto di un importo pari ai danni subiti. Questa riduzione dura finché il bersaglio non completa un riposo lungo. Il bersaglio muore se questo effetto riduce a 0 i suoi punti ferita massimi.\n\n***Fascino.*** Un umanoide situato nel campo visivo dell'immondo, in un raggio di 9 metri, deve superare un tiro salvezza su Saggezza con CD 15, altrimenti è magicamente affascinato per 1 giorno. Il bersaglio affascinato obbedisce ai comandi verbali o telepatici dell'immondo. Se il bersaglio subisce danni o riceve un comando suicida, può ripetere il tiro salvezza e, se lo supera, l'effetto svanisce. Se il bersaglio supera il tiro salvezza o se l'effetto per lui termina, è immune al fascino di questo immondo per le 24 ore successive. L'immondo può affascinare un solo bersaglio alla volta. Se ne affascina un altro, l'effetto su quello precedente termina.\n\n***Forma eterea.*** L'immondo entra magicamente nel Piano Etereo dal Piano Materiale o viceversa.",
			"",
			"",
			"",
			""),
		new Text(
			"Succubus/Incubus",
			null,
			"Medium fiend (shapechanger), neutral evil",
			"15 (natural armor)",
			"30 ft., fly 60 ft.",
			"",
			"Deception +9, Insight +5, Perception +5, Persuasion +9, Stealth +7",
			"",
			"cold, fire, lightning, poison; bludgeoning, piercing, and slashing from nonmagical weapons",
			"",
			"",
			"darkvision 60 ft., passive Perception 15",
			"Abyssal, Common, Infernal, telepathy 60 ft.",
			"***Telepathic Bond.*** The fiend ignores the range restriction on its telepathy when communicating with a creature it has charmed. The two don't even need to be on the same plane of existence.\n\n***Shapechanger.*** The fiend can use its action to polymorph into a Small or Medium humanoid, or back into its true form. Without wings, the fiend loses its flying speed. Other than its size and speed, its statistics are the same in each form. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.",
			"***Claw (Fiend Form Only).*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 6 (1d6 + 3) slashing damage.\n\n***Charm.*** One humanoid the fiend can see within 30 feet of it must succeed on a DC 15 Wisdom saving throw or be magically charmed for 1 day. The charmed target obeys the fiend's verbal or telepathic commands. If the target suffers any harm or receives a suicidal command, it can repeat the saving throw, ending the effect on a success. If the target successfully saves against the effect, or if the effect on it ends, the target is immune to this fiend's Charm for the next 24 hours.\n\nThe fiend can have only one target charmed at a time. If it charms another, the effect on the previous target ends.\n\n***Draining Kiss.*** The fiend kisses a creature charmed by it or a willing creature. The target must make a DC 15 Constitution saving throw against this magic, taking 32 (5d10 + 5) psychic damage on a failed save, or half as much damage on a successful one. The target's hit point maximum is reduced by an amount equal to the damage taken. This reduction lasts until the target finishes a long rest. The target dies if this effect reduces its hit point maximum to 0.\n\n***Etherealness.*** The fiend magically enters the Ethereal Plane from the Material Plane, or vice versa.",
			"",
			"",
			"",
			""));
}
