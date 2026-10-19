using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Oath of Devotion (paladin, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class OathOfDevotion2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-devotion");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Paladin2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-devotion", "en"), Language = LanguageCode.En, Name = "Oath of Devotion", Description = "The Oath of Devotion binds Paladins to the ideals of justice and order. These Paladins meet the archetype of the knight in shining armor. They hold themselves to the highest standards of conduct, and some—for better or worse—hold the rest of the world to the same standards.\n\nMany who swear this oath are devoted to gods of law and good and use their gods’ tenets as the measure of personal devotion. Others hold angels as their ideals and incorporate images of angelic wings into their helmets or coats of arms.\n\nThese paladins share the following tenets:\n\n- Let your word be your promise.\n- Protect the weak and never fear to act.\n- Let your honorable deeds be an example." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "oath-of-devotion", "it"), Language = LanguageCode.It, Name = "Giuramento di Devozione", Description = "Il Giuramento di Devozione vincola i paladini agli ideali di giustizia e di ordine. Questi paladini incarnano l'archetipo del cavaliere dall'armatura scintillante: si attengono ai più alti principi di condotta e alcuni, nel bene e nel male, pretendono lo stesso dal resto del mondo. Molti di coloro che pronunciano questo giuramento sono devoti a divinità della legge e del bene; altri prendono gli angeli come modello e ne riproducono le ali sugli elmi o sugli stemmi.\n\nQuesti paladini condividono i seguenti principi:\n\n- Che la tua parola sia una promessa.\n- Proteggi i deboli e non temere mai di agire.\n- Che le tue azioni onorevoli siano d'esempio." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/oath-of-devotion-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/oath-of-devotion-spells", "en"), Language = LanguageCode.En, Name = "Oath of Devotion Spells", Description = "The magic of your oath ensures you always have certain spells ready; when you reach a Paladin level specified in the table below, you thereafter always have the listed spells prepared.\n\n| Paladin Level | Spells |\n|---|---|\n| 3 | *Protection from Evil and Good*, *Shield of Faith* |\n| 5 | *Aid*, *Zone of Truth* |\n| 9 | *Beacon of Hope*, *Dispel Magic* |\n| 13 | *Freedom of Movement*, *Guardian of Faith* |\n| 17 | *Commune*, *Flame Strike* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/oath-of-devotion-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Giuramento di Devozione", Description = "La magia del giuramento garantisce al paladino di avere sempre pronti determinati incantesimi: quando raggiunge un livello da paladino indicato nella tabella seguente, da quel momento ha sempre preparati gli incantesimi elencati.\n\n| Livello da paladino | Incantesimi |\n|---|---|\n| 3 | *protezione dal bene e dal male*, *scudo della fede* |\n| 5 | *aiuto*, *zona di verità* |\n| 9 | *dissolvi magie*, *faro di speranza* |\n| 13 | *guardiano della fede*, *libertà di movimento* |\n| 17 | *colpo infuocato*, *comunione* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/sacred-weapon"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/sacred-weapon", "en"), Language = LanguageCode.En, Name = "Sacred Weapon", Description = "When you take the Attack action, you can expend one use of your Channel Divinity to imbue one Melee weapon that you are holding with positive energy. For 10 minutes or until you use this feature again, you add your Charisma modifier to attack rolls you make with that weapon (minimum bonus of +1), and each time you hit with it, you cause it to deal its normal damage type or Radiant damage. The weapon also emits Bright Light in a 20-foot radius and Dim Light 20 feet beyond that.\n\nYou can end this effect early (no action required). This effect also ends if you aren’t carrying the weapon." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/sacred-weapon", "it"), Language = LanguageCode.It, Name = "Arma Consacrata", Description = "Quando effettua l'azione di Attacco, il paladino può spendere un utilizzo di Incanalare Divinità per infondere energia positiva in un'arma da mischia che impugna. Per 10 minuti o finché non usa di nuovo questo privilegio, somma il suo modificatore di Carisma ai tiri per colpire effettuati con quell'arma (bonus minimo +1) e, ogni volta che colpisce con essa, può farle infliggere il suo tipo di danni normale o danni radiosi. L'arma emette inoltre luce intensa in un raggio di 6 metri e luce fioca per altri 6 metri.\n\nIl paladino può porre fine all'effetto in anticipo (nessuna azione richiesta). L'effetto termina anche se il paladino non porta più con sé l'arma." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/aura-of-devotion"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 7,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/aura-of-devotion", "en"), Language = LanguageCode.En, Name = "Aura of Devotion", Description = "You and your allies have Immunity to the Charmed condition while in your Aura of Protection. If a Charmed ally enters the aura, that condition has no effect on that ally while there." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/aura-of-devotion", "it"), Language = LanguageCode.It, Name = "Aura di Devozione", Description = "Il paladino e i suoi alleati sono immuni alla condizione di affascinato finché si trovano nella sua Aura di protezione. Se un alleato affascinato entra nell'aura, la condizione non ha effetto su di lui finché vi rimane." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/smite-of-protection"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 15,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/smite-of-protection", "en"), Language = LanguageCode.En, Name = "Smite of Protection", Description = "Your magical smite now radiates protective energy. Whenever you cast Divine Smite, you and your allies have Half Cover while in your Aura of Protection. The aura has this benefit until the start of your next turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/smite-of-protection", "it"), Language = LanguageCode.It, Name = "Punizione Protettiva", Description = "La punizione magica del paladino ora irradia energia protettiva. Ogni volta che lancia *punizione divina*, il paladino e i suoi alleati beneficiano di mezza copertura finché si trovano nella sua Aura di protezione; l'aura mantiene questo beneficio fino all'inizio del turno successivo del paladino." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/holy-nimbus"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 20,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/holy-nimbus", "en"), Language = LanguageCode.En, Name = "Holy Nimbus", Description = "As a Bonus Action, you can imbue your Aura of Protection with holy power, granting the benefits below for 10 minutes or until you end them (no action required). Once you use this feature, you can’t use it again until you finish a Long Rest. You can also restore your use of it by expending a level 5 spell slot (no action required).\n\n**Holy Ward.** You have Advantage on any saving throw you are forced to make by a Fiend or an Undead.\n\n**Radiant Damage.** Whenever an enemy starts its turn in the aura, that creature takes Radiant damage equal to your Charisma modifier plus your Proficiency Bonus.\n\n**Sunlight.** The aura is filled with Bright Light that is sunlight." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "oath-of-devotion/holy-nimbus", "it"), Language = LanguageCode.It, Name = "Nube Sacra", Description = "Come azione bonus, il paladino può infondere la sua Aura di protezione di potere sacro, ottenendo i benefici seguenti per 10 minuti o finché non vi pone fine (nessuna azione richiesta). Dopo aver usato questo privilegio, non può farlo di nuovo finché non completa un riposo lungo, ma può ripristinarne l'utilizzo spendendo uno slot incantesimo di 5° livello (nessuna azione richiesta).\n\n**Interdizione sacra.** Il paladino dispone di vantaggio ai tiri salvezza che è costretto a effettuare a causa di un immondo o di un non morto.\n\n**Danni radiosi.** Ogni volta che un nemico inizia il proprio turno nell'aura, subisce danni radiosi pari al modificatore di Carisma del paladino + il suo bonus di competenza.\n\n**Luce del sole.** L'aura è colma di luce intensa che è luce solare." }
					}
				}
			}
		};
	}
}
