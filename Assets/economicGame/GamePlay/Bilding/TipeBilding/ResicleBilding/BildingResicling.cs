using System.Collections.Generic;
using System;

public class BildingResicling : Bilding, IResyclingRes
{
	protected int _populationNeedForWork;
	protected Dictionary<TipeResurs, int> _criateRes;
	protected Dictionary<TipeResurs, int> _recyclRes;
	public Dictionary<TipeResurs, int> CriateRes { get => _criateRes; }
	public Dictionary<TipeResurs, int> EnterRes { get => _recyclRes; }
	public int PopulationNeedForWork { get => _populationNeedForWork; }

	public void ResyclingRes(StorageResurs storegRes, int collNeedPopulashion)
	{
		if (PopulationNeedForWork <= collNeedPopulashion)
		{
			if (HaveResForRecyclin(storegRes))
			{
				foreach (var res in _criateRes)
				{
					storegRes.AddRes(res.Key, res.Value);
				}
				foreach (var res in _recyclRes)
				{
					storegRes.RedusRes(res.Key, res.Value);
				}
			}
			else
			{
				throw new Exception("Не достаток ресурсов для производства завод встал  " + _criateRes);
			}
		}
		else
		{
			throw new Exception("Не достаток людей  " + _criateRes);
		}
	}

	public bool HaveResForRecyclin(StorageResurs storegRes)
	{
		foreach (var res in _recyclRes)
		{
			if (storegRes.HowRes(res.Key) < res.Value)
			{
				return false;
				//TODO: Выдавать ошибку что не хватает ресурсов
			}
		}
		return true;
	}

	public BildingResicling() : base()
	{
		_criateRes = new();
		_recyclRes = new();
	}
	public BildingResicling(BildingData data, Dictionary<TipeResurs, int> recCriate, Dictionary<TipeResurs, int> recyclRes) : base(data)
	{
		_criateRes = recCriate;
		_recyclRes = recyclRes;
	}
}







