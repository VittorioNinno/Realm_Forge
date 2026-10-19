using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.EquipmentData;

///	<summary>
///	Adventuring gear, ammunition, spellcasting focuses and equipment packs (2024 ruleset). Statistics and English text from the SRD 5.2 (CC BY 4.0), checked against the Player's Handbook;
///	the Italian texts are RealmForge translations that use the official Italian names.
///	</summary>
public static class AdventuringGear2024Seeder
{
	public static IEnumerable<Equipment> Build()
	{
		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "acid"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2500,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "acid", "en"), Language = LanguageCode.En, Name = "Acid", Description = "When you take the Attack action, you can replace one of your attacks with throwing a vial of Acid. Target one creature or object you can see within 20 feet of yourself. The target must succeed on a Dexterity saving throw (DC 8 plus your Dexterity modifier and Proficiency Bonus) or take 2d6 Acid damage." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "acid", "it"), Language = LanguageCode.It, Name = "Acido", Description = "Quando effettua l'azione di Attacco, il personaggio può sostituire uno dei suoi attacchi con il lancio di una fiala di acido contro una creatura o un oggetto che è in grado di vedere entro 6 metri. Il bersaglio deve superare un tiro salvezza su Destrezza (CD 8 + il modificatore di Destrezza del personaggio + il suo bonus di competenza), altrimenti subisce 2d6 danni da acido." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "alchemists-fire"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5000,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "alchemists-fire", "en"), Language = LanguageCode.En, Name = "Alchemist's Fire", Description = "When you take the Attack action, you can replace one of your attacks with throwing a flask of Alchemist’s Fire. Target one creature or object you can see within 20 feet of yourself. The target must succeed on a Dexterity saving throw (DC 8 plus your Dexterity modifier and Proficiency Bonus) or take 1d4 Fire damage and start burning (see the rules glossary)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "alchemists-fire", "it"), Language = LanguageCode.It, Name = "Fuoco dell'alchimista", Description = "Quando effettua l'azione di Attacco, il personaggio può sostituire uno dei suoi attacchi con il lancio di un'ampolla di fuoco dell'alchimista contro una creatura o un oggetto che è in grado di vedere entro 6 metri. Il bersaglio deve superare un tiro salvezza su Destrezza (CD 8 + il modificatore di Destrezza del personaggio + il suo bonus di competenza), altrimenti subisce 1d4 danni da fuoco e inizia a bruciare (vedi il glossario delle regole)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "amulet"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 500,
			WeightInPounds = 1m,
			FocusType = FocusType.HolySymbol,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "amulet", "en"), Language = LanguageCode.En, Name = "Amulet", Description = "A Holy Symbol is adorned or inlaid to channel divine magic. A Cleric or Paladin can use it as a Spellcasting Focus. An Amulet is worn or held, an Emblem is borne on fabric (such as a tabard or banner) or a Shield, and a Reliquary is held." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "amulet", "it"), Language = LanguageCode.It, Name = "Amuleto", Description = "Un simbolo sacro è decorato o intarsiato per incanalare la magia divina. Un chierico o un paladino può usarlo come focus da incantatore. L'amuleto va indossato o tenuto in mano, l'emblema va portato su un tessuto (come un tabarro o uno stendardo) o su uno scudo, il reliquiario va tenuto in mano." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "antitoxin"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "antitoxin", "en"), Language = LanguageCode.En, Name = "Antitoxin", Description = "As a Bonus Action, you can drink a vial of Antitoxin to gain Advantage on saving throws to avoid or end the Poisoned condition for 1 hour." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "antitoxin", "it"), Language = LanguageCode.It, Name = "Antitossina", Description = "Come azione bonus, il personaggio può bere una fiala di antitossina per disporre di vantaggio ai tiri salvezza per evitare o porre fine alla condizione di avvelenato per 1 ora." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "arrows"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ammunition,
			CostInCopper = 100,
			WeightInPounds = 1m,
			Quantity = 20,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "arrows", "en"), Language = LanguageCode.En, Name = "Arrows", Description = "Ammunition is required by a weapon that has the Ammunition property, and the weapon's description specifies the type it uses. Ammunition is bought in the listed amount and kept in a container that must be bought separately (quiver, case, or pouch)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "arrows", "it"), Language = LanguageCode.It, Name = "Frecce", Description = "Le munizioni sono necessarie alle armi con la proprietà munizioni; la descrizione di ogni arma indica il tipo di munizioni che usa. Si acquistano nella quantità indicata e vanno conservate in un contenitore acquistato a parte (faretra, custodia o borsa)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "backpack"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "backpack", "en"), Language = LanguageCode.En, Name = "Backpack", Description = "A Backpack holds up to 30 pounds within 1 cubic foot. It can also serve as a saddlebag." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "backpack", "it"), Language = LanguageCode.It, Name = "Zaino", Description = "Uno zaino contiene fino a 15 kg di oggetti, in un volume pari a un cubo di 30 centimetri di spigolo. Può essere usato anche come bisaccia da sella." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ball-bearings"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ball-bearings", "en"), Language = LanguageCode.En, Name = "Ball bearings", Description = "As a Utilize action, you can spill Ball Bearings from their pouch. They spread to cover a level, 10-foot-square area within 10 feet of yourself. A creature that enters this area for the first time on a turn must succeed on a DC 10 Dexterity saving throw or have the Prone condition. It takes 10 minutes to recover the Ball Bearings." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ball-bearings", "it"), Language = LanguageCode.It, Name = "Sfere metalliche", Description = "Come azione di Utilizzo, il personaggio può spargere le sfere metalliche dal loro sacchetto per coprire un'area piana quadrata di 3 metri di lato entro 3 metri da sé. Una creatura che entra nell'area per la prima volta in un turno deve superare un tiro salvezza su Destrezza con CD 10, altrimenti subisce la condizione di prono. Per raccogliere le sfere servono 10 minuti." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "barrel"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 70m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "barrel", "en"), Language = LanguageCode.En, Name = "Barrel", Description = "A Barrel holds up to 40 gallons of liquid or up to 4 cubic feet of dry goods." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "barrel", "it"), Language = LanguageCode.It, Name = "Barile", Description = "Un barile contiene fino a 160 litri di liquido oppure merci secche fino a un volume di 4 cubi di 30 centimetri di spigolo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "basket"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 40,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "basket", "en"), Language = LanguageCode.En, Name = "Basket", Description = "A Basket holds up to 40 pounds within 2 cubic feet." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "basket", "it"), Language = LanguageCode.It, Name = "Cesto", Description = "Un cesto contiene fino a 20 kg di oggetti, in un volume pari a 2 cubi di 30 centimetri di spigolo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bedroll"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 7m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bedroll", "en"), Language = LanguageCode.En, Name = "Bedroll", Description = "A Bedroll sleeps one Small or Medium creature. While in a Bedroll, you automatically succeed on saving throws against extreme cold (see the Dungeon Master’s Guide)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bedroll", "it"), Language = LanguageCode.It, Name = "Giaciglio", Description = "Su un giaciglio può dormire una creatura di taglia Piccola o Media. Finché si trova nel giaciglio, il personaggio supera automaticamente i tiri salvezza contro il freddo estremo (vedi la Guida del Dungeon Master)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bell"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bell", "en"), Language = LanguageCode.En, Name = "Bell", Description = "When rung as a Utilize action, a Bell produces a sound that can be heard up to 60 feet away." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bell", "it"), Language = LanguageCode.It, Name = "Campana", Description = "Suonata come azione di Utilizzo, una campana produce un suono udibile fino a 18 metri di distanza." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "blanket"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "blanket", "en"), Language = LanguageCode.En, Name = "Blanket", Description = "While wrapped in a blanket, you have Advantage on saving throws against extreme cold (see the Dungeon Master’s Guide)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "blanket", "it"), Language = LanguageCode.It, Name = "Coperta", Description = "Finché è avvolto in una coperta, il personaggio dispone di vantaggio ai tiri salvezza contro il freddo estremo (vedi la Guida del Dungeon Master)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "block-and-tackle"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "block-and-tackle", "en"), Language = LanguageCode.En, Name = "Block and tackle", Description = "A Block and Tackle allows you to hoist up to four times the weight you can normally lift." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "block-and-tackle", "it"), Language = LanguageCode.It, Name = "Carrucola e paranco", Description = "Una carrucola con paranco permette di sollevare fino a quattro volte il peso che il personaggio potrebbe sollevare normalmente." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "book"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2500,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "book", "en"), Language = LanguageCode.En, Name = "Book", Description = "A Book contains fiction or nonfiction. If you consult an accurate nonfiction Book about its topic, you gain a +5 bonus to Intelligence (Arcana, History, Nature, or Religion) checks you make about that topic." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "book", "it"), Language = LanguageCode.It, Name = "Libro", Description = "Un libro contiene un'opera di narrativa o di saggistica. Consultando un saggio accurato sull'argomento, il personaggio ottiene un bonus di +5 alle prove di Intelligenza (Arcano, Natura, Religione o Storia) che effettua su quell'argomento." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bolts"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ammunition,
			CostInCopper = 100,
			WeightInPounds = 1.5m,
			Quantity = 20,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bolts", "en"), Language = LanguageCode.En, Name = "Bolts", Description = "Ammunition is required by a weapon that has the Ammunition property, and the weapon's description specifies the type it uses. Ammunition is bought in the listed amount and kept in a container that must be bought separately (quiver, case, or pouch)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bolts", "it"), Language = LanguageCode.It, Name = "Quadrelli", Description = "Le munizioni sono necessarie alle armi con la proprietà munizioni; la descrizione di ogni arma indica il tipo di munizioni che usa. Si acquistano nella quantità indicata e vanno conservate in un contenitore acquistato a parte (faretra, custodia o borsa)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bottle-glass"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bottle-glass", "en"), Language = LanguageCode.En, Name = "Bottle, Glass", Description = "A Glass Bottle holds up to 1½ pints." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bottle-glass", "it"), Language = LanguageCode.It, Name = "Bottiglia di vetro", Description = "Una bottiglia di vetro contiene fino a 0,75 litri." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bucket"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bucket", "en"), Language = LanguageCode.En, Name = "Bucket", Description = "A Bucket holds up to half a cubic foot of contents." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bucket", "it"), Language = LanguageCode.It, Name = "Secchio", Description = "Un secchio contiene fino a mezzo cubo di 30 centimetri di spigolo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bullets-firearm"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ammunition,
			CostInCopper = 300,
			WeightInPounds = 2m,
			Quantity = 10,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bullets-firearm", "en"), Language = LanguageCode.En, Name = "Bullets, Firearm", Description = "Ammunition is required by a weapon that has the Ammunition property, and the weapon's description specifies the type it uses. Ammunition is bought in the listed amount and kept in a container that must be bought separately (quiver, case, or pouch)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bullets-firearm", "it"), Language = LanguageCode.It, Name = "Proiettili, arma da fuoco", Description = "Le munizioni sono necessarie alle armi con la proprietà munizioni; la descrizione di ogni arma indica il tipo di munizioni che usa. Si acquistano nella quantità indicata e vanno conservate in un contenitore acquistato a parte (faretra, custodia o borsa)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bullets-sling"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ammunition,
			CostInCopper = 4,
			WeightInPounds = 1.5m,
			Quantity = 20,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bullets-sling", "en"), Language = LanguageCode.En, Name = "Bullets, Sling", Description = "Ammunition is required by a weapon that has the Ammunition property, and the weapon's description specifies the type it uses. Ammunition is bought in the listed amount and kept in a container that must be bought separately (quiver, case, or pouch)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bullets-sling", "it"), Language = LanguageCode.It, Name = "Proiettili, fionda", Description = "Le munizioni sono necessarie alle armi con la proprietà munizioni; la descrizione di ogni arma indica il tipo di munizioni che usa. Si acquistano nella quantità indicata e vanno conservate in un contenitore acquistato a parte (faretra, custodia o borsa)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "burglars-pack"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 1600,
			WeightInPounds = 42m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "burglars-pack", "en"), Language = LanguageCode.En, Name = "Burglar's Pack", Description = "A Burglar's Pack contains the following items: Backpack, Ball Bearings, Bell, 10 Candles, Crowbar, Hooded Lantern, 7 flasks of Oil, 5 days of Rations, Rope, Tinderbox, and Waterskin." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "burglars-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da scassinatore", Description = "La dotazione da scassinatore contiene: zaino, sfere metalliche, campana, 10 candele, piede di porco, lanterna schermabile, 7 ampolle d'olio, 5 giorni di razioni, corda, acciarino con pietra focaia e otre." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "caltrops"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "caltrops", "en"), Language = LanguageCode.En, Name = "Caltrops", Description = "As a Utilize action, you can spread Caltrops from their bag to cover a 5-foot-square area within 5 feet of yourself. A creature that enters this area for the first time on a turn must succeed on a DC 15 Dexterity saving throw or take 1 Piercing damage and have its Speed reduced to 0 until the start of its next turn. It takes 10 minutes to recover the Caltrops." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "caltrops", "it"), Language = LanguageCode.It, Name = "Triboli", Description = "Come azione di Utilizzo, il personaggio può spargere i triboli dal loro sacchetto per coprire un'area quadrata di 1,5 metri di lato entro 1,5 metri da sé. Una creatura che entra nell'area per la prima volta in un turno deve superare un tiro salvezza su Destrezza con CD 15, altrimenti subisce 1 danno perforante e la sua velocità si riduce a 0 fino all'inizio del suo turno successivo. Per raccogliere i triboli servono 10 minuti." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "candle"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "candle", "en"), Language = LanguageCode.En, Name = "Candle", Description = "For 1 hour, a lit Candle sheds Bright Light in a 5-foot radius and Dim Light for an additional 5 feet." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "candle", "it"), Language = LanguageCode.It, Name = "Candela", Description = "Per 1 ora, una candela accesa proietta luce intensa in un raggio di 1,5 metri e luce fioca per altri 1,5 metri." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "case-crossbow-bolt"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "case-crossbow-bolt", "en"), Language = LanguageCode.En, Name = "Case, Crossbow Bolt", Description = "A Crossbow Bolt Case holds up to 20 Bolts." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "case-crossbow-bolt", "it"), Language = LanguageCode.It, Name = "Custodia per quadrelli da balestra", Description = "Una custodia per quadrelli da balestra contiene fino a 20 quadrelli." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "case-map-or-scroll"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "case-map-or-scroll", "en"), Language = LanguageCode.En, Name = "Case, Map or Scroll", Description = "A Map or Scroll Case holds up to 10 sheets of paper or 5 sheets of parchment." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "case-map-or-scroll", "it"), Language = LanguageCode.It, Name = "Custodia per mappe o pergamene", Description = "Una custodia per mappe o pergamene contiene fino a 10 fogli di carta o 5 fogli di pergamena." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "chain"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 10m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "chain", "en"), Language = LanguageCode.En, Name = "Chain", Description = "As a Utilize action, you can wrap a Chain around an unwilling creature within 5 feet of yourself that has the Grappled, Incapacitated, or Restrained condition if you succeed on a DC 13 Strength (Athletics) check. If the creature’s legs are bound, the creature has the Restrained condition until it escapes. Escaping the Chain requires the creature to make a successful DC 18 Dexterity (Acrobatics) check as an action. Bursting the Chain requires a successful DC 20 Strength (Athletics) check as an action." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "chain", "it"), Language = LanguageCode.It, Name = "Catena", Description = "Come azione di Utilizzo, il personaggio può avvolgere una catena attorno a una creatura non consenziente entro 1,5 metri da sé che sia afferrata, incapacitata o trattenuta, se supera una prova di Forza (Atletica) con CD 13. Se ha le gambe legate, la creatura è trattenuta finché non si libera. Per liberarsi deve superare una prova di Destrezza (Acrobazia) con CD 18 usando un'azione; per spezzare la catena serve una prova di Forza (Atletica) con CD 20, sempre con un'azione." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "chest"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 25m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "chest", "en"), Language = LanguageCode.En, Name = "Chest", Description = "A Chest holds up to 12 cubic feet of contents." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "chest", "it"), Language = LanguageCode.It, Name = "Forziere", Description = "Un forziere contiene oggetti fino a un volume di 12 cubi di 30 centimetri di spigolo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "climbers-kit"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2500,
			WeightInPounds = 12m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "climbers-kit", "en"), Language = LanguageCode.En, Name = "Climber's Kit", Description = "A Climber’s Kit includes boot tips, gloves, pitons, and a harness. As a Utilize action, you can use the Climber’s Kit to anchor yourself; when you do, you can’t fall more than 25 feet from the anchor point, and you can’t move more than 25 feet from there without undoing the anchor as a Bonus Action." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "climbers-kit", "it"), Language = LanguageCode.It, Name = "Attrezzi da scalatore", Description = "Gli attrezzi da scalatore comprendono punte per stivali, guanti, chiodi da roccia e un'imbracatura. Come azione di Utilizzo, il personaggio può usarli per ancorarsi: finché resta ancorato non può cadere per più di 7,5 metri dal punto di ancoraggio, e non può allontanarsene per più di 7,5 metri senza prima sganciarsi con un'azione bonus." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "clothes-fine"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1500,
			WeightInPounds = 6m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "clothes-fine", "en"), Language = LanguageCode.En, Name = "Clothes, Fine", Description = "Fine Clothes are made of expensive fabrics and adorned with expertly crafted details. Some events and locations admit only people wearing these clothes." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "clothes-fine", "it"), Language = LanguageCode.It, Name = "Abiti eleganti", Description = "Gli abiti eleganti sono fatti di stoffe costose e decorati con dettagli di pregio. Ad alcuni eventi e luoghi si accede solo indossandoli." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "clothes-travelers"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "clothes-travelers", "en"), Language = LanguageCode.En, Name = "Clothes, Traveler's", Description = "Traveler’s Clothes are resilient garments designed for travel in various environments." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "clothes-travelers", "it"), Language = LanguageCode.It, Name = "Abiti da viaggiatore", Description = "Gli abiti da viaggiatore sono indumenti robusti, pensati per viaggiare negli ambienti più vari." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "component-pouch"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2500,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "component-pouch", "en"), Language = LanguageCode.En, Name = "Component Pouch", Description = "A Component Pouch is watertight and filled with compartments that hold all the free Material components of your spells." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "component-pouch", "it"), Language = LanguageCode.It, Name = "Borsa per componenti", Description = "Una borsa per componenti è impermeabile e piena di scomparti che contengono tutte le componenti materiali gratuite degli incantesimi del personaggio." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "costume"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "costume", "en"), Language = LanguageCode.En, Name = "Costume", Description = "While wearing a Costume, you have Advantage on any ability check you make to impersonate the person or type of person it represents." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "costume", "it"), Language = LanguageCode.It, Name = "Costume", Description = "Mentre indossa un costume, il personaggio dispone di vantaggio a ogni prova di caratteristica effettuata per impersonare la persona o il tipo di persona che il costume rappresenta." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "crowbar"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "crowbar", "en"), Language = LanguageCode.En, Name = "Crowbar", Description = "Using a Crowbar gives you Advantage on Strength checks where the Crowbar’s leverage can be applied." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "crowbar", "it"), Language = LanguageCode.It, Name = "Piede di porco", Description = "Usare un piede di porco conferisce vantaggio alle prove di Forza in cui si può sfruttare la sua leva." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "crystal"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 1000,
			WeightInPounds = 1m,
			FocusType = FocusType.Arcane,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "crystal", "en"), Language = LanguageCode.En, Name = "Crystal", Description = "An Arcane Focus is bejeweled or carved to channel arcane magic. A Sorcerer, Warlock, or Wizard can use such an item as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "crystal", "it"), Language = LanguageCode.It, Name = "Cristallo", Description = "Un focus arcano è un oggetto ingioiellato o intagliato per incanalare la magia arcana. Uno stregone, un warlock o un mago può usarlo come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "diplomat-pack"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 3900,
			WeightInPounds = 39m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "diplomat-pack", "en"), Language = LanguageCode.En, Name = "Diplomat's Pack", Description = "A Diplomat's Pack contains the following items: Chest, Fine Clothes, Ink, 5 Ink Pens, Lamp, 2 Map or Scroll Cases, 4 flasks of Oil, 5 sheets of Paper, 5 sheets of Parchment, Perfume, and Tinderbox." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "diplomat-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da diplomatico", Description = "La dotazione da diplomatico contiene: forziere, abiti eleganti, inchiostro, 5 pennini, lampada, 2 custodie per mappe o pergamene, 4 ampolle d'olio, 5 fogli di carta, 5 fogli di pergamena, profumo e acciarino con pietra focaia." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dungeoneer-pack"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 1200,
			WeightInPounds = 55m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dungeoneer-pack", "en"), Language = LanguageCode.En, Name = "Dungeoneer's Pack", Description = "A Dungeoneer's Pack contains the following items: Backpack, Caltrops, Crowbar, 2 flasks of Oil, 10 days of Rations, Rope, Tinderbox, 10 Torches, and Waterskin." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dungeoneer-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da avventuriero", Description = "La dotazione da avventuriero contiene: zaino, triboli, piede di porco, 2 ampolle d'olio, 10 giorni di razioni, corda, acciarino con pietra focaia, 10 torce e otre." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "emblem"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 500,
			WeightInPounds = null,
			FocusType = FocusType.HolySymbol,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "emblem", "en"), Language = LanguageCode.En, Name = "Emblem", Description = "A Holy Symbol is adorned or inlaid to channel divine magic. A Cleric or Paladin can use it as a Spellcasting Focus. An Amulet is worn or held, an Emblem is borne on fabric (such as a tabard or banner) or a Shield, and a Reliquary is held." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "emblem", "it"), Language = LanguageCode.It, Name = "Emblema", Description = "Un simbolo sacro è decorato o intarsiato per incanalare la magia divina. Un chierico o un paladino può usarlo come focus da incantatore. L'amuleto va indossato o tenuto in mano, l'emblema va portato su un tessuto (come un tabarro o uno stendardo) o su uno scudo, il reliquiario va tenuto in mano." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "entertainers-pack"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 4000,
			WeightInPounds = 58.5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "entertainers-pack", "en"), Language = LanguageCode.En, Name = "Entertainer's Pack", Description = "An Entertainer's Pack contains the following items: Backpack, Bedroll, Bell, Bullseye Lantern, 3 Costumes, Mirror, 8 flasks of Oil, 9 days of Rations, Tinderbox, and Waterskin." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "entertainers-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da intrattenitore", Description = "La dotazione da intrattenitore contiene: zaino, giaciglio, campana, lanterna a lente sporgente, 3 costumi, specchio, 8 ampolle d'olio, 9 giorni di razioni, acciarino con pietra focaia e otre." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "explorers-pack"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1000,
			WeightInPounds = 55m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "explorers-pack", "en"), Language = LanguageCode.En, Name = "Explorer's Pack", Description = "An Explorer's Pack contains the following items: Backpack, Bedroll, 2 flasks of Oil, 10 days of Rations, Rope, Tinderbox, 10 Torches, and Waterskin." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "explorers-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da esploratore", Description = "La dotazione da esploratore contiene: zaino, giaciglio, 2 ampolle d'olio, 10 giorni di razioni, corda, acciarino con pietra focaia, 10 torce e otre." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "flask"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "flask", "en"), Language = LanguageCode.En, Name = "Flask", Description = "A Flask holds up to 1 pint." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "flask", "it"), Language = LanguageCode.It, Name = "Ampolla", Description = "Un'ampolla contiene fino a 0,5 litri." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "grappling-hook"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "grappling-hook", "en"), Language = LanguageCode.En, Name = "Grappling Hook", Description = "As a Utilize action, you can throw the Grappling Hook at a railing, a ledge, or another catch within 50 feet of yourself, and the hook catches on if you succeed on a DC 13 Dexterity (Acrobatics) check. If you tied a Rope to the hook, you can then climb it." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "grappling-hook", "it"), Language = LanguageCode.It, Name = "Rampino", Description = "Come azione di Utilizzo, il personaggio può lanciare il rampino verso una ringhiera, una sporgenza o un altro appiglio entro 15 metri da sé; il rampino fa presa se supera una prova di Destrezza (Acrobazia) con CD 13. Se al rampino è legata una corda, il personaggio può poi arrampicarsi su di essa." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "healers-kit"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "healers-kit", "en"), Language = LanguageCode.En, Name = "Healer's Kit", Description = "A Healer’s Kit has ten uses. As a Utilize action, you can expend one of its uses to stabilize an Unconscious creature that has 0 Hit Points without needing to make a Wisdom (Medicine) check." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "healers-kit", "it"), Language = LanguageCode.It, Name = "Borsa del guaritore", Description = "Una borsa del guaritore ha dieci utilizzi. Come azione di Utilizzo, il personaggio può spenderne uno per stabilizzare una creatura priva di sensi che ha 0 punti ferita, senza dover effettuare una prova di Saggezza (Medicina)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "holy-water"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2500,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "holy-water", "en"), Language = LanguageCode.En, Name = "Holy Water", Description = "When you take the Attack action, you can replace one of your attacks with throwing a flask of Holy Water. Target one creature you can see within 20 feet of yourself. The target must succeed on a Dexterity saving throw (DC 8 plus your Dexterity modifier and Proficiency Bonus) or take 2d8 Radiant damage if it is a Fiend or an Undead." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "holy-water", "it"), Language = LanguageCode.It, Name = "Acqua santa", Description = "Quando effettua l'azione di Attacco, il personaggio può sostituire uno dei suoi attacchi con il lancio di un'ampolla di acqua santa contro una creatura che è in grado di vedere entro 6 metri. Il bersaglio deve superare un tiro salvezza su Destrezza (CD 8 + il modificatore di Destrezza del personaggio + il suo bonus di competenza), altrimenti, se è un immondo o un non morto, subisce 2d8 danni radiosi." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "hunting-trap"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 25m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "hunting-trap", "en"), Language = LanguageCode.En, Name = "Hunting Trap", Description = "As a Utilize action, you can set a Hunting Trap, which is a sawtooth steel ring that snaps shut when a creature steps on a pressure plate in the center. The trap is affixed by a heavy chain to an immobile object, such as a tree or a spike driven into the ground. A creature that steps on the plate must succeed on a DC 13 Dexterity saving throw or take 1d4 Piercing damage and have its Speed reduced to 0 until the start of its next turn. Thereafter, until the creature breaks free of the trap, its movement is limited by the length of the chain (typically 3 feet). A creature can use its action to make a DC 13 Strength (Athletics) check, freeing itself or another creature within its reach on a success. Each failed check deals 1 Piercing damage to the trapped creature." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "hunting-trap", "it"), Language = LanguageCode.It, Name = "Tagliola", Description = "Come azione di Utilizzo, il personaggio può piazzare una tagliola: un anello d'acciaio dentato che scatta quando una creatura calpesta la piastra a pressione al centro. La tagliola è fissata con una pesante catena a un oggetto inamovibile, come un albero o un picchetto piantato nel terreno. Una creatura che calpesta la piastra deve superare un tiro salvezza su Destrezza con CD 13, altrimenti subisce 1d4 danni perforanti e la sua velocità si riduce a 0 fino all'inizio del suo turno successivo. In seguito, finché non si libera, i suoi movimenti sono limitati dalla lunghezza della catena (di solito 90 centimetri). Una creatura può usare la propria azione per effettuare una prova di Forza (Atletica) con CD 13 e, se la supera, libera se stessa o un'altra creatura alla sua portata; ogni prova fallita infligge 1 danno perforante alla creatura intrappolata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ink"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ink", "en"), Language = LanguageCode.En, Name = "Ink", Description = "Ink comes in a 1-ounce bottle, which provides enough ink to write about 500 pages." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ink", "it"), Language = LanguageCode.It, Name = "Inchiostro", Description = "L'inchiostro è venduto in boccette da 30 grammi, sufficienti per scrivere circa 500 pagine." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ink-pen"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ink-pen", "en"), Language = LanguageCode.En, Name = "Ink Pen", Description = "Using Ink, an Ink Pen is used to write or draw." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ink-pen", "it"), Language = LanguageCode.It, Name = "Pennino", Description = "Con l'inchiostro, il pennino serve a scrivere o disegnare." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "jug"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2,
			WeightInPounds = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "jug", "en"), Language = LanguageCode.En, Name = "Jug", Description = "A Jug holds up to 1 gallon." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "jug", "it"), Language = LanguageCode.It, Name = "Brocca", Description = "Una brocca contiene fino a 4 litri." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ladder"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10,
			WeightInPounds = 25m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ladder", "en"), Language = LanguageCode.En, Name = "Ladder", Description = "A Ladder is 10 feet tall. You must climb to move up or down it." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ladder", "it"), Language = LanguageCode.It, Name = "Scala a pioli", Description = "Una scala a pioli è alta 3 metri. Per salire o scendere bisogna arrampicarsi." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lamp"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lamp", "en"), Language = LanguageCode.En, Name = "Lamp", Description = "A Lamp burns Oil as fuel to cast Bright Light in a 15-foot radius and Dim Light for an additional 30 feet." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lamp", "it"), Language = LanguageCode.It, Name = "Lampada", Description = "Una lampada brucia olio come combustibile per proiettare luce intensa in un raggio di 4,5 metri e luce fioca per altri 9 metri." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lantern-bullseye"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1000,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lantern-bullseye", "en"), Language = LanguageCode.En, Name = "Lantern, Bullseye", Description = "A Bullseye Lantern burns Oil as fuel to cast Bright Light in a 60-foot Cone and Dim Light for an additional 60 feet." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lantern-bullseye", "it"), Language = LanguageCode.It, Name = "Lanterna a lente sporgente", Description = "Una lanterna a lente sporgente brucia olio come combustibile per proiettare luce intensa in un cono di 18 metri e luce fioca per altri 18 metri." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lantern-hooded"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lantern-hooded", "en"), Language = LanguageCode.En, Name = "Lantern, Hooded", Description = "A Hooded Lantern burns Oil as fuel to cast Bright Light in a 30-foot radius and Dim Light for an additional 30 feet. As a Bonus Action, you can lower the hood, reducing the light to Dim Light in a 5-foot radius, or raise it again." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lantern-hooded", "it"), Language = LanguageCode.It, Name = "Lanterna schermabile", Description = "Una lanterna schermabile brucia olio come combustibile per proiettare luce intensa in un raggio di 9 metri e luce fioca per altri 9 metri. Come azione bonus, il personaggio può abbassarne lo schermo, riducendo la luce a luce fioca in un raggio di 1,5 metri, o rialzarlo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lock"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1000,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lock", "en"), Language = LanguageCode.En, Name = "Lock", Description = "A Lock comes with a key. Without the key, a creature can use Thieves’ Tools to pick this Lock with a successful DC 15 Dexterity (Sleight of Hand) check." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lock", "it"), Language = LanguageCode.It, Name = "Serratura", Description = "Una serratura viene fornita con la sua chiave. Senza la chiave, una creatura può usare gli arnesi da scasso per forzarla superando una prova di Destrezza (Rapidità di mano) con CD 15." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "magnifying-glass"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "magnifying-glass", "en"), Language = LanguageCode.En, Name = "Magnifying Glass", Description = "A Magnifying Glass grants Advantage on any ability check made to appraise or inspect a highly detailed item. Lighting a fire with a Magnifying Glass requires light as bright as sunlight to focus, tinder to ignite, and about 5 minutes for the fire to ignite." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "magnifying-glass", "it"), Language = LanguageCode.It, Name = "Lente d'ingrandimento", Description = "Una lente d'ingrandimento conferisce vantaggio a ogni prova di caratteristica effettuata per valutare o esaminare un oggetto ricco di dettagli. Per accendere un fuoco con una lente d'ingrandimento servono una luce intensa come quella del sole da concentrare, dell'esca da incendiare e circa 5 minuti perché il fuoco prenda." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "manacles"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 6m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "manacles", "en"), Language = LanguageCode.En, Name = "Manacles", Description = "As a Utilize action, you can use Manacles to bind an unwilling Small or Medium creature within 5 feet of yourself that has the Grappled, Incapacitated, or Restrained condition if you succeed on a DC 13 Dexterity (Sleight of Hand) check. While bound, a creature has Disadvantage on attack rolls, and the creature is Restrained if the Manacles are attached to a chain or hook that is fixed in place. Escaping the Manacles requires a successful DC 20 Dexterity (Sleight of Hand) check as an action. Bursting them requires a successful DC 25 Strength (Athletics) check as an action. Each set of Manacles comes with a key. Without the key, a creature can use Thieves’ Tools to pick the Manacles’ lock with a successful DC 15 Dexterity (Sleight of Hand) check." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "manacles", "it"), Language = LanguageCode.It, Name = "Manette", Description = "Come azione di Utilizzo, il personaggio può usare le manette per immobilizzare una creatura non consenziente di taglia Piccola o Media entro 1,5 metri da sé che sia afferrata, incapacitata o trattenuta, se supera una prova di Destrezza (Rapidità di mano) con CD 13. Una creatura ammanettata subisce svantaggio ai tiri per colpire, ed è trattenuta se le manette sono assicurate a una catena o a un gancio fissato. Per liberarsi serve una prova di Destrezza (Rapidità di mano) con CD 20 effettuata con un'azione; per spezzarle, una prova di Forza (Atletica) con CD 25, sempre con un'azione. Ogni paio di manette ha la sua chiave; senza di essa, una creatura può usare gli arnesi da scasso per forzarne la serratura superando una prova di Destrezza (Rapidità di mano) con CD 15." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "map"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "map", "en"), Language = LanguageCode.En, Name = "Map", Description = "If you consult an accurate Map, you gain a +5 bonus to Wisdom (Survival) checks you make to find your way in the place represented on it." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "map", "it"), Language = LanguageCode.It, Name = "Mappa", Description = "Consultando una mappa accurata, il personaggio ottiene un bonus di +5 alle prove di Saggezza (Sopravvivenza) per orientarsi nel luogo che rappresenta." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mirror"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 0.5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mirror", "en"), Language = LanguageCode.En, Name = "Mirror", Description = "A handheld steel Mirror is useful for personal cosmetics but also for peeking around corners and reflecting light as a signal." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mirror", "it"), Language = LanguageCode.It, Name = "Specchio", Description = "Uno specchio d'acciaio portatile serve per la cura della persona, ma anche per sbirciare dietro gli angoli o riflettere la luce per mandare segnali." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "needles"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ammunition,
			CostInCopper = 100,
			WeightInPounds = 1m,
			Quantity = 50,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "needles", "en"), Language = LanguageCode.En, Name = "Needles", Description = "Ammunition is required by a weapon that has the Ammunition property, and the weapon's description specifies the type it uses. Ammunition is bought in the listed amount and kept in a container that must be bought separately (quiver, case, or pouch)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "needles", "it"), Language = LanguageCode.It, Name = "Aghi", Description = "Le munizioni sono necessarie alle armi con la proprietà munizioni; la descrizione di ogni arma indica il tipo di munizioni che usa. Si acquistano nella quantità indicata e vanno conservate in un contenitore acquistato a parte (faretra, custodia o borsa)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "net"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "net", "en"), Language = LanguageCode.En, Name = "Net", Description = "When you take the Attack action, you can replace one of your attacks with throwing a Net. Target a creature you can see within 15 feet of yourself. The target must succeed on a Dexterity saving throw (DC 8 plus your Dexterity modifier and Proficiency Bonus) or have the Restrained condition until it escapes. The target succeeds automatically if it is Huge or larger. To escape, the target or a creature within 5 feet of it must take an action to make a DC 10 Strength (Athletics) check, freeing the Restrained creature on a success. Destroying the Net (AC 10; 5 HP; Immunity to Bludgeoning, Poison, and Psychic damage) also frees the target, ending the effect." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "net", "it"), Language = LanguageCode.It, Name = "Rete", Description = "Quando effettua l'azione di Attacco, il personaggio può sostituire uno dei suoi attacchi con il lancio di una rete contro una creatura che è in grado di vedere entro 4,5 metri. Il bersaglio deve superare un tiro salvezza su Destrezza (CD 8 + il modificatore di Destrezza del personaggio + il suo bonus di competenza), altrimenti è trattenuto finché non si libera; le creature di taglia Enorme o superiore superano automaticamente il tiro salvezza. Per liberarlo, il bersaglio o una creatura entro 1,5 metri da esso deve usare un'azione per effettuare una prova di Forza (Atletica) con CD 10: se la supera, la creatura trattenuta si libera. Anche distruggere la rete (CA 10; 5 PF; immunità ai danni contundenti, psichici e da veleno) libera il bersaglio e pone fine all'effetto." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "oil"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "oil", "en"), Language = LanguageCode.En, Name = "Oil", Description = "You can douse a creature, object, or space with Oil or use it as fuel, as detailed below.\n\n**Dousing a Creature or an Object.** When you take the Attack action, you can replace one of your attacks with throwing an Oil flask. Target one creature or object within 20 feet of yourself. The target must succeed on a Dexterity saving throw (DC 8 plus your Dexterity modifier and Proficiency Bonus) or be covered in oil. If the target takes Fire damage before the oil dries (after 1 minute), the target takes an extra 5 Fire damage from burning oil.\n\n**Dousing a Space.** You can take the Utilize action to pour an Oil flask on level ground to cover a 5-foot-square area within 5 feet of yourself. If lit, the oil burns until the end of the turn 2 rounds from when the oil was lit (or 12 seconds) and deals 5 Fire damage to any creature that enters the area or ends its turn there. A creature can take this damage only once per turn.\n\n**Fuel.** Oil serves as fuel for Lamps and Lanterns. Once lit, a flask of Oil burns for 6 hours in a Lamp or Lantern. That duration doesn't need to be consecutive; you can extinguish the burning Oil (as a Utilize action) and rekindle it again until it has burned for a total of 6 hours." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "oil", "it"), Language = LanguageCode.It, Name = "Olio", Description = "Il personaggio può cospargere d'olio una creatura, un oggetto o uno spazio, oppure usarlo come combustibile.\n\n**Cospargere una creatura o un oggetto.** Quando effettua l'azione di Attacco, il personaggio può sostituire uno dei suoi attacchi con il lancio di un'ampolla d'olio contro una creatura o un oggetto entro 6 metri. Il bersaglio deve superare un tiro salvezza su Destrezza (CD 8 + il modificatore di Destrezza del personaggio + il suo bonus di competenza), altrimenti viene ricoperto d'olio. Se subisce danni da fuoco prima che l'olio si asciughi (dopo 1 minuto), subisce 5 danni da fuoco extra a causa dell'olio che brucia.\n\n**Cospargere uno spazio.** Con un'azione di Utilizzo, il personaggio può versare un'ampolla d'olio su un terreno piano per coprire un'area quadrata di 1,5 metri di lato entro 1,5 metri da sé. Se viene acceso, l'olio brucia fino alla fine del turno che cade 2 round dopo l'accensione (12 secondi) e infligge 5 danni da fuoco a ogni creatura che entra nell'area o vi termina il turno. Una creatura può subire questi danni una sola volta per turno.\n\n**Combustibile.** L'olio alimenta lampade e lanterne: un'ampolla, una volta accesa, brucia per 6 ore in una lampada o in una lanterna. Le ore non devono essere consecutive: il personaggio può spegnere l'olio (con un'azione di Utilizzo) e riaccenderlo finché non ha bruciato per un totale di 6 ore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "orb"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 2000,
			WeightInPounds = 3m,
			FocusType = FocusType.Arcane,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "orb", "en"), Language = LanguageCode.En, Name = "Orb", Description = "An Arcane Focus is bejeweled or carved to channel arcane magic. A Sorcerer, Warlock, or Wizard can use such an item as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "orb", "it"), Language = LanguageCode.It, Name = "Globo", Description = "Un focus arcano è un oggetto ingioiellato o intagliato per incanalare la magia arcana. Uno stregone, un warlock o un mago può usarlo come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "paper"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 20,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "paper", "en"), Language = LanguageCode.En, Name = "Paper", Description = "One sheet of Paper can hold about 250 handwritten words." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "paper", "it"), Language = LanguageCode.It, Name = "Carta", Description = "Un foglio di carta può contenere circa 250 parole scritte a mano." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "parchment"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "parchment", "en"), Language = LanguageCode.En, Name = "Parchment", Description = "One sheet of Parchment can hold about 250 handwritten words." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "parchment", "it"), Language = LanguageCode.It, Name = "Pergamena", Description = "Un foglio di pergamena può contenere circa 250 parole scritte a mano." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "perfume"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "perfume", "en"), Language = LanguageCode.En, Name = "Perfume", Description = "Perfume comes in a 4-ounce vial. For 1 hour after applying Perfume to yourself, you have Advantage on Charisma (Persuasion) checks made to influence an Indifferent Humanoid within 5 feet of yourself." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "perfume", "it"), Language = LanguageCode.It, Name = "Profumo", Description = "Il profumo è venduto in fiale da 120 millilitri. Per 1 ora dopo esserselo applicato, il personaggio dispone di vantaggio alle prove di Carisma (Persuasione) effettuate per influenzare un umanoide indifferente entro 1,5 metri da sé." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "poison-basic"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "poison-basic", "en"), Language = LanguageCode.En, Name = "Poison, Basic", Description = "As a Bonus Action, you can use a vial of Basic Poison to coat one weapon or up to three pieces of ammunition. A creature that takes Piercing or Slashing damage from the poisoned weapon or ammunition takes an extra 1d4 Poison damage. Once applied, the poison retains potency for 1 minute or until its damage is dealt, whichever comes first." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "poison-basic", "it"), Language = LanguageCode.It, Name = "Veleno base", Description = "Come azione bonus, il personaggio può usare una fiala di veleno base per ricoprire un'arma o fino a tre munizioni. Una creatura che subisce danni perforanti o taglienti dall'arma o dalle munizioni avvelenate subisce 1d4 danni da veleno extra. Una volta applicato, il veleno resta efficace per 1 minuto o finché non infligge i suoi danni, a seconda di quale evento si verifica prima." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pole"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5,
			WeightInPounds = 7m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pole", "en"), Language = LanguageCode.En, Name = "Pole", Description = "A Pole is 10 feet long. You can use it to touch something up to 10 feet away. If you must make a Strength (Athletics) check as part of a High or Long Jump, you can use the Pole to vault, giving yourself Advantage on the check." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pole", "it"), Language = LanguageCode.It, Name = "Asta", Description = "Un'asta è lunga 3 metri e permette di toccare qualcosa fino a 3 metri di distanza. Se il personaggio deve effettuare una prova di Forza (Atletica) come parte di un salto in alto o in lungo, può usare l'asta come appoggio per darsi lo slancio, ottenendo vantaggio alla prova." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pot-iron"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 10m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pot-iron", "en"), Language = LanguageCode.En, Name = "Pot, Iron", Description = "An Iron Pot holds up to 1 gallon." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pot-iron", "it"), Language = LanguageCode.It, Name = "Pentola di ferro", Description = "Una pentola di ferro contiene fino a 4 litri." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "potion-of-healing"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5000,
			WeightInPounds = 0.5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "potion-of-healing", "en"), Language = LanguageCode.En, Name = "Potion of Healing", Description = "This potion is a magic item. As a Bonus Action, you can drink it or administer it to another creature within 5 feet of yourself. The creature that drinks the magical red fluid in this vial regains 2d4 + 2 Hit Points." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "potion-of-healing", "it"), Language = LanguageCode.It, Name = "Pozione di guarigione", Description = "Questa pozione è un oggetto magico. Come azione bonus, il personaggio può berla o somministrarla a un'altra creatura entro 1,5 metri da sé. La creatura che beve il liquido rosso e magico della fiala recupera 2d4 + 2 punti ferita." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pouch"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pouch", "en"), Language = LanguageCode.En, Name = "Pouch", Description = "A Pouch holds up to 6 pounds within one-fifth of a cubic foot." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pouch", "it"), Language = LanguageCode.It, Name = "Borsa", Description = "Una borsa contiene fino a 3 kg di oggetti, in un volume pari a un quinto di un cubo di 30 centimetri di spigolo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "priests-pack"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 3300,
			WeightInPounds = 29m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "priests-pack", "en"), Language = LanguageCode.En, Name = "Priest's Pack", Description = "A Priest's Pack contains the following items: Backpack, Blanket, Holy Water, Lamp, 7 days of Rations, Robe, and Tinderbox." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "priests-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da sacerdote", Description = "La dotazione da sacerdote contiene: zaino, coperta, acqua santa, lampada, 7 giorni di razioni, tunica e acciarino con pietra focaia." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "quiver"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "quiver", "en"), Language = LanguageCode.En, Name = "Quiver", Description = "A Quiver holds up to 20 Arrows." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "quiver", "it"), Language = LanguageCode.It, Name = "Faretra", Description = "Una faretra contiene fino a 20 frecce." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ram-portable"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 400,
			WeightInPounds = 35m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ram-portable", "en"), Language = LanguageCode.En, Name = "Ram, Portable", Description = "You can use a Portable Ram to break down doors. When doing so, you gain a +4 bonus to the Strength check. One other character can help you use the ram, giving you Advantage on this check." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "ram-portable", "it"), Language = LanguageCode.It, Name = "Ariete portatile", Description = "Il personaggio può usare un ariete portatile per sfondare le porte, ottenendo un bonus di +4 alla prova di Forza. Un altro personaggio può aiutarlo a manovrare l'ariete, conferendogli vantaggio alla prova." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rations"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rations", "en"), Language = LanguageCode.En, Name = "Rations", Description = "Rations consist of travel-ready food, including jerky, dried fruit, hardtack, and nuts. See “Malnutrition” in the rules glossary for the risks of not eating." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rations", "it"), Language = LanguageCode.It, Name = "Razioni", Description = "Le razioni sono cibo pronto per il viaggio: carne essiccata, frutta secca, gallette e frutta a guscio. Per i rischi di chi non mangia, vedi \"Malnutrizione\" nel glossario delle regole." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "reliquary"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 500,
			WeightInPounds = 2m,
			FocusType = FocusType.HolySymbol,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "reliquary", "en"), Language = LanguageCode.En, Name = "Reliquary", Description = "A Holy Symbol is adorned or inlaid to channel divine magic. A Cleric or Paladin can use it as a Spellcasting Focus. An Amulet is worn or held, an Emblem is borne on fabric (such as a tabard or banner) or a Shield, and a Reliquary is held." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "reliquary", "it"), Language = LanguageCode.It, Name = "Reliquiario", Description = "Un simbolo sacro è decorato o intarsiato per incanalare la magia divina. Un chierico o un paladino può usarlo come focus da incantatore. L'amuleto va indossato o tenuto in mano, l'emblema va portato su un tessuto (come un tabarro o uno stendardo) o su uno scudo, il reliquiario va tenuto in mano." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "robe"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "robe", "en"), Language = LanguageCode.En, Name = "Robe", Description = "A Robe has vocational or ceremonial significance. Some events and locations admit only people wearing a Robe bearing certain colors or symbols." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "robe", "it"), Language = LanguageCode.It, Name = "Tunica", Description = "Una tunica ha un significato professionale o cerimoniale. Ad alcuni eventi e luoghi si accede solo indossando una tunica con determinati colori o simboli." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rod"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 1000,
			WeightInPounds = 2m,
			FocusType = FocusType.Arcane,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rod", "en"), Language = LanguageCode.En, Name = "Rod", Description = "An Arcane Focus is bejeweled or carved to channel arcane magic. A Sorcerer, Warlock, or Wizard can use such an item as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rod", "it"), Language = LanguageCode.It, Name = "Verga", Description = "Un focus arcano è un oggetto ingioiellato o intagliato per incanalare la magia arcana. Uno stregone, un warlock o un mago può usarlo come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rope"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rope", "en"), Language = LanguageCode.En, Name = "Rope", Description = "As a Utilize action, you can tie a knot with Rope if you succeed on a DC 10 Dexterity (Sleight of Hand) check. The Rope can be burst with a successful DC 20 Strength (Athletics) check. You can bind an unwilling creature with the Rope only if the creature has the Grappled, Incapacitated, or Restrained condition. If the creature’s legs are bound, the creature has the Restrained condition until it escapes. Escaping the Rope requires the creature to make a successful DC 15 Dexterity (Acrobatics) check as an action." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rope", "it"), Language = LanguageCode.It, Name = "Corda", Description = "Come azione di Utilizzo, il personaggio può fare un nodo con la corda se supera una prova di Destrezza (Rapidità di mano) con CD 10. La corda si spezza superando una prova di Forza (Atletica) con CD 20. Il personaggio può legare una creatura non consenziente solo se è afferrata, incapacitata o trattenuta; se ha le gambe legate, la creatura è trattenuta finché non si libera. Per liberarsi deve superare una prova di Destrezza (Acrobazia) con CD 15 effettuata con un'azione." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sack"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1,
			WeightInPounds = 0.5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sack", "en"), Language = LanguageCode.En, Name = "Sack", Description = "A Sack holds up to 30 pounds within 1 cubic foot." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sack", "it"), Language = LanguageCode.It, Name = "Sacco", Description = "Un sacco contiene fino a 15 kg di oggetti, in un volume pari a un cubo di 30 centimetri di spigolo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "scholars-pack"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 4000,
			WeightInPounds = 22m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "scholars-pack", "en"), Language = LanguageCode.En, Name = "Scholar's Pack", Description = "A Scholar's Pack contains the following items: Backpack, Book, Ink, Ink Pen, Lamp, 10 flasks of Oil, 10 sheets of Parchment, and Tinderbox." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "scholars-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da studioso", Description = "La dotazione da studioso contiene: zaino, libro, inchiostro, pennino, lampada, 10 ampolle d'olio, 10 fogli di pergamena e acciarino con pietra focaia." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shovel"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shovel", "en"), Language = LanguageCode.En, Name = "Shovel", Description = "Working for 1 hour, you can use a Shovel to dig a hole that is 5 feet on each side in soil or similar material." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shovel", "it"), Language = LanguageCode.It, Name = "Pala", Description = "Lavorando per 1 ora, il personaggio può usare una pala per scavare una buca di 1,5 metri per lato nel terreno o in un materiale simile." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "signal-whistle"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "signal-whistle", "en"), Language = LanguageCode.En, Name = "Signal Whistle", Description = "When blown as a Utilize action, a Signal Whistle produces a sound that can be heard up to 600 feet away.\n\nSpell Scroll (Cantrip, 30 GP Level 1, 50 GP) A Spell Scroll (Cantrip) or Spell Scroll (Level 1) is a magic item that bears the words of a cantrip or level 1 spell, respectively, determined by the scroll’s creator. If the spell is on your class’s spell list, you can read the scroll and cast the spell using its normal casting time and without providing any Material components. If the spell requires a saving throw or an attack roll, the spell save DC is 13, and the attack bonus is +5. The scroll disintegrates when the casting is completed." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "signal-whistle", "it"), Language = LanguageCode.It, Name = "Fischietto da richiamo", Description = "Soffiato come azione di Utilizzo, un fischietto da richiamo produce un suono udibile fino a 180 metri di distanza." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spellbook"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = null,
			WeightInPounds = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spellbook", "en"), Language = LanguageCode.En, Name = "Spellbook", Description = "Essential for Wizards, a spellbook is a Tiny object that weighs 3 pounds, contains 100 pages, and can be read only by its owner or someone casting *Identify*. It holds the level 1+ spells the Wizard knows." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spellbook", "it"), Language = LanguageCode.It, Name = "Libro degli incantesimi", Description = "Il libro degli incantesimi è indispensabile per il mago: è un oggetto Minuscolo che pesa 1,5 kg, contiene 100 pagine e può essere letto soltanto dal suo proprietario o da chi lancia *identificare*. Contiene gli incantesimi di 1° livello o superiore che il mago conosce." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spell-scroll-cantrip"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 3000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spell-scroll-cantrip", "en"), Language = LanguageCode.En, Name = "Spell Scroll, Cantrip", Description = "A Spell Scroll (Cantrip) or Spell Scroll (Level 1) is a magic item that bears the words of a cantrip or level 1 spell, respectively, determined by the scroll's creator. If the spell is on your class's spell list, you can read the scroll and cast the spell using its normal casting time and without providing any Material components. If the spell requires a saving throw or an attack roll, the spell save DC is 13, and the attack bonus is +5. The scroll disintegrates when the casting is completed." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spell-scroll-cantrip", "it"), Language = LanguageCode.It, Name = "Pergamena magica (trucchetto)", Description = "Una pergamena magica (trucchetto) o una pergamena magica (1° livello) è un oggetto magico che riporta le parole di un trucchetto o di un incantesimo di 1° livello, scelto da chi l'ha creata. Se l'incantesimo compare nella lista degli incantesimi della sua classe, il personaggio può leggere la pergamena e lanciarlo con il suo tempo di lancio normale e senza fornire componenti materiali. Se l'incantesimo richiede un tiro salvezza o un tiro per colpire, la CD del tiro salvezza è 13 e il bonus di attacco è +5. Al termine del lancio, la pergamena si disintegra." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spell-scroll-level-1"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spell-scroll-level-1", "en"), Language = LanguageCode.En, Name = "Spell Scroll, Level 1", Description = "A Spell Scroll (Cantrip) or Spell Scroll (Level 1) is a magic item that bears the words of a cantrip or level 1 spell, respectively, determined by the scroll's creator. If the spell is on your class's spell list, you can read the scroll and cast the spell using its normal casting time and without providing any Material components. If the spell requires a saving throw or an attack roll, the spell save DC is 13, and the attack bonus is +5. The scroll disintegrates when the casting is completed." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spell-scroll-level-1", "it"), Language = LanguageCode.It, Name = "Pergamena magica (1° livello)", Description = "Una pergamena magica (trucchetto) o una pergamena magica (1° livello) è un oggetto magico che riporta le parole di un trucchetto o di un incantesimo di 1° livello, scelto da chi l'ha creata. Se l'incantesimo compare nella lista degli incantesimi della sua classe, il personaggio può leggere la pergamena e lanciarlo con il suo tempo di lancio normale e senza fornire componenti materiali. Se l'incantesimo richiede un tiro salvezza o un tiro per colpire, la CD del tiro salvezza è 13 e il bonus di attacco è +5. Al termine del lancio, la pergamena si disintegra." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spikes-iron"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spikes-iron", "en"), Language = LanguageCode.En, Name = "Spikes, Iron", Description = "Iron Spikes come in bundles of ten. As a Utilize action, you can use a blunt object, such as a Light Hammer, to hammer a spike into wood, earth, or a similar material. You can do so to jam a door shut or to then tie a Rope or Chain to the Spike." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spikes-iron", "it"), Language = LanguageCode.It, Name = "Spuntoni di ferro", Description = "Gli spuntoni di ferro sono venduti in fasci da dieci. Come azione di Utilizzo, il personaggio può usare un oggetto contundente, come un martello leggero, per piantare uno spuntone nel legno, nella terra o in un materiale simile, per bloccare una porta o per legarvi poi una corda o una catena." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sprig-of-mistletoe"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 100,
			WeightInPounds = null,
			FocusType = FocusType.Druidic,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sprig-of-mistletoe", "en"), Language = LanguageCode.En, Name = "Sprig of Mistletoe", Description = "A Druidic Focus is carved, tied with ribbon, or painted to channel primal magic. A Druid or Ranger can use such an object as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sprig-of-mistletoe", "it"), Language = LanguageCode.It, Name = "Rametto di vischio", Description = "Un focus druidico è intagliato, legato con un nastro o dipinto per incanalare la magia primordiale. Un druido o un ranger può usarlo come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spyglass"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100000,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spyglass", "en"), Language = LanguageCode.En, Name = "Spyglass", Description = "Objects viewed through a Spyglass are magnified to twice their size." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spyglass", "it"), Language = LanguageCode.It, Name = "Cannocchiale", Description = "Gli oggetti osservati con un cannocchiale appaiono ingranditi al doppio delle loro dimensioni." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "staff"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 500,
			WeightInPounds = 4m,
			FocusType = FocusType.Arcane,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "staff", "en"), Language = LanguageCode.En, Name = "Staff", Description = "An Arcane Focus is bejeweled or carved to channel arcane magic. A Sorcerer, Warlock, or Wizard can use such an item as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "staff", "it"), Language = LanguageCode.It, Name = "Bastone", Description = "Un focus arcano è un oggetto ingioiellato o intagliato per incanalare la magia arcana. Uno stregone, un warlock o un mago può usarlo come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "string"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "string", "en"), Language = LanguageCode.En, Name = "String", Description = "String is 10 feet long. You can tie a knot in it as a Utilize action." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "string", "it"), Language = LanguageCode.It, Name = "Spago", Description = "Lo spago è lungo 3 metri. Il personaggio può farvi un nodo con un'azione di Utilizzo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "tent"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 20m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "tent", "en"), Language = LanguageCode.En, Name = "Tent", Description = "A Tent sleeps up to two Small or Medium creatures." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "tent", "it"), Language = LanguageCode.It, Name = "Tenda", Description = "In una tenda possono dormire fino a due creature di taglia Piccola o Media." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "tinderbox"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "tinderbox", "en"), Language = LanguageCode.En, Name = "Tinderbox", Description = "A Tinderbox is a small container holding flint, fire steel, and tinder (usually dry cloth soaked in light oil) used to kindle a fire. Using it to light a Candle, Lamp, Lantern, or Torch—or anything else with exposed fuel—takes a Bonus Action. Lighting any other fire takes 1 minute." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "tinderbox", "it"), Language = LanguageCode.It, Name = "Acciarino con pietra focaia", Description = "Un acciarino con pietra focaia è un piccolo contenitore con selce, acciarino ed esca (di solito un panno secco imbevuto d'olio leggero) per accendere il fuoco. Accendere una candela, una lampada, una lanterna o una torcia, o qualsiasi altra cosa con combustibile esposto, richiede un'azione bonus; accendere qualsiasi altro fuoco richiede 1 minuto." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "torch"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "torch", "en"), Language = LanguageCode.En, Name = "Torch", Description = "A Torch burns for 1 hour, casting Bright Light in a 20-foot radius and Dim Light for an additional 20 feet. When you take the Attack action, you can attack with the Torch, using it as a Simple Melee weapon. On a hit, the target takes 1 Fire damage." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "torch", "it"), Language = LanguageCode.It, Name = "Torcia", Description = "Una torcia brucia per 1 ora, proiettando luce intensa in un raggio di 6 metri e luce fioca per altri 6 metri. Quando effettua l'azione di Attacco, il personaggio può attaccare con la torcia, usandola come arma semplice da mischia: se colpisce, il bersaglio subisce 1 danno da fuoco." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "vial"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "vial", "en"), Language = LanguageCode.En, Name = "Vial", Description = "A Vial holds up to 4 ounces." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "vial", "it"), Language = LanguageCode.It, Name = "Fiala", Description = "Una fiala contiene fino a 120 millilitri." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "wand"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 1000,
			WeightInPounds = 1m,
			FocusType = FocusType.Arcane,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "wand", "en"), Language = LanguageCode.En, Name = "Wand", Description = "An Arcane Focus is bejeweled or carved to channel arcane magic. A Sorcerer, Warlock, or Wizard can use such an item as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "wand", "it"), Language = LanguageCode.It, Name = "Bacchetta", Description = "Un focus arcano è un oggetto ingioiellato o intagliato per incanalare la magia arcana. Uno stregone, un warlock o un mago può usarlo come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "waterskin"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 20,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "waterskin", "en"), Language = LanguageCode.En, Name = "Waterskin", Description = "A Waterskin holds up to 4 pints. If you don’t drink sufficient water, you risk dehydration (see the rules glossary)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "waterskin", "it"), Language = LanguageCode.It, Name = "Otre", Description = "Un otre contiene fino a 2 litri. Se il personaggio non beve abbastanza acqua, rischia la disidratazione (vedi il glossario delle regole)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "yew-wand"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 1000,
			WeightInPounds = 1m,
			FocusType = FocusType.Druidic,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "yew-wand", "en"), Language = LanguageCode.En, Name = "Yew Wand", Description = "A Druidic Focus is carved, tied with ribbon, or painted to channel primal magic. A Druid or Ranger can use such an object as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "yew-wand", "it"), Language = LanguageCode.It, Name = "Bacchetta in legno di tasso", Description = "Un focus druidico è intagliato, legato con un nastro o dipinto per incanalare la magia primordiale. Un druido o un ranger può usarlo come focus da incantatore." }
			}
		};
	}
}
