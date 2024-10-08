using System.Collections.Generic;

public interface IOutputRes : IPopulationNeed
{
	public Dictionary<TipeResurs, int> CriateRes { get; }
	public void AddBildingRes(StorageResurs storegRes, int collNeedPopulashion);
}







