using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.BackgroundsData;

///	<summary>
///	Acolyte (SRD 5.1, 2014 ruleset). English and Italian texts from the System Reference Document 5.1
///	and its official Italian translation, both licensed under CC BY 4.0.
///	</summary>
public static class Acolyte2014Seeder
{
	public static readonly Guid BackgroundId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "acolyte");

	public static Background Build()
	{
		return new Background
		{
			Id = BackgroundId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			SkillProficiencies = new List<Skill> { Skill.Insight, Skill.Religion },
			Translations = new List<BackgroundTranslation>
			{
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "acolyte", "en"),
					Language = LanguageCode.En,
					Name = "Acolyte",
					Description = "You have spent your life in the service of a temple to a specific god or pantheon of gods. You act as an intermediary between the realm of the holy and the mortal world, performing sacred rites and offering sacrifices in order to conduct worshipers into the presence of the divine. You are not necessarily a cleric—performing sacred rites is not the same thing as channeling divine power.\n\nChoose a god, a pantheon of gods, or some other quasi-divine being, and work with your DM to detail the nature of your religious service. Were you a lesser functionary in a temple, raised from childhood to assist the priests in the sacred rites? Or were you a high priest who suddenly experienced a call to serve your god in a different way? Perhaps you were the leader of a small cult outside of any established temple structure, or even an occult group that served a fiendish master that you now deny.",
					Languages = "Two of your choice",
					Equipment = "A holy symbol (a gift to you when you entered the priesthood), a prayer book or prayer wheel, 5 sticks of incense, vestments, a set of common clothes, and a belt pouch containing 15 gp",
					FeatureName = "Shelter of the Faithful",
					FeatureDescription = "As an acolyte, you command the respect of those who share your faith, and you can perform the religious ceremonies of your deity. You and your adventuring companions can expect to receive free healing and care at a temple, shrine, or other established presence of your faith, though you must provide any material components needed for spells. Those who share your religion will support you (but only you) at a modest lifestyle.\n\nYou might also have ties to a specific temple dedicated to your chosen deity or pantheon, and you have a residence there. This could be the temple where you used to serve, if you remain on good terms with it, or a temple where you have found a new home. While near your temple, you can call upon the priests for assistance, provided the assistance you ask for is not hazardous and you remain in good standing with your temple."
				},
				new BackgroundTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "background", "acolyte", "it"),
					Language = LanguageCode.It,
					Name = "Accolito",
					Description = "Un accolito ha passato la sua vita a servire un tempio dedicato a una specifica divinità o un pantheon di divinità. Funge da intermediario tra il reame del sacro e il mondo dei mortali, celebrando riti solenni e offrendo sacrifici al fine di radunare nuovi fedeli presso il suo patrono divino. Non è necessariamente un chierico, in quanto celebrare i riti sacri è ben diverso da incanalare il potere divino.\n\nIl personaggio sceglie un dio, un pantheon di divinità o un altro essere semi-divino e si accorda con il DM per definire in dettaglio la natura del suo servizio religioso. Era un funzionario minore in un tempio, dove è stato cresciuto fin dall'infanzia per assistere i sacerdoti nei loro riti? Oppure è un sommo sacerdote che improvvisamente ha udito un richiamo che lo ha spinto a servire il suo dio in modo diverso? Forse era il capo di un piccolo culto al di fuori delle strutture tradizionali del tempio, o addirittura di un gruppo occulto al servizio di un padrone immondo che ora l'accolito ha rinnegato.",
					Languages = "Due a scelta",
					Equipment = "Un simbolo sacro (donatogli quando è stato ordinato come sacerdote), un libro di preghiere o una ruota della preghiera, 5 bastoncini di incenso, vesti, un abito comune, una borsa con 15 mo",
					FeatureName = "Rifugio dei Fedeli",
					FeatureDescription = "Un accolito gode del rispetto di coloro che condividono la sua fede ed è in grado di celebrare le cerimonie religiose della sua divinità. L'accolito e gli avventurieri suoi compagni possono aspettarsi di ricevere cure e guarigioni gratuite presso un tempio, un santuario o un'altra presenza stabile della sua fede, anche se dovrà fornire le eventuali componenti richieste per gli incantesimi. Coloro che condividono la sua religione lo manterranno (limitandosi soltanto a lui) offrendogli uno stile di vita modesto.\n\nUn accolito potrebbe anche avere dei legami con un tempio specifico dedicato alla divinità o al pantheon di sua scelta, e beneficiare di una dimora presso quel tempio. Potrebbe trattarsi dello stesso tempio dove aveva prestato servizio in passato, se è rimasto in buoni rapporti con i fedeli del posto, oppure di un tempio dove ha trovato accoglienza recentemente. Finché si trova nei pressi del suo tempio, l'accolito può chiedere aiuto ai sacerdoti, purché quell'aiuto non comporti pericoli ed egli goda di una buona reputazione presso il tempio."
				}
			}
		};
	}
}
