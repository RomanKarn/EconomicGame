using System.Collections.Generic;
using System;

public class Market : ITikeProsses
{
	private StorageResurs _storageGlobal;
	private StorageMarketSellInTike _sellInTike;
	private StorageMarketPriseRes _priseRes;
	private Bank _bank;

	public Market(StorageResurs storageGlobal, Bank bank)
	{
		_storageGlobal = storageGlobal;
		_bank = bank;
		_sellInTike = new StorageMarketSellInTike(new MocLoadResSellInTike());
		_priseRes = new StorageMarketPriseRes(new MocLoadPriseRes());
	}

	public void PossesInTike()
	{
		SellInTike();
	}

	public void SelectCollSellResursInTike(TipeResurs resurs, int coll)
	{
		_sellInTike.SetSellRes(resurs, coll);
	}

	public void SellOneGo(TipeResurs resurs, int coll)
	{
		if (_storageGlobal.HowRes(resurs) >= coll)
		{
			_storageGlobal.RedusRes(resurs, coll);
			int profit = _priseRes.HowRes(resurs) * coll;
			_bank.AddMoney(profit);
		}
		else
		{
			throw new Exception("Не хватает на одноразовую продажу" + resurs + "сделка отменяется");
		}
	}
	public Dictionary<TipeResurs, int> HowSellResInTike()
	{
		return _sellInTike.CollAllResurs;
	}
	private void SellInTike()
	{
		foreach (TipeResurs type in Enum.GetValues(typeof(TipeResurs)))
		{
			int resSell = _sellInTike.HowRes(type);
			if (resSell <= 0)
			{
				continue;
			}

			if (_storageGlobal.HowRes(type) >= resSell)
			{
				_storageGlobal.RedusRes(type, resSell);
				int profit = _priseRes.HowRes(type) * resSell;
				_bank.AddMoney(profit);
			}
			else
			{
				_sellInTike.ResetRes(type);
				throw new Exception("Не хватает на продажу " + type + " ресурсов торговля остановлена");
			}
		}
	}
}







