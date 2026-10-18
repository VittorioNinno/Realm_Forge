using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Dissonant Whispers (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class DissonantWhispers2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dissonant-whispers");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dissonant-whispers", "en"),
					Language = LanguageCode.En,
					Name = "Dissonant Whispers",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "You whisper a jarring melody that only one creature of your choice within range can hear, and it fills the creature with agony. The target makes a Wisdom saving throw. On a failure, it takes 3d6 psychic damage and must immediately use its reaction, if it has one available, to move as far away from you as its speed allows, though it won't move into obviously dangerous ground such as a fire or a pit. On a success, it takes half as much damage and doesn't have to move. A deafened creature automatically succeeds on the save.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d6 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "dissonant-whispers", "it"),
					Language = LanguageCode.It,
					Name = "Sussurri Dissonanti",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "L'incantatore sussurra una melodia stridente che soltanto una creatura a sua scelta entro gittata può sentire, e che la riempie di sofferenza. Il bersaglio effettua un tiro salvezza su Saggezza. Se lo fallisce, subisce 3d6 danni psichici e deve usare immediatamente la sua reazione, se ne ha una disponibile, per allontanarsi dall'incantatore quanto più glielo consente la sua velocità, senza però entrare in zone palesemente pericolose come un fuoco o una fossa. Se lo supera, subisce la metà di quei danni e non è costretto a muoversi. Una creatura assordata supera automaticamente il tiro salvezza.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, i danni aumentano di 1d6 per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
