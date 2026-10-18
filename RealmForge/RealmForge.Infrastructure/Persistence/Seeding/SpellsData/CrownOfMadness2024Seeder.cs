using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Crown of Madness (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CrownOfMadness2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "crown-of-madness");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "crown-of-madness", "en"),
					Language = LanguageCode.En,
					Name = "Crown of Madness",
					CastingTime = "Action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Choose a creature you can see within range. Unless it succeeds on a Wisdom saving throw, it has the Charmed condition for the duration; a creature that isn't a Humanoid succeeds automatically.\n\nA ghostly crown appears on the head of the Charmed creature. On each of its turns, before it moves, it must use its action to make a melee attack against a creature other than itself that you choose mentally. If you choose no creature, or none is within its reach, it acts normally on that turn. At the end of each of its turns, the target repeats the save, ending the spell on itself on a success.\n\nOn each of your later turns, you must take the Magic action to keep control of the target; otherwise, the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "crown-of-madness", "it"),
					Language = LanguageCode.It,
					Name = "Corona di Follia",
					CastingTime = "Azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore sceglie una creatura entro gittata che è in grado di vedere. A meno che non superi un tiro salvezza su Saggezza, la creatura è affascinata per la durata; una creatura che non è un umanoide supera automaticamente il tiro salvezza.\n\nSulla testa della creatura affascinata compare una corona spettrale. In ognuno dei suoi turni, prima di muoversi, la creatura deve usare la propria azione per effettuare un attacco in mischia contro una creatura diversa da sé, scelta mentalmente dall'incantatore. Se l'incantatore non sceglie alcuna creatura, o se nessuna si trova entro la sua portata, il bersaglio agisce normalmente in quel turno. Alla fine di ogni suo turno, il bersaglio ripete il tiro salvezza e, se lo supera, l'incantesimo termina su di lui.\n\nIn ognuno dei suoi turni successivi, l'incantatore deve effettuare l'azione di Magia per mantenere il controllo del bersaglio; altrimenti, l'incantesimo termina.",
					HigherLevels = null
				}
			}
		};
	}
}
