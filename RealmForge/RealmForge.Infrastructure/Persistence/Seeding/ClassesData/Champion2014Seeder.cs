using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Champion (fighter, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Champion2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "champion");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Fighter2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "champion", "en"), Language = LanguageCode.En, Name = "Champion", Description = "The archetypal Champion focuses on the development of raw physical power honed to deadly perfection. Those who model themselves on this archetype combine rigorous training with physical excellence to deal devastating blows." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "champion", "it"), Language = LanguageCode.It, Name = "Campione", Description = "L'archetipo del Campione è incentrato sullo sviluppo della pura potenza fisica, affinata fino a una perfezione letale. Chi si ispira a questo archetipo unisce un addestramento rigoroso a un'eccellenza fisica che gli permette di sferrare colpi devastanti." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/improved-critical"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/improved-critical", "en"), Language = LanguageCode.En, Name = "Improved Critical", Description = "Your weapon attacks score a critical hit on a roll of 19 or 20." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/improved-critical", "it"), Language = LanguageCode.It, Name = "Critico Migliorato", Description = "Gli attacchi con un'arma del guerriero mettono a segno un colpo critico con un risultato di 19 o 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/remarkable-athlete"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/remarkable-athlete", "en"), Language = LanguageCode.En, Name = "Remarkable Athlete", Description = "You can add half your proficiency bonus (round up) to any Strength, Dexterity, or Constitution check you make that doesn't already use your proficiency bonus.\n\nIn addition, when you make a running long jump, the distance you can cover increases by a number of feet equal to your Strength modifier." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/remarkable-athlete", "it"), Language = LanguageCode.It, Name = "Atleta Straordinario", Description = "Il guerriero può aggiungere metà del suo bonus di competenza (arrotondata per eccesso) a qualsiasi prova di Forza, Destrezza o Costituzione che effettua e che non usi già il suo bonus di competenza.\n\nInoltre, quando effettua un salto in lungo con rincorsa, la distanza che può coprire aumenta di un numero di metri pari a 0,3 × il suo modificatore di Forza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/additional-fighting-style"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 10,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/additional-fighting-style", "en"), Language = LanguageCode.En, Name = "Additional Fighting Style", Description = "At 10th level, you can choose a second option from the Fighting Style class feature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/additional-fighting-style", "it"), Language = LanguageCode.It, Name = "Stile di Combattimento Aggiuntivo", Description = "Al 10° livello il guerriero può scegliere una seconda opzione dal privilegio di classe Stile di Combattimento." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/superior-critical"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 15,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/superior-critical", "en"), Language = LanguageCode.En, Name = "Superior Critical", Description = "Your weapon attacks score a critical hit on a roll of 18–20." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/superior-critical", "it"), Language = LanguageCode.It, Name = "Critico Superiore", Description = "Gli attacchi con un'arma del guerriero mettono a segno un colpo critico con un risultato da 18 a 20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/survivor"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 18,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/survivor", "en"), Language = LanguageCode.En, Name = "Survivor", Description = "You attain the pinnacle of resilience in battle.\n\nAt the start of each of your turns, you regain hit points equal to 5 + your Constitution modifier if you have no more than half of your hit points left.\n\nYou don't gain this benefit if you have 0 hit points." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "champion/survivor", "it"), Language = LanguageCode.It, Name = "Sopravvissuto", Description = "Il guerriero raggiunge l'apice della resistenza in battaglia.\n\nAll'inizio di ognuno dei suoi turni, se non gli resta più della metà dei suoi punti ferita, recupera punti ferita pari a 5 + il suo modificatore di Costituzione.\n\nNon ottiene questo beneficio se è a 0 punti ferita." }
					}
				}
			}
		};
	}
}
