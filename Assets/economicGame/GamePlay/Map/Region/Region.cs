using System.Collections.Generic;

public class Region
{
	private int _pepoleHave = 0;
	private List<Tile> _tileInRegion = new();

	public List<Tile> TileInRegion { get => _tileInRegion; }
	public int PepoleHave { get => _pepoleHave; }

	public void AddTileInRegin(Tile tile)
	{
		_tileInRegion.Add(tile);
	}
	public void GetPepolForWork(int needForWork)
	{
		_pepoleHave -= needForWork;
	}
	public void UpdateCollPepol()
	{
		_pepoleHave = 0;
		foreach (var tile in TileInRegion)
		{
			_pepoleHave += tile.GetCollPepole();
		}
	}
}







