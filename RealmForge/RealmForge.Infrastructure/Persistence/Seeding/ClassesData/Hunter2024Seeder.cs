using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Hunter (ranger, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Hunter2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "hunter");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Ranger2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "hunter", "en"), Language = LanguageCode.En, Name = "Hunter", Description = "You stalk prey in the wilds and elsewhere, using your abilities as a Hunter to protect nature and people everywhere from forces that would destroy them." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "hunter", "it"), Language = LanguageCode.It, Name = "Cacciatore", Description = "Il ranger bracca le sue prede nelle terre selvagge e altrove, usando le sue capacità di cacciatore per proteggere la natura e le persone, ovunque si trovino, dalle forze che vorrebbero distruggerle." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/hunters-lore"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/hunters-lore", "en"), Language = LanguageCode.En, Name = "Hunter's Lore", Description = "You can call on the forces of nature to reveal certain strengths and weaknesses of your prey. While a creature is marked by your Hunter's Mark, you know whether that creature has any Immunities, Resistances, or Vulnerabilities, and if the creature has any, you know what they are." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/hunters-lore", "it"), Language = LanguageCode.It, Name = "Sapienza del Cacciatore", Description = "Il ranger può invocare le forze della natura affinché rivelino determinati punti di forza e di debolezza della sua preda. Finché una creatura è marchiata dal suo *marchio del cacciatore*, il ranger sa se quella creatura possiede immunità, resistenze o vulnerabilità e, in caso affermativo, quali sono." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/hunters-prey"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/hunters-prey", "en"), Language = LanguageCode.En, Name = "Hunter's Prey", Description = "You gain one of the following feature options of your choice. Whenever you finish a Short or Long Rest, you can replace the chosen option with the other one.\n\n**Colossus Slayer.** Your tenacity can wear down even the most resilient foes. When you hit a creature with a weapon, the weapon deals an extra 1d8 damage to the target if it’s missing any of its Hit Points. You can deal this extra damage only once per turn.\n\n**Horde Breaker.** Once on each of your turns when you make an attack with a weapon, you can make another attack with the same weapon against a different creature that is within 5 feet of the original target, that is within the weapon’s range, and that you haven’t attacked this turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/hunters-prey", "it"), Language = LanguageCode.It, Name = "Preda del Cacciatore", Description = "Il ranger ottiene una delle opzioni seguenti, a sua scelta. Ogni volta che completa un riposo breve o lungo, può sostituire l'opzione scelta con l'altra.\n\n**Sterminatore di colossi.** La tenacia del ranger può logorare anche i nemici più resistenti. Quando colpisce una creatura con un'arma, l'arma infligge al bersaglio 1d8 danni extra se questo ha perso dei punti ferita. Il ranger può infliggere questi danni extra una sola volta per turno.\n\n**Devastatore dell'orda.** Una volta in ognuno dei suoi turni, quando effettua un attacco con un'arma, il ranger può effettuare un altro attacco con la stessa arma contro una creatura diversa che si trovi entro 1,5 metri dal bersaglio originale, nella gittata o portata dell'arma, e che non abbia ancora attaccato in questo turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/defensive-tactics"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/defensive-tactics", "en"), Language = LanguageCode.En, Name = "Defensive Tactics", Description = "You gain one of the following feature options of your choice. Whenever you finish a Short or Long Rest, you can replace the chosen option with the other one.\n\n**Escape the Horde.** Opportunity Attacks have Disadvantage against you.\n\n**Multiattack Defense.** When a creature hits you with an attack roll, that creature has Disadvantage on all other attack rolls against you this turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/defensive-tactics", "it"), Language = LanguageCode.It, Name = "Tattiche Difensive", Description = "Il ranger ottiene una delle opzioni seguenti, a sua scelta. Ogni volta che completa un riposo breve o lungo, può sostituire l'opzione scelta con l'altra.\n\n**Sfuggire all'orda.** Gli attacchi di opportunità contro il ranger subiscono svantaggio.\n\n**Difesa dal multiattacco.** Quando una creatura colpisce il ranger con un tiro per colpire, quella creatura subisce svantaggio a tutti gli altri tiri per colpire contro di lui in quel turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/superior-hunters-prey"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 11,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/superior-hunters-prey", "en"), Language = LanguageCode.En, Name = "Superior Hunter's Prey", Description = "Once per turn when you deal damage to a creature marked by your Hunter's Mark, you can also deal that spell's extra damage to a different creature that you can see within 30 feet of the first creature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/superior-hunters-prey", "it"), Language = LanguageCode.It, Name = "Preda del Cacciatore Superiore", Description = "Una volta per turno, quando infligge danni a una creatura marchiata dal suo *marchio del cacciatore*, il ranger può infliggere i danni extra di quell'incantesimo anche a un'altra creatura che è in grado di vedere entro 9 metri dalla prima." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/superior-hunters-defense"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/superior-hunters-defense", "en"), Language = LanguageCode.En, Name = "Superior Hunter's Defense", Description = "When you take damage, you can take a Reaction to give yourself Resistance to that damage and any other damage of the same type until the end of the current turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "hunter/superior-hunters-defense", "it"), Language = LanguageCode.It, Name = "Difesa del Cacciatore Superiore", Description = "Quando subisce danni, il ranger può usare una reazione per ottenere resistenza a quei danni e a qualsiasi altro danno dello stesso tipo fino alla fine del turno in corso." }
					}
				}
			}
		};
	}
}
