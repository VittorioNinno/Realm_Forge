using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Witch Bolt (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class WitchBolt2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "witch-bolt");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "witch-bolt", "en"),
					Language = LanguageCode.En,
					Name = "Witch Bolt",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a twig that lightning has struck",
					Description = "An arc of crackling energy springs from you to a creature within range and stays connected to it. Make a ranged spell attack; a hit deals 2d12 Lightning damage.\n\nFor the rest of the duration, as a Bonus Action on each of your later turns, you can send another surge along the arc, dealing 1d12 Lightning damage to the creature with no attack roll needed (this works even if your first attack missed).\n\nThe arc snaps, ending the spell, if the creature is ever beyond the spell's range or behind Total Cover from you.",
					HigherLevels = "For each slot level above 1, add 1d12 to the damage of the first attack."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "witch-bolt", "it"),
					Language = LanguageCode.It,
					Name = "Dardo Stregato",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un rametto che è stato colpito da un fulmine",
					Description = "Un arco di energia crepitante scaturisce dall'incantatore verso una creatura entro gittata e resta collegato a lei. L'incantatore effettua un attacco con incantesimo a distanza; un colpo a segno infligge 2d12 danni da fulmine.\n\nPer il resto della durata, con un'azione bonus in ognuno dei suoi turni successivi, l'incantatore può inviare un'altra scarica lungo l'arco, infliggendo alla creatura 1d12 danni da fulmine senza bisogno di alcun tiro per colpire (funziona anche se il primo attacco è andato a vuoto).\n\nL'arco si spezza, e l'incantesimo termina, se in qualsiasi momento la creatura si trova oltre la gittata dell'incantesimo o dietro una copertura totale rispetto all'incantatore.",
					HigherLevels = "Per ogni livello dello slot oltre il 1°, aggiungere 1d12 ai danni del primo attacco."
				}
			}
		};
	}
}
