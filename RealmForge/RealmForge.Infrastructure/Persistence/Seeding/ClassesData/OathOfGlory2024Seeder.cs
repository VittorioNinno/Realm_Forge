using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Oath of Glory (paladin, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class OathOfGlory2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-glory");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Paladin2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-glory", "en"), Language = LanguageCode.En, Name = "Oath of Glory", Description = "Paladins of the Oath of Glory believe that they and their companions are meant to win renown through heroic deeds. They train tirelessly and spur their friends on, so that everyone is ready when destiny comes knocking.\n\nThese Paladins share these tenets:\n\n- Let your deeds make your name.\n- Meet every trial with courage.\n- Spur others on toward glory." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-glory", "it"), Language = LanguageCode.It, Name = "Giuramento di Gloria", Description = "I paladini del Giuramento di Gloria credono che loro e i loro compagni siano destinati a conquistare la fama con imprese eroiche. Si allenano senza sosta e spronano gli amici, perché tutti siano pronti quando il destino busserà alla porta.\n\nQuesti paladini condividono i seguenti principi:\n\n- Fai sì che siano le tue gesta a darti un nome.\n- Affronta ogni prova con coraggio.\n- Sprona gli altri verso la gloria." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/inspiring-smite"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/inspiring-smite", "en"), Language = LanguageCode.En, Name = "Inspiring Smite", Description = "Right after you cast *Divine Smite*, you can spend a use of Channel Divinity to hand out Temporary Hit Points equal to 2d8 plus your Paladin level, split however you like among creatures of your choice within 30 feet of you, yourself included." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/inspiring-smite", "it"), Language = LanguageCode.It, Name = "Punizione Ispiratrice", Description = "Subito dopo aver lanciato *punizione divina*, il paladino può spendere un utilizzo di Incanalare Divinità per distribuire 2d8 + il suo livello da paladino in punti ferita temporanei tra le creature a sua scelta entro 9 metri da lui, che possono includere lui stesso, ripartendoli come preferisce." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/oath-of-glory-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/oath-of-glory-spells", "en"), Language = LanguageCode.En, Name = "Oath of Glory Spells", Description = "Your oath keeps certain spells always at hand: from the Paladin level shown in the table below onward, the listed spells are always prepared for you.\n\n| Paladin Level | Spells |\n|---|---|\n| 3 | *Guiding Bolt*, *Heroism* |\n| 5 | *Enhance Ability*, *Magic Weapon* |\n| 9 | *Haste*, *Protection from Energy* |\n| 13 | *Compulsion*, *Freedom of Movement* |\n| 17 | *Legend Lore*, Yolande's Regal Presence |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/oath-of-glory-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Giuramento di Gloria", Description = "Grazie al giuramento, il paladino ha sempre a disposizione alcuni incantesimi: dal livello da paladino indicato nella tabella seguente, gli incantesimi elencati sono sempre preparati per lui.\n\n| Livello da paladino | Incantesimi |\n|---|---|\n| 3 | *dardo tracciante*, *eroismo* |\n| 5 | *arma magica*, *caratteristica potenziata* |\n| 9 | *protezione dall'energia*, *velocità* |\n| 13 | *compulsione*, *libertà di movimento* |\n| 17 | *conoscenza delle leggende*, presenza regale di Yolande |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/peerless-athlete"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/peerless-athlete", "en"), Language = LanguageCode.En, Name = "Peerless Athlete", Description = "As a Bonus Action, you can spend a use of Channel Divinity to boost your athletic gifts. For 1 hour, your Strength (Athletics) and Dexterity (Acrobatics) checks have Advantage, and your Long Jumps and High Jumps carry you 10 feet farther (that extra distance still costs movement)." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/peerless-athlete", "it"), Language = LanguageCode.It, Name = "Atleta Impareggiabile", Description = "Come azione bonus, il paladino può spendere un utilizzo di Incanalare Divinità per potenziare le proprie doti atletiche. Per 1 ora dispone di vantaggio alle prove di Forza (Atletica) e di Destrezza (Acrobazia), e la distanza dei suoi salti in lungo e in alto aumenta di 3 metri (la distanza extra costa movimento come di consueto)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/aura-of-alacrity"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/aura-of-alacrity", "en"), Language = LanguageCode.En, Name = "Aura of Alacrity", Description = "Your Speed increases by 10 feet.\n\nAlso, whenever an ally first enters your Aura of Protection on a turn or begins its turn there, its Speed increases by 10 feet until the end of its next turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/aura-of-alacrity", "it"), Language = LanguageCode.It, Name = "Aura di Alacrità", Description = "La velocità del paladino aumenta di 3 metri.\n\nInoltre, quando un alleato entra per la prima volta in un turno nella sua Aura di protezione, o vi inizia il proprio turno, la velocità di quell'alleato aumenta di 3 metri fino alla fine del suo turno successivo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/glorious-defense"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/glorious-defense", "en"), Language = LanguageCode.En, Name = "Glorious Defense", Description = "You can turn a parry into a sudden counterblow. When you or another creature you can see within 10 feet of you is hit by an attack roll, you can use your Reaction to raise the target's AC against that attack by your Charisma modifier (at least +1), which might make it miss. If it misses and the attacker is within your weapon's range, you can make one weapon attack against the attacker as part of the same Reaction.\n\nYou can use this feature a number of times equal to your Charisma modifier (at least once), regaining every use after a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/glorious-defense", "it"), Language = LanguageCode.It, Name = "Difesa Gloriosa", Description = "Il paladino sa trasformare la difesa in un contrattacco improvviso. Quando lui o un'altra creatura che è in grado di vedere entro 3 metri da lui viene colpito da un tiro per colpire, può usare una reazione per conferire al bersaglio un bonus alla CA contro quell'attacco pari al suo modificatore di Carisma (minimo +1), con la possibilità di farlo mancare. Se l'attacco manca e l'attaccante è alla portata della sua arma, come parte della stessa reazione il paladino può effettuare contro di lui un attacco con un'arma.\n\nIl paladino può usare questo privilegio un numero di volte pari al suo modificatore di Carisma (almeno una) e recupera tutti gli utilizzi dopo un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/living-legend"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/living-legend", "en"), Language = LanguageCode.En, Name = "Living Legend", Description = "You can draw strength from the tales, true or embellished, told of your exploits. As a Bonus Action, you gain the benefits below for 10 minutes. You can use this feature once per Long Rest, and spending a level 5 spell slot (no action required) lets you use it again.\n\n**Charismatic.** An unearthly presence surrounds you, and you have Advantage on every Charisma check.\n\n**Saving Throw Reroll.** If you fail a saving throw, you can use your Reaction to roll it again, and you must use the new result.\n\n**Unerring Strike.** Once on each of your turns, when a weapon attack roll of yours misses, you can make it hit instead." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-glory/living-legend", "it"), Language = LanguageCode.It, Name = "Leggenda Vivente", Description = "Il paladino può attingere alle leggende, vere o esagerate, che circondano le sue imprese. Come azione bonus, ottiene i benefici seguenti per 10 minuti. Dopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo, ma può ripristinarne l'utilizzo spendendo uno slot incantesimo di 5° livello (nessuna azione richiesta).\n\n**Carismatico.** Una presenza ultraterrena accompagna il paladino, che dispone di vantaggio a tutte le prove di Carisma.\n\n**Ripetere il tiro salvezza.** Se fallisce un tiro salvezza, il paladino può usare una reazione per ripeterlo e deve usare il nuovo risultato.\n\n**Colpo infallibile.** Una volta in ognuno dei suoi turni, quando manca con un tiro per colpire effettuato con un'arma, il paladino può far sì che l'attacco colpisca comunque." }
					}
				}
			}
		};
	}
}
