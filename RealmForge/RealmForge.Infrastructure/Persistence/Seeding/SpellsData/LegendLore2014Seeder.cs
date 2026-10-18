using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Legend Lore (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LegendLore2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "legend-lore");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Cleric, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "legend-lore", "en"),
					Language = LanguageCode.En,
					Name = "Legend Lore",
					CastingTime = "10 minutes",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = "incense worth at least 250 gp, which the spell consumes, and four ivory strips worth at least 50 gp each",
					Description = "Name or describe a person, place, or object. The spell brings to your mind a brief summary of the significant lore about the thing you named. The lore might consist of current tales, forgotten stories, or even secret lore that has never been widely known. If the thing you named isn't of legendary importance, you gain no information. The more information you already have about the thing, the more precise and detailed the information you receive is.\n\nThe information you learn is accurate but might be couched in figurative language. For example, if you have a mysterious magic axe on hand the spell might yield this information: \"Woe to the evildoer whose hand touches the axe, for even the haft slices the hand of the evil ones. Only a true Child of Stone, lover and beloved of Moradin, may awaken the true powers of the axe, and only with the sacred word *Rudnogg* on the lips.\"",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "legend-lore", "it"),
					Language = LanguageCode.It,
					Name = "Conoscenza delle Leggende",
					CastingTime = "10 minuti",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = "incenso del valore di almeno 250 mo, che l'incantesimo consuma, e quattro listelli d'avorio del valore di almeno 50 mo ciascuno",
					Description = "L'incantatore nomina o descrive una persona, un luogo o un oggetto. L'incantesimo gli porta alla mente un breve riassunto delle conoscenze significative sulla cosa nominata. Tali conoscenze possono consistere in racconti attuali, storie dimenticate o perfino conoscenze segrete che non sono mai state ampiamente diffuse. Se la cosa nominata non ha un'importanza leggendaria, l'incantatore non ottiene alcuna informazione. Più informazioni possiede già sulla cosa, più precise e dettagliate saranno le informazioni che riceve.\n\nLe informazioni apprese sono accurate, ma possono essere espresse con un linguaggio figurato. Per esempio, se l'incantatore ha con sé una misteriosa ascia magica, l'incantesimo potrebbe fornire questa informazione: \"Guai al malvagio la cui mano tocchi l'ascia, poiché perfino il manico taglia la mano dei malvagi. Solo un vero Figlio della Pietra, amante e amato di Moradin, può risvegliare i veri poteri dell'ascia, e solo con la parola sacra *Rudnogg* sulle labbra.\"",
					HigherLevels = null
				}
			}
		};
	}
}
