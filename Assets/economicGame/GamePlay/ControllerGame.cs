using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;


public static class Instrument
{
	public static Transform FindChildByName(Transform parent, string name)
	{
		foreach (Transform child in parent)
		{
			if (child.name == name)
			{
				return child;
			}

			Transform result = FindChildByName(child, name);
			if (result != null)
			{
				return result;
			}
		}
		return null;
	}
} 

public class UIRoot : MonoBehaviour //TODO: нужно прикрепить к префабам ui
{
	public GameObject UIRootObg {  get; private set; }
	private string _pathPrefab= "UI/Root/UIRoot";
	public UIRoot()
	{
		GameObject uiRoot = Resources.Load<GameObject>(_pathPrefab);
		if (uiRoot != null)
		{
			UIRootObg = Instantiate(uiRoot, Vector3.zero, Quaternion.identity);

			Transform childTransform = Instrument.FindChildByName(UIRootObg.transform, "Screens");

			if (childTransform != null)
			{
				foreach (Transform child in childTransform)
				{
					Destroy(child.gameObject);
				}
			}
		}
		else
		{
			throw new Exception("Не получается загрузить префаб");
		}
	}
}

public class UIGame : MonoBehaviour //TODO: нужно прикрепить к префабам ui
{
	public GameObject UIGameObg { get; private set; }
	public Action NextStep;
	private string _pathPrefab = "UI/UI/UIGame";
	private Dictionary<TipeResurs, UIResurs> _uiResuses = new Dictionary<TipeResurs, UIResurs>();
	public UIGame(UIRoot uiRoot)
	{
		GameObject uiGame = Resources.Load<GameObject>(_pathPrefab);
		if (uiGame != null)
		{
			UIGameObg = Instantiate(uiGame, Instrument.FindChildByName(uiRoot.transform, "Screens"));
		}
		else
		{
			throw new Exception("Не получается загрузить префаб");
		}

		InitButton();
		InitResurses();
	}

	public void UpdateResursesColl(Dictionary<TipeResurs, int> collResurses)
	{
		foreach(var resurs in collResurses)
		{
			TextMeshProUGUI uiResText = _uiResuses[resurs.Key].UITextColl;
			uiResText.text = resurs.Value.ToString();
		}
	}

	private void HandlerNextStep()
	{
		NextStep?.Invoke();
	}

	private void InitResurses()
	{
		foreach (TipeResurs resurs in Enum.GetValues(typeof(TipeResurs)))
		{
			UIResurs uIResurs = new UIResurs(this);
			_uiResuses.Add(resurs , uIResurs);
		}
	}
	private void InitButton()
	{
		Button buttonNextStep = Instrument.FindChildByName(UIGameObg.transform, "NextStep").gameObject.GetComponent<Button>();
		buttonNextStep.onClick.AddListener(HandlerNextStep); //TODO: нужно добавить onDestroi и отвязывать кнопку
	}
}

public class UIResurs : MonoBehaviour //TODO: нужно прикрепить к префабам ui
{
	public GameObject UIResObg { get; private set; }
	public TextMeshProUGUI UITextColl { get; private set; }
	private string _pathPrefab = "UI/UI/ResColl";

	public UIResurs(UIGame uiGame)
	{
		GameObject uiRes = Resources.Load<GameObject>(_pathPrefab);
		if (uiRes != null)
		{
			UIResObg = Instantiate(uiRes, Instrument.FindChildByName(uiGame.transform, "ResursPull"));
			UITextColl = Instrument.FindChildByName(UIResObg.transform, "Text").GetComponent<TextMeshProUGUI>();
		}
		else
		{
			throw new Exception("Не получается загрузить префаб");
		}
	}
}

public class ControllerGame : MonoBehaviour
{

}

public class Game
{
	public List<ITikeProsses> _prosses;
	public StorageResurs _resursStorag;
	public Market _market;
	public Bank _bank;
	public MapTiles _mapTile;
	public Game()
	{
		_resursStorag = new GlobalStoreg(new MocLoadRes());
		_prosses = new List<ITikeProsses>();
		_bank = new Bank(new MocLoadBank());
		_market = new Market(_resursStorag, _bank);
		_mapTile = new MapTiles(_bank, _resursStorag);
		_mapTile.GenerateMap(5, 5);

		foreach (Tile tile in _mapTile.GetListTile())
		{
			_prosses.Add(tile);
		}
		_prosses.Add(_mapTile);
		_prosses.Add(_market); //маркет нужно добовлять последним, поскольку он снимает ресурсы



	}
	public void OneTike()
	{
		try
		{
			foreach (ITikeProsses prosses in _prosses)
			{
				prosses.PossesInTike();
			}
			HowMoney();
			HowAllRes();
			HowTikeRes();
			HowTileForRegion();
		}
		catch (Exception e)
		{
			Console.Write(e.Message);
			Console.WriteLine();
		}
	}
	public void HowMoney()
	{
		Console.WriteLine(" Money: " + _bank.HowMoney());

	}

	public void HowTileForRegion()
	{
		HashSet<Region> regions = _mapTile.GetListRegions();
		foreach (var region in regions)
		{
			Console.Write("Tile in " + region.ToString());
			Console.WriteLine();
			foreach (var tile in region.TileInRegion)
			{
				Console.Write("Tile: " + tile.GetCoord().X + tile.GetCoord().Y);
				Console.WriteLine();
			}
		}
	}

	public void HowAllRes()
	{
		var allres = _resursStorag.CollAllResurs;
		foreach (var res in allres)
		{
			Console.Write(" Type res: " + res.Key + " Coll: " + res.Value);
		}
		Console.WriteLine();
	}
	public void HowTikeRes()
	{
		StorageMarketSellInTike resInTike = new(new MocLoadRes());
		foreach (Tile tile in _mapTile.GetListTile())
		{
			foreach (Bilding bilding in tile.GellAllBildInTile())
			{
				if (bilding is IOutputRes)
				{
					IOutputRes resurses = bilding as IOutputRes;
					foreach (var res in resurses.CriateRes)
					{
						resInTike.AddRes(res.Key, res.Value);
					}
				}
				if (bilding is IResyclingRes)
				{
					IResyclingRes resurses = bilding as IResyclingRes;
					foreach (var res in resurses.CriateRes)
					{
						resInTike.AddRes(res.Key, res.Value);
					}
					foreach (var res in resurses.EnterRes)
					{
						resInTike.RedusRes(res.Key, res.Value);
					}
				}
			}
		}
		foreach (var res in _market.HowSellResInTike())
		{
			resInTike.RedusRes(res.Key, res.Value);
		}
		foreach (var res in resInTike.CollAllResurs)
		{
			Console.Write(" Type res in Tike: " + res.Key + " Coll: " + res.Value);
		}
		Console.WriteLine();
	}
}

public class MocLoadPriseRes : ILoadResInStorag
{
	private Dictionary<TipeResurs, int> _resurs = new Dictionary<TipeResurs, int>();
	public Dictionary<TipeResurs, int> LoadRes()
	{
		foreach (TipeResurs resurs in Enum.GetValues(typeof(TipeResurs)))
		{
			_resurs.Add(resurs, 5);
		}
		return _resurs;
	}
}

public class MocLoadResSellInTike : ILoadResInStorag
{
	private Dictionary<TipeResurs, int> _resurs = new Dictionary<TipeResurs, int>();
	public Dictionary<TipeResurs, int> LoadRes()
	{
		foreach (TipeResurs resurs in Enum.GetValues(typeof(TipeResurs)))
		{
			_resurs.Add(resurs, 0);
		}
		return _resurs;
	}
}


public class MocLoadRes : ILoadResInStorag
{
	private Dictionary<TipeResurs, int> _resurs = new Dictionary<TipeResurs, int>();
	public Dictionary<TipeResurs, int> LoadRes()
	{
		foreach (TipeResurs resurs in Enum.GetValues(typeof(TipeResurs)))
		{
			_resurs.Add(resurs, 0);
		}
		return _resurs;
	}
}
public class MocLoadBank : ILoadMoneyInBank
{
	public int LoadMoney()
	{
		return 5000;
	}
}






