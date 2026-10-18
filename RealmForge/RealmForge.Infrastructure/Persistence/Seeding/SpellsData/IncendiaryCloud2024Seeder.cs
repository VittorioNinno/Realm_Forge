using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Incendiary Cloud (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class IncendiaryCloud2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "incendiary-cloud");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 8,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "incendiary-cloud", "en"),
					Language = LanguageCode.En,
					Name = "Incendiary Cloud",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "A swirling cloud of embers and smoke fills a 20-foot-radius Sphere centered on a point within range. The cloud's area is Heavily Obscured. It lasts for the duration or until a strong wind (like that created by *Gust of Wind*) disperses it.\n\nWhen the cloud appears, each creature in it makes a Dexterity saving throw, taking 10d8 Fire damage on a failed save or half as much damage on a successful one. A creature must also make this save when the Sphere moves into its space and when it enters the Sphere or ends its turn there. A creature makes this save only once per turn. The cloud moves 10 feet away from you in a direction you choose at the start of each of your turns.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "incendiary-cloud", "it"),
					Language = LanguageCode.It,
					Name = "Nube Incendiaria",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Una nube vorticante di braci e fumo riempie una sfera del raggio di 6 metri centrata su un punto entro gittata. L'area della nube è pesantemente oscurata. La nube permane per la durata o finché un vento forte (come quello creato da *folata di vento*) non la disperde.\n\nQuando la nube compare, ogni creatura al suo interno effettua un tiro salvezza su Destrezza, subendo 10d8 danni da fuoco se lo fallisce, o la metà di quei danni se lo supera. Una creatura deve effettuare questo tiro salvezza anche quando la sfera si sposta nel suo spazio e quando entra nella sfera o vi termina il proprio turno. Una creatura effettua questo tiro salvezza soltanto una volta per turno. All'inizio di ogni turno dell'incantatore, la nube si allontana di 3 metri da lui in una direzione a sua scelta.",
					HigherLevels = null
				}
			}
		};
	}
}
