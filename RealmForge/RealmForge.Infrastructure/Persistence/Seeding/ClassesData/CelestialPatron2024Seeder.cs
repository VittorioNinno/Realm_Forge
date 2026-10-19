using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Celestial Patron (warlock, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class CelestialPatron2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "celestial-patron");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Warlock2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "celestial-patron", "en"), Language = LanguageCode.En, Name = "Celestial Patron", Description = "Your pact draws on the Upper Planes, the realms of endless joy. You might have reached an agreement with an empyrean, a couatl, a sphinx, a unicorn or some other heavenly being, or you might work alongside many such beings toward goals you share. Through your pact you catch a glimpse of the holy radiance that lights the multiverse." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "celestial-patron", "it"), Language = LanguageCode.It, Name = "Patrono Celestiale", Description = "Il patto del warlock attinge ai Piani Superiori, i reami della gioia eterna. Potrebbe aver stretto un accordo con un empireo, un couatl, una sfinge, un unicorno o un'altra creatura celeste, oppure collaborare con molti esseri simili per raggiungere obiettivi comuni. Grazie al patto, intravede la luce sacra che illumina il multiverso." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/celestial-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/celestial-spells", "en"), Language = LanguageCode.En, Name = "Celestial Spells", Description = "From the Warlock level shown in the table below onward, the listed spells are always prepared for you.\n\n| Warlock Level | Spells |\n|---|---|\n| 3 | *Aid*, *Cure Wounds*, *Guiding Bolt*, *Lesser Restoration*, *Light*, *Sacred Flame* |\n| 5 | *Daylight*, *Revivify* |\n| 7 | *Guardian of Faith*, *Wall of Fire* |\n| 9 | *Greater Restoration*, *Summon Celestial* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/celestial-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi Celesti", Description = "Dal livello da warlock indicato nella tabella seguente, il warlock ha sempre preparati gli incantesimi elencati.\n\n| Livello da warlock | Incantesimi |\n|---|---|\n| 3 | *aiuto*, *cura ferite*, *dardo tracciante*, *fiamma sacra*, *luce*, *ristorare inferiore* |\n| 5 | *luce diurna*, *rinascita* |\n| 7 | *guardiano della fede*, *muro di fuoco* |\n| 9 | *richiama celestiale*, *ristorare superiore* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/healing-light"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/healing-light", "en"), Language = LanguageCode.En, Name = "Healing Light", Description = "You can channel celestial energy to mend wounds. You have a pool of d6s for this healing, holding a number of dice equal to 1 plus your Warlock level.\n\nAs a Bonus Action, you can heal yourself or a creature you can see within 60 feet of you by spending dice from the pool, up to a number at once equal to your Charisma modifier (at least one die). Roll the spent dice and restore Hit Points equal to the total. The pool refills completely when you finish a Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/healing-light", "it"), Language = LanguageCode.It, Name = "Luce Curatrice", Description = "Il warlock ottiene la capacità di incanalare energia celeste per curare le ferite. Dispone di una riserva di d6 per alimentare questa guarigione, il cui numero è pari a 1 + il suo livello da warlock.\n\nCome azione bonus, può curare se stesso o una creatura che è in grado di vedere entro 18 metri da lui spendendo dadi dalla riserva, fino a un massimo per volta pari al suo modificatore di Carisma (minimo un dado). Tira i dadi spesi e ripristina un numero di punti ferita pari al totale. La riserva recupera tutti i dadi spesi quando il warlock completa un riposo lungo." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/radiant-soul"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/radiant-soul", "en"), Language = LanguageCode.En, Name = "Radiant Soul", Description = "Holy power flows through you freely, and Radiant damage meets your Resistance. When one of your spells burns foes with Radiant or Fire damage, you can boost the damage it deals to a single target by your Charisma modifier, no more than once per turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/radiant-soul", "it"), Language = LanguageCode.It, Name = "Anima Radiosa", Description = "Il legame con il patrono fa del warlock un canale per l'energia radiosa: ha resistenza ai danni radiosi. Una volta per turno, quando un incantesimo che lancia infligge danni radiosi o da fuoco, può sommare il suo modificatore di Carisma ai danni di quell'incantesimo contro uno dei bersagli." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/celestial-resilience"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/celestial-resilience", "en"), Language = LanguageCode.En, Name = "Celestial Resilience", Description = "Each time you use Magical Cunning or finish a Short or Long Rest, you gain Temporary Hit Points equal to your Warlock level plus your Charisma modifier. At the same moment, up to five creatures you can see each gain Temporary Hit Points equal to half your Warlock level plus your Charisma modifier." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/celestial-resilience", "it"), Language = LanguageCode.It, Name = "Resilienza Celestiale", Description = "Il warlock ottiene punti ferita temporanei ogni volta che usa Scaltrezza magica o completa un riposo breve o lungo, in quantità pari al suo livello da warlock + il suo modificatore di Carisma. Inoltre, quando ottiene quei punti, sceglie fino a cinque creature che è in grado di vedere: ognuna ottiene punti ferita temporanei pari alla metà del suo livello da warlock + il suo modificatore di Carisma." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/searing-vengeance"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/searing-vengeance", "en"), Language = LanguageCode.En, Name = "Searing Vengeance", Description = "Just before you or an ally within 60 feet of you rolls a Death Saving Throw, you can unleash a burst of holy light instead. The dying creature is restored to half of its maximum Hit Points and may rise from Prone, while any creatures you pick within 30 feet of it suffer 2d8 plus your Charisma modifier in Radiant damage and are Blinded until this turn ends.\n\nYou can use this feature once per Long Rest." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "celestial-patron/searing-vengeance", "it"), Language = LanguageCode.It, Name = "Vendetta Incandescente", Description = "Quando il warlock o un alleato entro 18 metri da lui sta per effettuare un tiro salvezza contro la morte, il warlock può scatenare energia radiosa per salvarlo. La creatura recupera punti ferita pari alla metà del suo massimo dei punti ferita e può porre fine alla condizione di prono su di sé. Ogni creatura a scelta del warlock entro 9 metri da quella creatura subisce danni radiosi pari a 2d8 + il modificatore di Carisma del warlock ed è accecata fino alla fine del turno in corso.\n\nDopo aver usato questo privilegio, il warlock non può farlo di nuovo finché non completa un riposo lungo." }
					}
				}
			}
		};
	}
}
