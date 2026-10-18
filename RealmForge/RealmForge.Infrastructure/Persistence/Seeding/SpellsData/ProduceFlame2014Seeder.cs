using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Produce Flame (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ProduceFlame2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "produce-flame");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 0,
			School = SpellSchool.Conjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "produce-flame", "en"),
					Language = LanguageCode.En,
					Name = "Produce Flame",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "10 minutes",
					MaterialComponent = null,
					Description = "A flickering flame appears in your hand. The flame remains there for the duration and harms neither you nor your equipment. The flame sheds bright light in a 10-foot radius and dim light for an additional 10 feet. The spell ends if you dismiss it as an action or if you cast it again.\n\nYou can also attack with the flame, although doing so ends the spell. When you cast this spell, or as an action on a later turn, you can hurl the flame at a creature within 30 feet of you. Make a ranged spell attack. On a hit, the target takes 1d8 fire damage.\n\nThis spell's damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "produce-flame", "it"),
					Language = LanguageCode.It,
					Name = "Produrre Fiamma",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "10 minuti",
					MaterialComponent = null,
					Description = "Una fiamma tremolante compare nella mano dell'incantatore. La fiamma vi rimane per la durata e non danneggia né l'incantatore né il suo equipaggiamento. La fiamma emette luce intensa in un raggio di 3 metri e luce fioca per ulteriori 3 metri. L'incantesimo termina se l'incantatore lo congeda come azione o se lo lancia di nuovo.\n\nL'incantatore può anche attaccare con la fiamma, anche se ciò pone fine all'incantesimo. Quando lancia questo incantesimo, o come azione in un turno successivo, può scagliare la fiamma contro una creatura entro 9 metri da lui. Effettua un attacco con incantesimo a distanza. Se colpisce, il bersaglio subisce 1d8 danni da fuoco.\n\nI danni di questo incantesimo aumentano di 1d8 quando l'incantatore raggiunge il 5° livello (2d8), l'11° livello (3d8) e il 17° livello (4d8).",
					HigherLevels = null
				}
			}
		};
	}
}
