using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Eldritch Knight (fighter, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class EldritchKnight2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "eldritch-knight");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Fighter2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.Third,
			SpellcastingAbility = AbilityScore.Intelligence,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "eldritch-knight", "en"), Language = LanguageCode.En, Name = "Eldritch Knight", Description = "Eldritch Knights pair the weapon mastery shared by every Fighter with a disciplined study of magic. Their spells round out and stretch their fighting skills, adding protection on top of their armor and letting them strike many foes at once with explosive power." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "eldritch-knight", "it"), Language = LanguageCode.It, Name = "Cavaliere Mistico", Description = "Il cavaliere mistico unisce la maestria nelle armi comune a tutti i guerrieri a uno studio disciplinato della magia. I suoi incantesimi completano ed estendono le sue capacità di combattimento, aggiungendo protezione oltre a quella dell'armatura e permettendogli di colpire molti nemici insieme con un potere esplosivo." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "You have learned to cast spells (the rules for spellcasting are in the spells chapter). Here is how you use them as an Eldritch Knight.\n\n**Cantrips.** You know two cantrips of your choice from the Wizard spell list; *Ray of Frost* and *Shocking Grasp* are recommended. Each time you gain a Fighter level, you can swap one of them for another Wizard cantrip of your choice. At Fighter level 10 you learn one more Wizard cantrip of your choice.\n\n**Spell Slots.** The table below shows how many spell slots you have for your level 1+ spells. You regain every expended slot after a Long Rest.\n\n| Fighter Level | Prepared Spells | 1 | 2 | 3 | 4 |\n|---|---|---|---|---|---|\n| 3 | 3 | 2 | — | — | — |\n| 4 | 4 | 3 | — | — | — |\n| 5 | 4 | 3 | — | — | — |\n| 6 | 4 | 3 | — | — | — |\n| 7 | 5 | 4 | 2 | — | — |\n| 8 | 6 | 4 | 2 | — | — |\n| 9 | 6 | 4 | 2 | — | — |\n| 10 | 7 | 4 | 3 | — | — |\n| 11 | 8 | 4 | 3 | — | — |\n| 12 | 8 | 4 | 3 | — | — |\n| 13 | 9 | 4 | 3 | 2 | — |\n| 14 | 10 | 4 | 3 | 2 | — |\n| 15 | 10 | 4 | 3 | 2 | — |\n| 16 | 11 | 4 | 3 | 3 | — |\n| 17 | 11 | 4 | 3 | 3 | — |\n| 18 | 11 | 4 | 3 | 3 | — |\n| 19 | 12 | 4 | 3 | 3 | 1 |\n| 20 | 13 | 4 | 3 | 3 | 1 |\n\nThe 1–4 columns show the spell slots per spell level.\n\n**Prepared Spells of Level 1+.** You prepare the list of level 1+ spells you can cast with this feature. To begin, pick three level 1 spells from the Wizard spell list; *Burning Hands*, *Jump*, and *Shield* are recommended. Your list grows as you gain Fighter levels, as the Prepared Spells column of the table shows: whenever the number goes up, add Wizard spells until your list matches it. Each chosen spell must be of a level for which you have spell slots; a level 7 Fighter, for instance, can prepare five Wizard spells of levels 1 and 2 in any mix.\n\n**Changing Your Prepared Spells.** Each time you gain a Fighter level, you can swap one spell on your list for another Wizard spell for which you have spell slots.\n\n**Spellcasting Ability.** Intelligence is your spellcasting ability for your Wizard spells.\n\n**Spellcasting Focus.** You can use an Arcane Focus as a Spellcasting Focus for your Wizard spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Il guerriero ha imparato a lanciare incantesimi (le regole per lanciarli si trovano nel capitolo sugli incantesimi). Di seguito è spiegato come le applica in quanto cavaliere mistico.\n\n**Trucchetti.** Il guerriero conosce due trucchetti a sua scelta dalla lista degli incantesimi da mago; sono consigliati *raggio di gelo* e *stretta folgorante*. Ogni volta che sale di livello come guerriero, può sostituirne uno con un altro trucchetto da mago a sua scelta. Al 10° livello da guerriero impara un altro trucchetto da mago a sua scelta.\n\n**Slot incantesimo.** La tabella seguente indica quanti slot incantesimo possiede il guerriero per lanciare i suoi incantesimi di 1° livello o superiore. Recupera tutti gli slot spesi quando completa un riposo lungo.\n\n| Livello da guerriero | Incantesimi preparati | 1 | 2 | 3 | 4 |\n|---|---|---|---|---|---|\n| 3 | 3 | 2 | — | — | — |\n| 4 | 4 | 3 | — | — | — |\n| 5 | 4 | 3 | — | — | — |\n| 6 | 4 | 3 | — | — | — |\n| 7 | 5 | 4 | 2 | — | — |\n| 8 | 6 | 4 | 2 | — | — |\n| 9 | 6 | 4 | 2 | — | — |\n| 10 | 7 | 4 | 3 | — | — |\n| 11 | 8 | 4 | 3 | — | — |\n| 12 | 8 | 4 | 3 | — | — |\n| 13 | 9 | 4 | 3 | 2 | — |\n| 14 | 10 | 4 | 3 | 2 | — |\n| 15 | 10 | 4 | 3 | 2 | — |\n| 16 | 11 | 4 | 3 | 3 | — |\n| 17 | 11 | 4 | 3 | 3 | — |\n| 18 | 11 | 4 | 3 | 3 | — |\n| 19 | 12 | 4 | 3 | 3 | 1 |\n| 20 | 13 | 4 | 3 | 3 | 1 |\n\nLe colonne 1–4 indicano gli slot incantesimo per livello di incantesimo.\n\n**Incantesimi preparati di 1° livello o superiore.** Il guerriero prepara l'elenco degli incantesimi di 1° livello o superiore che può lanciare con questo privilegio. Per cominciare, sceglie tre incantesimi di 1° livello dalla lista degli incantesimi da mago; sono consigliati *mani brucianti*, *saltare* e *scudo*. Il numero di incantesimi del suo elenco aumenta man mano che sale di livello come guerriero, come indicato nella colonna Incantesimi preparati della tabella: quando aumenta, sceglie altri incantesimi da mago finché non raggiunge quel numero. Gli incantesimi scelti devono essere di un livello per cui possiede slot incantesimo; per esempio, un guerriero di 7° livello può avere nel suo elenco cinque incantesimi da mago di 1° e 2° livello in qualsiasi combinazione.\n\n**Cambiare gli incantesimi preparati.** Ogni volta che sale di livello come guerriero, può sostituire un incantesimo del suo elenco con un altro incantesimo da mago per cui possiede slot incantesimo.\n\n**Caratteristica da incantatore.** L'Intelligenza è la caratteristica da incantatore del guerriero per i suoi incantesimi da mago.\n\n**Focus da incantatore.** Il guerriero può usare un focus arcano come focus da incantatore per i suoi incantesimi da mago." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/war-bond"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/war-bond", "en"), Language = LanguageCode.En, Name = "War Bond", Description = "You know a ritual that binds you magically to one weapon. It takes 1 hour, which can be part of a Short Rest; the weapon must stay within your reach the whole time, and at the end you touch it to seal the bond. The bond fails if the weapon is already bound to another Fighter or is a magic item someone else is attuned to.\n\nOnce bound, the weapon can't be knocked from your grasp unless you are Incapacitated. If it is on your plane of existence, you can call it as a Bonus Action, and it teleports straight into your hand. You can keep up to two bound weapons but summon only one per Bonus Action; to bind a third, you must first break the bond with one of the other two." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/war-bond", "it"), Language = LanguageCode.It, Name = "Arma Vincolata", Description = "Il guerriero conosce un rituale che crea un legame magico tra lui e un'arma. Il rituale dura 1 ora e può svolgersi durante un riposo breve; l'arma deve restare alla sua portata per tutto il tempo e, al termine, il guerriero la tocca e suggella il legame. Il legame non si forma se l'arma è già vincolata a un altro guerriero o se è un oggetto magico con cui qualcun altro è in sintonia.\n\nUna volta vincolata l'arma, il guerriero non può essere disarmato di essa a meno che non sia incapacitato. Se l'arma si trova sul suo stesso piano di esistenza, può richiamarla con un'azione bonus, facendola teletrasportare all'istante nella sua mano. Può avere fino a due armi vincolate, ma ne richiama una sola per azione bonus; se vuole vincolarne una terza, deve prima spezzare il legame con una delle altre due." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/war-magic"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/war-magic", "en"), Language = LanguageCode.En, Name = "War Magic", Description = "When you take the Attack action on your turn, you can trade one of its attacks for casting one of your Wizard cantrips whose casting time is an action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/war-magic", "it"), Language = LanguageCode.It, Name = "Magia da Guerra", Description = "Durante l'azione di Attacco nel suo turno, il guerriero può rinunciare a uno degli attacchi per lanciare al suo posto un trucchetto da mago che conosce, purché il tempo di lancio sia di un'azione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/eldritch-strike"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/eldritch-strike", "en"), Language = LanguageCode.En, Name = "Eldritch Strike", Description = "Each weapon blow you land cracks the target's magical defenses. A creature struck by your weapon attack rolls with Disadvantage on its first save against one of your spells, if that save comes before your next turn ends." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/eldritch-strike", "it"), Language = LanguageCode.It, Name = "Colpo Mistico", Description = "Ogni colpo d'arma del guerriero incrina le difese magiche del bersaglio. Una creatura colpita da un suo attacco con un'arma tira con svantaggio il primo tiro salvezza contro un incantesimo del guerriero, se lo effettua entro la fine del prossimo turno di quest'ultimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/arcane-charge"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/arcane-charge", "en"), Language = LanguageCode.En, Name = "Arcane Charge", Description = "Each Action Surge can come with a magical leap: before or after the extra action, you blink to an unoccupied space you can see no more than 30 feet away." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/arcane-charge", "it"), Language = LanguageCode.It, Name = "Carica Arcana", Description = "Ogni Azione impetuosa del guerriero può essere accompagnata da un balzo magico: prima o dopo l'azione extra, si teletrasporta in uno spazio libero visibile distante non più di 9 metri." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/improved-war-magic"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/improved-war-magic", "en"), Language = LanguageCode.En, Name = "Improved War Magic", Description = "When you take the Attack action on your turn, you can trade two of its attacks for casting one of your level 1 or 2 Wizard spells whose casting time is an action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "eldritch-knight/improved-war-magic", "it"), Language = LanguageCode.It, Name = "Magia da Guerra Migliorata", Description = "Durante l'azione di Attacco nel suo turno, il guerriero può rinunciare a due degli attacchi per lanciare al loro posto un incantesimo da mago di 1° o 2° livello che ha preparato, purché il tempo di lancio sia di un'azione." }
					}
				}
			}
		};
	}
}
