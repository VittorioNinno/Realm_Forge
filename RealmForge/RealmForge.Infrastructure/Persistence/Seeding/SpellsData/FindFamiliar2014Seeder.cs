using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Find Familiar (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FindFamiliar2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-familiar");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-familiar", "en"),
					Language = LanguageCode.En,
					Name = "Find Familiar",
					CastingTime = "1 hour",
					Range = "10 feet",
					Duration = "Instantaneous",
					MaterialComponent = "10 gp worth of charcoal, incense, and herbs that must be consumed by fire in a brass brazier",
					Description = "You gain the service of a familiar, a spirit that takes an animal form you choose: bat, cat, crab, frog (toad), hawk, lizard, octopus, owl, poisonous snake, fish (quipper), rat, raven, sea horse, spider, or weasel. Appearing in an unoccupied space within range, the familiar has the statistics of the chosen form, though it is a celestial, fey, or fiend (your choice) instead of a beast.\n\nYour familiar acts independently of you, but it always obeys your commands. In combat, it rolls its own initiative and acts on its own turn. A familiar can't attack, but it can take other actions as normal.\n\nWhen the familiar drops to 0 hit points, it disappears, leaving behind no physical form. It reappears after you cast this spell again.\n\nWhile your familiar is within 100 feet of you, you can communicate with it telepathically. Additionally, as an action, you can see through your familiar's eyes and hear what it hears until the start of your next turn, gaining the benefits of any special senses that the familiar has. During this time, you are deaf and blind with regard to your own senses.\n\nAs an action, you can temporarily dismiss your familiar. It disappears into a pocket dimension where it awaits your summons. Alternatively, you can dismiss it forever. As an action while it is temporarily dismissed, you can cause it to reappear in any unoccupied space within 30 feet of you.\n\nYou can't have more than one familiar at a time. If you cast this spell while you already have a familiar, you instead cause it to adopt a new form. Choose one of the forms from the above list. Your familiar transforms into the chosen creature.\n\nFinally, when you cast a spell with a range of touch, your familiar can deliver the spell as if it had cast the spell. Your familiar must be within 100 feet of you, and it must use its reaction to deliver the spell when you cast it. If the spell requires an attack roll, you use your attack modifier for the roll.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "find-familiar", "it"),
					Language = LanguageCode.It,
					Name = "Trova Famiglio",
					CastingTime = "1 ora",
					Range = "3 metri",
					Duration = "Istantanea",
					MaterialComponent = "carbone, incenso ed erbe per un valore di 10 mo, che devono essere consumati dal fuoco in un braciere d'ottone",
					Description = "L'incantatore ottiene i servigi di un famiglio, uno spirito che assume la forma animale da lui scelta: civetta, corvo, falco, gatto, granchio, lucertola, piovra, pipistrello, quipper (pesce), ragno, ratto, rana (rospo), cavalluccio marino, serpente velenoso o donnola. Il famiglio compare in uno spazio libero entro gittata e possiede le statistiche della forma scelta, ma è un celestiale, un folletto o un immondo (a scelta dell'incantatore) anziché una bestia.\n\nIl famiglio agisce in modo indipendente dall'incantatore, ma obbedisce sempre ai suoi comandi. In combattimento, tira la propria iniziativa e agisce nel proprio turno. Un famiglio non può attaccare, ma può compiere normalmente le altre azioni.\n\nQuando il famiglio scende a 0 punti ferita, scompare senza lasciare alcuna forma fisica. Ricompare quando l'incantatore lancia di nuovo questo incantesimo.\n\nFinché il famiglio si trova entro 30 metri dall'incantatore, quest'ultimo può comunicare telepaticamente con esso. Inoltre, come azione, l'incantatore può vedere attraverso gli occhi del famiglio e sentire ciò che sente fino all'inizio del suo turno successivo, ottenendo i benefici di eventuali sensi speciali del famiglio. Durante questo periodo, l'incantatore è sordo e cieco per quanto riguarda i propri sensi.\n\nCome azione, l'incantatore può congedare temporaneamente il famiglio, che scompare in una dimensione tascabile in attesa di essere richiamato. In alternativa, può congedarlo per sempre. Come azione, mentre il famiglio è temporaneamente congedato, l'incantatore può farlo ricomparire in uno spazio libero qualsiasi entro 9 metri da sé.\n\nL'incantatore non può avere più di un famiglio alla volta. Se lancia questo incantesimo quando ha già un famiglio, gli fa invece assumere una nuova forma, scelta tra quelle dell'elenco precedente. Il famiglio si trasforma nella creatura scelta.\n\nInfine, quando l'incantatore lancia un incantesimo con gittata di contatto, il famiglio può trasmettere l'incantesimo come se fosse stato lui a lanciarlo. Il famiglio deve trovarsi entro 30 metri dall'incantatore e deve usare la sua reazione per trasmettere l'incantesimo nel momento in cui l'incantatore lo lancia. Se l'incantesimo richiede un tiro per colpire, l'incantatore usa il proprio modificatore di attacco per il tiro.",
					HigherLevels = null
				}
			}
		};
	}
}
