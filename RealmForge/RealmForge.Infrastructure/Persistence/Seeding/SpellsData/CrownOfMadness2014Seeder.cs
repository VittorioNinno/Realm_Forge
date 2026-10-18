using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Crown of Madness (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CrownOfMadness2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "crown-of-madness");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 2,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "crown-of-madness", "en"),
					Language = LanguageCode.En,
					Name = "Crown of Madness",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Choose a humanoid you can see within range. It must succeed on a Wisdom saving throw or be charmed by you for the duration. While charmed this way, a crown of jagged, twisted iron appears on its head and its eyes shine with madness.\n\nOn each of its turns, before it moves, the charmed target must use its action to make a melee attack against a creature other than itself that you mentally pick. If you pick no creature, or none is within its reach, it can act normally.\n\nOn your later turns, you must use your action to keep control of the target, or the spell ends. The target can also make a Wisdom saving throw at the end of each of its turns, ending the spell on a success.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "crown-of-madness", "it"),
					Language = LanguageCode.It,
					Name = "Corona di Follia",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore sceglie un umanoide entro gittata che sia in grado di vedere. L'umanoide deve superare un tiro salvezza su Saggezza, altrimenti è affascinato dall'incantatore per la durata. Finché è affascinato in questo modo, sul suo capo compare una corona di ferro contorto e frastagliato e i suoi occhi brillano di follia.\n\nIn ognuno dei suoi turni, prima di muoversi, il bersaglio affascinato deve usare la sua azione per effettuare un attacco in mischia contro una creatura diversa da sé, scelta mentalmente dall'incantatore. Se l'incantatore non sceglie alcuna creatura, o se nessuna si trova a portata, il bersaglio può agire normalmente.\n\nNei turni successivi, l'incantatore deve usare la sua azione per mantenere il controllo del bersaglio, altrimenti l'incantesimo termina. Inoltre, il bersaglio può effettuare un tiro salvezza su Saggezza alla fine di ogni suo turno; se lo supera, l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
