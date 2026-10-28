using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	public enum MagicTemplateKind
	{
		Weapon = 1,
		Armor = 2,
		Shield = 3,
		Wondrous = 4,
		Potion = 5
	}

	///	<summary>
	///	A ready-made magic item: only its rules (rarity, attunement, effects, charges), with a short summary written in
	///	our own words; the name and every value stay editable on the sheet.
	///	</summary>
	public sealed record MagicItemTemplate(
		string Key,
		string NameIt,
		string NameEn,
		MagicTemplateKind Kind,
		ItemRarity Rarity,
		bool Attunement,
		MagicEffect[] Effects,
		string SummaryIt,
		string SummaryEn,
		int Charges = 0,
		ItemRecharge Recharge = ItemRecharge.None,
		string? RechargeDice = null,
		string? HealDice = null)
	{
		public string Name(LanguageCode lang) => lang == LanguageCode.It ? NameIt : NameEn;

		public string Summary(LanguageCode lang) => lang == LanguageCode.It ? SummaryIt : SummaryEn;

		public MagicItemProperties Create() => new()
		{
			Rarity = Rarity,
			RequiresAttunement = Attunement,
			Effects = Effects.Select(e => new MagicEffect { Kind = e.Kind, Value = e.Value, Ability = e.Ability, DamageType = e.DamageType }).ToList(),
			Charges = Charges,
			Recharge = Recharge,
			RechargeDice = RechargeDice,
			HealDice = HealDice,
			Template = Key
		};
	}

	///	<summary>
	///	Common magic items of the System Reference Document (same rules in 2014 and 2024), offered by the sheet when the
	///	edition has no magic item compendium yet. Italian names as in the official Italian SRD 5.1.
	///	</summary>
	public static class MagicItemCatalog
	{
		private static MagicEffect E(MagicEffectKind kind, int value, AbilityScore? ability = null) => new() { Kind = kind, Value = value, Ability = ability };

		public static readonly IReadOnlyList<MagicItemTemplate> All = Build();

		public static MagicItemTemplate? Find(string? key) => All.FirstOrDefault(t => t.Key == key);

		public static IEnumerable<MagicItemTemplate> OfKind(MagicTemplateKind kind) => All.Where(t => t.Kind == kind);

		private static List<MagicItemTemplate> Build()
		{
			var list = new List<MagicItemTemplate>();
			var rarities = new[] { ItemRarity.Uncommon, ItemRarity.Rare, ItemRarity.VeryRare };
			var armorRarities = new[] { ItemRarity.Rare, ItemRarity.VeryRare, ItemRarity.Legendary };
			for (var n = 1; n <= 3; n++)
			{
				list.Add(new MagicItemTemplate($"weapon-{n}", $"Arma +{n}", $"Weapon +{n}", MagicTemplateKind.Weapon, rarities[n - 1], false,
					new[] { E(MagicEffectKind.AttackAndDamage, n) },
					$"+{n} ai tiri per colpire e ai danni con quest'arma.", $"+{n} to attack and damage rolls made with this weapon."));
				list.Add(new MagicItemTemplate($"armor-{n}", $"Armatura +{n}", $"Armor +{n}", MagicTemplateKind.Armor, armorRarities[n - 1], false,
					new[] { E(MagicEffectKind.ArmorClass, n) },
					$"+{n} alla CA mentre la indossi.", $"+{n} to AC while you wear it."));
				list.Add(new MagicItemTemplate($"shield-{n}", $"Scudo +{n}", $"Shield +{n}", MagicTemplateKind.Shield, rarities[n - 1], false,
					new[] { E(MagicEffectKind.ArmorClass, n) },
					$"+{n} alla CA oltre al normale bonus dello scudo.", $"+{n} to AC on top of the shield's normal bonus."));
			}

			list.Add(new MagicItemTemplate("ring-of-protection", "Anello di protezione", "Ring of Protection", MagicTemplateKind.Wondrous, ItemRarity.Rare, true,
				new[] { E(MagicEffectKind.ArmorClass, 1), E(MagicEffectKind.SavingThrows, 1) },
				"+1 alla CA e ai tiri salvezza.", "+1 to AC and saving throws."));
			list.Add(new MagicItemTemplate("cloak-of-protection", "Mantello della protezione", "Cloak of Protection", MagicTemplateKind.Wondrous, ItemRarity.Uncommon, true,
				new[] { E(MagicEffectKind.ArmorClass, 1), E(MagicEffectKind.SavingThrows, 1) },
				"+1 alla CA e ai tiri salvezza.", "+1 to AC and saving throws."));
			list.Add(new MagicItemTemplate("bracers-of-defense", "Bracciali della difesa", "Bracers of Defense", MagicTemplateKind.Wondrous, ItemRarity.Rare, true,
				new[] { E(MagicEffectKind.UnarmoredArmorClass, 2) },
				"+2 alla CA se non indossi armature e non usi scudi.", "+2 to AC while you wear no armor and use no shield."));
			list.Add(new MagicItemTemplate("stone-of-good-luck", "Pietra della buona fortuna", "Stone of Good Luck", MagicTemplateKind.Wondrous, ItemRarity.Uncommon, true,
				new[] { E(MagicEffectKind.AbilityChecks, 1), E(MagicEffectKind.SavingThrows, 1) },
				"+1 alle prove di caratteristica e ai tiri salvezza.", "+1 to ability checks and saving throws."));
			list.Add(new MagicItemTemplate("amulet-of-health", "Amuleto della salute", "Amulet of Health", MagicTemplateKind.Wondrous, ItemRarity.Rare, true,
				new[] { E(MagicEffectKind.SetAbilityScore, 19, AbilityScore.Constitution) },
				"Costituzione 19 (nessun effetto se è già più alta).", "Constitution 19 (no effect if it is already higher)."));
			list.Add(new MagicItemTemplate("gauntlets-of-ogre-power", "Guanti del potere orchesco", "Gauntlets of Ogre Power", MagicTemplateKind.Wondrous, ItemRarity.Uncommon, true,
				new[] { E(MagicEffectKind.SetAbilityScore, 19, AbilityScore.Strength) },
				"Forza 19 (nessun effetto se è già più alta).", "Strength 19 (no effect if it is already higher)."));
			list.Add(new MagicItemTemplate("headband-of-intellect", "Fascia dell'intelletto", "Headband of Intellect", MagicTemplateKind.Wondrous, ItemRarity.Uncommon, true,
				new[] { E(MagicEffectKind.SetAbilityScore, 19, AbilityScore.Intelligence) },
				"Intelligenza 19 (nessun effetto se è già più alta).", "Intelligence 19 (no effect if it is already higher)."));
			list.Add(new MagicItemTemplate("belt-of-hill-giant-strength", "Cintura della forza dei giganti delle colline", "Belt of Hill Giant Strength", MagicTemplateKind.Wondrous, ItemRarity.Rare, true,
				new[] { E(MagicEffectKind.SetAbilityScore, 21, AbilityScore.Strength) },
				"Forza 21 (nessun effetto se è già più alta).", "Strength 21 (no effect if it is already higher)."));
			list.Add(new MagicItemTemplate("wand-of-magic-missiles", "Bacchetta di missili magici", "Wand of Magic Missiles", MagicTemplateKind.Wondrous, ItemRarity.Uncommon, false,
				Array.Empty<MagicEffect>(),
				"7 cariche per lanciare Dardo Incantato (1 carica per il 1° livello, +1 per ogni livello in più); recupera 1d6+1 cariche ogni alba.",
				"7 charges to cast Magic Missile (1 charge for level 1, +1 per extra level); regains 1d6+1 charges each dawn.",
				Charges: 7, Recharge: ItemRecharge.LongRest, RechargeDice: "1d6+1"));
			for (var n = 1; n <= 3; n++)
			{
				list.Add(new MagicItemTemplate($"wand-of-the-war-mage-{n}", $"Bacchetta del mago da guerra +{n}", $"Wand of the War Mage +{n}", MagicTemplateKind.Wondrous,
					rarities[n - 1], true, new[] { E(MagicEffectKind.SpellAttack, n) },
					$"+{n} ai tiri per colpire con gli incantesimi (sintonia di un incantatore).", $"+{n} to spell attack rolls (attuned by a spellcaster)."));
			}

			list.Add(new MagicItemTemplate("potion-of-healing", "Pozione di guarigione", "Potion of Healing", MagicTemplateKind.Potion, ItemRarity.Common, false,
				Array.Empty<MagicEffect>(), "Recupera 2d4+2 punti ferita.", "Regain 2d4 + 2 hit points.", HealDice: "2d4+2"));
			list.Add(new MagicItemTemplate("potion-of-greater-healing", "Pozione di guarigione maggiore", "Potion of Greater Healing", MagicTemplateKind.Potion, ItemRarity.Uncommon, false,
				Array.Empty<MagicEffect>(), "Recupera 4d4+4 punti ferita.", "Regain 4d4 + 4 hit points.", HealDice: "4d4+4"));
			list.Add(new MagicItemTemplate("potion-of-superior-healing", "Pozione di guarigione superiore", "Potion of Superior Healing", MagicTemplateKind.Potion, ItemRarity.Rare, false,
				Array.Empty<MagicEffect>(), "Recupera 8d4+8 punti ferita.", "Regain 8d4 + 8 hit points.", HealDice: "8d4+8"));
			list.Add(new MagicItemTemplate("potion-of-supreme-healing", "Pozione di guarigione suprema", "Potion of Supreme Healing", MagicTemplateKind.Potion, ItemRarity.VeryRare, false,
				Array.Empty<MagicEffect>(), "Recupera 10d4+20 punti ferita.", "Regain 10d4 + 20 hit points.", HealDice: "10d4+20"));
			return list;
		}
	}
}
