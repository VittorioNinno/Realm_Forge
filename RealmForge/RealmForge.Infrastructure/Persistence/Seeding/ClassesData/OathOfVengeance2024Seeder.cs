using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Oath of Vengeance (paladin, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class OathOfVengeance2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-vengeance");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Paladin2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-vengeance", "en"), Language = LanguageCode.En, Name = "Oath of Vengeance", Description = "The Oath of Vengeance is a grave promise to punish those guilty of terrible evil. When marauding armies cut down defenseless villagers, when a tyrant scorns the gods, when a thieves' guild turns murderous or a dragon lays waste to the land, Paladins rise and swear this oath to right the wrong.\n\nThese Paladins share these tenets:\n\n- Grant the wicked no mercy.\n- Strike at injustice and at its roots.\n- Stand by those whom injustice has wounded." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-vengeance", "it"), Language = LanguageCode.It, Name = "Giuramento di Vendetta", Description = "Il Giuramento di Vendetta è una promessa solenne di punire chi si è macchiato di un male terribile. Quando eserciti di predoni massacrano villaggi indifesi, quando un tiranno disprezza gli dei, quando una gilda di ladri diventa assassina o un drago devasta le terre, i paladini si levano e pronunciano questo giuramento per riparare il torto.\n\nQuesti paladini condividono i seguenti principi:\n\n- Non concedere pietà ai malvagi.\n- Colpisci l'ingiustizia e le sue radici.\n- Sostieni chi è stato ferito dall'ingiustizia." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/oath-of-vengeance-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/oath-of-vengeance-spells", "en"), Language = LanguageCode.En, Name = "Oath of Vengeance Spells", Description = "Your oath keeps certain spells always at hand: from the Paladin level shown in the table below onward, the listed spells are always prepared for you.\n\n| Paladin Level | Spells |\n|---|---|\n| 3 | *Bane*, *Hunter's Mark* |\n| 5 | *Hold Person*, *Misty Step* |\n| 9 | *Haste*, *Protection from Energy* |\n| 13 | *Banishment*, *Dimension Door* |\n| 17 | *Hold Monster*, *Scrying* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/oath-of-vengeance-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Giuramento di Vendetta", Description = "Grazie al giuramento, il paladino ha sempre a disposizione alcuni incantesimi: dal livello da paladino indicato nella tabella seguente, gli incantesimi elencati sono sempre preparati per lui.\n\n| Livello da paladino | Incantesimi |\n|---|---|\n| 3 | *anatema*, *marchio del cacciatore* |\n| 5 | *blocca persone*, *passo velato* |\n| 9 | *protezione dall'energia*, *velocità* |\n| 13 | *esilio*, *porta dimensionale* |\n| 17 | *blocca mostri*, *scrutare* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/vow-of-enmity"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/vow-of-enmity", "en"), Language = LanguageCode.En, Name = "Vow of Enmity", Description = "When you take the Attack action, you can spend a use of Channel Divinity to swear enmity against a creature you can see within 30 feet of you. For 1 minute, or until you use this feature again, your attack rolls against it have Advantage. If it drops to 0 Hit Points before the vow ends, you can shift the vow to another creature within 30 feet of you (no action required)." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/vow-of-enmity", "it"), Language = LanguageCode.It, Name = "Voto di Inimicizia", Description = "Quando effettua l'azione di Attacco, il paladino può spendere un utilizzo di Incanalare Divinità per pronunciare un voto di inimicizia contro una creatura che è in grado di vedere entro 9 metri da lui. Per 1 minuto, o finché non usa di nuovo questo privilegio, dispone di vantaggio ai tiri per colpire contro quella creatura. Se la creatura scende a 0 punti ferita prima che il voto termini, il paladino può trasferirlo a un'altra creatura entro 9 metri da lui (nessuna azione richiesta)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/relentless-avenger"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/relentless-avenger", "en"), Language = LanguageCode.En, Name = "Relentless Avenger", Description = "Your uncanny focus lets you cut off a foe's escape. When you hit a creature with an Opportunity Attack, you can drop its Speed to 0 until the end of the current turn, then move up to half your own Speed as part of that same Reaction without provoking Opportunity Attacks." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/relentless-avenger", "it"), Language = LanguageCode.It, Name = "Vendetta Implacabile", Description = "La concentrazione soprannaturale del paladino gli permette di tagliare la ritirata a un nemico. Quando colpisce una creatura con un attacco di opportunità, può ridurne la velocità a 0 fino alla fine del turno in corso e poi, come parte della stessa reazione, muoversi fino a metà della propria velocità senza provocare attacchi di opportunità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/soul-of-vengeance"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/soul-of-vengeance", "en"), Language = LanguageCode.En, Name = "Soul of Vengeance", Description = "Right after a creature under your Vow of Enmity makes an attack roll, whether it hits or misses, you can use your Reaction to make a melee attack against it if it is within your reach." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/soul-of-vengeance", "it"), Language = LanguageCode.It, Name = "Anima Vendicativa", Description = "Subito dopo che una creatura soggetta al suo Voto di inimicizia ha effettuato un tiro per colpire, che vada a segno o meno, il paladino può usare una reazione per effettuare un attacco in mischia contro di essa, se si trova alla sua portata." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/avenging-angel"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/avenging-angel", "en"), Language = LanguageCode.En, Name = "Avenging Angel", Description = "As a Bonus Action, you gain the benefits below for 10 minutes or until you end them (no action required). You can use this feature once per Long Rest, and spending a level 5 spell slot (no action required) lets you use it again.\n\n**Flight.** Ghostly wings unfold from your back, giving you a Fly Speed of 60 feet and the ability to hover.\n\n**Frightful Aura.** Whenever an enemy begins its turn inside your Aura of Protection, it must succeed on a Wisdom saving throw or be Frightened for 1 minute or until it takes any damage. Attack rolls against a creature Frightened this way have Advantage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-vengeance/avenging-angel", "it"), Language = LanguageCode.It, Name = "Angelo Vendicatore", Description = "Come azione bonus, il paladino ottiene i benefici seguenti per 10 minuti o finché non vi pone fine (nessuna azione richiesta). Dopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo, ma può ripristinarne l'utilizzo spendendo uno slot incantesimo di 5° livello (nessuna azione richiesta).\n\n**Volo.** Sulla schiena del paladino spuntano ali spettrali: ha una velocità di volare di 18 metri e può fluttuare.\n\n**Aura di terrore.** Ogni volta che un nemico inizia il proprio turno nella sua Aura di protezione, deve superare un tiro salvezza su Saggezza, altrimenti subisce la condizione di spaventato per 1 minuto o finché non subisce danni. I tiri per colpire contro la creatura spaventata dispongono di vantaggio." }
					}
				}
			}
		};
	}
}
