using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Sorcerer (2024 ruleset): class features of the SRD 5.2 (CC BY 4.0) in English; the Italian text is a RealmForge translation
///	that uses the official Italian game terms. Its subclasses have their own files.
///	</summary>
public static class Sorcerer2024Seeder
{
	public static readonly Guid ClassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "sorcerer");

	public static CharacterClass Build()
	{
		return new CharacterClass
		{
			Id = ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			HitDie = 6,
			PrimaryAbilities = new List<AbilityScore> { AbilityScore.Charisma },
			SavingThrows = new List<AbilityScore> { AbilityScore.Constitution, AbilityScore.Charisma },
			SkillChoiceCount = 2,
			SkillOptions = new List<Skill> { Skill.Arcana, Skill.Deception, Skill.Insight, Skill.Intimidation, Skill.Persuasion, Skill.Religion },
			CasterProgression = CasterProgression.Full,
			SpellcastingAbility = AbilityScore.Charisma,
			SubclassLevel = 3,
			Translations = new List<CharacterClassTranslation>
			{
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "sorcerer", "en"),
					Language = LanguageCode.En,
					Name = "Sorcerer",
					Description = "A dazzling mage whose power is part of their very being. Sorcerers never study spellbooks: their magic springs from a strange heritage, a twist of fate or an otherworldly touch, and they learn to shape that raw power to their will, bending and twisting their spells with Metamagic.",
					SubclassTitle = "Sorcerer Subclass",
					ArmorProficiencies = "None",
					WeaponProficiencies = "Simple weapons",
					ToolProficiencies = "None",
					StartingEquipment = "Choose A or B:\n- (A) Spear, 2 Daggers, Arcane Focus (crystal), Dungeoneer's Pack and 28 GP\n- (B) 50 GP",
					ProgressionTable = "The 1–9 columns show the spell slots per spell level.\n\n| Level | Proficiency Bonus | Class Features | Sorcery Points | Cantrips | Prepared Spells | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Spellcasting, Innate Sorcery | — | 4 | 2 | 2 | — | — | — | — | — | — | — | — |\n| 2 | +2 | Font of Magic, Metamagic | 2 | 4 | 4 | 3 | — | — | — | — | — | — | — | — |\n| 3 | +2 | Sorcerer Subclass | 3 | 4 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4 | +2 | Ability Score Improvement | 4 | 5 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5 | +3 | Sorcerous Restoration | 5 | 5 | 9 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6 | +3 | Subclass feature | 6 | 5 | 10 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7 | +3 | Sorcery Incarnate | 7 | 5 | 11 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8 | +3 | Ability Score Improvement | 8 | 5 | 12 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9 | +4 | — | 9 | 5 | 14 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10 | +4 | Metamagic | 10 | 6 | 15 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11 | +4 | — | 11 | 6 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12 | +4 | Ability Score Improvement | 12 | 6 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13 | +5 | — | 13 | 6 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14 | +5 | Subclass feature | 14 | 6 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15 | +5 | — | 15 | 6 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16 | +5 | Ability Score Improvement | 16 | 6 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17 | +6 | Metamagic | 17 | 6 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18 | +6 | Subclass feature | 18 | 6 | 20 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19 | +6 | Epic Boon | 19 | 6 | 21 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20 | +6 | Arcane Apotheosis | 20 | 6 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				},
				new CharacterClassTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class", "sorcerer", "it"),
					Language = LanguageCode.It,
					Name = "Stregone",
					Description = "Un mago abbagliante il cui potere fa parte del suo stesso essere. Lo stregone non studia libri di incantesimi: la sua magia nasce da un'eredità insolita, da un capriccio del destino o da un tocco ultraterreno, e lui impara a plasmare quel potere grezzo secondo la propria volontà, piegando e distorcendo gli incantesimi con la Metamagia.",
					SubclassTitle = "Sottoclasse dello stregone",
					ArmorProficiencies = "Nessuna",
					WeaponProficiencies = "Armi semplici",
					ToolProficiencies = "Nessuno",
					StartingEquipment = "A scelta tra A e B:\n- (A) una lancia, 2 pugnali, un focus arcano (cristallo), una dotazione da avventuriero e 28 mo\n- (B) 50 mo",
					ProgressionTable = "Le colonne 1–9 indicano gli slot incantesimo per livello di incantesimo.\n\n| Livello | Bonus di competenza | Privilegi di classe | Punti stregoneria | Trucchetti | Incantesimi preparati | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n|---|---|---|---|---|---|---|---|---|---|---|---|---|---|---|\n| 1 | +2 | Incantesimi, Stregoneria Innata | — | 4 | 2 | 2 | — | — | — | — | — | — | — | — |\n| 2 | +2 | Fonte di Magia, Metamagia | 2 | 4 | 4 | 3 | — | — | — | — | — | — | — | — |\n| 3 | +2 | Sottoclasse dello Stregone | 3 | 4 | 6 | 4 | 2 | — | — | — | — | — | — | — |\n| 4 | +2 | Aumento dei Punteggi di Caratteristica | 4 | 5 | 7 | 4 | 3 | — | — | — | — | — | — | — |\n| 5 | +3 | Ripristino Stregonesco | 5 | 5 | 9 | 4 | 3 | 2 | — | — | — | — | — | — |\n| 6 | +3 | Privilegio della sottoclasse | 6 | 5 | 10 | 4 | 3 | 3 | — | — | — | — | — | — |\n| 7 | +3 | Stregoneria Incarnata | 7 | 5 | 11 | 4 | 3 | 3 | 1 | — | — | — | — | — |\n| 8 | +3 | Aumento dei Punteggi di Caratteristica | 8 | 5 | 12 | 4 | 3 | 3 | 2 | — | — | — | — | — |\n| 9 | +4 | — | 9 | 5 | 14 | 4 | 3 | 3 | 3 | 1 | — | — | — | — |\n| 10 | +4 | Metamagia | 10 | 6 | 15 | 4 | 3 | 3 | 3 | 2 | — | — | — | — |\n| 11 | +4 | — | 11 | 6 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 12 | +4 | Aumento dei Punteggi di Caratteristica | 12 | 6 | 16 | 4 | 3 | 3 | 3 | 2 | 1 | — | — | — |\n| 13 | +5 | — | 13 | 6 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 14 | +5 | Privilegio della sottoclasse | 14 | 6 | 17 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | — | — |\n| 15 | +5 | — | 15 | 6 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 16 | +5 | Aumento dei Punteggi di Caratteristica | 16 | 6 | 18 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | — |\n| 17 | +6 | Metamagia | 17 | 6 | 19 | 4 | 3 | 3 | 3 | 2 | 1 | 1 | 1 | 1 |\n| 18 | +6 | Privilegio della sottoclasse | 18 | 6 | 20 | 4 | 3 | 3 | 3 | 3 | 1 | 1 | 1 | 1 |\n| 19 | +6 | Dono Epico | 19 | 6 | 21 | 4 | 3 | 3 | 3 | 3 | 2 | 1 | 1 | 1 |\n| 20 | +6 | Apoteosi Arcana | 20 | 6 | 22 | 4 | 3 | 3 | 3 | 3 | 2 | 2 | 1 | 1 |"
				}
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "Drawing from your innate magic, you can cast spells. See chapter 7 for the rules on spellcasting. The information below details how you use those rules with Sorcerer spells, which appear in the Sorcerer spell list later in the class’s description.\n\n**Cantrips.** You know four Sorcerer cantrips of your choice. Light, Prestidigitation, Shocking Grasp, and Sorcerous Burst are recommended. Whenever you gain a Sorcerer level, you can replace one of your cantrips from this feature with another Sorcerer cantrip of your choice. When you reach Sorcerer levels 4 and 10, you learn another Sorcerer cantrip of your choice, as shown in the Cantrips column of the Sorcerer Features table.\n\n**Spell Slots.** The Sorcerer Features table shows how many spell slots you have to cast your level 1+ spells. You regain all expended slots when you finish a Long Rest.\n\n**Prepared Spells of Level 1+.** You prepare the list of level 1+ spells that are available for you to cast with this feature. To start, choose two level 1 Sorcerer spells. Burning Hands and Detect Magic are recommended.\n\nThe number of spells on your list increases as you gain Sorcerer levels, as shown in the Prepared Spells column of the Sorcerer Features table. Whenever that number increases, choose additional Sorcerer spells until the number of spells on your list matches the number in the Sorcerer Features table. The chosen spells must be of a level for which you have spell slots. For example, if you’re a level 3 Sorcerer, your list of prepared spells can include six Sorcerer spells of level 1 or 2 in any combination.\n\nIf another Sorcerer feature gives you spells that you always have prepared, those spells don’t count against the number of spells you can prepare with this feature, but those spells otherwise count as Sorcerer spells for you.\n\n**Changing Your Prepared Spells.** Whenever you gain a Sorcerer level, you can replace one spell on your list with another Sorcerer spell for which you have spell slots.\n\n**Spellcasting Ability.** Charisma is your spellcasting ability for your Sorcerer spells.\n\n**Spellcasting Focus.** You can use an Arcane Focus as a Spellcasting Focus for your Sorcerer spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Attingendo alla sua magia innata, lo stregone è in grado di lanciare incantesimi (le regole per lanciarli si trovano nel capitolo sugli incantesimi). Di seguito è spiegato come lo stregone applica quelle regole agli incantesimi da stregone, che compaiono nella lista degli incantesimi da stregone.\n\n**Trucchetti.** Lo stregone conosce quattro trucchetti da stregone a sua scelta; sono consigliati *luce*, *prestidigitazione*, *stregoneria esplosiva* e *stretta folgorante*. Ogni volta che sale di livello come stregone, può sostituire uno dei trucchetti ottenuti con questo privilegio con un altro trucchetto da stregone a sua scelta. Al 4° e al 10° livello da stregone impara un altro trucchetto da stregone a sua scelta, come indicato nella colonna Trucchetti della tabella dei privilegi dello stregone.\n\n**Slot incantesimo.** La tabella dei privilegi dello stregone indica quanti slot incantesimo possiede lo stregone per lanciare i suoi incantesimi di 1° livello o superiore. Recupera tutti gli slot spesi quando completa un riposo lungo.\n\n**Incantesimi preparati di 1° livello o superiore.** Lo stregone prepara l'elenco degli incantesimi di 1° livello o superiore che può lanciare con questo privilegio. Per cominciare, sceglie due incantesimi da stregone di 1° livello; sono consigliati *individuazione del magico* e *mani brucianti*.\n\nIl numero di incantesimi del suo elenco aumenta man mano che sale di livello come stregone, come indicato nella colonna Incantesimi preparati della tabella dei privilegi dello stregone. Ogni volta che quel numero aumenta, sceglie altri incantesimi da stregone finché il numero di incantesimi nel suo elenco non coincide con quello della tabella. Gli incantesimi scelti devono essere di un livello per cui lo stregone possiede slot incantesimo. Per esempio, uno stregone di 3° livello può avere nel suo elenco sei incantesimi da stregone di 1° o 2° livello in qualsiasi combinazione.\n\nSe un altro privilegio da stregone gli fa avere incantesimi sempre preparati, quegli incantesimi non contano nel numero di incantesimi che può preparare con questo privilegio, ma per il resto contano come incantesimi da stregone per lui.\n\n**Cambiare gli incantesimi preparati.** Ogni volta che sale di livello come stregone, può sostituire un incantesimo del suo elenco con un altro incantesimo da stregone per cui possiede slot incantesimo.\n\n**Caratteristica da incantatore.** Il Carisma è la caratteristica da incantatore dello stregone per i suoi incantesimi da stregone.\n\n**Focus da incantatore.** Lo stregone può usare un focus arcano come focus da incantatore per i suoi incantesimi da stregone." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/innate-sorcery"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/innate-sorcery", "en"), Language = LanguageCode.En, Name = "Innate Sorcery", Description = "An event in your past left an indelible mark on you, infusing you with simmering magic. As a Bonus Action, you can unleash that magic for 1 minute, during which you gain the following benefits:\n\n- The spell save DC of your Sorcerer spells increases by 1.\n- You have Advantage on the attack rolls of Sorcerer spells you cast.\n\nYou can use this feature twice, and you regain all expended uses of it when you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/innate-sorcery", "it"), Language = LanguageCode.It, Name = "Stregoneria Innata", Description = "Un evento del passato ha lasciato sullo stregone un segno indelebile, infondendogli una magia che ribolle sotto la superficie. Come azione bonus, può scatenare quella magia per 1 minuto, durante il quale ottiene i benefici seguenti:\n\n- la CD del tiro salvezza dei suoi incantesimi da stregone aumenta di 1;\n- dispone di vantaggio ai tiri per colpire degli incantesimi da stregone che lancia.\n\nLo stregone può usare questo privilegio due volte e recupera tutti gli utilizzi spesi quando completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/font-of-magic"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/font-of-magic", "en"), Language = LanguageCode.En, Name = "Font of Magic", Description = "You can tap into the wellspring of magic within yourself. This wellspring is represented by Sorcery Points, which allow you to create a variety of magical effects.\n\nYou have 2 Sorcery Points, and you gain more as you reach higher levels, as shown in the Sorcery Points column of the Sorcerer Features table. You can't have more Sorcery Points than the number shown in the table for your level. You regain all expended Sorcery Points when you finish a Long Rest.\n\nYou can use your Sorcery Points to fuel the options below, along with other features, such as Metamagic, that use those points.\n\n**Converting Spell Slots to Sorcery Points.** You can expend a spell slot to gain a number of Sorcery Points equal to the slot's level (no action required).\n\n**Creating Spell Slots.** As a Bonus Action, you can transform unexpended Sorcery Points into one spell slot. The table below shows the cost of creating a spell slot of a given level, and it lists the minimum Sorcerer level you must be to create a slot. You can create a spell slot no higher than level 5.\n\n| Spell Slot Level | Sorcery Point Cost | Min. Sorcerer Level |\n|---|---|---|\n| 1 | 2 | 2 |\n| 2 | 3 | 3 |\n| 3 | 5 | 5 |\n| 4 | 6 | 7 |\n| 5 | 7 | 9 |\n\nAny spell slot you create with this feature vanishes when you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/font-of-magic", "it"), Language = LanguageCode.It, Name = "Fonte di Magia", Description = "Lo stregone può attingere alla fonte di magia che ha dentro di sé, rappresentata dai punti stregoneria, che gli permettono di creare una varietà di effetti magici.\n\nLo stregone ha 2 punti stregoneria e ne ottiene altri ai livelli superiori, come indicato nella colonna Punti stregoneria della tabella dei privilegi dello stregone. Non può avere più punti stregoneria di quelli indicati nella tabella per il suo livello. Recupera tutti i punti stregoneria spesi quando completa un riposo lungo.\n\nLo stregone può usare i punti stregoneria per alimentare le opzioni seguenti, oltre ad altri privilegi che usano quei punti, come la Metamagia.\n\n**Convertire gli slot incantesimo in punti stregoneria.** Lo stregone può spendere uno slot incantesimo per ottenere un numero di punti stregoneria pari al livello dello slot (nessuna azione richiesta).\n\n**Creare slot incantesimo.** Come azione bonus, lo stregone può trasformare punti stregoneria non spesi in uno slot incantesimo. La tabella seguente indica il costo per creare uno slot di un dato livello e il livello da stregone minimo necessario. Lo stregone non può creare slot di livello superiore al 5°.\n\n| Livello dello slot | Costo in punti stregoneria | Livello da stregone minimo |\n|---|---|---|\n| 1 | 2 | 2 |\n| 2 | 3 | 3 |\n| 3 | 5 | 5 |\n| 4 | 6 | 7 |\n| 5 | 7 | 9 |\n\nOgni slot incantesimo creato con questo privilegio svanisce quando lo stregone completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/metamagic"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/metamagic", "en"), Language = LanguageCode.En, Name = "Metamagic", Description = "Because your magic flows from within, you can alter your spells to suit your needs; you gain two Metamagic options of your choice from “Metamagic Options” later in this class’s description. You use the chosen options to temporarily modify spells you cast. To use an option, you must spend the number of Sorcery Points that it costs.\n\nYou can use only one Metamagic option on a spell when you cast it unless otherwise noted in one of those options. Whenever you gain a Sorcerer level, you can replace one of your Metamagic options with one you don’t know. You gain two more options at Sorcerer level 10 and two more at Sorcerer level 17.\n\n**Metamagic Options**\n\nThe options are presented in alphabetical order.\n\n**Careful Spell (Cost: 1 Sorcery Point).** When you cast a spell that forces other creatures to make a saving throw, you can protect some of those creatures from the spell's full force. To do so, spend 1 Sorcery Point and choose a number of those creatures up to your Charisma modifier (minimum of one creature). A chosen creature automatically succeeds on its saving throw against the spell, and it takes no damage if it would normally take half damage on a successful save.\n\n**Distant Spell (Cost: 1 Sorcery Point).** When you cast a spell that has a range of at least 5 feet, you can spend 1 Sorcery Point to double the spell's range. Or when you cast a spell that has a range of Touch, you can spend 1 Sorcery Point to make the spell's range 30 feet.\n\n**Empowered Spell (Cost: 1 Sorcery Point).** When you roll damage for a spell, you can spend 1 Sorcery Point to reroll a number of the damage dice up to your Charisma modifier (minimum of one), and you must use the new rolls. You can use Empowered Spell even if you've already used a different Metamagic option during the casting of the spell.\n\n**Extended Spell (Cost: 1 Sorcery Point).** When you cast a spell that has a duration of 1 minute or longer, you can spend 1 Sorcery Point to double its duration to a maximum duration of 24 hours. If the affected spell requires Concentration, you have Advantage on any saving throw you make to maintain that Concentration.\n\n**Heightened Spell (Cost: 2 Sorcery Points).** When you cast a spell that forces a creature to make a saving throw, you can spend 2 Sorcery Points to give one target of the spell Disadvantage on saves against the spell.\n\n**Quickened Spell (Cost: 2 Sorcery Points).** When you cast a spell that has a casting time of an action, you can spend 2 Sorcery Points to change the casting time to a Bonus Action for this casting. You can't modify a spell in this way if you've already cast a level 1+ spell on the current turn, nor can you cast a level 1+ spell on this turn after modifying a spell in this way.\n\n**Seeking Spell (Cost: 1 Sorcery Point).** If you make an attack roll for a spell and miss, you can spend 1 Sorcery Point to reroll the d20, and you must use the new roll. You can use Seeking Spell even if you've already used a different Metamagic option during the casting of the spell.\n\n**Subtle Spell (Cost: 1 Sorcery Point).** When you cast a spell, you can spend 1 Sorcery Point to cast it without any Verbal, Somatic, or Material components, except Material components that are consumed by the spell or that have a cost specified in the spell.\n\n**Transmuted Spell (Cost: 1 Sorcery Point).** When you cast a spell that deals a type of damage from the following list, you can spend 1 Sorcery Point to change that damage type to one of the other listed types: Acid, Cold, Fire, Lightning, Poison, Thunder.\n\n**Twinned Spell (Cost: 1 Sorcery Point).** When you cast a spell, such as *Charm Person*, that can be cast with a higher-level spell slot to target an additional creature, you can spend 1 Sorcery Point to increase the spell's effective level by 1." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/metamagic", "it"), Language = LanguageCode.It, Name = "Metamagia", Description = "Poiché la sua magia scaturisce dall'interno, lo stregone può modificare i suoi incantesimi secondo le sue esigenze: ottiene due opzioni di Metamagia a sua scelta tra quelle descritte di seguito, che usa per modificare temporaneamente gli incantesimi che lancia. Per usare un'opzione deve spendere il numero di punti stregoneria indicato come costo.\n\nLo stregone può applicare una sola opzione di Metamagia a un incantesimo quando lo lancia, salvo diversa indicazione nell'opzione stessa. Ogni volta che sale di livello come stregone, può sostituire una delle sue opzioni di Metamagia con una che non conosce. Ottiene altre due opzioni al 10° livello da stregone e altre due al 17°.\n\n**Opzioni di Metamagia**\n\nLe opzioni sono elencate in ordine alfabetico secondo il loro nome inglese.\n\n**Incantesimo preciso (costo: 1 punto stregoneria).** Quando lancia un incantesimo che costringe altre creature a effettuare un tiro salvezza, lo stregone può proteggere alcune di esse dalla piena forza dell'incantesimo: spende 1 punto stregoneria e sceglie un numero di quelle creature fino al suo modificatore di Carisma (minimo una). Una creatura scelta supera automaticamente il tiro salvezza contro l'incantesimo e, se normalmente subirebbe la metà dei danni con un successo, non subisce alcun danno.\n\n**Incantesimo distante (costo: 1 punto stregoneria).** Quando lancia un incantesimo con una gittata di almeno 1,5 metri, lo stregone può spendere 1 punto stregoneria per raddoppiarne la gittata; oppure, quando lancia un incantesimo con gittata a contatto, può spendere 1 punto stregoneria per portarne la gittata a 9 metri.\n\n**Incantesimo potenziato (costo: 1 punto stregoneria).** Quando tira i danni di un incantesimo, lo stregone può spendere 1 punto stregoneria per ripetere il tiro di un numero di dadi dei danni fino al suo modificatore di Carisma (minimo uno), e deve usare i nuovi risultati. Può usare questa opzione anche se ha già applicato un'altra opzione di Metamagia durante il lancio dell'incantesimo.\n\n**Incantesimo esteso (costo: 1 punto stregoneria).** Quando lancia un incantesimo con una durata di 1 minuto o superiore, lo stregone può spendere 1 punto stregoneria per raddoppiarne la durata, fino a un massimo di 24 ore. Se l'incantesimo richiede concentrazione, dispone di vantaggio a ogni tiro salvezza per mantenerla.\n\n**Incantesimo intensificato (costo: 2 punti stregoneria).** Quando lancia un incantesimo che costringe una creatura a effettuare un tiro salvezza, lo stregone può spendere 2 punti stregoneria per far subire a un bersaglio dell'incantesimo svantaggio ai tiri salvezza contro di esso.\n\n**Incantesimo rapido (costo: 2 punti stregoneria).** Quando lancia un incantesimo con un tempo di lancio di un'azione, lo stregone può spendere 2 punti stregoneria per cambiare il tempo di lancio in un'azione bonus per quel lancio. Non può modificare un incantesimo in questo modo se ha già lanciato un incantesimo di 1° livello o superiore nel turno, né può lanciare un incantesimo di 1° livello o superiore nel turno dopo averlo fatto.\n\n**Incantesimo mirato (costo: 1 punto stregoneria).** Se effettua un tiro per colpire per un incantesimo e manca, lo stregone può spendere 1 punto stregoneria per ripetere il tiro del d20, e deve usare il nuovo risultato. Può usare questa opzione anche se ha già applicato un'altra opzione di Metamagia durante il lancio dell'incantesimo.\n\n**Incantesimo celato (costo: 1 punto stregoneria).** Quando lancia un incantesimo, lo stregone può spendere 1 punto stregoneria per lanciarlo senza componenti verbali, somatiche o materiali, a eccezione delle componenti materiali consumate dall'incantesimo o di cui è indicato il costo.\n\n**Incantesimo trasmutato (costo: 1 punto stregoneria).** Quando lancia un incantesimo che infligge un tipo di danni tra acido, freddo, fuoco, fulmine, tuono e veleno, lo stregone può spendere 1 punto stregoneria per cambiare quel tipo di danni in un altro tipo dello stesso elenco.\n\n**Incantesimo raddoppiato (costo: 1 punto stregoneria).** Quando lancia un incantesimo che, se lanciato con uno slot di livello superiore, può prendere come bersaglio una creatura aggiuntiva (come *charme su persone*), lo stregone può spendere 1 punto stregoneria per aumentarne di 1 il livello effettivo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/sorcerer-subclass"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/sorcerer-subclass", "en"), Language = LanguageCode.En, Name = "Sorcerer Subclass", Description = "You gain a Sorcerer subclass of your choice. The Aberrant Sorcery, Clockwork Sorcery, Draconic Sorcery, and Wild Magic Sorcery subclasses are detailed after this class’s description. A subclass is a specialization that grants you features at certain Sorcerer levels. For the rest of your career, you gain each of your subclass’s features that are of your Sorcerer level or lower." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/sorcerer-subclass", "it"), Language = LanguageCode.It, Name = "Sottoclasse dello Stregone", Description = "Lo stregone ottiene una sottoclasse dello stregone a sua scelta: Stregoneria Aberrante, Stregoneria Draconica, Stregoneria della Magia Selvaggia o Stregoneria Meccanica. Una sottoclasse è una specializzazione che conferisce privilegi a determinati livelli da stregone. Per il resto della sua carriera, lo stregone ottiene ogni privilegio della sottoclasse di livello pari o inferiore al suo livello da stregone." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/ability-score-improvement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 4,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/ability-score-improvement", "en"), Language = LanguageCode.En, Name = "Ability Score Improvement", Description = "You gain the Ability Score Improvement feat (see chapter 5) or another feat of your choice for which you qualify. You gain this feature again at Sorcerer levels 8, 12, and 16." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/ability-score-improvement", "it"), Language = LanguageCode.It, Name = "Aumento dei Punteggi di Caratteristica", Description = "Lo stregone ottiene il talento Aumento dei punteggi di caratteristica o un altro talento a sua scelta di cui soddisfa i prerequisiti. Ottiene di nuovo questo privilegio all'8°, al 12° e al 16° livello da stregone." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/sorcerous-restoration"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 5,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/sorcerous-restoration", "en"), Language = LanguageCode.En, Name = "Sorcerous Restoration", Description = "When you finish a Short Rest, you can regain expended Sorcery Points, but no more than a number equal to half your Sorcerer level (round down). Once you use this feature, you can’t do so again until you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/sorcerous-restoration", "it"), Language = LanguageCode.It, Name = "Ripristino Stregonesco", Description = "Quando completa un riposo breve, lo stregone può recuperare punti stregoneria spesi, fino a un massimo pari alla metà del suo livello da stregone (arrotondata per difetto). Dopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/sorcery-incarnate"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 7,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/sorcery-incarnate", "en"), Language = LanguageCode.En, Name = "Sorcery Incarnate", Description = "If you have no uses of Innate Sorcery left, you can use it if you spend 2 Sorcery Points when you take the Bonus Action to activate it. In addition, while your Innate Sorcery feature is active, you can use up to two of your Metamagic options on each spell you cast." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/sorcery-incarnate", "it"), Language = LanguageCode.It, Name = "Stregoneria Incarnata", Description = "Se non gli restano utilizzi di Stregoneria innata, lo stregone può usarla comunque spendendo 2 punti stregoneria quando effettua l'azione bonus per attivarla. Inoltre, finché Stregoneria innata è attiva, può applicare fino a due opzioni di Metamagia a ogni incantesimo che lancia." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/epic-boon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 19,
					SortOrder = 8,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/epic-boon", "en"), Language = LanguageCode.En, Name = "Epic Boon", Description = "You gain an Epic Boon feat (see chapter 5) or another feat of your choice for which you qualify. Boon of Dimensional Travel is recommended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/epic-boon", "it"), Language = LanguageCode.It, Name = "Dono Epico", Description = "Lo stregone ottiene un talento Dono epico o un altro talento a sua scelta di cui soddisfa i prerequisiti. È consigliato il Dono del viaggio dimensionale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/arcane-apotheosis"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 9,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/arcane-apotheosis", "en"), Language = LanguageCode.En, Name = "Arcane Apotheosis", Description = "While your Innate Sorcery feature is active, you can use one Metamagic option on each of your turns without spending Sorcery Points on it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "sorcerer/arcane-apotheosis", "it"), Language = LanguageCode.It, Name = "Apoteosi Arcana", Description = "Finché Stregoneria innata è attiva, in ognuno dei suoi turni lo stregone può usare un'opzione di Metamagia senza spendere punti stregoneria per essa." }
					}
				}
			}
		};
	}
}
