using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	College of Valor (bard, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class CollegeOfValor2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "college-of-valor");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Bard2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "college-of-valor", "en"), Language = LanguageCode.En, Name = "College of Valor", Description = "Bards of this college carry the memory of great deeds. They wander from hall to battlefield, singing the stories of heroes so that their courage is never forgotten, and they are not afraid to step into the fight themselves to give those songs a new chapter. Their performances stir the listeners to rise to the same heights." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "college-of-valor", "it"), Language = LanguageCode.It, Name = "Collegio del Valore", Description = "I bardi di questo collegio custodiscono la memoria delle grandi imprese. Viaggiano dalle sale dei banchetti ai campi di battaglia, cantando le storie degli eroi perché il loro coraggio non venga mai dimenticato, e non hanno paura di gettarsi a loro volta nella mischia per aggiungere un nuovo capitolo a quei canti. Le loro esibizioni spingono chi ascolta a raggiungere le stesse vette." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/bonus-proficiencies"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/bonus-proficiencies", "en"), Language = LanguageCode.En, Name = "Bonus Proficiencies", Description = "On joining the College of Valor at 3rd level, you become proficient with medium armor, shields, and martial weapons." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/bonus-proficiencies", "it"), Language = LanguageCode.It, Name = "Competenze Bonus", Description = "Quando si unisce al Collegio del Valore al 3° livello, il bardo ottiene competenza nelle armature medie, negli scudi e nelle armi da guerra." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/combat-inspiration"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/combat-inspiration", "en"), Language = LanguageCode.En, Name = "Combat Inspiration", Description = "Also at 3rd level, your inspiration can be used in the heat of a fight. A creature holding one of your Bardic Inspiration dice can spend it in either of these ways:\n- **Damage.** Right after it rolls damage for a weapon attack, it rolls the die and adds the result to that damage.\n- **Defense.** When an attack roll is made against it, it can use its reaction to roll the die and add the result to its AC against that attack. It decides after seeing the attack roll, but before learning whether the attack hits." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/combat-inspiration", "it"), Language = LanguageCode.It, Name = "Ispirazione in Combattimento", Description = "Sempre al 3° livello, l'ispirazione del bardo può essere sfruttata nel pieno della battaglia. Una creatura che possiede uno dei suoi dadi di Ispirazione Bardica può spenderlo in uno di questi due modi:\n- **Danni.** Subito dopo aver tirato i danni di un attacco con un'arma, tira il dado e ne aggiunge il risultato a quei danni.\n- **Difesa.** Quando viene effettuato un tiro per colpire contro di lei, può usare la sua reazione per tirare il dado e aggiungerne il risultato alla propria CA contro quell'attacco. Decide dopo aver visto il tiro per colpire, ma prima di sapere se l'attacco va a segno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/extra-attack"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/extra-attack", "en"), Language = LanguageCode.En, Name = "Extra Attack", Description = "From 6th level, whenever you take the Attack action on your turn, you can make two attacks instead of one." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/extra-attack", "it"), Language = LanguageCode.It, Name = "Attacco Extra", Description = "Dal 6° livello, ogni volta che effettua l'azione di Attacco nel proprio turno, il bardo può attaccare due volte anziché una." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/battle-magic"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/battle-magic", "en"), Language = LanguageCode.En, Name = "Battle Magic", Description = "At 14th level, you weave spells and steel together. Whenever you use your action to cast a bard spell, you can make one weapon attack as a bonus action on that same turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "college-of-valor/battle-magic", "it"), Language = LanguageCode.It, Name = "Magia da Battaglia", Description = "Al 14° livello il bardo fonde incantesimi e acciaio. Nei turni in cui spende la sua azione nel lancio di un incantesimo da bardo, gli è concesso anche un attacco con un'arma, che effettua come azione bonus." }
					}
				}
			}
		};
	}
}
