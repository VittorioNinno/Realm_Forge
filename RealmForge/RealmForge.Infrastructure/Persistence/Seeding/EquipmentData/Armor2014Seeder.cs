using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.EquipmentData;

///	<summary>
///	Armor and shields (2014 ruleset). Statistics and English text from the SRD 5.1 (CC BY 4.0), checked against the Player's Handbook;
///	the Italian texts are RealmForge translations that use the official Italian names.
///	</summary>
public static class Armor2014Seeder
{
	public static IEnumerable<Equipment> Build()
	{
		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "padded-armor"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 500,
			WeightInPounds = 8m,
			ArmorCategory = ArmorCategory.Light,
			ArmorClass = 11,
			ArmorAddsDexterity = true,
			StealthDisadvantage = true,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "padded-armor", "en"), Language = LanguageCode.En, Name = "Padded Armor", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "padded-armor", "it"), Language = LanguageCode.It, Name = "Armatura imbottita", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "leather-armor"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 1000,
			WeightInPounds = 10m,
			ArmorCategory = ArmorCategory.Light,
			ArmorClass = 11,
			ArmorAddsDexterity = true,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "leather-armor", "en"), Language = LanguageCode.En, Name = "Leather Armor", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "leather-armor", "it"), Language = LanguageCode.It, Name = "Armatura di cuoio", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "studded-leather-armor"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 4500,
			WeightInPounds = 13m,
			ArmorCategory = ArmorCategory.Light,
			ArmorClass = 12,
			ArmorAddsDexterity = true,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "studded-leather-armor", "en"), Language = LanguageCode.En, Name = "Studded Leather Armor", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "studded-leather-armor", "it"), Language = LanguageCode.It, Name = "Armatura di cuoio borchiato", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hide-armor"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 1000,
			WeightInPounds = 12m,
			ArmorCategory = ArmorCategory.Medium,
			ArmorClass = 12,
			ArmorAddsDexterity = true,
			ArmorMaxDexterityBonus = 2,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hide-armor", "en"), Language = LanguageCode.En, Name = "Hide Armor", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hide-armor", "it"), Language = LanguageCode.It, Name = "Armatura di pelle", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chain-shirt"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 5000,
			WeightInPounds = 20m,
			ArmorCategory = ArmorCategory.Medium,
			ArmorClass = 13,
			ArmorAddsDexterity = true,
			ArmorMaxDexterityBonus = 2,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chain-shirt", "en"), Language = LanguageCode.En, Name = "Chain Shirt", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chain-shirt", "it"), Language = LanguageCode.It, Name = "Giaco di maglia", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scale-mail"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 5000,
			WeightInPounds = 45m,
			ArmorCategory = ArmorCategory.Medium,
			ArmorClass = 14,
			ArmorAddsDexterity = true,
			ArmorMaxDexterityBonus = 2,
			StealthDisadvantage = true,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scale-mail", "en"), Language = LanguageCode.En, Name = "Scale Mail", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scale-mail", "it"), Language = LanguageCode.It, Name = "Corazza di scaglie", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "breastplate"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 40000,
			WeightInPounds = 20m,
			ArmorCategory = ArmorCategory.Medium,
			ArmorClass = 14,
			ArmorAddsDexterity = true,
			ArmorMaxDexterityBonus = 2,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "breastplate", "en"), Language = LanguageCode.En, Name = "Breastplate", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "breastplate", "it"), Language = LanguageCode.It, Name = "Corazza di piastre", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "half-plate-armor"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 75000,
			WeightInPounds = 40m,
			ArmorCategory = ArmorCategory.Medium,
			ArmorClass = 15,
			ArmorAddsDexterity = true,
			ArmorMaxDexterityBonus = 2,
			StealthDisadvantage = true,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "half-plate-armor", "en"), Language = LanguageCode.En, Name = "Half Plate Armor", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "half-plate-armor", "it"), Language = LanguageCode.It, Name = "Mezza armatura", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ring-mail"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 3000,
			WeightInPounds = 40m,
			ArmorCategory = ArmorCategory.Heavy,
			ArmorClass = 14,
			ArmorAddsDexterity = false,
			StealthDisadvantage = true,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ring-mail", "en"), Language = LanguageCode.En, Name = "Ring Mail", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ring-mail", "it"), Language = LanguageCode.It, Name = "Corazza ad anelli", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chain-mail"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 7500,
			WeightInPounds = 55m,
			ArmorCategory = ArmorCategory.Heavy,
			ArmorClass = 16,
			ArmorAddsDexterity = false,
			StrengthRequirement = 13,
			StealthDisadvantage = true,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chain-mail", "en"), Language = LanguageCode.En, Name = "Chain Mail", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chain-mail", "it"), Language = LanguageCode.It, Name = "Cotta di maglia", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "splint-armor"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 20000,
			WeightInPounds = 60m,
			ArmorCategory = ArmorCategory.Heavy,
			ArmorClass = 17,
			ArmorAddsDexterity = false,
			StrengthRequirement = 15,
			StealthDisadvantage = true,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "splint-armor", "en"), Language = LanguageCode.En, Name = "Splint Armor", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "splint-armor", "it"), Language = LanguageCode.It, Name = "Corazza a strisce", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "plate-armor"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 150000,
			WeightInPounds = 65m,
			ArmorCategory = ArmorCategory.Heavy,
			ArmorClass = 18,
			ArmorAddsDexterity = false,
			StrengthRequirement = 15,
			StealthDisadvantage = true,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "plate-armor", "en"), Language = LanguageCode.En, Name = "Plate Armor", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "plate-armor", "it"), Language = LanguageCode.It, Name = "Armatura completa", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shield"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Armor,
			CostInCopper = 1000,
			WeightInPounds = 6m,
			ArmorCategory = ArmorCategory.Shield,
			ArmorClass = 2,
			ArmorAddsDexterity = false,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shield", "en"), Language = LanguageCode.En, Name = "Shield", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shield", "it"), Language = LanguageCode.It, Name = "Scudo", Description = "" }
			}
		};
	}
}
