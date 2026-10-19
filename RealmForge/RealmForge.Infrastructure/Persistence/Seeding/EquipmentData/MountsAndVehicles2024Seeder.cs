using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.EquipmentData;

///	<summary>
///	Mounts, tack, vehicles and ships (2024 ruleset). Statistics and English text from the SRD 5.2 (CC BY 4.0), checked against the Player's Handbook;
///	the Italian texts are RealmForge translations that use the official Italian names.
///	</summary>
public static class MountsAndVehicles2024Seeder
{
	public static IEnumerable<Equipment> Build()
	{
		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "camel"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Mount,
			CostInCopper = 5000,
			WeightInPounds = null,
			CarryingCapacityInPounds = 450,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "camel", "en"), Language = LanguageCode.En, Name = "Camel", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "camel", "it"), Language = LanguageCode.It, Name = "Cammello", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "elephant"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Mount,
			CostInCopper = 20000,
			WeightInPounds = null,
			CarryingCapacityInPounds = 1320,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "elephant", "en"), Language = LanguageCode.En, Name = "Elephant", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "elephant", "it"), Language = LanguageCode.It, Name = "Elefante", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "horse-draft"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Mount,
			CostInCopper = 5000,
			WeightInPounds = null,
			CarryingCapacityInPounds = 540,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "horse-draft", "en"), Language = LanguageCode.En, Name = "Horse, Draft", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "horse-draft", "it"), Language = LanguageCode.It, Name = "Cavallo da tiro", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "horse-riding"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Mount,
			CostInCopper = 7500,
			WeightInPounds = null,
			CarryingCapacityInPounds = 480,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "horse-riding", "en"), Language = LanguageCode.En, Name = "Horse, Riding", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "horse-riding", "it"), Language = LanguageCode.It, Name = "Cavallo da galoppo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mastiff"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Mount,
			CostInCopper = 2500,
			WeightInPounds = null,
			CarryingCapacityInPounds = 195,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mastiff", "en"), Language = LanguageCode.En, Name = "Mastiff", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mastiff", "it"), Language = LanguageCode.It, Name = "Mastino", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mule"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Mount,
			CostInCopper = 800,
			WeightInPounds = null,
			CarryingCapacityInPounds = 420,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mule", "en"), Language = LanguageCode.En, Name = "Mule", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mule", "it"), Language = LanguageCode.It, Name = "Mulo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pony"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Mount,
			CostInCopper = 3000,
			WeightInPounds = null,
			CarryingCapacityInPounds = 225,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pony", "en"), Language = LanguageCode.En, Name = "Pony", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pony", "it"), Language = LanguageCode.It, Name = "Pony", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "warhorse"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Mount,
			CostInCopper = 40000,
			WeightInPounds = null,
			CarryingCapacityInPounds = 540,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "warhorse", "en"), Language = LanguageCode.En, Name = "Warhorse", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "warhorse", "it"), Language = LanguageCode.It, Name = "Cavallo da guerra", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "carriage"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 10000,
			WeightInPounds = 600m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "carriage", "en"), Language = LanguageCode.En, Name = "Carriage", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "carriage", "it"), Language = LanguageCode.It, Name = "Carrozza", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cart"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 1500,
			WeightInPounds = 200m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cart", "en"), Language = LanguageCode.En, Name = "Cart", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cart", "it"), Language = LanguageCode.It, Name = "Carretto", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "chariot"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 25000,
			WeightInPounds = 100m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "chariot", "en"), Language = LanguageCode.En, Name = "Chariot", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "chariot", "it"), Language = LanguageCode.It, Name = "Biga", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "feed-per-day"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 5,
			WeightInPounds = 10m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "feed-per-day", "en"), Language = LanguageCode.En, Name = "Feed (per day)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "feed-per-day", "it"), Language = LanguageCode.It, Name = "Nutrimento (al giorno)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "saddle-exotic"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 6000,
			WeightInPounds = 40m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "saddle-exotic", "en"), Language = LanguageCode.En, Name = "Saddle, Exotic", Description = "An Exotic Saddle is required for riding an aquatic or flying mount." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "saddle-exotic", "it"), Language = LanguageCode.It, Name = "Sella esotica", Description = "Una sella esotica è necessaria per cavalcare una cavalcatura acquatica o volante." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "saddle-military"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 2000,
			WeightInPounds = 30m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "saddle-military", "en"), Language = LanguageCode.En, Name = "Saddle, Military", Description = "A Military Saddle braces the rider, helping you keep your seat on an active mount in battle. It gives you Advantage on any check you make to remain mounted." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "saddle-military", "it"), Language = LanguageCode.It, Name = "Sella militare", Description = "Una sella militare sostiene il cavaliere e lo aiuta a restare in sella su una cavalcatura impegnata in battaglia: conferisce vantaggio alle prove effettuate per non essere disarcionati." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "saddle-riding"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 1000,
			WeightInPounds = 25m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "saddle-riding", "en"), Language = LanguageCode.En, Name = "Saddle, Riding", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "saddle-riding", "it"), Language = LanguageCode.It, Name = "Sella da galoppo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sled"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 2000,
			WeightInPounds = 300m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sled", "en"), Language = LanguageCode.En, Name = "Sled", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sled", "it"), Language = LanguageCode.It, Name = "Slitta", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "stabling-per-day"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 50,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "stabling-per-day", "en"), Language = LanguageCode.En, Name = "Stabling (per day)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "stabling-per-day", "it"), Language = LanguageCode.It, Name = "Stallaggio (al giorno)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "wagon"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 3500,
			WeightInPounds = 400m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "wagon", "en"), Language = LanguageCode.En, Name = "Wagon", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "wagon", "it"), Language = LanguageCode.It, Name = "Carro", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "barding"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = null,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "barding", "en"), Language = LanguageCode.En, Name = "Barding", Description = "Barding is armor designed for a mount. Any type of armor on the Armor table in this chapter can be purchased as barding. The cost is four times the normal cost, and it weighs twice as much." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "barding", "it"), Language = LanguageCode.It, Name = "Bardatura", Description = "La bardatura è un'armatura pensata per una cavalcatura. Ogni tipo di armatura della tabella delle armature può essere acquistato come bardatura, al quadruplo del costo normale e con il doppio del peso." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "airship"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ship,
			CostInCopper = 4000000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 8m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "airship", "en"), Language = LanguageCode.En, Name = "Airship", Description = "**Crew** 10 · **Passengers** 20 · **Cargo (tons)** 1 · **AC** 13 · **HP** 300 · **Damage Threshold** —\n\nA ship larger than a Keelboat or Rowboat needs a crew of skilled hirelings to function. A ship sailing against a strong wind moves at half speed, and in a dead calm waterborne ships can't move under sail and must be rowed. Keelboats and Rowboats are used on lakes and rivers: going downstream, add the speed of the current (typically 3 miles per hour); they can't be rowed against any significant current but can be pulled upstream by draft animals on the shores. A Rowboat can be carried and weighs 100 pounds. Repairing 1 Hit Point of a berthed ship takes 1 day and costs 20 GP for materials and labor (halved in a well-supplied shipyard)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "airship", "it"), Language = LanguageCode.It, Name = "Dirigibile", Description = "**Equipaggio** 10 · **Passeggeri** 20 · **Carico (tonnellate)** 1 · **CA** 13 · **PF** 300 · **Soglia di danno** —\n\nUna nave più grande di un barcone o di una barca a remi ha bisogno di un equipaggio di gregari esperti per funzionare. Contro un forte vento procede a metà velocità e, in assenza di vento, le navi a vela non possono avanzare se non a remi. Barconi e barche a remi navigano su laghi e fiumi: seguendo la corrente si aggiunge la velocità di questa (di solito 4,5 km/h), mentre controcorrente non si può remare, ma si può essere trainati da animali sulla riva. Una barca a remi può essere trasportata e pesa 50 kg. Riparare 1 punto ferita di una nave ormeggiata richiede 1 giorno e 20 mo di materiali e manodopera (tempo e costo dimezzati in un cantiere ben fornito)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "galley"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ship,
			CostInCopper = 3000000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "galley", "en"), Language = LanguageCode.En, Name = "Galley", Description = "**Crew** 80 · **Passengers** — · **Cargo (tons)** 150 · **AC** 15 · **HP** 500 · **Damage Threshold** 20\n\nA ship larger than a Keelboat or Rowboat needs a crew of skilled hirelings to function. A ship sailing against a strong wind moves at half speed, and in a dead calm waterborne ships can't move under sail and must be rowed. Keelboats and Rowboats are used on lakes and rivers: going downstream, add the speed of the current (typically 3 miles per hour); they can't be rowed against any significant current but can be pulled upstream by draft animals on the shores. A Rowboat can be carried and weighs 100 pounds. Repairing 1 Hit Point of a berthed ship takes 1 day and costs 20 GP for materials and labor (halved in a well-supplied shipyard)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "galley", "it"), Language = LanguageCode.It, Name = "Galea", Description = "**Equipaggio** 80 · **Passeggeri** — · **Carico (tonnellate)** 150 · **CA** 15 · **PF** 500 · **Soglia di danno** 20\n\nUna nave più grande di un barcone o di una barca a remi ha bisogno di un equipaggio di gregari esperti per funzionare. Contro un forte vento procede a metà velocità e, in assenza di vento, le navi a vela non possono avanzare se non a remi. Barconi e barche a remi navigano su laghi e fiumi: seguendo la corrente si aggiunge la velocità di questa (di solito 4,5 km/h), mentre controcorrente non si può remare, ma si può essere trainati da animali sulla riva. Una barca a remi può essere trasportata e pesa 50 kg. Riparare 1 punto ferita di una nave ormeggiata richiede 1 giorno e 20 mo di materiali e manodopera (tempo e costo dimezzati in un cantiere ben fornito)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "keelboat"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ship,
			CostInCopper = 300000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "keelboat", "en"), Language = LanguageCode.En, Name = "Keelboat", Description = "**Crew** 1 · **Passengers** 6 · **Cargo (tons)** 1/2 · **AC** 15 · **HP** 100 · **Damage Threshold** 10\n\nA ship larger than a Keelboat or Rowboat needs a crew of skilled hirelings to function. A ship sailing against a strong wind moves at half speed, and in a dead calm waterborne ships can't move under sail and must be rowed. Keelboats and Rowboats are used on lakes and rivers: going downstream, add the speed of the current (typically 3 miles per hour); they can't be rowed against any significant current but can be pulled upstream by draft animals on the shores. A Rowboat can be carried and weighs 100 pounds. Repairing 1 Hit Point of a berthed ship takes 1 day and costs 20 GP for materials and labor (halved in a well-supplied shipyard)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "keelboat", "it"), Language = LanguageCode.It, Name = "Barcone", Description = "**Equipaggio** 1 · **Passeggeri** 6 · **Carico (tonnellate)** 1/2 · **CA** 15 · **PF** 100 · **Soglia di danno** 10\n\nUna nave più grande di un barcone o di una barca a remi ha bisogno di un equipaggio di gregari esperti per funzionare. Contro un forte vento procede a metà velocità e, in assenza di vento, le navi a vela non possono avanzare se non a remi. Barconi e barche a remi navigano su laghi e fiumi: seguendo la corrente si aggiunge la velocità di questa (di solito 4,5 km/h), mentre controcorrente non si può remare, ma si può essere trainati da animali sulla riva. Una barca a remi può essere trasportata e pesa 50 kg. Riparare 1 punto ferita di una nave ormeggiata richiede 1 giorno e 20 mo di materiali e manodopera (tempo e costo dimezzati in un cantiere ben fornito)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "longship"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ship,
			CostInCopper = 1000000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "longship", "en"), Language = LanguageCode.En, Name = "Longship", Description = "**Crew** 40 · **Passengers** 150 · **Cargo (tons)** 10 · **AC** 15 · **HP** 300 · **Damage Threshold** 15\n\nA ship larger than a Keelboat or Rowboat needs a crew of skilled hirelings to function. A ship sailing against a strong wind moves at half speed, and in a dead calm waterborne ships can't move under sail and must be rowed. Keelboats and Rowboats are used on lakes and rivers: going downstream, add the speed of the current (typically 3 miles per hour); they can't be rowed against any significant current but can be pulled upstream by draft animals on the shores. A Rowboat can be carried and weighs 100 pounds. Repairing 1 Hit Point of a berthed ship takes 1 day and costs 20 GP for materials and labor (halved in a well-supplied shipyard)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "longship", "it"), Language = LanguageCode.It, Name = "Nave lunga", Description = "**Equipaggio** 40 · **Passeggeri** 150 · **Carico (tonnellate)** 10 · **CA** 15 · **PF** 300 · **Soglia di danno** 15\n\nUna nave più grande di un barcone o di una barca a remi ha bisogno di un equipaggio di gregari esperti per funzionare. Contro un forte vento procede a metà velocità e, in assenza di vento, le navi a vela non possono avanzare se non a remi. Barconi e barche a remi navigano su laghi e fiumi: seguendo la corrente si aggiunge la velocità di questa (di solito 4,5 km/h), mentre controcorrente non si può remare, ma si può essere trainati da animali sulla riva. Una barca a remi può essere trasportata e pesa 50 kg. Riparare 1 punto ferita di una nave ormeggiata richiede 1 giorno e 20 mo di materiali e manodopera (tempo e costo dimezzati in un cantiere ben fornito)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rowboat"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ship,
			CostInCopper = 5000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 1.5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rowboat", "en"), Language = LanguageCode.En, Name = "Rowboat", Description = "**Crew** 1 · **Passengers** 3 · **Cargo (tons)** — · **AC** 11 · **HP** 50 · **Damage Threshold** —\n\nA ship larger than a Keelboat or Rowboat needs a crew of skilled hirelings to function. A ship sailing against a strong wind moves at half speed, and in a dead calm waterborne ships can't move under sail and must be rowed. Keelboats and Rowboats are used on lakes and rivers: going downstream, add the speed of the current (typically 3 miles per hour); they can't be rowed against any significant current but can be pulled upstream by draft animals on the shores. A Rowboat can be carried and weighs 100 pounds. Repairing 1 Hit Point of a berthed ship takes 1 day and costs 20 GP for materials and labor (halved in a well-supplied shipyard)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rowboat", "it"), Language = LanguageCode.It, Name = "Barca a remi", Description = "**Equipaggio** 1 · **Passeggeri** 3 · **Carico (tonnellate)** — · **CA** 11 · **PF** 50 · **Soglia di danno** —\n\nUna nave più grande di un barcone o di una barca a remi ha bisogno di un equipaggio di gregari esperti per funzionare. Contro un forte vento procede a metà velocità e, in assenza di vento, le navi a vela non possono avanzare se non a remi. Barconi e barche a remi navigano su laghi e fiumi: seguendo la corrente si aggiunge la velocità di questa (di solito 4,5 km/h), mentre controcorrente non si può remare, ma si può essere trainati da animali sulla riva. Una barca a remi può essere trasportata e pesa 50 kg. Riparare 1 punto ferita di una nave ormeggiata richiede 1 giorno e 20 mo di materiali e manodopera (tempo e costo dimezzati in un cantiere ben fornito)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sailing-ship"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ship,
			CostInCopper = 1000000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sailing-ship", "en"), Language = LanguageCode.En, Name = "Sailing Ship", Description = "**Crew** 20 · **Passengers** 20 · **Cargo (tons)** 100 · **AC** 15 · **HP** 300 · **Damage Threshold** 15\n\nA ship larger than a Keelboat or Rowboat needs a crew of skilled hirelings to function. A ship sailing against a strong wind moves at half speed, and in a dead calm waterborne ships can't move under sail and must be rowed. Keelboats and Rowboats are used on lakes and rivers: going downstream, add the speed of the current (typically 3 miles per hour); they can't be rowed against any significant current but can be pulled upstream by draft animals on the shores. A Rowboat can be carried and weighs 100 pounds. Repairing 1 Hit Point of a berthed ship takes 1 day and costs 20 GP for materials and labor (halved in a well-supplied shipyard)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sailing-ship", "it"), Language = LanguageCode.It, Name = "Nave a vela", Description = "**Equipaggio** 20 · **Passeggeri** 20 · **Carico (tonnellate)** 100 · **CA** 15 · **PF** 300 · **Soglia di danno** 15\n\nUna nave più grande di un barcone o di una barca a remi ha bisogno di un equipaggio di gregari esperti per funzionare. Contro un forte vento procede a metà velocità e, in assenza di vento, le navi a vela non possono avanzare se non a remi. Barconi e barche a remi navigano su laghi e fiumi: seguendo la corrente si aggiunge la velocità di questa (di solito 4,5 km/h), mentre controcorrente non si può remare, ma si può essere trainati da animali sulla riva. Una barca a remi può essere trasportata e pesa 50 kg. Riparare 1 punto ferita di una nave ormeggiata richiede 1 giorno e 20 mo di materiali e manodopera (tempo e costo dimezzati in un cantiere ben fornito)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "warship"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Ship,
			CostInCopper = 2500000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 2.5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "warship", "en"), Language = LanguageCode.En, Name = "Warship", Description = "**Crew** 60 · **Passengers** 60 · **Cargo (tons)** 200 · **AC** 15 · **HP** 500 · **Damage Threshold** 20\n\nA ship larger than a Keelboat or Rowboat needs a crew of skilled hirelings to function. A ship sailing against a strong wind moves at half speed, and in a dead calm waterborne ships can't move under sail and must be rowed. Keelboats and Rowboats are used on lakes and rivers: going downstream, add the speed of the current (typically 3 miles per hour); they can't be rowed against any significant current but can be pulled upstream by draft animals on the shores. A Rowboat can be carried and weighs 100 pounds. Repairing 1 Hit Point of a berthed ship takes 1 day and costs 20 GP for materials and labor (halved in a well-supplied shipyard)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "warship", "it"), Language = LanguageCode.It, Name = "Nave da guerra", Description = "**Equipaggio** 60 · **Passeggeri** 60 · **Carico (tonnellate)** 200 · **CA** 15 · **PF** 500 · **Soglia di danno** 20\n\nUna nave più grande di un barcone o di una barca a remi ha bisogno di un equipaggio di gregari esperti per funzionare. Contro un forte vento procede a metà velocità e, in assenza di vento, le navi a vela non possono avanzare se non a remi. Barconi e barche a remi navigano su laghi e fiumi: seguendo la corrente si aggiunge la velocità di questa (di solito 4,5 km/h), mentre controcorrente non si può remare, ma si può essere trainati da animali sulla riva. Una barca a remi può essere trasportata e pesa 50 kg. Riparare 1 punto ferita di una nave ormeggiata richiede 1 giorno e 20 mo di materiali e manodopera (tempo e costo dimezzati in un cantiere ben fornito)." }
			}
		};
	}
}
