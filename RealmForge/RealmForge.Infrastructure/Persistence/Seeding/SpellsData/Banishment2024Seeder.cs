using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Banishment (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Banishment2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "banishment");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Paladin, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "banishment", "en"),
					Language = LanguageCode.En,
					Name = "Banishment",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a pentacle",
					Description = "One creature that you can see within range must succeed on a Charisma saving throw or be transported to a harmless demiplane for the duration. While there, the target has the Incapacitated condition. When the spell ends, the target reappears in the space it left or in the nearest unoccupied space if that space is occupied.\n\nIf the target is an Aberration, a Celestial, an Elemental, a Fey, or a Fiend, the target doesn't return if the spell lasts for 1 minute. The target is instead transported to a random location on a plane (GM's choice) associated with its creature type.",
					HigherLevels = "You can target one additional creature for each spell slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "banishment", "it"),
					Language = LanguageCode.It,
					Name = "Esilio",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pentacolo",
					Description = "Una creatura entro gittata che l'incantatore è in grado di vedere deve superare un tiro salvezza su Carisma, altrimenti viene trasportata in un semipiano innocuo per la durata. Mentre si trova lì, il bersaglio è incapacitato. Quando l'incantesimo termina, il bersaglio ricompare nello spazio che aveva lasciato o, se quello spazio è occupato, nello spazio libero più vicino.\n\nSe il bersaglio è un'aberrazione, un celestiale, un elementale, un folletto o un immondo, non fa ritorno se l'incantesimo dura per 1 minuto. Il bersaglio viene invece trasportato in un luogo casuale di un piano (a scelta del DM) associato al suo tipo di creatura.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 4°."
				}
			}
		};
	}
}
