using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.EquipmentData;

///	<summary>
///	Tools (2024 ruleset). Statistics and English text from the SRD 5.2 (CC BY 4.0), checked against the Player's Handbook;
///	the Italian texts are RealmForge translations that use the official Italian names.
///	</summary>
public static class Tools2024Seeder
{
	public static IEnumerable<Equipment> Build()
	{
		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "alchemists-supplies"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 5000,
			WeightInPounds = 8m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Intelligence,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "alchemists-supplies", "en"), Language = LanguageCode.En, Name = "Alchemist's Supplies", Description = "**Ability:** Intelligence\n\n**Utilize:** Identify a substance (DC 15), or start a fire (DC 15).\n\n**Craft:** Acid, Alchemist’s Fire, Component Pouch, Oil, Paper, Perfume." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "alchemists-supplies", "it"), Language = LanguageCode.It, Name = "Scorte da alchimista", Description = "**Caratteristica:** Intelligenza\n\n**Utilizzo:** identificare una sostanza (CD 15), oppure accendere un fuoco (CD 15).\n\n**Creazione:** acido, fuoco dell'alchimista, borsa per componenti, olio, carta, profumo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bagpipes"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 3000,
			WeightInPounds = 6m,
			ToolCategory = ToolCategory.MusicalInstrument,
			ToolAbility = AbilityScore.Charisma,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bagpipes", "en"), Language = LanguageCode.En, Name = "Bagpipes", Description = "**Ability:** Charisma\n\n**Utilize:** Play a known tune (DC 10), or improvise a song (DC 15).\n\nA Bard can use a Musical Instrument as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "bagpipes", "it"), Language = LanguageCode.It, Name = "Cornamusa", Description = "**Caratteristica:** Carisma\n\n**Utilizzo:** suonare un brano conosciuto (CD 10), oppure improvvisare una canzone (CD 15).\n\nUn bardo può usare uno strumento musicale come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "brewers-supplies"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2000,
			WeightInPounds = 9m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Intelligence,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "brewers-supplies", "en"), Language = LanguageCode.En, Name = "Brewer's Supplies", Description = "**Ability:** Intelligence\n\n**Utilize:** Detect poisoned drink (DC 15), or identify alcohol (DC 10).\n\n**Craft:** Antitoxin." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "brewers-supplies", "it"), Language = LanguageCode.It, Name = "Scorte da birraio", Description = "**Caratteristica:** Intelligenza\n\n**Utilizzo:** riconoscere una bevanda avvelenata (CD 15), oppure identificare un alcolico (CD 10).\n\n**Creazione:** antitossina." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "calligraphers-supplies"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1000,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Dexterity,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "calligraphers-supplies", "en"), Language = LanguageCode.En, Name = "Calligrapher's Supplies", Description = "**Ability:** Dexterity\n\n**Utilize:** Write text with impressive flourishes that guard against forgery (DC 15).\n\n**Craft:** Ink, Spell Scroll." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "calligraphers-supplies", "it"), Language = LanguageCode.It, Name = "Scorte da calligrafo", Description = "**Caratteristica:** Destrezza\n\n**Utilizzo:** scrivere un testo con svolazzi elaborati che lo proteggono dalle falsificazioni (CD 15).\n\n**Creazione:** inchiostro, pergamena magica." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "carpenters-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 800,
			WeightInPounds = 6m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Strength,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "carpenters-tools", "en"), Language = LanguageCode.En, Name = "Carpenter's Tools", Description = "**Ability:** Strength\n\n**Utilize:** Seal or pry open a door or container (DC 20).\n\n**Craft:** Club, Greatclub, Quarterstaff, Barrel, Chest, Ladder, Pole, Portable Ram, Torch." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "carpenters-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da falegname", Description = "**Caratteristica:** Forza\n\n**Utilizzo:** sigillare o forzare una porta o un contenitore (CD 20).\n\n**Creazione:** randello, randello pesante, bastone ferrato, barile, forziere, scala a pioli, asta, ariete portatile, torcia." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cartographer-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1500,
			WeightInPounds = 6m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Wisdom,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cartographer-tools", "en"), Language = LanguageCode.En, Name = "Cartographer's Tools", Description = "**Ability:** Wisdom\n\n**Utilize:** Draft a map of a small area (DC 15).\n\n**Craft:** Map." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cartographer-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da cartografo", Description = "**Caratteristica:** Saggezza\n\n**Utilizzo:** disegnare la mappa di una piccola area (CD 15).\n\n**Creazione:** mappa." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cobblers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 500,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Dexterity,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cobblers-tools", "en"), Language = LanguageCode.En, Name = "Cobbler's Tools", Description = "**Ability:** Dexterity\n\n**Utilize:** Modify footwear to give Advantage on the wearer’s next Dexterity (Acrobatics) check (DC 10).\n\n**Craft:** Climber’s Kit." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cobblers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da calzolaio", Description = "**Caratteristica:** Destrezza\n\n**Utilizzo:** modificare una calzatura per dare a chi la indossa vantaggio alla sua prossima prova di Destrezza (Acrobazia) (CD 10).\n\n**Creazione:** attrezzi da scalatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cooks-utensils"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 100,
			WeightInPounds = 8m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Wisdom,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cooks-utensils", "en"), Language = LanguageCode.En, Name = "Cook's Utensils", Description = "**Ability:** Wisdom\n\n**Utilize:** Improve food’s flavor (DC 10), or detect spoiled or poisoned food (DC 15).\n\n**Craft:** Rations." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "cooks-utensils", "it"), Language = LanguageCode.It, Name = "Strumenti da cuoco", Description = "**Caratteristica:** Saggezza\n\n**Utilizzo:** migliorare il sapore del cibo (CD 10), oppure riconoscere cibo avariato o avvelenato (CD 15).\n\n**Creazione:** razioni." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dice"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 10,
			WeightInPounds = null,
			ToolCategory = ToolCategory.GamingSet,
			ToolAbility = AbilityScore.Wisdom,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dice", "en"), Language = LanguageCode.En, Name = "Dice", Description = "**Ability:** Wisdom\n\n**Utilize:** Discern whether someone is cheating (DC 10), or win the game (DC 20)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dice", "it"), Language = LanguageCode.It, Name = "Dadi", Description = "**Caratteristica:** Saggezza\n\n**Utilizzo:** capire se qualcuno sta barando (CD 10), oppure vincere la partita (CD 20)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "disguise-kit"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2500,
			WeightInPounds = 3m,
			ToolCategory = ToolCategory.OtherTool,
			ToolAbility = AbilityScore.Charisma,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "disguise-kit", "en"), Language = LanguageCode.En, Name = "Disguise Kit", Description = "**Ability:** Charisma\n\n**Utilize:** Apply makeup (DC 10).\n\n**Craft:** Costume." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "disguise-kit", "it"), Language = LanguageCode.It, Name = "Trucchi per il camuffamento", Description = "**Caratteristica:** Carisma\n\n**Utilizzo:** truccarsi (CD 10).\n\n**Creazione:** costume." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dragonchess"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 100,
			WeightInPounds = null,
			ToolCategory = ToolCategory.GamingSet,
			ToolAbility = AbilityScore.Wisdom,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dragonchess", "en"), Language = LanguageCode.En, Name = "Dragonchess", Description = "**Ability:** Wisdom\n\n**Utilize:** Discern whether someone is cheating (DC 10), or win the game (DC 20)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dragonchess", "it"), Language = LanguageCode.It, Name = "Scacchi dei draghi", Description = "**Caratteristica:** Saggezza\n\n**Utilizzo:** capire se qualcuno sta barando (CD 10), oppure vincere la partita (CD 20)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "drum"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 600,
			WeightInPounds = 3m,
			ToolCategory = ToolCategory.MusicalInstrument,
			ToolAbility = AbilityScore.Charisma,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "drum", "en"), Language = LanguageCode.En, Name = "Drum", Description = "**Ability:** Charisma\n\n**Utilize:** Play a known tune (DC 10), or improvise a song (DC 15).\n\nA Bard can use a Musical Instrument as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "drum", "it"), Language = LanguageCode.It, Name = "Tamburo", Description = "**Caratteristica:** Carisma\n\n**Utilizzo:** suonare un brano conosciuto (CD 10), oppure improvvisare una canzone (CD 15).\n\nUn bardo può usare uno strumento musicale come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dulcimer"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2500,
			WeightInPounds = 10m,
			ToolCategory = ToolCategory.MusicalInstrument,
			ToolAbility = AbilityScore.Charisma,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dulcimer", "en"), Language = LanguageCode.En, Name = "Dulcimer", Description = "**Ability:** Charisma\n\n**Utilize:** Play a known tune (DC 10), or improvise a song (DC 15).\n\nA Bard can use a Musical Instrument as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "dulcimer", "it"), Language = LanguageCode.It, Name = "Dulcimer", Description = "**Caratteristica:** Carisma\n\n**Utilizzo:** suonare un brano conosciuto (CD 10), oppure improvvisare una canzone (CD 15).\n\nUn bardo può usare uno strumento musicale come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "flute"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 200,
			WeightInPounds = 1m,
			ToolCategory = ToolCategory.MusicalInstrument,
			ToolAbility = AbilityScore.Charisma,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "flute", "en"), Language = LanguageCode.En, Name = "Flute", Description = "**Ability:** Charisma\n\n**Utilize:** Play a known tune (DC 10), or improvise a song (DC 15).\n\nA Bard can use a Musical Instrument as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "flute", "it"), Language = LanguageCode.It, Name = "Flauto", Description = "**Caratteristica:** Carisma\n\n**Utilizzo:** suonare un brano conosciuto (CD 10), oppure improvvisare una canzone (CD 15).\n\nUn bardo può usare uno strumento musicale come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "forgery-kit"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1500,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.OtherTool,
			ToolAbility = AbilityScore.Dexterity,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "forgery-kit", "en"), Language = LanguageCode.En, Name = "Forgery Kit", Description = "**Ability:** Dexterity\n\n**Utilize:** Mimic 10 or fewer words of someone else’s handwriting (DC 15), or duplicate a wax seal (DC 20)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "forgery-kit", "it"), Language = LanguageCode.It, Name = "Arnesi da falsario", Description = "**Caratteristica:** Destrezza\n\n**Utilizzo:** imitare la calligrafia di qualcuno per 10 parole o meno (CD 15), oppure duplicare un sigillo di ceralacca (CD 20)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "glassblowers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 3000,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Intelligence,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "glassblowers-tools", "en"), Language = LanguageCode.En, Name = "Glassblower's Tools", Description = "**Ability:** Intelligence\n\n**Utilize:** Discern what a glass object held in the past 24 hours (DC 15).\n\n**Craft:** Glass Bottle, Magnifying Glass, Spyglass, Vial." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "glassblowers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da soffiatore", Description = "**Caratteristica:** Intelligenza\n\n**Utilizzo:** scoprire che cosa ha contenuto un oggetto di vetro nelle ultime 24 ore (CD 15).\n\n**Creazione:** bottiglia di vetro, lente d'ingrandimento, cannocchiale, fiala." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "herbalism-kit"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 500,
			WeightInPounds = 3m,
			ToolCategory = ToolCategory.OtherTool,
			ToolAbility = AbilityScore.Intelligence,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "herbalism-kit", "en"), Language = LanguageCode.En, Name = "Herbalism Kit", Description = "**Ability:** Intelligence\n\n**Utilize:** Identify a plant (DC 10).\n\n**Craft:** Antitoxin, Candle, Healer’s Kit, Potion of Healing." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "herbalism-kit", "it"), Language = LanguageCode.It, Name = "Borsa da erborista", Description = "**Caratteristica:** Intelligenza\n\n**Utilizzo:** identificare una pianta (CD 10).\n\n**Creazione:** antitossina, candela, borsa del guaritore, pozione di guarigione." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "horn"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 300,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.MusicalInstrument,
			ToolAbility = AbilityScore.Charisma,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "horn", "en"), Language = LanguageCode.En, Name = "Horn", Description = "**Ability:** Charisma\n\n**Utilize:** Play a known tune (DC 10), or improvise a song (DC 15).\n\nA Bard can use a Musical Instrument as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "horn", "it"), Language = LanguageCode.It, Name = "Corno", Description = "**Caratteristica:** Carisma\n\n**Utilizzo:** suonare un brano conosciuto (CD 10), oppure improvvisare una canzone (CD 15).\n\nUn bardo può usare uno strumento musicale come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "jewelers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2500,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Intelligence,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "jewelers-tools", "en"), Language = LanguageCode.En, Name = "Jeweler's Tools", Description = "**Ability:** Intelligence\n\n**Utilize:** Discern a gem’s value (DC 15).\n\n**Craft:** Arcane Focus, Holy Symbol." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "jewelers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da gioielliere", Description = "**Caratteristica:** Intelligenza\n\n**Utilizzo:** stabilire il valore di una gemma (CD 15).\n\n**Creazione:** focus arcano, simbolo sacro." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "leatherworkers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 500,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Dexterity,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "leatherworkers-tools", "en"), Language = LanguageCode.En, Name = "Leatherworker's Tools", Description = "**Ability:** Dexterity\n\n**Utilize:** Add a design to a leather item (DC 10).\n\n**Craft:** Sling, Whip, Hide Armor, Leather Armor, Studded Leather Armor, Backpack, Crossbow Bolt Case, Map or Scroll Case, Parchment, Pouch, Quiver, Waterskin." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "leatherworkers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da conciatore", Description = "**Caratteristica:** Destrezza\n\n**Utilizzo:** aggiungere un decoro a un oggetto di cuoio (CD 10).\n\n**Creazione:** fionda, frusta, armatura di pelle, armatura di cuoio, armatura di cuoio borchiato, zaino, custodia per quadrelli da balestra, custodia per mappe o pergamene, pergamena, borsa, faretra, otre." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lute"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 3500,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.MusicalInstrument,
			ToolAbility = AbilityScore.Charisma,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lute", "en"), Language = LanguageCode.En, Name = "Lute", Description = "**Ability:** Charisma\n\n**Utilize:** Play a known tune (DC 10), or improvise a song (DC 15).\n\nA Bard can use a Musical Instrument as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lute", "it"), Language = LanguageCode.It, Name = "Liuto", Description = "**Caratteristica:** Carisma\n\n**Utilizzo:** suonare un brano conosciuto (CD 10), oppure improvvisare una canzone (CD 15).\n\nUn bardo può usare uno strumento musicale come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lyre"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 3000,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.MusicalInstrument,
			ToolAbility = AbilityScore.Charisma,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lyre", "en"), Language = LanguageCode.En, Name = "Lyre", Description = "**Ability:** Charisma\n\n**Utilize:** Play a known tune (DC 10), or improvise a song (DC 15).\n\nA Bard can use a Musical Instrument as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "lyre", "it"), Language = LanguageCode.It, Name = "Lira", Description = "**Caratteristica:** Carisma\n\n**Utilizzo:** suonare un brano conosciuto (CD 10), oppure improvvisare una canzone (CD 15).\n\nUn bardo può usare uno strumento musicale come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "masons-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1000,
			WeightInPounds = 8m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Strength,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "masons-tools", "en"), Language = LanguageCode.En, Name = "Mason's Tools", Description = "**Ability:** Strength\n\n**Utilize:** Chisel a symbol or hole in stone (DC 10).\n\n**Craft:** Block and Tackle." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "masons-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da muratore", Description = "**Caratteristica:** Forza\n\n**Utilizzo:** scolpire un simbolo o praticare un foro nella pietra (CD 10).\n\n**Creazione:** carrucola e paranco." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "navigators-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2500,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.OtherTool,
			ToolAbility = AbilityScore.Wisdom,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "navigators-tools", "en"), Language = LanguageCode.En, Name = "Navigator's Tools", Description = "**Ability:** Wisdom\n\n**Utilize:** Plot a course (DC 10), or determine position by stargazing (DC 15)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "navigators-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da navigatore", Description = "**Caratteristica:** Saggezza\n\n**Utilizzo:** tracciare una rotta (CD 10), oppure determinare la propria posizione osservando le stelle (CD 15)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "painters-supplies"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1000,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Wisdom,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "painters-supplies", "en"), Language = LanguageCode.En, Name = "Painter's Supplies", Description = "**Ability:** Wisdom\n\n**Utilize:** Paint a recognizable image of something you’ve seen (DC 10).\n\n**Craft:** Druidic Focus, Holy Symbol." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "painters-supplies", "it"), Language = LanguageCode.It, Name = "Strumenti da pittore", Description = "**Caratteristica:** Saggezza\n\n**Utilizzo:** dipingere un'immagine riconoscibile di qualcosa che si è visto (CD 10).\n\n**Creazione:** focus druidico, simbolo sacro." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pan-flute"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1200,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.MusicalInstrument,
			ToolAbility = AbilityScore.Charisma,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pan-flute", "en"), Language = LanguageCode.En, Name = "Pan flute", Description = "**Ability:** Charisma\n\n**Utilize:** Play a known tune (DC 10), or improvise a song (DC 15).\n\nA Bard can use a Musical Instrument as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "pan-flute", "it"), Language = LanguageCode.It, Name = "Flauto di pan", Description = "**Caratteristica:** Carisma\n\n**Utilizzo:** suonare un brano conosciuto (CD 10), oppure improvvisare una canzone (CD 15).\n\nUn bardo può usare uno strumento musicale come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "poisoners-kit"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 5000,
			WeightInPounds = 2m,
			ToolCategory = ToolCategory.OtherTool,
			ToolAbility = AbilityScore.Intelligence,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "poisoners-kit", "en"), Language = LanguageCode.En, Name = "Poisoner's Kit", Description = "**Ability:** Intelligence\n\n**Utilize:** Detect a poisoned object (DC 10).\n\n**Craft:** Basic Poison." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "poisoners-kit", "it"), Language = LanguageCode.It, Name = "Sostanze da avvelenatore", Description = "**Caratteristica:** Intelligenza\n\n**Utilizzo:** individuare un oggetto avvelenato (CD 10).\n\n**Creazione:** veleno base." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "playing-cards"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 50,
			WeightInPounds = null,
			ToolCategory = ToolCategory.GamingSet,
			ToolAbility = AbilityScore.Wisdom,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "playing-cards", "en"), Language = LanguageCode.En, Name = "Playing Cards", Description = "**Ability:** Wisdom\n\n**Utilize:** Discern whether someone is cheating (DC 10), or win the game (DC 20)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "playing-cards", "it"), Language = LanguageCode.It, Name = "Carte da gioco", Description = "**Caratteristica:** Saggezza\n\n**Utilizzo:** capire se qualcuno sta barando (CD 10), oppure vincere la partita (CD 20)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "potters-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 1000,
			WeightInPounds = 3m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Intelligence,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "potters-tools", "en"), Language = LanguageCode.En, Name = "Potter's Tools", Description = "**Ability:** Intelligence\n\n**Utilize:** Discern what a ceramic object held in the past 24 hours (DC 15).\n\n**Craft:** Jug, Lamp." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "potters-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da vasaio", Description = "**Caratteristica:** Intelligenza\n\n**Utilizzo:** scoprire che cosa ha contenuto un oggetto di ceramica nelle ultime 24 ore (CD 15).\n\n**Creazione:** brocca, lampada." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shawm"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 200,
			WeightInPounds = 1m,
			ToolCategory = ToolCategory.MusicalInstrument,
			ToolAbility = AbilityScore.Charisma,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shawm", "en"), Language = LanguageCode.En, Name = "Shawm", Description = "**Ability:** Charisma\n\n**Utilize:** Play a known tune (DC 10), or improvise a song (DC 15).\n\nA Bard can use a Musical Instrument as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "shawm", "it"), Language = LanguageCode.It, Name = "Ciaramella", Description = "**Caratteristica:** Carisma\n\n**Utilizzo:** suonare un brano conosciuto (CD 10), oppure improvvisare una canzone (CD 15).\n\nUn bardo può usare uno strumento musicale come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "smiths-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2000,
			WeightInPounds = 8m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Strength,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "smiths-tools", "en"), Language = LanguageCode.En, Name = "Smith's Tools", Description = "**Ability:** Strength\n\n**Utilize:** Pry open a door or container (DC 20).\n\n**Craft:** Any Melee weapon (except Club, Greatclub, Quarterstaff, and Whip), Medium armor (except Hide), Heavy armor, Ball Bearings, Bucket, Caltrops, Chain, Crowbar, Firearm Bullets, Grappling Hook, Iron Pot, Iron Spikes, Sling Bullets." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "smiths-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da fabbro", Description = "**Caratteristica:** Forza\n\n**Utilizzo:** forzare una porta o un contenitore (CD 20).\n\n**Creazione:** qualsiasi arma da mischia (tranne randello, randello pesante, bastone ferrato e frusta), armature medie (tranne l'armatura di pelle), armature pesanti, sfere metalliche, secchio, triboli, catena, piede di porco, proiettili per armi da fuoco, rampino, pentola di ferro, spuntoni di ferro, proiettili da fionda." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "thieves-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 2500,
			WeightInPounds = 1m,
			ToolCategory = ToolCategory.OtherTool,
			ToolAbility = AbilityScore.Dexterity,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "thieves-tools", "en"), Language = LanguageCode.En, Name = "Thieves' Tools", Description = "**Ability:** Dexterity\n\n**Utilize:** Pick a lock (DC 15), or disarm a trap (DC 15)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "thieves-tools", "it"), Language = LanguageCode.It, Name = "Arnesi da scasso", Description = "**Caratteristica:** Destrezza\n\n**Utilizzo:** scassinare una serratura (CD 15), oppure disattivare una trappola (CD 15)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "three-dragon-ante"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 100,
			WeightInPounds = null,
			ToolCategory = ToolCategory.GamingSet,
			ToolAbility = AbilityScore.Wisdom,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "three-dragon-ante", "en"), Language = LanguageCode.En, Name = "Three-Dragon Ante", Description = "**Ability:** Wisdom\n\n**Utilize:** Discern whether someone is cheating (DC 10), or win the game (DC 20)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "three-dragon-ante", "it"), Language = LanguageCode.It, Name = "Tre Draghi al Buio", Description = "**Caratteristica:** Saggezza\n\n**Utilizzo:** capire se qualcuno sta barando (CD 10), oppure vincere la partita (CD 20)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "tinkers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 5000,
			WeightInPounds = 10m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Dexterity,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "tinkers-tools", "en"), Language = LanguageCode.En, Name = "Tinker's Tools", Description = "**Ability:** Dexterity\n\n**Utilize:** Assemble a Tiny item composed of scrap, which falls apart in 1 minute (DC 20).\n\n**Craft:** Musket, Pistol, Bell, Bullseye Lantern, Flask, Hooded Lantern, Hunting Trap, Lock, Manacles, Mirror, Shovel, Signal Whistle, Tinderbox." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "tinkers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da inventore", Description = "**Caratteristica:** Destrezza\n\n**Utilizzo:** assemblare un oggetto Minuscolo fatto di rottami, che si sfascia dopo 1 minuto (CD 20).\n\n**Creazione:** moschetto, pistola, campana, lanterna a lente sporgente, ampolla, lanterna schermabile, tagliola, serratura, manette, specchio, pala, fischietto da richiamo, acciarino con pietra focaia." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "viol"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 3000,
			WeightInPounds = 1m,
			ToolCategory = ToolCategory.MusicalInstrument,
			ToolAbility = AbilityScore.Charisma,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "viol", "en"), Language = LanguageCode.En, Name = "Viol", Description = "**Ability:** Charisma\n\n**Utilize:** Play a known tune (DC 10), or improvise a song (DC 15).\n\nA Bard can use a Musical Instrument as a Spellcasting Focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "viol", "it"), Language = LanguageCode.It, Name = "Viola", Description = "**Caratteristica:** Carisma\n\n**Utilizzo:** suonare un brano conosciuto (CD 10), oppure improvvisare una canzone (CD 15).\n\nUn bardo può usare uno strumento musicale come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "weavers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 100,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Dexterity,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "weavers-tools", "en"), Language = LanguageCode.En, Name = "Weaver's Tools", Description = "**Ability:** Dexterity\n\n**Utilize:** Mend a tear in clothing (DC 10), or sew a Tiny design (DC 10).\n\n**Craft:** Padded Armor, Basket, Bedroll, Blanket, Fine Clothes, Net, Robe, Rope, Sack, String, Tent, Traveler's Clothes." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "weavers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da tessitore", Description = "**Caratteristica:** Destrezza\n\n**Utilizzo:** ricucire uno strappo in un indumento (CD 10), oppure ricamare un piccolo motivo (CD 10).\n\n**Creazione:** armatura imbottita, cesto, giaciglio, coperta, abiti eleganti, rete, tunica, corda, sacco, spago, tenda, abiti da viaggiatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "woodcarvers-tools"),
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Category = EquipmentCategory.Tool,
			CostInCopper = 100,
			WeightInPounds = 5m,
			ToolCategory = ToolCategory.ArtisansTools,
			ToolAbility = AbilityScore.Dexterity,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "woodcarvers-tools", "en"), Language = LanguageCode.En, Name = "Woodcarver's Tools", Description = "**Ability:** Dexterity\n\n**Utilize:** Carve a pattern in wood (DC 10).\n\n**Craft:** Club, Greatclub, Quarterstaff, Ranged weapons (except Pistol, Musket, and Sling), Arcane Focus, Arrows, Bolts, Druidic Focus, Ink Pen, Needles." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "equipment", "woodcarvers-tools", "it"), Language = LanguageCode.It, Name = "Strumenti da intagliatore", Description = "**Caratteristica:** Destrezza\n\n**Utilizzo:** intagliare un motivo nel legno (CD 10).\n\n**Creazione:** randello, randello pesante, bastone ferrato, armi a distanza (tranne pistola, moschetto e fionda), focus arcano, frecce, quadrelli, focus druidico, pennino, aghi." }
			}
		};
	}
}
