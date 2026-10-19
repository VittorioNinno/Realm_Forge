using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Evoker (wizard, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Evoker2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "evoker");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Wizard2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "evoker", "en"), Language = LanguageCode.En, Name = "Evoker", Description = "Your studies focus on magic that creates powerful elemental effects such as bitter cold, searing flame, rolling thunder, crackling lightning, and burning acid. Some Evokers find employment in military forces, serving as artillery to blast armies from afar. Others use their power to protect others, while some seek their own gain." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "evoker", "it"), Language = LanguageCode.It, Name = "Invocatore", Description = "Gli studi dell'invocatore si concentrano sulla magia che crea potenti effetti elementali, come il freddo pungente, la fiamma rovente, il tuono che rimbomba, il fulmine crepitante e l'acido corrosivo. Alcuni invocatori trovano impiego negli eserciti, dove fungono da artiglieria per colpire le armate da lontano; altri usano il loro potere per proteggere gli altri, mentre altri ancora cercano il proprio tornaconto." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/evocation-savant"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/evocation-savant", "en"), Language = LanguageCode.En, Name = "Evocation Savant", Description = "Choose two Wizard spells from the Evocation school, each of which must be no higher than level 2, and add them to your spellbook for free.\n\nIn addition, whenever you gain access to a new level of spell slots in this class, you can add one Wizard spell from the Evocation school to your spellbook for free. The chosen spell must be of a level for which you have spell slots." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/evocation-savant", "it"), Language = LanguageCode.It, Name = "Invocatore Sapiente", Description = "Il mago sceglie due incantesimi da mago della scuola di invocazione, ognuno di livello non superiore al 2°, e li aggiunge gratuitamente al suo libro degli incantesimi.\n\nInoltre, ogni volta che ottiene accesso a un nuovo livello di slot incantesimo in questa classe, può aggiungere gratuitamente al libro un incantesimo da mago della scuola di invocazione, di un livello per cui possiede slot incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/potent-cantrip"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/potent-cantrip", "en"), Language = LanguageCode.En, Name = "Potent Cantrip", Description = "Your damaging cantrips affect even creatures that avoid the brunt of the effect. When you cast a cantrip at a creature and you miss with the attack roll or the target succeeds on a saving throw against the cantrip, the target takes half the cantrip’s damage (if any) but suffers no additional effect from the cantrip." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/potent-cantrip", "it"), Language = LanguageCode.It, Name = "Trucchetto Potente", Description = "I trucchetti dannosi del mago colpiscono anche le creature che evitano il grosso dell'effetto. Quando lancia un trucchetto contro una creatura e manca con il tiro per colpire, oppure il bersaglio supera il tiro salvezza contro il trucchetto, il bersaglio subisce la metà dei danni del trucchetto (se ce ne sono) ma nessun effetto aggiuntivo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/sculpt-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/sculpt-spells", "en"), Language = LanguageCode.En, Name = "Sculpt Spells", Description = "You can create pockets of relative safety within the effects of your evocations. When you cast an Evocation spell that affects other creatures that you can see, you can choose a number of them equal to 1 plus the spell’s level. The chosen creatures automatically succeed on their saving throws against the spell, and they take no damage if they would normally take half damage on a successful save." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/sculpt-spells", "it"), Language = LanguageCode.It, Name = "Plasmare Incantesimi", Description = "Il mago può creare sacche di relativa sicurezza all'interno dei suoi incantesimi di invocazione. Quando lancia un incantesimo di invocazione che influenza altre creature che è in grado di vedere, può sceglierne un numero pari a 1 + il livello dell'incantesimo: le creature scelte superano automaticamente il tiro salvezza contro l'incantesimo e, se normalmente subirebbero la metà dei danni con un successo, non subiscono alcun danno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/empowered-evocation"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/empowered-evocation", "en"), Language = LanguageCode.En, Name = "Empowered Evocation", Description = "Whenever you cast a Wizard spell from the Evocation school, you can add your Intelligence modifier to one damage roll of that spell." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/empowered-evocation", "it"), Language = LanguageCode.It, Name = "Invocazione Potenziata", Description = "Ogni volta che lancia un incantesimo da mago della scuola di invocazione, il mago può sommare il suo modificatore di Intelligenza a un tiro per i danni di quell'incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/overchannel"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/overchannel", "en"), Language = LanguageCode.En, Name = "Overchannel", Description = "You can increase the power of your spells. When you cast a Wizard spell with a spell slot of levels 1–5 that deals damage, you can deal maximum damage with that spell on the turn you cast it.\n\nThe first time you do so, you suffer no adverse effect. If you use this feature again before you finish a Long Rest, you take 2d12 Necrotic damage for each level of the spell slot immediately after you cast it. This damage ignores Resistance and Immunity.\n\nEach time you use this feature again before finishing a Long Rest, the Necrotic damage per spell level increases by 1d12." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "evoker/overchannel", "it"), Language = LanguageCode.It, Name = "Saturazione Magica", Description = "Il mago può aumentare la potenza dei suoi incantesimi. Quando lancia un incantesimo da mago che infligge danni con uno slot di livello da 1 a 5, può infliggere con quell'incantesimo i danni massimi nel turno in cui lo lancia.\n\nLa prima volta che lo fa non subisce effetti negativi. Se usa di nuovo questo privilegio prima di completare un riposo lungo, subito dopo aver lanciato l'incantesimo subisce 2d12 danni necrotici per ogni livello dello slot; questi danni ignorano resistenza e immunità.\n\nOgni volta che usa di nuovo questo privilegio prima di completare un riposo lungo, i danni necrotici per livello dell'incantesimo aumentano di 1d12." }
					}
				}
			}
		};
	}
}
