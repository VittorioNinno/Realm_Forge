using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Private Sanctum (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PrivateSanctum2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "private-sanctum");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "private-sanctum", "en"),
					Language = LanguageCode.En,
					Name = "Private Sanctum",
					CastingTime = "10 minutes",
					Range = "120 feet",
					Duration = "24 hours",
					MaterialComponent = "a thin sheet of lead, a piece of opaque glass, a wad of cotton or cloth, and powdered chrysolite",
					Description = "You make an area within range magically secure. The area is a cube that can be as small as 5 feet to as large as 100 feet on each side. The spell lasts for the duration or until you use an action to dismiss it.\n\nWhen you cast the spell, you decide what sort of security the spell provides, choosing any or all of the following properties:\n\n- Sound can't pass through the barrier at the edge of the warded area.\n\n- The barrier of the warded area appears dark and foggy, preventing vision (including darkvision) through it.\n\n- Sensors created by divination spells can't appear inside the protected area or pass through the barrier at its perimeter.\n\n- Creatures in the area can't be targeted by divination spells.\n\n- Nothing can teleport into or out of the warded area.\n\n- Planar travel is blocked within the warded area.\n\nCasting this spell on the same spot every day for a year makes this effect permanent.",
					HigherLevels = "When you cast this spell using a spell slot of 5th level or higher, you can increase the size of the cube by 100 feet for each slot level beyond 4th. Thus you could protect a cube that can be up to 200 feet on one side by using a spell slot of 5th level."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "private-sanctum", "it"),
					Language = LanguageCode.It,
					Name = "Santuario Privato",
					CastingTime = "10 minuti",
					Range = "36 metri",
					Duration = "24 ore",
					MaterialComponent = "una sottile lamina di piombo, un pezzo di vetro opaco, un batuffolo di cotone o di stoffa e polvere di crisolito",
					Description = "L'incantatore rende magicamente sicura un'area entro gittata. L'area è un cubo il cui spigolo può variare da un minimo di 1,5 metri a un massimo di 30 metri. L'incantesimo dura per la durata o finché l'incantatore non usa un'azione per congedarlo.\n\nQuando lancia l'incantesimo, l'incantatore decide il tipo di sicurezza fornito dall'incantesimo, scegliendo una qualsiasi delle proprietà seguenti o tutte:\n\n- Il suono non può attraversare la barriera al confine dell'area protetta.\n\n- La barriera dell'area protetta appare scura e nebbiosa, e impedisce la vista (compresa la scurovisione) attraverso di essa.\n\n- I sensori creati dagli incantesimi di divinazione non possono comparire all'interno dell'area protetta né attraversare la barriera lungo il suo perimetro.\n\n- Le creature nell'area non possono essere bersagliate dagli incantesimi di divinazione.\n\n- Nulla può teletrasportarsi dentro o fuori dall'area protetta.\n\n- I viaggi planari sono bloccati all'interno dell'area protetta.\n\nLanciare questo incantesimo nello stesso punto ogni giorno per un anno rende questo effetto permanente.",
					HigherLevels = "Quando l'incantatore lancia questo incantesimo usando uno slot incantesimo di 5° livello o superiore, può aumentare lo spigolo del cubo di 30 metri per ogni livello dello slot superiore al 4°. Usando uno slot incantesimo di 5° livello, quindi, potrebbe proteggere un cubo con spigolo fino a 60 metri."
				}
			}
		};
	}
}
