using System.Collections.Generic;

public class Game
{
	public Dictionary<TipeResurs, int> _resurs = new Dictionary<TipeResurs, int>();
	private List<Tile> _tiels = new List<Tile>();

	public void OneTike()
	{
		Tile tileCri = new Tile();
		_tiels.Add(tileCri);
		foreach (Tile tile in _tiels)
		{
			List<Resurs> resursTiel = tile.GetResurs();
			foreach (Resurs resurs in resursTiel)
			{
				if (_resurs.ContainsKey(resurs.Name))
				{
					_resurs[resurs.Name] += resurs.Coll;
				}
				else
				{
					_resurs.Add(resurs.Name, resurs.Coll);
				}

			}
		}
	}
}
