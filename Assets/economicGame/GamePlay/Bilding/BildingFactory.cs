using System;

public static class BildingFactory
{
	public static Bilding CreateBilding(TypeBilding type, Tile tile)
	{
		switch (type)
		{
			case TypeBilding.FERMA:
				return new FermaBilding();
			case TypeBilding.WOODCRESH:
				return new WoodBilding();
			case TypeBilding.SAWMILL:
				return new SawmillBilding();
			case TypeBilding.ROAD:
				return new RoadBilding(tile);
			case TypeBilding.IRONMINE:
				throw new ArgumentException("Invalid building type"); //TODO: Исправить
			default:
				throw new ArgumentException("Invalid building type");
		}
	}
}







