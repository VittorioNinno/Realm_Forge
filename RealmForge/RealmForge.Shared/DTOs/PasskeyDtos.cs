namespace RealmForge.Shared.DTOs
{
	///	<summary>
	///	A passkey of the account: its id (base64url of the credential id), the name the person gave it and when it was
	///	added.
	///	</summary>
	public record PasskeyDto(string Id, string Name, DateTimeOffset CreatedAt);

	///	<summary>
	///	Options for the browser (WebAuthn JSON, passed as they are to navigator.credentials) and the protected state the
	///	server needs back with the answer.
	///	</summary>
	public record PasskeyOptionsDto(string Options, string State);

	///	<summary>
	///	The browser's answer (PublicKeyCredential as JSON) with the state of the options; Name only when adding one.
	///	</summary>
	public class PasskeyCredentialDto
	{
		public string Credential { get; set; } = string.Empty;
		public string State { get; set; } = string.Empty;
		public string? Name { get; set; }
	}

	public class RenamePasskeyDto
	{
		public string Name { get; set; } = string.Empty;
	}
}
