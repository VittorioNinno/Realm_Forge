using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Rod of Absorption (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class RodOfAbsorption2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("rod-of-absorption", null, 0, MagicItemType.Rod, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Verga dell'assorbimento", "Verga, molto rara (richiede sintonia)",
			"Mentre il personaggio impugna questa verga, può usare la sua reazione per assorbire un incantesimo che sta bersagliando solo lui e che non abbia un'area di effetto. L'effetto dell'incantesimo assorbito è annullato e l'energia dell'incantesimo (ma non l'incantesimo vero e proprio) viene accumulata nella verga. L'energia ha lo stesso livello dell'incantesimo nel momento in cui è stato lanciato. La verga può assorbire e accumulare fino a 50 livelli di energia nel corso della sua esistenza. Dopo aver assorbito 50 livelli di energia, non può assorbirne altri. Se il personaggio è bersagliato da un incantesimo che non può essere accumulato, la verga non ha alcun effetto su quell'incantesimo.\n\nQuando il personaggio entra in sintonia con la verga, scopre quanti livelli di energia quest'ultima ha assorbito nel corso della propria esistenza e quanti livelli di energia degli incantesimi contiene attualmente.\n\nSe il personaggio è un incantatore e impugna la verga, può trasformare l'energia accumulata al suo interno in slot incantesimo e usarli per lanciare gli incantesimi che ha preparato o che conosce. Il personaggio può creare soltanto slot incantesimo di livello pari o inferiore a quello dei propri slot, fino al 5° livello al massimo. Il personaggio usa i livelli accumulati al posto dei propri slot, ma sotto ogni altro aspetto lancia l'incantesimo normalmente. Per esempio, può usare 3 livelli accumulati nella verga come uno slot incantesimo di 3° livello.\n\nUna verga appena trovata ha già 1d10 livelli di energia di incantesimi accumulati. Una verga che non può assorbire altra energia degli incantesimi e a cui non rimane più energia smette di essere un oggetto magico."),
			("Rod of Absorption", "Rod, very rare (requires attunement)",
			"While holding this rod, you can use your reaction to absorb a spell that is targeting only you and not with an area of effect. The absorbed spell's effect is canceled, and the spell's energy-not the spell itself-is stored in the rod. The energy has the same level as the spell when it was cast. The rod can absorb and store up to 50 levels of energy over the course of its existence. Once the rod absorbs 50 levels of energy, it can't absorb more. If you are targeted by a spell that the rod can't store, the rod has no effect on that spell.\n\nWhen you become attuned to the rod, you know how many levels of energy the rod has absorbed over the course of its existence, and how many levels of spell energy it currently has stored.\n\nIf you are a spellcaster holding the rod, you can convert energy stored in it into spell slots to cast spells you have prepared or know. You can create spell slots only of a level equal to or lower than your own spell slots, up to a maximum of 5th level. You use the stored levels in place of your slots, but otherwise cast the spell as normal. For example, you can use 3 levels stored in the rod as a 3rd-level spell slot.\n\nA newly found rod has 1d10 levels of spell energy stored in it already. A rod that can no longer absorb spell energy and has no energy remaining becomes nonmagical.", null));
	}
}
