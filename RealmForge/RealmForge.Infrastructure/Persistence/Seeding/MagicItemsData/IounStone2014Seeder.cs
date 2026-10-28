using RealmForge.Domain.Entities;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MagicItemSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MagicItemsData;

///	<summary>
///	Ioun Stone (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English and in the official Italian SRD 5.1 (CC BY 4.0).
///	</summary>
public static class IounStone2014Seeder
{
	public static IEnumerable<MagicItem> Build()
	{
		yield return Item("ioun-stone", null, 0, MagicItemType.WondrousItem, null, true, ContentSource.Srd51,
			null,
			("Pietra di Ioun", "Oggetto meraviglioso, rarità variabile (richiede sintonia)",
			"La *pietra di Ioun* deve il suo nome a Ioun, dea della conoscenza e della profezia venerata su alcuni mondi. Esistono molti tipi di queste pietre, ognuno dei quali ha una diversa combinazione di forma e colore.\n\nQuando il personaggio usa un'azione per lanciare in aria una pietra, l'oggetto inizia a orbitare intorno alla sua testa a una distanza di 1d3 × 30 cm, conferendogli determinati benefici. Da allora in poi, se un'altra creatura desidera sottrarre la pietra al personaggio, deve usare un'azione per afferrarla o intrappolarla, effettuando con successo un tiro per colpire contro CA 24 o una prova di Destrezza (Acrobazia) con CD 24. Il possessore può usare un'azione per afferrare e riporre la pietra, terminandone l'effetto.\n\nUna pietra possiede CA 24, 10 punti ferita e resistenza a tutti i danni. Quando orbita intorno alla testa del personaggio, è considerata un oggetto indossato.\n\n***Agilità (molto rara).*** Finché questa sfera color rosso scuro orbita intorno alla testa del personaggio, il suo punteggio di Destrezza aumenta di 2, fino a un\n\ndi 20.\n\n***Assorbimento (molto rara).*** Finché orbita intorno alla testa del personaggio, questo ellissoide color lavanda chiaro gli permette di usare la sua reazione per annullare un incantesimo di 4° livello o inferiore lanciato da una creatura che il personaggio è in grado di vedere e che ha solo lui come bersaglio.\n\nDopo aver annullato 20 livelli di incantesimi, la pietra prende fuoco, assume una tonalità grigia e opaca, e perde la sua magia. Se il personaggio è il bersaglio di un incantesimo il cui livello supera il numero di livelli di incantesimo rimasti nella pietra, tale incantesimo non può essere annullato.\n\n***Assorbimento superiore (leggendaria).*** Finché orbita intorno alla testa del personaggio, questo ellissoide verde e color lavanda gli permette di usare la sua reazione per annullare un incantesimo di 8° livello o inferiore lanciato da una creatura che il personaggio è in grado di vedere e che ha solo lui come bersaglio.\n\nDopo aver annullato 50 livelli di incantesimi, la pietra prende fuoco, assume una tonalità grigia e opaca, e perde la sua magia. Se il personaggio è il bersaglio di un incantesimo il cui livello supera il numero di livelli di incantesimo rimasti nella pietra, tale incantesimo non può essere annullato.\n\n***Autorità (molto rara).*** Finché questa sfera rosa e verde orbita intorno alla testa del personaggio, il suo punteggio di Carisma aumenta di 2, fino a un massimo di 20.\n\n***Consapevolezza (rara).*** Finché questo romboide blu scuro orbita intorno alla sua testa, il personaggio non può essere sorpreso.\n\n***Forza (molto rara).*** Finché questo romboide azzurro orbita intorno alla testa del personaggio, il suo punteggio di Forza aumenta di 2, fino a un massimo di 20.\n\n***Intelletto (molto rara).*** Finché questa sfera blu e scarlatta orbita intorno alla testa del personaggio, il suo punteggio di Intelligenza aumenta di 2, fino a un massimo di 20.\n\n***Intuizione (molto rara).*** Finché questa sfera blu incandescente orbita intorno alla testa del personaggio, il suo punteggio di Saggezza aumenta di 2, fino a un massimo di 20.\n\n***Maestria (leggendaria).*** Finché questo prisma verde chiaro orbita intorno alla testa del personaggio, il suo bonus di competenza aumenta di 1.\n\n***Protezione (rara).*** Finché questo prisma rosa antico orbita intorno alla testa del personaggio, quest'ultimo ottiene un bonus di +1 alla sua CA.massimo\n\n***Rigenerazione (leggendaria).*** Finché questo fuso color madreperla orbita intorno alla testa del personaggio, questo recupera 15 punti ferita alla fine di ogni ora, purché abbia almeno 1 punto ferita.\n\n***Riserva (rara).*** Questo prisma viola acceso accumula al suo interno gli incantesimi lanciati su di esso, conservandoli finché il personaggio non li usa. Può contenere fino a 3 livelli di incantesimo per volta. Quando viene trovata, contiene 1d4 – 1 livelli di incantesimi accumulati a scelta del GM.\n\nQualsiasi creatura può lanciare nella pietra un incantesimo di livello compreso tra il 1° e il 3° toccandola al momento del lancio dell'incantesimo. L'incantesimo non ha alcun effetto, a parte quello di essere immagazzinato nella pietra. Se la pietra non può contenere altri incantesimi, quello lanciato viene sprecato senza provocare alcun effetto. Il livello dello slot usato per lanciare l'incantesimo determina lo spazio che occupa nella pietra.\n\nFinché la pietra orbita intorno alla testa del personaggio, quest'ultimo può lanciare qualsiasi incantesimo conservato al suo interno. L'incantesimo usa il livello di slot, la CD del tiro salvezza sull'incantesimo, il bonus all'attacco con incantesimo e la caratteristica da incantatore di chi l'ha lanciato in origine, ma sotto ogni altro aspetto si considera che sia stato il personaggio a lanciarlo. L'incantesimo lanciato dalla pietra non è più conservato al suo interno, liberando il relativo spazio.\n\n***Sostentamento (rara).*** Finché questo fuso trasparente orbita intorno alla testa del personaggio, quest'ultimo non ha bisogno di mangiare o bere.\n\n***Tempra (molto rara).*** Finché questo romboide rosa orbita intorno alla testa del personaggio, il suo punteggio di Costituzione aumenta di 2, fino a un massimo di 20.", null),
			("Ioun Stone", "Wondrous item, varies (requires attunement)",
			"An Ioun stone is named after Ioun, a god of knowledge and prophecy revered on some worlds. Many types of Ioun stone exist, each type a distinct combination of shape and color.\n\nWhen you use an action to toss one of these stones into the air, the stone orbits your head at a distance of 1d3 feet and confers a benefit to you. Thereafter, another creature must use an action to grasp or net the stone to separate it from you, either by making a successful attack roll against AC 24 or a successful DC 24 Dexterity (Acrobatics) check. You can use an action to seize and stow the stone, ending its effect.\n\nA stone has AC 24, 10 hit points, and resistance to all damage. It is considered to be an object that is being worn while it orbits your head.\n\n***Absorption (Very Rare).*** While this pale lavender ellipsoid orbits your head, you can use your reaction to cancel a spell of 4th level or lower cast by a creature you can see and targeting only you.\n\nOnce the stone has canceled 20 levels of spells, it burns out and turns dull gray, losing its magic. If you are targeted by a spell whose level is higher than the number of spell levels the stone has left, the stone can't cancel it.\n\n***Agility (Very Rare).*** Your Dexterity score increases by 2, to a maximum of 20, while this deep red sphere orbits your head.\n\n***Awareness (Rare).*** You can't be surprised while this dark blue rhomboid orbits your head.\n\n***Fortitude (Very Rare).*** Your Constitution score increases by 2, to a maximum of 20, while this pink rhomboid orbits your head.\n\n***Greater Absorption (Legendary).*** While this marbled lavender and green ellipsoid orbits your head, you can use your reaction to cancel a spell of 8th level or lower cast by a creature you can see and targeting only you.\n\nOnce the stone has canceled 50 levels of spells, it burns out and turns dull gray, losing its magic. If you are targeted by a spell whose level is higher than the number of spell levels the stone has left, the stone can't cancel it.\n\n***Insight (Very Rare).*** Your Wisdom score increases by 2, to a maximum of 20, while this incandescent blue sphere orbits your head.\n\n***Intellect (Very Rare).*** Your Intelligence score increases by 2, to a maximum of 20, while this marbled scarlet and blue sphere orbits your head.\n\n***Leadership (Very Rare).*** Your Charisma score increases by 2, to a maximum of 20, while this marbled pink and green sphere orbits your head.\n\n***Mastery (Legendary).*** Your proficiency bonus increases by 1 while this pale green prism orbits your head.\n\n***Protection (Rare).*** You gain a +1 bonus to AC while this dusty rose prism orbits your head.\n\n***Regeneration (Legendary).*** You regain 15 hit points at the end of each hour this pearly white spindle orbits your head, provided that you have at least 1 hit point.\n\n***Reserve (Rare).*** This vibrant purple prism stores spells cast into it, holding them until you use them. The stone can store up to 3 levels worth of spells at a time. When found, it contains 1d4 - 1 levels of stored spells chosen by the GM.\n\nAny creature can cast a spell of 1st through 3rd level into the stone by touching it as the spell is cast. The spell has no effect, other than to be stored in the stone. If the stone can't hold the spell, the spell is expended without effect. The level of the slot used to cast the spell determines how much space it uses.\n\nWhile this stone orbits your head, you can cast any spell stored in it. The spell uses the slot level, spell save DC, spell attack bonus, and spellcasting ability of the original caster, but is otherwise treated as if you cast the spell. The spell cast from the stone is no longer stored in it, freeing up space.\n\n***Strength (Very Rare).*** Your Strength score increases by 2, to a maximum of 20, while this pale blue rhomboid orbits your head.\n\n***Sustenance (Rare).*** You don't need to eat or drink while this clear spindle orbits your head.", null));
		yield return Item("ioun-stone-of-absorption", "ioun-stone", 1, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			null,
			("Pietra di Ioun (assorbimento)", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"", null),
			("Ioun Stone of Absorption", "Wondrous item, very rare (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-agility", "ioun-stone", 2, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.AbilityScoreBonus, 2, AbilityScore.Dexterity)),
			("Pietra di Ioun (agilità)", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"", null),
			("Ioun Stone of Agility", "Wondrous item, very rare (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-awareness", "ioun-stone", 3, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Pietra di Ioun (consapevolezza)", "Oggetto meraviglioso, raro (richiede sintonia)",
			"", null),
			("Ioun Stone of Awareness", "Wondrous item, rare (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-fortitude", "ioun-stone", 4, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.AbilityScoreBonus, 2, AbilityScore.Constitution)),
			("Pietra di Ioun (tempra)", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"", null),
			("Ioun Stone of Fortitude", "Wondrous item, very rare (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-greater-absorption", "ioun-stone", 5, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			null,
			("Pietra di Ioun (assorbimento superiore)", "Oggetto meraviglioso, leggendario (richiede sintonia)",
			"", null),
			("Ioun Stone of Greater Absorption", "Wondrous item, legendary (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-insight", "ioun-stone", 6, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.AbilityScoreBonus, 2, AbilityScore.Wisdom)),
			("Pietra di Ioun (intuizione)", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"", null),
			("Ioun Stone of Insight", "Wondrous item, very rare (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-intellect", "ioun-stone", 7, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.AbilityScoreBonus, 2, AbilityScore.Intelligence)),
			("Pietra di Ioun (intelletto)", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"", null),
			("Ioun Stone of Intellect", "Wondrous item, very rare (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-leadership", "ioun-stone", 8, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.AbilityScoreBonus, 2, AbilityScore.Charisma)),
			("Pietra di Ioun (autorità)", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"", null),
			("Ioun Stone of Leadership", "Wondrous item, very rare (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-mastery", "ioun-stone", 9, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			null,
			("Pietra di Ioun (maestria)", "Oggetto meraviglioso, leggendario (richiede sintonia)",
			"", null),
			("Ioun Stone of Mastery", "Wondrous item, legendary (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-protection", "ioun-stone", 10, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			Magic(Effect(MagicEffectKind.ArmorClass, 1)),
			("Pietra di Ioun (protezione)", "Oggetto meraviglioso, raro (richiede sintonia)",
			"", null),
			("Ioun Stone of Protection", "Wondrous item, rare (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-regeneration", "ioun-stone", 11, MagicItemType.WondrousItem, ItemRarity.Legendary, true, ContentSource.Srd51,
			null,
			("Pietra di Ioun (rigenerazione)", "Oggetto meraviglioso, leggendario (richiede sintonia)",
			"", null),
			("Ioun Stone of Regeneration", "Wondrous item, legendary (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-reserve", "ioun-stone", 12, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Pietra di Ioun (riserva)", "Oggetto meraviglioso, raro (richiede sintonia)",
			"", null),
			("Ioun Stone of Reserve", "Wondrous item, rare (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-strength", "ioun-stone", 13, MagicItemType.WondrousItem, ItemRarity.VeryRare, true, ContentSource.Srd51,
			Magic(Ability(MagicEffectKind.AbilityScoreBonus, 2, AbilityScore.Strength)),
			("Pietra di Ioun (forza)", "Oggetto meraviglioso, molto raro (richiede sintonia)",
			"", null),
			("Ioun Stone of Strength", "Wondrous item, very rare (requires attunement)",
			"", null));
		yield return Item("ioun-stone-of-sustenance", "ioun-stone", 14, MagicItemType.WondrousItem, ItemRarity.Rare, true, ContentSource.Srd51,
			null,
			("Pietra di Ioun (sostentamento)", "Oggetto meraviglioso, raro (richiede sintonia)",
			"", null),
			("Ioun Stone of Sustenance", "Wondrous item, rare (requires attunement)",
			"", null));
	}
}
