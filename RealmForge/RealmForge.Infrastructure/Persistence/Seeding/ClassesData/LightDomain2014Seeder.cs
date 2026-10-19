using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Light Domain (cleric, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class LightDomain2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "light-domain");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Cleric2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "light-domain", "en"), Language = LanguageCode.En, Name = "Light Domain", Description = "Gods of light stand for rebirth, renewal, truth, vigilance and beauty, and many of them take the sun as their symbol, either as the sun itself or as the one who guides it across the sky. Others are watchers whose gaze pierces every shadow and lie, or patrons of art who teach that beauty lifts the soul. Their clerics carry that radiance with them, driving away falsehood and burning away the dark." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "light-domain", "it"), Language = LanguageCode.It, Name = "Dominio della Luce", Description = "Gli dèi della luce rappresentano la rinascita, il rinnovamento, la verità, la vigilanza e la bellezza, e molti di loro hanno il sole come simbolo, che siano il sole stesso o colui che lo guida attraverso il cielo. Altri sono guardiani il cui sguardo penetra ogni ombra e ogni menzogna, oppure protettori dell'arte che insegnano come la bellezza elevi l'anima. I loro chierici portano con sé quello splendore, scacciando la falsità e bruciando l'oscurità." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/light-domain-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/light-domain-spells", "en"), Language = LanguageCode.En, Name = "Light Domain Spells", Description = "You gain these domain spells at the cleric levels shown. See the Divine Domain class feature for how domain spells work.\n\n| Cleric Level | Spells |\n|---|---|\n| 1st | burning hands, faerie fire |\n| 3rd | flaming sphere, scorching ray |\n| 5th | daylight, fireball |\n| 7th | guardian of faith, wall of fire |\n| 9th | flame strike, scrying |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/light-domain-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Dominio della Luce", Description = "Il chierico ottiene questi incantesimi di dominio ai livelli da chierico indicati. Il funzionamento degli incantesimi di dominio è descritto nel privilegio di classe Dominio Divino.\n\n| Livello da chierico | Incantesimi |\n|---|---|\n| 1° | luminescenza, mani brucianti |\n| 3° | raggio rovente, sfera infuocata |\n| 5° | luce diurna, palla di fuoco |\n| 7° | guardiano della fede, muro di fuoco |\n| 9° | colpo infuocato, scrutare |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/bonus-cantrip"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/bonus-cantrip", "en"), Language = LanguageCode.En, Name = "Bonus Cantrip", Description = "When you take this domain at 1st level, you learn the *light* cantrip if you don't already know it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/bonus-cantrip", "it"), Language = LanguageCode.It, Name = "Trucchetto Bonus", Description = "Quando sceglie questo dominio al 1° livello, il chierico apprende il trucchetto *luce*, se non lo conosce già." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/warding-flare"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/warding-flare", "en"), Language = LanguageCode.En, Name = "Warding Flare", Description = "Also at 1st level, you can throw a flash of holy light between yourself and an attacker. When a creature you can see within 30 feet of you attacks you, you can use your reaction to give that attack roll disadvantage, before you know whether it hits or misses. Creatures that can't be blinded aren't affected.\n\nYou can use this feature a number of times equal to your Wisdom modifier (at least once), and you regain all uses when you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/warding-flare", "it"), Language = LanguageCode.It, Name = "Lampo di Interdizione", Description = "Sempre al 1° livello, il chierico può far brillare un lampo di luce sacra tra sé e un attaccante. Quando una creatura entro 9 metri che il chierico è in grado di vedere lo attacca, il chierico può usare la sua reazione per imporre svantaggio a quel tiro per colpire, prima di sapere se va a segno o manca. Le creature che non possono essere accecate non sono influenzate.\n\nIl chierico può usare questo privilegio un numero di volte pari al suo modificatore di Saggezza (almeno una volta) e recupera tutti gli utilizzi quando completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/channel-divinity-radiance-of-the-dawn"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/channel-divinity-radiance-of-the-dawn", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Radiance of the Dawn", Description = "From 2nd level, you can call down the light of sunrise. As an action, you present your holy symbol and use your Channel Divinity: any magical darkness within 30 feet of you is dispelled, and every hostile creature within 30 feet of you makes a Constitution saving throw, taking radiant damage equal to 2d10 + your cleric level on a failure, or half as much on a success. A creature with total cover from you isn't affected." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/channel-divinity-radiance-of-the-dawn", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Fulgore dell'Alba", Description = "Dal 2° livello il chierico può invocare la luce dell'aurora. Come azione, presenta il suo simbolo sacro e usa Incanalare Divinità: qualsiasi oscurità magica entro 9 metri da lui viene dissolta, e ogni creatura ostile entro 9 metri da lui effettua un tiro salvezza su Costituzione, subendo danni radiosi pari a 2d10 + il livello da chierico se lo fallisce, o la metà se lo supera. Una creatura che ha copertura totale rispetto al chierico non è influenzata." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/improved-flare"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/improved-flare", "en"), Language = LanguageCode.En, Name = "Improved Flare", Description = "From 6th level, you can also use Warding Flare when a creature you can see within 30 feet of you attacks someone other than you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/improved-flare", "it"), Language = LanguageCode.It, Name = "Lampo Migliorato", Description = "Dal 6° livello il chierico può usare Lampo di Interdizione anche quando una creatura entro 9 metri che è in grado di vedere attacca qualcuno diverso da lui." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/potent-spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 8,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/potent-spellcasting", "en"), Language = LanguageCode.En, Name = "Potent Spellcasting", Description = "From 8th level, the damage you deal with any cleric cantrip increases by your Wisdom modifier." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/potent-spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi Potenti", Description = "Dall'8° livello, i danni che il chierico infligge con qualsiasi trucchetto da chierico aumentano di un ammontare pari al suo modificatore di Saggezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/corona-of-light"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 6,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/corona-of-light", "en"), Language = LanguageCode.En, Name = "Corona of Light", Description = "At 17th level, you can use your action to surround yourself with an aura of sunlight for 1 minute (you can end it early with another action). You shed bright light in a 60-foot radius and dim light for a further 30 feet, and enemies standing in the bright light have disadvantage on saving throws against spells that deal fire or radiant damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "light-domain/corona-of-light", "it"), Language = LanguageCode.It, Name = "Corona di Luce", Description = "Al 17° livello il chierico può usare la sua azione per avvolgersi in un'aura di luce solare per 1 minuto (può porvi fine prima con un'altra azione). Emana luce intensa in un raggio di 18 metri e luce fioca per altri 9 metri, e i nemici che si trovano nella luce intensa subiscono svantaggio ai tiri salvezza contro gli incantesimi che infliggono danni da fuoco o radiosi." }
					}
				}
			}
		};
	}
}
