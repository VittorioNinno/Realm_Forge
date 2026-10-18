using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Forbiddance (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Forbiddance2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "forbiddance");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "forbiddance", "en"),
					Language = LanguageCode.En,
					Name = "Forbiddance",
					CastingTime = "10 minutes",
					Range = "Touch",
					Duration = "1 day",
					MaterialComponent = "ruby dust worth 1,000+ GP",
					Description = "You create a ward against magical travel that protects up to 40,000 square feet of floor space to a height of 30 feet above the floor. For the duration, creatures can't teleport into the area or use portals, such as those created by the *Gate* spell, to enter the area. The spell proofs the area against planar travel, and therefore prevents creatures from accessing the area by way of the Astral Plane, the Ethereal Plane, the Feywild, the Shadowfell, or the *Plane Shift* spell.\n\nIn addition, the spell damages types of creatures that you choose when you cast it. Choose one or more of the following: Aberrations, Celestials, Elementals, Fey, Fiends, and Undead. When a creature of a chosen type enters the spell's area for the first time on a turn or ends its turn there, the creature takes 5d10 Radiant or Necrotic damage (your choice when you cast this spell).\n\nYou can designate a password when you cast the spell. A creature that speaks the password as it enters the area takes no damage from the spell.\n\nThe spell's area can't overlap with the area of another *Forbiddance* spell. If you cast *Forbiddance* every day for 30 days in the same location, the spell lasts until it is dispelled, and the Material components are consumed on the last casting.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "forbiddance", "it"),
					Language = LanguageCode.It,
					Name = "Proibizione",
					CastingTime = "10 minuti",
					Range = "Contatto",
					Duration = "1 giorno",
					MaterialComponent = "polvere di rubino del valore di almeno 1.000 mo",
					Description = "L'incantatore crea una protezione contro i viaggi magici che protegge fino a 3.600 metri quadrati di superficie del pavimento, fino a un'altezza di 9 metri sopra il pavimento. Per la durata, le creature non possono teletrasportarsi nell'area né usare portali, come quelli creati dall'incantesimo *portale*, per entrarvi. L'incantesimo protegge l'area dai viaggi planari e impedisce quindi alle creature di accedervi passando dal Piano Astrale, dal Piano Etereo, dalla Selva Fatata, dalla Coltre Oscura o tramite l'incantesimo *spostamento planare*.\n\nInoltre, l'incantesimo danneggia i tipi di creature scelti dall'incantatore al momento del lancio. L'incantatore sceglie uno o più dei seguenti: aberrazioni, celestiali, elementali, folletti, immondi e non morti. Quando una creatura di un tipo scelto entra nell'area dell'incantesimo per la prima volta in un turno o vi termina il proprio turno, subisce 5d10 danni radiosi o necrotici (a scelta dell'incantatore al momento del lancio).\n\nL'incantatore può stabilire una parola d'ordine quando lancia l'incantesimo. Una creatura che pronuncia la parola d'ordine mentre entra nell'area non subisce danni dall'incantesimo.\n\nL'area dell'incantesimo non può sovrapporsi all'area di un altro incantesimo *proibizione*. Se l'incantatore lancia *proibizione* ogni giorno per 30 giorni nello stesso luogo, l'incantesimo dura finché non viene dissolto e le componenti materiali vengono consumate nell'ultimo lancio.",
					HigherLevels = null
				}
			}
		};
	}
}
