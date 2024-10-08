using System.Collections.Generic;

public class MapTiles : ITikeProsses
{
	private Dictionary<Coord, Tile> _map = new();
	protected StorageResurs _resursStorag;
	protected Bank _bank;
	protected RegionPull _regions = new();

	public MapTiles(Bank bank, StorageResurs storageResurs)
	{
		_bank = bank;
		_resursStorag = storageResurs;
	}

	public void PossesInTike()
	{
		_regions.UpdateRegions(_map);
	}

	public void GenerateMap(int x, int y)
	{
		for (int i = 0; i < x; i++)
		{
			for (int j = 0; j < x; j++)
			{
				Coord newCord = new Coord(i, j);
				Tile tileCri = new NormalTiel(newCord, _bank, _resursStorag);
				_map.Add(newCord, tileCri);
			}
		}
		_regions.UpdateRegions(_map);
	}
	public HashSet<Region> GetListRegions()
	{
		return _regions.RegionsList;
	}
	public List<Tile> GetListTile()
	{
		List<Tile> tileList = new();
		foreach (var tile in _map)
		{
			tileList.Add(tile.Value);
		}
		return tileList;
	}
	public Dictionary<Coord, Tile> GetMap()
	{
		return _map;
	}
}







