using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Compelled Duel (2024 ruleset). Not part of SRD 5.2: the English and Italian descriptions are written for RealmForge, keeping the mechanics and the official game terms.
///	</summary>
public static class CompelledDuel2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "compelled-duel");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.RealmForge,
			Level = 1,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Paladin },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = false,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "compelled-duel", "en"),
					Language = LanguageCode.En,
					Name = "Compelled Duel",
					CastingTime = "Bonus Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "You single out one creature you can see within range and dare it to face you alone. It attempts a Wisdom saving throw. If it fails, then for the duration it rolls with Disadvantage when attacking anyone but you, and it can't choose to move to any space farther than 30 feet from you.\n\nThe challenge is broken, ending the spell, as soon as any of these happens:\n\n- you make an attack roll against a creature other than your foe, or cast a spell on an enemy other than your foe;\n- one of your allies damages your foe;\n- you finish your turn more than 30 feet away from your foe.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "compelled-duel", "it"),
					Language = LanguageCode.It,
					Name = "Duello Obbligato",
					CastingTime = "Azione bonus",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "L'incantatore individua una creatura entro gittata che è in grado di vedere e la sfida ad affrontarlo da sola. La creatura tenta un tiro salvezza su Saggezza. Se fallisce, per la durata tira con svantaggio quando attacca chiunque non sia l'incantatore, e non può scegliere di spostarsi in uno spazio a più di 9 metri da lui.\n\nLa sfida si rompe, e l'incantesimo termina, non appena accade una di queste cose:\n\n- l'incantatore effettua un tiro per colpire contro una creatura che non è il suo avversario, oppure lancia un incantesimo su un nemico che non è il suo avversario;\n- uno dei suoi alleati infligge danni all'avversario;\n- l'incantatore conclude il proprio turno a più di 9 metri dall'avversario.",
					HigherLevels = null
				}
			}
		};
	}
}
