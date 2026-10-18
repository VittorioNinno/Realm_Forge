using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Resilient Sphere (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class ResilientSphere2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "resilient-sphere");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Evocation,
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
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "resilient-sphere", "en"),
					Language = LanguageCode.En,
					Name = "Resilient Sphere",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a hemispherical piece of clear crystal and a matching hemispherical piece of gum arabic",
					Description = "A sphere of shimmering force encloses a creature or object of Large size or smaller within range. An unwilling creature must make a Dexterity saving throw. On a failed save, the creature is enclosed for the duration.\n\nNothing—not physical objects, energy, or other spell effects—can pass through the barrier, in or out, though a creature in the sphere can breathe there. The sphere is immune to all damage, and a creature or object inside can't be damaged by attacks or effects originating from outside, nor can a creature inside the sphere damage anything outside it.\n\nThe sphere is weightless and just large enough to contain the creature or object inside. An enclosed creature can use its action to push against the sphere's walls and thus roll the sphere at up to half the creature's speed. Similarly, the globe can be picked up and moved by other creatures.\n\nA disintegrate spell targeting the globe destroys it without harming anything inside it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "resilient-sphere", "it"),
					Language = LanguageCode.It,
					Name = "Sfera Elastica",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pezzo semisferico di cristallo trasparente e un pezzo semisferico corrispondente di gomma arabica",
					Description = "Una sfera di forza scintillante racchiude una creatura o un oggetto di taglia Grande o inferiore entro gittata. Una creatura non consenziente deve effettuare un tiro salvezza su Destrezza. Se lo fallisce, la creatura resta racchiusa nella sfera per la durata.\n\nNulla (né oggetti fisici, né energia, né effetti di altri incantesimi) può attraversare la barriera, né in entrata né in uscita, ma una creatura all'interno della sfera può respirarvi. La sfera è immune a tutti i danni, e una creatura o un oggetto al suo interno non può essere danneggiato da attacchi o effetti provenienti dall'esterno, né una creatura all'interno della sfera può danneggiare qualcosa all'esterno.\n\nLa sfera è priva di peso e grande appena quanto basta per contenere la creatura o l'oggetto al suo interno. Una creatura racchiusa può usare la sua azione per spingere contro le pareti della sfera e farla così rotolare fino a metà della propria velocità. Allo stesso modo, il globo può essere raccolto e spostato da altre creature.\n\nUn incantesimo disintegrazione che bersaglia il globo lo distrugge senza danneggiare ciò che si trova al suo interno.",
					HigherLevels = null
				}
			}
		};
	}
}
