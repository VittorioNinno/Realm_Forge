using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Planar Ally (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PlanarAlly2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "planar-ally");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "planar-ally", "en"),
					Language = LanguageCode.En,
					Name = "Planar Ally",
					CastingTime = "10 minutes",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You beseech an otherworldly entity for aid. The being must be known to you: a god, a primordial, a demon prince, or some other being of cosmic power. That entity sends a celestial, an elemental, or a fiend loyal to it to aid you, making the creature appear in an unoccupied space within range. If you know a specific creature's name, you can speak that name when you cast this spell to request that creature, though you might get a different creature anyway (GM's choice).\n\nWhen the creature appears, it is under no compulsion to behave in any particular way. You can ask the creature to perform a service in exchange for payment, but it isn't obliged to do so. The requested task could range from simple (fly us across the chasm, or help us fight a battle) to complex (spy on our enemies, or protect us during our foray into the dungeon). You must be able to communicate with the creature to bargain for its services.\n\nPayment can take a variety of forms. A celestial might require a sizable donation of gold or magic items to an allied temple, while a fiend might demand a living sacrifice or a gift of treasure. Some creatures might exchange their service for a quest undertaken by you.\n\nAs a rule of thumb, a task that can be measured in minutes requires a payment worth 100 gp per minute. A task measured in hours requires 1,000 gp per hour. And a task measured in days (up to 10 days) requires 10,000 gp per day. The GM can adjust these payments based on the circumstances under which you cast the spell. If the task is aligned with the creature's ethos, the payment might be halved or even waived. Nonhazardous tasks typically require only half the suggested payment, while especially dangerous tasks might require a greater gift. Creatures rarely accept tasks that seem suicidal.\n\nAfter the creature completes the task, or when the agreed-upon duration of service expires, the creature returns to its home plane after reporting back to you, if appropriate to the task and if possible. If you are unable to agree on a price for the creature's service, the creature immediately returns to its home plane.\n\nA creature enlisted to join your group counts as a member of it, receiving a full share of experience points awarded.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "planar-ally", "it"),
					Language = LanguageCode.It,
					Name = "Alleato Planare",
					CastingTime = "10 minuti",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore implora l'aiuto di un'entità ultraterrena. Deve trattarsi di un essere a lui noto: una divinità, un primordiale, un principe dei demoni o un altro essere dal potere cosmico. Quell'entità invia in aiuto dell'incantatore un celestiale, un elementale o un immondo a lei leale, facendo comparire la creatura in uno spazio libero entro gittata. Se l'incantatore conosce il nome di una creatura specifica, può pronunciarlo quando lancia questo incantesimo per richiedere quella creatura, ma potrebbe comunque arrivarne una diversa (a scelta del DM).\n\nQuando compare, la creatura non è costretta a comportarsi in alcun modo particolare. L'incantatore può chiederle di svolgere un servizio in cambio di un compenso, ma la creatura non è obbligata ad accettare. Il compito richiesto può essere semplice (portarci in volo oltre il baratro, o aiutarci a combattere una battaglia) o complesso (spiare i nostri nemici, o proteggerci durante la nostra incursione nel dungeon). Per contrattare i servigi della creatura, l'incantatore deve essere in grado di comunicare con essa.\n\nIl compenso può assumere varie forme. Un celestiale potrebbe richiedere una cospicua donazione d'oro o di oggetti magici a un tempio alleato, mentre un immondo potrebbe pretendere un sacrificio vivente o un dono in tesori. Alcune creature potrebbero offrire i propri servigi in cambio di un'impresa compiuta dall'incantatore.\n\nCome regola generale, un compito che può essere misurato in minuti richiede un compenso del valore di 100 mo al minuto. Un compito misurato in ore richiede 1.000 mo all'ora. Un compito misurato in giorni (fino a 10 giorni) richiede 10.000 mo al giorno. Il DM può modificare questi compensi in base alle circostanze in cui l'incantatore lancia l'incantesimo. Se il compito è in linea con l'etica della creatura, il compenso potrebbe essere dimezzato o persino non richiesto. I compiti non pericolosi richiedono di solito solo la metà del compenso suggerito, mentre quelli particolarmente pericolosi potrebbero richiedere un dono maggiore. Le creature accettano raramente compiti che sembrano suicidi.\n\nDopo che la creatura ha portato a termine il compito, o quando scade la durata del servizio concordata, la creatura fa ritorno al suo piano d'origine dopo aver riferito all'incantatore, se appropriato al compito e se possibile. Se l'incantatore non riesce a concordare un prezzo per i servigi della creatura, quest'ultima fa immediatamente ritorno al suo piano d'origine.\n\nUna creatura arruolata nel gruppo dell'incantatore ne diventa un membro a tutti gli effetti e riceve una quota piena dei punti esperienza assegnati.",
					HigherLevels = null
				}
			}
		};
	}
}
