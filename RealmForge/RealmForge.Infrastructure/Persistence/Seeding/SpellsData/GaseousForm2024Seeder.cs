using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Gaseous Form (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class GaseousForm2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gaseous-form");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gaseous-form", "en"),
					Language = LanguageCode.En,
					Name = "Gaseous Form",
					CastingTime = "Action",
					Range = "Touch",
					Duration = "Concentration, up to 1 hour",
					MaterialComponent = "a bit of gauze",
					Description = "A willing creature you touch shape-shifts, along with everything it's wearing and carrying, into a misty cloud for the duration. The spell ends on the target if it drops to 0 Hit Points or if it takes a Magic action to end the spell on itself.\n\nWhile in this form, the target's only method of movement is a Fly Speed of 10 feet, and it can hover. The target can enter and occupy the space of another creature. The target has Resistance to Bludgeoning, Piercing, and Slashing damage; it has Immunity to the Prone condition; and it has Advantage on Strength, Dexterity, and Constitution saving throws. The target can pass through narrow openings, but it treats liquids as though they were solid surfaces.\n\nThe target can't talk or manipulate objects, and any objects it was carrying or holding can't be dropped, used, or otherwise interacted with. Finally, the target can't attack or cast spells.",
					HigherLevels = "You can target one additional creature for each spell slot level above 3."
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "gaseous-form", "it"),
					Language = LanguageCode.It,
					Name = "Forma Gassosa",
					CastingTime = "Azione",
					Range = "Contatto",
					Duration = "Concentrazione, fino a 1 ora",
					MaterialComponent = "un pezzetto di garza",
					Description = "Una creatura consenziente toccata dall'incantatore si trasforma, insieme a tutto ciò che indossa e trasporta, in una nube nebbiosa per la durata. L'incantesimo termina sul bersaglio se scende a 0 punti ferita o se effettua un'azione di Magia per porre fine all'incantesimo su di sé.\n\nIn questa forma, l'unico mezzo di movimento del bersaglio è una velocità di volo di 3 metri, e può fluttuare. Il bersaglio può entrare nello spazio di un'altra creatura e occuparlo. Il bersaglio ha resistenza ai danni contundenti, perforanti e taglienti, è immune alla condizione prono e dispone di vantaggio ai tiri salvezza su Forza, Destrezza e Costituzione. Il bersaglio può passare attraverso aperture strette, ma tratta i liquidi come se fossero superfici solide.\n\nIl bersaglio non può parlare né manipolare oggetti, e gli oggetti che trasportava o impugnava non possono essere lasciati cadere, usati o utilizzati in altro modo. Infine, il bersaglio non può attaccare né lanciare incantesimi.",
					HigherLevels = "L'incantatore può scegliere come bersaglio una creatura aggiuntiva per ogni livello dello slot incantesimo superiore al 3°."
				}
			}
		};
	}
}
