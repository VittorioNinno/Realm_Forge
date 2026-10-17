using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Orc2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Orc aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000009");

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
						Name = "Orco",
						Description = "Gli orchi fanno risalire la loro creazione a Gruumsh, un dio possente che vagava per le terre aperte del Piano Materiale. Gruumsh donò ai suoi figli ciò di cui avevano bisogno per attraversare vaste pianure, caverne profonde e mari in tempesta e per affrontare i mostri che vi si annidano. Anche chi si rivolge ad altri dei conserva i doni di Gruumsh: resistenza, determinazione e occhi che vedono al buio.\n\nGli orchi sono in genere alti e massicci, con la pelle grigia, orecchie molto appuntite e canini inferiori sporgenti come piccole zanne. In alcuni mondi i giovani orchi crescono con le storie dei grandi viaggi dei loro antenati e si chiedono quando Gruumsh li chiamerà a eguagliarne le gesta; altri preferiscono lasciarsi alle spalle le vecchie storie e trovare la propria strada."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Orc",
						Description = "Orcs trace their creation to Gruumsh, a mighty god who roamed the open lands of the Material Plane. Gruumsh gave his children the gifts they would need to cross wide plains, deep caverns, and stormy seas and to stand against the monsters found there. Even those who turn to other gods keep Gruumsh's gifts: endurance, determination, and eyes that see in the dark.\n\nOrcs tend to be tall and broad, with gray skin, sharply pointed ears, and lower canines that jut like small tusks. On some worlds young orcs grow up on tales of their ancestors' great journeys and wonder when Gruumsh will call on them to match those deeds; others prefer to leave the old stories behind and make their own way."
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
								Name = "Scarica di adrenalina",
								Description = "Può utilizzare l’azione Scatto come azione bonus. Ogni volta che lo fa, ottiene un numero di punti ferita temporanei pari al suo bonus di competenza.\n\nIl personaggio può usare questo tratto un numero di volte pari al valore del suo bonus di competenza e recupera tutti gli utilizzi spesi quando completa un riposo breve o lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Adrenaline Rush",
								Description = "You can take the Dash action as a Bonus Action. When you do so, you gain a number of Temporary Hit Points equal to your Proficiency Bonus. You can use this trait a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Short or Long Rest."
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
								Name = "Scurovisione",
								Description = "Ha scurovisione fino a un raggio di 36 metri."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision",
								Description = "You have Darkvision with a range of 120 feet."
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
								Name = "Resistenza implacabile",
								Description = "Quando scende a 0 punti ferita ma non viene ucciso sul colpo, può decidere di rimanere a 1 punto ferita. Dopo averlo usato, non può riutilizzare questo tratto prima di aver completato un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Relentless Endurance",
								Description = "When you are reduced to 0 Hit Points but not killed outright, you can drop to 1 Hit Point instead. Once you use this trait, you can’t do so again until you finish a Long Rest."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};
		}
	}
}