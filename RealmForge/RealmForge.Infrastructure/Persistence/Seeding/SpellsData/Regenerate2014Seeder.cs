using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Regenerate (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Regenerate2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "regenerate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "regenerate", "en"),
					Language = LanguageCode.En,
					Name = "Regenerate",
					CastingTime = "1 minute",
					Range = "Touch",
					Duration = "1 hour",
					MaterialComponent = "a prayer wheel and holy water",
					Description = "You touch a creature and stimulate its natural healing ability. The target regains 4d8 + 15 hit points. For the duration of the spell, the target regains 1 hit point at the start of each of its turns (10 hit points each minute).\n\nThe target's severed body members (fingers, legs, tails, and so on), if any, are restored after 2 minutes. If you have the severed part and hold it to the stump, the spell instantaneously causes the limb to knit to the stump.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "regenerate", "it"),
					Language = LanguageCode.It,
					Name = "Rigenerazione",
					CastingTime = "1 minuto",
					Range = "Contatto",
					Duration = "1 ora",
					MaterialComponent = "una ruota della preghiera e acqua santa",
					Description = "L'incantatore tocca una creatura e ne stimola la capacità naturale di guarigione. Il bersaglio recupera 4d8 + 15 punti ferita. Per la durata dell'incantesimo, il bersaglio recupera 1 punto ferita all'inizio di ogni suo turno (10 punti ferita ogni minuto).\n\nLe eventuali parti del corpo amputate del bersaglio (dita, gambe, code e così via) ricrescono dopo 2 minuti. Se l'incantatore possiede la parte amputata e la tiene accostata al moncherino, l'incantesimo fa saldare istantaneamente l'arto al moncherino.",
					HigherLevels = null
				}
			}
		};
	}
}
