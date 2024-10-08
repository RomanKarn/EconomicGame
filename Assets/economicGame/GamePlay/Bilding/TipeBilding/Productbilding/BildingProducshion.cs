using System.Collections.Generic;
using System;

public class BildingProducshion : Bilding, IOutputRes
{
	protected int _populationNeedForWork;
	protected Dictionary<TipeResurs, int> _criateRes;
	public Dictionary<TipeResurs, int> CriateRes { get => _criateRes; }
	public int PopulationNeedForWork { get => _populationNeedForWork; }

	public BildingProducshion() : base()
	{
		_criateRes = new();
	}
	public BildingProducshion(BildingData data, Dictionary<TipeResurs, int> recCriate) : base(data)
	{
		_criateRes = recCriate;
	}
	public void AddBildingRes(StorageResurs storegRes, int collNeedPopulashion)
	{
		if (PopulationNeedForWork <= collNeedPopulashion)
		{
			foreach (var res in _criateRes)
			{
				storegRes.AddRes(res.Key, res.Value);
			}
		}
		else
		{
			Console.Write("Не хватает людей для работы " + collNeedPopulashion);
		}
	}
}







