using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Dwarf2014Seeder
	{
		//	Deterministic GUIDs for 2014 SRD Dwarf aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000009");
		public static readonly Guid HillDwarfSubspeciesId = Guid.Parse("10000000-0000-0000-0009-000000000001");
		public static readonly Guid MountainDwarfSubspeciesId = Guid.Parse("10000000-0000-0000-0009-000000000002");

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
				AllowedSizes = new List<CreatureSize> { CreatureSize.Medium },
				Ruleset = RulesetVersion.Dnd5e_2014,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Nano",
						Description = "I nani sono un popolo robusto e tenace che scava sale e città nel cuore delle montagne. Fedeli al clan e alla tradizione, orgogliosi del proprio lavoro e lenti a dimenticare un torto, possono vivere per secoli e affrontano le avversità con una pazienza incrollabile."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Dwarf",
						Description = "Dwarves are a stout, enduring people who carve halls and cities deep into the mountains. Loyal to clan and tradition, proud of their craft, and slow to forget a wrong, they can live for centuries and face hardship with unshakable patience."
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
								Description = "Abituato a vivere sottoterra, un nano beneficia di una vista superiore nell'oscurità e nella luce fioca fino a 18 metri (penombra come luce intensa e oscurità come luce fioca)."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision (60 ft.)",
								Description = "Accustomed to life underground, you have superior vision in dark and dim conditions up to 60 feet (see in dim light as bright light, and darkness as dim light)."
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
								Name = "Resilienza Nanica",
								Description = "Un nano dispone di vantaggio ai tiri salvezza contro il veleno e di resistenza ai danni da veleno."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Dwarven Resilience",
								Description = "You have advantage on saving throws against poison, and you have resistance against poison damage."
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
								Name = "Addestramento da Combattimento Nanico",
								Description = "Un nano ha competenza nelle asce, nelle asce da battaglia, nei martelli da guerra e nei martelli leggeri."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Dwarven Combat Training",
								Description = "You have proficiency with the battleaxe, handaxe, light hammer, and warhammer."
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
								Name = "Competenza negli Strumenti",
								Description = "Un nano ottiene competenza in un set di strumenti da artigiano a scelta tra: strumenti da fabbro, scorte da mescitore o strumenti da costruttore."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Tool Proficiency",
								Description = "You gain proficiency with the artisan's tools of your choice: smith's tools, brewer's supplies, or mason's tools."
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
								Name = "Esperto Minatore",
								Description = "Ogni volta che effettua una prova di Intelligenza (Storia) relativa all'origine di una struttura in pietra, aggiunge il doppio del proprio bonus di competenza alla prova anziché il normale bonus."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Stonecunning",
								Description = "Whenever you make an Intelligence (History) check related to the origin of stonework, you add double your proficiency bonus to the check, instead of your normal proficiency bonus."
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
								Name = "Passo Saldo",
								Description = "La velocità base sul terreno di un nano è di 7,5 metri (25 ft) e non viene ridotta se indossa un'armatura pesante."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Steady Footing",
								Description = "Your base walking speed is 25 feet and is not reduced by wearing heavy armor."
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
								Description = "Un nano sa parlare, leggere e scrivere in Comune e in Nanico. Il Nanico è ricco di aspre consonanti e inflessioni gutturali."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Languages",
								Description = "You can speak, read, and write Common and Dwarvish. Dwarvish is full of hard consonants and guttural sounds."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = HillDwarfSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Nano delle Colline",
								Description = "I nani delle colline sono noti per i sensi acuti, l'intuito profondo e una notevole tempra fisica e mentale."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Hill Dwarf",
								Description = "Hill dwarves are known for sharp senses, deep intuition, and remarkable toughness of body and mind."
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
										Name = "Robustezza Nanica",
										Description = "Il massimo dei punti ferita aumenta di 1, e aumenta di nuovo di 1 ogni volta che acquisisci un livello."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Dwarven Toughness",
										Description = "Your hit point maximum increases by 1, and it increases by 1 every time you gain a level."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = MountainDwarfSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Nano delle Montagne",
								Description = "I nani delle montagne sono forti e resistenti, temprati da una vita difficile tra le alte vette, e sono abituati a combattere in armatura."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Mountain Dwarf",
								Description = "Mountain dwarves are strong and hardy, shaped by a demanding life among high peaks, and are used to fighting in armor."
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
										Name = "Addestramento nelle Armature Naniche",
										Description = "Il personaggio ha competenza nelle armature leggere e medie."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Dwarven Armor Training",
										Description = "You are proficient with light and medium armor."
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