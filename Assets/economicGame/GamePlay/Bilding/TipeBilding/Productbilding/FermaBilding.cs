using System.Collections.Generic;

public class FermaBilding : BildingProducshion
{
	public FermaBilding() : base()
	{
		List<ResursesNeedForCriate> resforCriat = new List<ResursesNeedForCriate>()
		{
			{new ResursesNeedForCriate(TipeResurs.WOOD,5)}
		};
		BildingData data = new BildingData(resforCriat, 50, 5);
		_data = data;
		Dictionary<TipeResurs, int> criateRes = new()
		{
			{TipeResurs.FOOD,5}
		};
		_criateRes = criateRes;
		_populationNeedForWork = 10;
		//TODO:Сделать загрузку из файла
	}

}







