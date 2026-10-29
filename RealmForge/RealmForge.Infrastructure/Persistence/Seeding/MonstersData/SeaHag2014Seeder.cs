using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Sea Hag (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class SeaHag2014Seeder
{
	public static Monster Build() => Create("sea-hag", null, ContentSource.Srd51, CreatureSize.Medium, CreatureType.Fey,
		14, 52, "7d8 + 21", 30, new[] { 16, 13, 16, 12, 12, 13 }, 2m, 450, 2, 11,
		new Text(
			"Megera marina",
			null,
			"Folletto Medio, caotica malvagia",
			"14 (armatura naturale)",
			"9 m, nuotare 12 m",
			"",
			"",
			"",
			"",
			"",
			"",
			"Percezione passiva 11, scurovisione 18 m",
			"Aquan, Comune, Gigante",
			"***Anfibio.*** La megera può respirare in aria e in acqua.\n\n***Aspetto orripilante.*** Qualsiasi umanoide inizi il proprio turno nel campo visivo della megera, entro un raggio di 9 metri da lei, può vederne la vera forma e deve effettuare un tiro salvezza su Saggezza con CD 11; se lo fallisce, è spaventato per 1 minuto. Una creatura può ripetere il tiro salvezza alla fine di ogni suo turno, subendo svantaggio se la megera è situata nel suo campo visivo; se lo supera, l'effetto svanisce. Se una creatura supera il tiro salvezza o se l'effetto per lei termina, diventa immune all'Aspetto orripilante della megera per le 24 ore successive. A meno che il bersaglio non sia sorpreso o la rivelazione della vera forma della megera non sia improvvisa, il bersaglio può distogliere lo sguardo ed evitare di effettuare il tiro salvezza iniziale. Fino all'inizio del proprio turno successivo, una creatura che distoglie lo sguardo subisce svantaggio ai tiri per colpire contro la megera.",
			"***Artigli.*** *Attacco con arma da mischia:* +5 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 10 (2d6 + 3) danni taglienti.\n\n***Aspetto illusorio.*** La megera avvolge se stessa e tutto ciò che indossa o trasporta in un'illusione magica che la fa apparire come un creatura brutta, di taglia e di forma umanoide simile alla sua. L'illusione termina se la megera usa un'azione bonus per terminarla o se muore. I cambiamenti apportati da questo effetto non passano il vaglio di un'ispezione fisica. Per esempio, la megera potrebbe apparire priva di artigli, ma chiunque toccasse la sua mano sentirebbe che è artigliata. Sotto ogni altro aspetto, una creatura deve usare un'azione per ispezionare l'illusione e superare una prova di Intelligenza (Indagare) con CD 16 per capire che la megera è camuffata.\n\n***Sguardo mortale.*** La megera prende di mira una creatura spaventata visibile entro un raggio di 9 metri. Se il bersaglio può vedere la megera, deve superare un tiro salvezza su Saggezza con CD 11 contro questa magia, altrimenti scende a 0 punti ferita.",
			"",
			"",
			"",
			""),
		new Text(
			"Sea Hag",
			null,
			"Medium fey, chaotic evil",
			"14 (natural armor)",
			"30 ft., swim 40 ft.",
			"",
			"",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 11",
			"Aquan, Common, Giant",
			"***Amphibious.*** The hag can breathe air and water.\n\n***Horrific Appearance.*** Any humanoid that starts its turn within 30 feet of the hag and can see the hag's true form must make a DC 11 Wisdom saving throw. On a failed save, the creature is frightened for 1 minute. A creature can repeat the saving throw at the end of each of its turns, with disadvantage if the hag is within line of sight, ending the effect on itself on a success. If a creature's saving throw is successful or the effect ends for it, the creature is immune to the hag's Horrific Appearance for the next 24 hours.\n\nUnless the target is surprised or the revelation of the hag's true form is sudden, the target can avert its eyes and avoid making the initial saving throw. Until the start of its next turn, a creature that averts its eyes has disadvantage on attack rolls against the hag.",
			"***Claws.*** *Melee Weapon Attack:* +5 to hit, reach 5 ft., one target. *Hit:* 10 (2d6 + 3) slashing damage.\n\n***Death Glare.*** The hag targets one frightened creature she can see within 30 ft. of her. If the target can see the hag, it must succeed on a DC 11 Wisdom saving throw against this magic or drop to 0 hit points.\n\n***Illusory Appearance.*** The hag covers herself and anything she is wearing or carrying with a magical illusion that makes her look like an ugly creature of her general size and humanoid shape. The effect ends if the hag takes a bonus action to end it or if she dies.\n\nThe changes wrought by this effect fail to hold up to physical inspection. For example, the hag could appear to have no claws, but someone touching her hand might feel the claws. Otherwise, a creature must take an action to visually inspect the illusion and succeed on a DC 16 Intelligence (Investigation) check to discern that the hag is disguised.",
			"",
			"",
			"",
			""));
}
