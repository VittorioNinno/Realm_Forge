using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Contingency (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Contingency2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "contingency");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Abjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "contingency", "en"),
					Language = LanguageCode.En,
					Name = "Contingency",
					CastingTime = "10 minutes",
					Range = "Self",
					Duration = "10 days",
					MaterialComponent = "a gem-encrusted statuette of yourself worth 1,500+ GP",
					Description = "Choose a spell of level 5 or lower that you can cast, that has a casting time of an action, and that can target you. You cast that spell—called the contingent spell—as part of casting *Contingency*, expending spell slots for both, but the contingent spell doesn't come into effect. Instead, it takes effect when a certain trigger occurs. You describe that trigger when you cast the two spells. For example, a *Contingency* cast with *Water Breathing* might stipulate that *Water Breathing* comes into effect when you are engulfed in water or a similar liquid.\n\nThe contingent spell takes effect immediately after the trigger occurs for the first time, whether or not you want it to, and then *Contingency* ends.\n\nThe contingent spell takes effect only on you, even if it can normally target others. You can use only one *Contingency* spell at a time. If you cast this spell again, the effect of another *Contingency* spell on you ends. Also, *Contingency* ends on you if its material component is ever not on your person.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "contingency", "it"),
					Language = LanguageCode.It,
					Name = "Contingenza",
					CastingTime = "10 minuti",
					Range = "Incantatore",
					Duration = "10 giorni",
					MaterialComponent = "una statuetta incrostata di gemme raffigurante l'incantatore, del valore di almeno 1.500 mo",
					Description = "L'incantatore sceglie un incantesimo di 5° livello o inferiore che è in grado di lanciare, con un tempo di lancio di un'azione e che può prendere lui stesso come bersaglio. Lancia quell'incantesimo (detto incantesimo contingente) come parte del lancio di *contingenza*, spendendo gli slot incantesimo per entrambi, ma l'incantesimo contingente non ha effetto subito. Ha invece effetto quando si verifica un certo innesco, che l'incantatore descrive quando lancia i due incantesimi. Per esempio, una *contingenza* lanciata con *respirare sott'acqua* potrebbe stabilire che *respirare sott'acqua* abbia effetto quando l'incantatore viene sommerso dall'acqua o da un liquido simile.\n\nL'incantesimo contingente ha effetto subito dopo che l'innesco si verifica per la prima volta, che l'incantatore lo desideri o meno, dopodiché *contingenza* termina.\n\nL'incantesimo contingente ha effetto soltanto sull'incantatore, anche se normalmente può prendere altri come bersaglio. L'incantatore può usare un solo incantesimo *contingenza* alla volta. Se lancia di nuovo questo incantesimo, l'effetto di un'altra *contingenza* su di lui termina. Inoltre, *contingenza* termina se in qualsiasi momento la sua componente materiale non si trova addosso all'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
