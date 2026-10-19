using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Assassin (rogue, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class Assassin2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "assassin");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Rogue2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "assassin", "en"), Language = LanguageCode.En, Name = "Assassin", Description = "Assassins devote their training to the grim business of killing. Hired blades, spies, bounty hunters and even priests sworn to wipe out their god's enemies follow this path, relying on stealth, poison and disguise to remove their targets with ruthless efficiency." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "assassin", "it"), Language = LanguageCode.It, Name = "Assassino", Description = "Gli assassini dedicano il loro addestramento alla cupa arte di uccidere. Sicari prezzolati, spie, cacciatori di taglie e persino sacerdoti votati a sterminare i nemici del loro dio seguono questa strada, affidandosi a furtività, veleni e travestimenti per eliminare i propri bersagli con spietata efficienza." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/bonus-proficiencies"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/bonus-proficiencies", "en"), Language = LanguageCode.En, Name = "Bonus Proficiencies", Description = "When you choose this archetype at 3rd level, you become proficient with the disguise kit and the poisoner's kit." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/bonus-proficiencies", "it"), Language = LanguageCode.It, Name = "Competenze Bonus", Description = "Quando sceglie questo archetipo al 3° livello, il ladro ottiene competenza negli arnesi per il camuffamento e negli strumenti da avvelenatore." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/assassinate"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/assassinate", "en"), Language = LanguageCode.En, Name = "Assassinate", Description = "From 3rd level, you are deadliest when you strike first. You have advantage on attack rolls against any creature that hasn't yet taken a turn in the combat, and every hit you land on a surprised creature is a critical hit." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/assassinate", "it"), Language = LanguageCode.It, Name = "Assassinare", Description = "Dal 3° livello il ladro è più letale quando colpisce per primo. Dispone di vantaggio ai tiri per colpire contro qualsiasi creatura che non abbia ancora effettuato un turno nel combattimento, e ogni colpo che mette a segno contro una creatura sorpresa è un colpo critico." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/infiltration-expertise"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 9,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/infiltration-expertise", "en"), Language = LanguageCode.En, Name = "Infiltration Expertise", Description = "From 9th level, you can build flawless false identities. Spending seven days and 25 gp, you establish the history, profession and connections of an identity, which can't be one that already belongs to someone else. You might, for example, gather the right clothes, letters of introduction and official-looking papers to pass as a member of a trading house from a faraway city and mingle with other wealthy merchants. From then on, when you take on that identity as a disguise, other creatures believe you are that person until they are given an obvious reason not to." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/infiltration-expertise", "it"), Language = LanguageCode.It, Name = "Maestro Infiltrato", Description = "Dal 9° livello il ladro è in grado di costruire false identità impeccabili. Spendendo sette giorni e 25 mo, stabilisce la storia, la professione e i legami di un'identità, che non può essere quella di qualcun altro già esistente. Potrebbe, per esempio, procurarsi gli abiti adatti, lettere di presentazione e documenti dall'aspetto ufficiale per spacciarsi per un membro di una casa commerciale di una città lontana e mescolarsi ad altri ricchi mercanti. Da quel momento, quando assume quell'identità come travestimento, le altre creature credono che sia quella persona finché non ricevono un motivo evidente per pensare il contrario." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/impostor"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 13,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/impostor", "en"), Language = LanguageCode.En, Name = "Impostor", Description = "At 13th level, you can imitate another person's speech, handwriting and behavior perfectly. You must first spend at least three hours studying them: listening to the person talk, examining their writing and watching their mannerisms. A casual observer can't see through your act, and if a wary creature suspects something is off, you have advantage on any Charisma (Deception) check you make to avoid being found out." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/impostor", "it"), Language = LanguageCode.It, Name = "Impostore", Description = "Al 13° livello il ladro può imitare alla perfezione il modo di parlare, la calligrafia e il comportamento di un'altra persona. Prima deve passare almeno tre ore a studiarla: ascoltandola parlare, esaminando la sua scrittura e osservando i suoi atteggiamenti. Un osservatore occasionale non può smascherare la sua recita, e se una creatura sospettosa intuisce che qualcosa non va, il ladro dispone di vantaggio a qualsiasi prova di Carisma (Inganno) che effettua per non essere scoperto." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/death-strike"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/death-strike", "en"), Language = LanguageCode.En, Name = "Death Strike", Description = "From 17th level, you deal death in an instant. When you attack and hit a surprised creature, it makes a Constitution saving throw (DC 8 + your Dexterity modifier + your proficiency bonus). On a failure, the damage of your attack against it is doubled." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "assassin/death-strike", "it"), Language = LanguageCode.It, Name = "Colpo Mortale", Description = "Dal 17° livello il ladro porta la morte in un istante. Quando attacca e colpisce una creatura sorpresa, quella creatura effettua un tiro salvezza su Costituzione (CD 8 + il modificatore di Destrezza del ladro + il suo bonus di competenza). Se lo fallisce, i danni dell'attacco contro di essa raddoppiano." }
					}
				}
			}
		};
	}
}
