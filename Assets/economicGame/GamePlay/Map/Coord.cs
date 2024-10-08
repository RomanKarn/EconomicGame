using System;

public class Coord
{
	public Coord(int x, int y)
	{
		X = x;
		Y = y;
	}
	public int X { get; set; }
	public int Y { get; set; }

	public override bool Equals(object obj)
	{
		if (obj is Coord other)
		{
			return X == other.X && Y == other.Y;
		}
		return false;
	}
	public override int GetHashCode()
	{
		return HashCode.Combine(X, Y);
	}
}







