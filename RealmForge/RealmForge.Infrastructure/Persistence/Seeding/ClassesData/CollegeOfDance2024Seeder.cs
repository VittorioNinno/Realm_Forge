using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	College of Dance (bard, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class CollegeOfDance2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-dance");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Bard2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-dance", "en"), Language = LanguageCode.En, Name = "College of Dance", Description = "For these Bards the Words of Creation are not only spoken or sung: they move in the turning of the stars and in the steps of the smallest creatures. They train body and spirit to keep pace with the whirling cosmos, prizing agility, speed and grace above all." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-dance", "it"), Language = LanguageCode.It, Name = "Collegio della Danza", Description = "Per questi bardi le Parole della Creazione non si pronunciano né si cantano soltanto: vivono nel moto delle stelle e nei passi delle creature più minute. Allenano il corpo e lo spirito a tenere il ritmo del cosmo che danza, mettendo l'agilità, la rapidità e la grazia al di sopra di tutto." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/dazzling-footwork"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/dazzling-footwork", "en"), Language = LanguageCode.En, Name = "Dazzling Footwork", Description = "As long as you wear no armor and hold no Shield, you gain these benefits.\n\n**Dance Virtuoso.** Charisma (Performance) checks you make that involve dancing have Advantage.\n\n**Unarmored Defense.** Your base Armor Class is 10 plus your Dexterity and Charisma modifiers.\n\n**Agile Strikes.** Whenever you spend a use of Bardic Inspiration as part of an action, a Bonus Action, or a Reaction, you can also make one Unarmed Strike as part of it.\n\n**Bardic Damage.** Your Unarmed Strike attack rolls can use Dexterity in place of Strength. When an Unarmed Strike deals damage, you can replace its usual damage with Bludgeoning damage equal to a roll of your Bardic Inspiration die plus your Dexterity modifier; rolling the die this way doesn't spend it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/dazzling-footwork", "it"), Language = LanguageCode.It, Name = "Scarto Smagliante", Description = "Finché non indossa armature e non impugna uno scudo, il bardo ottiene i benefici seguenti.\n\n**Virtuoso della danza.** Il bardo dispone di vantaggio alle prove di Carisma (Intrattenere) che comportano una danza.\n\n**Difesa senza armatura.** La Classe Armatura base del bardo è pari a 10 + il suo modificatore di Destrezza + il suo modificatore di Carisma.\n\n**Colpi agili.** Quando spende un utilizzo di Ispirazione bardica come parte di un'azione, di un'azione bonus o di una reazione, il bardo può sferrare un colpo senz'armi come parte della stessa azione, azione bonus o reazione.\n\n**Danni bardici.** Per i tiri per colpire dei suoi colpi senz'armi il bardo può usare la Destrezza anziché la Forza. Quando infligge danni con un colpo senz'armi, invece dei danni normali può infliggere danni contundenti pari al risultato del suo dado di Ispirazione bardica + il suo modificatore di Destrezza. Questo tiro non spende il dado." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/inspiring-movement"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/inspiring-movement", "en"), Language = LanguageCode.En, Name = "Inspiring Movement", Description = "When an enemy you can see finishes its turn within 5 feet of you, you can use your Reaction and spend a use of Bardic Inspiration to move up to half your Speed. One ally of your choice within 30 feet of you can then use their Reaction to move up to half their own Speed. Neither movement provokes Opportunity Attacks." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/inspiring-movement", "it"), Language = LanguageCode.It, Name = "Movimento Ispiratore", Description = "Quando un nemico che il bardo è in grado di vedere termina il proprio turno entro 1,5 metri da lui, il bardo può usare una reazione e spendere un utilizzo di Ispirazione bardica per muoversi fino a metà della sua velocità. Poi un alleato a sua scelta entro 9 metri da lui può usare la propria reazione per muoversi a sua volta fino a metà della propria velocità. Nessuno di questi movimenti provoca attacchi di opportunità." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/tandem-footwork"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/tandem-footwork", "en"), Language = LanguageCode.En, Name = "Tandem Footwork", Description = "As you roll Initiative, provided you aren't Incapacitated, you can spend a use of Bardic Inspiration and roll the die. You and every ally within 30 feet who can see or hear you add the result to your Initiative." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/tandem-footwork", "it"), Language = LanguageCode.It, Name = "Scarto Coordinato", Description = "Quando tira per l'iniziativa, se non è incapacitato, il bardo può spendere un utilizzo di Ispirazione bardica e tirare il dado: lui e ogni alleato entro 9 metri da lui che è in grado di vederlo o di sentirlo ottengono un bonus all'iniziativa pari al risultato." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/leading-evasion"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/leading-evasion", "en"), Language = LanguageCode.En, Name = "Leading Evasion", Description = "If an effect lets you make a Dexterity saving throw to take only half damage, a success means you take no damage at all, and a failure means you take only half. Creatures within 5 feet of you that are making the same Dexterity save can share this benefit for that roll.\n\nThis feature doesn't work while you are Incapacitated." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-dance/leading-evasion", "it"), Language = LanguageCode.It, Name = "Elusione Trainante", Description = "Quando è soggetto a un effetto che gli permette di effettuare un tiro salvezza su Destrezza per subire solo la metà dei danni, il bardo non subisce alcun danno se supera il tiro salvezza e subisce solo la metà dei danni se lo fallisce. Le creature entro 1,5 metri da lui che effettuano lo stesso tiro salvezza su Destrezza possono condividere questo beneficio per quel tiro.\n\nIl bardo non può usare questo privilegio se è incapacitato." }
					}
				}
			}
		};
	}
}
