namespace RealmForge.Domain.Entities
{
	///	<summary>A special look of the dice a user has (from an achievement, or given by an administrator).</summary>
	public class UserDiceSkin
	{
		public string UserId { get; set; } = string.Empty;
		public string Skin { get; set; } = string.Empty;
		public DateTimeOffset UnlockedAt { get; set; } = DateTimeOffset.UtcNow;
	}

	///	<summary>
	///	An achievement of a user (RealmForge.Shared.Dice.Achievements): earned on its own, or given by an administrator
	///	(GrantedById). A revoked one stays, with RevokedAt, so that it is not earned again on its own until an administrator
	///	gives it back. Seen: the person has been told.
	///	</summary>
	public class UserAchievement
	{
		public string UserId { get; set; } = string.Empty;
		public string Key { get; set; } = string.Empty;
		public DateTimeOffset EarnedAt { get; set; } = DateTimeOffset.UtcNow;
		public string? GrantedById { get; set; }
		public DateTimeOffset? RevokedAt { get; set; }
		public string? RevokedById { get; set; }
		public bool Seen { get; set; }
	}

	///	<summary>
	///	What the dice of a user have done at the tables, counted as the rolls are saved (the dice log of a campaign keeps only
	///	its latest rolls): rolls, natural 20s and 1s, the last d20 and the last natural 20 (for the achievements made of a
	///	sequence), the moments already met, and the person's time zone (for "after midnight").
	///	</summary>
	public class UserDiceStats
	{
		public string UserId { get; set; } = string.Empty;
		public int Rolls { get; set; }
		public int NaturalTwenties { get; set; }
		public int NaturalOnes { get; set; }
		public int? LastD20 { get; set; }
		public Guid? LastTwentyCampaignId { get; set; }
		public DateTimeOffset? LastTwentyAt { get; set; }
		public bool OneThenTwenty { get; set; }
		public bool TwoTwentiesInASitting { get; set; }
		public bool TwentyAfterMidnight { get; set; }
		public string? TimeZone { get; set; }
		public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
	}
}
