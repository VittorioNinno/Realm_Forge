using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RealmForge.Domain.Common;
using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Content
{
	///	<summary>A row of content as JSON: its entity type and the values of its columns.</summary>
	public sealed class ContentRow
	{
		public string Type { get; set; } = string.Empty;
		public Dictionary<string, JsonElement> Values { get; set; } = new();
	}

	///	<summary>
	///	Copies Homebrew and Base content as rows of JSON and back as new content: an entry with what belongs to it (its
	///	translations, the traits of a species, the features and subclasses of a class, recursively along the cascading
	///	relationships, content only). A copy gets new ids (the references among its own rows follow them), belongs to the
	///	account that makes it, is private Homebrew. References to content outside the copy stay when that content exists
	///	here; otherwise an optional reference is cleared and a required one makes the copy fail (by kind).
	///	</summary>
	public class ContentCopier
	{
		public static readonly JsonSerializerOptions Json = new(JsonSerializerDefaults.Web);

		//	The content types a copy may hold, by the kind its root goes by (the kinds of the bin)
		public static readonly IReadOnlyDictionary<string, Type> Kinds = new Dictionary<string, Type>
		{
			["species"] = typeof(Species),
			["subspecies"] = typeof(Subspecies),
			["class"] = typeof(CharacterClass),
			["subclass"] = typeof(Subclass),
			["background"] = typeof(Background),
			["feat"] = typeof(Feat),
			["spell"] = typeof(Spell),
			["equipment"] = typeof(Equipment),
			["monster"] = typeof(Monster),
			["magic-item"] = typeof(MagicItem),
			["module"] = typeof(RuleModule)
		};

		//	At most this many rows in one copy (a class with all its features and subclasses fits many times)
		public const int MaxRows = 3000;

		private static readonly MethodInfo QueryMethod =
			typeof(ContentCopier).GetMethod(nameof(QueryByAsync), BindingFlags.NonPublic | BindingFlags.Static)!;

		private readonly RealmForgeDbContext _context;

		public ContentCopier(RealmForgeDbContext context)
		{
			_context = context;
		}

		public static string? KindOf(Type type) => Kinds.FirstOrDefault(k => k.Value == type).Key;

		//	Rows of content: Homebrew and Base entries and their translations
		private static bool IsContent(Type type) => typeof(GameEntity).IsAssignableFrom(type) || typeof(ITranslation).IsAssignableFrom(type);

		///	<summary>The rows of an entry and of what belongs to it, the entry first.</summary>
		public async Task<List<ContentRow>> SnapshotAsync(object entity)
		{
			var rows = new List<ContentRow>();
			await CollectAsync(entity, rows, new HashSet<string>());
			return rows;
		}

		private async Task CollectAsync(object entity, List<ContentRow> rows, HashSet<string> seen)
		{
			var entry = _context.Entry(entity);
			var type = entry.Metadata;
			var keyValues = type.FindPrimaryKey()!.Properties.Select(p => entry.Property(p.Name).CurrentValue).ToArray();
			if (!seen.Add($"{type.Name}|{string.Join("|", keyValues)}") || rows.Count >= MaxRows)
			{
				return;
			}
			rows.Add(new ContentRow
			{
				Type = type.ClrType.Name,
				//	Who wrote it is not part of the content (the copy belongs to whoever makes it)
				Values = type.GetProperties().Where(p => p.Name != nameof(GameEntity.AuthorId)).ToDictionary(p => p.Name, p => JsonSerializer.SerializeToElement(entry.Property(p.Name).CurrentValue, p.ClrType, Json))
			});
			foreach (var fk in type.GetReferencingForeignKeys())
			{
				if (!fk.PrincipalKey.IsPrimaryKey() || fk.DeleteBehavior is not (DeleteBehavior.Cascade or DeleteBehavior.ClientCascade) || !IsContent(fk.DeclaringEntityType.ClrType))
				{
					continue;
				}
				var query = (Task<List<object>>)QueryMethod.MakeGenericMethod(fk.DeclaringEntityType.ClrType)
					.Invoke(null, new object?[] { _context, fk.Properties, keyValues })!;
				foreach (var dependent in await query)
				{
					await CollectAsync(dependent, rows, seen);
				}
			}
		}

		///	<summary>
		///	New content from rows (a snapshot of this RealmForge or of another one): added to the context, not saved. The
		///	root is the first row; the result is its new entity, or the kind of the content it needs and is missing here.
		///	</summary>
		public async Task<(object? Root, string? Missing)> InsertAsync(IReadOnlyList<ContentRow> rows, string authorId, Action<object>? root = null)
		{
			if (rows.Count == 0 || rows.Count > MaxRows)
			{
				return (null, "empty");
			}
			var types = new List<IEntityType>();
			foreach (var row in rows)
			{
				var type = _context.Model.GetEntityTypes().FirstOrDefault(t => t.ClrType.Name == row.Type && IsContent(t.ClrType));
				if (type is null || type.FindPrimaryKey() is not { Properties: [{ ClrType: var keyType }] } || keyType != typeof(Guid))
				{
					return (null, "type");
				}
				types.Add(type);
			}
			if (KindOf(types[0].ClrType) is null)
			{
				return (null, "type");
			}

			//	New ids for every row, the references among the rows following them
			var ids = new Dictionary<Guid, Guid>();
			for (var i = 0; i < rows.Count; i++)
			{
				var key = types[i].FindPrimaryKey()!.Properties[0].Name;
				if (rows[i].Values.TryGetValue(key, out var old) && old.ValueKind == JsonValueKind.String && Guid.TryParse(old.GetString(), out var id))
				{
					ids[id] = Guid.NewGuid();
				}
			}
			object? first = null;
			for (var i = 0; i < rows.Count; i++)
			{
				var type = types[i];
				var instance = Activator.CreateInstance(type.ClrType, nonPublic: true)!;
				var foreignKeys = type.GetForeignKeys().SelectMany(f => f.Properties).Select(p => p.Name).ToHashSet();
				foreach (var property in type.GetProperties().Where(p => !p.IsShadowProperty() && p.PropertyInfo is { SetMethod: not null }))
				{
					if (!rows[i].Values.TryGetValue(property.Name, out var json))
					{
						continue;
					}
					object? value;
					try
					{
						value = json.Deserialize(property.ClrType, Json);
					}
					catch (JsonException)
					{
						continue;
					}
					if (value is Guid guid && ids.TryGetValue(guid, out var mapped) && (property.IsPrimaryKey() || foreignKeys.Contains(property.Name)))
					{
						value = mapped;
					}
					property.PropertyInfo!.SetValue(instance, value);
				}

				//	References to content outside the copy: kept when it is here
				foreach (var fk in type.GetForeignKeys().Where(f => f.PrincipalKey.IsPrimaryKey()))
				{
					var values = fk.Properties.Select(p => p.PropertyInfo?.GetValue(instance)).ToArray();
					if (values.Any(v => v is null) || values.All(v => v is Guid g && ids.ContainsValue(g)))
					{
						continue;
					}
					if (await _context.FindAsync(fk.PrincipalEntityType.ClrType, values) is not null)
					{
						continue;
					}
					if (fk.IsRequired)
					{
						if (i == 0)
						{
							return (null, KindOf(fk.PrincipalEntityType.ClrType) ?? fk.PrincipalEntityType.ClrType.Name.ToLowerInvariant());
						}
						goto next;
					}
					foreach (var p in fk.Properties)
					{
						p.PropertyInfo?.SetValue(instance, null);
					}
				}

				if (instance is GameEntity content)
				{
					content.AuthorId = authorId;
					content.IsOfficialSRD = false;
					content.Source = null;
					content.Visibility = ContentVisibility.Private;
				}
				if (i == 0)
				{
					root?.Invoke(instance);
					first = instance;
				}
				_context.Add(instance);
			next:;
			}
			return (first, null);
		}

		///	<summary>The name of an entry in a language (its translation in it, else any).</summary>
		public static string NameOf(object entity, LanguageCode lang)
		{
			var translations = (entity.GetType().GetProperty("Translations")?.GetValue(entity) as System.Collections.IEnumerable)?
				.OfType<ITranslation>().ToList() ?? new List<ITranslation>();
			return translations.FirstOrDefault(t => t.Language == lang)?.Name ?? translations.FirstOrDefault()?.Name ?? "?";
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
	}
}
