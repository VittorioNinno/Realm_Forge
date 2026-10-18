using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Animal Messenger (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AnimalMessenger2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animal-messenger");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animal-messenger", "en"),
					Language = LanguageCode.En,
					Name = "Animal Messenger",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "24 hours",
					MaterialComponent = "a morsel of food",
					Description = "A Tiny Beast of your choice that you can see within range must succeed on a Charisma saving throw, or it attempts to deliver a message for you (if the target's Challenge Rating isn't 0, it automatically succeeds). You specify a location you have visited and a recipient who matches a general description, such as \"a person dressed in the uniform of the town guard\" or \"a red-haired dwarf wearing a pointed hat.\" You also communicate a message of up to twenty-five words. The Beast travels for the duration toward the specified location, covering about 25 miles per 24 hours or 50 miles if the Beast can fly.\n\nWhen the Beast arrives, it delivers your message to the creature that you described, mimicking your communication. If the Beast doesn't reach its destination before the spell ends, the message is lost, and the Beast returns to where you cast the spell.",
					HigherLevels = "The spell's duration increases by 48 hours for each spell slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "animal-messenger", "it"),
					Language = LanguageCode.It,
					Name = "Animale Messaggero",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "24 ore",
					MaterialComponent = "un boccone di cibo",
					Description = "Una bestia Minuscola a scelta dell'incantatore, che l'incantatore è in grado di vedere entro gittata, deve superare un tiro salvezza su Carisma, altrimenti tenta di consegnare un messaggio per conto suo (se il Grado di Sfida del bersaglio non è 0, il tiro riesce automaticamente). L'incantatore specifica un luogo che ha già visitato e un destinatario che corrisponda a una descrizione generica, come \"una persona che indossa l'uniforme della guardia cittadina\" o \"un nano dai capelli rossi con un cappello a punta\". Comunica inoltre un messaggio di massimo venticinque parole. Per la durata, la bestia si dirige verso il luogo indicato, percorrendo circa 75 km ogni 24 ore, o 150 km se è in grado di volare.\n\nQuando la bestia arriva, consegna il messaggio alla creatura descritta dall'incantatore, imitandone le parole. Se la bestia non raggiunge la destinazione prima che l'incantesimo termini, il messaggio va perduto e la bestia ritorna nel luogo in cui l'incantesimo è stato lanciato.",
					HigherLevels = "La durata dell'incantesimo aumenta di 48 ore per ogni livello dello slot incantesimo superiore al 2°."
				}
			}
		};
	}
}
