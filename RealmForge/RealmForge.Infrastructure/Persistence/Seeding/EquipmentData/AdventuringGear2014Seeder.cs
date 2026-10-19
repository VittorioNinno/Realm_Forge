using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.EquipmentData;

///	<summary>
///	Adventuring gear, ammunition, spellcasting focuses and equipment packs (2014 ruleset). Statistics and English text from the SRD 5.1 (CC BY 4.0), checked against the Player's Handbook;
///	the Italian texts are RealmForge translations that use the official Italian names.
///	</summary>
public static class AdventuringGear2014Seeder
{
	public static IEnumerable<Equipment> Build()
	{
		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "abacus"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "abacus", "en"), Language = LanguageCode.En, Name = "Abacus", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "abacus", "it"), Language = LanguageCode.It, Name = "Abaco", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "acid-vial"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2500,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "acid-vial", "en"), Language = LanguageCode.En, Name = "Acid (vial)", Description = "As an action, you can splash the contents of this vial onto a creature within 5 feet of you or throw the vial up to 20 feet, shattering it on impact. In either case, make a ranged attack against a creature or object, treating the acid as an improvised weapon.\n\nOn a hit, the target takes 2d6 acid damage." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "acid-vial", "it"), Language = LanguageCode.It, Name = "Acido (fiala)", Description = "Come azione, il personaggio può versare il contenuto di questa fiala su una creatura entro 1,5 metri da sé oppure lanciarla fino a 6 metri, mandandola in frantumi all'impatto. In entrambi i casi effettua un attacco a distanza contro una creatura o un oggetto, considerando l'acido come un'arma improvvisata.\n\nSe colpisce, il bersaglio subisce 2d6 danni da acido." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "alchemists-fire-flask"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5000,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "alchemists-fire-flask", "en"), Language = LanguageCode.En, Name = "Alchemist's fire (flask)", Description = "This sticky, adhesive fluid ignites when exposed to air.\n\nAs an action, you can throw this flask up to 20 feet, shattering it on impact. Make a ranged attack against a creature or object, treating the alchemist's fire as an improvised weapon.\n\nOn a hit, the target takes 1d4 fire damage at the start of each of its turns. A creature can end this damage by using its action to make a DC 10 Dexterity check to extinguish the flames." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "alchemists-fire-flask", "it"), Language = LanguageCode.It, Name = "Fuoco dell'alchimista (ampolla)", Description = "Questo fluido appiccicoso prende fuoco a contatto con l'aria.\n\nCome azione, il personaggio può lanciare l'ampolla fino a 6 metri, mandandola in frantumi all'impatto. Effettua un attacco a distanza contro una creatura o un oggetto, considerando il fuoco dell'alchimista come un'arma improvvisata.\n\nSe colpisce, il bersaglio subisce 1d4 danni da fuoco all'inizio di ognuno dei suoi turni. Una creatura può porre fine a questi danni usando la propria azione per effettuare una prova di Destrezza con CD 10 e spegnere le fiamme." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "arrow"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Ammunition,
			CostInCopper = 100,
			WeightInPounds = 1m,
			Quantity = 20,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "arrow", "en"), Language = LanguageCode.En, Name = "Arrow", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "arrow", "it"), Language = LanguageCode.It, Name = "Frecce (20)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "blowgun-needle"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Ammunition,
			CostInCopper = 100,
			WeightInPounds = 1m,
			Quantity = 50,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "blowgun-needle", "en"), Language = LanguageCode.En, Name = "Blowgun needle", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "blowgun-needle", "it"), Language = LanguageCode.It, Name = "Aghi da cerbottana (50)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-bolt"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Ammunition,
			CostInCopper = 100,
			WeightInPounds = 1.5m,
			Quantity = 20,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-bolt", "en"), Language = LanguageCode.En, Name = "Crossbow bolt", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crossbow-bolt", "it"), Language = LanguageCode.It, Name = "Quadrelli da balestra (20)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sling-bullet"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.Ammunition,
			CostInCopper = 4,
			WeightInPounds = 1.5m,
			Quantity = 20,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sling-bullet", "en"), Language = LanguageCode.En, Name = "Sling bullet", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sling-bullet", "it"), Language = LanguageCode.It, Name = "Proiettili da fionda (20)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "amulet"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 500,
			WeightInPounds = 1m,
			FocusType = FocusType.HolySymbol,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "amulet", "en"), Language = LanguageCode.En, Name = "Amulet", Description = "A holy symbol is a representation of a god or pantheon. It might be an amulet depicting a symbol representing a deity, the same symbol carefully engraved or inlaid as an emblem on a shield, or a tiny box holding a fragment of a sacred relic.\n\nA cleric or paladin can use a holy symbol as a spellcasting focus. To use the symbol in this way, the caster must hold it in hand, wear it visibly, or bear it on a shield." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "amulet", "it"), Language = LanguageCode.It, Name = "Amuleto", Description = "Un simbolo sacro rappresenta un dio o un pantheon. Può essere un amuleto con il simbolo di una divinità, lo stesso simbolo inciso o intarsiato come emblema su uno scudo, oppure un piccolo scrigno che custodisce il frammento di una reliquia sacra.\n\nUn chierico o un paladino può usare un simbolo sacro come focus da incantatore. Per farlo, deve tenerlo in mano, indossarlo in modo visibile oppure portarlo su uno scudo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "antitoxin-vial"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "antitoxin-vial", "en"), Language = LanguageCode.En, Name = "Antitoxin (vial)", Description = "A creature that drinks this vial of liquid gains advantage on saving throws against poison for 1 hour. It confers no benefit to undead or constructs." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "antitoxin-vial", "it"), Language = LanguageCode.It, Name = "Antitossina (fiala)", Description = "Una creatura che beve il liquido di questa fiala dispone di vantaggio ai tiri salvezza contro il veleno per 1 ora. Non ha alcun effetto su non morti e costrutti." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crystal"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 1000,
			WeightInPounds = 1m,
			FocusType = FocusType.Arcane,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crystal", "en"), Language = LanguageCode.En, Name = "Crystal", Description = "An arcane focus is a special item--an orb, a crystal, a rod, a specially constructed staff, a wand-like length of wood, or some similar item--designed to channel the power of arcane spells. A sorcerer, warlock, or wizard can use such an item as a spellcasting focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crystal", "it"), Language = LanguageCode.It, Name = "Cristallo", Description = "Un focus arcano è un oggetto speciale (un globo, un cristallo, una verga, un bastone appositamente costruito, una bacchetta di legno o qualcosa di simile) progettato per incanalare il potere degli incantesimi arcani. Uno stregone, un warlock o un mago può usarlo come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "orb"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 2000,
			WeightInPounds = 3m,
			FocusType = FocusType.Arcane,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "orb", "en"), Language = LanguageCode.En, Name = "Orb", Description = "An arcane focus is a special item--an orb, a crystal, a rod, a specially constructed staff, a wand-like length of wood, or some similar item--designed to channel the power of arcane spells. A sorcerer, warlock, or wizard can use such an item as a spellcasting focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "orb", "it"), Language = LanguageCode.It, Name = "Globo", Description = "Un focus arcano è un oggetto speciale (un globo, un cristallo, una verga, un bastone appositamente costruito, una bacchetta di legno o qualcosa di simile) progettato per incanalare il potere degli incantesimi arcani. Uno stregone, un warlock o un mago può usarlo come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rod"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 1000,
			WeightInPounds = 2m,
			FocusType = FocusType.Arcane,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rod", "en"), Language = LanguageCode.En, Name = "Rod", Description = "An arcane focus is a special item--an orb, a crystal, a rod, a specially constructed staff, a wand-like length of wood, or some similar item--designed to channel the power of arcane spells. A sorcerer, warlock, or wizard can use such an item as a spellcasting focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rod", "it"), Language = LanguageCode.It, Name = "Verga", Description = "Un focus arcano è un oggetto speciale (un globo, un cristallo, una verga, un bastone appositamente costruito, una bacchetta di legno o qualcosa di simile) progettato per incanalare il potere degli incantesimi arcani. Uno stregone, un warlock o un mago può usarlo come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "staff"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 500,
			WeightInPounds = 4m,
			FocusType = FocusType.Arcane,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "staff", "en"), Language = LanguageCode.En, Name = "Staff", Description = "An arcane focus is a special item--an orb, a crystal, a rod, a specially constructed staff, a wand-like length of wood, or some similar item--designed to channel the power of arcane spells. A sorcerer, warlock, or wizard can use such an item as a spellcasting focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "staff", "it"), Language = LanguageCode.It, Name = "Bastone", Description = "Un focus arcano è un oggetto speciale (un globo, un cristallo, una verga, un bastone appositamente costruito, una bacchetta di legno o qualcosa di simile) progettato per incanalare il potere degli incantesimi arcani. Uno stregone, un warlock o un mago può usarlo come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "wand"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 1000,
			WeightInPounds = 1m,
			FocusType = FocusType.Arcane,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "wand", "en"), Language = LanguageCode.En, Name = "Wand", Description = "An arcane focus is a special item--an orb, a crystal, a rod, a specially constructed staff, a wand-like length of wood, or some similar item--designed to channel the power of arcane spells. A sorcerer, warlock, or wizard can use such an item as a spellcasting focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "wand", "it"), Language = LanguageCode.It, Name = "Bacchetta", Description = "Un focus arcano è un oggetto speciale (un globo, un cristallo, una verga, un bastone appositamente costruito, una bacchetta di legno o qualcosa di simile) progettato per incanalare il potere degli incantesimi arcani. Uno stregone, un warlock o un mago può usarlo come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "backpack"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "backpack", "en"), Language = LanguageCode.En, Name = "Backpack", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "backpack", "it"), Language = LanguageCode.It, Name = "Zaino", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ball-bearings-bag-of-1000"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ball-bearings-bag-of-1000", "en"), Language = LanguageCode.En, Name = "Ball bearings (bag of 1,000)", Description = "As an action, you can spill these tiny metal balls from their pouch to cover a level, square area that is 10 feet on a side.\n\nA creature moving across the covered area must succeed on a DC 10 Dexterity saving throw or fall prone.\n\nA creature moving through the area at half speed doesn't need to make the save." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ball-bearings-bag-of-1000", "it"), Language = LanguageCode.It, Name = "Sfere metalliche (sacchetto da 1.000)", Description = "Come azione, il personaggio può spargere queste minuscole sfere di metallo dal loro sacchetto per coprire un'area piana quadrata di 3 metri di lato.\n\nUna creatura che attraversa l'area deve superare un tiro salvezza su Destrezza con CD 10, altrimenti cade a terra prona.\n\nUna creatura che attraversa l'area a velocità dimezzata non deve effettuare il tiro salvezza." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "barrel"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 70m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "barrel", "en"), Language = LanguageCode.En, Name = "Barrel", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "barrel", "it"), Language = LanguageCode.It, Name = "Barile", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "basket"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 40,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "basket", "en"), Language = LanguageCode.En, Name = "Basket", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "basket", "it"), Language = LanguageCode.It, Name = "Canestro", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bedroll"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 7m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bedroll", "en"), Language = LanguageCode.En, Name = "Bedroll", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bedroll", "it"), Language = LanguageCode.It, Name = "Giaciglio", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bell"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bell", "en"), Language = LanguageCode.En, Name = "Bell", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bell", "it"), Language = LanguageCode.It, Name = "Campanella", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "blanket"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "blanket", "en"), Language = LanguageCode.En, Name = "Blanket", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "blanket", "it"), Language = LanguageCode.It, Name = "Coperta", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "block-and-tackle"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "block-and-tackle", "en"), Language = LanguageCode.En, Name = "Block and tackle", Description = "A set of pulleys with a cable threaded through them and a hook to attach to objects, a block and tackle allows you to hoist up to four times the weight you can normally lift." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "block-and-tackle", "it"), Language = LanguageCode.It, Name = "Carrucola e paranco", Description = "Un insieme di pulegge con un cavo e un gancio per agganciare gli oggetti: la carrucola con paranco permette di sollevare fino a quattro volte il peso che il personaggio potrebbe sollevare normalmente." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "book"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2500,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "book", "en"), Language = LanguageCode.En, Name = "Book", Description = "A book might contain poetry, historical accounts, information pertaining to a particular field of lore, diagrams and notes on gnomish contraptions, or just about anything else that can be represented using text or pictures. A book of spells is a spellbook (described later in this section)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "book", "it"), Language = LanguageCode.It, Name = "Libro", Description = "Un libro può contenere poesie, cronache storiche, informazioni su un particolare campo del sapere, schemi e appunti su marchingegni gnomeschi o quasi qualsiasi altra cosa si possa rappresentare con testi o immagini. Un libro di incantesimi è un libro degli incantesimi (descritto più avanti)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bottle-glass"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bottle-glass", "en"), Language = LanguageCode.En, Name = "Bottle, glass", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bottle-glass", "it"), Language = LanguageCode.It, Name = "Bottiglia di vetro", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bucket"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bucket", "en"), Language = LanguageCode.En, Name = "Bucket", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "bucket", "it"), Language = LanguageCode.It, Name = "Secchio", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "caltrops"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "caltrops", "en"), Language = LanguageCode.En, Name = "Caltrops", Description = "As an action, you can spread a bag of caltrops to cover a square area that is 5 feet on a side.\n\nAny creature that enters the area must succeed on a DC 15 Dexterity saving throw or stop moving this turn and take 1 piercing damage.\n\nTaking this damage reduces the creature's walking speed by 10 feet until the creature regains at least 1 hit point.\n\nA creature moving through the area at half speed doesn't need to make the save." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "caltrops", "it"), Language = LanguageCode.It, Name = "Triboli (sacchetto da 20)", Description = "Come azione, il personaggio può spargere un sacchetto di triboli per coprire un'area quadrata di 1,5 metri di lato.\n\nUna creatura che entra nell'area deve superare un tiro salvezza su Destrezza con CD 15, altrimenti smette di muoversi per quel turno e subisce 1 danno perforante.\n\nQuesti danni riducono la velocità base della creatura di 3 metri finché non recupera almeno 1 punto ferita.\n\nUna creatura che attraversa l'area a velocità dimezzata non deve effettuare il tiro salvezza." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "candle"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "candle", "en"), Language = LanguageCode.En, Name = "Candle", Description = "For 1 hour, a candle sheds bright light in a 5-foot radius and dim light for an additional 5 feet." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "candle", "it"), Language = LanguageCode.It, Name = "Candela", Description = "Per 1 ora, una candela proietta luce intensa in un raggio di 1,5 metri e luce fioca per altri 1,5 metri." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "case-crossbow-bolt"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "case-crossbow-bolt", "en"), Language = LanguageCode.En, Name = "Case, crossbow bolt", Description = "This wooden case can hold up to twenty crossbow bolts." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "case-crossbow-bolt", "it"), Language = LanguageCode.It, Name = "Custodia per quadrelli da balestra", Description = "Questa custodia di legno può contenere fino a venti quadrelli da balestra." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "case-map-or-scroll"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "case-map-or-scroll", "en"), Language = LanguageCode.En, Name = "Case, map or scroll", Description = "This cylindrical leather case can hold up to ten rolled-up sheets of paper or five rolled-up sheets of parchment." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "case-map-or-scroll", "it"), Language = LanguageCode.It, Name = "Custodia per mappe o pergamene", Description = "Questa custodia cilindrica di cuoio può contenere fino a dieci fogli di carta o cinque fogli di pergamena arrotolati." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chain-10-feet"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 10m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chain-10-feet", "en"), Language = LanguageCode.En, Name = "Chain (10 feet)", Description = "A chain has 10 hit points. It can be burst with a successful DC 20 Strength check." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chain-10-feet", "it"), Language = LanguageCode.It, Name = "Catena (3 metri)", Description = "Una catena ha 10 punti ferita. Può essere spezzata superando una prova di Forza con CD 20." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chalk-1-piece"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chalk-1-piece", "en"), Language = LanguageCode.En, Name = "Chalk (1 piece)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chalk-1-piece", "it"), Language = LanguageCode.It, Name = "Gessetto (1 pezzo)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chest"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 25m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chest", "en"), Language = LanguageCode.En, Name = "Chest", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "chest", "it"), Language = LanguageCode.It, Name = "Forziere", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-common"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-common", "en"), Language = LanguageCode.En, Name = "Clothes, common", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-common", "it"), Language = LanguageCode.It, Name = "Abito comune", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-costume"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-costume", "en"), Language = LanguageCode.En, Name = "Clothes, costume", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-costume", "it"), Language = LanguageCode.It, Name = "Costume", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-fine"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1500,
			WeightInPounds = 6m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-fine", "en"), Language = LanguageCode.En, Name = "Clothes, fine", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-fine", "it"), Language = LanguageCode.It, Name = "Abito pregiato", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-travelers"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-travelers", "en"), Language = LanguageCode.En, Name = "Clothes, traveler's", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "clothes-travelers", "it"), Language = LanguageCode.It, Name = "Abito da viaggiatore", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "component-pouch"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2500,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "component-pouch", "en"), Language = LanguageCode.En, Name = "Component pouch", Description = "A component pouch is a small, watertight leather belt pouch that has compartments to hold all the material components and other special items you need to cast your spells, except for those components that have a specific cost (as indicated in a spell's description)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "component-pouch", "it"), Language = LanguageCode.It, Name = "Borsa per componenti", Description = "Una borsa per componenti è una piccola borsa da cintura di cuoio, impermeabile, divisa in scomparti che contengono tutte le componenti materiali e gli altri oggetti speciali necessari per lanciare gli incantesimi, tranne le componenti di cui è indicato il costo nella descrizione dell'incantesimo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crowbar"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crowbar", "en"), Language = LanguageCode.En, Name = "Crowbar", Description = "Using a crowbar grants advantage to Strength checks where the crowbar's leverage can be applied." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "crowbar", "it"), Language = LanguageCode.It, Name = "Piede di porco", Description = "Usare un piede di porco conferisce vantaggio alle prove di Forza in cui si può sfruttare la sua leva." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sprig-of-mistletoe"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 100,
			WeightInPounds = null,
			FocusType = FocusType.Druidic,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sprig-of-mistletoe", "en"), Language = LanguageCode.En, Name = "Sprig of mistletoe", Description = "A druidic focus might be a sprig of mistletoe or holly, a wand or scepter made of yew or another special wood, a staff drawn whole out of a living tree, or a totem object incorporating feathers, fur, bones, and teeth from sacred animals. A druid can use such an object as a spellcasting focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sprig-of-mistletoe", "it"), Language = LanguageCode.It, Name = "Rametto di vischio", Description = "Un focus druidico può essere un rametto di vischio o di agrifoglio, una bacchetta o uno scettro di tasso o di un altro legno speciale, un bastone ricavato intero da un albero vivo, oppure un totem fatto di piume, pelliccia, ossa e denti di animali sacri. Un druido può usare un oggetto del genere come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "totem"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 100,
			WeightInPounds = null,
			FocusType = FocusType.Druidic,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "totem", "en"), Language = LanguageCode.En, Name = "Totem", Description = "A druidic focus might be a sprig of mistletoe or holly, a wand or scepter made of yew or another special wood, a staff drawn whole out of a living tree, or a totem object incorporating feathers, fur, bones, and teeth from sacred animals. A druid can use such an object as a spellcasting focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "totem", "it"), Language = LanguageCode.It, Name = "Totem", Description = "Un focus druidico può essere un rametto di vischio o di agrifoglio, una bacchetta o uno scettro di tasso o di un altro legno speciale, un bastone ricavato intero da un albero vivo, oppure un totem fatto di piume, pelliccia, ossa e denti di animali sacri. Un druido può usare un oggetto del genere come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "wooden-staff"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 500,
			WeightInPounds = 4m,
			FocusType = FocusType.Druidic,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "wooden-staff", "en"), Language = LanguageCode.En, Name = "Wooden staff", Description = "A druidic focus might be a sprig of mistletoe or holly, a wand or scepter made of yew or another special wood, a staff drawn whole out of a living tree, or a totem object incorporating feathers, fur, bones, and teeth from sacred animals. A druid can use such an object as a spellcasting focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "wooden-staff", "it"), Language = LanguageCode.It, Name = "Bastone di legno", Description = "Un focus druidico può essere un rametto di vischio o di agrifoglio, una bacchetta o uno scettro di tasso o di un altro legno speciale, un bastone ricavato intero da un albero vivo, oppure un totem fatto di piume, pelliccia, ossa e denti di animali sacri. Un druido può usare un oggetto del genere come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "yew-wand"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 1000,
			WeightInPounds = 1m,
			FocusType = FocusType.Druidic,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "yew-wand", "en"), Language = LanguageCode.En, Name = "Yew wand", Description = "A druidic focus might be a sprig of mistletoe or holly, a wand or scepter made of yew or another special wood, a staff drawn whole out of a living tree, or a totem object incorporating feathers, fur, bones, and teeth from sacred animals. A druid can use such an object as a spellcasting focus." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "yew-wand", "it"), Language = LanguageCode.It, Name = "Bacchetta in legno di tasso", Description = "Un focus druidico può essere un rametto di vischio o di agrifoglio, una bacchetta o uno scettro di tasso o di un altro legno speciale, un bastone ricavato intero da un albero vivo, oppure un totem fatto di piume, pelliccia, ossa e denti di animali sacri. Un druido può usare un oggetto del genere come focus da incantatore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "emblem"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 500,
			WeightInPounds = null,
			FocusType = FocusType.HolySymbol,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "emblem", "en"), Language = LanguageCode.En, Name = "Emblem", Description = "A holy symbol is a representation of a god or pantheon. It might be an amulet depicting a symbol representing a deity, the same symbol carefully engraved or inlaid as an emblem on a shield, or a tiny box holding a fragment of a sacred relic.\n\nA cleric or paladin can use a holy symbol as a spellcasting focus. To use the symbol in this way, the caster must hold it in hand, wear it visibly, or bear it on a shield." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "emblem", "it"), Language = LanguageCode.It, Name = "Emblema", Description = "Un simbolo sacro rappresenta un dio o un pantheon. Può essere un amuleto con il simbolo di una divinità, lo stesso simbolo inciso o intarsiato come emblema su uno scudo, oppure un piccolo scrigno che custodisce il frammento di una reliquia sacra.\n\nUn chierico o un paladino può usare un simbolo sacro come focus da incantatore. Per farlo, deve tenerlo in mano, indossarlo in modo visibile oppure portarlo su uno scudo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "fishing-tackle"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "fishing-tackle", "en"), Language = LanguageCode.En, Name = "Fishing tackle", Description = "This kit includes a wooden rod, silken line, corkwood bobbers, steel hooks, lead sinkers, velvet lures, and narrow netting." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "fishing-tackle", "it"), Language = LanguageCode.It, Name = "Canna da pesca", Description = "Questo kit comprende una canna di legno, una lenza di seta, galleggianti di sughero, ami d'acciaio, piombini, esche di velluto e una piccola rete." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "flask-or-tankard"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "flask-or-tankard", "en"), Language = LanguageCode.En, Name = "Flask or tankard", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "flask-or-tankard", "it"), Language = LanguageCode.It, Name = "Ampolla o boccale", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "grappling-hook"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "grappling-hook", "en"), Language = LanguageCode.En, Name = "Grappling hook", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "grappling-hook", "it"), Language = LanguageCode.It, Name = "Rampino", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hammer"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hammer", "en"), Language = LanguageCode.En, Name = "Hammer", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hammer", "it"), Language = LanguageCode.It, Name = "Martello", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hammer-sledge"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 10m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hammer-sledge", "en"), Language = LanguageCode.En, Name = "Hammer, sledge", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hammer-sledge", "it"), Language = LanguageCode.It, Name = "Martello da demolizione", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "holy-water-flask"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2500,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "holy-water-flask", "en"), Language = LanguageCode.En, Name = "Holy water (flask)", Description = "As an action, you can splash the contents of this flask onto a creature within 5 feet of you or throw it up to 20 feet, shattering it on impact. In either case, make a ranged attack against a target creature, treating the holy water as an improvised weapon.\n\nIf the target is a fiend or undead, it takes 2d6 radiant damage.\n\nA cleric or paladin may create holy water by performing a special ritual.\n\nThe ritual takes 1 hour to perform, uses 25 gp worth of powdered silver, and requires the caster to expend a 1st-level spell slot." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "holy-water-flask", "it"), Language = LanguageCode.It, Name = "Acqua santa (ampolla)", Description = "Come azione, il personaggio può versare il contenuto di questa ampolla su una creatura entro 1,5 metri da sé oppure lanciarla fino a 6 metri, mandandola in frantumi all'impatto. In entrambi i casi effettua un attacco a distanza contro una creatura, considerando l'acqua santa come un'arma improvvisata.\n\nSe il bersaglio è un immondo o un non morto, subisce 2d6 danni radiosi.\n\nUn chierico o un paladino può creare l'acqua santa celebrando un rituale speciale, che richiede 1 ora, consuma polvere d'argento del valore di 25 mo e costa al celebrante uno slot incantesimo di 1° livello." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hourglass"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2500,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hourglass", "en"), Language = LanguageCode.En, Name = "Hourglass", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hourglass", "it"), Language = LanguageCode.It, Name = "Clessidra", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hunting-trap"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 25m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hunting-trap", "en"), Language = LanguageCode.En, Name = "Hunting trap", Description = "When you use your action to set it, this trap forms a saw-toothed steel ring that snaps shut when a creature steps on a pressure plate in the center. The trap is affixed by a heavy chain to an immobile object, such as a tree or a spike driven into the ground.\n\nA creature that steps on the plate must succeed on a DC 13 Dexterity saving throw or take 1d4 piercing damage and stop moving. Thereafter, until the creature breaks free of the trap, its movement is limited by the length of the chain (typically 3 feet long).\n\nA creature can use its action to make a DC 13 Strength check, freeing itself or another creature within its reach on a success. Each failed check deals 1 piercing damage to the trapped creature." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "hunting-trap", "it"), Language = LanguageCode.It, Name = "Tagliola", Description = "Una volta piazzata con un'azione, questa trappola forma un anello d'acciaio dentato che scatta quando una creatura calpesta la piastra a pressione al centro. La trappola è fissata con una pesante catena a un oggetto inamovibile, come un albero o un picchetto piantato nel terreno.\n\nUna creatura che calpesta la piastra deve superare un tiro salvezza su Destrezza con CD 13, altrimenti subisce 1d4 danni perforanti e smette di muoversi. In seguito, finché non si libera, i suoi movimenti sono limitati dalla lunghezza della catena (di solito 90 centimetri).\n\nUna creatura può usare la propria azione per effettuare una prova di Forza con CD 13 e, se la supera, libera se stessa o un'altra creatura alla sua portata. Ogni prova fallita infligge 1 danno perforante alla creatura intrappolata." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ink-1-ounce-bottle"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ink-1-ounce-bottle", "en"), Language = LanguageCode.En, Name = "Ink (1 ounce bottle)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ink-1-ounce-bottle", "it"), Language = LanguageCode.It, Name = "Inchiostro (boccetta da 30 grammi)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ink-pen"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ink-pen", "en"), Language = LanguageCode.En, Name = "Ink pen", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ink-pen", "it"), Language = LanguageCode.It, Name = "Pennino", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "jug-or-pitcher"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2,
			WeightInPounds = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "jug-or-pitcher", "en"), Language = LanguageCode.En, Name = "Jug or pitcher", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "jug-or-pitcher", "it"), Language = LanguageCode.It, Name = "Brocca o caraffa", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "climbers-kit"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2500,
			WeightInPounds = 12m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "climbers-kit", "en"), Language = LanguageCode.En, Name = "Climber's Kit", Description = "A climber's kit includes special pitons, boot tips, gloves, and a harness. You can use the climber's kit as an action to anchor yourself; when you do, you can't fall more than 25 feet from the point where you anchored yourself, and you can't climb more than 25 feet away from that point without undoing the anchor." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "climbers-kit", "it"), Language = LanguageCode.It, Name = "Attrezzi da scalatore", Description = "Gli attrezzi da scalatore comprendono chiodi da roccia speciali, punte per stivali, guanti e un'imbracatura. Con un'azione, il personaggio può usarli per ancorarsi: finché resta ancorato non può cadere per più di 7,5 metri dal punto di ancoraggio, e non può arrampicarsi oltre 7,5 metri da quel punto senza prima sganciarsi." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "healers-kit"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "healers-kit", "en"), Language = LanguageCode.En, Name = "Healer's Kit", Description = "This kit is a leather pouch containing bandages, salves, and splints. The kit has ten uses. As an action, you can expend one use of the kit to stabilize a creature that has 0 hit points, without needing to make a Wisdom (Medicine) check." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "healers-kit", "it"), Language = LanguageCode.It, Name = "Borsa del guaritore", Description = "Questa borsa di cuoio contiene bende, unguenti e stecche. Ha dieci utilizzi. Con un'azione, il personaggio può spenderne uno per stabilizzare una creatura che ha 0 punti ferita, senza dover effettuare una prova di Saggezza (Medicina)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mess-kit"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 20,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mess-kit", "en"), Language = LanguageCode.En, Name = "Mess Kit", Description = "This tin box contains a cup and simple cutlery. The box clamps together, and one side can be used as a cooking pan and the other as a plate or shallow bowl." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mess-kit", "it"), Language = LanguageCode.It, Name = "Gavetta", Description = "Questa scatola di latta contiene una tazza e semplici posate. La scatola si chiude a incastro: una metà può essere usata come padella e l'altra come piatto o ciotola bassa." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ladder-10-foot"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10,
			WeightInPounds = 25m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ladder-10-foot", "en"), Language = LanguageCode.En, Name = "Ladder (10-foot)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ladder-10-foot", "it"), Language = LanguageCode.It, Name = "Scala a pioli (3 metri)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lamp"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lamp", "en"), Language = LanguageCode.En, Name = "Lamp", Description = "A lamp casts bright light in a 15-foot radius and dim light for an additional 30 feet. Once lit, it burns for 6 hours on a flask (1 pint) of oil." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lamp", "it"), Language = LanguageCode.It, Name = "Lampada", Description = "Una lampada proietta luce intensa in un raggio di 4,5 metri e luce fioca per altri 9 metri. Una volta accesa, brucia per 6 ore con un'ampolla (0,5 litri) d'olio." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lantern-bullseye"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1000,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lantern-bullseye", "en"), Language = LanguageCode.En, Name = "Lantern, bullseye", Description = "A bullseye lantern casts bright light in a 60-foot cone and dim light for an additional 60 feet. Once lit, it burns for 6 hours on a flask (1 pint) of oil." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lantern-bullseye", "it"), Language = LanguageCode.It, Name = "Lanterna a lente sporgente", Description = "Una lanterna a lente sporgente proietta luce intensa in un cono di 18 metri e luce fioca per altri 18 metri. Una volta accesa, brucia per 6 ore con un'ampolla (0,5 litri) d'olio." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lantern-hooded"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lantern-hooded", "en"), Language = LanguageCode.En, Name = "Lantern, hooded", Description = "A hooded lantern casts bright light in a 30-foot radius and dim light for an additional 30 feet. Once lit, it burns for 6 hours on a flask (1 pint) of oil. As an action, you can lower the hood, reducing the light to dim light in a 5-foot radius." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lantern-hooded", "it"), Language = LanguageCode.It, Name = "Lanterna schermabile", Description = "Una lanterna schermabile proietta luce intensa in un raggio di 9 metri e luce fioca per altri 9 metri. Una volta accesa, brucia per 6 ore con un'ampolla (0,5 litri) d'olio. Con un'azione, il personaggio può abbassarne lo schermo, riducendo la luce a luce fioca in un raggio di 1,5 metri." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lock"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1000,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lock", "en"), Language = LanguageCode.En, Name = "Lock", Description = "A key is provided with the lock. Without the key, a creature proficient with thieves' tools can pick this lock with a successful DC 15 Dexterity check. Your GM may decide that better locks are available for higher prices." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "lock", "it"), Language = LanguageCode.It, Name = "Serratura", Description = "Insieme alla serratura viene fornita la chiave. Senza la chiave, una creatura competente negli arnesi da scasso può forzarla superando una prova di Destrezza con CD 15. Il DM può decidere che serrature migliori siano disponibili a prezzi più alti." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "magnifying-glass"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "magnifying-glass", "en"), Language = LanguageCode.En, Name = "Magnifying glass", Description = "This lens allows a closer look at small objects. It is also useful as a substitute for flint and steel when starting fires. Lighting a fire with a magnifying glass requires light as bright as sunlight to focus, tinder to ignite, and about 5 minutes for the fire to ignite.\n\nA magnifying glass grants advantage on any ability check made to appraise or inspect an item that is small or highly detailed." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "magnifying-glass", "it"), Language = LanguageCode.It, Name = "Lente d'ingrandimento", Description = "Questa lente permette di osservare da vicino gli oggetti piccoli ed è utile anche al posto di acciarino e pietra focaia per accendere un fuoco: servono una luce intensa come quella del sole da concentrare, dell'esca da incendiare e circa 5 minuti perché il fuoco prenda.\n\nUna lente d'ingrandimento conferisce vantaggio a ogni prova di caratteristica effettuata per valutare o esaminare un oggetto piccolo o ricco di dettagli." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "manacles"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 6m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "manacles", "en"), Language = LanguageCode.En, Name = "Manacles", Description = "These metal restraints can bind a Small or Medium creature. Escaping the manacles requires a successful DC 20 Dexterity check. Breaking them requires a successful DC 20 Strength check.\n\nEach set of manacles comes with one key. Without the key, a creature proficient with thieves' tools can pick the manacles' lock with a successful DC 15 Dexterity check. Manacles have 15 hit points." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "manacles", "it"), Language = LanguageCode.It, Name = "Manette", Description = "Queste manette di metallo possono immobilizzare una creatura di taglia Piccola o Media. Per liberarsene serve una prova di Destrezza con CD 20; per spezzarle, una prova di Forza con CD 20.\n\nOgni paio di manette ha la sua chiave. Senza la chiave, una creatura competente negli arnesi da scasso può forzarne la serratura superando una prova di Destrezza con CD 15. Le manette hanno 15 punti ferita." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mirror-steel"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 0.5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mirror-steel", "en"), Language = LanguageCode.En, Name = "Mirror, steel", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "mirror-steel", "it"), Language = LanguageCode.It, Name = "Specchio piccolo di metallo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "oil-flask"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "oil-flask", "en"), Language = LanguageCode.En, Name = "Oil (flask)", Description = "Oil usually comes in a clay flask that holds 1 pint.\n\nAs an action, you can splash the oil in this flask onto a creature within 5 feet of you or throw it up to 20 feet, shattering it on impact. Make a ranged attack against a target creature or object, treating the oil as an improvised weapon.\n\nOn a hit, the target is covered in oil. If the target takes any fire damage before the oil dries (after 1 minute), the target takes an additional 5 fire damage from the burning oil.\n\nYou can also pour a flask of oil on the ground to cover a 5-foot-square area, provided that the surface is level.\n\nIf lit, the oil burns for 2 rounds and deals 5 fire damage to any creature that enters the area or ends its turn in the area. A creature can take this damage only once per turn." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "oil-flask", "it"), Language = LanguageCode.It, Name = "Olio (ampolla)", Description = "Di solito l'olio è venduto in un'ampolla d'argilla che contiene 0,5 litri.\n\nCome azione, il personaggio può versare l'olio dell'ampolla su una creatura entro 1,5 metri da sé oppure lanciarla fino a 6 metri, mandandola in frantumi all'impatto. Effettua un attacco a distanza contro una creatura o un oggetto, considerando l'olio come un'arma improvvisata.\n\nSe colpisce, il bersaglio è ricoperto d'olio. Se subisce danni da fuoco prima che l'olio si asciughi (dopo 1 minuto), subisce 5 danni da fuoco aggiuntivi a causa dell'olio che brucia.\n\nIl personaggio può anche versare un'ampolla d'olio a terra per coprire un'area quadrata di 1,5 metri di lato, purché la superficie sia piana.\n\nSe viene acceso, l'olio brucia per 2 round e infligge 5 danni da fuoco a ogni creatura che entra nell'area o vi termina il turno. Una creatura può subire questi danni una sola volta per turno." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "paper-one-sheet"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 20,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "paper-one-sheet", "en"), Language = LanguageCode.En, Name = "Paper (one sheet)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "paper-one-sheet", "it"), Language = LanguageCode.It, Name = "Carta (un foglio)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "parchment-one-sheet"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "parchment-one-sheet", "en"), Language = LanguageCode.En, Name = "Parchment (one sheet)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "parchment-one-sheet", "it"), Language = LanguageCode.It, Name = "Pergamena (un foglio)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "perfume-vial"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "perfume-vial", "en"), Language = LanguageCode.En, Name = "Perfume (vial)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "perfume-vial", "it"), Language = LanguageCode.It, Name = "Profumo (fiala)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pick-miners"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 10m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pick-miners", "en"), Language = LanguageCode.En, Name = "Pick, miner's", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pick-miners", "it"), Language = LanguageCode.It, Name = "Piccone da minatore", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "piton"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5,
			WeightInPounds = 0.25m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "piton", "en"), Language = LanguageCode.En, Name = "Piton", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "piton", "it"), Language = LanguageCode.It, Name = "Chiodo da rocciatore", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "poison-basic-vial"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "poison-basic-vial", "en"), Language = LanguageCode.En, Name = "Poison, basic (vial)", Description = "You can use the poison in this vial to coat one slashing or piercing weapon or up to three pieces of ammunition. Applying the poison takes an action. A creature hit by the poisoned weapon or ammunition must make a DC 10 Constitution saving throw or take 1d4 poison damage. Once applied, the poison retains potency for 1 minute before drying." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "poison-basic-vial", "it"), Language = LanguageCode.It, Name = "Veleno base (fiala)", Description = "Il veleno di questa fiala può ricoprire un'arma tagliente o perforante oppure fino a tre munizioni; applicarlo richiede un'azione. Una creatura colpita dall'arma o dalle munizioni avvelenate deve effettuare un tiro salvezza su Costituzione con CD 10, altrimenti subisce 1d4 danni da veleno. Una volta applicato, il veleno resta efficace per 1 minuto, poi si secca." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pole-10-foot"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5,
			WeightInPounds = 7m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pole-10-foot", "en"), Language = LanguageCode.En, Name = "Pole (10-foot)", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pole-10-foot", "it"), Language = LanguageCode.It, Name = "Asta (3 metri)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pot-iron"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 10m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pot-iron", "en"), Language = LanguageCode.En, Name = "Pot, iron", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pot-iron", "it"), Language = LanguageCode.It, Name = "Vaso di ferro", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pouch"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pouch", "en"), Language = LanguageCode.En, Name = "Pouch", Description = "A cloth or leather pouch can hold up to 20 sling bullets or 50 blowgun needles, among other things. A compartmentalized pouch for holding spell components is called a component pouch (described earlier in this section)." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "pouch", "it"), Language = LanguageCode.It, Name = "Borsa", Description = "Una borsa di stoffa o di cuoio può contenere, tra le altre cose, fino a 20 proiettili da fionda o 50 aghi da cerbottana. La borsa con scomparti per le componenti degli incantesimi è la borsa per componenti (descritta in precedenza)." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "quiver"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "quiver", "en"), Language = LanguageCode.En, Name = "Quiver", Description = "A quiver can hold up to 20 arrows." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "quiver", "it"), Language = LanguageCode.It, Name = "Faretra", Description = "Una faretra può contenere fino a 20 frecce." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ram-portable"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 400,
			WeightInPounds = 35m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ram-portable", "en"), Language = LanguageCode.En, Name = "Ram, portable", Description = "You can use a portable ram to break down doors. When doing so, you gain a +4 bonus on the Strength check. One other character can help you use the ram, giving you advantage on this check." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "ram-portable", "it"), Language = LanguageCode.It, Name = "Ariete portatile", Description = "Il personaggio può usare un ariete portatile per sfondare le porte, ottenendo un bonus di +4 alla prova di Forza. Un altro personaggio può aiutarlo a manovrare l'ariete, conferendogli vantaggio alla prova." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rations-1-day"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = 2m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rations-1-day", "en"), Language = LanguageCode.En, Name = "Rations (1 day)", Description = "Rations consist of dry foods suitable for extended travel, including jerky, dried fruit, hardtack, and nuts." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rations-1-day", "it"), Language = LanguageCode.It, Name = "Razioni (1 giornata)", Description = "Le razioni sono cibi secchi adatti ai lunghi viaggi: carne essiccata, frutta secca, gallette e frutta a guscio." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "reliquary"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.SpellcastingFocus,
			CostInCopper = 500,
			WeightInPounds = 2m,
			FocusType = FocusType.HolySymbol,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "reliquary", "en"), Language = LanguageCode.En, Name = "Reliquary", Description = "A holy symbol is a representation of a god or pantheon. It might be an amulet depicting a symbol representing a deity, the same symbol carefully engraved or inlaid as an emblem on a shield, or a tiny box holding a fragment of a sacred relic.\n\nA cleric or paladin can use a holy symbol as a spellcasting focus. To use the symbol in this way, the caster must hold it in hand, wear it visibly, or bear it on a shield." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "reliquary", "it"), Language = LanguageCode.It, Name = "Reliquiario", Description = "Un simbolo sacro rappresenta un dio o un pantheon. Può essere un amuleto con il simbolo di una divinità, lo stesso simbolo inciso o intarsiato come emblema su uno scudo, oppure un piccolo scrigno che custodisce il frammento di una reliquia sacra.\n\nUn chierico o un paladino può usare un simbolo sacro come focus da incantatore. Per farlo, deve tenerlo in mano, indossarlo in modo visibile oppure portarlo su uno scudo." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "robes"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 4m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "robes", "en"), Language = LanguageCode.En, Name = "Robes", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "robes", "it"), Language = LanguageCode.It, Name = "Veste", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rope-hempen-50-feet"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = 10m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rope-hempen-50-feet", "en"), Language = LanguageCode.En, Name = "Rope, hempen (50 feet)", Description = "Rope, whether made of hemp or silk, has 2 hit points and can be burst with a DC 17 Strength check." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rope-hempen-50-feet", "it"), Language = LanguageCode.It, Name = "Corda di canapa (15 metri)", Description = "Che sia di canapa o di seta, una corda ha 2 punti ferita e può essere spezzata superando una prova di Forza con CD 17." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rope-silk-50-feet"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1000,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rope-silk-50-feet", "en"), Language = LanguageCode.En, Name = "Rope, silk (50 feet)", Description = "Rope, whether made of hemp or silk, has 2 hit points and can be burst with a DC 17 Strength check." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "rope-silk-50-feet", "it"), Language = LanguageCode.It, Name = "Corda di seta (15 metri)", Description = "Che sia di canapa o di seta, una corda ha 2 punti ferita e può essere spezzata superando una prova di Forza con CD 17." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sack"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1,
			WeightInPounds = 0.5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sack", "en"), Language = LanguageCode.En, Name = "Sack", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sack", "it"), Language = LanguageCode.It, Name = "Sacco", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scale-merchants"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scale-merchants", "en"), Language = LanguageCode.En, Name = "Scale, merchant's", Description = "A scale includes a small balance, pans, and a suitable assortment of weights up to 2 pounds. With it, you can measure the exact weight of small objects, such as raw precious metals or trade goods, to help determine their worth." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scale-merchants", "it"), Language = LanguageCode.It, Name = "Bilancia da mercante", Description = "Una bilancia da mercante comprende un piccolo bilanciere, i piatti e un assortimento di pesi fino a 1 kg. Permette di misurare il peso esatto di piccoli oggetti, come metalli preziosi grezzi o merci, per stabilirne il valore." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sealing-wax"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sealing-wax", "en"), Language = LanguageCode.En, Name = "Sealing wax", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "sealing-wax", "it"), Language = LanguageCode.It, Name = "Cera per sigillo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shovel"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shovel", "en"), Language = LanguageCode.En, Name = "Shovel", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "shovel", "it"), Language = LanguageCode.It, Name = "Vanga o badile", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "signal-whistle"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "signal-whistle", "en"), Language = LanguageCode.En, Name = "Signal whistle", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "signal-whistle", "it"), Language = LanguageCode.It, Name = "Fischietto da richiamo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "signet-ring"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 500,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "signet-ring", "en"), Language = LanguageCode.En, Name = "Signet ring", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "signet-ring", "it"), Language = LanguageCode.It, Name = "Anello con sigillo", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "soap"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 2,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "soap", "en"), Language = LanguageCode.En, Name = "Soap", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "soap", "it"), Language = LanguageCode.It, Name = "Sapone", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spellbook"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 5000,
			WeightInPounds = 3m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spellbook", "en"), Language = LanguageCode.En, Name = "Spellbook", Description = "Essential for wizards, a spellbook is a leather-bound tome with 100 blank vellum pages suitable for recording spells." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spellbook", "it"), Language = LanguageCode.It, Name = "Libro degli incantesimi", Description = "Indispensabile per i maghi, il libro degli incantesimi è un tomo rilegato in cuoio con 100 pagine bianche di pergamena, adatte a trascrivere incantesimi." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spike-iron"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 10,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spike-iron", "en"), Language = LanguageCode.En, Name = "Spike, iron", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spike-iron", "it"), Language = LanguageCode.It, Name = "Spuntoni di ferro (10)", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spyglass"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100000,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spyglass", "en"), Language = LanguageCode.En, Name = "Spyglass", Description = "Objects viewed through a spyglass are magnified to twice their size." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "spyglass", "it"), Language = LanguageCode.It, Name = "Cannocchiale", Description = "Gli oggetti osservati con un cannocchiale appaiono ingranditi al doppio delle loro dimensioni." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "tent-two-person"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 200,
			WeightInPounds = 20m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "tent-two-person", "en"), Language = LanguageCode.En, Name = "Tent, two-person", Description = "A simple and portable canvas shelter, a tent sleeps two." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "tent-two-person", "it"), Language = LanguageCode.It, Name = "Tenda per due persone", Description = "Un riparo di tela semplice e portatile: in una tenda possono dormire due persone." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "tinderbox"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 50,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "tinderbox", "en"), Language = LanguageCode.En, Name = "Tinderbox", Description = "This small container holds flint, fire steel, and tinder (usually dry cloth soaked in light oil) used to kindle a fire. Using it to light a torch--or anything else with abundant, exposed fuel--takes an action.\n\nLighting any other fire takes 1 minute." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "tinderbox", "it"), Language = LanguageCode.It, Name = "Acciarino e pietra focaia", Description = "Questo piccolo contenitore custodisce selce, acciarino ed esca (di solito un panno secco imbevuto d'olio leggero) per accendere il fuoco. Accendere una torcia, o qualsiasi altra cosa con abbondante combustibile esposto, richiede un'azione.\n\nAccendere qualsiasi altro fuoco richiede 1 minuto." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "torch"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "torch", "en"), Language = LanguageCode.En, Name = "Torch", Description = "A torch burns for 1 hour, providing bright light in a 20-foot radius and dim light for an additional 20 feet. If you make a melee attack with a burning torch and hit, it deals 1 fire damage." },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "torch", "it"), Language = LanguageCode.It, Name = "Torcia", Description = "Una torcia brucia per 1 ora, proiettando luce intensa in un raggio di 6 metri e luce fioca per altri 6 metri. Se il personaggio effettua un attacco in mischia con una torcia accesa e colpisce, infligge 1 danno da fuoco." }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "vial"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 100,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "vial", "en"), Language = LanguageCode.En, Name = "Vial", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "vial", "it"), Language = LanguageCode.It, Name = "Fiala", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "waterskin"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 20,
			WeightInPounds = 5m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "waterskin", "en"), Language = LanguageCode.En, Name = "Waterskin", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "waterskin", "it"), Language = LanguageCode.It, Name = "Otre", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "whetstone"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.AdventuringGear,
			CostInCopper = 1,
			WeightInPounds = 1m,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "whetstone", "en"), Language = LanguageCode.En, Name = "Whetstone", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "whetstone", "it"), Language = LanguageCode.It, Name = "Cote per affilare", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "burglars-pack"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 1600,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "burglars-pack", "en"), Language = LanguageCode.En, Name = "Burglar's Pack", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "burglars-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da scassinatore", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "diplomats-pack"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 3900,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "diplomats-pack", "en"), Language = LanguageCode.En, Name = "Diplomat's Pack", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "diplomats-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da diplomatico", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dungeoneers-pack"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 1200,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dungeoneers-pack", "en"), Language = LanguageCode.En, Name = "Dungeoneer's Pack", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "dungeoneers-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da avventuriero", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "entertainers-pack"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 4000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "entertainers-pack", "en"), Language = LanguageCode.En, Name = "Entertainer's Pack", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "entertainers-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da intrattenitore", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "explorers-pack"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 1000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "explorers-pack", "en"), Language = LanguageCode.En, Name = "Explorer's Pack", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "explorers-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da esploratore", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "priests-pack"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 1900,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "priests-pack", "en"), Language = LanguageCode.En, Name = "Priest's Pack", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "priests-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da sacerdote", Description = "" }
			}
		};

		yield return new Equipment
		{
			Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scholars-pack"),
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Category = EquipmentCategory.EquipmentPack,
			CostInCopper = 4000,
			WeightInPounds = null,
			Translations = new List<EquipmentTranslation>
			{
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scholars-pack", "en"), Language = LanguageCode.En, Name = "Scholar's Pack", Description = "" },
				new EquipmentTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "equipment", "scholars-pack", "it"), Language = LanguageCode.It, Name = "Dotazione da studioso", Description = "" }
			}
		};
	}
}
