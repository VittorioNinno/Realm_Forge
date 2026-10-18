using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Guards and Wards (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GuardsAndWards2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "guards-and-wards");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "guards-and-wards", "en"),
					Language = LanguageCode.En,
					Name = "Guards and Wards",
					CastingTime = "1 hour",
					Range = "Touch",
					Duration = "24 hours",
					MaterialComponent = "a silver rod worth 10+ GP",
					Description = "You create a ward that protects up to 2,500 square feet of floor space. The warded area can be up to 20 feet tall, and you shape it as one 50-foot square, one hundred 5-foot squares that are contiguous, or twenty-five 10-foot squares that are contiguous.\n\nWhen you cast this spell, you can specify individuals that are unaffected by the spell's effects. You can also specify a password that, when spoken aloud within 5 feet of the warded area, makes the speaker immune to its effects. The spell creates the effects below within the warded area. *Dispel Magic* has no effect on *Guards and Wards* itself, but each of the following effects can be dispelled. If all four are dispelled, *Guards and Wards* ends. If you cast the spell every day for 365 days on the same area, the spell thereafter lasts until all its effects are dispelled.\n\n**Corridors.** Fog fills all the warded corridors, making them Heavily Obscured. In addition, at each intersection or branching passage offering a choice of direction, there is a 50 percent chance that a creature other than you believes it is going in the opposite direction from the one it chooses.\n\n**Doors.** All doors in the warded area are magically locked, as if sealed by the *Arcane Lock* spell. In addition, you can cover up to ten doors with an illusion to make them appear as plain sections of wall.\n\n**Stairs.** Webs fill all stairs in the warded area from top to bottom, as in the *Web* spell. These strands regrow in 10 minutes if they are destroyed while *Guards and Wards* lasts.\n\n**Other Spell Effect.** Place one of the following magical effects within the warded area:\n\n- *Dancing Lights* in four corridors, with a simple program that the lights repeat as long as *Guards and Wards* lasts\n\n- *Magic Mouth* in two locations\n\n- *Stinking Cloud* in two locations (the vapors return within 10 minutes if dispersed while *Guards and Wards* lasts)\n\n- *Gust of Wind* in one corridor or room (the wind blows continuously while the spell lasts)\n\n- *Suggestion* in one 5-foot square; any creature that enters that square receives the suggestion mentally",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "guards-and-wards", "it"),
					Language = LanguageCode.It,
					Name = "Vigilanza e Interdizione",
					CastingTime = "1 ora",
					Range = "Contatto",
					Duration = "24 ore",
					MaterialComponent = "una verga d'argento del valore di almeno 10 mo",
					Description = "L'incantatore crea una protezione che protegge fino a 225 metri quadrati di superficie del pavimento. L'area protetta può essere alta fino a 6 metri e l'incantatore le dà la forma di un quadrato di 15 metri di lato, di cento quadrati contigui di 1,5 metri di lato o di venticinque quadrati contigui di 3 metri di lato.\n\nQuando lancia questo incantesimo, l'incantatore può indicare degli individui che non sono influenzati dagli effetti dell'incantesimo. Può anche stabilire una parola d'ordine che, se pronunciata ad alta voce entro 1,5 metri dall'area protetta, rende chi la pronuncia immune ai suoi effetti. L'incantesimo crea gli effetti seguenti all'interno dell'area protetta. *Dissolvi magie* non ha alcun effetto su *vigilanza e interdizione* in sé, ma ognuno degli effetti seguenti può essere dissolto. Se tutti e quattro vengono dissolti, *vigilanza e interdizione* termina. Se l'incantatore lancia l'incantesimo ogni giorno per 365 giorni sulla stessa area, da quel momento l'incantesimo dura finché tutti i suoi effetti non vengono dissolti.\n\n**Corridoi.** La nebbia riempie tutti i corridoi protetti, rendendoli pesantemente oscurati. Inoltre, a ogni incrocio o diramazione che offre una scelta di direzione, c'è una probabilità del 50 per cento che una creatura diversa dall'incantatore creda di procedere nella direzione opposta a quella che sceglie.\n\n**Porte.** Tutte le porte nell'area protetta sono bloccate magicamente, come se fossero sigillate dall'incantesimo *serratura arcana*. Inoltre, l'incantatore può coprire fino a dieci porte con un'illusione per farle sembrare semplici sezioni di muro.\n\n**Scale.** Le ragnatele riempiono tutte le scale nell'area protetta dall'alto in basso, come per l'incantesimo *ragnatela*. Questi filamenti ricrescono in 10 minuti se vengono distrutti finché *vigilanza e interdizione* è attivo.\n\n**Altro Effetto Magico.** L'incantatore colloca uno degli effetti magici seguenti all'interno dell'area protetta:\n\n- *Luci danzanti* in quattro corridoi, con un semplice programma che le luci ripetono finché *vigilanza e interdizione* è attivo\n\n- *Bocca magica* in due punti\n\n- *Nube maleodorante* in due punti (i vapori ritornano entro 10 minuti se vengono dispersi finché *vigilanza e interdizione* è attivo)\n\n- *Folata di vento* in un corridoio o in una stanza (il vento soffia ininterrottamente finché l'incantesimo è attivo)\n\n- *Suggestione* in un quadrato di 1,5 metri di lato; qualsiasi creatura che entra in quel quadrato riceve mentalmente la suggestione",
					HigherLevels = null
				}
			}
		};
	}
}
