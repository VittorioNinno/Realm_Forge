using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Way of Shadow (monk, 2014 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class WayOfShadow2014Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "way-of-shadow");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Monk2014Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "way-of-shadow", "en"), Language = LanguageCode.En, Name = "Way of Shadow", Description = "Monks of this tradition prize stealth and subterfuge. Folk may call them ninjas or shadowdancers, and they often work as spies and assassins. Some of their monasteries are tight-knit clans sworn to secrecy, others behave more like thieves' guilds and sell their services to anyone who can pay. Whatever their methods, the masters of these orders expect absolute obedience from their students." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "subclass", "way-of-shadow", "it"), Language = LanguageCode.It, Name = "Via dell'Ombra", Description = "I monaci di questa tradizione apprezzano la furtività e l'inganno. La gente può chiamarli ninja o danzatori delle ombre, e spesso lavorano come spie e assassini. Alcuni dei loro monasteri sono clan affiatati votati alla segretezza, altri si comportano più come gilde di ladri e vendono i propri servigi a chiunque possa pagare. Qualunque sia il loro metodo, i maestri di questi ordini pretendono dagli allievi un'obbedienza assoluta." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/shadow-arts"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/shadow-arts", "en"), Language = LanguageCode.En, Name = "Shadow Arts", Description = "From 3rd level, your ki can reproduce certain spells. As an action, you can spend 2 ki points to cast *darkness*, *darkvision*, *pass without trace*, or *silence*, with no material components needed. You also learn the *minor illusion* cantrip if you don't already know it." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/shadow-arts", "it"), Language = LanguageCode.It, Name = "Arti dell'Ombra", Description = "Dal 3° livello il ki del monaco può riprodurre alcuni incantesimi. Come azione, il monaco può spendere 2 punti ki per lanciare *oscurità*, *scurovisione*, *passare senza tracce* o *silenzio*, senza bisogno di componenti materiali. Apprende inoltre il trucchetto *illusione minore*, se non lo conosce già." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/shadow-step"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 6,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/shadow-step", "en"), Language = LanguageCode.En, Name = "Shadow Step", Description = "At 6th level, you can slip from one shadow to another. While you are in dim light or darkness, you can use a bonus action to teleport up to 60 feet to an unoccupied space you can see that is also in dim light or darkness. Your first melee attack before the end of that turn has advantage." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/shadow-step", "it"), Language = LanguageCode.It, Name = "Passo dell'Ombra", Description = "Al 6° livello il monaco può scivolare da un'ombra all'altra. Finché si trova in luce fioca o nell'oscurità, può usare un'azione bonus per teletrasportarsi fino a 18 metri in uno spazio libero che è in grado di vedere e che si trova anch'esso in luce fioca o nell'oscurità. Il suo primo attacco in mischia prima della fine di quel turno ha vantaggio." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/cloak-of-shadows"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 11,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/cloak-of-shadows", "en"), Language = LanguageCode.En, Name = "Cloak of Shadows", Description = "At 11th level, you can melt into the shadows. While you are in dim light or darkness, you can use your action to turn invisible. You stay invisible until you attack, cast a spell, or enter an area of bright light." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/cloak-of-shadows", "it"), Language = LanguageCode.It, Name = "Manto di Ombre", Description = "All'11° livello il monaco può fondersi con le ombre. Finché si trova in luce fioca o nell'oscurità, può usare la sua azione per diventare invisibile. Resta invisibile finché non attacca, non lancia un incantesimo o non entra in un'area di luce intensa." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/opportunist"),
					Ruleset = RulesetVersion.Dnd5e_2014,
					Level = 17,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/opportunist", "en"), Language = LanguageCode.En, Name = "Opportunist", Description = "At 17th level, you take advantage of any opening. Whenever a creature within 5 feet of you is hit by an attack made by someone other than you, you can use your reaction to make a melee attack against that creature." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "class-feature", "way-of-shadow/opportunist", "it"), Language = LanguageCode.It, Name = "Opportunista", Description = "Al 17° livello il monaco sfrutta ogni apertura. Ogni volta che una creatura entro 1,5 metri da lui viene colpita da un attacco effettuato da qualcun altro, il monaco può usare la sua reazione per effettuare un attacco in mischia contro quella creatura." }
					}
				}
			}
		};
	}
}
