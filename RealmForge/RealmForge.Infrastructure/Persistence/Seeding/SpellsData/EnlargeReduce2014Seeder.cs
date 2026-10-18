using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Enlarge/Reduce (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class EnlargeReduce2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "enlarge-reduce");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "enlarge-reduce", "en"),
					Language = LanguageCode.En,
					Name = "Enlarge/Reduce",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a pinch of powdered iron",
					Description = "You cause a creature or an object you can see within range to grow larger or smaller for the duration. Choose either a creature or an object that is neither worn nor carried. If the target is unwilling, it can make a Constitution saving throw. On a success, the spell has no effect.\n\nIf the target is a creature, everything it is wearing and carrying changes size with it. Any item dropped by an affected creature returns to normal size at once.\n\n***Enlarge.*** The target's size doubles in all dimensions, and its weight is multiplied by eight. This growth increases its size by one category—from Medium to Large, for example. If there isn't enough room for the target to double its size, the creature or object attains the maximum possible size in the space available. Until the spell ends, the target also has advantage on Strength checks and Strength saving throws. The target's weapons also grow to match its new size. While these weapons are enlarged, the target's attacks with them deal 1d4 extra damage.\n\n***Reduce.*** The target's size is halved in all dimensions, and its weight is reduced to one-eighth of normal. This reduction decreases its size by one category—from Medium to Small, for example. Until the spell ends, the target also has disadvantage on Strength checks and Strength saving throws. The target's weapons also shrink to match its new size. While these weapons are reduced, the target's attacks with them deal 1d4 less damage (this can't reduce the damage below 1).",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "enlarge-reduce", "it"),
					Language = LanguageCode.It,
					Name = "Ingrandire/Ridurre",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pizzico di ferro in polvere",
					Description = "Per la durata, l'incantatore fa diventare più grande o più piccola una creatura o un oggetto entro gittata che sia in grado di vedere. Sceglie una creatura oppure un oggetto che non sia né indossato né trasportato. Se il bersaglio non è consenziente, può effettuare un tiro salvezza su Costituzione. Se lo supera, l'incantesimo non ha alcun effetto.\n\nSe il bersaglio è una creatura, tutto ciò che indossa e trasporta cambia dimensioni insieme a essa. Qualsiasi oggetto lasciato cadere da una creatura influenzata torna immediatamente alle sue dimensioni normali.\n\n***Ingrandire.*** Le dimensioni del bersaglio raddoppiano in ogni direzione e il suo peso viene moltiplicato per otto. Questa crescita aumenta la sua taglia di una categoria: per esempio, da Media a Grande. Se non c'è abbastanza spazio perché il bersaglio raddoppi le sue dimensioni, la creatura o l'oggetto raggiunge le dimensioni massime possibili nello spazio disponibile. Finché l'incantesimo non termina, il bersaglio dispone inoltre di vantaggio alle prove di Forza e ai tiri salvezza su Forza. Anche le armi del bersaglio crescono per adattarsi alla sua nuova taglia. Finché queste armi sono ingrandite, gli attacchi effettuati dal bersaglio con esse infliggono 1d4 danni extra.\n\n***Ridurre.*** Le dimensioni del bersaglio si dimezzano in ogni direzione e il suo peso si riduce a un ottavo del normale. Questa riduzione diminuisce la sua taglia di una categoria: per esempio, da Media a Piccola. Finché l'incantesimo non termina, il bersaglio subisce inoltre svantaggio alle prove di Forza e ai tiri salvezza su Forza. Anche le armi del bersaglio si rimpiccioliscono per adattarsi alla sua nuova taglia. Finché queste armi sono ridotte, gli attacchi effettuati dal bersaglio con esse infliggono 1d4 danni in meno (i danni non possono comunque scendere sotto 1).",
					HigherLevels = null
				}
			}
		};
	}
}
