using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Woodland Beings (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ConjureWoodlandBeings2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-woodland-beings");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-woodland-beings", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Woodland Beings",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You conjure nature spirits that flit around you in a 10-foot Emanation for the duration. Whenever the Emanation enters the space of a creature you can see and whenever a creature you can see enters the Emanation or ends its turn there, you can force that creature to make a Wisdom saving throw. The creature takes 5d8 Force damage on a failed save or half as much damage on a successful one. A creature makes this save only once per turn.\n\nIn addition, you can take the Disengage action as a Bonus Action for the spell's duration.",
					HigherLevels = "The damage increases by 1d8 for each spell slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-woodland-beings", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Creature Boschive",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore evoca spiriti della natura che gli svolazzano intorno in un'emanazione di 3 metri per la durata. Ogni volta che l'emanazione entra nello spazio di una creatura che l'incantatore è in grado di vedere, e ogni volta che una creatura che è in grado di vedere entra nell'emanazione o vi termina il proprio turno, l'incantatore può costringere quella creatura a effettuare un tiro salvezza su Saggezza. La creatura subisce 5d8 danni da forza se lo fallisce, o la metà di quei danni se lo supera. Una creatura effettua questo tiro salvezza soltanto una volta per turno.\n\nInoltre, per la durata dell'incantesimo, l'incantatore può effettuare l'azione di Disimpegno come azione bonus.",
					HigherLevels = "I danni aumentano di 1d8 per ogni livello dello slot incantesimo superiore al 4°."
				}
			}
		};
	}
}
