using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Energy Resistance feat (2024 ruleset).
///	</summary>
public static class BoonOfEnergyResistance2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555609");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551591");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551592");

	///	<summary>
	///	Builds the canonical SRD definition of this feat. Persistence is handled by FeatSeeder.
	///	</summary>
	public static Feat Build()
	{
		return new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Category = FeatCategory.EpicBoon,
			PrerequisiteMinimumLevel = 19,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Boon of Energy Resistance",
					Description = "Raw elemental energy flows around you without harming you.\n- **Ability +1.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **Two Resistances.** Choose two damage types among acid, cold, fire, lightning, necrotic, poison, psychic, radiant, and thunder: you have Resistance to them. You can change your choices whenever you finish a Long Rest.\n- **Redirect the Energy.** When you take damage of one of the chosen types, you can use your Reaction to send damage of that type at another creature you can see within 60 feet of you that isn't behind Total Cover. The target makes a Dexterity saving throw (DC 8 + your Constitution modifier + your Proficiency Bonus) and, on a failure, takes 2d12 + your Constitution modifier damage."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono della Resistenza all'Energia",
					Description = "L'energia elementale scorre intorno al personaggio senza ferirlo.\n- **Caratteristica +1.** Un punteggio di caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Due resistenze.** Sceglie due tipi di danno tra acido, freddo, fuoco, fulmine, necrotico, veleno, psichico, radioso e tuono: ha Resistenza a essi. Può cambiare la scelta ogni volta che termina un riposo lungo.\n- **Reindirizzare l'energia.** Quando subisce danni di uno dei tipi scelti, può usare la Reazione per scagliare danni dello stesso tipo contro un'altra creatura che può vedere entro 18 metri e che non si trovi dietro copertura totale. Il bersaglio effettua un tiro salvezza su Destrezza (CD 8 + il modificatore di Costituzione del personaggio + il suo bonus di competenza) e, se lo fallisce, subisce danni pari a 2d12 + il modificatore di Costituzione del personaggio."
				}
			}
		};
	}
}