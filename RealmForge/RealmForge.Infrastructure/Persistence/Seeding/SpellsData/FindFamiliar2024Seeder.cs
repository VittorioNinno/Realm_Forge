using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Find Familiar (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FindFamiliar2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-familiar");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-familiar", "en"),
					Language = LanguageCode.En,
					Name = "Find Familiar",
					CastingTime = "1 hour",
					Range = "10 feet",
					Duration = "Instantaneous",
					MaterialComponent = "burning incense worth 10+ GP, which the spell consumes",
					Description = "You gain the service of a familiar, a spirit that takes an animal form you choose: **Bat, Cat, Frog, Hawk, Lizard, Octopus, Owl, Rat, Raven, Spider, Weasel**, or another Beast that has a Challenge Rating of 0. Appearing in an unoccupied space within range, the familiar has the statistics of the chosen form (see \"Monsters\"), though it is a Celestial, Fey, or Fiend (your choice) instead of a Beast. Your familiar acts independently of you, but it obeys your commands.\n\n***Telepathic Connection.*** While your familiar is within 100 feet of you, you can communicate with it telepathically. Additionally, as a Bonus Action, you can see through the familiar's eyes and hear what it hears until the start of your next turn, gaining the benefits of any special senses it has.\n\nFinally, when you cast a spell with a range of touch, your familiar can deliver the touch. Your familiar must be within 100 feet of you, and it must take a Reaction to deliver the touch when you cast the spell.\n\n***Combat.*** The familiar is an ally to you and your allies. It rolls its own Initiative and acts on its own turn. A familiar can't attack, but it can take other actions as normal.\n\n***Disappearance of the Familiar.*** When the familiar drops to 0 Hit Points, it disappears. It reappears after you cast this spell again. As a Magic action, you can temporarily dismiss the familiar to a pocket dimension. Alternatively, you can dismiss it forever. As a Magic action while it is temporarily dismissed, you can cause it to reappear in an unoccupied space within 30 feet of you. Whenever the familiar drops to 0 Hit Points or disappears into the pocket dimension, it leaves behind in its space anything it was wearing or carrying.\n\n***One Familiar Only.*** You can't have more than one familiar at a time. If you cast this spell while you have a familiar, you instead cause it to adopt a new eligible form.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "find-familiar", "it"),
					Language = LanguageCode.It,
					Name = "Trova Famiglio",
					CastingTime = "1 ora",
					Range = "3 metri",
					Duration = "Istantanea",
					MaterialComponent = "incenso acceso del valore di almeno 10 mo, che l'incantesimo consuma",
					Description = "L'incantatore ottiene i servigi di un famiglio, uno spirito che assume una forma animale a sua scelta: **civetta, corvo, donnola, falco, gatto, lucertola, pipistrello, piovra, ragno, rana, ratto** o un'altra bestia con Grado di Sfida 0. Il famiglio compare in uno spazio libero entro gittata e ha le statistiche della forma scelta (vedi il capitolo \"Mostri\" dell'SRD), ma è un celestiale, un folletto o un immondo (a scelta dell'incantatore) anziché una bestia. Il famiglio agisce indipendentemente dall'incantatore, ma obbedisce ai suoi comandi.\n\n***Connessione Telepatica.*** Finché il famiglio si trova entro 30 metri da lui, l'incantatore può comunicare telepaticamente con esso. Inoltre, come azione bonus, l'incantatore può vedere attraverso gli occhi del famiglio e sentire ciò che sente fino all'inizio del proprio turno successivo, ottenendo i benefici degli eventuali sensi speciali del famiglio.\n\nInfine, quando l'incantatore lancia un incantesimo con gittata di contatto, il famiglio può trasmettere il contatto al posto suo. Il famiglio deve trovarsi entro 30 metri dall'incantatore e deve spendere la propria reazione per trasmettere il contatto quando l'incantatore lancia l'incantesimo.\n\n***Combattimento.*** Il famiglio è un alleato dell'incantatore e dei suoi alleati. Tira la propria Iniziativa e agisce nel proprio turno. Un famiglio non può attaccare, ma può effettuare normalmente altre azioni.\n\n***Scomparsa del Famiglio.*** Quando il famiglio scende a 0 punti ferita, scompare. Ricompare dopo che l'incantatore ha lanciato di nuovo questo incantesimo. Come azione di Magia, l'incantatore può congedare temporaneamente il famiglio in una dimensione tascabile. In alternativa, può congedarlo per sempre. Come azione di Magia mentre il famiglio è temporaneamente congedato, l'incantatore può farlo ricomparire in uno spazio libero entro 9 metri da sé. Ogni volta che il famiglio scende a 0 punti ferita o scompare nella dimensione tascabile, lascia nel proprio spazio tutto ciò che indossava o trasportava.\n\n***Un Solo Famiglio.*** L'incantatore non può avere più di un famiglio alla volta. Se lancia questo incantesimo mentre ha già un famiglio, fa invece assumere al famiglio una nuova forma tra quelle consentite.",
					HigherLevels = null
				}
			}
		};
	}
}
