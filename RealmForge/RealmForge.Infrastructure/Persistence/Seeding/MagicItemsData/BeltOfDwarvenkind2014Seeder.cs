using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Belt of Dwarvenkind (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class BeltOfDwarvenkind2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("belt-of-dwarvenkind", null, 0, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.AbilityScoreBonus, 2, AbilityScore.Constitution)),
			("Cintura nanica", "Oggetto meraviglioso, raro (richiede sintonia)",
			"Il personaggio che indossa questa cintura riceve i seguenti benefici:\n\n- Il suo punteggio di Costituzione aumenta di 2, fino a un massimo di 20.\n\n- Dispone di vantaggio alle prove di Carisma (Persuasione) effettuate per interagire con i nani. Inoltre, dopo che il personaggio che indossa la cintura è entrato in sintonia con essa, ogni mattina all'alba c'è una probabilità del 50 percento che gli spuntino barba e baffi, premesso che il suo corpo possa svilupparli, o che la sua barba cresca vistosamente, se già ne ha una.\n\nSe non è un nano, ottiene i seguenti benefici aggiuntivi finché indossa la cintura:\n\n- Vantaggio ai tiri salvezza contro il veleno e resistenza ai danni da veleno.\n\n- Scurovisione entro un raggio di 18 metri.\n\n- È in grado di parlare, leggere e scrivere il Nanico.", null),
			("Belt of Dwarvenkind", "Wondrous Items, rare (requires attunement)",
			"While wearing this belt, you gain the following benefits:\n\nYour Constitution score increases by 2, to a maximum of 20.\n\nYou have advantage on Charisma (Persuasion) checks made to interact with Dwarves.\n\nIn addition, while attuned to the belt, you have a 50 percent chance each day at dawn of growing a full beard if you're capable of growing one, or a visibly thicker beard if you already have one.\n\nIf you aren't a dwarf, you gain the following additional benefits while wearing the belt:\n\nYou have advantage on saving throws against poison, and you have resistance against poison damage.\n\nYou can speak, read, and write Dwarvish.", null));
	}
}
