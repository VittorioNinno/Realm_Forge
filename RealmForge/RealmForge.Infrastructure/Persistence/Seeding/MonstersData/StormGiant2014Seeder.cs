using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Storm Giant (2014 ruleset). SRD 5.1 statblock (CC BY 4.0): English text of the SRD, Italian text of the Italian SRD.
///	</summary>
public static class StormGiant2014Seeder
{
	public static Monster Build() => Create("storm-giant", null, CreatureSize.Huge, CreatureType.Giant,
		16, 230, "20d12 + 100", 50, new[] { 29, 14, 20, 16, 18, 18 }, 13m, 10000, 5, 19,
		new Text(
			"Gigante delle tempeste",
			null,
			"Gigante Enorme, caotico buono",
			"16 (corazza a scaglie)",
			"15 m, nuotare 15 m",
			"Car +9, Cos +10, For +14, Sag +9",
			"Arcano +8, Atletica +14, Percezione +9, Storia +8",
			"",
			"freddo",
			"fulmine, tuono",
			"",
			"Percezione passiva 19",
			"Comune, Gigante",
			"***Anfibio.*** Il gigante può respirare in aria e in acqua.\n\n***Incantesimi innati.*** La caratteristica innata da incantatore del gigante è Carisma (CD del tiro salvezza sull'incantesimo 17). Per sua natura, è in grado di lanciare gli incantesimi indicati di seguito senza aver bisogno di componenti materiali:\n\n- A volontà: *caduta morbida, individuazione del magico, levitazione, luce*\n- 3/giorno ciascuno: *controllare tempo atmosferico, respirare sott'acqua*",
			"***Multiattacco.*** Il gigante effettua due attacchi con lo spadone.\n\n***Spadone.*** *Attacco con arma da mischia:* +14 al tiro per colpire, portata 3 m, un bersaglio. *Colpito:* 30 (6d6 + 9) danni taglienti.\n\n***Roccia.*** *Attacco con arma a distanza:* +14 al tiro per colpire, gittata 18/72 m, un bersaglio. *Colpito:* 35 (4d12 + 9) danni contundenti.\n\n***Colpo di fulmine (ricarica 5–6).*** Il gigante scaglia un fulmine magico verso un punto che riesce a vedere entro 150 metri. Ogni creatura entro 3 metri da quel punto deve effettuare un tiro salvezza su Destrezza con CD 17, subendo 54 (12d8) danni da fulmine in caso di fallimento, o la metà dei danni in caso di successo.",
			"",
			""),
		new Text(
			"Storm Giant",
			null,
			"Huge giant, chaotic good",
			"16 (scale mail)",
			"50 ft., swim 50 ft.",
			"Str +14, Con +10, Wis +9, Cha +9",
			"Arcana +8, Athletics +14, History +8, Perception +9",
			"",
			"cold",
			"lightning, thunder",
			"",
			"passive Perception 19",
			"Common, Giant",
			"***Amphibious.*** The giant can breathe air and water.\n\n***Innate Spellcasting.*** The giant's innate spellcasting ability is Charisma (spell save DC 17). It can innately cast the following spells, requiring no material components:\n\n\n- At will: *detect magic, feather fall, levitate, light*\n- 3/day each: *control weather, water breathing*",
			"***Multiattack.*** The giant makes two greatsword attacks.\n\n***Greatsword.*** *Melee Weapon Attack:* +14 to hit, reach 10 ft., one target. *Hit:* 30 (6d6 + 9) slashing damage.\n\n***Rock.*** *Ranged Weapon Attack:* +14 to hit, range 60/240 ft., one target. *Hit:* 35 (4d12 + 9) bludgeoning damage.\n\n***Lightning Strike (Recharge 5–6).*** The giant hurls a magical lightning bolt at a point it can see within 500 feet of it. Each creature within 10 feet of that point must make a DC 17 Dexterity saving throw, taking 54 (12d8) lightning damage on a failed save, or half as much damage on a successful one.",
			"",
			""));
}
