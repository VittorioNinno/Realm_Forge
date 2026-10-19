using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Trickery Domain (cleric, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class TrickeryDomain2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "trickery-domain");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "trickery-domain", "en"), Language = LanguageCode.En, Name = "Trickery Domain", Description = "The Trickery Domain grants magic of disguise, illusion and stealth. Its Clerics shake up the world: they deflate the proud, mock tyrants, free prisoners and ignore empty customs, favoring ruses and pranks over open conflict. Their gods are mischief-makers and agitators who embody change and upheaval, patrons of thieves, gamblers, rebels and liberators, and secret orders that work against oppressive rulers draw on this power too." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "trickery-domain", "it"), Language = LanguageCode.It, Name = "Dominio dell'Inganno", Description = "Il Dominio dell'Inganno conferisce una magia fatta di travestimenti, illusioni e furtività. I suoi chierici scuotono il mondo: sgonfiano i superbi, deridono i tiranni, liberano i prigionieri e ignorano le usanze vuote, preferendo astuzie e scherzi allo scontro aperto. I loro dei sono burloni e agitatori che incarnano il cambiamento e lo sconvolgimento, patroni di ladri, giocatori d'azzardo, ribelli e liberatori; anche gli ordini segreti che lottano contro i governanti oppressivi attingono a questo potere." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/blessing-of-the-trickster"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/blessing-of-the-trickster", "en"), Language = LanguageCode.En, Name = "Blessing of the Trickster", Description = "As a Magic action, you pick yourself or a willing creature within 30 feet of you; the chosen creature has Advantage on Dexterity (Stealth) checks. The blessing lasts until you finish a Long Rest or use this feature again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/blessing-of-the-trickster", "it"), Language = LanguageCode.It, Name = "Benedizione dell'Ingannatore", Description = "Con un'azione di Magia, il chierico benedice se stesso o una creatura consenziente entro 9 metri: fino al suo prossimo riposo lungo, o finché non sceglie un altro beneficiario, il prescelto tira con vantaggio le prove di Destrezza (Furtività)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/trickery-domain-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/trickery-domain-spells", "en"), Language = LanguageCode.En, Name = "Trickery Domain Spells", Description = "Your bond with this domain keeps certain spells always at hand: from the Cleric level shown in the table below onward, the listed spells are always prepared for you.\n\n| Cleric Level | Prepared Spells |\n|---|---|\n| 3 | *Charm Person*, *Disguise Self*, *Invisibility*, *Pass without Trace* |\n| 5 | *Hypnotic Pattern*, *Nondetection* |\n| 7 | *Confusion*, *Dimension Door* |\n| 9 | *Dominate Person*, *Modify Memory* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/trickery-domain-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Dominio dell'Inganno", Description = "Grazie al legame con il suo dominio, il chierico ha sempre a disposizione alcuni incantesimi: dal livello da chierico indicato nella tabella seguente, gli incantesimi elencati sono sempre preparati per lui.\n\n| Livello da chierico | Incantesimi preparati |\n|---|---|\n| 3 | *camuffare se stesso*, *charme su persone*, *invisibilità*, *passare senza tracce* |\n| 5 | *anti-individuazione*, *trama ipnotica* |\n| 7 | *confusione*, *porta dimensionale* |\n| 9 | *dominare persone*, *modificare memoria* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/invoke-duplicity"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/invoke-duplicity", "en"), Language = LanguageCode.En, Name = "Invoke Duplicity", Description = "As a Bonus Action, you can spend a use of Channel Divinity to conjure a flawless visual illusion of yourself in an unoccupied space you can see within 30 feet of you. The illusion has no substance and doesn't fill its space. It lasts 1 minute, ending sooner if you dismiss it (no action required) or become Incapacitated. It moves and copies your expressions and gestures, and while it lasts you gain these benefits.\n\n**Cast Spells.** You can cast spells as if you stood in the illusion's space, though you still rely on your own senses.\n\n**Distract.** While you and your illusion are both within 5 feet of a creature that can see the illusion, your attack rolls against that creature have Advantage, because the double is so distracting.\n\n**Move.** As a Bonus Action, you can shift the illusion up to 30 feet to an unoccupied space you can see within 120 feet of you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/invoke-duplicity", "it"), Language = LanguageCode.It, Name = "Invocare Duplicato", Description = "Come azione bonus, il chierico può spendere un utilizzo di Incanalare Divinità per creare un'illusione visiva perfetta di se stesso in uno spazio libero che è in grado di vedere entro 9 metri da lui. L'illusione è intangibile e non occupa il suo spazio; dura 1 minuto, ma termina prima se il chierico la congeda (nessuna azione richiesta) o se subisce la condizione di incapacitato. L'illusione si muove e riproduce le sue espressioni e i suoi gesti. Finché persiste, il chierico ottiene i benefici seguenti.\n\n**Lanciare incantesimi.** Il chierico può lanciare incantesimi come se si trovasse nello spazio dell'illusione, ma usando i propri sensi.\n\n**Distrarre.** Quando sia il chierico sia la sua illusione si trovano entro 1,5 metri da una creatura in grado di vedere l'illusione, il chierico dispone di vantaggio ai tiri per colpire contro quella creatura, tanto l'illusione la distrae.\n\n**Spostare.** Come azione bonus, il chierico può spostare l'illusione fino a 9 metri, in uno spazio libero che è in grado di vedere entro 36 metri da lui." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/tricksters-transposition"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/tricksters-transposition", "en"), Language = LanguageCode.En, Name = "Trickster's Transposition", Description = "Each time you use the Bonus Action to create or shift the illusion of Invoke Duplicity, you can teleport and trade places with it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/tricksters-transposition", "it"), Language = LanguageCode.It, Name = "Trasposizione dell'Ingannatore", Description = "Ogni volta che usa l'azione bonus per creare o spostare l'illusione di Invocare duplicato, il chierico può teletrasportarsi, scambiandosi di posto con l'illusione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/improved-duplicity"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/improved-duplicity", "en"), Language = LanguageCode.En, Name = "Improved Duplicity", Description = "The illusion of Invoke Duplicity grows stronger in these ways.\n\n**Shared Distraction.** You and your allies attack with Advantage any creature standing within 5 feet of the double.\n\n**Healing Illusion.** As the double fades, you or a creature you choose within 5 feet of it recovers Hit Points equal to your Cleric level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "trickery-domain/improved-duplicity", "it"), Language = LanguageCode.It, Name = "Duplicato Migliorato", Description = "Il doppio creato con Invocare duplicato acquista nuovi poteri.\n\n**Distrazione condivisa.** Il chierico e i suoi alleati attaccano con vantaggio ogni creatura che si trova entro 1,5 metri dal doppio.\n\n**Illusione curativa.** Nel momento in cui il doppio svanisce, il chierico, o una creatura da lui scelta entro 1,5 metri dal doppio, recupera tanti punti ferita quanto è il livello da chierico." }
					}
				}
			}
		};
	}
}
