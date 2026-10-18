using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Thaumaturgy (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Thaumaturgy2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thaumaturgy");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 0,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thaumaturgy", "en"),
					Language = LanguageCode.En,
					Name = "Thaumaturgy",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Up to 1 minute",
					MaterialComponent = null,
					Description = "You manifest a minor wonder within range. You create one of the effects below within range. If you cast this spell multiple times, you can have up to three of its 1-minute effects active at a time.\n\n***Altered Eyes.*** You alter the appearance of your eyes for 1 minute.\n\n***Booming Voice.*** Your voice booms up to three times as loud as normal for 1 minute. For the duration, you have Advantage on Charisma (Intimidation) checks.\n\n***Fire Play.*** You cause flames to flicker, brighten, dim, or change color for 1 minute.\n\n***Invisible Hand.*** You instantaneously cause an unlocked door or window to fly open or slam shut.\n\n***Phantom Sound.*** You create an instantaneous sound that originates from a point of your choice within range, such as a rumble of thunder, the cry of a raven, or ominous whispers.\n\n***Tremors.*** You cause harmless tremors in the ground for 1 minute.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "thaumaturgy", "it"),
					Language = LanguageCode.It,
					Name = "Taumaturgia",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore manifesta un prodigio minore entro gittata, creando uno degli effetti seguenti entro gittata. Se lancia questo incantesimo più volte, può avere attivi contemporaneamente fino a tre dei suoi effetti da 1 minuto.\n\n***Occhi Alterati.*** L'incantatore altera l'aspetto dei propri occhi per 1 minuto.\n\n***Voce Tonante.*** La voce dell'incantatore risuona fino a tre volte più forte del normale per 1 minuto. Per la durata, l'incantatore dispone di vantaggio alle prove di Carisma (Intimidire).\n\n***Giocare col Fuoco.*** L'incantatore fa tremolare, ravvivare, affievolire o cambiare colore alle fiamme per 1 minuto.\n\n***Mano Invisibile.*** L'incantatore fa spalancare o sbattere istantaneamente una porta o una finestra non chiusa a chiave.\n\n***Suono Fantasma.*** L'incantatore crea un suono istantaneo che proviene da un punto entro gittata a sua scelta, come il rombo di un tuono, il gracchiare di un corvo o sussurri minacciosi.\n\n***Tremori.*** L'incantatore provoca tremori innocui nel terreno per 1 minuto.",
					HigherLevels = null
				}
			}
		};
	}
}
