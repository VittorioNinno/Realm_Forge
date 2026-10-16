using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Tiefling2024Seeder
	{
		//	Deterministic GUIDs for 2024 SRD Tiefling aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000010");
		public static readonly Guid AbyssalSubspeciesId = Guid.Parse("20000000-0000-0000-0010-000000000001");
		public static readonly Guid ChthonicSubspeciesId = Guid.Parse("20000000-0000-0000-0010-000000000002");
		public static readonly Guid InfernalSubspeciesId = Guid.Parse("20000000-0000-0000-0010-000000000003");

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
						Name = "Tiefling",
						Description = "I tiefling nascono nei Piani Inferiori oppure discendono da immondi che provengono da lì. Attraverso il sangue sono legati a un diavolo, a un demone o a un altro immondo; questo legame è la loro eredità immonda. Offre potere, ma non stabilisce se un tiefling sia buono o malvagio.\n\nOgni tiefling sceglie se accettare o combattere quell'eredità, attingendo alla furia selvaggia dell'Abisso, alla cupa disperazione dei piani più tetri o all'ordine ardente degli Inferi."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Tiefling",
						Description = "Tieflings are either born in the Lower Planes or descend from fiends who came from there. Through their blood they are bound to a devil, a demon, or another fiend; this bond is their fiendish legacy. It offers power, but it does not decide whether a tiefling is good or evil.\n\nEach tiefling chooses whether to embrace or resist that legacy, drawing on the wild fury of the Abyss, the bleak despair of the gloomier planes, or the burning order of the Hells."
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
								Description = "Ha scurovisione fino a un raggio di 18 metri."
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
								Name = "Presenza ultraterrena",
								Description = "Conosce il trucchetto taumaturgia. Quando lo lancia sfruttando questo tratto, l'incantesimo utilizza la stessa caratteristica da incantatore scelta per il tratto Retaggio immondo (Intelligenza, Saggezza o Carisma)."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Otherworldly Presence",
								Description = "You know the Thaumaturgy cantrip. When you cast it with this trait, the spell uses the same spellcasting ability you use for your Fiendish Legacy trait (Intelligence, Wisdom, or Charisma)."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = AbyssalSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Abissale",
								Description = "I tiefling dell'eredità abissale sentono il richiamo dei piani più caotici e disperati. La maggior parte ha demoni tra i propri antenati, e corna, pelliccia, zanne o odori insoliti sono comuni tra loro."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Abyssal",
								Description = "Tieflings of the abyssal legacy feel the pull of the most chaotic and despairing planes. Most have demons among their ancestors, and horns, fur, tusks, or unusual scents are common among them."
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
										Name = "Retaggio Abissale (1° Livello)",
										Description = "Ha resistenza ai danni da veleno. Inoltre, conosce il trucchetto spruzzo velenoso (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Abyssal Legacy (Level 1)",
										Description = "You have Resistance to Poison damage. You also know the Poison Spray cantrip (spellcasting ability: Int, Wis, or Cha)."
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
										Name = "Magia Abissale: Raggio di Infermità (3° Livello)",
										Description = "Apprendi l'incantesimo Raggio di Infermità. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Abyssal Magic: Ray of Sickness (Level 3)",
										Description = "You learn the Ray of Sickness spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
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
										Name = "Magia Abissale: Blocca Persone (5° Livello)",
										Description = "Apprendi l'incantesimo Blocca Persone. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Abyssal Magic: Hold Person (Level 5)",
										Description = "You learn the Hold Person spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = ChthonicSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Ctonio",
								Description = "I tiefling dell'eredità ctonia sono attratti dai piani dell'avidità, della tetraggine e della prigionia. Alcuni hanno un aspetto scarno e cadaverico, altri una bellezza inquietante, altri ancora condividono tratti con le megere o con altri immondi di malvagità egoista."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Chthonic",
								Description = "Tieflings of the chthonic legacy are drawn to the planes of greed, gloom, and imprisonment. Some look gaunt and deathly, others have an unsettling beauty, and others share features with hags or other fiends of selfish evil."
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
										Name = "Retaggio Ctonio (1° Livello)",
										Description = "Possiede resistenza ai danni necrotici. Inoltre, conosce il trucchetto tocco gelido (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Chthonic Legacy (Level 1)",
										Description = "You have Resistance to Necrotic damage. You also know the Chill Touch cantrip (spellcasting ability: Int, Wis, or Cha)."
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
										Name = "Magia Ctonia: Vita Falsata (3° Livello)",
										Description = "Apprendi l'incantesimo Vita Falsata. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Chthonic Magic: False Life (Level 3)",
										Description = "You learn the False Life spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
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
										Name = "Magia Ctonia: Raggio di Affaticamento (5° Livello)",
										Description = "Apprendi l'incantesimo Raggio di Affaticamento. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Chthonic Magic: Ray of Enfeeblement (Level 5)",
										Description = "You learn the Ray of Enfeeblement spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = InfernalSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Infernale",
								Description = "I tiefling dell'eredità infernale sono legati ai regni ordinati degli Inferi e ai loro campi di battaglia senza fine. La maggior parte discende da diavoli, e corna, aculei, code, occhi dorati e un lieve odore di fumo o di zolfo sono comuni tra loro."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Infernal",
								Description = "Tieflings of the infernal legacy are tied to the ordered realms of the Hells and their endless battlefields. Most descend from devils, and horns, spines, tails, golden eyes, and a faint smell of smoke or sulfur are common among them."
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
										Name = "Retaggio Infernale (1° Livello)",
										Description = "Possiede resistenza ai danni da fuoco. Inoltre, conosce il trucchetto dardo di fuoco (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Infernal Legacy (Level 1)",
										Description = "You have Resistance to Fire damage. You also know the Fire Bolt cantrip (spellcasting ability: Int, Wis, or Cha)."
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
										Name = "Magia Infernale: Intimorire Infernale (3° Livello)",
										Description = "Apprendi l'incantesimo Intimorire Infernale. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Infernal Magic: Hellish Rebuke (Level 3)",
										Description = "You learn the Hellish Rebuke spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
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
										Name = "Magia Infernale: Oscurità (5° Livello)",
										Description = "Apprendi l'incantesimo Oscurità. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Infernal Magic: Darkness (Level 5)",
										Description = "You learn the Darkness spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
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