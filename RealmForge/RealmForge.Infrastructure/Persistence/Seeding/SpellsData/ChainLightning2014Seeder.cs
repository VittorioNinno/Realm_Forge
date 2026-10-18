using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Chain Lightning (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ChainLightning2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "chain-lightning");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "chain-lightning", "en"),
					Language = LanguageCode.En,
					Name = "Chain Lightning",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "a bit of fur; a piece of amber, glass, or a crystal rod; and three silver pins",
					Description = "You create a bolt of lightning that arcs toward a target of your choice that you can see within range. Three bolts then leap from that target to as many as three other targets, each of which must be within 30 feet of the first target. A target can be a creature or an object and can be targeted by only one of the bolts.\n\nA target must make a Dexterity saving throw. The target takes 10d8 lightning damage on a failed save, or half as much damage on a successful one.",
					HigherLevels = "When you cast this spell using a spell slot of 7th level or higher, one additional bolt leaps from the first target to another target for each slot level above 6th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "chain-lightning", "it"),
					Language = LanguageCode.It,
					Name = "Catena di Fulmini",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "un po' di pelliccia; un pezzo d'ambra, di vetro o una bacchetta di cristallo; e tre spilli d'argento",
					Description = "L'incantatore crea un fulmine che si inarca verso un bersaglio a sua scelta entro gittata, che egli sia in grado di vedere. Da quel bersaglio partono poi tre fulmini che saltano fino a un massimo di altri tre bersagli, ognuno dei quali deve trovarsi entro 9 metri dal primo bersaglio. Un bersaglio può essere una creatura o un oggetto e può essere bersagliato da uno solo dei fulmini.\n\nUn bersaglio deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, subisce 10d8 danni da fulmine; se lo supera, subisce la metà di quei danni.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 7° livello o superiore, un fulmine aggiuntivo salta dal primo bersaglio a un altro bersaglio per ogni livello dello slot superiore al 6°."
				}
			}
		};
	}
}
