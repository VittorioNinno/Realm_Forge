using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Guards and Wards (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GuardsAndWards2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "guards-and-wards");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 6,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "guards-and-wards", "en"),
					Language = LanguageCode.En,
					Name = "Guards and Wards",
					CastingTime = "10 minutes",
					Range = "Touch",
					Duration = "24 hours",
					MaterialComponent = "burning incense, a small measure of brimstone and oil, a knotted string, a small amount of umber hulk blood, and a small silver rod worth at least 10 gp",
					Description = "You create a ward that protects up to 2,500 square feet of floor space (an area 50 feet square, or one hundred 5-foot squares or twenty-five 10-foot squares). The warded area can be up to 20 feet tall, and shaped as you desire. You can ward several stories of a stronghold by dividing the area among them, as long as you can walk into each contiguous area while you are casting the spell.\n\nWhen you cast this spell, you can specify individuals that are unaffected by any or all of the effects that you choose. You can also specify a password that, when spoken aloud, makes the speaker immune to these effects.\n\nGuards and wards creates the following effects within the warded area.\n\n***Corridors.*** Fog fills all the warded corridors, making them heavily obscured. In addition, at each intersection or branching passage offering a choice of direction, there is a 50 percent chance that a creature other than you will believe it is going in the opposite direction from the one it chooses.\n\n***Doors.*** All doors in the warded area are magically locked, as if sealed by an arcane lock spell. In addition, you can cover up to ten doors with an illusion (equivalent to the illusory object function of the minor illusion spell) to make them appear as plain sections of wall.\n\n***Stairs.*** Webs fill all stairs in the warded area from top to bottom, as the web spell. These strands regrow in 10 minutes if they are burned or torn away while guards and wards lasts.\n\n***Other Spell Effect.*** You can place your choice of one of the following magical effects within the warded area of the stronghold.\n\n- Place dancing lights in four corridors. You can designate a simple program that the lights repeat as long as guards and wards lasts.\n\n- Place magic mouth in two locations.\n\n- Place stinking cloud in two locations. The vapors appear in the places you designate; they return within 10 minutes if dispersed by wind while guards and wards lasts.\n\n- Place a constant gust of wind in one corridor or room.\n\n- Place a suggestion in one location. You select an area of up to 5 feet square, and any creature that enters or passes through the area receives the suggestion mentally.\n\nThe whole warded area radiates magic. A dispel magic cast on a specific effect, if successful, removes only that effect.\n\nYou can create a permanently guarded and warded structure by casting this spell there every day for one year.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "guards-and-wards", "it"),
					Language = LanguageCode.It,
					Name = "Vigilanza e Interdizione",
					CastingTime = "10 minuti",
					Range = "Contatto",
					Duration = "24 ore",
					MaterialComponent = "incenso acceso, una piccola quantità di zolfo e olio, una corda annodata, una piccola quantità di sangue di umber hulk e una piccola bacchetta d'argento del valore di almeno 10 mo",
					Description = "L'incantatore crea una protezione che copre fino a 225 metri quadrati di superficie del pavimento (un'area di 15 metri di lato, oppure cento quadrati di 1,5 metri di lato o venticinque quadrati di 3 metri di lato). L'area protetta può essere alta fino a 6 metri e avere la forma che l'incantatore desidera. L'incantatore può proteggere più piani di una roccaforte suddividendo l'area tra di essi, purché possa entrare in ogni area contigua mentre lancia l'incantesimo.\n\nQuando lancia questo incantesimo, l'incantatore può indicare degli individui che non sono influenzati da alcuni o da tutti gli effetti scelti. Può anche stabilire una parola d'ordine che, se pronunciata ad alta voce, rende chi la pronuncia immune a questi effetti.\n\nVigilanza e interdizione crea gli effetti seguenti all'interno dell'area protetta.\n\n***Corridoi.*** La nebbia riempie tutti i corridoi protetti, rendendoli pesantemente oscurati. Inoltre, a ogni incrocio o diramazione che offre una scelta di direzione, c'è una probabilità del 50 per cento che una creatura diversa dall'incantatore creda di procedere nella direzione opposta a quella che ha scelto.\n\n***Porte.*** Tutte le porte nell'area protetta sono chiuse magicamente, come se fossero sigillate da un incantesimo serratura arcana. Inoltre, l'incantatore può coprire fino a dieci porte con un'illusione (equivalente alla funzione di oggetto illusorio dell'incantesimo illusione minore) per farle sembrare semplici sezioni di muro.\n\n***Scale.*** Le ragnatele riempiono tutte le scale nell'area protetta dalla cima al fondo, come l'incantesimo ragnatela. Se vengono bruciati o strappati mentre vigilanza e interdizione è attivo, questi filamenti ricrescono in 10 minuti.\n\n***Altro Effetto Magico.*** L'incantatore può collocare a sua scelta uno degli effetti magici seguenti all'interno dell'area protetta della roccaforte.\n\n- Collocare luci danzanti in quattro corridoi. L'incantatore può stabilire un semplice programma che le luci ripetono finché vigilanza e interdizione è attivo.\n\n- Collocare bocca magica in due luoghi.\n\n- Collocare nube maleodorante in due luoghi. I vapori compaiono nei punti designati dall'incantatore; se vengono dispersi dal vento mentre vigilanza e interdizione è attivo, ricompaiono entro 10 minuti.\n\n- Collocare una folata di vento costante in un corridoio o in una stanza.\n\n- Collocare una suggestione in un luogo. L'incantatore sceglie un'area di massimo 1,5 metri di lato, e qualsiasi creatura che entra nell'area o la attraversa riceve mentalmente la suggestione.\n\nL'intera area protetta irradia magia. Un dissolvi magie lanciato su uno specifico effetto, se riesce, rimuove soltanto quell'effetto.\n\nL'incantatore può rendere una struttura permanentemente sorvegliata e protetta lanciandovi questo incantesimo ogni giorno per un anno.",
					HigherLevels = null
				}
			}
		};
	}
}
