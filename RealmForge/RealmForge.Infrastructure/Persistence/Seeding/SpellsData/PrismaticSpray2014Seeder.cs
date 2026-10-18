using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Prismatic Spray (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PrismaticSpray2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prismatic-spray");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 7,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prismatic-spray", "en"),
					Language = LanguageCode.En,
					Name = "Prismatic Spray",
					CastingTime = "1 action",
					Range = "Self (60-foot cone)",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Eight multicolored rays of light flash from your hand. Each ray is a different color and has a different power and purpose. Each creature in a 60-foot cone must make a Dexterity saving throw. For each target, roll a d8 to determine which color ray affects it.\n\n***1. Red.*** The target takes 10d6 fire damage on a failed save, or half as much damage on a successful one.\n\n***2. Orange.*** The target takes 10d6 acid damage on a failed save, or half as much damage on a successful one.\n\n***3. Yellow.*** The target takes 10d6 lightning damage on a failed save, or half as much damage on a successful one.\n\n***4. Green.*** The target takes 10d6 poison damage on a failed save, or half as much damage on a successful one.\n\n***5. Blue.*** The target takes 10d6 cold damage on a failed save, or half as much damage on a successful one.\n\n***6. Indigo.*** On a failed save, the target is restrained. It must then make a Constitution saving throw at the end of each of its turns. If it successfully saves three times, the spell ends. If it fails its save three times, it permanently turns to stone and is subjected to the petrified condition. The successes and failures don't need to be consecutive; keep track of both until the target collects three of a kind.\n\n***7. Violet.*** On a failed save, the target is blinded. It must then make a Wisdom saving throw at the start of your next turn. A successful save ends the blindness. If it fails that save, the creature is transported to another plane of existence of the GM's choosing and is no longer blinded. (Typically, a creature that is on a plane that isn't its home plane is banished home, while other creatures are usually cast into the Astral or Ethereal planes.)\n\n***8. Special.*** The target is struck by two rays. Roll twice more, rerolling any 8.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "prismatic-spray", "it"),
					Language = LanguageCode.It,
					Name = "Spruzzo Prismatico",
					CastingTime = "1 azione",
					Range = "Incantatore (cono di 18 metri)",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Otto raggi di luce multicolore scaturiscono dalla mano dell'incantatore. Ogni raggio è di un colore diverso e ha un potere e uno scopo diversi. Ogni creatura in un cono di 18 metri deve effettuare un tiro salvezza su Destrezza. Per ogni bersaglio, si tira un d8 per determinare quale raggio colorato lo influenza.\n\n***1. Rosso.*** Il bersaglio subisce 10d6 danni da fuoco se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\n***2. Arancione.*** Il bersaglio subisce 10d6 danni da acido se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\n***3. Giallo.*** Il bersaglio subisce 10d6 danni da fulmine se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\n***4. Verde.*** Il bersaglio subisce 10d6 danni da veleno se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\n***5. Blu.*** Il bersaglio subisce 10d6 danni da freddo se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\n***6. Indaco.*** Se fallisce il tiro salvezza, il bersaglio è trattenuto. Deve poi effettuare un tiro salvezza su Costituzione alla fine di ogni suo turno. Se lo supera tre volte, l'incantesimo termina. Se lo fallisce tre volte, viene trasformato permanentemente in pietra e subisce la condizione di pietrificato. I successi e i fallimenti non devono necessariamente essere consecutivi: si tiene traccia di entrambi finché il bersaglio non ne accumula tre dello stesso tipo.\n\n***7. Violetto.*** Se fallisce il tiro salvezza, il bersaglio è accecato. Deve poi effettuare un tiro salvezza su Saggezza all'inizio del turno successivo dell'incantatore. Se lo supera, la cecità termina. Se lo fallisce, la creatura viene trasportata in un altro piano di esistenza a scelta del DM e non è più accecata. (Di solito, una creatura che si trova in un piano diverso dal suo piano d'origine viene esiliata nel suo piano d'origine, mentre le altre creature vengono generalmente scagliate nel Piano Astrale o nel Piano Etereo.)\n\n***8. Speciale.*** Il bersaglio viene colpito da due raggi. Si tira altre due volte, ritirando ogni 8.",
					HigherLevels = null
				}
			}
		};
	}
}
