using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RealmForge.Domain.Common;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using RealmForge.Shared.Trash;

namespace RealmForge.Infrastructure.Persistence.Trash
{
	///	<summary>
	///	The outcome of a restore: done, or the reason it cannot be done (the entry it depends on, by kind, no longer
	///	exists; or the database refused the rows).
	///	</summary>
	public sealed record TrashRestoreResult(bool Ok, string? MissingKind = null, bool Conflict = false);

	///	<summary>
	///	Keeps what an account deletes for <see cref="TrashRules.RetentionDays"/> days. Before a deletion the entity and
	///	every row the database deletes with it (the dependents of cascading relationships, recursively) are saved as
	///	JSON, together with the rows whose reference the deletion sets to null; a restore inserts the rows again with
	///	their own ids and puts the references back. Rows that point to something deleted in the meantime (a campaign
	///	link to a character that is gone) are left out; the entry itself cannot come back without what it depends on.
	///	</summary>
	public class TrashBin
	{
		private static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

		private static readonly MethodInfo QueryMethod =
			typeof(TrashBin).GetMethod(nameof(QueryByAsync), BindingFlags.NonPublic | BindingFlags.Static)!;

		//	Entity types named by kind in the messages of a failed restore
		private static readonly Dictionary<Type, string> KindOfType = new()
		{
			[typeof(Character)] = "character",
			[typeof(Campaign)] = "campaign",
			[typeof(Species)] = "species",
			[typeof(Subspecies)] = "subspecies",
			[typeof(CharacterClass)] = "class",
			[typeof(Subclass)] = "subclass",
			[typeof(Background)] = "background",
			[typeof(Feat)] = "feat",
			[typeof(Spell)] = "spell",
			[typeof(Equipment)] = "equipment",
			[typeof(Monster)] = "monster",
			[typeof(MagicItem)] = "magic-item",
			[typeof(RuleModule)] = "module"
		};

		private readonly RealmForgeDbContext _context;

		public TrashBin(RealmForgeDbContext context)
		{
			_context = context;
		}

		private sealed class Payload
		{
			public List<Row> Rows { get; set; } = new();
			public List<Row> Nulled { get; set; } = new();
		}

		//	A row: its entity type and the values of its properties (for Nulled: the key and the foreign key cleared)
		private sealed class Row
		{
			public string Type { get; set; } = string.Empty;
			public Dictionary<string, JsonElement> Values { get; set; } = new();
		}

		///	<summary>
		///	Saves the entity and what goes with it as an entry of the user's bin. Called before the entity is removed:
		///	the entry is written by the same SaveChanges, so a deletion that fails leaves no entry behind.
		///	</summary>
		public async Task AddAsync(object entity, string kind, string userId, Guid entityId)
		{
			var payload = new Payload();
			var seen = new HashSet<string>();
			await CollectAsync(entity, payload, seen);

			var (nameIt, nameEn) = Names(entity);
			var now = DateTimeOffset.UtcNow;
			_context.TrashEntries.Add(new TrashEntry
			{
				UserId = userId,
				Kind = kind,
				EntityId = entityId,
				NameIt = nameIt.Length > 300 ? nameIt[..300] : nameIt,
				NameEn = nameEn.Length > 300 ? nameEn[..300] : nameEn,
				DeletedAt = now,
				ExpiresAt = now + TrashRules.Retention,
				Payload = JsonSerializer.Serialize(payload, Json)
			});
		}

		///	<summary>
		///	Puts the rows of an entry back. The caller removes the entry and saves.
		///	</summary>
		public async Task<TrashRestoreResult> RestoreAsync(TrashEntry entry)
		{
			var payload = JsonSerializer.Deserialize<Payload>(entry.Payload, Json) ?? new Payload();
			if (payload.Rows.Count == 0)
			{
				return new TrashRestoreResult(false, Conflict: true);
			}

			//	Rows restored so far, by key: what the next rows may point to
			var restoring = new HashSet<string>();
			var root = true;
			foreach (var row in payload.Rows)
			{
				var type = _context.Model.FindEntityType(row.Type);
				if (type is null)
				{
					if (root)
					{
						return new TrashRestoreResult(false, Conflict: true);
					}
					continue;
				}

				var values = type.GetProperties().ToDictionary(p => p.Name, p => row.Values.TryGetValue(p.Name, out var v) ? v.Deserialize(p.ClrType, Json) : null);
				var key = KeyOf(type, type.FindPrimaryKey()!.Properties.Select(p => values[p.Name]).ToArray());

				//	The entry itself must not exist already; a dependent row that does is left as it is
				if (await _context.FindAsync(type.ClrType, type.FindPrimaryKey()!.Properties.Select(p => values[p.Name]).ToArray()) is not null)
				{
					if (root)
					{
						return new TrashRestoreResult(false, Conflict: true);
					}
					continue;
				}

				string? missing = null;
				foreach (var fk in type.GetForeignKeys())
				{
					var fkValues = fk.Properties.Select(p => values[p.Name]).ToArray();
					if (fkValues.Any(v => v is null) || !fk.PrincipalKey.IsPrimaryKey())
					{
						continue;
					}
					if (restoring.Contains(KeyOf(fk.PrincipalEntityType, fkValues)) || await _context.FindAsync(fk.PrincipalEntityType.ClrType, fkValues) is not null)
					{
						continue;
					}
					missing = KindOfType.GetValueOrDefault(fk.PrincipalEntityType.ClrType, fk.PrincipalEntityType.ClrType.Name.ToLowerInvariant());
					break;
				}
				if (missing is not null)
				{
					if (root)
					{
						return new TrashRestoreResult(false, MissingKind: missing);
					}
					continue;
				}

				//	Mapped properties set on the object before it is tracked (so that its key is kept), shadow ones after
				var instance = Activator.CreateInstance(type.ClrType, nonPublic: true)!;
				foreach (var property in type.GetProperties().Where(p => !p.IsShadowProperty()))
				{
					var value = values[property.Name];
					if (property.PropertyInfo is { SetMethod: not null } info)
					{
						info.SetValue(instance, value);
					}
					else
					{
						property.FieldInfo?.SetValue(instance, value);
					}
				}
				var instanceEntry = _context.Add(instance);
				foreach (var property in type.GetProperties().Where(p => p.IsShadowProperty()))
				{
					instanceEntry.Property(property.Name).CurrentValue = values[property.Name];
				}
				restoring.Add(key);
				root = false;
			}

			//	References the deletion set to null point to the entry again, when nobody changed them since
			foreach (var row in payload.Nulled)
			{
				var type = _context.Model.FindEntityType(row.Type);
				if (type is null)
				{
					continue;
				}
				var keyValues = type.FindPrimaryKey()!.Properties
					.Select(p => row.Values.TryGetValue(p.Name, out var v) ? v.Deserialize(p.ClrType, Json) : null)
					.ToArray();
				if (keyValues.Any(v => v is null) || await _context.FindAsync(type.ClrType, keyValues) is not { } dependent)
				{
					continue;
				}
				var dependentEntry = _context.Entry(dependent);
				var cleared = row.Values.Keys.Where(k => type.FindPrimaryKey()!.Properties.All(p => p.Name != k)).ToList();
				if (cleared.All(name => dependentEntry.Property(name).CurrentValue is null))
				{
					foreach (var name in cleared)
					{
						var property = type.FindProperty(name)!;
						dependentEntry.Property(name).CurrentValue = row.Values[name].Deserialize(property.ClrType, Json);
					}
				}
			}

			return new TrashRestoreResult(true);
		}

		///	<summary>
		///	Deletes for good what has been in the bin longer than the retention.
		///	</summary>
		public static Task<int> PurgeAsync(RealmForgeDbContext context, CancellationToken cancellationToken = default)
		{
			var now = DateTimeOffset.UtcNow;
			return context.TrashEntries.Where(t => t.ExpiresAt <= now).ExecuteDeleteAsync(cancellationToken);
		}

		// ===== Snapshot =====

		private async Task CollectAsync(object entity, Payload payload, HashSet<string> seen)
		{
			var entry = _context.Entry(entity);
			var type = entry.Metadata;
			var keyValues = type.FindPrimaryKey()!.Properties.Select(p => entry.Property(p.Name).CurrentValue).ToArray();
			if (!seen.Add(KeyOf(type, keyValues)))
			{
				return;
			}

			payload.Rows.Add(new Row
			{
				Type = type.Name,
				Values = type.GetProperties().ToDictionary(p => p.Name, p => JsonSerializer.SerializeToElement(entry.Property(p.Name).CurrentValue, p.ClrType, Json))
			});

			foreach (var fk in type.GetReferencingForeignKeys())
			{
				if (!fk.PrincipalKey.IsPrimaryKey())
				{
					continue;
				}
				var dependentType = fk.DeclaringEntityType;
				var cascade = fk.DeleteBehavior is DeleteBehavior.Cascade or DeleteBehavior.ClientCascade;
				var nulls = fk.DeleteBehavior is DeleteBehavior.SetNull or DeleteBehavior.ClientSetNull;
				if (!cascade && !nulls)
				{
					continue;
				}

				var query = (Task<List<object>>)QueryMethod.MakeGenericMethod(dependentType.ClrType)
					.Invoke(null, new object?[] { _context, fk.Properties, keyValues })!;
				foreach (var dependent in await query)
				{
					if (cascade)
					{
						await CollectAsync(dependent, payload, seen);
						continue;
					}

					var dependentEntry = _context.Entry(dependent);
					var values = dependentType.FindPrimaryKey()!.Properties
						.ToDictionary(p => p.Name, p => JsonSerializer.SerializeToElement(dependentEntry.Property(p.Name).CurrentValue, p.ClrType, Json));
					foreach (var p in fk.Properties)
					{
						values[p.Name] = JsonSerializer.SerializeToElement(dependentEntry.Property(p.Name).CurrentValue, p.ClrType, Json);
					}
					payload.Nulled.Add(new Row { Type = dependentType.Name, Values = values });
				}
			}
		}

		//	The rows of a type whose foreign key equals the given values
		private static async Task<List<object>> QueryByAsync<T>(DbContext context, IReadOnlyList<IProperty> properties, object?[] values) where T : class
		{
			var e = Expression.Parameter(typeof(T), "e");
			Expression? body = null;
			for (var i = 0; i < properties.Count; i++)
			{
				var property = properties[i];
				var access = Expression.Call(typeof(EF), nameof(EF.Property), new[] { property.ClrType }, e, Expression.Constant(property.Name));
				var equal = Expression.Equal(access, Expression.Constant(values[i], property.ClrType));
				body = body is null ? equal : Expression.AndAlso(body, equal);
			}
			var rows = await context.Set<T>().Where(Expression.Lambda<Func<T, bool>>(body!, e)).ToListAsync();
			return rows.Cast<object>().ToList();
		}

		private static string KeyOf(IReadOnlyTypeBase type, object?[] values) =>
			$"{type.Name}|{string.Join("|", values.Select(v => v?.ToString()))}";

		//	The name in Italian and English: the entity's own name, or the names of its translations (loaded with the
		//	snapshot, so the navigation is filled)
		private static (string It, string En) Names(object entity)
		{
			if (entity.GetType().GetProperty("Name")?.GetValue(entity) is string name && name.Length > 0)
			{
				return (name, name);
			}
			var translations = (entity.GetType().GetProperty("Translations")?.GetValue(entity) as System.Collections.IEnumerable)?
				.OfType<ITranslation>().ToList() ?? new List<ITranslation>();
			var it = translations.FirstOrDefault(t => t.Language == LanguageCode.It)?.Name;
			var en = translations.FirstOrDefault(t => t.Language == LanguageCode.En)?.Name;
			var any = it ?? en ?? translations.FirstOrDefault()?.Name ?? "?";
			return (it ?? any, en ?? any);
		}
	}
}
