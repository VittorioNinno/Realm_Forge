using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Magic Jar (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MagicJar2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magic-jar");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magic-jar", "en"),
					Language = LanguageCode.En,
					Name = "Magic Jar",
					CastingTime = "1 minute",
					Range = "Self",
					Duration = "Until dispelled",
					MaterialComponent = "a gem, crystal, reliquary, or some other ornamental container worth at least 500 gp",
					Description = "Your body falls into a catatonic state as your soul leaves it and enters the container you used for the spell's material component. While your soul inhabits the container, you are aware of your surroundings as if you were in the container's space. You can't move or use reactions. The only action you can take is to project your soul up to 100 feet out of the container, either returning to your living body (and ending the spell) or attempting to possess a humanoid's body.\n\nYou can attempt to possess any humanoid within 100 feet of you that you can see (creatures warded by a protection from evil and good or magic circle spell can't be possessed). The target must make a Charisma saving throw. On a failure, your soul moves into the target's body, and the target's soul becomes trapped in the container. On a success, the target resists your efforts to possess it, and you can't attempt to possess it again for 24 hours.\n\nOnce you possess a creature's body, you control it. Your game statistics are replaced by the statistics of the creature, though you retain your alignment and your Intelligence, Wisdom, and Charisma scores. You retain the benefit of your own class features. If the target has any class levels, you can't use any of its class features.\n\nMeanwhile, the possessed creature's soul can perceive from the container using its own senses, but it can't move or take actions at all.\n\nWhile possessing a body, you can use your action to return from the host body to the container if it is within 100 feet of you, returning the host creature's soul to its body. If the host body dies while you're in it, the creature dies, and you must make a Charisma saving throw against your own spellcasting DC. On a success, you return to the container if it is within 100 feet of you. Otherwise, you die.\n\nIf the container is destroyed or the spell ends, your soul immediately returns to your body. If your body is more than 100 feet away from you or if your body is dead when you attempt to return to it, you die. If another creature's soul is in the container when it is destroyed, the creature's soul returns to its body if the body is alive and within 100 feet. Otherwise, that creature dies.\n\nWhen the spell ends, the container is destroyed.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "magic-jar", "it"),
					Language = LanguageCode.It,
					Name = "Giara Magica",
					CastingTime = "1 minuto",
					Range = "Incantatore",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "una gemma, un cristallo, un reliquiario o un altro contenitore ornamentale del valore di almeno 500 mo",
					Description = "Il corpo dell'incantatore cade in uno stato catatonico mentre la sua anima lo abbandona ed entra nel contenitore usato come componente materiale dell'incantesimo. Finché la sua anima abita il contenitore, l'incantatore è consapevole di ciò che lo circonda come se si trovasse nello spazio del contenitore. Non può muoversi né usare reazioni. L'unica azione che può compiere è proiettare la propria anima fino a 30 metri fuori dal contenitore, per tornare nel proprio corpo vivente (ponendo fine all'incantesimo) oppure per tentare di possedere il corpo di un umanoide.\n\nL'incantatore può tentare di possedere qualsiasi umanoide entro 30 metri da lui che sia in grado di vedere (le creature protette da un incantesimo protezione dal bene e dal male o cerchio magico non possono essere possedute). Il bersaglio deve effettuare un tiro salvezza su Carisma. Se lo fallisce, l'anima dell'incantatore si trasferisce nel corpo del bersaglio e l'anima del bersaglio resta intrappolata nel contenitore. Se lo supera, il bersaglio resiste ai tentativi di possessione e l'incantatore non può tentare di possederlo di nuovo per 24 ore.\n\nUna volta posseduto il corpo di una creatura, l'incantatore lo controlla. Le sue statistiche di gioco vengono sostituite da quelle della creatura, ma conserva il proprio allineamento e i propri punteggi di Intelligenza, Saggezza e Carisma. Conserva i benefici dei propri privilegi di classe. Se il bersaglio ha dei livelli di classe, l'incantatore non può usare alcun privilegio di classe del bersaglio.\n\nNel frattempo, l'anima della creatura posseduta può percepire ciò che la circonda dal contenitore usando i propri sensi, ma non può muoversi né compiere alcuna azione.\n\nMentre possiede un corpo, l'incantatore può usare la sua azione per tornare dal corpo ospite al contenitore, se questo si trova entro 30 metri da lui, restituendo l'anima della creatura ospite al suo corpo. Se il corpo ospite muore mentre l'incantatore si trova al suo interno, la creatura muore e l'incantatore deve effettuare un tiro salvezza su Carisma contro la propria CD degli incantesimi. Se lo supera, torna nel contenitore, se questo si trova entro 30 metri da lui. Altrimenti, muore.\n\nSe il contenitore viene distrutto o l'incantesimo termina, l'anima dell'incantatore torna immediatamente nel suo corpo. Se il suo corpo si trova a più di 30 metri da lui o è morto quando tenta di farvi ritorno, l'incantatore muore. Se l'anima di un'altra creatura si trova nel contenitore quando questo viene distrutto, l'anima di quella creatura torna nel suo corpo, se il corpo è vivo e si trova entro 30 metri. Altrimenti, quella creatura muore.\n\nQuando l'incantesimo termina, il contenitore viene distrutto.",
					HigherLevels = null
				}
			}
		};
	}
}
