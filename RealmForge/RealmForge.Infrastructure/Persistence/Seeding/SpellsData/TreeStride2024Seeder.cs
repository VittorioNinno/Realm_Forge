using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Tree Stride (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class TreeStride2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tree-stride");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tree-stride", "en"),
					Language = LanguageCode.En,
					Name = "Tree Stride",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You gain the ability to enter a tree and move from inside it to inside another tree of the same kind within 500 feet. Both trees must be living and at least the same size as you. You must use 5 feet of movement to enter a tree. You instantly know the location of all other trees of the same kind within 500 feet and, as part of the move used to enter the tree, can either pass into one of those trees or step out of the tree you're in. You appear in a spot of your choice within 5 feet of the destination tree, using another 5 feet of movement. If you have no movement left, you appear within 5 feet of the tree you entered.\n\nYou can use this transportation ability only once on each of your turns. You must end each turn outside a tree.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "tree-stride", "it"),
					Language = LanguageCode.It,
					Name = "Traslazione Arborea",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore ottiene la capacità di entrare in un albero e spostarsi dal suo interno all'interno di un altro albero della stessa specie entro 150 metri. Entrambi gli alberi devono essere vivi e grandi almeno quanto l'incantatore. Per entrare in un albero, l'incantatore deve usare 1,5 metri di movimento. Conosce istantaneamente la posizione di tutti gli altri alberi della stessa specie entro 150 metri e, come parte del movimento usato per entrare nell'albero, può passare in uno di quegli alberi o uscire dall'albero in cui si trova. Compare in un punto a sua scelta entro 1,5 metri dall'albero di destinazione, usando altri 1,5 metri di movimento. Se non gli resta movimento, compare entro 1,5 metri dall'albero in cui è entrato.\n\nL'incantatore può usare questa capacità di trasporto una sola volta in ognuno dei suoi turni. Deve terminare ogni turno fuori da un albero.",
					HigherLevels = null
				}
			}
		};
	}
}
