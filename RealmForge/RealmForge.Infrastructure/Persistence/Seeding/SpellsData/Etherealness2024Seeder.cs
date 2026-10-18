using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Etherealness (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Etherealness2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "etherealness");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "etherealness", "en"),
					Language = LanguageCode.En,
					Name = "Etherealness",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Up to 8 hours",
					MaterialComponent = null,
					Description = "You step into the border regions of the Ethereal Plane, where it overlaps with your current plane. You remain in the Border Ethereal for the duration. During this time, you can move in any direction. If you move up or down, every foot of movement costs an extra foot. You can perceive the plane you left, which looks gray, and you can't see anything there more than 60 feet away.\n\nWhile on the Ethereal Plane, you can affect and be affected only by creatures, objects, and effects on that plane. Creatures that aren't on the Ethereal Plane can't perceive or interact with you unless a feature gives them the ability to do so.\n\nWhen the spell ends, you return to the plane you left in the spot that corresponds to your space in the Border Ethereal. If you appear in an occupied space, you are shunted to the nearest unoccupied space and take Force damage equal to twice the number of feet you are moved.\n\nThis spell ends instantly if you cast it while you are on the Ethereal Plane or a plane that doesn't border it, such as one of the Outer Planes.",
					HigherLevels = "You can target up to three willing creatures (including yourself) for each spell slot level above 7. The creatures must be within 10 feet of you when you cast the spell."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "etherealness", "it"),
					Language = LanguageCode.It,
					Name = "Forma Eterea",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Fino a 8 ore",
					MaterialComponent = null,
					Description = "L'incantatore entra nelle regioni di confine del Piano Etereo, dove questo si sovrappone al piano in cui si trova. Rimane nel Confine Etereo per la durata. Durante questo periodo, può muoversi in qualsiasi direzione. Se si muove verso l'alto o verso il basso, ogni metro di movimento costa un metro extra. Può percepire il piano che ha lasciato, che appare grigio, ma non può vedere nulla che si trovi a più di 18 metri di distanza.\n\nMentre si trova nel Piano Etereo, l'incantatore può influenzare ed essere influenzato soltanto da creature, oggetti ed effetti che si trovano su quel piano. Le creature che non si trovano nel Piano Etereo non possono percepirlo né interagire con lui, a meno che un privilegio non conferisca loro questa capacità.\n\nQuando l'incantesimo termina, l'incantatore ritorna al piano che aveva lasciato, nel punto che corrisponde al suo spazio nel Confine Etereo. Se compare in uno spazio occupato, viene spinto nello spazio libero più vicino e subisce 2 danni da forza per ogni 30 centimetri di cui viene spostato.\n\nQuesto incantesimo termina immediatamente se l'incantatore lo lancia mentre si trova nel Piano Etereo o in un piano che non confina con esso, come uno dei Piani Esterni.",
					HigherLevels = "L'incantatore può scegliere come bersaglio fino a tre creature consenzienti (incluso sé stesso) per ogni livello dello slot incantesimo superiore al 7°. Le creature devono trovarsi entro 3 metri dall'incantatore quando lancia l'incantesimo."
				}
			}
		};
	}
}
