using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Secret Chest (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SecretChest2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "secret-chest");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "secret-chest", "en"),
					Language = LanguageCode.En,
					Name = "Secret Chest",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Instantaneous",
					MaterialComponent = "an exquisite chest, 3 feet by 2 feet by 2 feet, constructed from rare materials worth at least 5,000 gp, and a Tiny replica made from the same materials worth at least 50 gp",
					Description = "You hide a chest, and all its contents, on the Ethereal Plane. You must touch the chest and the miniature replica that serves as a material component for the spell. The chest can contain up to 12 cubic feet of nonliving material (3 feet by 2 feet by 2 feet).\n\nWhile the chest remains on the Ethereal Plane, you can use an action and touch the replica to recall the chest. It appears in an unoccupied space on the ground within 5 feet of you. You can send the chest back to the Ethereal Plane by using an action and touching both the chest and the replica.\n\nAfter 60 days, there is a cumulative 5 percent chance per day that the spell's effect ends. This effect ends if you cast this spell again, if the smaller replica chest is destroyed, or if you choose to end the spell as an action. If the spell ends and the larger chest is on the Ethereal Plane, it is irretrievably lost.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "secret-chest", "it"),
					Language = LanguageCode.It,
					Name = "Scrigno Segreto",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Istantanea",
					MaterialComponent = "uno scrigno pregiato di 90 cm per 60 cm per 60 cm, realizzato con materiali rari del valore di almeno 5.000 mo, e una sua riproduzione di taglia Minuscola fatta degli stessi materiali, del valore di almeno 50 mo",
					Description = "L'incantatore nasconde uno scrigno, con tutto il suo contenuto, nel Piano Etereo. Deve toccare lo scrigno e la riproduzione in miniatura che funge da componente materiale dell'incantesimo. Lo scrigno può contenere fino a 90 cm per 60 cm per 60 cm di materiale non vivente.\n\nFinché lo scrigno rimane nel Piano Etereo, l'incantatore può usare un'azione e toccare la riproduzione per richiamarlo. Lo scrigno compare in uno spazio libero sul terreno entro 1,5 metri dall'incantatore. L'incantatore può rimandare lo scrigno nel Piano Etereo usando un'azione e toccando sia lo scrigno sia la riproduzione.\n\nDopo 60 giorni, c'è una probabilità cumulativa del 5 per cento al giorno che l'effetto dell'incantesimo termini. Questo effetto termina se l'incantatore lancia di nuovo questo incantesimo, se la riproduzione in miniatura viene distrutta o se l'incantatore sceglie di porre fine all'incantesimo come azione. Se l'incantesimo termina mentre lo scrigno grande si trova nel Piano Etereo, lo scrigno è perduto per sempre.",
					HigherLevels = null
				}
			}
		};
	}
}
