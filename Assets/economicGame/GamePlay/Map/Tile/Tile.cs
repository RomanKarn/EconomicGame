using System.Collections.Generic;

public abstract class Tile : ITikeProsses
{
	protected StorageResurs _storageResursConnetcIsTile;
	protected Bank _bank;
	protected DataTile _data;
	protected bool _haveRoud = false;

	public DataTile Data { get => _data; }

	public Tile(Coord cord, Bank bank, StorageResurs storageResurs)
	{
		_bank = bank;
		_storageResursConnetcIsTile = storageResurs;
		_data = new DataTile(cord);
	}

	public void PossesInTike()
	{
		ResursUpdate();
		UpdateCriateBilding();
		_data.Population.PossesInTike();
	}
	public Coord GetCoord()
	{
		return _data.Coord;
	}
	public int GetCollPepole()
	{
		return _data.Population.CollPepole;
	}
	public List<Bilding> GellAllBildInTile()
	{
		return _data.Bilds;
	}
	public void SetRegion(Region region)
	{
		_data.SetRegion(region);
	}
	public bool HaveRoad()
	{
		if (!_haveRoud)
		{
			foreach (var bild in _data.Bilds)
			{
				if (bild is RoadBilding)
				{
					_haveRoud = true;
					return _haveRoud;
				}
			}
			return false;
		}
		return true;
	}
	public Region GetRegion()
	{
		return _data.Region;
	}

	private void UpdateCriateBilding()
	{
		if (_data.ProssesBild.Count != 0)
		{
			var ferst = _data.ProssesBild[0];
			if (ferst.Criating(this))
			{
				if (ferst is BildingProducshion)
				{
					_data.AddBild((BildingProducshion)ferst);
				}
				else if (ferst is BildingResicling)
				{
					_data.AddBild((BildingResicling)ferst);
				}
				else
				{
					_data.AddBild((Bilding)ferst);
				}
				_data.DeletPossesBild(0);
			}
		}
	}

	private void ResursUpdate()
	{
		int pepole = 0;
		if (_data.Region == null)
		{
			pepole = _data.Population.CollPepole;
		}
		foreach (var bildingCriateOrResuclenRes in _data.Bilds)
		{
			if (bildingCriateOrResuclenRes is IOutputRes)
			{
				IOutputRes addRes = bildingCriateOrResuclenRes as IOutputRes;
				if (addRes != null)
				{
					if (_data.Region != null)
					{
						pepole = _data.Region.PepoleHave;
						addRes.AddBildingRes(_storageResursConnetcIsTile, pepole);
						_data.Region.GetPepolForWork(addRes.PopulationNeedForWork);
					}
					else
					{
						addRes.AddBildingRes(_storageResursConnetcIsTile, pepole);
						pepole -= addRes.PopulationNeedForWork;
					}
				}
			}
			if (bildingCriateOrResuclenRes is IResyclingRes)
			{
				IResyclingRes addRes = bildingCriateOrResuclenRes as IResyclingRes;
				if (addRes != null)
				{
					if (_data.Region != null)
					{
						pepole = _data.Region.PepoleHave;
						addRes.ResyclingRes(_storageResursConnetcIsTile, pepole);
						_data.Region.GetPepolForWork(addRes.PopulationNeedForWork);
					}
					else
					{
						addRes.ResyclingRes(_storageResursConnetcIsTile, pepole);
						pepole -= addRes.PopulationNeedForWork;
					}
				}
			}
		}
	}


	public abstract void CreatBilding(TypeBilding type);

}







