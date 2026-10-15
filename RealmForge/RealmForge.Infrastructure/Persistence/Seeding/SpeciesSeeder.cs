using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Common;
using RealmForge.Domain.Entities;
using RealmForge.Infrastructure.Persistence.Seeding.SpeciesData;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding
{
	///	<summary>
	///	Synchronizes the official SRD species (with their lineages and traits) with the database.
	///	Missing species are inserted; existing SRD species, lineages and traits are updated to match the seed,
	///	SRD traits/lineages no longer in the seed are removed. Homebrew rows are never touched,
	///	including Homebrew lineages attached to an SRD species.
	///	</summary>
	public static class SpeciesSeeder
	{
		///	<summary>
		///	Every species definition, discovered from the static classes in the SpeciesData namespace
		///	that expose <c>public static Species Build()</c>, with stable ids on every row.
		///	</summary>
		public static IReadOnlyList<Species> GetDefinitions()
		{
			var builders = typeof(Elf2024Seeder).Assembly.GetTypes()
				.Where(t => t.Namespace == typeof(Elf2024Seeder).Namespace && t.IsAbstract && t.IsSealed)
				.Select(t => t.GetMethod("Build", BindingFlags.Public | BindingFlags.Static, Type.EmptyTypes))
				.Where(m => m is not null && m.ReturnType == typeof(Species))
				.Select(m => m!)
				.OrderBy(m => m.DeclaringType!.Name)
				.ToList();

			var definitions = new List<Species>();

			foreach (var build in builders)
			{
				//	Ids that differ between two builds are Guid.NewGuid() defaults: replace them with deterministic ones
				var first = (Species)build.Invoke(null, null)!;
				var second = (Species)build.Invoke(null, null)!;
				AssignStableIds(first, second);
				definitions.Add(first);
			}

			EnsureUniqueIds(definitions);
			return definitions;
		}

		public static void EnsureUniqueIds(IEnumerable<Species> definitions)
		{
			var ids = new List<Guid>();

			foreach (var species in definitions)
			{
				ids.Add(species.Id);
				ids.AddRange(species.Translations.Select(t => t.Id));

				foreach (var trait in species.Traits)
				{
					ids.Add(trait.Id);
					ids.AddRange(trait.Translations.Select(t => t.Id));
				}

				foreach (var sub in species.Subspecies)
				{
					ids.Add(sub.Id);
					ids.AddRange(sub.Translations.Select(t => t.Id));

					foreach (var trait in sub.Traits)
					{
						ids.Add(trait.Id);
						ids.AddRange(trait.Translations.Select(t => t.Id));
					}
				}
			}

			var duplicates = ids.GroupBy(id => id).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
			if (duplicates.Count > 0)
			{
				throw new InvalidOperationException($"Duplicate ids in species seed data: [{string.Join(", ", duplicates)}]");
			}
		}

		public static async Task SeedAsync(RealmForgeDbContext context, CancellationToken cancellationToken = default)
		{
			var definitions = GetDefinitions();
			var ids = definitions.Select(d => d.Id).ToList();

			var existing = await context.Species
				.Include(s => s.Translations)
				.Include(s => s.Traits).ThenInclude(t => t.Translations)
				.Include(s => s.Subspecies).ThenInclude(sub => sub.Translations)
				.Include(s => s.Subspecies).ThenInclude(sub => sub.Traits).ThenInclude(t => t.Translations)
				.AsSplitQuery()
				.Where(s => ids.Contains(s.Id))
				.ToDictionaryAsync(s => s.Id, cancellationToken);

			foreach (var definition in definitions)
			{
				if (!existing.TryGetValue(definition.Id, out var species))
				{
					context.Species.Add(definition);
					continue;
				}

				if (!species.IsOfficialSRD)
				{
					continue;
				}

				species.BaseSpeedInFeet = definition.BaseSpeedInFeet;
				species.CreatureType = definition.CreatureType;
				species.AllowedSizes = definition.AllowedSizes;
				species.Ruleset = definition.Ruleset;

				SyncSpeciesTranslations(context, species, definition);
				SyncTraits(context, species.Traits, definition.Traits);
				SyncSubspecies(context, species, definition);
			}

			//	Single transaction: either the whole SRD set is synchronized or nothing changes
			await context.SaveChangesAsync(cancellationToken);
		}

		#region Synchronization

		private static void SyncSpeciesTranslations(RealmForgeDbContext context, Species target, Species source)
		{
			foreach (var tr in source.Translations)
			{
				var current = target.Translations.FirstOrDefault(t => t.Language == tr.Language);
				if (current is null)
				{
					context.SpeciesTranslations.Add(new SpeciesTranslation { Id = tr.Id, SpeciesId = target.Id, Language = tr.Language, Name = tr.Name, Description = tr.Description });
				}
				else
				{
					current.Name = tr.Name;
					current.Description = tr.Description;
				}
			}
		}

		private static void SyncSubspecies(RealmForgeDbContext context, Species target, Species source)
		{
			var sourceIds = source.Subspecies.Select(s => s.Id).ToHashSet();

			//	SRD lineages removed from the seed (or stored with old random ids) are deleted; Homebrew lineages stay
			foreach (var stale in target.Subspecies.Where(s => s.IsOfficialSRD && !sourceIds.Contains(s.Id)).ToList())
			{
				context.Subspecies.Remove(stale);
			}

			foreach (var sub in source.Subspecies)
			{
				var current = target.Subspecies.FirstOrDefault(s => s.Id == sub.Id);
				if (current is null)
				{
					//	New rows with preset Guid keys must be added through the context, otherwise EF treats them as existing
					sub.SpeciesId = target.Id;
					context.Subspecies.Add(sub);
					continue;
				}

				current.BaseSpeedOverrideInFeet = sub.BaseSpeedOverrideInFeet;
				current.Ruleset = sub.Ruleset;

				foreach (var tr in sub.Translations)
				{
					var currentTr = current.Translations.FirstOrDefault(t => t.Language == tr.Language);
					if (currentTr is null)
					{
						context.SubspeciesTranslations.Add(new SubspeciesTranslation { Id = tr.Id, SubspeciesId = current.Id, Language = tr.Language, Name = tr.Name, Description = tr.Description });
					}
					else
					{
						currentTr.Name = tr.Name;
						currentTr.Description = tr.Description;
					}
				}

				SyncTraits(context, current.Traits, sub.Traits);
			}
		}

		private static void SyncTraits(RealmForgeDbContext context, ICollection<Trait> target, ICollection<Trait> source)
		{
			var sourceIds = source.Select(t => t.Id).ToHashSet();

			//	Explicit delete: Trait has nullable owner keys, so removing it from the collection alone would orphan it
			foreach (var stale in target.Where(t => t.IsOfficialSRD && !sourceIds.Contains(t.Id)).ToList())
			{
				context.Traits.Remove(stale);
			}

			foreach (var trait in source)
			{
				var current = target.FirstOrDefault(t => t.Id == trait.Id);
				if (current is null)
				{
					//	Owner FK is fixed up from the collection on SaveChanges; Add marks the trait and its translations as new rows
					target.Add(trait);
					context.Traits.Add(trait);
					continue;
				}

				current.RequiredLevel = trait.RequiredLevel;
				current.Ruleset = trait.Ruleset;

				foreach (var tr in trait.Translations)
				{
					var currentTr = current.Translations.FirstOrDefault(t => t.Language == tr.Language);
					if (currentTr is null)
					{
						context.TraitTranslations.Add(new TraitTranslation { Id = tr.Id, TraitId = current.Id, Language = tr.Language, Name = tr.Name, Description = tr.Description });
					}
					else
					{
						currentTr.Name = tr.Name;
						currentTr.Description = tr.Description;
					}
				}
			}
		}

		#endregion

		#region Stable ids

		private static void AssignStableIds(Species a, Species b)
		{
			var speciesKey = $"species:{a.Id}";

			Stabilize(a.Translations.ToList(), b.Translations.ToList(), (x, y) => x.Id == y.Id,
				(t) => t.Id = DeterministicGuid.Create($"{speciesKey}:tr:{Lang(t.Language)}"));

			StabilizeTraits(a.Traits.ToList(), b.Traits.ToList(), speciesKey);

			var subsA = a.Subspecies.ToList();
			var subsB = b.Subspecies.ToList();

			for (var i = 0; i < subsA.Count; i++)
			{
				var subA = subsA[i];
				var subB = subsB[i];

				if (subA.Id != subB.Id)
				{
					subA.Id = DeterministicGuid.Create($"{speciesKey}:subspecies:{Slug(EnglishName(subA.Translations))}");
				}

				var subKey = $"subspecies:{subA.Id}";
				Stabilize(subA.Translations.ToList(), subB.Translations.ToList(), (x, y) => x.Id == y.Id,
					(t) => t.Id = DeterministicGuid.Create($"{subKey}:tr:{Lang(t.Language)}"));

				StabilizeTraits(subA.Traits.ToList(), subB.Traits.ToList(), subKey);
			}
		}

		private static void StabilizeTraits(List<Trait> a, List<Trait> b, string ownerKey)
		{
			for (var i = 0; i < a.Count; i++)
			{
				if (a[i].Id != b[i].Id)
				{
					a[i].Id = DeterministicGuid.Create($"{ownerKey}:trait:{Slug(EnglishName(a[i].Translations))}");
				}

				var traitKey = $"trait:{a[i].Id}";
				Stabilize(a[i].Translations.ToList(), b[i].Translations.ToList(), (x, y) => x.Id == y.Id,
					(t) => t.Id = DeterministicGuid.Create($"{traitKey}:tr:{Lang(t.Language)}"));
			}
		}

		private static void Stabilize<T>(List<T> a, List<T> b, Func<T, T, bool> sameId, Action<T> assign)
		{
			for (var i = 0; i < a.Count; i++)
			{
				if (!sameId(a[i], b[i]))
				{
					assign(a[i]);
				}
			}
		}

		private static string EnglishName<T>(IEnumerable<T> translations) where T : ITranslation =>
			translations.FirstOrDefault(t => t.Language == LanguageCode.En)?.Name
			?? translations.First().Name;

		private static string Lang(LanguageCode language) => language.ToString().ToLowerInvariant();

		private static string Slug(string value) =>
			Regex.Replace(value.ToLowerInvariant(), "[^a-z0-9]+", "-").Trim('-');

		#endregion
	}
}
