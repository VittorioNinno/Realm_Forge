using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Circle of the Stars (druid, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class CircleOfTheStars2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-stars");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Druid2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-stars", "en"), Language = LanguageCode.En, Name = "Circle of the Stars", Description = "Since time out of mind the Circle of the Stars has charted the patterns of the heavens and uncovered the secrets woven among the constellations. By learning to read those secrets, its Druids aim to draw on the power of the cosmos itself." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-stars", "it"), Language = LanguageCode.It, Name = "Circolo delle Stelle", Description = "Da tempo immemorabile il Circolo delle Stelle traccia gli schemi del cielo e svela i segreti intessuti tra le costellazioni. Imparando a leggere quei segreti, i suoi druidi cercano di attingere al potere del cosmo stesso." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/star-map"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/star-map", "en"), Language = LanguageCode.En, Name = "Star Map", Description = "Your study of the sky has produced a star chart. It is a Tiny object you can use as a Spellcasting Focus for your Druid spells; roll on the table below to set its appearance, or pick one.\n\nWhile you hold the chart, *Guidance* and *Guiding Bolt* are prepared for you, and you can cast *Guiding Bolt* without spending a spell slot. You can do so a number of times equal to your Wisdom modifier (at least once), regaining every use after a Long Rest.\n\nIf the chart is lost, a 1-hour ceremony, which you can perform during a Short or Long Rest, magically makes a new one and destroys the old.\n\n| 1d6 | Chart Appearance |\n|---|---|\n| 1 | A scroll painted with the constellations |\n| 2 | A stone tablet pierced by tiny holes |\n| 3 | An owlbear hide tooled with star signs |\n| 4 | A bundle of maps bound in ebony covers |\n| 5 | A crystal carved with starry patterns |\n| 6 | A glass disk etched with constellations |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/star-map", "it"), Language = LanguageCode.It, Name = "Carta Celeste", Description = "Durante i suoi studi del cielo, il druido ha realizzato una carta stellare. È un oggetto Minuscolo che può usare come focus da incantatore per i suoi incantesimi da druido; ne stabilisce l'aspetto tirando sulla tabella seguente o scegliendone uno.\n\nFinché tiene in mano la carta, il druido ha preparati gli incantesimi *dardo tracciante* e *guida* e può lanciare *dardo tracciante* senza spendere uno slot incantesimo. Può farlo un numero di volte pari al suo modificatore di Saggezza (almeno una) e recupera tutti gli utilizzi dopo un riposo lungo.\n\nSe perde la carta, il druido può celebrare una cerimonia di 1 ora per crearne magicamente una nuova. La cerimonia può svolgersi durante un riposo breve o lungo e distrugge la carta precedente.\n\n| 1d6 | Aspetto della carta |\n|---|---|\n| 1 | Una pergamena che raffigura le costellazioni |\n| 2 | Una tavoletta di pietra attraversata da piccoli fori |\n| 3 | Una pelle di gufo civetta incisa con simboli stellari |\n| 4 | Una raccolta di mappe rilegate in una copertina d'ebano |\n| 5 | Un cristallo inciso con motivi stellati |\n| 6 | Un disco di vetro su cui sono tracciate le costellazioni |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/starry-form"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/starry-form", "en"), Language = LanguageCode.En, Name = "Starry Form", Description = "As a Bonus Action, you can spend a use of Wild Shape to take on a starry form instead of becoming a Beast. In this form you keep your game statistics, but your body turns luminous, your joints shine like stars, and lines of light link them as on a star chart. The form sheds Bright Light in a 10-foot radius and Dim Light for another 10 feet, and it lasts 10 minutes, ending sooner if you dismiss it (no action required), become Incapacitated, or use this feature again.\n\nEach time you take the starry form, choose which of these constellations shines on your body; your choice grants you benefits while the form lasts.\n\n**Archer.** An archer's constellation appears on you. When the form begins, and as a Bonus Action on your later turns while it lasts, you can make a ranged spell attack, loosing a shining arrow at one creature within 60 feet of you. On a hit, it deals Radiant damage equal to 1d8 plus your Wisdom modifier.\n\n**Chalice.** The constellation of a life-giving cup appears on you. Each time you cast a spell with a spell slot that restores Hit Points to a creature, you or another creature within 30 feet of you can regain Hit Points equal to 1d8 plus your Wisdom modifier.\n\n**Dragon.** The constellation of a wise dragon appears on you. When you make an Intelligence or Wisdom check, or a Constitution saving throw to keep Concentration, any roll of 9 or lower on the d20 counts as a 10." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/starry-form", "it"), Language = LanguageCode.It, Name = "Forma Siderale", Description = "Come azione bonus, il druido può spendere un utilizzo di Forma Selvatica per assumere una forma siderale anziché trasformarsi in una bestia. In questa forma conserva le sue statistiche di gioco, ma il suo corpo diventa luminoso, le articolazioni brillano come stelle e linee di luce le uniscono come su una carta celeste. La forma emana luce intensa in un raggio di 3 metri e luce fioca per altri 3 metri, e dura 10 minuti; termina prima se il druido la congeda (nessuna azione richiesta), se subisce la condizione di incapacitato o se usa di nuovo questo privilegio.\n\nOgni volta che assume la forma siderale, il druido sceglie quale delle costellazioni seguenti risplende sul suo corpo; la scelta gli conferisce determinati benefici finché resta in quella forma.\n\n**Arciere.** Sul druido compare la costellazione di un arciere. Quando attiva la forma e, come azione bonus, nei turni successivi finché dura, può effettuare un attacco con incantesimo a distanza scagliando una freccia luminosa contro una creatura entro 18 metri da lui. Se colpisce, l'attacco infligge danni radiosi pari a 1d8 + il suo modificatore di Saggezza.\n\n**Calice.** Sul druido compare la costellazione di una coppa che dona la vita. Ogni volta che lancia con uno slot incantesimo un incantesimo che fa recuperare punti ferita a una creatura, lui o un'altra creatura entro 9 metri da lui può recuperare punti ferita pari a 1d8 + il suo modificatore di Saggezza.\n\n**Drago.** Sul druido compare la costellazione di un drago saggio. Quando effettua una prova di Intelligenza o di Saggezza, oppure un tiro salvezza su Costituzione per mantenere la concentrazione, può considerare come un 10 qualsiasi risultato di 9 o meno sul d20." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/cosmic-omen"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/cosmic-omen", "en"), Language = LanguageCode.En, Name = "Cosmic Omen", Description = "After each Long Rest, you can read your star chart for signs and roll a die. Until your next Long Rest, you gain a special Reaction that depends on whether the result was even or odd.\n\n**Weal (Even).** When a creature you can see within 30 feet of you is about to make a D20 Test, you can use your Reaction to roll 1d6 and add it to the total.\n\n**Woe (Odd).** When a creature you can see within 30 feet of you is about to make a D20 Test, you can use your Reaction to roll 1d6 and subtract it from the total.\n\nYou can use this Reaction a number of times equal to your Wisdom modifier (at least once), regaining every use after a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/cosmic-omen", "it"), Language = LanguageCode.It, Name = "Profezia Cosmica", Description = "Ogni volta che completa un riposo lungo, il druido può interrogare la sua carta celeste in cerca di presagi e tirare un dado. Fino al termine del riposo lungo successivo ottiene una reazione speciale che dipende dal risultato, pari o dispari.\n\n**Ventura (pari).** Quando una creatura che il druido è in grado di vedere entro 9 metri da lui sta per effettuare una prova del d20, il druido può usare la reazione per tirare 1d6 e sommare il risultato al totale.\n\n**Sventura (dispari).** Quando una creatura che il druido è in grado di vedere entro 9 metri da lui sta per effettuare una prova del d20, il druido può usare la reazione per tirare 1d6 e sottrarre il risultato dal totale.\n\nIl druido può usare questa reazione un numero di volte pari al suo modificatore di Saggezza (almeno una) e recupera tutti gli utilizzi dopo un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/twinkling-constellations"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/twinkling-constellations", "en"), Language = LanguageCode.En, Name = "Twinkling Constellations", Description = "Your Starry Form's constellations grow brighter. The Archer's and the Chalice's 1d8 becomes 2d8, and while the Dragon is active you have a Fly Speed of 20 feet and can hover.\n\nAlso, at the start of each of your turns in Starry Form, you can switch the constellation shining on your body." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/twinkling-constellations", "it"), Language = LanguageCode.It, Name = "Costellazioni Scintillanti", Description = "Le costellazioni della Forma siderale si rafforzano. L'1d8 dell'Arciere e del Calice diventa 2d8 e, finché è attivo il Drago, il druido ha una velocità di volare di 6 metri e può fluttuare.\n\nInoltre, all'inizio di ognuno dei suoi turni in Forma siderale, il druido può cambiare la costellazione che risplende sul suo corpo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/full-of-stars"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/full-of-stars", "en"), Language = LanguageCode.En, Name = "Full of Stars", Description = "In Starry Form you become partly incorporeal, which gives you Resistance to Bludgeoning, Piercing, and Slashing damage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-stars/full-of-stars", "it"), Language = LanguageCode.It, Name = "Manto di Stelle", Description = "In Forma siderale il druido diventa in parte incorporeo e ottiene resistenza ai danni contundenti, perforanti e taglienti." }
					}
				}
			}
		};
	}
}
