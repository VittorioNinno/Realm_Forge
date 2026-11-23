using RealmForge.Shared.Puzzles;

namespace RealmForge.Tests;

public class CipherTests
{
	[Theory]
	[InlineData(CipherKind.Caesar, "3")]
	[InlineData(CipherKind.Vigenere, "DRAGO")]
	[InlineData(CipherKind.Atbash, null)]
	[InlineData(CipherKind.Runes, null)]
	[InlineData(CipherKind.Draconic, null)]
	public void EveryCipherComesBack(CipherKind kind, string? key)
	{
		var secret = Ciphers.Encode(kind, "La porta è chiusa, Città!", key);
		Assert.NotEqual("LA PORTA E CHIUSA, CITTA!", secret);
		Assert.Equal("LA PORTA E CHIUSA, CITTA!", Ciphers.Decode(kind, secret, key));
	}

	[Fact]
	public void KnownValues()
	{
		Assert.Equal("DEF", Ciphers.Encode(CipherKind.Caesar, "abc", "3"));
		Assert.Equal("ZYX", Ciphers.Encode(CipherKind.Atbash, "abc"));
		Assert.Equal("LXFOPV EF RNHR", Ciphers.Encode(CipherKind.Vigenere, "attack at dawn", "lemon"));
		Assert.Equal("3-9-1-15 / 13-15-14-4-15", Ciphers.Encode(CipherKind.Numbers, "ciao mondo"));
		Assert.Equal("CIAO MONDO", Ciphers.Decode(CipherKind.Numbers, "3-9-1-15 / 13-15-14-4-15"));
	}

	[Fact]
	public void AnswersIgnoreCaseAccentsAndSpaces()
	{
		Assert.True(Ciphers.Matches("  Oscurità! ", "buio|oscurita"));
		Assert.True(Ciphers.Matches("il tuo nome", "nome|il tuo nome"));
		Assert.False(Ciphers.Matches("", "nome"));
		Assert.False(Ciphers.Matches("luce", "buio|oscurita"));
	}

	[Fact]
	public void TheCatalogueIsComplete()
	{
		Assert.True(RiddleCatalog.All.Count >= 10);
		Assert.Equal(RiddleCatalog.All.Count, RiddleCatalog.All.Select(r => r.Id).Distinct().Count());
		Assert.All(RiddleCatalog.All, r =>
		{
			Assert.Equal(3, r.Hints.Count);
			Assert.True(r.Hints.Select(h => h.Dc).SequenceEqual(r.Hints.Select(h => h.Dc).Order()));
			Assert.False(string.IsNullOrWhiteSpace(r.AnswerIt + r.AnswerEn));
		});
	}
}
