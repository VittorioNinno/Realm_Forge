using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	War Domain (cleric, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class WarDomain2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "war-domain");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Cleric2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "war-domain", "en"), Language = LanguageCode.En, Name = "War Domain", Description = "War can turn ordinary people into heroes, or sink into despair and horror where cruelty and cowardice outshine courage. Gods of war watch over warriors and reward their deeds. They range from champions of honor and chivalry to lords of destruction and plunder, from gods of conquest and domination to neutral powers who embrace every face of battle. Their clerics excel in combat, urging others to fight the good fight or offering violence itself as prayer." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "war-domain", "it"), Language = LanguageCode.It, Name = "Dominio della Guerra", Description = "La guerra può trasformare gente comune in eroi, oppure sprofondare nella disperazione e nell'orrore, dove crudeltà e codardia offuscano il coraggio. Gli dèi della guerra vegliano sui guerrieri e ne ricompensano le gesta. Spaziano dai campioni dell'onore e della cavalleria ai signori della distruzione e del saccheggio, dagli dèi della conquista e del dominio alle potenze neutrali che abbracciano ogni volto della battaglia. I loro chierici eccellono in combattimento, spronando gli altri a combattere per una giusta causa o offrendo la violenza stessa come preghiera." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/war-domain-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/war-domain-spells", "en"), Language = LanguageCode.En, Name = "War Domain Spells", Description = "You gain these domain spells at the cleric levels shown. See the Divine Domain class feature for how domain spells work.\n\n| Cleric Level | Spells |\n|---|---|\n| 1st | divine favor, shield of faith |\n| 3rd | magic weapon, spiritual weapon |\n| 5th | crusader's mantle, spirit guardians |\n| 7th | freedom of movement, stoneskin |\n| 9th | flame strike, hold monster |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/war-domain-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Dominio della Guerra", Description = "Il chierico ottiene questi incantesimi di dominio ai livelli da chierico indicati. Il funzionamento degli incantesimi di dominio è descritto nel privilegio di classe Dominio Divino.\n\n| Livello da chierico | Incantesimi |\n|---|---|\n| 1° | favore divino, scudo della fede |\n| 3° | arma magica, arma spirituale |\n| 5° | guardiani spirituali, manto del crociato |\n| 7° | libertà di movimento, pelle di pietra |\n| 9° | blocca mostri, colpo infuocato |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/bonus-proficiencies"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/bonus-proficiencies", "en"), Language = LanguageCode.En, Name = "Bonus Proficiencies", Description = "At 1st level, you become proficient with martial weapons and heavy armor." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/bonus-proficiencies", "it"), Language = LanguageCode.It, Name = "Competenze Bonus", Description = "Al 1° livello il chierico ottiene competenza nelle armi da guerra e nelle armature pesanti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/war-priest"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/war-priest", "en"), Language = LanguageCode.En, Name = "War Priest", Description = "From 1st level, your god sends you bursts of zeal in battle. When you take the Attack action, you can make one weapon attack as a bonus action.\n\nYou can do so a number of times equal to your Wisdom modifier (at least once), and you regain all uses when you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/war-priest", "it"), Language = LanguageCode.It, Name = "Sacerdote di Guerra", Description = "Dal 1° livello la divinità del chierico gli infonde slanci di fervore in battaglia. Quando effettua l'azione di Attacco, il chierico può effettuare un attacco con un'arma come azione bonus.\n\nPuò farlo un numero di volte pari al suo modificatore di Saggezza (almeno una volta) e recupera tutti gli utilizzi quando completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/channel-divinity-guided-strike"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/channel-divinity-guided-strike", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Guided Strike", Description = "From 2nd level, when you make an attack roll, you can use your Channel Divinity to add +10 to it. You decide after seeing the roll, but before the DM says whether the attack hits or misses." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/channel-divinity-guided-strike", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Colpo Guidato", Description = "Dal 2° livello, quando effettua un tiro per colpire, il chierico può usare Incanalare Divinità per aggiungervi +10. Decide dopo aver visto il risultato, ma prima che il DM dica se l'attacco va a segno o manca." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/channel-divinity-war-god-s-blessing"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/channel-divinity-war-god-s-blessing", "en"), Language = LanguageCode.En, Name = "Channel Divinity: War God's Blessing", Description = "From 6th level, when a creature within 30 feet of you makes an attack roll, you can use your reaction and your Channel Divinity to add +10 to that roll. You decide after seeing the roll, but before the DM says whether the attack hits or misses." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/channel-divinity-war-god-s-blessing", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Benedizione del Dio della Guerra", Description = "Dal 6° livello, quando una creatura entro 9 metri dal chierico effettua un tiro per colpire, il chierico può usare la sua reazione e Incanalare Divinità per aggiungere +10 a quel tiro. Decide dopo aver visto il risultato, ma prima che il DM dica se l'attacco va a segno o manca." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/divine-strike"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 8,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/divine-strike", "en"), Language = LanguageCode.En, Name = "Divine Strike", Description = "At 8th level, divine power flows into your weapon. Once on each of your turns when you hit a creature with a weapon attack, you can deal an extra 1d8 damage of the same type as the weapon's damage. The extra damage becomes 2d8 at 14th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/divine-strike", "it"), Language = LanguageCode.It, Name = "Colpo Divino", Description = "All'8° livello il potere divino fluisce nell'arma del chierico. Una volta in ognuno dei suoi turni, quando colpisce una creatura con un attacco con un'arma, può infliggerle 1d8 danni extra dello stesso tipo dei danni dell'arma. I danni extra diventano 2d8 al 14° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/avatar-of-battle"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/avatar-of-battle", "en"), Language = LanguageCode.En, Name = "Avatar of Battle", Description = "At 17th level, you have resistance to bludgeoning, piercing, and slashing damage from nonmagical weapons." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "war-domain/avatar-of-battle", "it"), Language = LanguageCode.It, Name = "Avatar della Battaglia", Description = "Al 17° livello il chierico ha resistenza ai danni contundenti, perforanti e taglienti inflitti da armi non magiche." }
					}
				}
			}
		};
	}
}
