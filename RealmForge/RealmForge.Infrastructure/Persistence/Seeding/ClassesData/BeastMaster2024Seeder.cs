using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Beast Master (ranger, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class BeastMaster2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "beast-master");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Ranger2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "beast-master", "en"), Language = LanguageCode.En, Name = "Beast Master", Description = "A Beast Master shares a mystic bond with an extraordinary animal, a companion shaped by primal magic and by the Ranger's deep kinship with the natural world." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "beast-master", "it"), Language = LanguageCode.It, Name = "Signore delle Bestie", Description = "Il signore delle bestie condivide un legame mistico con un animale straordinario, un compagno plasmato dalla magia primordiale e dalla profonda affinità del ranger con il mondo naturale." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/primal-companion"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/primal-companion", "en"), Language = LanguageCode.En, Name = "Primal Companion", Description = "You magically call forth a primal beast that draws strength from your bond with nature. Pick its stat block (Beast of the Land, Beast of the Sea, or Beast of the Sky) and the kind of animal it is, suited to that stat block; whatever you pick, it bears primal markings that betray its supernatural origin.\n\nThe beast is Friendly to you and your allies and follows your commands. It vanishes if you die.\n\n**The Beast in Combat.** In combat, the beast acts on your turn. It moves and uses its Reaction on its own, but the only action it takes is Dodge unless you use a Bonus Action to order it to take an action from its stat block or another action. When you take the Attack action, you can also give up one of your attacks to have the beast use its Beast's Strike. If you are Incapacitated, the beast acts on its own and isn't limited to Dodge.\n\n**Restoring or Replacing the Beast.** If the beast died within the last hour, you can use a Magic action to touch it and spend a spell slot; after 1 minute it returns to life with all its Hit Points. Each time you finish a Long Rest, you can summon a different primal beast, which appears in an unoccupied space within 5 feet of you; you pick its stat block and look, and any earlier beast vanishes when the new one arrives.\n\n**Beast of the Land.** Medium Beast, Neutral. AC 13 plus your Wisdom modifier; HP 5 plus five times your Ranger level (the beast has a number of Hit Dice [d8s] equal to your Ranger level); Speed 40 ft., Climb 40 ft.; Darkvision 60 ft., Passive Perception 12; understands the languages you know; CR None (XP 0; its Proficiency Bonus equals yours).\n\n| STR | DEX | CON | INT | WIS | CHA |\n|---|---|---|---|---|---|\n| 14 (+2) | 14 (+2) | 15 (+2) | 8 (−1) | 14 (+2) | 11 (+0) |\n\n*Primal Bond.* The beast adds your Proficiency Bonus to every ability check and saving throw it makes. *Beast's Strike.* Melee Attack Roll with a bonus equal to your spell attack modifier, reach 5 ft. Hit: 1d8 + 2 plus your Wisdom modifier Bludgeoning, Piercing, or Slashing damage (chosen when you summon the beast). If the beast moved at least 20 feet straight toward the target before the hit, the target takes an extra 1d6 damage of the same type and, if it is Large or smaller, has the Prone condition.\n\n**Beast of the Sea.** Medium Beast, Neutral. AC 13 plus your Wisdom modifier; HP 5 plus five times your Ranger level (Hit Dice [d8s] equal to your Ranger level); Speed 5 ft., Swim 60 ft.; Darkvision 90 ft., Passive Perception 12; understands the languages you know; CR None (XP 0; its Proficiency Bonus equals yours).\n\n| STR | DEX | CON | INT | WIS | CHA |\n|---|---|---|---|---|---|\n| 14 (+2) | 14 (+2) | 15 (+2) | 8 (−1) | 14 (+2) | 11 (+0) |\n\n*Amphibious.* The beast breathes both air and water. *Primal Bond.* As above. *Beast's Strike.* Melee Attack Roll with a bonus equal to your spell attack modifier, reach 5 ft. Hit: 1d6 + 2 plus your Wisdom modifier Bludgeoning or Piercing damage (chosen when you summon the beast), and the target has the Grappled condition (escape DC equal to your spell save DC).\n\n**Beast of the Sky.** Small Beast, Neutral. AC 13 plus your Wisdom modifier; HP 4 plus four times your Ranger level (Hit Dice [d6s] equal to your Ranger level); Speed 10 ft., Fly 60 ft.; Darkvision 60 ft., Passive Perception 12; understands the languages you know; CR None (XP 0; its Proficiency Bonus equals yours).\n\n| STR | DEX | CON | INT | WIS | CHA |\n|---|---|---|---|---|---|\n| 6 (−2) | 16 (+3) | 13 (+1) | 8 (−1) | 14 (+2) | 11 (+0) |\n\n*Flyby.* The beast doesn't provoke Opportunity Attacks when it flies out of an enemy's reach. *Primal Bond.* As above. *Beast's Strike.* Melee Attack Roll with a bonus equal to your spell attack modifier, reach 5 ft. Hit: 1d4 + 3 plus your Wisdom modifier Slashing damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/primal-companion", "it"), Language = LanguageCode.It, Name = "Compagno Primordiale", Description = "Il ranger evoca magicamente una bestia primordiale, che trae forza dal suo legame con la natura. Ne sceglie la scheda delle statistiche (bestia della terra, bestia del mare o bestia del cielo) e il tipo di animale, adatto alla scheda scelta; qualunque sia l'animale, porta segni primordiali che ne rivelano l'origine soprannaturale.\n\nLa bestia è amichevole nei confronti del ranger e dei suoi alleati e obbedisce ai suoi comandi. Svanisce se il ranger muore.\n\n**La bestia in combattimento.** In combattimento la bestia agisce durante il turno del ranger. Può muoversi e usare la propria reazione in autonomia, ma come azione effettua soltanto Schivata, a meno che il ranger non usi un'azione bonus per ordinarle un'azione della sua scheda o un'altra azione. Quando effettua l'azione di Attacco, il ranger può anche rinunciare a uno dei suoi attacchi per ordinare alla bestia di usare l'azione Colpo della bestia. Se il ranger è incapacitato, la bestia agisce da sola e non è limitata all'azione di Schivata.\n\n**Ripristinare o sostituire la bestia.** Se la bestia è morta nell'ultima ora, il ranger può usare un'azione di Magia per toccarla e spendere uno slot incantesimo: dopo 1 minuto la bestia torna in vita con tutti i suoi punti ferita. Ogni volta che completa un riposo lungo, il ranger può evocare una bestia primordiale diversa, che compare in uno spazio libero entro 1,5 metri da lui; ne sceglie scheda e aspetto, e l'eventuale bestia precedente svanisce quando compare la nuova.\n\n**Bestia della terra.** Bestia Media, neutrale. CA 13 + il modificatore di Saggezza del ranger; PF 5 + cinque volte il livello da ranger (la bestia ha un numero di Dadi Vita [d8] pari al livello da ranger); velocità 12 m, scalare 12 m; scurovisione 18 m, Percezione passiva 12; capisce le lingue conosciute dal ranger; GS nessuno (PE 0; il suo bonus di competenza è quello del ranger).\n\n| FOR | DES | COS | INT | SAG | CAR |\n|---|---|---|---|---|---|\n| 14 (+2) | 14 (+2) | 15 (+2) | 8 (−1) | 14 (+2) | 11 (+0) |\n\n*Legame primordiale.* La bestia somma il bonus di competenza a ogni prova di caratteristica e a ogni tiro salvezza. *Colpo della bestia.* Tiro per colpire in mischia con bonus pari al modificatore di attacco con incantesimi del ranger, portata 1,5 m. Colpito: 1d8 + 2 + il modificatore di Saggezza del ranger danni contundenti, perforanti o taglienti (scelti quando la bestia viene evocata). Se la bestia si è mossa di almeno 6 metri in linea retta verso il bersaglio prima di colpirlo, il bersaglio subisce 1d6 danni extra dello stesso tipo e, se è di taglia Grande o inferiore, subisce la condizione di prono.\n\n**Bestia del mare.** Bestia Media, neutrale. CA 13 + il modificatore di Saggezza del ranger; PF 5 + cinque volte il livello da ranger (Dadi Vita [d8] pari al livello da ranger); velocità 1,5 m, nuotare 18 m; scurovisione 27 m, Percezione passiva 12; capisce le lingue conosciute dal ranger; GS nessuno (PE 0; il suo bonus di competenza è quello del ranger).\n\n| FOR | DES | COS | INT | SAG | CAR |\n|---|---|---|---|---|---|\n| 14 (+2) | 14 (+2) | 15 (+2) | 8 (−1) | 14 (+2) | 11 (+0) |\n\n*Anfibio.* La bestia respira sia l'aria sia l'acqua. *Legame primordiale.* Come sopra. *Colpo della bestia.* Tiro per colpire in mischia con bonus pari al modificatore di attacco con incantesimi del ranger, portata 1,5 m. Colpito: 1d6 + 2 + il modificatore di Saggezza del ranger danni contundenti o perforanti (scelti quando la bestia viene evocata), e il bersaglio subisce la condizione di afferrato (CD per sfuggire pari alla CD del tiro salvezza degli incantesimi del ranger).\n\n**Bestia del cielo.** Bestia Piccola, neutrale. CA 13 + il modificatore di Saggezza del ranger; PF 4 + quattro volte il livello da ranger (Dadi Vita [d6] pari al livello da ranger); velocità 3 m, volare 18 m; scurovisione 18 m, Percezione passiva 12; capisce le lingue conosciute dal ranger; GS nessuno (PE 0; il suo bonus di competenza è quello del ranger).\n\n| FOR | DES | COS | INT | SAG | CAR |\n|---|---|---|---|---|---|\n| 6 (−2) | 16 (+3) | 13 (+1) | 8 (−1) | 14 (+2) | 11 (+0) |\n\n*Sfuggente.* La bestia non provoca attacchi di opportunità quando vola fuori dalla portata di un nemico. *Legame primordiale.* Come sopra. *Colpo della bestia.* Tiro per colpire in mischia con bonus pari al modificatore di attacco con incantesimi del ranger, portata 1,5 m. Colpito: 1d4 + 3 + il modificatore di Saggezza del ranger danni taglienti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/exceptional-training"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/exceptional-training", "en"), Language = LanguageCode.En, Name = "Exceptional Training", Description = "When you use a Bonus Action to order your Primal Companion beast to take an action, you can also have it take the Dash, Disengage, Dodge, or Help action with its own Bonus Action.\n\nAlso, each time the beast hits with an attack roll and deals damage, you choose whether that damage is Force or its usual type." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/exceptional-training", "it"), Language = LanguageCode.It, Name = "Addestramento Eccezionale", Description = "Quando usa un'azione bonus per ordinare alla bestia del Compagno primordiale di compiere un'azione, il ranger può anche ordinarle di effettuare, con la sua azione bonus, l'azione di Aiuto, Disimpegno, Scatto o Schivata.\n\nInoltre, ogni volta che la bestia colpisce con un tiro per colpire e infligge danni, può infliggere danni da forza o il suo tipo di danni normale, a scelta del ranger." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/bestial-fury"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/bestial-fury", "en"), Language = LanguageCode.En, Name = "Bestial Fury", Description = "When you order your Primal Companion beast to use Beast's Strike, it can strike twice.\n\nAlso, the first time each turn the beast hits a creature affected by your *Hunter's Mark*, it adds extra Force damage equal to that spell's bonus damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/bestial-fury", "it"), Language = LanguageCode.It, Name = "Furia Bestiale", Description = "Quando il ranger ordina alla bestia del Compagno primordiale di usare Colpo della bestia, la bestia può usarlo due volte.\n\nInoltre, la prima volta in ogni turno in cui colpisce una creatura soggetta al *marchio del cacciatore* del ranger, la bestia infligge danni da forza extra pari ai danni bonus di quell'incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/share-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/share-spells", "en"), Language = LanguageCode.En, Name = "Share Spells", Description = "When you cast a spell that targets only you, it can also affect your Primal Companion beast if the beast is within 30 feet of you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "beast-master/share-spells", "it"), Language = LanguageCode.It, Name = "Condividi Incantesimi", Description = "Quando lancia un incantesimo che ha se stesso come bersaglio, il ranger può influenzare con l'incantesimo anche la bestia del Compagno primordiale, se si trova entro 9 metri da lui." }
					}
				}
			}
		};
	}
}
