using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Assassin (rogue, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class Assassin2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "assassin");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Rogue2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "assassin", "en"), Language = LanguageCode.En, Name = "Assassin", Description = "An Assassin trains in stealth, poison and disguise to take down foes with lethal efficiency. Some Rogues on this path are paid killers, spies or bounty hunters, but these talents serve just as well for adventurers who face all manner of monstrous enemies." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "assassin", "it"), Language = LanguageCode.It, Name = "Assassino", Description = "L'assassino si addestra nella furtività, nei veleni e nei travestimenti per eliminare i nemici con un'efficienza letale. Alcuni ladri che seguono questa via sono sicari, spie o cacciatori di taglie, ma le stesse capacità tornano altrettanto utili agli avventurieri che affrontano nemici mostruosi di ogni genere." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/assassinate"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/assassinate", "en"), Language = LanguageCode.En, Name = "Assassinate", Description = "You excel at catching a target unawares and gain these benefits.\n\n**Initiative.** Your Initiative rolls have Advantage.\n\n**Surprising Strikes.** During the first round of each combat, your attack rolls have Advantage against any creature that hasn't yet taken a turn. If your Sneak Attack hits a target in that round, the target also takes extra damage of the weapon's type equal to your Rogue level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/assassinate", "it"), Language = LanguageCode.It, Name = "Assassinare", Description = "Il ladro è abile nel tendere agguati e ottiene i benefici seguenti.\n\n**Iniziativa.** Il ladro dispone di vantaggio ai tiri per l'iniziativa.\n\n**Colpi a sorpresa.** Durante il primo round di ogni combattimento, il ladro dispone di vantaggio ai tiri per colpire contro qualsiasi creatura che non abbia ancora svolto un turno. Se in quel round il suo Attacco furtivo colpisce un bersaglio, quest'ultimo subisce danni extra del tipo dell'arma pari al livello da ladro." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/assassins-tools"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/assassins-tools", "en"), Language = LanguageCode.En, Name = "Assassin's Tools", Description = "You acquire a Disguise Kit and a Poisoner's Kit and are proficient with both." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/assassins-tools", "it"), Language = LanguageCode.It, Name = "Arnesi dell'Assassino", Description = "Il ladro ottiene un kit per il camuffamento e delle sostanze da avvelenatore, e ha competenza in entrambi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/infiltration-expertise"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 9,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/infiltration-expertise", "en"), Language = LanguageCode.En, Name = "Infiltration Expertise", Description = "You have mastered techniques that help you slip in where you don't belong.\n\n**Masterful Mimicry.** After studying someone for at least 1 hour, you can flawlessly copy their voice, their handwriting, or both.\n\n**Roving Aim.** Using Steady Aim doesn't drop your Speed to 0." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/infiltration-expertise", "it"), Language = LanguageCode.It, Name = "Maestro Infiltrato", Description = "Il ladro padroneggia tecniche che lo aiutano a infiltrarsi.\n\n**Imitazione sopraffina.** Dopo aver studiato una persona per almeno 1 ora, il ladro sa imitarne alla perfezione la voce, la calligrafia o entrambe.\n\n**Mira in movimento.** Usare Mira ferma non riduce a 0 la velocità del ladro." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/envenom-weapons"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 13,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/envenom-weapons", "en"), Language = LanguageCode.En, Name = "Envenom Weapons", Description = "When you use the Poison option of Cunning Strike, the target also takes 2d6 Poison damage each time it fails the save. This damage bypasses Resistance to Poison damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/envenom-weapons", "it"), Language = LanguageCode.It, Name = "Avvelenare Armi", Description = "Quando usa l'opzione Veleno di Colpo astuto, il bersaglio subisce anche 2d6 danni da veleno ogni volta che fallisce il tiro salvezza. Questi danni ignorano la resistenza ai danni da veleno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/death-strike"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/death-strike", "en"), Language = LanguageCode.En, Name = "Death Strike", Description = "Your opening blow can be lethal. If your Sneak Attack lands in a combat's first round, the creature you struck makes a Constitution save against a DC of 8 plus your Dexterity modifier and Proficiency Bonus; failing it means the attack deals it twice its normal damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "assassin/death-strike", "it"), Language = LanguageCode.It, Name = "Colpo di Morte", Description = "Quando colpisce con l'Attacco furtivo durante il primo round di un combattimento, il bersaglio deve superare un tiro salvezza su Costituzione (CD 8 + il modificatore di Destrezza del ladro + il suo bonus di competenza), altrimenti i danni dell'attacco contro di lui raddoppiano." }
					}
				}
			}
		};
	}
}
