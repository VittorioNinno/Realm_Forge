using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wall of Stone (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WallOfStone2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-stone");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-stone", "en"),
					Language = LanguageCode.En,
					Name = "Wall of Stone",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a small block of granite",
					Description = "A nonmagical wall of solid stone springs into existence at a point you choose within range. The wall is 6 inches thick and is composed of ten 10-foot-by-10-foot panels. Each panel must be contiguous with at least one other panel. Alternatively, you can create 10-foot-by-20-foot panels that are only 3 inches thick.\n\nIf the wall cuts through a creature's space when it appears, the creature is pushed to one side of the wall (your choice). If a creature would be surrounded on all sides by the wall (or the wall and another solid surface), that creature can make a Dexterity saving throw. On a success, it can use its reaction to move up to its speed so that it is no longer enclosed by the wall.\n\nThe wall can have any shape you desire, though it can't occupy the same space as a creature or object. The wall doesn't need to be vertical or rest on any firm foundation. It must, however, merge with and be solidly supported by existing stone. Thus, you can use this spell to bridge a chasm or create a ramp.\n\nIf you create a span greater than 20 feet in length, you must halve the size of each panel to create supports. You can crudely shape the wall to create crenellations, battlements, and so on.\n\nThe wall is an object made of stone that can be damaged and thus breached. Each panel has AC 15 and 30 hit points per inch of thickness. Reducing a panel to 0 hit points destroys it and might cause connected panels to collapse at the GM's discretion.\n\nIf you maintain your concentration on this spell for its whole duration, the wall becomes permanent and can't be dispelled. Otherwise, the wall disappears when the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wall-of-stone", "it"),
					Language = LanguageCode.It,
					Name = "Muro di Pietra",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "un piccolo blocco di granito",
					Description = "Un muro non magico di pietra solida si materializza in un punto entro gittata scelto dall'incantatore. Il muro è spesso 15 cm ed è composto da dieci pannelli di 3 metri per 3 metri. Ogni pannello deve essere adiacente ad almeno un altro pannello. In alternativa, l'incantatore può creare pannelli di 3 metri per 6 metri, spessi soltanto 7,5 cm.\n\nSe, quando compare, il muro attraversa lo spazio di una creatura, la creatura viene spinta su uno dei lati del muro (a scelta dell'incantatore). Se una creatura dovesse ritrovarsi circondata da ogni lato dal muro (o dal muro e da un'altra superficie solida), può effettuare un tiro salvezza su Destrezza. Se lo supera, può usare la sua reazione per muoversi fino alla sua velocità, in modo da non essere più racchiusa dal muro.\n\nIl muro può avere qualsiasi forma l'incantatore desideri, ma non può occupare lo stesso spazio di una creatura o di un oggetto. Non è necessario che il muro sia verticale o che poggi su fondamenta solide. Deve però fondersi con della pietra esistente ed esserne sostenuto saldamente. In questo modo, l'incantatore può usare questo incantesimo per gettare un ponte su un baratro o creare una rampa.\n\nSe crea una campata di lunghezza superiore a 6 metri, l'incantatore deve dimezzare le dimensioni di ogni pannello per creare dei sostegni. Può modellare grossolanamente il muro per creare merli, bastioni e così via.\n\nIl muro è un oggetto di pietra che può essere danneggiato e quindi aperto. Ogni pannello ha CA 15 e 30 punti ferita per ogni 2,5 cm di spessore. Ridurre un pannello a 0 punti ferita lo distrugge e, a discrezione del DM, può far crollare i pannelli collegati.\n\nSe l'incantatore mantiene la concentrazione su questo incantesimo per l'intera durata, il muro diventa permanente e non può essere dissolto. Altrimenti, il muro scompare quando l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
