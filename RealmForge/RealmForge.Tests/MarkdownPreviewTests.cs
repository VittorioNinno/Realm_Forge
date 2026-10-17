using RealmForge.Shared.Text;

namespace RealmForge.Tests;

public class MarkdownPreviewTests
{
	[Fact]
	public void Formatting_marks_and_list_dashes_are_removed()
	{
		var text = "You gain proficiency.\n- **Repeatable.** You can take this feat more than once.";
		Assert.Equal("You gain proficiency. Repeatable. You can take this feat more than once.", MarkdownPreview.ToPlainText(text));
	}

	[Fact]
	public void Headings_and_tables_are_left_out()
	{
		var text = "Intro text.\n\n### Favorite Schemes\n| d6 | Scheme |\n|---|---|\n| 1 | I cheat. |\n\nClosing words.";
		Assert.Equal("Intro text. Closing words.", MarkdownPreview.ToPlainText(text));
	}

	[Fact]
	public void Long_text_is_cut_on_a_word_boundary()
	{
		var text = string.Join(' ', Enumerable.Repeat("word", 60));
		var preview = MarkdownPreview.ToPlainText(text, 50);

		Assert.True(preview.Length <= 50);
		Assert.EndsWith("word…", preview);
	}

	[Fact]
	public void Snake_case_words_and_bullets_survive()
	{
		Assert.Equal("Light Bearer: snake_case stays", MarkdownPreview.ToPlainText("• Light Bearer: snake_case stays"));
	}

	[Theory]
	[InlineData(null)]
	[InlineData("   ")]
	public void Empty_input_gives_an_empty_preview(string? text)
	{
		Assert.Equal(string.Empty, MarkdownPreview.ToPlainText(text));
	}
}
