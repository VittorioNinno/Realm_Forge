using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Circle of the Land (druid, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CircleOfTheLand2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "circle-of-the-land");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Druid2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "circle-of-the-land", "en"), Language = LanguageCode.En, Name = "Circle of the Land", Description = "The Circle of the Land is made up of mystics and sages who safeguard ancient knowledge and rites through a vast oral tradition. These druids meet within sacred circles of trees or standing stones to whisper primal secrets in Druidic. The circle's wisest members preside as the chief priests of communities that hold to the Old Faith and serve as advisors to the rulers of those folk. As a member of this circle, your magic is influenced by the land where you were initiated into the circle's mysterious rites." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "circle-of-the-land", "it"), Language = LanguageCode.It, Name = "Circolo della Terra", Description = "Il Circolo della Terra è composto da mistici e saggi che custodiscono antiche conoscenze e antichi riti tramite una vasta tradizione orale. Questi druidi si riuniscono all'interno di cerchi sacri di alberi o di pietre erette per sussurrare in druidico segreti primordiali. I membri più saggi del circolo presiedono come sommi sacerdoti delle comunità fedeli all'Antica Fede e fungono da consiglieri per i governanti di quei popoli. In quanto membro di questo circolo, la magia del druido è influenzata dalla terra in cui è stato iniziato ai misteriosi riti del circolo." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/bonus-cantrip"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/bonus-cantrip", "en"), Language = LanguageCode.En, Name = "Bonus Cantrip", Description = "When you choose this circle at 2nd level, you learn one additional druid cantrip of your choice." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/bonus-cantrip", "it"), Language = LanguageCode.It, Name = "Trucchetto Bonus", Description = "Quando sceglie questo circolo al 2° livello, il druido apprende un trucchetto da druido aggiuntivo a sua scelta." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/natural-recovery"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/natural-recovery", "en"), Language = LanguageCode.En, Name = "Natural Recovery", Description = "Starting at 2nd level, you can regain some of your magical energy by sitting in meditation and communing with nature.\n\nDuring a short rest, you choose expended spell slots to recover. The spell slots can have a combined level that is equal to or less than half your druid level (rounded up), and none of the slots can be 6th level or higher. You can't use this feature again until you finish a long rest.\n\nFor example, when you are a 4th-level druid, you can recover up to two levels worth of spell slots. You can recover either a 2nd-level slot or two 1st-level slots." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/natural-recovery", "it"), Language = LanguageCode.It, Name = "Recupero Naturale", Description = "A partire dal 2° livello, il druido può recuperare parte della sua energia magica sedendo in meditazione e in comunione con la natura.\n\nDurante un riposo breve, il druido sceglie gli slot incantesimo spesi da recuperare. La somma dei livelli degli slot può essere pari o inferiore alla metà del suo livello da druido (arrotondata per eccesso), e nessuno degli slot può essere di 6° livello o superiore. Non può usare di nuovo questo privilegio finché non completa un riposo lungo.\n\nPer esempio, un druido di 4° livello può recuperare slot incantesimo per un totale di due livelli: uno slot di 2° livello oppure due slot di 1° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/circle-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/circle-spells", "en"), Language = LanguageCode.En, Name = "Circle Spells", Description = "Your mystical connection to the land infuses you with the ability to cast certain spells. At 3rd, 5th, 7th, and 9th level you gain access to circle spells connected to the land where you became a druid. Choose that land—arctic, coast, desert, forest, grassland, mountain, or swamp—and consult the associated list of spells.\n\nOnce you gain access to a circle spell, you always have it prepared, and it doesn't count against the number of spells you can prepare each day. If you gain access to a spell that doesn't appear on the druid spell list, the spell is nonetheless a druid spell for you.\n\n**Arctic**\n\n| Druid Level | Circle Spells |\n|---|---|\n| 3rd | hold person, spike growth |\n| 5th | sleet storm, slow |\n| 7th | freedom of movement, ice storm |\n| 9th | commune, cone of cold |\n\n**Coast**\n\n| Druid Level | Circle Spells |\n|---|---|\n| 3rd | mirror image, misty step |\n| 5th | water breathing, water walk |\n| 7th | control water, freedom of movement |\n| 9th | conjure elemental, scrying |\n\n**Desert**\n\n| Druid Level | Circle Spells |\n|---|---|\n| 3rd | blur, silence |\n| 5th | create food and water, protection from energy |\n| 7th | blight, hallucinatory terrain |\n| 9th | insect plague, wall of stone |\n\n**Forest**\n\n| Druid Level | Circle Spells |\n|---|---|\n| 3rd | barkskin, spider climb |\n| 5th | call lightning, plant growth |\n| 7th | divination, freedom of movement |\n| 9th | commune with nature, tree stride |\n\n**Grassland**\n\n| Druid Level | Circle Spells |\n|---|---|\n| 3rd | invisibility, pass without trace |\n| 5th | daylight, haste |\n| 7th | divination, freedom of movement |\n| 9th | dream, insect plague |\n\n**Mountain**\n\n| Druid Level | Circle Spells |\n|---|---|\n| 3rd | spider climb, spike growth |\n| 5th | lightning bolt, meld into stone |\n| 7th | stone shape, stoneskin |\n| 9th | passwall, wall of stone |\n\n**Swamp**\n\n| Druid Level | Circle Spells |\n|---|---|\n| 3rd | acid arrow, darkness |\n| 5th | water walk, stinking cloud |\n| 7th | freedom of movement, locate creature |\n| 9th | insect plague, scrying |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/circle-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Circolo", Description = "Il legame mistico del druido con la terra gli conferisce la capacità di lanciare determinati incantesimi. Al 3°, al 5°, al 7° e al 9° livello ottiene accesso agli incantesimi del circolo legati alla terra in cui è diventato druido. Il druido sceglie quella terra (artico, costa, deserto, foresta, prateria, montagna o palude) e consulta la relativa lista di incantesimi.\n\nUna volta ottenuto l'accesso a un incantesimo del circolo, il druido lo considera sempre preparato e non lo conta nel numero di incantesimi che può preparare ogni giorno. Se ottiene l'accesso a un incantesimo che non compare nella lista degli incantesimi del druido, per lui è comunque un incantesimo da druido.\n\n**Artico**\n\n| Livello da druido | Incantesimi del circolo |\n|---|---|\n| 3° | blocca persone, crescita di spine |\n| 5° | lentezza, tempesta di nevischio |\n| 7° | libertà di movimento, tempesta di ghiaccio |\n| 9° | comunione, cono di freddo |\n\n**Costa**\n\n| Livello da druido | Incantesimi del circolo |\n|---|---|\n| 3° | immagine speculare, passo velato |\n| 5° | camminare sull'acqua, respirare sott'acqua |\n| 7° | controllare acqua, libertà di movimento |\n| 9° | evoca elementale, scrutare |\n\n**Deserto**\n\n| Livello da druido | Incantesimi del circolo |\n|---|---|\n| 3° | sfocatura, silenzio |\n| 5° | creare cibo e acqua, protezione dall'energia |\n| 7° | inaridire, terreno illusorio |\n| 9° | muro di pietra, piaga degli insetti |\n\n**Foresta**\n\n| Livello da druido | Incantesimi del circolo |\n|---|---|\n| 3° | movimenti del ragno, pelle coriacea |\n| 5° | crescita vegetale, invocare il fulmine |\n| 7° | divinazione, libertà di movimento |\n| 9° | comunione con la natura, traslazione arborea |\n\n**Prateria**\n\n| Livello da druido | Incantesimi del circolo |\n|---|---|\n| 3° | invisibilità, passare senza tracce |\n| 5° | luce diurna, velocità |\n| 7° | divinazione, libertà di movimento |\n| 9° | piaga degli insetti, sogno |\n\n**Montagna**\n\n| Livello da druido | Incantesimi del circolo |\n|---|---|\n| 3° | crescita di spine, movimenti del ragno |\n| 5° | fondersi nella pietra, fulmine |\n| 7° | pelle di pietra, scolpire pietra |\n| 9° | muro di pietra, passapareti |\n\n**Palude**\n\n| Livello da druido | Incantesimi del circolo |\n|---|---|\n| 3° | freccia acida, oscurità |\n| 5° | camminare sull'acqua, nube maleodorante |\n| 7° | libertà di movimento, localizza creatura |\n| 9° | piaga degli insetti, scrutare |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/land-s-stride"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/land-s-stride", "en"), Language = LanguageCode.En, Name = "Land's Stride", Description = "Starting at 6th level, moving through nonmagical difficult terrain costs you no extra movement. You can also pass through nonmagical plants without being slowed by them and without taking damage from them if they have thorns, spines, or a similar hazard.\n\nIn addition, you have advantage on saving throws against plants that are magically created or manipulated to impede movement, such as those created by the *entangle* spell." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/land-s-stride", "it"), Language = LanguageCode.It, Name = "Andatura sul Territorio", Description = "A partire dal 6° livello, attraversare terreno difficile non magico non costa al druido movimento extra. Può inoltre attraversare la vegetazione non magica senza esserne rallentato e senza subire danni se presenta spine, aculei o pericoli simili.\n\nInoltre dispone di vantaggio ai tiri salvezza contro le piante create o manipolate magicamente per ostacolare il movimento, come quelle create dall'incantesimo *intralciare*." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/nature-s-ward"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/nature-s-ward", "en"), Language = LanguageCode.En, Name = "Nature's Ward", Description = "When you reach 10th level, you can't be charmed or frightened by elementals or fey, and you are immune to poison and disease." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/nature-s-ward", "it"), Language = LanguageCode.It, Name = "Interdizione della Natura", Description = "Quando arriva al 10° livello, il druido non può essere affascinato o spaventato da elementali o folletti ed è immune ai veleni e alle malattie." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/nature-s-sanctuary"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/nature-s-sanctuary", "en"), Language = LanguageCode.En, Name = "Nature's Sanctuary", Description = "When you reach 14th level, creatures of the natural world sense your connection to nature and become hesitant to attack you.\n\nWhen a beast or plant creature attacks you, that creature must make a Wisdom saving throw against your druid spell save DC. On a failed save, the creature must choose a different target, or the attack automatically misses. On a successful save, the creature is immune to this effect for 24 hours.\n\nThe creature is aware of this effect before it makes its attack against you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-land/nature-s-sanctuary", "it"), Language = LanguageCode.It, Name = "Rifugio della Natura", Description = "Quando arriva al 14° livello, le creature del mondo naturale percepiscono il legame del druido con la natura ed esitano ad attaccarlo.\n\nQuando una bestia o una creatura vegetale attacca il druido, deve effettuare un tiro salvezza su Saggezza contro la CD del tiro salvezza dei suoi incantesimi da druido. Se lo fallisce, deve scegliere un bersaglio diverso, altrimenti l'attacco manca automaticamente. Se lo supera, la creatura è immune a questo effetto per 24 ore.\n\nLa creatura è consapevole di questo effetto prima di effettuare l'attacco contro il druido." }
					}
				}
			}
		};
	}
}
