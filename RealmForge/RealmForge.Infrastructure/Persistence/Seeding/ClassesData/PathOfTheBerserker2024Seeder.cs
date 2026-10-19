using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Path of the Berserker (barbarian, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PathOfTheBerserker2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-berserker");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Barbarian2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-berserker", "en"), Language = LanguageCode.En, Name = "Path of the Berserker", Description = "Barbarians who walk the Path of the Berserker direct their Rage primarily toward violence. Their path is one of untrammeled fury, and they thrill in the chaos of battle as they allow their Rage to seize and empower them." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-berserker", "it"), Language = LanguageCode.It, Name = "Cammino del Berserker", Description = "I barbari che seguono il Cammino del Berserker indirizzano la loro ira soprattutto verso la violenza. Il loro è un cammino di furia sfrenata: gioiscono del caos della battaglia e lasciano che l'ira si impadronisca di loro e li renda più forti." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/frenzy"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/frenzy", "en"), Language = LanguageCode.En, Name = "Frenzy", Description = "If you use Reckless Attack while your Rage is active, you deal extra damage to the first target you hit on your turn with a Strength-based attack. To determine the extra damage, roll a number of d6s equal to your Rage Damage bonus, and add them together. The damage has the same type as the weapon or Unarmed Strike used for the attack." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/frenzy", "it"), Language = LanguageCode.It, Name = "Frenesia", Description = "Se usa Attacco irruento mentre l'ira è attiva, il barbaro infligge danni extra al primo bersaglio che colpisce nel suo turno con un attacco basato sulla Forza. Per determinare i danni extra, tira un numero di d6 pari al suo bonus dei Danni dell'ira e somma i risultati. I danni sono dello stesso tipo dell'arma o del colpo senz'armi usato per l'attacco." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/mindless-rage"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/mindless-rage", "en"), Language = LanguageCode.En, Name = "Mindless Rage", Description = "You have Immunity to the Charmed and Frightened conditions while your Rage is active. If you’re Charmed or Frightened when you enter your Rage, the condition ends on you." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/mindless-rage", "it"), Language = LanguageCode.It, Name = "Ira Incontenibile", Description = "Finché l'ira è attiva, il barbaro ha immunità alle condizioni di affascinato e spaventato. Se è affascinato o spaventato quando entra in ira, la condizione termina." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/retaliation"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/retaliation", "en"), Language = LanguageCode.En, Name = "Retaliation", Description = "When you take damage from a creature that is within 5 feet of you, you can take a Reaction to make one melee attack against that creature, using a weapon or an Unarmed Strike." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/retaliation", "it"), Language = LanguageCode.It, Name = "Ritorsione", Description = "Quando subisce danni da una creatura che si trova entro 1,5 metri da lui, il barbaro può usare una reazione per effettuare un attacco in mischia contro quella creatura, con un'arma o con un colpo senz'armi." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/intimidating-presence"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/intimidating-presence", "en"), Language = LanguageCode.En, Name = "Intimidating Presence", Description = "As a Bonus Action, you can strike terror into others with your menacing presence and primal power. When you do so, each creature of your choice in a 30-foot Emanation originating from you must make a Wisdom saving throw (DC 8 plus your Strength modifier and Proficiency Bonus). On a failed save, a creature has the Frightened condition for 1 minute. At the end of each of the Frightened creature’s turns, the creature repeats the save, ending the effect on itself on a success.\n\nOnce you use this feature, you can’t use it again until you finish a Long Rest unless you expend a use of your Rage (no action required) to restore your use of it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-berserker/intimidating-presence", "it"), Language = LanguageCode.It, Name = "Presenza Intimidatoria", Description = "Come azione bonus, il barbaro può incutere terrore negli altri con la sua presenza minacciosa e il suo potere primordiale. Quando lo fa, ogni creatura a sua scelta in un'emanazione di 9 metri che parte da lui deve effettuare un tiro salvezza su Saggezza (CD pari a 8 + il modificatore di Forza del barbaro + il suo bonus di competenza). Se lo fallisce, la creatura subisce la condizione di spaventato per 1 minuto. Alla fine di ogni turno della creatura spaventata, questa ripete il tiro salvezza e, se lo supera, l'effetto su di lei termina.\n\nDopo aver usato questo privilegio, il barbaro non può usarlo di nuovo finché non completa un riposo lungo, a meno che non spenda un utilizzo di Ira (nessuna azione richiesta) per ripristinarlo." }
					}
				}
			}
		};
	}
}
