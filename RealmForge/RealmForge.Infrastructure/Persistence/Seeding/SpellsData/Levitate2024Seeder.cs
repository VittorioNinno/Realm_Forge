using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Levitate (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Levitate2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "levitate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "levitate", "en"),
					Language = LanguageCode.En,
					Name = "Levitate",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = "a metal spring",
					Description = "One creature or loose object of your choice that you can see within range rises vertically up to 20 feet and remains suspended there for the duration. The spell can levitate an object that weighs up to 500 pounds. An unwilling creature that succeeds on a Constitution saving throw is unaffected.\n\nThe target can move only by pushing or pulling against a fixed object or surface within reach (such as a wall or a ceiling), which allows it to move as if it were climbing. You can change the target's altitude by up to 20 feet in either direction on your turn. If you are the target, you can move up or down as part of your move. Otherwise, you can take a Magic action to move the target, which must remain within the spell's range.\n\nWhen the spell ends, the target floats gently to the ground if it is still aloft.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "levitate", "it"),
					Language = LanguageCode.It,
					Name = "Levitazione",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = "una molla di metallo",
					Description = "Una creatura o un oggetto non fissato a scelta dell'incantatore, che egli è in grado di vedere entro gittata, si solleva verticalmente fino a 6 metri e rimane sospeso a quell'altezza per la durata. L'incantesimo può far levitare un oggetto che pesa fino a 250 kg. Una creatura non consenziente che supera un tiro salvezza su Costituzione non viene influenzata.\n\nIl bersaglio può muoversi soltanto spingendosi o tirandosi contro un oggetto fisso o una superficie entro portata (come un muro o un soffitto), il che gli consente di muoversi come se stesse scalando. Nel proprio turno, l'incantatore può cambiare l'altitudine del bersaglio fino a 6 metri in entrambe le direzioni. Se il bersaglio è l'incantatore stesso, può muoversi verso l'alto o verso il basso come parte del proprio movimento. Altrimenti, può effettuare un'azione di Magia per spostare il bersaglio, che deve rimanere entro la gittata dell'incantesimo.\n\nQuando l'incantesimo termina, il bersaglio scende dolcemente al suolo se si trova ancora in aria.",
					HigherLevels = null
				}
			}
		};
	}
}
