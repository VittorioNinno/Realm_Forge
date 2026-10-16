using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Tiefling2014Seeder
	{
		//	Deterministic GUID for 2014 SRD Tiefling aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000008");

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
						Name = "Tiefling",
						Description = "I tiefling discendono da famiglie umane segnate molto tempo fa da un patto con un signore degli Inferi. Corna ricurve, pelle dalle sfumature rossastre, lunghe code e occhi di un unico colore pieno rivelano l'eredità immonda che scorre ancora nel loro sangue."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Tiefling",
						Description = "Tieflings descend from human families marked long ago by a bargain with a lord of the Hells. Curving horns, skin in shades of red, long tails, and eyes of a single solid color reveal the fiendish heritage that still runs in their blood."
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
								Description = "Grazie al retaggio infernale, un tiefling beneficia di una vista superiore nell'oscurità e nelle condizioni di luce fioca fino a 18 metri (vede nella penombra come luce intensa e nell'oscurità come luce fioca)."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision (60 ft.)",
								Description = "Thanks to your infernal heritage, you have superior vision in dark and dim conditions up to 60 feet (see in dim light as bright light, and darkness as dim light)."
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
								Name = "Resistenza Infernale",
								Description = "Un tiefling dispone di resistenza ai danni da fuoco."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Hellish Resistance",
								Description = "You have resistance to fire damage."
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
								Name = "Eredità Infernale",
								Description = "Un tiefling conosce il trucchetto Taumaturgia. Al 3° livello può lanciare l'incantesimo Intimorire Infernale (al 2° livello di slot) una volta per riposo lungo; al 5° livello può lanciare Oscurità una volta per riposo lungo (Carisma è la caratteristica da incantatore)."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Infernal Legacy",
								Description = "You know the thaumaturgy cantrip. At 3rd level, cast hellish rebuke once per long rest as a 2nd-level spell; at 5th level, cast darkness once per long rest (Charisma is your spellcasting ability)."
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
								Description = "Un tiefling sa parlare, leggere e scrivere in Comune e in Infernale."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Languages",
								Description = "You can speak, read, and write Common and Infernal."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};
		}
	}
}