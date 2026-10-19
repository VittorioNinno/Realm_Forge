using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Warrior of Mercy (monk, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class WarriorOfMercy2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-mercy");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Monk2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-mercy", "en"), Language = LanguageCode.En, Name = "Warrior of Mercy", Description = "Warriors of Mercy work with the life force of other creatures. They roam the land as healers, yet they bring a swift end to those who stand against them. Many hide their faces behind masks, appearing as nameless bearers of both life and death." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-mercy", "it"), Language = LanguageCode.It, Name = "Guerriero della Misericordia", Description = "I guerrieri della misericordia agiscono sulla forza vitale delle altre creature. Vagano per il mondo come guaritori, ma sanno porre una fine rapida a chi si oppone loro. Molti nascondono il volto dietro una maschera, presentandosi come anonimi portatori di vita e di morte." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/hand-of-harm"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/hand-of-harm", "en"), Language = LanguageCode.En, Name = "Hand of Harm", Description = "Your touch can wound as well as mend: once per turn, if your Unarmed Strike lands and damages a creature, spending 1 Focus Point adds Necrotic damage equal to your Martial Arts die plus your Wisdom modifier." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/hand-of-harm", "it"), Language = LanguageCode.It, Name = "Mano del Dolore", Description = "Il tocco del monaco sa anche ferire: una volta per turno, se un suo colpo senz'armi va a segno e danneggia una creatura, spendendo 1 punto concentrazione aggiunge danni necrotici pari al dado di Arti marziali più il modificatore di Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/hand-of-healing"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/hand-of-healing", "en"), Language = LanguageCode.En, Name = "Hand of Healing", Description = "As a Magic action, you can spend 1 Focus Point and touch a creature, restoring Hit Points equal to one roll of your Martial Arts die plus your Wisdom modifier.\n\nWhen you use Flurry of Blows, you can swap one of its Unarmed Strikes for a use of this feature, paying no Focus Point for the healing." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/hand-of-healing", "it"), Language = LanguageCode.It, Name = "Mano Guaritrice", Description = "Con un'azione di Magia, il monaco può spendere 1 punto concentrazione e toccare una creatura per farle recuperare punti ferita pari a un tiro del dado di Arti marziali + il suo modificatore di Saggezza.\n\nQuando usa Raffica di colpi, può sostituire uno dei colpi senz'armi con un utilizzo di questo privilegio, senza spendere punti concentrazione per la guarigione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/implements-of-mercy"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/implements-of-mercy", "en"), Language = LanguageCode.En, Name = "Implements of Mercy", Description = "Your training as a healer makes you proficient with the Herbalism Kit and in two skills: Insight and Medicine." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/implements-of-mercy", "it"), Language = LanguageCode.It, Name = "Strumenti di Misericordia", Description = "La formazione da guaritore rende il monaco competente nella borsa da erborista e in due abilità: Intuizione e Medicina." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/physicians-touch"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/physicians-touch", "en"), Language = LanguageCode.En, Name = "Physician's Touch", Description = "Your Hand of Harm and Hand of Healing grow stronger.\n\n**Hand of Harm.** When you use Hand of Harm on a creature, you can also leave it Poisoned until the end of your next turn.\n\n**Hand of Healing.** When you use Hand of Healing, you can also end one of these conditions on the creature you heal: Blinded, Deafened, Paralyzed, Poisoned, or Stunned." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/physicians-touch", "it"), Language = LanguageCode.It, Name = "Tocco del Medico", Description = "Mano del dolore e Mano guaritrice migliorano.\n\n**Mano del dolore.** Quando usa Mano del dolore su una creatura, il monaco può anche farle subire la condizione di avvelenato fino alla fine del proprio turno successivo.\n\n**Mano guaritrice.** Quando usa Mano guaritrice, il monaco può anche porre fine a una delle condizioni seguenti sulla creatura che cura: accecato, assordato, avvelenato, paralizzato o stordito." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/flurry-of-healing-and-harm"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/flurry-of-healing-and-harm", "en"), Language = LanguageCode.En, Name = "Flurry of Healing and Harm", Description = "When you use Flurry of Blows, you can swap each of its Unarmed Strikes for a use of Hand of Healing, paying no Focus Points for the healing.\n\nAlso, when an Unarmed Strike from Flurry of Blows deals damage, you can apply Hand of Harm to it without paying its Focus Point; Hand of Harm is still limited to once per turn.\n\nYou can use these benefits a combined number of times equal to your Wisdom modifier (at least once), regaining every use after a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/flurry-of-healing-and-harm", "it"), Language = LanguageCode.It, Name = "Raffica di Guarigione e Dolore", Description = "Quando usa Raffica di colpi, il monaco può sostituire ciascuno dei colpi senz'armi con un utilizzo di Mano guaritrice, senza spendere punti concentrazione per la guarigione.\n\nInoltre, quando un colpo senz'armi di Raffica di colpi infligge danni, può applicare a quel colpo Mano del dolore senza spendere il punto concentrazione richiesto; Mano del dolore resta comunque utilizzabile una sola volta per turno.\n\nIl monaco può usare questi benefici un numero complessivo di volte pari al suo modificatore di Saggezza (almeno una) e recupera tutti gli utilizzi dopo un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/hand-of-ultimate-mercy"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/hand-of-ultimate-mercy", "en"), Language = LanguageCode.En, Name = "Hand of Ultimate Mercy", Description = "Your command of life energy opens the way to the greatest mercy. As a Magic action, you can touch the corpse of a creature that died within the last 24 hours and spend 5 Focus Points: it returns to life with Hit Points equal to 4d10 plus your Wisdom modifier, freed of any Blinded, Deafened, Paralyzed, Poisoned, or Stunned condition it had when it died. You can use this feature once per Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-mercy/hand-of-ultimate-mercy", "it"), Language = LanguageCode.It, Name = "Mano della Misericordia Suprema", Description = "La padronanza dell'energia vitale schiude al monaco la misericordia suprema. Con un'azione di Magia, può toccare il cadavere di una creatura morta nelle ultime 24 ore e spendere 5 punti concentrazione: la creatura torna in vita con un numero di punti ferita pari a 4d10 + il modificatore di Saggezza del monaco, libera dalle condizioni accecato, assordato, avvelenato, paralizzato e stordito che aveva al momento della morte. Dopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo." }
					}
				}
			}
		};
	}
}
