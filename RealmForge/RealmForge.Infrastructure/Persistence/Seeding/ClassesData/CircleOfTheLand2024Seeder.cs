using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Circle of the Land (druid, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CircleOfTheLand2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-land");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Druid2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-land", "en"), Language = LanguageCode.En, Name = "Circle of the Land", Description = "The Circle of the Land comprises mystics and sages who safeguard ancient knowledge and rites. These Druids meet within sacred circles of trees or standing stones to whisper primal secrets in Druidic. The circle’s wisest members preside as the chief priests of their communities." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-land", "it"), Language = LanguageCode.It, Name = "Circolo della Terra", Description = "Il Circolo della Terra riunisce mistici e saggi che custodiscono conoscenze e riti antichi. Questi druidi si incontrano in cerchi sacri di alberi o di pietre erette per sussurrare in druidico i segreti primordiali, e i membri più saggi del circolo fungono da sommi sacerdoti delle loro comunità." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/circle-of-the-land-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/circle-of-the-land-spells", "en"), Language = LanguageCode.En, Name = "Circle of the Land Spells", Description = "Whenever you finish a Long Rest, choose one type of land: arid, polar, temperate, or tropical. Consult the table below that corresponds to the chosen type; you have the spells listed for your Druid level and lower prepared.\n\n**Arid Land**\n\n| Druid Level | Circle Spells |\n|---|---|\n| 3 | *Blur*, *Burning Hands*, *Fire Bolt* |\n| 5 | *Fireball* |\n| 7 | *Blight* |\n| 9 | *Wall of Stone* |\n\n**Polar Land**\n\n| Druid Level | Circle Spells |\n|---|---|\n| 3 | *Fog Cloud*, *Hold Person*, *Ray of Frost* |\n| 5 | *Sleet Storm* |\n| 7 | *Ice Storm* |\n| 9 | *Cone of Cold* |\n\n**Temperate Land**\n\n| Druid Level | Circle Spells |\n|---|---|\n| 3 | *Misty Step*, *Shocking Grasp*, *Sleep* |\n| 5 | *Lightning Bolt* |\n| 7 | *Freedom of Movement* |\n| 9 | *Tree Stride* |\n\n**Tropical Land**\n\n| Druid Level | Circle Spells |\n|---|---|\n| 3 | *Acid Splash*, *Ray of Sickness*, *Web* |\n| 5 | *Stinking Cloud* |\n| 7 | *Polymorph* |\n| 9 | *Insect Plague* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/circle-of-the-land-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Circolo della Terra", Description = "Ogni volta che completa un riposo lungo, il druido sceglie un tipo di terra: arida, polare, temperata o tropicale. Ha preparati gli incantesimi indicati nella tabella corrispondente al tipo scelto per il suo livello da druido e per quelli inferiori.\n\n**Terra arida**\n\n| Livello da druido | Incantesimi del Circolo |\n|---|---|\n| 3 | *dardo di fuoco*, *mani brucianti*, *sfocatura* |\n| 5 | *palla di fuoco* |\n| 7 | *inaridire* |\n| 9 | *muro di pietra* |\n\n**Terra polare**\n\n| Livello da druido | Incantesimi del Circolo |\n|---|---|\n| 3 | *blocca persone*, *nube di nebbia*, *raggio di gelo* |\n| 5 | *tempesta di nevischio* |\n| 7 | *tempesta di ghiaccio* |\n| 9 | *cono di freddo* |\n\n**Terra temperata**\n\n| Livello da druido | Incantesimi del Circolo |\n|---|---|\n| 3 | *passo velato*, *sonno*, *stretta folgorante* |\n| 5 | *fulmine* |\n| 7 | *libertà di movimento* |\n| 9 | *traslazione arborea* |\n\n**Terra tropicale**\n\n| Livello da druido | Incantesimi del Circolo |\n|---|---|\n| 3 | *fiotto acido*, *raggio di infermità*, *ragnatela* |\n| 5 | *nube maleodorante* |\n| 7 | *metamorfosi* |\n| 9 | *piaga degli insetti* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/lands-aid"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/lands-aid", "en"), Language = LanguageCode.En, Name = "Land's Aid", Description = "As a Magic action, you can expend a use of your Wild Shape and choose a point within 60 feet of yourself. Vitality-giving flowers and lifedraining thorns appear for a moment in a 10-foot-radius Sphere centered on that point. Each creature of your choice in the Sphere must make a Constitution saving throw against your spell save DC, taking 2d6 Necrotic damage on a failed save or half as much damage on a successful one. One creature of your choice in that area regains 2d6 Hit Points.\n\nThe damage and healing increase by 1d6 when you reach Druid levels 10 (3d6) and 14 (4d6)." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/lands-aid", "it"), Language = LanguageCode.It, Name = "Ausilio della Terra", Description = "Con un'azione di Magia, il druido può spendere un utilizzo di Forma Selvatica e scegliere un punto entro 18 metri da lui. Per un istante, in una sfera del raggio di 3 metri centrata su quel punto, spuntano fiori che donano vitalità e spine che prosciugano la vita. Ogni creatura a sua scelta nella sfera deve effettuare un tiro salvezza su Costituzione contro la CD del tiro salvezza dei suoi incantesimi: se lo fallisce subisce 2d6 danni necrotici, se lo supera ne subisce la metà. Una creatura a sua scelta nell'area recupera 2d6 punti ferita.\n\nI danni e la guarigione aumentano di 1d6 al 10° (3d6) e al 14° livello da druido (4d6)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/natural-recovery"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/natural-recovery", "en"), Language = LanguageCode.En, Name = "Natural Recovery", Description = "You can cast one of the level 1+ spells that you have prepared from your Circle Spells feature without expending a spell slot, and you must finish a Long Rest before you do so again.\n\nIn addition, when you finish a Short Rest, you can choose expended spell slots to recover. The spell slots can have a combined level that is equal to or less than half your Druid level (round up), and none of them can be level 6+. For example, if you’re a level 6 Druid, you can recover up to three levels’ worth of spell slots. You can recover a level 3 spell slot, a level 2 and a level 1 spell slot, or three level 1 spell slots. Once you recover spell slots with this feature, you can’t do so again until you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/natural-recovery", "it"), Language = LanguageCode.It, Name = "Recupero Naturale", Description = "Il druido può lanciare uno degli incantesimi di 1° livello o superiore che ha preparati grazie al privilegio Incantesimi del Circolo senza spendere uno slot incantesimo; deve completare un riposo lungo prima di poterlo fare di nuovo.\n\nInoltre, quando completa un riposo breve, il druido può scegliere alcuni slot incantesimo spesi da recuperare. Gli slot possono avere un livello complessivo pari o inferiore alla metà del suo livello da druido (arrotondato per eccesso) e nessuno di essi può essere di 6° livello o superiore. Per esempio, un druido di 6° livello può recuperare slot incantesimo per un totale di tre livelli: uno slot di 3° livello, uno di 2° e uno di 1° livello, oppure tre slot di 1° livello. Dopo aver recuperato slot incantesimo con questo privilegio, non può farlo di nuovo finché non completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/natures-ward"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/natures-ward", "en"), Language = LanguageCode.En, Name = "Nature's Ward", Description = "You are immune to the Poisoned condition, and you have Resistance to a damage type associated with your current land choice in the Circle Spells feature, as shown in the table below.\n\n| Land Type | Resistance |\n|---|---|\n| Arid | Fire |\n| Polar | Cold |\n| Temperate | Lightning |\n| Tropical | Poison |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/natures-ward", "it"), Language = LanguageCode.It, Name = "Interdizione della Natura", Description = "Il druido è immune alla condizione di avvelenato e ha resistenza a un tipo di danni associato alla terra attualmente scelta per il privilegio Incantesimi del Circolo, come indicato nella tabella seguente.\n\n| Tipo di terra | Resistenza |\n|---|---|\n| Arida | Fuoco |\n| Polare | Freddo |\n| Temperata | Fulmine |\n| Tropicale | Veleno |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/natures-sanctuary"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/natures-sanctuary", "en"), Language = LanguageCode.En, Name = "Nature's Sanctuary", Description = "As a Magic action, you can expend a use of your Wild Shape and cause spectral trees and vines to appear in a 15-foot Cube on the ground within 120 feet of yourself. They last there for 1 minute or until you have the Incapacitated condition or die. You and your allies have Half Cover while in that area, and your allies gain the current Resistance of your Nature’s Ward while there.\n\nAs a Bonus Action, you can move the Cube up to 60 feet to ground within 120 feet of yourself." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-land/natures-sanctuary", "it"), Language = LanguageCode.It, Name = "Rifugio della Natura", Description = "Con un'azione di Magia, il druido può spendere un utilizzo di Forma Selvatica per far apparire alberi e rampicanti spettrali in un cubo con spigolo di 4,5 metri sul terreno entro 36 metri da lui. Rimangono lì per 1 minuto o finché il druido non subisce la condizione di incapacitato o non muore. Il druido e i suoi alleati beneficiano di mezza copertura mentre si trovano nell'area, e gli alleati ottengono, finché vi rimangono, la resistenza attualmente conferita da Interdizione della natura.\n\nCome azione bonus, il druido può spostare il cubo fino a 18 metri, su un terreno entro 36 metri da lui." }
					}
				}
			}
		};
	}
}
