using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Marvelous Pigments (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class MarvelousPigments2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("marvelous-pigments", null, 0, MagicItemType.WondrousItem, ItemRarity.VeryRare, false, ContentSource.Srd51,
			null,
			("Pigmenti meravigliosi", "Oggetto meraviglioso, molto raro",
			"Questi pigmenti, che solitamente si trovano in 1d4 vasetti custoditi all'interno di un'elegante scatola di legno insieme a un pennello (per un peso totale di 0,5 kg), consentono di creare oggetti tridimensionali dipingendoli in due dimensioni. La vernice fluisce dal pennello e forma l'oggetto desiderato mentre il personaggio si concentra sulla sua immagine.\n\nOgni vasetto di pittura può coprire una superficie di 90 metri quadrati e consente al personaggio di creare oggetti inanimati o caratteristiche del terreno (porte, fosse, fiori, alberi, celle, stanze o armi) per un volume massimo pari a 10.000 cubi con spigolo di 30 cm. Per coprire un'area di 9 metri quadrati sono necessari 10 minuti di tempo.\n\nDopo che il personaggio ha completato il dipinto, l'oggetto o l'elemento del terreno diventa un oggetto non magico reale. Di conseguenza, se il personaggio dipinge una porta su un muro, crea una vera porta che dà accesso a ciò che si trova dall'altra parte e, se dipinge una fossa sul pavimento, crea una fossa vera e propria la cui profondità conta al fine di determinare l'area totale di oggetti che il personaggio può creare.\n\nNulla di ciò che viene creato tramite i pigmenti può avere un valore superiore a 25 mo. Se il personaggio dipinge un oggetto di valore superiore (come un diamante o una pila d'oro), tale oggetto appare autentico, ma un esame accurato rivela che è composto di pasta, di osso o di qualche altro materiale privo di valore.\n\nSe viene dipinta una forma di energia come il fuoco o il fulmine, l'energia compare, ma si dissipa non appena il personaggio finisce di dipingerla, senza infliggere alcun danno."),
			("Marvelous Pigments", "Wondrous item, very rare",
			"Typically found in 1d4 pots inside a fine wooden box with a brush (weighing 1 pound in total), these pigments allow you to create three-dimensional objects by painting them in two dimensions. The paint flows from the brush to form the desired object as you concentrate on its image.\n\nEach pot of paint is sufficient to cover 1,000 square feet of a surface, which lets you create inanimate objects or terrain features-such as a door, a pit, flowers, trees, cells, rooms, or weapons- that are up to 10,000 cubic feet. It takes 10 minutes to cover 100 square feet.\n\nWhen you complete the painting, the object or terrain feature depicted becomes a real, nonmagical object. Thus, painting a door on a wall creates an actual door that can be opened to whatever is beyond. Painting a pit on a floor creates a real pit, and its depth counts against the total area of objects you create.\n\nNothing created by the pigments can have a value greater than 25 gp. If you paint an object of greater value (such as a diamond or a pile of gold), the object looks authentic, but close inspection reveals it is made from paste, bone, or some other worthless material.\n\nIf you paint a form of energy such as fire or lightning, the energy appears but dissipates as soon as you complete the painting, doing no harm to anything.", "Nolzur's Marvelous Pigments"));
	}
}
