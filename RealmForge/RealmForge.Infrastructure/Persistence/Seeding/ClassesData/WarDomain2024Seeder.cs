using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	War Domain (cleric, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class WarDomain2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "war-domain");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Cleric2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "war-domain", "en"), Language = LanguageCode.En, Name = "War Domain", Description = "War takes many forms: it can turn ordinary folk into heroes, or sink into despair and horror where cruelty and cowardice outshine courage. Clerics of the War Domain shine on the battlefield, urging others to fight for a just cause or offering violence itself as a prayer. Their gods watch over warriors and reward great deeds; some champion honor and chivalry, others destruction and plunder, and still others favor war in every guise." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "war-domain", "it"), Language = LanguageCode.It, Name = "Dominio della Guerra", Description = "La guerra assume molte forme: può trasformare la gente comune in eroi, oppure sprofondare nella disperazione e nell'orrore, dove la crudeltà e la viltà oscurano il coraggio. I chierici del Dominio della Guerra brillano sul campo di battaglia, spronando gli altri a combattere per una giusta causa o offrendo la violenza stessa come preghiera. I loro dei vegliano sui guerrieri e ricompensano le grandi imprese; alcuni difendono l'onore e la cavalleria, altri la distruzione e il saccheggio, altri ancora favoriscono la guerra in ogni sua forma." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/guided-strike"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/guided-strike", "en"), Language = LanguageCode.En, Name = "Guided Strike", Description = "When you or a creature within 30 feet of you misses with an attack roll, you can spend a use of Channel Divinity to give that roll a +10 bonus, which might turn it into a hit. If the roll belongs to another creature, doing so takes your Reaction." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/guided-strike", "it"), Language = LanguageCode.It, Name = "Colpo Guidato", Description = "Se un tiro per colpire del chierico, o di una creatura entro 9 metri da lui, manca il bersaglio, il chierico può spendere un utilizzo di Incanalare Divinità e aggiungere +10 al risultato, magari mutandolo in un colpo riuscito. Aiutare così un'altra creatura richiede la sua reazione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/war-domain-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/war-domain-spells", "en"), Language = LanguageCode.En, Name = "War Domain Spells", Description = "Your bond with this domain keeps certain spells always at hand: from the Cleric level shown in the table below onward, the listed spells are always prepared for you.\n\n| Cleric Level | Prepared Spells |\n|---|---|\n| 3 | *Guiding Bolt*, *Magic Weapon*, *Shield of Faith*, *Spiritual Weapon* |\n| 5 | *Crusader's Mantle*, *Spirit Guardians* |\n| 7 | *Fire Shield*, *Freedom of Movement* |\n| 9 | *Hold Monster*, *Steel Wind Strike* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/war-domain-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Dominio della Guerra", Description = "Grazie al legame con il suo dominio, il chierico ha sempre a disposizione alcuni incantesimi: dal livello da chierico indicato nella tabella seguente, gli incantesimi elencati sono sempre preparati per lui.\n\n| Livello da chierico | Incantesimi preparati |\n|---|---|\n| 3 | *arma magica*, *arma spirituale*, *dardo tracciante*, *scudo della fede* |\n| 5 | *guardiani spirituali*, *manto del crociato* |\n| 7 | *libertà di movimento*, *scudo di fuoco* |\n| 9 | *blocca mostri*, *turbine implacabile* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/war-priest"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/war-priest", "en"), Language = LanguageCode.En, Name = "War Priest", Description = "You can make one attack with a weapon or an Unarmed Strike as a Bonus Action. You can do so a number of times equal to your Wisdom modifier (at least once), regaining every expended use after a Short or Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/war-priest", "it"), Language = LanguageCode.It, Name = "Sacerdote di Guerra", Description = "Il chierico può sferrare un singolo attacco con un'arma, o un colpo senz'armi, usando un'azione bonus. Ha a disposizione tanti di questi attacchi quanto è il suo modificatore di Saggezza (almeno uno) e li recupera tutti al termine di un riposo, breve o lungo che sia." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/war-gods-blessing"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/war-gods-blessing", "en"), Language = LanguageCode.En, Name = "War God's Blessing", Description = "Instead of a spell slot, you can spend a use of Channel Divinity to cast *Shield of Faith* or *Spiritual Weapon*. A spell cast this way needs no Concentration; it simply lasts 1 minute, ending early if you cast that same spell again, become Incapacitated, or die." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/war-gods-blessing", "it"), Language = LanguageCode.It, Name = "Benedizione del Dio della Guerra", Description = "Il chierico può spendere un utilizzo di Incanalare Divinità anziché uno slot incantesimo per lanciare *arma spirituale* o *scudo della fede*. Un incantesimo lanciato in questo modo non richiede concentrazione: dura invece 1 minuto, ma termina prima se il chierico lancia di nuovo lo stesso incantesimo, se subisce la condizione di incapacitato o se muore." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/avatar-of-battle"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/avatar-of-battle", "en"), Language = LanguageCode.En, Name = "Avatar of Battle", Description = "Battle has hardened you: you have Resistance to Slashing, Piercing, and Bludgeoning damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "war-domain/avatar-of-battle", "it"), Language = LanguageCode.It, Name = "Avatar della Battaglia", Description = "Il chierico è ormai un campione temprato dalla battaglia: dispone di resistenza ai danni taglienti, perforanti e contundenti." }
					}
				}
			}
		};
	}
}
