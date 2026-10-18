using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Web (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Web2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "web");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "web", "en"),
					Language = LanguageCode.En,
					Name = "Web",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a bit of spiderweb",
					Description = "You conjure a mass of thick, sticky webbing at a point of your choice within range. The webs fill a 20-foot cube from that point for the duration. The webs are difficult terrain and lightly obscure their area.\n\nIf the webs aren't anchored between two solid masses (such as walls or trees) or layered across a floor, wall, or ceiling, the conjured web collapses on itself, and the spell ends at the start of your next turn. Webs layered over a flat surface have a depth of 5 feet.\n\nEach creature that starts its turn in the webs or that enters them during its turn must make a Dexterity saving throw. On a failed save, the creature is restrained as long as it remains in the webs or until it breaks free.\n\nA creature restrained by the webs can use its action to make a Strength check against your spell save DC. If it succeeds, it is no longer restrained.\n\nThe webs are flammable. Any 5-foot cube of webs exposed to fire burns away in 1 round, dealing 2d4 fire damage to any creature that starts its turn in the fire.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "web", "it"),
					Language = LanguageCode.It,
					Name = "Ragnatela",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un po' di ragnatela",
					Description = "L'incantatore evoca una massa di ragnatele spesse e appiccicose in un punto entro gittata a sua scelta. Per la durata, le ragnatele riempiono un cubo con spigolo di 6 metri a partire da quel punto. Le ragnatele sono terreno difficile e rendono la loro area leggermente oscurata.\n\nSe le ragnatele non sono ancorate tra due masse solide (come muri o alberi) o stese su un pavimento, un muro o un soffitto, la ragnatela evocata collassa su sé stessa e l'incantesimo termina all'inizio del turno successivo dell'incantatore. Le ragnatele stese su una superficie piana hanno uno spessore di 1,5 metri.\n\nOgni creatura che inizia il proprio turno nelle ragnatele o che vi entra durante il proprio turno deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, la creatura è trattenuta finché rimane nelle ragnatele o finché non si libera.\n\nUna creatura trattenuta dalle ragnatele può usare la sua azione per effettuare una prova di Forza contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se la supera, non è più trattenuta.\n\nLe ragnatele sono infiammabili. Qualsiasi cubo di ragnatele con spigolo di 1,5 metri esposto al fuoco brucia in 1 round, infliggendo 2d4 danni da fuoco a qualsiasi creatura che inizia il proprio turno tra le fiamme.",
					HigherLevels = null
				}
			}
		};
	}
}
