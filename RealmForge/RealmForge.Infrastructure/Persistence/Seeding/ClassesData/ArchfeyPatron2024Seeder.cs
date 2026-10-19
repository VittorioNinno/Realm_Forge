using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Archfey Patron (warlock, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class ArchfeyPatron2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "archfey-patron");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Warlock2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "archfey-patron", "en"), Language = LanguageCode.En, Name = "Archfey Patron", Description = "The Feywild is the wellspring of your pact. Your patron may be one of the great archfey (the frost-crowned Prince, the shadowy Queen who rules the twilight court, the summer queen Titania) or an ancient hag; or you may owe favors to a whole tangle of fey creatures at once. Whoever stands behind your power, expect whims, riddles and bargains with hidden clauses." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "archfey-patron", "it"), Language = LanguageCode.It, Name = "Patrono Signore Fatato", Description = "Il patto del warlock attinge il suo potere dalla Selva Fatata. Potrebbe aver stretto un accordo con un arcifolletto, come il Principe del Gelo, la Regina dell'Aria e dell'Oscurità che governa la Corte del Crepuscolo, Titania della Corte d'Estate o un'antica megera; oppure potrebbe corteggiare molti folletti insieme, tessendo una rete di favori e di debiti. Chiunque siano, i suoi patroni sono di solito capricciosi e difficili da decifrare." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/archfey-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/archfey-spells", "en"), Language = LanguageCode.En, Name = "Archfey Spells", Description = "From the Warlock level shown in the table below onward, the listed spells are always prepared for you.\n\n| Warlock Level | Spells |\n|---|---|\n| 3 | *Calm Emotions*, *Faerie Fire*, *Misty Step*, *Phantasmal Force*, *Sleep* |\n| 5 | *Blink*, *Plant Growth* |\n| 7 | *Dominate Beast*, *Greater Invisibility* |\n| 9 | *Dominate Person*, *Seeming* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/archfey-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Signore Fatato", Description = "Dal livello da warlock indicato nella tabella seguente, il warlock ha sempre preparati gli incantesimi elencati.\n\n| Livello da warlock | Incantesimi |\n|---|---|\n| 3 | *allucinazione di forza*, *calmare emozioni*, *luminescenza*, *passo velato*, *sonno* |\n| 5 | *crescita vegetale*, *intermittenza* |\n| 7 | *dominare bestie*, *invisibilità superiore* |\n| 9 | *dominare persone*, *sembrare* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/steps-of-the-fey"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/steps-of-the-fey", "en"), Language = LanguageCode.En, Name = "Steps of the Fey", Description = "Your patron lets you slip along the seams between planes. A number of times equal to your Charisma modifier (at least once), you can cast *Misty Step* for free, with no slot required; every use returns after a Long Rest.\n\nAlso, each time you cast that spell, you can add one of these effects.\n\n**Refreshing Step.** Right after you teleport, you or a creature you can see within 10 feet of you gains 1d10 Temporary Hit Points.\n\n**Taunting Step.** Creatures within 5 feet of the space you left must succeed on a Wisdom saving throw against your spell save DC or have Disadvantage on attack rolls against anyone but you until the start of your next turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/steps-of-the-fey", "it"), Language = LanguageCode.It, Name = "Movimenti del Folletto", Description = "Il patrono concede al warlock la capacità di muoversi lungo i confini tra i piani. Può lanciare *passo velato* senza spendere uno slot incantesimo un numero di volte pari al suo modificatore di Carisma (almeno una) e recupera tutti gli utilizzi dopo un riposo lungo.\n\nInoltre, ogni volta che lancia quell'incantesimo, può scegliere uno degli effetti aggiuntivi seguenti.\n\n**Movimento rinvigorente.** Subito dopo il teletrasporto, il warlock o una creatura che è in grado di vedere entro 3 metri da lui ottiene 1d10 punti ferita temporanei.\n\n**Movimento provocatorio.** Le creature entro 1,5 metri dallo spazio che il warlock ha lasciato devono superare un tiro salvezza su Saggezza contro la CD del tiro salvezza dei suoi incantesimi, altrimenti subiscono svantaggio ai tiri per colpire contro creature diverse da lui fino all'inizio del suo turno successivo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/misty-escape"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/misty-escape", "en"), Language = LanguageCode.En, Name = "Misty Escape", Description = "Pain sends you slipping through the mists: whenever you take damage, your Reaction can be spent casting *Misty Step*.\n\nTwo new options are added to Steps of the Fey.\n\n**Disappearing Step.** You turn Invisible, and stay so until your next turn begins or until you attack, deal damage, or cast a spell, whichever comes first.\n\n**Dreadful Step.** Pick either the spot you vacated or the spot where you arrive; each creature within 5 feet of it makes a Wisdom save against your spell save DC, taking 2d10 Psychic damage on a failure." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/misty-escape", "it"), Language = LanguageCode.It, Name = "Fuga Nebbiosa", Description = "Il warlock può lanciare *passo velato* come reazione quando subisce danni.\n\nInoltre, gli effetti seguenti si aggiungono alle opzioni di Movimenti del folletto.\n\n**Movimento evanescente.** Il warlock è invisibile fino all'inizio del suo turno successivo, o finché non effettua un tiro per colpire, infligge danni o lancia un incantesimo.\n\n**Movimento terribile.** Le creature entro 1,5 metri dallo spazio che il warlock ha lasciato o da quello in cui compare (a sua scelta) devono superare un tiro salvezza su Saggezza contro la CD del tiro salvezza dei suoi incantesimi, altrimenti subiscono 2d10 danni psichici." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/beguiling-defenses"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/beguiling-defenses", "en"), Language = LanguageCode.En, Name = "Beguiling Defenses", Description = "Your patron has taught you to guard body and mind: you are immune to the Charmed condition.\n\nAlso, right after a creature you can see hits you with an attack roll, you can use your Reaction to halve the damage you take (round down) and force the attacker to make a Wisdom saving throw against your spell save DC; on a failure, it takes Psychic damage equal to the damage you took. After using this Reaction, you need a Long Rest to use it again, unless you spend a Pact Magic spell slot (no action required) to restore it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/beguiling-defenses", "it"), Language = LanguageCode.It, Name = "Difese Seducenti", Description = "Il patrono insegna al warlock come proteggere la mente e il corpo: è immune alla condizione di affascinato.\n\nInoltre, subito dopo che una creatura che è in grado di vedere lo colpisce con un tiro per colpire, il warlock può usare una reazione per dimezzare i danni che subisce (arrotondati per difetto) e costringere l'attaccante a un tiro salvezza su Saggezza contro la CD del tiro salvezza dei suoi incantesimi: se lo fallisce, l'attaccante subisce danni psichici pari a quelli subiti dal warlock. Dopo aver usato questa reazione, non può farlo di nuovo finché non completa un riposo lungo, a meno che non spenda uno slot incantesimo della Magia del patto (nessuna azione richiesta) per ripristinarla." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/bewitching-magic"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/bewitching-magic", "en"), Language = LanguageCode.En, Name = "Bewitching Magic", Description = "Fey trickery and travel become one for you. Whenever you spend an action and a spell slot on an Enchantment or Illusion spell, that same action also lets you cast *Misty Step* for free, with no slot required, immediately afterward." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "archfey-patron/bewitching-magic", "it"), Language = LanguageCode.It, Name = "Magia Ammaliante", Description = "Il patrono concede al warlock la capacità di intrecciare la sua magia con il teletrasporto. Subito dopo aver lanciato un incantesimo di ammaliamento o di illusione usando un'azione e uno slot incantesimo, può lanciare *passo velato* come parte della stessa azione e senza spendere uno slot incantesimo." }
					}
				}
			}
		};
	}
}
