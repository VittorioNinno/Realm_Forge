using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Holy Aura (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class HolyAura2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "holy-aura");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Cleric },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "holy-aura", "en"),
					Language = LanguageCode.En,
					Name = "Holy Aura",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a tiny reliquary worth at least 1,000 gp containing a sacred relic, such as a scrap of cloth from a saint's robe or a piece of parchment from a religious text",
					Description = "Divine light washes out from you and coalesces in a soft radiance in a 30-foot radius around you. Creatures of your choice in that radius when you cast this spell shed dim light in a 5-foot radius and have advantage on all saving throws, and other creatures have disadvantage on attack rolls against them until the spell ends. In addition, when a fiend or an undead hits an affected creature with a melee attack, the aura flashes with brilliant light. The attacker must succeed on a Constitution saving throw or be blinded until the spell ends.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "holy-aura", "it"),
					Language = LanguageCode.It,
					Name = "Aura Sacra",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un minuscolo reliquiario del valore di almeno 1.000 mo contenente una reliquia sacra, come un brandello della veste di un santo o un frammento di pergamena di un testo religioso",
					Description = "Una luce divina si irradia dall'incantatore e si condensa in un tenue splendore in un raggio di 9 metri attorno a lui. Le creature a scelta dell'incantatore che si trovano entro quel raggio quando lancia l'incantesimo emettono luce fioca in un raggio di 1,5 metri e dispongono di vantaggio a tutti i tiri salvezza, mentre le altre creature subiscono svantaggio ai tiri per colpire contro di esse finché l'incantesimo non termina. Inoltre, quando un immondo o un non morto colpisce una creatura influenzata con un attacco in mischia, l'aura sprigiona una luce abbagliante. L'attaccante deve superare un tiro salvezza su Costituzione, altrimenti è accecato finché l'incantesimo non termina.",
					HigherLevels = null
				}
			}
		};
	}
}
