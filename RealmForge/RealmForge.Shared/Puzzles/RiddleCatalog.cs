namespace RealmForge.Shared.Puzzles;

///	<summary>
///	A riddle for the table: the text the players read, the answers accepted ("|" separates them) and three hints, each
///	given to whoever passes a check of a skill against its DC. Place: where it fits (a door, a statue, a well…).
///	</summary>
public sealed record Riddle(string Id, string PlaceIt, string PlaceEn, string TextIt, string TextEn, string AnswerIt, string AnswerEn,
	IReadOnlyList<RiddleHint> Hints);

public sealed record RiddleHint(string Skill, int Dc, string It, string En);

///	<summary>
///	Environmental riddles written for RealmForge (Italian and English): carved on doors, sung by statues, scratched on
///	the edge of a well. The hints grow clearer as the DC rises.
///	</summary>
public static class RiddleCatalog
{
	public static readonly IReadOnlyList<Riddle> All =
	[
		new("shadow", "Porta della cripta", "Crypt door",
			"Ti seguo al sole e ti precedo al tramonto; a mezzogiorno mi nascondo sotto i tuoi piedi. Pronuncia il mio nome e la pietra si aprirà.",
			"I follow you in the morning and lead you at dusk; at noon I hide beneath your feet. Speak my name and the stone will open.",
			"ombra", "shadow",
			[new("Percezione", 10, "Le torce del corridoio proiettano forme scure sulla porta.", "The corridor's torches cast dark shapes on the door."),
			 new("Indagare", 13, "Un solco nel pavimento segue il cammino del sole lungo la giornata.", "A groove in the floor follows the sun's path through the day."),
			 new("Arcano", 16, "Le rune parlano di ciò che la luce crea ma non tocca.", "The runes speak of what light makes but never touches.")]),
		new("echo", "Grotta delle voci", "Cave of voices",
			"Non ho bocca ma rispondo, non ho orecchie ma ripeto ogni parola. Chi sono?",
			"I have no mouth yet I answer, no ears yet I repeat every word. What am I?",
			"eco", "echo",
			[new("Percezione", 10, "La vostra voce torna indietro un istante dopo.", "Your voice comes back a moment later."),
			 new("Natura", 13, "Le pareti lisce della grotta rimandano ogni suono.", "The smooth cave walls send every sound back."),
			 new("Storia", 16, "Una ninfa, secondo le leggende, fu condannata a ripetere le parole altrui.", "Legends tell of a nymph doomed to repeat the words of others.")]),
		new("map", "Tavolo del cartografo", "Cartographer's table",
			"Ho città senza case, foreste senza alberi e fiumi senza acqua. Cosa sono?",
			"I have cities without houses, forests without trees and rivers without water. What am I?",
			"mappa|carta", "map",
			[new("Indagare", 10, "Sul tavolo restano compassi e inchiostro.", "Compasses and ink are left on the table."),
			 new("Sopravvivenza", 13, "Chi viaggia lontano mi porta sempre con sé.", "Whoever travels far always carries me."),
			 new("Storia", 16, "I re mi fanno disegnare per conoscere i propri confini.", "Kings have me drawn to know their borders.")]),
		new("time", "Meridiana spezzata", "Broken sundial",
			"Divoro il ferro, consumo le montagne, abbatto i re; nessuno mi vede passare. Cosa sono?",
			"I devour iron, wear down mountains, bring kings low; no one sees me pass. What am I?",
			"tempo", "time",
			[new("Percezione", 10, "La meridiana è coperta di muschio e ruggine.", "The sundial is covered in moss and rust."),
			 new("Indagare", 13, "Le lancette di pietra sono state spezzate di proposito.", "The stone hands were broken on purpose."),
			 new("Religione", 16, "Un'iscrizione invoca il dio delle stagioni e degli anni.", "An inscription calls on the god of seasons and years.")]),
		new("candle", "Altare spento", "Dark altar",
			"Più a lungo vivo, più divento corta; muoio quando mi soffi addosso. Accendimi e la via si mostrerà.",
			"The longer I live, the shorter I grow; I die when you breathe on me. Light me and the way will show.",
			"candela", "candle",
			[new("Percezione", 10, "Colature di cera indurita coprono l'altare.", "Drips of hardened wax cover the altar."),
			 new("Religione", 13, "I fedeli lasciavano qui una piccola luce per i defunti.", "The faithful left a small light here for the dead."),
			 new("Indagare", 16, "Uno stoppino annerito spunta da una crepa.", "A blackened wick pokes out of a crack.")]),
		new("key", "Forziere del guardiano", "Warden's chest",
			"Ho denti ma non mordo; entro dove nessuno passa e lascio passare chi mi porta. Cosa sono?",
			"I have teeth but never bite; I go where no one passes and let through whoever carries me. What am I?",
			"chiave", "key",
			[new("Indagare", 10, "Il forziere ha una serratura senza alcuna chiave in vista.", "The chest has a lock and no key in sight."),
			 new("Rapidità di mano", 13, "La serratura ha sette denti di diversa altezza.", "The lock has seven teeth of different heights."),
			 new("Intuizione", 16, "Il guardiano tocca nervosamente la cintura quando lo guardate.", "The warden nervously touches his belt when you look at him.")]),
		new("silence", "Biblioteca sepolta", "Buried library",
			"Basta pronunciare il mio nome per spezzarmi. Cosa sono?",
			"Just saying my name breaks me. What am I?",
			"silenzio", "silence",
			[new("Percezione", 10, "Nella sala non si sente alcun rumore, nemmeno i vostri passi.", "No sound can be heard in the hall, not even your steps."),
			 new("Arcano", 13, "Un incantesimo antico smorza ogni suono tra questi scaffali.", "An old spell muffles every sound among these shelves."),
			 new("Storia", 16, "I bibliotecari facevano voto di non parlare mai.", "The librarians vowed never to speak.")]),
		new("river", "Ponte del traghettatore", "Ferryman's bridge",
			"Corro senza gambe, ho un letto ma non dormo, ho una bocca ma non parlo. Cosa sono?",
			"I run without legs, I have a bed but never sleep, a mouth but never speak. What am I?",
			"fiume", "river",
			[new("Natura", 10, "Sotto il ponte l'acqua scorre veloce.", "Under the bridge the water runs fast."),
			 new("Sopravvivenza", 13, "Il letto di sassi si vede dove la corrente è bassa.", "The stony bed shows where the current is low."),
			 new("Storia", 16, "Il traghettatore dice che il suo padrone sfocia nel mare.", "The ferryman says his master flows into the sea.")]),
		new("egg", "Nido della viverna", "Wyvern's nest",
			"Uno scrigno senza cardini né chiave né coperchio, eppure dentro custodisce un tesoro d'oro. Cosa sono?",
			"A box without hinges, key or lid, yet a golden treasure is hidden inside. What am I?",
			"uovo", "egg",
			[new("Natura", 10, "Il nido è caldo, come se qualcosa vi riposasse.", "The nest is warm, as if something rests in it."),
			 new("Percezione", 13, "Gusci rotti e sottili sono sparsi tra i rami.", "Thin broken shells are scattered among the branches."),
			 new("Addestrare animali", 16, "La madre torna sempre a covare al tramonto.", "The mother always comes back to brood at dusk.")]),
		new("darkness", "Pozzo senza fondo", "Bottomless well",
			"Più ce n'è, meno vedi. Cosa sono?",
			"The more of me there is, the less you see. What am I?",
			"buio|oscurita", "darkness|dark",
			[new("Percezione", 10, "La luce delle torce si perde a pochi metri.", "Torchlight fades a few feet down."),
			 new("Arcano", 13, "Un velo magico inghiotte ogni bagliore nel pozzo.", "A magical veil swallows every glow in the well."),
			 new("Sopravvivenza", 16, "Le creature di qui non hanno occhi.", "The creatures down here have no eyes.")]),
		new("footsteps", "Corridoio delle impronte", "Corridor of footprints",
			"Più ne fai, più ne lasci indietro. Cosa sono?",
			"The more you take, the more you leave behind. What are they?",
			"passi|impronte", "footsteps|steps|footprints",
			[new("Percezione", 10, "La polvere del pavimento conserva tracce recenti.", "The floor's dust keeps recent tracks."),
			 new("Sopravvivenza", 13, "Le tracce si allungano a ogni metro che percorrete.", "The tracks grow longer with every yard you walk."),
			 new("Indagare", 16, "Le piastrelle cedono solo dove si appoggia il piede.", "The tiles give way only where a foot rests.")]),
		new("name", "Statua senza volto", "Faceless statue",
			"È tuo, eppure gli altri lo usano più di te. Cosa?",
			"It is yours, yet others use it more than you do. What is it?",
			"nome|il tuo nome", "name|your name",
			[new("Percezione", 10, "Sul piedistallo è stata scalpellata via una targa.", "A plaque has been chiselled off the pedestal."),
			 new("Persuasione", 13, "Il guardiano vi chiede come vi chiamate, insistendo.", "The guard keeps asking what you are called."),
			 new("Storia", 16, "Gli antichi credevano che conoscere un nome desse potere su chi lo porta.", "The ancients believed knowing a name gave power over its bearer.")])
	];

	public static Riddle? Find(string? id) => All.FirstOrDefault(r => r.Id == id);
}
