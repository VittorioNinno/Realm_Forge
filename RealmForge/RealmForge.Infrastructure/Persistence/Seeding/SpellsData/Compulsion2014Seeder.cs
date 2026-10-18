using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Compulsion (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class Compulsion2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "compulsion");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 4,
			School = SpellSchool.Enchantment,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "compulsion", "en"),
					Language = LanguageCode.En,
					Name = "Compulsion",
					CastingTime = "1 action",
					Range = "30 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = null,
					Description = "Creatures of your choice that you can see within range and that can hear you must make a Wisdom saving throw. A target automatically succeeds on this saving throw if it can't be charmed. On a failed save, a target is affected by this spell. Until the spell ends, you can use a bonus action on each of your turns to designate a direction that is horizontal to you. Each affected target must use as much of its movement as possible to move in that direction on its next turn. It can take any action before it moves. After moving in this way, it can make another Wisdom save to try to end the effect.\n\nA target isn't compelled to move into an obviously deadly hazard, such as a fire or a pit, but it will provoke opportunity attacks to move in the designated direction.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "compulsion", "it"),
					Language = LanguageCode.It,
					Name = "Compulsione",
					CastingTime = "1 azione",
					Range = "9 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = null,
					Description = "Le creature a scelta dell'incantatore entro gittata, che egli sia in grado di vedere e che possano sentirlo, devono effettuare un tiro salvezza su Saggezza. Un bersaglio supera automaticamente questo tiro salvezza se non può essere affascinato. Se lo fallisce, il bersaglio è influenzato da questo incantesimo. Finché l'incantesimo non termina, in ognuno dei suoi turni l'incantatore può usare un'azione bonus per designare una direzione orizzontale rispetto a sé. Nel suo turno successivo, ogni bersaglio influenzato deve usare quanto più movimento possibile per spostarsi in quella direzione. Può compiere qualsiasi azione prima di muoversi. Dopo essersi mosso in questo modo, può effettuare un altro tiro salvezza su Saggezza per tentare di porre fine all'effetto.\n\nUn bersaglio non è costretto a muoversi verso un pericolo palesemente mortale, come un fuoco o una fossa, ma provocherà attacchi di opportunità pur di muoversi nella direzione designata.",
					HigherLevels = null
				}
			}
		};
	}
}
