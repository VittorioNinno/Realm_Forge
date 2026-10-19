using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.ClassesData;

///	<summary>
///	Path of the World Tree (barbarian, 2024 ruleset). Not in the SRD: names and mechanics as in the rules, with descriptions written for RealmForge in English and Italian.
///	</summary>
public static class PathOfTheWorldTree2024Seeder
{
	public static readonly Guid SubclassId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-world-tree");

	public static Subclass Build()
	{
		return new Subclass
		{
			Id = SubclassId,
			CharacterClassId = Barbarian2024Seeder.ClassId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			CasterProgression = CasterProgression.None,
			SpellcastingAbility = null,
			Translations = new List<SubclassTranslation>
			{
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-world-tree", "en"), Language = LanguageCode.En, Name = "Path of the World Tree", Description = "These Barbarians feel the roots and branches of Yggdrasil, the cosmic tree that links the Outer Planes to each other and to the Material Plane. Their Rage draws on the tree's life force to sustain them and their allies, and lets them step along its branches from place to place." },
				new SubclassTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "subclass", "path-of-the-world-tree", "it"), Language = LanguageCode.It, Name = "Cammino dell'Albero del Mondo", Description = "Questi barbari percepiscono le radici e i rami di Yggdrasil, l'albero cosmico che collega i Piani Esterni tra loro e con il Piano Materiale. La loro ira attinge alla forza vitale dell'albero per sostenere loro stessi e i loro alleati, e permette loro di spostarsi da un luogo all'altro lungo i suoi rami." }
			},
			Features = new List<ClassFeature>
			{
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/vitality-of-the-tree"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 3,
					SortOrder = 0,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/vitality-of-the-tree", "en"), Language = LanguageCode.En, Name = "Vitality of the Tree", Description = "The World Tree's life force feeds your Rage, which grants you two benefits.\n\n**Vitality Surge.** Each time your Rage starts, Temporary Hit Points equal to your Barbarian level wash over you.\n\n**Life-Giving Force.** At the start of each of your turns while your Rage lasts, you can pick another creature within 10 feet of you to receive Temporary Hit Points: roll a number of d6s equal to your Rage Damage bonus and add them up. Any of these Temporary Hit Points left when your Rage ends disappear." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/vitality-of-the-tree", "it"), Language = LanguageCode.It, Name = "Vitalità dell'Albero", Description = "L'ira del barbaro attinge alla forza vitale dell'Albero del Mondo e gli conferisce i benefici seguenti.\n\n**Impeto vitale.** Quando entra in ira, il barbaro ottiene un numero di punti ferita temporanei pari al suo livello da barbaro.\n\n**Forza vivificante.** All'inizio di ciascuno dei suoi turni in cui l'ira è attiva, il barbaro può scegliere un'altra creatura entro 3 metri da sé che ottiene punti ferita temporanei: il barbaro tira un numero di d6 pari al suo bonus dei Danni dell'ira e somma i risultati. I punti ferita temporanei ancora rimasti quando l'ira termina svaniscono." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/branches-of-the-tree"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 6,
					SortOrder = 1,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/branches-of-the-tree", "en"), Language = LanguageCode.En, Name = "Branches of the Tree", Description = "While your Rage lasts, when a creature you can see begins its turn within 30 feet of you, you can use your Reaction to wrap it in ghostly branches of the World Tree. It must succeed on a Strength saving throw (DC 8 plus your Strength modifier and Proficiency Bonus) or be teleported to an unoccupied space within 5 feet of you, or to the closest unoccupied space you can see. Once it has been moved, you can also drop its Speed to 0 for the rest of the current turn." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/branches-of-the-tree", "it"), Language = LanguageCode.It, Name = "Rami dell'Albero", Description = "Mentre l'ira è attiva, quando una creatura che il barbaro è in grado di vedere inizia il proprio turno entro 9 metri da lui, il barbaro può usare una reazione per far comparire attorno a lei i rami spettrali dell'Albero del Mondo. Il bersaglio deve superare un tiro salvezza su Forza (CD pari a 8 + il modificatore di Forza del barbaro + il suo bonus di competenza), altrimenti viene teletrasportato in uno spazio libero entro 1,5 metri dal barbaro, o nello spazio libero più vicino che il barbaro è in grado di vedere. Dopo il teletrasporto, il barbaro può ridurre la velocità del bersaglio a 0 fino alla fine del turno in corso." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/battering-roots"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 10,
					SortOrder = 2,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/battering-roots", "en"), Language = LanguageCode.En, Name = "Battering Roots", Description = "On your turn, tendrils of the World Tree stretch out from you, adding 10 feet to your reach with any Melee weapon that has the Heavy or Versatile property. When you hit with such a weapon during your turn, you can trigger the Push or Topple mastery property on top of another mastery property you're already using with that weapon." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/battering-roots", "it"), Language = LanguageCode.It, Name = "Radici d'Assalto", Description = "Durante il suo turno, la portata del barbaro con qualsiasi arma da mischia dotata della proprietà pesante o versatile aumenta di 3 metri, mentre dal suo corpo si allungano i viticci dell'Albero del Mondo. Quando colpisce con un'arma simile nel suo turno, può attivare la proprietà di padronanza Spinta o Rovesciamento in aggiunta a un'altra proprietà di padronanza che sta usando con quell'arma." }
					}
				},
				new ClassFeature
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/travel-along-the-tree"),
					Ruleset = RulesetVersion.Dnd5e_2024,
					Level = 14,
					SortOrder = 3,
					Translations = new List<ClassFeatureTranslation>
					{
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/travel-along-the-tree", "en"), Language = LanguageCode.En, Name = "Travel along the Tree", Description = "When you enter your Rage, and as a Bonus Action while it lasts, you can teleport up to 60 feet to an unoccupied space you can see.\n\nOnce per Rage, you can also stretch that teleport to 150 feet. If you do, up to six willing creatures within 10 feet of you can come along; each one arrives in an unoccupied space of your choice within 10 feet of the space you reach." },
						new ClassFeatureTranslation { Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "class-feature", "path-of-the-world-tree/travel-along-the-tree", "it"), Language = LanguageCode.It, Name = "Viaggio lungo l'Albero", Description = "Quando entra in ira, e come azione bonus finché l'ira è attiva, il barbaro può teletrasportarsi fino a 18 metri in uno spazio libero che è in grado di vedere.\n\nInoltre, una volta per ira, può aumentare la gittata di questo teletrasporto a 45 metri. In tal caso può portare con sé fino a sei creature consenzienti che si trovano entro 3 metri da lui: ognuna si teletrasporta in uno spazio libero a scelta del barbaro entro 3 metri dallo spazio di destinazione." }
					}
				}
			}
		};
	}
}
