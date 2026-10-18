using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Swift Quiver (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SwiftQuiver2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "swift-quiver");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 5,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "swift-quiver", "en"),
					Language = LanguageCode.En,
					Name = "Swift Quiver",
					CastingTime = "1 bonus action",
					Range = "Touch",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a quiver holding at least one piece of ammunition",
					Description = "You enchant your quiver so that it never runs dry: nonmagical ammunition seems to jump into your hand whenever you reach for it.\n\nOn each of your turns until the spell ends, you can use a bonus action to make two attacks with a weapon that uses ammunition from the quiver. Each time you make one of these ranged attacks, the quiver magically replaces the ammunition you used with an identical piece of nonmagical ammunition. Ammunition created by this spell crumbles to nothing when the spell ends. The spell also ends if the quiver leaves your possession.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "swift-quiver", "it"),
					Language = LanguageCode.It,
					Name = "Faretra Rapida",
					CastingTime = "1 azione bonus",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una faretra contenente almeno una munizione",
					Description = "L'incantatore incanta la sua faretra in modo che non si esaurisca mai: le munizioni non magiche sembrano balzargli in mano ogni volta che allunga la mano per prenderle.\n\nIn ognuno dei suoi turni, finché l'incantesimo non termina, l'incantatore può usare un'azione bonus per effettuare due attacchi con un'arma che usa le munizioni della faretra. Ogni volta che effettua uno di questi attacchi a distanza, la faretra sostituisce magicamente la munizione usata con una munizione non magica identica. Le munizioni create da questo incantesimo si dissolvono nel nulla quando l'incantesimo termina. L'incantesimo termina anche se la faretra non è più in possesso dell'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
