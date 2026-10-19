using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Oath of the Ancients (paladin, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class OathOfTheAncients2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-the-ancients");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-the-ancients", "en"), Language = LanguageCode.En, Name = "Oath of the Ancients", Description = "The Oath of the Ancients dates back to the first elves. Paladins who swear it treasure the light, valuing the beauty and life of the world above any abstract code of honor, courage or justice. They often decorate their armor and clothing with living motifs, such as leaves, antlers or blossoms, as a sign of their pledge to keep life and light alive.\n\nThese Paladins share these tenets:\n\n- Keep the flame of hope burning.\n- Protect all that lives.\n- Find joy in art and laughter." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-the-ancients", "it"), Language = LanguageCode.It, Name = "Giuramento degli Antichi", Description = "Il Giuramento degli Antichi risale ai primi elfi. I paladini che lo pronunciano hanno a cuore la luce e antepongono la bellezza e la vita del mondo a qualsiasi codice astratto di onore, coraggio o giustizia. Spesso decorano armature e vesti con motivi viventi, come foglie, palchi di corna o fiori, in segno del loro impegno a custodire la vita e la luce.\n\nQuesti paladini condividono i seguenti principi:\n\n- Tieni accesa la fiamma della speranza.\n- Proteggi tutto ciò che vive.\n- Trova la gioia nell'arte e nella risata." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/natures-wrath"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/natures-wrath", "en"), Language = LanguageCode.En, Name = "Nature's Wrath", Description = "As a Magic action, you can spend a use of Channel Divinity to make spectral vines lash out around nearby creatures. Each creature of your choice that you can see within 15 feet of you must succeed on a Strength saving throw or be Restrained for 1 minute; a Restrained creature repeats the save at the end of each of its turns, freeing itself on a success." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/natures-wrath", "it"), Language = LanguageCode.It, Name = "Furia della Natura", Description = "Con un'azione di Magia, il paladino può spendere un utilizzo di Incanalare Divinità per far comparire rampicanti spettrali attorno alle creature vicine. Ogni creatura a sua scelta che è in grado di vedere entro 4,5 metri da lui deve superare un tiro salvezza su Forza, altrimenti subisce la condizione di trattenuto per 1 minuto; la creatura trattenuta ripete il tiro salvezza alla fine di ognuno dei suoi turni e, se lo supera, l'effetto su di lei termina." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/oath-of-the-ancients-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/oath-of-the-ancients-spells", "en"), Language = LanguageCode.En, Name = "Oath of the Ancients Spells", Description = "Your oath keeps certain spells always at hand: from the Paladin level shown in the table below onward, the listed spells are always prepared for you.\n\n| Paladin Level | Spells |\n|---|---|\n| 3 | *Ensnaring Strike*, *Speak with Animals* |\n| 5 | *Misty Step*, *Moonbeam* |\n| 9 | *Plant Growth*, *Protection from Energy* |\n| 13 | *Ice Storm*, *Stoneskin* |\n| 17 | *Commune with Nature*, *Tree Stride* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/oath-of-the-ancients-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Giuramento degli Antichi", Description = "Grazie al giuramento, il paladino ha sempre a disposizione alcuni incantesimi: dal livello da paladino indicato nella tabella seguente, gli incantesimi elencati sono sempre preparati per lui.\n\n| Livello da paladino | Incantesimi |\n|---|---|\n| 3 | *colpo intrappolante*, *parlare con gli animali* |\n| 5 | *bagliore lunare*, *passo velato* |\n| 9 | *crescita vegetale*, *protezione dall'energia* |\n| 13 | *pelle di pietra*, *tempesta di ghiaccio* |\n| 17 | *comunione con la natura*, *traslazione arborea* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/aura-of-warding"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/aura-of-warding", "en"), Language = LanguageCode.En, Name = "Aura of Warding", Description = "Ancient magic clings to you so strongly that it forms an arcane shield, dulling energies from beyond the Material Plane: you and your allies resist Necrotic, Psychic, and Radiant damage while inside your Aura of Protection." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/aura-of-warding", "it"), Language = LanguageCode.It, Name = "Aura Guardiana", Description = "Una magia antica grava sul paladino con tale intensità da formare una protezione arcana che smorza le energie provenienti da oltre il Piano Materiale: lui e i suoi alleati hanno resistenza ai danni necrotici, psichici e radiosi finché si trovano nella sua Aura di protezione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/undying-sentinel"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/undying-sentinel", "en"), Language = LanguageCode.En, Name = "Undying Sentinel", Description = "When you drop to 0 Hit Points without being killed outright, you can drop to 1 Hit Point instead and regain Hit Points equal to three times your Paladin level. You can use this feature once per Long Rest.\n\nAlso, magic can't age you, and your body no longer shows the passing years." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/undying-sentinel", "it"), Language = LanguageCode.It, Name = "Sentinella Imperitura", Description = "Quando i suoi punti ferita scendono a 0 senza che muoia sul colpo, il paladino può invece scendere a 1 punto ferita e recuperare punti ferita pari al triplo del suo livello da paladino. Dopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo.\n\nInoltre, la magia non può farlo invecchiare e il suo aspetto smette di mostrare i segni del tempo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/elder-champion"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/elder-champion", "en"), Language = LanguageCode.En, Name = "Elder Champion", Description = "As a Bonus Action, you can fill your Aura of Protection with primal power, gaining the benefits below for 1 minute or until you end them (no action required). You can use this feature once per Long Rest, and spending a level 5 spell slot (no action required) lets you use it again.\n\n**Diminish Defiance.** Enemies inside the aura have Disadvantage on saving throws against your spells and your Channel Divinity options.\n\n**Regeneration.** You regain 10 Hit Points at the start of each of your turns.\n\n**Swift Spells.** A spell you cast that normally takes an action can be cast with a Bonus Action instead." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-the-ancients/elder-champion", "it"), Language = LanguageCode.It, Name = "Campione degli Antichi", Description = "Come azione bonus, il paladino può infondere la sua Aura di protezione di potere primordiale, ottenendo i benefici seguenti per 1 minuto o finché non vi pone fine (nessuna azione richiesta). Dopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo, ma può ripristinarne l'utilizzo spendendo uno slot incantesimo di 5° livello (nessuna azione richiesta).\n\n**Volontà compromessa.** I nemici nell'aura subiscono svantaggio ai tiri salvezza contro i suoi incantesimi e le sue opzioni di Incanalare Divinità.\n\n**Rigenerazione.** All'inizio di ognuno dei suoi turni, il paladino recupera 10 punti ferita.\n\n**Incantesimi rapidi.** Quando lancia un incantesimo con un tempo di lancio di un'azione, il paladino può lanciarlo invece con un'azione bonus." }
					}
				}
			}
		};
	}
}
