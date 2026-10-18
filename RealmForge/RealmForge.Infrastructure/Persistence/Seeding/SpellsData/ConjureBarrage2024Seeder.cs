using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Conjure Barrage (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ConjureBarrage2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-barrage");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 3,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-barrage", "en"),
					Language = LanguageCode.En,
					Name = "Conjure Barrage",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "a Melee or Ranged weapon worth at least 1 CP",
					Description = "With a swing of the weapon you used to cast the spell, you unleash a storm of ghostly duplicates of it (or of fitting ammunition) that streak away in a 60-foot Cone and then fade. You choose which creatures you can see in the Cone are targeted; each of them attempts a Dexterity saving throw, suffering 5d8 Force damage if it fails or half that much if it succeeds.",
					HigherLevels = "Add 1d8 to the damage for each slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "conjure-barrage", "it"),
					Language = LanguageCode.It,
					Name = "Evoca Raffica",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "un'arma da mischia o a distanza del valore di almeno 1 mr",
					Description = "Con un fendente dell'arma usata per lanciare l'incantesimo, l'incantatore scatena una tempesta di suoi duplicati spettrali (o di munizioni adeguate) che sfrecciano in un cono di 18 metri e poi svaniscono. L'incantatore decide quali creature visibili nel cono sono bersagliate; ognuna di esse tenta un tiro salvezza su Destrezza e subisce 5d8 danni da forza se fallisce, o metà di quei danni se riesce.",
					HigherLevels = "Aggiungere 1d8 ai danni per ogni livello dello slot oltre il 3°."
				}
			}
		};
	}
}
