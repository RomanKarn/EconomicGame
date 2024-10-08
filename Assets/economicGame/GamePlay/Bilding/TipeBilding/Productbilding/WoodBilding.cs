using System.Collections.Generic;

public class WoodBilding : BildingProducshion
{
	public WoodBilding() : base()
	{
		List<ResursesNeedForCriate> resforCriat = new List<ResursesNeedForCriate>();
		BildingData data = new BildingData(resforCriat, 100, 5);
		_data = data;
		Dictionary<TipeResurs, int> criateRes = new()
		{
			{TipeResurs.WOOD,10}
		};
		_criateRes = criateRes;
		_populationNeedForWork = 30;
		//TODO:Сделать загрузку из файла
	}
}







