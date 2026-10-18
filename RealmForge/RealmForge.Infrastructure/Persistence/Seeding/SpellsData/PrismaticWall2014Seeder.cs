using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Prismatic Wall (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PrismaticWall2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prismatic-wall");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 9,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prismatic-wall", "en"),
					Language = LanguageCode.En,
					Name = "Prismatic Wall",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "10 minutes",
					MaterialComponent = null,
					Description = "A shimmering, multicolored plane of light forms a vertical opaque wall—up to 90 feet long, 30 feet high, and 1 inch thick—centered on a point you can see within range. Alternatively, you can shape the wall into a sphere up to 30 feet in diameter centered on a point you choose within range. The wall remains in place for the duration. If you position the wall so that it passes through a space occupied by a creature, the spell fails, and your action and the spell slot are wasted.\n\nThe wall sheds bright light out to a range of 100 feet and dim light for an additional 100 feet. You and creatures you designate at the time you cast the spell can pass through and remain near the wall without harm. If another creature that can see the wall moves to within 20 feet of it or starts its turn there, the creature must succeed on a Constitution saving throw or become blinded for 1 minute.\n\nThe wall consists of seven layers, each with a different color. When a creature attempts to reach into or pass through the wall, it does so one layer at a time through all the wall's layers. As it passes or reaches through each layer, the creature must make a Dexterity saving throw or be affected by that layer's properties as described below.\n\nThe wall can be destroyed, also one layer at a time, in order from red to violet, by means specific to each layer. Once a layer is destroyed, it remains so for the duration of the spell. A rod of cancellation destroys a prismatic wall, but an antimagic field has no effect on it.\n\n***1. Red.*** The creature takes 10d6 fire damage on a failed save, or half as much damage on a successful one. While this layer is in place, nonmagical ranged attacks can't pass through the wall. The layer can be destroyed by dealing at least 25 cold damage to it.\n\n***2. Orange.*** The creature takes 10d6 acid damage on a failed save, or half as much damage on a successful one. While this layer is in place, magical ranged attacks can't pass through the wall. The layer is destroyed by a strong wind.\n\n***3. Yellow.*** The creature takes 10d6 lightning damage on a failed save, or half as much damage on a successful one. This layer can be destroyed by dealing at least 60 force damage to it.\n\n***4. Green.*** The creature takes 10d6 poison damage on a failed save, or half as much damage on a successful one. A passwall spell, or another spell of equal or greater level that can open a portal on a solid surface, destroys this layer.\n\n***5. Blue.*** The creature takes 10d6 cold damage on a failed save, or half as much damage on a successful one. This layer can be destroyed by dealing at least 25 fire damage to it.\n\n***6. Indigo.*** On a failed save, the creature is restrained. It must then make a Constitution saving throw at the end of each of its turns. If it successfully saves three times, the spell ends. If it fails its save three times, it permanently turns to stone and is subjected to the petrified condition. The successes and failures don't need to be consecutive; keep track of both until the creature collects three of a kind.\n\nWhile this layer is in place, spells can't be cast through the wall. The layer is destroyed by bright light shed by a daylight spell or a similar spell of equal or higher level.\n\n***7. Violet.*** On a failed save, the creature is blinded. It must then make a Wisdom saving throw at the start of your next turn. A successful save ends the blindness. If it fails that save, the creature is transported to another plane of the GM's choosing and is no longer blinded. (Typically, a creature that is on a plane that isn't its home plane is banished home, while other creatures are usually cast into the Astral or Ethereal planes.) This layer is destroyed by a dispel magic spell or a similar spell of equal or higher level that can end spells and magical effects.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prismatic-wall", "it"),
					Language = LanguageCode.It,
					Name = "Muro Prismatico",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "10 minuti",
					MaterialComponent = null,
					Description = "Un piano di luce scintillante e multicolore forma un muro verticale opaco, lungo fino a 27 metri, alto 9 metri e spesso 2,5 cm, centrato su un punto entro gittata che l'incantatore sia in grado di vedere. In alternativa, l'incantatore può dare al muro la forma di una sfera del diametro massimo di 9 metri, centrata su un punto entro gittata da lui scelto. Il muro rimane al suo posto per la durata. Se l'incantatore posiziona il muro in modo che attraversi uno spazio occupato da una creatura, l'incantesimo fallisce e l'azione e lo slot incantesimo vanno sprecati.\n\nIl muro emette luce intensa fino a una distanza di 30 metri e luce fioca per ulteriori 30 metri. L'incantatore e le creature da lui designate al momento del lancio possono attraversare il muro e restare nelle sue vicinanze senza subire danni. Se un'altra creatura in grado di vedere il muro si avvicina entro 6 metri da esso o vi inizia il proprio turno, deve superare un tiro salvezza su Costituzione, altrimenti è accecata per 1 minuto.\n\nIl muro è composto da sette strati, ognuno di un colore diverso. Quando una creatura tenta di allungarsi attraverso il muro o di attraversarlo, lo fa uno strato alla volta, attraverso tutti gli strati del muro. Mentre attraversa ogni strato o si allunga attraverso di esso, la creatura deve effettuare un tiro salvezza su Destrezza, altrimenti è influenzata dalle proprietà di quello strato, come descritto di seguito.\n\nIl muro può essere distrutto, anch'esso uno strato alla volta, in ordine dal rosso al violetto, con mezzi specifici per ogni strato. Una volta distrutto, uno strato rimane tale per la durata dell'incantesimo. Una verga della cancellazione distrugge un muro prismatico, mentre un campo anti-magia non ha alcun effetto su di esso.\n\n***1. Rosso.*** La creatura subisce 10d6 danni da fuoco se fallisce il tiro salvezza, o la metà di quei danni se lo supera. Finché questo strato è presente, gli attacchi a distanza non magici non possono attraversare il muro. Lo strato può essere distrutto infliggendogli almeno 25 danni da freddo.\n\n***2. Arancione.*** La creatura subisce 10d6 danni da acido se fallisce il tiro salvezza, o la metà di quei danni se lo supera. Finché questo strato è presente, gli attacchi a distanza magici non possono attraversare il muro. Lo strato viene distrutto da un vento forte.\n\n***3. Giallo.*** La creatura subisce 10d6 danni da fulmine se fallisce il tiro salvezza, o la metà di quei danni se lo supera. Questo strato può essere distrutto infliggendogli almeno 60 danni da forza.\n\n***4. Verde.*** La creatura subisce 10d6 danni da veleno se fallisce il tiro salvezza, o la metà di quei danni se lo supera. Un incantesimo passapareti, o un altro incantesimo di livello pari o superiore che possa aprire un passaggio in una superficie solida, distrugge questo strato.\n\n***5. Blu.*** La creatura subisce 10d6 danni da freddo se fallisce il tiro salvezza, o la metà di quei danni se lo supera. Questo strato può essere distrutto infliggendogli almeno 25 danni da fuoco.\n\n***6. Indaco.*** Se fallisce il tiro salvezza, la creatura è trattenuta. Deve poi effettuare un tiro salvezza su Costituzione alla fine di ogni suo turno. Se lo supera tre volte, l'incantesimo termina. Se lo fallisce tre volte, viene trasformata permanentemente in pietra e subisce la condizione di pietrificato. I successi e i fallimenti non devono necessariamente essere consecutivi: si tiene traccia di entrambi finché la creatura non ne accumula tre dello stesso tipo.\n\nFinché questo strato è presente, non è possibile lanciare incantesimi attraverso il muro. Lo strato viene distrutto dalla luce intensa emessa da un incantesimo luce diurna o da un incantesimo simile di livello pari o superiore.\n\n***7. Violetto.*** Se fallisce il tiro salvezza, la creatura è accecata. Deve poi effettuare un tiro salvezza su Saggezza all'inizio del turno successivo dell'incantatore. Se lo supera, la cecità termina. Se lo fallisce, la creatura viene trasportata in un altro piano a scelta del DM e non è più accecata. (Di solito, una creatura che si trova in un piano diverso dal suo piano d'origine viene esiliata nel suo piano d'origine, mentre le altre creature vengono generalmente scagliate nel Piano Astrale o nel Piano Etereo.) Questo strato viene distrutto da un incantesimo dissolvi magie o da un incantesimo simile di livello pari o superiore che possa porre fine agli incantesimi e agli effetti magici.",
					HigherLevels = null
				}
			}
		};
	}
}
