using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Path of the Zealot (barbarian, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class PathOfTheZealot2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-zealot");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Barbarian2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-zealot", "en"), Language = LanguageCode.En, Name = "Path of the Zealot", Description = "Zealots are Barbarians blessed by a god or a whole pantheon. Their Rage feels like a moment of ecstatic communion with the divine, and that holy fervor fills them with power. They often fight alongside the priests and faithful of the gods they honor." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-zealot", "it"), Language = LanguageCode.It, Name = "Cammino dello Zelota", Description = "Gli zeloti sono barbari benedetti da un dio o da un intero pantheon. Per loro l'ira è un momento di estatica comunione con il divino, e quel fervore sacro li riempie di potere. Spesso combattono al fianco dei sacerdoti e dei fedeli degli dei che onorano." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/divine-fury"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/divine-fury", "en"), Language = LanguageCode.En, Name = "Divine Fury", Description = "Divine power flows into your blows. While your Rage lasts, once on each of your turns, the first target you strike with a weapon or an Unarmed Strike suffers 1d6 extra damage plus half your Barbarian level (rounded down), Necrotic or Radiant as you prefer each time." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/divine-fury", "it"), Language = LanguageCode.It, Name = "Furia Divina", Description = "Il barbaro può incanalare il potere divino nei suoi colpi. In ognuno dei suoi turni in cui l'ira è attiva, la prima creatura che colpisce con un'arma o con un colpo senz'armi subisce danni extra pari a 1d6 + la metà del suo livello da barbaro (arrotondata per difetto). I danni extra sono necrotici o radiosi, a scelta del barbaro ogni volta che li infligge." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/warrior-of-the-gods"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/warrior-of-the-gods", "en"), Language = LanguageCode.En, Name = "Warrior of the Gods", Description = "A divine presence keeps you on your feet. You have a pool of four d12s for healing yourself: as a Bonus Action, spend any number of dice from the pool, roll them, and regain Hit Points equal to the total.\n\nThe pool refills when you finish a Long Rest. Its maximum size grows by one die at Barbarian levels 6 (5 dice), 12 (6 dice), and 17 (7 dice)." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/warrior-of-the-gods", "it"), Language = LanguageCode.It, Name = "Guerriero degli Dei", Description = "Un'entità divina fa in modo che il barbaro possa continuare a combattere. Il barbaro dispone di una riserva di quattro d12 da spendere per curarsi: come azione bonus, può spendere dadi dalla riserva, tirarli e recuperare un numero di punti ferita pari al totale.\n\nLa riserva recupera tutti i dadi spesi quando il barbaro completa un riposo lungo. Il numero massimo di dadi della riserva aumenta di uno al 6° (5 dadi), al 12° (6 dadi) e al 17° livello da barbaro (7 dadi)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/fanatical-focus"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/fanatical-focus", "en"), Language = LanguageCode.En, Name = "Fanatical Focus", Description = "Once per Rage, when you fail a saving throw, you can roll it again, adding your Rage Damage bonus to it; you must keep the new result." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/fanatical-focus", "it"), Language = LanguageCode.It, Name = "Focus Fanatico", Description = "Una volta per ira, se il barbaro fallisce un tiro salvezza, può ripeterlo aggiungendo un bonus pari al suo bonus dei Danni dell'ira, e deve usare il nuovo risultato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/zealous-presence"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/zealous-presence", "en"), Language = LanguageCode.En, Name = "Zealous Presence", Description = "Taking a Bonus Action, you roar a holy battle cry. Until your next turn begins, up to ten other creatures you choose within 60 feet roll attacks and saving throws with Advantage.\n\nAfter using this feature, you can't use it again until you finish a Long Rest, unless you spend a use of your Rage (no action required) to recover it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/zealous-presence", "it"), Language = LanguageCode.It, Name = "Presenza Zelante", Description = "Come azione bonus, il barbaro lancia un grido di battaglia intriso di energia divina. Fino a dieci altre creature a sua scelta entro 18 metri da lui dispongono di vantaggio ai tiri per colpire e ai tiri salvezza fino all'inizio del turno successivo del barbaro.\n\nDopo aver usato questo privilegio, il barbaro non può usarlo di nuovo finché non completa un riposo lungo, a meno che non spenda un utilizzo di Ira (nessuna azione richiesta) per ripristinarlo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/rage-of-the-gods"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/rage-of-the-gods", "en"), Language = LanguageCode.En, Name = "Rage of the Gods", Description = "As your Rage begins, you can transform into a divine warrior for 1 minute, or until you drop to 0 Hit Points. After transforming, you must finish a Long Rest before doing so again.\n\nWhile transformed, you gain these benefits.\n\n**Flight.** You gain a Fly Speed equal to your Speed, and you can hover.\n\n**Resistance.** You have Resistance to Necrotic, Psychic, and Radiant damage.\n\n**Revivification.** When a creature within 30 feet of you is about to drop to 0 Hit Points, you can use your Reaction and spend a use of your Rage to set its Hit Points to your Barbarian level instead." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-zealot/rage-of-the-gods", "it"), Language = LanguageCode.It, Name = "Ira degli Dei", Description = "Quando entra in ira, il barbaro può assumere la forma di un guerriero divino. Questa forma dura 1 minuto o finché il barbaro non scende a 0 punti ferita. Dopo aver usato questo privilegio, non può usarlo di nuovo finché non completa un riposo lungo.\n\nIn questa forma il barbaro ottiene i benefici seguenti.\n\n**Volo.** Il barbaro ha una velocità di volare pari alla sua velocità e può fluttuare.\n\n**Resistenza.** Il barbaro ha resistenza ai danni necrotici, psichici e radiosi.\n\n**Rinvigorimento.** Quando una creatura entro 9 metri dal barbaro sta per scendere a 0 punti ferita, il barbaro può usare una reazione e spendere un utilizzo di Ira per portare invece i punti ferita di quella creatura a un numero pari al suo livello da barbaro." }
					}
				}
			}
		};
	}
}
