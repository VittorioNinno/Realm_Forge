using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Resilient Sphere (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ResilientSphere2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "resilient-sphere");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 4,
			School = SpellSchool.Abjuration,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "resilient-sphere", "en"),
					Language = LanguageCode.En,
					Name = "Resilient Sphere",
					CastingTime = "Action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a glass sphere",
					Description = "A shimmering sphere encloses a Large or smaller creature or object within range. An unwilling creature must succeed on a Dexterity saving throw or be enclosed for the duration.\n\nNothing—not physical objects, energy, or other spell effects—can pass through the barrier, in or out, though a creature in the sphere can breathe there. The sphere is immune to all damage, and a creature or object inside can't be damaged by attacks or effects originating from outside, nor can a creature inside the sphere damage anything outside it.\n\nThe sphere is weightless and just large enough to contain the creature or object inside. An enclosed creature can take an action to push against the sphere's walls and thus roll the sphere at up to half the creature's Speed. Similarly, the globe can be picked up and moved by other creatures.\n\nA *Disintegrate* spell targeting the globe destroys it without harming anything inside.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "resilient-sphere", "it"),
					Language = LanguageCode.It,
					Name = "Sfera Elastica",
					CastingTime = "Azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "una sfera di vetro",
					Description = "Una sfera scintillante racchiude una creatura o un oggetto di taglia Grande o inferiore entro gittata. Una creatura non consenziente deve superare un tiro salvezza su Destrezza, altrimenti rimane racchiusa per la durata.\n\nNulla (né oggetti fisici, né energia, né altri effetti magici) può attraversare la barriera, né dall'esterno né dall'interno, ma una creatura nella sfera può respirarvi. La sfera è immune a tutti i danni, e una creatura o un oggetto al suo interno non possono subire danni da attacchi o effetti originati all'esterno, né una creatura all'interno della sfera può danneggiare qualcosa all'esterno.\n\nLa sfera non ha peso ed è grande quanto basta per contenere la creatura o l'oggetto al suo interno. Una creatura racchiusa può effettuare un'azione per spingere contro le pareti della sfera e farla così rotolare fino a metà della propria velocità. Allo stesso modo, il globo può essere raccolto e spostato da altre creature.\n\nUn incantesimo *disintegrazione* che prende come bersaglio il globo lo distrugge senza danneggiare nulla al suo interno.",
					HigherLevels = null
				}
			}
		};
	}
}
