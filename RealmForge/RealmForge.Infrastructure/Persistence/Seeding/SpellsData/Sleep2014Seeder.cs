using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sleep (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Sleep2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sleep");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sleep", "en"),
					Language = LanguageCode.En,
					Name = "Sleep",
					CastingTime = "1 action",
					Range = "90 feet",
					Duration = "1 minute",
					MaterialComponent = "a pinch of fine sand, rose petals, or a cricket",
					Description = "This spell sends creatures into a magical slumber. Roll 5d8; the total is how many hit points of creatures this spell can affect. Creatures within 20 feet of a point you choose within range are affected in ascending order of their current hit points (ignoring unconscious creatures).\n\nStarting with the creature that has the lowest current hit points, each creature affected by this spell falls unconscious until the spell ends, the sleeper takes damage, or someone uses an action to shake or slap the sleeper awake. Subtract each creature's hit points from the total before moving on to the creature with the next lowest hit points. A creature's hit points must be equal to or less than the remaining total for that creature to be affected.\n\nUndead and creatures immune to being charmed aren't affected by this spell.",
					HigherLevels = "When you cast this spell using a spell slot of 2nd level or higher, roll an additional 2d8 for each slot level above 1st."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "sleep", "it"),
					Language = LanguageCode.It,
					Name = "Sonno",
					CastingTime = "1 azione",
					Range = "27 metri",
					Duration = "1 minuto",
					MaterialComponent = "un pizzico di sabbia fine, petali di rosa o un grillo",
					Description = "Questo incantesimo fa cadere le creature in un sonno magico. L'incantatore tira 5d8: il totale indica quanti punti ferita di creature l'incantesimo può influenzare. Le creature entro 6 metri da un punto entro gittata scelto dall'incantatore sono influenzate in ordine crescente di punti ferita attuali (ignorando le creature prive di sensi).\n\nA partire dalla creatura con il minor numero di punti ferita attuali, ogni creatura influenzata da questo incantesimo cade priva di sensi finché l'incantesimo non termina, finché chi dorme non subisce danni o finché qualcuno non usa un'azione per scuoterlo o schiaffeggiarlo e svegliarlo. Prima di passare alla creatura con il numero di punti ferita immediatamente superiore, si sottraggono dal totale i punti ferita di ogni creatura influenzata. Perché una creatura sia influenzata, i suoi punti ferita devono essere pari o inferiori al totale rimanente.\n\nI non morti e le creature immuni alla condizione di affascinato non sono influenzati da questo incantesimo.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 2° livello o superiore, tira 2d8 aggiuntivi per ogni livello dello slot superiore al 1°."
				}
			}
		};
	}
}
