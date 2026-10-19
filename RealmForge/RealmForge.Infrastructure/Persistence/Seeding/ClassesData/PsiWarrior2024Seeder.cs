using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Psi Warrior (fighter, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class PsiWarrior2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "psi-warrior");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Fighter2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "psi-warrior", "en"), Language = LanguageCode.En, Name = "Psi Warrior", Description = "Psi Warriors awaken the strength of their minds to amplify the strength of their bodies. They channel that psionic energy into their weapon blows, lash out with telekinetic force and raise barriers of pure thought." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "psi-warrior", "it"), Language = LanguageCode.It, Name = "Guerriero Psionico", Description = "I guerrieri psionici risvegliano la forza della mente per amplificare quella del corpo. Incanalano questa energia psionica nei loro colpi, sferzano i nemici con la forza telecinetica ed erigono barriere di puro pensiero." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/psionic-power"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/psionic-power", "en"), Language = LanguageCode.En, Name = "Psionic Power", Description = "A wellspring of psionic energy rises within you, represented by your Psionic Energy Dice, which fuel this subclass's powers. The table below shows the size and number of dice you have at certain Fighter levels.\n\n| Fighter Level | Die Size | Number |\n|---|---|---|\n| 3 | d6 | 4 |\n| 5 | d8 | 6 |\n| 9 | d8 | 8 |\n| 11 | d10 | 8 |\n| 13 | d10 | 10 |\n| 17 | d12 | 12 |\n\nFeatures of this subclass that call for a Psionic Energy Die use only this subclass's dice. Some powers spend the die, as their text says, and you can't use a power that needs a die once all your dice are spent. You regain one spent die after a Short Rest and all of them after a Long Rest.\n\n**Protective Field.** When you or another creature you can see within 30 feet of you takes damage, you can use your Reaction and spend a Psionic Energy Die: roll it and reduce the damage by the result plus your Intelligence modifier (at least 1), as a brief shield of telekinetic force flickers into being.\n\n**Psionic Strike.** Once on each of your turns, right after you hit and damage a target within 30 feet of you with a weapon attack, you can spend a Psionic Energy Die and roll it; the target takes Force damage equal to the result plus your Intelligence modifier.\n\n**Telekinetic Movement.** As a Magic action, pick a target you can see within 30 feet of you: a loose object of Large size or smaller, or a willing creature other than yourself. You carry it up to 30 feet to an unoccupied space you can see; a Tiny object can instead be moved to or from your hand. After using this action, you need a Short or Long Rest to use it again, unless you spend a Psionic Energy Die (no action required) to restore it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/psionic-power", "it"), Language = LanguageCode.It, Name = "Potere Psionico", Description = "Dentro il guerriero sgorga una fonte di energia psionica, rappresentata dai suoi dadi di energia psionica, che alimentano i poteri di questa sottoclasse. La tabella seguente indica il tipo e il numero di dadi posseduti a determinati livelli da guerriero.\n\n| Livello da guerriero | Tipo di dado | Numero |\n|---|---|---|\n| 3 | d6 | 4 |\n| 5 | d8 | 6 |\n| 9 | d8 | 8 |\n| 11 | d10 | 8 |\n| 13 | d10 | 10 |\n| 17 | d12 | 12 |\n\nI privilegi di questa sottoclasse che usano un dado di energia psionica usano soltanto i dadi di questa sottoclasse. Alcuni poteri spendono il dado, come indicato nella loro descrizione, e il guerriero non può usare un potere che richiede un dado se li ha spesi tutti. Recupera un dado speso dopo un riposo breve e tutti i dadi dopo un riposo lungo.\n\n**Campo protettivo.** Quando il guerriero o un'altra creatura che è in grado di vedere entro 9 metri da lui subisce danni, il guerriero può usare una reazione e spendere un dado di energia psionica: lo tira e riduce i danni del risultato + il suo modificatore di Intelligenza (riduzione minima 1), creando per un istante uno scudo di forza telecinetica.\n\n**Colpo psionico.** Una volta in ognuno dei suoi turni, subito dopo aver colpito con un attacco e danneggiato con un'arma un bersaglio entro 9 metri da lui, il guerriero può spendere un dado di energia psionica e tirarlo: il bersaglio subisce danni da forza pari al risultato + il modificatore di Intelligenza del guerriero.\n\n**Movimento telecinetico.** Con un'azione di Magia, il guerriero sceglie un bersaglio che è in grado di vedere entro 9 metri da lui: un oggetto non fissato di taglia Grande o inferiore oppure una creatura consenziente diversa da lui. Lo trasporta fino a 9 metri in uno spazio libero che è in grado di vedere; se il bersaglio è un oggetto Minuscolo, può invece portarlo nella propria mano o allontanarlo da essa. Dopo aver usato questa azione, non può farlo di nuovo finché non completa un riposo breve o lungo, a meno che non spenda un dado di energia psionica (nessuna azione richiesta) per ripristinarla." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/telekinetic-adept"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/telekinetic-adept", "en"), Language = LanguageCode.En, Name = "Telekinetic Adept", Description = "You master new ways to wield your telekinesis.\n\n**Psi-Powered Leap.** As a Bonus Action, you gain a Fly Speed equal to twice your Speed until the end of the turn. After using this Bonus Action, you need a Short or Long Rest to use it again, unless you spend a Psionic Energy Die (no action required) to restore it.\n\n**Telekinetic Thrust.** When your Psionic Strike damages a target, you can force it to make a Strength saving throw (DC 8 plus your Intelligence modifier and Proficiency Bonus). On a failure, you either knock it Prone or carry it up to 10 feet horizontally." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/telekinetic-adept", "it"), Language = LanguageCode.It, Name = "Adepto Telecinetico", Description = "Il guerriero padroneggia nuovi modi di usare le sue capacità telecinetiche.\n\n**Balzo psionico.** Come azione bonus, il guerriero ottiene una velocità di volare pari al doppio della sua velocità fino alla fine del turno. Dopo aver usato questa azione bonus, non può farlo di nuovo finché non completa un riposo breve o lungo, a meno che non spenda un dado di energia psionica (nessuna azione richiesta) per ripristinarla.\n\n**Spinta telecinetica.** Quando danneggia un bersaglio con Colpo psionico, il guerriero può costringerlo a effettuare un tiro salvezza su Forza (CD 8 + il suo modificatore di Intelligenza + il suo bonus di competenza). Se lo fallisce, il guerriero può fargli subire la condizione di prono oppure trasportarlo fino a 3 metri in orizzontale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/guarded-mind"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/guarded-mind", "en"), Language = LanguageCode.En, Name = "Guarded Mind", Description = "You resist Psychic damage. Also, if you begin your turn Charmed or Frightened, you can spend a Psionic Energy Die (no action required) to end every effect on you that causes those conditions." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/guarded-mind", "it"), Language = LanguageCode.It, Name = "Scudo Mentale", Description = "La mente del guerriero è temprata: i danni psichici lo colpiscono con resistenza. Se all'inizio del suo turno è affascinato o spaventato, gli basta spendere un dado di energia psionica (senza bisogno di azioni) per liberarsi di tutti gli effetti che gli causano quelle condizioni." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/bulwark-of-force"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/bulwark-of-force", "en"), Language = LanguageCode.En, Name = "Bulwark of Force", Description = "You can screen yourself and others with telekinetic force. As a Bonus Action, choose a number of creatures within 30 feet of you, yourself included, up to your Intelligence modifier (at least one): each has Half Cover for 1 minute or until you become Incapacitated.\n\nAfter using this feature, you need a Long Rest to use it again, unless you spend a Psionic Energy Die (no action required) to restore it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/bulwark-of-force", "it"), Language = LanguageCode.It, Name = "Baluardo della Forza", Description = "Il guerriero può proteggere se stesso e gli altri con la forza telecinetica. Come azione bonus, sceglie un numero di creature entro 9 metri da lui, incluso se stesso, fino al suo modificatore di Intelligenza (minimo una): ognuna beneficia di mezza copertura per 1 minuto o finché il guerriero non subisce la condizione di incapacitato.\n\nDopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo, a meno che non spenda un dado di energia psionica (nessuna azione richiesta) per ripristinarlo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/telekinetic-master"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/telekinetic-master", "en"), Language = LanguageCode.En, Name = "Telekinetic Master", Description = "*Telekinesis* is always prepared for you. Through this feature you can cast it with no spell slot or components, using Intelligence as your spellcasting ability. On each of your turns while you keep Concentration on it, including the turn you cast it, you can make one weapon attack as a Bonus Action.\n\nAfter casting the spell this way, you need a Long Rest to do so again, unless you spend a Psionic Energy Die (no action required) to restore the use." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "psi-warrior/telekinetic-master", "it"), Language = LanguageCode.It, Name = "Maestro della Telecinesi", Description = "Il guerriero ha sempre preparato l'incantesimo *telecinesi*. Con questo privilegio può lanciarlo senza slot incantesimo né componenti, usando l'Intelligenza come caratteristica da incantatore. In ognuno dei suoi turni in cui mantiene la concentrazione su di esso, compreso quello in cui lo lancia, può effettuare un attacco con un'arma come azione bonus.\n\nDopo aver lanciato l'incantesimo con questo privilegio, non può farlo di nuovo in questo modo finché non completa un riposo lungo, a meno che non spenda un dado di energia psionica (nessuna azione richiesta) per ripristinarne l'utilizzo." }
					}
				}
			}
		};
	}
}
