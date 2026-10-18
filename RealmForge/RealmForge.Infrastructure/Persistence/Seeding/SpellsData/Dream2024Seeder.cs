using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dream (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Dream2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dream");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dream", "en"),
					Language = LanguageCode.En,
					Name = "Dream",
					CastingTime = "1 minute",
					Range = "Special",
					Duration = "8 hours",
					MaterialComponent = "a handful of sand",
					Description = "You target a creature you know on the same plane of existence. You or a willing creature you touch enters a trance state to act as a dream messenger. While in the trance, the messenger is Incapacitated and has a Speed of 0.\n\nIf the target is asleep, the messenger appears in the target's dreams and can converse with the target as long as it remains asleep, through the spell's duration. The messenger can also shape the dream's environment, creating landscapes, objects, and other images. The messenger can emerge from the trance at any time, ending the spell. The target recalls the dream perfectly upon waking.\n\nIf the target is awake when you cast the spell, the messenger knows it and can either end the trance (and the spell) or wait for the target to sleep, at which point the messenger enters its dreams.\n\nYou can make the messenger terrifying to the target. If you do so, the messenger can deliver a message of no more than ten words, and then the target makes a Wisdom saving throw. On a failed save, the target gains no benefit from its rest, and it takes 3d6 Psychic damage when it wakes up.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "dream", "it"),
					Language = LanguageCode.It,
					Name = "Sogno",
					CastingTime = "1 minuto",
					Range = "Speciale",
					Duration = "8 ore",
					MaterialComponent = "una manciata di sabbia",
					Description = "L'incantatore sceglie come bersaglio una creatura che conosce e che si trova sullo stesso piano di esistenza. L'incantatore o una creatura consenziente da lui toccata entra in uno stato di trance per fungere da messaggero onirico. Durante la trance, il messaggero è incapacitato e ha velocità 0.\n\nSe il bersaglio sta dormendo, il messaggero compare nei suoi sogni e può conversare con lui finché resta addormentato, per la durata dell'incantesimo. Il messaggero può anche plasmare l'ambiente del sogno, creando paesaggi, oggetti e altre immagini. Il messaggero può uscire dalla trance in qualsiasi momento, ponendo fine all'incantesimo. Al risveglio, il bersaglio ricorda perfettamente il sogno.\n\nSe il bersaglio è sveglio quando l'incantatore lancia l'incantesimo, il messaggero lo sa e può porre fine alla trance (e all'incantesimo) oppure attendere che il bersaglio si addormenti; a quel punto, il messaggero entra nei suoi sogni.\n\nL'incantatore può rendere il messaggero terrificante agli occhi del bersaglio. In tal caso, il messaggero può consegnare un messaggio di non più di dieci parole, dopodiché il bersaglio effettua un tiro salvezza su Saggezza. Se lo fallisce, il bersaglio non ottiene alcun beneficio dal suo riposo e subisce 3d6 danni psichici al risveglio.",
					HigherLevels = null
				}
			}
		};
	}
}
