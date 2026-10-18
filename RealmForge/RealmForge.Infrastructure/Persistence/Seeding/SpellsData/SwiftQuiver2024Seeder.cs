using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Swift Quiver (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SwiftQuiver2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "swift-quiver");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "swift-quiver", "en"),
					Language = LanguageCode.En,
					Name = "Swift Quiver",
					CastingTime = "Bonus Action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a Quiver worth 1+ GP",
					Description = "Magic keeps your quiver endlessly stocked. As part of casting the spell, and again by taking a Bonus Action on each of your turns while it lasts, you can make two attacks with a weapon that fires Arrows or Bolts (a Longbow or Light Crossbow, for instance). The spell supplies the ammunition for these attacks: each conjured piece deals the same damage as a normal, nonmagical Arrow or Bolt, and it disintegrates the moment its attack hits or misses.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "swift-quiver", "it"),
					Language = LanguageCode.It,
					Name = "Faretra Rapida",
					CastingTime = "Azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una faretra del valore di almeno 1 mo",
					Description = "La magia rifornisce di continuo la faretra dell'incantatore. Nell'ambito del lancio, e di nuovo con un'azione bonus in ognuno dei suoi turni finché l'incantesimo dura, l'incantatore può effettuare due attacchi con un'arma che scaglia frecce o quadrelli (per esempio un arco lungo o una balestra leggera). L'incantesimo fornisce le munizioni per questi attacchi: ogni munizione creata infligge gli stessi danni di una normale freccia o di un normale quadrello non magico, e si disintegra nell'istante in cui il suo attacco colpisce o manca.",
					HigherLevels = null
				}
			}
		};
	}
}
