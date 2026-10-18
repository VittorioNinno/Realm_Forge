using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Fount of Moonlight (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class FountOfMoonlight2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fount-of-moonlight");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 4,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fount-of-moonlight", "en"),
					Language = LanguageCode.En,
					Name = "Fount of Moonlight",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You glow with the chill radiance of the moon until the spell ends. The glow sheds Bright Light out to 20 feet from you and Dim Light for 20 feet beyond that, and while it lasts you gain these benefits:\n\n- You have Resistance to Radiant damage.\n- Your melee attacks add 2d6 Radiant damage whenever they hit.\n- When a creature you can see within 60 feet of you damages you, you can respond with your Reaction, forcing that creature to attempt a Constitution saving throw. If it fails, it is Blinded until your next turn ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "fount-of-moonlight", "it"),
					Language = LanguageCode.It,
					Name = "Fonte di Luce Lunare",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore risplende del gelido chiarore della luna finché l'incantesimo non termina. Il bagliore emana luce intensa fino a 6 metri da lui e luce fioca per altri 6 metri oltre quel limite, e finché dura l'incantatore ottiene questi benefici:\n\n- Ha resistenza ai danni radiosi.\n- I suoi attacchi in mischia aggiungono 2d6 danni radiosi ogni volta che colpiscono.\n- Quando una creatura visibile entro 18 metri gli infligge danni, l'incantatore può rispondere con la propria reazione, costringendo quella creatura a tentare un tiro salvezza su Costituzione. Se fallisce, è accecata fino al termine del turno successivo dell'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
