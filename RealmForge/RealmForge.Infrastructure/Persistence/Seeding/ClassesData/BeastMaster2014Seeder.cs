using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Beast Master (ranger, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class BeastMaster2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "beast-master");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Ranger2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "beast-master", "en"), Language = LanguageCode.En, Name = "Beast Master", Description = "Beast Masters forge a deep partnership with an animal companion. Ranger and beast fight as one, protecting both civilized lands and the wild from the monsters that threaten them, and the bond between them is one of true friendship." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "beast-master", "it"), Language = LanguageCode.It, Name = "Signore delle Bestie", Description = "I Signori delle Bestie stringono un profondo legame con un compagno animale. Ranger e bestia combattono come una cosa sola, proteggendo sia le terre civilizzate sia le terre selvagge dai mostri che le minacciano, e il loro legame è una vera amicizia." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/ranger-s-companion"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/ranger-s-companion", "en"), Language = LanguageCode.En, Name = "Ranger's Companion", Description = "At 3rd level, a beast joins you on your adventures, trained to fight at your side. Choose a beast of Medium size or smaller with a challenge rating of 1/4 or lower (a hawk, mastiff, or panther, for example). Add your proficiency bonus to its AC, attack rolls and damage rolls, and to any saving throws and skills it is proficient in. Its hit point maximum is its normal maximum or four times your ranger level, whichever is higher.\n\nThe beast does its best to obey you. It acts on your initiative, but it takes an action only when you command it:\n- On your turn, you can tell it where to move, with no action required.\n- You can use your action to command it to take the Attack, Dash, Disengage, Dodge, or Help action. Once you have Extra Attack, you can also make one weapon attack yourself when you command the beast to Attack.\n\nWhen you travel through your favored terrain with only your beast for company, you can move stealthily at a normal pace.\n\nIf the beast dies, you can bond with a new one by spending 8 hours magically bonding with a beast that isn't hostile to you, of the same kind as before or a different one." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/ranger-s-companion", "it"), Language = LanguageCode.It, Name = "Compagno del Ranger", Description = "Al 3° livello una bestia si unisce al ranger nelle sue avventure, addestrata a combattere al suo fianco. Il ranger sceglie una bestia di taglia Media o inferiore con un grado di sfida pari o inferiore a 1/4 (per esempio un falco, un mastino o una pantera). Aggiunge il suo bonus di competenza alla CA, ai tiri per colpire e ai tiri per i danni della bestia, oltre che ai tiri salvezza e alle abilità in cui la bestia ha competenza. Il massimo dei punti ferita della bestia è pari al suo massimo normale o a quattro volte il livello da ranger, scegliendo il valore più alto.\n\nLa bestia fa del suo meglio per obbedire al ranger. Agisce con l'iniziativa del ranger, ma compie un'azione soltanto quando lui glielo ordina:\n- Nel suo turno, il ranger può dirle dove muoversi, senza bisogno di alcuna azione.\n- Il ranger può usare la sua azione per ordinarle di effettuare l'azione di Attacco, Scatto, Disimpegno, Schivata o Aiuto. Una volta ottenuto Attacco Extra, quando ordina alla bestia di attaccare può effettuare anche lui un attacco con un'arma.\n\nQuando viaggia nel suo terreno prescelto con la sola compagnia della sua bestia, il ranger può muoversi furtivamente a passo normale.\n\nSe la bestia muore, il ranger può legarsi a una nuova bestia trascorrendo 8 ore a creare un legame magico con una bestia che non gli sia ostile, dello stesso tipo della precedente o di un tipo diverso." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/exceptional-training"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/exceptional-training", "en"), Language = LanguageCode.En, Name = "Exceptional Training", Description = "From 7th level, on any turn when your companion doesn't attack, you can use a bonus action to command it to take the Dash, Disengage, Dodge, or Help action on its turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/exceptional-training", "it"), Language = LanguageCode.It, Name = "Addestramento Straordinario", Description = "Dal 7° livello, in qualsiasi turno in cui il suo compagno non attacca, il ranger può usare un'azione bonus per ordinargli di effettuare l'azione di Scatto, Disimpegno, Schivata o Aiuto nel suo turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/bestial-fury"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 11,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/bestial-fury", "en"), Language = LanguageCode.En, Name = "Bestial Fury", Description = "From 11th level, your companion makes two attacks whenever you command it to take the Attack action." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/bestial-fury", "it"), Language = LanguageCode.It, Name = "Furia Bestiale", Description = "Dall'11° livello, il compagno del ranger effettua due attacchi ogni volta che il ranger gli ordina di effettuare l'azione di Attacco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/share-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 15,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/share-spells", "en"), Language = LanguageCode.En, Name = "Share Spells", Description = "From 15th level, when you cast a spell that targets you, you can also have it affect your companion, as long as the beast is within 30 feet of you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "beast-master/share-spells", "it"), Language = LanguageCode.It, Name = "Condividere Incantesimi", Description = "Dal 15° livello, quando lancia un incantesimo che ha come bersaglio se stesso, il ranger può far sì che influenzi anche il suo compagno, purché la bestia si trovi entro 9 metri da lui." }
					}
				}
			}
		};
	}
}
