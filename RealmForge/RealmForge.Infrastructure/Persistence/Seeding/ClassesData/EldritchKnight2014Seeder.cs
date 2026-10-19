using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Eldritch Knight (fighter, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class EldritchKnight2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "eldritch-knight");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Fighter2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.Third,
			SpellcastingAbility = AbilityScore.Intelligence,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "eldritch-knight", "en"), Language = LanguageCode.En, Name = "Eldritch Knight", Description = "Eldritch Knights blend a fighter's mastery of arms with the study of magic. They learn spells the way wizards do, but focus on two schools: abjuration, which protects them in battle, and evocation, which lets them strike many foes at once. Rather than keeping a spellbook, they commit their small repertoire of spells to memory." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "eldritch-knight", "it"), Language = LanguageCode.It, Name = "Cavaliere Mistico", Description = "I Cavalieri Mistici uniscono la padronanza delle armi del guerriero allo studio della magia. Apprendono gli incantesimi come i maghi, ma si concentrano su due scuole: abiurazione, che li protegge in battaglia, e invocazione, che permette loro di colpire molti nemici in una volta sola. Invece di tenere un libro degli incantesimi, imparano a memoria il loro piccolo repertorio di incantesimi." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "At 3rd level, you learn to cast spells from the wizard spell list.\n\n**Cantrips.** You learn two wizard cantrips of your choice, and one more at 10th level.\n\n**Spell Slots.** The Eldritch Knight Spellcasting table shows your spell slots for spells of 1st level and higher. To cast such a spell, you spend a slot of the spell's level or higher, and you regain all spent slots when you finish a long rest.\n\n**Spells Known of 1st Level and Higher.** You know three 1st-level wizard spells of your choice, two of which must be abjuration or evocation spells. The Spells Known column shows when you learn more wizard spells; each must be of a level for which you have spell slots, and must be an abjuration or evocation spell, except the ones you learn at 8th, 14th, and 20th level, which can come from any school. Whenever you gain a fighter level, you can replace one wizard spell you know with another of a level for which you have slots; the new spell must be abjuration or evocation unless it replaces one of the spells gained at 8th, 14th, or 20th level.\n\n**Spellcasting Ability.** Intelligence is your spellcasting ability for these spells: you use it whenever a spell refers to your spellcasting ability, and your Intelligence modifier sets the save DC and the attack bonus of your spells.\n\n**Spell save DC** = 8 + your proficiency bonus + your Intelligence modifier\n\n**Spell attack modifier** = your proficiency bonus + your Intelligence modifier\n\n**Eldritch Knight Spellcasting**\n\n| Fighter Level | Cantrips Known | Spells Known | 1st | 2nd | 3rd | 4th |\n|---|---|---|---|---|---|---|\n| 3rd | 2 | 3 | 2 | — | — | — |\n| 4th | 2 | 4 | 3 | — | — | — |\n| 5th | 2 | 4 | 3 | — | — | — |\n| 6th | 2 | 4 | 3 | — | — | — |\n| 7th | 2 | 5 | 4 | 2 | — | — |\n| 8th | 2 | 6 | 4 | 2 | — | — |\n| 9th | 2 | 6 | 4 | 2 | — | — |\n| 10th | 3 | 7 | 4 | 3 | — | — |\n| 11th | 3 | 8 | 4 | 3 | — | — |\n| 12th | 3 | 8 | 4 | 3 | — | — |\n| 13th | 3 | 9 | 4 | 3 | 2 | — |\n| 14th | 3 | 10 | 4 | 3 | 2 | — |\n| 15th | 3 | 10 | 4 | 3 | 2 | — |\n| 16th | 3 | 11 | 4 | 3 | 3 | — |\n| 17th | 3 | 11 | 4 | 3 | 3 | — |\n| 18th | 3 | 11 | 4 | 3 | 3 | — |\n| 19th | 3 | 12 | 4 | 3 | 3 | 1 |\n| 20th | 3 | 13 | 4 | 3 | 3 | 1 |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Al 3° livello il guerriero impara a lanciare incantesimi dalla lista degli incantesimi del mago.\n\n**Trucchetti.** Il guerriero apprende due trucchetti da mago a sua scelta, e un altro al 10° livello.\n\n**Slot incantesimo.** La tabella degli Incantesimi del Cavaliere Mistico indica gli slot incantesimo del guerriero per gli incantesimi di 1° livello e superiore. Per lanciare uno di questi incantesimi spende uno slot di livello pari o superiore a quello dell'incantesimo, e recupera tutti gli slot spesi quando completa un riposo lungo.\n\n**Incantesimi conosciuti di 1° livello e superiore.** Il guerriero conosce tre incantesimi da mago di 1° livello a sua scelta, due dei quali devono essere di abiurazione o di invocazione. La colonna \"Incantesimi conosciuti\" indica quando apprende altri incantesimi da mago; ognuno deve essere di un livello per cui possiede slot incantesimo e deve essere di abiurazione o di invocazione, tranne quelli appresi all'8°, al 14° e al 20° livello, che possono appartenere a qualsiasi scuola. Ogni volta che ottiene un livello da guerriero, può sostituire un incantesimo da mago che conosce con un altro di un livello per cui possiede slot; il nuovo incantesimo deve essere di abiurazione o di invocazione, a meno che non sostituisca uno di quelli ottenuti all'8°, al 14° o al 20° livello.\n\n**Caratteristica da incantatore.** L'Intelligenza è la caratteristica da incantatore del guerriero per questi incantesimi: la usa ogni volta che un incantesimo fa riferimento alla sua caratteristica da incantatore, e il suo modificatore di Intelligenza determina la CD dei tiri salvezza e il bonus di attacco dei suoi incantesimi.\n\n**CD del tiro salvezza degli incantesimi** = 8 + bonus di competenza + modificatore di Intelligenza\n\n**Modificatore di attacco degli incantesimi** = bonus di competenza + modificatore di Intelligenza\n\n**Incantesimi del Cavaliere Mistico**\n\n| Livello da guerriero | Trucchetti conosciuti | Incantesimi conosciuti | 1° | 2° | 3° | 4° |\n|---|---|---|---|---|---|---|\n| 3° | 2 | 3 | 2 | — | — | — |\n| 4° | 2 | 4 | 3 | — | — | — |\n| 5° | 2 | 4 | 3 | — | — | — |\n| 6° | 2 | 4 | 3 | — | — | — |\n| 7° | 2 | 5 | 4 | 2 | — | — |\n| 8° | 2 | 6 | 4 | 2 | — | — |\n| 9° | 2 | 6 | 4 | 2 | — | — |\n| 10° | 3 | 7 | 4 | 3 | — | — |\n| 11° | 3 | 8 | 4 | 3 | — | — |\n| 12° | 3 | 8 | 4 | 3 | — | — |\n| 13° | 3 | 9 | 4 | 3 | 2 | — |\n| 14° | 3 | 10 | 4 | 3 | 2 | — |\n| 15° | 3 | 10 | 4 | 3 | 2 | — |\n| 16° | 3 | 11 | 4 | 3 | 3 | — |\n| 17° | 3 | 11 | 4 | 3 | 3 | — |\n| 18° | 3 | 11 | 4 | 3 | 3 | — |\n| 19° | 3 | 12 | 4 | 3 | 3 | 1 |\n| 20° | 3 | 13 | 4 | 3 | 3 | 1 |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/weapon-bond"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/weapon-bond", "en"), Language = LanguageCode.En, Name = "Weapon Bond", Description = "At 3rd level, you can perform a 1-hour ritual (it can be done during a short rest) to bind yourself to a weapon you are holding. You can't be disarmed of a bonded weapon unless you are incapacitated. If it is on the same plane of existence as you, you can summon it as a bonus action on your turn, and it teleports instantly into your hand.\n\nYou can have up to two bonded weapons, but you can summon only one at a time with that bonus action. Bonding a third weapon breaks the bond with one of the other two." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/weapon-bond", "it"), Language = LanguageCode.It, Name = "Arma Vincolata", Description = "Al 3° livello il guerriero può eseguire un rituale di 1 ora (che può svolgersi durante un riposo breve) per legarsi a un'arma che impugna. Non può essere disarmato di un'arma vincolata a meno che non sia incapacitato. Se l'arma si trova sul suo stesso piano di esistenza, può richiamarla come azione bonus nel proprio turno, e l'arma si teletrasporta all'istante nella sua mano.\n\nIl guerriero può avere fino a due armi vincolate, ma può richiamarne soltanto una alla volta con quell'azione bonus. Vincolare una terza arma spezza il legame con una delle altre due." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/war-magic"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/war-magic", "en"), Language = LanguageCode.En, Name = "War Magic", Description = "From 7th level, when you use your action to cast a cantrip, you can make one weapon attack as a bonus action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/war-magic", "it"), Language = LanguageCode.It, Name = "Magia da Guerra", Description = "Dal 7° livello, quando usa la sua azione per lanciare un trucchetto, il guerriero può effettuare un attacco con un'arma come azione bonus." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/eldritch-strike"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/eldritch-strike", "en"), Language = LanguageCode.En, Name = "Eldritch Strike", Description = "From 10th level, your blows weaken a creature's defenses against your magic. When you hit a creature with a weapon attack, it has disadvantage on the next saving throw it makes against a spell you cast before the end of your next turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/eldritch-strike", "it"), Language = LanguageCode.It, Name = "Colpo Mistico", Description = "Dal 10° livello i colpi del guerriero indeboliscono le difese di una creatura contro la sua magia. Quando colpisce una creatura con un attacco con un'arma, quella creatura subisce svantaggio al successivo tiro salvezza che effettua contro un incantesimo lanciato dal guerriero prima della fine del turno successivo di quest'ultimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/arcane-charge"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 15,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/arcane-charge", "en"), Language = LanguageCode.En, Name = "Arcane Charge", Description = "From 15th level, when you use Action Surge, you can also teleport up to 30 feet to an unoccupied space you can see, either before or after the additional action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/arcane-charge", "it"), Language = LanguageCode.It, Name = "Carica Arcana", Description = "Dal 15° livello, quando usa Azione Impetuosa, il guerriero può anche teletrasportarsi fino a 9 metri in uno spazio libero che è in grado di vedere, prima o dopo l'azione aggiuntiva." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/improved-war-magic"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 18,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/improved-war-magic", "en"), Language = LanguageCode.En, Name = "Improved War Magic", Description = "From 18th level, when you use your action to cast a spell, you can make one weapon attack as a bonus action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "eldritch-knight/improved-war-magic", "it"), Language = LanguageCode.It, Name = "Magia da Guerra Migliorata", Description = "Dal 18° livello, quando usa la sua azione per lanciare un incantesimo, il guerriero può effettuare un attacco con un'arma come azione bonus." }
					}
				}
			}
		};
	}
}
