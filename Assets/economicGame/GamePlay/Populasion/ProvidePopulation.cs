public class ProvidePopulation
{
	private int _maxPopulationInTile = 1;
	private int _hospitalProvide = 1;
	private int _securetyProvide = 1;
	private int _compfortProvide = 1;

	public int MaxPopulationInTile { get => _maxPopulationInTile; }
	public int HospitalProvide { get => _hospitalProvide; }
	public int SecuretyProvide { get => _securetyProvide; }
	public int CompfortProvide { get => _compfortProvide; }

	public void AddMaxPopulashion(int coll)
	{
		_maxPopulationInTile += coll;
	}
	public void AddHospitalProvide(int coll)
	{
		_hospitalProvide += coll;
	}
	public void AddSecuretyProvide(int coll)
	{
		_securetyProvide += coll;
	}
	public void AddCompfortProvide(int coll)
	{
		_compfortProvide += coll;
	}
}







