using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Searing Smite (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class SearingSmite2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "searing-smite");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "searing-smite", "en"),
					Language = LanguageCode.En,
					Name = "Searing Smite",
					CastingTime = "1 bonus action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "The next time you hit a creature with a melee weapon attack while this spell lasts, your weapon flares white-hot. The attack deals an extra 1d6 fire damage and sets the target ablaze. At the start of each of its turns until the spell ends, the burning target makes a Constitution saving throw, taking 1d6 fire damage on a failure; on a success, the spell ends. The spell also ends if the target or a creature within 5 feet of it uses an action to put out the flames, or if something else douses them (such as the target diving into water).",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the extra damage of the initial hit increases by 1d6 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "searing-smite", "it"),
					Language = LanguageCode.It,
					Name = "Punizione Incandescente",
					CastingTime = "1 azione bonus",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "La prossima volta che l'incantatore colpisce una creatura con un attacco con un'arma da mischia finché l'incantesimo dura, la sua arma diventa incandescente. L'attacco infligge 1d6 danni da fuoco extra e dà fuoco al bersaglio. All'inizio di ogni suo turno, finché l'incantesimo non termina, il bersaglio in fiamme effettua un tiro salvezza su Costituzione; se lo fallisce subisce 1d6 danni da fuoco, se lo supera l'incantesimo termina. L'incantesimo termina anche se il bersaglio o una creatura entro 1,5 metri da esso usa un'azione per spegnere le fiamme, o se qualcos'altro le estingue (per esempio, il bersaglio che si tuffa in acqua).",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni extra del colpo iniziale aumentano di 1d6 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
