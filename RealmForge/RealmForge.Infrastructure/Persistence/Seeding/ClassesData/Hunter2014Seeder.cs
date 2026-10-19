using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Hunter (ranger, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Hunter2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "hunter");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Ranger2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "hunter", "en"), Language = LanguageCode.En, Name = "Hunter", Description = "Emulating the Hunter archetype means accepting your place as a bulwark between civilization and the terrors of the wilderness. As you walk the Hunter's path, you learn specialized techniques for fighting the threats you face, from rampaging ogres and hordes of orcs to towering giants and terrifying dragons." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "hunter", "it"), Language = LanguageCode.It, Name = "Cacciatore", Description = "Emulare l'archetipo del Cacciatore significa accettare il proprio ruolo di baluardo tra la civiltà e i terrori delle terre selvagge. Seguendo la via del Cacciatore, il ranger apprende tecniche specializzate per combattere le minacce che affronta, dagli ogre infuriati alle orde di orchi, fino ai giganti torreggianti e ai draghi terrificanti." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/hunter-s-prey"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/hunter-s-prey", "en"), Language = LanguageCode.En, Name = "Hunter's Prey", Description = "At 3rd level, you gain one of the following features of your choice.\n\n***Colossus Slayer.*** Your tenacity can wear down the most potent foes. When you hit a creature with a weapon attack, the creature takes an extra 1d8 damage if it's below its hit point maximum. You can deal this extra damage only once per turn.\n\n***Giant Killer.*** When a Large or larger creature within 5 feet of you hits or misses you with an attack, you can use your reaction to attack that creature immediately after its attack, provided that you can see the creature.\n\n***Horde Breaker.*** Once on each of your turns when you make a weapon attack, you can make another attack with the same weapon against a different creature that is within 5 feet of the original target and within range of your weapon." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/hunter-s-prey", "it"), Language = LanguageCode.It, Name = "Preda del Cacciatore", Description = "Al 3° livello il ranger ottiene uno dei privilegi seguenti a sua scelta.\n\n***Sterminatore di Colossi.*** La tenacia del ranger è in grado di logorare i nemici più potenti. Quando colpisce una creatura con un attacco con un'arma, la creatura subisce 1d8 danni extra se i suoi punti ferita sono inferiori al massimo. Il ranger può infliggere questi danni extra soltanto una volta per turno.\n\n***Uccisore di Giganti.*** Quando una creatura di taglia Grande o superiore entro 1,5 metri dal ranger lo colpisce o lo manca con un attacco, il ranger può usare la sua reazione per attaccare quella creatura subito dopo il suo attacco, a patto di essere in grado di vederla.\n\n***Devastatore dell'Orda.*** Una volta in ognuno dei suoi turni, quando effettua un attacco con un'arma, il ranger può effettuare un altro attacco con la stessa arma contro una creatura diversa che si trovi entro 1,5 metri dal bersaglio originale ed entro la gittata della sua arma." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/defensive-tactics"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/defensive-tactics", "en"), Language = LanguageCode.En, Name = "Defensive Tactics", Description = "At 7th level, you gain one of the following features of your choice.\n\n***Escape the Horde.*** Opportunity attacks against you are made with disadvantage.\n\n***Multiattack Defense.*** When a creature hits you with an attack, you gain a +4 bonus to AC against all subsequent attacks made by that creature for the rest of the turn.\n\n***Steel Will.*** You have advantage on saving throws against being frightened." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/defensive-tactics", "it"), Language = LanguageCode.It, Name = "Tattiche Difensive", Description = "Al 7° livello il ranger ottiene uno dei privilegi seguenti a sua scelta.\n\n***Sfuggire all'Orda.*** Gli attacchi di opportunità contro il ranger sono effettuati con svantaggio.\n\n***Difesa dal Multiattacco.*** Quando una creatura colpisce il ranger con un attacco, il ranger ottiene un bonus di +4 alla CA contro tutti gli attacchi successivi effettuati da quella creatura per il resto del turno.\n\n***Volontà d'Acciaio.*** Il ranger dispone di vantaggio ai tiri salvezza per non essere spaventato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/multiattack"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 11,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/multiattack", "en"), Language = LanguageCode.En, Name = "Multiattack", Description = "At 11th level, you gain one of the following features of your choice.\n\n***Volley.*** You can use your action to make a ranged attack against any number of creatures within 10 feet of a point you can see within your weapon's range. You must have ammunition for each target, as normal, and you make a separate attack roll for each target.\n\n***Whirlwind Attack.*** You can use your action to make a melee attack against any number of creatures within 5 feet of you, with a separate attack roll for each target." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/multiattack", "it"), Language = LanguageCode.It, Name = "Multiattacco", Description = "All'11° livello il ranger ottiene uno dei privilegi seguenti a sua scelta.\n\n***Raffica.*** Il ranger può usare la sua azione per effettuare un attacco a distanza contro un qualsiasi numero di creature entro 3 metri da un punto che è in grado di vedere entro la gittata della sua arma. Deve avere munizioni per ogni bersaglio, come di consueto, ed effettua un tiro per colpire separato per ogni bersaglio.\n\n***Attacco Turbinante.*** Il ranger può usare la sua azione per effettuare un attacco in mischia contro un qualsiasi numero di creature entro 1,5 metri da lui, con un tiro per colpire separato per ogni bersaglio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/superior-hunter-s-defense"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 15,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/superior-hunter-s-defense", "en"), Language = LanguageCode.En, Name = "Superior Hunter's Defense", Description = "At 15th level, you gain one of the following features of your choice.\n\n***Evasion.*** When you are subjected to an effect, such as a red dragon's fiery breath or a *lightning bolt* spell, that allows you to make a Dexterity saving throw to take only half damage, you instead take no damage if you succeed on the saving throw, and only half damage if you fail.\n\n***Stand Against the Tide.*** When a hostile creature misses you with a melee attack, you can use your reaction to force that creature to repeat the same attack against another creature (other than itself) of your choice.\n\n***Uncanny Dodge.*** When an attacker that you can see hits you with an attack, you can use your reaction to halve the attack's damage against you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "hunter/superior-hunter-s-defense", "it"), Language = LanguageCode.It, Name = "Difesa del Cacciatore Superiore", Description = "Al 15° livello il ranger ottiene uno dei privilegi seguenti a sua scelta.\n\n***Elusione.*** Quando è soggetto a un effetto che gli consente di effettuare un tiro salvezza su Destrezza per subire soltanto la metà dei danni, come il soffio infuocato di un drago rosso o un incantesimo *fulmine*, il ranger non subisce invece alcun danno se supera il tiro salvezza, e soltanto la metà dei danni se lo fallisce.\n\n***Opporsi alla Marea.*** Quando una creatura ostile manca il ranger con un attacco in mischia, il ranger può usare la sua reazione per costringere quella creatura a ripetere lo stesso attacco contro un'altra creatura (diversa da se stessa) a scelta del ranger.\n\n***Schivata Prodigiosa.*** Quando un attaccante che il ranger è in grado di vedere lo colpisce con un attacco, il ranger può usare la sua reazione per dimezzare i danni dell'attacco contro di lui." }
					}
				}
			}
		};
	}
}
