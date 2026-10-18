using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Zone of Truth (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ZoneOfTruth2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "zone-of-truth");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "zone-of-truth", "en"),
					Language = LanguageCode.En,
					Name = "Zone of Truth",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "10 minutes",
					MaterialComponent = null,
					Description = "You create a magical zone that guards against deception in a 15-foot-radius sphere centered on a point of your choice within range. Until the spell ends, a creature that enters the spell's area for the first time on a turn or starts its turn there must make a Charisma saving throw. On a failed save, a creature can't speak a deliberate lie while in the radius. You know whether each creature succeeds or fails on its saving throw.\n\nAn affected creature is aware of the spell and can thus avoid answering questions to which it would normally respond with a lie. Such a creature can remain evasive in its answers as long as it remains within the boundaries of the truth.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "zone-of-truth", "it"),
					Language = LanguageCode.It,
					Name = "Zona di Verità",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore crea una zona magica che protegge dall'inganno, in una sfera del raggio di 4,5 metri centrata su un punto entro gittata a sua scelta. Finché l'incantesimo non termina, una creatura che entra nell'area dell'incantesimo per la prima volta in un turno o vi inizia il proprio turno deve effettuare un tiro salvezza su Carisma. Se lo fallisce, la creatura non può dire una menzogna deliberata finché si trova entro il raggio. L'incantatore sa se ogni creatura supera o fallisce il tiro salvezza.\n\nUna creatura influenzata è consapevole dell'incantesimo e può quindi evitare di rispondere alle domande a cui normalmente risponderebbe con una menzogna. Può restare evasiva nelle sue risposte, purché rimanga entro i confini della verità.",
					HigherLevels = null
				}
			}
		};
	}
}
