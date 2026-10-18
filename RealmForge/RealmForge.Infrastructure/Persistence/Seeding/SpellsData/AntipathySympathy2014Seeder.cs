using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Antipathy/Sympathy (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class AntipathySympathy2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "antipathy-sympathy");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 8,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Druid, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "antipathy-sympathy", "en"),
					Language = LanguageCode.En,
					Name = "Antipathy/Sympathy",
					CastingTime = "1 hour",
					Range = "60 feet",
					Duration = "10 days",
					MaterialComponent = "either a lump of alum soaked in vinegar for the antipathy effect or a drop of honey for the sympathy effect",
					Description = "This spell attracts or repels creatures of your choice. You target something within range, either a Huge or smaller object or creature or an area that is no larger than a 200-foot cube. Then specify a kind of intelligent creature, such as red dragons, goblins, or vampires. You invest the target with an aura that either attracts or repels the specified creatures for the duration. Choose antipathy or sympathy as the aura's effect.\n\n***Antipathy.*** The enchantment causes creatures of the kind you designated to feel an intense urge to leave the area and avoid the target. When such a creature can see the target or comes within 60 feet of it, the creature must succeed on a Wisdom saving throw or become frightened. The creature remains frightened while it can see the target or is within 60 feet of it. While frightened by the target, the creature must use its movement to move to the nearest safe spot from which it can't see the target. If the creature moves more than 60 feet from the target and can't see it, the creature is no longer frightened, but the creature becomes frightened again if it regains sight of the target or moves within 60 feet of it.\n\n***Sympathy.*** The enchantment causes the specified creatures to feel an intense urge to approach the target while within 60 feet of it or able to see it. When such a creature can see the target or comes within 60 feet of it, the creature must succeed on a Wisdom saving throw or use its movement on each of its turns to enter the area or move within reach of the target. When the creature has done so, it can't willingly move away from the target.\n\nIf the target damages or otherwise harms an affected creature, the affected creature can make a Wisdom saving throw to end the effect, as described below.\n\n***Ending the Effect.*** If an affected creature ends its turn while not within 60 feet of the target or able to see it, the creature makes a Wisdom saving throw. On a successful save, the creature is no longer affected by the target and recognizes the feeling of repugnance or attraction as magical. In addition, a creature affected by the spell is allowed another Wisdom saving throw every 24 hours while the spell persists.\n\nA creature that successfully saves against this effect is immune to it for 1 minute, after which time it can be affected again.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "antipathy-sympathy", "it"),
					Language = LanguageCode.It,
					Name = "Antipatia/Simpatia",
					CastingTime = "1 ora",
					Range = "18 metri",
					Duration = "10 giorni",
					MaterialComponent = "un pezzo di allume imbevuto di aceto per l'effetto di antipatia, oppure una goccia di miele per l'effetto di simpatia",
					Description = "Questo incantesimo attira o respinge le creature scelte dall'incantatore. L'incantatore bersaglia qualcosa entro gittata: un oggetto o una creatura di taglia Enorme o inferiore, oppure un'area non più grande di un cubo con spigolo di 60 metri. Specifica poi un tipo di creatura intelligente, come i draghi rossi, i goblin o i vampiri. Infonde nel bersaglio un'aura che, per la durata, attira o respinge le creature specificate. Sceglie antipatia o simpatia come effetto dell'aura.\n\n***Antipatia.*** L'ammaliamento spinge le creature del tipo designato a provare un impulso irresistibile ad abbandonare l'area e a evitare il bersaglio. Quando una di queste creature è in grado di vedere il bersaglio o arriva entro 18 metri da esso, deve superare un tiro salvezza su Saggezza, altrimenti diventa spaventata. La creatura resta spaventata finché è in grado di vedere il bersaglio o si trova entro 18 metri da esso. Finché è spaventata dal bersaglio, la creatura deve usare il proprio movimento per spostarsi nel punto sicuro più vicino da cui non possa vedere il bersaglio. Se la creatura si allontana di più di 18 metri dal bersaglio e non è in grado di vederlo, non è più spaventata, ma lo diventa di nuovo se torna a vedere il bersaglio o si avvicina entro 18 metri da esso.\n\n***Simpatia.*** L'ammaliamento spinge le creature specificate a provare un impulso irresistibile ad avvicinarsi al bersaglio quando si trovano entro 18 metri da esso o sono in grado di vederlo. Quando una di queste creature è in grado di vedere il bersaglio o arriva entro 18 metri da esso, deve superare un tiro salvezza su Saggezza, altrimenti in ognuno dei suoi turni usa il proprio movimento per entrare nell'area o per portarsi a portata del bersaglio. Una volta fatto ciò, la creatura non può allontanarsi volontariamente dal bersaglio.\n\nSe il bersaglio infligge danni o nuoce in altro modo a una creatura influenzata, quest'ultima può effettuare un tiro salvezza su Saggezza per porre fine all'effetto, come descritto di seguito.\n\n***Fine dell'Effetto.*** Se una creatura influenzata termina il proprio turno mentre non si trova entro 18 metri dal bersaglio e non è in grado di vederlo, effettua un tiro salvezza su Saggezza. Se lo supera, il bersaglio non la influenza più e la creatura riconosce come magica la sensazione di repulsione o di attrazione. Inoltre, una creatura influenzata dall'incantesimo può effettuare un nuovo tiro salvezza su Saggezza ogni 24 ore finché l'incantesimo persiste.\n\nUna creatura che supera il tiro salvezza contro questo effetto ne è immune per 1 minuto, dopodiché può esserne influenzata di nuovo.",
					HigherLevels = null
				}
			}
		};
	}
}
