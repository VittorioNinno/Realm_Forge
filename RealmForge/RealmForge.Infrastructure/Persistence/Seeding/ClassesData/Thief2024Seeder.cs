using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Thief (rogue, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Thief2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "thief");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Rogue2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "thief", "en"), Language = LanguageCode.En, Name = "Thief", Description = "A mix of burglar, treasure hunter, and explorer, you are the epitome of an adventurer. In addition to improving your agility and stealth, you gain abilities useful for delving into ruins and getting maximum benefit from the magic items you find there." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "thief", "it"), Language = LanguageCode.It, Name = "Furfante", Description = "Un misto di scassinatore, cacciatore di tesori ed esploratore: il furfante è l'avventuriero per eccellenza. Oltre ad affinare l'agilità e la furtività, ottiene capacità utili per esplorare le rovine e trarre il massimo dagli oggetti magici che vi trova." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/fast-hands"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/fast-hands", "en"), Language = LanguageCode.En, Name = "Fast Hands", Description = "As a Bonus Action, you can do one of the following.\n\n**Sleight of Hand.** Make a Dexterity (Sleight of Hand) check to pick a lock or disarm a trap with Thieves’ Tools or to pick a pocket.\n\n**Use an Object.** Take the Utilize action, or take the Magic action to use a magic item that requires that action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/fast-hands", "it"), Language = LanguageCode.It, Name = "Mani Veloci", Description = "Come azione bonus, il ladro può fare una delle cose seguenti.\n\n**Rapidità di mano.** Effettuare una prova di Destrezza (Rapidità di mano) per scassinare una serratura o disattivare una trappola con gli arnesi da scasso, oppure per borseggiare qualcuno.\n\n**Usare un oggetto.** Effettuare l'azione di Utilizzo, oppure l'azione di Magia per usare un oggetto magico che richiede quell'azione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/second-story-work"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/second-story-work", "en"), Language = LanguageCode.En, Name = "Second-Story Work", Description = "You’ve trained to get into especially hard-to-reach places, granting you these benefits.\n\n**Climber.** You gain a Climb Speed equal to your Speed.\n\n**Jumper.** You can determine your jump distance using your Dexterity rather than your Strength." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/second-story-work", "it"), Language = LanguageCode.It, Name = "Lavoro al Secondo Piano", Description = "Il ladro si è addestrato a raggiungere i luoghi più inaccessibili e ottiene i benefici seguenti.\n\n**Scalatore.** Il ladro ottiene una velocità di scalare pari alla sua velocità.\n\n**Saltatore.** Il ladro può determinare la distanza dei suoi salti usando la Destrezza anziché la Forza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/supreme-sneak"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 9,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/supreme-sneak", "en"), Language = LanguageCode.En, Name = "Supreme Sneak", Description = "You gain the following Cunning Strike option.\n\n**Stealth Attack (Cost: 1d6).** If you have the Hide action's Invisible condition, this attack doesn't end that condition on you if you end the turn behind Three-Quarters Cover or Total Cover." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/supreme-sneak", "it"), Language = LanguageCode.It, Name = "Furtività Suprema", Description = "Il ladro ottiene l'opzione di Colpo astuto seguente.\n\n**Attacco nascosto (costo: 1d6).** Se il ladro è invisibile grazie all'azione Nascondersi, questo attacco non pone fine a quella condizione, purché termini il turno dietro copertura a tre quarti o totale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/use-magic-device"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 13,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/use-magic-device", "en"), Language = LanguageCode.En, Name = "Use Magic Device", Description = "You've learned how to maximize use of magic items, granting you the following benefits.\n\n**Attunement.** You can attune to up to four magic items at once.\n\n**Charges.** Whenever you use a magic item property that expends charges, roll 1d6. On a roll of 6, you use the property without expending the charges.\n\n**Scrolls.** You can use any Spell Scroll, using Intelligence as your spellcasting ability for the spell. If the spell is a cantrip or a level 1 spell, you can cast it reliably. If the scroll contains a higher-level spell, you must first succeed on an Intelligence (Arcana) check (DC 10 plus the spell's level). On a successful check, you cast the spell from the scroll. On a failed check, the scroll disintegrates." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/use-magic-device", "it"), Language = LanguageCode.It, Name = "Usare Oggetti Magici", Description = "Il ladro ha imparato a sfruttare al massimo gli oggetti magici e ottiene i benefici seguenti.\n\n**Sintonia.** Il ladro può essere in sintonia con un massimo di quattro oggetti magici contemporaneamente.\n\n**Cariche.** Ogni volta che usa una proprietà di un oggetto magico che spende cariche, il ladro tira 1d6: con un 6, usa la proprietà senza spendere le cariche.\n\n**Pergamene.** Il ladro può usare qualsiasi pergamena magica, usando l'Intelligenza come caratteristica da incantatore per l'incantesimo. Se l'incantesimo è un trucchetto o di 1° livello, può lanciarlo senza problemi. Se la pergamena contiene un incantesimo di livello superiore, deve prima superare una prova di Intelligenza (Arcano) con CD pari a 10 + il livello dell'incantesimo: se la supera, lancia l'incantesimo dalla pergamena; se la fallisce, la pergamena si disintegra." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/thiefs-reflexes"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/thiefs-reflexes", "en"), Language = LanguageCode.En, Name = "Thief's Reflexes", Description = "You are adept at laying ambushes and quickly escaping danger. You can take two turns during the first round of any combat. You take your first turn at your normal Initiative and your second turn at your Initiative minus 10." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "thief/thiefs-reflexes", "it"), Language = LanguageCode.It, Name = "Riflessi da Furfante", Description = "Il ladro è abile nel tendere agguati e nel sottrarsi rapidamente al pericolo: durante il primo round di qualsiasi combattimento può svolgere due turni. Svolge il primo al suo normale punteggio di iniziativa e il secondo all'iniziativa meno 10." }
					}
				}
			}
		};
	}
}
