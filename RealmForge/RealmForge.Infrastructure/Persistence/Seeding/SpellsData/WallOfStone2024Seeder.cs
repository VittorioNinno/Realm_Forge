using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wall of Stone (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WallOfStone2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-stone");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-stone", "en"),
					Language = LanguageCode.En,
					Name = "Wall of Stone",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a cube of granite",
					Description = "A nonmagical wall of solid stone springs into existence at a point you choose within range. The wall is 6 inches thick and is composed of ten 10-foot-by-10-foot panels. Each panel must be contiguous with another panel. Alternatively, you can create 10-foot-by-20-foot panels that are only 3 inches thick.\n\nIf the wall cuts through a creature's space when it appears, the creature is pushed to one side of the wall (you choose which side). If a creature would be surrounded on all sides by the wall (or the wall and another solid surface), that creature can make a Dexterity saving throw. On a success, it can use its Reaction to move up to its Speed so that it is no longer enclosed by the wall.\n\nThe wall can have any shape you desire, though it can't occupy the same space as a creature or object. The wall doesn't need to be vertical or rest on a firm foundation. It must, however, merge with and be solidly supported by existing stone. Thus, you can use this spell to bridge a chasm or create a ramp.\n\nIf you create a span greater than 20 feet in length, you must halve the size of each panel to create supports. You can crudely shape the wall to create battlements and the like.\n\nThe wall is an object made of stone that can be damaged and thus breached. Each panel has AC 15 and 30 Hit Points per inch of thickness, and it has Immunity to Poison and Psychic damage. Reducing a panel to 0 Hit Points destroys it and might cause connected panels to collapse at the GM's discretion.\n\nIf you maintain your Concentration on this spell for its full duration, the wall becomes permanent and can't be dispelled. Otherwise, the wall disappears when the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "wall-of-stone", "it"),
					Language = LanguageCode.It,
					Name = "Muro di Pietra",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un cubo di granito",
					Description = "Un muro non magico di pietra solida prende forma in un punto entro gittata a scelta dell'incantatore. Il muro è spesso 15 centimetri ed è composto da dieci pannelli di 3 metri per 3 metri. Ogni pannello deve essere adiacente a un altro pannello. In alternativa, l'incantatore può creare pannelli di 3 metri per 6 metri spessi soltanto 7,5 centimetri.\n\nSe il muro attraversa lo spazio di una creatura quando compare, la creatura viene spinta su un lato del muro (a scelta dell'incantatore). Se una creatura dovesse essere circondata su tutti i lati dal muro (o dal muro e da un'altra superficie solida), può effettuare un tiro salvezza su Destrezza. Se lo supera, può usare la propria reazione per muoversi fino alla sua velocità, in modo da non essere più racchiusa dal muro.\n\nIl muro può avere qualsiasi forma l'incantatore desideri, ma non può occupare lo stesso spazio di una creatura o di un oggetto. Il muro non deve necessariamente essere verticale o poggiare su fondamenta solide. Deve però fondersi con la pietra esistente ed esserne sostenuto saldamente. L'incantatore può quindi usare questo incantesimo per gettare un ponte su un baratro o creare una rampa.\n\nSe crea una campata più lunga di 6 metri, l'incantatore deve dimezzare le dimensioni di ogni pannello per creare dei sostegni. Può modellare rozzamente il muro per creare merlature e simili.\n\nIl muro è un oggetto di pietra che può essere danneggiato e quindi sfondato. Ogni pannello ha CA 15 e 30 punti ferita ogni 2,5 centimetri di spessore, ed è immune ai danni psichici e da veleno. Ridurre un pannello a 0 punti ferita lo distrugge e potrebbe far crollare i pannelli collegati, a discrezione del DM.\n\nSe l'incantatore mantiene la concentrazione su questo incantesimo per l'intera durata, il muro diventa permanente e non può essere dissolto. Altrimenti, il muro scompare quando l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
