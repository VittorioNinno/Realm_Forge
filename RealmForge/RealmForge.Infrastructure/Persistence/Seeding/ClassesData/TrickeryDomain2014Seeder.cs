using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Trickery Domain (cleric, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class TrickeryDomain2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "trickery-domain");

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
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "trickery-domain", "en"), Language = LanguageCode.En, Name = "Trickery Domain", Description = "Gods of trickery are mischief-makers and troublemakers who challenge the established order among gods and mortals alike. They watch over thieves, rogues, gamblers, rebels and liberators. Their clerics shake things up: they deflate pride, mock tyrants, rob the rich, free captives and ignore empty traditions, preferring tricks, pranks, deceit and theft to open confrontation." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "trickery-domain", "it"), Language = LanguageCode.It, Name = "Dominio dell'Inganno", Description = "Gli dèi dell'inganno sono burloni e sobillatori che sfidano l'ordine costituito tra gli dèi come tra i mortali. Proteggono ladri, furfanti, giocatori d'azzardo, ribelli e liberatori. I loro chierici scuotono lo status quo: sgonfiano l'orgoglio, deridono i tiranni, derubano i ricchi, liberano i prigionieri e ignorano le tradizioni vuote, preferendo trucchi, scherzi, inganni e furti allo scontro aperto." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/trickery-domain-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/trickery-domain-spells", "en"), Language = LanguageCode.En, Name = "Trickery Domain Spells", Description = "You gain these domain spells at the cleric levels shown. See the Divine Domain class feature for how domain spells work.\n\n| Cleric Level | Spells |\n|---|---|\n| 1st | charm person, disguise self |\n| 3rd | mirror image, pass without trace |\n| 5th | blink, dispel magic |\n| 7th | dimension door, polymorph |\n| 9th | dominate person, modify memory |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/trickery-domain-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Dominio dell'Inganno", Description = "Il chierico ottiene questi incantesimi di dominio ai livelli da chierico indicati. Il funzionamento degli incantesimi di dominio è descritto nel privilegio di classe Dominio Divino.\n\n| Livello da chierico | Incantesimi |\n|---|---|\n| 1° | camuffare se stesso, charme su persone |\n| 3° | immagine speculare, passare senza tracce |\n| 5° | dissolvi magie, intermittenza |\n| 7° | metamorfosi, porta dimensionale |\n| 9° | dominare persone, modificare memoria |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/blessing-of-the-trickster"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/blessing-of-the-trickster", "en"), Language = LanguageCode.En, Name = "Blessing of the Trickster", Description = "From 1st level, you can use your action to touch a willing creature other than yourself, giving it advantage on Dexterity (Stealth) checks. The blessing lasts for 1 hour, or until you use this feature again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/blessing-of-the-trickster", "it"), Language = LanguageCode.It, Name = "Benedizione dell'Ingannatore", Description = "Dal 1° livello il chierico può usare la sua azione per toccare una creatura consenziente diversa da sé, conferendole vantaggio alle prove di Destrezza (Furtività). La benedizione dura 1 ora, o finché il chierico non usa di nuovo questo privilegio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/channel-divinity-invoke-duplicity"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 2,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/channel-divinity-invoke-duplicity", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Invoke Duplicity", Description = "From 2nd level, you can use your Channel Divinity, as an action, to conjure a perfect illusory double of yourself in an unoccupied space you can see within 30 feet of you. It lasts for 1 minute, or until your concentration breaks (as if you were concentrating on a spell). As a bonus action on your turn, you can move the double up to 30 feet to a space you can see, as long as it stays within 120 feet of you.\n\nWhile the double exists:\n- you can cast spells as though you were in its space, but you still use your own senses;\n- when both you and the double are within 5 feet of a creature that can see the double, you have advantage on attack rolls against that creature, which is distracted by the illusion." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/channel-divinity-invoke-duplicity", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Invocare Duplicato", Description = "Dal 2° livello il chierico può usare Incanalare Divinità, come azione, per creare un perfetto doppio illusorio di sé in uno spazio libero entro 9 metri che è in grado di vedere. Il doppio dura 1 minuto, o finché la concentrazione del chierico non si interrompe (come se si stesse concentrando su un incantesimo). Come azione bonus nel suo turno, il chierico può spostare il doppio fino a 9 metri in uno spazio che è in grado di vedere, purché resti entro 36 metri da lui.\n\nFinché il doppio esiste:\n- il chierico può lanciare incantesimi come se si trovasse nel suo spazio, ma usa comunque i propri sensi;\n- quando sia il chierico sia il doppio si trovano entro 1,5 metri da una creatura che è in grado di vedere il doppio, il chierico dispone di vantaggio ai tiri per colpire contro quella creatura, distratta dall'illusione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/channel-divinity-cloak-of-shadows"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/channel-divinity-cloak-of-shadows", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Cloak of Shadows", Description = "From 6th level, you can use your Channel Divinity, as an action, to become invisible until the end of your next turn. The invisibility ends early if you attack or cast a spell." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/channel-divinity-cloak-of-shadows", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Manto di Ombre", Description = "Dal 6° livello il chierico può usare Incanalare Divinità, come azione, per diventare invisibile fino alla fine del suo turno successivo. L'invisibilità termina prima se attacca o lancia un incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/divine-strike"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 8,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/divine-strike", "en"), Language = LanguageCode.En, Name = "Divine Strike", Description = "At 8th level, your god coats your weapon with venom. Once on each of your turns when you hit a creature with a weapon attack, you can deal an extra 1d8 poison damage to it. The extra damage becomes 2d8 at 14th level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/divine-strike", "it"), Language = LanguageCode.It, Name = "Colpo Divino", Description = "All'8° livello la divinità del chierico intride la sua arma di veleno. Una volta in ognuno dei suoi turni, quando colpisce una creatura con un attacco con un'arma, può infliggerle 1d8 danni da veleno extra. I danni extra diventano 2d8 al 14° livello." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/improved-duplicity"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/improved-duplicity", "en"), Language = LanguageCode.En, Name = "Improved Duplicity", Description = "At 17th level, Invoke Duplicity creates up to four doubles instead of one. As a bonus action on your turn, you can move any number of them up to 30 feet each, to a maximum distance of 120 feet from you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "trickery-domain/improved-duplicity", "it"), Language = LanguageCode.It, Name = "Duplicato Migliorato", Description = "Al 17° livello Invocare Duplicato crea fino a quattro doppi invece di uno. Come azione bonus nel suo turno, il chierico può spostarne un qualsiasi numero fino a 9 metri ciascuno, fino a una distanza massima di 36 metri da lui." }
					}
				}
			}
		};
	}
}
