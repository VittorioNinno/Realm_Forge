using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Entangle (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Entangle2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "entangle");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "entangle", "en"),
					Language = LanguageCode.En,
					Name = "Entangle",
					CastingTime = "1 action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Grasping weeds and vines sprout from the ground in a 20-foot square starting from a point within range. For the duration, these plants turn the ground in the area into difficult terrain.\n\nA creature in the area when you cast the spell must succeed on a Strength saving throw or be restrained by the entangling plants until the spell ends. A creature restrained by the plants can use its action to make a Strength check against your spell save DC. On a success, it frees itself.\n\nWhen the spell ends, the conjured plants wilt away.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "entangle", "it"),
					Language = LanguageCode.It,
					Name = "Intralciare",
					CastingTime = "1 azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Erbacce e rampicanti avvinghianti spuntano dal terreno in un quadrato di 6 metri di lato a partire da un punto entro gittata. Per la durata, questi vegetali rendono il terreno dell'area terreno difficile.\n\nUna creatura che si trova nell'area quando l'incantatore lancia l'incantesimo deve superare un tiro salvezza su Forza, altrimenti è trattenuta dai vegetali avvinghianti finché l'incantesimo non termina. Una creatura trattenuta dai vegetali può usare la sua azione per effettuare una prova di Forza contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se la supera, si libera.\n\nQuando l'incantesimo termina, i vegetali evocati avvizziscono.",
					HigherLevels = null
				}
			}
		};
	}
}
