using RealmForge.Client.Components;
using RealmForge.Client.Localization;
using RealmForge.Shared.Characters;
using RealmForge.Shared.Rules;

namespace RealmForge.Client.Pages
{
	///	<summary>
	///	Attacks with what can join them: before rolling, the sheet asks which conditional features to use (Sneak Attack,
	///	Rage, Divine Smite with its slot, Hunter's Mark…); the automatic ones (Improved Divine Smite) are always added.
	///	</summary>
	public partial class CharacterSheet
	{
		//	The attack being prepared: null when the dialog is closed
		private sealed class AttackDraft
		{
			public required string Name { get; init; }
			public required int Bonus { get; init; }
			public required string Damage { get; init; }
			public required List<AttackRiders.Rider> Riders { get; init; }
			public HashSet<string> Chosen { get; } = new();
			public int SmiteLevel { get; set; } = 1;
			public bool UndeadOrFiend { get; set; }
			public bool Critical { get; set; }
		}

		private AttackDraft? attackDraft;

		private List<AttackRiders.Rider> RidersFor(ContextItem? item)
		{
			if (computed is null)
			{
				return new();
			}
			var concentration = ConcentrationSpell?.Key;
			return AttackRiders.For(computed, item, concentration);
		}

		//	Spell slot levels with a slot left, for Divine Smite
		private List<int> SmiteLevels => computed is null ? new() : Enumerable.Range(1, 9)
			.Where(l => computed.SpellSlots[l - 1] - SpentSlots(l) > 0)
			.ToList();

		private void AttackHit(string name, int bonus, string damage, ContextItem? item)
		{
			var riders = RidersFor(item);
			if (riders.Any(r => !r.Automatic))
			{
				OpenAttack(name, bonus, damage, riders);
				return;
			}
			Roll(name, bonus);
		}

		private void AttackDamage(string name, int bonus, string damage, ContextItem? item)
		{
			var riders = RidersFor(item);
			if (riders.Any(r => !r.Automatic))
			{
				OpenAttack(name, bonus, damage, riders);
				return;
			}
			RollAttackDamage(name, damage, riders.Where(r => r.Automatic).ToList(), 0, false, false);
		}

		private void OpenAttack(string name, int bonus, string damage, List<AttackRiders.Rider> riders)
		{
			attackDraft = new AttackDraft { Name = name, Bonus = bonus, Damage = damage, Riders = riders };
			if (SmiteLevels.FirstOrDefault() is > 0 and var lowest)
			{
				attackDraft.SmiteLevel = lowest;
			}
		}

		private void ToggleRider(string key)
		{
			if (attackDraft is null)
			{
				return;
			}
			if (!attackDraft.Chosen.Remove(key))
			{
				attackDraft.Chosen.Add(key);
			}
		}

		private bool PowerAttack => attackDraft is not null && attackDraft.Riders.Any(r => r.Kind == AttackRiders.Kind.PowerAttack && attackDraft.Chosen.Contains(r.Key));

		//	The attack roll with the chosen options (−5 for Great Weapon Master or Sharpshooter)
		private void RollDraftHit()
		{
			if (attackDraft is not { } draft)
			{
				return;
			}
			var penalty = PowerAttack ? -5 : 0;
			var (die, dice) = RollD20();
			var critical = die == 20;
			var note = critical ? UiText.RollCritical(Lang) : die == 1 ? UiText.RollFumble(Lang) : null;
			draft.Critical = critical;
			var label = penalty == 0 ? draft.Name : $"{draft.Name} · {UiText.RiderName("great-weapon-master", Lang)} −5";
			ShowRoll(new DiceRollResult(label, dice, draft.Bonus + penalty, die + draft.Bonus + penalty, note));
		}

		//	The damage with the chosen options; Divine Smite spends its slot
		private void RollDraftDamage()
		{
			if (attackDraft is not { } draft)
			{
				return;
			}
			var chosen = draft.Riders.Where(r => r.Automatic || draft.Chosen.Contains(r.Key)).ToList();
			var smite = chosen.FirstOrDefault(r => r.Kind == AttackRiders.Kind.SlotDice);
			var smiteDice = string.Empty;
			if (smite is not null)
			{
				if (!SmiteLevels.Contains(draft.SmiteLevel))
				{
					return;
				}
				ToggleSlot(draft.SmiteLevel, SpentSlots(draft.SmiteLevel));
				smiteDice = AttackRiders.SmiteDice(draft.SmiteLevel, draft.UndeadOrFiend);
			}
			RollAttackDamage(draft.Name, draft.Damage, chosen, PowerAttack ? 10 : 0, draft.Critical, smite is not null, smiteDice);
			attackDraft = null;
			Changed();
		}

		//	"1d8+3" plus the dice and bonuses of the riders; a critical hit doubles every die
		private void RollAttackDamage(string name, string damage, List<AttackRiders.Rider> riders, int power, bool critical, bool smite, string smiteDice = "")
		{
			var faces = new List<DieFace>();
			var modifier = power;
			var match = System.Text.RegularExpressions.Regex.Match(damage.Replace('−', '-'), @"^(\d+)d(\d+)\s*([+-]\s*\d+)?");
			if (match.Success)
			{
				AddDice(faces, int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value), critical);
				modifier += match.Groups[3].Success ? int.Parse(match.Groups[3].Value.Replace(" ", string.Empty)) : 0;
			}
			else if (int.TryParse(damage.Replace('−', '-'), out var flat))
			{
				modifier += flat;
			}
			var names = new List<string>();
			foreach (var rider in riders)
			{
				var dice = rider.Kind == AttackRiders.Kind.SlotDice ? smiteDice : rider.Dice;
				if (rider.Kind is AttackRiders.Kind.Dice or AttackRiders.Kind.SlotDice && DiceNotation.TryParse(dice, out var parsed))
				{
					foreach (var group in parsed.Groups)
					{
						AddDice(faces, group.Count, group.Sides, critical);
					}
				}
				if (rider.Kind == AttackRiders.Kind.Flat)
				{
					modifier += rider.Flat;
				}
				if (rider.Kind != AttackRiders.Kind.PowerAttack || power > 0)
				{
					names.Add(rider.Kind == AttackRiders.Kind.SlotDice ? $"{UiText.RiderName(rider.Key, Lang)} {dice}" : UiText.RiderName(rider.Key, Lang));
				}
			}
			var label = $"{name} · {UiText.LabelDamage(Lang)}" + (names.Count > 0 ? $" + {string.Join(", ", names)}" : string.Empty);
			ShowRoll(new DiceRollResult(label, faces, modifier, Math.Max(0, faces.Sum(f => f.Value) + modifier), critical ? UiText.RollCritical(Lang) : null));
		}

		private static void AddDice(List<DieFace> faces, int count, int size, bool critical)
		{
			for (var i = 0; i < Math.Min(count, 20) * (critical ? 2 : 1); i++)
			{
				faces.Add(new DieFace(size, Random.Shared.Next(1, size + 1)));
			}
		}
	}
}
