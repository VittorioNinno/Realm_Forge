using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	Spell. Level, school, components, ritual, concentration and class lists are structured (used by the filters);
	///	names, descriptions and the casting time / range / duration lines are localized in <see cref="SpellTranslation"/>.
	///	</summary>
	public class Spell : GameEntity
	{
		//	0 = cantrip, 1-9 = spell level
		public int Level { get; set; }

		public SpellSchool School { get; set; }

		//	Classes whose spell list includes this spell
		public List<SpellcastingClass> Classes { get; set; } = new();

		public bool Ritual { get; set; }
		public bool Concentration { get; set; }

		//	Components: verbal, somatic, material (the material text is localized)
		public bool Verbal { get; set; }
		public bool Somatic { get; set; }
		public bool Material { get; set; }

		public ICollection<SpellTranslation> Translations { get; set; } = new List<SpellTranslation>();
	}

	///	<summary>
	///	Texts of a spell in one language (unique per spell and language). Description and HigherLevels are Markdown.
	///	</summary>
	public class SpellTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid SpellId { get; set; }
		public Spell Spell { get; set; } = null!;

		public LanguageCode Language { get; set; }

		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		//	"At Higher Levels" (spells) or the cantrip damage scaling; null when the spell has none
		public string? HigherLevels { get; set; }

		//	Stat block lines as printed, e.g. "1 reaction, which you take when…", "Self (15-foot cone)", "Concentration, up to 1 minute"
		public string CastingTime { get; set; } = string.Empty;
		public string Range { get; set; } = string.Empty;
		public string Duration { get; set; } = string.Empty;

		//	Material component, e.g. "a diamond worth at least 300 gp, which the spell consumes"
		public string? MaterialComponent { get; set; }
	}
}
