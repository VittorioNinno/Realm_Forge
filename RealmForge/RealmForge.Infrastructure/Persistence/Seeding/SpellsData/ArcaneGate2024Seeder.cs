using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Arcane Gate (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class ArcaneGate2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-gate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 6,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-gate", "en"),
					Language = LanguageCode.En,
					Name = "Arcane Gate",
					CastingTime = "Action",
					Range = "500 feet",
					Duration = "Concentration, up to 10 minutes",
					MaterialComponent = null,
					Description = "You tear open a pair of teleportation portals that are linked to each other. Pick two Large, unoccupied spaces on the ground that you can see: one anywhere within range and the other within 10 feet of you. A circular portal appears in each space and stays for the duration.\n\nEach portal is a flat ring of light filled with a mist that blocks vision. It floats a few inches above the ground, standing at a right angle to it.\n\nOnly one face of each portal is open (you decide which). Anything that goes into the open face of one portal steps out of the open face of the other, as though the two stood side by side. As a Bonus Action, you can turn the open faces to point in new directions.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "arcane-gate", "it"),
					Language = LanguageCode.It,
					Name = "Portale Arcano",
					CastingTime = "Azione",
					Range = "150 metri",
					Duration = "Concentrazione, fino a 10 minuti",
					MaterialComponent = null,
					Description = "L'incantatore apre una coppia di portali di teletrasporto collegati tra loro. Sceglie due spazi liberi di taglia Grande sul terreno che è in grado di vedere: uno in qualsiasi punto entro gittata e l'altro entro 3 metri da sé. In ciascuno spazio compare un portale circolare, che resta per la durata.\n\nOgni portale è un anello di luce piatto pieno di una nebbia che impedisce la vista. Fluttua a pochi centimetri dal suolo, in posizione perpendicolare al terreno.\n\nSoltanto una faccia di ciascun portale è aperta (a scelta dell'incantatore). Qualsiasi cosa entri dalla faccia aperta di un portale esce dalla faccia aperta dell'altro, come se i due fossero uno accanto all'altro. Come azione bonus, l'incantatore può orientare le facce aperte in nuove direzioni.",
					HigherLevels = null
				}
			}
		};
	}
}
