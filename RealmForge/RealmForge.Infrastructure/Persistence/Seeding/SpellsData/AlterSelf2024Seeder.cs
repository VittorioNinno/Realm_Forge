using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Alter Self (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AlterSelf2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "alter-self");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "alter-self", "en"),
					Language = LanguageCode.En,
					Name = "Alter Self",
					CastingTime = "Action",
					Range = "Self",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You alter your physical form. Choose one of the following options. Its effects last for the duration, during which you can take a Magic action to replace the option you chose with a different one.\n\n***Aquatic Adaptation.*** You sprout gills and grow webs between your fingers. You can breathe underwater and gain a Swim Speed equal to your Speed.\n\n***Change Appearance.*** You alter your appearance. You decide what you look like, including your height, weight, facial features, sound of your voice, hair length, coloration, and other distinguishing characteristics. You can make yourself appear as a member of another species, though none of your statistics change. You can't appear as a creature of a different size, and your basic shape stays the same; if you're bipedal, you can't use this spell to become quadrupedal, for instance. For the duration, you can take a Magic action to change your appearance in this way again.\n\n***Natural Weapons.*** You grow claws (Slashing), fangs (Piercing), horns (Piercing), or hooves (Bludgeoning). When you use your Unarmed Strike to deal damage with that new growth, it deals 1d6 damage of the type in parentheses instead of dealing the normal damage for your Unarmed Strike, and you use your spellcasting ability modifier for the attack and damage rolls rather than using Strength.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "alter-self", "it"),
					Language = LanguageCode.It,
					Name = "Alterare Se Stesso",
					CastingTime = "Azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore altera la propria forma fisica. Sceglie una delle opzioni seguenti, i cui effetti durano per tutta la durata; nel frattempo, l'incantatore può effettuare un'azione di Magia per sostituire l'opzione scelta con un'altra.\n\n***Adattamento Acquatico.*** All'incantatore spuntano branchie e tra le sue dita crescono membrane. Può respirare sott'acqua e ottiene una velocità di nuoto pari alla sua velocità.\n\n***Cambiare Aspetto.*** L'incantatore altera il proprio aspetto. Decide come apparire, inclusi altezza, peso, lineamenti del volto, timbro di voce, lunghezza dei capelli, colorito e altre caratteristiche distintive. Può assumere l'aspetto di un membro di un'altra specie, ma nessuna delle sue statistiche cambia. Non può assumere l'aspetto di una creatura di taglia diversa e la sua forma di base resta la stessa; se è bipede, per esempio, non può usare questo incantesimo per diventare quadrupede. Per la durata, l'incantatore può effettuare un'azione di Magia per cambiare di nuovo aspetto in questo modo.\n\n***Armi Naturali.*** All'incantatore crescono artigli (taglienti), zanne (perforanti), corna (perforanti) o zoccoli (contundenti). Quando usa il proprio colpo senz'armi per infliggere danni con questa nuova crescita, infligge 1d6 danni del tipo indicato tra parentesi invece dei normali danni del colpo senz'armi, e usa il proprio modificatore di caratteristica da incantatore per i tiri per colpire e per i danni invece della Forza.",
					HigherLevels = null
				}
			}
		};
	}
}
