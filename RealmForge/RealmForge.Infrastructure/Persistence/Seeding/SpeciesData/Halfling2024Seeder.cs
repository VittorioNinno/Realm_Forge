using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Halfling2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Halfling aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000008");

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
						Name = "Halfling",
						Description = "Gli halfling sono protetti da dei che hanno a cuore la vita, la casa e il focolare, e tendono a riunirsi in tranquille comunità di campagna dove famiglia e vicini plasmano la loro esistenza. Molti di loro, però, hanno un'indole audace e curiosa che li spinge a scoprire il mondo e a farsi amici lungo la strada. La piccola statura permette loro di passare inosservati tra la folla e di infilarsi in passaggi stretti.\n\nChi viaggia con gli halfling si accorge presto della loro famosa fortuna, una forza silenziosa che sembra intervenire quando il pericolo è più grande. Lo stesso dono potrebbe spiegare la loro lunga vita, di circa 150 anni."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Halfling",
						Description = "Halflings are watched over by gods who cherish life, home, and hearth, and they tend to gather in peaceful countryside communities where family and neighbors shape their lives. Plenty of them, though, have a bold and curious streak that sends them off to see the wider world and make friends along the way. Their small size lets them pass unnoticed through crowds and squeeze through narrow gaps.\n\nThose who travel with halflings soon notice their famous luck, a quiet force that seems to step in when danger is greatest. The same gift may help explain their long lives of about 150 years."
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
								Name = "Agilità halfling",
								Description = "Può attraversare lo spazio occupato da qualsiasi creatura più grande di lui, ma non può fermarvisi dentro."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Halfling Nimbleness",
								Description = "You can move through the space of any creature that is a size larger than you, but you can't stop in the same space."
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
								Name = "Coraggioso",
								Description = "Dispone di vantaggio ai tiri salvezza eseguiti per evitare o terminare la condizione spaventato su se stesso."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Brave",
								Description = "You have Advantage on saving throws you make to avoid or end the Frightened condition."
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
								Name = "Fortuna",
								Description = "Quando effettua una prova con d20 (D20 Test) e ottiene 1, può ritirare il dado e deve utilizzare il nuovo risultato."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Luck",
								Description = "When you roll a 1 on the d20 of a D20 Test, you can reroll the die, and you must use the new roll."
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
								Name = "Furtività innata",
								Description = "Può effettuare l'azione di nascondersi anche se è oscurato solo da una singola creatura, purché questa sia più grande di lui di almeno una taglia."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Naturally Stealthy",
								Description = "You can take the Hide action even when you are obscured only by a creature that is at least one size larger than you."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};
		}
	}
}