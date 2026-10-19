using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.EquipmentData;

///	<summary>
///	Weapons (2024 ruleset). Statistics and English text from the SRD 5.2 (CC BY 4.0), checked against the Player's Handbook;
///	the Italian texts are RealmForge translations that use the official Italian names.
///	</summary>
public static class Weapons2024Seeder
{
	public static IEnumerable<Equipment> Build()
	{
		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "battleaxe"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1000,
			WeightInPounds = 4m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Slashing,
			VersatileDamageDice = "1d10",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Versatile },
			Mastery = WeaponMastery.Topple,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "battleaxe", "en"), Language = LanguageCode.En, Name = "Battleaxe", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "battleaxe", "it"), Language = LanguageCode.It, Name = "Ascia da battaglia", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "blowgun"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Vex,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "blowgun", "en"), Language = LanguageCode.En, Name = "Blowgun", Description = "Ammunition: Needles." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "blowgun", "it"), Language = LanguageCode.It, Name = "Cerbottana", Description = "Munizioni: aghi." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "club"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 10,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d4",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Light },
			Mastery = WeaponMastery.Slow,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "club", "en"), Language = LanguageCode.En, Name = "Club", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "club", "it"), Language = LanguageCode.It, Name = "Randello", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dagger"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Nick,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dagger", "en"), Language = LanguageCode.En, Name = "Dagger", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dagger", "it"), Language = LanguageCode.It, Name = "Pugnale", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dart"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Vex,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dart", "en"), Language = LanguageCode.En, Name = "Dart", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dart", "it"), Language = LanguageCode.It, Name = "Dardo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "flail"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1000,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty>(),
			Mastery = WeaponMastery.Sap,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "flail", "en"), Language = LanguageCode.En, Name = "Flail", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "flail", "it"), Language = LanguageCode.It, Name = "Mazzafrusto", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "glaive"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 2000,
			WeightInPounds = 6m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d10",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.Reach, WeaponProperty.TwoHanded },
			Mastery = WeaponMastery.Graze,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "glaive", "en"), Language = LanguageCode.En, Name = "Glaive", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "glaive", "it"), Language = LanguageCode.It, Name = "Falcione", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "greataxe"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 3000,
			WeightInPounds = 7m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d12",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.TwoHanded },
			Mastery = WeaponMastery.Cleave,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "greataxe", "en"), Language = LanguageCode.En, Name = "Greataxe", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "greataxe", "it"), Language = LanguageCode.It, Name = "Ascia bipenne", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "greatclub"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 20,
			WeightInPounds = 10m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.TwoHanded },
			Mastery = WeaponMastery.Push,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "greatclub", "en"), Language = LanguageCode.En, Name = "Greatclub", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "greatclub", "it"), Language = LanguageCode.It, Name = "Randello pesante", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "greatsword"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 5000,
			WeightInPounds = 6m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "2d6",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.TwoHanded },
			Mastery = WeaponMastery.Graze,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "greatsword", "en"), Language = LanguageCode.En, Name = "Greatsword", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "greatsword", "it"), Language = LanguageCode.It, Name = "Spadone", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "halberd"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 2000,
			WeightInPounds = 6m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d10",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.Reach, WeaponProperty.TwoHanded },
			Mastery = WeaponMastery.Cleave,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "halberd", "en"), Language = LanguageCode.En, Name = "Halberd", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "halberd", "it"), Language = LanguageCode.It, Name = "Alabarda", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "hand-crossbow"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Vex,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "hand-crossbow", "en"), Language = LanguageCode.En, Name = "Hand Crossbow", Description = "Ammunition: Bolts." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "hand-crossbow", "it"), Language = LanguageCode.It, Name = "Balestra a mano", Description = "Munizioni: quadrelli." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "handaxe"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Vex,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "handaxe", "en"), Language = LanguageCode.En, Name = "Handaxe", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "handaxe", "it"), Language = LanguageCode.It, Name = "Ascia", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "heavy-crossbow"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Push,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "heavy-crossbow", "en"), Language = LanguageCode.En, Name = "Heavy Crossbow", Description = "Ammunition: Bolts." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "heavy-crossbow", "it"), Language = LanguageCode.It, Name = "Balestra pesante", Description = "Munizioni: quadrelli." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "javelin"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Slow,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "javelin", "en"), Language = LanguageCode.En, Name = "Javelin", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "javelin", "it"), Language = LanguageCode.It, Name = "Giavellotto", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lance"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1000,
			WeightInPounds = 6m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d10",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.Reach, WeaponProperty.TwoHanded },
			Mastery = WeaponMastery.Topple,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lance", "en"), Language = LanguageCode.En, Name = "Lance", Description = "The Lance requires two hands to wield when you aren't mounted." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lance", "it"), Language = LanguageCode.It, Name = "Lancia da cavaliere", Description = "Quando non si è in sella, la lancia da cavaliere va impugnata a due mani." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "light-crossbow"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Slow,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "light-crossbow", "en"), Language = LanguageCode.En, Name = "Light Crossbow", Description = "Ammunition: Bolts." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "light-crossbow", "it"), Language = LanguageCode.It, Name = "Balestra leggera", Description = "Munizioni: quadrelli." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "light-hammer"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Nick,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "light-hammer", "en"), Language = LanguageCode.En, Name = "Light Hammer", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "light-hammer", "it"), Language = LanguageCode.It, Name = "Martello leggero", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "longbow"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Slow,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "longbow", "en"), Language = LanguageCode.En, Name = "Longbow", Description = "Ammunition: Arrows." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "longbow", "it"), Language = LanguageCode.It, Name = "Arco lungo", Description = "Munizioni: frecce." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "longsword"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1500,
			WeightInPounds = 3m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Slashing,
			VersatileDamageDice = "1d10",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Versatile },
			Mastery = WeaponMastery.Sap,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "longsword", "en"), Language = LanguageCode.En, Name = "Longsword", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "longsword", "it"), Language = LanguageCode.It, Name = "Spada lunga", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mace"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 500,
			WeightInPounds = 4m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty>(),
			Mastery = WeaponMastery.Sap,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mace", "en"), Language = LanguageCode.En, Name = "Mace", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "mace", "it"), Language = LanguageCode.It, Name = "Mazza", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "maul"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1000,
			WeightInPounds = 10m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "2d6",
			DamageType = DamageType.Bludgeoning,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.TwoHanded },
			Mastery = WeaponMastery.Topple,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "maul", "en"), Language = LanguageCode.En, Name = "Maul", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "maul", "it"), Language = LanguageCode.It, Name = "Maglio", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "morningstar"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1500,
			WeightInPounds = 4m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty>(),
			Mastery = WeaponMastery.Sap,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "morningstar", "en"), Language = LanguageCode.En, Name = "Morningstar", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "morningstar", "it"), Language = LanguageCode.It, Name = "Mazza chiodata", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "musket"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 50000,
			WeightInPounds = 10m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Ranged,
			DamageDice = "1d12",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Ammunition, WeaponProperty.Loading, WeaponProperty.TwoHanded },
			NormalRange = 40,
			LongRange = 120,
			Mastery = WeaponMastery.Slow,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "musket", "en"), Language = LanguageCode.En, Name = "Musket", Description = "Ammunition: Firearm Bullets." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "musket", "it"), Language = LanguageCode.It, Name = "Moschetto", Description = "Munizioni: proiettili per armi da fuoco." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pike"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 500,
			WeightInPounds = 18m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d10",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Heavy, WeaponProperty.Reach, WeaponProperty.TwoHanded },
			Mastery = WeaponMastery.Push,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pike", "en"), Language = LanguageCode.En, Name = "Pike", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pike", "it"), Language = LanguageCode.It, Name = "Picca", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pistol"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 25000,
			WeightInPounds = 3m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Ranged,
			DamageDice = "1d10",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Ammunition, WeaponProperty.Loading },
			NormalRange = 30,
			LongRange = 90,
			Mastery = WeaponMastery.Vex,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pistol", "en"), Language = LanguageCode.En, Name = "Pistol", Description = "Ammunition: Firearm Bullets." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pistol", "it"), Language = LanguageCode.It, Name = "Pistola", Description = "Munizioni: proiettili per armi da fuoco." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "quarterstaff"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 20,
			WeightInPounds = 4m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Bludgeoning,
			VersatileDamageDice = "1d8",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Versatile },
			Mastery = WeaponMastery.Topple,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "quarterstaff", "en"), Language = LanguageCode.En, Name = "Quarterstaff", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "quarterstaff", "it"), Language = LanguageCode.It, Name = "Bastone ferrato", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rapier"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 2500,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Finesse },
			Mastery = WeaponMastery.Vex,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rapier", "en"), Language = LanguageCode.En, Name = "Rapier", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "rapier", "it"), Language = LanguageCode.It, Name = "Stocco", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "scimitar"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 2500,
			WeightInPounds = 3m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Finesse, WeaponProperty.Light },
			Mastery = WeaponMastery.Nick,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "scimitar", "en"), Language = LanguageCode.En, Name = "Scimitar", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "scimitar", "it"), Language = LanguageCode.It, Name = "Scimitarra", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shortbow"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Vex,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shortbow", "en"), Language = LanguageCode.En, Name = "Shortbow", Description = "Ammunition: Arrows." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shortbow", "it"), Language = LanguageCode.It, Name = "Arco corto", Description = "Munizioni: frecce." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shortsword"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1000,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d6",
			DamageType = DamageType.Piercing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Finesse, WeaponProperty.Light },
			Mastery = WeaponMastery.Vex,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shortsword", "en"), Language = LanguageCode.En, Name = "Shortsword", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shortsword", "it"), Language = LanguageCode.It, Name = "Spada corta", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sickle"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 100,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Simple,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d4",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Light },
			Mastery = WeaponMastery.Nick,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sickle", "en"), Language = LanguageCode.En, Name = "Sickle", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sickle", "it"), Language = LanguageCode.It, Name = "Falcetto", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sling"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Slow,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sling", "en"), Language = LanguageCode.En, Name = "Sling", Description = "Ammunition: Sling Bullets." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "sling", "it"), Language = LanguageCode.It, Name = "Fionda", Description = "Munizioni: proiettili da fionda." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spear"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
			Mastery = WeaponMastery.Sap,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spear", "en"), Language = LanguageCode.En, Name = "Spear", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "spear", "it"), Language = LanguageCode.It, Name = "Lancia", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "trident"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 500,
			WeightInPounds = 4m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Piercing,
			VersatileDamageDice = "1d10",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Thrown, WeaponProperty.Versatile },
			NormalRange = 20,
			LongRange = 60,
			Mastery = WeaponMastery.Topple,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "trident", "en"), Language = LanguageCode.En, Name = "Trident", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "trident", "it"), Language = LanguageCode.It, Name = "Tridente", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "warhammer"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 1500,
			WeightInPounds = 5m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Bludgeoning,
			VersatileDamageDice = "1d10",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Versatile },
			Mastery = WeaponMastery.Push,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "warhammer", "en"), Language = LanguageCode.En, Name = "Warhammer", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "warhammer", "it"), Language = LanguageCode.It, Name = "Martello da guerra", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "war-pick"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 500,
			WeightInPounds = 2m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d8",
			DamageType = DamageType.Piercing,
			VersatileDamageDice = "1d10",
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Versatile },
			Mastery = WeaponMastery.Sap,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "war-pick", "en"), Language = LanguageCode.En, Name = "War Pick", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "war-pick", "it"), Language = LanguageCode.It, Name = "Piccone da guerra", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "whip"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Weapon,
			CostInCopper = 200,
			WeightInPounds = 3m,
			WeaponCategory = WeaponCategory.Martial,
			WeaponRange = WeaponRange.Melee,
			DamageDice = "1d4",
			DamageType = DamageType.Slashing,
			WeaponProperties = new List<WeaponProperty> { WeaponProperty.Finesse, WeaponProperty.Reach },
			Mastery = WeaponMastery.Slow,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "whip", "en"), Language = LanguageCode.En, Name = "Whip", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "whip", "it"), Language = LanguageCode.It, Name = "Frusta", Description = "" }
			}
		};
	}
}
