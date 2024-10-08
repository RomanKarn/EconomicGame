using System;

public class GlobalStoreg : StorageResurs
{
	public GlobalStoreg(ILoadResInStorag loadRes) : base(loadRes) { }

	public override void AddRes(TipeResurs typeRes, int coll)
	{
		if (IsHaveRes(typeRes))
		{
			CollAllResurs[typeRes] += coll;
			return;
		}
		throw new Exception("Ошибка в добавлении колличества ресурсо,причина не извесна, в " + this.GetType());
	}
	public override void RedusRes(TipeResurs typeRes, int coll)
	{
		if (IsHaveRes(typeRes))
		{
			CollAllResurs[typeRes] -= coll;
			return;
		}
		throw new Exception("Ошибка в Удалении колличества ресурсо,причина не извесна, в " + this.GetType());
	}
}







