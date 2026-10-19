using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Arcane Trickster (rogue, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class ArcaneTrickster2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "arcane-trickster");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Rogue2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.Third,
			SpellcastingAbility = AbilityScore.Intelligence,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "arcane-trickster", "en"), Language = LanguageCode.En, Name = "Arcane Trickster", Description = "Some rogues sharpen their stealth and agility with magic, learning tricks of enchantment and illusion. Pickpockets and burglars walk this path, but so do pranksters, troublemakers and plenty of adventurers." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "arcane-trickster", "it"), Language = LanguageCode.It, Name = "Mistificatore Arcano", Description = "Alcuni ladri affinano la propria furtività e agilità con la magia, imparando trucchi di ammaliamento e di illusione. Questa strada è seguita da borseggiatori e scassinatori, ma anche da burloni, attaccabrighe e da molti avventurieri." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "At 3rd level, you learn to cast spells from the wizard spell list.\n\n**Cantrips.** You learn *mage hand* and two other wizard cantrips of your choice, and one more wizard cantrip at 10th level.\n\n**Spell Slots.** The Arcane Trickster Spellcasting table shows your spell slots for spells of 1st level and higher. To cast such a spell, you spend a slot of the spell's level or higher, and you regain all spent slots when you finish a long rest.\n\n**Spells Known of 1st Level and Higher.** You know three 1st-level wizard spells of your choice, two of which must be enchantment or illusion spells. The Spells Known column shows when you learn more wizard spells; each must be of a level for which you have spell slots, and must be an enchantment or illusion spell, except the ones you learn at 8th, 14th, and 20th level, which can come from any school. Whenever you gain a rogue level, you can replace one wizard spell you know with another of a level for which you have slots; the new spell must be enchantment or illusion unless it replaces one of the spells gained at 8th, 14th, or 20th level.\n\n**Spellcasting Ability.** Intelligence is your spellcasting ability for these spells: you use it whenever a spell refers to your spellcasting ability, and your Intelligence modifier sets the save DC and the attack bonus of your spells.\n\n**Spell save DC** = 8 + your proficiency bonus + your Intelligence modifier\n\n**Spell attack modifier** = your proficiency bonus + your Intelligence modifier\n\n**Arcane Trickster Spellcasting**\n\n| Rogue Level | Cantrips Known | Spells Known | 1st | 2nd | 3rd | 4th |\n|---|---|---|---|---|---|---|\n| 3rd | 3 | 3 | 2 | — | — | — |\n| 4th | 3 | 4 | 3 | — | — | — |\n| 5th | 3 | 4 | 3 | — | — | — |\n| 6th | 3 | 4 | 3 | — | — | — |\n| 7th | 3 | 5 | 4 | 2 | — | — |\n| 8th | 3 | 6 | 4 | 2 | — | — |\n| 9th | 3 | 6 | 4 | 2 | — | — |\n| 10th | 4 | 7 | 4 | 3 | — | — |\n| 11th | 4 | 8 | 4 | 3 | — | — |\n| 12th | 4 | 8 | 4 | 3 | — | — |\n| 13th | 4 | 9 | 4 | 3 | 2 | — |\n| 14th | 4 | 10 | 4 | 3 | 2 | — |\n| 15th | 4 | 10 | 4 | 3 | 2 | — |\n| 16th | 4 | 11 | 4 | 3 | 3 | — |\n| 17th | 4 | 11 | 4 | 3 | 3 | — |\n| 18th | 4 | 11 | 4 | 3 | 3 | — |\n| 19th | 4 | 12 | 4 | 3 | 3 | 1 |\n| 20th | 4 | 13 | 4 | 3 | 3 | 1 |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Al 3° livello il ladro impara a lanciare incantesimi dalla lista degli incantesimi del mago.\n\n**Trucchetti.** Il ladro apprende *mano magica* e altri due trucchetti da mago a sua scelta, e un altro trucchetto da mago al 10° livello.\n\n**Slot incantesimo.** La tabella degli Incantesimi del Mistificatore Arcano indica gli slot incantesimo del ladro per gli incantesimi di 1° livello e superiore. Per lanciare uno di questi incantesimi spende uno slot di livello pari o superiore a quello dell'incantesimo, e recupera tutti gli slot spesi quando completa un riposo lungo.\n\n**Incantesimi conosciuti di 1° livello e superiore.** Il ladro conosce tre incantesimi da mago di 1° livello a sua scelta, due dei quali devono essere di ammaliamento o di illusione. La colonna \"Incantesimi conosciuti\" indica quando apprende altri incantesimi da mago; ognuno deve essere di un livello per cui possiede slot incantesimo e deve essere di ammaliamento o di illusione, tranne quelli appresi all'8°, al 14° e al 20° livello, che possono appartenere a qualsiasi scuola. Ogni volta che ottiene un livello da ladro, può sostituire un incantesimo da mago che conosce con un altro di un livello per cui possiede slot; il nuovo incantesimo deve essere di ammaliamento o di illusione, a meno che non sostituisca uno di quelli ottenuti all'8°, al 14° o al 20° livello.\n\n**Caratteristica da incantatore.** L'Intelligenza è la caratteristica da incantatore del ladro per questi incantesimi: la usa ogni volta che un incantesimo fa riferimento alla sua caratteristica da incantatore, e il suo modificatore di Intelligenza determina la CD dei tiri salvezza e il bonus di attacco dei suoi incantesimi.\n\n**CD del tiro salvezza degli incantesimi** = 8 + bonus di competenza + modificatore di Intelligenza\n\n**Modificatore di attacco degli incantesimi** = bonus di competenza + modificatore di Intelligenza\n\n**Incantesimi del Mistificatore Arcano**\n\n| Livello da ladro | Trucchetti conosciuti | Incantesimi conosciuti | 1° | 2° | 3° | 4° |\n|---|---|---|---|---|---|---|\n| 3° | 3 | 3 | 2 | — | — | — |\n| 4° | 3 | 4 | 3 | — | — | — |\n| 5° | 3 | 4 | 3 | — | — | — |\n| 6° | 3 | 4 | 3 | — | — | — |\n| 7° | 3 | 5 | 4 | 2 | — | — |\n| 8° | 3 | 6 | 4 | 2 | — | — |\n| 9° | 3 | 6 | 4 | 2 | — | — |\n| 10° | 4 | 7 | 4 | 3 | — | — |\n| 11° | 4 | 8 | 4 | 3 | — | — |\n| 12° | 4 | 8 | 4 | 3 | — | — |\n| 13° | 4 | 9 | 4 | 3 | 2 | — |\n| 14° | 4 | 10 | 4 | 3 | 2 | — |\n| 15° | 4 | 10 | 4 | 3 | 2 | — |\n| 16° | 4 | 11 | 4 | 3 | 3 | — |\n| 17° | 4 | 11 | 4 | 3 | 3 | — |\n| 18° | 4 | 11 | 4 | 3 | 3 | — |\n| 19° | 4 | 12 | 4 | 3 | 3 | 1 |\n| 20° | 4 | 13 | 4 | 3 | 3 | 1 |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/mage-hand-legerdemain"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/mage-hand-legerdemain", "en"), Language = LanguageCode.En, Name = "Mage Hand Legerdemain", Description = "From 3rd level, when you cast *mage hand*, you can make the spectral hand invisible, and it can perform these extra tasks:\n- put an object it is holding into a container worn or carried by another creature;\n- take an object out of a container worn or carried by another creature;\n- use your thieves' tools to pick locks and disarm traps at a distance.\n\nYou can perform one of these tasks without the creature noticing if you succeed on a Dexterity (Sleight of Hand) check contested by its Wisdom (Perception) check. You can also use the bonus action from Cunning Action to control the hand." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/mage-hand-legerdemain", "it"), Language = LanguageCode.It, Name = "Gioco di Prestigio della Mano Magica", Description = "Dal 3° livello, la *mano magica* del ladro diventa uno strumento da vero borsaiolo: quando lancia il trucchetto, può renderne invisibile la mano spettrale, che diventa capace di:\n- infilare un oggetto che tiene nella borsa, nello zaino o in un altro contenitore che una creatura ha addosso;\n- sottrarre un oggetto da un contenitore che una creatura porta con sé;\n- maneggiare a distanza gli arnesi da scasso del ladro, per forzare serrature e neutralizzare trappole.\n\nPer riuscire in una di queste operazioni senza farsi notare, il ladro effettua una prova di Destrezza (Rapidità di Mano), a cui il possessore oppone una prova di Saggezza (Percezione). Il ladro può anche guidare la mano spendendo l'azione bonus che gli concede Azione Scaltra." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/magical-ambush"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 9,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/magical-ambush", "en"), Language = LanguageCode.En, Name = "Magical Ambush", Description = "From 9th level, if you are hidden from a creature when you cast a spell on it, it has disadvantage on any saving throw it makes against that spell this turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/magical-ambush", "it"), Language = LanguageCode.It, Name = "Imboscata Magica", Description = "Dal 9° livello la magia del ladro colpisce meglio dall'ombra. Se lancia un incantesimo su una creatura che non si è accorta della sua posizione perché lui è nascosto, la creatura tira con svantaggio i tiri salvezza contro quell'incantesimo fino alla fine del turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/versatile-trickster"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 13,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/versatile-trickster", "en"), Language = LanguageCode.En, Name = "Versatile Trickster", Description = "From 13th level, you can use your spectral hand as a distraction. As a bonus action on your turn, you pick a creature within 5 feet of the hand created by your *mage hand* spell: you have advantage on attack rolls against that creature until the end of the turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/versatile-trickster", "it"), Language = LanguageCode.It, Name = "Ingannatore Versatile", Description = "Dal 13° livello il ladro può usare la sua mano spettrale come diversivo. Come azione bonus nel suo turno, sceglie una creatura entro 1,5 metri dalla mano creata dal suo incantesimo *mano magica*: dispone di vantaggio ai tiri per colpire contro quella creatura fino alla fine del turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/spell-thief"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/spell-thief", "en"), Language = LanguageCode.En, Name = "Spell Thief", Description = "At 17th level, you can steal other casters' magic. Right after a creature casts a spell that targets you or includes you in its area, you can use your reaction to force it to make a saving throw with its spellcasting ability modifier, against your spell save DC. On a failure, the spell has no effect on you, and if it is of 1st level or higher and of a level you can cast, you steal the knowledge of it (it doesn't have to be a wizard spell). For the next 8 hours you know the spell and can cast it using your spell slots, while the creature can't cast it until those 8 hours have passed.\n\nOnce you use this feature, you can't use it again until you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "arcane-trickster/spell-thief", "it"), Language = LanguageCode.It, Name = "Ladro di Incantesimi", Description = "Al 17° livello il ladro può rubare la magia agli altri incantatori. Subito dopo che una creatura ha lanciato un incantesimo che lo prende come bersaglio o lo include nella sua area, il ladro può usare la sua reazione per costringerla a effettuare un tiro salvezza usando il suo modificatore di caratteristica da incantatore, contro la CD del tiro salvezza degli incantesimi del ladro. Se lo fallisce, l'incantesimo non ha effetto sul ladro e, se è di 1° livello o superiore e di un livello che il ladro è in grado di lanciare, il ladro ne ruba la conoscenza (non deve essere per forza un incantesimo da mago). Per le 8 ore successive conosce l'incantesimo e può lanciarlo usando i suoi slot incantesimo, mentre la creatura non può lanciarlo finché quelle 8 ore non sono trascorse.\n\nUna volta usato questo privilegio, il ladro non può usarlo di nuovo finché non completa un riposo lungo." }
					}
				}
			}
		};
	}
}
