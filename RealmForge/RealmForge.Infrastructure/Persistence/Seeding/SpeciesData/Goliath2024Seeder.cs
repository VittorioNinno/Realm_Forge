using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Goliath2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Goliath aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000007");

		private record GiantLineageConfig(
			Guid Id,
			string SubspeciesNameIt,
			string SubspeciesNameEn,
			string TraitNameIt,
			string TraitNameEn,
			string TraitDescIt,
			string TraitDescEn
		);

		private static readonly GiantLineageConfig[] Lineages = new[]
		{
			new GiantLineageConfig(
				Guid.Parse("20000000-0000-0000-0007-000000000001"),
				"Gigante delle Nuvole",
				"Cloud Giant",
				"Salta-nuvole",
				"Cloud's Jaunt",
				"Come azione bonus, il personaggio può teletrasportarsi magicamente fino a un massimo di 9 metri in uno spazio non occupato che sia in grado di vedere. Può utilizzare questo beneficio un numero di volte pari al suo bonus di competenza, recuperando tutti gli utilizzi spesi al termine di un riposo lungo.",
				"As a Bonus Action, you magically teleport up to 30 feet to an unoccupied space you can see. You can use this benefit a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Long Rest."
			),
			new GiantLineageConfig(
				Guid.Parse("20000000-0000-0000-0007-000000000002"),
				"Gigante del Fuoco",
				"Fire Giant",
				"Fuoco bruciante",
				"Fire's Burn",
				"Quando colpisce un bersaglio con un tiro per colpire e gli infligge dei danni, può anche infliggergli 1d10 danni da fuoco extra. Può utilizzare questo beneficio un numero di volte pari al suo bonus di competenza, recuperando tutti gli utilizzi spesi al termine di un riposo lungo.",
				"When you hit a target with an attack roll and deal damage to it, you can also deal 1d10 Fire damage to that target. You can use this benefit a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Long Rest."
			),
			new GiantLineageConfig(
				Guid.Parse("20000000-0000-0000-0007-000000000003"),
				"Gigante del Gelo",
				"Frost Giant",
				"Brivido gelante",
				"Frost's Chill",
				"Quando colpisce un bersaglio con un tiro per colpire e gli infligge dei danni, può anche infliggere 1d6 danni da freddo e ridurre la velocità del bersaglio di 3 metri fino all'inizio del proprio turno successivo. Può utilizzare questo beneficio un numero di volte pari al suo bonus di competenza, recuperando tutti gli utilizzi spesi al termine di un riposo lungo.",
				"When you hit a target with an attack roll and deal damage to it, you can also deal 1d6 Cold damage to that target and reduce its Speed by 10 feet until the start of your next turn. You can use this benefit a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Long Rest."
			),
			new GiantLineageConfig(
				Guid.Parse("20000000-0000-0000-0007-000000000004"),
				"Gigante delle Colline",
				"Hill Giant",
				"Forza della collina",
				"Hill's Tumble",
				"Quando colpisce una creatura di taglia Grande o inferiore con un tiro per colpire e le infligge dei danni, può far cadere prona la creatura colpita. Può utilizzare questo beneficio un numero di volte pari al suo bonus di competenza, recuperando tutti gli utilizzi spesi al termine di un riposo lungo.",
				"When you hit a Large or smaller creature with an attack roll and deal damage to it, you can give that target the Prone condition. You can use this benefit a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Long Rest."
			),
			new GiantLineageConfig(
				Guid.Parse("20000000-0000-0000-0007-000000000005"),
				"Gigante delle Pietre",
				"Stone Giant",
				"Resistenza della pietra",
				"Stone's Endurance",
				"Quando subisce danni, può usare una reazione per tirare 1d12. Aggiunge il suo modificatore di Costituzione al totale e riduce il danno subito di tale ammontare. Può utilizzare questo beneficio un numero di volte pari al suo bonus di competenza, recuperando tutti gli utilizzi spesi al termine di un riposo lungo.",
				"When you take damage, you can take a Reaction to roll 1d12. Add your Constitution modifier to the number rolled and reduce the damage by that total. You can use this benefit a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Long Rest."
			),
			new GiantLineageConfig(
				Guid.Parse("20000000-0000-0000-0007-000000000006"),
				"Gigante delle Tempeste",
				"Storm Giant",
				"Tuono tempestoso",
				"Storm's Thunder",
				"Quando subisce danni da una creatura entro 18 metri da sé, può usare una reazione per infliggere 1d8 danni da tuono a tale creatura. Può utilizzare questo beneficio un numero di volte pari al suo bonus di competenza, recuperando tutti gli utilizzi spesi al termine di un riposo lungo.",
				"When you take damage from a creature within 60 feet of you, you can take a Reaction to deal 1d8 Thunder damage to that creature. You can use this benefit a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Long Rest."
			)
		};

		///	<summary>
		///	Builds the canonical SRD definition of this species. Persistence is handled by SpeciesSeeder.
		///	</summary>
		public static Species Build()
		{
			return new Species
			{
				Id = SpeciesId,
				BaseSpeedInFeet = 35,
				CreatureType = CreatureType.Humanoid,
				AllowedSizes = new List<CreatureSize> { CreatureSize.Medium },
				Ruleset = RulesetVersion.Dnd5e_2024,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Goliath",
						Description = "I goliath superano in altezza la maggior parte delle persone e il loro sangue porta l'eredità degli antichi giganti. Quell'eredità si manifesta in doni soprannaturali, tra cui la capacità di crescere per breve tempo fino ad avvicinarsi alla statura dei loro imponenti antenati.\n\nI tratti di un goliath ricordano spesso un particolare tipo di gigante, come quelli delle pietre, del gelo o del fuoco. Liberi dalle faide che da sempre dividono i giganti, i goliath seguono una propria strada e aspirano a salire più in alto di quanto abbiano mai fatto i loro avi."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Goliath",
						Description = "Goliaths stand head and shoulders above most people, and their blood carries the legacy of the ancient giants. That inheritance shows in supernatural gifts, including the power to swell briefly toward the size of their towering ancestors.\n\nA goliath's features often echo a particular kind of giant, resembling stone, frost, or fire giants. Free of the feuds that have long divided giantkind, goliaths follow their own path and strive to climb higher than their forebears ever did."
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
								Name = "Costituzione robusta",
								Description = "Ha vantaggio alle prove di caratteristica effettuate per terminare la condizione afferrato su se stesso. Inoltre, la capacità di trasporto del personaggio è quella di una creatura di taglia superiore."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Powerful Build",
								Description = "You have Advantage on any ability check you make to end the Grappled condition. You also count as one size larger when determining your carrying capacity."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 5,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Forma grande",
								Description = "A partire dal 5° livello, come azione bonus può diventare di taglia Grande se si trova in uno spazio abbastanza ampio. La trasformazione dura per 10 minuti o finché non la interrompe (nessuna azione richiesta). Per tutta la sua durata, ottiene vantaggio alle prove di Forza e la sua velocità aumenta di 3 metri. Dopo aver utilizzato questo tratto, il personaggio non può riutilizzarlo prima di aver completato un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Large Form",
								Description = "Starting at character level 5, you can change your size to Large as a Bonus Action if you're in a big enough space. This transformation lasts for 10 minutes or until you end it (no action required). For that duration, you have Advantage on Strength checks, and your Speed increases by 10 feet. Once you use this trait, you can't use it again until you finish a Long Rest."
							}
						}
					}
				},
				Subspecies = Lineages.Select(lin => new Subspecies
				{
					Id = lin.Id,
					Ruleset = RulesetVersion.Dnd5e_2024,
					IsOfficialSRD = true,
					Translations = new List<SubspeciesTranslation>
					{
						new SubspeciesTranslation
						{
							Language = LanguageCode.It,
							Name = lin.SubspeciesNameIt,
							Description = $"Discendenza legata alla stirpe del {lin.SubspeciesNameIt}. Concede il dono soprannaturale '{lin.TraitNameIt}'."
						},
						new SubspeciesTranslation
						{
							Language = LanguageCode.En,
							Name = lin.SubspeciesNameEn,
							Description = $"Lineage descending from {lin.SubspeciesNameEn} ancestors. Grants the supernatural boon '{lin.TraitNameEn}'."
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
									Name = lin.TraitNameIt,
									Description = lin.TraitDescIt
								},
								new TraitTranslation
								{
									Language = LanguageCode.En,
									Name = lin.TraitNameEn,
									Description = lin.TraitDescEn
								}
							}
						}
					}
				}).ToList()
			};
		}
	}
}