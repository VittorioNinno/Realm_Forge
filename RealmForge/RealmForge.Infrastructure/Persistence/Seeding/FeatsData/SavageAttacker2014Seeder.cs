using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Savage Attacker feat (2014 ruleset).
///	</summary>
public static class SavageAttacker2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555533");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555831");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555832");

	///	<summary>
	///	Builds the canonical SRD definition of this feat. Persistence is handled by FeatSeeder.
	///	</summary>
	public static Feat Build()
	{
		return new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Savage Attacker",
					Description = "Your blows land with brutal force.\n- Once per turn, when you roll damage for a melee weapon attack, you can roll the weapon's damage dice again and use whichever total you prefer."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Aggressore Selvaggio",
					Description = "I colpi del personaggio si abbattono con forza brutale.\n- Una volta per turno, quando tira i danni di un attacco con un'arma da mischia, può ritirare i dadi di danno dell'arma e usare il totale che preferisce."
				}
			}
		};
	}
}