using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Efreeti Chain (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class EfreetiChain2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("efreeti-chain", null, 0, MagicItemType.Armor, ItemRarity.Legendary, true, ContentSource.RealmForge,
			Magic(Effect(MagicEffectKind.ArmorClass, 3)),
			("Cotta dell'efreeti", "Armatura (cotta di maglia), leggendaria (richiede sintonia)",
			"Mentre indossa questa armatura, il personaggio ottiene un bonus di +3 alla CA, è immune ai danni da fuoco e può parlare e capire il Primordiale. Inoltre può stare in piedi e camminare sulla roccia fusa come se fosse terreno solido."),
			("Efreeti Chain", "Armor (chain mail), legendary (requires attunement)",
			"While wearing this armor, you gain a +3 bonus to AC, you are immune to fire damage, and you can speak and understand Primordial. You can also stand on and walk across molten rock as if it were solid ground.", null));
	}
}
