using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Oath of the Ancients (paladin, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class OathOfTheAncients2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "oath-of-the-ancients");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Paladin2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "oath-of-the-ancients", "en"), Language = LanguageCode.En, Name = "Oath of the Ancients", Description = "This oath is as old as the elves and the rites of the druids. Its paladins, sometimes called fey knights, green knights or horned knights, side with the light against the darkness because they love every beautiful, living thing in the world, more than out of devotion to abstract ideals of honor or justice. Leaves, antlers and flowers decorate their armor and clothing as a sign of their promise to protect life and light.\n\n**Tenets of the Ancients**\n\nPreserved for countless centuries, this oath puts goodness above any question of law or chaos. Its four tenets are simple:\n\n**Kindle the Light.** Bring hope into the world through mercy, kindness and forgiveness, and push back despair.\n\n**Shelter the Light.** Wherever goodness, beauty, love and laughter exist, defend them from the wickedness that would devour them; wherever life thrives, oppose whatever would make it barren.\n\n**Preserve Your Own Light.** Take joy in song, laughter, beauty and art: a light that dies in your own heart can't be kept alive in the world.\n\n**Be the Light.** Shine like a beacon for everyone lost in despair, letting your joy and courage show in everything you do." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "oath-of-the-ancients", "it"), Language = LanguageCode.It, Name = "Giuramento degli Antichi", Description = "Questo giuramento è antico quanto gli elfi e i riti dei druidi. I suoi paladini, chiamati a volte cavalieri fatati, cavalieri verdi o cavalieri cornuti, si schierano con la luce contro l'oscurità perché amano ogni cosa bella e viva del mondo, più che per devozione a ideali astratti di onore o giustizia. Foglie, palchi di corna e fiori decorano le loro armature e i loro abiti, come segno della loro promessa di proteggere la vita e la luce.\n\n**Dettami degli Antichi**\n\nTramandato per innumerevoli secoli, questo giuramento pone il bene al di sopra di qualsiasi questione di legge o di caos. I suoi quattro dettami sono semplici:\n\n**Alimenta la Luce.** Porta speranza nel mondo con la pietà, la gentilezza e il perdono, e respingi la disperazione.\n\n**Proteggi la Luce.** Ovunque esistano bontà, bellezza, amore e risate, difendili dalla malvagità che vorrebbe divorarli; ovunque la vita prosperi, opponiti a ciò che vorrebbe renderla sterile.\n\n**Preserva la Tua Luce.** Trai gioia dal canto, dalle risate, dalla bellezza e dall'arte: una luce che muore nel tuo cuore non può essere tenuta viva nel mondo.\n\n**Sii la Luce.** Splendi come un faro per chiunque sia perso nella disperazione, lasciando che gioia e coraggio traspaiano da ogni tua azione." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/oath-of-the-ancients-spells"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/oath-of-the-ancients-spells", "en"), Language = LanguageCode.En, Name = "Oath of the Ancients Spells", Description = "You gain these oath spells at the paladin levels shown. See the Sacred Oath class feature for how oath spells work.\n\n| Paladin Level | Spells |\n|---|---|\n| 3rd | ensnaring strike, speak with animals |\n| 5th | misty step, moonbeam |\n| 9th | plant growth, protection from energy |\n| 13th | ice storm, stoneskin |\n| 17th | commune with nature, tree stride |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/oath-of-the-ancients-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Giuramento degli Antichi", Description = "Il paladino ottiene questi incantesimi di giuramento ai livelli da paladino indicati. Il funzionamento degli incantesimi di giuramento è descritto nel privilegio di classe Giuramento Sacro.\n\n| Livello da paladino | Incantesimi |\n|---|---|\n| 3° | colpo intrappolante, parlare con gli animali |\n| 5° | bagliore lunare, passo velato |\n| 9° | crescita vegetale, protezione dall'energia |\n| 13° | pelle di pietra, tempesta di ghiaccio |\n| 17° | comunione con la natura, traslazione arborea |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/channel-divinity-nature-s-wrath"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/channel-divinity-nature-s-wrath", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Nature's Wrath", Description = "When you take this oath at 3rd level, you can use your Channel Divinity, as an action, to make ghostly vines lunge at a creature you can see within 10 feet of you. The creature must succeed on a Strength or Dexterity saving throw (its choice) or be restrained. A restrained creature repeats the save at the end of each of its turns; on a success, it breaks free and the vines disappear." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/channel-divinity-nature-s-wrath", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Collera della Natura", Description = "Quando presta questo giuramento al 3° livello, il paladino può usare Incanalare Divinità, come azione, per far scattare dei rampicanti spettrali contro una creatura entro 3 metri che è in grado di vedere. La creatura deve superare un tiro salvezza su Forza o su Destrezza (a sua scelta), altrimenti è trattenuta. Una creatura trattenuta ripete il tiro salvezza alla fine di ognuno dei suoi turni; se lo supera, si libera e i rampicanti scompaiono." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/channel-divinity-turn-the-faithless"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/channel-divinity-turn-the-faithless", "en"), Language = LanguageCode.En, Name = "Channel Divinity: Turn the Faithless", Description = "Also at 3rd level, you can use your Channel Divinity, as an action, to present your holy symbol and speak ancient words that fey and fiends find painful to hear. Each fey or fiend within 30 feet of you that can hear you makes a Wisdom saving throw; on a failure, it is turned for 1 minute or until it takes damage.\n\nA turned creature must spend its turns moving as far away from you as it can, can't willingly move to a space within 30 feet of you, and can't take reactions. As its action, it can only Dash or try to escape an effect that keeps it from moving; if it has nowhere to go, it can take the Dodge action. If its true form is hidden by an illusion, shapechanging or a similar effect, that form is revealed while it is turned." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/channel-divinity-turn-the-faithless", "it"), Language = LanguageCode.It, Name = "Incanalare Divinità: Scacciare gli Infedeli", Description = "Sempre al 3° livello, il paladino può usare Incanalare Divinità, come azione, per presentare il suo simbolo sacro e pronunciare antiche parole che folletti e immondi trovano dolorose da udire. Ogni folletto o immondo entro 9 metri da lui che è in grado di sentirlo effettua un tiro salvezza su Saggezza; se lo fallisce, è scacciato per 1 minuto o finché non subisce danni.\n\nUna creatura scacciata deve passare i suoi turni allontanandosi il più possibile dal paladino, non può spostarsi volontariamente in uno spazio entro 9 metri da lui e non può effettuare reazioni. Come azione può soltanto effettuare lo Scatto o cercare di liberarsi da un effetto che le impedisce di muoversi; se non ha alcun posto in cui andare, può effettuare l'azione di Schivata. Se la sua vera forma è celata da un'illusione, da un cambio di forma o da un effetto simile, quella forma viene rivelata finché è scacciata." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/aura-of-warding"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 7,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/aura-of-warding", "en"), Language = LanguageCode.En, Name = "Aura of Warding", Description = "From 7th level, ancient magic surrounds you like a shield. You and friendly creatures within 10 feet of you have resistance to damage from spells. At 18th level, the aura's range becomes 30 feet." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/aura-of-warding", "it"), Language = LanguageCode.It, Name = "Aura di Interdizione", Description = "Dal 7° livello un'antica magia circonda il paladino come uno scudo. Il paladino e le creature amiche entro 3 metri da lui hanno resistenza ai danni inflitti dagli incantesimi. Al 18° livello il raggio dell'aura diventa di 9 metri." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/undying-sentinel"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 15,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/undying-sentinel", "en"), Language = LanguageCode.En, Name = "Undying Sentinel", Description = "From 15th level, when you drop to 0 hit points without being killed outright, you can choose to drop to 1 hit point instead. Once you do so, you can't do it again until you finish a long rest.\n\nYou also don't suffer any of the drawbacks of old age, and you can't be aged by magic." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/undying-sentinel", "it"), Language = LanguageCode.It, Name = "Sentinella Imperitura", Description = "Dal 15° livello, quando scende a 0 punti ferita senza morire sul colpo, il paladino può scegliere di scendere invece a 1 punto ferita. Una volta che lo ha fatto, non può farlo di nuovo finché non completa un riposo lungo.\n\nInoltre non subisce alcuno degli svantaggi della vecchiaia e non può essere invecchiato tramite la magia." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/elder-champion"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 20,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/elder-champion", "en"), Language = LanguageCode.En, Name = "Elder Champion", Description = "At 20th level, you can use your action to take the form of an ancient force of nature, with an appearance you choose: green or bark-like skin, leafy or mossy hair, antlers, a lion's mane and so on. For 1 minute, you gain these benefits:\n- At the start of each of your turns, you regain 10 hit points.\n- You can cast any paladin spell with a casting time of 1 action as a bonus action instead.\n- Enemies within 10 feet of you have disadvantage on saving throws against your paladin spells and Channel Divinity options.\n\nOnce you use this feature, you can't use it again until you finish a long rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "oath-of-the-ancients/elder-champion", "it"), Language = LanguageCode.It, Name = "Campione degli Antichi", Description = "Al 20° livello il paladino può usare la sua azione per assumere la forma di un'antica forza della natura, con l'aspetto che preferisce: pelle verde o simile a corteccia, capelli di foglie o di muschio, palchi di corna, una criniera leonina e così via. Per 1 minuto ottiene questi benefici:\n- All'inizio di ognuno dei suoi turni, recupera 10 punti ferita.\n- Può lanciare qualsiasi incantesimo da paladino con un tempo di lancio di 1 azione usando invece un'azione bonus.\n- I nemici entro 3 metri da lui subiscono svantaggio ai tiri salvezza contro i suoi incantesimi da paladino e le sue opzioni di Incanalare Divinità.\n\nUna volta usato questo privilegio, il paladino non può usarlo di nuovo finché non completa un riposo lungo." }
					}
				}
			}
		};
	}
}
