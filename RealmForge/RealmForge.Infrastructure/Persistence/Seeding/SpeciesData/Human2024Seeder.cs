using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Human2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Human aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000001");

		///	<summary>
		///	Builds the canonical SRD definition of this species. Persistence is handled by SpeciesSeeder.
		///	</summary>
		public static Species Build()
		{
			return new Species
			{
				Id = SpeciesId,
				BaseSpeedInFeet = 30,
				CreatureType = CreatureType.Humanoid,
				AllowedSizes = new List<CreatureSize> { CreatureSize.Medium, CreatureSize.Small },
				Ruleset = RulesetVersion.Dnd5e_2024,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Umano",
						Description = "Gli umani si trovano quasi ovunque e sono tanto vari quanto numerosi. Sapendo di avere poco tempo, cercano di realizzare quanto più possibile, e la loro ambizione e il loro ingegno suscitano ammirazione, rispetto e talvolta timore.\n\nGli umani hanno aspetti molto diversi tra loro e venerano molti dei. Gli studiosi discutono ancora su dove abbia avuto origine l'umanità; una teoria diffusa la colloca in una grande città al crocevia dei piani, da cui gli umani si sarebbero sparsi per i mondi portando con sé uno spirito cosmopolita e la lingua Comune."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Human",
						Description = "Humans are found almost everywhere and are as varied as they are numerous. Knowing their time is short, they try to accomplish as much as they can, and their ambition and ingenuity earn them admiration, respect, and sometimes fear.\n\nHumans differ widely in appearance and worship many gods. Scholars still argue about where humanity began; one popular theory places its origin in a great city at the crossroads of the planes, from which humans spread across the worlds carrying a cosmopolitan spirit and the Common tongue."
					}
				},
				Traits = new List<Trait>
				{
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Intraprendente",
								Description = "Ottiene Ispirazione eroica ogni volta che completa un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Resourceful",
								Description = "You gain Heroic Inspiration whenever you finish a Long Rest."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Pluriabilità",
								Description = "Acquisisce competenze in un'abilità a tua scelta."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Skillful",
								Description = "You gain proficiency in one skill of your choice."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Versatile",
								Description = "Ottiene un talento delle origini a tua scelta (vedi capitolo 5). È consigliato il talento Abile."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Versatile",
								Description = "You gain an Origin feat of your choice (see chapter 5). Skilled is recommended."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};
		}
	}
}