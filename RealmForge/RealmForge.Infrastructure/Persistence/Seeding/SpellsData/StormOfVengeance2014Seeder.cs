using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Storm of Vengeance (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class StormOfVengeance2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "storm-of-vengeance");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 9,
			School = SpellSchool.Conjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "storm-of-vengeance", "en"),
					Language = LanguageCode.En,
					Name = "Storm of Vengeance",
					CastingTime = "1 action",
					Range = "Sight",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "A churning storm cloud forms, centered on a point you can see and spreading to a radius of 360 feet. Lightning flashes in the area, thunder booms, and strong winds roar. Each creature under the cloud (no more than 5,000 feet beneath the cloud) when it appears must make a Constitution saving throw. On a failed save, a creature takes 2d6 thunder damage and becomes deafened for 5 minutes.\n\nEach round you maintain concentration on this spell, the storm produces additional effects on your turn.\n\n***Round 2.*** Acidic rain falls from the cloud. Each creature and object under the cloud takes 1d6 acid damage.\n\n***Round 3.*** You call six bolts of lightning from the cloud to strike six creatures or objects of your choice beneath the cloud. A given creature or object can't be struck by more than one bolt. A struck creature must make a Dexterity saving throw. The creature takes 10d6 lightning damage on a failed save, or half as much damage on a successful one.\n\n***Round 4.*** Hailstones rain down from the cloud. Each creature under the cloud takes 2d6 bludgeoning damage.\n\n***Round 5-10.*** Gusts and freezing rain assail the area under the cloud. The area becomes difficult terrain and is heavily obscured. Each creature there takes 1d6 cold damage. Ranged weapon attacks in the area are impossible. The wind and rain count as a severe distraction for the purposes of maintaining concentration on spells. Finally, gusts of strong wind (ranging from 20 to 50 miles per hour) automatically disperse fog, mists, and similar phenomena in the area, whether mundane or magical.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "storm-of-vengeance", "it"),
					Language = LanguageCode.It,
					Name = "Tempesta di Vendetta",
					CastingTime = "1 azione",
					Range = "Vista",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Si forma una nube temporalesca ribollente, centrata su un punto che l'incantatore è in grado di vedere e che si estende fino a un raggio di 108 metri. Nell'area balenano fulmini, rimbombano tuoni e ruggiscono venti forti. Ogni creatura sotto la nube (a non più di 1.500 metri sotto di essa) quando la nube compare deve effettuare un tiro salvezza su Costituzione. Se lo fallisce, la creatura subisce 2d6 danni da tuono ed è assordata per 5 minuti.\n\nA ogni round in cui l'incantatore mantiene la concentrazione su questo incantesimo, la tempesta produce effetti aggiuntivi nel suo turno.\n\n***Round 2.*** Dalla nube cade una pioggia acida. Ogni creatura e oggetto sotto la nube subisce 1d6 danni da acido.\n\n***Round 3.*** L'incantatore richiama dalla nube sei fulmini che colpiscono sei creature od oggetti a sua scelta sotto la nube. Una stessa creatura o uno stesso oggetto non può essere colpito da più di un fulmine. Una creatura colpita deve effettuare un tiro salvezza su Destrezza. Subisce 10d6 danni da fulmine se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\n***Round 4.*** Dalla nube piovono chicchi di grandine. Ogni creatura sotto la nube subisce 2d6 danni contundenti.\n\n***Round 5-10.*** Raffiche di vento e pioggia gelata investono l'area sotto la nube. L'area diventa terreno difficile ed è pesantemente oscurata. Ogni creatura che vi si trova subisce 1d6 danni da freddo. Gli attacchi con armi a distanza nell'area sono impossibili. Il vento e la pioggia contano come una grave distrazione ai fini del mantenimento della concentrazione sugli incantesimi. Infine, le raffiche di vento forte (da 30 a 75 km orari) disperdono automaticamente nebbie, foschie e fenomeni simili nell'area, siano essi comuni o magici.",
					HigherLevels = null
				}
			}
		};
	}
}
