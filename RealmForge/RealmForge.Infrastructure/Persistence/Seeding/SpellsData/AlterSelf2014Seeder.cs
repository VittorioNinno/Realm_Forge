using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Alter Self (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AlterSelf2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "alter-self");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "alter-self", "en"),
					Language = LanguageCode.En,
					Name = "Alter Self",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = null,
					Description = "You assume a different form. When you cast the spell, choose one of the following options, the effects of which last for the duration of the spell. While the spell lasts, you can end one option as an action to gain the benefits of a different one.\n\n***Aquatic Adaptation.*** You adapt your body to an aquatic environment, sprouting gills and growing webbing between your fingers. You can breathe underwater and gain a swimming speed equal to your walking speed.\n\n***Change Appearance.*** You transform your appearance. You decide what you look like, including your height, weight, facial features, sound of your voice, hair length, coloration, and distinguishing characteristics, if any. You can make yourself appear as a member of another race, though none of your statistics change. You also can't appear as a creature of a different size than you, and your basic shape stays the same; if you're bipedal, you can't use this spell to become quadrupedal, for instance. At any time for the duration of the spell, you can use your action to change your appearance in this way again.\n\n***Natural Weapons.*** You grow claws, fangs, spines, horns, or a different natural weapon of your choice. Your unarmed strikes deal 1d6 bludgeoning, piercing, or slashing damage, as appropriate to the natural weapon you chose, and you are proficient with your unarmed strikes. Finally, the natural weapon is magic and you have a +1 bonus to the attack and damage rolls you make using it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "alter-self", "it"),
					Language = LanguageCode.It,
					Name = "Alterare Se Stesso",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = null,
					Description = "L'incantatore assume una forma diversa. Quando lancia l'incantesimo, sceglie una delle opzioni seguenti, i cui effetti durano per tutta la durata dell'incantesimo. Finché l'incantesimo dura, l'incantatore può usare un'azione per porre fine a un'opzione e ottenere i benefici di un'altra.\n\n***Adattamento Acquatico.*** L'incantatore adatta il proprio corpo a un ambiente acquatico: gli spuntano branchie e tra le dita gli crescono membrane. Può respirare sott'acqua e ottiene una velocità di nuotare pari alla sua velocità base sul terreno.\n\n***Cambiare Aspetto.*** L'incantatore trasforma il proprio aspetto. Decide come apparire, inclusi altezza, peso, lineamenti del volto, timbro della voce, lunghezza dei capelli, colorito ed eventuali tratti distintivi. Può assumere l'aspetto di un membro di un'altra razza, ma nessuna delle sue statistiche cambia. Non può inoltre apparire come una creatura di taglia diversa dalla propria e la sua forma di base resta la stessa: se è bipede, per esempio, non può usare questo incantesimo per diventare quadrupede. In qualsiasi momento per la durata dell'incantesimo, può usare la sua azione per cambiare di nuovo aspetto in questo modo.\n\n***Armi Naturali.*** All'incantatore crescono artigli, zanne, aculei, corna o un'altra arma naturale a sua scelta. I suoi colpi senz'armi infliggono 1d6 danni contundenti, perforanti o taglienti, a seconda dell'arma naturale scelta, e l'incantatore ha competenza nei propri colpi senz'armi. Infine, l'arma naturale è magica e l'incantatore ottiene un bonus di +1 ai tiri per colpire e ai tiri per i danni effettuati con essa.",
					HigherLevels = null
				}
			}
		};
	}
}
