using System.Reflection;
using System.Text.RegularExpressions;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Keys of every Base entry (species, subspecies, backgrounds, classes, subclasses, feats), read once from the seeders:
///	"Dwarf2014Seeder.SpeciesId" → "dwarf", "HillDwarfSubspeciesId" → "hill-dwarf", "MagicInitiate2024Seeder.FeatId" →
///	"magic-initiate". The character rules use them to recognize the content they apply to.
///	</summary>
public static partial class BaseContentKeys
{
	private static readonly Lazy<IReadOnlyDictionary<Guid, string>> Keys = new(Discover);

	public static string? Of(Guid id) => Keys.Value.TryGetValue(id, out var key) ? key : null;

	public static IReadOnlyDictionary<Guid, string> All => Keys.Value;

	private static IReadOnlyDictionary<Guid, string> Discover()
	{
		var keys = new Dictionary<Guid, string>();
		var types = typeof(BaseContentKeys).Assembly.GetTypes()
			.Where(t => t.IsClass && t.IsAbstract && t.IsSealed && t.Namespace?.StartsWith("RealmForge.Infrastructure.Persistence.Seeding") == true);

		foreach (var type in types)
		{
			var match = SeederName().Match(type.Name);
			if (!match.Success)
			{
				continue;
			}

			var typeKey = Kebab(match.Groups[1].Value);
			foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static).Where(f => f.FieldType == typeof(Guid) && f.IsInitOnly))
			{
				var name = field.Name;
				string? key = name switch
				{
					"SpeciesId" or "BackgroundId" or "ClassId" or "SubclassId" or "FeatId" => typeKey,
					_ when name.EndsWith("SubspeciesId", StringComparison.Ordinal) && name.Length > "SubspeciesId".Length => Kebab(name[..^"SubspeciesId".Length]),
					_ => null
				};

				if (key is not null && field.GetValue(null) is Guid id)
				{
					keys.TryAdd(id, key);
				}
			}
		}

		return keys;
	}

	private static string Kebab(string pascal) => KebabBoundary().Replace(pascal, "-$1").ToLowerInvariant();

	[GeneratedRegex(@"^([A-Za-z]+?)(?:2014|2024)Seeder$")]
	private static partial Regex SeederName();

	[GeneratedRegex(@"(?<=[a-z0-9])([A-Z])")]
	private static partial Regex KebabBoundary();
}
