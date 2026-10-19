using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Circle of the Moon (druid, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class CircleOfTheMoon2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-moon");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Druid2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-moon", "en"), Language = LanguageCode.En, Name = "Circle of the Moon", Description = "Druids of the Circle of the Moon use lunar magic to change their own bodies. The circle meets beneath the moon to trade news and hold its rites. As changeable as the moon itself, one of these Druids might stalk the night as a great cat, glide above the forest as an eagle the following day, and then smash through the brush as a bear to chase off an intruding monster. The wild runs in their veins." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "circle-of-the-moon", "it"), Language = LanguageCode.It, Name = "Circolo della Luna", Description = "I druidi del Circolo della Luna sfruttano la magia lunare per mutare il proprio corpo. Il circolo si riunisce sotto la luna per scambiarsi notizie e celebrare i suoi riti. Mutevole come la luna stessa, uno di questi druidi può aggirarsi di notte nei panni di un grande felino, librarsi sopra la foresta come un'aquila il giorno dopo e poi aprirsi un varco nella boscaglia come un orso per scacciare un mostro intruso. La natura selvaggia gli scorre nelle vene." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/circle-forms"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/circle-forms", "en"), Language = LanguageCode.En, Name = "Circle Forms", Description = "When you take a Wild Shape form, you can draw on lunar magic and gain these benefits.\n\n**Challenge Rating.** The form's maximum Challenge Rating is your Druid level divided by 3, rounded down.\n\n**Armor Class.** While you keep the form, your AC becomes 13 plus your Wisdom modifier whenever that number beats the Beast's AC.\n\n**Temporary Hit Points.** You gain Temporary Hit Points equal to three times your Druid level." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/circle-forms", "it"), Language = LanguageCode.It, Name = "Forme del Circolo", Description = "Quando assume una forma di Forma Selvatica, il druido può incanalare la magia lunare e ottenere i benefici seguenti.\n\n**Grado di sfida.** Il grado di sfida massimo della forma è pari al livello da druido diviso per 3 (arrotondato per difetto).\n\n**Classe Armatura.** Finché resta nella forma, la CA del druido è pari a 13 + il suo modificatore di Saggezza, se questo valore supera la CA della bestia.\n\n**Punti ferita temporanei.** Il druido ottiene punti ferita temporanei pari a tre volte il suo livello da druido." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/circle-of-the-moon-spells"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/circle-of-the-moon-spells", "en"), Language = LanguageCode.En, Name = "Circle of the Moon Spells", Description = "From the Druid level shown in the table below onward, the listed spells are always prepared for you. You can also cast this feature's spells while you are in a Wild Shape form.\n\n| Druid Level | Prepared Spells |\n|---|---|\n| 3 | *Cure Wounds*, *Moonbeam*, *Starry Wisp* |\n| 5 | *Conjure Animals* |\n| 7 | *Fount of Moonlight* |\n| 9 | *Mass Cure Wounds* |" },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/circle-of-the-moon-spells", "it"), Language = LanguageCode.It, Name = "Incantesimi del Circolo della Luna", Description = "Dal livello da druido indicato nella tabella seguente, il druido ha sempre preparati gli incantesimi elencati. Può inoltre lanciare gli incantesimi di questo privilegio anche mentre si trova in una forma di Forma Selvatica.\n\n| Livello da druido | Incantesimi preparati |\n|---|---|\n| 3 | *bagliore lunare*, *cura ferite*, *luce splendente* |\n| 5 | *evoca animali* |\n| 7 | *fonte di luce lunare* |\n| 9 | *cura ferite di massa* |" }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/improved-circle-forms"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/improved-circle-forms", "en"), Language = LanguageCode.En, Name = "Improved Circle Forms", Description = "While in a Wild Shape form, you gain these benefits.\n\n**Lunar Radiance.** Each time you hit with one of the form's attacks, you decide whether it deals its usual damage type or Radiant damage.\n\n**Increased Toughness.** Your Wisdom modifier is added to your Constitution saving throws." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/improved-circle-forms", "it"), Language = LanguageCode.It, Name = "Forme del Circolo Migliorate", Description = "Mentre si trova in una forma di Forma Selvatica, il druido ottiene i benefici seguenti.\n\n**Radianza lunare.** Ogni volta che colpisce con un attacco della forma, il druido sceglie se infliggere il tipo di danni normale dell'attacco o danni radiosi.\n\n**Robustezza aumentata.** Il druido somma il suo modificatore di Saggezza ai propri tiri salvezza su Costituzione." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/moonlight-step"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/moonlight-step", "en"), Language = LanguageCode.En, Name = "Moonlight Step", Description = "You vanish and reappear in a flash of moonlight. As a Bonus Action, you teleport up to 30 feet to an unoccupied space you can see, and your next attack roll before the end of this turn has Advantage.\n\nYou can use this feature a number of times equal to your Wisdom modifier (at least once), regaining every use after a Long Rest. You can also restore one use for each level 2+ spell slot you spend for that purpose (no action required)." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/moonlight-step", "it"), Language = LanguageCode.It, Name = "Passo Chiardiluna", Description = "Il druido svanisce e ricompare in un lampo di luce lunare. Come azione bonus, si teletrasporta fino a 9 metri in uno spazio libero che è in grado di vedere e dispone di vantaggio al successivo tiro per colpire che effettua prima della fine del turno.\n\nIl druido può usare questo privilegio un numero di volte pari al suo modificatore di Saggezza (almeno una) e recupera tutti gli utilizzi dopo un riposo lungo. Può anche ripristinare un utilizzo per ogni slot incantesimo di 2° livello o superiore che spende a questo scopo (nessuna azione richiesta)." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/lunar-form"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 4,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/lunar-form", "en"), Language = LanguageCode.En, Name = "Lunar Form", Description = "The moon's power fills you, granting these benefits.\n\n**Improved Lunar Radiance.** Once per turn, when you hit a target with a Wild Shape form's attack, you can deal an extra 2d10 Radiant damage to it.\n\n**Shared Moonlight.** Each time you use Moonlight Step, you can bring along one willing creature within 10 feet of you, teleporting it to an unoccupied space you can see within 10 feet of where you arrive." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "circle-of-the-moon/lunar-form", "it"), Language = LanguageCode.It, Name = "Forma Lunare", Description = "Il potere della luna permea il druido, conferendogli i benefici seguenti.\n\n**Radianza lunare migliorata.** Una volta per turno, quando colpisce un bersaglio con un attacco di una forma di Forma Selvatica, il druido può infliggergli 2d10 danni radiosi extra.\n\n**Chiardiluna condiviso.** Ogni volta che usa Passo chiardiluna, il druido può portare con sé una creatura consenziente entro 3 metri da lui, teletrasportandola in uno spazio libero che è in grado di vedere entro 3 metri dal punto in cui arriva." }
					}
				}
			}
		};
	}
}
