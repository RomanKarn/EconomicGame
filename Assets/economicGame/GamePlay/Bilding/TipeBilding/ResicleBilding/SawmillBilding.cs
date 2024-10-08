using System.Collections.Generic;

public class SawmillBilding : BildingResicling
{

	public SawmillBilding() : base()
	{
		List<ResursesNeedForCriate> resforCriat = new List<ResursesNeedForCriate>();
		BildingData data = new BildingData(resforCriat, 100, 5);
		_data = data;
		Dictionary<TipeResurs, int> criateRes = new()
		{
			{TipeResurs.BOARD,10}
		};
		_criateRes = criateRes;

		Dictionary<TipeResurs, int> recyclRes = new()
		{
			{TipeResurs.WOOD,15}
		};
		_recyclRes = recyclRes;
		_populationNeedForWork = 30;
		//TODO:Сделать загрузку из файла
	}


}







