using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Hunger of Hadar (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class HungerOfHadar2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hunger-of-hadar");

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
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hunger-of-hadar", "en"),
					Language = LanguageCode.En,
					Name = "Hunger of Hadar",
					CastingTime = "Action",
					Range = "150 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a tentacle preserved in brine",
					Description = "You rip a passage to the Far Realm, home of horrors without names. For the duration, a Sphere of magical Darkness with a 20-foot radius fills the space around a point within range. Nothing can light it, magical or not. Inside, the ground counts as Difficult Terrain, any creature wholly within the Sphere is Blinded, and murmurs and wet sucking noises spill out to a distance of 30 feet.\n\nThe void feeds on those caught in it:\n\n- A creature that begins its turn inside suffers 2d6 Cold damage.\n- A creature that finishes its turn inside is groped by unseen tentacles and attempts a Dexterity saving throw, suffering 2d6 Acid damage if it fails.",
					HigherLevels = "For each slot level above 3, add 1d6 to either the Cold or the Acid damage (your choice)."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "hunger-of-hadar", "it"),
					Language = LanguageCode.It,
					Name = "Fame di Hadar",
					CastingTime = "Azione",
					Range = "45 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un tentacolo conservato in salamoia",
					Description = "L'incantatore apre a forza un varco verso il Reame Remoto, dimora di orrori senza nome. Per la durata, una sfera di oscurità magica con un raggio di 6 metri occupa lo spazio attorno a un punto entro gittata. Nulla può illuminarla, magico o meno. Al suo interno il suolo è terreno difficile, ogni creatura che si trova del tutto dentro la sfera è accecata, e mormorii e rumori umidi di risucchio si odono fino a 9 metri di distanza.\n\nIl vuoto si nutre di chi vi resta intrappolato:\n\n- Una creatura che inizia il proprio turno all'interno subisce 2d6 danni da freddo.\n- Una creatura che conclude il proprio turno all'interno viene palpata da tentacoli invisibili e tenta un tiro salvezza su Destrezza; se fallisce, subisce 2d6 danni da acido.",
					HigherLevels = "Per ogni livello dello slot oltre il 3°, aggiungere 1d6 ai danni da freddo o a quelli da acido (a scelta dell'incantatore)."
				}
			}
		};
	}
}
