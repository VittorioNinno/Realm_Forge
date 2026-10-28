using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Berserker Axe (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BerserkerAxe2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("berserker-axe", null, 0, MagicItemType.Weapon, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 1)),
			("Ascia del berserker", "Arma (qualsiasi ascia), rara (richiede sintonia)",
			"Il personaggio ottiene un bonus di +1 ai tiri per colpire e ai tiri per i danni effettuati con quest'arma magica. Inoltre, una volta entrato in sintonia con l'arma, il suoi punti ferita massimi aumentano di 1 per ogni livello acquisito.\n\n***Maledizione.*** Quest'ascia è maledetta e la sua maledizione si trasmette al personaggio quando entra in sintonia con essa. Finché è maledetto, il personaggio non vuole separarsene e non la perde mai di vista. Subisce inoltre svantaggio ai tiri per colpire effettuati con tutte le altre armi, a meno che nel raggio di 18 metri non ci sia alcun nemico che è in grado di vedere o udire.\n\nOgni volta che una creatura ostile infligge danni al personaggio mentre questi è in possesso dell'ascia, il personaggio deve superare un tiro salvezza su Saggezza con CD 15, altrimenti entra in uno stato di berserk. Finché è in stato di berserk, il personaggio deve usare la sua azione ogni round per attaccare con l'ascia la creatura a lui più vicina. Se il personaggio può effettuare attacchi extra come parte della sua azione Attacco, li effettua muovendosi per attaccare la creatura successiva più vicina dopo avere abbattuto il bersaglio attuale. Se i bersagli possibili sono più di uno, ne attacca uno a caso. Il personaggio rimane in uno stato di berserk fino a quando non ci sono più creature che può vedere o udire entro un raggio di 18 metri all'inizio del suo turno."),
			("Berserker Axe", "Weapon (any axe), rare (requires attunement)",
			"You gain a +1 bonus to attack and damage rolls made with this magic weapon. In addition, while you are attuned to this weapon, your Hit points maximum increases by 1 for each level you have attained.\n\n***Curse.*** This axe is cursed, and becoming attuned to it extends the curse to you. As long as you remain cursed, you are unwilling to part with the axe, keeping it within reach at all times. You also have disadvantage on attack rolls with weapons other than this one, unless no foe is within 60 feet of you that you can see or hear.\n\nWhenever a hostile creature damages you while the axe is in your possession, you must succeed on a DC 15 Wisdom saving throw or go berserk. While berserk, you must use your action each round to attack the creature nearest to you with the axe. If you can make extra attacks as part of the attack action, you use those extra attacks, moving to attack the next nearest creature after you fell your current target. If you have multiple possible targets, you attack one at random. You are berserk until you start your turn with no creatures within 60 feet of you that you can see or hear.", null));
	}
}
