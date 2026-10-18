using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dream (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Dream2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dream");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dream", "en"),
					Language = LanguageCode.En,
					Name = "Dream",
					CastingTime = "1 minute",
					Range = "Special",
					Duration = "8 hours",
					MaterialComponent = "a handful of sand, a dab of ink, and a writing quill plucked from a sleeping bird",
					Description = "This spell shapes a creature's dreams. Choose a creature known to you as the target of this spell. The target must be on the same plane of existence as you. Creatures that don't sleep, such as elves, can't be contacted by this spell. You, or a willing creature you touch, enters a trance state, acting as a messenger.\n\nWhile in the trance, the messenger is aware of his or her surroundings, but can't take actions or move.\n\nIf the target is asleep, the messenger appears in the target's dreams and can converse with the target as long as it remains asleep, through the duration of the spell. The messenger can also shape the environment of the dream, creating landscapes, objects, and other images. The messenger can emerge from the trance at any time, ending the effect of the spell early. The target recalls the dream perfectly upon waking. If the target is awake when you cast the spell, the messenger knows it, and can either end the trance (and the spell) or wait for the target to fall asleep, at which point the messenger appears in the target's dreams.\n\nYou can make the messenger appear monstrous and terrifying to the target. If you do, the messenger can deliver a message of no more than ten words and then the target must make a Wisdom saving throw. On a failed save, echoes of the phantasmal monstrosity spawn a nightmare that lasts the duration of the target's sleep and prevents the target from gaining any benefit from that rest. In addition, when the target wakes up, it takes 3d6 psychic damage.\n\nIf you have a body part, lock of hair, clipping from a nail, or similar portion of the target's body, the target makes its saving throw with disadvantage.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dream", "it"),
					Language = LanguageCode.It,
					Name = "Sogno",
					CastingTime = "1 minuto",
					Range = "Speciale",
					Duration = "8 ore",
					MaterialComponent = "una manciata di sabbia, una goccia d'inchiostro e una penna d'oca strappata a un uccello addormentato",
					Description = "Questo incantesimo plasma i sogni di una creatura. L'incantatore sceglie come bersaglio una creatura che conosce. Il bersaglio deve trovarsi sullo stesso piano di esistenza dell'incantatore. Le creature che non dormono, come gli elfi, non possono essere contattate da questo incantesimo. L'incantatore, o una creatura consenziente che tocca, entra in uno stato di trance e agisce come messaggero.\n\nDurante la trance, il messaggero è consapevole di ciò che lo circonda, ma non può compiere azioni né muoversi.\n\nSe il bersaglio sta dormendo, il messaggero compare nei suoi sogni e può conversare con lui finché resta addormentato, per tutta la durata dell'incantesimo. Il messaggero può anche plasmare l'ambiente del sogno, creando paesaggi, oggetti e altre immagini. Può uscire dalla trance in qualsiasi momento, ponendo fine prematuramente all'effetto dell'incantesimo. Al risveglio, il bersaglio ricorda perfettamente il sogno. Se il bersaglio è sveglio quando l'incantatore lancia l'incantesimo, il messaggero lo sa e può porre fine alla trance (e all'incantesimo) oppure attendere che il bersaglio si addormenti; a quel punto, il messaggero compare nei suoi sogni.\n\nL'incantatore può far apparire il messaggero mostruoso e terrificante agli occhi del bersaglio. In tal caso, il messaggero può recapitare un messaggio di non più di dieci parole, dopodiché il bersaglio deve effettuare un tiro salvezza su Saggezza. Se lo fallisce, gli echi della mostruosità spettrale generano un incubo che dura per tutto il sonno del bersaglio e gli impedisce di ottenere qualsiasi beneficio da quel riposo. Inoltre, quando si sveglia, il bersaglio subisce 3d6 danni psichici.\n\nSe l'incantatore possiede una parte del corpo, una ciocca di capelli, un frammento di unghia o una porzione simile del corpo del bersaglio, quest'ultimo effettua il tiro salvezza con svantaggio.",
					HigherLevels = null
				}
			}
		};
	}
}
