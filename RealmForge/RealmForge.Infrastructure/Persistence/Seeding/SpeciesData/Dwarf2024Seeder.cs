using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Dwarf2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Dwarf aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000004");

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
						Name = "Nano",
						Description = "Secondo le loro stesse leggende, i primi nani furono fatti sorgere dalla terra da un dio della forgia, conosciuto nei vari mondi come Moradin, Reorx e con altri nomi. Quel dio donò loro l'amore per la pietra, per il metallo e per la vita sotterranea, e li rese duraturi come le montagne. Un nano può vivere circa 350 anni.\n\nBassi, robusti e spesso barbuti, i nani costruirono le loro prime città nei fianchi delle montagne e sotto terra, e i loro canti più antichi narrano di battaglie contro i giganti delle vette e gli orrori del Sottosuolo. Quei racconti li spingono ancora a celebrare il coraggio, soprattutto quando i piccoli tengono testa ai potenti. In alcuni mondi, le famiglie che discendono dai primi insediamenti sulle colline o sulle montagne si definiscono ancora nani delle colline o nani delle montagne, come nelle ambientazioni di Greyhawk e Dragonlance."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Dwarf",
						Description = "According to their own legends, the first dwarves were raised from the earth by a god of the forge, known on different worlds as Moradin, Reorx, and other names. That god gave them a love of stone and metal and of life underground, and made them as enduring as the mountains. A dwarf can live for about 350 years.\n\nShort, sturdy, and often bearded, dwarves built their first cities into mountainsides and beneath the earth, and their oldest songs tell of battles against giants of the peaks and horrors of the Underdark. Those tales still inspire them to celebrate courage, especially when the small stand up to the mighty. On some worlds, the families descended from the first settlements in hills or mountains still call themselves hill dwarves or mountain dwarves, as in the Greyhawk and Dragonlance settings."
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
								Name = "Resilienza nanica",
								Description = "Ha resistenza ai danni da veleno. Dispone di vantaggio sui tiri salvezza eseguiti per evitare o terminare la condizione avvelenato su se stesso."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Dwarven Resilience",
								Description = "You have Resistance to Poison damage. You also have Advantage on saving throws you make to avoid or end the Poisoned condition."
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
								Name = "Robustezza nanica",
								Description = "I punti ferita massimi di un nano aumentano di 1 e aumentano di 1 ogni volta che acquisisce un livello."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Dwarven Toughness",
								Description = "Your Hit Point maximum increases by 1, and it increases by 1 again whenever you gain a level."
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
								Name = "Esperto minatore",
								Description = "Come azione bonus, il personaggio ottiene percezione tellurica con un raggio di 18 metri per 10 minuti. Per poterla utilizzare, deve trovarsi su una superficie di pietra o toccarla. La pietra deve essere naturale o lavorata.\n\nIl personaggio può utilizzare questa azione bonus un numero di volte pari al valore del suo bonus di competenza, recuperando tutti gli utilizzi spesi quando completa un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Stonecunning",
								Description = "As a Bonus Action, you gain Tremorsense with a range of 60 feet for 10 minutes. You must be on a stone surface or touching a stone surface to use this Tremorsense. The stone can be natural or worked. You can use this Bonus Action a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Long Rest."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};
		}
	}
}