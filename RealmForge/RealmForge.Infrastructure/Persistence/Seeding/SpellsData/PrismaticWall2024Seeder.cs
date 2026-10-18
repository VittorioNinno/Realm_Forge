using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Prismatic Wall (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PrismaticWall2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prismatic-wall");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 9,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prismatic-wall", "en"),
					Language = LanguageCode.En,
					Name = "Prismatic Wall",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "10 minutes",
					MaterialComponent = null,
					Description = "A shimmering, multicolored plane of light forms a vertical opaque wall—up to 90 feet long, 30 feet high, and 1 inch thick—centered on a point within range. Alternatively, you shape the wall into a globe up to 30 feet in diameter centered on a point within range. The wall lasts for the duration. If you position the wall in a space occupied by a creature, the spell ends instantly without effect.\n\nThe wall sheds Bright Light within 100 feet and Dim Light for an additional 100 feet. You and creatures you designate when you cast the spell can pass through and be near the wall without harm. If another creature that can see the wall moves within 20 feet of it or starts its turn there, the creature must succeed on a Constitution saving throw or have the Blinded condition for 1 minute.\n\nThe wall consists of seven layers, each with a different color. When a creature reaches into or passes through the wall, it does so one layer at a time through all the layers. Each layer forces the creature to make a Dexterity saving throw or be affected by that layer's properties as described in the Prismatic Layers table.\n\nThe wall, which has AC 10, can be destroyed one layer at a time, in order from red to violet, by means specific to each layer. If a layer is destroyed, it is gone for the duration. *Antimagic Field* has no effect on the wall, and *Dispel Magic* can affect only the violet layer.\n\n**Prismatic Layers**\n\n| Order | Effects |\n|---|---|\n| 1 | **Red.** *Failed Save:* 12d6 Fire damage. *Successful Save:* Half as much damage. *Additional Effects:* Nonmagical ranged attacks can't pass through this layer, which is destroyed if it takes at least 25 Cold damage. |\n| 2 | **Orange.** *Failed Save:* 12d6 Acid damage. *Successful Save:* Half as much damage. *Additional Effects:* Magical ranged attacks can't pass through this layer, which is destroyed by a strong wind (such as the one created by *Gust of Wind*). |\n| 3 | **Yellow.** *Failed Save:* 12d6 Lightning damage. *Successful Save:* Half as much damage. *Additional Effects:* The layer is destroyed if it takes at least 60 Force damage. |\n| 4 | **Green.** *Failed Save:* 12d6 Poison damage. *Successful Save:* Half as much damage. *Additional Effects:* A *Passwall* spell, or another spell of equal or greater level that can open a portal on a solid surface, destroys this layer. |\n| 5 | **Blue.** *Failed Save:* 12d6 Cold damage. *Successful Save:* Half as much damage. *Additional Effects:* The layer is destroyed if it takes at least 25 Fire damage. |\n| 6 | **Indigo.** *Failed Save:* The target has the Restrained condition and makes a Constitution saving throw at the end of each of its turns. If it successfully saves three times, the condition ends. If it fails three times, it has the Petrified condition until it is freed by an effect like the *Greater Restoration* spell. The successes and failures needn't be consecutive; keep track of both until the target collects three of a kind. *Additional Effects:* Spells can't be cast through this layer, which is destroyed by Bright Light shed by the *Daylight* spell. |\n| 7 | **Violet.** *Failed Save:* The target has the Blinded condition and makes a Wisdom saving throw at the start of your next turn. On a successful save, the condition ends. On a failed save, the condition ends, and the creature teleports to another plane of existence (GM's choice). *Additional Effects:* This layer is destroyed by *Dispel Magic*. |",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prismatic-wall", "it"),
					Language = LanguageCode.It,
					Name = "Muro Prismatico",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "10 minuti",
					MaterialComponent = null,
					Description = "Un piano di luce multicolore e scintillante forma un muro verticale opaco (lungo fino a 27 metri, alto 9 metri e spesso 2,5 centimetri) centrato su un punto entro gittata. In alternativa, l'incantatore dà al muro la forma di un globo del diametro massimo di 9 metri, centrato su un punto entro gittata. Il muro permane per la durata. Se l'incantatore colloca il muro in uno spazio occupato da una creatura, l'incantesimo termina immediatamente senza alcun effetto.\n\nIl muro proietta luce intensa entro 30 metri e luce fioca per altri 30 metri. L'incantatore e le creature da lui designate al momento del lancio possono attraversare il muro e trovarsi vicino a esso senza subire danni. Se un'altra creatura che è in grado di vedere il muro si muove entro 6 metri da esso o vi inizia il proprio turno, deve superare un tiro salvezza su Costituzione, altrimenti è accecata per 1 minuto.\n\nIl muro è composto da sette strati, ognuno di un colore diverso. Quando una creatura si protende nel muro o lo attraversa, lo fa uno strato alla volta, attraverso tutti gli strati. Ogni strato costringe la creatura a effettuare un tiro salvezza su Destrezza, altrimenti subisce le proprietà di quello strato, come descritto nella tabella degli Strati Prismatici.\n\nIl muro, che ha CA 10, può essere distrutto uno strato alla volta, in ordine dal rosso al violetto, con mezzi specifici per ciascuno strato. Se uno strato viene distrutto, scompare per la durata. *Campo anti-magia* non ha alcun effetto sul muro, e *dissolvi magie* può influenzare soltanto lo strato violetto.\n\n**Strati Prismatici**\n\n| Ordine | Effetti |\n|---|---|\n| 1 | **Rosso.** *Tiro salvezza fallito:* 12d6 danni da fuoco. *Tiro salvezza superato:* la metà di quei danni. *Effetti aggiuntivi:* gli attacchi a distanza non magici non possono attraversare questo strato, che viene distrutto se subisce almeno 25 danni da freddo. |\n| 2 | **Arancione.** *Tiro salvezza fallito:* 12d6 danni da acido. *Tiro salvezza superato:* la metà di quei danni. *Effetti aggiuntivi:* gli attacchi a distanza magici non possono attraversare questo strato, che viene distrutto da un vento forte (come quello creato da *folata di vento*). |\n| 3 | **Giallo.** *Tiro salvezza fallito:* 12d6 danni da fulmine. *Tiro salvezza superato:* la metà di quei danni. *Effetti aggiuntivi:* lo strato viene distrutto se subisce almeno 60 danni da forza. |\n| 4 | **Verde.** *Tiro salvezza fallito:* 12d6 danni da veleno. *Tiro salvezza superato:* la metà di quei danni. *Effetti aggiuntivi:* un incantesimo *passapareti*, o un altro incantesimo di livello pari o superiore in grado di aprire un portale su una superficie solida, distrugge questo strato. |\n| 5 | **Blu.** *Tiro salvezza fallito:* 12d6 danni da freddo. *Tiro salvezza superato:* la metà di quei danni. *Effetti aggiuntivi:* lo strato viene distrutto se subisce almeno 25 danni da fuoco. |\n| 6 | **Indaco.** *Tiro salvezza fallito:* il bersaglio è trattenuto ed effettua un tiro salvezza su Costituzione alla fine di ogni suo turno. Se lo supera tre volte, la condizione termina. Se lo fallisce tre volte, è pietrificato finché non viene liberato da un effetto come l'incantesimo *ristorare superiore*. I successi e i fallimenti non devono essere necessariamente consecutivi; si tiene il conto di entrambi finché il bersaglio non ne accumula tre dello stesso tipo. *Effetti aggiuntivi:* non è possibile lanciare incantesimi attraverso questo strato, che viene distrutto dalla luce intensa proiettata dall'incantesimo *luce diurna*. |\n| 7 | **Violetto.** *Tiro salvezza fallito:* il bersaglio è accecato ed effettua un tiro salvezza su Saggezza all'inizio del turno successivo dell'incantatore. Se lo supera, la condizione termina. Se lo fallisce, la condizione termina e la creatura si teletrasporta su un altro piano di esistenza (a scelta del DM). *Effetti aggiuntivi:* questo strato viene distrutto da *dissolvi magie*. |",
					HigherLevels = null
				}
			}
		};
	}
}
