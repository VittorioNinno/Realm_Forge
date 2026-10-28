using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Staff of the Python (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StaffOfThePython2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("staff-of-the-python", null, 0, MagicItemType.Staff, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Bastone del pitone", "Bastone, non comune (richiede sintonia con un chierico, un druido o un warlock)",
			"Il personaggio può usare un'azione per pronunciarne la parola d'ordine e gettarlo a terra entro 3 metri da lui. Il bastone diventa un serpente stritolatore gigante sotto il controllo del personaggio e agisce in base al proprio punteggio di iniziativa. Quando il personaggio usa un'azione bonus per pronunciare di nuovo la parola d'ordine, il bastone torna alla sua forma normale nello spazio occupato in precedenza dal serpente.\n\nDurante il proprio turno, il personaggio può comandare mentalmente il serpente, purché questi si trovi entro 18 metri da lui e il personaggio non sia incapacitato. Il personaggio decide quale azione il serpente deve effettuare e dove si muoverà nel suo turno successivo, oppure può impartirgli un comando generico, come per esempio attaccare i nemici o fare la guardia a un luogo.\n\nSe il serpente scende a 0 punti ferita, muore e torna alla forma di bastone. Dopodiché, il bastone va in frantumi e viene distrutto. Se il serpente torna alla forma di bastone prima di perdere tutti i punti ferita, li recupera tutti."),
			("Staff of the Python", "Staff, very rare (requires attunement by a cleric, druid, or warlock)",
			"You can use an action to speak this staff's command word and throw the staff on the ground within 10 feet of you. The staff becomes a giant constrictor snake under your control and acts on its own initiative count. By using a bonus action to speak the command word again, you return the staff to its normal form in a space formerly occupied by the snake.\n\nOn your turn, you can mentally command the snake if it is within 60 feet of you and you aren't incapacitated. You decide what action the snake takes and where it moves during its next turn, or you can issue it a general command, such as to attack your enemies or guard a location.\n\nIf the snake is reduced to 0 hit points, it dies and reverts to its staff form. The staff then shatters and is destroyed. If the snake reverts to staff form before losing all its hit points, it regains all of them.", null));
	}
}
