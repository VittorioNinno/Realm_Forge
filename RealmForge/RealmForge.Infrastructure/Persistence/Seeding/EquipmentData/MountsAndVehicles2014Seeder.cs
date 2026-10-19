using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.EquipmentData;

///	<summary>
///	Mounts, tack, vehicles and ships (2014 ruleset). Statistics and English text from the SRD 5.1 (CC BY 4.0), checked against the Player's Handbook;
///	the Italian texts are RealmForge translations that use the official Italian names.
///	</summary>
public static class MountsAndVehicles2014Seeder
{
	public static IEnumerable<Equipment> Build()
	{
		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "camel"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Mount,
			CostInCopper = 5000,
			WeightInPounds = null,
			SpeedInFeet = 50,
			CarryingCapacityInPounds = 480,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "camel", "en"), Language = LanguageCode.En, Name = "Camel", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "camel", "it"), Language = LanguageCode.It, Name = "Cammello", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "donkey"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Mount,
			CostInCopper = 800,
			WeightInPounds = null,
			SpeedInFeet = 40,
			CarryingCapacityInPounds = 420,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "donkey", "en"), Language = LanguageCode.En, Name = "Donkey", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "donkey", "it"), Language = LanguageCode.It, Name = "Asino", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mule"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Mount,
			CostInCopper = 800,
			WeightInPounds = null,
			SpeedInFeet = 40,
			CarryingCapacityInPounds = 420,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mule", "en"), Language = LanguageCode.En, Name = "Mule", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mule", "it"), Language = LanguageCode.It, Name = "Mulo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "elephant"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Mount,
			CostInCopper = 20000,
			WeightInPounds = null,
			SpeedInFeet = 40,
			CarryingCapacityInPounds = 1320,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "elephant", "en"), Language = LanguageCode.En, Name = "Elephant", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "elephant", "it"), Language = LanguageCode.It, Name = "Elefante", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "horse-draft"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Mount,
			CostInCopper = 5000,
			WeightInPounds = null,
			SpeedInFeet = 40,
			CarryingCapacityInPounds = 540,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "horse-draft", "en"), Language = LanguageCode.En, Name = "Horse, draft", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "horse-draft", "it"), Language = LanguageCode.It, Name = "Cavallo da tiro", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "horse-riding"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Mount,
			CostInCopper = 7500,
			WeightInPounds = null,
			SpeedInFeet = 60,
			CarryingCapacityInPounds = 480,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "horse-riding", "en"), Language = LanguageCode.En, Name = "Horse, riding", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "horse-riding", "it"), Language = LanguageCode.It, Name = "Cavallo da galoppo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mastiff"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Mount,
			CostInCopper = 2500,
			WeightInPounds = null,
			SpeedInFeet = 40,
			CarryingCapacityInPounds = 195,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mastiff", "en"), Language = LanguageCode.En, Name = "Mastiff", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mastiff", "it"), Language = LanguageCode.It, Name = "Mastino", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pony"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Mount,
			CostInCopper = 3000,
			WeightInPounds = null,
			SpeedInFeet = 40,
			CarryingCapacityInPounds = 225,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pony", "en"), Language = LanguageCode.En, Name = "Pony", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pony", "it"), Language = LanguageCode.It, Name = "Pony", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "warhorse"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Mount,
			CostInCopper = 40000,
			WeightInPounds = null,
			SpeedInFeet = 60,
			CarryingCapacityInPounds = 540,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "warhorse", "en"), Language = LanguageCode.En, Name = "Warhorse", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "warhorse", "it"), Language = LanguageCode.It, Name = "Cavallo da guerra", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bit-and-bridle"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 200,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bit-and-bridle", "en"), Language = LanguageCode.En, Name = "Bit and bridle", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bit-and-bridle", "it"), Language = LanguageCode.It, Name = "Morso e briglie", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "carriage"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 10000,
			WeightInPounds = 600m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "carriage", "en"), Language = LanguageCode.En, Name = "Carriage", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "carriage", "it"), Language = LanguageCode.It, Name = "Carrozza", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cart"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 1500,
			WeightInPounds = 200m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cart", "en"), Language = LanguageCode.En, Name = "Cart", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cart", "it"), Language = LanguageCode.It, Name = "Carretto", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chariot"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 25000,
			WeightInPounds = 100m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chariot", "en"), Language = LanguageCode.En, Name = "Chariot", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chariot", "it"), Language = LanguageCode.It, Name = "Biga", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "animal-feed-1-day"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 5,
			WeightInPounds = 10m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "animal-feed-1-day", "en"), Language = LanguageCode.En, Name = "Animal Feed (1 day)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "animal-feed-1-day", "it"), Language = LanguageCode.It, Name = "Nutrimento (al giorno)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-exotic"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 6000,
			WeightInPounds = 50m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-exotic", "en"), Language = LanguageCode.En, Name = "Saddle, Exotic", Description = "An exotic saddle is required for riding any aquatic or flying mount." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-exotic", "it"), Language = LanguageCode.It, Name = "Sella esotica", Description = "Una sella esotica è necessaria per cavalcare una cavalcatura acquatica o volante." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-military"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 2000,
			WeightInPounds = 30m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-military", "en"), Language = LanguageCode.En, Name = "Saddle, Military", Description = "A military saddle braces the rider, helping you keep your seat on an active mount in battle. It gives you advantage on any check you make to remain mounted." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-military", "it"), Language = LanguageCode.It, Name = "Sella militare", Description = "Una sella militare sostiene il cavaliere e lo aiuta a restare in sella su una cavalcatura impegnata in battaglia. Conferisce vantaggio alle prove effettuate per non essere disarcionati." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-pack"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 500,
			WeightInPounds = 15m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-pack", "en"), Language = LanguageCode.En, Name = "Saddle, Pack", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-pack", "it"), Language = LanguageCode.It, Name = "Sella da carico", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-riding"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 1000,
			WeightInPounds = 25m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-riding", "en"), Language = LanguageCode.En, Name = "Saddle, Riding", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddle-riding", "it"), Language = LanguageCode.It, Name = "Sella da galoppo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddlebags"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 400,
			WeightInPounds = 8m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddlebags", "en"), Language = LanguageCode.En, Name = "Saddlebags", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "saddlebags", "it"), Language = LanguageCode.It, Name = "Bisacce", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sled"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 2000,
			WeightInPounds = 300m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sled", "en"), Language = LanguageCode.En, Name = "Sled", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sled", "it"), Language = LanguageCode.It, Name = "Slitta", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "stabling-1-day"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 50,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "stabling-1-day", "en"), Language = LanguageCode.En, Name = "Stabling (1 day)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "stabling-1-day", "it"), Language = LanguageCode.It, Name = "Stallaggio (al giorno)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "wagon"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = 3500,
			WeightInPounds = 400m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "wagon", "en"), Language = LanguageCode.En, Name = "Wagon", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "wagon", "it"), Language = LanguageCode.It, Name = "Carro", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "galley"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Ship,
			CostInCopper = 3000000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "galley", "en"), Language = LanguageCode.En, Name = "Galley", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "galley", "it"), Language = LanguageCode.It, Name = "Galea", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "keelboat"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Ship,
			CostInCopper = 300000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "keelboat", "en"), Language = LanguageCode.En, Name = "Keelboat", Description = "Keelboats and rowboats are used on lakes and rivers. If going downstream, add the speed of the current (typically 3 miles per hour) to the speed of the vehicle. These vehicles can't be rowed against any significant current, but they can be pulled upstream by draft animals on the shores. A rowboat weighs 100 pounds, in case adventurers carry it over land." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "keelboat", "it"), Language = LanguageCode.It, Name = "Barcone", Description = "Barconi e barche a remi navigano su laghi e fiumi. Seguendo la corrente, alla velocità del veicolo si aggiunge quella della corrente (di solito 4,5 km/h). Questi veicoli non possono essere spinti a remi contro una corrente significativa, ma possono essere trainati controcorrente da animali sulla riva. Una barca a remi pesa 50 kg, nel caso gli avventurieri debbano trasportarla via terra." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "longship"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Ship,
			CostInCopper = 1000000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "longship", "en"), Language = LanguageCode.En, Name = "Longship", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "longship", "it"), Language = LanguageCode.It, Name = "Nave lunga", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rowboat"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Ship,
			CostInCopper = 5000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 1.5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rowboat", "en"), Language = LanguageCode.En, Name = "Rowboat", Description = "Keelboats and rowboats are used on lakes and rivers. If going downstream, add the speed of the current (typically 3 miles per hour) to the speed of the vehicle. These vehicles can't be rowed against any significant current, but they can be pulled upstream by draft animals on the shores. A rowboat weighs 100 pounds, in case adventurers carry it over land." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rowboat", "it"), Language = LanguageCode.It, Name = "Barca a remi", Description = "Barconi e barche a remi navigano su laghi e fiumi. Seguendo la corrente, alla velocità del veicolo si aggiunge quella della corrente (di solito 4,5 km/h). Questi veicoli non possono essere spinti a remi contro una corrente significativa, ma possono essere trainati controcorrente da animali sulla riva. Una barca a remi pesa 50 kg, nel caso gli avventurieri debbano trasportarla via terra." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sailing-ship"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Ship,
			CostInCopper = 1000000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sailing-ship", "en"), Language = LanguageCode.En, Name = "Sailing ship", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sailing-ship", "it"), Language = LanguageCode.It, Name = "Nave a vela", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "warship"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Ship,
			CostInCopper = 2500000,
			WeightInPounds = null,
			SpeedInMilesPerHour = 2.5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "warship", "en"), Language = LanguageCode.En, Name = "Warship", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "warship", "it"), Language = LanguageCode.It, Name = "Nave da guerra", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "barding"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TackAndVehicle,
			CostInCopper = null,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "barding", "en"), Language = LanguageCode.En, Name = "Barding", Description = "Barding is armor designed to protect an animal's head, neck, chest, and body. Any type of armor shown on the Armor table can be purchased as barding. The cost is four times the equivalent armor made for humanoids, and it weighs twice as much." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "barding", "it"), Language = LanguageCode.It, Name = "Bardatura", Description = "La bardatura è un'armatura progettata per proteggere la testa, il collo, il petto e il corpo di un animale. Ogni tipo di armatura della tabella delle armature può essere acquistato come bardatura, al quadruplo del costo dell'armatura equivalente per umanoidi e con il doppio del peso." }
			}
		};
	}
}
