using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Bubbling Cauldron (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class BubblingCauldron2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "bubbling-cauldron");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 6,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "bubbling-cauldron", "en"),
					Language = LanguageCode.En,
					Name = "Bubbling Cauldron",
					CastingTime = "Action",
					Range = "5 feet",
					Duration = "10 minutes",
					MaterialComponent = "a gold-plated ladle worth 500+ GP",
					Description = "You summon a clawed-foot cauldron of bubbling brew into an unoccupied space on the ground within 5 feet of you. It stays put for the duration (it can't be moved), and when the spell ends it disappears together with everything in it.\n\nWhen you cast the spell, pick one Common or Uncommon potion, such as a Potion of Healing; the brew has that potion's properties. You or an ally can take a Bonus Action to ladle out one dose, which appears in a vial that disappears once the potion has been drunk. The cauldron holds as many doses as your spellcasting ability modifier (at least 1). Taking the last dose makes the cauldron vanish, ending the spell.\n\nIf you cast this spell again, any undrunk doses from your earlier casting disappear.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "bubbling-cauldron", "it"),
					Language = LanguageCode.It,
					Name = "Calderone Ribollente",
					CastingTime = "Azione",
					Range = "1,5 metri",
					Duration = "10 minuti",
					MaterialComponent = "un mestolo placcato d'oro del valore di almeno 500 mo",
					Description = "L'incantatore richiama un calderone dai piedi artigliati, colmo di un intruglio gorgogliante, in uno spazio libero sul terreno entro 1,5 metri da lui. Rimane fermo per la durata (non può essere spostato) e, quando l'incantesimo termina, scompare insieme a tutto ciò che contiene.\n\nAl momento del lancio, l'incantatore sceglie una pozione comune o non comune, come una pozione di guarigione; l'intruglio ne possiede le proprietà. L'incantatore o un alleato può usare un'azione bonus per attingere una dose, che compare in una fiala destinata a scomparire non appena la pozione è stata bevuta. Il calderone contiene tante dosi quanto il modificatore di caratteristica da incantatore dell'incantatore (almeno 1). Prelevare l'ultima dose fa svanire il calderone e pone fine all'incantesimo.\n\nSe l'incantatore lancia di nuovo questo incantesimo, tutte le dosi non bevute del lancio precedente scompaiono.",
					HigherLevels = null
				}
			}
		};
	}
}
