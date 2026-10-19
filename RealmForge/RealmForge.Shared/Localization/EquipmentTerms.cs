using System.Globalization;
using RealmForge.Shared.Enums;

namespace RealmForge.Shared.Localization
{
	///	<summary>
	///	Localized names of the equipment terms and the formatting of costs, weights, ranges and speeds.
	///	Quantities are stored as in the English rules (pounds, feet, miles per hour); Italian texts use the
	///	conversions of the Italian books: 1 lb = 0,5 kg, 5 ft = 1,5 m, 1 mph = 1,5 km/h.
	///	</summary>
	public static class EquipmentTerms
	{
		//	Numbers are formatted by hand (the WebAssembly client may run without culture data): Italian uses
		//	the comma for decimals and the dot for thousands
		private static string Dec(decimal value, LanguageCode lang)
		{
			var text = value.ToString("0.###", CultureInfo.InvariantCulture);
			return lang == LanguageCode.It ? text.Replace('.', ',') : text;
		}

		private static string Int(int value, LanguageCode lang)
		{
			var text = value.ToString("N0", CultureInfo.InvariantCulture);
			return lang == LanguageCode.It ? text.Replace(',', '.') : text;
		}

		public static string CategoryName(EquipmentCategory category, LanguageCode lang) => (category, lang == LanguageCode.It) switch
		{
			(EquipmentCategory.Weapon, true) => "Armi",
			(EquipmentCategory.Armor, true) => "Armature e scudi",
			(EquipmentCategory.Ammunition, true) => "Munizioni",
			(EquipmentCategory.SpellcastingFocus, true) => "Focus da incantatore",
			(EquipmentCategory.AdventuringGear, true) => "Equipaggiamento d'avventura",
			(EquipmentCategory.Tool, true) => "Strumenti",
			(EquipmentCategory.EquipmentPack, true) => "Dotazioni",
			(EquipmentCategory.Mount, true) => "Cavalcature e animali",
			(EquipmentCategory.TackAndVehicle, true) => "Finimenti e veicoli",
			(EquipmentCategory.Ship, true) => "Navi",
			(EquipmentCategory.TradeGood, true) => "Merci",
			(EquipmentCategory.Weapon, false) => "Weapons",
			(EquipmentCategory.Armor, false) => "Armor and shields",
			(EquipmentCategory.Ammunition, false) => "Ammunition",
			(EquipmentCategory.SpellcastingFocus, false) => "Spellcasting focuses",
			(EquipmentCategory.AdventuringGear, false) => "Adventuring gear",
			(EquipmentCategory.Tool, false) => "Tools",
			(EquipmentCategory.EquipmentPack, false) => "Equipment packs",
			(EquipmentCategory.Mount, false) => "Mounts and animals",
			(EquipmentCategory.TackAndVehicle, false) => "Tack and vehicles",
			(EquipmentCategory.Ship, false) => "Ships",
			(EquipmentCategory.TradeGood, false) => "Trade goods",
			_ => category.ToString()
		};

		public static string WeaponCategoryName(WeaponCategory category, WeaponRange range, LanguageCode lang) => (category, range, lang == LanguageCode.It) switch
		{
			(WeaponCategory.Simple, WeaponRange.Melee, true) => "Arma semplice da mischia",
			(WeaponCategory.Simple, WeaponRange.Ranged, true) => "Arma semplice a distanza",
			(WeaponCategory.Martial, WeaponRange.Melee, true) => "Arma da guerra da mischia",
			(WeaponCategory.Martial, WeaponRange.Ranged, true) => "Arma da guerra a distanza",
			(WeaponCategory.Simple, WeaponRange.Melee, false) => "Simple melee weapon",
			(WeaponCategory.Simple, WeaponRange.Ranged, false) => "Simple ranged weapon",
			(WeaponCategory.Martial, WeaponRange.Melee, false) => "Martial melee weapon",
			_ => "Martial ranged weapon"
		};

		public static string WeaponCategoryLabel(WeaponCategory category, LanguageCode lang) => (category, lang == LanguageCode.It) switch
		{
			(WeaponCategory.Simple, true) => "Semplice",
			(WeaponCategory.Martial, true) => "Da guerra",
			(WeaponCategory.Simple, false) => "Simple",
			_ => "Martial"
		};

		public static string WeaponRangeLabel(WeaponRange range, LanguageCode lang) => (range, lang == LanguageCode.It) switch
		{
			(WeaponRange.Melee, true) => "Mischia",
			(WeaponRange.Ranged, true) => "Distanza",
			(WeaponRange.Melee, false) => "Melee",
			_ => "Ranged"
		};

		public static string PropertyName(WeaponProperty property, LanguageCode lang) => (property, lang == LanguageCode.It) switch
		{
			(WeaponProperty.Ammunition, true) => "Munizioni",
			(WeaponProperty.Finesse, true) => "Accurata",
			(WeaponProperty.Heavy, true) => "Pesante",
			(WeaponProperty.Light, true) => "Leggera",
			(WeaponProperty.Loading, true) => "Ricarica",
			(WeaponProperty.Reach, true) => "Portata",
			(WeaponProperty.Special, true) => "Speciale",
			(WeaponProperty.Thrown, true) => "Lancio",
			(WeaponProperty.TwoHanded, true) => "Due mani",
			(WeaponProperty.Versatile, true) => "Versatile",
			(WeaponProperty.Ammunition, false) => "Ammunition",
			(WeaponProperty.Finesse, false) => "Finesse",
			(WeaponProperty.Heavy, false) => "Heavy",
			(WeaponProperty.Light, false) => "Light",
			(WeaponProperty.Loading, false) => "Loading",
			(WeaponProperty.Reach, false) => "Reach",
			(WeaponProperty.Special, false) => "Special",
			(WeaponProperty.Thrown, false) => "Thrown",
			(WeaponProperty.TwoHanded, false) => "Two-Handed",
			(WeaponProperty.Versatile, false) => "Versatile",
			_ => property.ToString()
		};

		public static string MasteryName(WeaponMastery mastery, LanguageCode lang) => (mastery, lang == LanguageCode.It) switch
		{
			(WeaponMastery.Cleave, true) => "Doppio fendente",
			(WeaponMastery.Graze, true) => "Colpo di striscio",
			(WeaponMastery.Nick, true) => "Graffio",
			(WeaponMastery.Push, true) => "Spinta",
			(WeaponMastery.Sap, true) => "Prosciugamento",
			(WeaponMastery.Slow, true) => "Lentezza",
			(WeaponMastery.Topple, true) => "Rovesciamento",
			(WeaponMastery.Vex, true) => "Vessazione",
			_ => mastery.ToString()
		};

		public static string DamageTypeName(DamageType type, LanguageCode lang, bool plural = true) => (type, lang == LanguageCode.It) switch
		{
			(DamageType.Acid, true) => "da acido",
			(DamageType.Bludgeoning, true) => plural ? "contundenti" : "contundente",
			(DamageType.Cold, true) => "da freddo",
			(DamageType.Fire, true) => "da fuoco",
			(DamageType.Force, true) => "da forza",
			(DamageType.Lightning, true) => "da fulmine",
			(DamageType.Necrotic, true) => plural ? "necrotici" : "necrotico",
			(DamageType.Piercing, true) => plural ? "perforanti" : "perforante",
			(DamageType.Poison, true) => "da veleno",
			(DamageType.Psychic, true) => plural ? "psichici" : "psichico",
			(DamageType.Radiant, true) => plural ? "radiosi" : "radioso",
			(DamageType.Slashing, true) => plural ? "taglienti" : "tagliente",
			(DamageType.Thunder, true) => "da tuono",
			_ => type.ToString()
		};

		public static string ArmorCategoryName(ArmorCategory category, LanguageCode lang) => (category, lang == LanguageCode.It) switch
		{
			(ArmorCategory.Light, true) => "Armatura leggera",
			(ArmorCategory.Medium, true) => "Armatura media",
			(ArmorCategory.Heavy, true) => "Armatura pesante",
			(ArmorCategory.Shield, true) => "Scudo",
			(ArmorCategory.Light, false) => "Light armor",
			(ArmorCategory.Medium, false) => "Medium armor",
			(ArmorCategory.Heavy, false) => "Heavy armor",
			_ => "Shield"
		};

		public static string ToolCategoryName(ToolCategory category, LanguageCode lang) => (category, lang == LanguageCode.It) switch
		{
			(ToolCategory.ArtisansTools, true) => "Strumenti da artigiano",
			(ToolCategory.GamingSet, true) => "Gioco",
			(ToolCategory.MusicalInstrument, true) => "Strumento musicale",
			(ToolCategory.OtherTool, true) => "Altri strumenti",
			(ToolCategory.ArtisansTools, false) => "Artisan's tools",
			(ToolCategory.GamingSet, false) => "Gaming set",
			(ToolCategory.MusicalInstrument, false) => "Musical instrument",
			_ => "Other tools"
		};

		public static string FocusTypeName(FocusType type, LanguageCode lang) => (type, lang == LanguageCode.It) switch
		{
			(FocusType.Arcane, true) => "Focus arcano",
			(FocusType.Druidic, true) => "Focus druidico",
			(FocusType.HolySymbol, true) => "Simbolo sacro",
			(FocusType.Arcane, false) => "Arcane focus",
			(FocusType.Druidic, false) => "Druidic focus",
			_ => "Holy symbol"
		};

		///	<summary>
		///	"15 GP" / "15 mo": the largest coin that expresses the price exactly (gold, silver, copper); "—" when the price varies.
		///	</summary>
		public static string FormatCost(int? copper, LanguageCode lang)
		{
			if (copper is null)
			{
				return "—";
			}

			var it = lang == LanguageCode.It;
			var c = copper.Value;
			var (amount, unit) = c % 100 == 0 ? (c / 100, it ? "mo" : "GP")
				: c % 10 == 0 ? (c / 10, it ? "ma" : "SP")
				: (c, it ? "mr" : "CP");
			return $"{Int(amount, lang)} {unit}";
		}

		///	<summary>
		///	"3 lb." / "1,5 kg"; "—" for negligible weight.
		///	</summary>
		public static string FormatWeight(decimal? pounds, LanguageCode lang)
		{
			if (pounds is null or 0)
			{
				return "—";
			}

			if (lang == LanguageCode.It)
			{
				return $"{Dec(pounds.Value / 2, lang)} kg";
			}

			var value = pounds.Value;
			var text = value switch
			{
				0.25m => "1/4",
				0.5m => "1/2",
				_ when value % 1 == 0.5m => $"{Math.Floor(value):0}½",
				_ => Dec(value, lang)
			};
			return $"{text} lb.";
		}

		///	<summary>
		///	Feet to the unit of the language: "30 ft." / "9 m".
		///	</summary>
		public static string FormatDistance(int feet, LanguageCode lang) =>
			lang == LanguageCode.It ? $"{Dec(feet * 0.3m, lang)} m" : $"{feet} ft.";

		///	<summary>
		///	Normal and long range of a ranged or thrown weapon: "80/320" (feet) or "24/96" (metres).
		///	</summary>
		public static string FormatRange(int normal, int longRange, LanguageCode lang) =>
			lang == LanguageCode.It
				? $"{Dec(normal * 0.3m, lang)}/{Dec(longRange * 0.3m, lang)}"
				: $"{normal}/{longRange}";

		public static string FormatShipSpeed(decimal mph, LanguageCode lang) =>
			lang == LanguageCode.It ? $"{Dec(mph * 1.5m, lang)} km/h" : $"{Dec(mph, lang)} mph";

		public static string FormatCapacity(int pounds, LanguageCode lang) =>
			lang == LanguageCode.It ? $"{Dec(pounds / 2m, lang)} kg" : $"{Int(pounds, lang)} lb.";

		///	<summary>
		///	"1d8 slashing" / "1d8 taglienti" ("1 piercing" / "1 perforante" for a flat damage).
		///	</summary>
		public static string FormatDamage(string? dice, DamageType? type, LanguageCode lang)
		{
			if (string.IsNullOrWhiteSpace(dice) || type is null)
			{
				return "—";
			}

			var flatOne = dice.Trim() == "1";
			return lang == LanguageCode.It
				? $"{dice} {DamageTypeName(type.Value, lang, plural: !flatOne)}"
				: $"{dice} {type.Value.ToString().ToLowerInvariant()}";
		}

		///	<summary>
		///	Armor Class column: "11 + Dex modifier (max 2)", "16", "+2" for a shield.
		///	</summary>
		public static string FormatArmorClass(ArmorCategory? category, int? baseAc, bool addsDex, int? maxDex, LanguageCode lang)
		{
			if (baseAc is null)
			{
				return "—";
			}

			if (category == ArmorCategory.Shield)
			{
				return $"+{baseAc}";
			}

			if (!addsDex)
			{
				return baseAc.Value.ToString(CultureInfo.InvariantCulture);
			}

			var dex = lang == LanguageCode.It ? "modificatore di Des" : "Dex modifier";
			return maxDex is null ? $"{baseAc} + {dex}" : $"{baseAc} + {dex} (max {maxDex})";
		}

		///	<summary>
		///	Weapon properties with their details: "Thrown (range 20/60), Versatile (1d8)" / "Lancio (gittata 6/18), Versatile (1d8)".
		///	</summary>
		public static string FormatProperties(IEnumerable<WeaponProperty> properties, int? normal, int? longRange, string? versatileDice, LanguageCode lang)
		{
			var it = lang == LanguageCode.It;
			var parts = properties.Select(p =>
			{
				var name = PropertyName(p, lang);
				return p switch
				{
					WeaponProperty.Ammunition or WeaponProperty.Thrown when normal is not null && longRange is not null =>
						$"{name} ({(it ? "gittata" : "range")} {FormatRange(normal.Value, longRange.Value, lang)})",
					WeaponProperty.Versatile when !string.IsNullOrWhiteSpace(versatileDice) => $"{name} ({versatileDice})",
					_ => name
				};
			}).OrderBy(p => p, StringComparer.OrdinalIgnoreCase).ToList();
			return parts.Count == 0 ? "—" : string.Join(", ", parts);
		}

		///	<summary>
		///	Rules of the weapon properties for the reference panel of the equipment page.
		///	</summary>
		public static string PropertyRule(WeaponProperty property, RulesetVersion ruleset, LanguageCode lang)
		{
			var it = lang == LanguageCode.It;
			var r2024 = ruleset == RulesetVersion.Dnd5e_2024;
			return property switch
			{
				WeaponProperty.Ammunition => it
					? "Per attaccare a distanza serve una munizione, che viene spesa con l'attacco; tra parentesi c'è la gittata. Dopo la battaglia si può recuperare metà delle munizioni usate."
					: "A ranged attack needs a piece of ammunition, which is spent by the attack; the range is in parentheses. After a fight you can recover half of the ammunition you used.",
				WeaponProperty.Finesse => it
					? "Per i tiri per colpire e per i danni si può usare il modificatore di Forza o di Destrezza, lo stesso per entrambi."
					: "Attack and damage rolls can use your Strength or Dexterity modifier, the same one for both rolls.",
				WeaponProperty.Heavy => it
					? (r2024 ? "Chi ha Forza inferiore a 13 (armi da mischia) o Destrezza inferiore a 13 (armi a distanza) subisce svantaggio ai tiri per colpire." : "Le creature di taglia Piccola subiscono svantaggio ai tiri per colpire con quest'arma.")
					: (r2024 ? "You have Disadvantage on attack rolls if your Strength (melee) or Dexterity (ranged) is less than 13." : "Small creatures have disadvantage on attack rolls with this weapon."),
				WeaponProperty.Light => it
					? (r2024 ? "Dopo aver attaccato con un'arma leggera nell'azione di Attacco, si può attaccare con un'altra arma leggera come azione bonus, senza aggiungere il modificatore ai danni (se positivo)." : "Un'arma leggera è adatta al combattimento con due armi.")
					: (r2024 ? "After attacking with a Light weapon as part of the Attack action, you can make an extra attack with a different Light weapon as a Bonus Action, without adding your modifier to its damage (unless negative)." : "A light weapon is ideal for fighting with two weapons."),
				WeaponProperty.Loading => it
					? "Con un'azione, un'azione bonus o una reazione si può sparare una sola munizione, a prescindere dal numero di attacchi."
					: "You can fire only one piece of ammunition with an action, bonus action, or reaction, regardless of how many attacks you have.",
				WeaponProperty.Reach => it
					? "La portata aumenta di 1,5 metri, anche per gli attacchi di opportunità."
					: "Your reach is 5 feet longer when you attack with this weapon, including Opportunity Attacks.",
				WeaponProperty.Special => it
					? "L'arma ha regole particolari, indicate nella sua descrizione."
					: "The weapon has unusual rules, explained in its description.",
				WeaponProperty.Thrown => it
					? "L'arma può essere lanciata per un attacco a distanza (tra parentesi la gittata), usando lo stesso modificatore di caratteristica dell'attacco in mischia."
					: "You can throw the weapon to make a ranged attack (range in parentheses), using the same ability modifier as for a melee attack.",
				WeaponProperty.TwoHanded => it
					? "L'arma va impugnata a due mani per attaccare."
					: "The weapon requires two hands when you attack with it.",
				WeaponProperty.Versatile => it
					? "L'arma si può usare a una o a due mani; tra parentesi i danni a due mani."
					: "The weapon can be used with one or two hands; the damage in parentheses applies with two hands.",
				_ => string.Empty
			};
		}

		///	<summary>
		///	Mastery properties of the 2024 rules, usable only by a creature with the Weapon Mastery feature for that weapon.
		///	</summary>
		public static string MasteryRule(WeaponMastery mastery, LanguageCode lang)
		{
			var it = lang == LanguageCode.It;
			return mastery switch
			{
				WeaponMastery.Cleave => it
					? "Dopo aver colpito una creatura con un attacco in mischia, si può attaccare una seconda creatura entro 1,5 metri dalla prima e alla propria portata, senza aggiungere il modificatore ai danni (se positivo). Una volta per turno."
					: "After hitting a creature with a melee attack, you can attack a second creature within 5 feet of the first and within your reach, without adding your modifier to its damage (unless negative). Once per turn.",
				WeaponMastery.Graze => it
					? "Se l'attacco manca, il bersaglio subisce comunque danni pari al modificatore di caratteristica usato per l'attacco, dello stesso tipo dell'arma."
					: "If your attack misses, the target still takes damage equal to the ability modifier you used for the attack, of the weapon's damage type.",
				WeaponMastery.Nick => it
					? "L'attacco extra della proprietà leggera si effettua come parte dell'azione di Attacco anziché con un'azione bonus. Una volta per turno."
					: "The extra attack of the Light property is made as part of the Attack action instead of as a Bonus Action. Once per turn.",
				WeaponMastery.Push => it
					? "Se colpisce una creatura di taglia Grande o inferiore, il personaggio può spingerla fino a 3 metri in linea retta lontano da sé."
					: "If you hit a Large or smaller creature, you can push it up to 10 feet straight away from yourself.",
				WeaponMastery.Sap => it
					? "Se colpisce una creatura, questa subisce svantaggio al suo prossimo tiro per colpire prima dell'inizio del turno successivo del personaggio."
					: "If you hit a creature, it has Disadvantage on its next attack roll before the start of your next turn.",
				WeaponMastery.Slow => it
					? "Se colpisce e infligge danni, la velocità della creatura si riduce di 3 metri fino all'inizio del turno successivo del personaggio (non cumulabile)."
					: "If you hit and deal damage, the creature's Speed drops by 10 feet until the start of your next turn (this doesn't stack).",
				WeaponMastery.Topple => it
					? "Se colpisce, il personaggio può costringere la creatura a un tiro salvezza su Costituzione (CD 8 + il modificatore usato per l'attacco + il bonus di competenza): se lo fallisce, cade prona."
					: "If you hit, you can force the creature to make a Constitution saving throw (DC 8 plus the attack's ability modifier and your Proficiency Bonus); on a failure, it has the Prone condition.",
				WeaponMastery.Vex => it
					? "Se colpisce e infligge danni, il personaggio dispone di vantaggio al suo prossimo tiro per colpire contro quella creatura prima della fine del suo turno successivo."
					: "If you hit and deal damage, you have Advantage on your next attack roll against that creature before the end of your next turn.",
				_ => string.Empty
			};
		}
	}
}
