using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Compulsion (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Compulsion2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "compulsion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "compulsion", "en"),
					Language = LanguageCode.En,
					Name = "Compulsion",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Each creature of your choice that you can see within range must succeed on a Wisdom saving throw or have the Charmed condition until the spell ends.\n\nFor the duration, you can take a Bonus Action to designate a direction that is horizontal to you. Each Charmed target must use as much of its movement as possible to move in that direction on its next turn, taking the safest route. After moving in this way, a target repeats the save, ending the spell on itself on a success.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "compulsion", "it"),
					Language = LanguageCode.It,
					Name = "Compulsione",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Ogni creatura a scelta dell'incantatore entro gittata che egli è in grado di vedere deve superare un tiro salvezza su Saggezza, altrimenti è affascinata finché l'incantesimo non termina.\n\nPer la durata, l'incantatore può effettuare un'azione bonus per indicare una direzione orizzontale rispetto a sé. Ogni bersaglio affascinato deve usare quanto più movimento possibile per muoversi in quella direzione nel suo turno successivo, seguendo il percorso più sicuro. Dopo essersi mosso in questo modo, un bersaglio ripete il tiro salvezza e, se lo supera, l'incantesimo termina su di lui.",
					HigherLevels = null
				}
			}
		};
	}
}
