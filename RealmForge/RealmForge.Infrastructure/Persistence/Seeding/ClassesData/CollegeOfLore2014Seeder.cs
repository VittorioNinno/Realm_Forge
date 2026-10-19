using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	College of Lore (bard, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CollegeOfLore2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "college-of-lore");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Bard2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "college-of-lore", "en"), Language = LanguageCode.En, Name = "College of Lore", Description = "Bards of the College of Lore know something about most things, collecting bits of knowledge from sources as diverse as scholarly tomes and peasant tales. Whether singing folk ballads in taverns or elaborate compositions in royal courts, these bards use their gifts to hold audiences spellbound. When the applause dies down, the audience members might find themselves questioning everything they held to be true, from their faith in the priesthood of the local temple to their loyalty to the king.\n\nThe loyalty of these bards lies in the pursuit of beauty and truth, not in fealty to a monarch or following the tenets of a deity. A noble who keeps such a bard as a herald or advisor knows that the bard would rather be honest than politic.\n\nThe college's members gather in libraries and sometimes in actual colleges, complete with classrooms and dormitories, to share their lore with one another. They also meet at festivals or affairs of state, where they can expose corruption, unravel lies, and poke fun at self-important figures of authority." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "college-of-lore", "it"), Language = LanguageCode.It, Name = "Collegio della Sapienza", Description = "I bardi del Collegio della Sapienza sanno qualcosa su quasi tutto, raccogliendo frammenti di conoscenza dalle fonti più diverse, dai tomi eruditi alle storie dei contadini. Che cantino ballate popolari nelle taverne o composizioni elaborate nelle corti reali, questi bardi usano il loro talento per incantare il pubblico. Quando gli applausi si spengono, gli spettatori potrebbero ritrovarsi a mettere in dubbio tutto ciò che credevano vero, dalla fiducia nel clero del tempio locale alla lealtà verso il re.\n\nLa lealtà di questi bardi sta nella ricerca della bellezza e della verità, non nella fedeltà a un sovrano o nei dettami di una divinità. Un nobile che tiene un bardo del genere come araldo o consigliere sa che preferirà essere onesto piuttosto che diplomatico.\n\nI membri del collegio si riuniscono nelle biblioteche e talvolta in veri e propri collegi, con aule e dormitori, per condividere il loro sapere. Si incontrano anche in occasione di feste o affari di stato, dove possono smascherare la corruzione, sbrogliare le menzogne e prendersi gioco delle autorità piene di sé." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/bonus-proficiencies"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/bonus-proficiencies", "en"), Language = LanguageCode.En, Name = "Bonus Proficiencies", Description = "When you join the College of Lore at 3rd level, you gain proficiency with three skills of your choice." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/bonus-proficiencies", "it"), Language = LanguageCode.It, Name = "Competenze Bonus", Description = "Quando si unisce al Collegio della Sapienza al 3° livello, il bardo ottiene competenza in tre abilità a sua scelta." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/cutting-words"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/cutting-words", "en"), Language = LanguageCode.En, Name = "Cutting Words", Description = "Also at 3rd level, you learn how to use your wit to distract, confuse, and otherwise sap the confidence and competence of others.\n\nWhen a creature that you can see within 60 feet of you makes an attack roll, an ability check, or a damage roll, you can use your reaction to expend one of your uses of Bardic Inspiration, rolling a Bardic Inspiration die and subtracting the number rolled from the creature's roll.\n\nYou can choose to use this feature after the creature makes its roll, but before the GM determines whether the attack roll or ability check succeeds or fails, or before the creature deals its damage. The creature is immune if it can't hear you or if it's immune to being charmed." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/cutting-words", "it"), Language = LanguageCode.It, Name = "Parole Taglienti", Description = "Sempre al 3° livello, il bardo impara a usare il proprio spirito per distrarre, confondere e altrimenti minare la sicurezza e la competenza altrui.\n\nQuando una creatura entro 18 metri che il bardo è in grado di vedere effettua un tiro per colpire, una prova di caratteristica o un tiro per i danni, il bardo può usare la sua reazione per spendere uno dei suoi utilizzi di Ispirazione Bardica, tirando un dado di Ispirazione Bardica e sottraendo il risultato dal tiro della creatura.\n\nPuò decidere di usare questo privilegio dopo che la creatura ha effettuato il tiro, ma prima che il DM stabilisca se il tiro per colpire o la prova di caratteristica hanno successo, o prima che la creatura infligga i danni. La creatura è immune se non è in grado di sentire il bardo o se è immune all'essere affascinata." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/additional-magical-secrets"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/additional-magical-secrets", "en"), Language = LanguageCode.En, Name = "Additional Magical Secrets", Description = "At 6th level, you learn two spells of your choice from any class. A spell you choose must be of a level you can cast, as shown on the Bard table, or a cantrip. The chosen spells count as bard spells for you but don't count against the number of bard spells you know." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/additional-magical-secrets", "it"), Language = LanguageCode.It, Name = "Segreti Magici Aggiuntivi", Description = "Al 6° livello il bardo apprende due incantesimi a sua scelta da qualsiasi classe. Ogni incantesimo scelto deve essere di un livello che è in grado di lanciare, come indicato nella tabella del Bardo, oppure un trucchetto. Gli incantesimi scelti contano come incantesimi da bardo per lui, ma non rientrano nel numero di incantesimi da bardo che conosce." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/peerless-skill"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/peerless-skill", "en"), Language = LanguageCode.En, Name = "Peerless Skill", Description = "Starting at 14th level, when you make an ability check, you can expend one use of Bardic Inspiration.\n\nRoll a Bardic Inspiration die and add the number rolled to your ability check.\n\nYou can choose to do so after you roll the die for the ability check, but before the GM tells you whether you succeed or fail." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-lore/peerless-skill", "it"), Language = LanguageCode.It, Name = "Abilità Impareggiabile", Description = "A partire dal 14° livello, quando effettua una prova di caratteristica, il bardo può spendere un utilizzo di Ispirazione Bardica.\n\nTira un dado di Ispirazione Bardica e aggiunge il risultato alla prova di caratteristica.\n\nPuò decidere di farlo dopo aver tirato il dado per la prova, ma prima che il DM gli dica se ha avuto successo o meno." }
					}
				}
			}
		};
	}
}
