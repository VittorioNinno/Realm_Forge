using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Aberrant Sorcery (sorcerer, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class AberrantSorcery2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "aberrant-sorcery");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Sorcerer2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "aberrant-sorcery", "en"), Language = LanguageCode.En, Name = "Aberrant Sorcery", Description = "Something alien has wound its tendrils around your mind and left psionic power behind. With it you can reach into other minds and reshape the world around you. Will you become a beacon of hope, or a terror to every mind that feels your touch? Perhaps a psychic gale blowing from the Astral Plane carried this energy to you, or you were touched by the twisting influence of the Far Realm; perhaps a mind flayer tadpole was planted in you but the transformation never came, leaving its power yours. However it happened, your mind now burns with it." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "aberrant-sorcery", "it"), Language = LanguageCode.It, Name = "Stregoneria Aberrante", Description = "Qualcosa di alieno ha avvolto i suoi tentacoli attorno alla mente dello stregone, lasciandogli in dono un potere psionico. Con esso può raggiungere altre menti e rimodellare il mondo che lo circonda. Diventerà un faro di speranza o il terrore di ogni mente che ne avverte il tocco? Forse un vento psichico proveniente dal Piano Astrale gli ha portato questa energia, o forse è stato sfiorato dall'influsso deformante del Reame Remoto; forse gli è stato impiantato un girino di mind flayer, ma la trasformazione non è mai avvenuta e il suo potere è rimasto a lui. In qualunque modo sia accaduto, ora la sua mente arde di questo potere." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/psionic-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/psionic-spells", "en"), Language = LanguageCode.En, Name = "Psionic Spells", Description = "From the Sorcerer level shown in the table below onward, the listed spells are always prepared for you.\n\n| Sorcerer Level | Spells |\n|---|---|\n| 3 | *Arms of Hadar*, *Calm Emotions*, *Detect Thoughts*, *Dissonant Whispers*, *Mind Sliver* |\n| 5 | *Hunger of Hadar*, *Sending* |\n| 7 | *Black Tentacles*, *Summon Aberration* |\n| 9 | *Telekinesis*, *Telepathic Bond* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/psionic-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi Psionici", Description = "Dal livello da stregone indicato nella tabella seguente, lo stregone ha sempre preparati gli incantesimi elencati.\n\n| Livello da stregone | Incantesimi |\n|---|---|\n| 3 | *braccia di Hadar*, *calmare emozioni*, *individuazione dei pensieri*, *scheggia della mente*, *sussurri dissonanti* |\n| 5 | *fame di Hadar*, *inviare* |\n| 7 | *richiama aberrazione*, *tentacoli neri* |\n| 9 | *legame telepatico*, *telecinesi* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/telepathic-speech"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/telepathic-speech", "en"), Language = LanguageCode.En, Name = "Telepathic Speech", Description = "You can link your mind telepathically with another's. As a Bonus Action, pick a creature you can see within 30 feet of you: as long as the two of you are no more than a number of miles apart equal to your Charisma modifier (at least 1 mile), you can speak to each other mind to mind. To understand each other, each of you must think in a language the other knows.\n\nThe link lasts a number of minutes equal to your Sorcerer level, ending sooner if you use this ability to link with someone else." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/telepathic-speech", "it"), Language = LanguageCode.It, Name = "Conversazione Telepatica", Description = "Lo stregone può creare un collegamento telepatico tra la propria mente e quella di un'altra creatura. Come azione bonus, sceglie una creatura che è in grado di vedere entro 9 metri da lui: finché si trovano a una distanza massima pari a 1,5 chilometri per il modificatore di Carisma dello stregone (minimo 1,5 chilometri), i due possono comunicare telepaticamente. Per capirsi, entrambi devono usare mentalmente una lingua conosciuta dall'altro.\n\nIl collegamento dura un numero di minuti pari al livello da stregone e termina prima se lo stregone usa questa capacità per collegarsi a un'altra creatura." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/psionic-sorcery"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/psionic-sorcery", "en"), Language = LanguageCode.En, Name = "Psionic Sorcery", Description = "When you cast a level 1+ spell granted by Psionic Spells, you can pay for it with a spell slot as usual or with Sorcery Points equal to the spell's level. Cast with Sorcery Points, the spell needs no Verbal or Somatic components, and no Material components unless they are consumed or have a listed cost." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/psionic-sorcery", "it"), Language = LanguageCode.It, Name = "Stregoneria Psionica", Description = "Quando lancia un incantesimo di 1° livello o superiore ottenuto con Incantesimi psionici, lo stregone può spendere normalmente uno slot incantesimo oppure un numero di punti stregoneria pari al livello dell'incantesimo. Se usa i punti stregoneria, l'incantesimo non richiede componenti verbali né somatiche, e nemmeno componenti materiali, a meno che non vengano consumate o non ne sia indicato il costo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/psychic-defenses"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/psychic-defenses", "en"), Language = LanguageCode.En, Name = "Psychic Defenses", Description = "Psychic damage meets your Resistance, and your saving throws to avoid or shake off the Charmed or Frightened condition have Advantage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/psychic-defenses", "it"), Language = LanguageCode.It, Name = "Difese Psichiche", Description = "Lo stregone ha resistenza ai danni psichici e dispone di vantaggio ai tiri salvezza per evitare o porre fine alle condizioni di affascinato o spaventato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/revelation-in-flesh"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/revelation-in-flesh", "en"), Language = LanguageCode.En, Name = "Revelation in Flesh", Description = "You can let loose the aberrant truth buried inside you. As a Bonus Action, you can spend 1 or more Sorcery Points to warp your body magically for 10 minutes. For each point spent, pick one of these benefits, which lasts as long as the transformation.\n\n**Aquatic Adaptation.** You gain a Swim Speed equal to twice your Speed and can breathe underwater. Gills open along your neck or behind your ears, and your fingers grow webbed or sprout waving cilia.\n\n**Glistening Flight.** You gain a Fly Speed equal to your Speed and can hover. While you fly, your skin gleams with slime or an unearthly glow.\n\n**See the Invisible.** You see any Invisible creature within 60 feet of you that isn't behind Total Cover. Your eyes turn black or become squirming sensory tendrils.\n\n**Wormlike Movement.** Your body, and whatever you wear or carry, turns slick and pliant. You can squeeze through a gap only 1 inch wide, and you can spend 5 feet of movement to slip out of nonmagical bonds or the Grappled condition." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/revelation-in-flesh", "it"), Language = LanguageCode.It, Name = "Rivelazione della Carne", Description = "Lo stregone può liberare la verità aberrante celata dentro di sé. Come azione bonus, può spendere 1 o più punti stregoneria per alterare magicamente il proprio corpo per 10 minuti. Per ogni punto speso ottiene uno dei benefici seguenti, a sua scelta, che dura finché dura l'alterazione.\n\n**Adattamento acquatico.** Lo stregone ottiene una velocità di nuotare pari al doppio della sua velocità e può respirare sott'acqua. Sul collo o dietro le orecchie gli spuntano branchie, e le sue dita si fanno palmate o si coprono di ciglia ondeggianti.\n\n**Volo scintillante.** Lo stregone ottiene una velocità di volare pari alla sua velocità e può fluttuare. Mentre vola, la sua pelle luccica di muco o di una luce ultraterrena.\n\n**Vedere l'invisibile.** Lo stregone vede qualsiasi creatura invisibile entro 18 metri da lui che non sia dietro copertura totale. I suoi occhi diventano neri oppure si trasformano in tentacoli sensoriali che si contorcono.\n\n**Movimento invertebrato.** Il corpo dello stregone, insieme all'equipaggiamento che indossa o trasporta, diventa viscido e flessibile. Può passare attraverso qualsiasi spazio largo appena 2,5 centimetri e può spendere 1,5 metri di movimento per liberarsi da vincoli non magici o dalla condizione di afferrato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/warping-implosion"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 18,
					SortOrder = 5,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/warping-implosion", "en"), Language = LanguageCode.En, Name = "Warping Implosion", Description = "You can unleash a rift that bends space. As a Magic action, you teleport to an unoccupied space you can see within 120 feet of you. Right after you vanish, each creature within 30 feet of the space you left makes a Strength saving throw against your spell save DC: on a failure, it takes 3d10 Force damage and is dragged straight toward the space you left, stopping in the nearest unoccupied space to it; on a success, it takes only half the damage. After using this feature, you need a Long Rest to use it again, unless you spend 5 Sorcery Points (no action required) to restore it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "aberrant-sorcery/warping-implosion", "it"), Language = LanguageCode.It, Name = "Implosione Distorcente", Description = "Lo stregone può scatenare un'anomalia che deforma lo spazio. Con un'azione di Magia, si teletrasporta in uno spazio libero che è in grado di vedere entro 36 metri da lui. Subito dopo la sua scomparsa, ogni creatura entro 9 metri dallo spazio che ha lasciato effettua un tiro salvezza su Forza contro la CD del tiro salvezza dei suoi incantesimi: se lo fallisce, subisce 3d10 danni da forza e viene trascinata in linea retta verso lo spazio lasciato, fermandosi nello spazio libero più vicino possibile; se lo supera, subisce soltanto la metà dei danni. Dopo aver usato questo privilegio, lo stregone non può farlo di nuovo finché non completa un riposo lungo, a meno che non spenda 5 punti stregoneria (nessuna azione richiesta) per ripristinarlo." }
					}
				}
			}
		};
	}
}
