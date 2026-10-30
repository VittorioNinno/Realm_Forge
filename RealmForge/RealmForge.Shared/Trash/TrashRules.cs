namespace RealmForge.Shared.Trash
{
	///	<summary>
	///	The bin: what an account deletes stays restorable for three days, then it is gone for good.
	///	</summary>
	public static class TrashRules
	{
		public const int RetentionDays = 3;

		public static readonly TimeSpan Retention = TimeSpan.FromDays(RetentionDays);

		//	The kinds of content that go through the bin
		public static readonly IReadOnlyList<string> Kinds = new[]
		{
			"character", "campaign", "species", "subspecies", "class", "subclass", "background", "feat", "spell", "equipment", "monster", "magic-item"
		};
	}
}
