using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Enlarge/Reduce (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class EnlargeReduce2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "enlarge-reduce");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Druid, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "enlarge-reduce", "en"),
					Language = LanguageCode.En,
					Name = "Enlarge/Reduce",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a pinch of powdered iron",
					Description = "For the duration, the spell enlarges or reduces a creature or an object you can see within range (see the chosen effect below). A targeted object must be neither worn nor carried. If the target is an unwilling creature, it can make a Constitution saving throw. On a successful save, the spell has no effect.\n\nEverything that a targeted creature is wearing and carrying changes size with it. Any item it drops returns to normal size at once. A thrown weapon or piece of ammunition returns to normal size immediately after it hits or misses a target.\n\n***Enlarge.*** The target's size increases by one category—from Medium to Large, for example. The target also has Advantage on Strength checks and Strength saving throws. The target's attacks with its enlarged weapons or Unarmed Strikes deal an extra 1d4 damage on a hit.\n\n***Reduce.*** The target's size decreases by one category—from Medium to Small, for example. The target also has Disadvantage on Strength checks and Strength saving throws. The target's attacks with its reduced weapons or Unarmed Strikes deal 1d4 less damage on a hit (this can't reduce the damage below 1).",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "enlarge-reduce", "it"),
					Language = LanguageCode.It,
					Name = "Ingrandire/Ridurre",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pizzico di ferro in polvere",
					Description = "Per la durata, l'incantesimo ingrandisce o rimpicciolisce una creatura o un oggetto entro gittata che l'incantatore è in grado di vedere (vedi l'effetto scelto sotto). Un oggetto preso come bersaglio non deve essere né indossato né trasportato. Se il bersaglio è una creatura non consenziente, può effettuare un tiro salvezza su Costituzione. Se lo supera, l'incantesimo non ha alcun effetto.\n\nTutto ciò che una creatura presa come bersaglio indossa e trasporta cambia taglia insieme a essa. Qualsiasi oggetto lasciato cadere dalla creatura torna immediatamente alla taglia normale. Un'arma da lancio o un proiettile tornano alla taglia normale subito dopo aver colpito o mancato un bersaglio.\n\n***Ingrandire.*** La taglia del bersaglio aumenta di una categoria, per esempio da Media a Grande. Il bersaglio dispone inoltre di vantaggio alle prove di Forza e ai tiri salvezza su Forza. Gli attacchi del bersaglio con le sue armi ingrandite o con i colpi senz'armi infliggono 1d4 danni extra quando colpiscono.\n\n***Ridurre.*** La taglia del bersaglio diminuisce di una categoria, per esempio da Media a Piccola. Il bersaglio subisce inoltre svantaggio alle prove di Forza e ai tiri salvezza su Forza. Gli attacchi del bersaglio con le sue armi ridotte o con i colpi senz'armi infliggono 1d4 danni in meno quando colpiscono (questo non può ridurre i danni al di sotto di 1).",
					HigherLevels = null
				}
			}
		};
	}
}
