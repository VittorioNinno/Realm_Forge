using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Aasimar2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Aasimar aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000002");

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
						Name = "Aasimar",
						Description = "Gli aasimar (pronunciato così come si scrive) sono mortali la cui anima custodisce una scintilla dei Piani Superiori. Alcuni la devono a un antenato angelico, altri a un'infusione di potere celestiale; in ogni caso, quella scintilla può essere ravvivata in luce, guarigione o ira dei cieli. Un aasimar può nascere presso qualsiasi popolo e somiglia molto alla sua famiglia, ma piccoli segni lo distinguono: lentiggini metalliche, occhi luminosi, un'aureola o una pelle del colore di quella di un angelo (argento, verde opalescente o rosso ramato). Questi segni si fanno più evidenti man mano che l'aasimar impara a rivelare la sua piena natura celestiale, e la sua vita può durare fino a 160 anni."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Aasimar",
						Description = "Aasimar (pronounced AH-sih-mar) are mortals whose souls hold a spark of the Upper Planes. Some owe it to an angelic ancestor, others to a blessing of celestial power; either way, the spark can be stirred into light, healing, or heavenly fury. An aasimar can be born to any people and looks much like their family, yet subtle signs set them apart: metallic freckles, luminous eyes, a halo, or skin with an angel's hue (silver, opalescent green, or coppery red). These signs grow stronger as the aasimar learns to reveal their full celestial nature, and they can live up to 160 years."
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
								Description = "Il personaggio vede nell'oscurità fino a 18 metri."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision",
								Description = "You can see in darkness out to 60 feet."
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
								Name = "Resistenza celestiale",
								Description = "Il personaggio ha Resistenza ai danni necrotici e radiosi."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Celestial Resistance",
								Description = "You have Resistance to Necrotic and Radiant damage."
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
								Name = "Portatore di luce",
								Description = "Il personaggio conosce il trucchetto Luce e usa il Carisma come caratteristica da incantatore per lanciarlo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Light Bearer",
								Description = "You know the Light cantrip, using Charisma as your spellcasting ability for it."
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
								Name = "Mani curative",
								Description = "Con un'azione Magia, il personaggio tocca una creatura e tira un numero di d4 pari al suo bonus di competenza; la creatura recupera punti ferita pari al totale. Può usare di nuovo questo tratto solo dopo aver terminato un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Healing Hands",
								Description = "With a Magic action, you touch a creature and roll a number of d4s equal to your Proficiency Bonus; the creature regains Hit Points equal to the total. You can use this trait again only after finishing a Long Rest."
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
								Name = "Rivelazione celestiale",
								Description = "Dal 3° livello del personaggio, può usare un'azione bonus per trasformarsi in una delle forme seguenti, scegliendo la forma ogni volta. La trasformazione dura 1 minuto o finché non vi pone fine (nessuna azione richiesta), e non può ripeterla finché non completa un riposo lungo.\n\nMentre è trasformato, una volta in ciascuno dei suoi turni può aggiungere danni extra pari al suo bonus di competenza a un bersaglio che danneggia con un attacco o un incantesimo. I danni extra sono necrotici per Sudario necrotico e radiosi per Ali celesti e Bagliore interiore.\n\n• Ali celesti: Ali spettrali si dispiegano dalla sua schiena, conferendogli una velocità di volo pari alla sua velocità fino al termine della trasformazione.\n• Bagliore interiore: Una luce bruciante sgorga dai suoi occhi e dalla sua bocca. Emette luce intensa in un raggio di 3 metri e luce fioca per altri 3 metri, e alla fine di ciascuno dei suoi turni ogni creatura entro 3 metri da lui subisce danni radiosi pari al suo bonus di competenza.\n• Sudario necrotico: I suoi occhi diventano pozze di oscurità e dalla sua schiena spuntano ali incapaci di volare. Ogni creatura entro 3 metri da lui che non sia sua alleata effettua un tiro salvezza su Carisma (CD 8 + il suo modificatore di Carisma + il suo bonus di competenza); se lo fallisce, ha la condizione di spaventato fino alla fine del turno successivo del personaggio."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Celestial Revelation",
								Description = "From character level 3, you can take a Bonus Action to transform using one of the options below, choosing the option each time. The transformation lasts 1 minute or until you end it (no action needed), and you can't transform again until you finish a Long Rest.\n\nWhile transformed, once on each of your turns you can add extra damage equal to your Proficiency Bonus to one target you damage with an attack or a spell. The extra damage is Necrotic for Necrotic Shroud and Radiant for Heavenly Wings and Inner Radiance.\n\n• Heavenly Wings: Ghostly wings unfold from your back, giving you a Fly Speed equal to your Speed until the transformation ends.\n• Inner Radiance: Searing light pours from your eyes and mouth. You shed Bright Light in a 10-foot radius and Dim Light for a further 10 feet, and at the end of each of your turns every creature within 10 feet of you takes Radiant damage equal to your Proficiency Bonus.\n• Necrotic Shroud: Your eyes turn to pools of darkness and flightless wings sprout from your back. Each creature within 10 feet of you that isn't your ally makes a Charisma saving throw (DC 8 + your Charisma modifier + your Proficiency Bonus) or has the Frightened condition until the end of your next turn."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};
		}
	}
}