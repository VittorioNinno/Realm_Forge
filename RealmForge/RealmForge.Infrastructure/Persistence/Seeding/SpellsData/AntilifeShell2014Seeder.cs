using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Antilife Shell (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AntilifeShell2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "antilife-shell");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "antilife-shell", "en"),
					Language = LanguageCode.En,
					Name = "Antilife Shell",
					CastingTime = "1 action",
					Range = "Self (10-foot radius)",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "A shimmering barrier extends out from you in a 10-foot radius and moves with you, remaining centered on you and hedging out creatures other than undead and constructs. The barrier lasts for the duration.\n\nThe barrier prevents an affected creature from passing or reaching through. An affected creature can cast spells or make attacks with ranged or reach weapons through the barrier.\n\nIf you move so that an affected creature is forced to pass through the barrier, the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "antilife-shell", "it"),
					Language = LanguageCode.It,
					Name = "Guscio Anti-vita",
					CastingTime = "1 azione",
					Range = "Incantatore (raggio di 3 metri)",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "Una barriera scintillante si estende dall'incantatore in un raggio di 3 metri e si sposta con lui, rimanendo centrata su di lui e tenendo lontane tutte le creature tranne i non morti e i costrutti. La barriera dura per tutta la durata dell'incantesimo.\n\nLa barriera impedisce a una creatura influenzata di attraversarla o di allungarsi oltre di essa. Una creatura influenzata può comunque lanciare incantesimi o effettuare attacchi con armi a distanza o con portata attraverso la barriera.\n\nSe l'incantatore si muove in modo tale da costringere una creatura influenzata ad attraversare la barriera, l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
