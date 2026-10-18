using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Stone Shape (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class StoneShape2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "stone-shape");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "stone-shape", "en"),
					Language = LanguageCode.En,
					Name = "Stone Shape",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "soft clay, to be crudely worked into the desired shape for the stone object",
					Description = "You touch a stone object of Medium size or smaller or a section of stone no more than 5 feet in any dimension and form it into any shape that suits your purpose. So, for example, you could shape a large rock into a weapon, idol, or coffer, or make a small passage through a wall, as long as the wall is less than 5 feet thick. You could also shape a stone door or its frame to seal the door shut. The object you create can have up to two hinges and a latch, but finer mechanical detail isn't possible.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "stone-shape", "it"),
					Language = LanguageCode.It,
					Name = "Scolpire Pietra",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "argilla morbida, da modellare grossolanamente nella forma desiderata per l'oggetto di pietra",
					Description = "L'incantatore tocca un oggetto di pietra di taglia Media o inferiore, oppure una sezione di pietra le cui dimensioni non superano 1,5 metri in ogni direzione, e le dà la forma che più si addice ai suoi scopi. Per esempio, potrebbe modellare un grosso masso in un'arma, un idolo o un forziere, oppure aprire un piccolo passaggio in un muro, purché il muro sia spesso meno di 1,5 metri. Potrebbe anche modellare una porta di pietra o il suo telaio per sigillare la porta. L'oggetto creato può avere fino a due cardini e un chiavistello, ma non sono possibili dettagli meccanici più fini.",
					HigherLevels = null
				}
			}
		};
	}
}
