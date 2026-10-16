using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Gnome2024Seeder
	{
		//	Deterministic GUIDs for 2024 SRD Gnome aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000006");
		public static readonly Guid ForestGnomeSubspeciesId = Guid.Parse("20000000-0000-0000-0006-000000000001");
		public static readonly Guid RockGnomeSubspeciesId = Guid.Parse("20000000-0000-0000-0006-000000000002");

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
				AllowedSizes = new List<CreatureSize> { CreatureSize.Small },
				Ruleset = RulesetVersion.Dnd5e_2024,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Gnomo",
						Description = "Gli gnomi sono un popolo magico che si dice sia stato creato da dei dell'invenzione, dell'illusione e dei luoghi nascosti sotto terra. I primi gnomi vivevano in foreste e tane e si facevano vedere di rado, ingannando i predatori più grossi con trappole e gallerie labirintiche. I loro dei, facendo visita in incognito, insegnarono loro una magia da cui nacquero le stirpi degli gnomi delle foreste e degli gnomi delle rocce.\n\nGli gnomi sono piccoli, con occhi grandi e orecchie appuntite, e vivono circa 425 anni. Molti amano avere qualcosa sopra la testa, anche se si tratta solo di un cappello."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Gnome",
						Description = "Gnomes are a magical people said to have been made by gods of invention, illusion, and the hidden places underground. The first gnomes kept to forests and burrows and were rarely seen, outwitting larger predators with traps and maze-like tunnels. Their gods, visiting in disguise, taught them magic that eventually gave rise to the forest gnome and rock gnome lineages.\n\nGnomes are small, with large eyes and pointed ears, and live around 425 years. Many of them like having something over their heads, even if it is only a hat."
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
								Name = "Astuzia gnomesca",
								Description = "Dispone di vantaggio ai tiri salvezza su Intelligenza, Saggezza e Carisma."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Gnomish Cunning",
								Description = "You have Advantage on Intelligence, Wisdom, and Charisma saving throws."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = ForestGnomeSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Gnomo delle foreste",
								Description = "Il personaggio conosce il trucchetto illusione minore. Inoltre, l'incantesimo parlare con gli animali è sempre considerato come preparato. Può lanciarlo senza consumare uno slot incantesimo un numero di volte pari al suo bonus di competenza e riacquista tutti gli usi spesi al termine di un riposo lungo. Può anche lanciare l'incantesimo usando uno qualsiasi degli slot incantesimo a sua disposizione (caratteristica: Int, Sag o Car a scelta)."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Forest Gnome",
								Description = "You know the Minor Illusion cantrip. You also always have the Speak with Animals spell prepared. You can cast it without a spell slot a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Long Rest. You can also use any spell slots you have to cast the spell (spellcasting ability: Int, Wis, or Cha)."
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
										Name = "Lignaggio: Illusione Minore",
										Description = "Il personaggio conosce il trucchetto illusione minore. La caratteristica da incantatore può essere Intelligenza, Saggezza o Carisma (decisa al momento della scelta del lignaggio)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Lineage: Minor Illusion",
										Description = "You know the Minor Illusion cantrip. Intelligence, Wisdom, or Charisma is your spellcasting ability for it (choose the ability when you select the lineage)."
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
										Name = "Lignaggio: Parlare con gli Animali",
										Description = "L'incantesimo parlare con gli animali è sempre considerato come preparato. Può lanciarlo senza consumare uno slot incantesimo un numero di volte pari al suo bonus di competenza e riacquista tutti gli usi spesi al termine di un riposo lungo. Può anche lanciare l'incantesimo usando uno qualsiasi degli slot incantesimo a sua disposizione."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Lineage: Speak with Animals",
										Description = "You always have the Speak with Animals spell prepared. You can cast it without a spell slot a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Long Rest. You can also use any spell slots you have to cast the spell."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = RockGnomeSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Gnomo delle rocce",
								Description = "Conosce i trucchetti riparare e prestidigitazione. Inoltre, può impiegare 10 minuti di lancio di prestidigitazione per creare un piccolo dispositivo meccanico (CA 5, 1 PF) che produce un effetto di prestidigitazione attivabile a contatto con un'azione bonus (caratteristica: Int, Sag o Car a scelta)."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Rock Gnome",
								Description = "You know the Mending and Prestidigitation cantrips. In addition, you can spend 10 minutes casting Prestidigitation to create a Tiny clockwork device (AC 5, 1 HP) producing an effect triggered by a Bonus Action touch (spellcasting ability: Int, Wis, or Cha)."
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
										Name = "Lignaggio: Riparare e Prestidigitazione",
										Description = "Conosce i trucchetti riparare e prestidigitazione. La caratteristica da incantatore può essere Intelligenza, Saggezza o Carisma (decisa al momento della scelta del lignaggio)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Lineage: Mending and Prestidigitation",
										Description = "You know the Mending and Prestidigitation cantrips. Intelligence, Wisdom, or Charisma is your spellcasting ability for them (choose the ability when you select the lineage)."
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
										Name = "Lignaggio: Dispositivo Meccanico",
										Description = "Può impiegare 10 minuti di lancio di prestidigitazione per creare un piccolo dispositivo meccanico (CA 5, 1 PF), come un giocattolo, un accendifuoco o un carillon. Una volta creato, puoi determinare il suo effetto scegliendo fra quelli di prestidigitazione. Il dispositivo lo produrrà ogni volta che il personaggio o un'altra creatura utilizza un'azione bonus per attivarlo a contatto. Se l'effetto selezionato presenta ulteriori opzioni, puoi sceglierne una al momento della creazione del congegno (per esempio decidere tra accensione o spegnimento, ma non entrambi). Il personaggio può avere in contemporanea fino a tre oggetti del genere. Ciascuno si smantella 8 ore dopo la sua creazione o finché non lo fa il personaggio stesso con un'azione di contatto o utilizzo."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Lineage: Clockwork Device",
										Description = "You can spend 10 minutes casting Prestidigitation to create a Tiny clockwork device (AC 5, 1 HP), such as a toy, fire starter, or music box. When you create the device, you determine its function by choosing one effect from Prestidigitation; the device produces that effect whenever you or another creature takes a Bonus Action to activate it with a touch. If the chosen effect has options within it, you choose one of those options for the device when you create it. For example, if you choose the spell's ignite-extinguish effect, you determine whether the device ignites or extinguishes fire; the device doesn't do both. You can have three such devices in existence at a time, and each falls apart 8 hours after its creation or when you dismantle it with a touch as a Utilize action."
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