using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Draconic Sorcery (sorcerer, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DraconicSorcery2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "draconic-sorcery");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Sorcerer2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "draconic-sorcery", "en"), Language = LanguageCode.En, Name = "Draconic Sorcery", Description = "Your innate magic comes from the gift of a dragon. Perhaps an ancient dragon facing death bequeathed some of its magical power to you or your ancestor. You might have absorbed magic from a site infused with dragons’ power. Or perhaps you handled a treasure taken from a dragon’s hoard that was steeped in draconic power. Or you might have a dragon for an ancestor." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "draconic-sorcery", "it"), Language = LanguageCode.It, Name = "Stregoneria Draconica", Description = "La magia innata dello stregone proviene dal dono di un drago. Forse un drago antico in punto di morte ha lasciato in eredità parte del suo potere magico allo stregone o a un suo antenato; forse lo stregone ha assorbito la magia di un luogo intriso del potere dei draghi, o ha maneggiato un tesoro sottratto all'orda di un drago e impregnato del suo potere; oppure ha un drago tra i suoi antenati." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/draconic-resilience"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/draconic-resilience", "en"), Language = LanguageCode.En, Name = "Draconic Resilience", Description = "The magic in your body manifests physical traits of your draconic gift. Your Hit Point maximum increases by 3, and it increases by 1 whenever you gain another Sorcerer level.\n\nParts of you are also covered by dragon-like scales. While you aren’t wearing armor, your base Armor Class equals 10 plus your Dexterity and Charisma modifiers." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/draconic-resilience", "it"), Language = LanguageCode.It, Name = "Resilienza Draconica", Description = "La magia che scorre nel corpo dello stregone fa emergere tratti fisici del suo dono draconico. Il suo massimo dei punti ferita aumenta di 3, e aumenta di 1 ogni volta che sale di un altro livello come stregone.\n\nParti del suo corpo sono inoltre coperte da scaglie simili a quelle di un drago. Finché non indossa armature, la sua Classe Armatura base è pari a 10 + il suo modificatore di Destrezza + il suo modificatore di Carisma." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/draconic-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/draconic-spells", "en"), Language = LanguageCode.En, Name = "Draconic Spells", Description = "When you reach a Sorcerer level specified in the table below, you thereafter always have the listed spells prepared.\n\n| Sorcerer Level | Spells |\n|---|---|\n| 3 | *Alter Self*, *Chromatic Orb*, *Command*, *Dragon's Breath* |\n| 5 | *Fear*, *Fly* |\n| 7 | *Arcane Eye*, *Charm Monster* |\n| 9 | *Legend Lore*, *Summon Dragon* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/draconic-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi Draconici", Description = "Quando raggiunge un livello da stregone indicato nella tabella seguente, da quel momento lo stregone ha sempre preparati gli incantesimi elencati.\n\n| Livello da stregone | Incantesimi |\n|---|---|\n| 3 | *alterare se stesso*, *comando*, *globo cromatico*, *soffio del drago* |\n| 5 | *paura*, *volare* |\n| 7 | *charme sui mostri*, *occhio arcano* |\n| 9 | *conoscenza delle leggende*, *richiama drago* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/elemental-affinity"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/elemental-affinity", "en"), Language = LanguageCode.En, Name = "Elemental Affinity", Description = "Your draconic magic has an affinity with a damage type associated with dragons. Choose one of those types: Acid, Cold, Fire, Lightning, or Poison.\n\nYou have Resistance to that damage type, and when you cast a spell that deals damage of that type, you can add your Charisma modifier to one damage roll of that spell." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/elemental-affinity", "it"), Language = LanguageCode.It, Name = "Affinità Elementale", Description = "La magia draconica dello stregone ha un'affinità con un tipo di danni associato ai draghi. Lo stregone sceglie uno di questi tipi: acido, freddo, fuoco, fulmine o veleno.\n\nHa resistenza a quel tipo di danni e, quando lancia un incantesimo che infligge danni di quel tipo, può sommare il suo modificatore di Carisma a un tiro per i danni di quell'incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/dragon-wings"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/dragon-wings", "en"), Language = LanguageCode.En, Name = "Dragon Wings", Description = "As a Bonus Action, you can cause draconic wings to appear on your back. The wings last for 1 hour or until you dismiss them (no action required). For the duration, you have a Fly Speed of 60 feet.\n\nOnce you use this feature, you can’t use it again until you finish a Long Rest unless you spend 3 Sorcery Points (no action required) to restore your use of it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/dragon-wings", "it"), Language = LanguageCode.It, Name = "Ali di Drago", Description = "Come azione bonus, lo stregone può far comparire sulla schiena ali draconiche, che durano 1 ora o finché non le congeda (nessuna azione richiesta). Per la durata, ha una velocità di volare di 18 metri.\n\nDopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo, a meno che non spenda 3 punti stregoneria (nessuna azione richiesta) per ripristinarlo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/dragon-companion"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/dragon-companion", "en"), Language = LanguageCode.En, Name = "Dragon Companion", Description = "You can cast Summon Dragon without a Material component. You can also cast it once without a spell slot, and you regain the ability to cast it in this way when you finish a Long Rest.\n\nWhenever you start casting the spell, you can modify it so that it doesn’t require Concentration. If you do so, the spell’s duration becomes 1 minute for that casting." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "draconic-sorcery/dragon-companion", "it"), Language = LanguageCode.It, Name = "Seguace Draconico", Description = "Lo stregone può lanciare *richiama drago* senza componente materiale. Può inoltre lanciarlo una volta senza slot incantesimo, e riacquista questa possibilità quando completa un riposo lungo.\n\nOgni volta che inizia a lanciare l'incantesimo, può modificarlo in modo che non richieda concentrazione; in tal caso, per quel lancio la durata diventa di 1 minuto." }
					}
				}
			}
		};
	}
}
