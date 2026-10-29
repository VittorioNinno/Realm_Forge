using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Pixie (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Pixie2014Seeder
{
	public static Monster Build() => Create("pixie", null, ContentSource.RealmForge, CreatureSize.Tiny, CreatureType.Fey,
		15, 1, "1d4 - 1", 10, new[] { 2, 20, 8, 10, 14, 15 }, 0.25m, 50, 2, 14,
		new Text(
			"Pixie",
			null,
			"Folletto Minuscolo, neutrale buono",
			"15",
			"3 m, volare 9 m",
			"",
			"Furtività +7, Percezione +4",
			"",
			"",
			"",
			"",
			"Percezione passiva 14",
			"Silvano",
			"***Resistenza alla magia.*** Il pixie dispone di vantaggio ai tiri salvezza contro incantesimi e altri effetti magici.\n\n***Incantesimi innati.*** Il pixie lancia per natura gli incantesimi seguenti usando il Carisma (CD del tiro salvezza sull'incantesimo 12), senza altra componente che la sua polvere di pixie:\n\n- A volontà: *artificio druidico*\n- 1/giorno ciascuno: *confusione*, *luci danzanti*, *individuazione del bene e del male*, *individuazione dei pensieri*, *dissolvi magie*, *intralciare*, *volare*, *allucinazione di forza*, *metamorfosi*, *sonno*",
			"***Invisibilità superiore.*** Il pixie diventa magicamente invisibile, insieme a ciò che indossa o trasporta, finché la sua concentrazione non termina (come se si concentrasse su un incantesimo).",
			"",
			"",
			"",
			""),
		new Text(
			"Pixie",
			null,
			"Tiny fey, neutral good",
			"15",
			"10 ft., fly 30 ft.",
			"",
			"Perception +4, Stealth +7",
			"",
			"",
			"",
			"",
			"passive Perception 14",
			"Sylvan",
			"***Magic Resistance.*** The pixie has advantage on saving throws against spells and other magical effects.\n\n***Innate Spellcasting.*** The pixie casts the following spells innately, using Charisma (spell save DC 12) and needing no component other than its pixie dust:\n\n- At will: *druidcraft*\n- 1/day each: *confusion*, *dancing lights*, *detect evil and good*, *detect thoughts*, *dispel magic*, *entangle*, *fly*, *phantasmal force*, *polymorph*, *sleep*",
			"***Superior Invisibility.*** The pixie magically becomes invisible, together with what it wears or carries, until its concentration ends (as if it were concentrating on a spell).",
			"",
			"",
			"",
			""));
}
