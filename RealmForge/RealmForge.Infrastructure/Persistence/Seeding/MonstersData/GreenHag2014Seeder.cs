using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Green Hag (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class GreenHag2014Seeder
{
	public static Monster Build() => Create("green-hag", null, CreatureSize.Medium, CreatureType.Fey,
		17, 82, "11d8 + 33", 30, new[] { 18, 12, 16, 13, 14, 14 }, 3m, 700, 2, 14,
		new Text(
			"Megera verde",
			null,
			"Folletto Medio, neutrale malvagio",
			"17 (armatura naturale)",
			"9 m",
			"",
			"Arcano +3, Furtività +3, Inganno +4, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 18 m",
			"Comune, Draconico, Silvano",
			"***Anfibio.*** La megera può respirare in aria e in acqua.\n\n***Imitare.*** La megera può imitare i versi degli animali e le voci degli umanoidi. Una creatura che oda tali suoni riesce a capire che si tratta di imitazioni superando una prova di Saggezza (Intuizione) con CD 14.\n\n***Incantesimi innati.*** La caratteristica innata da incantatore della megera è Carisma (CD del tiro salvezza sull'incantesimo 12). Per sua natura, è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *beffa crudele, illusione minore, luci danzanti*",
			"***Artigli.*** *Attacco con arma da mischia:* +6 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 13 (2d8 + 4) danni taglienti.\n\n***Aspetto illusorio.*** La megera avvolge se stessa e tutto ciò che indossa o trasporta in un'illusione magica che la fa apparire come un'altra creatura di taglia e di forma umanoide simile alla sua. L'illusione termina se la megera usa un'azione bonus per terminarla o se muore. I cambiamenti apportati da questo effetto non passano il vaglio di un'ispezione fisica. Per esempio, la megera potrebbe apparire dotata di una pelle liscia, ma chiunque la toccasse sentirebbe che la sua pelle è ruvida. Sotto ogni altro aspetto, una creatura deve effettuare un'azione per ispezionare l'illusione e superare una prova di Intelligenza (Indagare) con CD 20 per capire che la megera è camuffata.\n\n***Passaggio invisibile.*** La megera diventa invisibile magicamente finché non attacca o lancia un incantesimo, o finché non perde la concentrazione (come se si concentrasse su un incantesimo). Mentre è invisibile, non lascia alcuna traccia fisica del suo passaggio, quindi è possibile seguirla solo tramite la magia. Ogni oggetto che indossa o trasporta diventa invisibile insieme a lei.",
			"",
			""),
		new Text(
			"Green Hag",
			null,
			"Medium fey, neutral evil",
			"17 (natural armor)",
			"30 ft.",
			"",
			"Arcana +3, Deception +4, Perception +4, Stealth +3",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 14",
			"Common, Draconic, Sylvan",
			"***Amphibious.*** The hag can breathe air and water.\n\n***Innate Spellcasting.*** The hag's innate spellcasting ability is Charisma (spell save DC 12). She can innately cast the following spells, requiring no material components:\n\n\n- At will: *dancing lights, minor illusion, vicious mockery*\n\n***Mimicry.*** The hag can mimic animal sounds and humanoid voices. A creature that hears the sounds can tell they are imitations with a successful DC 14 Wisdom (Insight) check.",
			"***Claws.*** *Melee Weapon Attack:* +6 to hit, reach 5 ft., one target. *Hit:* 13 (2d8 + 4) slashing damage.\n\n***Illusory Appearance.*** The hag covers herself and anything she is wearing or carrying with a magical illusion that makes her look like another creature of her general size and humanoid shape. The illusion ends if the hag takes a bonus action to end it or if she dies.\n\nThe changes wrought by this effect fail to hold up to physical inspection. For example, the hag could appear to have smooth skin, but someone touching her would feel her rough flesh. Otherwise, a creature must take an action to visually inspect the illusion and succeed on a DC 20 Intelligence (Investigation) check to discern that the hag is disguised.\n\n***Invisible Passage.*** The hag magically turns invisible until she attacks or casts a spell, or until her concentration ends (as if concentrating on a spell). While invisible, she leaves no physical evidence of her passage, so she can be tracked only by magic. Any equipment she wears or carries is invisible with her.",
			"",
			""));
}
