using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Draconic Bloodline (sorcerer, 2014 ruleset). SRD text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DraconicBloodline2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "draconic-bloodline");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Sorcerer2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "draconic-bloodline", "en"), Language = LanguageCode.En, Name = "Draconic Bloodline", Description = "Your innate magic comes from draconic magic that was mingled with your blood or that of your ancestors. Most often, sorcerers with this origin trace their descent back to a mighty sorcerer of ancient times who made a bargain with a dragon or who might even have claimed a dragon parent. Some of these bloodlines are well established in the world, but most are obscure. Any given sorcerer could be the first of a new bloodline, as a result of a pact or some other exceptional circumstance." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "draconic-bloodline", "it"), Language = LanguageCode.It, Name = "Discendenza Draconica", Description = "La magia innata dello stregone deriva dalla magia draconica che si è mescolata al suo sangue o a quello dei suoi antenati. Il più delle volte gli stregoni con questa origine fanno risalire la propria discendenza a un potente stregone dei tempi antichi che strinse un patto con un drago, o che addirittura poteva vantare un genitore draconico. Alcune di queste stirpi sono ben note nel mondo, ma la maggior parte è oscura. Qualsiasi stregone potrebbe essere il capostipite di una nuova stirpe, in seguito a un patto o a qualche altra circostanza eccezionale." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/dragon-ancestor"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/dragon-ancestor", "en"), Language = LanguageCode.En, Name = "Dragon Ancestor", Description = "At 1st level, you choose one type of dragon as your ancestor. The damage type associated with each dragon is used by features you gain later.\n\n| Dragon | Damage Type |\n|---|---|\n| Black | Acid |\n| Blue | Lightning |\n| Brass | Fire |\n| Bronze | Lightning |\n| Copper | Acid |\n| Gold | Fire |\n| Green | Poison |\n| Red | Fire |\n| Silver | Cold |\n| White | Cold |\n\nYou can speak, read, and write Draconic. Additionally, whenever you make a Charisma check when interacting with dragons, your proficiency bonus is doubled if it applies to the check." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/dragon-ancestor", "it"), Language = LanguageCode.It, Name = "Antenato Draconico", Description = "Al 1° livello lo stregone sceglie un tipo di drago come proprio antenato. Il tipo di danno associato a ogni drago viene usato dai privilegi che ottiene in seguito.\n\n| Drago | Tipo di danno |\n|---|---|\n| Nero | Acido |\n| Blu | Fulmine |\n| Ottone | Fuoco |\n| Bronzo | Fulmine |\n| Rame | Acido |\n| Oro | Fuoco |\n| Verde | Veleno |\n| Rosso | Fuoco |\n| Argento | Freddo |\n| Bianco | Freddo |\n\nLo stregone sa parlare, leggere e scrivere il Draconico. Inoltre, ogni volta che effettua una prova di Carisma per interagire con i draghi, il suo bonus di competenza raddoppia, se si applica alla prova." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/draconic-resilience"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 1,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/draconic-resilience", "en"), Language = LanguageCode.En, Name = "Draconic Resilience", Description = "As magic flows through your body, it causes physical traits of your dragon ancestors to emerge. At 1st level, your hit point maximum increases by 1 and increases by 1 again whenever you gain a level in this class.\n\nAdditionally, parts of your skin are covered by a thin sheen of dragon-like scales. When you aren't wearing armor, your AC equals 13 + your Dexterity modifier." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/draconic-resilience", "it"), Language = LanguageCode.It, Name = "Resilienza Draconica", Description = "Mentre la magia scorre nel corpo dello stregone, fa emergere alcuni tratti fisici dei suoi antenati draconici. Al 1° livello il suo massimo dei punti ferita aumenta di 1, e aumenta di nuovo di 1 ogni volta che ottiene un livello in questa classe.\n\nInoltre, parti della sua pelle sono ricoperte da un sottile strato di scaglie simili a quelle di un drago. Quando non indossa un'armatura, la sua CA è pari a 13 + il suo modificatore di Destrezza." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/elemental-affinity"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/elemental-affinity", "en"), Language = LanguageCode.En, Name = "Elemental Affinity", Description = "Starting at 6th level, when you cast a spell that deals damage of the type associated with your draconic ancestry, you can add your Charisma modifier to one damage roll of that spell. At the same time, you can spend 1 sorcery point to gain resistance to that damage type for 1 hour." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/elemental-affinity", "it"), Language = LanguageCode.It, Name = "Affinità Elementale", Description = "A partire dal 6° livello, quando lancia un incantesimo che infligge danni del tipo associato alla sua ascendenza draconica, lo stregone può aggiungere il suo modificatore di Carisma a un tiro per i danni di quell'incantesimo. Allo stesso tempo, può spendere 1 punto stregoneria per ottenere resistenza a quel tipo di danno per 1 ora." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/dragon-wings"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/dragon-wings", "en"), Language = LanguageCode.En, Name = "Dragon Wings", Description = "At 14th level, you gain the ability to sprout a pair of dragon wings from your back, gaining a flying speed equal to your current speed. You can create these wings as a bonus action on your turn. They last until you dismiss them as a bonus action on your turn.\n\nYou can't manifest your wings while wearing armor unless the armor is made to accommodate them, and clothing not made to accommodate your wings might be destroyed when you manifest them." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/dragon-wings", "it"), Language = LanguageCode.It, Name = "Ali di Drago", Description = "Al 14° livello lo stregone ottiene la capacità di far spuntare dalla schiena un paio di ali di drago, ottenendo una velocità di volare pari alla sua velocità attuale. Può creare queste ali come azione bonus nel suo turno, e durano finché non le congeda come azione bonus nel suo turno.\n\nNon può far comparire le ali mentre indossa un'armatura, a meno che l'armatura non sia fatta per accoglierle, e gli abiti non adatti alle ali potrebbero essere distrutti quando le fa comparire." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/draconic-presence"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 18,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/draconic-presence", "en"), Language = LanguageCode.En, Name = "Draconic Presence", Description = "Beginning at 18th level, you can channel the dread presence of your dragon ancestor, causing those around you to become awestruck or frightened. As an action, you can spend 5 sorcery points to draw on this power and exude an aura of awe or fear (your choice) to a distance of 60 feet. For 1 minute or until you lose your concentration (as if you were casting a concentration spell), each hostile creature that starts its turn in this aura must succeed on a Wisdom saving throw or be charmed (if you chose awe) or frightened (if you chose fear) until the aura ends. A creature that succeeds on this saving throw is immune to your aura for 24 hours." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "draconic-bloodline/draconic-presence", "it"), Language = LanguageCode.It, Name = "Presenza Draconica", Description = "A partire dal 18° livello, lo stregone può incanalare la terribile presenza del suo antenato draconico, suscitando reverenza o paura in chi lo circonda. Come azione, può spendere 5 punti stregoneria per attingere a questo potere ed emanare un'aura di reverenza o di paura (a sua scelta) fino a una distanza di 18 metri. Per 1 minuto o finché lo stregone non perde la concentrazione (come se stesse lanciando un incantesimo a concentrazione), ogni creatura ostile che inizia il suo turno nell'aura deve superare un tiro salvezza su Saggezza, altrimenti diventa affascinata (se lo stregone ha scelto la reverenza) o spaventata (se ha scelto la paura) finché l'aura non termina. Una creatura che supera questo tiro salvezza è immune all'aura dello stregone per 24 ore." }
					}
				}
			}
		};
	}
}
