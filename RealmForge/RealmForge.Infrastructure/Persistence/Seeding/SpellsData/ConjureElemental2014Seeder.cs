using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Elemental (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConjureElemental2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-elemental");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-elemental", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Elemental",
					CastingTime = "1 minute",
					Range = "90 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "burning incense for air, soft clay for earth, sulfur and phosphorus for fire, or water and sand for water",
					Description = "You call forth an elemental servant. Choose an area of air, earth, fire, or water that fills a 10-foot cube within range. An elemental of challenge rating 5 or lower appropriate to the area you chose appears in an unoccupied space within 10 feet of it. For example, a fire elemental emerges from a bonfire, and an earth elemental rises up from the ground. The elemental disappears when it drops to 0 hit points or when the spell ends.\n\nThe elemental is friendly to you and your companions for the duration. Roll initiative for the elemental, which has its own turns. It obeys any verbal commands that you issue to it (no action required by you). If you don't issue any commands to the elemental, it defends itself from hostile creatures but otherwise takes no actions.\n\nIf your concentration is broken, the elemental doesn't disappear. Instead, you lose control of the elemental, it becomes hostile toward you and your companions, and it might attack. An uncontrolled elemental can't be dismissed by you, and it disappears 1 hour after you summoned it.\n\nThe GM has the elemental's statistics.",
					HigherLevels = "When you cast this spell using a spell slot of 6th level or higher, the challenge rating increases by 1 for each slot level above 5th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "conjure-elemental", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Elementale",
					CastingTime = "1 minuto",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "incenso acceso per l'aria, argilla morbida per la terra, zolfo e fosforo per il fuoco, oppure acqua e sabbia per l'acqua",
					Description = "L'incantatore richiama un servitore elementale. Sceglie un'area di aria, terra, fuoco o acqua che riempia un cubo con spigolo di 3 metri entro gittata. Un elementale con grado di sfida pari o inferiore a 5, adatto all'area scelta, compare in uno spazio libero entro 3 metri da essa. Per esempio, un elementale del fuoco emerge da un falò e un elementale della terra si solleva dal terreno. L'elementale scompare quando scende a 0 punti ferita o quando l'incantesimo termina.\n\nL'elementale è amichevole nei confronti dell'incantatore e dei suoi compagni per la durata. Si tira l'iniziativa per l'elementale, che agisce nei propri turni. Obbedisce a qualsiasi comando verbale impartito dall'incantatore (non è richiesta alcuna azione da parte sua). Se l'incantatore non gli impartisce alcun comando, l'elementale si difende dalle creature ostili, ma per il resto non compie alcuna azione.\n\nSe la concentrazione dell'incantatore si interrompe, l'elementale non scompare. L'incantatore perde invece il controllo dell'elementale, che diventa ostile nei confronti suoi e dei suoi compagni e potrebbe attaccarli. Un elementale fuori controllo non può essere congedato dall'incantatore e scompare 1 ora dopo essere stato evocato.\n\nIl DM possiede le statistiche dell'elementale.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 6° livello o superiore, il grado di sfida aumenta di 1 per ogni livello dello slot superiore al 5°."
				}
			}
		};
	}
}
