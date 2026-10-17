using RealmForge.Domain.Common;
using RealmForge.Shared.Enums;

namespace RealmForge.Domain.Entities
{
	///	<summary>
	///	Subspecies or lineage of a species (e.g. Wood Elf, Drow), with an optional speed override and its own traits.
	///	</summary>
	public class Subspecies : GameEntity
	{
		//	Foreign key and navigation property to the parent Species
		public Guid SpeciesId { get; set; }
		public Species Species { get; set; } = null!;

		//	Optional base walking speed override in feet (e.g., 35 ft. for Wood Elf)
		public int? BaseSpeedOverrideInFeet { get; set; }

		//	Traits granted exclusively by this subspecies or lineage
		public ICollection<Trait> Traits { get; set; } = new List<Trait>();

		//	Localized name and description collection
		public ICollection<SubspeciesTranslation> Translations { get; set; } = new List<SubspeciesTranslation>();
	}

	///	<summary>
	///	Texts of a subspecies in one language (unique per subspecies and language).
	///	</summary>
	public class SubspeciesTranslation : ITranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid SubspeciesId { get; set; }
		public Subspecies Subspecies { get; set; } = null!;

		public LanguageCode Language { get; set; }

		//	Localized fields
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}