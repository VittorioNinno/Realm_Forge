using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Animate Objects (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AnimateObjects2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animate-objects");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 5,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animate-objects", "en"),
					Language = LanguageCode.En,
					Name = "Animate Objects",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Objects come to life at your command. Choose up to ten nonmagical objects within range that are not being worn or carried. Medium targets count as two objects, Large targets count as four objects, Huge targets count as eight objects. You can't animate any object larger than Huge. Each target animates and becomes a creature under your control until the spell ends or until reduced to 0 hit points.\n\nAs a bonus action, you can mentally command any creature you made with this spell if the creature is within 500 feet of you (if you control multiple creatures, you can command any or all of them at the same time, issuing the same command to each one). You decide what action the creature will take and where it will move during its next turn, or you can issue a general command, such as to guard a particular chamber or corridor. If you issue no commands, the creature only defends itself against hostile creatures. Once given an order, the creature continues to follow it until its task is complete.\n\n##### Animated Object Statistics\n\n| Size | HP | AC | Attack | Str | Dex |\n|---|---|---|---|---|---|\n| Tiny | 20 | 18 | +8 to hit, 1d4 + 4 damage | 4 | 18 |\n| Small | 25 | 16 | +6 to hit, 1d8 + 2 damage | 6 | 14 |\n| Medium | 40 | 13 | +5 to hit, 2d6 + 1 damage | 10 | 12 |\n| Large | 50 | 10 | +6 to hit, 2d10 + 2 damage | 14 | 10 |\n| Huge | 80 | 10 | +8 to hit, 2d12 + 4 damage | 18 | 6 |\n\nAn animated object is a construct with AC, hit points, attacks, Strength, and Dexterity determined by its size. Its Constitution is 10 and its Intelligence and Wisdom are 3, and its Charisma is 1. Its speed is 30 feet; if the object lacks legs or other appendages it can use for locomotion, it instead has a flying speed of 30 feet and can hover. If the object is securely attached to a surface or a larger object, such as a chain bolted to a wall, its speed is 0. It has blindsight with a radius of 30 feet and is blind beyond that distance. When the animated object drops to 0 hit points, it reverts to its original object form, and any remaining damage carries over to its original object form.\n\nIf you command an object to attack, it can make a single melee attack against a creature within 5 feet of it. It makes a slam attack with an attack bonus and bludgeoning damage determined by its size. The GM might rule that a specific object inflicts slashing or piercing damage based on its form.",
					HigherLevels = "If you cast this spell using a spell slot of 6th level or higher, you can animate two additional objects for each slot level above 5th."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "animate-objects", "it"),
					Language = LanguageCode.It,
					Name = "Animare Oggetti",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Alcuni oggetti prendono vita al comando dell'incantatore. L'incantatore sceglie fino a dieci oggetti non magici entro gittata che non siano indossati o trasportati. Un bersaglio di taglia Media conta come due oggetti, uno di taglia Grande come quattro oggetti e uno di taglia Enorme come otto oggetti. Non è possibile animare alcun oggetto di taglia superiore a Enorme. Ogni bersaglio si anima e diventa una creatura sotto il controllo dell'incantatore finché l'incantesimo non termina o finché non scende a 0 punti ferita.\n\nCome azione bonus, l'incantatore può impartire mentalmente un comando a qualsiasi creatura creata con questo incantesimo, se la creatura si trova entro 150 metri da lui (se controlla più creature, può impartire un comando a una qualsiasi di esse o a tutte contemporaneamente, dando lo stesso ordine a ciascuna). L'incantatore decide quale azione compirà la creatura e dove si muoverà durante il suo turno successivo, oppure può impartire un comando generico, come sorvegliare una certa stanza o un certo corridoio. Se non impartisce alcun comando, la creatura si limita a difendersi dalle creature ostili. Una volta ricevuto un ordine, la creatura continua a eseguirlo finché il suo compito non è portato a termine.\n\n##### Statistiche degli oggetti animati\n\n| Taglia | PF | CA | Attacco | For | Des |\n|---|---|---|---|---|---|\n| Minuscola | 20 | 18 | +8 al tiro per colpire, 1d4 + 4 danni | 4 | 18 |\n| Piccola | 25 | 16 | +6 al tiro per colpire, 1d8 + 2 danni | 6 | 14 |\n| Media | 40 | 13 | +5 al tiro per colpire, 2d6 + 1 danni | 10 | 12 |\n| Grande | 50 | 10 | +6 al tiro per colpire, 2d10 + 2 danni | 14 | 10 |\n| Enorme | 80 | 10 | +8 al tiro per colpire, 2d12 + 4 danni | 18 | 6 |\n\nUn oggetto animato è un costrutto la cui CA, i cui punti ferita e attacchi e i cui punteggi di Forza e Destrezza dipendono dalla sua taglia. Ha Costituzione 10, Intelligenza e Saggezza 3 e Carisma 1. Ha velocità 9 metri; se l'oggetto è privo di gambe o di altre appendici con cui spostarsi, ha invece una velocità di volare di 9 metri e può fluttuare. Se l'oggetto è saldamente fissato a una superficie o a un oggetto più grande, come una catena imbullonata a un muro, la sua velocità è 0. Possiede vista cieca entro un raggio di 9 metri ed è cieco oltre tale distanza. Quando l'oggetto animato scende a 0 punti ferita, torna alla sua forma originale di oggetto e gli eventuali danni rimanenti si trasferiscono a tale forma.\n\nSe l'incantatore ordina a un oggetto di attaccare, l'oggetto può effettuare un singolo attacco in mischia contro una creatura entro 1,5 metri da esso. Effettua un attacco di schianto con un bonus di attacco e danni contundenti che dipendono dalla sua taglia. Il DM può stabilire che un determinato oggetto infligga danni taglienti o perforanti in base alla sua forma.",
					HigherLevels = "Se l'incantatore lancia questo incantesimo usando uno slot incantesimo di 6° livello o superiore, può animare due oggetti aggiuntivi per ogni livello dello slot superiore al 5°."
				}
			}
		};
	}
}
