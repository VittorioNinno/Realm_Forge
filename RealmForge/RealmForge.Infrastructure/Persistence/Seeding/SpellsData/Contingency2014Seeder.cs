using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Contingency (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Contingency2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "contingency");

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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "contingency", "en"),
					Language = LanguageCode.En,
					Name = "Contingency",
					CastingTime = "10 minutes",
					Range = "Self",
					Duration = "10 days",
					MaterialComponent = "a statuette of yourself carved from ivory and decorated with gems worth at least 1,500 gp",
					Description = "Choose a spell of 5th level or lower that you can cast, that has a casting time of 1 action, and that can target you. You cast that spell—called the contingent spell—as part of casting contingency, expending spell slots for both, but the contingent spell doesn't come into effect. Instead, it takes effect when a certain circumstance occurs. You describe that circumstance when you cast the two spells. For example, a contingency cast with water breathing might stipulate that water breathing comes into effect when you are engulfed in water or a similar liquid.\n\nThe contingent spell takes effect immediately after the circumstance is met for the first time, whether or not you want it to, and then contingency ends.\n\nThe contingent spell takes effect only on you, even if it can normally target others. You can use only one contingency spell at a time. If you cast this spell again, the effect of another contingency spell on you ends. Also, contingency ends on you if its material component is ever not on your person.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "contingency", "it"),
					Language = LanguageCode.It,
					Name = "Contingenza",
					CastingTime = "10 minuti",
					Range = "Incantatore",
					Duration = "10 giorni",
					MaterialComponent = "una statuetta dell'incantatore scolpita nell'avorio e decorata con gemme, del valore di almeno 1.500 mo",
					Description = "L'incantatore sceglie un incantesimo di 5° livello o inferiore che è in grado di lanciare, che ha un tempo di lancio di 1 azione e che può bersagliarlo. Lancia quell'incantesimo, detto incantesimo contingente, come parte del lancio di contingenza, spendendo gli slot incantesimo per entrambi; l'incantesimo contingente però non ha effetto subito, ma solo quando si verifica una determinata circostanza. L'incantatore descrive tale circostanza quando lancia i due incantesimi. Per esempio, una contingenza lanciata con respirare sott'acqua potrebbe stabilire che respirare sott'acqua abbia effetto quando l'incantatore viene sommerso dall'acqua o da un liquido simile.\n\nL'incantesimo contingente ha effetto immediatamente dopo che la circostanza si verifica per la prima volta, che l'incantatore lo voglia o meno, dopodiché contingenza termina.\n\nL'incantesimo contingente ha effetto solo sull'incantatore, anche se normalmente può bersagliare altre creature. L'incantatore può usare un solo incantesimo contingenza alla volta. Se lancia di nuovo questo incantesimo, l'effetto di un'altra contingenza su di lui termina. Inoltre, contingenza termina se in qualsiasi momento la sua componente materiale non si trova sulla persona dell'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
