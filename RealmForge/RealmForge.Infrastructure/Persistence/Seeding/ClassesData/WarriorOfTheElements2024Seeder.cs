using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Warrior of the Elements (monk, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class WarriorOfTheElements2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-the-elements");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-the-elements", "en"), Language = LanguageCode.En, Name = "Warrior of the Elements", Description = "Warriors of the Elements draw on the might of the Elemental Planes. Through their extraordinary focus, these Monks briefly bend the raw energy of the Elemental Chaos to their will, strengthening themselves both in battle and beyond it." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-the-elements", "it"), Language = LanguageCode.It, Name = "Guerriero degli Elementi", Description = "I guerrieri degli elementi attingono alla potenza dei Piani Elementali. Grazie alla loro straordinaria concentrazione, questi monaci piegano per brevi istanti al proprio volere l'energia grezza del Caos Elementale, rafforzandosi in battaglia e fuori da essa." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/elemental-attunement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/elemental-attunement", "en"), Language = LanguageCode.En, Name = "Elemental Attunement", Description = "At the start of your turn, you can spend 1 Focus Point to fill yourself with elemental energy for 10 minutes or until you become Incapacitated. While it is active, you gain these benefits.\n\n**Reach.** Your Unarmed Strikes reach 10 feet farther than normal, as elemental energy stretches out from you.\n\n**Elemental Strikes.** Each time your Unarmed Strike hits, you can make it deal Acid, Cold, Fire, Lightning, or Thunder damage (your choice) instead of its usual type. When it deals one of those types, you can also force the target to make a Strength saving throw; on a failure, you can shift it up to 10 feet toward or away from you as elemental energy whirls around it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/elemental-attunement", "it"), Language = LanguageCode.It, Name = "Sintonia Elementale", Description = "All'inizio del suo turno, il monaco può spendere 1 punto concentrazione per infondersi di energia elementale, che dura 10 minuti o finché non subisce la condizione di incapacitato. Finché il privilegio è attivo, ottiene i benefici seguenti.\n\n**Portata.** Quando effettua un colpo senz'armi, la sua portata aumenta di 3 metri, perché l'energia elementale si protende da lui.\n\n**Colpi elementali.** Ogni volta che colpisce con un colpo senz'armi, il monaco può fargli infliggere danni da acido, da freddo, da fuoco, da fulmine o da tuono (a sua scelta) anziché il tipo normale. Quando infligge uno di questi tipi di danni, può anche costringere il bersaglio a un tiro salvezza su Forza: se lo fallisce, il monaco può spostarlo fino a 3 metri verso di sé o lontano da sé, mentre l'energia elementale gli turbina attorno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/manipulate-elements"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/manipulate-elements", "en"), Language = LanguageCode.En, Name = "Manipulate Elements", Description = "You know the *Elementalism* spell, using Wisdom as your spellcasting ability for it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/manipulate-elements", "it"), Language = LanguageCode.It, Name = "Manipolare gli Elementi", Description = "Il monaco conosce l'incantesimo *elementalismo*, per il quale la sua caratteristica da incantatore è la Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/elemental-burst"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/elemental-burst", "en"), Language = LanguageCode.En, Name = "Elemental Burst", Description = "As a Magic action, you can spend 2 Focus Points to make elemental energy erupt in a 20-foot-radius Sphere centered on a point within 120 feet of you. Pick Acid, Cold, Fire, Lightning, or Thunder: each creature in the Sphere makes a Dexterity saving throw, taking damage of that type equal to three rolls of your Martial Arts die on a failure, or half as much on a success." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/elemental-burst", "it"), Language = LanguageCode.It, Name = "Esplosione Elementale", Description = "Con un'azione di Magia, il monaco può spendere 2 punti concentrazione per far esplodere energia elementale in una sfera del raggio di 6 metri centrata su un punto entro 36 metri da lui. Sceglie un tipo di danni tra acido, freddo, fuoco, fulmine e tuono: ogni creatura nella sfera effettua un tiro salvezza su Destrezza e, se lo fallisce, subisce danni del tipo scelto pari a tre tiri del dado di Arti marziali; se lo supera, ne subisce la metà." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/stride-of-the-elements"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/stride-of-the-elements", "en"), Language = LanguageCode.En, Name = "Stride of the Elements", Description = "As long as Elemental Attunement is running, the elements carry you: you can fly and swim at your normal Speed." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/stride-of-the-elements", "it"), Language = LanguageCode.It, Name = "Passo degli Elementi", Description = "Per tutto il tempo in cui Sintonia elementale è attiva, gli elementi sostengono il monaco: può volare e nuotare alla sua velocità normale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/elemental-epitome"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/elemental-epitome", "en"), Language = LanguageCode.En, Name = "Elemental Epitome", Description = "While your Elemental Attunement is active, you also gain these benefits.\n\n**Damage Resistance.** You resist one damage type of your choice from Acid, Cold, Fire, Lightning, and Thunder, and you can switch the choice at the start of each of your turns.\n\n**Destructive Stride.** When you use Step of the Wind, your Speed rises by 20 feet until the end of the turn. During that time, whenever you enter a space within 5 feet of a creature you choose, it takes damage equal to one roll of your Martial Arts die, of a type you pick from Acid, Cold, Fire, Lightning, and Thunder. A creature can take this damage only once per turn.\n\n**Empowered Strikes.** Once on each of your turns, when your Unarmed Strike hits a target, you can add extra damage equal to one roll of your Martial Arts die, of the same type as the strike." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-the-elements/elemental-epitome", "it"), Language = LanguageCode.It, Name = "Quintessenza Elementale", Description = "Finché Sintonia elementale è attiva, il monaco ottiene anche i benefici seguenti.\n\n**Resistenza ai danni.** Il monaco ha resistenza a un tipo di danni a sua scelta tra acido, freddo, fuoco, fulmine e tuono, e all'inizio di ognuno dei suoi turni può cambiare la scelta.\n\n**Passo distruttivo.** Quando usa Passo del vento, la sua velocità aumenta di 6 metri fino alla fine del turno. Per quella durata, quando entra in uno spazio entro 1,5 metri da una creatura a sua scelta, quella creatura subisce danni pari a un tiro del dado di Arti marziali, del tipo che il monaco sceglie tra acido, freddo, fuoco, fulmine e tuono. Una creatura può subire questi danni una sola volta per turno.\n\n**Colpi potenziati.** Una volta in ognuno dei suoi turni, quando colpisce un bersaglio con un colpo senz'armi, il monaco può infliggergli danni extra pari a un tiro del dado di Arti marziali, dello stesso tipo del colpo." }
					}
				}
			}
		};
	}
}
