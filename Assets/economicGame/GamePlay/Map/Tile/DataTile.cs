using System.Collections.Generic;

public class DataTile
{
	protected Coord _coordTile = new Coord(0, 0);
	protected Region _region = null;
	protected ProvidePopulation _providePopulation = new();
	protected Population _population;
	protected List<TypeBilding> _canCriateBilding = new List<TypeBilding>();
	protected List<Bilding> _bilds = new List<Bilding>();
	protected List<IProssesCriating> _prossesBild = new List<IProssesCriating>();

	public Coord Coord { get => _coordTile; }
	public Region Region { get => _region; }
	public ProvidePopulation ProvidePopulation { get => _providePopulation; }
	public Population Population { get => _population; }
	public List<TypeBilding> CanCriateBilding { get => _canCriateBilding; }
	public List<Bilding> Bilds { get => _bilds; }
	public List<IProssesCriating> ProssesBild { get => _prossesBild; }


	public DataTile(Coord cord)
	{
		_coordTile = cord;
		_population = new(_providePopulation);
		//TODO: Должно загружаться из файла 
	}
	public DataTile(Coord cord, List<TypeBilding> canCriateBilding)
	{
		_coordTile = cord;
		_canCriateBilding = canCriateBilding;
		_population = new(_providePopulation);
		//TODO: Должно загружаться из файла 
	}

	public void SetCoord(Coord cord)
	{
		_coordTile = cord;
	}
	public void SetRegion(Region region)
	{
		_region = region;
	}

	public void AddMaxPopulashion(int coll)
	{
		AddMaxPopulashion(coll);
	}
	public void AddHospitalProvide(int coll)
	{
		AddHospitalProvide(coll);
	}
	public void AddSecuretyProvide(int coll)
	{
		AddSecuretyProvide(coll);
	}
	public void AddCompfortProvide(int coll)
	{
		AddCompfortProvide(coll);
	}

	public void AddBild(Bilding bilding)
	{
		_bilds.Add(bilding);
	}
	public void AddPossesBild(Bilding bilding)
	{
		_prossesBild.Add(bilding);
	}
	public void DeletPossesBild(int number)
	{
		_prossesBild.RemoveAt(number);
	}
}







