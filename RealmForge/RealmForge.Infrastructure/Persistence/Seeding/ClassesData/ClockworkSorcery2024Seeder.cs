using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Clockwork Sorcery (sorcerer, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class ClockworkSorcery2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "clockwork-sorcery");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Sorcerer2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "clockwork-sorcery", "en"), Language = LanguageCode.En, Name = "Clockwork Sorcery", Description = "The cosmic principle of order has filled you with magic. That power flows from Mechanus, or a realm like it, a plane built entirely on the precision of clockwork. You or one of your forebears may have been caught up in the schemes of the modrons, the orderly inhabitants of Mechanus, or even marched in the Great Modron March. Whatever its source, the power of order may seem alien to others, but to you it is part of a vast and glorious design." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "clockwork-sorcery", "it"), Language = LanguageCode.It, Name = "Stregoneria Meccanica", Description = "Il principio cosmico dell'ordine ha colmato lo stregone di magia. Quel potere scaturisce da Mechanus, o da un reame simile, un piano interamente costruito sulla precisione di un meccanismo a orologeria. Lo stregone o uno dei suoi antenati potrebbe essere rimasto invischiato nelle trame dei modron, gli ordinati abitanti di Mechanus, o aver persino preso parte alla Grande Marcia dei Modron. Qualunque sia la sua fonte, il potere dell'ordine può sembrare estraneo agli altri, ma per lo stregone fa parte di un disegno vasto e glorioso." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/clockwork-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/clockwork-spells", "en"), Language = LanguageCode.En, Name = "Clockwork Spells", Description = "From the Sorcerer level shown in the table below onward, the listed spells are always prepared for you.\n\n| Sorcerer Level | Spells |\n|---|---|\n| 3 | *Aid*, *Alarm*, *Lesser Restoration*, *Protection from Evil and Good* |\n| 5 | *Dispel Magic*, *Protection from Energy* |\n| 7 | *Freedom of Movement*, *Summon Construct* |\n| 9 | *Greater Restoration*, *Wall of Force* |\n\nIn addition, pick or roll on the table below to decide how your bond with order shows itself while you cast your Sorcerer spells.\n\n| 1d6 | Manifestation of Order |\n|---|---|\n| 1 | Ghostly cogwheels hover behind you. |\n| 2 | Clock hands turn within your eyes. |\n| 3 | Your skin takes on a brassy shine. |\n| 4 | Drifting equations and geometric shapes overlay your body. |\n| 5 | Your Spellcasting Focus briefly becomes a tiny clockwork device. |\n| 6 | You and those touched by your magic hear ticking gears or a chiming clock. |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/clockwork-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi Meccanici", Description = "Dal livello da stregone indicato nella tabella seguente, lo stregone ha sempre preparati gli incantesimi elencati.\n\n| Livello da stregone | Incantesimi |\n|---|---|\n| 3 | *aiuto*, *allarme*, *protezione dal bene e dal male*, *ristorare inferiore* |\n| 5 | *dissolvi magie*, *protezione dall'energia* |\n| 7 | *libertà di movimento*, *richiama costrutto* |\n| 9 | *muro di forza*, *ristorare superiore* |\n\nInoltre, lo stregone sceglie o determina casualmente con la tabella seguente il modo in cui il suo legame con l'ordine si manifesta mentre lancia i suoi incantesimi da stregone.\n\n| 1d6 | Manifestazione dell'ordine |\n|---|---|\n| 1 | Ingranaggi spettrali fluttuano alle spalle dello stregone. |\n| 2 | Lancette d'orologio ruotano nei suoi occhi. |\n| 3 | La sua pelle risplende di un riflesso d'ottone. |\n| 4 | Equazioni e solidi geometrici fluttuanti si sovrappongono al suo corpo. |\n| 5 | Il suo focus da incantatore assume per un istante la forma di un minuscolo meccanismo a orologeria. |\n| 6 | Lui e chi è colpito dalla sua magia sentono il ticchettio di ingranaggi o i rintocchi di un orologio. |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/restore-balance"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/restore-balance", "en"), Language = LanguageCode.En, Name = "Restore Balance", Description = "Your bond with the plane of perfect order lets you even out moments of chaos. When a creature you can see within 60 feet of you is about to roll a d20 with Advantage or Disadvantage, you can use your Reaction to strip both Advantage and Disadvantage from that roll.\n\nYou can use this feature a number of times equal to your Charisma modifier (at least once), regaining every use after a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/restore-balance", "it"), Language = LanguageCode.It, Name = "Ripristino dell'Equilibrio", Description = "Il legame con il piano dell'ordine assoluto permette allo stregone di riequilibrare gli attimi di caos. Quando una creatura che è in grado di vedere entro 18 metri da lui sta per tirare un d20 con vantaggio o svantaggio, lo stregone può usare una reazione per far sì che quel tiro non sia influenzato né dal vantaggio né dallo svantaggio.\n\nLo stregone può usare questo privilegio un numero di volte pari al suo modificatore di Carisma (almeno una) e recupera tutti gli utilizzi dopo un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/bastion-of-law"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/bastion-of-law", "en"), Language = LanguageCode.En, Name = "Bastion of Law", Description = "You can draw on the great equation of existence to wrap a creature in a shimmering shield of order. As a Magic action, you spend 1 to 5 Sorcery Points to raise a magical ward around yourself or another creature you can see within 30 feet of you. The ward holds a number of d8s equal to the points spent; when the warded creature takes damage, it can spend some of those dice, roll them, and subtract the total from the damage.\n\nThe ward lasts until you finish a Long Rest or use this feature again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/bastion-of-law", "it"), Language = LanguageCode.It, Name = "Bastione della Legge", Description = "Lo stregone può attingere alla grande equazione dell'esistenza per avvolgere una creatura in uno scudo scintillante di ordine. Con un'azione di Magia, spende da 1 a 5 punti stregoneria per creare una protezione magica attorno a sé o a un'altra creatura che è in grado di vedere entro 9 metri da lui. La protezione è rappresentata da un numero di d8 pari ai punti stregoneria spesi; quando subisce danni, la creatura protetta può spendere alcuni di quei dadi, tirarli e ridurre i danni subiti del totale ottenuto.\n\nLa protezione dura finché lo stregone non completa un riposo lungo o non usa di nuovo questo privilegio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/trance-of-order"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/trance-of-order", "en"), Language = LanguageCode.En, Name = "Trance of Order", Description = "You learn to tune your mind to the endless reckonings of Mechanus. As a Bonus Action, you can enter this state for 1 minute. For that time, attack rolls against you can't gain Advantage, and whenever you make a D20 Test, any d20 roll of 9 or lower counts as a 10.\n\nAfter using this feature, you need a Long Rest to use it again, unless you spend 5 Sorcery Points (no action required) to restore it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/trance-of-order", "it"), Language = LanguageCode.It, Name = "Trance dell'Ordine", Description = "Lo stregone impara ad allineare la propria coscienza agli infiniti calcoli di Mechanus. Come azione bonus, può entrare in questo stato per 1 minuto. Per la durata, i tiri per colpire contro di lui non possono beneficiare del vantaggio e, ogni volta che effettua una prova del d20, può considerare come un 10 qualsiasi risultato di 9 o meno sul d20.\n\nDopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo, a meno che non spenda 5 punti stregoneria (nessuna azione richiesta) per ripristinarlo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/clockwork-cavalcade"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/clockwork-cavalcade", "en"), Language = LanguageCode.En, Name = "Clockwork Cavalcade", Description = "You briefly call up spirits of order that sweep away disorder around you. As a Magic action, you summon them in a 30-foot Cube that starts from you; they resemble modrons or other Constructs of your choice, are intangible and invulnerable, and produce the effects below in the Cube before vanishing. After using this action, you need a Long Rest to use it again, unless you spend 7 Sorcery Points (no action required) to restore it.\n\n**Heal.** The spirits restore up to 100 Hit Points, split as you like among any number of creatures of your choice in the Cube.\n\n**Repair.** Damaged objects wholly inside the Cube are mended at once.\n\n**Dispel.** Every spell of level 6 or lower ends on creatures and objects of your choice in the Cube." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "clockwork-sorcery/clockwork-cavalcade", "it"), Language = LanguageCode.It, Name = "Cavalleria Meccanica", Description = "Lo stregone evoca per un istante spiriti dell'ordine che cancellano il disordine attorno a lui. Con un'azione di Magia, li evoca in un cubo di 9 metri di spigolo che parte da lui; gli spiriti somigliano a modron o ad altri costrutti a sua scelta, sono intangibili e invulnerabili e, prima di svanire, producono nel cubo gli effetti seguenti. Dopo aver usato questa azione, lo stregone non può farlo di nuovo finché non completa un riposo lungo, a meno che non spenda 7 punti stregoneria (nessuna azione richiesta) per ripristinarla.\n\n**Guarigione.** Gli spiriti ripristinano fino a 100 punti ferita, ripartiti come lo stregone preferisce tra un qualsiasi numero di creature a sua scelta nel cubo.\n\n**Riparazione.** Gli oggetti danneggiati che si trovano interamente nel cubo vengono riparati all'istante.\n\n**Dissoluzione.** Ogni incantesimo di 6° livello o inferiore termina sulle creature e sugli oggetti a scelta dello stregone nel cubo." }
					}
				}
			}
		};
	}
}
