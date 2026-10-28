using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Robe of Eyes (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RobeOfEyes2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("robe-of-eyes", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Tunica degli occhi", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Questa tunica è decorata con un motivo raffigurante vari occhi. Mentre il personaggio la indossa ottiene i benefici seguenti:\n\n- Il personaggio dispone di vantaggio alle prove di Saggezza (Percezione) basate sulla vista e la tunica gli consente di vedere in tutte le direzioni.\n\n- Il personaggio ha scurovisione entro un raggio di 36 metri.\n\n- Il personaggio può vedere le creature e gli oggetti invisibili ed è in grado di vedere il Piano Etereo entro un raggio di 36 metri.\n\nGli occhi della tunica non possono essere chiusi e non distolgono lo sguardo in alcun modo. Anche se il personaggio può chiudere i propri occhi o distogliere il proprio sguardo, finché indossa la tunica non è mai considerato con gli occhi chiusi o distolti.\n\nUn incantesimo *luce* lanciato sulla tunica o un incantesimo *luce diurna* lanciato entro 1,5 metri dalla tunica rende il personaggio accecato per 1 minuto. Alla fine di ogni suo turno, il personaggio può effettuare un tiro salvezza su Costituzione (CD 11 per *luce* o CD 15 per *luce diurna),* terminando la cecità in caso di successo.", null),
			("Robe of Eyes", "Wondrous item, rare (requires attunement)",
			"This robe is adorned with eyelike patterns. While you wear the robe, you gain the following benefits:\n\nThe robe lets you see in all directions, and you have advantage on Wisdom (Perception) checks that rely on sight.\n\nYou have darkvision out to a range of 120 feet.\n\nYou can see invisible creatures and objects, as well as see into the Ethereal Plane, out to a range of 120 feet.\n\nThe eyes on the robe can't be closed or averted. Although you can close or avert your own eyes, you are never considered to be doing so while wearing this robe.\n\nA light spell cast on the robe or a daylight spell cast within 5 feet of the robe causes you to be blinded for 1 minute. At the end of each of your turns, you can make a Constitution saving throw (DC 11 for light or DC 15 for daylight), ending the blindness on a success.", null));
	}
}
