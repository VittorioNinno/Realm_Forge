using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Contact Other Plane (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ContactOtherPlane2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "contact-other-plane");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 5,
			School = SpellSchool.Divination,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = true,
			Concentration = false,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "contact-other-plane", "en"),
					Language = LanguageCode.En,
					Name = "Contact Other Plane",
					CastingTime = "1 minute",
					Range = "Self",
					Duration = "1 minute",
					MaterialComponent = null,
					Description = "You mentally contact a demigod, the spirit of a long-dead sage, or some other knowledgeable entity from another plane. Contacting this otherworldly intelligence can break your mind. When you cast this spell, make a DC 15 Intelligence saving throw. On a successful save, you can ask the entity up to five questions. You must ask your questions before the spell ends. The GM answers each question with one word, such as \"yes,\" \"no,\" \"maybe,\" \"never,\" \"irrelevant,\" or \"unclear\" (if the entity doesn't know the answer to the question). If a one-word answer would be misleading, the GM might instead offer a short phrase as an answer.\n\nOn a failed save, you take 6d6 Psychic damage and have the Incapacitated condition until you finish a Long Rest. A *Greater Restoration* spell cast on you ends this effect.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "contact-other-plane", "it"),
					Language = LanguageCode.It,
					Name = "Contattare Altri Piani",
					CastingTime = "1 minuto",
					Range = "Incantatore",
					Duration = "1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore contatta mentalmente un semidio, lo spirito di un saggio morto da tempo o qualche altra entità sapiente di un altro piano. Contattare questa intelligenza ultraterrena può spezzare la mente dell'incantatore. Quando lancia questo incantesimo, l'incantatore effettua un tiro salvezza su Intelligenza con CD 15. Se lo supera, può porre all'entità fino a cinque domande. Deve porre le sue domande prima che l'incantesimo termini. Il DM risponde a ogni domanda con una sola parola, come \"sì\", \"no\", \"forse\", \"mai\", \"irrilevante\" o \"incerto\" (se l'entità non conosce la risposta alla domanda). Se una risposta di una sola parola risultasse fuorviante, il DM potrebbe invece fornire come risposta una breve frase.\n\nSe fallisce il tiro salvezza, l'incantatore subisce 6d6 danni psichici ed è incapacitato finché non termina un riposo lungo. Un incantesimo *ristorare superiore* lanciato su di lui pone fine a questo effetto.",
					HigherLevels = null
				}
			}
		};
	}
}
