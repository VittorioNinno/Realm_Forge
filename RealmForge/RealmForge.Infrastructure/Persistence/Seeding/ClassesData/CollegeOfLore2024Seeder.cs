using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	College of Lore (bard, 2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class CollegeOfLore2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-lore");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Bard2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-lore", "en"), Language = LanguageCode.En, Name = "College of Lore", Description = "Bards of the College of Lore collect spells and secrets from diverse sources, such as scholarly tomes, mystical rites, and peasant tales. The college’s members gather in libraries and universities to share their lore with one another. They also meet at festivals or affairs of state, where they can expose corruption, unravel lies, and poke fun at self-important figures of authority." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "college-of-lore", "it"), Language = LanguageCode.It, Name = "Collegio della Sapienza", Description = "I bardi del Collegio della Sapienza raccolgono incantesimi e segreti dalle fonti più diverse: tomi eruditi, riti mistici, racconti di contadini. I membri del collegio si ritrovano nelle biblioteche e nelle università per scambiarsi il loro sapere, ma anche nelle feste e negli affari di stato, dove smascherano la corruzione, sbrogliano le menzogne e si prendono gioco delle autorità troppo piene di sé." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/bonus-proficiencies"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/bonus-proficiencies", "en"), Language = LanguageCode.En, Name = "Bonus Proficiencies", Description = "You gain proficiency with three skills of your choice." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/bonus-proficiencies", "it"), Language = LanguageCode.It, Name = "Competenze Bonus", Description = "Il bardo ottiene competenza in tre abilità a sua scelta." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/cutting-words"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/cutting-words", "en"), Language = LanguageCode.En, Name = "Cutting Words", Description = "You learn to use your wit to supernaturally distract, confuse, and otherwise sap the confidence and competence of others. When a creature that you can see within 60 feet of yourself makes a damage roll or succeeds on an ability check or attack roll, you can take a Reaction to expend one use of your Bardic Inspiration; roll your Bardic Inspiration die, and subtract the number rolled from the creature’s roll, reducing the damage or potentially turning the success into a failure." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/cutting-words", "it"), Language = LanguageCode.It, Name = "Parole Taglienti", Description = "Il bardo impara a usare il suo spirito per distrarre, confondere e minare in modo soprannaturale la fiducia e la bravura degli altri. Quando una creatura entro 18 metri da lui che è in grado di vedere effettua un tiro per i danni oppure supera una prova di caratteristica o un tiro per colpire, il bardo può usare una reazione e spendere un utilizzo di Ispirazione bardica: tira il dado e sottrae il risultato dal tiro della creatura, riducendo i danni o forse trasformando il successo in un fallimento." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/magical-discoveries"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/magical-discoveries", "en"), Language = LanguageCode.En, Name = "Magical Discoveries", Description = "You learn two spells of your choice. These spells can come from the Cleric, Druid, or Wizard spell list or any combination thereof (see a class’s section for its spell list). A spell you choose must be a cantrip or a spell for which you have spell slots, as shown in the Bard Features table.\n\nYou always have the chosen spells prepared, and whenever you gain a Bard level, you can replace one of the spells with another spell that meets these requirements." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/magical-discoveries", "it"), Language = LanguageCode.It, Name = "Scoperte Magiche", Description = "Il bardo impara due incantesimi a sua scelta, che possono provenire dalle liste degli incantesimi da chierico, druido o mago, o da una loro combinazione. Ogni incantesimo scelto deve essere un trucchetto o un incantesimo per cui il bardo possiede slot incantesimo, come indicato nella tabella dei privilegi del bardo.\n\nIl bardo ha sempre preparati gli incantesimi scelti e, ogni volta che sale di livello come bardo, può sostituirne uno con un altro incantesimo che soddisfa questi requisiti." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/peerless-skill"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/peerless-skill", "en"), Language = LanguageCode.En, Name = "Peerless Skill", Description = "When you make an ability check or attack roll and fail, you can expend one use of Bardic Inspiration; roll the Bardic Inspiration die, and add the number rolled to the d20, potentially turning a failure into a success. On a failure, the Bardic Inspiration isn’t expended." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "college-of-lore/peerless-skill", "it"), Language = LanguageCode.It, Name = "Abilità Impareggiabile", Description = "Quando fallisce una prova di caratteristica o un tiro per colpire, il bardo può spendere un utilizzo di Ispirazione bardica: tira il dado e somma il risultato al d20, con la possibilità di trasformare il fallimento in un successo. Se il risultato resta un fallimento, l'Ispirazione bardica non viene spesa." }
					}
				}
			}
		};
	}
}
