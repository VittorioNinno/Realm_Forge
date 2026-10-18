using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Mirror Image (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class MirrorImage2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mirror-image");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mirror-image", "en"),
					Language = LanguageCode.En,
					Name = "Mirror Image",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "Three illusory duplicates of yourself appear in your space. Until the spell ends, the duplicates move with you and mimic your actions, shifting position so it's impossible to track which image is real. You can use your action to dismiss the illusory duplicates.\n\nEach time a creature targets you with an attack during the spell's duration, roll a d20 to determine whether the attack instead targets one of your duplicates.\n\nIf you have three duplicates, you must roll a 6 or higher to change the attack's target to a duplicate. With two duplicates, you must roll an 8 or higher. With one duplicate, you must roll an 11 or higher.\n\nA duplicate's AC equals 10 + your Dexterity modifier. If an attack hits a duplicate, the duplicate is destroyed. A duplicate can be destroyed only by an attack that hits it. It ignores all other damage and effects. The spell ends when all three duplicates are destroyed.\n\nA creature is unaffected by this spell if it can't see, if it relies on senses other than sight, such as blindsight, or if it can perceive illusions as false, as with truesight.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "mirror-image", "it"),
					Language = LanguageCode.It,
					Name = "Immagine Speculare",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "Tre duplicati illusori dell'incantatore compaiono nel suo spazio. Finché l'incantesimo non termina, i duplicati si muovono con lui e imitano le sue azioni, cambiando posizione in modo che sia impossibile capire quale immagine sia quella reale. L'incantatore può usare la sua azione per congedare i duplicati illusori.\n\nOgni volta che una creatura bersaglia l'incantatore con un attacco durante la durata dell'incantesimo, l'incantatore tira un d20 per determinare se l'attacco bersaglia invece uno dei suoi duplicati.\n\nSe ha tre duplicati, deve ottenere 6 o più per spostare il bersaglio dell'attacco su un duplicato. Con due duplicati, deve ottenere 8 o più. Con un duplicato, deve ottenere 11 o più.\n\nLa CA di un duplicato è pari a 10 + il modificatore di Destrezza dell'incantatore. Se un attacco colpisce un duplicato, il duplicato viene distrutto. Un duplicato può essere distrutto soltanto da un attacco che lo colpisce, e ignora tutti gli altri danni ed effetti. L'incantesimo termina quando tutti e tre i duplicati sono stati distrutti.\n\nUna creatura non è influenzata da questo incantesimo se non può vedere, se fa affidamento su sensi diversi dalla vista, come la vista cieca, o se è in grado di riconoscere le illusioni come false, come nel caso della vista pura.",
					HigherLevels = null
				}
			}
		};
	}
}
