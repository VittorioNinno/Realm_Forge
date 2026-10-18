using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Gate (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Gate2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 9,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gate", "en"),
					Language = LanguageCode.En,
					Name = "Gate",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a diamond worth 5,000+ GP",
					Description = "You conjure a portal linking an unoccupied space you can see within range to a precise location on a different plane of existence. The portal is a circular opening, which you can make 5 to 20 feet in diameter. You can orient the portal in any direction you choose. The portal lasts for the duration, and the portal's destination is visible through it.\n\nThe portal has a front and a back on each plane where it appears. Travel through the portal is possible only by moving through its front. Anything that does so is instantly transported to the other plane, appearing in the unoccupied space nearest to the portal.\n\nDeities and other planar rulers can prevent portals created by this spell from opening in their presence or anywhere within their domains.\n\nWhen you cast this spell, you can speak the name of a specific creature (a pseudonym, title, or nickname doesn't work). If that creature is on a plane other than the one you are on, the portal opens next to the named creature and transports it to the nearest unoccupied space on your side of the portal. You gain no special power over the creature, and it is free to act as the GM deems appropriate. It might leave, attack you, or help you.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gate", "it"),
					Language = LanguageCode.It,
					Name = "Portale",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un diamante del valore di almeno 5.000 mo",
					Description = "L'incantatore evoca un portale che collega uno spazio libero entro gittata che è in grado di vedere a un luogo preciso su un diverso piano di esistenza. Il portale è un'apertura circolare, il cui diametro può variare da 1,5 a 6 metri, a scelta dell'incantatore. L'incantatore può orientare il portale nella direzione che preferisce. Il portale permane per la durata e la sua destinazione è visibile attraverso di esso.\n\nIl portale ha un lato anteriore e un lato posteriore su ogni piano in cui compare. È possibile viaggiare attraverso il portale soltanto passando dal lato anteriore. Qualsiasi cosa lo faccia viene trasportata istantaneamente sull'altro piano e compare nello spazio libero più vicino al portale.\n\nLe divinità e gli altri sovrani planari possono impedire ai portali creati da questo incantesimo di aprirsi in loro presenza o in qualsiasi punto dei loro domini.\n\nQuando lancia questo incantesimo, l'incantatore può pronunciare il nome di una creatura specifica (uno pseudonimo, un titolo o un soprannome non funzionano). Se quella creatura si trova su un piano diverso da quello in cui si trova l'incantatore, il portale si apre accanto alla creatura nominata e la trasporta nello spazio libero più vicino dal lato del portale in cui si trova l'incantatore. L'incantatore non ottiene alcun potere speciale sulla creatura, che è libera di agire come il DM ritiene opportuno. Potrebbe andarsene, attaccare l'incantatore o aiutarlo.",
					HigherLevels = null
				}
			}
		};
	}
}
