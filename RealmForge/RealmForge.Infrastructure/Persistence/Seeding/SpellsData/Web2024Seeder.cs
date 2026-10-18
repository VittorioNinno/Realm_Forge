using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Web (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Web2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "web");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "web", "en"),
					Language = LanguageCode.En,
					Name = "Web",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a bit of spiderweb",
					Description = "You conjure a mass of sticky webbing at a point within range. The webs fill a 20-foot Cube there for the duration. The webs are Difficult Terrain, and the area within them is Lightly Obscured.\n\nIf the webs aren't anchored between two solid masses (such as walls or trees) or layered across a floor, wall, or ceiling, the web collapses on itself, and the spell ends at the start of your next turn. Webs layered over a flat surface have a depth of 5 feet.\n\nThe first time a creature enters the webs on a turn or starts its turn there, it must succeed on a Dexterity saving throw or have the Restrained condition while in the webs or until it breaks free.\n\nA creature Restrained by the webs can take an action to make a Strength (Athletics) check against your spell save DC. If it succeeds, it is no longer Restrained.\n\nThe webs are flammable. Any 5-foot Cube of webs exposed to fire burns away in 1 round, dealing 2d4 Fire damage to any creature that starts its turn in the fire.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "web", "it"),
					Language = LanguageCode.It,
					Name = "Ragnatela",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un po' di ragnatela",
					Description = "L'incantatore evoca una massa di ragnatele appiccicose in un punto entro gittata. Le ragnatele riempiono un cubo con spigolo di 6 metri in quel punto per la durata. Le ragnatele sono terreno difficile e l'area al loro interno è leggermente oscurata.\n\nSe le ragnatele non sono ancorate tra due masse solide (come muri o alberi) o stese su un pavimento, un muro o un soffitto, la ragnatela collassa su sé stessa e l'incantesimo termina all'inizio del turno successivo dell'incantatore. Le ragnatele stese su una superficie piatta hanno uno spessore di 1,5 metri.\n\nLa prima volta in un turno in cui una creatura entra nelle ragnatele o vi inizia il proprio turno, deve superare un tiro salvezza su Destrezza, altrimenti è trattenuta finché si trova nelle ragnatele o finché non si libera.\n\nUna creatura trattenuta dalle ragnatele può effettuare un'azione per compiere una prova di Forza (Atletica) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se la supera, non è più trattenuta.\n\nLe ragnatele sono infiammabili. Qualsiasi cubo di ragnatele con spigolo di 1,5 metri esposto al fuoco brucia in 1 round, infliggendo 2d4 danni da fuoco a qualsiasi creatura che inizia il proprio turno tra le fiamme.",
					HigherLevels = null
				}
			}
		};
	}
}
