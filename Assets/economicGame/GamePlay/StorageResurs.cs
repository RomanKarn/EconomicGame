using System.Collections.Generic;
using System;

public abstract class StorageResurs
{
	public Dictionary<TipeResurs, int> CollAllResurs { get; protected set; }

	public StorageResurs(ILoadResInStorag loadRes)
	{
		CollAllResurs = new Dictionary<TipeResurs, int>();
		Dictionary<TipeResurs, int> ladingRes = loadRes.LoadRes();
		foreach (var resurs in ladingRes)
		{
			CollAllResurs.Add(resurs.Key, resurs.Value);
		}
	}

	public int HowRes(TipeResurs typeRes)
	{
		if (IsHaveRes(typeRes))
		{
			int collRes = CollAllResurs[typeRes];
			return collRes;
		}
		throw new Exception("Ошибка в получении колличества ресурсо,причина не извесна, в" + this.GetType());
	}
	public void ResetRes(TipeResurs typeRes)
	{
		if (IsHaveRes(typeRes))
		{
			CollAllResurs[typeRes] = 0;
			return;
		}
		throw new Exception("Ошибка в сбросе колличества ресурсов к нулю,причина не извесна, в" + this.GetType());
	}

	public abstract void AddRes(TipeResurs typeRes, int coll);
	public abstract void RedusRes(TipeResurs typeRes, int coll);

	protected bool IsHaveRes(TipeResurs typeRes)
	{
		if (!CollAllResurs.ContainsKey(typeRes))
		{
			throw new Exception(typeRes + " не существует в " + this.GetType());
		}
		return true;
	}
}







