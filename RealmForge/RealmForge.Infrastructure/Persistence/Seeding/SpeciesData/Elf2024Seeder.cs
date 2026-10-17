using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Elf2024Seeder
	{
		//	Deterministic GUIDs for 2024 SRD Elf aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000005");
		public static readonly Guid DrowSubspeciesId = Guid.Parse("20000000-0000-0000-0005-000000000001");
		public static readonly Guid HighElfSubspeciesId = Guid.Parse("20000000-0000-0000-0005-000000000002");
		public static readonly Guid WoodElfSubspeciesId = Guid.Parse("20000000-0000-0000-0005-000000000003");

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
				Ruleset = RulesetVersion.Dnd5e_2024,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Elfo",
						Description = "I primi elfi, creati dal dio Corellon, potevano cambiare forma a piacimento. Persero quel dono quando Corellon li maledisse per essersi schierati con Lolth, una divinità che tentò senza successo di usurparne il potere. Quando Lolth fu scagliata nell'Abisso, la maggior parte degli elfi la rinnegò e fu perdonata, ma il dono non fu mai restituito.\n\nNon più in grado di mutare forma, gli elfi si ritirarono nella Selva Fatata, dove l'influenza di quel piano rese ancora più profondo il loro dolore. Col tempo, la curiosità spinse molti di loro a esplorare altri piani, compresi i mondi del Piano Materiale.\n\nGli elfi hanno orecchie appuntite e sono privi di peli sul viso e sul corpo, e vivono circa 750 anni. Invece di dormire riposano in trance, restando consapevoli di ciò che li circonda mentre si perdono in ricordi e meditazioni. Nel corso di mille anni o più, la terra in cui abitano li trasforma lentamente e dona loro la propria magia: drow, elfi alti ed elfi dei boschi sono esempi di elfi trasformati in questo modo."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Elf",
						Description = "The first elves, created by the god Corellon, could change their shape at will. They lost that gift when Corellon cursed them for siding with Lolth, a deity who tried and failed to seize Corellon's power. When Lolth was cast into the Abyss, most elves turned away from her and were forgiven, but the gift was never returned.\n\nNo longer able to shapeshift, the elves withdrew to the Feywild, where the plane's influence deepened their grief. In time, curiosity drew many of them out again to explore other planes, including the worlds of the Material Plane.\n\nElves have pointed ears and no facial or body hair, and they live for around 750 years. Instead of sleeping, they rest in a trance, staying aware of their surroundings while lost in memory and meditation. Over a thousand years or more, the land they inhabit subtly reshapes them and grants them its own magic: drow, high elves, and wood elves are examples of elves transformed in this way."
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
								Name = "Scurovisione",
								Description = "Il personaggio ha scurovisione fino a un raggio di 18 metri."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision",
								Description = "You have Darkvision with a range of 60 feet."
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
								Name = "Retaggio fatato",
								Description = "Dispone di vantaggio ai tiri salvezza eseguiti per evitare o terminare la condizione affascinato su se stesso."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Fey Ancestry",
								Description = "You have Advantage on saving throws you make to avoid or end the Charmed condition."
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
								Name = "Sensi acuti",
								Description = "Ha competenza nelle abilità Intuizione, Percezione o Sopravvivenza."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Keen Senses",
								Description = "You have proficiency in the Insight, Perception, or Survival skill."
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
								Name = "Trance",
								Description = "Non ha bisogno di dormire e la magia non può farlo addormentare. Può completare un riposo lungo in 4 ore rimanendo in uno stato di trance meditativa, durante il quale resta cosciente."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Trance",
								Description = "You don't need to sleep, and magic can't put you to sleep. You can finish a Long Rest in 4 hours if you spend those hours in a trancelike meditation, during which you retain consciousness."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = DrowSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Drow",
								Description = "I drow vivono di solito nel Sottosuolo e ne sono stati plasmati. Alcuni drow, e persino intere società drow, evitano del tutto il Sottosuolo ma ne portano comunque la magia: nell'ambientazione di Eberron, ad esempio, i drow vivono nelle foreste pluviali e tra le rovine ciclopiche del continente di Xen'drik."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Drow",
								Description = "Drow usually live in the Underdark and have been shaped by it. Some drow, and even whole drow societies, avoid the Underdark entirely yet still carry its magic: in the Eberron setting, for example, drow live in the rainforests and colossal ruins of the continent of Xen'drik."
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
										Name = "Lignaggio Drow (1° Livello)",
										Description = "La portata di scurovisione aumenta fino a 36 metri. Inoltre, il personaggio conosce il trucchetto luci danzanti."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Drow Lineage (Level 1)",
										Description = "The range of your Darkvision increases to 120 feet. You also know the Dancing Lights cantrip."
									}
								}
							},
							new Trait
							{
								RequiredLevel = 3,
								Ruleset = RulesetVersion.Dnd5e_2024,
								IsOfficialSRD = true,
								Translations = new List<TraitTranslation>
								{
									new TraitTranslation
									{
										Language = LanguageCode.It,
										Name = "Magia Drow: Luminescenza (3° Livello)",
										Description = "Apprendi l'incantesimo Luminescenza. È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Drow Magic: Faerie Fire (Level 3)",
										Description = "You learn the Faerie Fire spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
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
										Name = "Magia Drow: Oscurità (5° Livello)",
										Description = "Apprendi l'incantesimo Oscurità. È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Drow Magic: Darkness (Level 5)",
										Description = "You learn the Darkness spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = HighElfSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Elfo Alto",
								Description = "Gli elfi alti portano in sé la magia dei luoghi in cui la Selva Fatata incontra il Piano Materiale. In alcuni mondi sono conosciuti con altri nomi: elfi del sole o elfi della luna nei Forgotten Realms, Silvanesti e Qualinesti in Dragonlance, e Aereni in Eberron."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "High Elf",
								Description = "High elves carry the magic of the places where the Feywild meets the Material Plane. On some worlds they go by other names: sun elves or moon elves in the Forgotten Realms, Silvanesti and Qualinesti in Dragonlance, and Aereni in Eberron."
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
										Name = "Lignaggio dell'Elfo Alto (1° Livello)",
										Description = "Il personaggio impara il trucchetto prestidigitazione. Ogni volta che completa un riposo lungo, può sostituirlo con un altro trucchetto dalla lista degli incantesimi del mago."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "High Elf Lineage (Level 1)",
										Description = "You know the Prestidigitation cantrip. Whenever you finish a Long Rest, you can replace that cantrip with a different cantrip from the Wizard spell list."
									}
								}
							},
							new Trait
							{
								RequiredLevel = 3,
								Ruleset = RulesetVersion.Dnd5e_2024,
								IsOfficialSRD = true,
								Translations = new List<TraitTranslation>
								{
									new TraitTranslation
									{
										Language = LanguageCode.It,
										Name = "Magia dell'Elfo Alto: Individuazione del Magico (3° Livello)",
										Description = "Apprendi l'incantesimo Individuazione del Magico. È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "High Elf Magic: Detect Magic (Level 3)",
										Description = "You learn the Detect Magic spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
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
										Name = "Magia dell'Elfo Alto: Passo Velato (5° Livello)",
										Description = "Apprendi l'incantesimo Passo Velato. È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "High Elf Magic: Misty Step (Level 5)",
										Description = "You learn the Misty Step spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = WoodElfSubspeciesId,
						BaseSpeedOverrideInFeet = 35,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Elfo dei Boschi",
								Description = "Gli elfi dei boschi custodiscono in sé la magia delle foreste primordiali. Sono chiamati anche elfi selvaggi, elfi verdi o elfi delle foreste. Sono elfi dei boschi gli schivi Grugach dell'ambientazione di Greyhawk, così come i Kagonesti di Dragonlance e i Tairnadal di Eberron."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Wood Elf",
								Description = "Wood elves hold the magic of primeval forests within them. They are also called wild elves, green elves, or forest elves. The reclusive Grugach of the Greyhawk setting are wood elves, as are the Kagonesti of Dragonlance and the Tairnadal of Eberron."
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
										Name = "Lignaggio dell'Elfo dei Boschi (1° Livello)",
										Description = "La velocità del personaggio aumenta a 10,5 metri (35 ft). Inoltre, conosce il trucchetto artificio druidico."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Wood Elf Lineage (Level 1)",
										Description = "Your Speed increases to 35 feet. You also know the Druidcraft cantrip."
									}
								}
							},
							new Trait
							{
								RequiredLevel = 3,
								Ruleset = RulesetVersion.Dnd5e_2024,
								IsOfficialSRD = true,
								Translations = new List<TraitTranslation>
								{
									new TraitTranslation
									{
										Language = LanguageCode.It,
										Name = "Magia dell'Elfo dei Boschi: Passo Veloce (3° Livello)",
										Description = "Apprendi l'incantesimo Passo Veloce (Longstrider). È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Wood Elf Magic: Longstrider (Level 3)",
										Description = "You learn the Longstrider spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
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
										Name = "Magia dell'Elfo dei Boschi: Passare Senza Tracce (5° Livello)",
										Description = "Apprendi l'incantesimo Passare Senza Tracce (Pass without Trace). È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Wood Elf Magic: Pass without Trace (Level 5)",
										Description = "You learn the Pass without Trace spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
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