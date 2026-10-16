using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Human2014Seeder
	{
		//	Deterministic GUIDs for 2014 SRD Human aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000001");
		public static readonly Guid StandardHumanSubspeciesId = Guid.Parse("10000000-0000-0000-0003-000000000001");
		public static readonly Guid VariantHumanSubspeciesId = Guid.Parse("10000000-0000-0000-0003-000000000002");

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
						Name = "Umano",
						Description = "Gli umani sono il più adattabile e intraprendente tra i popoli comuni. Usanze, credenze e ambizioni variano enormemente da una terra all'altra, e nel corso di una vita relativamente breve fondano città e regni destinati a durare per generazioni."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Human",
						Description = "Humans are the most adaptable and driven of the common peoples. Their customs, beliefs, and ambitions vary enormously from land to land, and in their relatively short lives they found cities and kingdoms meant to endure for generations."
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
								Name = "Linguaggi",
								Description = "Gli umani parlano, leggono e scrivono in Comune e in un linguaggio extra a scelta. Amano impreziosire la parlata con parole prese da altre lingue, imprecazioni o espressioni melodiche."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Languages",
								Description = "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the languages of other peoples they deal with."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = StandardHumanSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Umano Standard",
								Description = "Il tipo di umano più comune, capace un po' in tutto e determinato a riuscire in ogni campo."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Standard Human",
								Description = "The most common kind of human, capable of a little of everything and driven to succeed in every field."
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
										Name = "Incremento dei Punteggi di Caratteristica",
										Description = "Ciascuno dei sei punteggi di caratteristica aumenta di 1."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Ability Score Increase",
										Description = "Your ability scores each increase by 1."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = VariantHumanSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Umano Variante",
								Description = "Una versione opzionale dell'umano per i gruppi che usano i talenti: meno aumenti di caratteristica in cambio di un'abilità e di un talento che definiscono la specialità del personaggio."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Variant Human",
								Description = "An optional version of the human for groups that use feats: fewer ability increases in exchange for a skill and a feat that define the character's specialty."
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
										Name = "Incremento di Caratteristica Variante",
										Description = "Il personaggio sceglie due punteggi di caratteristica diversi: ciascuno aumenta di 1."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Ability Score Increase (Variant)",
										Description = "Choose two different ability scores: each increases by 1."
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
										Name = "Abilità",
										Description = "Il personaggio ottiene competenza in un'abilità a sua scelta."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Skills",
										Description = "You become proficient in one skill of your choice."
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
										Name = "Talento",
										Description = "Il personaggio inizia con un talento a sua scelta."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Feat",
										Description = "You start with one feat of your choice."
									}
								}
							}
						}
					}
				}
			};
		}
	}
}