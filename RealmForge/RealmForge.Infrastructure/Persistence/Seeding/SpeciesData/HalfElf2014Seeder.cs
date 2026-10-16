using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class HalfElf2014Seeder
	{
		//	Deterministic GUID for 2014 SRD Half-Elf aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000006");

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
				AllowedSizes = new List<CreatureSize> { CreatureSize.Medium },
				Ruleset = RulesetVersion.Dnd5e_2014,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Mezzelfo",
						Description = "I mezzelfi crescono tra due popoli senza appartenere del tutto a nessuno dei due. Molti uniscono l'intraprendenza e la curiosità umane ai sensi acuti, all'amore per la natura e al gusto per la bellezza degli elfi, e spesso diventano abili nel fare da ponte tra i mondi a cui appartengono."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Half-Elf",
						Description = "Half-elves grow up between two peoples without fully belonging to either. Many combine a human's drive and curiosity with an elf's keen senses, love of nature, and eye for beauty, and they often become skilled at bridging the worlds they straddle."
					}
				},
				Traits = new List<Trait>
				{
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Scurovisione (18 m)",
								Description = "Grazie al suo sangue elfico, un mezzelfo beneficia di una vista superiore nell'oscurità e nelle condizioni di luce fioca fino a 18 metri (luce intensa nella penombra e luce fioca nel buio)."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision (60 ft.)",
								Description = "Thanks to your elf blood, you have superior vision in dark and dim conditions up to 60 feet (see in dim light as bright light, and darkness as dim light)."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Retaggio Fatato",
								Description = "Un mezzelfo dispone di vantaggio ai tiri salvezza per non essere affascinato e non può essere addormentato tramite la magia."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Fey Ancestry",
								Description = "You have advantage on saving throws against being charmed, and magic can't put you to sleep."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Versatilità nelle Abilità",
								Description = "Un mezzelfo ha competenza in due abilità a sua scelta."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Skill Versatility",
								Description = "You gain proficiency in two skills of your choice."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Linguaggi",
								Description = "Un mezzelfo può parlare, leggere e scrivere in Comune, in Elfico e in un linguaggio extra a sua scelta."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Languages",
								Description = "You can speak, read, and write Common, Elvish, and one extra language of your choice."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};
		}
	}
}