using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Great Old One Patron (warlock, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class GreatOldOnePatron2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "great-old-one-patron");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Warlock2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "great-old-one-patron", "en"), Language = LanguageCode.En, Name = "Great Old One Patron", Description = "With this pact you may have bound yourself to a nameless horror from the Far Realm or to an elder god, a being such as Tharizdun the Chained God, Zargon the Returner, Hadar the Dark Hunger or Great Cthulhu; or you may call on several such entities without serving any single one. Their aims are beyond understanding, and your patron may not even notice that you exist, yet the secrets you have gleaned still let you draw strange magic from it." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "great-old-one-patron", "it"), Language = LanguageCode.It, Name = "Patrono Grande Antico", Description = "Con questo patto il warlock potrebbe essersi legato a un orrore senza nome del Reame Remoto o a un dio antico, un essere come Tharizdun il Dio Incatenato, Zargon il Ritornante, Hadar la Fame Oscura o il Grande Cthulhu; oppure potrebbe invocare più entità di questo tipo senza servirne nessuna in particolare. I loro scopi sono incomprensibili e il patrono potrebbe persino non accorgersi della sua esistenza, eppure i segreti appresi gli permettono comunque di attingere da esso una magia insolita." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/awakened-mind"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/awakened-mind", "en"), Language = LanguageCode.En, Name = "Awakened Mind", Description = "You can open a telepathic link between your mind and another's. As a Bonus Action, pick a creature you can see within 30 feet of you: while you stay no more than a number of miles apart equal to your Charisma modifier (at least 1 mile), the two of you can talk mind to mind. To understand each other, each must think in a language the other knows.\n\nThe link lasts a number of minutes equal to your Warlock level, ending sooner if you use this feature to link with someone else." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/awakened-mind", "it"), Language = LanguageCode.It, Name = "Mente Risvegliata", Description = "Il warlock può creare un collegamento telepatico tra la propria mente e quella di un'altra creatura. Come azione bonus, sceglie una creatura che è in grado di vedere entro 9 metri da lui: finché si trovano a una distanza massima pari a 1,5 chilometri per il modificatore di Carisma del warlock (minimo 1,5 chilometri), i due possono comunicare telepaticamente. Per capirsi, entrambi devono usare mentalmente una lingua conosciuta dall'altro.\n\nIl collegamento dura un numero di minuti pari al livello da warlock e termina prima se il warlock usa questo privilegio per collegarsi a un'altra creatura." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/great-old-one-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/great-old-one-spells", "en"), Language = LanguageCode.En, Name = "Great Old One Spells", Description = "From the Warlock level shown in the table below onward, the listed spells are always prepared for you.\n\n| Warlock Level | Spells |\n|---|---|\n| 3 | *Detect Thoughts*, *Dissonant Whispers*, *Hideous Laughter*, *Phantasmal Force* |\n| 5 | *Clairvoyance*, *Hunger of Hadar* |\n| 7 | *Confusion*, *Summon Aberration* |\n| 9 | *Modify Memory*, *Telekinesis* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/great-old-one-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Grande Antico", Description = "Dal livello da warlock indicato nella tabella seguente, il warlock ha sempre preparati gli incantesimi elencati.\n\n| Livello da warlock | Incantesimi |\n|---|---|\n| 3 | *allucinazione di forza*, *individuazione dei pensieri*, *risata incontenibile*, *sussurri dissonanti* |\n| 5 | *chiaroveggenza*, *fame di Hadar* |\n| 7 | *confusione*, *richiama aberrazione* |\n| 9 | *modificare memoria*, *telecinesi* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/psychic-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/psychic-spells", "en"), Language = LanguageCode.En, Name = "Psychic Spells", Description = "Any Warlock spell of yours that deals damage can have its damage type switched to Psychic. And when you cast a Warlock spell of the Enchantment or Illusion school, you can do so without Verbal or Somatic components." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/psychic-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi Psichici", Description = "Quando lancia un incantesimo da warlock che infligge danni, il warlock può cambiarne il tipo di danni in psichico. Inoltre, quando lancia un incantesimo da warlock di ammaliamento o di illusione, può farlo senza componenti verbali né somatiche." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/clairvoyant-combatant"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/clairvoyant-combatant", "en"), Language = LanguageCode.En, Name = "Clairvoyant Combatant", Description = "When you link minds with a creature through Awakened Mind, you can force it to make a Wisdom saving throw against your spell save DC. On a failure, for as long as the link lasts, it has Disadvantage on attack rolls against you and you have Advantage on attack rolls against it.\n\nAfter using this feature, you need a Short or Long Rest to use it again, unless you spend a Pact Magic spell slot (no action required) to restore it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/clairvoyant-combatant", "it"), Language = LanguageCode.It, Name = "Guerriero Chiaroveggente", Description = "Quando crea un collegamento telepatico con una creatura tramite Mente risvegliata, il warlock può costringerla a un tiro salvezza su Saggezza contro la CD del tiro salvezza dei suoi incantesimi. Se lo fallisce, per la durata del collegamento la creatura subisce svantaggio ai tiri per colpire contro il warlock, e il warlock dispone di vantaggio ai tiri per colpire contro di essa.\n\nDopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo breve o lungo, a meno che non spenda uno slot incantesimo della Magia del patto (nessuna azione richiesta) per ripristinarlo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/eldritch-hex"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/eldritch-hex", "en"), Language = LanguageCode.En, Name = "Eldritch Hex", Description = "Your alien patron grants you a potent curse: *Hex* is always prepared for you. When you cast *Hex* and pick an ability, the target also has Disadvantage on saving throws using that ability while the spell lasts." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/eldritch-hex", "it"), Language = LanguageCode.It, Name = "Sortilegio Occulto", Description = "Il patrono alieno concede al warlock una maledizione potente: ha sempre preparato l'incantesimo *sortilegio*. Quando lancia *sortilegio* e sceglie una caratteristica, il bersaglio subisce anche svantaggio ai tiri salvezza su quella caratteristica per la durata dell'incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/thought-shield"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/thought-shield", "en"), Language = LanguageCode.En, Name = "Thought Shield", Description = "No telepathy or other means can read your thoughts unless you allow it. You also resist Psychic damage, and whenever a creature deals Psychic damage to you, it takes as much damage as you did." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/thought-shield", "it"), Language = LanguageCode.It, Name = "Scudo del Pensiero", Description = "I pensieri del warlock non possono essere letti tramite telepatia o altri mezzi, a meno che non lo permetta. Ha inoltre resistenza ai danni psichici e, ogni volta che una creatura gli infligge danni psichici, quella creatura subisce la stessa quantità di danni subiti dal warlock." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/create-thrall"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/create-thrall", "en"), Language = LanguageCode.En, Name = "Create Thrall", Description = "When you cast *Summon Aberration*, you can alter it so it doesn't need Concentration; that casting then lasts 1 minute, and the summoned Aberration gains Temporary Hit Points equal to your Warlock level plus your Charisma modifier.\n\nAlso, the first time each turn the Aberration hits a creature under your *Hex*, it adds extra Psychic damage equal to that spell's bonus damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "great-old-one-patron/create-thrall", "it"), Language = LanguageCode.It, Name = "Creare Servitore", Description = "Quando lancia *richiama aberrazione*, il warlock può modificarlo in modo che non richieda concentrazione; in tal caso, per quel lancio la durata diventa di 1 minuto, e l'aberrazione evocata ottiene punti ferita temporanei pari al livello da warlock + il modificatore di Carisma del warlock.\n\nInoltre, la prima volta in ogni turno in cui l'aberrazione colpisce una creatura soggetta al *sortilegio* del warlock, le infligge danni psichici extra pari ai danni bonus di quell'incantesimo." }
					}
				}
			}
		};
	}
}
