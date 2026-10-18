using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Flesh to Stone (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FleshToStone2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flesh-to-stone");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 6,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flesh-to-stone", "en"),
					Language = LanguageCode.En,
					Name = "Flesh to Stone",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a cockatrice feather",
					Description = "You attempt to turn one creature that you can see within range into stone. The target makes a Constitution saving throw. On a failed save, it has the Restrained condition for the duration. On a successful save, its Speed is 0 until the start of your next turn. Constructs automatically succeed on the save.\n\nA Restrained target makes another Constitution saving throw at the end of each of its turns. If it successfully saves against this spell three times, the spell ends. If it fails its saves three times, it is turned to stone and has the Petrified condition for the duration. The successes and failures needn't be consecutive; keep track of both until the target collects three of a kind.\n\nIf you maintain your Concentration on this spell for the entire possible duration, the target is Petrified until the condition is ended by *Greater Restoration* or similar magic.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "flesh-to-stone", "it"),
					Language = LanguageCode.It,
					Name = "Carne in Pietra",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una piuma di cockatrice",
					Description = "L'incantatore tenta di trasformare in pietra una creatura entro gittata che è in grado di vedere. Il bersaglio effettua un tiro salvezza su Costituzione. Se lo fallisce, è trattenuto per la durata. Se lo supera, la sua velocità è 0 fino all'inizio del turno successivo dell'incantatore. I costrutti superano automaticamente il tiro salvezza.\n\nUn bersaglio trattenuto effettua un altro tiro salvezza su Costituzione alla fine di ogni suo turno. Se supera tre volte il tiro salvezza contro questo incantesimo, l'incantesimo termina. Se lo fallisce tre volte, viene trasformato in pietra ed è pietrificato per la durata. I successi e i fallimenti non devono essere necessariamente consecutivi; si tiene il conto di entrambi finché il bersaglio non ne accumula tre dello stesso tipo.\n\nSe l'incantatore mantiene la concentrazione su questo incantesimo per l'intera durata possibile, il bersaglio resta pietrificato finché la condizione non viene terminata da *ristorare superiore* o da una magia simile.",
					HigherLevels = null
				}
			}
		};
	}
}
