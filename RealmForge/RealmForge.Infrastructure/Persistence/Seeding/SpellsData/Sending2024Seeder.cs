using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Sending (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Sending2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sending");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 3,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sending", "en"),
					Language = LanguageCode.En,
					Name = "Sending",
					CastingTime = "Action",
					Range = "Unlimited",
					Duration = "Instantaneous",
					MaterialComponent = "a copper wire",
					Description = "You send a short message of 25 words or fewer to a creature you have met or a creature described to you by someone who has met it. The target hears the message in its mind, recognizes you as the sender if it knows you, and can answer in a like manner immediately. The spell enables targets to understand the meaning of your message.\n\nYou can send the message across any distance and even to other planes of existence, but if the target is on a different plane than you, there is a 5 percent chance that the message doesn't arrive. You know if the delivery fails.\n\nUpon receiving your message, a creature can block your ability to reach it again with this spell for 8 hours. If you try to send another message during that time, you learn that you are blocked, and the spell fails.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "sending", "it"),
					Language = LanguageCode.It,
					Name = "Inviare",
					CastingTime = "Azione",
					Range = "Illimitata",
					Duration = "Istantanea",
					MaterialComponent = "un filo di rame",
					Description = "L'incantatore invia un breve messaggio di 25 parole o meno a una creatura che ha incontrato o a una creatura che gli è stata descritta da qualcuno che l'ha incontrata. Il bersaglio sente il messaggio nella propria mente, riconosce l'incantatore come mittente se lo conosce e può rispondere immediatamente allo stesso modo. L'incantesimo permette ai bersagli di comprendere il significato del messaggio.\n\nL'incantatore può inviare il messaggio a qualsiasi distanza e persino su altri piani di esistenza, ma se il bersaglio si trova su un piano diverso dal suo, c'è una probabilità del 5 per cento che il messaggio non arrivi. L'incantatore sa se la consegna fallisce.\n\nDopo aver ricevuto il messaggio, una creatura può impedire all'incantatore di raggiungerla di nuovo con questo incantesimo per 8 ore. Se l'incantatore tenta di inviare un altro messaggio durante quel periodo, scopre di essere bloccato e l'incantesimo fallisce.",
					HigherLevels = null
				}
			}
		};
	}
}
