using System.Collections.Generic;

public class BildingData
{
	protected List<ResursesNeedForCriate> _resForCriat = new List<ResursesNeedForCriate>();
	protected int _prise;
	protected int _baseTimeNeedForCriateBilding;

	public List<ResursesNeedForCriate> ResForCriat { get => _resForCriat; }
	public int Prise { get => _prise; }
	public int BaseTimeNeedForCriate { get => _baseTimeNeedForCriateBilding; }

	public BildingData()
	{
		_resForCriat = new List<ResursesNeedForCriate>();
		_prise = 0;
		_baseTimeNeedForCriateBilding = 0;
	}
	public BildingData(List<ResursesNeedForCriate> resforCriat,
					   int prise,
					   int baseTimeNeedForCriateBilding)
	{
		_resForCriat = resforCriat;
		_prise = prise;
		_baseTimeNeedForCriateBilding = baseTimeNeedForCriateBilding; //TODO: По хорошему это должно откуда-то загружаться
	}
}







