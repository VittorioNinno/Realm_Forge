using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Wind Wall (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class WindWall2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wind-wall");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 3,
			School = SpellSchool.Evocation,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Ranger },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wind-wall", "en"),
					Language = LanguageCode.En,
					Name = "Wind Wall",
					CastingTime = "1 action",
					Range = "120 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a tiny fan and a feather of exotic origin",
					Description = "A wall of strong wind rises from the ground at a point you choose within range. You can make the wall up to 50 feet long, 15 feet high, and 1 foot thick. You can shape the wall in any way you choose so long as it makes one continuous path along the ground. The wall lasts for the duration.\n\nWhen the wall appears, each creature within its area must make a Strength saving throw. A creature takes 3d8 bludgeoning damage on a failed save, or half as much damage on a successful one.\n\nThe strong wind keeps fog, smoke, and other gases at bay. Small or smaller flying creatures or objects can't pass through the wall. Loose, lightweight materials brought into the wall fly upward. Arrows, bolts, and other ordinary projectiles launched at targets behind the wall are deflected upward and automatically miss. (Boulders hurled by giants or siege engines, and similar projectiles, are unaffected.) Creatures in gaseous form can't pass through it.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "wind-wall", "it"),
					Language = LanguageCode.It,
					Name = "Muro di Vento",
					CastingTime = "1 azione",
					Range = "36 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un minuscolo ventaglio e una piuma di origine esotica",
					Description = "Un muro di vento forte si leva dal terreno in un punto entro gittata scelto dall'incantatore. L'incantatore può creare un muro lungo fino a 15 metri, alto 4,5 metri e spesso 30 cm. Può modellare il muro nel modo che preferisce, purché formi un unico percorso continuo lungo il terreno. Il muro dura per la durata.\n\nQuando il muro compare, ogni creatura nella sua area deve effettuare un tiro salvezza su Forza. Una creatura subisce 3d8 danni contundenti se fallisce il tiro salvezza, o la metà di quei danni se lo supera.\n\nIl vento forte tiene lontani nebbia, fumo e altri gas. Le creature volanti o gli oggetti di taglia Piccola o inferiore non possono attraversare il muro. I materiali leggeri e sciolti portati nel muro volano verso l'alto. Le frecce, i quadrelli e gli altri proiettili ordinari lanciati contro bersagli dietro il muro vengono deviati verso l'alto e mancano automaticamente il bersaglio. (I macigni scagliati dai giganti o dalle macchine d'assedio e i proiettili simili non ne sono influenzati.) Le creature in forma gassosa non possono attraversarlo.",
					HigherLevels = null
				}
			}
		};
	}
}
