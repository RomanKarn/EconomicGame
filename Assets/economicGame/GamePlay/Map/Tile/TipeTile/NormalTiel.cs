using System.Collections.Generic;
using System;

public class NormalTiel : Tile
{
	public NormalTiel(Coord cord, Bank bank, StorageResurs storageResurs) : base(cord, bank, storageResurs)
	{
		List<TypeBilding> canCriateBilding = new List<TypeBilding>();
		canCriateBilding.Add(TypeBilding.FERMA); //TODO: Исправить
		canCriateBilding.Add(TypeBilding.WOODCRESH);
		canCriateBilding.Add(TypeBilding.ROAD);
		canCriateBilding.Add(TypeBilding.SAWMILL);
		_data = new DataTile(cord, canCriateBilding);
	}

	public override void CreatBilding(TypeBilding type)
	{
		if (_data.CanCriateBilding.Contains(type)) // проверка что в этом тайле можно строить такой тип зданий
		{
			Bilding bild = BildingFactory.CreateBilding(type, this);
			if (bild.CanStartCriatig(_bank, _storageResursConnetcIsTile))// проверка что здание можно построить
			{
				bild.PayForCriating(_bank, _storageResursConnetcIsTile);
				_data.AddPossesBild(bild);
			}
			else
			{
				throw new Exception("Не достаток ресурсов или денег " + this.GetType());
			}
		}
		else
		{
			throw new Exception("Мы не можем строить такой тип здания в этом тайле " + this.GetType());
		}

	}
}







