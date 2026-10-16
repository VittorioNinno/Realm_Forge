using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Halfling2014Seeder
	{
		//	Deterministic GUIDs for 2014 SRD Halfling aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000003");
		public static readonly Guid LightfootSubspeciesId = Guid.Parse("10000000-0000-0000-0002-000000000001");
		public static readonly Guid StoutSubspeciesId = Guid.Parse("10000000-0000-0000-0002-000000000002");

		///	<summary>
		///	Builds the canonical SRD definition of this species. Persistence is handled by SpeciesSeeder.
		///	</summary>
		public static Species Build()
		{
			return new Species
			{
				Id = SpeciesId,
				BaseSpeedInFeet = 25,
				CreatureType = CreatureType.Humanoid,
				AllowedSizes = new List<CreatureSize> { CreatureSize.Small },
				Ruleset = RulesetVersion.Dnd5e_2014,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Halfling",
						Description = "La maggior parte degli halfling non desidera altro che una casa accogliente: un luogo tranquillo lontano da mostri e guerre, con un focolare caldo, un buon pasto e una piacevole compagnia. Quelli che si mettono in viaggio portano con sé lo stesso allegro senso pratico."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Halfling",
						Description = "Most halflings want nothing more than a comfortable home: a quiet place far from monsters and wars, with a warm hearth, a good meal, and pleasant company. Those who do take to the road bring that same cheerful practicality with them."
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
								Name = "Fortunato",
								Description = "Quando ottiene 1 a un tiro per colpire, a una prova di caratteristica o a un tiro salvezza, un halfling può ripetere il tiro del dado e deve usare il nuovo risultato."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Lucky",
								Description = "When you roll a 1 on an attack roll, ability check, or saving throw, you can reroll the die and must use the new roll."
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
								Name = "Coraggioso",
								Description = "Un halfling dispone di vantaggio ai tiri salvezza per non essere spaventato."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Brave",
								Description = "You have advantage on saving throws against being frightened."
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
								Name = "Agilità Halfling",
								Description = "Un halfling può muoversi attraverso gli spazi di qualsiasi creatura più grande di lui."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Halfling Nimbleness",
								Description = "You can move through the space of any creature that is of a size larger than yours."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = LightfootSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Halfling Piedelesto",
								Description = "Gli halfling piedelesto sono cordiali e alla mano, ed esperti nel sottrarsi alla vista, persino nascondendosi dietro altre persone."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Lightfoot Halfling",
								Description = "Lightfoot halflings are friendly and easygoing, and are experts at slipping out of sight, even behind other people."
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
										Name = "Furtività Innata",
										Description = "Un halfling piedelesto può tentare di nascondersi anche se è oscurato solo da una singola creatura, purché questa sia più grande di lui di almeno una taglia."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Naturally Stealthy",
										Description = "You can attempt to hide even when you are obscured only by a creature that is at least one size larger than you."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = StoutSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Halfling Tozzo",
								Description = "Gli halfling tozzi sono più resistenti della maggior parte dei loro simili e sopportano veleni che abbatterebbero altri. C'è chi sostiene che nelle loro famiglie scorra sangue nanico."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Stout Halfling",
								Description = "Stout halflings are tougher than most of their kin and shrug off poisons that would fell others. Some claim there is dwarven blood in their families."
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
										Name = "Resilienza dei Tozzi",
										Description = "Il veleno fatica ad avere effetto sul personaggio: ha vantaggio ai tiri salvezza contro di esso e resistenza ai danni da veleno."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Stout Resilience",
										Description = "Poison has a hard time affecting you: you have advantage on saving throws against it and resistance to poison damage."
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