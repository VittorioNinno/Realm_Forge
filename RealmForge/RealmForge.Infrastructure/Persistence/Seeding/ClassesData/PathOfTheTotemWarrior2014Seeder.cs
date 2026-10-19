using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Path of the Totem Warrior (barbarian, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class PathOfTheTotemWarrior2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "path-of-the-totem-warrior");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Barbarian2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "path-of-the-totem-warrior", "en"), Language = LanguageCode.En, Name = "Path of the Totem Warrior", Description = "Barbarians who walk this path take an animal spirit as their guide and protector. The spirit's strength flows into their rage, turning it into something wilder and stranger than ordinary anger. Many tribes see a totem animal as kin to a whole clan, so most of these barbarians bond with a single spirit, though some learn to call on more than one." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "path-of-the-totem-warrior", "it"), Language = LanguageCode.It, Name = "Cammino del Combattente Totemico", Description = "I barbari che seguono questo cammino scelgono uno spirito animale come guida e protettore. La forza dello spirito si riversa nella loro ira, rendendola più selvaggia e misteriosa di una semplice collera. Molte tribù considerano un animale totemico parente di un intero clan, perciò la maggior parte di questi barbari si lega a un solo spirito, anche se alcuni imparano a invocarne più d'uno." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/spirit-seeker"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/spirit-seeker", "en"), Language = LanguageCode.En, Name = "Spirit Seeker", Description = "Your bond with the natural world lets you reach out to beasts. From 3rd level, you can cast *beast sense* and *speak with animals*, but only as rituals." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/spirit-seeker", "it"), Language = LanguageCode.It, Name = "Cercatore di Spiriti", Description = "Il legame del barbaro con il mondo naturale gli permette di entrare in contatto con le bestie. Dal 3° livello può lanciare *percezione delle bestie* e *parlare con gli animali*, ma soltanto come rituali." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/totem-spirit"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/totem-spirit", "en"), Language = LanguageCode.En, Name = "Totem Spirit", Description = "At 3rd level, you bind yourself to a totem spirit: bear, eagle, or wolf. You carry a physical token of it, such as an amulet or ornament made with fur, feathers, claws, teeth, or bones of that animal, and you may take on small physical traits of the beast (thick hair for the bear, piercing yellow eyes for the eagle, and so on). The spirit grants you one benefit, active only while you are raging:\n- **Bear.** You resist every type of damage except psychic.\n- **Eagle.** As long as you aren't wearing heavy armor, opportunity attacks against you are made with disadvantage, and you can take the Dash action as a bonus action on your turn.\n- **Wolf.** Your allies have advantage on melee attack rolls against any hostile creature within 5 feet of you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/totem-spirit", "it"), Language = LanguageCode.It, Name = "Spirito Totemico", Description = "Al 3° livello il barbaro si lega a uno spirito totemico: orso, aquila o lupo. Porta con sé un oggetto fisico che lo rappresenta, come un amuleto o un ornamento fatto con pelliccia, piume, artigli, denti o ossa di quell'animale, e può assumere piccoli tratti fisici della bestia (peli folti per l'orso, occhi gialli e penetranti per l'aquila e così via). Lo spirito gli conferisce un beneficio, attivo soltanto mentre è in ira:\n- **Orso.** Il barbaro ha resistenza a tutti i tipi di danni tranne quelli psichici.\n- **Aquila.** Finché non indossa un'armatura pesante, gli attacchi di opportunità contro di lui sono effettuati con svantaggio, e può effettuare l'azione di Scatto come azione bonus nel proprio turno.\n- **Lupo.** Gli alleati del barbaro dispongono di vantaggio ai tiri per colpire in mischia contro qualsiasi creatura ostile entro 1,5 metri da lui." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/aspect-of-the-beast"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/aspect-of-the-beast", "en"), Language = LanguageCode.En, Name = "Aspect of the Beast", Description = "At 6th level, you gain a lasting gift from a totem animal. It can be the animal you picked at 3rd level or a different one:\n- **Bear.** Your carrying capacity (including maximum load and lift) doubles, and you have advantage on Strength checks to push, pull, lift, or break objects.\n- **Eagle.** You see clearly up to 1 mile away, making out details as if they were no more than 100 feet from you, and dim light doesn't give you disadvantage on Wisdom (Perception) checks.\n- **Wolf.** You can track creatures while traveling at a fast pace, and move stealthily while traveling at a normal pace." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/aspect-of-the-beast", "it"), Language = LanguageCode.It, Name = "Aspetto della Bestia", Description = "Al 6° livello il barbaro riceve un dono permanente da un animale totemico. Può essere lo stesso scelto al 3° livello oppure un altro:\n- **Orso.** La capacità di trasporto del barbaro (inclusi il carico massimo e il sollevamento) raddoppia, e dispone di vantaggio alle prove di Forza per spingere, trascinare, sollevare o rompere oggetti.\n- **Aquila.** Il barbaro vede con chiarezza fino a 1,5 km di distanza, distinguendo i dettagli come se fossero a non più di 30 metri, e la luce fioca non gli impone svantaggio alle prove di Saggezza (Percezione).\n- **Lupo.** Il barbaro può seguire tracce mentre viaggia a passo veloce e muoversi furtivamente mentre viaggia a passo normale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/spirit-walker"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/spirit-walker", "en"), Language = LanguageCode.En, Name = "Spirit Walker", Description = "At 10th level, you can cast *commune with nature*, but only as a ritual. When you do, the answers come from a spirit version of one of the animals you chose for Totem Spirit or Aspect of the Beast, which appears to you for the duration." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/spirit-walker", "it"), Language = LanguageCode.It, Name = "Viandante Spirituale", Description = "Al 10° livello il barbaro può lanciare *comunione con la natura*, ma soltanto come rituale. Quando lo fa, le risposte gli giungono da una versione spirituale di uno degli animali scelti per Spirito Totemico o Aspetto della Bestia, che gli appare per la durata." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/totemic-attunement"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/totemic-attunement", "en"), Language = LanguageCode.En, Name = "Totemic Attunement", Description = "At 14th level, a totem animal grants you a final benefit, again active only while you are raging. You can choose the same animal as before or a new one:\n- **Bear.** Hostile creatures within 5 feet of you have disadvantage on attack rolls against anyone other than you or another creature with this feature. A creature that can't see or hear you, or that can't be frightened, is unaffected.\n- **Eagle.** You gain a flying speed equal to your walking speed. The flight comes in short bursts: if your turn ends while you are in the air and nothing else is holding you up, you fall.\n- **Wolf.** When you hit a Large or smaller creature with a melee weapon attack, you can use a bonus action on that turn to knock it prone." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "path-of-the-totem-warrior/totemic-attunement", "it"), Language = LanguageCode.It, Name = "Sintonia Totemica", Description = "Al 14° livello un animale totemico concede al barbaro un ultimo beneficio, anche questo attivo soltanto mentre è in ira. Può scegliere lo stesso animale di prima o uno nuovo:\n- **Orso.** Le creature ostili entro 1,5 metri dal barbaro subiscono svantaggio ai tiri per colpire contro chiunque non sia lui o un'altra creatura dotata di questo privilegio. Una creatura che non è in grado di vederlo o di sentirlo, o che non può essere spaventata, non è influenzata.\n- **Aquila.** Il barbaro ottiene una velocità di volare pari alla sua velocità sul terreno. Il volo avviene a brevi balzi: se il suo turno termina mentre è in aria e nient'altro lo sostiene, cade.\n- **Lupo.** Quando colpisce una creatura di taglia Grande o inferiore con un attacco con un'arma da mischia, il barbaro può usare un'azione bonus in quel turno per buttarla a terra prona." }
					}
				}
			}
		};
	}
}
