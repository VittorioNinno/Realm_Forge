using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Commune with Nature (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CommuneWithNature2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "commune-with-nature");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "commune-with-nature", "en"),
					Language = LanguageCode.En,
					Name = "Commune with Nature",
					CastingTime = "1 minute",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You commune with nature spirits and gain knowledge of the surrounding area. In the outdoors, the spell gives you knowledge of the area within 3 miles of you. In caves and other natural underground settings, the radius is limited to 300 feet. The spell doesn't function where nature has been replaced by construction, such as in castles and settlements.\n\nChoose three of the following facts; you learn those facts as they pertain to the spell's area:\n\n- Locations of settlements\n- Locations of portals to other planes of existence\n- Location of one Challenge Rating 10+ creature (GM's choice) that is a Celestial, an Elemental, a Fey, a Fiend, or an Undead\n- The most prevalent kind of plant, mineral, or Beast (you choose which to learn)\n- Locations of bodies of water\n\nFor example, you could determine the location of a powerful monster in the area, the locations of bodies of water, and the locations of any towns.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "commune-with-nature", "it"),
					Language = LanguageCode.It,
					Name = "Comunione con la Natura",
					CastingTime = "1 minuto",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore entra in comunione con gli spiriti della natura e ottiene conoscenze sull'area circostante. All'aperto, l'incantesimo gli conferisce conoscenze sull'area entro 4,5 km da lui. Nelle caverne e in altri ambienti sotterranei naturali, il raggio è limitato a 90 metri. L'incantesimo non funziona dove la natura è stata sostituita da costruzioni, come nei castelli e negli insediamenti.\n\nL'incantatore sceglie tre dei fatti seguenti e li apprende in relazione all'area dell'incantesimo:\n\n- L'ubicazione degli insediamenti\n- L'ubicazione dei portali verso altri piani di esistenza\n- L'ubicazione di una creatura con Grado di Sfida pari o superiore a 10 (a scelta del DM) che sia un celestiale, un elementale, un folletto, un immondo o un non morto\n- Il tipo più diffuso di pianta, minerale o bestia (l'incantatore sceglie quale apprendere)\n- L'ubicazione delle distese d'acqua\n\nPer esempio, l'incantatore potrebbe determinare l'ubicazione di un mostro potente nell'area, l'ubicazione delle distese d'acqua e l'ubicazione degli eventuali centri abitati.",
					HigherLevels = null
				}
			}
		};
	}
}
