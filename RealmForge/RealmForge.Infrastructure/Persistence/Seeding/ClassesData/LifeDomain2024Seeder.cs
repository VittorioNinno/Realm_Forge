using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Life Domain (cleric, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class LifeDomain2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "life-domain");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Cleric2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "life-domain", "en"), Language = LanguageCode.En, Name = "Life Domain", Description = "The Life Domain focuses on the positive energy that helps sustain all life in the multiverse. Clerics who tap into this domain are masters of healing, using that life force to cure many hurts. It is particularly associated with agricultural deities, gods of healing or endurance, and gods of home and community." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "life-domain", "it"), Language = LanguageCode.It, Name = "Dominio della Vita", Description = "Il Dominio della Vita si concentra sull'energia positiva che sostiene ogni forma di vita nel multiverso. I chierici che attingono a questo dominio sono maestri della guarigione e usano quella forza vitale per curare ogni genere di ferita. È legato in particolare alle divinità dell'agricoltura, agli dei della guarigione e della resistenza e a quelli del focolare e della comunità." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/disciple-of-life"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/disciple-of-life", "en"), Language = LanguageCode.En, Name = "Disciple of Life", Description = "When a spell you cast with a spell slot restores Hit Points to a creature, that creature regains additional Hit Points on the turn you cast the spell. The additional Hit Points equal 2 plus the spell slot’s level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/disciple-of-life", "it"), Language = LanguageCode.It, Name = "Discepolo della Vita", Description = "Quando un incantesimo lanciato dal chierico con uno slot incantesimo fa recuperare punti ferita a una creatura, quella creatura recupera punti ferita aggiuntivi nel turno in cui l'incantesimo viene lanciato, pari a 2 + il livello dello slot incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/life-domain-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/life-domain-spells", "en"), Language = LanguageCode.En, Name = "Life Domain Spells", Description = "Your connection to this divine domain ensures you always have certain spells ready. When you reach a Cleric level specified in the table below, you thereafter always have the listed spells prepared.\n\n| Cleric Level | Prepared Spells |\n|---|---|\n| 3 | *Aid*, *Bless*, *Cure Wounds*, *Lesser Restoration* |\n| 5 | *Mass Healing Word*, *Revivify* |\n| 7 | *Aura of Life*, *Death Ward* |\n| 9 | *Greater Restoration*, *Mass Cure Wounds* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/life-domain-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Dominio della Vita", Description = "Il legame con questo dominio divino garantisce al chierico di avere sempre pronti determinati incantesimi. Quando raggiunge un livello da chierico indicato nella tabella seguente, da quel momento ha sempre preparati gli incantesimi elencati.\n\n| Livello da chierico | Incantesimi preparati |\n|---|---|\n| 3 | *aiuto*, *benedizione*, *cura ferite*, *ristorare inferiore* |\n| 5 | *parola guaritrice di massa*, *rinascita* |\n| 7 | *aura di vita*, *interdizione alla morte* |\n| 9 | *cura ferite di massa*, *ristorare superiore* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/preserve-life"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/preserve-life", "en"), Language = LanguageCode.En, Name = "Preserve Life", Description = "As a Magic action, you present your Holy Symbol and expend a use of your Channel Divinity to evoke healing energy that can restore a number of Hit Points equal to five times your Cleric level. Choose Bloodied creatures within 30 feet of yourself (which can include you), and divide those Hit Points among them. This feature can restore a creature to no more than half its Hit Point maximum." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/preserve-life", "it"), Language = LanguageCode.It, Name = "Preservare Vita", Description = "Con un'azione di Magia, il chierico presenta il suo simbolo sacro e spende un utilizzo di Incanalare Divinità per evocare un'energia curativa in grado di ripristinare un numero di punti ferita pari a cinque volte il suo livello da chierico. Sceglie un qualsiasi numero di creature sanguinanti entro 9 metri da lui (incluso se stesso) e divide quei punti ferita tra di esse. Questo privilegio non può portare una creatura oltre la metà del suo massimo dei punti ferita." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/blessed-healer"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/blessed-healer", "en"), Language = LanguageCode.En, Name = "Blessed Healer", Description = "The healing spells you cast on others heal you as well. Immediately after you cast a spell with a spell slot that restores Hit Points to one or more creatures other than yourself, you regain Hit Points equal to 2 plus the spell slot’s level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/blessed-healer", "it"), Language = LanguageCode.It, Name = "Guaritore Benedetto", Description = "Gli incantesimi di guarigione che il chierico lancia sugli altri curano anche lui. Subito dopo aver lanciato con uno slot incantesimo un incantesimo che fa recuperare punti ferita a una o più creature diverse da lui, il chierico recupera un numero di punti ferita pari a 2 + il livello dello slot incantesimo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/supreme-healing"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 17,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/supreme-healing", "en"), Language = LanguageCode.En, Name = "Supreme Healing", Description = "When you would normally roll one or more dice to restore Hit Points to a creature with a spell or Channel Divinity, don’t roll those dice for the healing; instead use the highest number possible for each die. For example, instead of restoring 2d6 Hit Points to a creature with a spell, you restore 12." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "life-domain/supreme-healing", "it"), Language = LanguageCode.It, Name = "Guarigione Suprema", Description = "Quando dovrebbe tirare uno o più dadi per far recuperare punti ferita a una creatura con un incantesimo o con Incanalare Divinità, il chierico non tira quei dadi, ma usa per ciascuno il valore massimo possibile. Per esempio, anziché far recuperare 2d6 punti ferita a una creatura con un incantesimo, gliene fa recuperare 12." }
					}
				}
			}
		};
	}
}
