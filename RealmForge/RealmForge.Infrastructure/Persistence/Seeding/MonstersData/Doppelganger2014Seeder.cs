using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Doppelganger (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Doppelganger2014Seeder
{
	public static Monster Build() => Create("doppelganger", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Monstrosity,
		14, 52, "8d8 + 16", 30, new[] { 11, 18, 14, 11, 12, 14 }, 3m, 700, 2, 11,
		new Text(
			"Doppelganger",
			null,
			"Mostruosità Media (mutaforma), neutrale",
			"14",
			"9 m",
			"",
			"Inganno +6, Intuizione +3",
			"",
			"",
			"",
			"affascinato",
			"Percezione passiva 11, scurovisione 18 m",
			"Comune",
			"***Mutaforma.*** Il doppelganger può usare la sua azione per trasformarsi in un umanoide Piccolo o Medio che abbia visto in precedenza, o per tornare alla sua forma naturale. Le sue statistiche, a eccezione della taglia, restano le stesse in ogni forma. Ogni oggetto che indossa o trasporta non viene trasformato. Se muore, torna alla sua forma naturale.\n\n***Attacco a sorpresa.*** Se il doppelganger sorprende una creatura e la colpisce con un attacco durante il primo round di combattimento, il bersaglio subisce 10 (3d6) danni extra dall'attacco.\n\n***Imboscata.*** Nel primo round di un combattimento, il doppelganger dispone di vantaggio ai tiri per colpire contro qualsiasi creatura che riesca a cogliere di sorpresa.",
			"***Multiattacco.*** Il doppelganger effettua due attacchi in mischia.\n\n***Schianto.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 7 (1d6 + 4) danni contundenti.\n\n***Lettura del pensiero.*** Il doppelganger può leggere magicamente i pensieri superficiali di una creatura entro 18 metri da lui. Questo effetto può penetrare le barriere, ma 90 centimetri di legno o terriccio, 60 centimetri di pietra, 5 centimetri di metallo o una sottile lamina di piombo lo bloccano. Mentre il bersaglio si trova entro gittata, il doppelganger può continuare a leggere i suoi pensieri finché non perde la concentrazione (come se si concentrasse su un incantesimo). Quando legge i pensieri del bersaglio, il doppelganger dispone di vantaggio alle prove di Saggezza (Intuizione) e Carisma (Inganno, Intimidire e Persuasione) contro il bersaglio.",
			"",
			"",
			"",
			""),
		new Text(
			"Doppelganger",
			null,
			"Medium monstrosity (shapechanger), unaligned",
			"14",
			"30 ft.",
			"",
			"Deception +6, Insight +3",
			"",
			"",
			"",
			"charmed",
			"darkvision 60 ft., passive Perception 11",
			"Common",
			"***Shapechanger.*** The doppelganger can use its action to polymorph into a Small or Medium humanoid it has seen, or back into its true form. Its statistics, other than its size, are the same in each form. Any equipment it is wearing or carrying isn't transformed. It reverts to its true form if it dies.\n\n***Ambusher.*** In the first round of combat, the doppelganger has advantage on attack rolls against any creature it has surprised.\n\n***Surprise Attack.*** If the doppelganger surprises a creature and hits it with an attack during the first round of combat, the target takes an extra 10 (3d6) damage from the attack.",
			"***Multiattack.*** The doppelganger makes two melee attacks.\n\n***Slam.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 7 (1d6 + 4) bludgeoning damage.\n\n***Read Thoughts.*** The doppelganger magically reads the surface thoughts of one creature within 60 ft. of it. The effect can penetrate barriers, but 3 ft. of wood or dirt, 2 ft. of stone, 2 inches of metal, or a thin sheet of lead blocks it. While the target is in range, the doppelganger can continue reading its thoughts, as long as the doppelganger's concentration isn't broken (as if concentrating on a spell). While reading the target's mind, the doppelganger has advantage on Wisdom (Insight) and Charisma (Deception, Intimidation, and Persuasion) checks against the target.",
			"",
			"",
			"",
			""));
}
