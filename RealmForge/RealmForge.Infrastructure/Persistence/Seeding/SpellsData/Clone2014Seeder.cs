using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Clone (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Clone2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "clone");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Necromancy,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "clone", "en"),
					Language = LanguageCode.En,
					Name = "Clone",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "a diamond worth at least 1,000 gp and at least 1 cubic inch of flesh of the creature that is to be cloned, which the spell consumes, and a vessel worth at least 2,000 gp that has a sealable lid and is large enough to hold a Medium creature, such as a huge urn, coffin, mud-filled cyst in the ground, or crystal container filled with salt water",
					Description = "This spell grows an inert duplicate of a living creature as a safeguard against death. This clone forms inside a sealed vessel and grows to full size and maturity after 120 days; you can also choose to have the clone be a younger version of the same creature. It remains inert and endures indefinitely, as long as its vessel remains undisturbed.\n\nAt any time after the clone matures, if the original creature dies, its soul transfers to the clone, provided that the soul is free and willing to return. The clone is physically identical to the original and has the same personality, memories, and abilities, but none of the original's equipment. The original creature's physical remains, if they still exist, become inert and can't thereafter be restored to life, since the creature's soul is elsewhere.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "clone", "it"),
					Language = LanguageCode.It,
					Name = "Clone",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "un diamante del valore di almeno 1.000 mo e almeno 2,5 centimetri cubi di carne della creatura da clonare, che l'incantesimo consuma, e un contenitore del valore di almeno 2.000 mo, dotato di un coperchio sigillabile e abbastanza grande da contenere una creatura di taglia Media, come un'enorme urna, una bara, una cisti piena di fango nel terreno o un contenitore di cristallo colmo di acqua salata",
					Description = "Questo incantesimo fa crescere un duplicato inerte di una creatura vivente, come salvaguardia contro la morte. Il clone si forma all'interno di un contenitore sigillato e raggiunge le dimensioni e la maturità piene dopo 120 giorni; l'incantatore può anche scegliere che il clone sia una versione più giovane della stessa creatura. Il clone rimane inerte e si conserva indefinitamente, purché il suo contenitore non venga disturbato.\n\nIn qualsiasi momento dopo che il clone è maturato, se la creatura originale muore, la sua anima si trasferisce nel clone, a condizione che sia libera e disposta a tornare. Il clone è fisicamente identico all'originale e ne possiede la personalità, i ricordi e le capacità, ma non l'equipaggiamento. I resti fisici della creatura originale, se esistono ancora, diventano inerti e non possono più essere riportati in vita, dato che l'anima della creatura si trova altrove.",
					HigherLevels = null
				}
			}
		};
	}
}
