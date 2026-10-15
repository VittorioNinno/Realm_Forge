using RealmForge.Infrastructure.Persistence.Seeding;
using RealmForge.Shared.Enums;

namespace RealmForge.Tests;

public class DeterministicGuidTests
{
	[Fact]
	public void Matches_the_RFC_reference_implementation()
	{
		//	Same value as Python's uuid.uuid5(uuid.NAMESPACE_DNS, "www.example.com")
		var dns = Guid.Parse("6ba7b810-9dad-11d1-80b4-00c04fd430c8");
		Assert.Equal(Guid.Parse("2ed6657d-e927-568b-95e1-2665a8aea6a2"), DeterministicGuid.Create(dns, "www.example.com"));
	}

	[Fact]
	public void RealmForge_keys_are_stable()
	{
		//	If this test fails, the namespace or the algorithm changed and every generated id would change with it
		Assert.Equal(Guid.Parse("1f4769aa-4564-53d9-b91f-1a1728b723ed"), DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "feat", "lucky"));
		Assert.Equal(Guid.Parse("b9b8e17f-c84a-5272-842d-aea032c51b37"), DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "feat", "lucky", "en"));
	}

	[Fact]
	public void Different_keys_give_different_ids()
	{
		Assert.NotEqual(
			DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "feat", "lucky"),
			DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "feat", "lucky"));
	}
}
