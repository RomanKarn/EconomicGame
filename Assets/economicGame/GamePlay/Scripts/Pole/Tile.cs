using System.Collections.Generic;

public class Tile
{
	List<Bilding> _bilds = new List<Bilding>();

	public Tile()
	{
		Bilding newBild = new Bilding();
		_bilds.Add(newBild);
	}

	public List<Resurs> GetResurs()
	{
		Dictionary<TipeResurs, int> resurses = new Dictionary<TipeResurs, int>();
		List<Resurs> returnRes = new List<Resurs>();
		foreach (Bilding bild in _bilds)
		{
			Resurs resBild = bild.GetResurs();
			if (resurses.ContainsKey(resBild.Name))
			{
				resurses[resBild.Name] += resBild.Coll;
			}
			else
			{
				resurses.Add(resBild.Name, resBild.Coll);
			}
		}

		foreach (var res in resurses)
		{
			Resurs oneRes = new Resurs();
			oneRes.Name = res.Key;
			oneRes.Coll = res.Value;
			returnRes.Add(oneRes);
		}
		return returnRes;
	}
}
