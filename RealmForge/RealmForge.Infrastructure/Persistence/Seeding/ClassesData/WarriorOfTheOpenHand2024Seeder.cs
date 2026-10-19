using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Warrior of the Open Hand (monk, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WarriorOfTheOpenHand2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-the-open-hand");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Monk2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-the-open-hand", "en"), Language = LanguageCode.En, Name = "Warrior of the Open Hand", Description = "Warriors of the Open Hand are masters of unarmed combat. They learn techniques to push and trip their opponents and manipulate their own energy to protect themselves from harm." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-the-open-hand", "it"), Language = LanguageCode.It, Name = "Guerriero della Mano Aperta", Description = "I guerrieri della mano aperta sono maestri del combattimento senz'armi. Imparano tecniche per spingere e sbilanciare gli avversari e manipolano la propria energia per proteggersi dai danni." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/open-hand-technique"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/open-hand-technique", "en"), Language = LanguageCode.En, Name = "Open Hand Technique", Description = "Whenever you hit a creature with an attack granted by your Flurry of Blows, you can impose one of the following effects on that target.\n\n**Addle.** The target can’t make Opportunity Attacks until the start of its next turn.\n\n**Push.** The target must succeed on a Strength saving throw or be pushed up to 15 feet away from you.\n\n**Topple.** The target must succeed on a Dexterity saving throw or have the Prone condition." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/open-hand-technique", "it"), Language = LanguageCode.It, Name = "Tecnica della Mano Aperta", Description = "Ogni volta che colpisce una creatura con un attacco conferito da Raffica di colpi, il monaco può imporre al bersaglio uno degli effetti seguenti.\n\n**Disorientamento.** Il bersaglio non può effettuare attacchi di opportunità fino all'inizio del suo turno successivo.\n\n**Spinta.** Il bersaglio deve superare un tiro salvezza su Forza, altrimenti viene spinto fino a 4,5 metri lontano dal monaco.\n\n**Rovesciamento.** Il bersaglio deve superare un tiro salvezza su Destrezza, altrimenti subisce la condizione di prono." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/wholeness-of-body"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/wholeness-of-body", "en"), Language = LanguageCode.En, Name = "Wholeness of Body", Description = "You gain the ability to heal yourself. As a Bonus Action, you can roll your Martial Arts die. You regain a number of Hit Points equal to the number rolled plus your Wisdom modifier (minimum of 1 Hit Point regained). You can use this feature a number of times equal to your Wisdom modifier (minimum of once), and you regain all expended uses when you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/wholeness-of-body", "it"), Language = LanguageCode.It, Name = "Integrità del Corpo", Description = "Il monaco impara a sanare il proprio corpo. Spendendo un'azione bonus tira il dado di Arti marziali: recupera tanti punti ferita quanto il risultato più il modificatore di Saggezza, e comunque almeno 1. Gli utilizzi a disposizione sono pari al modificatore di Saggezza (almeno uno) e tornano tutti dopo un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/fleet-step"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/fleet-step", "en"), Language = LanguageCode.En, Name = "Fleet Step", Description = "When you take a Bonus Action other than Step of the Wind, you can also use Step of the Wind immediately after that Bonus Action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/fleet-step", "it"), Language = LanguageCode.It, Name = "Passo Lesto", Description = "Quando effettua un'azione bonus diversa da Passo del vento, il monaco può usare Passo del vento subito dopo quell'azione bonus." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/quivering-palm"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/quivering-palm", "en"), Language = LanguageCode.En, Name = "Quivering Palm", Description = "You gain the ability to set up lethal vibrations in someone’s body. When you hit a creature with an Unarmed Strike, you can expend 4 Focus Points to start these imperceptible vibrations, which last for a number of days equal to your Monk level. The vibrations are harmless unless you take an action to end them.\n\nAlternatively, when you take the Attack action on your turn, you can forgo one of the attacks to end the vibrations. To end them, you and the target must be on the same plane of existence. When you end them, the target must make a Constitution saving throw, taking 10d12 Force damage on a failed save or half as much damage on a successful one.\n\nYou can have only one creature under the effect of this feature at a time. You can end the vibrations harmlessly (no action required).\n\nCharacter class provides a character’s most exciting capabilities. This chapter offers twelve classes, each of which contains four subclasses—all summarized below.\n\n**Barbarian.** Storm with Rage, and wade into hand-to-hand combat.\n\nThen follow the Path of the...\n\nBerserker to unleash raw violence.\n\nWild Heart to manifest kinship with animals.\n\nWorld Tree to tap into cosmic vitality.\n\nZealot to rage in union with a god.\n\n**Bard.** Perform spells that inspire and heal allies or beguile foes.\n\nThen join the College of...\n\nDance to harness agility in battle.\n\nGlamour to weave beguiling Feywild magic.\n\nLore to collect knowledge and magical secrets.\n\nValor to wield weapons with spells.\n\n**Cleric.** Invoke divine magic to heal, bolster, and smite. Then harness the...\n\nLife Domain to be a master of healing.\n\nLight Domain to wield searing, warding light.\n\nTrickery Domain to bedevil foes with mischief.\n\nWar Domain to inspire valor and chastise foes.\n\n**Druid.** Channel nature magic to heal, shape-shift, and control the elements. Then join the Circle of the...\n\nLand to draw on the magic of the environment.\n\nMoon to adopt powerful animal forms.\n\nSea to channel tides and storms.\n\nStars to gain powers in a starry form.\n\n**Fighter.** Master all weapons and armor. Then embody the...\n\nBattle Master to use special combat maneuvers.\n\nChampion to strive for peak combat prowess.\n\nEldritch Knight to learn spells to aid in combat.\n\nPsi Warrior to augment attacks with psionic power.\n\n**Monk.** Dart in and out of melee while striking fast and hard. Then become a Warrior of...\n\nMercy to heal or harm with a touch.\n\nShadow to employ shadows for subterfuge.\n\nThe Elements to wield elemental power.\n\nThe Open Hand to master unarmed combat.\n\n**Paladin.** Smite foes and shield allies with divine and martial might.\n\nThen swear the Oath of...\n\nDevotion to emulate the angels of justice.\n\nGlory to reach the heights of heroism.\n\nThe Ancients to preserve life, joy, and nature.\n\nVengeance to hunt down evildoers.\n\n**Ranger.** Weave together martial prowess, nature magic, and survival skills. Then embody the...\n\nBeast Master to bond with a primal beast.\n\nFey Wanderer to manifest fey mirth and fury.\n\nGloom Stalker to hunt foes that lurk in darkness.\n\nHunter to protect nature with martial versatility.\n\n**Rogue.** Launch deadly Sneak Attacks while avoiding harm through stealth. Then embody the...\n\nArcane Trickster to enhance stealth with spells.\n\nAssassin to deliver ambushes and poison.\n\nSoulknife to strike foes with psi blades.\n\nThief to master infiltration and treasure hunting.\n\n**Sorcerer.** Wield magic innate to your being, shaping the power to your will. Then channel...\n\nAberrant Sorcery to use strange psionic magic.\n\nClockwork Sorcery to harness cosmic forces of order.\n\nDraconic Sorcery to breathe the magic of dragons.\n\nWild Magic to unleash chaos magic.\n\n**Warlock.** Cast spells derived from occult knowledge. Then form a pact with the...\n\nArchfey Patron to teleport and wield fey magic.\n\nCelestial Patron to heal with heavenly magic.\n\nFiend Patron to call on sinister powers.\n\nGreat Old One Patron to delve into forbidden lore.\n\n**Wizard.** Study arcane magic and master spells for every purpose.\n\nThen embody the...\n\nAbjurer to shield allies and banish foes.\n\nDiviner to learn the multiverse’s secrets.\n\nEvoker to create explosive effects.\n\nIllusionist to weave spells of deception." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-open-hand/quivering-palm", "it"), Language = LanguageCode.It, Name = "Palmo Tremante", Description = "Il monaco ottiene la capacità di generare vibrazioni letali nel corpo di una creatura. Quando colpisce una creatura con un colpo senz'armi, può spendere 4 punti concentrazione per avviare queste vibrazioni impercettibili, che durano un numero di giorni pari al suo livello da monaco. Finché il monaco non decide di usare un'azione per interromperle, le vibrazioni non provocano alcun effetto.\n\nIn alternativa, quando effettua l'azione di Attacco nel suo turno, può rinunciare a uno degli attacchi per porre fine alle vibrazioni. Per farlo, il monaco e il bersaglio devono trovarsi sullo stesso piano di esistenza. Nell'istante in cui il monaco le interrompe, il bersaglio tira un tiro salvezza su Costituzione e subisce 10d12 danni da forza in caso di fallimento, oppure metà di quei danni in caso di successo.\n\nIl monaco può tenere sotto l'effetto di questo privilegio una sola creatura alla volta, e può porre fine alle vibrazioni senza alcun danno (nessuna azione richiesta)." }
					}
				}
			}
		};
	}
}
