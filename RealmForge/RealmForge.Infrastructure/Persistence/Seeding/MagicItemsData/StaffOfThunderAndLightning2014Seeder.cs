using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Staff of Thunder and Lightning (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class StaffOfThunderAndLightning2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("staff-of-thunder-and-lightning", null, 0, MagicItemType.Staff, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.AttackAndDamage, 2)),
			("Bastone dei tuoni e fulmini", "Bastone, molto raro (richiede sintonia)",
			"Questo bastone può essere impugnato come un bastone ferrato magico che garantisce un bonus di +2 ai tiri per colpire e ai tiri per i danni effettuati con esso. Possiede anche le seguenti proprietà aggiuntive. Quando una di queste proprietà viene usata, non può essere riutilizzata fino all'alba successiva.\n\n***Fulmini.*** Quando il personaggio colpisce con un attacco in mischia usando questo bastone, il bersaglio subisce 2d6 danni da fulmine extra.\n\n***Tuono.*** Quando il personaggio colpisce con un attacco in mischia usando questo bastone, quest'ultimo scatena un tuono che può essere udito fino a 90 metri. Il bersaglio colpito deve superare un tiro salvezza su Costituzione con CD 17, altrimenti sarà stordito fino alla fine del suo turno successivo.\n\n***Colpo del fulmine.*** Il personaggio può usare un'azione per generare un fulmine che guizza dalla punta del bastone lungo una linea larga 1,5 metri e lunga 36 metri. Ogni creatura su quella linea deve effettuare un tiro salvezza su Destrezza con CD 17, subendo 9d6 danni da fulmine in caso di fallimento, o la metà dei danni in caso di successo.\n\n***Rombo di tuono.*** Il personaggio può usare un'azione per fare in modo che il bastone emetta un rombo di tuono assordante, udibile fino a 180 metri. Ogni creatura entro 18 metri dal personaggio (escluso il personaggio stesso) deve superare un tiro salvezza su Costituzione con CD 17. Se lo fallisce, subisce 2d6 danni da tuono e diventa assordata per 1 minuto, mentre se lo supera, subisce la metà di quei danni e non viene assordata.\n\n***Tuono e fulmine.*** Il personaggio può usare un'azione per attivare le proprietà Colpo del fulmine e Rombo di tuono contemporaneamente. Così facendo il personaggio non consuma l'uso giornaliero di quelle proprietà, ma solamente l'uso di questa.", null),
			("Staff of Thunder and Lightning", "Staff, very rare (requires attunement)",
			"This staff can be wielded as a magic quarterstaff that grants a +2 bonus to attack and damage rolls made with it. It also has the following additional properties. When one of these properties is used, it can't be used again until the next dawn.\n\n***Lightning.*** When you hit with a melee attack using the staff, you can cause the target to take an extra 2d6 lightning damage.\n\n***Thunder.*** When you hit with a melee attack using the staff, you can cause the staff to emit a crack of thunder, audible out to 300 feet. The target you hit must succeed on a DC 17 Constitution saving throw or become stunned until the end of your next turn.\n\n***Lightning Strike.*** You can use an action to cause a bolt of lightning to leap from the staff's tip in a line that is 5 feet wide and 120 feet long. Each creature in that line must make a DC 17 Dexterity saving throw, taking 9d6 lightning damage on a failed save, or half as much damage on a successful one.\n\n***Thunderclap.*** You can use an action to cause the staff to issue a deafening thunderclap, audible out to 600 feet. Each creature within 60 feet of you (not including you) must make a DC 17 Constitution saving throw. On a failed save, a creature takes 2d6 thunder damage and becomes deafened for 1 minute. On a successful save, a creature takes half damage and isn't deafened.\n\n***Thunder and Lightning.*** You can use an action to use the Lightning Strike and Thunderclap properties at the same time. Doing so doesn't expend the daily use of those properties, only the use of this one.", null));
	}
}
