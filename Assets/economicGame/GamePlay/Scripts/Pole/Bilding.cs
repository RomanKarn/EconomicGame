public class Bilding
{
	Resurs _resursCriate = new Resurs();

	public Bilding(TipeResurs name = TipeResurs.FOOD, int coll = 1)
	{
		_resursCriate.Name = name;
		_resursCriate.Coll = coll;
	}

	public Resurs GetResurs()
	{
		return _resursCriate;
	}
}