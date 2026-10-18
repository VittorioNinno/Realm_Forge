using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Contagion (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Contagion2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "contagion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Necromancy,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "contagion", "en"),
					Language = LanguageCode.En,
					Name = "Contagion",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "7 days",
					MaterialComponent = null,
					Description = "Your touch inflicts disease. Make a melee spell attack against a creature within your reach. On a hit, you afflict the creature with a disease of your choice from any of the ones described below.\n\nAt the end of each of the target's turns, it must make a Constitution saving throw. After failing three of these saving throws, the disease's effects last for the duration, and the creature stops making these saves. After succeeding on three of these saving throws, the creature recovers from the disease, and the spell ends.\n\nSince this spell induces a natural disease in its target, any effect that removes a disease or otherwise ameliorates a disease's effects apply to it.\n\n***Blinding Sickness.*** Pain grips the creature's mind, and its eyes turn milky white. The creature has disadvantage on Wisdom checks and Wisdom saving throws and is blinded.\n\n***Filth Fever.*** A raging fever sweeps through the creature's body. The creature has disadvantage on Strength checks, Strength saving throws, and attack rolls that use Strength.\n\n***Flesh Rot.*** The creature's flesh decays. The creature has disadvantage on Charisma checks and vulnerability to all damage.\n\n***Mindfire.*** The creature's mind becomes feverish. The creature has disadvantage on Intelligence checks and Intelligence saving throws, and the creature behaves as if under the effects of the confusion spell during combat.\n\n***Seizure.*** The creature is overcome with shaking. The creature has disadvantage on Dexterity checks, Dexterity saving throws, and attack rolls that use Dexterity.\n\n***Slimy Doom.*** The creature begins to bleed uncontrollably. The creature has disadvantage on Constitution checks and Constitution saving throws. In addition, whenever the creature takes damage, it is stunned until the end of its next turn.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "contagion", "it"),
					Language = LanguageCode.It,
					Name = "Contagio",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "7 giorni",
					MaterialComponent = null,
					Description = "Il tocco dell'incantatore trasmette una malattia. L'incantatore effettua un attacco con incantesimo in mischia contro una creatura entro la sua portata. Se colpisce, infligge alla creatura una malattia a sua scelta tra quelle descritte di seguito.\n\nAlla fine di ogni turno del bersaglio, quest'ultimo deve effettuare un tiro salvezza su Costituzione. Dopo aver fallito tre di questi tiri salvezza, gli effetti della malattia durano per la durata dell'incantesimo e la creatura smette di effettuare i tiri salvezza. Dopo averne superati tre, la creatura guarisce dalla malattia e l'incantesimo termina.\n\nDato che questo incantesimo induce una malattia naturale nel bersaglio, qualsiasi effetto che rimuove una malattia o ne attenua in altro modo gli effetti si applica anche a essa.\n\n***Febbre Lurida.*** Una febbre violenta pervade il corpo della creatura. La creatura subisce svantaggio alle prove di Forza, ai tiri salvezza su Forza e ai tiri per colpire che usano la Forza.\n\n***Fuoco Mentale.*** La mente della creatura diventa febbricitante. La creatura subisce svantaggio alle prove di Intelligenza e ai tiri salvezza su Intelligenza, e in combattimento si comporta come se fosse sotto l'effetto dell'incantesimo confusione.\n\n***Male Accecante.*** Il dolore attanaglia la mente della creatura e i suoi occhi diventano bianchi come il latte. La creatura subisce svantaggio alle prove di Saggezza e ai tiri salvezza su Saggezza, ed è accecata.\n\n***Morbo Viscido.*** La creatura inizia a sanguinare in modo incontrollabile. La creatura subisce svantaggio alle prove di Costituzione e ai tiri salvezza su Costituzione. Inoltre, ogni volta che subisce danni, è stordita fino alla fine del suo turno successivo.\n\n***Putrefazione della Carne.*** La carne della creatura si decompone. La creatura subisce svantaggio alle prove di Carisma ed è vulnerabile a tutti i danni.\n\n***Tremori.*** La creatura è scossa da tremori. La creatura subisce svantaggio alle prove di Destrezza, ai tiri salvezza su Destrezza e ai tiri per colpire che usano la Destrezza.",
					HigherLevels = null
				}
			}
		};
	}
}
