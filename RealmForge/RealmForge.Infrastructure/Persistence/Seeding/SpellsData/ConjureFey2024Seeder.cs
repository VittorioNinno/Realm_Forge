using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Fey (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConjureFey2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-fey");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-fey", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Fey",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You conjure a Medium spirit from the Feywild in an unoccupied space you can see within range. The spirit lasts for the duration, and it looks like a Fey creature of your choice. When the spirit appears, you can make one melee spell attack against a creature within 5 feet of it. On a hit, the target takes Psychic damage equal to 3d12 plus your spellcasting ability modifier, and the target has the Frightened condition until the start of your next turn, with both you and the spirit as the source of the fear.\n\nAs a Bonus Action on your later turns, you can teleport the spirit to an unoccupied space you can see within 30 feet of the space it left and make the attack against a creature within 5 feet of it.",
					HigherLevels = "The damage increases by 1d12 for each spell slot level above 6."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-fey", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Folletto",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore evoca uno spirito Medio dalla Selva Fatata in uno spazio libero entro gittata che è in grado di vedere. Lo spirito permane per la durata e ha l'aspetto di una creatura folletto a scelta dell'incantatore. Quando lo spirito compare, l'incantatore può effettuare un attacco con incantesimo in mischia contro una creatura entro 1,5 metri dallo spirito. Se colpisce, il bersaglio subisce danni psichici pari a 3d12 più il modificatore di caratteristica da incantatore dell'incantatore ed è spaventato fino all'inizio del turno successivo dell'incantatore; sia l'incantatore sia lo spirito sono la fonte della paura.\n\nCome azione bonus nei turni successivi, l'incantatore può teletrasportare lo spirito in uno spazio libero che è in grado di vedere entro 9 metri dallo spazio che lo spirito ha lasciato ed effettuare l'attacco contro una creatura entro 1,5 metri da esso.",
					HigherLevels = "I danni aumentano di 1d12 per ogni livello dello slot incantesimo superiore al 6°."
				}
			}
		};
	}
}
