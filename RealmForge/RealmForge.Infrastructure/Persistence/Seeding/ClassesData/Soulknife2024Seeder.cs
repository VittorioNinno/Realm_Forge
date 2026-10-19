using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Soulknife (rogue, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class Soulknife2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "soulknife");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Rogue2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "soulknife", "en"), Language = LanguageCode.En, Name = "Soulknife", Description = "A Soulknife strikes with the mind, slicing through walls both physical and mental. These Rogues find psionic power inside themselves and turn it to their roguish craft. Perhaps the gift troubled you since childhood and only revealed its full strength under the strain of adventure, or perhaps you sought out an order of psychic adepts and spent years learning to call it forth." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "soulknife", "it"), Language = LanguageCode.It, Name = "Lama Spirituale", Description = "La lama spirituale colpisce con la mente, tagliando barriere fisiche e mentali. Questi ladri scoprono dentro di sé un potere psionico e lo mettono al servizio del loro mestiere. Forse il dono li ha tormentati fin dall'infanzia e ha rivelato tutta la sua forza solo sotto la tensione dell'avventura, oppure hanno cercato un ordine di adepti psichici e hanno trascorso anni a imparare a evocarlo." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/psionic-power"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/psionic-power", "en"), Language = LanguageCode.En, Name = "Psionic Power", Description = "A wellspring of psionic energy rises within you, represented by your Psionic Energy Dice, which fuel some of this subclass's powers. The table below shows the size and number of dice you have at certain Rogue levels.\n\n| Rogue Level | Die Size | Number |\n|---|---|---|\n| 3 | d6 | 4 |\n| 5 | d8 | 6 |\n| 9 | d8 | 8 |\n| 11 | d10 | 8 |\n| 13 | d10 | 10 |\n| 17 | d12 | 12 |\n\nFeatures of this subclass that call for a Psionic Energy Die use only this subclass's dice. Some powers spend the die, as their text says, and you can't use a power that needs a die once all your dice are spent. You regain one spent die after a Short Rest and all of them after a Long Rest.\n\n**Psi-Bolstered Knack.** If you fail an ability check using a skill or tool you're proficient with, you can roll a Psionic Energy Die and add it to the check, which might turn the failure into a success. The die is spent only if the check then succeeds.\n\n**Psychic Whispers.** You can open telepathic links with others. As a Magic action, pick one or more creatures you can see, up to a number equal to your Proficiency Bonus, and roll a Psionic Energy Die: for that many hours, you and the chosen creatures can speak to each other telepathically. Sending or receiving a message (no action required) works only while you are within 1 mile of each other, and any participant can break the link at any time (no action required). The first time you use this power after each Long Rest, the die isn't spent; every other time, it is." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/psionic-power", "it"), Language = LanguageCode.It, Name = "Potere Psionico", Description = "Dentro il ladro sgorga una fonte di energia psionica, rappresentata dai suoi dadi di energia psionica, che alimentano alcuni poteri di questa sottoclasse. La tabella seguente indica il tipo e il numero di dadi posseduti a determinati livelli da ladro.\n\n| Livello da ladro | Tipo di dado | Numero |\n|---|---|---|\n| 3 | d6 | 4 |\n| 5 | d8 | 6 |\n| 9 | d8 | 8 |\n| 11 | d10 | 8 |\n| 13 | d10 | 10 |\n| 17 | d12 | 12 |\n\nI privilegi di questa sottoclasse che usano un dado di energia psionica usano soltanto i dadi di questa sottoclasse. Alcuni poteri spendono il dado, come indicato nella loro descrizione, e il ladro non può usare un potere che richiede un dado se li ha spesi tutti. Recupera un dado speso dopo un riposo breve e tutti i dadi dopo un riposo lungo.\n\n**Abilità psicorinforzata.** Se fallisce una prova di caratteristica con un'abilità o uno strumento in cui ha competenza, il ladro può tirare un dado di energia psionica e sommarne il risultato alla prova, con la possibilità di trasformare il fallimento in un successo. Il dado viene speso solo se la prova riesce.\n\n**Sussurri psichici.** Il ladro può stabilire una comunicazione telepatica con altre creature. Con un'azione di Magia, sceglie una o più creature che è in grado di vedere, fino a un numero pari al suo bonus di competenza, e tira un dado di energia psionica: per un numero di ore pari al risultato, le creature scelte e il ladro possono parlarsi telepaticamente. Per inviare o ricevere un messaggio (nessuna azione richiesta), il ladro e l'altra creatura devono trovarsi entro 1,5 chilometri l'uno dall'altra. Una creatura può interrompere il collegamento telepatico in qualsiasi momento (nessuna azione richiesta). La prima volta che usa questo potere dopo ogni riposo lungo, il ladro non spende il dado; tutte le altre volte lo spende." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/psychic-blades"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/psychic-blades", "en"), Language = LanguageCode.En, Name = "Psychic Blades", Description = "You can call forth shimmering blades of psychic energy. Whenever you take the Attack action or make an Opportunity Attack, you can form a Psychic Blade in your free hand and attack with it. The magic blade has these traits.\n\n- **Weapon Category:** Simple Melee.\n- **Damage:** 1d6 Psychic, plus whichever ability modifier you used to attack.\n- **Properties:** Finesse and Thrown, with a 60/120-foot range.\n- **Mastery:** Vex, which you can always use with this blade; it doesn't take up one of your Weapon Mastery choices.\n\nThe blade vanishes the moment it hits or misses, and it leaves no wound behind if it deals damage.\n\nOnce you have attacked with the blade on your turn, a Bonus Action that same turn lets you form a second blade in your other hand, if it is empty, and attack with it in melee or at range; this extra blade deals 1d4 rather than 1d6." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/psychic-blades", "it"), Language = LanguageCode.It, Name = "Lame Psichiche", Description = "Il ladro può manifestare lame scintillanti di energia psichica. Ogni volta che effettua l'azione di Attacco o un attacco di opportunità, può far comparire una Lama psichica nella mano libera ed effettuare l'attacco con essa. La lama magica ha le caratteristiche seguenti.\n\n- **Categoria dell'arma:** da mischia semplice.\n- **Danni a segno:** 1d6 danni psichici + il modificatore di caratteristica usato per il tiro per colpire.\n- **Proprietà:** accurata, da lancio (gittata 18/36 metri).\n- **Padronanza:** Vessazione (il ladro può usare questa proprietà, che non conta nel numero di proprietà utilizzabili con Padronanza nelle armi).\n\nLa lama svanisce subito dopo aver colpito o mancato il bersaglio e, se infligge danni, non lascia alcun segno.\n\nDopo aver attaccato con la lama nel suo turno, il ladro può effettuare come azione bonus nello stesso turno un attacco in mischia o a distanza con una seconda lama psichica, se ha l'altra mano libera per crearla. Il dado dei danni di questo attacco bonus è 1d4 anziché 1d6." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/soul-blades"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 9,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/soul-blades", "en"), Language = LanguageCode.En, Name = "Soul Blades", Description = "You can now use these powers with your Psychic Blades.\n\n**Homing Strikes.** If your Psychic Blade attack roll misses, you can roll a Psionic Energy Die and add it to the attack roll; if that makes the attack hit, the die is spent.\n\n**Psychic Teleportation.** As a Bonus Action, you form a Psychic Blade, spend and roll a Psionic Energy Die, and hurl the blade at an unoccupied space you can see up to 10 feet away per point rolled. You then teleport to that space, and the blade disappears." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/soul-blades", "it"), Language = LanguageCode.It, Name = "Lame dell'Anima", Description = "Il ladro può ora usare i poteri seguenti con le sue Lame psichiche.\n\n**Colpi guidati.** Se effettua un tiro per colpire con una Lama psichica e manca il bersaglio, il ladro può tirare un dado di energia psionica e sommarne il risultato al tiro per colpire; se così l'attacco va a segno, il dado viene speso.\n\n**Teletrasporto psichico.** Come azione bonus, il ladro manifesta una Lama psichica, spende un dado di energia psionica e lo tira, e scaglia la lama verso uno spazio libero che è in grado di vedere a una distanza massima pari a 3 metri per il risultato. Poi si teletrasporta in quello spazio e la lama svanisce." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/psychic-veil"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 13,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/psychic-veil", "en"), Language = LanguageCode.En, Name = "Psychic Veil", Description = "You can wrap yourself in a veil of psychic static. As a Magic action, you become Invisible for 1 hour or until you end the effect (no action required). The invisibility ends early right after you damage a creature or force one to make a saving throw.\n\nAfter using this feature, you need a Long Rest to use it again, unless you spend a Psionic Energy Die (no action required) to restore it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/psychic-veil", "it"), Language = LanguageCode.It, Name = "Velo Psichico", Description = "Il ladro può tessere un velo di disturbo psichico per celarsi. Con un'azione di Magia, ottiene la condizione di invisibile per 1 ora o finché non pone fine all'effetto (nessuna azione richiesta). L'invisibilità termina prima, subito dopo che il ladro ha inflitto danni a una creatura o l'ha costretta a effettuare un tiro salvezza.\n\nDopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo, a meno che non spenda un dado di energia psionica (nessuna azione richiesta) per ripristinarlo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/rend-mind"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/rend-mind", "en"), Language = LanguageCode.En, Name = "Rend Mind", Description = "You can sweep your Psychic Blades through a creature's mind. When your Psychic Blades deal Sneak Attack damage to a creature, you can force it to make a Wisdom saving throw (DC 8 plus your Dexterity modifier and Proficiency Bonus). On a failure, it is Stunned for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success.\n\nAfter using this feature, you need a Long Rest to use it again, unless you spend three Psionic Energy Dice (no action required) to restore it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "soulknife/rend-mind", "it"), Language = LanguageCode.It, Name = "Squarciare la Mente", Description = "Il ladro può far passare le sue Lame psichiche attraverso la mente di una creatura. Quando usa le Lame psichiche per infliggere danni da Attacco furtivo a una creatura, può costringerla a effettuare un tiro salvezza su Saggezza (CD 8 + il suo modificatore di Destrezza + il suo bonus di competenza). Se lo fallisce, il bersaglio subisce la condizione di stordito per 1 minuto; ripete il tiro salvezza alla fine di ognuno dei suoi turni e, se lo supera, l'effetto su di lui termina.\n\nDopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo, a meno che non spenda tre dadi di energia psionica (nessuna azione richiesta) per ripristinarlo." }
					}
				}
			}
		};
	}
}
