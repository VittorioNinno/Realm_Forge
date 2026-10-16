using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Elf2014Seeder
	{
		//	Deterministic GUIDs for 2014 SRD Elf aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000002");
		public static readonly Guid HighElfSubspeciesId = Guid.Parse("10000000-0000-0000-0001-000000000001");
		public static readonly Guid WoodElfSubspeciesId = Guid.Parse("10000000-0000-0000-0001-000000000002");
		public static readonly Guid DarkElfSubspeciesId = Guid.Parse("10000000-0000-0000-0001-000000000003");

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
						Name = "Elfo",
						Description = "Gli elfi sono un popolo aggraziato e longevo, toccato dalla magia, che sembra appartenere solo in parte al mondo che lo circonda. Vivono in luoghi di quieta bellezza, dalle foreste antiche alle sottili torri di pietra chiara."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Elf",
						Description = "Elves are a graceful, long-lived people touched by magic, who seem to belong only partly to the world around them. They make their homes in places of quiet beauty, from ancient forests to slender towers of pale stone."
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
								Description = "Abituato a muoversi nella penombra e alla luna, l'elfo vede nell'oscurità e nella luce fioca fino a 18 metri."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision (60 ft.)",
								Description = "Accustomed to twilit forests and the night sky, you have superior vision in dark and dim conditions up to 60 feet."
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
								Name = "Sensi Acuti",
								Description = "L'elfo ottiene competenza nell'abilità Percezione."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Keen Senses",
								Description = "You have proficiency in the Perception skill."
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
								Description = "Vantaggio ai tiri salvezza per non essere affascinato e la magia non può addormentarti."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Fey Ancestry",
								Description = "You have advantage on saving throws against being charmed, and magic cannot put you to sleep."
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
								Name = "Trance",
								Description = "Non hai bisogno di dormire; mediti per 4 ore al giorno ottenendo gli stessi benefici di 8 ore di sonno."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Trance",
								Description = "Elves meditate deeply for 4 hours a day instead of sleeping."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = HighElfSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Elfo Alto",
								Description = "Gli elfi alti hanno una mente pronta e almeno una conoscenza di base della magia arcana."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "High Elf",
								Description = "High elves have a quick mind and at least a basic command of arcane magic."
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
										Name = "Addestramento nelle Armi Elfiche",
										Description = "Competenza nelle spade corte, spade lunghe, archi corti e archi lunghi."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Elf Weapon Training",
										Description = "Proficiency with the longsword, shortsword, shortbow, and longbow."
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
										Name = "Trucchetto",
										Description = "Conosce un trucchetto a scelta dalla lista degli incantesimi da mago."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Cantrip",
										Description = "You know one cantrip of your choice from the wizard spell list."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = WoodElfSubspeciesId,
						BaseSpeedOverrideInFeet = 35,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Elfo dei Boschi",
								Description = "Gli elfi dei boschi hanno sensi acuti e passi rapidi e silenziosi, e si muovono nelle loro foreste quasi senza essere visti."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Wood Elf",
								Description = "Wood elves have sharp senses and quick, silent feet, and move through their forest homes almost unseen."
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
										Name = "Piede Lesto (10,5 m)",
										Description = "La velocità base sul terreno del personaggio è di 10,5 metri."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Fleet of Foot (35 ft.)",
										Description = "Your base walking speed is 35 feet."
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
										Name = "Maschera della Selva",
										Description = "Il personaggio può tentare di nascondersi anche quando è solo leggermente oscurato da fenomeni naturali come fogliame, pioggia battente, neve che cade o nebbia."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Mask of the Wild",
										Description = "You can try to hide when you are only lightly obscured by natural phenomena such as foliage, heavy rain, falling snow, or mist."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = DarkElfSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Elfo Oscuro (Drow)",
								Description = "I drow sono elfi i cui antenati furono banditi nel Sottosuolo. La vita in quelle profondità ha affinato la loro vista nell'oscurità e ha donato loro una magia innata."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Dark Elf (Drow)",
								Description = "Drow are elves whose ancestors were banished to the Underdark. Life in those depths has sharpened their sight in darkness and given them innate magic."
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
										Name = "Scurovisione Superiore (36 m)",
										Description = "La scurovisione del personaggio arriva fino a 36 metri invece che a 18."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Superior Darkvision (120 ft.)",
										Description = "Your darkvision reaches out to 120 feet instead of 60."
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
										Name = "Sensibilità alla Luce del精度",
										Description = "Mentre il personaggio, o ciò che cerca di vedere o di attaccare, si trova alla luce diretta del sole, ha svantaggio ai tiri per colpire e alle prove di Saggezza (Percezione) basate sulla vista."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Sunlight Sensitivity",
										Description = "While you or what you are trying to see or attack is in direct sunlight, you have disadvantage on attack rolls and on Wisdom (Perception) checks that rely on sight."
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
										Name = "Magia Drow",
										Description = "Il personaggio conosce il trucchetto Luci Danzanti. Dal 3° livello può lanciare anche Luminescenza, e dal 5° livello Oscurità; ciascuno di questi due incantesimi può essere lanciato una volta in questo modo, e il personaggio ne recupera l'uso dopo un riposo lungo. Il Carisma è la caratteristica da incantatore per tutti e tre."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Drow Magic",
										Description = "You know the Dancing Lights cantrip. From 3rd level you can also cast Faerie Fire, and from 5th level Darkness; each of these two spells can be cast once this way, and you regain the use after a long rest. Charisma is your spellcasting ability for all three."
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