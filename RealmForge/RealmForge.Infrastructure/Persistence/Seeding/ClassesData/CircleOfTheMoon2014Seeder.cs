using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Circle of the Moon (druid, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class CircleOfTheMoon2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "circle-of-the-moon");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Druid2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "circle-of-the-moon", "en"), Language = LanguageCode.En, Name = "Circle of the Moon", Description = "Druids of this circle are the fierce wardens of the deep wilderness. They gather under the full moon to swap news and warnings, then vanish for weeks into places where they rarely meet another soul. As changeable as the moon, they might stalk the night as a great cat, glide over the forest as an eagle the next morning and crash through the undergrowth as a bear to chase off an intruder: the wild runs in their blood." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "circle-of-the-moon", "it"), Language = LanguageCode.It, Name = "Circolo della Luna", Description = "I druidi di questo circolo sono i feroci custodi delle terre selvagge più remote. Si riuniscono sotto la luna piena per scambiarsi notizie e avvertimenti, poi spariscono per settimane in luoghi dove raramente incontrano anima viva. Mutevoli come la luna, possono aggirarsi nella notte come un grande felino, librarsi sopra la foresta come un'aquila il mattino seguente e farsi strada nel sottobosco come un orso per scacciare un intruso: la natura selvaggia scorre nel loro sangue." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/combat-wild-shape"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/combat-wild-shape", "en"), Language = LanguageCode.En, Name = "Combat Wild Shape", Description = "When you choose this circle at 2nd level, Wild Shape becomes a bonus action for you instead of an action.\n\nAlso, while transformed by Wild Shape, you can use a bonus action to expend a spell slot and regain 1d8 hit points per level of the slot spent." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/combat-wild-shape", "it"), Language = LanguageCode.It, Name = "Forma Selvatica da Combattimento", Description = "Quando sceglie questo circolo al 2° livello, per il druido Forma Selvatica diventa un'azione bonus anziché un'azione.\n\nInoltre, mentre è trasformato tramite Forma Selvatica, può usare un'azione bonus per spendere uno slot incantesimo e recuperare 1d8 punti ferita per ogni livello dello slot speso." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/circle-forms"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/circle-forms", "en"), Language = LanguageCode.En, Name = "Circle Forms", Description = "Your circle's rites let you take far more dangerous shapes. From 2nd level, Wild Shape can turn you into a beast of challenge rating 1 or lower: ignore the Max. CR column of the Beast Shapes table, but keep its other limitations.\n\nFrom 6th level, the highest challenge rating you can assume becomes your druid level divided by 3, rounded down." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/circle-forms", "it"), Language = LanguageCode.It, Name = "Forme del Circolo", Description = "I riti del circolo permettono al druido di assumere forme molto più pericolose. Dal 2° livello, Forma Selvatica può trasformarlo in una bestia con grado di sfida pari o inferiore a 1: il druido ignora la colonna \"GS massimo\" della tabella delle Forme bestiali, ma rispetta le altre limitazioni.\n\nDal 6° livello, il grado di sfida massimo che può assumere diventa pari al suo livello da druido diviso per 3, arrotondato per difetto." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/primal-strike"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/primal-strike", "en"), Language = LanguageCode.En, Name = "Primal Strike", Description = "From 6th level, the attacks you make in beast form count as magical when it comes to overcoming resistance and immunity to nonmagical attacks and damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/primal-strike", "it"), Language = LanguageCode.It, Name = "Colpo Primordiale", Description = "Dal 6° livello, gli attacchi che il druido effettua in forma bestiale sono considerati magici ai fini di superare la resistenza e l'immunità agli attacchi e ai danni non magici." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/elemental-wild-shape"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/elemental-wild-shape", "en"), Language = LanguageCode.En, Name = "Elemental Wild Shape", Description = "At 10th level, you can spend two uses of Wild Shape at once to become an air elemental, an earth elemental, a fire elemental, or a water elemental." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/elemental-wild-shape", "it"), Language = LanguageCode.It, Name = "Forma Selvatica Elementale", Description = "Al 10° livello il druido può spendere due utilizzi di Forma Selvatica contemporaneamente per trasformarsi in un elementale dell'aria, un elementale della terra, un elementale del fuoco o un elementale dell'acqua." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/thousand-forms"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/thousand-forms", "en"), Language = LanguageCode.En, Name = "Thousand Forms", Description = "At 14th level, your mastery of shapechanging extends to subtler changes: you can cast *alter self* at will." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "circle-of-the-moon/thousand-forms", "it"), Language = LanguageCode.It, Name = "Mille Forme", Description = "Al 14° livello la padronanza del druido nel mutare forma si estende ai cambiamenti più sottili: può lanciare *alterare se stesso* a volontà." }
					}
				}
			}
		};
	}
}
