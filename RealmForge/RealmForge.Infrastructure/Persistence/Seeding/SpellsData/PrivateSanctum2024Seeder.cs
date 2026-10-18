using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Private Sanctum (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PrivateSanctum2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "private-sanctum");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Abjuration,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "private-sanctum", "en"),
					Language = LanguageCode.En,
					Name = "Private Sanctum",
					CastingTime = "10 minutes",
					Range = "120 feet",
					Duration = "24 hours",
					MaterialComponent = "a thin sheet of lead",
					Description = "You make an area within range magically secure. The area is a Cube that can be as small as 5 feet to as large as 100 feet on each side. The spell lasts for the duration.\n\nWhen you cast the spell, you decide what sort of security the spell provides, choosing any of the following properties:\n\n- Sound can't pass through the barrier at the edge of the warded area.\n\n- The barrier of the warded area appears dark and foggy, preventing vision (including Darkvision) through it.\n\n- Sensors created by Divination spells can't appear inside the protected area or pass through the barrier at its perimeter.\n\n- Creatures in the area can't be targeted by Divination spells.\n\n- Nothing can teleport into or out of the warded area.\n\n- Planar travel is blocked within the warded area.\n\nCasting this spell on the same spot every day for 365 days makes the spell last until dispelled.",
					HigherLevels = "You can increase the size of the Cube by 100 feet for each spell slot level above 4."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "private-sanctum", "it"),
					Language = LanguageCode.It,
					Name = "Santuario Privato",
					CastingTime = "10 minuti",
					Range = "36 metri",
					Duration = "24 ore",
					MaterialComponent = "una sottile lamina di piombo",
					Description = "L'incantatore rende un'area entro gittata magicamente sicura. L'area è un cubo il cui spigolo può variare da un minimo di 1,5 metri a un massimo di 30 metri. L'incantesimo permane per la durata.\n\nQuando lancia l'incantesimo, l'incantatore decide quale tipo di sicurezza fornisce l'incantesimo, scegliendo una qualsiasi delle proprietà seguenti:\n\n- Il suono non può attraversare la barriera al confine dell'area protetta.\n\n- La barriera dell'area protetta appare scura e nebbiosa, impedendo la visione (inclusa la scurovisione) attraverso di essa.\n\n- I sensori creati dagli incantesimi di divinazione non possono comparire all'interno dell'area protetta né attraversare la barriera lungo il suo perimetro.\n\n- Le creature nell'area non possono essere prese come bersaglio dagli incantesimi di divinazione.\n\n- Nulla può teletrasportarsi dentro o fuori dall'area protetta.\n\n- I viaggi planari sono bloccati all'interno dell'area protetta.\n\nLanciare questo incantesimo nello stesso punto ogni giorno per 365 giorni fa sì che l'incantesimo duri finché non viene dissolto.",
					HigherLevels = "L'incantatore può aumentare lo spigolo del cubo di 30 metri per ogni livello dello slot incantesimo superiore al 4°."
				}
			}
		};
	}
}
