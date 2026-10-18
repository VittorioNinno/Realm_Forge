using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Planar Ally (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PlanarAlly2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "planar-ally");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "planar-ally", "en"),
					Language = LanguageCode.En,
					Name = "Planar Ally",
					CastingTime = "10 minutes",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You beseech an otherworldly entity for aid. The being must be known to you: a god, a demon prince, or some other being of cosmic power. That entity sends a Celestial, an Elemental, or a Fiend loyal to it to aid you, making the creature appear in an unoccupied space within range. If you know a specific creature's name, you can speak that name when you cast this spell to request that creature, though you might get a different creature anyway (GM's choice).\n\nWhen the creature appears, it is under no compulsion to behave a particular way. You can ask it to perform a service in exchange for payment, but it isn't obliged to do so. The requested task could range from simple (fly us across the chasm, or help us fight a battle) to complex (spy on our enemies, or protect us during our foray into the dungeon). You must be able to communicate with the creature to bargain for its services.\n\nPayment can take a variety of forms. A Celestial might require a sizable donation of gold or magic items to an allied temple, while a Fiend might demand a living sacrifice or a gift of treasure. Some creatures might exchange their service for a quest undertaken by you.\n\nA task that can be measured in minutes requires a payment worth 100 GP per minute. A task measured in hours requires 1,000 GP per hour. And a task measured in days (up to 10 days) requires 10,000 GP per day. The GM can adjust these payments based on the circumstances under which you cast the spell. If the task is aligned with the creature's ethos, the payment might be halved or even waived. Nonhazardous tasks typically require only half the suggested payment, while especially dangerous tasks might require a greater gift. Creatures rarely accept tasks that seem suicidal.\n\nAfter the creature completes the task, or when the agreed-upon duration of service expires, the creature returns to its home plane after reporting back to you if possible. If you are unable to agree on a price for the creature's service, the creature immediately returns to its home plane.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "planar-ally", "it"),
					Language = LanguageCode.It,
					Name = "Alleato Planare",
					CastingTime = "10 minuti",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore implora l'aiuto di un'entità ultraterrena. L'essere deve essergli noto: un dio, un principe dei demoni o qualche altro essere dal potere cosmico. Quell'entità invia un celestiale, un elementale o un immondo a lei fedele per aiutare l'incantatore, facendo comparire la creatura in uno spazio libero entro gittata. Se l'incantatore conosce il nome di una creatura specifica, può pronunciarlo quando lancia questo incantesimo per richiedere quella creatura, ma potrebbe comunque ottenerne una diversa (a scelta del DM).\n\nQuando la creatura compare, non è costretta a comportarsi in un modo particolare. L'incantatore può chiederle di svolgere un servizio in cambio di un pagamento, ma la creatura non è obbligata a farlo. Il compito richiesto può variare da semplice (portarci in volo oltre il baratro, o aiutarci a combattere una battaglia) a complesso (spiare i nostri nemici, o proteggerci durante la nostra incursione nel dungeon). L'incantatore deve essere in grado di comunicare con la creatura per contrattare i suoi servigi.\n\nIl pagamento può assumere varie forme. Un celestiale potrebbe richiedere una cospicua donazione di oro o di oggetti magici a un tempio alleato, mentre un immondo potrebbe pretendere un sacrificio vivente o un dono in tesori. Alcune creature potrebbero scambiare il proprio servizio con una missione intrapresa dall'incantatore.\n\nUn compito che può essere misurato in minuti richiede un pagamento del valore di 100 mo al minuto. Un compito misurato in ore richiede 1.000 mo all'ora. E un compito misurato in giorni (fino a 10 giorni) richiede 10.000 mo al giorno. Il DM può modificare questi pagamenti in base alle circostanze in cui l'incantesimo viene lanciato. Se il compito è in linea con l'etica della creatura, il pagamento potrebbe essere dimezzato o persino annullato. I compiti non pericolosi di solito richiedono soltanto la metà del pagamento suggerito, mentre i compiti particolarmente pericolosi potrebbero richiedere un dono maggiore. Le creature accettano raramente compiti che sembrano suicidi.\n\nDopo che la creatura ha portato a termine il compito, o quando scade la durata del servizio concordata, la creatura ritorna al suo piano natale, dopo aver fatto rapporto all'incantatore, se possibile. Se l'incantatore non riesce a concordare un prezzo per il servizio della creatura, questa ritorna immediatamente al suo piano natale.",
					HigherLevels = null
				}
			}
		};
	}
}
