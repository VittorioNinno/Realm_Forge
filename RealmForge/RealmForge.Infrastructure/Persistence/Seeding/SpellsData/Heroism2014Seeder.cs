using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Heroism (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Heroism2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "heroism");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "heroism", "en"),
					Language = LanguageCode.En,
					Name = "Heroism",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "A willing creature you touch is imbued with bravery. Until the spell ends, the creature is immune to being frightened and gains temporary hit points equal to your spellcasting ability modifier at the start of each of its turns. When the spell ends, the target loses any remaining temporary hit points from this spell.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "heroism", "it"),
					Language = LanguageCode.It,
					Name = "Eroismo",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Una creatura consenziente toccata dall'incantatore viene infusa di coraggio. Finché l'incantesimo non termina, la creatura è immune alla condizione di spaventato e, all'inizio di ogni suo turno, ottiene un numero di punti ferita temporanei pari al modificatore di caratteristica da incantatore dell'incantatore. Quando l'incantesimo termina, il bersaglio perde gli eventuali punti ferita temporanei rimanenti conferiti da questo incantesimo.",
					HigherLevels = null
				}
			}
		};
	}
}
