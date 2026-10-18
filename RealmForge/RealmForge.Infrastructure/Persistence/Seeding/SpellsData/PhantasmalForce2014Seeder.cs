using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Phantasmal Force (2014 ruleset). Not part of SRD 5.1: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class PhantasmalForce2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "phantasmal-force");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 2,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "phantasmal-force", "en"),
					Language = LanguageCode.En,
					Name = "Phantasmal Force",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a bit of fleece",
					Description = "You plant an illusion in the mind of a creature you can see within range. The target makes an Intelligence saving throw. On a failure, you create a phantasmal object, creature, or other visible phenomenon of your choice, no larger than a 10-foot cube, that only the target can perceive for the duration. This spell has no effect on undead or constructs.\n\nThe phantasm comes with sounds, temperature, and other sensations, all of which only the target perceives.\n\nThe target can use its action to study the phantasm with an Intelligence (Investigation) check against your spell save DC. If the check succeeds, the target recognizes the phantasm as an illusion and the spell ends.\n\nWhile affected, the target believes the phantasm is real and explains away anything that doesn't add up. For example, a target that steps onto a phantasmal bridge over a chasm falls as soon as it does so; if it survives, it still believes in the bridge and finds some other reason for the fall, such as a shove, a slip, or a sudden gust of wind.\n\nThe target is so convinced that the phantasm can even hurt it. A phantasm shaped like a creature can attack the target, and one shaped like fire, a pool of acid, or lava can burn it. On each of your turns, the phantasm can deal 1d6 psychic damage to the target if the target is in the phantasm's area or within 5 feet of it, provided the illusion is of a creature or hazard that could logically cause harm, for example by attacking. The target perceives the damage as whatever type suits the illusion.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "phantasmal-force", "it"),
					Language = LanguageCode.It,
					Name = "Allucinazione di Forza",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un po' di vello",
					Description = "L'incantatore insinua un'illusione nella mente di una creatura entro gittata che sia in grado di vedere. Il bersaglio effettua un tiro salvezza su Intelligenza. Se lo fallisce, l'incantatore crea un oggetto, una creatura o un altro fenomeno visibile illusorio a sua scelta, non più grande di un cubo con spigolo di 3 metri, che per la durata soltanto il bersaglio può percepire. Questo incantesimo non ha alcun effetto sui non morti e sui costrutti.\n\nIl fantasma è accompagnato da suoni, temperatura e altre sensazioni, che soltanto il bersaglio percepisce.\n\nIl bersaglio può usare la sua azione per esaminare il fantasma con una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se la prova riesce, il bersaglio riconosce il fantasma come un'illusione e l'incantesimo termina.\n\nFinché è influenzato, il bersaglio crede che il fantasma sia reale e trova una spiegazione a tutto ciò che non torna. Per esempio, un bersaglio che mette piede su un ponte illusorio sopra un baratro cade non appena lo fa; se sopravvive, continua a credere che il ponte esista e attribuisce la caduta a qualche altra causa, come una spinta, una scivolata o un'improvvisa raffica di vento.\n\nIl bersaglio è talmente convinto che il fantasma può persino ferirlo. Un fantasma con l'aspetto di una creatura può attaccare il bersaglio, e uno con l'aspetto di un fuoco, di una pozza d'acido o di lava può ustionarlo. In ognuno dei turni dell'incantatore, il fantasma può infliggere 1d6 danni psichici al bersaglio, se questo si trova nell'area del fantasma o entro 1,5 metri da esso, purché l'illusione rappresenti una creatura o un pericolo che potrebbe logicamente nuocergli, per esempio attaccandolo. Il bersaglio percepisce i danni come del tipo più adatto all'illusione.",
					HigherLevels = null
				}
			}
		};
	}
}
