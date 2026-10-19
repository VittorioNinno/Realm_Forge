using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.EquipmentData;

///	<summary>
///	Trade goods (2014 ruleset). Statistics and English text from the SRD 5.1 (CC BY 4.0), checked against the Player's Handbook;
///	the Italian texts are RealmForge translations that use the official Italian names.
///	</summary>
public static class TradeGoods2014Seeder
{
	public static IEnumerable<Equipment> Build()
	{
		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-wheat"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 1,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-wheat", "en"), Language = LanguageCode.En, Name = "Wheat (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-wheat", "it"), Language = LanguageCode.It, Name = "Grano (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-flour"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 2,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-flour", "en"), Language = LanguageCode.En, Name = "Flour (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-flour", "it"), Language = LanguageCode.It, Name = "Farina (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-chicken"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 2,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-chicken", "en"), Language = LanguageCode.En, Name = "Chicken", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-chicken", "it"), Language = LanguageCode.It, Name = "Pollo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-salt"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 5,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-salt", "en"), Language = LanguageCode.En, Name = "Salt (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-salt", "it"), Language = LanguageCode.It, Name = "Sale (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-iron"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 10,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-iron", "en"), Language = LanguageCode.En, Name = "Iron (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-iron", "it"), Language = LanguageCode.It, Name = "Ferro (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-canvas"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 10,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-canvas", "en"), Language = LanguageCode.En, Name = "Canvas (1 sq. yd.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-canvas", "it"), Language = LanguageCode.It, Name = "Tela (telo di 90 cm di lato)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-copper"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 50,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-copper", "en"), Language = LanguageCode.En, Name = "Copper (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-copper", "it"), Language = LanguageCode.It, Name = "Rame (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cotton-cloth"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 50,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cotton-cloth", "en"), Language = LanguageCode.En, Name = "Cotton cloth (1 sq. yd.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cotton-cloth", "it"), Language = LanguageCode.It, Name = "Cotone (telo di 90 cm di lato)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-ginger"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 100,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-ginger", "en"), Language = LanguageCode.En, Name = "Ginger (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-ginger", "it"), Language = LanguageCode.It, Name = "Zenzero (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-goat"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 100,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-goat", "en"), Language = LanguageCode.En, Name = "Goat", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-goat", "it"), Language = LanguageCode.It, Name = "Capra", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cinnamon"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 200,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cinnamon", "en"), Language = LanguageCode.En, Name = "Cinnamon (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cinnamon", "it"), Language = LanguageCode.It, Name = "Cannella (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-pepper"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 200,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-pepper", "en"), Language = LanguageCode.En, Name = "Pepper (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-pepper", "it"), Language = LanguageCode.It, Name = "Pepe (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-sheep"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 200,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-sheep", "en"), Language = LanguageCode.En, Name = "Sheep", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-sheep", "it"), Language = LanguageCode.It, Name = "Pecora", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cloves"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 300,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cloves", "en"), Language = LanguageCode.En, Name = "Cloves (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cloves", "it"), Language = LanguageCode.It, Name = "Chiodi di garofano (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-pig"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 300,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-pig", "en"), Language = LanguageCode.En, Name = "Pig", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-pig", "it"), Language = LanguageCode.It, Name = "Maiale", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-silver"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 500,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-silver", "en"), Language = LanguageCode.En, Name = "Silver (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-silver", "it"), Language = LanguageCode.It, Name = "Argento (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-linen"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 500,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-linen", "en"), Language = LanguageCode.En, Name = "Linen (1 sq. yd.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-linen", "it"), Language = LanguageCode.It, Name = "Lino (telo di 90 cm di lato)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-silk"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 1000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-silk", "en"), Language = LanguageCode.En, Name = "Silk (1 sq. yd.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-silk", "it"), Language = LanguageCode.It, Name = "Seta (telo di 90 cm di lato)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cow"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 1000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cow", "en"), Language = LanguageCode.En, Name = "Cow", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-cow", "it"), Language = LanguageCode.It, Name = "Mucca", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-saffron"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 1500,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-saffron", "en"), Language = LanguageCode.En, Name = "Saffron (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-saffron", "it"), Language = LanguageCode.It, Name = "Zafferano (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-ox"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 1500,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-ox", "en"), Language = LanguageCode.En, Name = "Ox", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-ox", "it"), Language = LanguageCode.It, Name = "Bue", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-gold"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 5000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-gold", "en"), Language = LanguageCode.En, Name = "Gold (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-gold", "it"), Language = LanguageCode.It, Name = "Oro (0,5 kg)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-platinum"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.TradeGood,
			CostInCopper = 50000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-platinum", "en"), Language = LanguageCode.En, Name = "Platinum (1 lb.)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "trade-platinum", "it"), Language = LanguageCode.It, Name = "Platino (0,5 kg)", Description = "" }
			}
		};
	}
}
