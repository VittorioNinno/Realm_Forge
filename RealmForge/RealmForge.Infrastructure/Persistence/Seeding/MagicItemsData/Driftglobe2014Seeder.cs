using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Driftglobe (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class Driftglobe2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("driftglobe", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, false, ContentSource.RealmForge,
			null,
			("Globo fluttuante", "Oggetto meraviglioso, non comune",
			"Una piccola sfera di vetro spesso che pesa 500 grammi. Se il personaggio si trova entro 18 metri dal globo, può pronunciarne una parola di comando per fargli emanare l'incantesimo *luce* o *luce diurna*. L'effetto di *luce diurna* non può essere riusato fino all'alba successiva.\n\nCon un'azione, il personaggio può pronunciare un'altra parola di comando per far salire in aria il globo illuminato, che resta sospeso a non più di 1,5 metri dal suolo finché qualcuno non lo afferra. Se il personaggio si allontana a più di 18 metri, il globo lo segue per la via più breve fino a tornargli entro 18 metri; se qualcosa gli impedisce di muoversi, scende piano a terra, si disattiva e la sua luce si spegne."),
			("Driftglobe", "Wondrous item, uncommon",
			"A small sphere of thick glass weighing 1 pound. If you are within 60 feet of it, you can speak a command word to make it emanate the *light* or *daylight* spell. The *daylight* effect can't be used again until the next dawn.\n\nAs an action, you can speak another command word to make the glowing globe rise into the air; it hovers no more than 5 feet above the ground until someone grabs it. If you move more than 60 feet away, it follows you by the shortest route until it is within 60 feet again; if something stops it, it sinks gently to the ground, becomes inactive and its light goes out.", null));
	}
}
