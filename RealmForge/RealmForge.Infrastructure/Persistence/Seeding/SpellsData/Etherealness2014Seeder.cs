using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Etherealness (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Etherealness2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "etherealness");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Transmutation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "etherealness", "en"),
					Language = LanguageCode.En,
					Name = "Etherealness",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Up to 8 hours",
					MaterialComponent = null,
					Description = "You step into the border regions of the Ethereal Plane, in the area where it overlaps with your current plane. You remain in the Border Ethereal for the duration or until you use your action to dismiss the spell. During this time, you can move in any direction. If you move up or down, every foot of movement costs an extra foot. You can see and hear the plane you originated from, but everything there looks gray, and you can't see anything more than 60 feet away.\n\nWhile on the Ethereal Plane, you can only affect and be affected by other creatures on that plane. Creatures that aren't on the Ethereal Plane can't perceive you and can't interact with you, unless a special ability or magic has given them the ability to do so.\n\nYou ignore all objects and effects that aren't on the Ethereal Plane, allowing you to move through objects you perceive on the plane you originated from.\n\nWhen the spell ends, you immediately return to the plane you originated from in the spot you currently occupy. If you occupy the same spot as a solid object or creature when this happens, you are immediately shunted to the nearest unoccupied space that you can occupy and take force damage equal to twice the number of feet you are moved.\n\nThis spell has no effect if you cast it while you are on the Ethereal Plane or a plane that doesn't border it, such as one of the Outer Planes.",
					HigherLevels = "When you cast this spell using a spell slot of 8th level or higher, you can target up to three willing creatures (including you) for each slot level above 7th. The creatures must be within 10 feet of you when you cast the spell."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "etherealness", "it"),
					Language = LanguageCode.It,
					Name = "Forma Eterea",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Fino a 8 ore",
					MaterialComponent = null,
					Description = "L'incantatore entra nelle regioni di confine del Piano Etereo, nell'area in cui si sovrappone al suo piano attuale. Rimane nel Confine Etereo per la durata o finché non usa la sua azione per congedare l'incantesimo. Durante questo periodo, può muoversi in qualsiasi direzione. Se si muove verso l'alto o verso il basso, ogni metro di movimento costa un metro extra. Può vedere e sentire il piano da cui proviene, ma lì tutto appare grigio e non può vedere nulla che si trovi a più di 18 metri di distanza.\n\nFinché si trova nel Piano Etereo, l'incantatore può influenzare soltanto le altre creature presenti su quel piano ed essere influenzato soltanto da esse. Le creature che non si trovano nel Piano Etereo non possono percepirlo né interagire con lui, a meno che una capacità speciale o la magia non abbia conferito loro questa possibilità.\n\nL'incantatore ignora tutti gli oggetti e gli effetti che non si trovano nel Piano Etereo, e ciò gli permette di attraversare gli oggetti che percepisce nel piano da cui proviene.\n\nQuando l'incantesimo termina, l'incantatore torna immediatamente al piano da cui proviene, nel punto che occupa in quel momento. Se in quel momento occupa lo stesso punto di un oggetto solido o di una creatura, viene immediatamente spinto nello spazio libero più vicino che può occupare e subisce 2 danni da forza per ogni 30 cm di cui viene spostato.\n\nQuesto incantesimo non ha alcun effetto se l'incantatore lo lancia mentre si trova nel Piano Etereo o in un piano che non confina con esso, come uno dei Piani Esterni.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 8° livello o superiore, può bersagliare fino a tre creature consenzienti (incluso sé stesso) per ogni livello dello slot superiore al 7°. Le creature devono trovarsi entro 3 metri dall'incantatore quando lancia l'incantesimo."
				}
			}
		};
	}
}
