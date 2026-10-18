using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpellsData;

///	<summary>
///	Disguise Self (2014 ruleset). SRD 5.1 text (CC BY 4.0) in English; the Italian text is a RealmForge translation that uses the official Italian game terms.
///	</summary>
public static class DisguiseSelf2014Seeder
{
	public static readonly Guid SpellId = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "disguise-self");

	public static Spell Build()
	{
		return new Spell
		{
			Id = SpellId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Source = ContentSource.Srd51,
			Level = 1,
			School = SpellSchool.Illusion,
			Classes = new List<SpellcastingClass> { SpellcastingClass.Bard, SpellcastingClass.Sorcerer, SpellcastingClass.Wizard },
			Ritual = false,
			Concentration = false,
			Verbal = true,
			Somatic = true,
			Material = false,
			Translations = new List<SpellTranslation>
			{
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "disguise-self", "en"),
					Language = LanguageCode.En,
					Name = "Disguise Self",
					CastingTime = "1 action",
					Range = "Self",
					Duration = "1 hour",
					MaterialComponent = null,
					Description = "You make yourself—including your clothing, armor, weapons, and other belongings on your person—look different until the spell ends or until you use your action to dismiss it. You can seem 1 foot shorter or taller and can appear thin, fat, or in between. You can't change your body type, so you must adopt a form that has the same basic arrangement of limbs. Otherwise, the extent of the illusion is up to you.\n\nThe changes wrought by this spell fail to hold up to physical inspection. For example, if you use this spell to add a hat to your outfit, objects pass through the hat, and anyone who touches it would feel nothing or would feel your head and hair. If you use this spell to appear thinner than you are, the hand of someone who reaches out to touch you would bump into you while it was seemingly still in midair.\n\nTo discern that you are disguised, a creature can use its action to inspect your appearance and must succeed on an Intelligence (Investigation) check against your spell save DC.",
					HigherLevels = null
				},
				new SpellTranslation
				{
					Id = DeterministicGuid.ForSrd(RulesetVersion.Dnd5e_2014, "spell", "disguise-self", "it"),
					Language = LanguageCode.It,
					Name = "Camuffare Se Stesso",
					CastingTime = "1 azione",
					Range = "Incantatore",
					Duration = "1 ora",
					MaterialComponent = null,
					Description = "L'incantatore modifica il proprio aspetto (inclusi abiti, armatura, armi e altri oggetti che ha addosso) finché l'incantesimo non termina o finché non usa la sua azione per congedarlo. Può sembrare più basso o più alto di 30 cm e può apparire magro, grasso o una via di mezzo. Non può cambiare la propria struttura corporea, quindi deve assumere una forma con la stessa disposizione di base degli arti. Per il resto, la portata dell'illusione dipende da lui.\n\nI cambiamenti prodotti da questo incantesimo non resistono a un'ispezione fisica. Per esempio, se l'incantatore usa questo incantesimo per aggiungere un cappello al suo abbigliamento, gli oggetti attraversano il cappello e chiunque lo tocchi non sentirebbe nulla, oppure sentirebbe la testa e i capelli dell'incantatore. Se usa questo incantesimo per apparire più magro di quanto sia, la mano di chi cerca di toccarlo urterebbe il suo corpo mentre sembra ancora trovarsi a mezz'aria.\n\nPer accorgersi che l'incantatore è camuffato, una creatura può usare la sua azione per esaminarne l'aspetto e deve superare una prova di Intelligenza (Indagare) contro la CD del tiro salvezza degli incantesimi dell'incantatore.",
					HigherLevels = null
				}
			}
		};
	}
}
