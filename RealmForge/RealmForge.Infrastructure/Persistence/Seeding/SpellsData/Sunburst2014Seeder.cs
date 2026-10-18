using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sunburst (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Sunburst2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sunburst");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sunburst", "en"),
					Language = LanguageCode.En,
					Name = "Sunburst",
					CastingTime = "1 action",
					Range = "150 feet",
					Duration = "Instantaneous",
					MaterialComponent = "fire and a piece of sunstone",
					Description = "Brilliant sunlight flashes in a 60-foot radius centered on a point you choose within range. Each creature in that light must make a Constitution saving throw. On a failed save, a creature takes 12d6 radiant damage and is blinded for 1 minute. On a successful save, it takes half as much damage and isn't blinded by this spell. Undead and oozes have disadvantage on this saving throw.\n\nA creature blinded by this spell makes another Constitution saving throw at the end of each of its turns. On a successful save, it is no longer blinded.\n\nThis spell dispels any darkness in its area that was created by a spell.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sunburst", "it"),
					Language = LanguageCode.It,
					Name = "Esplosione Solare",
					CastingTime = "1 azione",
					Range = "45 metri",
					Duration = "Istantanea",
					MaterialComponent = "del fuoco e un frammento di pietra del sole",
					Description = "Una luce solare abbagliante sfolgora in un raggio di 18 metri centrato su un punto entro gittata scelto dall'incantatore. Ogni creatura investita da quella luce deve effettuare un tiro salvezza su Costituzione. Se lo fallisce, la creatura subisce 12d6 danni radiosi ed è accecata per 1 minuto. Se lo supera, subisce la metà di quei danni e non è accecata da questo incantesimo. I non morti e le melme subiscono svantaggio a questo tiro salvezza.\n\nUna creatura accecata da questo incantesimo effettua un altro tiro salvezza su Costituzione alla fine di ogni suo turno. Se lo supera, non è più accecata.\n\nQuesto incantesimo dissolve qualsiasi oscurità creata da un incantesimo che si trovi nella sua area.",
					HigherLevels = null
				}
			}
		};
	}
}
