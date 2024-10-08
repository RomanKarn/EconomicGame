using System.Collections.Generic;

public interface IResyclingRes : IPopulationNeed
{
	public Dictionary<TipeResurs, int> CriateRes { get; }
	public Dictionary<TipeResurs, int> EnterRes { get; }
	public void ResyclingRes(StorageResurs storegRes, int collNeedPopulashion);
	public bool HaveResForRecyclin(StorageResurs storegRes);
}







