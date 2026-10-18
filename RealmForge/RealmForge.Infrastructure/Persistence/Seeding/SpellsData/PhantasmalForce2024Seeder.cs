using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Phantasmal Force (2024 ruleset). SRD 5.2 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class PhantasmalForce2024Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "phantasmal-force");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Source = ContentSource.Srd52,
			Level = 2,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = true,
			Verbal = true,
			Somatic = true,
			Material = true,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "phantasmal-force", "en"),
					Language = LanguageCode.En,
					Name = "Phantasmal Force",
					CastingTime = "Action",
					Range = "60 feet",
					Duration = "Concentration, up to 1 minute",
					MaterialComponent = "a bit of fleece",
					Description = "You attempt to craft an illusion in the mind of a creature you can see within range. The target makes an Intelligence saving throw. On a failed save, you create a phantasmal object, creature, or other phenomenon that is no larger than a 10-foot Cube and that is perceivable only to the target for the duration. The phantasm includes sound, temperature, and other stimuli.\n\nThe target can take a Study action to examine the phantasm with an Intelligence (Investigation) check against your spell save DC. If the check succeeds, the target realizes that the phantasm is an illusion, and the spell ends.\n\nWhile affected by the spell, the target treats the phantasm as if it were real and rationalizes any illogical outcomes from interacting with it. For example, if the target steps through a phantasmal bridge and survives the fall, it believes the bridge exists and something else caused it to fall.\n\nAn affected target can even take damage from the illusion if the phantasm represents a dangerous creature or hazard. On each of your turns, such a phantasm can deal 2d8 Psychic damage to the target if it is in the phantasm's area or within 5 feet of the phantasm. The target perceives the damage as a type appropriate to the illusion.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2024, "spell", "phantasmal-force", "it"),
					Language = LanguageCode.It,
					Name = "Allucinazione di Forza",
					CastingTime = "Azione",
					Range = "18 metri",
					Duration = "Concentrazione, fino a 1 minuto",
					MaterialComponent = "un pezzetto di vello",
					Description = "L'incantatore tenta di creare un'illusione nella mente di una creatura entro gittata che è in grado di vedere. Il bersaglio effettua un tiro salvezza su Intelligenza. Se lo fallisce, l'incantatore crea un oggetto, una creatura o un altro fenomeno fantasmatico, non più grande di un cubo con spigolo di 3 metri e percepibile soltanto dal bersaglio per la durata. Il fantasma include suoni, temperatura e altri stimoli.\n\nIl bersaglio può effettuare l'azione di Studio per esaminare il fantasma con una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore. Se la prova riesce, il bersaglio si rende conto che il fantasma è un'illusione e l'incantesimo termina.\n\nFinché è influenzato dall'incantesimo, il bersaglio tratta il fantasma come se fosse reale e trova una spiegazione razionale per ogni conseguenza illogica dell'interazione con esso. Per esempio, se il bersaglio attraversa un ponte fantasmatico e sopravvive alla caduta, crede che il ponte esista e che qualcos'altro lo abbia fatto cadere.\n\nUn bersaglio influenzato può persino subire danni dall'illusione, se il fantasma rappresenta una creatura o un pericolo minaccioso. In ognuno dei turni dell'incantatore, un tale fantasma può infliggere 2d8 danni psichici al bersaglio, se questo si trova nell'area del fantasma o entro 1,5 metri da esso. Il bersaglio percepisce i danni come di un tipo appropriato all'illusione.",
					HigherLevels = null
				}
			}
		};
	}
}
