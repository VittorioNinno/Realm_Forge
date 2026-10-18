using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Incendiary Cloud (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class IncendiaryCloud2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "incendiary-cloud");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "incendiary-cloud", "en"),
					Language = LanguageCode.En,
					Name = "Incendiary Cloud",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "A swirling cloud of smoke shot through with white-hot embers appears in a 20-foot-radius sphere centered on a point within range. The cloud spreads around corners and is heavily obscured. It lasts for the duration or until a wind of moderate or greater speed (at least 10 miles per hour) disperses it.\n\nWhen the cloud appears, each creature in it must make a Dexterity saving throw. A creature takes 10d8 fire damage on a failed save, or half as much damage on a successful one. A creature must also make this saving throw when it enters the spell's area for the first time on a turn or ends its turn there.\n\nThe cloud moves 10 feet directly away from you in a direction that you choose at the start of each of your turns.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "incendiary-cloud", "it"),
					Language = LanguageCode.It,
					Name = "Nube Incendiaria",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Una nube vorticante di fumo, attraversata da braci incandescenti, compare in una sfera del raggio di 6 metri centrata su un punto entro gittata. La nube si propaga dietro gli angoli ed è pesantemente oscurata. Dura per la durata o finché un vento di velocità moderata o superiore (almeno 15 km orari) non la disperde.\n\nQuando la nube compare, ogni creatura al suo interno deve effettuare un tiro salvezza su Destrezza. Una creatura subisce 10d8 danni da fuoco se fallisce il tiro salvezza, o la metà di quei danni se lo supera. Una creatura deve effettuare questo tiro salvezza anche quando entra nell'area dell'incantesimo per la prima volta in un turno o vi termina il proprio turno.\n\nAll'inizio di ogni turno dell'incantatore, la nube si allontana direttamente da lui di 3 metri, in una direzione da lui scelta.",
					HigherLevels = null
				}
			}
		};
	}
}
