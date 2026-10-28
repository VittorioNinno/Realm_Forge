using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Javelin of Lightning (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class JavelinOfLightning2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("javelin-of-lightning", null, 0, MagicItemType.Weapon, ItemRarity.Uncommon, false, ContentSource.Srd51,
			null,
			("Giavellotto del fulmine", "Arma (giavellotto), non comune",
			"Questo giavellotto è un'arma magica. Quando il personaggio lo scaglia pronunciandone la parola d'ordine, si trasforma in un fulmine che forma una linea larga 1,5 metri e si estende dal personaggio a un bersaglio situato entro 36 metri. Ogni creatura lungo la linea (a eccezione del personaggio) deve effettuare un tiro salvezza su Destrezza con CD 13; se lo fallisce, subisce 4d6 danni da fulmine, mentre se lo supera subisce la metà di quei danni. Una volta raggiunto il bersaglio, il fulmine torna ad essere un giavellotto. Il personaggio effettua un attacco con arma a distanza contro il bersaglio; se il colpo va a segno, il bersaglio subisce i danni del giavellotto più 4d6 danni da fulmine.\n\nLa proprietà del giavellotto non può essere riutilizzata fino all'alba successiva. Nel frattempo, il giavellotto può comunque essere usato come arma magica."),
			("Javelin of Lightning", "Weapon (javelin), uncommon",
			"This javelin is a magic weapon. When you hurl it and speak its command word, it transforms into a bolt of lightning, forming a line 5 feet wide that extends out from you to a target within 120 feet. Each creature in the line excluding you and the target must make a DC 13 Dexterity saving throw, taking 4d6 lightning damage on a failed save, and half as much damage on a successful one. The lightning bolt turns back into a javelin when it reaches the target. Make a ranged weapon attack against the target. On a hit, the target takes damage from the javelin plus 4d6 lightning damage.\n\nThe javelin's property can't be used again until the next dawn. In the meantime, the javelin can still be used as a magic weapon.", null));
	}
}
