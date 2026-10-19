using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	School of Evocation (wizard, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SchoolOfEvocation2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-evocation");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Wizard2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-evocation", "en"), Language = LanguageCode.En, Name = "School of Evocation", Description = "You focus your study on magic that creates powerful elemental effects such as bitter cold, searing flame, rolling thunder, crackling lightning, and burning acid. Some evokers find employment in military forces, serving as artillery to blast enemy armies from afar. Others use their spectacular power to protect the weak, while some seek their own gain as bandits, adventurers, or aspiring tyrants." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "school-of-evocation", "it"), Language = LanguageCode.It, Name = "Scuola di Invocazione", Description = "Il mago concentra i suoi studi sulla magia che crea potenti effetti elementali come il freddo pungente, le fiamme ardenti, il tuono rombante, il fulmine crepitante e l'acido corrosivo. Alcuni invocatori trovano impiego negli eserciti, dove fungono da artiglieria per colpire da lontano le schiere nemiche. Altri usano il loro potere spettacolare per proteggere i deboli, mentre altri ancora cercano il proprio tornaconto come banditi, avventurieri o aspiranti tiranni." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/evocation-savant"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/evocation-savant", "en"), Language = LanguageCode.En, Name = "Evocation Savant", Description = "Beginning when you select this school at 2nd level, the gold and time you must spend to copy an evocation spell into your spellbook is halved." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/evocation-savant", "it"), Language = LanguageCode.It, Name = "Invocatore Sapiente", Description = "A partire da quando sceglie questa scuola al 2° livello, l'oro e il tempo che il mago deve spendere per copiare un incantesimo di invocazione nel suo libro degli incantesimi sono dimezzati." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/sculpt-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/sculpt-spells", "en"), Language = LanguageCode.En, Name = "Sculpt Spells", Description = "Beginning at 2nd level, you can create pockets of relative safety within the effects of your evocation spells. When you cast an evocation spell that affects other creatures that you can see, you can choose a number of them equal to 1 + the spell's level. The chosen creatures automatically succeed on their saving throws against the spell, and they take no damage if they would normally take half damage on a successful save." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/sculpt-spells", "it"), Language = LanguageCode.It, Name = "Plasmare Incantesimi", Description = "A partire dal 2° livello, il mago può creare zone di relativa sicurezza all'interno degli effetti dei suoi incantesimi di invocazione. Quando lancia un incantesimo di invocazione che influenza altre creature che è in grado di vedere, può sceglierne un numero pari a 1 + il livello dell'incantesimo. Le creature scelte superano automaticamente i loro tiri salvezza contro l'incantesimo e non subiscono danni se normalmente ne subirebbero la metà con un tiro salvezza superato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/potent-cantrip"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/potent-cantrip", "en"), Language = LanguageCode.En, Name = "Potent Cantrip", Description = "Starting at 6th level, your damaging cantrips affect even creatures that avoid the brunt of the effect. When a creature succeeds on a saving throw against your cantrip, the creature takes half the cantrip's damage (if any) but suffers no additional effect from the cantrip." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/potent-cantrip", "it"), Language = LanguageCode.It, Name = "Trucchetto Potente", Description = "A partire dal 6° livello, i trucchetti dannosi del mago colpiscono anche le creature che evitano il grosso dell'effetto. Quando una creatura supera un tiro salvezza contro un trucchetto del mago, subisce la metà dei danni del trucchetto (se ce ne sono), ma non subisce alcun effetto aggiuntivo del trucchetto." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/empowered-evocation"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/empowered-evocation", "en"), Language = LanguageCode.En, Name = "Empowered Evocation", Description = "Beginning at 10th level, you can add your Intelligence modifier to one damage roll of any wizard evocation spell you cast." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/empowered-evocation", "it"), Language = LanguageCode.It, Name = "Invocazione Potente", Description = "A partire dal 10° livello, il mago può aggiungere il suo modificatore di Intelligenza a un tiro per i danni di qualsiasi incantesimo da mago di invocazione che lancia." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/overchannel"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/overchannel", "en"), Language = LanguageCode.En, Name = "Overchannel", Description = "Starting at 14th level, you can increase the power of your simpler spells. When you cast a wizard spell of 1st through 5th level that deals damage, you can deal maximum damage with that spell.\n\nThe first time you do so, you suffer no adverse effect. If you use this feature again before you finish a long rest, you take 2d12 necrotic damage for each level of the spell, immediately after you cast it. Each time you use this feature again before finishing a long rest, the necrotic damage per spell level increases by 1d12. This damage ignores resistance and immunity." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "school-of-evocation/overchannel", "it"), Language = LanguageCode.It, Name = "Saturazione Magica", Description = "A partire dal 14° livello, il mago può aumentare la potenza dei suoi incantesimi più semplici. Quando lancia un incantesimo da mago dal 1° al 5° livello che infligge danni, può infliggere il massimo dei danni con quell'incantesimo.\n\nLa prima volta che lo fa, non subisce alcun effetto negativo. Se usa di nuovo questo privilegio prima di completare un riposo lungo, subisce 2d12 danni necrotici per ogni livello dell'incantesimo, subito dopo averlo lanciato. Ogni volta che usa di nuovo questo privilegio prima di completare un riposo lungo, i danni necrotici per livello dell'incantesimo aumentano di 1d12. Questi danni ignorano la resistenza e l'immunità." }
					}
				}
			}
		};
	}
}
