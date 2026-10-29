using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Dryad (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class Dryad2014Seeder
{
	public static Monster Build() => Create("dryad", null, CreatureSize.Medium, CreatureType.Fey,
		11, 22, "5d8", 30, new[] { 10, 12, 11, 14, 15, 18 }, 1m, 200, 2, 14,
		new Text(
			"Driade",
			null,
			"Folletto Medio, neutrale",
			"11 (16 con pelle coriacea)",
			"9 m",
			"",
			"Furtività +5, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14, scurovisione 18 m",
			"Elfico, Silvano",
			"***Incantesimi innati.*** La caratteristica innata da incantatore della driade è Carisma (CD del tiro salvezza sull'incantesimo 14). Per sua natura, la driade è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *artificio druidico*\n- 3/giorno ciascuno: *bacche benefiche, intralciare*\n- 1/giorno ciascuno: *passare senza tracce, pelle coriacea, randello incantato*\n\n***Parlare con bestie e vegetali.*** La driade può comunicare con le bestie e i vegetali come se condividesse con loro un linguaggio.\n\n***Passo arboreo.*** Per una volta nel suo turno, la driade può usare 3 metri del suo movimento per entrare magicamente in un albero vivente entro la sua portata e uscire da un secondo albero vivente situato entro 18 metri dal primo, comparendo in uno spazio libero entro 1,5 metri dal secondo. Entrambi gli alberi devono essere di taglia Grande o superiore.\n\n***Resistenza alla magia.*** La driade dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.",
			"***Randello.*** *Attacco con arma da mischia:* +2 al tiro per colpire (+6 con *randello incantato),* portata 1,5 m, un bersaglio. *Colpito:* 2 (1d4) danni contundenti o 8 (1d8 + 4) danni contundenti con *randello incantato.*\n\n***Fascino fatato.*** La driade prende di mira un umanoide o una bestia nel suo campo visivo in un raggio di 9 metri. Se il bersaglio può vedere la driade, deve superare un tiro salvezza su Saggezza con CD 14, altrimenti è affascinato magicamente. La creatura affascinata considera la driade un'alleata fidata da ascoltare e da proteggere. Anche se il bersaglio non è sotto il controllo della driade, interpreta le sue richieste o le sue azioni nel modo più favorevole possibile. Ogni volta che la driade o i suoi alleati fanno qualcosa di dannoso al bersaglio, quest'ultimo può ripetere il tiro salvezza e, se lo supera, l'effetto svanisce. Altrimenti, l'effetto dura 24 ore o finché la driade non muore, non si trova su un piano di esistenza diverso da quello del bersaglio o non termina l'effetto con un'azione bonus. Se il bersaglio supera il tiro salvezza, è immune al Fascino fatato della driade per le 24 ore successive. La driade può affascinare al massimo un umanoide e tre bestie contemporaneamente.",
			"",
			""),
		new Text(
			"Dryad",
			null,
			"Medium fey, neutral",
			"11 (16 with barkskin)",
			"30 ft.",
			"",
			"Perception +4, Stealth +5",
			"",
			"",
			"",
			"",
			"darkvision 60 ft., passive Perception 14",
			"Elvish, Sylvan",
			"***Innate Spellcasting.*** The dryad's innate spellcasting ability is Charisma (spell save DC 14). The dryad can innately cast the following spells, requiring no material components:\n\n\n- At will: *druidcraft*\n- 3/day each: *entangle, goodberry*\n- 1/day each: *barkskin, pass without trace, shillelagh*\n\n***Magic Resistance.*** The dryad has advantage on saving throws against spells and other magical effects.\n\n***Speak with Beasts and Plants.*** The dryad can communicate with beasts and plants as if they shared a language.\n\n***Tree Stride.*** Once on her turn, the dryad can use 10 ft. of her movement to step magically into one living tree within her reach and emerge from a second living tree within 60 ft. of the first tree, appearing in an unoccupied space within 5 ft. of the second tree. Both trees must be large or bigger.",
			"***Club.*** *Melee Weapon Attack:* +2 to hit (+6 to hit with shillelagh), reach 5 ft., one target. *Hit:* 2 (1d4) bludgeoning damage, or 8 (1d8 + 4) bludgeoning damage with shillelagh.\n\n***Fey Charm.*** The dryad targets one humanoid or beast that she can see within 30 feet of her. If the target can see the dryad, it must succeed on a DC 14 Wisdom saving throw or be magically charmed. The charmed creature regards the dryad as a trusted friend to be heeded and protected. Although the target isn't under the dryad's control, it takes the dryad's requests or actions in the most favorable way it can.\n\nEach time the dryad or its allies do anything harmful to the target, it can repeat the saving throw, ending the effect on itself on a success. Otherwise, the effect lasts 24 hours or until the dryad dies, is on a different plane of existence from the target, or ends the effect as a bonus action. If a target's saving throw is successful, the target is immune to the dryad's Fey Charm for the next 24 hours.\nThe dryad can have no more than one humanoid and up to three beasts charmed at a time.",
			"",
			""));
}
