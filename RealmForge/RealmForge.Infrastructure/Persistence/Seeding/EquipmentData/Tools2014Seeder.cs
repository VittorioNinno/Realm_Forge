using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.EquipmentData;

///	<summary>
///	Tools (2014 ruleset). Statistics and English text from the SRD 5.1 (CC BY 4.0), checked against the Player's Handbook;
///	the Italian texts are RealmForge translations that use the official Italian names.
///	</summary>
public static class Tools2014Seeder
{
	public static IEnumerable<Equipment> Build()
	{
		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "disguise-kit"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2500,
			WeightInPounds = 3m,
			ToolCategory = ToolCategory.OtherTool,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "disguise-kit", "en"), Language = LanguageCode.En, Name = "Disguise Kit", Description = "This pouch of cosmetics, hair dye, and small props lets you create disguises that change your physical appearance. Proficiency with this kit lets you add your proficiency bonus to any ability checks you make to create a visual disguise." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "disguise-kit", "it"), Language = LanguageCode.It, Name = "Trucchi per il camuffamento", Description = "Questa borsa di cosmetici, tinture per capelli e piccoli oggetti di scena permette di creare travestimenti che cambiano l'aspetto fisico. La competenza in questi strumenti permette di sommare il bonus di competenza alle prove di caratteristica effettuate per creare un travestimento visivo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "forgery-kit"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1500,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.OtherTool,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "forgery-kit", "en"), Language = LanguageCode.En, Name = "Forgery Kit", Description = "This small box contains a variety of papers and parchments, pens and inks, seals and sealing wax, gold and silver leaf, and other supplies necessary to create convincing forgeries of physical documents. Proficiency with this kit lets you add your proficiency bonus to any ability checks you make to create a physical forgery of a document." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "forgery-kit", "it"), Language = LanguageCode.It, Name = "Arnesi da falsario", Description = "Questa piccola scatola contiene carte e pergamene di vario tipo, penne e inchiostri, sigilli e ceralacca, foglia d'oro e d'argento e altro materiale necessario per creare falsi convincenti di documenti. La competenza in questi strumenti permette di sommare il bonus di competenza alle prove di caratteristica effettuate per falsificare un documento." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "herbalism-kit"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 500,
			WeightInPounds = 3m,
			ToolCategory = ToolCategory.OtherTool,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "herbalism-kit", "en"), Language = LanguageCode.En, Name = "Herbalism Kit", Description = "This kit contains a variety of instruments such as clippers, mortar and pestle, and pouches and vials used by herbalists to create remedies and potions. Proficiency with this kit lets you add your proficiency bonus to any ability checks you make to identify or apply herbs. Also, proficiency with this kit is required to create antitoxin and potions of healing." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "herbalism-kit", "it"), Language = LanguageCode.It, Name = "Borsa da erborista", Description = "Questo kit contiene vari strumenti, come cesoie, mortaio e pestello, sacchetti e fiale, usati dagli erboristi per preparare rimedi e pozioni. La competenza in questi strumenti permette di sommare il bonus di competenza alle prove di caratteristica effettuate per identificare o applicare le erbe; inoltre è necessaria per preparare l'antitossina e le pozioni di guarigione." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "poisoners-kit"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 5000,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.OtherTool,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "poisoners-kit", "en"), Language = LanguageCode.En, Name = "Poisoner's Kit", Description = "A poisoner's kit includes the vials, chemicals, and other equipment necessary for the creation of poisons. Proficiency with this kit lets you add your proficiency bonus to any ability checks you make to craft or use poisons." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "poisoners-kit", "it"), Language = LanguageCode.It, Name = "Sostanze da avvelenatore", Description = "Questo kit comprende le fiale, le sostanze chimiche e le altre attrezzature necessarie per creare veleni. La competenza in questi strumenti permette di sommare il bonus di competenza alle prove di caratteristica effettuate per creare o usare veleni." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "alchemists-supplies"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 5000,
			WeightInPounds = 8m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "alchemists-supplies", "en"), Language = LanguageCode.En, Name = "Alchemist's Supplies", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "alchemists-supplies", "it"), Language = LanguageCode.It, Name = "Scorte da alchimista", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "brewers-supplies"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2000,
			WeightInPounds = 9m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "brewers-supplies", "en"), Language = LanguageCode.En, Name = "Brewer's Supplies", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "brewers-supplies", "it"), Language = LanguageCode.It, Name = "Scorte da mescitore", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "calligraphers-supplies"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1000,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "calligraphers-supplies", "en"), Language = LanguageCode.En, Name = "Calligrapher's Supplies", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "calligraphers-supplies", "it"), Language = LanguageCode.It, Name = "Scorte da calligrafo", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "carpenters-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 800,
			WeightInPounds = 6m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "carpenters-tools", "en"), Language = LanguageCode.En, Name = "Carpenter's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "carpenters-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da falegname", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cartographers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1500,
			WeightInPounds = 6m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cartographers-tools", "en"), Language = LanguageCode.En, Name = "Cartographer's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cartographers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da cartografo", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cobblers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 500,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cobblers-tools", "en"), Language = LanguageCode.En, Name = "Cobbler's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cobblers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da calzolaio", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cooks-utensils"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 100,
			WeightInPounds = 8m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cooks-utensils", "en"), Language = LanguageCode.En, Name = "Cook's utensils", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "cooks-utensils", "it"), Language = LanguageCode.It, Name = "Utensili da cuoco", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "glassblowers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 3000,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "glassblowers-tools", "en"), Language = LanguageCode.En, Name = "Glassblower's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "glassblowers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da soffiatore", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "jewelers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2500,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "jewelers-tools", "en"), Language = LanguageCode.En, Name = "Jeweler's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "jewelers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da gioielliere", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "leatherworkers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 500,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "leatherworkers-tools", "en"), Language = LanguageCode.En, Name = "Leatherworker's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "leatherworkers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da conciatore", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "masons-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1000,
			WeightInPounds = 8m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "masons-tools", "en"), Language = LanguageCode.En, Name = "Mason's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "masons-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da costruttore", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "painters-supplies"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1000,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "painters-supplies", "en"), Language = LanguageCode.En, Name = "Painter's Supplies", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "painters-supplies", "it"), Language = LanguageCode.It, Name = "Strumenti da pittore", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "potters-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1000,
			WeightInPounds = 3m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "potters-tools", "en"), Language = LanguageCode.En, Name = "Potter's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "potters-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da vasaio", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "smiths-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2000,
			WeightInPounds = 8m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "smiths-tools", "en"), Language = LanguageCode.En, Name = "Smith's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "smiths-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da fabbro", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "tinkers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 5000,
			WeightInPounds = 10m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "tinkers-tools", "en"), Language = LanguageCode.En, Name = "Tinker's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "tinkers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da inventore", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "weavers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 100,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "weavers-tools", "en"), Language = LanguageCode.En, Name = "Weaver's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "weavers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da tessitore", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "woodcarvers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 100,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "woodcarvers-tools", "en"), Language = LanguageCode.En, Name = "Woodcarver's Tools", Description = "These special tools include the items needed to pursue a craft or trade, each type providing items related to a single craft. Proficiency with a set of artisan's tools lets you add your proficiency bonus to any ability checks you make using the tools in your craft. Each type of artisan's tools requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "woodcarvers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da intagliatore", Description = "Questi strumenti speciali comprendono tutto il necessario per esercitare un mestiere o un'arte; ogni tipo riguarda un solo mestiere. La competenza in un set di strumenti da artigiano permette di sommare il bonus di competenza alle prove di caratteristica effettuate usando gli strumenti del proprio mestiere. Ogni tipo di strumenti da artigiano richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dice-set"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 10,
			WeightInPounds = null,
			ToolCategory = ToolCategory.GamingSet,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dice-set", "en"), Language = LanguageCode.En, Name = "Dice Set", Description = "This item encompasses a wide range of game pieces, including dice and decks of cards (for games such as Three-Dragon Ante); other kinds of gaming sets exist as well. If you are proficient with a gaming set, you can add your proficiency bonus to ability checks you make to play a game with that set. Each type of gaming set requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dice-set", "it"), Language = LanguageCode.It, Name = "Dadi", Description = "Questa voce comprende un'ampia varietà di accessori da gioco, tra cui dadi e mazzi di carte (per giochi come Tre Draghi al Buio); esistono anche altri tipi di giochi. Chi è competente in un gioco può sommare il bonus di competenza alle prove di caratteristica effettuate per giocare con quel gioco. Ogni tipo di gioco richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "playing-card-set"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 50,
			WeightInPounds = null,
			ToolCategory = ToolCategory.GamingSet,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "playing-card-set", "en"), Language = LanguageCode.En, Name = "Playing Card Set", Description = "This item encompasses a wide range of game pieces, including dice and decks of cards (for games such as Three-Dragon Ante); other kinds of gaming sets exist as well. If you are proficient with a gaming set, you can add your proficiency bonus to ability checks you make to play a game with that set. Each type of gaming set requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "playing-card-set", "it"), Language = LanguageCode.It, Name = "Mazzo di carte", Description = "Questa voce comprende un'ampia varietà di accessori da gioco, tra cui dadi e mazzi di carte (per giochi come Tre Draghi al Buio); esistono anche altri tipi di giochi. Chi è competente in un gioco può sommare il bonus di competenza alle prove di caratteristica effettuate per giocare con quel gioco. Ogni tipo di gioco richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bagpipes"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 3000,
			WeightInPounds = 6m,
			ToolCategory = ToolCategory.MusicalInstrument,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bagpipes", "en"), Language = LanguageCode.En, Name = "Bagpipes", Description = "If you have proficiency with a given musical instrument, you can add your proficiency bonus to any ability checks you make to play music with the instrument. A bard can use a musical instrument as a spellcasting focus. Each type of musical instrument requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bagpipes", "it"), Language = LanguageCode.It, Name = "Cornamusa", Description = "Chi è competente in uno strumento musicale può sommare il bonus di competenza alle prove di caratteristica effettuate per suonare con quello strumento. Un bardo può usare uno strumento musicale come focus da incantatore. Ogni tipo di strumento musicale richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "drum"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 600,
			WeightInPounds = 3m,
			ToolCategory = ToolCategory.MusicalInstrument,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "drum", "en"), Language = LanguageCode.En, Name = "Drum", Description = "If you have proficiency with a given musical instrument, you can add your proficiency bonus to any ability checks you make to play music with the instrument. A bard can use a musical instrument as a spellcasting focus. Each type of musical instrument requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "drum", "it"), Language = LanguageCode.It, Name = "Tamburo", Description = "Chi è competente in uno strumento musicale può sommare il bonus di competenza alle prove di caratteristica effettuate per suonare con quello strumento. Un bardo può usare uno strumento musicale come focus da incantatore. Ogni tipo di strumento musicale richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dulcimer"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2500,
			WeightInPounds = 10m,
			ToolCategory = ToolCategory.MusicalInstrument,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dulcimer", "en"), Language = LanguageCode.En, Name = "Dulcimer", Description = "If you have proficiency with a given musical instrument, you can add your proficiency bonus to any ability checks you make to play music with the instrument. A bard can use a musical instrument as a spellcasting focus. Each type of musical instrument requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dulcimer", "it"), Language = LanguageCode.It, Name = "Dulcimer", Description = "Chi è competente in uno strumento musicale può sommare il bonus di competenza alle prove di caratteristica effettuate per suonare con quello strumento. Un bardo può usare uno strumento musicale come focus da incantatore. Ogni tipo di strumento musicale richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "flute"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 200,
			WeightInPounds = 1m,
			ToolCategory = ToolCategory.MusicalInstrument,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "flute", "en"), Language = LanguageCode.En, Name = "Flute", Description = "If you have proficiency with a given musical instrument, you can add your proficiency bonus to any ability checks you make to play music with the instrument. A bard can use a musical instrument as a spellcasting focus. Each type of musical instrument requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "flute", "it"), Language = LanguageCode.It, Name = "Flauto", Description = "Chi è competente in uno strumento musicale può sommare il bonus di competenza alle prove di caratteristica effettuate per suonare con quello strumento. Un bardo può usare uno strumento musicale come focus da incantatore. Ogni tipo di strumento musicale richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lute"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 3500,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.MusicalInstrument,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lute", "en"), Language = LanguageCode.En, Name = "Lute", Description = "If you have proficiency with a given musical instrument, you can add your proficiency bonus to any ability checks you make to play music with the instrument. A bard can use a musical instrument as a spellcasting focus. Each type of musical instrument requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lute", "it"), Language = LanguageCode.It, Name = "Liuto", Description = "Chi è competente in uno strumento musicale può sommare il bonus di competenza alle prove di caratteristica effettuate per suonare con quello strumento. Un bardo può usare uno strumento musicale come focus da incantatore. Ogni tipo di strumento musicale richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lyre"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 3000,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.MusicalInstrument,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lyre", "en"), Language = LanguageCode.En, Name = "Lyre", Description = "If you have proficiency with a given musical instrument, you can add your proficiency bonus to any ability checks you make to play music with the instrument. A bard can use a musical instrument as a spellcasting focus. Each type of musical instrument requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lyre", "it"), Language = LanguageCode.It, Name = "Lira", Description = "Chi è competente in uno strumento musicale può sommare il bonus di competenza alle prove di caratteristica effettuate per suonare con quello strumento. Un bardo può usare uno strumento musicale come focus da incantatore. Ogni tipo di strumento musicale richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "horn"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 300,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.MusicalInstrument,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "horn", "en"), Language = LanguageCode.En, Name = "Horn", Description = "If you have proficiency with a given musical instrument, you can add your proficiency bonus to any ability checks you make to play music with the instrument. A bard can use a musical instrument as a spellcasting focus. Each type of musical instrument requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "horn", "it"), Language = LanguageCode.It, Name = "Corno", Description = "Chi è competente in uno strumento musicale può sommare il bonus di competenza alle prove di caratteristica effettuate per suonare con quello strumento. Un bardo può usare uno strumento musicale come focus da incantatore. Ogni tipo di strumento musicale richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pan-flute"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1200,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.MusicalInstrument,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pan-flute", "en"), Language = LanguageCode.En, Name = "Pan flute", Description = "If you have proficiency with a given musical instrument, you can add your proficiency bonus to any ability checks you make to play music with the instrument. A bard can use a musical instrument as a spellcasting focus. Each type of musical instrument requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pan-flute", "it"), Language = LanguageCode.It, Name = "Flauto di Pan", Description = "Chi è competente in uno strumento musicale può sommare il bonus di competenza alle prove di caratteristica effettuate per suonare con quello strumento. Un bardo può usare uno strumento musicale come focus da incantatore. Ogni tipo di strumento musicale richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shawm"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 200,
			WeightInPounds = 1m,
			ToolCategory = ToolCategory.MusicalInstrument,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shawm", "en"), Language = LanguageCode.En, Name = "Shawm", Description = "If you have proficiency with a given musical instrument, you can add your proficiency bonus to any ability checks you make to play music with the instrument. A bard can use a musical instrument as a spellcasting focus. Each type of musical instrument requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shawm", "it"), Language = LanguageCode.It, Name = "Ciaramella", Description = "Chi è competente in uno strumento musicale può sommare il bonus di competenza alle prove di caratteristica effettuate per suonare con quello strumento. Un bardo può usare uno strumento musicale come focus da incantatore. Ogni tipo di strumento musicale richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "viol"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 3000,
			WeightInPounds = 1m,
			ToolCategory = ToolCategory.MusicalInstrument,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "viol", "en"), Language = LanguageCode.En, Name = "Viol", Description = "If you have proficiency with a given musical instrument, you can add your proficiency bonus to any ability checks you make to play music with the instrument. A bard can use a musical instrument as a spellcasting focus. Each type of musical instrument requires a separate proficiency." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "viol", "it"), Language = LanguageCode.It, Name = "Viola", Description = "Chi è competente in uno strumento musicale può sommare il bonus di competenza alle prove di caratteristica effettuate per suonare con quello strumento. Un bardo può usare uno strumento musicale come focus da incantatore. Ogni tipo di strumento musicale richiede una competenza separata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "navigators-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2500,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.OtherTool,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "navigators-tools", "en"), Language = LanguageCode.En, Name = "Navigator's Tools", Description = "This set of instruments is used for navigation at sea. Proficiency with navigator's tools lets you chart a ship's course and follow navigation charts. In addition, these tools allow you to add your proficiency bonus to any ability check you make to avoid getting lost at sea." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "navigators-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da navigatore", Description = "Questo set di strumenti serve per navigare in mare. La competenza negli strumenti da navigatore permette di tracciare la rotta di una nave e di seguire le carte nautiche; inoltre permette di sommare il bonus di competenza alle prove di caratteristica effettuate per non perdersi in mare." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "thieves-tools"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2500,
			WeightInPounds = 1m,
			ToolCategory = ToolCategory.OtherTool,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "thieves-tools", "en"), Language = LanguageCode.En, Name = "Thieves' Tools", Description = "This set of tools includes a small file, a set of lock picks, a small mirror mounted on a metal handle, a set of narrow-bladed scissors, and a pair of pliers. Proficiency with these tools lets you add your proficiency bonus to any ability checks you make to disarm traps or open locks." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "thieves-tools", "it"), Language = LanguageCode.It, Name = "Arnesi da scasso", Description = "Questo set comprende una piccola lima, un set di grimaldelli, uno specchietto montato su un manico di metallo, un paio di forbici a lama stretta e un paio di pinze. La competenza in questi strumenti permette di sommare il bonus di competenza alle prove di caratteristica effettuate per disattivare trappole o aprire serrature." }
			}
		};
	}
}
