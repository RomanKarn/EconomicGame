public abstract class Bilding : IProssesCriating //TODO: Разделить бильдинг на продуктовую инфраструктурную и заводы 
{

	protected BildingData _data;
	protected bool _startCriat = false;
	protected int _prosses = 0;
	public Bilding()
	{
		_data = new BildingData();
	}
	public Bilding(BildingData data)
	{
		_data = data;
	}

	public void PayForCriating(Bank collMoney, StorageResurs resAll)
	{
		collMoney.RedusMoney(_data.Prise);
		foreach (ResursesNeedForCriate needRes in _data.ResForCriat)
		{
			resAll.RedusRes(needRes.Name, needRes.Coll);
		}
	}

	public virtual bool CanStartCriatig(Bank collMoney, StorageResurs resAll)
	{
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

	public bool Criating(Tile tile)
	{
		if (!IsBild())
		{
			_prosses++;
			return false;
		}
		AddSomfingInTileWhithEndBildin(tile);
		return true;
	}
	protected virtual void AddSomfingInTileWhithEndBildin(Tile tile) { }

	protected bool IsBild()
	{
		if (_prosses >= _data.BaseTimeNeedForCriate)
		{
			return true;
		}
		return false;
	}

}







