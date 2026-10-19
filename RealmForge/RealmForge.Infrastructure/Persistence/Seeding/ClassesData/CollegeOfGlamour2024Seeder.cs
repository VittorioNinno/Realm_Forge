using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	College of Glamour (bard, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class CollegeOfGlamour2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-glamour");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Bard2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-glamour", "en"), Language = LanguageCode.En, Name = "College of Glamour", Description = "The College of Glamour learned its art from the bewitching magic of the Feywild. Its Bards spin beauty and dread into their songs and tales, and the greatest of them can wrap themselves in an otherworldly majesty. Their performances awaken longing for a lost innocence and buried fears alike, moving even the hardest hearts." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-glamour", "it"), Language = LanguageCode.It, Name = "Collegio del Fascino", Description = "Il Collegio del Fascino ha appreso la sua arte dalla magia seducente della Selva Fatata. I suoi bardi intrecciano bellezza e timore nelle loro canzoni e nei loro racconti, e i più grandi tra loro sanno avvolgersi in una maestosità ultraterrena. Le loro esibizioni risvegliano la nostalgia di un'innocenza perduta e le paure più sepolte, commuovendo anche i cuori più duri." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/beguiling-magic"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/beguiling-magic", "en"), Language = LanguageCode.En, Name = "Beguiling Magic", Description = "*Charm Person* and *Mirror Image* are always prepared for you.\n\nAlso, right after you cast an Enchantment or Illusion spell with a spell slot, you can pick a creature you can see within 60 feet; it must make a Wisdom saving throw against your spell save DC or be Charmed or Frightened (your pick) for 1 minute, repeating the save at the end of each of its turns and ending the effect on a success. You can use this benefit once per Long Rest, and you can spend a use of Bardic Inspiration (no action required) to use it again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/beguiling-magic", "it"), Language = LanguageCode.It, Name = "Magia Ammaliante", Description = "Il bardo ha sempre preparati gli incantesimi *charme su persone* e *immagine speculare*.\n\nInoltre, subito dopo aver lanciato un incantesimo di ammaliamento o di illusione usando uno slot incantesimo, il bardo può costringere una creatura entro 18 metri da lui che è in grado di vedere a effettuare un tiro salvezza su Saggezza contro la CD del tiro salvezza dei suoi incantesimi. Se lo fallisce, il bersaglio subisce la condizione di affascinato o di spaventato (a scelta del bardo) per 1 minuto; ripete il tiro salvezza alla fine di ogni suo turno e, se lo supera, l'effetto su di lui termina. Dopo aver usato questo beneficio, il bardo non può usarlo di nuovo finché non completa un riposo lungo, ma può ripristinarlo spendendo un utilizzo di Ispirazione bardica (nessuna azione richiesta)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/mantle-of-inspiration"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/mantle-of-inspiration", "en"), Language = LanguageCode.En, Name = "Mantle of Inspiration", Description = "Weaving fey magic into song or dance, you can lift others' spirits. As a Bonus Action, spend a use of Bardic Inspiration and roll the die. Then pick other creatures within 60 feet, up to your Charisma modifier (at least one): each gains Temporary Hit Points equal to twice the result, and each can use its Reaction to move up to its Speed without provoking Opportunity Attacks." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/mantle-of-inspiration", "it"), Language = LanguageCode.It, Name = "Manto di Ispirazione", Description = "Il bardo può intrecciare la magia fatata in una canzone o in una danza per infondere vigore negli altri. Come azione bonus, spende un utilizzo di Ispirazione bardica e tira il dado. Sceglie poi un numero di altre creature entro 18 metri da lui fino al suo modificatore di Carisma (minimo una creatura): ognuna ottiene un numero di punti ferita temporanei pari al doppio del risultato e può subito usare la propria reazione per muoversi fino alla propria velocità senza provocare attacchi di opportunità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/mantle-of-majesty"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/mantle-of-majesty", "en"), Language = LanguageCode.En, Name = "Mantle of Majesty", Description = "*Command* is always prepared for you.\n\nWith a Bonus Action, you cast *Command* without spending a spell slot and take on an unearthly appearance for 1 minute or until your Concentration ends. For that time you can cast *Command* as a Bonus Action without a spell slot, and any creature Charmed by you automatically fails its save against a *Command* cast this way.\n\nYou can use this feature once per Long Rest; spending a level 3+ spell slot (no action required) lets you use it again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/mantle-of-majesty", "it"), Language = LanguageCode.It, Name = "Manto di Maestosità", Description = "Il bardo ha sempre preparato l'incantesimo *comando*.\n\nCome azione bonus, il bardo lancia *comando* senza spendere uno slot incantesimo e assume un aspetto ultraterreno per 1 minuto o finché la sua concentrazione non termina. Durante questo periodo può lanciare *comando* come azione bonus senza spendere uno slot incantesimo. Le creature affascinate dal bardo falliscono automaticamente il tiro salvezza contro il *comando* lanciato con questo privilegio.\n\nDopo aver usato questo privilegio, il bardo non può usarlo di nuovo finché non completa un riposo lungo, ma può ripristinarlo spendendo uno slot incantesimo di 3° livello o superiore (nessuna azione richiesta)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/unbreakable-majesty"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/unbreakable-majesty", "en"), Language = LanguageCode.En, Name = "Unbreakable Majesty", Description = "As a Bonus Action, you can take on a magical, majestic bearing for 1 minute or until you become Incapacitated. During that time, the first time each turn that a creature hits you with an attack roll, it must succeed on a Charisma saving throw against your spell save DC or miss instead, shrinking back from your splendor.\n\nAfter using this feature, you must finish a Short or Long Rest before using it again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-glamour/unbreakable-majesty", "it"), Language = LanguageCode.It, Name = "Maestosità Invitta", Description = "Come azione bonus, il bardo può assumere un portamento magicamente maestoso per 1 minuto o finché non subisce la condizione di incapacitato. Per la durata, la prima volta in ogni turno in cui una creatura lo colpisce con un tiro per colpire, l'attaccante deve superare un tiro salvezza su Carisma contro la CD del tiro salvezza degli incantesimi del bardo, altrimenti, intimorito dalla sua maestà, manca il colpo.\n\nDopo aver assunto questo portamento, il bardo non può farlo di nuovo finché non completa un riposo breve o lungo." }
					}
				}
			}
		};
	}
}
