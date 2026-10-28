using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Sword of Vengeance (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class SwordOfVengeance2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("sword-of-vengeance", null, 0, MagicItemType.Weapon, ItemRarity.Uncommon, true, ContentSource.RealmForge,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 1)),
			("Spada della vendetta", "Arma (qualsiasi spada), non comune (richiede sintonia)",
			"Il personaggio ottiene un bonus di +1 ai tiri per colpire e ai danni effettuati con quest'arma magica.\n\n***Maledizione.*** La spada è maledetta e posseduta da uno spirito vendicativo; entrare in sintonia con essa estende la maledizione al personaggio. Finché resta maledetto, il personaggio non vuole separarsi dalla spada e la tiene sempre con sé. Mentre è in sintonia con essa, subisce svantaggio ai tiri per colpire con le altre armi.\n\nInoltre, finché ha con sé la spada, ogni volta che subisce danni in combattimento il personaggio deve superare un tiro salvezza su Saggezza con CD 15. Se lo fallisce, deve attaccare la creatura che lo ha danneggiato finché uno dei due non scende a 0 punti ferita o finché non può più raggiungerla con un attacco in mischia.\n\nLa maledizione può essere spezzata nei modi consueti; in alternativa, lanciare *esilio* sulla spada costringe lo spirito ad abbandonarla, e la spada diventa un'arma +1 senza altre proprietà.", null),
			("Sword of Vengeance", "Weapon (any sword), uncommon (requires attunement)",
			"You gain a +1 bonus to attack and damage rolls made with this magic weapon.\n\n***Curse.*** The sword is cursed and possessed by a vengeful spirit; attuning to it extends the curse to you. While cursed, you are unwilling to part with the sword and keep it on you at all times. While attuned to it, you have disadvantage on attack rolls with other weapons.\n\nIn addition, while the sword is on you, you must succeed on a DC 15 Wisdom saving throw whenever you take damage in combat. On a failure, you must attack the creature that damaged you until one of you drops to 0 hit points or you can no longer reach it with a melee attack.\n\nThe curse can be broken in the usual ways; alternatively, casting *banishment* on the sword forces the spirit out, and the sword becomes a +1 weapon with no other properties.", null));
	}
}
