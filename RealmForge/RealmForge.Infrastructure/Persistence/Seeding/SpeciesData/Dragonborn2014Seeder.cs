using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Dragonborn2014Seeder
	{
		//	Deterministic GUID for 2014 SRD Dragonborn
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000004");

		private record AncestryConfig(
			Guid Id,
			string NameIt,
			string NameEn,
			string DamageTypeIt,
			string DamageTypeEn,
			string BreathAreaIt,
			string BreathAreaEn,
			string SaveIt,
			string SaveEn
		);

		private static readonly AncestryConfig[] Ancestries = new[]
		{
			new AncestryConfig(Guid.Parse("10000000-0000-0000-0004-000000000001"), "Drago Nero", "Black Dragon", "Acido", "Acid", "Linea di 1,5 x 9 m", "5 by 30 ft. line", "Destrezza", "Dexterity"),
			new AncestryConfig(Guid.Parse("10000000-0000-0000-0004-000000000002"), "Drago Blu", "Blue Dragon", "Fulmine", "Lightning", "Linea di 1,5 x 9 m", "5 by 30 ft. line", "Destrezza", "Dexterity"),
			new AncestryConfig(Guid.Parse("10000000-0000-0000-0004-000000000003"), "Drago d'Ottone", "Brass Dragon", "Fuoco", "Fire", "Linea di 1,5 x 9 m", "5 by 30 ft. line", "Destrezza", "Dexterity"),
			new AncestryConfig(Guid.Parse("10000000-0000-0000-0004-000000000004"), "Drago di Bronzo", "Bronze Dragon", "Fulmine", "Lightning", "Linea di 1,5 x 9 m", "5 by 30 ft. line", "Destrezza", "Dexterity"),
			new AncestryConfig(Guid.Parse("10000000-0000-0000-0004-000000000005"), "Drago di Rame", "Copper Dragon", "Acido", "Acid", "Linea di 1,5 x 9 m", "5 by 30 ft. line", "Destrezza", "Dexterity"),
			new AncestryConfig(Guid.Parse("10000000-0000-0000-0004-000000000006"), "Drago d'Oro", "Gold Dragon", "Fuoco", "Fire", "Cono di 4,5 m", "15 ft. cone", "Destrezza", "Dexterity"),
			new AncestryConfig(Guid.Parse("10000000-0000-0000-0004-000000000007"), "Drago Verde", "Green Dragon", "Veleno", "Poison", "Cono di 4,5 m", "15 ft. cone", "Costituzione", "Constitution"),
			new AncestryConfig(Guid.Parse("10000000-0000-0000-0004-000000000008"), "Drago Rosso", "Red Dragon", "Fuoco", "Fire", "Cono di 4,5 m", "15 ft. cone", "Destrezza", "Dexterity"),
			new AncestryConfig(Guid.Parse("10000000-0000-0000-0004-000000000009"), "Drago d'Argento", "Silver Dragon", "Freddo", "Cold", "Cono di 4,5 m", "15 ft. cone", "Costituzione", "Constitution"),
			new AncestryConfig(Guid.Parse("10000000-0000-0000-0004-000000000010"), "Drago Bianco", "White Dragon", "Freddo", "Cold", "Cono di 4,5 m", "15 ft. cone", "Costituzione", "Constitution")
		};

		///	<summary>
		///	Builds the canonical SRD definition of this species. Persistence is handled by SpeciesSeeder.
		///	</summary>
		public static Species Build()
		{
			return new Species
			{
				Id = SpeciesId,
				BaseSpeedInFeet = 30,
				CreatureType = CreatureType.Humanoid,
				AllowedSizes = new List<CreatureSize> { CreatureSize.Medium },
				Ruleset = RulesetVersion.Dnd5e_2014,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Dragonide",
						Description = "I dragonidi portano il sangue e la fierezza dei draghi in un corpo umanoide. Coperti di scaglie, dalle spalle larghe e orgogliosi, percorrono un mondo che spesso li guarda con sospetto e rispondono pretendendo da sé stessi il massimo in onore e abilità."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Dragonborn",
						Description = "Dragonborn carry the blood and pride of dragons in a humanoid frame. Scaled, broad-shouldered, and proud, they walk through a world that often regards them with suspicion, and they answer it by holding themselves to the highest standards of honor and skill."
					}
				},
				Traits = new List<Trait>
				{
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Arma a Soffio",
								Description = "Un dragonide può usare la sua azione per esalare energia distruttiva determinata dalla sua discendenza. Ogni creatura nell'area deve effettuare un tiro salvezza (CD 8 + mod. Costituzione + bonus competenza). Subisce 2d6 danni se fallito, la metà se riuscito. I danni aumentano a 3d6 al 6° livello, 4d6 all'11° e 5d6 al 16°. Si ricarica con un riposo breve o lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Breath Weapon",
								Description = "You can use your action to exhale destructive energy determined by your draconic ancestry. Each creature in the area must make a saving throw (DC 8 + Con modifier + proficiency bonus). It takes 2d6 damage on a failed save, and half as much on a successful one. Damage increases to 3d6 at 6th level, 4d6 at 11th, and 5d6 at 16th. Recharges after a short or long rest."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Resistenza ai Danni",
								Description = "Un dragonide dispone di resistenza al tipo di danno associato alla sua discendenza draconica."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Damage Resistance",
								Description = "You have resistance to the damage type associated with your draconic ancestry."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Linguaggi",
								Description = "Un dragonide sa parlare, leggere e scrivere in Comune e in Draconico. Il Draconico è ritenuto uno dei linguaggi più antichi del multiverso."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Languages",
								Description = "You can speak, read, and write Common and Draconic. Draconic is thought to be one of the oldest languages and is often used in magical studies."
							}
						}
					}
				},
				Subspecies = Ancestries.Select(cfg => new Subspecies
				{
					Id = cfg.Id,
					Ruleset = RulesetVersion.Dnd5e_2014,
					IsOfficialSRD = true,
					Translations = new List<SubspeciesTranslation>
					{
						new SubspeciesTranslation
						{
							Language = LanguageCode.It,
							Name = cfg.NameIt,
							Description = $"Discendenza legata al {cfg.NameIt}. Concorre a definire il soffio elementale ({cfg.DamageTypeIt}, {cfg.BreathAreaIt}, TS {cfg.SaveIt}) e la resistenza ai danni."
						},
						new SubspeciesTranslation
						{
							Language = LanguageCode.En,
							Name = cfg.NameEn,
							Description = $"Ancestry tied to the {cfg.NameEn}. Dictates elemental breath ({cfg.DamageTypeEn}, {cfg.BreathAreaEn}, {cfg.SaveEn} save) and damage resistance."
						}
					},
					Traits = new List<Trait>
					{
						new Trait
						{
							RequiredLevel = 1,
							Ruleset = RulesetVersion.Dnd5e_2014,
							IsOfficialSRD = true,
							Translations = new List<TraitTranslation>
							{
								new TraitTranslation
								{
									Language = LanguageCode.It,
									Name = $"Soffio Draconico ({cfg.DamageTypeIt})",
									Description = $"Esalazione in {cfg.BreathAreaIt}. Tipo di danno: {cfg.DamageTypeIt}. Tiro Salvezza richiesto: {cfg.SaveIt}."
								},
								new TraitTranslation
								{
									Language = LanguageCode.En,
									Name = $"Draconic Breath ({cfg.DamageTypeEn})",
									Description = $"Exhalation area: {cfg.BreathAreaEn}. Damage type: {cfg.DamageTypeEn}. Saving throw: {cfg.SaveEn}."
								}
							}
						},
						new Trait
						{
							RequiredLevel = 1,
							Ruleset = RulesetVersion.Dnd5e_2014,
							IsOfficialSRD = true,
							Translations = new List<TraitTranslation>
							{
								new TraitTranslation
								{
									Language = LanguageCode.It,
									Name = $"Resistenza elementale ({cfg.DamageTypeIt})",
									Description = $"Subisci dimezzati tutti i danni di tipo {cfg.DamageTypeIt}."
								},
								new TraitTranslation
								{
									Language = LanguageCode.En,
									Name = $"Elemental Resistance ({cfg.DamageTypeEn})",
									Description = $"You take half damage from {cfg.DamageTypeEn} damage sources."
								}
							}
						}
					}
				}).ToList()
			};
		}
	}
}