namespace RealmForge.Shared.Enums
{
	///	<summary>
	///	What a nonplayer character is for at the table: the "Funzione" filter of the NPC registry.
	///	</summary>
	public enum NpcArchetype
	{
		//	Allies and followers
		Ally = 1,

		//	Merchants, innkeepers and craftsfolk
		Merchant = 2,

		//	Informants, nobles and contacts
		Contact = 3,

		//	Guards, rivals and assassins
		Threat = 4
	}

	///	<summary>
	///	How a nonplayer character feels about the party (friendly, indifferent, hostile).
	///	</summary>
	public enum NpcAttitude
	{
		Hostile = 1,
		Indifferent = 2,
		Friendly = 3
	}
}
