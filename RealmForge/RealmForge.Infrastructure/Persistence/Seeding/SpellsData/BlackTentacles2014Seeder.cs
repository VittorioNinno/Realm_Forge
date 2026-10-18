using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Black Tentacles (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class BlackTentacles2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "black-tentacles");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "black-tentacles", "en"),
					Language = LanguageCode.En,
					Name = "Black Tentacles",
					CastingTime = "1 action",
					Range = "90 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a piece of tentacle from a giant octopus or a giant squid",
					Description = "Squirming, ebony tentacles fill a 20-foot square on ground that you can see within range. For the duration, these tentacles turn the ground in the area into difficult terrain.\n\nWhen a creature enters the affected area for the first time on a turn or starts its turn there, the creature must succeed on a Dexterity saving throw or take 3d6 bludgeoning damage and be restrained by the tentacles until the spell ends. A creature that starts its turn in the area and is already restrained by the tentacles takes 3d6 bludgeoning damage.\n\nA creature restrained by the tentacles can use its action to make a Strength or Dexterity check (its choice) against your spell save DC. On a success, it frees itself.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "black-tentacles", "it"),
					Language = LanguageCode.It,
					Name = "Tentacoli Neri",
					CastingTime = "1 azione",
					Range = "27 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pezzo di tentacolo di una piovra gigante o di un calamaro gigante",
					Description = "Tentacoli d'ebano che si contorcono riempiono un quadrato di 6 metri di lato sul terreno entro gittata, in un punto che l'incantatore sia in grado di vedere. Per la durata, questi tentacoli rendono il terreno dell'area terreno difficile.\n\nQuando una creatura entra nell'area influenzata per la prima volta in un turno o vi inizia il proprio turno, deve superare un tiro salvezza su Destrezza, altrimenti subisce 3d6 danni contundenti ed è trattenuta dai tentacoli finché l'incantesimo non termina. Una creatura che inizia il proprio turno nell'area mentre è già trattenuta dai tentacoli subisce 3d6 danni contundenti.\n\nUna creatura trattenuta dai tentacoli può usare la propria azione per effettuare una prova di Forza o di Destrezza (a sua scelta) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se la supera, si libera.",
					HigherLevels = null
				}
			}
		};
	}
}
