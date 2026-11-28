namespace RealmForge.Client.Services
{
	///	<summary>
	///	The table screen: this window shows a master's virtual tabletop to the players round the table (a second monitor,
	///	or a touch screen). Every call about that campaign says so (the API answers as to a player), and what is done on a
	///	player's token is sent as theirs (ActAs): their rights, their name on the rolls, their achievements. Each window has
	///	its own state: the master's own window is untouched.
	///	</summary>
	public static class TableScreen
	{
		///	<summary>The campaign shown on the table screen (null: this window is not one).</summary>
		public static Guid? CampaignId { get; set; }

		///	<summary>The player acting now on the table screen (their token chosen, or their turn).</summary>
		public static string? ActAs { get; set; }

		public static bool Active => CampaignId is not null;
	}

	///	<summary>Marks the calls of the table screen (and those of a player acting on it).</summary>
	public sealed class TableScreenHandler : DelegatingHandler
	{
		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (TableScreen.CampaignId is { } campaign && request.RequestUri is { } uri
				&& uri.AbsolutePath.Contains($"/api/campaigns/{campaign}", StringComparison.OrdinalIgnoreCase))
			{
				request.Headers.TryAddWithoutValidation("X-Rf-Screen", "table");
				//	Reading the table is the screen's own; acting is the player's
				if (request.Method != HttpMethod.Get && TableScreen.ActAs is { Length: > 0 } player)
				{
					request.Headers.TryAddWithoutValidation("X-Rf-Act-As", player);
				}
			}
			return base.SendAsync(request, cancellationToken);
		}
	}
}
