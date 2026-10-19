using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Path of the Wild Heart (barbarian, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class PathOfTheWildHeart2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-wild-heart");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Barbarian2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-wild-heart", "en"), Language = LanguageCode.En, Name = "Path of the Wild Heart", Description = "These Barbarians feel a kinship with every creature of the wild. They learn to speak with animals through a touch of nature magic, and when their Rage rises it binds them ever closer to the beasts, borrowing their strength, senses and cunning." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-wild-heart", "it"), Language = LanguageCode.It, Name = "Cammino del Cuore Selvaggio", Description = "Questi barbari si sentono imparentati con ogni creatura della natura selvaggia. Imparano a parlare con gli animali grazie a un pizzico di magia naturale e, quando l'ira si risveglia, si legano ancora di più alle bestie, prendendone in prestito la forza, i sensi e l'astuzia." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/animal-speaker"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/animal-speaker", "en"), Language = LanguageCode.En, Name = "Animal Speaker", Description = "You know how to cast *Beast Sense* and *Speak with Animals* in their Ritual form only, using Wisdom as your spellcasting ability." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/animal-speaker", "it"), Language = LanguageCode.It, Name = "Portavoce degli Animali", Description = "Il barbaro può lanciare gli incantesimi *percezione delle bestie* e *parlare con gli animali*, ma solo come rituali. La sua caratteristica da incantatore per questi incantesimi è la Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/rage-of-the-wilds"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/rage-of-the-wilds", "en"), Language = LanguageCode.En, Name = "Rage of the Wilds", Description = "Your Rage draws on the primal might of beasts. Each time you enter your Rage, pick one of these options.\n\n**Bear.** For as long as your Rage lasts, you have Resistance to all damage types other than Force, Necrotic, Psychic, and Radiant.\n\n**Eagle.** As part of the Bonus Action that starts your Rage, you can take both the Disengage and Dash actions. For as long as your Rage lasts, a Bonus Action lets you take both of those actions again.\n\n**Wolf.** For as long as your Rage lasts, your allies roll with Advantage when they attack an enemy of yours that stands within 5 feet of you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/rage-of-the-wilds", "it"), Language = LanguageCode.It, Name = "Ira della Natura Selvaggia", Description = "L'ira del barbaro attinge al potere primordiale delle bestie. Ogni volta che entra in ira, sceglie una delle opzioni seguenti.\n\n**Orso.** Finché l'ira è attiva, il barbaro ha resistenza a tutti i tipi di danni tranne forza, necrotici, psichici e radiosi.\n\n**Aquila.** Quando entra in ira, il barbaro può effettuare le azioni di Disimpegno e di Scatto come parte della stessa azione bonus. Finché l'ira è attiva, può usare un'azione bonus per effettuarle entrambe.\n\n**Lupo.** Finché l'ira è attiva, gli alleati del barbaro dispongono di vantaggio ai tiri per colpire contro i nemici del barbaro che si trovano entro 1,5 metri da lui." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/aspect-of-the-wilds"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/aspect-of-the-wilds", "en"), Language = LanguageCode.En, Name = "Aspect of the Wilds", Description = "Pick one of these options. You can swap it for another each time you finish a Long Rest.\n\n**Owl.** You gain Darkvision out to 60 feet, or 60 extra feet of range if you already have Darkvision.\n\n**Panther.** You gain a Climb Speed that matches your Speed.\n\n**Salmon.** You gain a Swim Speed that matches your Speed." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/aspect-of-the-wilds", "it"), Language = LanguageCode.It, Name = "Aspetto della Natura Selvaggia", Description = "Il barbaro sceglie una delle opzioni seguenti. Può cambiare scelta ogni volta che completa un riposo lungo.\n\n**Gufo.** Il barbaro ha scurovisione con un raggio di 18 metri. Se ha già la scurovisione, il suo raggio aumenta di 18 metri.\n\n**Pantera.** Il barbaro ha una velocità di scalare pari alla sua velocità.\n\n**Salmone.** Il barbaro ha una velocità di nuotare pari alla sua velocità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/nature-speaker"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/nature-speaker", "en"), Language = LanguageCode.En, Name = "Nature Speaker", Description = "*Commune with Nature* joins your magic: you can cast it, but only in its Ritual form, using Wisdom as your spellcasting ability." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/nature-speaker", "it"), Language = LanguageCode.It, Name = "Portavoce della Natura", Description = "Il barbaro può lanciare l'incantesimo *comunione con la natura*, ma solo come rituale. La sua caratteristica da incantatore per questo incantesimo è la Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/power-of-the-wilds"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/power-of-the-wilds", "en"), Language = LanguageCode.En, Name = "Power of the Wilds", Description = "Each time you enter your Rage, pick one of these options.\n\n**Falcon.** For as long as your Rage lasts and you wear no armor, you gain a Fly Speed that matches your Speed.\n\n**Lion.** For as long as your Rage lasts, enemies within 5 feet of you roll with Disadvantage when they attack anyone other than you or another Barbarian who has this option active.\n\n**Ram.** For as long as your Rage lasts, when you hit a Large or smaller creature with a melee attack, you can knock it Prone." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-wild-heart/power-of-the-wilds", "it"), Language = LanguageCode.It, Name = "Potere della Natura Selvaggia", Description = "Ogni volta che entra in ira, il barbaro sceglie una delle opzioni seguenti.\n\n**Falco.** Finché l'ira è attiva e il barbaro non indossa alcuna armatura, ha una velocità di volare pari alla sua velocità.\n\n**Leone.** Finché l'ira è attiva, i nemici del barbaro che si trovano entro 1,5 metri da lui subiscono svantaggio ai tiri per colpire contro bersagli diversi dal barbaro o da un altro barbaro che ha questa opzione attiva.\n\n**Ariete.** Finché l'ira è attiva, quando il barbaro colpisce con un attacco in mischia una creatura di taglia Grande o inferiore, può farle subire la condizione di prono." }
					}
				}
			}
		};
	}
}
