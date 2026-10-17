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
						Description = "Gli umani si trovano in tutto il multiverso e sono tanto vari quanto numerosi. Sapendo di avere poco tempo, cercano di realizzare quanto più possibile, e la loro ambizione e il loro ingegno suscitano ammirazione, rispetto e talvolta timore.\n\nGli umani hanno aspetti diversi quanto i popoli della Terra e venerano molti dei. Gli studiosi discutono ancora su dove abbia avuto origine l'umanità, ma si dice che una delle prime comunità umane conosciute sia nata a Sigil, la città a forma di toro al centro del multiverso in cui è nata la lingua Comune. Da lì gli umani si sarebbero sparsi ovunque, portando con sé lo spirito cosmopolita della Città delle Porte."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Human",
						Description = "Humans are found throughout the multiverse and are as varied as they are numerous. Knowing their time is short, they try to accomplish as much as they can, and their ambition and ingenuity earn them admiration, respect, and sometimes fear.\n\nHumans differ in appearance as widely as the people of Earth, and they worship many gods. Scholars still argue about where humanity began, but one of the earliest known human communities is said to have formed in Sigil, the torus-shaped city at the center of the multiverse where the Common language was born. From there humans may have spread everywhere, carrying the cosmopolitan spirit of the City of Doors with them."
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