using RealmForge.Shared.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	"Genera casuale": a name, an ancestry, a role and a roleplay hook picked at random for a base NPC of the chosen
	///	archetype. The tables are written for RealmForge, in Italian and English.
	///	</summary>
	public static class NpcGenerator
	{
		public sealed record Idea(string Name, string AncestryIt, string AncestryEn, string RoleIt, string RoleEn, string HookIt, string HookEn);

		private static readonly string[] Names =
		[
			"Vaelen", "Brannoc", "Mirela", "Tobias Ferrante", "Isolde", "Garrick", "Selvana", "Dario Neromanto", "Ysolde", "Korvin",
			"Lysandra", "Oswin", "Tamsin", "Bertrand", "Nerys", "Fennick", "Aurelia", "Rook", "Elowen", "Matthias Grigio",
			"Saphira", "Corwin", "Ilaria", "Thorne", "Gwendal", "Pietro Lanterna", "Zarael", "Hollis", "Brielle", "Edric"
		];

		private static readonly (string It, string En)[] Ancestries =
		[
			("Umano", "Human"), ("Elfo dei boschi", "Wood elf"), ("Nano delle colline", "Hill dwarf"), ("Halfling", "Halfling"),
			("Gnomo", "Gnome"), ("Mezzelfo", "Half-elf"), ("Mezzorco", "Half-orc"), ("Tiefling", "Tiefling"), ("Dragonide", "Dragonborn")
		];

		private static readonly Dictionary<NpcArchetype, (string It, string En)[]> Roles = new()
		{
			[NpcArchetype.Ally] = [("Mercenario fidato", "Trusted sellsword"), ("Guida locale", "Local guide"), ("Sacerdote del villaggio", "Village priest"), ("Veterano in congedo", "Retired veteran")],
			[NpcArchetype.Merchant] = [("Mercante di spezie", "Spice merchant"), ("Locandiere", "Innkeeper"), ("Fabbro", "Blacksmith"), ("Alchimista", "Alchemist")],
			[NpcArchetype.Contact] = [("Informatore", "Informant"), ("Nobile decaduto", "Fallen noble"), ("Erudito", "Scholar"), ("Ricettatore", "Fence")],
			[NpcArchetype.Threat] = [("Capitano della guardia", "Captain of the guard"), ("Cacciatore di taglie", "Bounty hunter"), ("Contrabbandiere", "Smuggler"), ("Sicario", "Hired blade")]
		};

		private static readonly (string It, string En)[] Hooks =
		[
			("Parla a bassa voce facendo roteare una moneta tra le dita; deve un favore a qualcuno di pericoloso.",
				"Speaks softly while rolling a coin across the knuckles; owes a favour to someone dangerous."),
			("Ride troppo forte e ricorda il nome di tutti; nasconde una lettera che non ha mai avuto il coraggio di spedire.",
				"Laughs too loudly and remembers everyone's name; hides a letter never sent."),
			("Diffida degli stranieri ma adora le storie di viaggio; offre uno sconto a chi gliene racconta una vera.",
				"Distrusts strangers but loves travel stories; gives a discount for a true one."),
			("Ha sempre fretta e le mani sporche d'inchiostro; sa chi entra e chi esce dalla città di notte.",
				"Always in a hurry with ink-stained hands; knows who comes and goes at night."),
			("Cortese fino all'eccesso, colleziona piccoli segreti come altri collezionano monete.",
				"Courteous to a fault, collects small secrets the way others collect coins."),
			("Burbero e di poche parole, protegge in silenzio un bambino che non è suo.",
				"Gruff and terse, quietly protects a child who is not theirs."),
			("Superstizioso fino al midollo: non comincia nulla senza aver toccato il suo amuleto.",
				"Superstitious to the bone: starts nothing without touching an amulet."),
			("Vuole lasciare la città e cerca qualcuno abbastanza folle da accompagnarlo oltre le colline.",
				"Wants to leave town and looks for someone foolish enough to escort them past the hills.")
		];

		public static NpcAttitude Attitude(Random? random = null) => (NpcAttitude)(random ?? Random.Shared).Next(1, 4);

		public static Idea For(NpcArchetype archetype, Random? random = null)
		{
			random ??= Random.Shared;
			var ancestry = Ancestries[random.Next(Ancestries.Length)];
			var roles = Roles.GetValueOrDefault(archetype) ?? Roles[NpcArchetype.Merchant];
			var role = roles[random.Next(roles.Length)];
			var hook = Hooks[random.Next(Hooks.Length)];
			return new Idea(Names[random.Next(Names.Length)], ancestry.It, ancestry.En, role.It, role.En, hook.It, hook.En);
		}
	}
}
