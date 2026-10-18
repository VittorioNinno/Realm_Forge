using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Passwall (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Passwall2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "passwall");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "passwall", "en"),
					Language = LanguageCode.En,
					Name = "Passwall",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "1 hour",
					MaterialComponent = "a pinch of sesame seeds",
					Description = "A passage appears at a point of your choice that you can see on a wooden, plaster, or stone surface (such as a wall, a ceiling, or a floor) within range, and lasts for the duration. You choose the opening's dimensions: up to 5 feet wide, 8 feet tall, and 20 feet deep. The passage creates no instability in a structure surrounding it.\n\nWhen the opening disappears, any creatures or objects still in the passage created by the spell are safely ejected to an unoccupied space nearest to the surface on which you cast the spell.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "passwall", "it"),
					Language = LanguageCode.It,
					Name = "Passapareti",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "1 ora",
					MaterialComponent = "un pizzico di semi di sesamo",
					Description = "Un passaggio compare in un punto a scelta dell'incantatore, che egli sia in grado di vedere, su una superficie di legno, di gesso o di pietra (come un muro, un soffitto o un pavimento) entro gittata, e dura per la durata. L'incantatore sceglie le dimensioni dell'apertura: fino a 1,5 metri di larghezza, 2,4 metri di altezza e 6 metri di profondità. Il passaggio non crea alcuna instabilità nella struttura circostante.\n\nQuando l'apertura scompare, tutte le creature o gli oggetti che si trovano ancora nel passaggio creato dall'incantesimo vengono espulsi senza danni nello spazio libero più vicino alla superficie su cui l'incantatore ha lanciato l'incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
