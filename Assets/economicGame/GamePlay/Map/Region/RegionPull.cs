using System.Collections.Generic;

public class RegionPull
{
	private HashSet<Region> _regions = new();
	public HashSet<Region> RegionsList { get => _regions; }

	public void UpdateRegions(Dictionary<Coord, Tile> map)
	{
		foreach (var tile in map)
		{
			int x = tile.Key.X;
			int y = tile.Key.Y;
			if (!tile.Value.HaveRoad())
			{
				continue;
			}
			if (tile.Value.GetRegion() == null)
			{
				Region newRegion = new();
				_regions.Add(newRegion); //добовляем в пулл всех регионов
				newRegion.AddTileInRegin(tile.Value); // в сам регион добовляем этот такил
				tile.Value.SetRegion(newRegion); // в тайле указываем к какому он пренадлежит региону 
			}
			FindAndUpdateClouse(x, y, tile, map, 1, 0);
			FindAndUpdateClouse(x, y, tile, map, -1, 0);
			FindAndUpdateClouse(x, y, tile, map, 0, 1);
			FindAndUpdateClouse(x, y, tile, map, 0, -1);
		}
		foreach (var region in RegionsList)
		{
			region.UpdateCollPepol();
		}
	}
	private void FindAndUpdateClouse(int x, int y, KeyValuePair<Coord, Tile> tile, Dictionary<Coord, Tile> map, int cordClouseX, int cordClouseY)
	{
		if (map.ContainsKey(new Coord(x + cordClouseX, y + cordClouseY)))
		{
			Tile tileClose = map[new Coord(x + cordClouseX, y + cordClouseY)];
			if (tileClose.HaveRoad())
			{
				if (tileClose.GetRegion() != null)
				{
					if (tileClose.GetRegion() != tile.Value.GetRegion())
					{
						Region oldRegionForDelet = tileClose.GetRegion();
						foreach (var tileWhisRegion in oldRegionForDelet.TileInRegion)
						{
							//Это проблема зацикленной ссылки приходится добовлять и в таил регион и в регион таил
							tileWhisRegion.SetRegion(tile.Value.GetRegion());
							tile.Value.GetRegion().AddTileInRegin(tileWhisRegion);
						}
						_regions.Remove(oldRegionForDelet);
						oldRegionForDelet = null; //Надеюсь это последняя ссылка на объект 
												  //TODO: Проверить что объект удаляется 
					}
				}
				else
				{
					tile.Value.GetRegion().AddTileInRegin(tileClose);
					tileClose.SetRegion(tile.Value.GetRegion());
				}
			}
		}
	}
}







