using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sunbeam (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Sunbeam2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sunbeam");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sunbeam", "en"),
					Language = LanguageCode.En,
					Name = "Sunbeam",
					CastingTime = "1 action",
					Range = "Self (60-foot line)",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a magnifying glass",
					Description = "A beam of brilliant light flashes out from your hand in a 5-foot-wide, 60-foot-long line. Each creature in the line must make a Constitution saving throw. On a failed save, a creature takes 6d8 radiant damage and is blinded until your next turn. On a successful save, it takes half as much damage and isn't blinded by this spell. Undead and oozes have disadvantage on this saving throw.\n\nYou can create a new line of radiance as your action on any turn until the spell ends.\n\nFor the duration, a mote of brilliant radiance shines in your hand. It sheds bright light in a 30-foot radius and dim light for an additional 30 feet. This light is sunlight.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sunbeam", "it"),
					Language = LanguageCode.It,
					Name = "Bagliore Solare",
					CastingTime = "1 azione",
					Range = "Incantatore (linea di 18 metri)",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una lente d'ingrandimento",
					Description = "Un raggio di luce brillante scaturisce dalla mano dell'incantatore in una linea larga 1,5 metri e lunga 18 metri. Ogni creatura nella linea deve effettuare un tiro salvezza su Costituzione. Se lo fallisce, la creatura subisce 6d8 danni radiosi ed è accecata fino al turno successivo dell'incantatore. Se lo supera, subisce la metà di quei danni e non è accecata da questo incantesimo. I non morti e le melme subiscono svantaggio a questo tiro salvezza.\n\nL'incantatore può creare una nuova linea di splendore come sua azione in qualsiasi turno, finché l'incantesimo non termina.\n\nPer la durata, una scintilla di splendore abbagliante risplende nella mano dell'incantatore. Emette luce intensa in un raggio di 9 metri e luce fioca per ulteriori 9 metri. Questa luce è luce solare.",
					HigherLevels = null
				}
			}
		};
	}
}
