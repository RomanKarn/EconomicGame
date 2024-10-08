using System.Collections.Generic;

public class RoadBilding : Bilding
{
	private Tile _tile;
	private int _addMaxPouplashion;
	public RoadBilding(Tile tile) : base()
	{
		List<ResursesNeedForCriate> resforCriat = new List<ResursesNeedForCriate>();
		BildingData data = new BildingData(resforCriat, 100, 1);
		_data = data;
		_tile = tile;
		_addMaxPouplashion = 10;
		//TODO:Сделать загрузку из файла
	}
	public override bool CanStartCriatig(Bank collMoney, StorageResurs resAll)
	{
		foreach (Bilding bilding in _tile.GellAllBildInTile())
		{
			if (bilding is RoadBilding)
			{
				return false;
			}

		}

		if (collMoney.HowMoney() >= _data.Prise)
		{
			foreach (ResursesNeedForCriate needRes in _data.ResForCriat)
			{
				if (resAll.CollAllResurs[needRes.Name] <= needRes.Coll)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	protected override void AddSomfingInTileWhithEndBildin(Tile tile)
	{
		tile.Data.AddMaxPopulashion(_addMaxPouplashion);
	}

}







