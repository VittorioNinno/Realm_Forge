using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Animal Messenger (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AnimalMessenger2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animal-messenger");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animal-messenger", "en"),
					Language = LanguageCode.En,
					Name = "Animal Messenger",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "24 hours",
					MaterialComponent = "a morsel of food",
					Description = "By means of this spell, you use an animal to deliver a message. Choose a Tiny beast you can see within range, such as a squirrel, a blue jay, or a bat. You specify a location, which you must have visited, and a recipient who matches a general description, such as \"a man or woman dressed in the uniform of the town guard\" or \"a red-haired dwarf wearing a pointed hat.\" You also speak a message of up to twenty-five words. The target beast travels for the duration of the spell toward the specified location, covering about 50 miles per 24 hours for a flying messenger, or 25 miles for other animals.\n\nWhen the messenger arrives, it delivers your message to the creature that you described, replicating the sound of your voice. The messenger speaks only to a creature matching the description you gave. If the messenger doesn't reach its destination before the spell ends, the message is lost, and the beast makes its way back to where you cast this spell.",
					HigherLevels = "If you cast this spell using a spell slot of 3rd level or higher, the duration of the spell increases by 48 hours for each slot level above 2nd."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animal-messenger", "it"),
					Language = LanguageCode.It,
					Name = "Animale Messaggero",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "24 ore",
					MaterialComponent = "un boccone di cibo",
					Description = "Con questo incantesimo, l'incantatore si serve di un animale per recapitare un messaggio. Sceglie una bestia Minuscola entro gittata che sia in grado di vedere, come uno scoiattolo, una ghiandaia o un pipistrello. Indica un luogo, in cui deve essere già stato, e un destinatario che corrisponda a una descrizione generica, come \"un uomo o una donna con l'uniforme della guardia cittadina\" o \"un nano dai capelli rossi con un cappello a punta\". Pronuncia inoltre un messaggio di massimo venticinque parole. Per la durata dell'incantesimo, la bestia bersaglio viaggia verso il luogo indicato, percorrendo circa 75 km ogni 24 ore se è un messaggero volante, o 37,5 km se è un altro animale.\n\nQuando arriva, il messaggero recapita il messaggio dell'incantatore alla creatura descritta, riproducendo il suono della sua voce. Il messaggero parla soltanto a una creatura che corrisponde alla descrizione fornita. Se non raggiunge la destinazione prima che l'incantesimo termini, il messaggio va perduto e la bestia torna al luogo in cui l'incantesimo è stato lanciato.",
					HigherLevels = "Se l'incantatore lancia questo incantesimo usando uno slot incantesimo di 3° livello o superiore, la durata dell'incantesimo aumenta di 48 ore per ogni livello dello slot superiore al 2°."
				}
			}
		};
	}
}
