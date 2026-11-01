using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Identity;

namespace RealmForge.Infrastructure.Persistence
{
	///	<summary>
	///	EF Core context (PostgreSQL): Identity tables, the ASP.NET Core data protection keys and the game content
	///	with its translation tables.
	///	</summary>
	public class RealmForgeDbContext : IdentityDbContext<ApplicationUser>, IDataProtectionKeyContext
	{
		public RealmForgeDbContext(DbContextOptions<RealmForgeDbContext> options)
			: base(options)
		{
		}

		//	Keys that sign bearer tokens and e-mail links: stored here so they survive restarts of the API container
		public DbSet<DataProtectionKey> DataProtectionKeys => Set<DataProtectionKey>();

		//	Species aggregate
		public DbSet<Species> Species => Set<Species>();
		public DbSet<SpeciesTranslation> SpeciesTranslations => Set<SpeciesTranslation>();

		//	Subspecies and Lineages aggregate
		public DbSet<Subspecies> Subspecies => Set<Subspecies>();
		public DbSet<SubspeciesTranslation> SubspeciesTranslations => Set<SubspeciesTranslation>();

		//	Traits and Abilities aggregate
		public DbSet<Trait> Traits => Set<Trait>();
		public DbSet<TraitTranslation> TraitTranslations => Set<TraitTranslation>();

		public DbSet<Feat> Feats => Set<Feat>();
		public DbSet<FeatTranslation> FeatTranslations => Set<FeatTranslation>();

		//	Backgrounds aggregate
		public DbSet<Background> Backgrounds => Set<Background>();
		public DbSet<BackgroundTranslation> BackgroundTranslations => Set<BackgroundTranslation>();

		//	Spells aggregate
		public DbSet<Spell> Spells => Set<Spell>();
		public DbSet<SpellTranslation> SpellTranslations => Set<SpellTranslation>();

		//	Equipment aggregate
		public DbSet<Equipment> Equipment => Set<Equipment>();
		public DbSet<EquipmentTranslation> EquipmentTranslations => Set<EquipmentTranslation>();

		//	Magic items aggregate
		public DbSet<MagicItem> MagicItems => Set<MagicItem>();
		public DbSet<MagicItemTranslation> MagicItemTranslations => Set<MagicItemTranslation>();

		//	Monsters
		public DbSet<Monster> Monsters => Set<Monster>();
		public DbSet<MonsterTranslation> MonsterTranslations => Set<MonsterTranslation>();

		//	Player characters
		public DbSet<Character> Characters => Set<Character>();

		//	Sharing: Homebrew entries and characters shared with chosen accounts
		public DbSet<ContentShare> ContentShares => Set<ContentShare>();
		public DbSet<CharacterShare> CharacterShares => Set<CharacterShare>();

		//	Campaigns: members and their roles, invitations, characters and shared Homebrew
		public DbSet<Campaign> Campaigns => Set<Campaign>();
		public DbSet<CampaignMember> CampaignMembers => Set<CampaignMember>();
		public DbSet<CampaignInvite> CampaignInvites => Set<CampaignInvite>();
		public DbSet<CampaignCharacter> CampaignCharacters => Set<CampaignCharacter>();
		public DbSet<CampaignContent> CampaignContents => Set<CampaignContent>();
		public DbSet<CampaignNote> CampaignNotes => Set<CampaignNote>();
		public DbSet<CampaignEncounter> CampaignEncounters => Set<CampaignEncounter>();
		public DbSet<CampaignSession> CampaignSessions => Set<CampaignSession>();
		public DbSet<CampaignRoll> CampaignRolls => Set<CampaignRoll>();

		//	The bin: deleted characters, campaigns and Homebrew, restorable for a few days
		public DbSet<TrashEntry> TrashEntries => Set<TrashEntry>();

		//	Rules glossary
		public DbSet<RuleModule> RuleModules => Set<RuleModule>();
		public DbSet<RuleModuleTranslation> RuleModuleTranslations => Set<RuleModuleTranslation>();
		public DbSet<RuleEntry> RuleEntries => Set<RuleEntry>();
		public DbSet<RuleEntryTranslation> RuleEntryTranslations => Set<RuleEntryTranslation>();

		//	Classes aggregate: classes, subclasses and the features of both
		public DbSet<CharacterClass> Classes => Set<CharacterClass>();
		public DbSet<CharacterClassTranslation> ClassTranslations => Set<CharacterClassTranslation>();
		public DbSet<Subclass> Subclasses => Set<Subclass>();
		public DbSet<SubclassTranslation> SubclassTranslations => Set<SubclassTranslation>();
		public DbSet<ClassFeature> ClassFeatures => Set<ClassFeature>();
		public DbSet<ClassFeatureTranslation> ClassFeatureTranslations => Set<ClassFeatureTranslation>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//	Nicknames: never two equal ones, whatever the case
			modelBuilder.Entity<ApplicationUser>(entity =>
			{
				entity.Property(u => u.Nickname).HasMaxLength(32);
				entity.Property(u => u.NormalizedNickname).HasMaxLength(32);
				entity.HasIndex(u => u.NormalizedNickname).IsUnique();
			});

			//	Species configuration
			modelBuilder.Entity<Species>(entity =>
			{
				entity.Property(s => s.Effects).IsRequired().HasColumnType("jsonb").HasDefaultValue("[]");
				entity.HasKey(e => e.Id);
				entity.Property(e => e.BaseSpeedInFeet).IsRequired();
				entity.Property(e => e.CreatureType).IsRequired();
				entity.Property(e => e.AllowedSizes).IsRequired();
				entity.Property(e => e.Ruleset).IsRequired();
				entity.Property(e => e.IsOfficialSRD).IsRequired();

				//	One-to-many relationship with translations
				entity.HasMany(e => e.Translations)
						.WithOne(t => t.Species)
						.HasForeignKey(t => t.SpeciesId)
						.OnDelete(DeleteBehavior.Cascade);

				//	One-to-many relationship with subspecies/lineages
				entity.HasMany(e => e.Subspecies)
						.WithOne(s => s.Species)
						.HasForeignKey(s => s.SpeciesId)
						.OnDelete(DeleteBehavior.Cascade);

				//	One-to-many relationship with base traits
				entity.HasMany(e => e.Traits)
						.WithOne(t => t.Species)
						.HasForeignKey(t => t.SpeciesId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Species translations configuration
			modelBuilder.Entity<SpeciesTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).HasMaxLength(150).IsRequired();
				entity.Property(t => t.Description).HasMaxLength(4000);

				//	Unique index: a species cannot have two translations for the same language
				entity.HasIndex(t => new { t.SpeciesId, t.Language }).IsUnique();
			});

			//	Subspecies configuration
			modelBuilder.Entity<Subspecies>(entity =>
			{
				entity.Property(s => s.Effects).IsRequired().HasColumnType("jsonb").HasDefaultValue("[]");
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Ruleset).IsRequired();
				entity.Property(e => e.IsOfficialSRD).IsRequired();

				//	One-to-many relationship with translations
				entity.HasMany(e => e.Translations)
						.WithOne(t => t.Subspecies)
						.HasForeignKey(t => t.SubspeciesId)
						.OnDelete(DeleteBehavior.Cascade);

				//	One-to-many relationship with exclusive traits
				entity.HasMany(e => e.Traits)
						.WithOne(t => t.Subspecies)
						.HasForeignKey(t => t.SubspeciesId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Subspecies translations configuration
			modelBuilder.Entity<SubspeciesTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).HasMaxLength(150).IsRequired();
				entity.Property(t => t.Description).HasMaxLength(4000);

				//	Unique index: a subspecies cannot have two translations for the same language
				entity.HasIndex(t => new { t.SubspeciesId, t.Language }).IsUnique();
			});

			//	Trait configuration
			modelBuilder.Entity<Trait>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.RequiredLevel).IsRequired().HasDefaultValue(1);
				entity.Property(e => e.Ruleset).IsRequired();
				entity.Property(e => e.IsOfficialSRD).IsRequired();

				//	One-to-many relationship with translations
				entity.HasMany(e => e.Translations)
						.WithOne(t => t.Trait)
						.HasForeignKey(t => t.TraitId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Trait translations configuration
			modelBuilder.Entity<TraitTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).HasMaxLength(150).IsRequired();
				entity.Property(t => t.Description).HasMaxLength(4000);

				//	Unique index: a trait cannot have two translations for the same language
				entity.HasIndex(t => new { t.TraitId, t.Language }).IsUnique();
			});

			//	Homebrew rule modules: effects as JSON, a translation per language
			modelBuilder.Entity<RuleModule>(entity =>
			{
				entity.HasKey(m => m.Id);
				entity.Property(m => m.Effects).IsRequired().HasColumnType("jsonb");
				entity.HasIndex(m => m.AuthorId);
				entity.HasMany(m => m.Translations)
						.WithOne(t => t.RuleModule)
						.HasForeignKey(t => t.RuleModuleId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<RuleModuleTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
				entity.Property(t => t.Description).IsRequired().HasMaxLength(8000);
				entity.HasIndex(t => new { t.RuleModuleId, t.Language }).IsUnique();
			});

			//	Feats configuration
			modelBuilder.Entity<Feat>(entity =>
			{
				//	Rule effects of a Homebrew feat (JSON list of RuleEffect), empty for Base content
				entity.Property(f => f.Effects).IsRequired().HasColumnType("jsonb").HasDefaultValue("[]");
				entity.HasKey(f => f.Id);
				entity.Property(f => f.Category).IsRequired();
				entity.Property(f => f.Ruleset).IsRequired();
				entity.Property(f => f.IsOfficialSRD).IsRequired();
				entity.Property(f => f.PrerequisiteAbilities).IsRequired();

				entity.HasMany(f => f.Translations)
						.WithOne(t => t.Feat)
						.HasForeignKey(t => t.FeatId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Feats translations configuration
			modelBuilder.Entity<FeatTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Description).IsRequired();
				entity.Property(t => t.PrerequisiteNote).HasMaxLength(300);

				//	Unique index: a feat cannot have two translations for the same language
				entity.HasIndex(t => new { t.FeatId, t.Language }).IsUnique();
			});

			//	Backgrounds configuration
			modelBuilder.Entity<Background>(entity =>
			{
				entity.HasKey(b => b.Id);
				entity.Property(b => b.Ruleset).IsRequired();
				entity.Property(b => b.IsOfficialSRD).IsRequired();
				entity.Property(b => b.AbilityOptions).IsRequired();
				entity.Property(b => b.SkillProficiencies).IsRequired();

				//	Deleting a (Homebrew) feat must not delete the backgrounds that reference it
				entity.HasOne(b => b.OriginFeat)
						.WithMany()
						.HasForeignKey(b => b.OriginFeatId)
						.OnDelete(DeleteBehavior.SetNull);

				entity.HasMany(b => b.Translations)
						.WithOne(t => t.Background)
						.HasForeignKey(t => t.BackgroundId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Background translations configuration
			modelBuilder.Entity<BackgroundTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Description).IsRequired();
				entity.Property(t => t.ToolProficiencies).HasMaxLength(500);
				entity.Property(t => t.Languages).HasMaxLength(500);
				entity.Property(t => t.Equipment).HasMaxLength(2000);
				entity.Property(t => t.OriginFeatNote).HasMaxLength(300);
				entity.Property(t => t.FeatureName).HasMaxLength(150);
				entity.Property(t => t.PersonalityTraits).IsRequired();
				entity.Property(t => t.Ideals).IsRequired();
				entity.Property(t => t.Bonds).IsRequired();
				entity.Property(t => t.Flaws).IsRequired();

				//	Unique index: a background cannot have two translations for the same language
				entity.HasIndex(t => new { t.BackgroundId, t.Language }).IsUnique();
			});

			//	Spells configuration
			modelBuilder.Entity<Spell>(entity =>
			{
				entity.HasKey(s => s.Id);
				entity.Property(s => s.Ruleset).IsRequired();
				entity.Property(s => s.IsOfficialSRD).IsRequired();
				entity.Property(s => s.Level).IsRequired();
				entity.Property(s => s.School).IsRequired();
				entity.Property(s => s.Classes).IsRequired();
				entity.ToTable(t => t.HasCheckConstraint("CK_Spells_Level", "\"Level\" BETWEEN 0 AND 9"));

				//	The list filters by ruleset and level
				entity.HasIndex(s => new { s.Ruleset, s.Level });

				entity.HasMany(s => s.Translations)
						.WithOne(t => t.Spell)
						.HasForeignKey(t => t.SpellId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Spell translations configuration
			modelBuilder.Entity<SpellTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Description).IsRequired();
				entity.Property(t => t.CastingTime).IsRequired().HasMaxLength(300);
				entity.Property(t => t.Range).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Duration).IsRequired().HasMaxLength(150);
				entity.Property(t => t.MaterialComponent).HasMaxLength(500);

				//	Unique index: a spell cannot have two translations for the same language
				entity.HasIndex(t => new { t.SpellId, t.Language }).IsUnique();
			});

			//	Equipment configuration
			modelBuilder.Entity<Equipment>(entity =>
			{
				entity.ToTable("Equipment", t =>
				{
					t.HasCheckConstraint("CK_Equipment_Cost", "\"CostInCopper\" IS NULL OR \"CostInCopper\" >= 0");
					t.HasCheckConstraint("CK_Equipment_Quantity", "\"Quantity\" >= 1");
				});
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Ruleset).IsRequired();
				entity.Property(e => e.IsOfficialSRD).IsRequired();
				entity.Property(e => e.Category).IsRequired();
				entity.Property(e => e.WeightInPounds).HasPrecision(9, 3);
				entity.Property(e => e.SpeedInMilesPerHour).HasPrecision(6, 2);
				entity.Property(e => e.DamageDice).HasMaxLength(20);
				entity.Property(e => e.VersatileDamageDice).HasMaxLength(20);
				entity.Property(e => e.WeaponProperties).IsRequired();

				//	The list filters by ruleset and category
				entity.HasIndex(e => new { e.Ruleset, e.Category });

				entity.HasMany(e => e.Translations)
						.WithOne(t => t.Equipment)
						.HasForeignKey(t => t.EquipmentId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Equipment translations configuration
			modelBuilder.Entity<EquipmentTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Description).IsRequired();

				//	Unique index: an item cannot have two translations for the same language
				entity.HasIndex(t => new { t.EquipmentId, t.Language }).IsUnique();
			});

			//	Magic items configuration: variants belong to their item
			modelBuilder.Entity<MagicItem>(entity =>
			{
				entity.ToTable("MagicItems");
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Ruleset).IsRequired();
				entity.Property(e => e.IsOfficialSRD).IsRequired();
				entity.Property(e => e.Type).IsRequired();
				entity.Property(e => e.Mechanics).HasColumnType("jsonb");

				//	The list filters by ruleset and category
				entity.HasIndex(e => new { e.Ruleset, e.Type });

				entity.HasOne(e => e.Parent)
						.WithMany(e => e.Variants)
						.HasForeignKey(e => e.ParentId)
						.OnDelete(DeleteBehavior.Cascade);

				entity.HasMany(e => e.Translations)
						.WithOne(t => t.MagicItem)
						.HasForeignKey(t => t.MagicItemId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Magic item translations configuration
			modelBuilder.Entity<MagicItemTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Subtitle).IsRequired().HasMaxLength(300);
				entity.Property(t => t.Description).IsRequired();
				entity.Property(t => t.Alias).HasMaxLength(150);

				//	Unique index: an item cannot have two translations for the same language
				entity.HasIndex(t => new { t.MagicItemId, t.Language }).IsUnique();
			});

			//	Monsters configuration: a variant loses the link (not itself) when its original is deleted
			modelBuilder.Entity<Monster>(entity =>
			{
				entity.ToTable("Monsters");
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Ruleset).IsRequired();
				entity.Property(e => e.IsOfficialSRD).IsRequired();
				entity.Property(e => e.HitDice).IsRequired().HasMaxLength(40);
				entity.Property(e => e.ChallengeRating).HasPrecision(6, 3);

				//	The list filters by ruleset, type and challenge
				entity.HasIndex(e => new { e.Ruleset, e.Type });
				entity.HasIndex(e => e.AuthorId);

				entity.HasOne(e => e.VariantOf)
						.WithMany()
						.HasForeignKey(e => e.VariantOfId)
						.OnDelete(DeleteBehavior.SetNull);

				entity.HasMany(e => e.Translations)
						.WithOne(t => t.Monster)
						.HasForeignKey(t => t.MonsterId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Monster translations configuration
			modelBuilder.Entity<MonsterTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Alias).HasMaxLength(150);
				entity.Property(t => t.Subtitle).IsRequired().HasMaxLength(300);
				entity.Property(t => t.ArmorClass).IsRequired().HasMaxLength(300);
				entity.Property(t => t.Speed).IsRequired().HasMaxLength(300);
				entity.Property(t => t.SavingThrows).IsRequired().HasMaxLength(300);
				entity.Property(t => t.Skills).IsRequired().HasMaxLength(500);
				entity.Property(t => t.DamageVulnerabilities).IsRequired().HasMaxLength(500);
				entity.Property(t => t.DamageResistances).IsRequired().HasMaxLength(500);
				entity.Property(t => t.DamageImmunities).IsRequired().HasMaxLength(500);
				entity.Property(t => t.ConditionImmunities).IsRequired().HasMaxLength(500);
				entity.Property(t => t.Senses).IsRequired().HasMaxLength(500);
				entity.Property(t => t.Languages).IsRequired().HasMaxLength(500);
				entity.Property(t => t.Traits).IsRequired();
				entity.Property(t => t.Actions).IsRequired();
				entity.Property(t => t.BonusActions).IsRequired();
				entity.Property(t => t.Reactions).IsRequired();
				entity.Property(t => t.LegendaryActions).IsRequired();
				entity.Property(t => t.Description).IsRequired();

				//	Unique index: a monster cannot have two translations for the same language
				entity.HasIndex(t => new { t.MonsterId, t.Language }).IsUnique();
			});

			//	Characters configuration: private to their owner; the compendium entries they use cannot be deleted under them
			modelBuilder.Entity<Character>(entity =>
			{
				entity.ToTable("Characters", t =>
				{
					t.HasCheckConstraint("CK_Characters_Level", "\"Level\" BETWEEN 1 AND 20");
				});
				entity.HasKey(c => c.Id);
				entity.Property(c => c.OwnerId).IsRequired().HasMaxLength(450);
				entity.Property(c => c.UpdatedById).HasMaxLength(450);
				entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
				entity.Property(c => c.Build).IsRequired().HasColumnType("jsonb");
				entity.Property(c => c.Sheet).IsRequired().HasColumnType("jsonb");

				entity.HasIndex(c => c.OwnerId);

				entity.HasOne(c => c.Species).WithMany().HasForeignKey(c => c.SpeciesId).OnDelete(DeleteBehavior.Restrict);
				entity.HasOne(c => c.Subspecies).WithMany().HasForeignKey(c => c.SubspeciesId).OnDelete(DeleteBehavior.Restrict);
				entity.HasOne(c => c.Background).WithMany().HasForeignKey(c => c.BackgroundId).OnDelete(DeleteBehavior.Restrict);
				entity.HasOne(c => c.Class).WithMany().HasForeignKey(c => c.ClassId).OnDelete(DeleteBehavior.Restrict);
			});

			//	Sharing configuration: one row per entry (or character) and account
			modelBuilder.Entity<ContentShare>(entity =>
			{
				entity.HasKey(s => s.Id);
				entity.Property(s => s.UserId).IsRequired().HasMaxLength(450);
				entity.Property(s => s.GrantedById).IsRequired().HasMaxLength(450);
				entity.HasIndex(s => new { s.EntityId, s.UserId }).IsUnique();
				entity.HasIndex(s => s.UserId);
			});

			modelBuilder.Entity<CharacterShare>(entity =>
			{
				entity.HasKey(s => s.Id);
				entity.Property(s => s.UserId).IsRequired().HasMaxLength(450);
				entity.HasIndex(s => new { s.CharacterId, s.UserId }).IsUnique();
				entity.HasIndex(s => s.UserId);
				entity.HasOne(s => s.Character).WithMany().HasForeignKey(s => s.CharacterId).OnDelete(DeleteBehavior.Cascade);
			});

			//	Campaigns configuration: everything of a campaign goes with it
			modelBuilder.Entity<Campaign>(entity =>
			{
				entity.HasKey(c => c.Id);
				entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
				entity.Property(c => c.Description).IsRequired().HasMaxLength(8000);
				entity.Property(c => c.InviteCode).HasMaxLength(32);
				entity.Property(c => c.CreatedById).IsRequired().HasMaxLength(450);
				entity.HasIndex(c => c.InviteCode).IsUnique();
			});

			modelBuilder.Entity<CampaignMember>(entity =>
			{
				entity.HasKey(m => m.Id);
				entity.Property(m => m.UserId).IsRequired().HasMaxLength(450);
				entity.Property(m => m.Color).HasMaxLength(9);
				entity.HasIndex(m => new { m.CampaignId, m.UserId }).IsUnique();
				entity.HasIndex(m => m.UserId);
				entity.HasOne(m => m.Campaign).WithMany(c => c.Members).HasForeignKey(m => m.CampaignId).OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<CampaignInvite>(entity =>
			{
				entity.HasKey(i => i.Id);
				entity.Property(i => i.UserId).IsRequired().HasMaxLength(450);
				entity.Property(i => i.InvitedById).IsRequired().HasMaxLength(450);
				entity.HasIndex(i => new { i.CampaignId, i.UserId }).IsUnique();
				entity.HasIndex(i => i.UserId);
				entity.HasOne(i => i.Campaign).WithMany(c => c.Invites).HasForeignKey(i => i.CampaignId).OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<CampaignCharacter>(entity =>
			{
				entity.HasKey(c => c.Id);
				entity.Property(c => c.AddedById).IsRequired().HasMaxLength(450);
				entity.HasIndex(c => new { c.CampaignId, c.CharacterId }).IsUnique();
				entity.HasIndex(c => c.CharacterId);
				entity.HasOne(c => c.Campaign).WithMany(c => c.Characters).HasForeignKey(c => c.CampaignId).OnDelete(DeleteBehavior.Cascade);
				entity.HasOne(c => c.Character).WithMany().HasForeignKey(c => c.CharacterId).OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<CampaignContent>(entity =>
			{
				entity.HasKey(c => c.Id);
				entity.Property(c => c.SharedById).IsRequired().HasMaxLength(450);
				entity.Property(c => c.ReviewedById).HasMaxLength(450);
				entity.HasIndex(c => new { c.CampaignId, c.EntityId }).IsUnique();
				entity.HasIndex(c => c.EntityId);
				entity.HasOne(c => c.Campaign).WithMany(c => c.Contents).HasForeignKey(c => c.CampaignId).OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<CampaignNote>(entity =>
			{
				entity.HasKey(n => n.Id);
				entity.Property(n => n.AuthorId).IsRequired().HasMaxLength(450);
				entity.Property(n => n.Title).IsRequired().HasMaxLength(120);
				entity.Property(n => n.Body).IsRequired().HasMaxLength(8000);
				entity.HasIndex(n => new { n.CampaignId, n.Kind });
				entity.HasOne(n => n.Campaign).WithMany(c => c.Notes).HasForeignKey(n => n.CampaignId).OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<CampaignEncounter>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
				entity.Property(e => e.Notes).IsRequired().HasMaxLength(8000);
				entity.Property(e => e.Combatants).IsRequired().HasColumnType("jsonb");
				entity.Property(e => e.PartyIds).IsRequired();
				entity.Property(e => e.CreatedById).IsRequired().HasMaxLength(450);
				entity.HasIndex(e => e.CampaignId);
				entity.HasOne(e => e.Campaign).WithMany(c => c.Encounters).HasForeignKey(e => e.CampaignId).OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<CampaignSession>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Title).IsRequired().HasMaxLength(120);
				entity.Property(e => e.Plan).IsRequired().HasMaxLength(8000);
				entity.Property(e => e.Recap).IsRequired().HasMaxLength(8000);
				entity.Property(e => e.MasterNotes).IsRequired().HasMaxLength(8000);
				entity.Property(e => e.UpdatedById).IsRequired().HasMaxLength(450);
				entity.HasIndex(e => new { e.CampaignId, e.Number });
				entity.HasOne(e => e.Campaign).WithMany(c => c.Sessions).HasForeignKey(e => e.CampaignId).OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<CampaignRoll>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.UserId).IsRequired().HasMaxLength(450);
				entity.Property(e => e.CharacterName).HasMaxLength(100);
				entity.Property(e => e.Roller).IsRequired().HasMaxLength(100);
				entity.Property(e => e.Color).IsRequired().HasMaxLength(9);
				entity.Property(e => e.Label).IsRequired().HasMaxLength(120);
				entity.Property(e => e.Expression).IsRequired().HasMaxLength(80);
				entity.Property(e => e.Dice).IsRequired().HasColumnType("jsonb");
				entity.Property(e => e.Note).HasMaxLength(200);
				entity.HasIndex(e => new { e.CampaignId, e.CreatedAt });
				entity.HasOne(e => e.Campaign).WithMany(c => c.Rolls).HasForeignKey(e => e.CampaignId).OnDelete(DeleteBehavior.Cascade);
			});

			//	Rules glossary configuration
			modelBuilder.Entity<TrashEntry>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.UserId).IsRequired().HasMaxLength(450);
				entity.Property(t => t.Kind).IsRequired().HasMaxLength(32);
				entity.Property(t => t.NameIt).IsRequired().HasMaxLength(300);
				entity.Property(t => t.NameEn).IsRequired().HasMaxLength(300);
				entity.Property(t => t.Payload).IsRequired();
				entity.HasIndex(t => new { t.UserId, t.ExpiresAt });
				entity.HasIndex(t => t.ExpiresAt);
			});

			modelBuilder.Entity<RuleEntry>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Ruleset).IsRequired();
				entity.Property(e => e.IsOfficialSRD).IsRequired();
				entity.Property(e => e.Category).IsRequired();
				entity.Property(e => e.Key).IsRequired().HasMaxLength(100);
				entity.Property(e => e.RelatedKeys).IsRequired();

				//	A key identifies an entry within its edition
				entity.HasIndex(e => new { e.Ruleset, e.Key }).IsUnique();

				entity.HasMany(e => e.Translations)
						.WithOne(t => t.RuleEntry)
						.HasForeignKey(t => t.RuleEntryId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Rules glossary translations configuration
			modelBuilder.Entity<RuleEntryTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Description).IsRequired();
				entity.Property(t => t.Aliases).IsRequired();

				//	Unique index: an entry cannot have two translations for the same language
				entity.HasIndex(t => new { t.RuleEntryId, t.Language }).IsUnique();
			});

			//	Classes configuration
			modelBuilder.Entity<CharacterClass>(entity =>
			{
				entity.ToTable("Classes", t =>
				{
					t.HasCheckConstraint("CK_Classes_HitDie", "\"HitDie\" IN (6, 8, 10, 12)");
					t.HasCheckConstraint("CK_Classes_SubclassLevel", "\"SubclassLevel\" BETWEEN 1 AND 20");
				});
				entity.HasKey(c => c.Id);
				entity.Property(c => c.Ruleset).IsRequired();
				entity.Property(c => c.IsOfficialSRD).IsRequired();
				entity.Property(c => c.PrimaryAbilities).IsRequired();
				entity.Property(c => c.SavingThrows).IsRequired();
				entity.Property(c => c.SkillOptions).IsRequired();

				entity.HasMany(c => c.Translations)
						.WithOne(t => t.CharacterClass)
						.HasForeignKey(t => t.CharacterClassId)
						.OnDelete(DeleteBehavior.Cascade);

				entity.HasMany(c => c.Features)
						.WithOne(f => f.CharacterClass)
						.HasForeignKey(f => f.CharacterClassId)
						.OnDelete(DeleteBehavior.Cascade);

				entity.HasMany(c => c.Subclasses)
						.WithOne(s => s.CharacterClass)
						.HasForeignKey(s => s.CharacterClassId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<CharacterClassTranslation>(entity =>
			{
				entity.ToTable("ClassTranslations");
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Description).IsRequired();
				entity.Property(t => t.SubclassTitle).HasMaxLength(150);
				entity.Property(t => t.ArmorProficiencies).HasMaxLength(500);
				entity.Property(t => t.WeaponProficiencies).HasMaxLength(500);
				entity.Property(t => t.ToolProficiencies).HasMaxLength(500);
				entity.Property(t => t.StartingEquipment).HasMaxLength(4000);

				//	Unique index: a class cannot have two translations for the same language
				entity.HasIndex(t => new { t.CharacterClassId, t.Language }).IsUnique();
			});

			//	Subclasses configuration
			modelBuilder.Entity<Subclass>(entity =>
			{
				entity.HasKey(s => s.Id);
				entity.Property(s => s.Ruleset).IsRequired();
				entity.Property(s => s.IsOfficialSRD).IsRequired();

				entity.HasMany(s => s.Translations)
						.WithOne(t => t.Subclass)
						.HasForeignKey(t => t.SubclassId)
						.OnDelete(DeleteBehavior.Cascade);

				entity.HasMany(s => s.Features)
						.WithOne(f => f.Subclass)
						.HasForeignKey(f => f.SubclassId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<SubclassTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Description).IsRequired();

				//	Unique index: a subclass cannot have two translations for the same language
				entity.HasIndex(t => new { t.SubclassId, t.Language }).IsUnique();
			});

			//	Class features configuration: each feature belongs to exactly one class or one subclass
			modelBuilder.Entity<ClassFeature>(entity =>
			{
				entity.Property(f => f.Effects).IsRequired().HasColumnType("jsonb").HasDefaultValue("[]");
				entity.ToTable(t =>
				{
					t.HasCheckConstraint("CK_ClassFeatures_Level", "\"Level\" BETWEEN 1 AND 20");
					t.HasCheckConstraint("CK_ClassFeatures_Owner", "(\"CharacterClassId\" IS NULL) <> (\"SubclassId\" IS NULL)");
				});
				entity.HasKey(f => f.Id);
				entity.Property(f => f.Ruleset).IsRequired();
				entity.Property(f => f.IsOfficialSRD).IsRequired();

				entity.HasMany(f => f.Translations)
						.WithOne(t => t.ClassFeature)
						.HasForeignKey(t => t.ClassFeatureId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<ClassFeatureTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Description).IsRequired();

				//	Unique index: a feature cannot have two translations for the same language
				entity.HasIndex(t => new { t.ClassFeatureId, t.Language }).IsUnique();
			});
		}
	}
}