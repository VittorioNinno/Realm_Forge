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
						Description = "I racconti elfici narrano che un tempo il loro popolo potesse cambiare forma a piacimento, finché un tradimento divino non gli costò per sempre quel dono. Nel dolore, molti si ritirarono nel regno fatato; col tempo, la curiosità li spinse di nuovo a vagare per altri piani e mondi.\n\nGli elfi hanno orecchie appuntite e sono privi di peli sul viso e sul corpo, e vivono circa 750 anni. Invece di dormire riposano in trance, restando consapevoli di ciò che li circonda mentre si perdono in ricordi e meditazioni. Nel corso di mille anni o più, la terra in cui abitano li trasforma lentamente e dona loro la propria magia: drow, elfi alti ed elfi dei boschi ne sono gli esempi più noti."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Elf",
						Description = "Elven tales say their people were once able to change shape at will, until a divine betrayal cost them that gift forever. Grieving, many withdrew to the realm of the fey; in time, curiosity drew them out again to wander other planes and worlds.\n\nElves have pointed ears and no facial or body hair, and they live for around 750 years. Instead of sleeping, they rest in a trance, staying aware of their surroundings while lost in memory and meditation. Over a thousand years or more, the land they inhabit subtly reshapes them and grants them its own magic: drow, high elves, and wood elves are the best-known results."
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
								Description = "I drow sono stati plasmati dalle caverne senza luce che si estendono sotto la superficie. Alcuni di loro non hanno mai vissuto sottoterra, ma portano comunque nel sangue la magia delle profondità."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Drow",
								Description = "Drow have been shaped by the lightless caverns deep beneath the surface. Some of them have never lived underground, yet still carry the magic of the depths in their blood."
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
								Description = "Gli elfi alti portano in sé la magia dei luoghi in cui il regno fatato tocca il mondo mortale. Terre diverse li conoscono con nomi diversi, spesso legati al sole, alla luna o ai loro antichi regni."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "High Elf",
								Description = "High elves carry the magic of places where the realm of the fey touches the mortal world. Different lands know them by different names, often linked to the sun, the moon, or their ancient kingdoms."
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
								Description = "Gli elfi dei boschi custodiscono in sé la magia delle foreste antiche. Sono conosciuti con molti nomi, come elfi selvaggi o elfi verdi, e molti vivono lontano dalle città, nel cuore dei boschi."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Wood Elf",
								Description = "Wood elves hold the magic of ancient forests within them. They go by many names, such as wild elves or green elves, and many live far from cities, in deep woodland."
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