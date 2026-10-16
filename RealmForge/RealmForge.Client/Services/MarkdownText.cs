using Markdig;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Shared Markdown rendering for detail views (feats, backgrounds, species and traits).
	///	</summary>
	public static class MarkdownText
	{
		//	Advanced extensions: tables, lists, emphasis and the rest of the GitHub-flavoured syntax
		private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder()
			.UseAdvancedExtensions()
			.Build();

		public static string ToHtml(string? text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Empty;
			}

			//	Seed texts start lists right after a paragraph ("text\n- item") and some use "•" bullets:
			//	both are normalized so Markdown parses them as proper lists
			var normalized = text.Replace("\r", string.Empty).Replace("\n• ", "\n- ").Replace("\n- ", "\n\n- ");
			return Markdown.ToHtml(normalized, Pipeline);
		}
	}
}
