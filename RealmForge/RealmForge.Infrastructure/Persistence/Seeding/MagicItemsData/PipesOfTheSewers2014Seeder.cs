using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Pipes of the Sewers (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class PipesOfTheSewers2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("pipes-of-the-sewers", null, 0, MagicItemType.WondrousItem, ItemRarity.Uncommon, true, ContentSource.Srd51,
			null,
			("Flauto dei topi", "Oggetto meraviglioso, non comune (richiede sintonia)",
			"Per usare questo flauto, il personaggio deve essere competente negli strumenti a fiato. Finché il personaggio è in sintonia con esso, i topi comuni e i topi giganti lo ignorano e non lo attaccano, a meno che il personaggio non li minacci o non li ferisca.\n\nIl flauto possiede 3 cariche. Se il personaggio usa un'azione per suonarlo, può usare un'azione bonus per consumare da 1 a 3 cariche e richiamare uno sciame di topi per ogni carica consumata, purché entro un raggio di 750 metri ci siano topi sufficienti (sarà il GM a determinarlo). Se non ci sono abbastanza topi per formare uno sciame, la carica viene sprecata. Gli sciami così chiamati si muovono verso la musica seguendo il percorso più breve disponibile, ma sotto ogni altro aspetto non sono sotto il controllo del personaggio. Il flauto recupera 1d3 cariche consumate all'all'alba di ogni giorno.\n\nOgni volta che uno sciame di topi che non è sotto il controllo di altre creature giunge entro 9 metri dal personaggio mentre suona il flauto, quest'ultimo può effettuare una prova di Carisma contrapposta alla prova di Saggezza dello sciame. Se perde, lo sciame si comporta normalmente e non può essere controllato dalla musica del flauto per le 24 ore successive. Se vince, lo sciame è controllato dalla musica del flauto e diventa amichevole nei confronti del personaggio e dei suoi compagni, finché il personaggio continua a usare un'azione a ogni round per suonare il flauto. Uno sciame amichevole obbedisce ai comandi del personaggio. Se il personaggio non impartisce alcun comando allo sciame amichevole, questo si difende, ma non effettua altre azioni. Se uno sciame amichevole inizia il suo turno mentre non può sentire la musica del flauto, il controllo che il personaggio esercita su di esso si interrompe, lo sciame torna a comportarsi secondo la sua natura e non può essere soggetto all'influsso della musica del flauto per le 24 ore successive.", null),
			("Pipes of the Sewers", "Wondrous item, uncommon (requires attunement)",
			"You must be proficient with wind instruments to use these pipes. While you are attuned to the pipes, ordinary rats and giant rats are indifferent toward you and will not attack you unless you threaten or harm them.\n\nThe pipes have 3 charges. If you play the pipes as an action, you can use a bonus action to expend 1 to 3 charges, calling forth one swarm of rats with each expended charge, provided that enough rats are within half a mile of you to be called in this fashion (as determined by the GM). If there aren't enough rats to form a swarm, the charge is wasted. Called swarms move toward the music by the shortest available route but aren't under your control otherwise. The pipes regain 1d3 expended charges daily at dawn.\n\nWhenever a swarm of rats that isn't under another creature's control comes within 30 feet of you while you are playing the pipes, you can make a Charisma check contested by the swarm's Wisdom check. If you lose the contest, the swarm behaves as it normally would and can't be swayed by the pipes' music for the next 24 hours. If you win the contest, the swarm is swayed by the pipes' music and becomes friendly to you and your companions for as long as you continue to play the pipes each round as an action. A friendly swarm obeys your commands. If you issue no commands to a friendly swarm, it defends itself but otherwise takes no actions. If a friendly swarm starts its turn and can't hear the pipes' music, your control over that swarm ends, and the swarm behaves as it normally would and can't be swayed by the pipes' music for the next 24 hours.", null));
	}
}
