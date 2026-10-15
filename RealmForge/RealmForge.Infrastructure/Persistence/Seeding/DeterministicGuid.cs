using System.Security.Cryptography;
using System.Text;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Name-based UUIDv5 (RFC 9562) for seed data: the same readable key always yields the same id,
///	so new modules never need hand-numbered GUIDs. Example keys: "srd2024:spell:fireball",
///	"srd2024:spell:fireball:en". Existing seeders keep their historical ids (changing them would
///	orphan rows in existing databases); use this helper for every new module.
///	</summary>
public static class DeterministicGuid
{
	//	RealmForge namespace. Never change it: every generated id depends on it.
	public static readonly Guid Namespace = Guid.Parse("7f3c2a1e-5b4d-4e8f-9a6b-1c2d3e4f5a6b");

	public static Guid Create(string name) => Create(Namespace, name);

	public static Guid Create(Guid namespaceId, string name)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(name);

		Span<byte> namespaceBytes = stackalloc byte[16];
		namespaceId.TryWriteBytes(namespaceBytes, bigEndian: true, out _);

		var nameBytes = Encoding.UTF8.GetBytes(name);
		var buffer = new byte[16 + nameBytes.Length];
		namespaceBytes.CopyTo(buffer);
		nameBytes.CopyTo(buffer, 16);

		var hash = SHA1.HashData(buffer);
		hash[6] = (byte)((hash[6] & 0x0F) | 0x50);	//	version 5
		hash[8] = (byte)((hash[8] & 0x3F) | 0x80);	//	RFC 4122 variant

		return new Guid(hash.AsSpan(0, 16), bigEndian: true);
	}

	///	<summary>
	///	Builds the conventional SRD key, e.g. ForSrd(Dnd5e_2024, "feat", "lucky", "en") → "srd2024:feat:lucky:en".
	///	</summary>
	public static Guid ForSrd(RulesetVersion ruleset, string kind, string slug, string? suffix = null)
	{
		var year = ruleset == RulesetVersion.Dnd5e_2014 ? "2014" : "2024";
		var key = $"srd{year}:{kind}:{slug}".ToLowerInvariant();
		return Create(suffix is null ? key : $"{key}:{suffix.ToLowerInvariant()}");
	}
}
