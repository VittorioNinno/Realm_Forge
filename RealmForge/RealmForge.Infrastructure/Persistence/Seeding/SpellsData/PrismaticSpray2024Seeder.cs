using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Prismatic Spray (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PrismaticSpray2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prismatic-spray");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 7,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prismatic-spray", "en"),
					Language = LanguageCode.En,
					Name = "Prismatic Spray",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Instantaneous",
					MaterialComponent = null,
					Description = "Eight rays of light flash from you in a 60-foot Cone. Each creature in the Cone makes a Dexterity saving throw. For each target, roll 1d8 to determine which color ray affects it, consulting the Prismatic Rays table.\n\n**Prismatic Rays**\n\n| 1d8 | Ray |\n|---|---|\n| 1 | **Red.** *Failed Save:* 12d6 Fire damage. *Successful Save:* Half as much damage. |\n| 2 | **Orange.** *Failed Save:* 12d6 Acid damage. *Successful Save:* Half as much damage. |\n| 3 | **Yellow.** *Failed Save:* 12d6 Lightning damage. *Successful Save:* Half as much damage. |\n| 4 | **Green.** *Failed Save:* 12d6 Poison damage. *Successful Save:* Half as much damage. |\n| 5 | **Blue.** *Failed Save:* 12d6 Cold damage. *Successful Save:* Half as much damage. |\n| 6 | **Indigo.** *Failed Save:* The target has the Restrained condition and makes a Constitution saving throw at the end of each of its turns. If it successfully saves three times, the condition ends. If it fails three times, it has the Petrified condition until it is freed by an effect like the *Greater Restoration* spell. The successes and failures needn't be consecutive; keep track of both until the target collects three of a kind. |\n| 7 | **Violet.** *Failed Save:* The target has the Blinded condition and makes a Wisdom saving throw at the start of your next turn. On a successful save, the condition ends. On a failed save, the condition ends, and the creature teleports to another plane of existence (GM's choice). |\n| 8 | **Special.** The target is struck by two rays. Roll twice, rerolling any 8. |",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "prismatic-spray", "it"),
					Language = LanguageCode.It,
					Name = "Spruzzo Prismatico",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Istantanea",
					MaterialComponent = null,
					Description = "Otto raggi di luce scaturiscono dall'incantatore in un cono di 18 metri. Ogni creatura nel cono effettua un tiro salvezza su Destrezza. Per ogni bersaglio, l'incantatore tira 1d8 per determinare quale raggio colorato lo influenza, consultando la tabella dei Raggi Prismatici.\n\n**Raggi Prismatici**\n\n| 1d8 | Raggio |\n|---|---|\n| 1 | **Rosso.** *Tiro salvezza fallito:* 12d6 danni da fuoco. *Tiro salvezza superato:* la metà di quei danni. |\n| 2 | **Arancione.** *Tiro salvezza fallito:* 12d6 danni da acido. *Tiro salvezza superato:* la metà di quei danni. |\n| 3 | **Giallo.** *Tiro salvezza fallito:* 12d6 danni da fulmine. *Tiro salvezza superato:* la metà di quei danni. |\n| 4 | **Verde.** *Tiro salvezza fallito:* 12d6 danni da veleno. *Tiro salvezza superato:* la metà di quei danni. |\n| 5 | **Blu.** *Tiro salvezza fallito:* 12d6 danni da freddo. *Tiro salvezza superato:* la metà di quei danni. |\n| 6 | **Indaco.** *Tiro salvezza fallito:* il bersaglio è trattenuto ed effettua un tiro salvezza su Costituzione alla fine di ogni suo turno. Se lo supera tre volte, la condizione termina. Se lo fallisce tre volte, è pietrificato finché non viene liberato da un effetto come l'incantesimo *ristorare superiore*. I successi e i fallimenti non devono essere necessariamente consecutivi; si tiene il conto di entrambi finché il bersaglio non ne accumula tre dello stesso tipo. |\n| 7 | **Violetto.** *Tiro salvezza fallito:* il bersaglio è accecato ed effettua un tiro salvezza su Saggezza all'inizio del turno successivo dell'incantatore. Se lo supera, la condizione termina. Se lo fallisce, la condizione termina e la creatura si teletrasporta su un altro piano di esistenza (a scelta del DM). |\n| 8 | **Speciale.** Il bersaglio viene colpito da due raggi. Si tira due volte, ritirando qualsiasi 8. |",
					HigherLevels = null
				}
			}
		};
	}
}
