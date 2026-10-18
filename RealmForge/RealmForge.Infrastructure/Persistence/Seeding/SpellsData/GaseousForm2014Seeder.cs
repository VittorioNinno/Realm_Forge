using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Gaseous Form (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GaseousForm2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gaseous-form");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Transmutation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Sorcerer, SpellcastingClass.Warlock, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gaseous-form", "en"),
					Language = LanguageCode.En,
					Name = "Gaseous Form",
					CastingTime = "1 action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a bit of gauze and a wisp of smoke",
					Description = "You transform a willing creature you touch, along with everything it's wearing and carrying, into a misty cloud for the duration. The spell ends if the creature drops to 0 hit points. An incorporeal creature isn't affected.\n\nWhile in this form, the target's only method of movement is a flying speed of 10 feet. The target can enter and occupy the space of another creature. The target has resistance to nonmagical damage, and it has advantage on Strength, Dexterity, and Constitution saving throws. The target can pass through small holes, narrow openings, and even mere cracks, though it treats liquids as though they were solid surfaces. The target can't fall and remains hovering in the air even when stunned or otherwise incapacitated.\n\nWhile in the form of a misty cloud, the target can't talk or manipulate objects, and any objects it was carrying or holding can't be dropped, used, or otherwise interacted with. The target can't attack or cast spells.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "gaseous-form", "it"),
					Language = LanguageCode.It,
					Name = "Forma Gassosa",
					CastingTime = "1 azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un pezzetto di garza e un filo di fumo",
					Description = "Per la durata, l'incantatore trasforma una creatura consenziente che tocca, insieme a tutto ciò che indossa e trasporta, in una nube nebbiosa. L'incantesimo termina se la creatura scende a 0 punti ferita. Una creatura incorporea non è influenzata.\n\nFinché si trova in questa forma, l'unico modo in cui il bersaglio può muoversi è una velocità di volare di 3 metri. Il bersaglio può entrare nello spazio di un'altra creatura e occuparlo. Ha resistenza ai danni non magici e dispone di vantaggio ai tiri salvezza su Forza, Destrezza e Costituzione. Può passare attraverso piccoli fori, aperture strette e perfino semplici fessure, ma tratta i liquidi come se fossero superfici solide. Il bersaglio non può cadere e resta sospeso a mezz'aria anche quando è stordito o incapacitato in altro modo.\n\nFinché ha la forma di una nube nebbiosa, il bersaglio non può parlare né manipolare oggetti, e gli oggetti che trasportava o impugnava non possono essere lasciati cadere, usati o essere oggetto di altre interazioni. Il bersaglio non può attaccare né lanciare incantesimi.",
					HigherLevels = null
				}
			}
		};
	}
}
