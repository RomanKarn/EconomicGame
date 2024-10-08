using System;

public class Bank
{
	private int _money;
	public Bank(ILoadMoneyInBank loadMoney)
	{
		_money = loadMoney.LoadMoney();
	}
	public int HowMoney()
	{
		return _money;
	}
	public void AddMoney(int coll)
	{
		if (coll >= 0)
		{
			_money += coll;
			return;
		}
		else
		{
			throw new Exception("Не возможно работать с отрицательными деньгами " + this.GetType() + " Колиичество денег " + coll);
		}
	}
	public void RedusMoney(int coll)
	{
		if (coll >= 0)
		{
			_money -= coll;
			if (_money < 0)
			{
				throw new Exception("В бюджете дыра, нужно срочно что-то делать" + this.GetType());
			}

			return;
		}
		throw new Exception("Не возможно работать с отрицательными деньгами" + this.GetType());
	}
}







