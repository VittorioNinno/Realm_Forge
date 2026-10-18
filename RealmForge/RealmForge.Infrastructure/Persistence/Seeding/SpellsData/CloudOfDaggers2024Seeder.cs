using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Cloud of Daggers (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CloudOfDaggers2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "cloud-of-daggers");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 2,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "cloud-of-daggers", "en"),
					Language = LanguageCode.En,
					Name = "Cloud of Daggers",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a shard of glass",
					Description = "Pick a point within range: a 5-foot Cube centered there fills with phantom blades that spin and slash for the duration. A creature suffers 4d4 Slashing damage from them when the spell is cast with the creature inside the Cube, when it enters the Cube, when it finishes its turn there, or when the Cube is moved onto it. Whatever the trigger, a creature takes this damage no more than once per turn.\n\nAs a Magic action on a later turn, you can teleport the Cube to a new spot up to 30 feet away.",
					HigherLevels = "Add 2d4 to the damage for each slot level above 2."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "cloud-of-daggers", "it"),
					Language = LanguageCode.It,
					Name = "Nube di Pugnali",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un frammento di vetro",
					Description = "L'incantatore sceglie un punto entro gittata: un cubo di 1,5 metri di spigolo centrato su di esso si riempie di lame fantasma che roteano e tagliano per la durata. Una creatura subisce 4d4 danni taglienti da quelle lame quando l'incantesimo viene lanciato mentre si trova nel cubo, quando vi entra, quando vi conclude il proprio turno o quando il cubo viene spostato su di lei. Qualunque sia la causa, una creatura subisce questi danni al massimo una volta per turno.\n\nCon un'azione di Magia in un turno successivo, l'incantatore può teletrasportare il cubo in un nuovo punto distante fino a 9 metri.",
					HigherLevels = "Aggiungere 2d4 ai danni per ogni livello dello slot oltre il 2°."
				}
			}
		};
	}
}
