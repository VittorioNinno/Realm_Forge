using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Secret Chest (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class SecretChest2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "secret-chest");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "secret-chest", "en"),
					Language = LanguageCode.En,
					Name = "Secret Chest",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Until dispelled",
					MaterialComponent = "a chest, 3 feet by 2 feet by 2 feet, constructed from rare materials worth 5,000+ GP, and a Tiny replica of the chest made from the same materials worth 50+ GP",
					Description = "You hide a chest and all its contents on the Ethereal Plane. You must touch the chest and the miniature replica that serve as Material components for the spell. The chest can contain up to 12 cubic feet of nonliving material (3 feet by 2 feet by 2 feet).\n\nWhile the chest remains on the Ethereal Plane, you can take a Magic action and touch the replica to recall the chest. It appears in an unoccupied space on the ground within 5 feet of you. You can send the chest back to the Ethereal Plane by taking a Magic action to touch the chest and the replica.\n\nAfter 60 days, there is a cumulative 5 percent chance at the end of each day that the spell ends. The spell also ends if you cast this spell again or if the Tiny replica chest is destroyed. If the spell ends and the larger chest is on the Ethereal Plane, the chest remains there for you or someone else to find.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "secret-chest", "it"),
					Language = LanguageCode.It,
					Name = "Scrigno Segreto",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Finché non viene dissolto",
					MaterialComponent = "uno scrigno di 90 × 60 × 60 centimetri, costruito con materiali rari del valore di almeno 5.000 mo, e una replica Minuscola dello scrigno fatta degli stessi materiali, del valore di almeno 50 mo",
					Description = "L'incantatore nasconde uno scrigno e tutto il suo contenuto nel Piano Etereo. Deve toccare lo scrigno e la replica in miniatura che fungono da componenti materiali dell'incantesimo. Lo scrigno può contenere fino a 324 decimetri cubi di materiale non vivente (90 × 60 × 60 centimetri).\n\nFinché lo scrigno rimane nel Piano Etereo, l'incantatore può effettuare un'azione di Magia e toccare la replica per richiamare lo scrigno, che compare in uno spazio libero sul terreno entro 1,5 metri da lui. L'incantatore può rimandare lo scrigno nel Piano Etereo effettuando un'azione di Magia per toccare lo scrigno e la replica.\n\nDopo 60 giorni, alla fine di ogni giorno c'è una probabilità cumulativa del 5 per cento che l'incantesimo termini. L'incantesimo termina anche se l'incantatore lo lancia di nuovo o se la replica Minuscola dello scrigno viene distrutta. Se l'incantesimo termina mentre lo scrigno più grande si trova nel Piano Etereo, lo scrigno resta lì, in attesa che l'incantatore o qualcun altro lo trovi.",
					HigherLevels = null
				}
			}
		};
	}
}
