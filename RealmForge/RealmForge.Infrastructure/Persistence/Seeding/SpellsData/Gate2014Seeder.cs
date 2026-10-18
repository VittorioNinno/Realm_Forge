using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Gate (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Gate2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gate");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 9,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gate", "en"),
					Language = LanguageCode.En,
					Name = "Gate",
					CastingTime = "1 action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a diamond worth at least 5,000 gp",
					Description = "You conjure a portal linking an unoccupied space you can see within range to a precise location on a different plane of existence. The portal is a circular opening, which you can make 5 to 20 feet in diameter. You can orient the portal in any direction you choose. The portal lasts for the duration.\n\nThe portal has a front and a back on each plane where it appears. Travel through the portal is possible only by moving through its front. Anything that does so is instantly transported to the other plane, appearing in the unoccupied space nearest to the portal.\n\nDeities and other planar rulers can prevent portals created by this spell from opening in their presence or anywhere within their domains.\n\nWhen you cast this spell, you can speak the name of a specific creature (a pseudonym, title, or nickname doesn't work). If that creature is on a plane other than the one you are on, the portal opens in the named creature's immediate vicinity and draws the creature through it to the nearest unoccupied space on your side of the portal. You gain no special power over the creature, and it is free to act as the GM deems appropriate. It might leave, attack you, or help you.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gate", "it"),
					Language = LanguageCode.It,
					Name = "Portale",
					CastingTime = "1 azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un diamante del valore di almeno 5.000 mo",
					Description = "L'incantatore evoca un portale che collega uno spazio libero entro gittata, che egli sia in grado di vedere, a un luogo preciso di un piano di esistenza diverso. Il portale è un'apertura circolare il cui diametro può variare da 1,5 a 6 metri, a scelta dell'incantatore, che può orientarlo nella direzione che preferisce. Il portale dura per la durata.\n\nSu ogni piano in cui compare, il portale ha un lato anteriore e uno posteriore. È possibile viaggiare attraverso il portale soltanto passando dal lato anteriore. Tutto ciò che lo fa viene trasportato istantaneamente nell'altro piano e compare nello spazio libero più vicino al portale.\n\nLe divinità e gli altri signori planari possono impedire ai portali creati da questo incantesimo di aprirsi in loro presenza o in qualsiasi punto dei loro domini.\n\nQuando lancia questo incantesimo, l'incantatore può pronunciare il nome di una creatura specifica (uno pseudonimo, un titolo o un soprannome non funzionano). Se quella creatura si trova su un piano diverso da quello in cui si trova l'incantatore, il portale si apre nelle immediate vicinanze della creatura nominata e la attira attraverso di sé, fino allo spazio libero più vicino dal lato del portale in cui si trova l'incantatore. L'incantatore non ottiene alcun potere particolare sulla creatura, che è libera di agire come il DM ritiene opportuno: potrebbe andarsene, attaccarlo o aiutarlo.",
					HigherLevels = null
				}
			}
		};
	}
}
