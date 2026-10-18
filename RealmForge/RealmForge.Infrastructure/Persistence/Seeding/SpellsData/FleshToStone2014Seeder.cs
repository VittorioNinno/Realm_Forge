using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Flesh to Stone (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class FleshToStone2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flesh-to-stone");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flesh-to-stone", "en"),
					Language = LanguageCode.En,
					Name = "Flesh to Stone",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a pinch of lime, water, and earth",
					Description = "You attempt to turn one creature that you can see within range into stone. If the target's body is made of flesh, the creature must make a Constitution saving throw. On a failed save, it is restrained as its flesh begins to harden. On a successful save, the creature isn't affected.\n\nA creature restrained by this spell must make another Constitution saving throw at the end of each of its turns. If it successfully saves against this spell three times, the spell ends. If it fails its saves three times, it is turned to stone and subjected to the petrified condition for the duration. The successes and failures don't need to be consecutive; keep track of both until the target collects three of a kind.\n\nIf the creature is physically broken while petrified, it suffers from similar deformities if it reverts to its original state.\n\nIf you maintain your concentration on this spell for the entire possible duration, the creature is turned to stone until the effect is removed.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "flesh-to-stone", "it"),
					Language = LanguageCode.It,
					Name = "Carne in Pietra",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pizzico di calce, acqua e terra",
					Description = "L'incantatore tenta di trasformare in pietra una creatura entro gittata che sia in grado di vedere. Se il corpo del bersaglio è fatto di carne, la creatura deve effettuare un tiro salvezza su Costituzione. Se lo fallisce, è trattenuta mentre la sua carne inizia a indurirsi. Se lo supera, la creatura non è influenzata.\n\nUna creatura trattenuta da questo incantesimo deve effettuare un altro tiro salvezza su Costituzione alla fine di ogni suo turno. Se supera tre volte il tiro salvezza contro questo incantesimo, l'incantesimo termina. Se lo fallisce tre volte, viene trasformata in pietra e subisce la condizione di pietrificata per la durata. I successi e i fallimenti non devono necessariamente essere consecutivi: si tiene traccia di entrambi finché il bersaglio non ne accumula tre dello stesso tipo.\n\nSe la creatura viene fisicamente spezzata mentre è pietrificata, quando torna al suo stato originale presenta deformità corrispondenti.\n\nSe l'incantatore mantiene la concentrazione su questo incantesimo per tutta la durata possibile, la creatura resta trasformata in pietra finché l'effetto non viene rimosso.",
					HigherLevels = null
				}
			}
		};
	}
}
