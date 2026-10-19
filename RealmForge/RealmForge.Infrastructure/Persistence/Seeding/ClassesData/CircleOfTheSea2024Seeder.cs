using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Circle of the Sea (druid, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class CircleOfTheSea2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-sea");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Druid2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-sea", "en"), Language = LanguageCode.En, Name = "Circle of the Sea", Description = "Druids of the Circle of the Sea call on the restless power of oceans and storms. Some see themselves as nature's wrath made flesh, hunting down those who defile the wild. Others seek a mystic union with the world by tuning themselves to the rise and fall of the tides, riding currents and waves and heeding the murmurs and howls of the wind." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-sea", "it"), Language = LanguageCode.It, Name = "Circolo del Mare", Description = "I druidi del Circolo del Mare invocano la forza irrequieta degli oceani e delle tempeste. Alcuni si considerano l'ira della natura fatta carne e danno la caccia a chi profana il mondo selvaggio. Altri cercano un'unione mistica con il mondo accordandosi al flusso e al riflusso delle maree, seguendo correnti e onde e ascoltando i mormorii e gli ululati del vento." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/circle-of-the-sea-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/circle-of-the-sea-spells", "en"), Language = LanguageCode.En, Name = "Circle of the Sea Spells", Description = "From the Druid level shown in the table below onward, the listed spells are always prepared for you.\n\n| Druid Level | Prepared Spells |\n|---|---|\n| 3 | *Fog Cloud*, *Gust of Wind*, *Ray of Frost*, *Shatter*, *Thunderwave* |\n| 5 | *Lightning Bolt*, *Water Breathing* |\n| 7 | *Control Water*, *Ice Storm* |\n| 9 | *Conjure Elemental*, *Hold Monster* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/circle-of-the-sea-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Circolo del Mare", Description = "Dal livello da druido indicato nella tabella seguente, il druido ha sempre preparati gli incantesimi elencati.\n\n| Livello da druido | Incantesimi preparati |\n|---|---|\n| 3 | *folata di vento*, *frantumare*, *nube di nebbia*, *onda tonante*, *raggio di gelo* |\n| 5 | *fulmine*, *respirare sott'acqua* |\n| 7 | *controllare acqua*, *tempesta di ghiaccio* |\n| 9 | *blocca mostri*, *evoca elementale* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/wrath-of-the-sea"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/wrath-of-the-sea", "en"), Language = LanguageCode.En, Name = "Wrath of the Sea", Description = "As a Bonus Action, you can spend a use of Wild Shape to wrap yourself for 10 minutes in a 5-foot Emanation of churning sea spray. It ends sooner if you dismiss it (no action required), call it up again, or become Incapacitated.\n\nWhen the Emanation appears, and as a Bonus Action on each of your later turns, you can pick another creature you can see inside it. The target must succeed on a Constitution saving throw against your spell save DC or take Cold damage and, if it is Large or smaller, be shoved up to 15 feet away from you. For the damage, roll a number of d6s equal to your Wisdom modifier (at least one die)." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/wrath-of-the-sea", "it"), Language = LanguageCode.It, Name = "Furia dei Mari", Description = "Come azione bonus, il druido può spendere un utilizzo di Forma Selvatica per far apparire attorno a sé, per 10 minuti, un'emanazione di 1,5 metri fatta di spruzzi marini. L'effetto termina prima se il druido lo congeda (nessuna azione richiesta), se lo evoca di nuovo o se subisce la condizione di incapacitato.\n\nQuando fa apparire l'emanazione e, come azione bonus, in ognuno dei turni successivi, il druido può scegliere un'altra creatura che è in grado di vedere all'interno dell'emanazione. Il bersaglio deve superare un tiro salvezza su Costituzione contro la CD del tiro salvezza dei suoi incantesimi, altrimenti subisce danni da freddo e, se è di taglia Grande o inferiore, viene spinto fino a 4,5 metri lontano dal druido. Per i danni si tirano tanti d6 quanto è il modificatore di Saggezza del druido (almeno un dado)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/aquatic-affinity"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/aquatic-affinity", "en"), Language = LanguageCode.En, Name = "Aquatic Affinity", Description = "The Emanation of your Wrath of the Sea grows to 10 feet, and you gain a Swim Speed equal to your Speed." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/aquatic-affinity", "it"), Language = LanguageCode.It, Name = "Affinità Acquatica", Description = "L'emanazione di Furia dei mari si estende a 3 metri. Il druido ottiene inoltre una velocità di nuotare pari alla sua velocità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/stormborn"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/stormborn", "en"), Language = LanguageCode.En, Name = "Stormborn", Description = "While your Wrath of the Sea is active, it grants you two more benefits.\n\n**Flight.** You have a Fly Speed equal to your Speed.\n\n**Resistance.** You resist Cold, Lightning, and Thunder damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/stormborn", "it"), Language = LanguageCode.It, Name = "Nato dalla Tempesta", Description = "Finché Furia dei mari è attiva, conferisce al druido due benefici aggiuntivi.\n\n**Volo.** Il druido ottiene una velocità di volare pari alla sua velocità.\n\n**Resistenza.** Il druido ha resistenza ai danni da freddo, da fulmine e da tuono." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/oceanic-gift"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/oceanic-gift", "en"), Language = LanguageCode.En, Name = "Oceanic Gift", Description = "Rather than around yourself, you can raise the Emanation of Wrath of the Sea around one willing creature within 60 feet of you. That creature gets every benefit of the Emanation, using your spell save DC and Wisdom modifier for it. If you spend two uses of Wild Shape instead of one, the Emanation can surround both that creature and you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-sea/oceanic-gift", "it"), Language = LanguageCode.It, Name = "Dono Oceanico", Description = "Anziché attorno a sé, il druido può far apparire l'emanazione di Furia dei mari attorno a una creatura consenziente entro 18 metri da lui. Quella creatura ottiene tutti i benefici dell'emanazione e, per essa, usa la CD del tiro salvezza degli incantesimi e il modificatore di Saggezza del druido. Spendendo due utilizzi di Forma Selvatica anziché uno, il druido può far apparire l'emanazione sia attorno all'altra creatura sia attorno a se stesso." }
					}
				}
			}
		};
	}
}
