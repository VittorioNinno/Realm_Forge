using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Lizardfolk Shaman (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class LizardfolkShaman2014Seeder
{
	public static Monster Build() => Create("lizardfolk-shaman", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		13, 27, "5d8 + 5", 30, new[] { 15, 10, 13, 10, 15, 8 }, 2m, 450, 2, 14,
		new Text(
			"Lucertoloide sciamano",
			null,
			"Umanoide Medio (lucertoloide), neutrale",
			"13 (armatura naturale)",
			"9 m, nuotare 9 m",
			"",
			"Furtività +4, Percezione +4, Sopravvivenza +6",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"Draconico",
			"***Trattenere il respiro.*** Il lucertoloide può trattenere il respiro per 15 minuti.\n\n***Incantesimi (solo in forma di lucertoloide).*** Il lucertoloide lancia incantesimi come un incantatore di 5° livello, usando la Saggezza (CD del tiro salvezza sull'incantesimo 12, +4 al tiro per colpire con attacco con incantesimo). Ha preparati i seguenti incantesimi da druido:\n\n- Trucchetti (a volontà): *artificio druidico*, *produrre fiamma*, *frusta di spine*\n- 1° livello (4 slot): *intralciare*, *nube di nebbia*\n- 2° livello (3 slot): *riscaldare il metallo*, *crescita di spine*\n- 3° livello (2 slot): *evoca animali* (solo rettili), *crescita vegetale*",
			"***Multiattacco.*** In forma di lucertoloide, il lucertoloide effettua due attacchi: uno con il morso e uno con gli artigli.\n\n***Morso.*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni perforanti, o 7 (1d10 + 2) danni perforanti in forma di coccodrillo. In forma di coccodrillo, una creatura di taglia Grande o inferiore colpita è anche afferrata (CD 12 per sfuggire) e trattenuta finché dura la presa; nel frattempo il lucertoloide non può mordere nessun altro, e la presa termina se torna alla sua vera forma.\n\n***Artigli (solo in forma di lucertoloide).*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni taglienti.\n\n***Cambiare forma (ricarica dopo un riposo breve o lungo).*** Il lucertoloide si trasforma magicamente in un coccodrillo per un massimo di 1 ora, e può tornare alla sua vera forma come azione bonus. A parte la taglia le sue statistiche non cambiano, e ciò che indossa o trasporta non si trasforma. Quando muore torna alla sua vera forma.",
			"",
			"",
			"",
			""),
		new Text(
			"Lizardfolk Shaman",
			null,
			"Medium humanoid (lizardfolk), neutral",
			"13 (natural armor)",
			"30 ft., swim 30 ft.",
			"",
			"Perception +4, Stealth +4, Survival +6",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"Draconic",
			"***Hold Breath.*** The lizardfolk can hold its breath for 15 minutes.\n\n***Spellcasting (Lizardfolk Form Only).*** The lizardfolk casts spells as a 5th-level spellcaster, using Wisdom (spell save DC 12, +4 to hit with spell attacks). It has these druid spells prepared:\n\n- Cantrips (at will): *druidcraft*, *produce flame*, *thorn whip*\n- 1st level (4 slots): *entangle*, *fog cloud*\n- 2nd level (3 slots): *heat metal*, *spike growth*\n- 3rd level (2 slots): *conjure animals* (reptiles only), *plant growth*",
			"***Multiattack.*** In lizardfolk form, the lizardfolk makes two attacks: a bite and a claws attack.\n\n***Bite.*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) piercing damage, or 7 (1d10 + 2) piercing damage in crocodile form. In crocodile form, a Large or smaller creature hit is also grappled (escape DC 12) and restrained while the grapple lasts; the lizardfolk can't bite anyone else meanwhile, and the grapple ends if it returns to its true form.\n\n***Claws (Lizardfolk Form Only).*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) slashing damage.\n\n***Change Shape (Recharges after a Short or Long Rest).*** The lizardfolk magically turns into a crocodile for up to 1 hour, and can return to its true form as a bonus action. Apart from its size its statistics don't change, and what it wears or carries isn't transformed. It returns to its true form when it dies.",
			"",
			"",
			"",
			""));
}
