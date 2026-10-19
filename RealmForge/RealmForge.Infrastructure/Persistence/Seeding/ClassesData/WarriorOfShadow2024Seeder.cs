using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Warrior of Shadow (monk, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class WarriorOfShadow2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-shadow");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-shadow", "en"), Language = LanguageCode.En, Name = "Warrior of Shadow", Description = "Warriors of Shadow follow a path of stealth and trickery fed by the power of the Shadowfell. Darkness is their home: they gather gloom around themselves to vanish, slip from one shadow to the next and take on a ghostly form." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "warrior-of-shadow", "it"), Language = LanguageCode.It, Name = "Guerriero dell'Ombra", Description = "I guerrieri dell'ombra seguono una via di furtività e inganno alimentata dal potere della Coltre Oscura. L'oscurità è la loro casa: raccolgono le tenebre attorno a sé per sparire, scivolano da un'ombra all'altra e assumono una forma spettrale." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/shadow-arts"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/shadow-arts", "en"), Language = LanguageCode.En, Name = "Shadow Arts", Description = "You have learned to draw on the Shadowfell's power and gain these benefits.\n\n**Darkness.** You can spend 1 Focus Point to cast *Darkness* without components. When cast this way, you can see inside the spell's area, and while it lasts you can move that area to a space within 60 feet of you at the start of each of your turns.\n\n**Darkvision.** You gain Darkvision out to 60 feet; if you already have it, its range grows by 60 feet.\n\n**Shadowy Figments.** You know the *Minor Illusion* spell, using Wisdom as your spellcasting ability for it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/shadow-arts", "it"), Language = LanguageCode.It, Name = "Arti dell'Ombra", Description = "Il monaco ha imparato ad attingere al potere della Coltre Oscura e ottiene i benefici seguenti.\n\n**Oscurità.** Il monaco può spendere 1 punto concentrazione per lanciare l'incantesimo *oscurità* senza componenti. Quando lo lancia in questo modo, è in grado di vedere all'interno dell'area dell'incantesimo e, finché l'incantesimo dura, all'inizio di ognuno dei suoi turni può spostarne l'area in uno spazio entro 18 metri da lui.\n\n**Scurovisione.** Il monaco ottiene scurovisione con un raggio di 18 metri; se ne possiede già, il raggio aumenta di 18 metri.\n\n**Apparizioni oscure.** Il monaco conosce l'incantesimo *illusione minore*, per il quale la sua caratteristica da incantatore è la Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/shadow-step"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/shadow-step", "en"), Language = LanguageCode.En, Name = "Shadow Step", Description = "When you stand fully in Dim Light or Darkness, a Bonus Action lets you step through the shadows to another unoccupied space you can see, up to 60 feet away, that is likewise dim or dark. Until your turn ends, your next melee attack gains Advantage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/shadow-step", "it"), Language = LanguageCode.It, Name = "Passo d'Ombra", Description = "Finché si trova interamente in luce fioca o nell'oscurità, il monaco può usare un'azione bonus per teletrasportarsi fino a 18 metri in uno spazio libero che è in grado di vedere e che si trova anch'esso in luce fioca o nell'oscurità. Il suo successivo attacco in mischia prima della fine del turno dispone di vantaggio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/improved-shadow-step"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/improved-shadow-step", "en"), Language = LanguageCode.En, Name = "Improved Shadow Step", Description = "Your bond with the Shadowfell strengthens your teleportation. When you use Shadow Step, you can spend 1 Focus Point to ignore, for that use, the need to start and finish in Dim Light or Darkness. As part of the same Bonus Action, right after teleporting, you can make an Unarmed Strike." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/improved-shadow-step", "it"), Language = LanguageCode.It, Name = "Passo d'Ombra Migliorato", Description = "Il legame con la Coltre Oscura potenzia il teletrasporto del monaco. Quando usa Passo d'ombra, può spendere 1 punto concentrazione per ignorare, in quell'utilizzo, il requisito di partire e arrivare in luce fioca o nell'oscurità. Come parte della stessa azione bonus, subito dopo il teletrasporto, può effettuare un colpo senz'armi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/cloak-of-shadows"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/cloak-of-shadows", "en"), Language = LanguageCode.En, Name = "Cloak of Shadows", Description = "As a Magic action while wholly within Dim Light or Darkness, you can spend 3 Focus Points to wrap yourself in shadow for 1 minute, until you become Incapacitated, or until you end your turn in Bright Light. While cloaked, you gain these benefits.\n\n**Invisibility.** You have the Invisible condition.\n\n**Partially Incorporeal.** You can pass through occupied spaces as though they were Difficult Terrain. If your turn ends in such a space, you are pushed back to the last unoccupied space you were in.\n\n**Shadow Flurry.** You can use Flurry of Blows without spending Focus Points." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "warrior-of-shadow/cloak-of-shadows", "it"), Language = LanguageCode.It, Name = "Manto di Ombre", Description = "Con un'azione di Magia, mentre si trova interamente in luce fioca o nell'oscurità, il monaco può spendere 3 punti concentrazione per avvolgersi nelle ombre per 1 minuto, finché non subisce la condizione di incapacitato o finché non termina il turno in luce intensa. Mentre è avvolto dalle ombre, ottiene i benefici seguenti.\n\n**Invisibilità.** Il monaco ha la condizione di invisibile.\n\n**Parzialmente incorporeo.** Il monaco può attraversare gli spazi occupati come se fossero terreno difficile. Se termina il turno in uno di quegli spazi, viene spinto nell'ultimo spazio libero che ha occupato.\n\n**Raffica di ombre.** Il monaco può usare Raffica di colpi senza spendere punti concentrazione." }
					}
				}
			}
		};
	}
}
