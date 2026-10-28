using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Tome of the Stilled Tongue (2014 ruleset). Item of the 2014 Dungeon Master's Guide outside the SRD: name and texts written by RealmForge (Italian and English).
///	</summary>
public static class TomeOfTheStilledTongue2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("tome-of-the-stilled-tongue", null, 0, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.RealmForge,
			null,
			("Tomo della lingua essiccata", "Oggetto meraviglioso, leggendario (richiede sintonia con un mago)",
			"Un pesante volume rilegato in pelle con una lingua rinsecchita inchiodata sulla copertina. Ne esistono cinque copie e nessuno sa quale sia l'originale: la lingua del primo apparteneva a un servitore traditore del dio-lich Vecna, custode dei segreti, mentre quelle delle copie provengono da altri incantatori che lo hanno sfidato. Le prime pagine sono coperte di scarabocchi indecifrabili, le altre sono bianche e intatte.\n\nIl personaggio in sintonia con il tomo può usarlo come libro degli incantesimi e come focus arcano. Inoltre, mentre lo impugna, può usare un'azione bonus per lanciare un incantesimo scritto nel tomo senza spendere uno slot incantesimo e senza componenti verbali o somatiche; non può usare di nuovo questa proprietà fino all'alba successiva.\n\nMentre è in sintonia con il tomo, il personaggio può staccare la lingua dalla copertina: se lo fa, tutti gli incantesimi scritti nel libro vengono cancellati per sempre.\n\nVecna osserva chiunque usi il tomo, e a volte vi scrive messaggi criptici che compaiono a mezzanotte e svaniscono dopo essere stati letti.", null),
			("Tome of the Stilled Tongue", "Wondrous item, legendary (requires attunement by a wizard)",
			"A heavy leather-bound volume with a shriveled tongue pinned to its cover. Five of these tomes exist and nobody knows which is the original: the first tongue belonged to a treacherous servant of the lich-god Vecna, keeper of secrets, while the copies bear the tongues of other spellcasters who crossed him. The first pages are covered in unreadable scrawls; the rest are blank and untouched.\n\nIf you are attuned to the tome, you can use it as a spellbook and an arcane focus. In addition, while holding it, you can use a bonus action to cast a spell written in it without expending a spell slot and without verbal or somatic components; you can't use this property again until the next dawn.\n\nWhile attuned to the tome, you can tear the tongue off its cover: if you do, every spell written in the book is erased forever.\n\nVecna watches anyone who uses the tome, and sometimes writes cryptic messages in it that appear at midnight and fade once they are read.", null));
	}
}
