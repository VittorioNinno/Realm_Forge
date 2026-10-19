using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Arcane Trickster (rogue, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class ArcaneTrickster2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "arcane-trickster");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Rogue2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.Third,
			SpellcastingAbility = AbilityScore.Intelligence,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "arcane-trickster", "en"), Language = LanguageCode.En, Name = "Arcane Trickster", Description = "Some Rogues sharpen their stealth and agility with spells, learning magical tricks that help them in their trade. Certain Arcane Tricksters put their gifts to work as pickpockets and burglars, while others are simply incorrigible pranksters." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "arcane-trickster", "it"), Language = LanguageCode.It, Name = "Mistificatore Arcano", Description = "Alcuni ladri affinano la loro furtività e la loro agilità con gli incantesimi, imparando trucchi magici che li aiutano nel mestiere. Certi mistificatori arcani mettono il loro talento al servizio del borseggio e dello scasso, mentre altri sono semplicemente burloni incorreggibili." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/spellcasting"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/spellcasting", "en"), Language = LanguageCode.En, Name = "Spellcasting", Description = "You have learned to cast spells (the rules for spellcasting are in the spells chapter). Here is how you use them as an Arcane Trickster.\n\n**Cantrips.** You know three cantrips: *Mage Hand* and two more of your choice from the Wizard spell list; *Mind Sliver* and *Minor Illusion* are recommended. Each time you gain a Rogue level, you can swap one of your cantrips, other than *Mage Hand*, for another Wizard cantrip of your choice. At Rogue level 10 you learn one more Wizard cantrip of your choice.\n\n**Spell Slots.** The table below shows how many spell slots you have for your level 1+ spells. You regain every expended slot after a Long Rest.\n\n| Rogue Level | Prepared Spells | 1 | 2 | 3 | 4 |\n|---|---|---|---|---|---|\n| 3 | 3 | 2 | — | — | — |\n| 4 | 4 | 3 | — | — | — |\n| 5 | 4 | 3 | — | — | — |\n| 6 | 4 | 3 | — | — | — |\n| 7 | 5 | 4 | 2 | — | — |\n| 8 | 6 | 4 | 2 | — | — |\n| 9 | 6 | 4 | 2 | — | — |\n| 10 | 7 | 4 | 3 | — | — |\n| 11 | 8 | 4 | 3 | — | — |\n| 12 | 8 | 4 | 3 | — | — |\n| 13 | 9 | 4 | 3 | 2 | — |\n| 14 | 10 | 4 | 3 | 2 | — |\n| 15 | 10 | 4 | 3 | 2 | — |\n| 16 | 11 | 4 | 3 | 3 | — |\n| 17 | 11 | 4 | 3 | 3 | — |\n| 18 | 11 | 4 | 3 | 3 | — |\n| 19 | 12 | 4 | 3 | 3 | 1 |\n| 20 | 13 | 4 | 3 | 3 | 1 |\n\nThe 1–4 columns show the spell slots per spell level.\n\n**Prepared Spells of Level 1+.** You prepare the list of level 1+ spells you can cast with this feature. To begin, pick three level 1 Wizard spells; *Charm Person*, *Disguise Self*, and *Fog Cloud* are recommended. Your list grows as you gain Rogue levels, as the Prepared Spells column of the table shows: whenever the number goes up, add Wizard spells until your list matches it. Each chosen spell must be of a level for which you have spell slots; a level 7 Rogue, for instance, can prepare five Wizard spells of levels 1 and 2 in any mix.\n\n**Changing Your Prepared Spells.** Each time you gain a Rogue level, you can swap one spell on your list for another Wizard spell for which you have spell slots.\n\n**Spellcasting Ability.** Intelligence is your spellcasting ability for your Wizard spells.\n\n**Spellcasting Focus.** You can use an Arcane Focus as a Spellcasting Focus for your Wizard spells." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/spellcasting", "it"), Language = LanguageCode.It, Name = "Incantesimi", Description = "Il ladro ha imparato a lanciare incantesimi (le regole per lanciarli si trovano nel capitolo sugli incantesimi). Di seguito è spiegato come le applica in quanto mistificatore arcano.\n\n**Trucchetti.** Il ladro conosce tre trucchetti: *mano magica* e altri due trucchetti a sua scelta dalla lista degli incantesimi da mago; sono consigliati *illusione minore* e *scheggia della mente*. Ogni volta che sale di livello come ladro, può sostituire uno dei suoi trucchetti, tranne *mano magica*, con un altro trucchetto da mago a sua scelta. Al 10° livello da ladro impara un altro trucchetto da mago a sua scelta.\n\n**Slot incantesimo.** La tabella seguente indica quanti slot incantesimo possiede il ladro per lanciare i suoi incantesimi di 1° livello o superiore. Recupera tutti gli slot spesi quando completa un riposo lungo.\n\n| Livello da ladro | Incantesimi preparati | 1 | 2 | 3 | 4 |\n|---|---|---|---|---|---|\n| 3 | 3 | 2 | — | — | — |\n| 4 | 4 | 3 | — | — | — |\n| 5 | 4 | 3 | — | — | — |\n| 6 | 4 | 3 | — | — | — |\n| 7 | 5 | 4 | 2 | — | — |\n| 8 | 6 | 4 | 2 | — | — |\n| 9 | 6 | 4 | 2 | — | — |\n| 10 | 7 | 4 | 3 | — | — |\n| 11 | 8 | 4 | 3 | — | — |\n| 12 | 8 | 4 | 3 | — | — |\n| 13 | 9 | 4 | 3 | 2 | — |\n| 14 | 10 | 4 | 3 | 2 | — |\n| 15 | 10 | 4 | 3 | 2 | — |\n| 16 | 11 | 4 | 3 | 3 | — |\n| 17 | 11 | 4 | 3 | 3 | — |\n| 18 | 11 | 4 | 3 | 3 | — |\n| 19 | 12 | 4 | 3 | 3 | 1 |\n| 20 | 13 | 4 | 3 | 3 | 1 |\n\nLe colonne 1–4 indicano gli slot incantesimo per livello di incantesimo.\n\n**Incantesimi preparati di 1° livello o superiore.** Il ladro prepara l'elenco degli incantesimi di 1° livello o superiore che può lanciare con questo privilegio. Per cominciare, sceglie tre incantesimi da mago di 1° livello; sono consigliati *camuffare se stesso*, *charme su persone* e *nube di nebbia*. Il numero di incantesimi del suo elenco aumenta man mano che sale di livello come ladro, come indicato nella colonna Incantesimi preparati della tabella: quando aumenta, sceglie altri incantesimi da mago finché non raggiunge quel numero. Gli incantesimi scelti devono essere di un livello per cui possiede slot incantesimo; per esempio, un ladro di 7° livello può avere nel suo elenco cinque incantesimi da mago di 1° o 2° livello in qualsiasi combinazione.\n\n**Cambiare gli incantesimi preparati.** Ogni volta che sale di livello come ladro, può sostituire un incantesimo del suo elenco con un altro incantesimo da mago per cui possiede slot incantesimo.\n\n**Caratteristica da incantatore.** L'Intelligenza è la caratteristica da incantatore del ladro per i suoi incantesimi da mago.\n\n**Focus da incantatore.** Il ladro può usare un focus arcano come focus da incantatore per i suoi incantesimi da mago." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/mage-hand-legerdemain"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/mage-hand-legerdemain", "en"), Language = LanguageCode.En, Name = "Mage Hand Legerdemain", Description = "You can cast *Mage Hand* as a Bonus Action and make the spectral hand Invisible. You can steer the hand as a Bonus Action and use it to make Dexterity (Sleight of Hand) checks." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/mage-hand-legerdemain", "it"), Language = LanguageCode.It, Name = "Gioco di Prestigio della Mano Magica", Description = "Il ladro può lanciare *mano magica* come azione bonus e rendere invisibile la mano spettrale. Può controllare la mano come azione bonus e, attraverso di essa, effettuare prove di Destrezza (Rapidità di mano)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/magical-ambush"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 9,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/magical-ambush", "en"), Language = LanguageCode.En, Name = "Magical Ambush", Description = "If you are Invisible when you cast a spell on a creature, that creature rolls with Disadvantage on any save it makes against the spell during the same turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/magical-ambush", "it"), Language = LanguageCode.It, Name = "Imboscata Magica", Description = "Se è invisibile quando lancia un incantesimo su una creatura, quella creatura subisce svantaggio a ogni tiro salvezza che effettua contro l'incantesimo nello stesso turno." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/versatile-trickster"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 13,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/versatile-trickster", "en"), Language = LanguageCode.En, Name = "Versatile Trickster", Description = "You learn to use your *Mage Hand* as a distraction. When you use the Trip option of Cunning Strike on a creature, you can apply it to a second creature within 5 feet of the spectral hand as well." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/versatile-trickster", "it"), Language = LanguageCode.It, Name = "Ingannatore Versatile", Description = "Il ladro impara a distrarre i bersagli con la sua mano magica. Quando usa l'opzione Inciampo di Colpo astuto su una creatura, può applicarla anche a un'altra creatura entro 1,5 metri dalla mano spettrale." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/spell-thief"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/spell-thief", "en"), Language = LanguageCode.En, Name = "Spell Thief", Description = "You learn to magically steal another spellcaster's knowledge of a spell.\n\nRight after a creature casts a spell that targets you or includes you in its area, you can use your Reaction to force it to make an Intelligence saving throw against your spell save DC. On a failure, you cancel the spell's effect on you and, if the spell is level 1 or higher and of a level you can cast (it needn't be a Wizard spell), you take its knowledge: for the next 8 hours you have that spell prepared, and the creature can't cast it until those hours have passed.\n\nAfter stealing a spell this way, you need a Long Rest before you can do so again." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "arcane-trickster/spell-thief", "it"), Language = LanguageCode.It, Name = "Ladro di Incantesimi", Description = "Il ladro impara a rubare magicamente a un altro incantatore la conoscenza di un incantesimo.\n\nSubito dopo che una creatura ha lanciato un incantesimo che lo prende come bersaglio o lo include nella sua area d'effetto, il ladro può usare una reazione per costringere quella creatura a un tiro salvezza su Intelligenza contro la CD del tiro salvezza dei suoi incantesimi. Se lo fallisce, il ladro annulla gli effetti dell'incantesimo su di sé e, se l'incantesimo è almeno di 1° livello e di un livello che è in grado di lanciare (anche se non è un incantesimo da mago), ne ruba la conoscenza: per le 8 ore successive ha quell'incantesimo preparato, mentre la creatura non può lanciarlo finché non sono trascorse.\n\nDopo aver rubato un incantesimo con questo privilegio, il ladro non può farlo di nuovo finché non completa un riposo lungo." }
					}
				}
			}
		};
	}
}
