using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.EquipmentData;

///	<summary>
///	Weapons (2014 ruleset). Statistics and English text from the SRD 5.1 (CC BY 4.0), checked against the Player's Handbook;
///	the Italian texts are RealmForge translations that use the official Italian names.
///	</summary>
public static class Weapons2014Seeder
{
	public static IEnumerable<Equipment> Build()
	{
		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "club"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 10,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d4",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Light },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "club", "en"), Language = LanguageCode.En, Name = "Club", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "club", "it"), Language = LanguageCode.It, Name = "Randello", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dagger"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 200,
			WeightInPounds = 1m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d4",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Finesse, WeaponProperty.Light, WeaponProperty.Thrown },
			NormalRange = 20,
			LongRange = 60,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dagger", "en"), Language = LanguageCode.En, Name = "Dagger", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dagger", "it"), Language = LanguageCode.It, Name = "Pugnale", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "greatclub"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 20,
			WeightInPounds = 10m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.TwoHanded },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "greatclub", "en"), Language = LanguageCode.En, Name = "Greatclub", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "greatclub", "it"), Language = LanguageCode.It, Name = "Randello pesante", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "handaxe"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 500,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Light, WeaponProperty.Thrown },
			NormalRange = 20,
			LongRange = 60,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "handaxe", "en"), Language = LanguageCode.En, Name = "Handaxe", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "handaxe", "it"), Language = LanguageCode.It, Name = "Ascia", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "javelin"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 50,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Thrown },
			NormalRange = 30,
			LongRange = 120,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "javelin", "en"), Language = LanguageCode.En, Name = "Javelin", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "javelin", "it"), Language = LanguageCode.It, Name = "Giavellotto", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "light-hammer"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 200,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d4",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Light, WeaponProperty.Thrown },
			NormalRange = 20,
			LongRange = 60,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "light-hammer", "en"), Language = LanguageCode.En, Name = "Light hammer", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "light-hammer", "it"), Language = LanguageCode.It, Name = "Martello leggero", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mace"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 500,
			WeightInPounds = 4m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty>(),
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mace", "en"), Language = LanguageCode.En, Name = "Mace", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mace", "it"), Language = LanguageCode.It, Name = "Mazza", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "quarterstaff"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 20,
			WeightInPounds = 4m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Bludgeoning,
			VersatileDamageDice = "1d8",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Versatile },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "quarterstaff", "en"), Language = LanguageCode.En, Name = "Quarterstaff", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "quarterstaff", "it"), Language = LanguageCode.It, Name = "Bastone ferrato", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sickle"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 100,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d4",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Light },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sickle", "en"), Language = LanguageCode.En, Name = "Sickle", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sickle", "it"), Language = LanguageCode.It, Name = "Falcetto", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spear"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 100,
			WeightInPounds = 3m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Piercing,
			VersatileDamageDice = "1d8",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Thrown, WeaponProperty.Versatile },
			NormalRange = 20,
			LongRange = 60,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spear", "en"), Language = LanguageCode.En, Name = "Spear", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spear", "it"), Language = LanguageCode.It, Name = "Lancia", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-light"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 2500,
			WeightInPounds = 5m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Ranged,
			DamageDice = "1d8",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Ammunition, WeaponProperty.Loading, WeaponProperty.TwoHanded },
			NormalRange = 80,
			LongRange = 320,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-light", "en"), Language = LanguageCode.En, Name = "Crossbow, light", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-light", "it"), Language = LanguageCode.It, Name = "Balestra leggera", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dart"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 5,
			WeightInPounds = 0.25m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Ranged,
			DamageDice = "1d4",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Finesse, WeaponProperty.Thrown },
			NormalRange = 20,
			LongRange = 60,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dart", "en"), Language = LanguageCode.En, Name = "Dart", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dart", "it"), Language = LanguageCode.It, Name = "Dardo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shortbow"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 2500,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Ranged,
			DamageDice = "1d6",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Ammunition, WeaponProperty.TwoHanded },
			NormalRange = 80,
			LongRange = 320,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shortbow", "en"), Language = LanguageCode.En, Name = "Shortbow", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shortbow", "it"), Language = LanguageCode.It, Name = "Arco corto", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sling"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 10,
			WeightInPounds = null,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Ranged,
			DamageDice = "1d4",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Ammunition },
			NormalRange = 30,
			LongRange = 120,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sling", "en"), Language = LanguageCode.En, Name = "Sling", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sling", "it"), Language = LanguageCode.It, Name = "Fionda", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "battleaxe"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1000,
			WeightInPounds = 4m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Slashing,
			VersatileDamageDice = "1d10",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Versatile },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "battleaxe", "en"), Language = LanguageCode.En, Name = "Battleaxe", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "battleaxe", "it"), Language = LanguageCode.It, Name = "Ascia da battaglia", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "flail"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1000,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty>(),
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "flail", "en"), Language = LanguageCode.En, Name = "Flail", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "flail", "it"), Language = LanguageCode.It, Name = "Mazzafrusto", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "glaive"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 2000,
			WeightInPounds = 6m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d10",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.Reach, WeaponProperty.TwoHanded },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "glaive", "en"), Language = LanguageCode.En, Name = "Glaive", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "glaive", "it"), Language = LanguageCode.It, Name = "Falcione", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "greataxe"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 3000,
			WeightInPounds = 7m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d12",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.TwoHanded },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "greataxe", "en"), Language = LanguageCode.En, Name = "Greataxe", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "greataxe", "it"), Language = LanguageCode.It, Name = "Ascia bipenne", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "greatsword"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 5000,
			WeightInPounds = 6m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "2d6",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.TwoHanded },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "greatsword", "en"), Language = LanguageCode.En, Name = "Greatsword", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "greatsword", "it"), Language = LanguageCode.It, Name = "Spadone", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "halberd"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 2000,
			WeightInPounds = 6m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d10",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.Reach, WeaponProperty.TwoHanded },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "halberd", "en"), Language = LanguageCode.En, Name = "Halberd", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "halberd", "it"), Language = LanguageCode.It, Name = "Alabarda", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lance"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1000,
			WeightInPounds = 6m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d12",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Reach, WeaponProperty.Special },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lance", "en"), Language = LanguageCode.En, Name = "Lance", Description = "You have disadvantage when you use a lance to attack a target within 5 feet of you. Also, a lance requires two hands to wield when you aren't mounted." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lance", "it"), Language = LanguageCode.It, Name = "Lancia da cavaliere", Description = "Chi usa una lancia da cavaliere per attaccare un bersaglio entro 1,5 metri subisce svantaggio al tiro per colpire. Inoltre, quando non si è in sella, la lancia da cavaliere va impugnata a due mani." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "longsword"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1500,
			WeightInPounds = 3m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Slashing,
			VersatileDamageDice = "1d10",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Versatile },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "longsword", "en"), Language = LanguageCode.En, Name = "Longsword", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "longsword", "it"), Language = LanguageCode.It, Name = "Spada lunga", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "maul"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1000,
			WeightInPounds = 10m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "2d6",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.TwoHanded },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "maul", "en"), Language = LanguageCode.En, Name = "Maul", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "maul", "it"), Language = LanguageCode.It, Name = "Maglio", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "morningstar"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1500,
			WeightInPounds = 4m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty>(),
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "morningstar", "en"), Language = LanguageCode.En, Name = "Morningstar", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "morningstar", "it"), Language = LanguageCode.It, Name = "Morning star", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pike"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 500,
			WeightInPounds = 18m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d10",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.Reach, WeaponProperty.TwoHanded },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pike", "en"), Language = LanguageCode.En, Name = "Pike", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pike", "it"), Language = LanguageCode.It, Name = "Picca", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rapier"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 2500,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Finesse },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rapier", "en"), Language = LanguageCode.En, Name = "Rapier", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rapier", "it"), Language = LanguageCode.It, Name = "Stocco", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scimitar"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 2500,
			WeightInPounds = 3m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Finesse, WeaponProperty.Light },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scimitar", "en"), Language = LanguageCode.En, Name = "Scimitar", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scimitar", "it"), Language = LanguageCode.It, Name = "Scimitarra", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shortsword"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1000,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Finesse, WeaponProperty.Light },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shortsword", "en"), Language = LanguageCode.En, Name = "Shortsword", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shortsword", "it"), Language = LanguageCode.It, Name = "Spada corta", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trident"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 500,
			WeightInPounds = 4m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Piercing,
			VersatileDamageDice = "1d8",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Thrown, WeaponProperty.Versatile },
			NormalRange = 20,
			LongRange = 60,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trident", "en"), Language = LanguageCode.En, Name = "Trident", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trident", "it"), Language = LanguageCode.It, Name = "Tridente", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "war-pick"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 500,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty>(),
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "war-pick", "en"), Language = LanguageCode.En, Name = "War pick", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "war-pick", "it"), Language = LanguageCode.It, Name = "Piccone da guerra", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "warhammer"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1500,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Bludgeoning,
			VersatileDamageDice = "1d10",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Versatile },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "warhammer", "en"), Language = LanguageCode.En, Name = "Warhammer", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "warhammer", "it"), Language = LanguageCode.It, Name = "Martello da guerra", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "whip"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 200,
			WeightInPounds = 3m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d4",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Finesse, WeaponProperty.Reach },
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "whip", "en"), Language = LanguageCode.En, Name = "Whip", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "whip", "it"), Language = LanguageCode.It, Name = "Frusta", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "blowgun"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1000,
			WeightInPounds = 1m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Ranged,
			DamageDice = "1",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Ammunition, WeaponProperty.Loading },
			NormalRange = 25,
			LongRange = 100,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "blowgun", "en"), Language = LanguageCode.En, Name = "Blowgun", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "blowgun", "it"), Language = LanguageCode.It, Name = "Cerbottana", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-hand"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 7500,
			WeightInPounds = 3m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Ranged,
			DamageDice = "1d6",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Ammunition, WeaponProperty.Light, WeaponProperty.Loading },
			NormalRange = 30,
			LongRange = 120,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-hand", "en"), Language = LanguageCode.En, Name = "Crossbow, hand", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-hand", "it"), Language = LanguageCode.It, Name = "Balestra a mano", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-heavy"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 5000,
			WeightInPounds = 18m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Ranged,
			DamageDice = "1d10",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Ammunition, WeaponProperty.Heavy, WeaponProperty.Loading, WeaponProperty.TwoHanded },
			NormalRange = 100,
			LongRange = 400,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-heavy", "en"), Language = LanguageCode.En, Name = "Crossbow, heavy", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-heavy", "it"), Language = LanguageCode.It, Name = "Balestra pesante", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "longbow"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 5000,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Ranged,
			DamageDice = "1d8",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Ammunition, WeaponProperty.Heavy, WeaponProperty.TwoHanded },
			NormalRange = 150,
			LongRange = 600,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "longbow", "en"), Language = LanguageCode.En, Name = "Longbow", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "longbow", "it"), Language = LanguageCode.It, Name = "Arco lungo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "net"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 100,
			WeightInPounds = 3m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Ranged,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Thrown, WeaponProperty.Special },
			NormalRange = 5,
			LongRange = 15,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "net", "en"), Language = LanguageCode.En, Name = "Net", Description = "A Large or smaller creature hit by a net is restrained until it is freed. A net has no effect on creatures that are formless, or creatures that are Huge or larger. A creature can use its action to make a DC 10 Strength check, freeing itself or another creature within its reach on a success. Dealing 5 slashing damage to the net (AC 10) also frees the creature without harming it, ending the effect and destroying the net. When you use an action, bonus action, or reaction to attack with a net, you can make only one attack regardless of the number of attacks you can normally make." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "net", "it"), Language = LanguageCode.It, Name = "Rete", Description = "Una creatura di taglia Grande o inferiore colpita da una rete è trattenuta finché non viene liberata. La rete non ha effetto sulle creature prive di forma o di taglia Enorme o superiore. Una creatura può usare la propria azione per effettuare una prova di Forza con CD 10 e, se la supera, libera se stessa o un'altra creatura alla sua portata. Infliggere 5 danni taglienti alla rete (CA 10) libera la creatura senza ferirla, pone fine all'effetto e distrugge la rete.\n\nQuando usa un'azione, un'azione bonus o una reazione per attaccare con una rete, il personaggio può effettuare un solo attacco, a prescindere dal numero di attacchi che potrebbe effettuare normalmente." }
			}
		};
	}
}
