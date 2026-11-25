namespace RealmForge.Shared.Characters;

///	<summary>
///	The coins of a party shared out: each character gets the same share of every coin; what does not divide evenly is
///	changed into smaller coins (gold, silver, copper) and shared again; the last copper pieces stay in the chest.
///	</summary>
public static class TreasureRules
{
	public static (CoinPurse Each, CoinPurse Left) Split(CoinPurse pool, int shares)
	{
		if (shares <= 0)
		{
			return (new CoinPurse(), Copy(pool));
		}
		var each = new CoinPurse
		{
			Pp = pool.Pp / shares,
			Gp = pool.Gp / shares,
			Ep = pool.Ep / shares,
			Sp = pool.Sp / shares,
			Cp = pool.Cp / shares
		};

		//	The coins left over, changed into copper and shared again in gold, silver and copper
		var rest = pool.Pp % shares * 1000 + pool.Gp % shares * 100 + pool.Ep % shares * 50 + pool.Sp % shares * 10 + pool.Cp % shares;
		var share = rest / shares;
		each.Gp += share / 100;
		each.Sp += share % 100 / 10;
		each.Cp += share % 10;
		var left = new CoinPurse { Cp = rest - share * shares };
		return (each, left);
	}

	public static void Add(CoinPurse purse, CoinPurse more)
	{
		purse.Pp += more.Pp;
		purse.Gp += more.Gp;
		purse.Ep += more.Ep;
		purse.Sp += more.Sp;
		purse.Cp += more.Cp;
	}

	public static CoinPurse Copy(CoinPurse p) => new() { Pp = p.Pp, Gp = p.Gp, Ep = p.Ep, Sp = p.Sp, Cp = p.Cp };
}
