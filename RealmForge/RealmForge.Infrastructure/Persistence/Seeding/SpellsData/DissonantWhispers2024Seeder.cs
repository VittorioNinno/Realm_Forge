using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dissonant Whispers (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DissonantWhispers2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dissonant-whispers");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dissonant-whispers", "en"),
					Language = LanguageCode.En,
					Name = "Dissonant Whispers",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "One creature of your choice that you can see within range hears a discordant melody in its mind. The target makes a Wisdom saving throw. On a failed save, it takes 3d6 Psychic damage and must immediately use its Reaction, if available, to move as far away from you as it can, using the safest route. On a successful save, the target takes half as much damage only.",
					HigherLevels = "The damage increases by 1d6 for each spell slot level above 1."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dissonant-whispers", "it"),
					Language = LanguageCode.It,
					Name = "Sussurri Dissonanti",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Una creatura a scelta dell'incantatore entro gittata, che egli è in grado di vedere, sente una melodia dissonante nella propria mente. Il bersaglio effettua un tiro salvezza su Saggezza. Se lo fallisce, subisce 3d6 danni psichici e deve usare immediatamente la propria reazione, se disponibile, per allontanarsi il più possibile dall'incantatore, seguendo il percorso più sicuro. Se lo supera, il bersaglio subisce soltanto la metà dei danni.",
					HigherLevels = "I danni aumentano di 1d6 per ogni livello dello slot incantesimo superiore al 1°."
				}
			}
		};
	}
}
