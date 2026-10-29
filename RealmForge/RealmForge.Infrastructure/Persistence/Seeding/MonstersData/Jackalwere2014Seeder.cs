using RealmForge.Domain.Entities;
using RealmForge.Shared.Enums;
using static RealmForge.Infrastructure.Persistence.Seeding.MonsterSeeder;

namespace RealmForge.Infrastructure.Persistence.Seeding.MonstersData;

///	<summary>
///	Jackalwere (2014 ruleset). Monster Manual statblock outside the SRD: numbers and official names from the book, texts written for RealmForge.
///	</summary>
public static class Jackalwere2014Seeder
{
	public static Monster Build() => Create("jackalwere", null, ContentSource.RealmForge, CreatureSize.Medium, CreatureType.Humanoid,
		12, 18, "4d8", 40, new[] { 11, 15, 11, 13, 11, 10 }, 0.5m, 100, 2, 12,
		new Text(
			"Sciacallo mannaro",
			null,
			"Umanoide Medio (umano, mutaforma), caotico malvagio",
			"12",
			"12 m",
			"",
			"Furtività +4, Inganno +4, Percezione +2",
			"",
			"",
			"contundenti, perforanti e taglienti da attacchi non magici con armi non argentate",
			"",
			"Percezione passiva 12",
			"Comune (non può parlare in forma di sciacallo)",
			"***Mutaforma.*** Con un'azione, lo sciacallo mannaro può assumere l'aspetto di un determinato umano di taglia Media o di un ibrido sciacallo-umanoide, o tornare alla sua vera forma, uno sciacallo Piccolo. A parte la taglia le sue statistiche non cambiano, e ciò che indossa o trasporta non si trasforma. Quando muore torna alla sua vera forma.\n\n***Udito e olfatto acuti.*** Lo sciacallo mannaro dispone di vantaggio alle prove di Saggezza (Percezione) basate sull'udito o sull'olfatto.\n\n***Tattiche del branco.*** Lo sciacallo mannaro dispone di vantaggio al tiro per colpire contro una creatura se almeno uno dei suoi alleati si trova entro 1,5 metri da essa e non è incapacitato.",
			"***Morso (solo in forma di sciacallo o ibrida).*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 4 (1d4 + 2) danni perforanti.\n\n***Scimitarra (solo in forma umana o ibrida).*** *Attacco con arma da mischia:* +4 al tiro per colpire, portata 1,5 m, un bersaglio. *Colpito:* 5 (1d6 + 2) danni taglienti.\n\n***Sguardo soporifero.*** Lo sciacallo mannaro fissa una creatura che è in grado di vedere entro 9 metri da lui, che effettua un tiro salvezza su Saggezza con CD 10. Se lo fallisce cade in un sonno magico, priva di sensi per 10 minuti o finché qualcuno non usa un'azione per scuoterla. Una creatura che lo supera è immune allo sguardo di questo sciacallo mannaro per 24 ore. I non morti e le creature immuni alla condizione affascinato non ne sono toccati.",
			"",
			"",
			"",
			""),
		new Text(
			"Jackalwere",
			null,
			"Medium humanoid (human, shapechanger), chaotic evil",
			"12",
			"40 ft.",
			"",
			"Deception +4, Perception +2, Stealth +4",
			"",
			"",
			"bludgeoning, piercing, and slashing from nonmagical attacks that aren't silvered",
			"",
			"passive Perception 12",
			"Common (can't speak in jackal form)",
			"***Shapechanger.*** As an action, the jackalwere can take the shape of a specific Medium human or of a jackal-humanoid hybrid, or return to its true form, a Small jackal. Apart from its size its statistics don't change, and what it wears or carries isn't transformed. It returns to its true form when it dies.\n\n***Keen Hearing and Smell.*** The jackalwere has advantage on Wisdom (Perception) checks that rely on hearing or smell.\n\n***Pack Tactics.*** The jackalwere has advantage on an attack roll against a creature if at least one of the jackalwere's allies is within 5 feet of the creature and the ally isn't incapacitated.",
			"***Bite (Jackal or Hybrid Form Only).*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 4 (1d4 + 2) piercing damage.\n\n***Scimitar (Human or Hybrid Form Only).*** *Melee Weapon Attack:* +4 to hit, reach 5 ft., one target. *Hit:* 5 (1d6 + 2) slashing damage.\n\n***Sleep Gaze.*** The jackalwere stares at a creature it can see within 30 feet of it, which makes a DC 10 Wisdom saving throw. On a failure it falls into a magical sleep, unconscious for 10 minutes or until someone uses an action to shake it awake. A creature that succeeds is immune to this jackalwere's gaze for 24 hours. Undead and creatures immune to being charmed are unaffected.",
			"",
			"",
			"",
			""));
}
